namespace CafeClient
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label_pcname = new System.Windows.Forms.Label();
            this.label_pcname_value = new System.Windows.Forms.Label();
            this.label_ip_value = new System.Windows.Forms.Label();
            this.label_ip = new System.Windows.Forms.Label();
            this.listBox_adapters = new System.Windows.Forms.ListBox();
            this.label_adapters = new System.Windows.Forms.Label();
            this.metroButton_save = new MetroFramework.Controls.MetroButton();
            this.button_start = new System.Windows.Forms.Button();
            this.checkBox_autostart = new System.Windows.Forms.CheckBox();
            this.toolTip_startbutton = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox_monitorprocess = new System.Windows.Forms.CheckBox();
            this.label_logpath = new System.Windows.Forms.Label();
            this.button_choosepath = new System.Windows.Forms.Button();
            this.label_logpath_value = new System.Windows.Forms.Label();
            this.folderBrowserDialog_logpath = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label_pcname
            // 
            this.label_pcname.AutoSize = true;
            this.label_pcname.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_pcname.Location = new System.Drawing.Point(23, 31);
            this.label_pcname.Name = "label_pcname";
            this.label_pcname.Size = new System.Drawing.Size(69, 17);
            this.label_pcname.TabIndex = 0;
            this.label_pcname.Text = "PC Name :";
            // 
            // label_pcname_value
            // 
            this.label_pcname_value.AutoSize = true;
            this.label_pcname_value.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_pcname_value.Location = new System.Drawing.Point(98, 31);
            this.label_pcname_value.Name = "label_pcname_value";
            this.label_pcname_value.Size = new System.Drawing.Size(92, 17);
            this.label_pcname_value.TabIndex = 1;
            this.label_pcname_value.Text = "Not Available";
            // 
            // label_ip_value
            // 
            this.label_ip_value.AutoSize = true;
            this.label_ip_value.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ip_value.Location = new System.Drawing.Point(98, 60);
            this.label_ip_value.Name = "label_ip_value";
            this.label_ip_value.Size = new System.Drawing.Size(92, 17);
            this.label_ip_value.TabIndex = 3;
            this.label_ip_value.Text = "Not Available";
            // 
            // label_ip
            // 
            this.label_ip.AutoSize = true;
            this.label_ip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ip.Location = new System.Drawing.Point(23, 60);
            this.label_ip.Name = "label_ip";
            this.label_ip.Size = new System.Drawing.Size(25, 17);
            this.label_ip.TabIndex = 2;
            this.label_ip.Text = "IP :";
            // 
            // listBox_adapters
            // 
            this.listBox_adapters.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_adapters.FormattingEnabled = true;
            this.listBox_adapters.ItemHeight = 21;
            this.listBox_adapters.Location = new System.Drawing.Point(26, 137);
            this.listBox_adapters.Name = "listBox_adapters";
            this.listBox_adapters.Size = new System.Drawing.Size(400, 193);
            this.listBox_adapters.TabIndex = 4;
            this.listBox_adapters.SelectedIndexChanged += new System.EventHandler(this.listBox_adapters_SelectedIndexChanged);
            // 
            // label_adapters
            // 
            this.label_adapters.AutoSize = true;
            this.label_adapters.Location = new System.Drawing.Point(24, 115);
            this.label_adapters.Name = "label_adapters";
            this.label_adapters.Size = new System.Drawing.Size(49, 13);
            this.label_adapters.TabIndex = 5;
            this.label_adapters.Text = "Adapters";
            // 
            // metroButton_save
            // 
            this.metroButton_save.BackColor = System.Drawing.Color.SeaGreen;
            this.metroButton_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton_save.Enabled = false;
            this.metroButton_save.ForeColor = System.Drawing.Color.White;
            this.metroButton_save.Location = new System.Drawing.Point(332, 396);
            this.metroButton_save.Name = "metroButton_save";
            this.metroButton_save.Size = new System.Drawing.Size(94, 23);
            this.metroButton_save.TabIndex = 6;
            this.metroButton_save.Text = "Save";
            this.metroButton_save.UseCustomBackColor = true;
            this.metroButton_save.UseCustomForeColor = true;
            this.metroButton_save.UseSelectable = true;
            this.metroButton_save.Click += new System.EventHandler(this.metroButton_save_Click);
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.Teal;
            this.button_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_start.Enabled = false;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_start.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.ForeColor = System.Drawing.Color.White;
            this.button_start.Location = new System.Drawing.Point(351, 31);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 46);
            this.button_start.TabIndex = 7;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // checkBox_autostart
            // 
            this.checkBox_autostart.AutoSize = true;
            this.checkBox_autostart.Location = new System.Drawing.Point(355, 83);
            this.checkBox_autostart.Name = "checkBox_autostart";
            this.checkBox_autostart.Size = new System.Drawing.Size(71, 17);
            this.checkBox_autostart.TabIndex = 8;
            this.checkBox_autostart.Text = "Auto start";
            this.checkBox_autostart.UseVisualStyleBackColor = true;
            this.checkBox_autostart.CheckedChanged += new System.EventHandler(this.checkBox_autostart_CheckedChanged);
            // 
            // checkBox_monitorprocess
            // 
            this.checkBox_monitorprocess.AutoSize = true;
            this.checkBox_monitorprocess.Location = new System.Drawing.Point(325, 106);
            this.checkBox_monitorprocess.Name = "checkBox_monitorprocess";
            this.checkBox_monitorprocess.Size = new System.Drawing.Size(102, 17);
            this.checkBox_monitorprocess.TabIndex = 9;
            this.checkBox_monitorprocess.Text = "Monitor Process";
            this.checkBox_monitorprocess.UseVisualStyleBackColor = true;
            this.checkBox_monitorprocess.CheckedChanged += new System.EventHandler(this.checkBox_monitorprocess_CheckedChanged);
            // 
            // label_logpath
            // 
            this.label_logpath.AutoSize = true;
            this.label_logpath.Location = new System.Drawing.Point(24, 345);
            this.label_logpath.Name = "label_logpath";
            this.label_logpath.Size = new System.Drawing.Size(50, 13);
            this.label_logpath.TabIndex = 10;
            this.label_logpath.Text = "Log Path";
            // 
            // button_choosepath
            // 
            this.button_choosepath.Location = new System.Drawing.Point(26, 367);
            this.button_choosepath.Name = "button_choosepath";
            this.button_choosepath.Size = new System.Drawing.Size(88, 23);
            this.button_choosepath.TabIndex = 11;
            this.button_choosepath.Text = "Choose Folder";
            this.button_choosepath.UseVisualStyleBackColor = true;
            this.button_choosepath.Click += new System.EventHandler(this.button_choosepath_Click);
            // 
            // label_logpath_value
            // 
            this.label_logpath_value.AutoEllipsis = true;
            this.label_logpath_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_logpath_value.Location = new System.Drawing.Point(140, 372);
            this.label_logpath_value.Name = "label_logpath_value";
            this.label_logpath_value.Size = new System.Drawing.Size(286, 13);
            this.label_logpath_value.TabIndex = 12;
            this.label_logpath_value.Text = "Not Available";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 435);
            this.Controls.Add(this.label_logpath_value);
            this.Controls.Add(this.button_choosepath);
            this.Controls.Add(this.label_logpath);
            this.Controls.Add(this.checkBox_monitorprocess);
            this.Controls.Add(this.checkBox_autostart);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.metroButton_save);
            this.Controls.Add(this.label_adapters);
            this.Controls.Add(this.listBox_adapters);
            this.Controls.Add(this.label_ip_value);
            this.Controls.Add(this.label_ip);
            this.Controls.Add(this.label_pcname_value);
            this.Controls.Add(this.label_pcname);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_pcname;
        private System.Windows.Forms.Label label_pcname_value;
        private System.Windows.Forms.Label label_ip_value;
        private System.Windows.Forms.Label label_ip;
        private System.Windows.Forms.ListBox listBox_adapters;
        private System.Windows.Forms.Label label_adapters;
        private MetroFramework.Controls.MetroButton metroButton_save;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.CheckBox checkBox_autostart;
        private System.Windows.Forms.ToolTip toolTip_startbutton;
        private System.Windows.Forms.CheckBox checkBox_monitorprocess;
        private System.Windows.Forms.Label label_logpath;
        private System.Windows.Forms.Button button_choosepath;
        private System.Windows.Forms.Label label_logpath_value;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_logpath;
    }
}