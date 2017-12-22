using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VastGIS.RealEastate.Api.Interface
{
    public interface IREDatabase
    {
        List<IObjectClass> GetObjectClasses();
        List<IObjectClass> GetObjectClassesByParent(string parentName);

        

    }
}
