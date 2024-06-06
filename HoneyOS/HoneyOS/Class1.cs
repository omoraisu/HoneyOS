using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HoneyOS.MemoryManager;

namespace HoneyOS
{
    public class ProcessControlBlock
    {
        public int pID;             // Process ID
        public int burstTime;       // Process' burst time
        public int arrivalTime;     // Process' arrival time
        public int priority;        // Process' priority value
        public int memorySize;      // Process' memory requirement
        public status state;        // Process' current state
        public MemorySegment Segment { get; set; }

        public ProcessControlBlock(int pID, int burstTime, int arrivalTime, int priority, int memorySize, status state)
        {
            this.pID = pID;
            this.burstTime = burstTime; 
            this.arrivalTime = arrivalTime;
            this.priority = priority;
            this.memorySize = memorySize;
            this.state = (status)state;
        }

        // Console debug function to print all details of the process
        public void PrintPCB()
        {
            Console.WriteLine($"Process ID: {pID}, BT: {burstTime}, AT: {arrivalTime}, Priority: {priority}, Memory Size: {memorySize}, State: {state}");
        }
    }

    public enum status
    {
        NEW,            // the process has been newly added to the job queue
        READY,          // the process has been added to the ready queue
        RUNNING,        // the process is currently the being executed by the task manager
        TERMINATED,     // the process is terminated (burst time == 0)
    }
}
