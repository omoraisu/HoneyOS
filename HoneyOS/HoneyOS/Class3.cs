using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace HoneyOS
{
    public class TaskManager
    {
        // Lists for the Job and Ready Queues
        public List<ProcessControlBlock> readyQueue;
        public List<ProcessControlBlock> jobQueue;

        // keeps track of following:
        public taskStatus taskStatus;   // the status of the task manager
        private static int nextPID = 0; // the next avaliable(unused) pID
        public int currentTime;         // the task manager's runtime's current time
        public algo schedulingAlgorithm { get; set; }
        public MemoryManager memoryManager;

        public TaskManager() { 
            readyQueue = new List<ProcessControlBlock>();
            jobQueue = new List<ProcessControlBlock>();
            currentTime = 0;
            taskStatus = taskStatus.PAUSE;
            memoryManager = new MemoryManager();
        }

        // function to generate {numProcesses} number of processes and add it to the Job Queue
        public void GenerateProcesses(int numProcesses)
        {
            Random random = new Random();
            for (int i = 0; i < numProcesses; i++)
            {
                ProcessControlBlock pcb = CreateProcess(nextPID++, random);
                jobQueue.Add(pcb);
            }
        }

        // function to generate a process with random burst time, arrival time, priority, and memory requirement
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

        // function to add processes from the job queue into the ready queue until no more processes can be added
        private void AdmitJobQueue()
        {

            // sort the job queue, according to arrival time
            jobQueue.Sort((pcb1, pcb2) => pcb1.arrivalTime.CompareTo(pcb2.arrivalTime));

            foreach (var pcb in jobQueue.ToList())
            {
                // if the process has already arrived, and process' memory requirement can be provided by the memory manager
                if (pcb.arrivalTime <= currentTime && memoryManager.AllocateMemory(pcb.memorySize, out MemorySegment segment))
                {
                    // add the process to the ready queue and remove the process from the job queue
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

        // function executed by the task manager for each clock's tick
        public void Execute()
        {
            int index;

            currentTime++;      // increase current time
            AdmitJobQueue();    // add available processes in job queue to ready queue is possible

            switch (schedulingAlgorithm)
            {
                case algo.FIFO: // selected algorithm is First In, First Out
                    FIFO fifo = new FIFO();
                    index = fifo.GetEarliest(readyQueue, currentTime);          // get index of the target process

                    if (index != -1) // if a target process is found
                    {
                        ProcessControlBlock currentProcess = readyQueue[index];

                        readyQueue[index] = fifo.Run(currentProcess);           // execute the process

                        // if the process is terminated
                        if (readyQueue[index].state == status.TERMINATED)
                        {
                            memoryManager.DeallocateMemory(readyQueue[index].Segment);  // deallocate its allocated memory
                            readyQueue.RemoveAt(index);                                 // remove the process from the ready queue
                        }
                    }

                    break;
                case algo.SJF:  // selected algorithm is Shortest Job First
                    SJF sjf = new SJF();
                    index = sjf.GetShortest(readyQueue, currentTime);           // get index of the target process
                    
                    if (index != -1) // if a target process is found
                    {
                        readyQueue[index] = sjf.Run(index, ref readyQueue);     // execute the process

                        // if the process is terminated
                        if (readyQueue[index].state == status.TERMINATED)
                        {
                            memoryManager.DeallocateMemory(readyQueue[index].Segment);  // deallocate its allocated memory
                            readyQueue.RemoveAt(index);                                 // remove the process from the ready queue
                        }
                    }

                    break;
                case algo.PRIO:   // selected algorithm is Priority
                    PRIO prio = new PRIO();
                    index = prio.PrioritizeProcess(readyQueue, currentTime);    // get index of the target process

                    if (index != -1) // if a target process is found
                    {
                        readyQueue[index] = prio.Run(index, ref readyQueue);    // execute the process

                        // if the process is terminated
                        if (readyQueue[index].state == status.TERMINATED)
                        {
                            memoryManager.DeallocateMemory(readyQueue[index].Segment);  // deallocate its allocated memory
                            readyQueue.RemoveAt(index);                                 // remove the process from the ready queue
                        }
                    }

                    break;
                case algo.RRR:
                    RRR rr = new RRR(4);

                    // if end of quantum time is reached
                    if (rr.ifTimeToQuantum(currentTime))
                    {
                        // get index of the target process
                        index = rr.GetEarliest(readyQueue, currentTime);

                        // regenerate target process
                        ProcessControlBlock process = new ProcessControlBlock(
                            readyQueue[index].pID,
                            readyQueue[index].burstTime,
                            currentTime,
                            readyQueue[index].priority,
                            readyQueue[index].memorySize, 
                            status.READY
                        );

                        // put the target process to the end of the ready queue
                        memoryManager.DeallocateMemory(readyQueue[index].Segment);
                        readyQueue.RemoveAt(index);
                        if(memoryManager.AllocateMemory(process.memorySize, out MemorySegment segment))
                        {
                            process.Segment = segment;
                        }
                        readyQueue.Add(process);
                    }

                    index = rr.GetEarliest(readyQueue, currentTime);                    // get index of the new target process
                    if (index != -1) // if a target process is found
                    {
                        ProcessControlBlock currentProcess = readyQueue[index];
                        readyQueue[index] = rr.Run(currentProcess);

                        if (readyQueue[index].state == status.TERMINATED)               // execute the process
                        {
                            memoryManager.DeallocateMemory(readyQueue[index].Segment);  // deallocate its allocated memory
                            readyQueue.RemoveAt(index);                                 // remove the process from the ready queue
                        }
                    }
                    break;
            }
        }
    }

    public enum taskStatus
    {
        PLAY,           // task manager is currently being played
        PAUSE,          // task manager is currently paused
        STOP            // task manager is currently not running
    }

}
