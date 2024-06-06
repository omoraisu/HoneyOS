using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime;
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

        // execute the target process
        public ProcessControlBlock Run(ProcessControlBlock process)
        {
             process.state = status.RUNNING;
             process.burstTime--;
             if (process.burstTime < 1)
             {
                // if the burst time is 0, terminate the process
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

        // function to get the index of the oldest process in the list
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

         // function to get the index of the process with the shortest burst time in the list
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

        // checks any previous executed process and return it to ready state, then execute the target process
        public ProcessControlBlock Run(int index, ref List<ProcessControlBlock> q)
        {
            for (int i = 0; i < q.Count; i++)
            {
                if (q[i].state == status.RUNNING && q[i].pID != q[index].pID)
                {
                    q[i].state = status.READY;
                }
            }

            q[index].state = status.RUNNING;
            q[index].burstTime--;
            if (q[index].burstTime < 1)
            {
                q[index].state = status.TERMINATED;
                q[index].PrintPCB();
            }
            return q[index];
        }
    }



    public class PRIO : Scheduler
    {
        public PRIO() : base() // Calls superclass constructor
        {

        }

        // function to get the index of the process with the highest priority in the list
        public int PrioritizeProcess(List<ProcessControlBlock> processes, int currentTime)
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
                        if (processes[i].priority > processes[index].priority)
                        {
                            index = i;
                        }
                    }
                }
            }
            return index;
        }

        // checks any previous executed process and return it to ready state, then execute the target process
        public ProcessControlBlock Run(int index, ref List<ProcessControlBlock> q)
        {
            for (int i = 0; i < q.Count; i++)
            {
                if (q[i].state == status.RUNNING && q[i].pID != q[index].pID)
                {
                    q[i].state = status.READY;
                }
            }

            q[index].state = status.RUNNING;
            q[index].burstTime--;
            if (q[index].burstTime < 1)
            {
                q[index].state = status.TERMINATED;
                q[index].PrintPCB();
            }
            return q[index];
        }
    }

    public class RRR : Scheduler
    {
        private int timeSlice;
        public RRR(int timeSlice) : base() // Calls superclass constructor
        {
            this.timeSlice = timeSlice; // quantum time
        }

        // function to check if the end of the quantum time has been reached
        public bool ifTimeToQuantum(int currentTime)
        {
            return currentTime != 0 && currentTime % timeSlice == 0;
        }

        // function to get the index of the oldest process in the list
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
    public enum algo
    {
        SJF,    // Shortest Job First
        FIFO,   // First In, First  Out
        PRIO,   // Priority
        RRR     // Round Robin
    }
}
