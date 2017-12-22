using System.Drawing;
using VastGIS.Common.Plugins.Enums;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.UI.Controls;
using VastGIS.RealEstateDB.Properties;

namespace VastGIS.RealEstateDB.Configuration
{
    public partial class DataFormatsConfigPage : ConfigPageBase, IConfigPage
    {
        public DataFormatsConfigPage()
        {
            InitializeComponent();
        }

        public string Description
        {
            get { return "General settings for various data formats"; }
        }

        public Bitmap Icon
        {
            get { return Resources.img_layers32; }
        }

        public string PageName
        {
            get { return "Data"; }
        }

        public ConfigPageType PageType
        {
            get { return ConfigPageType.DataFormats; }
        }

        /// <summary>
        /// Gets a value indicating whether the page height can be adjusted to fit the the parent.
        /// </summary>
        public bool VariableHeight 
        {
            get { return true; } 
        }

        public void Initialize()
        {
            
        }

        public void Save()
        {

        }
    }
}
