using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Services.Serialization;
using VastGIS.Common.Services.Views;
using VastGIS.RealEstate.Api.Concrete;
using VastGIS.RealEstate.Api.Interface;

namespace VastGIS.RealEstate.Api.Helpers
{
    public class ReProjectHelper
    {
        public static XmlProject CreateReProject(IAppContext context,string name, string parentPath, int epsgCode)
        {
            ProjectLoadingView _loadingForm;
            _loadingForm=new ProjectLoadingView(name);
            context.View.ShowChildView(_loadingForm, false);
            Application.DoEvents();
            context.View.Lock();
            _loadingForm.ShowProgress(10, "创建项目目录");
            DirectoryInfo info =new DirectoryInfo(parentPath+"\\"+name);
            if (info.Exists == false)
            {
                info.Create();
            }
            info.CreateSubdirectory("Database");
            info.CreateSubdirectory("Attachments");
            _loadingForm.ShowProgress(30, "创建项目数据库");
            IREDatabase reDatabase=new ReDatabase(Path.Combine(info.FullName, "Database\\redatabase.db"));
            string errMsg = "";
            _loadingForm.ShowProgress(50, "初始化项目数据库，数据较多，请耐心等待");
            reDatabase.InitREDatabase(epsgCode, _loadingForm,out errMsg);
            string projectFile = Path.Combine(info.FullName, name + ".vgproj");
            XmlProject project=new XmlProject(context as ISecureContext, projectFile);
            project.ProjectName = name;
            project.Database = "Database\\redatabase.db";
            project.AttachmentPath = "Attachments";
            _loadingForm.Close();
            _loadingForm.Dispose();
            context.View.Unlock();
            _loadingForm = null;
            return project;
        }
    }
}
