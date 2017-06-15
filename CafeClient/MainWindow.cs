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

namespace CafeClient
{
    public partial class MainWindow : MetroForm
    {
        Computer pc = null;
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
                    ip = adapter.GetIPProperties().UnicastAddresses.Where(x => x.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).Select(y => y.Address.ToString()).SingleOrDefault();
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

                if (!label_pcname_value.Text.Equals("Not Available"))
                {
                    button_start.Enabled = true;

                    if (config.AppSettings.Settings["Autostart"] != null)
                    {
                        if (config.AppSettings.Settings["Autostart"].Value.Equals("Yes"))
                        {
                            LockWindow lw = new LockWindow(pc,this);
                            lw.Show();
                            this.Visible = false;
                            this.ShowInTaskbar = false;

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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private void metroButton_save_Click(object sender, EventArgs e)
        {
            SetConfigValue("Adapter", listBox_adapters.SelectedItem.ToString());
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

            return config.AppSettings.Settings[key].Value;

        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (pc != null)
            {
                LockWindow lw = new LockWindow(pc,this);
                lw.Show();
                this.Visible = false;
                this.ShowInTaskbar = false;
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
    }
}
