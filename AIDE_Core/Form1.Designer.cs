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
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.comboBoxCameras = new System.Windows.Forms.ComboBox();
            this.videoSourcePlayerFiltered = new AForge.Controls.VideoSourcePlayer();
            this.videoSourcePlayerClone = new AForge.Controls.VideoSourcePlayer();
            this.videoSourcePlayerOriginal = new AForge.Controls.VideoSourcePlayer();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBoxConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.Controls.Add(this.buttonDisconnect);
            this.groupBoxConnection.Controls.Add(this.comboBoxCameras);
            this.groupBoxConnection.Location = new System.Drawing.Point(13, 403);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(190, 100);
            this.groupBoxConnection.TabIndex = 17;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "Connection";
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(110, 53);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(75, 23);
            this.buttonDisconnect.TabIndex = 10;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.ButtonDisconnect_Click);
            // 
            // comboBoxCameras
            // 
            this.comboBoxCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameras.FormattingEnabled = true;
            this.comboBoxCameras.Location = new System.Drawing.Point(17, 26);
            this.comboBoxCameras.Name = "comboBoxCameras";
            this.comboBoxCameras.Size = new System.Drawing.Size(167, 21);
            this.comboBoxCameras.TabIndex = 5;
            this.comboBoxCameras.Visible = false;
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
            this.buttonStart.Location = new System.Drawing.Point(13, 509);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 13;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 556);
            this.Controls.Add(this.groupBoxConnection);
            this.Controls.Add(this.videoSourcePlayerFiltered);
            this.Controls.Add(this.videoSourcePlayerClone);
            this.Controls.Add(this.videoSourcePlayerOriginal);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Deactivate += new System.EventHandler(this.ButtonDisconnect_Click);
            this.groupBoxConnection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.ComboBox comboBoxCameras;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayerFiltered;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayerClone;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayerOriginal;
        private System.Windows.Forms.Button buttonStart;
    }
}

