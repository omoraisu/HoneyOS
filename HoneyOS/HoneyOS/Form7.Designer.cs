namespace HoneyOS
{
    partial class Form7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            this.panel2 = new System.Windows.Forms.Panel();
            this.newWindow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.save = new System.Windows.Forms.Button();
            this.saveAs = new System.Windows.Forms.Button();
            this.copy = new System.Windows.Forms.Button();
            this.cut = new System.Windows.Forms.Button();
            this.paste = new System.Windows.Forms.Button();
            this.open = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse4 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse5 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse6 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse7 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Linen;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.newWindow);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.save);
            this.panel2.Controls.Add(this.saveAs);
            this.panel2.Controls.Add(this.copy);
            this.panel2.Controls.Add(this.cut);
            this.panel2.Controls.Add(this.paste);
            this.panel2.Controls.Add(this.open);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel2.Size = new System.Drawing.Size(254, 709);
            this.panel2.TabIndex = 7;
            // 
            // newWindow
            // 
            this.newWindow.BackColor = System.Drawing.Color.White;
            this.newWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newWindow.FlatAppearance.BorderSize = 0;
            this.newWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newWindow.Font = new System.Drawing.Font("Poppins", 9F);
            this.newWindow.Image = global::HoneyOS.Properties.Resources.New_Window;
            this.newWindow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newWindow.Location = new System.Drawing.Point(-38, 140);
            this.newWindow.Name = "newWindow";
            this.newWindow.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.newWindow.Size = new System.Drawing.Size(270, 65);
            this.newWindow.TabIndex = 11;
            this.newWindow.Text = "     New File";
            this.newWindow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newWindow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.newWindow.UseVisualStyleBackColor = false;
            this.newWindow.Click += new System.EventHandler(this.newWindow_Click);
            this.newWindow.MouseEnter += new System.EventHandler(this.newWindow_MouseEnter);
            this.newWindow.MouseLeave += new System.EventHandler(this.newWindow_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 15F);
            this.label1.Location = new System.Drawing.Point(88, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 53);
            this.label1.TabIndex = 10;
            this.label1.Text = "Notepad";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::HoneyOS.Properties.Resources.Note_App;
            this.pictureBox1.Location = new System.Drawing.Point(24, 52);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.White;
            this.save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save.Enabled = false;
            this.save.FlatAppearance.BorderSize = 0;
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save.Font = new System.Drawing.Font("Poppins", 9F);
            this.save.Image = global::HoneyOS.Properties.Resources.Save;
            this.save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.save.Location = new System.Drawing.Point(-38, 211);
            this.save.Name = "save";
            this.save.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.save.Size = new System.Drawing.Size(270, 65);
            this.save.TabIndex = 6;
            this.save.Text = "     Save";
            this.save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            this.save.MouseEnter += new System.EventHandler(this.save_MouseEnter);
            this.save.MouseLeave += new System.EventHandler(this.save_MouseLeave);
            // 
            // saveAs
            // 
            this.saveAs.BackColor = System.Drawing.Color.White;
            this.saveAs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveAs.Enabled = false;
            this.saveAs.FlatAppearance.BorderSize = 0;
            this.saveAs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveAs.Font = new System.Drawing.Font("Poppins", 9F);
            this.saveAs.Image = global::HoneyOS.Properties.Resources.Save_as;
            this.saveAs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveAs.Location = new System.Drawing.Point(-38, 282);
            this.saveAs.Name = "saveAs";
            this.saveAs.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.saveAs.Size = new System.Drawing.Size(270, 65);
            this.saveAs.TabIndex = 1;
            this.saveAs.Text = "     Save As";
            this.saveAs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveAs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveAs.UseVisualStyleBackColor = false;
            this.saveAs.Click += new System.EventHandler(this.saveAs_Click);
            this.saveAs.MouseEnter += new System.EventHandler(this.saveAs_MouseEnter);
            this.saveAs.MouseLeave += new System.EventHandler(this.saveAs_MouseLeave);
            // 
            // copy
            // 
            this.copy.BackColor = System.Drawing.Color.White;
            this.copy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.copy.Enabled = false;
            this.copy.FlatAppearance.BorderSize = 0;
            this.copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copy.Font = new System.Drawing.Font("Poppins", 9F);
            this.copy.Image = global::HoneyOS.Properties.Resources.Copy;
            this.copy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.copy.Location = new System.Drawing.Point(-38, 494);
            this.copy.Name = "copy";
            this.copy.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.copy.Size = new System.Drawing.Size(270, 65);
            this.copy.TabIndex = 4;
            this.copy.Text = "      Copy";
            this.copy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.copy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.copy.UseVisualStyleBackColor = false;
            this.copy.Click += new System.EventHandler(this.copy_Click);
            this.copy.MouseEnter += new System.EventHandler(this.copy_MouseEnter);
            this.copy.MouseLeave += new System.EventHandler(this.copy_MouseLeave);
            // 
            // cut
            // 
            this.cut.BackColor = System.Drawing.Color.White;
            this.cut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cut.Enabled = false;
            this.cut.FlatAppearance.BorderSize = 0;
            this.cut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cut.Font = new System.Drawing.Font("Poppins", 9F);
            this.cut.Image = global::HoneyOS.Properties.Resources.Cut;
            this.cut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cut.Location = new System.Drawing.Point(-38, 423);
            this.cut.Name = "cut";
            this.cut.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.cut.Size = new System.Drawing.Size(270, 65);
            this.cut.TabIndex = 3;
            this.cut.Text = "     Cut";
            this.cut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cut.UseVisualStyleBackColor = false;
            this.cut.Click += new System.EventHandler(this.cut_Click);
            this.cut.MouseEnter += new System.EventHandler(this.cut_MouseEnter);
            this.cut.MouseLeave += new System.EventHandler(this.cut_MouseLeave);
            // 
            // paste
            // 
            this.paste.BackColor = System.Drawing.Color.White;
            this.paste.Cursor = System.Windows.Forms.Cursors.Hand;
            this.paste.FlatAppearance.BorderSize = 0;
            this.paste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paste.Font = new System.Drawing.Font("Poppins", 9F);
            this.paste.Image = global::HoneyOS.Properties.Resources.Paste;
            this.paste.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paste.Location = new System.Drawing.Point(-38, 565);
            this.paste.Name = "paste";
            this.paste.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.paste.Size = new System.Drawing.Size(270, 65);
            this.paste.TabIndex = 5;
            this.paste.Text = "      Paste";
            this.paste.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paste.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.paste.UseVisualStyleBackColor = false;
            this.paste.Click += new System.EventHandler(this.paste_Click);
            this.paste.MouseEnter += new System.EventHandler(this.paste_MouseEnter);
            this.paste.MouseLeave += new System.EventHandler(this.paste_MouseLeave);
            // 
            // open
            // 
            this.open.BackColor = System.Drawing.Color.White;
            this.open.Cursor = System.Windows.Forms.Cursors.Hand;
            this.open.FlatAppearance.BorderSize = 0;
            this.open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.open.Font = new System.Drawing.Font("Poppins", 9F);
            this.open.Image = global::HoneyOS.Properties.Resources.Opened_Folder;
            this.open.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.open.Location = new System.Drawing.Point(-38, 352);
            this.open.Name = "open";
            this.open.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.open.Size = new System.Drawing.Size(270, 65);
            this.open.TabIndex = 2;
            this.open.Text = "     Open";
            this.open.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.open.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.open.UseVisualStyleBackColor = false;
            this.open.Click += new System.EventHandler(this.open_Click);
            this.open.MouseEnter += new System.EventHandler(this.open_MouseEnter);
            this.open.MouseLeave += new System.EventHandler(this.open_MouseLeave);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.richTextBox1.Location = new System.Drawing.Point(254, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(822, 709);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 40;
            this.bunifuElipse2.TargetControl = this.saveAs;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 40;
            this.bunifuElipse3.TargetControl = this.open;
            // 
            // bunifuElipse4
            // 
            this.bunifuElipse4.ElipseRadius = 40;
            this.bunifuElipse4.TargetControl = this.cut;
            // 
            // bunifuElipse5
            // 
            this.bunifuElipse5.ElipseRadius = 40;
            this.bunifuElipse5.TargetControl = this.copy;
            // 
            // bunifuElipse6
            // 
            this.bunifuElipse6.ElipseRadius = 40;
            this.bunifuElipse6.TargetControl = this.paste;
            // 
            // bunifuElipse7
            // 
            this.bunifuElipse7.ElipseRadius = 40;
            this.bunifuElipse7.TargetControl = this.save;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 40;
            this.bunifuElipse1.TargetControl = this.newWindow;
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 709);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form7";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form7_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form7_FormClosed);
            this.Load += new System.EventHandler(this.Form7_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button saveAs;
        private System.Windows.Forms.Button copy;
        private System.Windows.Forms.Button cut;
        private System.Windows.Forms.Button paste;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse4;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse5;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse6;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newWindow;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}