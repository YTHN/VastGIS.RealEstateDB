using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.RealEstateDB.Properties;

namespace VastGIS.RealEstateDB.Commands.File
{
    public class CmdQuit : BaseCommand
    {
        private IAppContext _context;
        public CmdQuit(IAppContext context)
        {
            base._text = "退出系统";
            base._key = Common.Plugins.Menu.MenuKeys.Quit;
            base._icon = Resources.icon_quit;
            base._headerName = "tabFile";
            base._toolStripExName = "toolStripFiles";
            _context = context;
        }

        public override void OnClick()
        {
            var appContext = _context as AppContext;
            if (appContext != null)
            {
                appContext.Close();
            }
        }
    }
}