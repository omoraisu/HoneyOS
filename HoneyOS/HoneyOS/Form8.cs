﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoneyOS
{
    public partial class Form8 : Form
    {
        private Desktop desktopInstance; // Reference to an instance of Desktop form
        public bool button2_Clicked;
        public bool button1_Clicked;

        public Form8(Desktop desktopInstance)
        {
            InitializeComponent();
            this.desktopInstance = desktopInstance; // Assign the reference to the instance of Desktop form
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
        private void OpenFileFunction()
        {
            Form6 taskManager = new Form6(desktopInstance);
            taskManager.Show();
            this.Close();
        }
        //First Come First Served
        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(255, 234, 177);
            OpenFileFunction();
            
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(255, 234, 177);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(250, 240, 230);
        }
        //Shortest Job First
        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(255, 234, 177);
            OpenFileFunction();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(255, 234, 177);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(250, 240, 230);
        }
        //Priority
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(255, 234, 177);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(250, 240, 230);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(255, 234, 177);
            OpenFileFunction();
        }
        // Round Robin
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(255, 234, 177);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(250, 240, 230);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(255, 234, 177);
            OpenFileFunction();
        }
/*        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(242, 190, 66);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(255, 255, 255);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(255, 234, 177);
        }*/

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.FromArgb(242, 190, 66);
        }
    }
}