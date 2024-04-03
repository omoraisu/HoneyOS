using HoneyOS.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoneyOS
{
    public partial class Form4 : Form
    {
        private Desktop desktopInstance; // Reference to an instance of Desktop form
        public Form4(Desktop desktopInstance)
        {
            InitializeComponent();
            this.desktopInstance = desktopInstance; // Assign the reference to the instance of Desktop form
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }


        //Buttons Hover and Clicked
        private void save_Click(object sender, EventArgs e)
        {
            save.BackColor = Color.FromArgb(255, 234, 177);
        }
        private void save_MouseLeave(object sender, EventArgs e)
        {
            save.BackColor = Color.White;
        }
        private void save_MouseEnter(object sender, EventArgs e)
        {
            save.BackColor = Color.FromArgb(255, 243, 222);
        }
        private void saveAs_Click(object sender, EventArgs e)
        {
            saveAs.BackColor = Color.FromArgb(255, 234, 177);
        }
        private void saveAs_MouseLeave(object sender, EventArgs e)
        {
            saveAs.BackColor = Color.White;
        }
        private void saveAs_MouseEnter(object sender, EventArgs e)
        {
            saveAs.BackColor = Color.FromArgb(255, 243, 222);
        }
        private void open_Click(object sender, EventArgs e)
        {
            open.BackColor = Color.FromArgb(255, 234, 177);
        }
        private void open_MouseLeave(object sender, EventArgs e)
        {
            open.BackColor = Color.White;
        }
        private void open_MouseEnter(object sender, EventArgs e)
        {
            open.BackColor = Color.FromArgb(255, 243, 222);
        }
        private void cut_Click(object sender, EventArgs e)
        {
            cut.BackColor = Color.FromArgb(255, 234, 177);
            richTextBox1.Cut();
        }
        private void cut_MouseLeave(object sender, EventArgs e)
        {
            cut.BackColor = Color.White;
        }
        private void cut_MouseEnter(object sender, EventArgs e)
        {
            cut.BackColor = Color.FromArgb(255, 234, 177);
        }
        private void copy_Click(object sender, EventArgs e)
        {

            copy.BackColor = Color.FromArgb(255, 234, 177);
            richTextBox1.Copy();
        }
        private void copy_MouseLeave(object sender, EventArgs e)
        {
            copy.BackColor = Color.White;
        }
        private void copy_MouseEnter(object sender, EventArgs e)
        {
            copy.BackColor = Color.FromArgb(255, 234, 177);
        }
        private void paste_Click(object sender, EventArgs e)
        {
            paste.BackColor = Color.FromArgb(255, 234, 177);
            richTextBox1.Paste();
        }
        private void paste_MouseLeave(object sender, EventArgs e)
        {
            paste.BackColor = Color.White;
        }
        private void paste_MouseEnter(object sender, EventArgs e)
        {
            paste.BackColor = Color.FromArgb(255, 234, 177);
        }

        private void close_Click(object sender, EventArgs e)
        {
            desktopInstance?.HideNotepadToolStripMenuItem(); // Call the method to hide notepadToolStripMenuItem on Desktop form
            this.Close();
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(richTextBox1.Text.Length > 0)
            {
                copyToolStripMenuItem1.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                copy.Enabled = true;
                cut.Enabled = true;
            }
            else
            {
                copyToolStripMenuItem1.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                copy.Enabled = false;
                cut.Enabled = false;
            }
        }

        private void maximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal; // If already maximized, restore to normal size
                maximize.Image = HoneyOS.Properties.Resources.Maximize;
                bunifuElipse1.ElipseRadius = 20; // Set ElipseRadius to 0 when the form is maximized
            }
            else
            {
                this.WindowState = FormWindowState.Maximized; // Otherwise, maximize the form
                maximize.Image = HoneyOS.Properties.Resources.Restore;
                bunifuElipse1.ElipseRadius = 0; // Set ElipseRadius to 0 when the form is maximized

            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            maximize.Image = Properties.Resources.Maximize; // Set the icon to the maximize icon initially
            bunifuElipse1.ElipseRadius = 20; // Set ElipseRadius to its original value initially
        }
    }
}
