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
    
    public partial class Form5 : Form
    {
        private Desktop desktopInstance;
        public Form5(Desktop desktopInstance)
        {
            InitializeComponent();
            this.desktopInstance = desktopInstance;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
