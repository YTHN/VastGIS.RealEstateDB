using VastGIS.RealEastate.Api.Enums;

namespace VastGIS.RealEastate.Api.Interface
{
    public interface IFeatureClass : IObjectClass
    {
        string GeometryFieldName { get; set; }
        REGeometryType GeometryType { get; set; }
    }
}