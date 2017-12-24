using System.Collections.Generic;
using VastGIS.RealEstate.Data.Entity;

namespace VastGIS.RealEstate.Data.Dao
{
    public interface TmpCadmDao
    {
        void Save(TmpCadm cadd);
        List<TmpCadm> Find(string query);
        TmpCadm Find(int id);
        TmpCadm FindByHandle(string handle);
    }
}