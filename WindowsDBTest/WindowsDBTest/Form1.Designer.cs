namespace WindowsDBTest
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.userDataOneID = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.userDataOneUN = new System.Windows.Forms.TextBox();
            this.userDataOnePW = new System.Windows.Forms.TextBox();
            this.unLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(119, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load Users";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // userDataOneID
            // 
            this.userDataOneID.Location = new System.Drawing.Point(12, 25);
            this.userDataOneID.Name = "userDataOneID";
            this.userDataOneID.Size = new System.Drawing.Size(100, 20);
            this.userDataOneID.TabIndex = 1;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(49, 9);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 13);
            this.idLabel.TabIndex = 2;
            this.idLabel.Text = "ID";
            // 
            // userDataOneUN
            // 
            this.userDataOneUN.Location = new System.Drawing.Point(119, 24);
            this.userDataOneUN.Name = "userDataOneUN";
            this.userDataOneUN.Size = new System.Drawing.Size(100, 20);
            this.userDataOneUN.TabIndex = 3;
            // 
            // userDataOnePW
            // 
            this.userDataOnePW.Location = new System.Drawing.Point(226, 24);
            this.userDataOnePW.Name = "userDataOnePW";
            this.userDataOnePW.Size = new System.Drawing.Size(100, 20);
            this.userDataOnePW.TabIndex = 4;
            // 
            // unLabel
            // 
            this.unLabel.AutoSize = true;
            this.unLabel.Location = new System.Drawing.Point(143, 9);
            this.unLabel.Name = "unLabel";
            this.unLabel.Size = new System.Drawing.Size(60, 13);
            this.unLabel.TabIndex = 5;
            this.unLabel.Text = "User Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Password";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 336);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unLabel);
            this.Controls.Add(this.userDataOnePW);
            this.Controls.Add(this.userDataOneUN);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.userDataOneID);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Access";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox userDataOneID;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox userDataOneUN;
        private System.Windows.Forms.TextBox userDataOnePW;
        private System.Windows.Forms.Label unLabel;
        private System.Windows.Forms.Label label1;
    }
}

