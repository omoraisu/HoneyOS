using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace HoneyOS
{
    public class TaskManager
    {
        private static int nextPID = 0; // keeps track of the next available pID 
        public List<ProcessControlBlock> processes;
        public taskStatus taskStatus;
        public algo schedulingAlgorithm { get; set; }
        public int currentTime; 

        public TaskManager() { 
            processes = new List<ProcessControlBlock>();
            currentTime = 0;
            taskStatus = taskStatus.PAUSE;
        }

        public void GenerateProcesses(int numProcesses)
        {
            Random random = new Random();
            for (int i = 0; i < numProcesses; i++)
            {
                processes.Add(CreateProcess(nextPID++, random));
            }
        }

        private ProcessControlBlock CreateProcess(int pID, Random random)
        {
            return new ProcessControlBlock(
                pID,
                random.Next(1, 10), // Burst Time
                random.Next(0, 10), // Arrival Time
                random.Next(0, 10), // Priority Level
                status.READY // Set initial state to Ready
            );
        }

        // this is still bootleg version for testing purposes 
        public void Execute()
        {
            int index;
            currentTime++;
            switch (schedulingAlgorithm)
            {
                case algo.FIFO: 
                    FIFO fifo = new FIFO();
                    // ProcessControlBlock current_pcb = processes[0];
                    index = fifo.GetEarliest(processes, currentTime);
                    if (index != -1) 
                    {
                        ProcessControlBlock currentProcess = processes[index];

                        processes[index] = fifo.Run(currentProcess);
                        if (processes[index].state == status.TERMINATED)
                        {
                            processes.RemoveAt(index);
                        }
                    }
                    break;
                case algo.SJF:
                    SJF sjf = new SJF();
                    index = sjf.GetShortest(processes, currentTime);
                    if (index != -1)
                    {
                        ProcessControlBlock currentProcess = processes[index];

                        processes[index] = sjf.Run(currentProcess);
                        if (processes[index].state == status.TERMINATED)
                        {
                            processes.RemoveAt(index);
                        }
                    }
                    break;
                case algo.PRIO:
                    PRIO PRIO = new PRIO();
                    index = PRIO.PrioritizeProcess(processes, currentTime);
                    if (index != -1)
                    {
                        ProcessControlBlock currentProcess = processes[index];

                        processes[index] = PRIO.Run(currentProcess);
                        if (processes[index].state == status.TERMINATED)
                        {
                            processes.RemoveAt(index);
                        }
                    }

                    break;
                case algo.RRR:
                    RRR rr = new RRR(4);

                    if (rr.ifTimeToQuantum(currentTime))
                    {
                        index = rr.GetEarliest(processes, currentTime);
                        ProcessControlBlock process = new ProcessControlBlock(
                            processes[index].pID,
                            processes[index].burstTime, // Burst Time
                            currentTime, // Arrival Time
                            processes[index].priority, // Priority Level
                            status.READY // Set initial state to Ready
                        );

                        processes.Add(process);
                        processes.RemoveAt(index);
                    }

                    index = rr.GetEarliest(processes, currentTime);
                    if (index != -1)
                    {
                        ProcessControlBlock currentProcess = processes[index];
                        processes[index] = rr.Run(currentProcess);

                        if (processes[index].state == status.TERMINATED)
                        {
                            processes.RemoveAt(index);
                        }
                    }
                    break;
            }
        }
    }

    public enum taskStatus
    {
        PLAY, 
        PAUSE, 
        STOP
    }

}
