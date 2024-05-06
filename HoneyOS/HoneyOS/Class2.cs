using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyOS
{
    public class Scheduler
    {
        protected List<ProcessControlBlock> pcb_list;
        // add variable for current time 

        // constructor to initialize list of pcbs
        public Scheduler() { 
            pcb_list = new List<ProcessControlBlock>(); 
            // initialize current time 
        }

        // adds pcb to list
        public void AddPCB(ProcessControlBlock pcb)
        {
            this.pcb_list.Add(pcb);
        }

        // removes pcb from list
        public void RemovePCB(ProcessControlBlock pcb)
        {
            this.pcb_list.Remove(pcb);
        }
    }

    // child classes for scheduling algorithms 
    public class FIFO : Scheduler
    {
        // add logic here
    }

    public class SJF : Scheduler
    {
        // add logic here
    }

    public class PRIO : Scheduler
    {
        // add logic here
    }

    public class RRR : Scheduler
    {
        private int timeSlice;

        // constructor for round robin
        public RRR(int timeSlice) : base() // Calls superclass constructor
        {
            this.timeSlice = timeSlice;
        }

        public void Run()
        {
            while (pcb_list.Count > 0)
            {
                ProcessControlBlock current_pcb = pcb_list[0];
                pcb_list.RemoveAt(0);
                current_pcb.state = status.RUNNING;

                if (current_pcb.burstTime > timeSlice)
                {
                    current_pcb.burstTime -= timeSlice;
                    pcb_list.Add(current_pcb);
                    current_pcb.state = status.WAITING;
                }
                else
                {
                    current_pcb.burstTime = 0;
                    current_pcb.state = status.TERMINATED;
                }

                // send process to task manager 
            }
        }
    }
}
