using System.Data.Entity.Spatial;

namespace VastGIS.RealEstate.Data.Entity
{
    public class TmpCadzj : TmpCadEntity
    {
        public TmpCadzj() { }
        public TmpCadzj(string handle, string geoStr, string entityType, string fileName)
        {
            Handle = handle;
            EntityType = entityType;
            Geometry = DbGeometry.FromText(geoStr);
            FileName = fileName;
        }
    }
}