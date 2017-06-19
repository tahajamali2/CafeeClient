namespace CafeClient
{
    partial class AdminPassword
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
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.metroButton_next = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // textBox_password
            // 
            this.textBox_password.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_password.Location = new System.Drawing.Point(25, 81);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(439, 25);
            this.textBox_password.TabIndex = 0;
            this.textBox_password.UseSystemPasswordChar = true;
            // 
            // metroButton_next
            // 
            this.metroButton_next.BackColor = System.Drawing.Color.SeaGreen;
            this.metroButton_next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton_next.ForeColor = System.Drawing.Color.White;
            this.metroButton_next.Location = new System.Drawing.Point(377, 127);
            this.metroButton_next.Name = "metroButton_next";
            this.metroButton_next.Size = new System.Drawing.Size(87, 23);
            this.metroButton_next.TabIndex = 1;
            this.metroButton_next.Text = "Next";
            this.metroButton_next.UseCustomBackColor = true;
            this.metroButton_next.UseCustomForeColor = true;
            this.metroButton_next.UseSelectable = true;
            this.metroButton_next.Click += new System.EventHandler(this.metroButton_next_Click);
            // 
            // AdminPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 160);
            this.Controls.Add(this.metroButton_next);
            this.Controls.Add(this.textBox_password);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminPassword";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Admin Password";
            this.Load += new System.EventHandler(this.AdminPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_password;
        private MetroFramework.Controls.MetroButton metroButton_next;
    }
}