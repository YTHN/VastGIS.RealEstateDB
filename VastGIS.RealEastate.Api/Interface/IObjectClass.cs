using System.Collections.Generic;
using VastGIS.RealEstate.Api.Enums;

namespace VastGIS.RealEstate.Api.Interface
{
    public interface IObjectClass
    {
        string Name { get; set; }
        string Caption { get; set; }
        string IDFieldName { get; set; }
        REClassType ClassType { get; set; }
        string ParentName { get; set; }
        string GeometryFieldName { get; set; }
        REGeometryType GeometryType { get; set; }
        string DatabaseName { get; set; }
        List<IObjectClass> SubClasses { get; set; }
    }

    public interface ICodeDomain
    {
        string Name { get; set; }
        List<ICodeDomainValue> Values { get; set; }
        ICodeDomainValue DefaultValue { get; set; }
    }

    public interface ICodeDomainValue
    {
        string Description { get; set; }
        string Code { get; set; }
        bool IsDefault { get; set; }
    }
  
}