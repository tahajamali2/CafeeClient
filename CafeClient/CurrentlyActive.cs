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

namespace CafeClient
{
    public partial class CurrentlyActive : MetroForm
    {
        MainWindow _mainwindow;
        CommandControl _commandcontrol;
        AdminPassword _adminpassword;
        Session _session;

        public CurrentlyActive(MainWindow mw,CommandControl cc,AdminPassword ap,Session s)
        {
            InitializeComponent();
            _mainwindow = mw;
            _commandcontrol = cc;
            _adminpassword = ap;
            _session = s;

            label_code_value.Text = s.SessionCode;

        }

        private void CurrentlyActive_Load(object sender, EventArgs e)
        {

        }

        private void metroButton_pause_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are your sure you want to pause the session ?\n\nNote :- All print job's will be cancelled.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    if (_session.PauseSession(textBox_comment.Text.Trim().Equals("") ? "Session Pause By Employee From User Computer" : textBox_comment.Text.Trim(), null))
                    {
                        _adminpassword.Close();
                        _commandcontrol.server.Stop();
                        _commandcontrol.backgroundWorker1.CancelAsync();
                        _commandcontrol.Close();
                        _mainwindow.Visible = true;
                        _mainwindow.ShowInTaskbar = true;
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Some thing went wrong while pausing the session !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (MessageBox.Show("Are your sure you want to logff the session ?\n\nNote :- All print job's will be cancelled.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    if (_session.StopSession(textBox_comment.Text.Trim().Equals("") ? "Session Logoff By Employee From User Computer" : textBox_comment.Text.Trim(), null))
                    {
                        _adminpassword.Close();
                        _commandcontrol.server.Stop();
                        _commandcontrol.backgroundWorker1.CancelAsync();
                        _commandcontrol.Close();
                        _mainwindow.Visible = true;
                        _mainwindow.ShowInTaskbar = true;
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Some thing went wrong while logging off the session !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
