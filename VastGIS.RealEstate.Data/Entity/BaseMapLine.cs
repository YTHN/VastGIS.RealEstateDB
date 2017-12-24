using System.Data.Entity.Spatial;

namespace VastGIS.RealEstate.Data.Entity
{
    public abstract class BaseMapLine : IEntity, IFeature
    {
        public int Bsm { get; set; }
        public string Tc { get; set; }
        public string Cassdm { get; set; }
        public string Xx { get; set; }
        public double? Fhdx { get; set; }
        public string Fsxx1 { get; set; }
        public string Fsxx2 { get; set; }
        public string Ysdm { get; set; }
        public DbGeometry Geometry { get; set; }
    }
}