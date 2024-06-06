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
    // Welcome Screen Form
    public partial class WelcomeScreen : Form
    {

        SpeechRecognitionEngine recognizer; // Speech recognition engine instance
        bool topmost, isListening;  // Flags to track the form's focus and listening state
        public WelcomeScreen()
        {
            InitializeComponent();  // Initializes the form components
            TransparentButton.Hide();   // Hides the transparent button initially
            timer1.Start(); // Starts the timer when the form is created
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            recognizer = new SpeechRecognitionEngine(); // Initializing Speech Recognition
            recognizer.SetInputToDefaultAudioDevice();  // Sets the default audio device as input
            Grammar grammar = new Grammar(new GrammarBuilder(new Choices("hello honey")));  // Defines grammar for recognition
            recognizer.LoadGrammar(grammar);    // Loads the grammar into the recognizer
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);    // Subscribes to the SpeechRecognized event

            // Timer to periodically update the form's state
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
                Desktop_GotFocus(); // If focused, call the GotFocus method
            }
            else
            {
                Desktop_LostFocus();    // If not focused, call the LostFocus method
            }
        }

        // Method to handle when the form gets focus
        private void Desktop_GotFocus()
        {
            // Start listening if not already listening
            if (!isListening)
            {
                try
                {
                    isListening = true;
                    recognizer.RecognizeAsync(RecognizeMode.Multiple);  // Start recognition in multiple mode
                    Debug.WriteLine("currentlyListening");
                }
                catch (ObjectDisposedException)
                {
                    
                }
            }
        }
        // Method to handle when the form loses focus
        private void Desktop_LostFocus()
        {
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
        // Event Handler to when the Hexagon button is clicked to proceed to Desktop
        private void button1_Click(object sender, EventArgs e)
        {
            OpenDesktop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // When the animation is done, it will how the picture background and dispose the animation
            timer1.Stop();
            TransparentButton.Show();
            pictureBox2.Show();
            pictureBox1.Dispose();
        }

        // Event handler for the speech recognition event
        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // Check if the recognized speech is "hello honey"
            if (e.Result.Text == "hello honey")
            {
                // Check the confidence level of the recognized speech
                if (e.Result.Confidence < 0.8)
                {
                    MessageBox.Show("Who are you?", "HoneyOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // If yes it will show the message box and proceeds to Desktop
                MessageBox.Show("Oh it's you, honey! Welcome home dear!", "HoneyOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OpenDesktop();
            }
        }
        // Function to open the desktop form
        private void OpenDesktop()
        {
            // Logic to handle the "hello honey" speech
            // Create and show the Desktop form, then hide the current form
            Desktop form3 = new Desktop();
            form3.Show();
            this.Hide();

            // Stop and dispose of the recognizer
            recognizer.RecognizeAsyncStop();
            recognizer.Dispose();
        }
    }
}
