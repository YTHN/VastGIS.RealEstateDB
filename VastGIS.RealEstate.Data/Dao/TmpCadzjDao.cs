using System.Collections.Generic;
using VastGIS.RealEstate.Data.Entity;

namespace VastGIS.RealEstate.Data.Dao
{
    public interface TmpCadzjDao
    {
        void Save(TmpCadzj cadd);
        List<TmpCadzj> Find(string query);
        TmpCadzj Find(int id);
        TmpCadzj FindByHandle(string handle);
    }
}