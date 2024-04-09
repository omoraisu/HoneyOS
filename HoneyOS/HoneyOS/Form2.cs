using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Reflection;
using System.Diagnostics;

namespace HoneyOS
{
    public partial class WelcomeScreen : Form
    {

        SpeechRecognitionEngine recognizer;
        public WelcomeScreen()
        {
            InitializeComponent();
            TransparentButton.Hide();
            timer1.Start();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // initializing Speech Recognition
            recognizer = new SpeechRecognitionEngine();
            recognizer.SetInputToDefaultAudioDevice();
            Grammar grammar = new Grammar(new GrammarBuilder(new Choices("hello honey")));
            recognizer.LoadGrammar(grammar);
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenDesktop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            TransparentButton.Show();
            pictureBox2.Show();
            pictureBox1.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "hello honey")
            {
                Debug.WriteLine("hello honey, welcome home");    
                OpenDesktop();
            }
        }
        private void OpenDesktop()
        {
            // Logic to handle the "hello honey" speech
            Desktop form3 = new Desktop();
            form3.Show();
            this.Hide();
            recognizer.RecognizeAsyncStop();
            recognizer.Dispose();
        }
    }
}
