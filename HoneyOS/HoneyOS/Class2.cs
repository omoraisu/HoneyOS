using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

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
        public FIFO() : base() // Calls superclass constructor
        {

        }
        public void Run()
        {

            List<ProcessControlBlock> sortedProcess = pcb_list.OrderBy(prcs => prcs.arrivalTime)
                                                              .ThenBy(prcs => prcs.pID)
                                                              .ToList();

            foreach(ProcessControlBlock process in sortedProcess)
            {
                pcb_list.RemoveAt(pcb_list.IndexOf(process));
            }
        }
    }

    public class SJF : Scheduler
    {
        public SJF() : base() // Calls superclass constructor
        {

        }
        public void Run()
        {
            int interval = 1; // this is according to the usual examples
            int currentTime = 0;

            while (pcb_list.Count > 0)
            {
                ProcessControlBlock min_pcb = pcb_list[0];
                foreach(ProcessControlBlock process in pcb_list)
                {
                    if(process.arrivalTime <= currentTime && min_pcb.burstTime > process.burstTime)
                    {
                        min_pcb = process;
                    }
                }

                min_pcb.state = status.RUNNING;
                min_pcb.burstTime -= interval;

                if (min_pcb.burstTime <= 0)
                {
                    min_pcb.burstTime = 0;
                    pcb_list.RemoveAt(pcb_list.IndexOf(min_pcb));
                    min_pcb.state = status.TERMINATED;
                }

                currentTime++;
                // send process to task manager 
            }
        }
    }

    public class PRIO : Scheduler
    {
        public PRIO() : base() // Calls superclass constructor
        {

        }
        public void Run()
        {
            int interval = 1; // this is according to the usual examples
            int currentTime = 0;

            while (pcb_list.Count > 0)
            {
                ProcessControlBlock highprio_pcb = pcb_list[0];
                foreach (ProcessControlBlock process in pcb_list)
                {
                    if (process.arrivalTime <= currentTime && highprio_pcb.priority > process.priority)
                    {
                        highprio_pcb = process;
                    }
                }

                highprio_pcb.state = status.RUNNING;
                highprio_pcb.burstTime -= interval;

                if (highprio_pcb.burstTime <= 0)
                {
                    highprio_pcb.burstTime = 0;
                    pcb_list.RemoveAt(pcb_list.IndexOf(highprio_pcb));
                    highprio_pcb.state = status.TERMINATED;
                }

                currentTime++;
                // send process to task manager 
            }
        }
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
