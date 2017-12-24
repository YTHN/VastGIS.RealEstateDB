using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Spatial;
using System.Data.SQLite;
using System.Text;
using VastGIS.RealEstate.Data.Entity;

namespace VastGIS.RealEstate.Data.Dao.Impl
{
    public class TmpCadzjDaoImpl : SQLiteDao, TmpCadzjDao
    {
        private const string TmpCadzjsTable = "TmpCadzj";
        private const string bsmCol = "Bsm";
        private const string entitytypeCol = "EntityType";
        private const string handleCol = "Handle";
        private const string geometryCol = "Geometry";

        public void Save(TmpCadzj cadd)
        {
            if (cadd.Bsm <= 0)
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                StringBuilder fieldParameters = new StringBuilder();
                StringBuilder valuesParameters = new StringBuilder();
                fieldParameters.Append("Handle");
                valuesParameters.Append("'" + cadd.Handle + "'");

                fieldParameters.Append(",EntityType");
                valuesParameters.Append(",'" + cadd.EntityType + "'");

                fieldParameters.Append(",FileName");
                valuesParameters.Append(",'" + cadd.FileName + "'");

                fieldParameters.Append(",Geometry");
                valuesParameters.Append(",GeomFromText('" + cadd.Geometry.AsText() + "'," + _srid.ToString() + ")");
                string query = String.Format("Insert Into TmpCadzj ({0}) Values ({1})", fieldParameters.ToString(),
                    valuesParameters.ToString());
                command.CommandText = query;
                ExecuteSql(command);
            }
            else
            {

            }
        }

        private void Update(TmpCadzj cadd)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            StringBuilder fieldParameters = new StringBuilder();

            fieldParameters.Append("Handle='" + cadd.Handle + "'");
            fieldParameters.Append(",EntityType='" + cadd.EntityType + "'");
            fieldParameters.Append(",FileName='" + cadd.FileName + "'");
            fieldParameters.Append(",Geometry=GeomFromText('" + cadd.Geometry.AsText() + "'," + _srid.ToString() + ")");
            string query = String.Format("Update TmpCadzj Set {0} Where Bsm={1}", fieldParameters.ToString(),
                cadd.Bsm);
            command.CommandText = query;
            ExecuteSql(command);
        }

        public List<TmpCadzj> Find(string query)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = String.Format("Select Bsm,Handle,EntityType,AsText(Geometry),FileName from TmpCadzj where EntityType like '{0}'", query);
            DataTable dt = ExecuteSql(command);
            return ProcessResult(dt);
        }

        public TmpCadzj Find(int id)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = String.Format("Select Bsm,Handle,EntityType,AsText(Geometry),FileName from TmpCadzj where Bsm={0}", id);
            DataTable dt = ExecuteSql(command);
            return ProcessResult(dt)[0];
        }

        public TmpCadzj FindByHandle(string handle)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = String.Format("Select Bsm,Handle,EntityType,AsText(Geometry),FileName from TmpCadzj where Handle='{0}'", handle);
            DataTable dt = ExecuteSql(command);
            return ProcessResult(dt)[0];
        }

        private List<TmpCadzj> ProcessResult(DataTable dt)
        {
            List<TmpCadzj> cadds = new List<TmpCadzj>();
            foreach (DataRow row in dt.Rows)
            {
                TmpCadzj cadd = new TmpCadzj();
                cadd.Bsm = int.Parse(row[bsmCol].ToString());
                cadd.Handle = (string)row[handleCol];
                cadd.EntityType = (string)row[entitytypeCol];
                cadd.Geometry = DbGeometry.FromText(row[3].ToString());
                cadd.FileName = (string)row[4];
                cadds.Add(cadd);
            }
            return cadds;
        }
    }
}