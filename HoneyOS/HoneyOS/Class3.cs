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
        public algo schedulingAlgorithm;
        public int currentTime; 

        public TaskManager() { 
            processes = new List<ProcessControlBlock>();
            currentTime = 0;
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
                random.Next(0, 10), // Arrival Time
                random.Next(1, 10), // Burst Time
                random.Next(0, 10), // Priority Level
                status.READY // Set initial state to Ready
            );
        }

        // this is still bootleg version for testing purposes 
        public void Execute()
        {
            switch (schedulingAlgorithm)
            {
                case algo.FIFO: 
                    FIFO fifo = new FIFO();
                    if (processes.Count > 0)
                    {
                        SimulateTimePassage();
                        // ProcessControlBlock current_pcb = processes[0];
                        processes[0] = fifo.Run(processes[0]);

                        if (processes[0].state == status.TERMINATED & processes.Count > 0)
                        {
                            processes.RemoveAt(0);
                        }
                    }
                    break;
            }
        }
        public void SimulateTimePassage()
        {
            currentTime += 1; // Simulate 5-second delay
            Thread.Sleep(2000);
            // scheduler.Run(currentTime); // Run the scheduler with current time
        }
    }

    public enum taskStatus
    {
        PLAY, 
        PAUSE, 
        STOP
    }
}
