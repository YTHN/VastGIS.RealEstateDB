using System;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
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
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "数据库";
            dialog.Filter = "Sqlite数据库(*.sqlite)|*.sqlite";
            if (dialog.ShowDialog() != DialogResult.OK) return ;
            txtDB.Text = dialog.FileName;

            
        }

        public string DatabaseName { get { return txtDB.Text; } }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            var spatialitePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Templates\\vastgis.sqlite");
            FileInfo tempFile = new FileInfo(spatialitePath);
            tempFile.CopyTo(txtDB.Text);
            //SQLiteConnection.CreateFile(txtDB.Text);
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + txtDB.Text + "; Version = 3;");
            conn.Open();
            SpatialiteSharp.SpatialiteLoader.Load(conn);
            SQLiteCommand command=new SQLiteCommand(ZDSqlHelper.C,conn);
            command.ExecuteNonQuery();
            command.CommandText = ZDSqlHelper.QLR;
            command.ExecuteNonQuery();
            command.CommandText = ZDSqlHelper.FDCQXM;
            command.ExecuteNonQuery();
            command.CommandText = ZDSqlHelper.H;
            command.ExecuteNonQuery();
            command.CommandText = ZDSqlHelper.JSYDSYQ;
            command.ExecuteNonQuery();
            command.CommandText = ZDSqlHelper.TDSYQ;
            command.ExecuteNonQuery();
            command.CommandText = ZDSqlHelper.DJQ;
            command.ExecuteNonQuery();
            command.CommandText = "SELECT AddGeometryColumn('DJQ','geometry'," +txtSR.Tag.ToString()+
                                  ",'POLYGON','XY');";
            command.ExecuteNonQuery();
            command.CommandText = ZDSqlHelper.DJZQ;
            command.ExecuteNonQuery();
            command.CommandText = "SELECT AddGeometryColumn('DJZQ','geometry'," + txtSR.Tag.ToString() +
                                  ",'POLYGON','XY');";
            command.ExecuteNonQuery();
            command.CommandText = ZDSqlHelper.ZDJBXX;
            command.ExecuteNonQuery();
            command.CommandText = "SELECT AddGeometryColumn('ZDJBXX','geometry'," + txtSR.Tag.ToString() +
                                  ",'POLYGON','XY');";
            command.ExecuteNonQuery();
            command.CommandText = ZDSqlHelper.JZX;
            command.ExecuteNonQuery();
            command.CommandText = "SELECT AddGeometryColumn('jzx','geometry'," + txtSR.Tag.ToString() +
                                  ",'LINESTRING','XY');";
            command.ExecuteNonQuery();
            command.CommandText = ZDSqlHelper.JZD;
            command.ExecuteNonQuery();
            command.CommandText = "SELECT AddGeometryColumn('jzd','geometry'," + txtSR.Tag.ToString() +
                                  ",'MULTIPOINT','XY');";
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("数据库创建成功!", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult=DialogResult.OK;
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
