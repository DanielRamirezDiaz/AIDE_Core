namespace AIDE_Core
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
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.videoSourcePlayerFiltered = new AForge.Controls.VideoSourcePlayer();
            this.videoSourcePlayerClone = new AForge.Controls.VideoSourcePlayer();
            this.videoSourcePlayerOriginal = new AForge.Controls.VideoSourcePlayer();
            this.buttonStart = new System.Windows.Forms.Button();
            this.numericUpDownTimeBetween = new System.Windows.Forms.NumericUpDown();
            this.labelTimeBetweenChecks = new System.Windows.Forms.Label();
            this.numericUpDownChecksForLock = new System.Windows.Forms.NumericUpDown();
            this.labelChecksForLock = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeBetween)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChecksForLock)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(93, 481);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(75, 23);
            this.buttonDisconnect.TabIndex = 4;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.ButtonDisconnect_Click);
            // 
            // videoSourcePlayerFiltered
            // 
            this.videoSourcePlayerFiltered.Location = new System.Drawing.Point(808, 12);
            this.videoSourcePlayerFiltered.Name = "videoSourcePlayerFiltered";
            this.videoSourcePlayerFiltered.Size = new System.Drawing.Size(392, 385);
            this.videoSourcePlayerFiltered.TabIndex = 16;
            this.videoSourcePlayerFiltered.Text = "videoSourcePlayer3";
            this.videoSourcePlayerFiltered.VideoSource = null;
            this.videoSourcePlayerFiltered.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayerFiltered_NewFrame);
            // 
            // videoSourcePlayerClone
            // 
            this.videoSourcePlayerClone.Location = new System.Drawing.Point(410, 12);
            this.videoSourcePlayerClone.Name = "videoSourcePlayerClone";
            this.videoSourcePlayerClone.Size = new System.Drawing.Size(392, 385);
            this.videoSourcePlayerClone.TabIndex = 15;
            this.videoSourcePlayerClone.Text = "videoSourcePlayer2";
            this.videoSourcePlayerClone.VideoSource = null;
            this.videoSourcePlayerClone.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayerClone_NewFrame);
            // 
            // videoSourcePlayerOriginal
            // 
            this.videoSourcePlayerOriginal.Location = new System.Drawing.Point(12, 12);
            this.videoSourcePlayerOriginal.Name = "videoSourcePlayerOriginal";
            this.videoSourcePlayerOriginal.Size = new System.Drawing.Size(392, 385);
            this.videoSourcePlayerOriginal.TabIndex = 14;
            this.videoSourcePlayerOriginal.Text = "videoSourcePlayer1";
            this.videoSourcePlayerOriginal.VideoSource = null;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 481);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // numericUpDownTimeBetween
            // 
            this.numericUpDownTimeBetween.Location = new System.Drawing.Point(12, 416);
            this.numericUpDownTimeBetween.Name = "numericUpDownTimeBetween";
            this.numericUpDownTimeBetween.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownTimeBetween.TabIndex = 1;
            this.numericUpDownTimeBetween.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // labelTimeBetweenChecks
            // 
            this.labelTimeBetweenChecks.AutoSize = true;
            this.labelTimeBetweenChecks.Location = new System.Drawing.Point(9, 400);
            this.labelTimeBetweenChecks.Name = "labelTimeBetweenChecks";
            this.labelTimeBetweenChecks.Size = new System.Drawing.Size(163, 13);
            this.labelTimeBetweenChecks.TabIndex = 21;
            this.labelTimeBetweenChecks.Text = "Time Between Checks (seconds)";
            // 
            // numericUpDownChecksForLock
            // 
            this.numericUpDownChecksForLock.Location = new System.Drawing.Point(12, 455);
            this.numericUpDownChecksForLock.Name = "numericUpDownChecksForLock";
            this.numericUpDownChecksForLock.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownChecksForLock.TabIndex = 2;
            this.numericUpDownChecksForLock.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // labelChecksForLock
            // 
            this.labelChecksForLock.AutoSize = true;
            this.labelChecksForLock.Location = new System.Drawing.Point(9, 439);
            this.labelChecksForLock.Name = "labelChecksForLock";
            this.labelChecksForLock.Size = new System.Drawing.Size(93, 13);
            this.labelChecksForLock.TabIndex = 23;
            this.labelChecksForLock.Text = "Checks Before Kill";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 516);
            this.Controls.Add(this.labelChecksForLock);
            this.Controls.Add(this.numericUpDownChecksForLock);
            this.Controls.Add(this.labelTimeBetweenChecks);
            this.Controls.Add(this.numericUpDownTimeBetween);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.videoSourcePlayerFiltered);
            this.Controls.Add(this.videoSourcePlayerClone);
            this.Controls.Add(this.videoSourcePlayerOriginal);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeBetween)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChecksForLock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonDisconnect;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayerFiltered;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayerClone;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayerOriginal;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeBetween;
        private System.Windows.Forms.Label labelTimeBetweenChecks;
        private System.Windows.Forms.NumericUpDown numericUpDownChecksForLock;
        private System.Windows.Forms.Label labelChecksForLock;
    }
}

