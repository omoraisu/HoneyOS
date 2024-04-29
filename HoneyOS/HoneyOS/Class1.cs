using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyOS
{
    public class ProcessControlBlock
    {
        private int pID;
        private int burstTime;
        private int arrivalTime;
        private int priority;
        private status state;

        public ProcessControlBlock(int pID, int burstTime, int arrivalTime, int priority, int state)
        {
            this.pID = pID;
            this.burstTime = burstTime; 
            this.arrivalTime = arrivalTime;
            this.priority = priority;
            this.state = (status)state;
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
