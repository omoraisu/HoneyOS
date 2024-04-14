using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Speech.Recognition;
using System.Windows.Forms;

namespace HoneyOS
{
    public partial class Desktop : Form
    {
        List<string> phrases = new List<string>
        {
            /* command initializer */
            "honey",
            /* full commands */
            "open notepad please",          // create instance of notepad window
            "open file manager please",     // create instance of file manager window
            "close notepad please",         // close all existing instance of notepad window
            "close file manager please",    // close all existing instance of file manager window
            "goodbye",                // close the notepad
        };

        bool isListeningForAction, topmost, isListening;
        SpeechRecognitionEngine recognizer;

        List<Form7> notepads = new List<Form7>();
        List<Form5> file_managers = new List<Form5>();

        PowerStatus ps = SystemInformation.PowerStatus;

        public Desktop()
        {
            InitializeComponent();
            isListeningForAction = false;
            isListening = false;
        }
        private void Desktop_Load(object sender, EventArgs e)
        {
            notepadToolStripMenuItem.Visible = false;
            fileManagerToolStripMenuItem.Visible = false;
            BatteryTimer.Start();

            // Start a timer to call the update function periodically
            Timer updateTimer = new Timer();
            updateTimer.Interval = 1000; // 1000 milliseconds = 1 second
            updateTimer.Tick += (s, ev) => DesktopUpdate(); // Lambda expression to call the Update function
            updateTimer.Start();

            SpeechRecognition_Load();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DesktopUpdate(); // Call the update function
        }
        public void DesktopUpdate()
        {
            // Update the current time displayed on the form
            label1.Text = DateTime.Now.ToShortTimeString();
            label2.Text = DateTime.Now.ToShortDateString();

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
                }
                catch (ObjectDisposedException)
                {

                }

            }
        }

        private void SpeechRecognition_Load()
        {
            //setup grammar
            Choices choices = new Choices(phrases.ToArray());
            GrammarBuilder builder = new GrammarBuilder(choices);
            Grammar grammar = new Grammar(builder);

            // initializing Speech Recognition
            recognizer = new SpeechRecognitionEngine();
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.LoadGrammar(grammar);
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
        }

        /* Speech Commands Functions */
        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence < 0.7)
            {
                MessageBox.Show("I'm sorry honey, I'm not sure I heard you clearly", "HoneyOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (e.Result.Text.ToLower() == "honey" && !isListeningForAction)
            {
                //indicate to UI that Beebot is listening
                MessageBox.Show("Hello dear, what can I do for you?", "HoneyOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isListeningForAction = true;
            }
            else if (isListeningForAction)
            {
                switch (e.Result.Text.ToLower()) // for each case, create a corresponding function
                {
                    case "open notepad please":
                        MessageBox.Show("Sure, i'll open it for you dear", "HoneyOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OpenNotepadFunction();
                        isListeningForAction = false;
                        break;
                    case "open file manager please":
                        MessageBox.Show("Sure, i'll open it for you dear", "HoneyOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OpenFileManagerFunction();
                        isListeningForAction = false;
                        break;
                    case "close notepad please":
                        MessageBox.Show("Sure, i'll close it for you dear", "HoneyOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CloseNotepadFunction();
                        isListeningForAction = false;
                        break;
                    case "close file manager please":
                        MessageBox.Show("Sure, i'll close it for you dear", "HoneyOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CloseFileManagerFunction();
                        isListeningForAction = false;
                        break;
                    case "goodbye":
                        MessageBox.Show("Goodbye, honey", "HoneyOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShutdownFunction();
                        isListeningForAction = false;
                        break;
                    default:
                        //indicate to UI that the command taken was not recognized
                        break;
                }
            }

        }
        private void OpenNotepadFunction()
        {
            notepadToolStripMenuItem.Visible = true;
            // Create an instance of Form7
            Form7 form7 = new Form7(this);
            notepads.Add(form7);
            form7.Show();
        }
        private void OpenFileManagerFunction()
        {
            fileManagerToolStripMenuItem.Visible = true;
            // Create an instance of Form5
            Form5 form5 = new Form5(this);
            file_managers.Add(form5);
            form5.Show();
        }
        private void CloseNotepadFunction()
        {
            foreach(Form7 notepad in notepads)
            {
                if (notepad.Visible)
                {
                    notepad.Hide();
                    notepad.Dispose();
                }
            }
            notepads.Clear();
        }
        private void CloseFileManagerFunction()
        {
            foreach (Form5 fm in file_managers)
            {
                if (fm.Visible)
                {
                    fm.Hide();
                    fm.Dispose();
                }
            }
            file_managers.Clear();
        }
        private void ShutdownFunction()
        {
            recognizer.Dispose();
            Application.Exit();
        }



        /* Click / MouseEnter / MouseLeave Functions */
        private void button1_Click(object sender, EventArgs e)
        {
            OpenNotepadFunction();
        }

        // Handle the MouseEnter event to change the ToolStripMenuItem's image when hovered over
        private void startToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
        }

        // Handle the MouseLeave event to change the ToolStripMenuItem's image when the mouse leaves
        private void startToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
        }

        // Handle the Click event to change the ToolStripMenuItem's image when clicked
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void notepadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenNotepadFunction();
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShutdownFunction();
        }
        public void HideNotepadToolStripMenuItem()
        {
            notepadToolStripMenuItem.Visible = false;
        }
        public void HideFileManagerToolStripMenuItem()
        {
            fileManagerToolStripMenuItem.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileManagerFunction();
        }
        private void BatteryTimer_Tick(object sender, EventArgs e)
        {
            BatteryLife.Value = (int)(ps.BatteryLifePercent * 100);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
