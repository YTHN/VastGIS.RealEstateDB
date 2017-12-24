namespace VastGIS.RealEstate.Data.Dao
{
    public interface MainDao
    {
        void Close();

        int GetGeometryColumnSRID(string tableName, string columnName);
        void ClearCADTemps();
    }

   
}