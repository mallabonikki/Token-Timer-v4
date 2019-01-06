namespace TokenTimerV4
{
    partial class frmTTimer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTTimer));
            this.lblSec = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblTokens = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.gbGroup = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.nudTime = new System.Windows.Forms.NumericUpDown();
            this.rbAdd = new System.Windows.Forms.RadioButton();
            this.rbSet = new System.Windows.Forms.RadioButton();
            this.btnRes = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPO = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblCounter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveTime = new System.Windows.Forms.Button();
            this.gbSavaTime = new System.Windows.Forms.GroupBox();
            this.btnSaveOk = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSavePassword = new System.Windows.Forms.TextBox();
            this.lblCloseLogOut = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.gbGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).BeginInit();
            this.gbSavaTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.BackColor = System.Drawing.Color.Transparent;
            this.lblSec.ForeColor = System.Drawing.Color.Gold;
            this.lblSec.Location = new System.Drawing.Point(125, 7);
            this.lblSec.Margin = new System.Windows.Forms.Padding(0);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(31, 32);
            this.lblSec.TabIndex = 0;
            this.lblSec.Text = "0";
            this.lblSec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSec.DoubleClick += new System.EventHandler(this.lblSec_DoubleClick);
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.BackColor = System.Drawing.Color.Transparent;
            this.lblMin.ForeColor = System.Drawing.Color.Gold;
            this.lblMin.Location = new System.Drawing.Point(53, 7);
            this.lblMin.Margin = new System.Windows.Forms.Padding(0);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(31, 32);
            this.lblMin.TabIndex = 1;
            this.lblMin.Text = "0";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMin.DoubleClick += new System.EventHandler(this.lblMin_DoubleClick);
            // 
            // lblTokens
            // 
            this.lblTokens.AutoSize = true;
            this.lblTokens.BackColor = System.Drawing.Color.Transparent;
            this.lblTokens.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTokens.ForeColor = System.Drawing.Color.Gold;
            this.lblTokens.Location = new System.Drawing.Point(173, 14);
            this.lblTokens.Margin = new System.Windows.Forms.Padding(0);
            this.lblTokens.Name = "lblTokens";
            this.lblTokens.Size = new System.Drawing.Size(176, 25);
            this.lblTokens.TabIndex = 2;
            this.lblTokens.Text = "Inserted Tokens=0";
            this.lblTokens.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTokens.DoubleClick += new System.EventHandler(this.lblTokens_DoubleClick);
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.BackColor = System.Drawing.Color.Transparent;
            this.lblRight.ForeColor = System.Drawing.Color.Gold;
            this.lblRight.Location = new System.Drawing.Point(552, 7);
            this.lblRight.Margin = new System.Windows.Forms.Padding(0);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(31, 32);
            this.lblRight.TabIndex = 3;
            this.lblRight.Text = ">";
            this.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRight.Click += new System.EventHandler(this.lblRight_Click);
            // 
            // gbGroup
            // 
            this.gbGroup.BackColor = System.Drawing.Color.Transparent;
            this.gbGroup.Controls.Add(this.btnOK);
            this.gbGroup.Controls.Add(this.nudTime);
            this.gbGroup.Controls.Add(this.rbAdd);
            this.gbGroup.Controls.Add(this.rbSet);
            this.gbGroup.Controls.Add(this.btnRes);
            this.gbGroup.Controls.Add(this.btnReset);
            this.gbGroup.Controls.Add(this.btnPO);
            this.gbGroup.Controls.Add(this.btnClose);
            this.gbGroup.Enabled = false;
            this.gbGroup.Location = new System.Drawing.Point(27, 281);
            this.gbGroup.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbGroup.Name = "gbGroup";
            this.gbGroup.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbGroup.Size = new System.Drawing.Size(520, 289);
            this.gbGroup.TabIndex = 4;
            this.gbGroup.TabStop = false;
            this.gbGroup.Text = "ADJUST TIME";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(272, 210);
            this.btnOK.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(232, 55);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // nudTime
            // 
            this.nudTime.Location = new System.Drawing.Point(272, 153);
            this.nudTime.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nudTime.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudTime.Name = "nudTime";
            this.nudTime.Size = new System.Drawing.Size(232, 38);
            this.nudTime.TabIndex = 1;
            this.nudTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudTime_KeyDown);
            // 
            // rbAdd
            // 
            this.rbAdd.AutoSize = true;
            this.rbAdd.Location = new System.Drawing.Point(272, 31);
            this.rbAdd.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rbAdd.Name = "rbAdd";
            this.rbAdd.Size = new System.Drawing.Size(173, 36);
            this.rbAdd.TabIndex = 6;
            this.rbAdd.TabStop = true;
            this.rbAdd.Text = "Add Time";
            this.rbAdd.UseVisualStyleBackColor = true;
            // 
            // rbSet
            // 
            this.rbSet.AutoSize = true;
            this.rbSet.Location = new System.Drawing.Point(272, 100);
            this.rbSet.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rbSet.Name = "rbSet";
            this.rbSet.Size = new System.Drawing.Size(165, 36);
            this.rbSet.TabIndex = 7;
            this.rbSet.TabStop = true;
            this.rbSet.Text = "Set Time";
            this.rbSet.UseVisualStyleBackColor = true;
            // 
            // btnRes
            // 
            this.btnRes.Location = new System.Drawing.Point(16, 217);
            this.btnRes.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnRes.Name = "btnRes";
            this.btnRes.Size = new System.Drawing.Size(200, 55);
            this.btnRes.TabIndex = 2;
            this.btnRes.Text = "Restart";
            this.btnRes.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(16, 91);
            this.btnReset.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(200, 55);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnPO
            // 
            this.btnPO.Location = new System.Drawing.Point(16, 153);
            this.btnPO.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnPO.Name = "btnPO";
            this.btnPO.Size = new System.Drawing.Size(200, 55);
            this.btnPO.TabIndex = 1;
            this.btnPO.Text = "Power Off";
            this.btnPO.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(16, 31);
            this.btnClose.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(200, 55);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // txtPW
            // 
            this.txtPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPW.Location = new System.Drawing.Point(371, 7);
            this.txtPW.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtPW.Name = "txtPW";
            this.txtPW.PasswordChar = '*';
            this.txtPW.Size = new System.Drawing.Size(127, 34);
            this.txtPW.TabIndex = 0;
            this.txtPW.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPW_KeyUp);
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.BackColor = System.Drawing.Color.Transparent;
            this.lblLeft.ForeColor = System.Drawing.Color.Gold;
            this.lblLeft.Location = new System.Drawing.Point(3, 7);
            this.lblLeft.Margin = new System.Windows.Forms.Padding(0);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(31, 32);
            this.lblLeft.TabIndex = 6;
            this.lblLeft.Text = "<";
            this.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLeft.Click += new System.EventHandler(this.lblLeft_Click);
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.BackColor = System.Drawing.Color.Transparent;
            this.lblCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblCounter.Location = new System.Drawing.Point(589, 69);
            this.lblCounter.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(380, 272);
            this.lblCounter.TabIndex = 7;
            this.lblCounter.Text = "30";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(933, 138);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2206, 181);
            this.label1.TabIndex = 8;
            this.label1.Text = "INSERT 5 PESO COIN NOW!";
            // 
            // btnSaveTime
            // 
            this.btnSaveTime.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveTime.Enabled = false;
            this.btnSaveTime.ForeColor = System.Drawing.Color.Gold;
            this.btnSaveTime.Location = new System.Drawing.Point(512, 0);
            this.btnSaveTime.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnSaveTime.Name = "btnSaveTime";
            this.btnSaveTime.Size = new System.Drawing.Size(37, 55);
            this.btnSaveTime.TabIndex = 9;
            this.btnSaveTime.Text = "S";
            this.btnSaveTime.UseVisualStyleBackColor = false;
            this.btnSaveTime.Click += new System.EventHandler(this.btnSaveTime_Click);
            // 
            // gbSavaTime
            // 
            this.gbSavaTime.BackColor = System.Drawing.Color.Transparent;
            this.gbSavaTime.Controls.Add(this.btnSaveOk);
            this.gbSavaTime.Controls.Add(this.label3);
            this.gbSavaTime.Controls.Add(this.txtConfirmPassword);
            this.gbSavaTime.Controls.Add(this.label2);
            this.gbSavaTime.Controls.Add(this.txtSavePassword);
            this.gbSavaTime.Enabled = false;
            this.gbSavaTime.Location = new System.Drawing.Point(21, 60);
            this.gbSavaTime.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gbSavaTime.Name = "gbSavaTime";
            this.gbSavaTime.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gbSavaTime.Size = new System.Drawing.Size(525, 210);
            this.gbSavaTime.TabIndex = 10;
            this.gbSavaTime.TabStop = false;
            this.gbSavaTime.Text = "SAVE TIME";
            // 
            // btnSaveOk
            // 
            this.btnSaveOk.AutoSize = true;
            this.btnSaveOk.Location = new System.Drawing.Point(349, 141);
            this.btnSaveOk.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnSaveOk.Name = "btnSaveOk";
            this.btnSaveOk.Size = new System.Drawing.Size(176, 100);
            this.btnSaveOk.TabIndex = 2;
            this.btnSaveOk.Text = "OK";
            this.btnSaveOk.UseVisualStyleBackColor = true;
            this.btnSaveOk.Click += new System.EventHandler(this.btnSaveOk_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "CONFIRM:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(176, 91);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(332, 38);
            this.txtConfirmPassword.TabIndex = 1;
            this.txtConfirmPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConfirmPassword_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "PASSWORD:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSavePassword
            // 
            this.txtSavePassword.Location = new System.Drawing.Point(176, 41);
            this.txtSavePassword.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtSavePassword.Name = "txtSavePassword";
            this.txtSavePassword.PasswordChar = '*';
            this.txtSavePassword.Size = new System.Drawing.Size(332, 38);
            this.txtSavePassword.TabIndex = 0;
            this.txtSavePassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSavePassword_KeyDown);
            // 
            // lblCloseLogOut
            // 
            this.lblCloseLogOut.AutoSize = true;
            this.lblCloseLogOut.BackColor = System.Drawing.Color.Transparent;
            this.lblCloseLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCloseLogOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblCloseLogOut.Location = new System.Drawing.Point(21, 603);
            this.lblCloseLogOut.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCloseLogOut.Name = "lblCloseLogOut";
            this.lblCloseLogOut.Size = new System.Drawing.Size(480, 78);
            this.lblCloseLogOut.TabIndex = 11;
            this.lblCloseLogOut.Text = "Close/Log Out";
            this.lblCloseLogOut.Click += new System.EventHandler(this.lblCloseLogOut_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblVersion.Location = new System.Drawing.Point(624, 14);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(112, 32);
            this.lblVersion.TabIndex = 13;
            this.lblVersion.Text = "Version";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTime.Location = new System.Drawing.Point(1395, 21);
            this.lblTime.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(135, 54);
            this.lblTime.TabIndex = 14;
            this.lblTime.Tag = "";
            this.lblTime.Text = "TIME";
            // 
            // frmTTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(3003, 1362);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblCloseLogOut);
            this.Controls.Add(this.gbSavaTime);
            this.Controls.Add(this.btnSaveTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.txtPW);
            this.Controls.Add(this.gbGroup);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.lblTokens);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblSec);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "frmTTimer";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmTTimer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTTimer_FormClosing);
            this.Load += new System.EventHandler(this.frmTTimer_Load);
            this.gbGroup.ResumeLayout(false);
            this.gbGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).EndInit();
            this.gbSavaTime.ResumeLayout(false);
            this.gbSavaTime.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblTokens;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.GroupBox gbGroup;
        private System.Windows.Forms.Button btnRes;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnPO;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown nudTime;
        private System.Windows.Forms.RadioButton rbAdd;
        private System.Windows.Forms.RadioButton rbSet;
        private System.Windows.Forms.TextBox txtPW;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveTime;
        private System.Windows.Forms.GroupBox gbSavaTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSavePassword;
        private System.Windows.Forms.Button btnSaveOk;
        private System.Windows.Forms.Label lblCloseLogOut;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblTime;
    }
}