namespace MFS100_VS2013
{
    partial class frmMFS100
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMFS100));
            this.btnInit = new System.Windows.Forms.Button();
            this.btnStartCapture = new System.Windows.Forms.Button();
            this.btnStopCapture = new System.Windows.Forms.Button();
            this.btnUninit = new System.Windows.Forms.Button();
            this.picFinger = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnAutoCapture = new System.Windows.Forms.Button();
            this.chkShowPreview = new System.Windows.Forms.CheckBox();
            this.btnCheckDevice = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuality = new System.Windows.Forms.TextBox();
            this.btnVersion = new System.Windows.Forms.Button();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMatchISOTemplate = new System.Windows.Forms.Button();
            this.btnMatchANSITemplate = new System.Windows.Forms.Button();
            this.lblSerial = new System.Windows.Forms.Label();
            this.chkIsDetectFinger = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picFinger)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInit
            // 
            this.btnInit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnInit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnInit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInit.Location = new System.Drawing.Point(17, 135);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(105, 30);
            this.btnInit.TabIndex = 2;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = false;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnStartCapture
            // 
            this.btnStartCapture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnStartCapture.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnStartCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartCapture.Location = new System.Drawing.Point(17, 274);
            this.btnStartCapture.Name = "btnStartCapture";
            this.btnStartCapture.Size = new System.Drawing.Size(105, 30);
            this.btnStartCapture.TabIndex = 6;
            this.btnStartCapture.Text = "Start Capture";
            this.btnStartCapture.UseVisualStyleBackColor = false;
            this.btnStartCapture.Click += new System.EventHandler(this.btnStartCapture_Click);
            // 
            // btnStopCapture
            // 
            this.btnStopCapture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnStopCapture.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnStopCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopCapture.Location = new System.Drawing.Point(17, 306);
            this.btnStopCapture.Name = "btnStopCapture";
            this.btnStopCapture.Size = new System.Drawing.Size(105, 30);
            this.btnStopCapture.TabIndex = 7;
            this.btnStopCapture.Text = "Stop Capture";
            this.btnStopCapture.UseVisualStyleBackColor = false;
            this.btnStopCapture.Click += new System.EventHandler(this.btnStopCapture_Click);
            // 
            // btnUninit
            // 
            this.btnUninit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnUninit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnUninit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUninit.Location = new System.Drawing.Point(17, 467);
            this.btnUninit.Name = "btnUninit";
            this.btnUninit.Size = new System.Drawing.Size(105, 30);
            this.btnUninit.TabIndex = 11;
            this.btnUninit.Text = "Uninit";
            this.btnUninit.UseVisualStyleBackColor = false;
            this.btnUninit.Click += new System.EventHandler(this.btnUninit_Click);
            // 
            // picFinger
            // 
            this.picFinger.BackColor = System.Drawing.Color.White;
            this.picFinger.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFinger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFinger.Location = new System.Drawing.Point(130, 69);
            this.picFinger.Name = "picFinger";
            this.picFinger.Size = new System.Drawing.Size(396, 429);
            this.picFinger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFinger.TabIndex = 4;
            this.picFinger.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(127, 503);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(399, 40);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAutoCapture
            // 
            this.btnAutoCapture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAutoCapture.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnAutoCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoCapture.Location = new System.Drawing.Point(17, 366);
            this.btnAutoCapture.Name = "btnAutoCapture";
            this.btnAutoCapture.Size = new System.Drawing.Size(105, 30);
            this.btnAutoCapture.TabIndex = 8;
            this.btnAutoCapture.Text = "Auto Capture";
            this.btnAutoCapture.UseVisualStyleBackColor = false;
            this.btnAutoCapture.Click += new System.EventHandler(this.btnAutoCapture_Click);
            // 
            // chkShowPreview
            // 
            this.chkShowPreview.AutoSize = true;
            this.chkShowPreview.Checked = true;
            this.chkShowPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowPreview.ForeColor = System.Drawing.Color.White;
            this.chkShowPreview.Location = new System.Drawing.Point(21, 170);
            this.chkShowPreview.Name = "chkShowPreview";
            this.chkShowPreview.Size = new System.Drawing.Size(94, 17);
            this.chkShowPreview.TabIndex = 3;
            this.chkShowPreview.Text = "Show Preview";
            this.chkShowPreview.UseVisualStyleBackColor = true;
            // 
            // btnCheckDevice
            // 
            this.btnCheckDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCheckDevice.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCheckDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckDevice.Location = new System.Drawing.Point(17, 102);
            this.btnCheckDevice.Name = "btnCheckDevice";
            this.btnCheckDevice.Size = new System.Drawing.Size(105, 30);
            this.btnCheckDevice.TabIndex = 1;
            this.btnCheckDevice.Text = "Check Device";
            this.btnCheckDevice.UseVisualStyleBackColor = false;
            this.btnCheckDevice.Click += new System.EventHandler(this.btnCheckDevice_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Quality (1 to 100)";
            // 
            // txtQuality
            // 
            this.txtQuality.Location = new System.Drawing.Point(21, 207);
            this.txtQuality.MaxLength = 2;
            this.txtQuality.Name = "txtQuality";
            this.txtQuality.Size = new System.Drawing.Size(101, 20);
            this.txtQuality.TabIndex = 4;
            this.txtQuality.Text = "55";
            // 
            // btnVersion
            // 
            this.btnVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnVersion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVersion.Location = new System.Drawing.Point(17, 69);
            this.btnVersion.Name = "btnVersion";
            this.btnVersion.Size = new System.Drawing.Size(105, 30);
            this.btnVersion.TabIndex = 0;
            this.btnVersion.Text = "Version";
            this.btnVersion.UseVisualStyleBackColor = false;
            this.btnVersion.Click += new System.EventHandler(this.btnVersion_Click);
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(21, 248);
            this.txtTimeout.MaxLength = 5;
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(101, 20);
            this.txtTimeout.TabIndex = 5;
            this.txtTimeout.Text = "10000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Timeout (ms)";
            // 
            // btnMatchISOTemplate
            // 
            this.btnMatchISOTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnMatchISOTemplate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnMatchISOTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMatchISOTemplate.Location = new System.Drawing.Point(17, 400);
            this.btnMatchISOTemplate.Name = "btnMatchISOTemplate";
            this.btnMatchISOTemplate.Size = new System.Drawing.Size(105, 30);
            this.btnMatchISOTemplate.TabIndex = 9;
            this.btnMatchISOTemplate.Text = "Match ISO";
            this.btnMatchISOTemplate.UseVisualStyleBackColor = false;
            this.btnMatchISOTemplate.Click += new System.EventHandler(this.btnMatchISOTemplate_Click);
            // 
            // btnMatchANSITemplate
            // 
            this.btnMatchANSITemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnMatchANSITemplate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnMatchANSITemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMatchANSITemplate.Location = new System.Drawing.Point(17, 434);
            this.btnMatchANSITemplate.Name = "btnMatchANSITemplate";
            this.btnMatchANSITemplate.Size = new System.Drawing.Size(105, 30);
            this.btnMatchANSITemplate.TabIndex = 10;
            this.btnMatchANSITemplate.Text = "Match ANSI";
            this.btnMatchANSITemplate.UseVisualStyleBackColor = false;
            this.btnMatchANSITemplate.Click += new System.EventHandler(this.btnMatchANSITemplate_Click);
            // 
            // lblSerial
            // 
            this.lblSerial.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerial.ForeColor = System.Drawing.Color.White;
            this.lblSerial.Location = new System.Drawing.Point(0, 0);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(538, 50);
            this.lblSerial.TabIndex = 13;
            this.lblSerial.Text = "Serial";
            this.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkIsDetectFinger
            // 
            this.chkIsDetectFinger.AutoSize = true;
            this.chkIsDetectFinger.Checked = true;
            this.chkIsDetectFinger.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsDetectFinger.ForeColor = System.Drawing.Color.White;
            this.chkIsDetectFinger.Location = new System.Drawing.Point(21, 343);
            this.chkIsDetectFinger.Name = "chkIsDetectFinger";
            this.chkIsDetectFinger.Size = new System.Drawing.Size(90, 17);
            this.chkIsDetectFinger.TabIndex = 14;
            this.chkIsDetectFinger.Text = "Detect Finger";
            this.chkIsDetectFinger.UseVisualStyleBackColor = true;
            // 
            // frmMFS100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(538, 552);
            this.Controls.Add(this.chkIsDetectFinger);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.btnMatchISOTemplate);
            this.Controls.Add(this.btnMatchANSITemplate);
            this.Controls.Add(this.txtTimeout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnVersion);
            this.Controls.Add(this.txtQuality);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCheckDevice);
            this.Controls.Add(this.chkShowPreview);
            this.Controls.Add(this.btnAutoCapture);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.picFinger);
            this.Controls.Add(this.btnUninit);
            this.Controls.Add(this.btnStopCapture);
            this.Controls.Add(this.btnStartCapture);
            this.Controls.Add(this.btnInit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMFS100";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MFS100 Ver: 9.0.1.1 - MANTRA SOFTECH INDIA PVT. LTD.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMFS100_FormClosing);
            this.Load += new System.EventHandler(this.frmMFS100_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFinger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnStartCapture;
        private System.Windows.Forms.Button btnStopCapture;
        private System.Windows.Forms.Button btnUninit;
        private System.Windows.Forms.PictureBox picFinger;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnAutoCapture;
        private System.Windows.Forms.CheckBox chkShowPreview;
        private System.Windows.Forms.Button btnCheckDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuality;
        private System.Windows.Forms.Button btnVersion;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMatchISOTemplate;
        private System.Windows.Forms.Button btnMatchANSITemplate;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.CheckBox chkIsDetectFinger;
    }
}