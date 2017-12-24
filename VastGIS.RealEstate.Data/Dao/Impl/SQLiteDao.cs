using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;

namespace VastGIS.RealEstate.Data.Dao.Impl
{
    public class SQLiteDao
    {
        protected SQLiteConnection connection;

        protected int _srid = -1;

        public SQLiteDao()
        {
            connection = DbConnection.GetConnection();
            GetSRID();
        }
        
        public DataTable ExecuteSql(SQLiteCommand command)
        {
            Trace.TraceInformation("Execute query {0}", command.CommandText);
            DataTable dt = new DataTable();
            SQLiteDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            return dt;
        }

        public int GetSRID()
        {
            if (_srid > 0) return _srid;
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText =
                    "Select srid from geometry_columns where f_table_name='tmpcadd' and f_geometry_column='geometry'";
                _srid = Convert.ToInt32(command.ExecuteScalar());
                return _srid;
            }
        }
    }
}