using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyOS
{
    public class TaskManager
    {
        public TaskManager() { }
        // this is still bootleg version for testing purposes 
        public void Execute()
        {
            // insert main logic here
            ProcessControlBlock pcb1 = new ProcessControlBlock(0, 3, 0, 1, status.READY);
            ProcessControlBlock pcb2 = new ProcessControlBlock(1, 5, 3, 4, status.READY);

            RRR rr = new RRR(4);

            rr.AddPCB(pcb1);
            rr.AddPCB(pcb2);

            pcb1.PrintPCB();
            pcb2.PrintPCB();

            rr.Run();

            ProcessControlBlock pcb3 = new ProcessControlBlock(0, 3, 0, 1, status.READY);
            ProcessControlBlock pcb4 = new ProcessControlBlock(1, 5, 3, 4, status.READY);

            SJF sjf = new SJF();

            sjf.AddPCB(pcb3);
            sjf.AddPCB(pcb4);

            pcb3.PrintPCB();
            pcb4.PrintPCB();

            sjf.Run();

            ProcessControlBlock pcb5 = new ProcessControlBlock(0, 3, 0, 1, status.READY);
            ProcessControlBlock pcb6 = new ProcessControlBlock(1, 5, 3, 4, status.READY);

            PRIO prio = new PRIO(); 

            prio.AddPCB(pcb5);
            prio.AddPCB(pcb6);

            pcb5.PrintPCB();
            pcb6.PrintPCB();

            prio.Run();

            ProcessControlBlock pcb7 = new ProcessControlBlock(0, 3, 0, 1, status.READY);
            ProcessControlBlock pcb8 = new ProcessControlBlock(1, 5, 3, 4, status.READY);

            FIFO fifo = new FIFO();

            fifo.AddPCB(pcb7);
            fifo.AddPCB(pcb8);

            pcb7.PrintPCB();
            pcb8.PrintPCB();

            fifo.Run();
        }
    }
}
