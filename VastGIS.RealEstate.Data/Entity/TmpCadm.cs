using System.Data.Entity.Spatial;

namespace VastGIS.RealEstate.Data.Entity
{
    public class TmpCadm : TmpCadEntity
    {
        public TmpCadm() { }
        public TmpCadm(string handle, string geoStr, string entityType, string fileName)
        {
            Handle = handle;
            EntityType = entityType;
            Geometry = DbGeometry.FromText(geoStr);
            FileName = fileName;
        }
    }
}