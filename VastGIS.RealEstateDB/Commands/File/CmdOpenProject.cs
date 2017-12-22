using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Services;
using VastGIS.RealEstateDB.Menu;
using VastGIS.RealEstateDB.Properties;

namespace VastGIS.RealEstateDB.Commands.File
{
    public class CmdOpenProject : BaseCommand
    {
        private IAppContext _context;
        public CmdOpenProject(IAppContext context)
        {
            base._text = "打开项目";
            base._key = MenuKeys.OpenProject;
            base._icon = Resources.icon_folder;
            base._headerName = "tabFile";
            base._toolStripExName = "toolStripFiles";

            _context = context;
        }

        public override void OnClick()
        {
            IProjectService projectService = _context.Container.GetSingleton<IProjectService>();
            projectService.Open();
        }
    }
}