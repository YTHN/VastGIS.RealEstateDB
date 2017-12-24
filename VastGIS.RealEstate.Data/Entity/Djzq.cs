using System.Data.Entity.Spatial;

namespace VastGIS.RealEstate.Data.Entity
{
    public  class Djzq:BackEntity, IFeature
    {
      
        public string Ysdm { get; set; }
        public string Djzqdm { get; set; }
        public string Djzqmc { get; set; }
        public string WxDcy { get; set; }
        public DbGeometry Geometry { get; set; }

    }
}