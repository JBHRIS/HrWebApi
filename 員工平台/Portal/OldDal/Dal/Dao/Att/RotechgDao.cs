using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OldBll.Att.Vdb;
using OldBll.Tools;
using JBModule.Data.Linq;
using System.Data;

namespace OldDal.Dao.Att
{
    public class RotechgDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;

        /// <summary>
        /// 資料
        /// </summary>
        /// <param name="conn"></param>
        public RotechgDao(IDbConnection conn = null)
        {
                dcHr = new HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 資料
        /// </summary>
        /// <param name="ConnectionString"></param>
        public RotechgDao(string ConnectionString = null)
        {
                dcHr = new HrDBDataContext(ConnectionString);
        }

        /// <summary>
        /// 資料
        /// </summary>
        public RotechgDao()
        {
            dcHr = new HrDBDataContext();
        }

        /// <summary>
        /// 取得換班資料(區間)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <returns>List CardRow</returns>
        public List<RotechgRow> GetData(string sNobr, DateTime dDateB, DateTime dDateE)
        {
            var Vdb = (from c in dcHr.ROTECHG
                       join b in dcHr.BASE on c.NOBR equals b.NOBR
                       where c.NOBR.Trim() == sNobr
                       && dDateB.Date <= c.ADATE.Date
                       && c.ADATE.Date <= dDateE.Date
                       select new RotechgRow
                       {
                           Nobr = c.NOBR.Trim(),
                           Name = b.NAME_C,
                           DateA = c.ADATE.Date,
                           RoteCode = c.ROTE,
                           Code = c.CODE,
                           Serno = "",
                           KeyMan = c.KEY_MAN.Trim(),
                           keyDate = c.KEY_DATE,
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 存入換班資料
        /// </summary>
        /// <param name="rs"></param>
        /// <param name="bReplace">重複蓋過去</param>
        /// <returns>bool</returns>
        public bool Save(RotechgRow rs, bool bReplace = true)
        {
            bool Vdb = false;

            var rt = (from c in dcHr.ROTECHG
                      where c.NOBR.Trim() == rs.Nobr
                      && c.ADATE.Date == rs.DateA
                      select c).FirstOrDefault();

            if (rt == null)
            {
                rt = new ROTECHG();
                rt.NOBR = rs.Nobr;
                rt.ADATE = rs.DateA;
                dcHr.ROTECHG.InsertOnSubmit(rt);

                bReplace = true;
            }

            if (bReplace)
            {
                rt.ROTE = rs.RoteCode;
                rt.CODE = rs.Code;
                rt.KEY_DATE = DateTime.Now;
                rt.KEY_MAN = rs.KeyMan;

                dcHr.SubmitChanges();

                Vdb = true;
            }

            return Vdb;
        }

        /// <summary>
        /// 存入換班資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">日期</param>
        /// <param name="sRoteCode">班別</param>
        /// <param name="sCode">備註</param>
        /// <param name="sKeyMan">登錄者</param>
        /// <param name="sSerno">序號</param>
        /// <returns>bool</returns>
        public bool Save(string sNobr, DateTime dDate, string sRoteCode, string sCode = "", string sKeyMan = "System", string sSerno = "")
        {
            bool Vdb = false;

            List<string> arrHoidDay = new List<string> { "00", "0Y", "0X", "0Z" };

            var rROTECHG = (from c in dcHr.ROTECHG
                            where c.NOBR.Trim() == sNobr
                            && c.ADATE.Date == dDate
                            select c).FirstOrDefault();

            if (rROTECHG == null)
            {
                rROTECHG = new ROTECHG();
                OldBll.Tools.DefaultData.SetRowDefaultValue(rROTECHG);
                rROTECHG.NOBR = sNobr;
                rROTECHG.ADATE = dDate;
                rROTECHG.ROTE = sRoteCode;
                rROTECHG.CODE = sCode;
                rROTECHG.KEY_DATE = DateTime.Now;
                rROTECHG.KEY_MAN = sKeyMan;
                dcHr.ROTECHG.InsertOnSubmit(rROTECHG);

                Vdb = true;
            }
            else
            {
                rROTECHG.ROTE = sRoteCode;
                rROTECHG.CODE = sCode;
                rROTECHG.KEY_DATE = DateTime.Now;
                rROTECHG.KEY_MAN = sKeyMan;

                Vdb = true;
            }
            var rATTEND = (from c in dcHr.ATTEND
                           where c.NOBR == sNobr
                           && c.ADATE == dDate
                           select c).FirstOrDefault();

            if (rATTEND != null)
            {
                rATTEND.ROTE = sRoteCode;
                rATTEND.KEY_MAN = sKeyMan;
                rATTEND.KEY_DATE = DateTime.Now;

                if (!arrHoidDay.Contains(sRoteCode))
                    rATTEND.ROTE_H = sRoteCode;

            }
            if (Vdb)
                dcHr.SubmitChanges();

            return Vdb;
        }

        /// <summary>
        /// 檢查換班資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">日期</param>
        /// <param name="sRoteCode">班別</param>
        /// <param name="sCode"></param>
        /// <returns>string</returns>
        public string RotechgCheck(string sNobr, DateTime dDate, string sRoteCode, string sCode = "")
        {
            if (sNobr.Trim().Length == 0)
                return "工號不得空白";

            OldDal.Dao.Bas.BasDao oBasDao = new Bas.BasDao(dcHr.Connection);
            var rBase = oBasDao.GetBaseByNobr(sNobr, dDate).FirstOrDefault();
            if (rBase == null)
                return "工號並不存在";

            var rRotechg = GetData(sNobr, dDate.Date, dDate.Date).FirstOrDefault();
            if (rRotechg != null &&  rRotechg.RoteCode == sRoteCode)
                return "人事資料重複";

            OldDal.Dao.Att.AttendDao oAttendDao = new AttendDao(dcHr.Connection);
            var rAttend = oAttendDao.GetAttend(sNobr, dDate.Date).FirstOrDefault();
            if (rAttend == null)
                return "無出勤資料";

            if (rAttend.RoteCode == sRoteCode)
                return "此天班別與換班班別相同";


            return "";
        }
    }
}