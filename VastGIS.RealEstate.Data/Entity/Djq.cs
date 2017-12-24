using System.Data.Entity.Spatial;

namespace VastGIS.RealEstate.Data.Entity
{
    public class Djq: BackEntity,IFeature
    {
        
       
        public string Ysdm { get; set; }
        public string Djqdm { get; set; }
        public string Djqmc { get; set; }
        public string WxDcy { get; set; }
        public DbGeometry Geometry { get; set; }

    }
}