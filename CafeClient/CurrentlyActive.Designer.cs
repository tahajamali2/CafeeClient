namespace CafeClient
{
    partial class CurrentlyActive
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
            this.label_code_value = new System.Windows.Forms.Label();
            this.label1_code = new System.Windows.Forms.Label();
            this.label_comment = new System.Windows.Forms.Label();
            this.textBox_comment = new System.Windows.Forms.TextBox();
            this.metroButton_pause = new MetroFramework.Controls.MetroButton();
            this.metroButton_logoff = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // label_code_value
            // 
            this.label_code_value.AutoSize = true;
            this.label_code_value.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_code_value.Location = new System.Drawing.Point(115, 80);
            this.label_code_value.Name = "label_code_value";
            this.label_code_value.Size = new System.Drawing.Size(81, 20);
            this.label_code_value.TabIndex = 3;
            this.label_code_value.Text = "########";
            // 
            // label1_code
            // 
            this.label1_code.AutoSize = true;
            this.label1_code.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_code.Location = new System.Drawing.Point(23, 83);
            this.label1_code.Name = "label1_code";
            this.label1_code.Size = new System.Drawing.Size(86, 15);
            this.label1_code.TabIndex = 2;
            this.label1_code.Text = "Session code #";
            // 
            // label_comment
            // 
            this.label_comment.AutoSize = true;
            this.label_comment.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_comment.Location = new System.Drawing.Point(23, 120);
            this.label_comment.Name = "label_comment";
            this.label_comment.Size = new System.Drawing.Size(71, 15);
            this.label_comment.TabIndex = 4;
            this.label_comment.Text = "Comment :-";
            // 
            // textBox_comment
            // 
            this.textBox_comment.Location = new System.Drawing.Point(26, 147);
            this.textBox_comment.Multiline = true;
            this.textBox_comment.Name = "textBox_comment";
            this.textBox_comment.Size = new System.Drawing.Size(298, 71);
            this.textBox_comment.TabIndex = 5;
            // 
            // metroButton_pause
            // 
            this.metroButton_pause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.metroButton_pause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton_pause.ForeColor = System.Drawing.Color.White;
            this.metroButton_pause.Location = new System.Drawing.Point(89, 234);
            this.metroButton_pause.Name = "metroButton_pause";
            this.metroButton_pause.Size = new System.Drawing.Size(75, 23);
            this.metroButton_pause.TabIndex = 11;
            this.metroButton_pause.Text = "Pause";
            this.metroButton_pause.UseCustomBackColor = true;
            this.metroButton_pause.UseCustomForeColor = true;
            this.metroButton_pause.UseSelectable = true;
            this.metroButton_pause.UseStyleColors = true;
            this.metroButton_pause.Click += new System.EventHandler(this.metroButton_pause_Click);
            // 
            // metroButton_logoff
            // 
            this.metroButton_logoff.BackColor = System.Drawing.Color.Red;
            this.metroButton_logoff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton_logoff.ForeColor = System.Drawing.Color.White;
            this.metroButton_logoff.Location = new System.Drawing.Point(180, 234);
            this.metroButton_logoff.Name = "metroButton_logoff";
            this.metroButton_logoff.Size = new System.Drawing.Size(75, 23);
            this.metroButton_logoff.TabIndex = 10;
            this.metroButton_logoff.Text = "Log off";
            this.metroButton_logoff.UseCustomBackColor = true;
            this.metroButton_logoff.UseCustomForeColor = true;
            this.metroButton_logoff.UseSelectable = true;
            this.metroButton_logoff.UseStyleColors = true;
            this.metroButton_logoff.Click += new System.EventHandler(this.metroButton_logoff_Click);
            // 
            // CurrentlyActive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 275);
            this.Controls.Add(this.metroButton_pause);
            this.Controls.Add(this.metroButton_logoff);
            this.Controls.Add(this.textBox_comment);
            this.Controls.Add(this.label_comment);
            this.Controls.Add(this.label_code_value);
            this.Controls.Add(this.label1_code);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CurrentlyActive";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Session is currently active !";
            this.Load += new System.EventHandler(this.CurrentlyActive_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_code_value;
        private System.Windows.Forms.Label label1_code;
        private System.Windows.Forms.Label label_comment;
        private System.Windows.Forms.TextBox textBox_comment;
        private MetroFramework.Controls.MetroButton metroButton_pause;
        private MetroFramework.Controls.MetroButton metroButton_logoff;
    }
}