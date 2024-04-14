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
            "time to sleep",                // close application
        };

        bool isListeningForAction;
        SpeechRecognitionEngine recognizer;

        List<Form7> notepads = new List<Form7>();
        List<Form5> file_managers = new List<Form5>();

        public Desktop()
        {
            InitializeComponent();
            isListeningForAction = false;

            this.GotFocus += Desktop_GotFocus;
            this.LostFocus += Desktop_LostFocus;
        }
        private void Desktop_Load(object sender, EventArgs e)
        {
            notepadToolStripMenuItem.Visible = false;
            BatteryTimer.Start();
            label1.Text = DateTime.Now.ToShortTimeString();
            label2.Text = DateTime.Now.ToShortDateString();

            SpeechRecognition_Load();
        }

        private void Desktop_GotFocus(object sender, EventArgs e)
        {
            // add stuff to do whenever the desktop is currently focused
            Debug.WriteLine("desktop is currently focused");
            if (recognizer == null)
            {
                SpeechRecognition_Load();
            }

            recognizer.RecognizeAsync(RecognizeMode.Multiple);
            Debug.WriteLine("speech is continued");
        }
        private void Desktop_LostFocus(object sender, EventArgs e)
        {
            // add stuff to do whenever the desktop has lost focused ie another window is currently focused
            Debug.WriteLine("desktop has lost focus");
            if (recognizer != null)
            {
                recognizer.RecognizeAsyncStop();
                Debug.WriteLine("speech is paused");
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
            if (e.Result.Text.ToLower() == "honey" && !isListeningForAction)
            {
                //indicate to UI that Beebot is listening
                Debug.WriteLine("i heard u honey, what can I do for you?");
                isListeningForAction = true;
            }
            else if (isListeningForAction)
            {
                isListeningForAction = false;

                switch (e.Result.Text.ToLower()) // for each case, create a corresponding function
                {
                    case "open notepad please":
                        Debug.WriteLine("sure, i'll open it for u");
                        OpenNotepadFunction();
                        break;
                    case "open file manager please":
                        Debug.WriteLine("sure, i'll open it for u");
                        OpenFileManagerFunction();
                        break;
                    case "close notepad please":
                        Debug.WriteLine("sure, i'll close it for u");
                        CloseNotepadFunction();
                        break;
                    case "close file manager please":
                        Debug.WriteLine("sure, i'll close it for u");
                        CloseFileManagerFunction();
                        break;
                    case "time to sleep":
                        Debug.WriteLine("sure, sweet dreams honey");
                        ShutdownFunction();
                        break;
                    default:
                        //indicate to UI that the command taken was not recognized
                        Debug.WriteLine("I'm sorry honey, I'm not sure I heard you clearly");
                        isListeningForAction = true;
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
            form7.Show(this);
        }
        private void OpenFileManagerFunction()
        {
            notepadToolStripMenuItem.Visible = true;
            // Create an instance of Form5
            Form5 form5 = new Form5(this);
            file_managers.Add(form5);
            form5.Show(this);
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

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileManagerFunction();
        }

        PowerStatus ps = SystemInformation.PowerStatus;

        private void BatteryTimer_Tick(object sender, EventArgs e)
        {
            BatteryLife.Value = (int)(ps.BatteryLifePercent * 100);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
