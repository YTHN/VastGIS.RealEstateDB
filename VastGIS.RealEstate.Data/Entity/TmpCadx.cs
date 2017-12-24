using System.Data.Entity.Spatial;

namespace VastGIS.RealEstate.Data.Entity
{
    public class TmpCadx : TmpCadEntity
    {
        public TmpCadx() { }
        public TmpCadx(string handle, string geoStr, string entityType, string fileName)
        {
            Handle = handle;
            EntityType = entityType;
            Geometry = DbGeometry.FromText(geoStr);
            FileName = fileName;
        }
    }
}