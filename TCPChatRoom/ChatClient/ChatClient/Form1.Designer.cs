namespace ChatClient
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
            this.nameLbl = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.conversationText = new System.Windows.Forms.TextBox();
            this.msgText = new System.Windows.Forms.TextBox();
            this.msgBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(12, 21);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(87, 13);
            this.nameLbl.TabIndex = 0;
            this.nameLbl.Text = "Enter your name:";
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(109, 18);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(165, 20);
            this.nameText.TabIndex = 1;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(109, 44);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(165, 23);
            this.connectBtn.TabIndex = 2;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // conversationText
            // 
            this.conversationText.Location = new System.Drawing.Point(15, 73);
            this.conversationText.Multiline = true;
            this.conversationText.Name = "conversationText";
            this.conversationText.Size = new System.Drawing.Size(259, 195);
            this.conversationText.TabIndex = 3;
            // 
            // msgText
            // 
            this.msgText.Location = new System.Drawing.Point(15, 274);
            this.msgText.Name = "msgText";
            this.msgText.Size = new System.Drawing.Size(259, 20);
            this.msgText.TabIndex = 4;
            // 
            // msgBtn
            // 
            this.msgBtn.Location = new System.Drawing.Point(109, 300);
            this.msgBtn.Name = "msgBtn";
            this.msgBtn.Size = new System.Drawing.Size(165, 23);
            this.msgBtn.TabIndex = 5;
            this.msgBtn.Text = "Send";
            this.msgBtn.UseVisualStyleBackColor = true;
            this.msgBtn.Click += new System.EventHandler(this.msgBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 342);
            this.Controls.Add(this.msgBtn);
            this.Controls.Add(this.msgText);
            this.Controls.Add(this.conversationText);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.nameLbl);
            this.Name = "Form1";
            this.Text = "Chat Room";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.TextBox conversationText;
        private System.Windows.Forms.TextBox msgText;
        private System.Windows.Forms.Button msgBtn;
    }
}

