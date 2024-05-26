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
        public List<ProcessControlBlock> readyQueue;
        public List<ProcessControlBlock> jobQueue;
        public taskStatus taskStatus;
        public algo schedulingAlgorithm { get; set; }
        public int currentTime;

        public MemoryManager memoryManager;

        public TaskManager() { 
            readyQueue = new List<ProcessControlBlock>();
            jobQueue = new List<ProcessControlBlock>();
            currentTime = 0;
            taskStatus = taskStatus.PAUSE;
            memoryManager = new MemoryManager();
        }

        public void GenerateProcesses(int numProcesses)
        {
            Random random = new Random();
            for (int i = 0; i < numProcesses; i++)
            {
                ProcessControlBlock pcb = CreateProcess(nextPID++, random);
                jobQueue.Add(pcb);
            }
        }

        private ProcessControlBlock CreateProcess(int pID, Random random)
        {
            return new ProcessControlBlock(
                pID,
                random.Next(1, 10), // Burst Time
                random.Next(1, 10), // Arrival Time
                random.Next(1, 10), // Priority Level
                random.Next(2, 8), // Memory Size
                status.NEW // Set initial state to NEW
            );
        }

        private void AdmitJobQueue()
        {

            jobQueue.Sort((pcb1, pcb2) => pcb1.arrivalTime.CompareTo(pcb2.arrivalTime));

            foreach (var pcb in jobQueue.ToList())
            {
                if(pcb.arrivalTime <= currentTime && memoryManager.AllocateMemory(pcb.memorySize, out MemorySegment segment))
                {
                    pcb.Segment = segment;
                    pcb.state = status.READY;
                    readyQueue.Add(pcb);
                    jobQueue.Remove(pcb);
                }
                else
                {
                    break; 
                }
            }
        }

        public void Execute()
        {
            int index;
            currentTime++;

            AdmitJobQueue();

            switch (schedulingAlgorithm)
            {
                case algo.FIFO: 
                    FIFO fifo = new FIFO();
                    // ProcessControlBlock current_pcb = readyQueue[0];
                    index = fifo.GetEarliest(readyQueue, currentTime);
                    if (index != -1) 
                    {
                        ProcessControlBlock currentProcess = readyQueue[index];

                        readyQueue[index] = fifo.Run(currentProcess);
                        if (readyQueue[index].state == status.TERMINATED)
                        {
                            memoryManager.DeallocateMemory(readyQueue[index].Segment);
                            readyQueue.RemoveAt(index);
                        }
                    }
                    break;
                case algo.SJF:
                    SJF sjf = new SJF();
                    index = sjf.GetShortest(readyQueue, currentTime);
                    if (index != -1)
                    {
                        // ProcessControlBlock currentProcess = readyQueue[index];

                        readyQueue[index] = sjf.Run(index, ref readyQueue);

                        if (readyQueue[index].state == status.TERMINATED)
                        {
                            memoryManager.DeallocateMemory(readyQueue[index].Segment);
                            readyQueue.RemoveAt(index);
                        }
                    }
                    break;
                case algo.PRIO:
                    PRIO prio = new PRIO();
                    index = prio.PrioritizeProcess(readyQueue, currentTime);
                    if (index != -1)
                    {
                        readyQueue[index] = prio.Run(index, ref readyQueue);

                        if (readyQueue[index].state == status.TERMINATED)
                        {
                            memoryManager.DeallocateMemory(readyQueue[index].Segment);
                            readyQueue.RemoveAt(index);
                        }
                    }

                    break;
                case algo.RRR:
                    RRR rr = new RRR(4);

                    if (rr.ifTimeToQuantum(currentTime))
                    {
                        index = rr.GetEarliest(readyQueue, currentTime);
                        ProcessControlBlock process = new ProcessControlBlock(
                            readyQueue[index].pID,
                            readyQueue[index].burstTime, // Burst Time
                            currentTime, // Arrival Time
                            readyQueue[index].priority, // Priority Level
                            readyQueue[index].memorySize, 
                            status.READY // Set initial state to Ready
                        );

                        // transfer katong segment data from readyqueue[index] to process
                        memoryManager.DeallocateMemory(readyQueue[index].Segment);
                        readyQueue.RemoveAt(index);

                        if(memoryManager.AllocateMemory(process.memorySize, out MemorySegment segment))
                        {
                            process.Segment = segment;
                        }
                        readyQueue.Add(process);
                    }

                    index = rr.GetEarliest(readyQueue, currentTime);
                    if (index != -1)
                    {
                        ProcessControlBlock currentProcess = readyQueue[index];
                        readyQueue[index] = rr.Run(currentProcess);

                        if (readyQueue[index].state == status.TERMINATED)
                        {
                            memoryManager.DeallocateMemory(readyQueue[index].Segment);
                            readyQueue.RemoveAt(index);
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
