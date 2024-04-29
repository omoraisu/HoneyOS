using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyOS
{
    public class ProcessControlBlock
    {
        public int pID;
        public int burstTime;
        public int arrivalTime;
        public int priority;
        public status state;

        public ProcessControlBlock(int pID, int burstTime, int arrivalTime, int priority, status state)
        {
            this.pID = pID;
            this.burstTime = burstTime; 
            this.arrivalTime = arrivalTime;
            this.priority = priority;
            this.state = (status)state;
        }

        public void PrintPCB()
        {
            Console.WriteLine($"Process ID: {pID}, BT: {burstTime}, AT: {arrivalTime}, Priority: {priority}, State: {state}");
        }
    }

    public enum status
    {
        READY,
        WAITING,
        RUNNING,
        TERMINATED
    }
}
