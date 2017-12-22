using VastGIS.Common.Api;
using VastGIS.Common.Api.Enums;
using VastGIS.Common.Plugins.Mvp;

namespace VastGIS.Common.Services.Views.Abstract
{
    public interface ICreateLayerView : IView<CreateLayerModel>
    {
        string LayerName { get; }
        GeometryType GeometryType { get; }
        ZValueType ZValueType { get; }
        bool MemoryLayer { get; }
    }
}
