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
        public int pID;
        public int burstTime;
        public int arrivalTime;
        public int priority;
        public int memorySize;
        public MemorySegment Segment { get; set; }
        public status state;

        public ProcessControlBlock(int pID, int burstTime, int arrivalTime, int priority, int memorySize, status state)
        {
            this.pID = pID;
            this.burstTime = burstTime; 
            this.arrivalTime = arrivalTime;
            this.priority = priority;
            this.memorySize = memorySize;
            this.state = (status)state;
        }

        public void PrintPCB()
        {
            Console.WriteLine($"Process ID: {pID}, BT: {burstTime}, AT: {arrivalTime}, Priority: {priority}, Memory Size: {memorySize}, State: {state}");
        }
    }

    public enum status
    {
        NEW,
        READY,
        RUNNING,
        TERMINATED,
    }
}
