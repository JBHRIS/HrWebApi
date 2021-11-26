using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OldBll.Bas.Vdb;

namespace OldDal.Dao.Bas
{
    public class IpControlDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;

        /// <summary>
        /// 員工基本資料
        /// </summary>
        /// <param name="conn">連接字串 沒有等於預設</param>
        public IpControlDao(IDbConnection conn = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (conn != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 員工基本資料
        /// </summary>
        /// <param name="ConnectionString"></param>
        public IpControlDao(string ConnectionString = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (ConnectionString != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(ConnectionString);
        }

        public List<IpControlRow> GetData(string sIpAdd = "")
        {
            var Vdb1 = new List<IpControlRow>();

            var r = new IpControlRow();
            r.IpAdd = "192.168.*.*";
            Vdb1.Add(r);

            foreach (var rVdb in Vdb1)
            {
                var arrIp = rVdb.IpAdd.Split('.');

                if (arrIp.Length >= 1)
                    rVdb.Ip1 = arrIp[0];
                else
                    rVdb.Ip1 = "";

                if (arrIp.Length >= 2)
                    rVdb.Ip2 = arrIp[1];
                else
                    rVdb.Ip2 = "";

                if (arrIp.Length >= 3)
                    rVdb.Ip3 = arrIp[2];
                else
                    rVdb.Ip3 = "";

                if (arrIp.Length >= 4)
                    rVdb.Ip4 = arrIp[3];
                else
                    rVdb.Ip4 = "";
            }

            var arrIpAdd = sIpAdd.Split('.');
            string Ip1 = "";
            string Ip2 = "";
            string Ip3 = "";
            string Ip4 = "";

            if (arrIpAdd.Length >= 1)
                Ip1 = arrIpAdd[0];

            if (arrIpAdd.Length >= 2)
                Ip2 = arrIpAdd[1];

            if (arrIpAdd.Length >= 3)
                Ip3 = arrIpAdd[2];

            if (arrIpAdd.Length >= 4)
                Ip4 = arrIpAdd[3];

            var Vdb = (from c in Vdb1
                       where ((c.Ip1 == "*" || c.Ip1 == Ip1)
                       && (c.Ip2 == "*" || c.Ip2 == Ip2)
                       && (c.Ip3 == "*" || c.Ip3 == Ip3)
                       && (c.Ip4 == "*" || c.Ip4 == Ip4)
                       || sIpAdd == "::1")
                       select c).ToList();

            return Vdb;
        }
    }
}