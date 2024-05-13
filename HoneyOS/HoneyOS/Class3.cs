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
        }
    }
}
