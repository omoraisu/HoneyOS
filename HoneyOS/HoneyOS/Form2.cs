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
        bool topmost, isListening;
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

            Timer updateTimer = new Timer();
            updateTimer.Interval = 1000; // 1000 milliseconds = 1 second
            updateTimer.Tick += (s, ev) => Form2Update(); // Lambda expression to call the Update function
            updateTimer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Form2Update(); // Call the update function
        }
        public void Form2Update()
        {
            // Check whether Desktop is focused currently
            topmost = (Form.ActiveForm == this);
            if (topmost)
            {
                Desktop_GotFocus();
            }
            else
            {
                Desktop_LostFocus();
            }
        }
        private void Desktop_GotFocus()
        {
            // add stuff to do whenever the desktop is currently focused
            if (!isListening)
            {
                try
                {
                    isListening = true;
                    recognizer.RecognizeAsync(RecognizeMode.Multiple);
                    Debug.WriteLine("currentlyListening");
                }
                catch (ObjectDisposedException)
                {
                    
                }
            }
        }
        private void Desktop_LostFocus()
        {
            // add stuff to do whenever the desktop has lost focused ie another window is currently focused
            if (isListening)
            {
                try
                {
                    isListening = false;
                    recognizer.RecognizeAsyncStop();
                    Debug.WriteLine("currentlynotListening");
                }
                catch (ObjectDisposedException)
                {

                }

            }
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
                if (e.Result.Confidence < 0.8)
                {
                    MessageBox.Show("Who are you?", "HoneyOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MessageBox.Show("Oh it's you, honey! Welcome home dear!", "HoneyOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
