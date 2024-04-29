using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyOS
{
    public class Scheduler
    {
        private List<ProcessControlBlock> pcb_list;
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
        // add logic here
    }
}
