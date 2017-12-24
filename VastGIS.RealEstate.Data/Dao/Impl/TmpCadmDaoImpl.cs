using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Spatial;
using System.Data.SQLite;
using System.Text;
using VastGIS.RealEstate.Data.Entity;

namespace VastGIS.RealEstate.Data.Dao.Impl
{
    public class TmpCadmDaoImpl : SQLiteDao, TmpCadmDao
    {
        private const string TmpCadmsTable = "TmpCadm";
        private const string bsmCol = "Bsm";
        private const string entitytypeCol = "EntityType";
        private const string handleCol = "Handle";
        private const string geometryCol = "Geometry";

        public void Save(TmpCadm cadd)
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
                valuesParameters.Append(",GeomFromText('" +cadd.Geometry.AsText() + "'," + _srid.ToString() + ")");
                string query = String.Format("Insert Into TmpCadm ({0}) Values ({1})", fieldParameters.ToString(),
                    valuesParameters.ToString());
                command.CommandText = query;
                ExecuteSql(command);
            }
            else
            {
                Update(cadd);
            }
        }

        private void Update(TmpCadm cadd)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            StringBuilder fieldParameters = new StringBuilder();

            fieldParameters.Append("Handle='" + cadd.Handle + "'");
            fieldParameters.Append(",EntityType='" + cadd.EntityType + "'");
            fieldParameters.Append(",FileName='" + cadd.FileName + "'");
            fieldParameters.Append(",Geometry=GeomFromText('" + cadd.Geometry.AsText() + "'," + _srid.ToString() + ")");
            string query = String.Format("Update TmpCadm Set {0} Where Bsm={1}", fieldParameters.ToString(),
                cadd.Bsm);
            command.CommandText = query;
            ExecuteSql(command);
        }

        public List<TmpCadm> Find(string query)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = String.Format("Select Bsm,Handle,EntityType,AsText(Geometry),FileName from TmpCadm where EntityType like '{0}'", query);
            DataTable dt = ExecuteSql(command);
            return ProcessResult(dt);
        }

        public TmpCadm Find(int id)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = String.Format("Select Bsm,Handle,EntityType,AsText(Geometry),FileName from TmpCadm where Bsm={0}", id);
            DataTable dt = ExecuteSql(command);
            return ProcessResult(dt)[0];
        }

        public TmpCadm FindByHandle(string handle)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = String.Format("Select Bsm,Handle,EntityType,AsText(Geometry),FileName from TmpCadm where Handle='{0}'", handle);
            DataTable dt = ExecuteSql(command);
            return ProcessResult(dt)[0];
        }

        private List<TmpCadm> ProcessResult(DataTable dt)
        {
            List<TmpCadm> cadds = new List<TmpCadm>();
            foreach (DataRow row in dt.Rows)
            {
                TmpCadm cadd = new TmpCadm();
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