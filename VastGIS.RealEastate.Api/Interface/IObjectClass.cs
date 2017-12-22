using VastGIS.RealEastate.Api.Enums;

namespace VastGIS.RealEastate.Api.Interface
{
    public interface IObjectClass
    {
        string Name { get; set; }
        string Caption { get; set; }
        string IDFieldName { get; set; }
        REClassType ClassType { get; set; }
        string ParentName { get; set; }

        string DatabaseName { get; set; }
    }
}