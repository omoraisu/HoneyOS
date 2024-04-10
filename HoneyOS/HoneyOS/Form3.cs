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
            "honey",
            // full commands
            "open notepad please",
            "close notepad please",
            "shut down please",
        };

        bool isListeningForAction;

        public Desktop()
        {
            InitializeComponent();
            isListeningForAction = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenNotepadFunction();
        }

        private void Desktop_Load(object sender, EventArgs e)
        {
            notepadToolStripMenuItem.Visible = false;
            BatteryTimer.Start();
            label1.Text = DateTime.Now.ToShortTimeString();
            label2.Text = DateTime.Now.ToShortDateString();

            //setup grammar
            Choices choices = new Choices(phrases.ToArray());
            GrammarBuilder builder = new GrammarBuilder(choices);
            Grammar grammar = new Grammar(builder);


            // initializing Speech Recognition
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.LoadGrammar(grammar);
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void notepadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            notepadToolStripMenuItem1.Visible = true;
            // Create an instance of Form7
            Form7 form7 = new Form7(this);
            form7.Show();
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Close the application
        }
        public void HideNotepadToolStripMenuItem()
        {
            notepadToolStripMenuItem.Visible = false;
        }


        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text.ToLower() == "honey")
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
                    case "close notepad please":
                        Debug.WriteLine("sure, i'll close it for u");
                        //CloseNotepadFunction();
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
            form7.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(this);
            form5.Show();
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
