using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VastGIS.RealEstate.Api.Enums
{
    public enum REClassType
    {
        Dataset=0,
        SpatialData=1,
        TableData=2
    }

    public enum REGeometryType
    {
        None = 0,
        Point = 1,
        Polyline = 2,
        Polygon = 3,
        MultiPoint = 4,
        MultiPolyline=5,
        MultiPolygon=6,
        GeometryCollection=7
    }

    public enum CADGeometryType
    {
        Point,
        Polyline,
        Polygon,
        Text
    }

}
