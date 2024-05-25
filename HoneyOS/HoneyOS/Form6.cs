using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
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

        // Store the shuffled list of unique colors
        private List<Color> uniqueColors = new List<Color>();

        // Current index of the color in the shuffled list
        private int colorIndex = 0;


        public algo schedulingAlgorithm { get; set; }

        // Constructor
        public Form6(Desktop desktopInstance)
        {
            InitializeComponent();
            InitializeTaskManager();
            // Initialize the list of unique colors
            InitializeUniqueColors();

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
                listView1.Columns[1].Width = 0;
                listView1.Width = 508;
                FIFO = false;

            }
            else if (PRIO)
            {
                label4.Text = "Priority";
                listView1.Columns[1].Width = 100;
                listView1.Width = 608;
                PRIO = false;
            }
            else if (RRR)
            {
                label4.Text = "Round Robin";
                listView1.Columns[1].Width = 0;
                listView1.Width = 508;
                RRR = false;
            }
            else if (SJF)
            {
                label4.Text = "Shortest Job First";
                listView1.Columns[1].Width = 0;
                listView1.Width = 508;
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

        // Initial memory value (in MB)
        private int remainingMemory = 440;

        // Store the last used color index to ensure uniqueness
        private int lastColorIndex = -1;

        // When the "Next" button is clicked
        private void button4_Click(object sender, EventArgs e)
        {
            playOnce();

            // Check if there is enough remaining memory
            if (remainingMemory >= 20) // Assuming the minimum height of a panel is 20 pixels
            {
                AddPanelToFlowLayout();
            }
            else
            {
                MessageBox.Show("Not enough memory.", "Insufficient Memory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddPanelToFlowLayout()
        {
            // Create a new Panel control
            Panel dynamicPanel = new Panel();

            // Set properties for the panel
            Random random = new Random();
            int randomHeight = random.Next(1, Math.Min(21, remainingMemory + 1)); // Generate a random height between 1 and remaining memory or 20, whichever is smaller

            dynamicPanel.Location = new Point(0, 0); // Not necessary for FlowLayoutPanel placement
            dynamicPanel.Name = "Panel" + flowLayoutPanel1.Controls.Count;
            dynamicPanel.Size = new Size(194, randomHeight); // Use the random height

            // Generate a unique random color for the panel
            Color panelColor = GetNextUniqueColor(random);
            dynamicPanel.BackColor = panelColor;

            dynamicPanel.Margin = new Padding(0); // Remove margin

            // Create and add a label to the panel
            CreateLabelInPanel(dynamicPanel, "Panel " + flowLayoutPanel1.Controls.Count, randomHeight);

            // Add the panel to the FlowLayoutPanel
            flowLayoutPanel1.Controls.Add(dynamicPanel);

            // Decrease remaining memory and update the label
            UpdateRemainingMemory(randomHeight);
        }

        private void CreateLabelInPanel(Panel panel, string labelText, int panelHeight)
        {
            Label label = new Label();
            label.Text = labelText;
            label.AutoSize = true;
            label.Margin = new Padding(0); // Remove margin

            // Set the font to Poppins, 8pt
            label.Font = new Font("Poppins", 8);

            // Set the label's back color to transparent
            label.BackColor = Color.Transparent;

            // Measure the label's size after setting its text and font
            label.Size = TextRenderer.MeasureText(label.Text, label.Font);

            // Center the label in the panel
            label.Location = new Point(
                (panel.Width - label.Width) / 2,
                (panel.Height - label.Height) / 2
            );

            // Check if panel height exceeds remaining memory
            if (panelHeight > remainingMemory)
            {
                label.Text = "Not enough";
            }

            panel.Controls.Add(label);
        }

        private void UpdateRemainingMemory(int panelHeight)
        {
            // Convert panel height to memory units (assuming 1 pixel height = 1 MB for simplicity)
            remainingMemory -= panelHeight;

            // Update the memoryMax label
            memoryMax.Text = remainingMemory + " MB";

            // Ensure memory doesn't go below zero
            if (remainingMemory < 0)
            {
                memoryMax.Text = "0 MB";
            }
        }

        private Color GetNextUniqueColor(Random random)
        {
            // Ensure there are enough unique colors in the list
            if (uniqueColors.Count == 0)
            {
                // Regenerate more unique colors if the list is empty
                GenerateUniqueColors(1000);
            }

            // Get the first color from the list
            Color color = uniqueColors[0];
            // Remove the color from the list
            uniqueColors.RemoveAt(0);

            return color;
        }
        private void InitializeUniqueColors()
        {
            // Generate a large number of unique colors
            GenerateUniqueColors(1000);
        }

        private void GenerateUniqueColors(int count)
        {
            // Ensure count is positive
            if (count <= 0)
                return;

            // Clear existing unique colors
            uniqueColors.Clear();

            // Generate and add unique colors
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                Color color = GenerateRandomColor(random);
                uniqueColors.Add(color);
            }
        }

        private Color GenerateRandomColor(Random random)
        {
            // Generate random ARGB values
            int alpha = random.Next(0, 256); // Alpha (transparency) between 0 and 255
            int red = random.Next(0, 256); // Red value between 0 and 255
            int green = random.Next(0, 256); // Green value between 0 and 255
            int blue = random.Next(0, 256); // Blue value between 0 and 255

            return Color.FromArgb(alpha, red, green, blue);
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
