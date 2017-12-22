using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.RealEstateDB.Menu;
using VastGIS.RealEstateDB.Properties;
using VastGIS.RealEstateDB.Views;

namespace VastGIS.RealEstateDB.Commands.File
{
    public class CmdSettings : BaseCommand
    {
        private IAppContext _context;
        public CmdSettings(IAppContext context)
        {
            base._text = "设置";
            base._key = MenuKeys.Settings;
            base._icon = Resources.icon_settings;
            base._headerName = "tabFile";
            base._toolStripExName = "toolStripFiles";
            _context = context;
        }

        public override void OnClick()
        {
            var model = _context.Container.GetInstance<ConfigViewModel>();
            _context.Container.Run<ConfigPresenter, ConfigViewModel>(model);
        }
    }
}