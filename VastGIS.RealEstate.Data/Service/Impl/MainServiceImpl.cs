using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.RealEstate.Data.Dao;
using VastGIS.RealEstate.Data.Entity;

namespace VastGIS.RealEstate.Data.Service.Impl
{
    public class MainServiceImpl:MainService
    {
        private MainDao mainDao;
        public MainServiceImpl(MainDao mainDao)
        {
            this.mainDao = mainDao;
        }

        public void Close()
        {
            mainDao.Close();
        }

        public int GetGeometryColumnSRID(string tableName, string columnName)
        {
            return mainDao.GetGeometryColumnSRID(tableName, columnName);
        }

        public void ClearCADTemps()
        {
            mainDao.ClearCADTemps();
        }
    }

    public class TmpCaddServiceImpl : TmpCaddService
    {
        private TmpCaddDao tmpCaddDao;

        public TmpCaddServiceImpl(TmpCaddDao tmpCaddDao)
        {
            this.tmpCaddDao = tmpCaddDao;
        }
        public void Create(TmpCadd cadd)
        {
            this.tmpCaddDao.Save(cadd);
        }

        public TmpCadd GetTmpCadd(int id)
        {
            return this.tmpCaddDao.Find(id);
        }

        public TmpCadd GetTmpCadd(string handle)
        {
            return this.tmpCaddDao.FindByHandle(handle);
        }

        public void Edit(TmpCadd cadd)
        {
            this.tmpCaddDao.Save(cadd);
        }

        public List<TmpCadd> FindCadd(string query)
        {
            return this.tmpCaddDao.Find(query);
        }
    }


    public class TmpCadxServiceImpl : TmpCadxService
    {
        private TmpCadxDao tmpCadxDao;

        public TmpCadxServiceImpl(TmpCadxDao tmpCadxDao)
        {
            this.tmpCadxDao = tmpCadxDao;
        }
        public void Create(TmpCadx cadx)
        {
            this.tmpCadxDao.Save(cadx);
        }

        public TmpCadx GetTmpCadx(int id)
        {
            return this.tmpCadxDao.Find(id);
        }

        public TmpCadx GetTmpCadx(string handle)
        {
            return this.tmpCadxDao.FindByHandle(handle);
        }

        public void Edit(TmpCadx cadx)
        {
            this.tmpCadxDao.Save(cadx);
        }

        public List<TmpCadx> FindCadx(string query)
        {
            return this.tmpCadxDao.Find(query);
        }
    }


    public class TmpCadmServiceImpl : TmpCadmService
    {
        private TmpCadmDao tmpCadmDao;

        public TmpCadmServiceImpl(TmpCadmDao tmpCadmDao)
        {
            this.tmpCadmDao = tmpCadmDao;
        }
        public void Create(TmpCadm cadm)
        {
            this.tmpCadmDao.Save(cadm);
        }

        public TmpCadm GetTmpCadm(int id)
        {
            return this.tmpCadmDao.Find(id);
        }

        public TmpCadm GetTmpCadm(string handle)
        {
            return this.tmpCadmDao.FindByHandle(handle);
        }

        public void Edit(TmpCadm cadm)
        {
            this.tmpCadmDao.Save(cadm);
        }

        public List<TmpCadm> FindCadm(string query)
        {
            return this.tmpCadmDao.Find(query);
        }
    }


    public class TmpCadzjServiceImpl : TmpCadzjService
    {
        private TmpCadzjDao tmpCadzjDao;

        public TmpCadzjServiceImpl(TmpCadzjDao tmpCadzjDao)
        {
            this.tmpCadzjDao = tmpCadzjDao;
        }
        public void Create(TmpCadzj cadzj)
        {
            this.tmpCadzjDao.Save(cadzj);
        }

        public TmpCadzj GetTmpCadzj(int id)
        {
            return this.tmpCadzjDao.Find(id);
        }

        public TmpCadzj GetTmpCadzj(string handle)
        {
            return this.tmpCadzjDao.FindByHandle(handle);
        }

        public void Edit(TmpCadzj cadzj)
        {
            this.tmpCadzjDao.Save(cadzj);
        }

        public List<TmpCadzj> FindCadzj(string query)
        {
            return this.tmpCadzjDao.Find(query);
        }
    }

    public class TmpCadxdataServiceImpl : TmpCadxdataService
    {
        private TmpCadxdataDao tmpCadxdataDao;

        public TmpCadxdataServiceImpl(TmpCadxdataDao tmpCadxdataDao)
        {
            this.tmpCadxdataDao = tmpCadxdataDao;
        }
        public void Create(TmpCadxdata cadxdata)
        {
            this.tmpCadxdataDao.Save(cadxdata);
        }

        public TmpCadxdata GetTmpCadxdata(int id)
        {
            return this.tmpCadxdataDao.Find(id);
        }

        public TmpCadxdata GetTmpCadxdata(string handle)
        {
            return this.tmpCadxdataDao.FindByHandle(handle);
        }

        public void Edit(TmpCadxdata cadxdata)
        {
            this.tmpCadxdataDao.Save(cadxdata);
        }

        public List<TmpCadxdata> FindCadxdata(string query)
        {
            return this.tmpCadxdataDao.Find(query);
        }
    }
}
