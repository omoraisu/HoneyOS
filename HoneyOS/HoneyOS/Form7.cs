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
using System.Diagnostics;
using System.Speech.Recognition;


namespace HoneyOS
{
    public partial class Form7 : Form
    {
        string filePath = ""; //used to store file location 
        private Desktop desktopInstance; // Reference to an instance of Desktop form
        private bool isModified = false; // determines if text was modified
        private string oldText = "";
        private object form5;
        public string currentFile = "";
        public string currentPath = "";
        public bool isSaved = false;


        List<string> phrases = new List<string>
        {
            /* command initializer */
            "honey",
            /* full commands */
            "open new file please",         // open a text file
            "save this please",             // save the current text file
            "save this new please",         // save text file to another text file
            "close this please",            // close current notepad
            // additional commands (not yet implemented)
            "cut this please",              // cut text
            "copy this please",             // copy text
            "paste this please",            // paste cut/copied text
        };

        bool isListeningForAction, topmost, isListening;
        SpeechRecognitionEngine recognizer;


        public Form7(Desktop desktopInstance)
        {
            InitializeComponent();
            this.desktopInstance = desktopInstance; // Assign the reference to the instance of Desktop form
            isListeningForAction = false;
            isListening = false;
        }

        private void Form7_Load(object sender, EventArgs e)
        {

            // Start a timer to call the update function periodically
            Timer updateTimer = new Timer();
            updateTimer.Interval = 1000; // 1000 milliseconds = 1 second
            updateTimer.Tick += (s, ev) => Form7Update(); // Lambda expression to call the Update function
            updateTimer.Start();

            SpeechRecognition_Load();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Form7Update(); // Call the update function
        }
        public void Form7Update()
        {
            // Check whether Desktop is focused currently
            topmost = (Form.ActiveForm == this);
            if (topmost){Notepad_GotFocus();}
            else{Notepad_LostFocus();}
        }
        private void Notepad_GotFocus()
        {
            // add stuff to do whenever the form is currently focused
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
        private void Notepad_LostFocus()
        {
            // add stuff to do whenever the form has lost focused ie another window is currently focused
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
                    case "open new file please":
                        MessageBox.Show("Sure, i'll open one for you dear", "HoneyOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OpenFileFunction();
                        isListeningForAction = false;
                        break;
                    case "save this please":
                        MessageBox.Show("Sure, i'll save it for you dear", "HoneyOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveFileFunction();
                        isListeningForAction = false;
                        break;
                    case "save this new please":
                        MessageBox.Show("Sure, i'll save one for you dear", "HoneyOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveFileAsFunction();
                        isListeningForAction = false;
                        break;
                    case "close this please":
                        MessageBox.Show("Sure, i'll close this for you dear", "HoneyOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        isListeningForAction = false;
                        break;
                    default:
                        //indicate to UI that the command taken was not recognized
                        break;
                }
            }

        }
        private void OpenFileFunction()
        {
            open.BackColor = Color.FromArgb(255, 234, 177);
            Form5 fileManager = new Form5(desktopInstance);
            fileManager.Show();
            this.Close();
        }
        private void SaveFileFunction()
        {
            save.BackColor = Color.FromArgb(255, 234, 177);
            string CFilePath = Path.Combine(currentPath, currentFile);
            if (CFilePath != "")
            {
                File.WriteAllText(CFilePath, richTextBox1.Text);
            }
            else
            {
                Form5 fileManager = new Form5(desktopInstance);

                // Subscribe to the SaveCompleted event
                fileManager.SaveCompleted += FileManager_SaveCompleted;

                fileManager.SetFileContent(richTextBox1.Text);

                fileManager.Show();
                fileManager.ShowSaveFilePanel();

                if (!fileManager.Visible) // Check if it's not visible after showing
                {
                    fileManager.Close();
                }
            }
            save.Enabled = false;
            isSaved = true;
        }
        private void SaveFileAsFunction()
        {
            saveAs.BackColor = Color.FromArgb(255, 234, 177);
            Form5 fileManager = new Form5(desktopInstance);

            // Subscribe to the SaveCompleted event
            fileManager.SaveCompleted += FileManager_SaveCompleted;

            fileManager.SetFileContent(richTextBox1.Text);

            fileManager.Show();
            fileManager.ShowSaveFilePanel();

            if (!fileManager.Visible) // Check if it's not visible after showing
            {
                fileManager.Close();
            }
            save.Enabled = false;
            isSaved = true;
        }
        private void CloseWindowFunction(object sender, FormClosingEventArgs e)
        {
            // MessageBox.Show("isModified: " + isModified + "\nOld Text: " + oldText + "\nCurrent Text: " + richTextBox1.Text);
            if (!isSaved && isModified)
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
                    string CFilePath = Path.Combine(currentPath, currentFile);
                    if (CFilePath != "")
                    {
                        File.WriteAllText(CFilePath, richTextBox1.Text);
                    }
                    else
                    {
                        Form5 fileManager = new Form5(desktopInstance);

                        // Subscribe to the SaveCompleted event
                        fileManager.SaveCompleted += FileManager_SaveCompleted;

                        fileManager.SetFileContent(richTextBox1.Text);

                        fileManager.Show();
                        fileManager.ShowSaveFilePanel();

                        if (!fileManager.Visible) // Check if it's not visible after showing
                        {
                            fileManager.Close();
                        }
                    }
                }
                else if (dialogResult == DialogResult.No) { }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        //Buttons Hover and Clicked
        /*
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
                        }
                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLineAsync(richTextBox1.Text);
                }
            }

        }
        */

        /*
        private void save_Click(object sender, EventArgs e)
        {
            save.BackColor = Color.FromArgb(255, 234, 177);
            Form5 fileManager = new Form5(desktopInstance);
            fileManager.Show();
            fileManager.ShowSaveFilePanel();

            if (fileManager.ShowSaveFilePanel == false)
            {
                fileManager.Close();
            }

        }
        */


        private void save_Click(object sender, EventArgs e)
        {
            SaveFileFunction();
        }

        private void FileManager_SaveCompleted(object sender, EventArgs e)
        {
            if (sender is Form5 fileManager)
            {
                // Unsubscribe from the event
                fileManager.SaveCompleted -= FileManager_SaveCompleted;

                // Hide or close Form 5 after save is completed
                fileManager.Visible = false;
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
            SaveFileAsFunction();
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
            OpenFileFunction();
        }
        private void open_MouseLeave(object sender, EventArgs e)
        {
            open.BackColor = Color.White;
        }
        private void open_MouseEnter(object sender, EventArgs e)
        {
            open.BackColor = Color.FromArgb(255, 243, 222);
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
            if (richTextBox1.Text != oldText)
            {
                isModified = true;
            }

            if (richTextBox1.Text.Length > 0)
            {
                copy.Enabled = true;
                cut.Enabled = true;
            }
            else
            {
                copy.Enabled = false;
                cut.Enabled = false;
            }
        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            recognizer.Dispose();
            desktopInstance?.HideNotepadToolStripMenuItem(); // Call the method to hide notepadToolStripMenuItem on Desktop form
        }

        private void newWindow_Click(object sender, EventArgs e)
        {
            newWindow.BackColor = Color.FromArgb(255, 234, 177);
            // MessageBox.Show("isModified: " + isModified + "\nOld Text: " + oldText + "\nCurrent Text: " + richTextBox1.Text);
            if (!isSaved && isModified)
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
                    string CFilePath = Path.Combine(currentPath, currentFile);
                    if (CFilePath != "")
                    {
                        File.WriteAllText(CFilePath, richTextBox1.Text);
                    }
                    else
                    {
                        Form5 fileManager = new Form5(desktopInstance);

                        // Subscribe to the SaveCompleted event
                        fileManager.SaveCompleted += FileManager_SaveCompleted;

                        fileManager.SetFileContent(richTextBox1.Text);

                        fileManager.Show();
                        fileManager.ShowSaveFilePanel();

                        if (!fileManager.Visible) // Check if it's not visible after showing
                        {
                            fileManager.Close();
                        }
                    }
                }
                else if (dialogResult == DialogResult.No) {
                    filePath = "";
                    richTextBox1.Text = "";
                }
            }
        }

        private void newWindow_MouseEnter(object sender, EventArgs e)
        {
            newWindow.BackColor = Color.FromArgb(255, 243, 222);
        }

        private void newWindow_MouseLeave(object sender, EventArgs e)
        {
            newWindow.BackColor = Color.White;
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

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseWindowFunction(sender,e);
        }
        /*
        private void set_FilePath(string filePath)
        {
            this.filePath = filePath;

            // Assuming you have a RichTextBox or TextBox control for displaying text
            if (filePath.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    // Read the text file content
                    string fileContent = File.ReadAllText(filePath);

                    // Update the text box content with the file content
                    yourTextBoxControl.Text = fileContent;
                }
                catch (Exception ex)
                {
                    // Handle exceptions like file not found or permission issues
                    MessageBox.Show("Error opening file: " + ex.Message);
                }
            }
            else
            {
                // Handle non-text files (optional: display message or disable editing)
                MessageBox.Show("This file type is not supported.");
            }
        }
        private void open_Click(object sender, EventArgs e)
        {
    
            //Code for open a txt file 
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "TextDocument |* .txt", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                filePath = ofd.FileName;
                Task<string> text = sr.ReadToEndAsync();
                richTextBox1.Text = text.Result;
            }
        }
    }
}
*/

    }
}
