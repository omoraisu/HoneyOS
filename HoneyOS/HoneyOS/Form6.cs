using System;
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
    public partial class Form6 : Form
    {
        private Desktop desktopInstance; // Reference to an instance of Desktop form
        public Form6(Desktop desktopInstance)
        {
            InitializeComponent();
            this.desktopInstance = desktopInstance; // Assign the reference to the instance of Desktop form
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this is a sample on how to add a single item on the list.
            ListViewItem listitem = new ListViewItem("Process 1");
            listitem.SubItems.Add("00:00:00");
            listitem.SubItems.Add("00:00:00");
            listitem.SubItems.Add("memory");
            listitem.SubItems.Add("Ready");

            listView1.Items.Add(listitem);

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
    }
}
