using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VastGIS.RealEstate.Data.Dao.Impl
{
    public class DbConnection
    {
        private static SQLiteConnection connection = null;
        private static string _databaseName="";
        private DbConnection()
        {
            string connectionString = string.Format("Data Source={0}", _databaseName);
            Trace.TraceInformation("Connect to database using source '{0}'", _databaseName);
            connection = new SQLiteConnection(connectionString);
            connection.Open();
            SpatialiteSharp.SpatialiteLoader.Load(connection);
        }

        public static void SetDatabaseName(string dbName)
        {
            _databaseName = dbName;
            connection = null;
        }

        public static bool HasDatabaseName()
        {
            return string.IsNullOrEmpty(_databaseName);
        }
        
        public static SQLiteConnection GetConnection()
        {
            if (connection == null)
            {
                new DbConnection();
            }
           
            
            return connection;
        }
    }
}
