using System;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using VastGIS.Common.Plugins.Services;
using VastGIS.Common.UI.Forms;
using VastGIS.RealEstateDB.Helpers;

namespace VastGIS.RealEstateDB.Forms
{
    public partial class frmCreateDB : VGWindowForm
    {
        public frmCreateDB()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            DialogResult=DialogResult.Cancel;
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "项目保存位置";
            dialog.ShowNewFolderButton = true;
            if (dialog.ShowDialog() != DialogResult.OK) return ;
           
            txtDB.Text = dialog.SelectedPath;
        }

        public string ProjectFile { get { return txtDB.Text; } }
        public string ProjectName { get { return txtName.Text; } }

        public int EpsGCode { get { return Convert.ToInt16(txtSR.Tag); } }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDB.Text))
            {
                MessageService.Current.Warn("请输入项目文件保存位置!");
               
                return;
            }
            string folder = txtDB.Text+"\\"+txtName.Text.Trim();
            if (Directory.Exists(folder))
            {
                if (Directory.GetDirectories(folder).Length > 0 || Directory.GetFiles(folder).Length > 0)
                {
                    MessageService.Current.Warn("'文件夹不为空！");
                    return;
                }
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageService.Current.Warn("请输入项目名称!");
                return;
            }
            if (string.IsNullOrEmpty(txtSR.Tag.ToString()))
            {
                MessageService.Current.Warn("请选择坐标基准!");
                return;
            }
            DialogResult =DialogResult.OK;
        }

        private void btnSR_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ESRI 投影信息文件(*.prj)|*.prj";
            ofd.Title = "读取ESRI投影定义文件";
            ofd.Multiselect = false;
            string pFolderPath = System.IO.Path.Combine(Application.StartupPath + "\\Coordinate Systems");
            if (pFolderPath != null &&
                Directory.Exists(pFolderPath))
            {
                ofd.InitialDirectory = pFolderPath;
            }
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                FileStream fs=new FileStream(filePath,FileMode.Open, FileAccess.Read);
                FileInfo info=new FileInfo(ofd.FileName);
                StreamReader sr=new StreamReader(fs);
                string str = sr.ReadToEnd();
                fs.Close();
                int i = str.IndexOf(@"AUTHORITY[");
                int j = str.IndexOf("]", i + 1);
                string epsStr = str.Substring(i + 10, j - i - 10);
                txtSR.Tag = epsStr.Split(',')[1];
                txtSR.Text = info.Name;

            }
           
        }
    }
}
