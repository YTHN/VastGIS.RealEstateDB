using System.Collections.Generic;
using VastGIS.RealEstate.Data.Entity;

namespace VastGIS.RealEstate.Data.Dao
{
    public interface TmpCadxDao
    {
        void Save(TmpCadx cadd);
        List<TmpCadx> Find(string query);
        TmpCadx Find(int id);
        TmpCadx FindByHandle(string handle);
    }
}