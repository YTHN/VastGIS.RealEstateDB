using System;
using VastGIS.Common.Plugins.Concrete;

namespace VastGIS.Common.Plugins.Events
{
    public class ConnectionEventArgs: EventArgs
    {
        public ConnectionEventArgs(string dbName)
        {
            DatabaseName = dbName;
        }

        public string DatabaseName { get; private set; }
    }
}
