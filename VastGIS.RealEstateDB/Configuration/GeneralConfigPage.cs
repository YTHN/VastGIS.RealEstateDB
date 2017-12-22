using System;
using System.Drawing;
using VastGIS.Common.Plugins.Enums;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Services;
using VastGIS.Common.UI.Controls;
using VastGIS.Common.UI.Helpers;
using VastGIS.RealEstateDB.Properties;

namespace VastGIS.RealEstateDB.Configuration
{
    public partial class GeneralConfigPage : ConfigPageBase, IConfigPage
    {
        private readonly IConfigService _configService;

        public GeneralConfigPage(IConfigService configService)
        {
            if (configService == null) throw new ArgumentNullException("configService");
            _configService = configService;

            InitializeComponent();

            InitControls();

            Initialize();
        }

        private void InitControls()
        {
            cboSymbologyStorage.AddItemsFromEnum<SymbologyStorage>();
        }

        public void Initialize()
        {
            var config = _configService.Config;
            chkLoadLastProject.Checked = config.LoadLastProject;
            chkShowPluginInToolTip.Checked = config.ShowPluginInToolTip;
            chkShowMenuToolTips.Checked = config.ShowMenuToolTips;
            chkLocalDocumentation.Checked = config.LocalDocumentation;
            chkNewVersion.Checked = config.UpdaterCheckNewVersion;
          
        }

        public string PageName
        {
            get { return "General"; }
        }

        public void Save()
        {
            var config = _configService.Config;
            config.LoadLastProject = chkLoadLastProject.Checked;
     
            config.ShowPluginInToolTip = chkShowPluginInToolTip.Checked;
            config.ShowMenuToolTips = chkShowMenuToolTips.Checked;
        
            config.LocalDocumentation = chkLocalDocumentation.Checked;
            config.UpdaterCheckNewVersion = chkNewVersion.Checked;
          
        }

        public Bitmap Icon
        {
            get { return Resources.img_component32; }
        }

        public ConfigPageType PageType
        {
            get { return ConfigPageType.General; }
        }

        public string Description
        {
            get { return "Here is a description of general settings."; }
        }

        public bool VariableHeight
        {
            get { return false; }
        }
    }
}
