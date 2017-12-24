using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.RealEstate.Data.Dao.Impl;
using VastGIS.RealEstate.Data.Entity;
using VastGIS.RealEstate.Data.Service.Impl;

namespace VastGIS.RealEstate.Data.Service
{
    public interface MainService
    {
        void Close();
        int GetGeometryColumnSRID(string tableName, string columnName);
        void ClearCADTemps();
    }

    public interface TmpCaddService
    {

        void Create(TmpCadd cadd);

        TmpCadd GetTmpCadd(int id);

        TmpCadd GetTmpCadd(string handle);

        void Edit(TmpCadd cadd);

        List<TmpCadd> FindCadd(string query);


    }

    public interface TmpCadxService
    {

        void Create(TmpCadx cadx);

        TmpCadx GetTmpCadx(int id);

        TmpCadx GetTmpCadx(string handle);

        void Edit(TmpCadx cadx);

        List<TmpCadx> FindCadx(string query);


    }

    public interface TmpCadmService
    {

        void Create(TmpCadm cadm);

        TmpCadm GetTmpCadm(int id);

        TmpCadm GetTmpCadm(string handle);

        void Edit(TmpCadm cadm);

        List<TmpCadm> FindCadm(string query);


    }

    public interface TmpCadzjService
    {

        void Create(TmpCadzj cadzj);

        TmpCadzj GetTmpCadzj(int id);

        TmpCadzj GetTmpCadzj(string handle);

        void Edit(TmpCadzj cadzj);

        List<TmpCadzj> FindCadzj(string query);


    }

    public interface TmpCadxdataService
    {

        void Create(TmpCadxdata cadxdata);

        TmpCadxdata GetTmpCadxdata(int id);

        TmpCadxdata GetTmpCadxdata(string handle);

        void Edit(TmpCadxdata cadxdata);

        List<TmpCadxdata> FindCadxdata(string query);


    }

    public class ServiceFactory
    {

        public static TmpCaddService GetTmpCaddService()
        {
            return new TmpCaddServiceImpl(new TmpCaddDaoImpl());
        }

        public static TmpCadxService GetTmpCadxService()
        {
            return new TmpCadxServiceImpl(new TmpCadxDaoImpl());
        }

        public static TmpCadmService GetTmpCadmService()
        {
            return new TmpCadmServiceImpl(new TmpCadmDaoImpl());
        }
        public static TmpCadzjService GetTmpCadzjService()
        {
            return new TmpCadzjServiceImpl(new TmpCadzjDaoImpl());
        }
        public static TmpCadxdataService GetTmpCadxdataService()
        {
            return new TmpCadxdataServiceImpl(new TmpCadxdataDaoImpl());
        }

        public static MainService GetMainService()
        {
            return new MainServiceImpl(new MainDaoImpl());
        }

    }
}
