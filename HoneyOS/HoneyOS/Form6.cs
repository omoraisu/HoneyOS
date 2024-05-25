using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Schema;
using Win32Interop.Enums;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace HoneyOS
{
    public partial class Form6 : Form
    {
        private Desktop desktopInstance; // Reference to an instance of Desktop form
        private TaskManager taskManager;
        public algo schedulingAlgo;


        // Public properties to hold the boolean values
        public bool FIFO { get; set; }
        public bool PRIO { get; set; }
        public bool RRR { get; set; }
        public bool SJF { get; set; }
        public algo schedulingAlgorithm { get; set; }

        // Constructor
        public Form6(Desktop desktopInstance)
        {
            InitializeComponent();
            InitializeTaskManager();


            Timer updateTimer = new Timer();
            updateTimer.Interval = 1000; // 1000 milliseconds = 1 second
            updateTimer.Tick += (s, ev) => Form6Update(); // Lambda expression to call the Update function
            updateTimer.Start();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            // Access boolean properties and update label4
            if (FIFO)
            {
                label4.Text = "First Come First Serve";
                FIFO = false;
            }
            else if (PRIO)
            {
                label4.Text = "Priority";
                PRIO = false;
            }
            else if (RRR)
            {
                label4.Text = "Round Robin";
                RRR = false;
            }
            else if (SJF)
            {
                label4.Text = "Shortest Job First";
                SJF = false;
            }
        }

        public void Form6Update()
        {
            if(taskManager.taskStatus == taskStatus.PLAY)
            {
                playOnce();
            }
        }

        public void playOnce()
        {
            taskManager.Execute();

            if (isAllProcessesTerminated(taskManager.processes))
            {
                taskManager.taskStatus = taskStatus.STOP;
                taskManager.currentTime = 0;
            }
            UpdateProcessList();
        }

        public bool isAllProcessesTerminated(List<ProcessControlBlock> processes)
        {
            foreach (ProcessControlBlock process in taskManager.processes)
            {
                if (process.state != HoneyOS.status.TERMINATED)
                {
                    return false;
                }
            }
            return true;
        }

        // Initializes new task manager to be used for this instance 
        private void InitializeTaskManager()
        {
            taskManager = new TaskManager();

            // Check if a TaskManager instance is available
            if (taskManager != null)
            {
                // Update the process list based on the TaskManager instance
                Random random = new Random();
                int numProcesses = random.Next(1, 10);
                taskManager.GenerateProcesses(numProcesses);
                UpdateProcessList();
            }
            else
            {
                // Handle the case where TaskManager is not available
                MessageBox.Show("Task Manager instance not found!", "HoneyOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Updates the list based on the current list in task manager 
        private void UpdateProcessList()
        {
            listView1.Items.Clear(); // Clear existing items

            foreach (ProcessControlBlock process in taskManager.processes)
            {
                string[] processInfo = { process.pID.ToString(), process.burstTime.ToString(), process.arrivalTime.ToString(), process.priority.ToString(), process.state.ToString() };
                ListViewItem newItem = new ListViewItem(processInfo);
                listView1.Items.Add(newItem);
            }
            label6.Text = taskManager.currentTime.ToString();
        }

        public void UpdateSchedulingAlgo(algo al)
        {
            schedulingAlgo = al;
            taskManager.schedulingAlgorithm = schedulingAlgo;
            Debug.WriteLine(al);
        }

        // When play is clicked 
        private void button1_Click(object sender, EventArgs e)
        {
            taskManager.taskStatus = taskStatus.PLAY;
        }

        // When pause is clicked
        private void button2_Click(object sender, EventArgs e)
        {
            taskManager.taskStatus = taskStatus.PAUSE;
        }

        // When stop is clicked
        private void button3_Click(object sender, EventArgs e)
        {
            taskManager.taskStatus = taskStatus.STOP;
            taskManager.currentTime = 0;
            listView1.Items.Clear();
        }

        // When next is clicked 
        private void button4_Click(object sender, EventArgs e)
        {
            playOnce();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(193, 225, 193);
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(255, 255, 255);
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(255, 225, 191);
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(255, 255, 255);
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(255, 204, 203);
        }
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(255, 255, 255);
        }
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(215, 242, 243);
        }
        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(255, 255, 255);
        } 

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
