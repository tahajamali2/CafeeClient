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
using Utilities;

namespace CafeClient
{
    public partial class AdminPassword : MetroForm
    {
        MainWindow _mainwindow;
        LockWindow _lockwindow;
        CommandControl _commandcontrol;
        Session _mysession;


        public AdminPassword(MainWindow mw,LockWindow lw,globalKeyboardHook hook)
        {
            InitializeComponent();
            _mainwindow = mw;
            _lockwindow = lw;
            hook.unhook();

        }

        public AdminPassword(MainWindow mw, CommandControl cc,Session s)
        {
            InitializeComponent();
            _mainwindow = mw;
            _commandcontrol = cc;
            _mysession = s;

        }

        private void AdminPassword_Load(object sender, EventArgs e)
        {

        }

        private void metroButton_next_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mysession != null)
                {
                    if (!textBox_password.Text.Trim().Equals(""))
                    {
                        if (textBox_password.Text.Equals(MiscClass.GetMiscValue("AdminPassword")))
                        {
                            CurrentlyActive ca = new CurrentlyActive(_mainwindow, _commandcontrol, this, _mysession);
                            ca.Show();
                        }

                        else
                        {
                            MessageBox.Show("Password is incorrect !.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Password cannot be empty/spaces.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else
                {
                    if (!textBox_password.Text.Trim().Equals(""))
                    {
                        if (textBox_password.Text.Equals(MiscClass.GetMiscValue("AdminPassword")))
                        {
                            _lockwindow.server.Stop();
                            _lockwindow.backgroundWorker1.CancelAsync();
                            //_lockwindow.backgroundWorker_processviewer.CancelAsync();
                            _lockwindow.Close();
                            _mainwindow.Visible = true;
                            _mainwindow.ShowInTaskbar = true;
                            this.Close();
                        }

                        else
                        {
                            MessageBox.Show("Password is incorrect !.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Password cannot be empty/spaces.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
