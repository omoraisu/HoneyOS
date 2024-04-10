using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;


namespace HoneyOS
{
    public partial class Form7 : Form
    {
        string filePath = ""; //used to store file location 
        private Desktop desktopInstance; // Reference to an instance of Desktop form
        public Form7(Desktop desktopInstance)
        {
            InitializeComponent();
            this.desktopInstance = desktopInstance; // Assign the reference to the instance of Desktop form
        }
        //Buttons Hover and Clicked
        private void save_Click(object sender, EventArgs e)
        {
            save.BackColor = Color.FromArgb(255, 234, 177);
            if (string.IsNullOrEmpty(filePath))
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "TextDocument |* .txt", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            sw.WriteLineAsync(richTextBox1.Text);
                        }
                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLineAsync(richTextBox1.Text);
                }
            }
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
            //Code for open a txt file 
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "TextDocument |* .txt", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        filePath = ofd.FileName;
                        Task<string> text = sr.ReadToEndAsync();
                        richTextBox1.Text = text.Result;
                    }
                }
            }
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
            cut.BackColor = Color.FromArgb(255, 243, 222);
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
            copy.BackColor = Color.FromArgb(255, 243, 222);
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
            paste.BackColor = Color.FromArgb(255, 243, 222);
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                copy.Enabled = true;
                cut.Enabled = true;
            }
            else
            {
                copy.Enabled = false;
                cut.Enabled = false;
            }
        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            desktopInstance?.HideNotepadToolStripMenuItem(); // Call the method to hide notepadToolStripMenuItem on Desktop form
        }

        private void newWindow_Click(object sender, EventArgs e)
        {
            newWindow.BackColor = Color.FromArgb(255, 234, 177);
            filePath = "";
            richTextBox1.Text = "";
        }

        private void newWindow_MouseEnter(object sender, EventArgs e)
        {
            newWindow.BackColor = Color.FromArgb(255, 243, 222);
        }

        private void newWindow_MouseLeave(object sender, EventArgs e)
        {
            newWindow.BackColor = Color.White;
        }
    }
}
