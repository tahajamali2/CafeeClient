namespace CafeClient
{
    partial class LockWindow
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
            this.metroTextBox_accesscode = new System.Windows.Forms.TextBox();
            this.metroButton_redeem = new MetroFramework.Controls.MetroButton();
            this.toolTip_redeem = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox_setting = new System.Windows.Forms.PictureBox();
            this.pictureBox_bg = new System.Windows.Forms.PictureBox();
            this.toolTip_setting = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_setting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bg)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTextBox_accesscode
            // 
            this.metroTextBox_accesscode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroTextBox_accesscode.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTextBox_accesscode.Location = new System.Drawing.Point(44, 103);
            this.metroTextBox_accesscode.Name = "metroTextBox_accesscode";
            this.metroTextBox_accesscode.Size = new System.Drawing.Size(200, 39);
            this.metroTextBox_accesscode.TabIndex = 1;
            this.metroTextBox_accesscode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // metroButton_redeem
            // 
            this.metroButton_redeem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton_redeem.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton_redeem.Location = new System.Drawing.Point(103, 162);
            this.metroButton_redeem.Name = "metroButton_redeem";
            this.metroButton_redeem.Size = new System.Drawing.Size(85, 43);
            this.metroButton_redeem.TabIndex = 2;
            this.metroButton_redeem.Text = "Redeem";
            this.metroButton_redeem.UseSelectable = true;
            this.metroButton_redeem.Click += new System.EventHandler(this.metroButton_redeem_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pictureBox_setting
            // 
            this.pictureBox_setting.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_setting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_setting.Image = global::CafeClient.Properties.Resources.setting_2;
            this.pictureBox_setting.Location = new System.Drawing.Point(225, 33);
            this.pictureBox_setting.Name = "pictureBox_setting";
            this.pictureBox_setting.Size = new System.Drawing.Size(40, 40);
            this.pictureBox_setting.TabIndex = 3;
            this.pictureBox_setting.TabStop = false;
            // 
            // pictureBox_bg
            // 
            this.pictureBox_bg.BackgroundImage = global::CafeClient.Properties.Resources.internet_background_with_water_2984_1;
            this.pictureBox_bg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_bg.Location = new System.Drawing.Point(2, 6);
            this.pictureBox_bg.Name = "pictureBox_bg";
            this.pictureBox_bg.Size = new System.Drawing.Size(281, 250);
            this.pictureBox_bg.TabIndex = 0;
            this.pictureBox_bg.TabStop = false;
            // 
            // LockWindow
            // 
            this.ApplyImageInvert = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox_setting);
            this.Controls.Add(this.metroButton_redeem);
            this.Controls.Add(this.metroTextBox_accesscode);
            this.Controls.Add(this.pictureBox_bg);
            this.Movable = false;
            this.Name = "LockWindow";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.LockWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_setting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_bg;
        private System.Windows.Forms.TextBox metroTextBox_accesscode;
        private MetroFramework.Controls.MetroButton metroButton_redeem;
        private System.Windows.Forms.ToolTip toolTip_redeem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox_setting;
        private System.Windows.Forms.ToolTip toolTip_setting;

    }
}

