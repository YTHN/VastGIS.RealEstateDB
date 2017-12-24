using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Spatial;
using System.Data.SQLite;
using System.Text;
using VastGIS.RealEstate.Data.Entity;

namespace VastGIS.RealEstate.Data.Dao.Impl
{
    public class TmpCadxdataDaoImpl : SQLiteDao, TmpCadxdataDao
    {
        private const string TmpCadxdataTable = "TmpCadxdata";
       

        public void Save(TmpCadxdata cadxdata)
        {
            if (cadxdata.Bsm <= 0)
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                StringBuilder fieldParameters = new StringBuilder();
                StringBuilder valuesParameters = new StringBuilder();
                fieldParameters.Append("Handle");
                valuesParameters.Append("'" + cadxdata.Handle + "'");

                fieldParameters.Append(",Wbnr");
                valuesParameters.Append(",'" + cadxdata.Wbnr + "'");

                fieldParameters.Append(",Tc");
                valuesParameters.Append(",'" + cadxdata.Tc + "'");

                fieldParameters.Append(",Cassdm");
                valuesParameters.Append(",'" + cadxdata.Cassdm + "'");

                fieldParameters.Append(",Fh");
                valuesParameters.Append(",'" + cadxdata.Fh + "'");

                fieldParameters.Append(",Fsxx1");
                valuesParameters.Append(",'" + cadxdata.Fsxx1 + "'");

                fieldParameters.Append(",Fsxx2");
                valuesParameters.Append(",'" + cadxdata.Fsxx2 + "'");

                fieldParameters.Append(",Ysdm");
                valuesParameters.Append(",'" + cadxdata.Ysdm + "'");

                fieldParameters.Append(",Fhdx");
                valuesParameters.Append("," + cadxdata.Fhdx.ToString());

                fieldParameters.Append(",Xzjd");
                valuesParameters.Append("," + cadxdata.Xzjd.ToString());

                fieldParameters.Append(",FileName");
                valuesParameters.Append(",'" + cadxdata.FileName + "'");


                string query = String.Format("Insert Into TmpCadxdata ({0}) Values ({1})", fieldParameters.ToString(),
                    valuesParameters.ToString());
                command.CommandText = query;
                ExecuteSql(command);
            }
            else
            {
                Update(cadxdata);
            }
        }

        private void Update(TmpCadxdata cadxdata)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            StringBuilder fieldParameters = new StringBuilder();

            fieldParameters.Append("Handle='" + cadxdata.Handle + "'");
            fieldParameters.Append(",Wbnr='" + cadxdata.Wbnr + "'");
            fieldParameters.Append(",Tc='" + cadxdata.Tc + "'");
            fieldParameters.Append(",Cassdm='" + cadxdata.Cassdm + "'");
            fieldParameters.Append(",Fh='" + cadxdata.Fh + "'");
            fieldParameters.Append(",Fsxx1='" + cadxdata.Fsxx1 + "'");
            fieldParameters.Append(",Fsxx2='" + cadxdata.Fsxx2 + "'");
            fieldParameters.Append(",Ysdm='" + cadxdata.Ysdm + "'");
            fieldParameters.Append(",Fhdx=" + cadxdata.Fhdx.ToString());
            fieldParameters.Append(",Xzjd=" + cadxdata.Xzjd.ToString());
            fieldParameters.Append(",FileName='" + cadxdata.FileName + "'");

            string query = String.Format("Update TmpCadxdata Set {0} Where Bsm={1}", fieldParameters.ToString(),
                cadxdata.Bsm);
            command.CommandText = query;
            ExecuteSql(command);
        }

        public List<TmpCadxdata> Find(string query)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = String.Format("Select * from TmpCadxdata where EntityType like '{0}'", query);
            DataTable dt = ExecuteSql(command);
            return ProcessResult(dt);
        }

        public TmpCadxdata Find(int id)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = String.Format("Select  * from TmpCadxdata where Bsm={0}", id);
            DataTable dt = ExecuteSql(command);
            return ProcessResult(dt)[0];
        }

        public TmpCadxdata FindByHandle(string handle)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = String.Format("Select * from TmpCadxdata where Handle='{0}'", handle);
            DataTable dt = ExecuteSql(command);
            return ProcessResult(dt)[0];
        }

        private List<TmpCadxdata> ProcessResult(DataTable dt)
        {
            List<TmpCadxdata> cadds = new List<TmpCadxdata>();
            foreach (DataRow row in dt.Rows)
            {
                TmpCadxdata cadd = new TmpCadxdata();
                cadd.Bsm = int.Parse(row["Bsm"].ToString());
                cadd.Handle = (string)row["Handle"];
                cadd.Wbnr = (string)row["Wbnr"];
                cadd.Tc = (string)row["Tc"];
                cadd.Cassdm = (string)row["Cassdm"];
                cadd.Fh = (string)row["Fh"];
                cadd.Fsxx1 = (string)row["Fsxx1"];
                cadd.Fsxx2 = (string)row["Fsxx2"];
                cadd.Fsxx2 = (string)row["Fsxx2"];
                cadd.FileName = (string)row["FileName"];
                cadd.Fhdx = double.Parse(row["Fhdx"].ToString());
                cadd.Xzjd = double.Parse(row["Xzjd"].ToString());
            
                cadds.Add(cadd);
            }
            return cadds;
        }
    }
}