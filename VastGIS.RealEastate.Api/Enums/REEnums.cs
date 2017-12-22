using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VastGIS.RealEastate.Api.Enums
{
    public enum REClassType
    {
        SpatialData,
        TableData
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
}
