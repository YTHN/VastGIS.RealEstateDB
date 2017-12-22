using System;
using VastGIS.Common.Plugins.Mvp;


namespace VastGIS.RealEstateDB.Views.Abstract
{
    public interface IConfigView: IView<ConfigViewModel>, IMenuProvider
    {
        event Action PageShown;
    }
}
