using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.RealEstate.Data.Entity;

namespace VastGIS.RealEstate.Data.Dao
{
    public interface TmpCadxdataDao
    {
        void Save(TmpCadxdata cadd);
        List<TmpCadxdata> Find(string query);
        TmpCadxdata Find(int id);
        TmpCadxdata FindByHandle(string handle);
    }
}
