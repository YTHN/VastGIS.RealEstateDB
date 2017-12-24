using System.Data.Entity.Spatial;

namespace VastGIS.RealEstate.Data.Entity
{
    public abstract class TmpCadEntity : IEntity, IFeature
    {
        public int Bsm { get; set; }
        public DbGeometry Geometry { get; set; }
        public string EntityType { get; set; }

        public string Handle { get; set; }

        public string FileName { get; set; }
    }
}