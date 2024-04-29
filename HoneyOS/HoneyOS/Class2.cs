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

        // constructor to initialize list of pcbs
        public Scheduler() { pcb_list = new List<ProcessControlBlock>(); }

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

        private void FIFO()
        {
            // insert logic here
        }

        private void SJF()
        {
            //insert logic here
        }

        private void PRIO()
        {
            //insert logic here
        }

        private void RRR()
        {
            //insert logic here
        }
    }
}
