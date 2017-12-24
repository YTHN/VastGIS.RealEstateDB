using System;
using System.Data.SQLite;

namespace VastGIS.RealEstate.Data.Dao.Impl
{
    public class MainDaoImpl : MainDao
    {
        public void Close()
        {
            DbConnection.GetConnection().Close();
        }

        public int GetGeometryColumnSRID(string tableName, string columnName)
        {
            using (SQLiteCommand command = new SQLiteCommand(DbConnection.GetConnection()))
            {
                command.CommandText =
                    string.Format(
                        "Select srid from geometry_columns where f_table_name='{0}' and f_geometry_column='{1}'",
                        tableName.ToLower().Trim(), columnName.ToLower().Trim());
                int srid=Convert.ToInt32(command.ExecuteScalar());
                return srid;
            }
        }

        public void ClearCADTemps()
        {
            using (SQLiteCommand command = new SQLiteCommand(DbConnection.GetConnection()))
            {
                command.CommandText = "delete from tmpcadd";
                command.ExecuteNonQuery();
                command.CommandText = "delete from tmpcadx";
                command.ExecuteNonQuery();
                command.CommandText = "delete from tmpcadm";
                command.ExecuteNonQuery();
                command.CommandText = "delete from tmpcadzj";
                command.ExecuteNonQuery();
                command.CommandText = "delete from tmpcadxdata";
                command.ExecuteNonQuery();

            }
        }
    }
}