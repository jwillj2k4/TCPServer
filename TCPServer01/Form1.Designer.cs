namespace TCPServer01
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
            this.tbConsoleOutput = new System.Windows.Forms.TextBox();
            this.tbIpAddress = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartListening = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbPayload = new System.Windows.Forms.TextBox();
            this.btnFindIp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbConsoleOutput
            // 
            this.tbConsoleOutput.Location = new System.Drawing.Point(12, 25);
            this.tbConsoleOutput.Multiline = true;
            this.tbConsoleOutput.Name = "tbConsoleOutput";
            this.tbConsoleOutput.Size = new System.Drawing.Size(760, 375);
            this.tbConsoleOutput.TabIndex = 1;
            // 
            // tbIpAddress
            // 
            this.tbIpAddress.Location = new System.Drawing.Point(97, 422);
            this.tbIpAddress.Name = "tbIpAddress";
            this.tbIpAddress.Size = new System.Drawing.Size(121, 20);
            this.tbIpAddress.TabIndex = 2;
            this.tbIpAddress.Text = "192.168.0.9";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(224, 422);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(132, 20);
            this.tbPort.TabIndex = 3;
            this.tbPort.Text = "23000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ip / Port";
            // 
            // btnStartListening
            // 
            this.btnStartListening.Location = new System.Drawing.Point(97, 448);
            this.btnStartListening.Name = "btnStartListening";
            this.btnStartListening.Size = new System.Drawing.Size(259, 23);
            this.btnStartListening.TabIndex = 5;
            this.btnStartListening.Text = "Start Listening";
            this.btnStartListening.UseVisualStyleBackColor = true;
            this.btnStartListening.Click += new System.EventHandler(this.btnStartListening_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(643, 448);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(129, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbPayload
            // 
            this.tbPayload.Location = new System.Drawing.Point(643, 415);
            this.tbPayload.Name = "tbPayload";
            this.tbPayload.Size = new System.Drawing.Size(129, 20);
            this.tbPayload.TabIndex = 7;
            // 
            // btnFindIp
            // 
            this.btnFindIp.Location = new System.Drawing.Point(362, 448);
            this.btnFindIp.Name = "btnFindIp";
            this.btnFindIp.Size = new System.Drawing.Size(83, 23);
            this.btnFindIp.TabIndex = 8;
            this.btnFindIp.Text = "Find Ip";
            this.btnFindIp.UseVisualStyleBackColor = true;
            this.btnFindIp.Click += new System.EventHandler(this.btnFindIp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 483);
            this.Controls.Add(this.btnFindIp);
            this.Controls.Add(this.tbPayload);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnStartListening);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbIpAddress);
            this.Controls.Add(this.tbConsoleOutput);
            this.Name = "Form1";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbConsoleOutput;
        private System.Windows.Forms.TextBox tbIpAddress;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartListening;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbPayload;
        private System.Windows.Forms.Button btnFindIp;
    }
}

