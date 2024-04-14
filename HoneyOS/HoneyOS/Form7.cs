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
        private Desktop desktopInstance; // reference to an instance of Desktop form
        private bool isModified = false; // determines if text was modified 
        private string oldText = "";
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
                            oldText = richTextBox1.Text;
                        }
                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLineAsync(richTextBox1.Text);
                    oldText = richTextBox1.Text;
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
            Form5 fileManager = new Form5(desktopInstance);  
            fileManager.Show();
            this.Close();
        }
        private void open_MouseLeave(object sender, EventArgs e)
        {
            open.BackColor = Color.White;
        }
        private void open_MouseEnter(object sender, EventArgs e)
        {
            open.BackColor = Color.FromArgb(255, 243, 222);
        }
        public void openFile(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string fileContent = sr.ReadToEnd();
                richTextBox1.Text = fileContent;
                oldText = richTextBox1.Text;
                isModified = false;
            }
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
            MessageBox.Show("isModified: " + isModified + "\nOld Text: " + oldText + "\nCurrent Text: " + richTextBox1.Text);

            if (richTextBox1.Text != oldText)
            {
                isModified = true;
            } 
            if (richTextBox1.Text.Length > 0)
            {
                copy.Enabled = cut.Enabled = true;
            }
            else
            {
                copy.Enabled = cut.Enabled = false;
            }
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

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            MessageBox.Show("isModified: " + isModified + "\nOld Text: " + oldText + "\nCurrent Text: " + richTextBox1.Text);

            if (isModified)
            {
                // Display confirmation dialog
                DialogResult dialogResult = MessageBox.Show(
                  "The text has been modified. Do you want to save the changes?",
                  "Unsaved Changes",
                  MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Implement logic to save changes
                    isModified = false; // Reset flag after saving
                    e.Cancel = true; 
                }
                else if (dialogResult == DialogResult.No)
                {
                    // Restore text to its last state
                    richTextBox1.Text = oldText;
                    isModified = false; // Reset flag after discarding changes
                }
            }

            // Call the method to hide notepadToolStripMenuItem on Desktop form
            desktopInstance?.HideNotepadToolStripMenuItem();
        }
    }
}
