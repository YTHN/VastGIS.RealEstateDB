using VastGIS.Common.UI.Controls;

namespace VastGIS.RealEstateDB.Views
{
    partial class WelcomeView
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
            this.btnClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.picureLogo = new System.Windows.Forms.PictureBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lbProject3 = new VastGIS.Common.UI.Controls.LinkLabelEx();
            this.lbProject2 = new VastGIS.Common.UI.Controls.LinkLabelEx();
            this.lbProject1 = new VastGIS.Common.UI.Controls.LinkLabelEx();
            this.chkShowDlg = new System.Windows.Forms.CheckBox();
            this.PictureBox5 = new System.Windows.Forms.PictureBox();
            this.PictureBox3 = new System.Windows.Forms.PictureBox();
            this.lbGettingStarted = new VastGIS.Common.UI.Controls.LinkLabelEx();
            this.lbOpenProject = new VastGIS.Common.UI.Controls.LinkLabelEx();
            ((System.ComponentModel.ISupportInitialize)(this.picureLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnClose.BeforeTouchSize = new System.Drawing.Size(93, 27);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.IsBackStageButton = false;
            this.btnClose.Location = new System.Drawing.Point(459, 206);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 27);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "关闭";
            // 
            // picureLogo
            // 
            this.picureLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picureLogo.Image = global::VastGIS.RealEstateDB.Properties.Resources.mapwindow_logo;
            this.picureLogo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picureLogo.Location = new System.Drawing.Point(11, 22);
            this.picureLogo.Name = "picureLogo";
            this.picureLogo.Size = new System.Drawing.Size(268, 41);
            this.picureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picureLogo.TabIndex = 35;
            this.picureLogo.TabStop = false;
            // 
            // lblVersion
            // 
            this.lblVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblVersion.Location = new System.Drawing.Point(40, 66);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(222, 22);
            this.lblVersion.TabIndex = 34;
            this.lblVersion.Text = "版本1.0";
            // 
            // lbProject3
            // 
            this.lbProject3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbProject3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbProject3.LinkArea = new System.Windows.Forms.LinkArea(0, 8);
            this.lbProject3.Location = new System.Drawing.Point(308, 130);
            this.lbProject3.Name = "lbProject3";
            this.lbProject3.Size = new System.Drawing.Size(215, 15);
            this.lbProject3.TabIndex = 33;
            this.lbProject3.TabStop = true;
            this.lbProject3.Tag = "2";
            this.lbProject3.Text = "Project3";
            this.lbProject3.Click += new System.EventHandler(this.OnRecentProjectClick);
            // 
            // lbProject2
            // 
            this.lbProject2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbProject2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbProject2.LinkArea = new System.Windows.Forms.LinkArea(0, 8);
            this.lbProject2.Location = new System.Drawing.Point(308, 108);
            this.lbProject2.Name = "lbProject2";
            this.lbProject2.Size = new System.Drawing.Size(215, 15);
            this.lbProject2.TabIndex = 32;
            this.lbProject2.TabStop = true;
            this.lbProject2.Tag = "1";
            this.lbProject2.Text = "Project2";
            this.lbProject2.Click += new System.EventHandler(this.OnRecentProjectClick);
            // 
            // lbProject1
            // 
            this.lbProject1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbProject1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbProject1.LinkArea = new System.Windows.Forms.LinkArea(0, 8);
            this.lbProject1.Location = new System.Drawing.Point(308, 86);
            this.lbProject1.Name = "lbProject1";
            this.lbProject1.Size = new System.Drawing.Size(215, 15);
            this.lbProject1.TabIndex = 31;
            this.lbProject1.TabStop = true;
            this.lbProject1.Tag = "0";
            this.lbProject1.Text = "Project1";
            this.lbProject1.Click += new System.EventHandler(this.OnRecentProjectClick);
            // 
            // chkShowDlg
            // 
            this.chkShowDlg.Checked = true;
            this.chkShowDlg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowDlg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkShowDlg.Location = new System.Drawing.Point(13, 210);
            this.chkShowDlg.Name = "chkShowDlg";
            this.chkShowDlg.Size = new System.Drawing.Size(170, 18);
            this.chkShowDlg.TabIndex = 30;
            this.chkShowDlg.Text = "启动的时候显示该窗口";
            this.chkShowDlg.CheckedChanged += new System.EventHandler(this.cbShowDlg_CheckedChanged);
            // 
            // PictureBox5
            // 
            this.PictureBox5.Image = global::VastGIS.RealEstateDB.Properties.Resources.img_book24;
            this.PictureBox5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PictureBox5.Location = new System.Drawing.Point(11, 96);
            this.PictureBox5.Name = "PictureBox5";
            this.PictureBox5.Size = new System.Drawing.Size(24, 22);
            this.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox5.TabIndex = 28;
            this.PictureBox5.TabStop = false;
            // 
            // PictureBox3
            // 
            this.PictureBox3.Image = global::VastGIS.RealEstateDB.Properties.Resources.icon_folder;
            this.PictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PictureBox3.Location = new System.Drawing.Point(299, 55);
            this.PictureBox3.Name = "PictureBox3";
            this.PictureBox3.Size = new System.Drawing.Size(24, 22);
            this.PictureBox3.TabIndex = 26;
            this.PictureBox3.TabStop = false;
            // 
            // lbGettingStarted
            // 
            this.lbGettingStarted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbGettingStarted.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbGettingStarted.LinkArea = new System.Windows.Forms.LinkArea(0, 4);
            this.lbGettingStarted.Location = new System.Drawing.Point(40, 103);
            this.lbGettingStarted.Name = "lbGettingStarted";
            this.lbGettingStarted.Size = new System.Drawing.Size(223, 15);
            this.lbGettingStarted.TabIndex = 22;
            this.lbGettingStarted.TabStop = true;
            this.lbGettingStarted.Text = "帮助手册";
            this.lbGettingStarted.UseCompatibleTextRendering = true;
            // 
            // lbOpenProject
            // 
            this.lbOpenProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbOpenProject.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbOpenProject.LinkArea = new System.Windows.Forms.LinkArea(0, 4);
            this.lbOpenProject.Location = new System.Drawing.Point(331, 63);
            this.lbOpenProject.Name = "lbOpenProject";
            this.lbOpenProject.Size = new System.Drawing.Size(220, 15);
            this.lbOpenProject.TabIndex = 21;
            this.lbOpenProject.TabStop = true;
            this.lbOpenProject.Text = "打开项目";
            this.lbOpenProject.UseCompatibleTextRendering = true;
            // 
            // WelcomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 240);
            this.Controls.Add(this.picureLogo);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lbProject3);
            this.Controls.Add(this.lbProject2);
            this.Controls.Add(this.lbProject1);
            this.Controls.Add(this.chkShowDlg);
            this.Controls.Add(this.PictureBox5);
            this.Controls.Add(this.PictureBox3);
            this.Controls.Add(this.lbGettingStarted);
            this.Controls.Add(this.lbOpenProject);
            this.Controls.Add(this.btnClose);
            this.Name = "WelcomeView";
            this.Text = "欢迎使用未见不动产数据库管理工具";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WelcomeView_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picureLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnClose;
        internal System.Windows.Forms.PictureBox picureLogo;
        internal System.Windows.Forms.Label lblVersion;
        internal LinkLabelEx lbProject3;
        internal LinkLabelEx lbProject2;
        internal LinkLabelEx lbProject1;
        internal System.Windows.Forms.CheckBox chkShowDlg;
        internal System.Windows.Forms.PictureBox PictureBox5;
        internal System.Windows.Forms.PictureBox PictureBox3;
        internal LinkLabelEx lbGettingStarted;
        internal LinkLabelEx lbOpenProject;
    }
}