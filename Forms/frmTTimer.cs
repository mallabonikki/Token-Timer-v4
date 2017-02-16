using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Diagnostics;
using RawInput_dll;

namespace TokenTimerV4
{
    public partial class frmTTimer : Form 
    {
        //Fields Declaration..
        private System.Windows.Forms.Timer tmrTime = new System.Windows.Forms.Timer();
        private System.ServiceProcess.ServiceController sc = new System.ServiceProcess.ServiceController("Service1");

        ////RawInput Declaration..
        //private InputDevice id;
        //private int NumberOfKeyboards;

        private TheConnection connection;
        private bool blnFormLoad = false;

        //RawInput Declaration;
        private readonly RawInput _rawinput;

        public frmTTimer()
        {
            InitializeComponent();
            myToolClass.ErrorLogToText(" ---------------------------------------------------------------------- Token Timer started from initialization");
            //Timer Initialization and Event..
            tmrTime.Tick += new EventHandler(tmrTime_Tick);
            tmrTime.Interval = 1000;
            tmrTime.Enabled = true;

            //// Create a new InputDevice object, get the number of
            //// keyboards, and register the method which will handle the 
            //// InputDevice KeyPressed event
            //id = new InputDevice(Handle);
            //NumberOfKeyboards = id.EnumerateDevices();
            //id.KeyPressed += new InputDevice.DeviceEventHandler(m_KeyPressed);

            //Win32.DeviceAudit();            
            _rawinput = new RawInput(Handle, false);
            _rawinput.KeyPressed += OnKeyPressed;
            //AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        bool playIsloop = false;
        private void OnKeyPressed(object sender, RawInputEventArg e)
        {
            try
            {
                string strDeviceName = e.KeyPressEvent.DeviceName.Substring(12, 4).ToUpper();
                if (!(strDeviceName == "13BA" || strDeviceName == "05D5")) { return; }

                SoundPlayer PlayPoints2 = new SoundPlayer();
                if (e.KeyPressEvent.KeyPressState == "MAKE" && e.KeyPressEvent.VKeyName == "MULTIPLY")//KeyDown..
                {
                    if (playIsloop == false)
                    {
                        if (File.Exists(Application.StartupPath + @"\insertCoinPart1.wav"))
                        {
                            PlayPoints2 = new SoundPlayer(Application.StartupPath + @"\insertCoinPart1.wav");
                            PlayPoints2.PlayLooping();
                        }
                    }
                    playIsloop = true;
                    txtPW.Text = "*****";
                    txtPW.Focus();
                }
                if (e.KeyPressEvent.KeyPressState == "MAKE" || e.KeyPressEvent.VKeyName != "MULTIPLY") { return; } //Trap not multiply and Keydown return
                System.Threading.Thread.Sleep(100);
                if (playIsloop) PlayPoints2.Stop();
                playIsloop = false;
                SoundPlayer PlayPoints3 = new SoundPlayer(Application.StartupPath + @"\insertCoinPart2.wav"); PlayPoints3.Play();
                System.Threading.Thread.Sleep(100);
                txtPW.Clear();

                //Resize Form
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(218, 22);

                lblCounter.Text = "30";
                lblMin.Text = Convert.ToString(Convert.ToInt32(lblMin.Text) + 20);
                myToolClass.ErrorLogToText(" ^^- 20 minutes added. Your total remaining time is " + lblMin.Text + " -^^");
                blnFormLoad = false;

                //Insert Time To Database..
                connection = new TheConnection();
                Time time = new Time();
                time.fTime = Convert.ToInt32(lblMin.Text);
                time.fToken = 5;
                connection.InsertTime(time);

                //Write and Refresh Total Tokens To lblInsertedToken..
                time.fInDate = DateTime.Now;
                int j = connection.SelectpDateTotalToken(time);
                lblTokens.Text = "Inserted Tokens=" + j.ToString();

                //play sound;
                SoundPlayer PlayPoints = new SoundPlayer(Application.StartupPath + @"\Points.wav"); PlayPoints.Play();
                txtSavePassword.Clear();
                infinitePassword = 0;
            }
            catch (Exception exp)
            {
                myToolClass.ErrorLogToText(" OnKeyPressed ", exp.ToString());
                //WindowsController.ExitWindows(RestartOptions.LogOff, true);
            }
        }
       
        //private static void CurrentDomain_UnhandledException(Object sender, UnhandledExceptionEventArgs e)
        //{
        //    var exp = e.ExceptionObject as Exception;

        //    if (null == exp) return;

        //    // Log this error. Logging the exception doesn't correct the problem but at least now
        //    // you may have more insight as to why the exception is being thrown.
        //    //Debug.WriteLine("Unhandled Exception: " + ex.Message.ToString().ToString());
        //    //Debug.WriteLine("Unhandled Exception: " + ex);
        //    //MessageBox.Show(ex.Message.ToString().ToString());

        //    using (StreamWriter writer = new StreamWriter(Application.StartupPath + @"\Errors.txt", true))
        //    {
        //        writer.WriteLine("CurrentDomain_UnhandledException(Object sender, UnhandledExceptionEventArgs e): " + exp.Message.ToString() + DateTime.Now);
        //    }
        //}

        byte[] pix = {1, 2, 3, 4, 5, 6, 7, 8, 9 };
        byte i = 0;
        private void tmrTime_Tick(object sender, EventArgs e)
        {
            try
            {
                //FormLoad and FormShown..
                if (GlobalVariables.fisttimeIsload)
                {
                    GlobalVariables.fisttimeIsload = false;
                    frmTTimer_Load();
                    if (IsErrorToDB() == true) { GlobalVariables.errorIsnone = false; }
                    else { GlobalVariables.errorIsnone = true; tmrTime.Interval = 4000; }
                }
                
                if (GlobalVariables.errorIsnone == false)
                {
                    if (IsErrorToDB() == true)
                    {
                        //Application.DoEvents();
                        GlobalVariables.errorIsnone = false;
                    }
                    else { GlobalVariables.errorIsnone = true; tmrTime.Interval = 4000; }
                }

                if (File.Exists(Application.StartupPath + "\\" + pix[i] + ".jpg"))
                {
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\" + pix[i] + ".jpg");
                }
                pix[i] = i++; if (i == 9) i = 0;

                if (lblMin.Text == "0" && lblSec.Text == "0") //End of time..
                {
                    this.WindowState = FormWindowState.Maximized;
                    this.Activate();
                    gbSavaTime.Enabled = false;
                    txtPW.Enabled = true;
                    this.TopMost = true;
                    //txtPW.Focus();

                    //Update Time And OutDate -----
                    if (lblCounter.Text == "30" && GlobalVariables.fisttimeIsload == false && GlobalVariables.errorIsnone == true)
                    {
                        //Update Last Row When No Time -----
                        connection = new TheConnection();
                        Time time = new Time();
                        time.fTime = 0;
                        time.fOutDate = DateTime.Now;
                        connection.UpdateLastRowTimeOutDate(time);
                        myToolClass.ErrorLogToText(" vv- Time ended. Please insert coin -vv");
                    }
                    //Decrease lblCounter Until Zero To Shutdown -----------------
                    lblCounter.Text = Convert.ToString(Convert.ToInt32(lblCounter.Text) - 1);
                    lblTime.Text = DateTime.Now.ToString();

                    if (Convert.ToInt32(lblCounter.Text) <= 0) //Shutdown PC when counter reached zero..
                    {
                        SoundPlayer PlayShutdown = new SoundPlayer(Application.StartupPath + @"\Shutdown1.wav"); PlayShutdown.Play();
                        Application.Exit();
                        System.Threading.Thread.Sleep(3000);
                        WindowsController.ExitWindows(RestartOptions.ShutDown, true);
                    }

                }
                else if (lblMin.Text != "0" && lblSec.Text == "0") //Fires Every Minutes
                {
                    //if (!(txtSavePassword.Focused) || txtConfirmPassword.Focused) { txtPW.Enabled = true; }

                    lblSec.Text = "56";
                    lblMin.Text = Convert.ToString(Convert.ToInt32(lblMin.Text) - 1);
                    infinitePassword = 0;

                    //copy TokenTimer.accdb to drive C:
                    string dbPath= "\\\\PC-99\\e$\\TokenData\\" + System.Environment.MachineName;
                    if (File.Exists(dbPath + "\\TokenTimer.accdb"))
                    {
                        string sourceFile = Path.Combine(dbPath, "TokenTimer.accdb");
                        string destFile = Path.Combine("C:\\Norton2", "TokenTimer.accdb");
                        File.Copy(sourceFile, destFile, true);
                    }


                    //Update Time And OutDate Last Row Every Minutes-----
                    connection = new TheConnection();
                    Time time = new Time();
                    time.fTime = Convert.ToInt32(lblMin.Text);
                    time.fOutDate = DateTime.Now;
                    connection.UpdateLastRowTimeOutDate(time);

                    //Token Stucked Up or reached maximum time.. The time will reset to zero..
                    if (Convert.ToInt32(lblMin.Text) > 181)
                    {
                        lblMin.Text = "0"; lblSec.Text = "0";
                    }
                    if (lblMin.Text == "0" || lblMin.Text == "1")
                    {
                        SoundPlayer oneMinuteRemaining = new SoundPlayer(Application.StartupPath + @"\Music.wav");
                        oneMinuteRemaining.Play();
                    }
                }
                //Decrease lblSec every 4 seconds..
                else if (lblMin.Text != "0" || lblSec.Text != "0")
                    { lblSec.Text = Convert.ToString(Convert.ToInt16(lblSec.Text) - 4); 
                        if (txtPW.Enabled) this.Size = new Size(218, 22); this.WindowState = FormWindowState.Normal;
                }
            }
            catch (Win32Exception ex)
            {
                myToolClass.ErrorLogToText(" TickTimer ", ex.ToString());
                Application.Exit();
                WindowsController.ExitWindows(RestartOptions.LogOff, true);
            }

            catch (Exception exp)
            {
                myToolClass.ErrorLogToText(" TickTimer ", exp.ToString());
                //WindowsController.ExitWindows(RestartOptions.LogOff, true);
            }
            //Application.DoEvents();
        }
        //private void frmTTimer_Shown(object sender, EventArgs e)
        private bool IsErrorToDB()
        {
            bool r = false;
            try
            {
                //Stablish connection..
                connection = new TheConnection();

                //Get the current time in TIME table if is not zero and put it to lblmin.text..
                int iMin = connection.SelectLastRowTime();
                if (iMin > 0)
                {
                    lblMin.Text = iMin.ToString();
                    blnFormLoad = false;
                    this.WindowState = FormWindowState.Normal;
                    this.Size = new Size(218, 22);
                    myToolClass.ErrorLogToText(" ~~ Your time is successfully recovered. Remaining time = " + iMin.ToString() + " ~~");
                }
                else if (iMin == -1) { myToolClass.ErrorLogToText("!!! Database connection failed !!!"); }
                else
                    { myToolClass.ErrorLogToText(@" \\ You are succecfully connected to the database. Please insert coin. //"); }


                //Put And Refresh Total Inserted Token Label ---
                Time time = new Time();
                time.fInDate = DateTime.Now;
                int j = connection.SelectpDateTotalToken(time);
                lblTokens.Text = "Inserted Tokens=" + j.ToString();

                if (iMin == -1) { r = true; }

                //Run norton2 Service named Service1..
                sc.Refresh();
                if (sc.Status != System.ServiceProcess.ServiceControllerStatus.Running)
                {
                    sc.Start();
                    sc.Refresh();
                }
            }
            catch (Exception exp)
            {
                myToolClass.ErrorLogToText(" frmTTimer_Shown(object sender, EventArgs e) ", exp.ToString());
            }
            return r;
        }
        //private void frmTTimer_Load(object sender, EventArgs e)
        private void frmTTimer_Load()
        {
            try
            {
                lblVersion.Text = "Token Timer 4.0020 by NickJr";
                blnFormLoad = true;
                gbGroup.Enabled = false;
                this.Location = new Point(600, 0);
                this.TopMost = true;
                txtPW.Focus();
                myToolClass.ErrorLogToText(" ---------------------------------------------------------------------- Token Timer Started from FormLoad()");
                //Application.DoEvents();
            }
            catch (Exception exp)
            {
                myToolClass.ErrorLogToText(" FormLoad ", exp.ToString());
            }
        }

        byte infinitePassword = 0;
        private void txtPW_KeyUp(object sender, KeyEventArgs e)
        {
            //Moved KeyDown event to here with some edited statements..
            string pass = "4dm1n15tr4t0r";
            string pw0 = pass + "0";
            string pwc = pass + "c";
            string pwdt = pass + "dt";
            string pwdst = pass + "dst";

            try
            {
                if (e.KeyCode == Keys.Escape) { txtPW.Clear(); }
                if (e.KeyCode == Keys.Enter && txtPW.Text.Length >= 5)
                {
                    //Close From Backdoor with the static password..
                    if (txtPW.Text == pwc) { Application.Exit(); }

                    //Get PC name and number..
                    string strPcNum = txtPW.Text;
                    int pos = strPcNum.LastIndexOf("=") + 1;
                    strPcNum = strPcNum.Substring(pos, strPcNum.Length - pos);
                    if (strPcNum.Length == 1) { strPcNum = "0" + strPcNum; }
                    string strPcName = "PC-" + strPcNum;
                    //Set connection string of specific computer where the time saved.
                    if (pos < 5)
                    {
                        connection = new TheConnection();
                        strPcName = System.Environment.MachineName;
                    }
                    else
                    {
                        txtPW.Text = txtPW.Text.Substring(0, pos - 1);
                        string strPath = @"\\PC-99\e$\TokenData\" + strPcName + @"\TokenTimer.accdb";
                        string strConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " + strPath;
                        connection = new TheConnection(strConString);
                    }

                    //Retrive saved time from savetime database using txtPW.text parameter password..
                    SaveTime savetime = new SaveTime();
                    savetime.StPassword = txtPW.Text;
                    int i = connection.SelectpPasswordSaveTime(savetime); 

                    if (i != 0) //Correct Password..
                    {
                        this.WindowState = FormWindowState.Normal;
                        this.Size = new Size(218, 22);
                        //Update the savetime.stime field from what PC was saved..
                        savetime.StTime = 0;
                        savetime.StUseDate = DateTime.Now;
                        //TimeSpan minDiff = DateTime.Now - savetime.StSaveDate;
                        //int minutesDiff =  minDiff.Minutes;
                        savetime.StPassword = i.ToString() + " - " + strPcName + " - " + pass;
                        savetime.StUsePassword = txtPW.Text;
                        savetime.StPasswordw = txtPW.Text;
                        connection.UpdatepPasswordSaveTime(savetime);
                        blnFormLoad = false;

                        //Insert Time To Database And Place Token To Zero ---------------
                        connection = new TheConnection();
                        Time time = new Time();
                        lblMin.Text = Convert.ToString(i + (Convert.ToInt32(lblMin.Text)));
                        time.fTime = Convert.ToInt32(lblMin.Text);
                        time.fToken = 0;
                        connection.InsertTime(time);

                        myToolClass.ErrorLogToText(" <= " + i.ToString() +  " minutes added from saved time " 
                            + strPcName + " [" + txtPW.Text + "]." +  " Your total remaining time is " + lblMin.Text + " =>");

                        txtPW.Clear();
                        SoundPlayer PlayPoints = new SoundPlayer(Application.StartupPath + @"\Music3.wav");
                        PlayPoints.Play();
                        infinitePassword = 0;
                        return;
                    }
                    else if (txtPW.Text == pwc)
                    {
                        Application.Exit();
                    }
                    else if (txtPW.Text == pw0)
                    {
                        this.Size = new Size(218, 250);
                        gbGroup.Enabled = true;
                        rbAdd.Checked = true;
                        txtPW.Clear();
                        tmrTime.Stop();
                        nudTime.Focus();
                        nudTime.Select(1, 2);
                        return;
                    }
                    else if (txtPW.Text == pwdt)
                    {
                        //Delete Time To Database
                        connection = new TheConnection();
                        Time time = new Time();
                        connection.DeleteTime(time);
                        txtPW.Clear();

                        lblTokens.Text = "Inserted Tokens=0";
                    }
                    else if (txtPW.Text == pwdst)
                    {
                        //Delete Save Time To Database
                        connection = new TheConnection();
                        connection.DeleteSaveTime(savetime);
                        txtPW.Clear();
                    }
                    else if (txtPW.Text == "4dm1n15tr4t0r20")///Like token inserted..
                    {
                        //Resize Form
                        this.WindowState = FormWindowState.Normal;
                        this.Size = new Size(218, 22);

                        lblCounter.Text = "30";
                        lblMin.Text = Convert.ToString(Convert.ToInt32(lblMin.Text) + 20);
                        blnFormLoad = false;

                        //Insert Time To Database..
                        connection = new TheConnection();
                        Time time = new Time();
                        time.fTime = Convert.ToInt32(lblMin.Text);
                        time.fToken = 5;
                        connection.InsertTime(time);

                        //Write and Refresh Total Tokens To lblInsertedToken..
                        time.fInDate = DateTime.Now;
                        int j = connection.SelectpDateTotalToken(time);
                        lblTokens.Text = "Inserted Tokens=" + j.ToString();

                        //play sound;
                        SoundPlayer PlayPoints = new SoundPlayer(Application.StartupPath + @"\Points.wav"); PlayPoints.Play();
                        txtSavePassword.Clear();
                        infinitePassword = 0;
                    }
                    else // Wrong password. plays sound..
                    {
                        //Shutdown when infinite wrong passwords occured..
                        infinitePassword += 1;
                        if (infinitePassword == 5)
                        {
                            Application.DoEvents();
                            string msg = "!!! Wrong password[" + txtPW.Text + "] limit exceeded the computer will shutdown. " + "Your remaining time is " + lblMin.Text + " minutes !!!";
                            myToolClass.ErrorLogToText(msg);
                            SoundPlayer PlayShutdown = new SoundPlayer(Application.StartupPath + @"\Shutdown1.wav"); PlayShutdown.Play();
                            Application.Exit();
                            System.Threading.Thread.Sleep(3000);
                            WindowsController.ExitWindows(RestartOptions.ShutDown, true);
                        }
                        else if (infinitePassword == 4)
                        {
                            string msg = " You have entered wrong password[" + txtPW.Text + "] 4 TIMES, one more wrong input password will shutdown this computer.";
                            myToolClass.ErrorLogToText(msg);
                            SoundPlayer PlayPoints = new SoundPlayer(Application.StartupPath + @"\Music2.wav");
                            PlayPoints.Play();
                            MessageBox.Show(msg, "WARNING EXCEEDING WRONG PASSWORD!!");
                            txtPW.Clear();
                        }
                        else if (infinitePassword <= 3)
                        {
                            string msg = " You have entered wrong password[" + txtPW.Text + "] " + infinitePassword + " TIME/S. Please enter correct password.";
                            myToolClass.ErrorLogToText(msg);
                            SoundPlayer PlayPoints = new SoundPlayer(Application.StartupPath + @"\Music2.wav");
                            PlayPoints.Play();
                            MessageBox.Show(msg, "ENTERED WRONG PASSWORD!" );
                            txtPW.Clear();
                        }
                        return;
                    }
                }
            }
            catch (Win32Exception ex)
            {
                myToolClass.ErrorLogToText(" txtPW_KeyUp ", ex.ToString());
                Application.Exit();
                WindowsController.ExitWindows(RestartOptions.LogOff, true);
            }
            catch (Exception exp)
            {
                myToolClass.ErrorLogToText(" txtPW_KeyUp ", exp.ToString());
            }
        }

       
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                tmrTime.Start();
                if (nudTime.Value == 0) 
                {
                    gbGroup.Enabled = false;
                    this.WindowState = FormWindowState.Normal;
                    this.Size = new Size(218, 22);
                    return; 
                }
                else
                {
                    blnFormLoad = false;
                }

                connection = new TheConnection();
                Time time = new Time();
                if (rbAdd.Checked)
                {
                    
                    if (lblMin.Text == "0" && lblMin.Text == "0")
                    {
                        //Insert Time To Database
                        lblMin.Text = nudTime.Value.ToString();
                        time.fTime = Convert.ToInt32(lblMin.Text);
                        time.fToken = 0;
                        connection.InsertTime(time);
                    }
                    else
                    {
                        //Update Time To Database
                        lblMin.Text = Convert.ToString(Convert.ToInt32(lblMin.Text) + Convert.ToInt32(nudTime.Value));
                        time.fTime = Convert.ToInt32(lblMin.Text);
                        time.fOutDate = DateTime.Now;
                        connection.UpdateLastRowTimeOutDate(time);
                    }
                }
                else
                {
                    //Update Time To Database
                    lblMin.Text = Convert.ToString(nudTime.Value);
                    time.fTime = Convert.ToInt32(lblMin.Text);
                    time.fOutDate = DateTime.Now;
                    connection.UpdateLastRowTimeOutDate(time);
                }

                gbGroup.Enabled = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(218, 22);
                nudTime.Value = 0;
                lblCounter.Text = "30";
            }
            catch (Exception exp)
            {
                myToolClass.ErrorLogToText(" btnOK_Click(object sender, EventArgs e) ", exp.ToString());
            }
        }

        private void lblTokens_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var ans = MessageBox.Show("Click YES To Log Off. No To Shutdown. Cancel To Restart", "OFF", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    SoundPlayer PlayShutdown = new SoundPlayer(Application.StartupPath + @"\Shutdown1.wav");
                    PlayShutdown.Play();
                    Application.Exit();
                    System.Threading.Thread.Sleep(4000);
                    WindowsController.ExitWindows(RestartOptions.LogOff, true);
                }
                else if(ans == DialogResult.No)
                {
                    SoundPlayer PlayShutdown = new SoundPlayer(Application.StartupPath + @"\Shutdown1.wav");
                    PlayShutdown.Play();
                    Application.Exit();
                    System.Threading.Thread.Sleep(4000);
                    WindowsController.ExitWindows(RestartOptions.ShutDown, true);
                }
                else if(ans==DialogResult.Cancel)
                {
                    SoundPlayer PlayShutdown = new SoundPlayer(Application.StartupPath + @"\Shutdown1.wav");
                    PlayShutdown.Play();
                    Application.Exit();
                    System.Threading.Thread.Sleep(4000);
                    WindowsController.ExitWindows(RestartOptions.Reboot, true);
                }
            }
            catch (Exception exp)
            {
                myToolClass.ErrorLogToText(" lblTokens_DoubleClick(object sender, EventArgs e) ", exp.ToString());
            }
        }

        private void frmTTimer_FormClosing(object sender, FormClosingEventArgs e)
        {
            myToolClass.ErrorLogToText(" |----------------------------------------------------------------------| Token Timer Closed");
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                //SoundPlayer PlayShutdown = new SoundPlayer(Application.StartupPath + @"\Shutdown1.wav");
                //PlayShutdown.Play();
                myToolClass.ErrorLogToText(" ---Improper Shutdown Detected! ---");
                //System.Threading.Thread.Sleep(500);
                WindowsController.ExitWindows(RestartOptions.LogOff, true);
            }
        }

        private void lblLeft_Click(object sender, EventArgs e)
        {
            this.Left -= 100;
        }

        private void lblRight_Click(object sender, EventArgs e)
        {
            this.Left += 100;
        }

        private void nudTime_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnOK.PerformClick();
                }
                if (e.KeyCode == Keys.S && e.Modifiers == Keys.Alt)
                {
                    rbSet.Checked = true;
                    rbAdd.Checked = false;
                }
                if (e.KeyCode == Keys.A && e.Modifiers == Keys.Alt)
                {
                    rbAdd.Checked = true;
                    rbSet.Checked = false;
                }
            }
            catch (Exception exp)
            {
                myToolClass.ErrorLogToText(" nudTime_KeyDown(object sender, KeyEventArgs e) ", exp.ToString());
            }
        }
        private void lblMin_DoubleClick(object sender, EventArgs e)
        {
            lblSec_DoubleClick(sender, e);
        }

        private void lblSec_DoubleClick(object sender, EventArgs e)
        {
            if (lblMin.Text == "0" && lblSec.Text == "0") return;
            var ans = MessageBox.Show("Reset Time?", "Reset Time", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                //Reset Time----
                lblMin.Text = "0"; lblSec.Text = "0"; txtPW.Clear(); lblCounter.Text = "30";
            }
        }

        private void btnSaveTime_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                if (this.Height == 22)
                {
                    gbSavaTime.Enabled = true;
                    this.Size = new Size(218, 120);
                    txtSavePassword.Focus();
                    txtPW.Enabled = false;
                }
                else if (this.Height == 120)
                {
                    this.Size = new Size(218, 22);
                    gbSavaTime.Enabled = false;
                    txtSavePassword.Clear();
                    txtConfirmPassword.Clear();
                    txtPW.Enabled = true;
                    txtPW.Focus();
                }
            }
        }

        private void btnSaveOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSavePassword.TextLength < 5)
                {
                    MessageBox.Show("Maglagay ng password na higit sa apat(4).","PASSWORD ERRROR!");
                    txtSavePassword.Clear();
                    txtConfirmPassword.Clear();
                    txtSavePassword.Focus();
                    return;
                }
                if (txtSavePassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Kailangang magkapareho ang iyong password.", "PASSSWORD CHECKING!");
                    txtSavePassword.Clear();
                    txtConfirmPassword.Clear();
                    //gbSavaTime.Enabled = false;
                    //this.Size = new Size(218, 22);
                    //txtPW.Enabled = true;
                    txtSavePassword.Focus();
                    return;
                }
                else if (Convert.ToInt32(lblMin.Text) > 2)
                {
                    //Insert Saved Time To Database -------
                    connection = new TheConnection();
                    SaveTime savetime = new SaveTime();
                    savetime.StPassword = txtSavePassword.Text;
                    int i = connection.SelectpPasswordSaveTime(savetime);
                    if (i == 0)
                    {
                        savetime.StTime = Convert.ToInt32(lblMin.Text);
                        //savetime.StUseDate = Convert.ToDateTime("#6/6/1978#");
                        savetime.StPassword = txtSavePassword.Text;
                        connection.InsertSaveTime(savetime);
                        txtPW.Enabled = true;
                        myToolClass.ErrorLogToText(" => " + lblMin.Text," minutes is sucessfully saved " + "[" + txtSavePassword.Text + "]." +  " <=");

                        //Update last row in tbSaveTime to zero
                        Time time = new Time();
                        time.fTime = 0;
                        time.fToken = 0;
                        connection.InsertTime(time);
                    }
                    else
                    {
                        MessageBox.Show("Maglagay ng ibang password.", "PASSWORD WARNING!");
                        txtSavePassword.Clear();
                        txtConfirmPassword.Clear();
                        //gbSavaTime.Enabled = false;
                        //this.Size = new Size(218, 22);
                        //txtPW.Enabled = true;
                        txtSavePassword.Focus();
                        return;
                    }
                    //Reset Time----
                    lblMin.Text = "0"; lblSec.Text = "0"; txtPW.Clear();
                    lblCounter.Text = "30";
                    txtSavePassword.Clear();
                    txtConfirmPassword.Clear();
                    gbSavaTime.Enabled = false;

                    this.WindowState = FormWindowState.Maximized;
                    this.Activate();
                    this.TopMost = true;
                    txtPW.Focus();
                }
            }
            catch (Exception exp)
            {
                myToolClass.ErrorLogToText(" btnSaveOk_Click(object sender, EventArgs e) ", exp.ToString());
                txtSavePassword.Focus();
            }
        }

        private void txtSavePassword_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
           {
               txtConfirmPassword.Focus();
           }
        }

        private void txtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               btnSaveOk_Click(sender, e);
            }
        }

        private void lblCloseLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult msgresult = MessageBox.Show("Close And Log Out All Open Applications?", "Confirmation...", MessageBoxButtons.YesNo);
                if (msgresult == DialogResult.Yes)
                {
                    foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses(System.Environment.MachineName))
                    {
                        if (p.MainWindowHandle != IntPtr.Zero)
                        {
                            p.Kill();
                            //Console.WriteLine(p.ProcessName);
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception exp)
            {
                myToolClass.ErrorLogToText(" lblCloseLogOut_DoubleClick(object sender, EventArgs e) ", exp.ToString());
            }
        }

        private void frmTTimer_Load(object sender, EventArgs e)
        {
            myToolClass.ErrorLogToText(" << Form Load Started Typical >>");
        }
    }

    public class myToolClass
    {
        public static void ErrorLogToText(string eventname, [Optional] string exp)
        {
            bool pathIslocal = true;
            for (int i = 1; i <= 2; i++)
            {
                string path = (pathIslocal == true) ? Application.StartupPath : @"\\PC-99\e$\TokenData\";
                if (!Directory.Exists(path)) return;
                using (StreamWriter writer = new StreamWriter(path + @"\Errors_" + System.Environment.MachineName + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now + eventname + exp);
                }
                pathIslocal = false;
            }
        }
    }
}
