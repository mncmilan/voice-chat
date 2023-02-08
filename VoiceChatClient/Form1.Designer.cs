namespace VoiceChatClient
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
            this.recordButton = new System.Windows.Forms.Button();
            this.stopRecordButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.receiveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // recordButton
            // 
            this.recordButton.Location = new System.Drawing.Point(48, 54);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(129, 63);
            this.recordButton.TabIndex = 0;
            this.recordButton.Text = "Record";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // stopRecordButton
            // 
            this.stopRecordButton.Location = new System.Drawing.Point(194, 54);
            this.stopRecordButton.Name = "stopRecordButton";
            this.stopRecordButton.Size = new System.Drawing.Size(129, 63);
            this.stopRecordButton.TabIndex = 1;
            this.stopRecordButton.Text = "Stop recording";
            this.stopRecordButton.UseVisualStyleBackColor = true;
            this.stopRecordButton.Click += new System.EventHandler(this.stopRecordButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(48, 136);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(275, 63);
            this.playButton.TabIndex = 2;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(368, 54);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(164, 63);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // receiveButton
            // 
            this.receiveButton.Location = new System.Drawing.Point(368, 136);
            this.receiveButton.Name = "receiveButton";
            this.receiveButton.Size = new System.Drawing.Size(164, 63);
            this.receiveButton.TabIndex = 4;
            this.receiveButton.Text = "Receive";
            this.receiveButton.UseVisualStyleBackColor = true;
            this.receiveButton.Click += new System.EventHandler(this.receiveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 237);
            this.Controls.Add(this.receiveButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.stopRecordButton);
            this.Controls.Add(this.recordButton);
            this.Name = "Form1";
            this.Text = "Voice Chat";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Button stopRecordButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button receiveButton;
    }
}

