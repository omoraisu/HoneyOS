﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace HoneyOS
{
    
    public partial class Form5 : Form
    {
        public event EventHandler SaveCompleted;
        private Desktop desktopInstance;
        private string filePath = "C:\\";
        private bool isFile = false;
        public bool isSaved = false; 
        private string currentlySelectedItemName = "";

        private string cutItemPath = "";     // To remember the item being cut
        private string copiedItemPath = "";  // To remember the item being copied
        private string fileContent;

        public Form5(Desktop desktopInstance)
        {
            InitializeComponent();
            this.desktopInstance = desktopInstance;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            filePathTextBox.Text = filePath;
            loadFilesAndDirectories();

            //for saving file appearance
            saveFileName.Visible = false;
            saveFileName.Visible = false;
            saveFileButton.Visible = false;
            cancelFileButton.Visible = false;
            saveFileTypeLabel.Visible = false;
            saveFileNameLabel.Visible = false;

            //clears file name and type when not selected
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;

            // Associate delete button click event with DeleteSelectedItem method
            deleteButton.Click += deleteButton_Click;

            //for rename files
            renameButton.Click += renameButton_Click;
        }

        public void loadFilesAndDirectories() //loads file and directories O - O
        {
            DirectoryInfo fileList;
            string tempFilePath = "";
            FileAttributes fileAttr;

            try
            {
                if (isFile)
                {
                    tempFilePath = filePath + "/" + currentlySelectedItemName;
                    FileInfo fileDetails = new FileInfo(tempFilePath);
                    fileNameLabel.Text = fileDetails.Name;
                    fileTypeLabel.Text = fileDetails.Extension;
                    fileAttr = File.GetAttributes(tempFilePath);

                    Form7 textEditorForm = new Form7(desktopInstance);

                    // Check if the selected file is a text file
                    if (Path.GetExtension(tempFilePath).ToLower() == ".txt")
                    {
                        // Open Form7 (text editor)
                        if (textEditorForm != null) // Check if reference is valid
                        {
                            textEditorForm.openFile(tempFilePath);
                            textEditorForm.currentPath = filePath;
                            textEditorForm.currentFile = currentlySelectedItemName;
                            textEditorForm.Show();
                        }

                        // Close Form5 (file manager)
                        this.Close();
                    }

                    // Process.Start(tempFilePath);
                }
                else
                {
                    fileAttr = File.GetAttributes(filePath);

                }

                if ((fileAttr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    fileList = new DirectoryInfo(filePath);
                    FileInfo[] files = fileList.GetFiles(); // get all the file
                    DirectoryInfo[] dirs = fileList.GetDirectories(); // get all the directories
                    string fileExtension = "";

                    listView1.Items.Clear();

                    for (int i = 0; i < files.Length; i++)
                    {
                        //fileExtension = files[i].Extension.ToUpper();

                        /*switch (fileExtension)
                        {
                            /*case ".MP3":
                            case ".MP2":
                                listView1.Items.Add(files[i].Name, 3);
                                break;
                            case ".EXE":
                            case ".COM":
                                listView1.Items.Add(files[i].Name, 1);
                                break;
                            case "MP4":
                            case ".AVI":
                            case ".MKV":
                                listView1.Items.Add(files[i].Name, 4);
                                break;
                            case ".PDF":
                                listView1.Items.Add(files[i].Name, 5);
                                break;
                            case ".DOC":
                            case ".DOCX":
                                listView1.Items.Add(files[i].Name, 0);
                                break;
                            case ".PNG":
                            case ".JPG":
                            case ".JPEG":
                                listView1.Items.Add(files[i].Name, 6);
                                break;

                            default:
                                listView1.Items.Add(files[i].Name, 7);
                                break;
                        }*/

                        if (files[i].Extension.ToUpper() == ".TXT")
                        {
                            listView1.Items.Add(files[i].Name, 8); //display txt file (hopefully)
                        }

                    }

                    for (int i = 0; i < dirs.Length; i++) 
                    {
                        listView1.Items.Add(dirs[i].Name, 2); //display the directories
                    }
                }
                else
                {
                    fileNameLabel.Text = this.currentlySelectedItemName;

                }
            }
            catch (Exception e)
            {

            }

        }

        public void loadButtonAction()
        {
            removeBackSlash();
            filePath = filePathTextBox.Text;
            loadFilesAndDirectories();
            isFile = false;
        }

        public void removeBackSlash() //for file names, naay ma /programFiles example
        {
            string path = filePathTextBox.Text;
            if (path.LastIndexOf("/") == path.Length - 1)
            {
                filePathTextBox.Text = path.Substring(0, path.Length - 1);
            }
        }

        public void goBack()
        {
            try
            {
                removeBackSlash();
                string path = filePathTextBox.Text;
                path = path.Substring(0, path.LastIndexOf("/"));
                this.isFile = false;
                filePathTextBox.Text = path;
                removeBackSlash();
            }
            catch (Exception e)
            {

            }

        }
        private void backButton_Click(object sender, EventArgs e)
        {
            goBack();
            loadButtonAction();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            loadButtonAction();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nasayop ko ani, lol wa ni gamit pero ay lang i delete basin maguba
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            currentlySelectedItemName = e.Item.Text;

            FileAttributes fileAttr = File.GetAttributes(filePath + "/" + currentlySelectedItemName);

            //if selected is file or directory: if file then butang siya labels (else statement nako)
            if ((fileAttr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                isFile = false;
                filePathTextBox.Text = filePath + "/" + currentlySelectedItemName;
            }
            else
            {
                isFile = true;

                //Update labels (i hope it works with just 1 click)
                FileInfo fileDetails = new FileInfo(filePath + "/" + currentlySelectedItemName);
                fileNameLabel.Text = Path.GetFileNameWithoutExtension(fileDetails.Name); // Display file name without extension
                fileTypeLabel.Text = "." + fileDetails.Extension.TrimStart('.');
            }

            //clears file name and type if di na i select
            if (listView1.SelectedItems.Count == 0)
            {
                // No item selected, clear the file name and type labels
                fileNameLabel.Text = "";
                fileTypeLabel.Text = "";
            }

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            loadButtonAction();
        }

        private void fileNameLabel_Click(object sender, EventArgs e)
        {

        }


        //this is the delete button function
        /*private void button10_Click(object sender, EventArgs e)
        {
            DeleteSelectedItem();
        }
        */
        public void ShowSaveFilePanel()
        {
            saveFileName.Visible = true;
            saveFileName.Visible = true;
            saveFileButton.Visible = true;
            cancelFileButton.Visible = true;
            saveFileTypeLabel.Visible = true;
            saveFileNameLabel.Visible = true;

            // Set default values or clear any previous input
            saveFileName.Text = ""; // Clear the text box for file name
            saveFileTypeLabel.Text = "File Type: " + "Text documents (*.txt;  *.TXT)"; // Set default file type (e.g., .txt)
        }

        private void saveFilePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void renameButton_Click(object sender, EventArgs e)
        {

        }

        /*
        private void saveFileButton_Click(object sender, EventArgs e)
        {
            string fileName = saveFileName.Text.Trim(); // Get the entered file name

            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("Please enter a valid file name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop execution if no file name is entered
            }

            // Combine the file path with the new file name and extension
            string newFilePath = Path.Combine(filePath, fileName + ".txt"); // Always create .txt file

            try
            {
                // Get the text to write to the file
                string fileContent = ""; // Add your content here or leave it empty for a blank file

                // Write the text content to the new file
                File.WriteAllText(newFilePath, fileContent);

                // Refresh the file list
                loadFilesAndDirectories();

                // Hide the save file panel after creating the file
                saveFilePanel.Visible = false;

                // triggers that file has been saved 
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */

        public void SetFileContent(string content)
        {
            fileContent = content;
        }




        private void CopyDirectory(string sourceDir, string targetDir)
        {
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            string[] files = Directory.GetFiles(sourceDir);
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(targetDir, fileName);
                File.Copy(file, destFile, true);
            }

            string[] subDirs = Directory.GetDirectories(sourceDir);
            foreach (string subDir in subDirs)
            {
                string dirName = Path.GetFileName(subDir);
                string destDir = Path.Combine(targetDir, dirName);
                CopyDirectory(subDir, destDir);
            }
        }

        //made this to refresh is instead of calling the loadFileAndDirectories() which opens the Notepad;
        public void refreshFilesAndDirectories()
        {
            DirectoryInfo fileList;
            string tempFilePath = "";
            FileAttributes fileAttr;

            try
            {
                fileAttr = File.GetAttributes(filePath);

                if ((fileAttr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    fileList = new DirectoryInfo(filePath);
                    FileInfo[] files = fileList.GetFiles(); // get all the files
                    DirectoryInfo[] dirs = fileList.GetDirectories(); // get all the directories
                    string fileExtension = "";

                    listView1.Items.Clear();

                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i].Extension.ToUpper() == ".TXT")
                        {
                            listView1.Items.Add(files[i].Name, 8); // display txt file
                        }
                    }

                    for (int i = 0; i < dirs.Length; i++)
                    {
                        listView1.Items.Add(dirs[i].Name, 2); // display the directories
                    }
                }
                else
                {
                    fileNameLabel.Text = this.currentlySelectedItemName;
                }
            }
            catch (Exception e)
            {
                // Handle exceptions
            }
        }

        private void DeleteSelectedItem()
        {
            if (string.IsNullOrEmpty(currentlySelectedItemName))
            {
                MessageBox.Show("No item selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedItemPath = Path.Combine(filePath, currentlySelectedItemName);

            try
            {
                if (File.Exists(selectedItemPath))
                {
                    // Check if the file is in use before deleting
                    using (FileStream fs = File.Open(selectedItemPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
                        // If we reach here, the file is not in use
                    }

                    // Delete the file
                    File.Delete(selectedItemPath);
                }
                else if (Directory.Exists(selectedItemPath))
                {
                    // Check if the directory is empty before deleting
                    if (Directory.EnumerateFileSystemEntries(selectedItemPath).Any())
                    {
                        MessageBox.Show("Cannot delete the directory because it is not empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Delete the directory
                    Directory.Delete(selectedItemPath);
                }

                // Refresh the file list after deletion
                refreshFilesAndDirectories();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access to the item is denied. Make sure it is not in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show("An error occurred while deleting the item. Make sure it is not in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        
        private string GetNewNameFromUser(string currentName)
        {
            // Display an input dialog to get the new name from the user
            string newName = Interaction.InputBox("Enter the new name:", "Rename Item", currentName);

            // You can add validation here if needed
            // For example, check if the new name is valid, not empty, etc.

            return newName;
        }

        private void saveFileButton_Click_1(object sender, EventArgs e)
        {
            string fileName = saveFileName.Text.Trim();

            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("Please enter a valid file name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newFilePath = Path.Combine(filePath, fileName + ".txt");

            try
            {
                // string fileContent = "breh"; // Add content here or leave it empty for a blank file

                File.WriteAllText(newFilePath, fileContent);

                loadFilesAndDirectories();

                saveFileName.Visible = false;

                SaveCompleted?.Invoke(this, EventArgs.Empty); // Notify that save is completed
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Needs to tell Form7 if the user actually pressed saved or cancelled since currently it assumes that it saves
        }

        private void cancelFileButton_Click_1(object sender, EventArgs e)
        {
            // Hide the save file panel without creating a file
            this.Close();
        }

        private void newFileButton_Click_1(object sender, EventArgs e)
        {
            ShowSaveFilePanel();
        }

        private void cutButton_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentlySelectedItemName))
            {
                cutItemPath = Path.Combine(filePath, currentlySelectedItemName);
                FileAttributes fileAttr = File.GetAttributes(cutItemPath);

                try
                {
                    if ((fileAttr & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        // Check if the directory is empty before moving
                        if (Directory.EnumerateFileSystemEntries(cutItemPath).Any())
                        {
                            MessageBox.Show("Cannot cut the directory because it is not empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Store the full path to the directory
                        cutItemPath = Path.GetFullPath(cutItemPath);

                        // No need to move directories immediately
                    }
                    else
                    {
                        // Check if the file is in use before moving
                        using (FileStream fs = File.Open(cutItemPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                        {
                            // If we reach here, the file is not in use
                        }

                        // Store the full path to the file
                        cutItemPath = Path.GetFullPath(cutItemPath);

                        // No need to move files immediately
                    }

                    // Don't perform the move here, just store the path
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Access to the file is denied. Make sure the file is not in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException)
                {
                    MessageBox.Show("An error occurred while moving the file. Make sure the file is not in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void copyButton_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentlySelectedItemName))
            {
                copiedItemPath = Path.Combine(filePath, currentlySelectedItemName);
            }
        }

        private void pasteButton_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(copiedItemPath) || !string.IsNullOrEmpty(cutItemPath))
            {
                string destinationPath = filePath;

                try
                {
                    // If there's a cut item, move it
                    if (!string.IsNullOrEmpty(cutItemPath))
                    {
                        if (File.Exists(cutItemPath))
                        {
                            // Check if the file is in use before moving
                            using (FileStream fs = File.Open(cutItemPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                            {
                                // If we reach here, the file is not in use
                            }

                            // Move the file
                            File.Move(cutItemPath, Path.Combine(destinationPath, Path.GetFileName(cutItemPath)));
                        }
                        else if (Directory.Exists(cutItemPath))
                        {
                            // Check if the directory is empty before moving
                            if (Directory.EnumerateFileSystemEntries(cutItemPath).Any())
                            {
                                MessageBox.Show("Cannot cut the directory because it is not empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Move the directory
                            Directory.Move(cutItemPath, Path.Combine(destinationPath, Path.GetFileName(cutItemPath)));
                        }

                        cutItemPath = ""; // Reset cut item after paste
                    }

                    // If there's a copied item, copy it
                    if (!string.IsNullOrEmpty(copiedItemPath))
                    {
                        string newFileName = Path.GetFileName(copiedItemPath);

                        // Check if the file already exists in the destination directory
                        string destinationFilePath = Path.Combine(destinationPath, newFileName);
                        int count = 1;
                        string fileNameOnly = Path.GetFileNameWithoutExtension(newFileName);
                        string extension = Path.GetExtension(newFileName);

                        // Append incrementing numbers until we find a unique name
                        while (File.Exists(destinationFilePath))
                        {
                            string tempFileName = string.Format("{0} ({1})", fileNameOnly, count++);
                            newFileName = tempFileName + extension;
                            destinationFilePath = Path.Combine(destinationPath, newFileName);
                        }

                        if (File.Exists(copiedItemPath))
                        {
                            // Check if the file is in use before copying
                            using (FileStream fs = File.Open(copiedItemPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                            {
                                // If we reach here, the file is not in use
                            }

                            // Copy the file
                            File.Copy(copiedItemPath, destinationFilePath);
                        }
                        else if (Directory.Exists(copiedItemPath))
                        {
                            // Copy the directory
                            CopyDirectory(copiedItemPath, Path.Combine(destinationPath, Path.GetFileName(copiedItemPath)));
                        }
                    }

                    // Refresh the file list
                    refreshFilesAndDirectories();

                    // Check if the pasted item is a text file
                    if (Path.GetExtension(copiedItemPath).ToLower() == ".txt")
                    {
                        // If it is a text file, do not open Form7
                        return;
                    }

                    // Open the pasted item in Form7 if it's not a text file
                    Form7 textEditorForm = new Form7(desktopInstance);
                    if (textEditorForm != null)
                    {
                        textEditorForm.openFile(Path.Combine(destinationPath, Path.GetFileName(copiedItemPath)));
                        textEditorForm.Show();
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Access to the file is denied. Make sure the file is not in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException)
                {
                    MessageBox.Show("An error occurred while pasting the file. Make sure the file is not in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void renameButton_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentlySelectedItemName))
            {
                MessageBox.Show("No item selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedItemPath = Path.Combine(filePath, currentlySelectedItemName);

            try
            {
                // Display a dialog to get the new name from the user
                string newName = GetNewNameFromUser(currentlySelectedItemName);
                if (string.IsNullOrEmpty(newName))
                {
                    // User canceled or entered an empty name
                    return;
                }

                // Combine the new name with the file path
                string newPath = Path.Combine(filePath, newName);

                if (File.Exists(selectedItemPath))
                {
                    // Check if the file is in use before renaming
                    using (FileStream fs = File.Open(selectedItemPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
                        // If we reach here, the file is not in use
                    }

                    // Rename the file
                    File.Move(selectedItemPath, newPath);
                }
                else if (Directory.Exists(selectedItemPath))
                {
                    // Check if the directory is empty before renaming
                    if (Directory.EnumerateFileSystemEntries(selectedItemPath).Any())
                    {
                        MessageBox.Show("Cannot rename the directory because it is not empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Rename the directory
                    Directory.Move(selectedItemPath, newPath);
                }

                // Refresh the file list after renaming
                refreshFilesAndDirectories();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access to the item is denied. Make sure it is not in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show("An error occurred while renaming the item. Make sure it is not in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteSelectedItem();
        }
    }
}