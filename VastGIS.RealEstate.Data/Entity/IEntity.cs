using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VastGIS.RealEstate.Data.Entity
{
    public interface IEntity
    {
        int Bsm { get; set; }
    }

    public interface IFeature
    {
        DbGeometry Geometry { get; set; }
    }
}
