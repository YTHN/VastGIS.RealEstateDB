using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Enums;

namespace VastGIS.Common.Plugins.Services
{
    public interface IGeoDatabaseService
    {
        void ImportLayer();
        //DatabaseConnection PromptUserForConnection(GeoDatabaseType? databaseType = null);
    }
}
