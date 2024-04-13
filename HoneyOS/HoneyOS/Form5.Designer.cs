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
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.fileTypeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(6, 5);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(25, 25);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "<";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(209, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(0, 0);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(34, 5);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(25, 25);
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
            this.textBox1.Location = new System.Drawing.Point(9, 78);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(46, 15);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Path:";
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filePathTextBox.Location = new System.Drawing.Point(44, 75);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(672, 21);
            this.filePathTextBox.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(65, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(651, 24);
            this.textBox3.TabIndex = 5;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.iconList;
            this.listView1.Location = new System.Drawing.Point(3, 132);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(710, 289);
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
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fileTypeLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.fileNameLabel);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.filePathTextBox);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.goButton);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.backButton);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Location = new System.Drawing.Point(-3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 125);
            this.panel1.TabIndex = 14;
            // 
            // fileTypeLabel
            // 
            this.fileTypeLabel.AutoSize = true;
            this.fileTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileTypeLabel.Location = new System.Drawing.Point(540, 102);
            this.fileTypeLabel.Name = "fileTypeLabel";
            this.fileTypeLabel.Size = new System.Drawing.Size(15, 15);
            this.fileTypeLabel.TabIndex = 16;
            this.fileTypeLabel.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(466, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "File Type:";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameLabel.Location = new System.Drawing.Point(84, 102);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(15, 15);
            this.fileNameLabel.TabIndex = 14;
            this.fileNameLabel.Text = "--";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "File Name:";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Window;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Image = global::HoneyOS.Properties.Resources.SEARCH_icon;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(325, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(73, 21);
            this.button4.TabIndex = 6;
            this.button4.Text = "Search";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.Image = global::HoneyOS.Properties.Resources.New_Copy;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(6, 36);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(84, 36);
            this.button5.TabIndex = 7;
            this.button5.Text = "New File";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Image = global::HoneyOS.Properties.Resources.Cut;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(91, 36);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(62, 36);
            this.button6.TabIndex = 8;
            this.button6.Text = "Cut";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Image = global::HoneyOS.Properties.Resources.delete;
            this.button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.Location = new System.Drawing.Point(379, 36);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(71, 36);
            this.button10.TabIndex = 12;
            this.button10.Text = "Delete";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Image = global::HoneyOS.Properties.Resources.Copy;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(154, 36);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(68, 36);
            this.button7.TabIndex = 9;
            this.button7.Text = "Copy";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Image = global::HoneyOS.Properties.Resources.rename_icon;
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(294, 36);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(84, 36);
            this.button9.TabIndex = 11;
            this.button9.Text = "Rename";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Image = global::HoneyOS.Properties.Resources.Paste;
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.Location = new System.Drawing.Point(223, 36);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(69, 36);
            this.button8.TabIndex = 10;
            this.button8.Text = "Paste";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 429);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form5";
            this.Text = "File Manager";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList iconList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label fileTypeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label label1;
    }
}