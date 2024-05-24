using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Speech.Synthesis.TtsEngine;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        public ProcessControlBlock Run(ProcessControlBlock process)
        {
             process.state = status.RUNNING;
             process.burstTime--;
             if (process.burstTime < 1)
             {
                 process.state = status.TERMINATED;
                 process.PrintPCB();
             }

             return process;
            

        }
        
    }

    // child classes for scheduling algorithms 
    public class FIFO : Scheduler
    {
        public FIFO() : base() // Calls superclass constructor
        {

        }

        public int GetEarliest(List<ProcessControlBlock> processes, int currentTime)
        {
            int index = -1;

            for (int i = 0; i < processes.Count; i++)
            {
                if (processes[i].arrivalTime <= currentTime)
                {
                    if (index == -1)
                    {
                        index = i;
                    }
                    else
                    {
                        if (processes[i].arrivalTime < processes[index].arrivalTime)
                        {
                            index = i;
                        }
                    }
                }
            }
            return index;
        }
    }

    public class SJF : Scheduler
     {
         public SJF() : base() // Calls superclass constructor
         {

         }

         public int GetShortest(List<ProcessControlBlock> processes, int currentTime)
         {
             int index = -1;

             for (int i = 0; i < processes.Count; i++)
             {
                 if (processes[i].arrivalTime <= currentTime)
                 {
                     if (index == -1)
                     {
                         index = i;
                     }
                     else
                     {
                         if (processes[i].burstTime < processes[index].burstTime)
                         {
                             index = i;
                         }
                     }
                 }
             }
             return index;
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
    public enum algo
    {
        FIFO,
        SJF,
        PRIO,
        RRR
    }
}
