using System.Windows.Forms;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Services;
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
            base._text = "新建地图";
            base._key = MenuKeys.NewMap;
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

            }
        }
    }
}