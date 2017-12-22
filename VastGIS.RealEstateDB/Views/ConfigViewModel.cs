using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VastGIS.Common.Plugins.Enums;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Services;

using VastGIS.RealEstateDB.Configuration;


namespace VastGIS.RealEstateDB.Views
{
    public class ConfigViewModel
    {
        private readonly IAppContext _context;
        private readonly IPluginManager _pluginManager;
        private readonly IConfigService _configeService;
        private readonly List<IConfigPage> _pages = new List<IConfigPage>();

        public ConfigViewModel(IAppContext context, IPluginManager pluginManager, IConfigService configeService)
        {
            _context = context;
            _pluginManager = pluginManager;
            _configeService = configeService;

            Initialize();
        }

        private void Initialize()
        {
            _pages.Clear();

            _pages.Add(new GeneralConfigPage(_configeService));

            _pages.Add(new DataFormatsConfigPage());

            _pages.Add(new PluginsConfigPage(_pluginManager, _context));

            foreach (var p in _pluginManager.ActivePlugins)
            {
                foreach (var page in p.ConfigPages)
                {
                    _pages.Add(page);
                }
            }
        }

        public void ReloadPage(ConfigPageType type)
        {
            var page = Pages.FirstOrDefault(p => p.PageType == type);
            if (page != null)
            {
                page.Initialize();
            }
        }

        public ConfigPageType SelectedPage { get; set; }

        public bool UseSelectedPage { get; set; }

        public IEnumerable<IConfigPage> Pages
        {
            get { return _pages; }
        }

        public IConfigPage GetPage(ConfigPageType pageType)
        {
            return _pages.FirstOrDefault(p => p.PageType == pageType);
        }
    }
}
