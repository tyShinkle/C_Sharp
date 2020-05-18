namespace ClientSocket
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
            this.Connect = new System.Windows.Forms.Button();
            this.connectStatus = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.TextBox();
            this.response = new System.Windows.Forms.TextBox();
            this.send = new System.Windows.Forms.Button();
            this.responseLbl = new System.Windows.Forms.Label();
            this.messageLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(163, 153);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(125, 23);
            this.Connect.TabIndex = 0;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // connectStatus
            // 
            this.connectStatus.AutoSize = true;
            this.connectStatus.Location = new System.Drawing.Point(208, 179);
            this.connectStatus.Name = "connectStatus";
            this.connectStatus.Size = new System.Drawing.Size(80, 13);
            this.connectStatus.TabIndex = 1;
            this.connectStatus.Text = "No connection.";
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(86, 77);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(202, 20);
            this.message.TabIndex = 2;
            this.message.Text = "message";
            // 
            // response
            // 
            this.response.Location = new System.Drawing.Point(86, 41);
            this.response.Name = "response";
            this.response.Size = new System.Drawing.Size(202, 20);
            this.response.TabIndex = 3;
            this.response.Text = "response";
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(163, 103);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(125, 23);
            this.send.TabIndex = 4;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // responseLbl
            // 
            this.responseLbl.AutoSize = true;
            this.responseLbl.Location = new System.Drawing.Point(22, 44);
            this.responseLbl.Name = "responseLbl";
            this.responseLbl.Size = new System.Drawing.Size(58, 13);
            this.responseLbl.TabIndex = 5;
            this.responseLbl.Text = "Response:";
            // 
            // messageLbl
            // 
            this.messageLbl.AutoSize = true;
            this.messageLbl.Location = new System.Drawing.Point(27, 80);
            this.messageLbl.Name = "messageLbl";
            this.messageLbl.Size = new System.Drawing.Size(53, 13);
            this.messageLbl.TabIndex = 6;
            this.messageLbl.Text = "Message:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 207);
            this.Controls.Add(this.messageLbl);
            this.Controls.Add(this.responseLbl);
            this.Controls.Add(this.send);
            this.Controls.Add(this.response);
            this.Controls.Add(this.message);
            this.Controls.Add(this.connectStatus);
            this.Controls.Add(this.Connect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Label connectStatus;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.TextBox response;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.Label responseLbl;
        private System.Windows.Forms.Label messageLbl;
    }
}

