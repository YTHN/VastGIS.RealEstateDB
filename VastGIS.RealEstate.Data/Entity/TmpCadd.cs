using System.Data.Entity.Spatial;

namespace VastGIS.RealEstate.Data.Entity
{
    public class TmpCadd : TmpCadEntity
    {
        public TmpCadd() { }
        public TmpCadd(string handle, string geoStr,string entityType,string fileName)
        {
            Handle = handle;
            EntityType = entityType;
            Geometry=DbGeometry.FromText(geoStr);
            FileName = fileName;
        }
    }
}