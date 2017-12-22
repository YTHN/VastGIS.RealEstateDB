

using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Services;
using VastGIS.RealEstateDB.Menu;
using VastGIS.RealEstateDB.Properties;

namespace VastGIS.RealEstateDB.Commands.File
{
    public class CmdSaveProject : BaseCommand
    {
        private IAppContext _context;
        public CmdSaveProject(IAppContext context)
        {
            base._text = "保存项目";
            base._key = MenuKeys.SaveProject;
            base._icon = Resources.icon_save;
            base._headerName = "tabFile";
            base._toolStripExName = "toolStripFiles";
            _context = context;
        }

        public override void OnClick()
        {
            IProjectService projectService = _context.Container.GetSingleton<IProjectService>();
            if (projectService.Save())
            {
                MessageService.Current.Info("项目已经成功保存为: " + projectService.Filename);
            }
        }
    }
}