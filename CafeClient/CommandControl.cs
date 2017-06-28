using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Diagnostics;
using Utilities;
using System.Management;
using System.Net.NetworkInformation;
using System.Configuration;
using System.Threading;
using System.IO;
using CsvHelper;

namespace CafeClient
{
    public partial class CommandControl : MetroForm
    {
        public TcpListener server = null;
        int hour;
        int min;
        int sec;
        bool isenter=false;

        bool isdisconnect = false;

        Session mysession;
        Computer mycomputer;
        MainWindow mainwind;

        string ismonitoringable;

        string pagescount;

        ManagementEventWatcher eventWatcher;

        DataTable dtdata = new DataTable();
        DataRow dr;

        List<PrintJob> printjobs = new List<PrintJob>();

        public CommandControl()
        {
            InitializeComponent();
        }

        public CommandControl(Session currentsession,Computer currentcomputer,MainWindow main,globalKeyboardHook hook)
        {
            InitializeComponent();

            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - (this.Width + 60), 60);

            mysession = currentsession;
            mycomputer = currentcomputer;

            label_hour.Text = currentsession.Hour.ToString("00");
            label_minute.Text = currentsession.Min.ToString("00");
            label_second.Text = currentsession.Sec.ToString("00");

            label_code_value.Text = currentsession.SessionCode;

            mainwind = main;
            hook.unhook();

            toolTip_setting.SetToolTip(pictureBox_setting, "Setting");
            toolTip_setting.SetToolTip(pictureBox_minimize, "Minimize");

            WqlEventQuery WQLquery = new WqlEventQuery("SELECT * FROM __InstanceOperationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_PrintJob'");
            eventWatcher = new ManagementEventWatcher(WQLquery);
            eventWatcher.EventArrived += eventWatcher_EventArrived;
            eventWatcher.Start();

            //FileSystemWatcher fwatcher = new FileSystemWatcher();
            //fwatcher.Path = MiscClass.GetConfigValue("LogPath");

            //fwatcher.NotifyFilter =  NotifyFilters.LastWrite | NotifyFilters.FileName;

            //fwatcher.Changed += fwatcher_Changed;
            //fwatcher.Created += fwatcher_Created;

            //fwatcher.Filter = "*.csv";
            //fwatcher.EnableRaisingEvents = true;


            NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;


            ismonitoringable = main.is_monitorable_public;

            dtdata = new DataTable();
            dtdata.Columns.Add("Time",typeof(DateTime));
            dtdata.Columns.Add("User", typeof(string));
            dtdata.Columns.Add("Pages", typeof(int));
            dtdata.Columns.Add("Copies", typeof(int));
            dtdata.Columns.Add("Printer", typeof(string));
            dtdata.Columns.Add("DocumentName", typeof(string));
            dtdata.Columns.Add("Client", typeof(string));
            dtdata.Columns.Add("PaperSize", typeof(string));
            dtdata.Columns.Add("Language", typeof(string));
            dtdata.Columns.Add("Height", typeof(string));
            dtdata.Columns.Add("Width", typeof(string));
            dtdata.Columns.Add("Duplex", typeof(string));
            dtdata.Columns.Add("Grayscale", typeof(string));
            dtdata.Columns.Add("Size", typeof(string));

            pagescount = currentsession.PagesPrinted.ToString();


            this.Focus();

        }

        //public void fwatcher_Created(object sender, FileSystemEventArgs e)
        //{
            
        //}

        //public void fwatcher_Changed(object sender, FileSystemEventArgs e)
        //{

        //}


        private void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            if (!e.IsAvailable)
            {
                isdisconnect = true;
            }
        }


        private void eventWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            if (File.Exists(MiscClass.GetConfigValue("LogPath") + "\\papercut-print-log-" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv"))
            {
                dtdata.Rows.Clear();


                File.Copy(MiscClass.GetConfigValue("LogPath") + "\\papercut-print-log-" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv", MiscClass.GetConfigValue("LogPath") + "\\papercut-print-log-" + DateTime.Now.ToString("yyyy-MM-dd") + " - Copy.csv", true);
                if (MiscClass.IsFileLocked(MiscClass.GetConfigValue("LogPath") + "\\papercut-print-log-" + DateTime.Now.ToString("yyyy-MM-dd") + " - Copy.csv"))
                {
                    return;
                }

                try
                {
                    using (TextReader reader = File.OpenText(MiscClass.GetConfigValue("LogPath") + "\\papercut-print-log-" + DateTime.Now.ToString("yyyy-MM-dd") + " - Copy.csv"))
                    {
                        reader.ReadLine();
                        // now initialize the CsvReader

                        var parser = new CsvReader(new StringReader(reader.ReadToEnd())); // ...
                        while (parser.Read())
                        {
                            dr = dtdata.NewRow();
                            dr["Time"] = parser.GetField<DateTime>(0);
                            dr["User"] = parser.GetField<string>(1);
                            dr["Pages"] = parser.GetField<int>(2);
                            dr["Copies"] = parser.GetField<int>(3);
                            dr["Printer"] = parser.GetField<string>(4);
                            dr["DocumentName"] = parser.GetField<string>(5);
                            dr["Client"] = parser.GetField<string>(6);
                            dr["PaperSize"] = parser.GetField<string>(7);
                            dr["Language"] = parser.GetField<string>(8);
                            dr["Height"] = parser.GetField<string>(9);
                            dr["Width"] = parser.GetField<string>(10);
                            dr["Duplex"] = parser.GetField<string>(11);
                            dr["Grayscale"] = parser.GetField<string>(12);
                            dr["Size"] = parser.GetField<string>(13);

                            dtdata.Rows.Add(dr);

                        }
                    }

                    pagescount = PrintJob.DumpJobsToDatabase(mysession.Id, mycomputer.Id, dtdata);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void CommandControl_Load(object sender, EventArgs e)
        {

            backgroundWorker1.RunWorkerAsync();
            backgroundWorker_processviewer.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                // Set the TcpListener on port 13000.
                //Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse(mycomputer.IPAddress);

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, mycomputer.Port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;

                // Enter the listening loop.
                while (true)
                {

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    if (stream != null)
                    {

                        int i;

                        // Loop to receive all the data sent by the client.
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            // Translate data bytes to a ASCII string.
                            data = Regex.Unescape(System.Text.Encoding.ASCII.GetString(bytes, 0, i)).Replace("\r", "");

                            // Process the data sent by the client.


                            byte[] msg = System.Text.Encoding.ASCII.GetBytes("Received");

                            // Send back a response.
                            stream.Write(msg, 0, msg.Length);
                            break;

                        }
                    }

                    // Shutdown and end connection
                    client.Close();

                    (sender as BackgroundWorker).ReportProgress(1, data);
                   
                }
            }
            catch (SocketException ex)
            {
                (sender as BackgroundWorker).ReportProgress(0, ex.Message);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           
            try { 

                    if (e.UserState != null)
                    {
                        if (e.UserState.ToString().StartsWith("Command:"))
                        {
                            if (e.UserState.ToString().Split(':').Count() > 0)
                            {
                                if (e.UserState.ToString().Split(':')[1].Equals("Pause"))
                                {
                                    if (mysession.PauseSession(e.UserState.ToString().Split(':').Count() >= 3 ? e.UserState.ToString().Split(':')[2] : "Session Pause By Employee", e.UserState.ToString().Split(':').Count() >= 4 ? HelpingClass.IsNumeric(e.UserState.ToString().Split(':')[3]) ? e.UserState.ToString().Split(':')[3] : 0.ToString() : null))
                                    {
                                        LockWindow lw = new LockWindow(mycomputer, mainwind, e.UserState.ToString().Split(':').Count() == 5 ? e.UserState.ToString().Split(':')[4] : "");
                                        lw.Show();
                                        server.Stop();
                                        backgroundWorker1.CancelAsync();
                                        this.Close();
                                    }

                                    else
                                    {
                                        MessageBox.Show("Some thing went wrong while pausing your session by employee !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                else if (e.UserState.ToString().Split(':')[1].Equals("Stop"))
                                {
                                    if (mysession.StopSession(e.UserState.ToString().Split(':').Count() >= 3 ? e.UserState.ToString().Split(':')[2] : "Session Close By Employee", e.UserState.ToString().Split(':').Count() >= 4 ? HelpingClass.IsNumeric(e.UserState.ToString().Split(':')[3]) ? e.UserState.ToString().Split(':')[3] : 0.ToString() : null))
                                    {
                                        LockWindow lw = new LockWindow(mycomputer, mainwind, e.UserState.ToString().Split(':').Count() == 5 ? e.UserState.ToString().Split(':')[4] : "");
                                        lw.Show();
                                        server.Stop();
                                        backgroundWorker1.CancelAsync();
                                        this.Close();
                                    }

                                    else
                                    {
                                        MessageBox.Show("Some thing went wrong while closing your session by employee !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }


                                else if (e.UserState.ToString().Split(':')[1].Equals("StopShutdown"))
                                {
                                    if (mysession.StopSession(e.UserState.ToString().Split(':').Count() >= 3 ? e.UserState.ToString().Split(':')[2] : "Session Close By Employee", e.UserState.ToString().Split(':').Count() >= 4 ? HelpingClass.IsNumeric(e.UserState.ToString().Split(':')[3]) ? e.UserState.ToString().Split(':')[3] : 0.ToString() : null))
                                    {
                                        var psi = new ProcessStartInfo("shutdown", "/s /f /t 30");
                                        psi.CreateNoWindow = true;
                                        psi.UseShellExecute = false;
                                        Process.Start(psi);

                                        LockWindow lw = new LockWindow(mycomputer, mainwind, e.UserState.ToString().Split(':').Count() == 5 ? e.UserState.ToString().Split(':')[4] : "");
                                        lw.Show();
                                        server.Stop();
                                        backgroundWorker1.CancelAsync();
                                        this.Close();


                                    }

                                    else
                                    {
                                        MessageBox.Show("Some thing went wrong while closing your session by employee !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }


                                else if (e.UserState.ToString().Split(':')[1].Equals("PauseShutdown"))
                                {
                                    if (mysession.PauseSession(e.UserState.ToString().Split(':').Count() >= 3 ? e.UserState.ToString().Split(':')[2] : "Session Pause By Employee", e.UserState.ToString().Split(':').Count() >= 4 ? HelpingClass.IsNumeric(e.UserState.ToString().Split(':')[3]) ? e.UserState.ToString().Split(':')[3] : 0.ToString() : null))
                                    {
                                        var psi = new ProcessStartInfo("shutdown", "/s /f /t 30");
                                        psi.CreateNoWindow = true;
                                        psi.UseShellExecute = false;
                                        Process.Start(psi);

                                        LockWindow lw = new LockWindow(mycomputer, mainwind, e.UserState.ToString().Split(':').Count() == 5 ? e.UserState.ToString().Split(':')[4] : "");
                                        lw.Show();
                                        server.Stop();
                                        backgroundWorker1.CancelAsync();
                                        this.Close();
                                    }

                                    else
                                    {
                                        MessageBox.Show("Some thing went wrong while pausing your session by employee !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                else if (e.UserState.ToString().Split(':')[1].Equals("StopRestart"))
                                {
                                    if (mysession.StopSession(e.UserState.ToString().Split(':').Count() >= 3 ? e.UserState.ToString().Split(':')[2] : "Session Close By Employee", e.UserState.ToString().Split(':').Count() >= 4 ? HelpingClass.IsNumeric(e.UserState.ToString().Split(':')[3]) ? e.UserState.ToString().Split(':')[3] : 0.ToString() : null))
                                    {
                                        var psi = new ProcessStartInfo("shutdown", "/r /f /t 30");
                                        psi.CreateNoWindow = true;
                                        psi.UseShellExecute = false;
                                        Process.Start(psi);

                                        LockWindow lw = new LockWindow(mycomputer, mainwind, e.UserState.ToString().Split(':').Count() == 5 ? e.UserState.ToString().Split(':')[4] : "");
                                        lw.Show();
                                        server.Stop();
                                        backgroundWorker1.CancelAsync();
                                        this.Close();


                                    }

                                    else
                                    {
                                        MessageBox.Show("Some thing went wrong while closing your session by employee !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                else if (e.UserState.ToString().Split(':')[1].Equals("PauseRestart"))
                                {
                                    if (mysession.PauseSession(e.UserState.ToString().Split(':').Count() >= 3 ? e.UserState.ToString().Split(':')[2] : "Session Pause By Employee", e.UserState.ToString().Split(':').Count() >= 4 ? HelpingClass.IsNumeric(e.UserState.ToString().Split(':')[3]) ? e.UserState.ToString().Split(':')[3] : 0.ToString() : null))
                                    {
                                        var psi = new ProcessStartInfo("shutdown", "/r /f /t 30");
                                        psi.CreateNoWindow = true;
                                        psi.UseShellExecute = false;
                                        Process.Start(psi);

                                        LockWindow lw = new LockWindow(mycomputer, mainwind, e.UserState.ToString().Split(':').Count() == 5 ? e.UserState.ToString().Split(':')[4] : "");
                                        lw.Show();
                                        server.Stop();
                                        backgroundWorker1.CancelAsync();
                                        this.Close();
                                    }

                                    else
                                    {
                                        MessageBox.Show("Some thing went wrong while pausing your session by employee !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                else
                                {
                                    MessageBox.Show("Invalid Command", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            else
                            {
                                MessageBox.Show(e.UserState.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        else if (e.UserState.ToString().StartsWith("Message:"))
                        {
                            MessageBox.Show(e.UserState.ToString().Split(':')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {
                            if (!e.UserState.ToString().EndsWith("WSACancelBlockingCall"))
                            {
                                MessageBox.Show(e.UserState.ToString());
                            }

                        }
                    }
            }

            catch(Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            hour = Convert.ToInt32(label_hour.Text);
            min = Convert.ToInt32(label_minute.Text);
            sec = Convert.ToInt32(label_second.Text);

             if (min == 59 && sec == 59)
            {
                label_hour.Text = (hour + 1).ToString("00");
                label_minute.Text = "00";
                label_second.Text = "00";
                min = 0;
                sec = 0;
                isenter = true;
            }

            else if (sec == 59)
            {
                label_minute.Text = (min + 1).ToString("00");
                label_second.Text = "00";
                sec = 0;
                isenter = true;
            }
            else
            {
                isenter = false;
            }


            if (!isenter)
            {
                label_second.Text = (sec + 1).ToString("00");
            }

            if (isdisconnect)
            {
                try
                {
                    

                            // close the form on the forms thread
                            LockWindow lw = new LockWindow(mycomputer, mainwind);
                            lw.Show();
                            server.Stop();
                            backgroundWorker1.CancelAsync();
                            MiscClass.SetConfigValue("ActiveSession", mysession.Id.ToString() + "{{Session}}" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                            this.Close();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

               
            }

            label_pagesprinted_value.Text = pagescount;
        }

        private void metroButton_pause_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are your sure you want to pause your session ?\n\nNote :- All print job's will be cancelled.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    if (mysession.PauseSession("Session Pause By User", null))
                    {
                        LockWindow lw = new LockWindow(mycomputer, mainwind);
                        lw.Show();
                        server.Stop();
                        backgroundWorker1.CancelAsync();
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Some thing went wrong while pausing your session !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void metroButton_logoff_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are your sure you want to close your session ?\n\nNote :- All print job's will be cancelled.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    if (mysession.StopSession("Session Close By User", null))
                    {
                        LockWindow lw = new LockWindow(mycomputer, mainwind);
                        lw.Show();
                        server.Stop();
                        backgroundWorker1.CancelAsync();
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Some thing went wrong while closing your session !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox_minimize_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
            notifyIcon_minimize.Visible = true;
            notifyIcon_minimize.ShowBalloonTip(3000);
        }

        private void notifyIcon_minimize_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            this.Visible = true;
            //this.Show();
            notifyIcon_minimize.Visible = false;
        }

        private void pictureBox_setting_Click(object sender, EventArgs e)
        {
            AdminPassword ap = new AdminPassword(mainwind, this, mysession);
            ap.Show();
        }

        private void CommandControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            PrintJob.CancelPrintJobs();
            eventWatcher.Dispose();
            backgroundWorker_processviewer.CancelAsync();
        }

        private void backgroundWorker_processviewer_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (ismonitoringable.Equals("Yes"))
                {
                    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    string applicationname = config.AppSettings.Settings["MonitoringApplication"].Value;

                    while (true)
                    {
                        if ((sender as BackgroundWorker).CancellationPending == true)
                        {
                            e.Cancel = true;
                            return; // abort work, if it's cancelled
                        }

                        if (Process.GetProcessesByName(applicationname).Length < 1)
                        {
                            System.Diagnostics.Process.Start(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + applicationname + ".exe");
                            Thread.Sleep(500);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
