using System.IO;
using System.Windows.Forms;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Services;
using VastGIS.Common.Services.Serialization;
using VastGIS.Common.Shared;
using VastGIS.RealEstate.Api.Helpers;
using VastGIS.RealEstateDB.Forms;
using VastGIS.RealEstateDB.Menu;
using VastGIS.RealEstateDB.Properties;

namespace VastGIS.RealEstateDB.Commands.File
{
    public class CmdCreateNewMap : BaseCommand
    {
        private IAppContext _context;
        public CmdCreateNewMap(IAppContext context)
        {
            base._text = "新建项目";
            base._key = MenuKeys.NewProject;
            base._icon = Resources.icon_new_map;
            base._headerName = "tabFile";
            base._toolStripExName = "toolStripFiles";
            _context = context;
        }

        public override void OnClick()
        {
            
            //IProjectService projectService = _context.Container.GetSingleton<IProjectService>();
            //projectService.TryClose();
            frmCreateDB frm = new frmCreateDB();
            if (_context.View.ShowChildView(frm,true))
            {
                string projectFile = Path.Combine(frm.ProjectFile, frm.ProjectName, frm.ProjectName + ".vgproj");
                XmlProject project =
                    ReProjectHelper.CreateReProject(_context, frm.ProjectName, frm.ProjectFile, frm.EpsGCode);
                using (var writer = new StreamWriter(projectFile))
                {
                    writer.Write(project.Serialize());
                    writer.Flush();
                }
                //((ISecureContext) _context).VastProject = project;
                IProjectService projectService = _context.Container.GetSingleton<IProjectService>();
                projectService.Open(projectFile, false);
            }
        }
    }
}