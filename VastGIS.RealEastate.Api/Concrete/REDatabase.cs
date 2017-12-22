using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.RealEastate.Api.Interface;

namespace VastGIS.RealEastate.Api.Concrete
{
   
    public class ReDatabase:IREDatabase
    {
        public List<IObjectClass> GetObjectClasses()
        {
            throw new NotImplementedException();
        }

        public List<IObjectClass> GetObjectClassesByParent(string parentName)
        {
            throw new NotImplementedException();
        }
    }
}
