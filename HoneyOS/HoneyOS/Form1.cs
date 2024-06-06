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
    // Intro Animation Form
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();  // Initializes the form components
            timer1.Start(); // Starts the timer when the form is created
        }   

        private void timer1_Tick(object sender, EventArgs e)
        {
            WelcomeScreen form2 = new WelcomeScreen();  // Creates an instance of the WelcomeScreen form
            timer1.Stop();  // Stops the timer so this code doesn't run again
            form2.Show();   // Shows the WelcomeScreen form
            this.Hide();    // Hides the current form (Form1)
        }
    }
}
