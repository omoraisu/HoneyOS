using System;
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

namespace HoneyOS
{
    
    public partial class Form5 : Form
    {
        private Desktop desktopInstance;
        private string filePath = "C:\\";
        private bool isFile = false;
        private string currentlySelectedItemName = "";

        public Form5(Desktop desktopInstance)
        {
            InitializeComponent();
            this.desktopInstance = desktopInstance;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            filePathTextBox.Text = filePath;
            loadFilesAndDirectories();
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
                    Process.Start(tempFilePath);
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
                        fileExtension = files[i].Extension.ToUpper();
                        switch (fileExtension)
                        {
                            case ".MP3":
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
                        }

                    }

                    for (int i = 0; i < dirs.Length; i++)
                    {
                        listView1.Items.Add(dirs[i].Name, 2);
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
            if(path.LastIndexOf("/") == path.Length - 1)
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

            if ((fileAttr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                isFile = false;
                filePathTextBox.Text = filePath + "/" + currentlySelectedItemName;
            }
            else
            {
                isFile = true;
            }

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            loadButtonAction();
        }

    }
}
