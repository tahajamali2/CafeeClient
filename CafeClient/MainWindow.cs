using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Net.NetworkInformation;
using System.Configuration;
using System.IO;

namespace CafeClient
{
    public partial class MainWindow : MetroForm
    {
        Computer pc = null;
        public string adapter_public;
        public string ip_public;
        public string is_monitorable_public;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                toolTip_startbutton.SetToolTip(button_start, "Start session lock");
                var adapters = NetworkInterface.GetAllNetworkInterfaces();
                string ip = "";
                foreach (var adapter in adapters)
                {
                    if (adapter.OperationalStatus == OperationalStatus.Down)
                    {
                        ip = "0.0.0.0";
                    }

                    else
                    {
                        ip = adapter.GetIPProperties().UnicastAddresses.Where(x => x.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).Select(y => y.Address.ToString()).SingleOrDefault();
                        
                    }

                    listBox_adapters.Items.Add(adapter.Name + "  -  (" + ip + ")");
                }

                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (config.AppSettings.Settings["Adapter"] != null)
                {
                    foreach(object ob in listBox_adapters.Items) 
                    {
                        if (ob.ToString().StartsWith(config.AppSettings.Settings["Adapter"].Value.Split(new string[] { "  -  (" }, StringSplitOptions.None)[0]))
                        {
                            listBox_adapters.SelectedItem = ob;
                            break;
                        }
                    }


                    ip = listBox_adapters.SelectedItem.ToString().Split(new string[] { "  -  (" }, StringSplitOptions.None)[1].Split(')')[0];
                    label_ip_value.Text = ip;


                    pc = Computer.GetComputerByIp(ip);

                    if (pc != null)
                    {
                        label_pcname_value.Text = pc.PcName;
                    }

                }


                if (config.AppSettings.Settings["MonitorCheck"] != null)
                {
                    if (config.AppSettings.Settings["MonitorCheck"].Value.Equals("Yes"))
                    {
                        checkBox_monitorprocess.Checked = true;
                        is_monitorable_public = "Yes";
                    }

                    else
                    {
                        checkBox_monitorprocess.Checked = false;
                        is_monitorable_public = "No";
                    }
                }

                else
                {
                    is_monitorable_public = "No";
                }


                label_logpath_value.Text = GetConfigValue("LogPath").Equals("")?"Not Available":GetConfigValue("LogPath");

                if (!label_pcname_value.Text.Equals("Not Available"))
                {
                    button_start.Enabled = true;

                    if (config.AppSettings.Settings["Autostart"] != null)
                    {
                        if (config.AppSettings.Settings["Autostart"].Value.Equals("Yes"))
                        {
                            if (!label_logpath_value.Text.Equals("Not Available"))
                            {
                                if (Directory.Exists(label_logpath_value.Text))
                                {
                                    LockWindow lw = new LockWindow(pc, this);
                                    lw.Show();
                                    this.Visible = false;
                                    this.ShowInTaskbar = false;
                                }
                            }

                        }
                    }
                }

                if (config.AppSettings.Settings["Autostart"] != null)
                {
                    if (config.AppSettings.Settings["Autostart"].Value.Equals("Yes"))
                    {
                        checkBox_autostart.Checked = true;
                    }

                    else
                    {
                        checkBox_autostart.Checked = false;
                    }
                }

                adapter_public = config.AppSettings.Settings["Adapter"].Value.Split(new string[] { "  -  (" }, StringSplitOptions.None)[0];
                ip_public = label_ip_value.Text;

         

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private void metroButton_save_Click(object sender, EventArgs e)
        {
            SetConfigValue("Adapter", listBox_adapters.SelectedItem.ToString());
            SetConfigValue("LogPath", label_logpath_value.Text.Equals("Not Available") ? "" : label_logpath_value.Text);
            System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
            this.Close(); //to turn off current app
        }

        private void listBox_adapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroButton_save.Enabled = true;
        }

        public void SetConfigValue(string key, string value)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, value);
                config.Save(ConfigurationSaveMode.Modified);
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
            }
            
        }

        public string GetConfigValue(string key)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            return config.AppSettings.Settings[key] == null ? "" : config.AppSettings.Settings[key].Value;

        }

        private void button_start_Click(object sender, EventArgs e)
        {
            try
            {
                if (pc != null)
                {
                    if (MiscClass.CheckNetworkAvailablity(adapter_public, ip_public))
                    {
                        if (checkBox_monitorprocess.Checked)
                        {
                            is_monitorable_public = "Yes";
                        }

                        else
                        {
                            is_monitorable_public = "No";
                        }

                        if (!GetConfigValue("LogPath").Equals(""))
                        {
                            if (Directory.Exists(GetConfigValue("LogPath")))
                            {
                                LockWindow lw = new LockWindow(pc, this);
                                lw.Show();
                                this.Visible = false;
                                this.ShowInTaskbar = false;
                            }
                            else
                            {
                                MessageBox.Show("LogPath directory is not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        else
                        {
                            MessageBox.Show("LogPath is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox_autostart_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_autostart.Checked)
            {
                SetConfigValue("Autostart", "Yes");
            }

            else
            {
                SetConfigValue("Autostart", "No");
            }
        }

        private void checkBox_monitorprocess_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_monitorprocess.Checked)
            {
                SetConfigValue("MonitorCheck", "Yes");
            }

            else
            {
                SetConfigValue("MonitorCheck", "No");
            }
        }

        private void button_choosepath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog_logpath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                label_logpath_value.Text = folderBrowserDialog_logpath.SelectedPath;
            }
        }
    }
}
