using System.Collections.Generic;
using VastGIS.RealEstate.Data.Entity;

namespace VastGIS.RealEstate.Data.Dao
{
    public interface TmpCaddDao
    {
        void Save(TmpCadd cadd);
        List<TmpCadd> Find(string query);
        TmpCadd Find(int id);
        TmpCadd FindByHandle(string handle);
    }
}