namespace HoneyOS
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.backButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.goButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.fileTypeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.newFileButton = new System.Windows.Forms.Button();
            this.cutButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.pasteButton = new System.Windows.Forms.Button();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.cancelFileButton = new System.Windows.Forms.Button();
            this.saveFileName = new System.Windows.Forms.TextBox();
            this.saveFileNameLabel = new System.Windows.Forms.Label();
            this.saveFileTypeLabel = new System.Windows.Forms.Label();
            this.saveFilePanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.saveFilePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(8, 6);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(33, 31);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "<";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(279, 53);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(0, 0);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(45, 6);
            this.goButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(33, 31);
            this.goButton.TabIndex = 2;
            this.goButton.Text = ">";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(85, 14);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(61, 19);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Path:";
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filePathTextBox.Location = new System.Drawing.Point(133, 11);
            this.filePathTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(820, 24);
            this.filePathTextBox.TabIndex = 4;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.iconList;
            this.listView1.Location = new System.Drawing.Point(4, 117);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(945, 309);
            this.listView1.SmallImageList = this.iconList;
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "DOC icon.png");
            this.iconList.Images.SetKeyName(1, "EXE icon.png");
            this.iconList.Images.SetKeyName(2, "FOLDER icon.png");
            this.iconList.Images.SetKeyName(3, "MP3 icon.png");
            this.iconList.Images.SetKeyName(4, "MP4 icon.png");
            this.iconList.Images.SetKeyName(5, "PDF icon.png");
            this.iconList.Images.SetKeyName(6, "PNG icon.png");
            this.iconList.Images.SetKeyName(7, "FILE icon.png");
            this.iconList.Images.SetKeyName(8, "Voice Indicator (Works).png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fileTypeLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.fileNameLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.filePathTextBox);
            this.panel1.Controls.Add(this.newFileButton);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.cutButton);
            this.panel1.Controls.Add(this.goButton);
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.copyButton);
            this.panel1.Controls.Add(this.backButton);
            this.panel1.Controls.Add(this.renameButton);
            this.panel1.Controls.Add(this.pasteButton);
            this.panel1.Location = new System.Drawing.Point(-4, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 110);
            this.panel1.TabIndex = 14;
            // 
            // fileTypeLabel
            // 
            this.fileTypeLabel.AutoSize = true;
            this.fileTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileTypeLabel.Location = new System.Drawing.Point(708, 70);
            this.fileTypeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileTypeLabel.Name = "fileTypeLabel";
            this.fileTypeLabel.Size = new System.Drawing.Size(18, 18);
            this.fileTypeLabel.TabIndex = 16;
            this.fileTypeLabel.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(621, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "File Type:";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameLabel.Location = new System.Drawing.Point(720, 44);
            this.fileNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(18, 18);
            this.fileNameLabel.TabIndex = 14;
            this.fileNameLabel.Text = "--";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(621, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "File Name:";
            // 
            // newFileButton
            // 
            this.newFileButton.Image = global::HoneyOS.Properties.Resources.New_Copy;
            this.newFileButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newFileButton.Location = new System.Drawing.Point(8, 44);
            this.newFileButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.newFileButton.Name = "newFileButton";
            this.newFileButton.Size = new System.Drawing.Size(112, 44);
            this.newFileButton.TabIndex = 7;
            this.newFileButton.Text = "New File";
            this.newFileButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.newFileButton.UseVisualStyleBackColor = true;
            this.newFileButton.Click += new System.EventHandler(this.newFileButton_Click_1);
            // 
            // cutButton
            // 
            this.cutButton.Image = global::HoneyOS.Properties.Resources.Cut;
            this.cutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cutButton.Location = new System.Drawing.Point(121, 44);
            this.cutButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cutButton.Name = "cutButton";
            this.cutButton.Size = new System.Drawing.Size(83, 44);
            this.cutButton.TabIndex = 8;
            this.cutButton.Text = "Cut";
            this.cutButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cutButton.UseVisualStyleBackColor = true;
            this.cutButton.Click += new System.EventHandler(this.cutButton_Click_1);
            // 
            // deleteButton
            // 
            this.deleteButton.Image = global::HoneyOS.Properties.Resources.delete;
            this.deleteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteButton.Location = new System.Drawing.Point(505, 44);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(95, 44);
            this.deleteButton.TabIndex = 12;
            this.deleteButton.Text = "Delete";
            this.deleteButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.Image = global::HoneyOS.Properties.Resources.Copy;
            this.copyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.copyButton.Location = new System.Drawing.Point(205, 44);
            this.copyButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(91, 44);
            this.copyButton.TabIndex = 9;
            this.copyButton.Text = "Copy";
            this.copyButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click_1);
            // 
            // renameButton
            // 
            this.renameButton.Image = global::HoneyOS.Properties.Resources.rename_icon;
            this.renameButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.renameButton.Location = new System.Drawing.Point(392, 44);
            this.renameButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(112, 44);
            this.renameButton.TabIndex = 11;
            this.renameButton.Text = "Rename";
            this.renameButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click_1);
            // 
            // pasteButton
            // 
            this.pasteButton.Image = global::HoneyOS.Properties.Resources.Paste;
            this.pasteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pasteButton.Location = new System.Drawing.Point(297, 44);
            this.pasteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(92, 44);
            this.pasteButton.TabIndex = 10;
            this.pasteButton.Text = "Paste";
            this.pasteButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pasteButton.UseVisualStyleBackColor = true;
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click_1);
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(711, 18);
            this.saveFileButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(100, 28);
            this.saveFileButton.TabIndex = 15;
            this.saveFileButton.Text = "Save";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click_1);
            // 
            // cancelFileButton
            // 
            this.cancelFileButton.Location = new System.Drawing.Point(711, 50);
            this.cancelFileButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelFileButton.Name = "cancelFileButton";
            this.cancelFileButton.Size = new System.Drawing.Size(100, 28);
            this.cancelFileButton.TabIndex = 16;
            this.cancelFileButton.Text = "Cancel";
            this.cancelFileButton.UseVisualStyleBackColor = true;
            this.cancelFileButton.Click += new System.EventHandler(this.cancelFileButton_Click_1);
            // 
            // saveFileName
            // 
            this.saveFileName.Location = new System.Drawing.Point(241, 18);
            this.saveFileName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveFileName.Name = "saveFileName";
            this.saveFileName.Size = new System.Drawing.Size(460, 22);
            this.saveFileName.TabIndex = 17;
            // 
            // saveFileNameLabel
            // 
            this.saveFileNameLabel.AutoSize = true;
            this.saveFileNameLabel.Location = new System.Drawing.Point(164, 25);
            this.saveFileNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.saveFileNameLabel.Name = "saveFileNameLabel";
            this.saveFileNameLabel.Size = new System.Drawing.Size(72, 16);
            this.saveFileNameLabel.TabIndex = 18;
            this.saveFileNameLabel.Text = "File Name:";
            // 
            // saveFileTypeLabel
            // 
            this.saveFileTypeLabel.AutoSize = true;
            this.saveFileTypeLabel.Location = new System.Drawing.Point(164, 57);
            this.saveFileTypeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.saveFileTypeLabel.Name = "saveFileTypeLabel";
            this.saveFileTypeLabel.Size = new System.Drawing.Size(229, 16);
            this.saveFileTypeLabel.TabIndex = 19;
            this.saveFileTypeLabel.Text = "File Type: Text document (*.txt; *.TXT)";
            // 
            // saveFilePanel
            // 
            this.saveFilePanel.Controls.Add(this.saveFileName);
            this.saveFilePanel.Controls.Add(this.saveFileTypeLabel);
            this.saveFilePanel.Controls.Add(this.saveFileButton);
            this.saveFilePanel.Controls.Add(this.saveFileNameLabel);
            this.saveFilePanel.Controls.Add(this.cancelFileButton);
            this.saveFilePanel.Location = new System.Drawing.Point(4, 434);
            this.saveFilePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveFilePanel.Name = "saveFilePanel";
            this.saveFilePanel.Size = new System.Drawing.Size(945, 90);
            this.saveFilePanel.TabIndex = 20;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 528);
            this.Controls.Add(this.saveFilePanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form5";
            this.Text = "File Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form5_FormClosed);
            this.Load += new System.EventHandler(this.Form5_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.saveFilePanel.ResumeLayout(false);
            this.saveFilePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Button newFileButton;
        private System.Windows.Forms.Button cutButton;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button pasteButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList iconList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label fileTypeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.Button cancelFileButton;
        private System.Windows.Forms.TextBox saveFileName;
        private System.Windows.Forms.Label saveFileNameLabel;
        private System.Windows.Forms.Label saveFileTypeLabel;
        private System.Windows.Forms.Panel saveFilePanel;
    }
}