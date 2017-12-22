using VastGIS.Common.Plugins.Interfaces;

namespace VastGIS.Common.Plugins.Concrete
{
    internal class MenuItemCollectionMetadata
    {
        public IMenuItem InsertBefore { get; set; }
        public bool AlignRight { get; set; }
    }
}
