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
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Utilities;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace CafeClient
{
    public partial class LockWindow : MetroForm
    {
        TcpListener server = null;
        string message = string.Empty;

        globalKeyboardHook gkh = new globalKeyboardHook();
        Computer mypc = new Computer();
        MainWindow tw;
        public LockWindow()
        {
            InitializeComponent();

            ConfigureScreen();
            BlockKeyBoard();
            
        }

        public LockWindow(Computer pc,MainWindow mw)
        {
            InitializeComponent();

            toolTip_redeem.SetToolTip(metroButton_redeem, "Connect Session");

            ConfigureScreen();
            BlockKeyBoard();

            mypc = pc;
            tw = mw;

        }

        public LockWindow(Computer pc, MainWindow mw,string popupmessage)
        {
            InitializeComponent();
            message = popupmessage;
            toolTip_redeem.SetToolTip(metroButton_redeem, "Connect Session");
            toolTip_setting.SetToolTip(pictureBox_setting, "Setting");


            ConfigureScreen();
            BlockKeyBoard();

            mypc = pc;
            tw = mw;

        }

        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        void gkh_KeyDown_unevent(object sender, KeyEventArgs e)
        {
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void metroButton_redeem_Click(object sender, EventArgs e)
        {
            if (metroTextBox_accesscode.Text.Trim().Length == 8)
            {
                try
                {
                    var sessionobject = Session.GetNonClosedSession(mypc.Id, metroTextBox_accesscode.Text.Trim());

                    if(sessionobject.StartSession("Session Start By User",null))
                    {
                        CommandControl cc = new CommandControl(sessionobject, mypc,tw,gkh);
                        server.Stop();
                        backgroundWorker1.CancelAsync();
                        cc.Show();
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Some thing went wrong while starting your session !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message+"1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Access code should be 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public void ConfigureScreen()
        {
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height + 100;

            pictureBox_setting.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 100, 60);

            pictureBox_bg.Location = new Point(0, 0);
            pictureBox_bg.Width = this.Width;
            pictureBox_bg.Height = this.Height;
            metroTextBox_accesscode.Location = new Point((this.Width / 2) - (metroTextBox_accesscode.Width / 2), (this.Height / 2) - (metroTextBox_accesscode.Height / 2));
            metroButton_redeem.Location = new Point((this.Width / 2) - (metroButton_redeem.Width / 2), ((this.Height / 2) - (metroButton_redeem.Height / 2)) + 140);

        }

        public void BlockKeyBoard()
        {
            gkh.HookedKeys.Add(Keys.Control);
            gkh.HookedKeys.Add(Keys.ControlKey);
            gkh.HookedKeys.Add(Keys.LWin);
            gkh.HookedKeys.Add(Keys.RWin);
            gkh.HookedKeys.Add(Keys.Alt);
            gkh.HookedKeys.Add(Keys.Delete);
            gkh.HookedKeys.Add(Keys.Delete);
            gkh.HookedKeys.Add(Keys.RControlKey);
            gkh.HookedKeys.Add(Keys.LControlKey);
            gkh.HookedKeys.Add(Keys.F1);
            gkh.HookedKeys.Add(Keys.F2);
            gkh.HookedKeys.Add(Keys.F3);
            gkh.HookedKeys.Add(Keys.F4);
            gkh.HookedKeys.Add(Keys.F5);
            gkh.HookedKeys.Add(Keys.F6);
            gkh.HookedKeys.Add(Keys.F7);
            gkh.HookedKeys.Add(Keys.F8);
            gkh.HookedKeys.Add(Keys.F9);
            gkh.HookedKeys.Add(Keys.F10);
            gkh.HookedKeys.Add(Keys.F11);
            gkh.HookedKeys.Add(Keys.F12);

            gkh.KeyDown += gkh_KeyDown;

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Set the TcpListener on port 13000.
                //Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse(mypc.IPAddress);

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, mypc.Port);

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


                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

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
                (sender as BackgroundWorker).ReportProgress(0, ex.Message+"2");
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try 
            {
            if (e.UserState != null)
            {

                if (!e.UserState.ToString().Equals("A blocking operation was interrupted by a call to WSACancelBlockingCall2"))
                {
                    if (e.UserState.ToString().Split(':').Count() >= 1 && e.UserState.ToString().Split(':').Count() <= 3)
                    {
                        if (e.UserState.ToString().Split(':')[1].Equals("Shutdown"))
                        {

                            var psi = new ProcessStartInfo("shutdown", "/s /f /t 30");
                            psi.CreateNoWindow = true;
                            psi.UseShellExecute = false;
                            Process.Start(psi);

                            if (e.UserState.ToString().Split(':').Count() == 3)
                            {
                                MessageBox.Show(e.UserState.ToString().Split(':')[2], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }


                        else if (e.UserState.ToString().Split(':')[1].Equals("Restart"))
                        {

                            var psi = new ProcessStartInfo("shutdown", "/r /f /t 30");
                            psi.CreateNoWindow = true;
                            psi.UseShellExecute = false;
                            Process.Start(psi);

                            if (e.UserState.ToString().Split(':').Count() == 3)
                            {
                                MessageBox.Show(e.UserState.ToString().Split(':')[2], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }


                        else
                        {
                            MessageBox.Show("Invalid Command", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Command", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                }



        
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message+"3","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void LockWindow_Shown(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();

            if (!message.Trim().Equals(""))
            {
                MessageBox.Show(message.Trim(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
    }
}
