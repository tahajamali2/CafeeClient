namespace CafeClient
{
    partial class CommandControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandControl));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1_code = new System.Windows.Forms.Label();
            this.label_code_value = new System.Windows.Forms.Label();
            this.label_elapsed = new System.Windows.Forms.Label();
            this.label2_collon1 = new System.Windows.Forms.Label();
            this.label_hour = new System.Windows.Forms.Label();
            this.label_minute = new System.Windows.Forms.Label();
            this.label_collon2 = new System.Windows.Forms.Label();
            this.label_second = new System.Windows.Forms.Label();
            this.metroButton_logoff = new MetroFramework.Controls.MetroButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.metroButton_pause = new MetroFramework.Controls.MetroButton();
            this.toolTip_setting = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox_minimize = new System.Windows.Forms.PictureBox();
            this.pictureBox_setting = new System.Windows.Forms.PictureBox();
            this.toolTip_minimize = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIcon_minimize = new System.Windows.Forms.NotifyIcon(this.components);
            this.backgroundWorker_processviewer = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_setting)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label1_code
            // 
            this.label1_code.AutoSize = true;
            this.label1_code.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_code.Location = new System.Drawing.Point(18, 44);
            this.label1_code.Name = "label1_code";
            this.label1_code.Size = new System.Drawing.Size(86, 15);
            this.label1_code.TabIndex = 0;
            this.label1_code.Text = "Session code #";
            // 
            // label_code_value
            // 
            this.label_code_value.AutoSize = true;
            this.label_code_value.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_code_value.Location = new System.Drawing.Point(110, 41);
            this.label_code_value.Name = "label_code_value";
            this.label_code_value.Size = new System.Drawing.Size(81, 20);
            this.label_code_value.TabIndex = 1;
            this.label_code_value.Text = "########";
            // 
            // label_elapsed
            // 
            this.label_elapsed.AutoSize = true;
            this.label_elapsed.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_elapsed.Location = new System.Drawing.Point(78, 152);
            this.label_elapsed.Name = "label_elapsed";
            this.label_elapsed.Size = new System.Drawing.Size(127, 25);
            this.label_elapsed.TabIndex = 2;
            this.label_elapsed.Text = "Time Elapsed";
            // 
            // label2_collon1
            // 
            this.label2_collon1.AutoSize = true;
            this.label2_collon1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2_collon1.Location = new System.Drawing.Point(79, 87);
            this.label2_collon1.Name = "label2_collon1";
            this.label2_collon1.Size = new System.Drawing.Size(32, 50);
            this.label2_collon1.TabIndex = 3;
            this.label2_collon1.Text = ":";
            // 
            // label_hour
            // 
            this.label_hour.AutoSize = true;
            this.label_hour.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hour.Location = new System.Drawing.Point(20, 87);
            this.label_hour.Name = "label_hour";
            this.label_hour.Size = new System.Drawing.Size(64, 50);
            this.label_hour.TabIndex = 4;
            this.label_hour.Text = "01";
            // 
            // label_minute
            // 
            this.label_minute.AutoSize = true;
            this.label_minute.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_minute.Location = new System.Drawing.Point(108, 87);
            this.label_minute.Name = "label_minute";
            this.label_minute.Size = new System.Drawing.Size(64, 50);
            this.label_minute.TabIndex = 5;
            this.label_minute.Text = "59";
            // 
            // label_collon2
            // 
            this.label_collon2.AutoSize = true;
            this.label_collon2.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_collon2.Location = new System.Drawing.Point(168, 87);
            this.label_collon2.Name = "label_collon2";
            this.label_collon2.Size = new System.Drawing.Size(32, 50);
            this.label_collon2.TabIndex = 6;
            this.label_collon2.Text = ":";
            // 
            // label_second
            // 
            this.label_second.AutoSize = true;
            this.label_second.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_second.Location = new System.Drawing.Point(198, 87);
            this.label_second.Name = "label_second";
            this.label_second.Size = new System.Drawing.Size(64, 50);
            this.label_second.TabIndex = 7;
            this.label_second.Text = "54";
            // 
            // metroButton_logoff
            // 
            this.metroButton_logoff.BackColor = System.Drawing.Color.Red;
            this.metroButton_logoff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton_logoff.ForeColor = System.Drawing.Color.White;
            this.metroButton_logoff.Location = new System.Drawing.Point(148, 193);
            this.metroButton_logoff.Name = "metroButton_logoff";
            this.metroButton_logoff.Size = new System.Drawing.Size(75, 23);
            this.metroButton_logoff.TabIndex = 8;
            this.metroButton_logoff.Text = "Log off";
            this.metroButton_logoff.UseCustomBackColor = true;
            this.metroButton_logoff.UseCustomForeColor = true;
            this.metroButton_logoff.UseSelectable = true;
            this.metroButton_logoff.UseStyleColors = true;
            this.metroButton_logoff.Click += new System.EventHandler(this.metroButton_logoff_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // metroButton_pause
            // 
            this.metroButton_pause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.metroButton_pause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton_pause.ForeColor = System.Drawing.Color.White;
            this.metroButton_pause.Location = new System.Drawing.Point(57, 193);
            this.metroButton_pause.Name = "metroButton_pause";
            this.metroButton_pause.Size = new System.Drawing.Size(75, 23);
            this.metroButton_pause.TabIndex = 9;
            this.metroButton_pause.Text = "Pause";
            this.metroButton_pause.UseCustomBackColor = true;
            this.metroButton_pause.UseCustomForeColor = true;
            this.metroButton_pause.UseSelectable = true;
            this.metroButton_pause.UseStyleColors = true;
            this.metroButton_pause.Click += new System.EventHandler(this.metroButton_pause_Click);
            // 
            // pictureBox_minimize
            // 
            this.pictureBox_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_minimize.Image = global::CafeClient.Properties.Resources.minimize;
            this.pictureBox_minimize.Location = new System.Drawing.Point(253, 10);
            this.pictureBox_minimize.Name = "pictureBox_minimize";
            this.pictureBox_minimize.Size = new System.Drawing.Size(24, 5);
            this.pictureBox_minimize.TabIndex = 11;
            this.pictureBox_minimize.TabStop = false;
            this.pictureBox_minimize.Click += new System.EventHandler(this.pictureBox_minimize_Click);
            // 
            // pictureBox_setting
            // 
            this.pictureBox_setting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_setting.Image = global::CafeClient.Properties.Resources.settings;
            this.pictureBox_setting.Location = new System.Drawing.Point(230, 35);
            this.pictureBox_setting.Name = "pictureBox_setting";
            this.pictureBox_setting.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_setting.TabIndex = 10;
            this.pictureBox_setting.TabStop = false;
            this.pictureBox_setting.Click += new System.EventHandler(this.pictureBox_setting_Click);
            // 
            // notifyIcon_minimize
            // 
            this.notifyIcon_minimize.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon_minimize.BalloonTipText = "You can view your session info by clicking the icon";
            this.notifyIcon_minimize.BalloonTipTitle = "Session window";
            this.notifyIcon_minimize.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_minimize.Icon")));
            this.notifyIcon_minimize.Text = "View the session info by double clicking the icon";
            this.notifyIcon_minimize.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_minimize_MouseDoubleClick);
            // 
            // backgroundWorker_processviewer
            // 
            this.backgroundWorker_processviewer.WorkerReportsProgress = true;
            this.backgroundWorker_processviewer.WorkerSupportsCancellation = true;
            this.backgroundWorker_processviewer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_processviewer_DoWork);
            // 
            // CommandControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 232);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox_minimize);
            this.Controls.Add(this.pictureBox_setting);
            this.Controls.Add(this.metroButton_pause);
            this.Controls.Add(this.metroButton_logoff);
            this.Controls.Add(this.label_second);
            this.Controls.Add(this.label_collon2);
            this.Controls.Add(this.label_minute);
            this.Controls.Add(this.label_hour);
            this.Controls.Add(this.label2_collon1);
            this.Controls.Add(this.label_elapsed);
            this.Controls.Add(this.label_code_value);
            this.Controls.Add(this.label1_code);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CommandControl";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowInTaskbar = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CommandControl_FormClosed);
            this.Load += new System.EventHandler(this.CommandControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_setting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1_code;
        private System.Windows.Forms.Label label_code_value;
        private System.Windows.Forms.Label label_elapsed;
        private System.Windows.Forms.Label label2_collon1;
        private System.Windows.Forms.Label label_hour;
        private System.Windows.Forms.Label label_minute;
        private System.Windows.Forms.Label label_collon2;
        private System.Windows.Forms.Label label_second;
        private MetroFramework.Controls.MetroButton metroButton_logoff;
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroButton metroButton_pause;
        private System.Windows.Forms.PictureBox pictureBox_setting;
        private System.Windows.Forms.ToolTip toolTip_setting;
        private System.Windows.Forms.PictureBox pictureBox_minimize;
        private System.Windows.Forms.ToolTip toolTip_minimize;
        private System.Windows.Forms.NotifyIcon notifyIcon_minimize;
        private System.ComponentModel.BackgroundWorker backgroundWorker_processviewer;
    }
}