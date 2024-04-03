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
    public partial class Desktop : Form
    {
        private Image normalImage = Image.FromFile(@"C:\Users\Lenny\Downloads\StartButton [Default].png"); // Replace 'path\to\normal_image.png' with the path to your normal image
        private Image hoverImage = Image.FromFile(@"C:\Users\Lenny\Downloads\StartButton [Hovered].png"); // Replace 'path\to\hover_image.png' with the path to your hover image
        private Image clickedImage = Image.FromFile(@"C:\Users\Lenny\Downloads\StartButton [Clicked].png"); // Replace 'path\to\clicked_image.png' with the path to your clicked image

        public Desktop()
        {
            InitializeComponent();
            startToolStripMenuItem.Image = normalImage;
        }
        // Handle the MouseEnter event to change the ToolStripMenuItem's image when hovered over
        private void startToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            startToolStripMenuItem.Image = hoverImage;
        }

        // Handle the MouseLeave event to change the ToolStripMenuItem's image when the mouse leaves
        private void startToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            startToolStripMenuItem.Image = normalImage;
        }

        // Handle the Click event to change the ToolStripMenuItem's image when clicked
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startToolStripMenuItem.Image = clickedImage;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            notepadToolStripMenuItem.Visible = true;
            // Create an instance of Form4
            Form4 form4 = new Form4(this);
            form4.Show();

        }

        private void Desktop_Load(object sender, EventArgs e)
        {
            notepadToolStripMenuItem.Visible = false;
        }

        private void notepadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            notepadToolStripMenuItem1.Visible = true;
            // Create an instance of Form4
            Form4 form4 = new Form4(this);
            form4.Show();
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Close the application
        }
        public void HideNotepadToolStripMenuItem()
        {
            notepadToolStripMenuItem.Visible = false;
        }
    }
}
