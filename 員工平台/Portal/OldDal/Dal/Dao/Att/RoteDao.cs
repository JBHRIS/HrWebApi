using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OldBll.Att.Vdb;

namespace OldDal.Dao.Att
{
    public class RoteDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;

        /// <summary>
        /// 假別代碼
        /// </summary>
        /// <param name="conn"></param>
        public RoteDao(IDbConnection conn = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (conn != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 假別代碼
        /// </summary>
        /// <param name="ConnectionString"></param>
        public RoteDao(string ConnectionString = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (ConnectionString != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(ConnectionString);
        }

        /// <summary>
        /// 取得班表資料
        /// </summary>
        /// <param name="lsRoteCode">null = 全部</param>
        /// <returns>RoteDetailRow</returns>
        public List<RoteDetailRow> GetRoteDetail(List<string> lsRoteCode = null)
        {
            var iqRote = from c in dcHr.ROTE
                         select c;

            if (lsRoteCode != null)
                iqRote = from c in dcHr.ROTE
                         where lsRoteCode.Contains(c.ROTE1)
                         select c;

            var Vdb = (from c in iqRote
                       select new RoteDetailRow()
                       {
                           RoteCode = c.ROTE1,
                           WorkHour = c.WK_HRS,
                           OnTime = c.ON_TIME,
                           OffTime = c.OFF_TIME,
                           OffLastTime = c.OFFTIME2,
                           OtBeginTime = c.OT_BEGIN,
                           AbsEndTime = c.ATT_END.Length > 0 ? c.ATT_END : c.OFF_TIME,
                           LatesMin = Convert.ToInt32(c.ALLLATES),
                           ElasticityMin = Convert.ToInt32(c.ALLLATES1),
                           MiddleTimeB = c.RES_B1_TIME,
                           MiddleTimeE = c.RES_E1_TIME,
                           DayRes = GetRoteRes(c.RES_B_TIME, c.RES_E_TIME
                           , "", ""
                           , c.RES_B2_TIME, c.RES_E2_TIME
                           , c.RES_B3_TIME, c.RES_E3_TIME
                           , c.RES_B4_TIME, c.RES_E4_TIME)
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 休息時間
        /// </summary>
        /// <param name="sResB1">休息時間</param>
        /// <param name="sResE1">休息時間</param>
        /// <param name="sResB2">休息時間</param>
        /// <param name="sResE2">休息時間</param>
        /// <param name="sResB3">休息時間</param>
        /// <param name="sResE3">休息時間</param>
        /// <param name="sResB4">休息時間</param>
        /// <param name="sResE4">休息時間</param>
        /// <param name="sResB5">休息時間</param>
        /// <param name="sResE5">休息時間</param>
        /// <returns>RoteResTable</returns>
        private List<RoteResRow> GetRoteRes(string sResB1, string sResE1, string sResB2, string sResE2, string sResB3, string sResE3, string sResB4, string sResE4, string sResB5, string sResE5)
        {
            List<RoteResRow> ls = new List<RoteResRow>();

            var r = new RoteResRow();

            if (sResB1.Trim().Length == 4 && sResE1.Trim().Length == 4)
            {
                r = new RoteResRow();
                r.ResTimeB = sResB1;
                r.ResTimeE = sResE1;
                ls.Add(r);
            }

            if (sResB2.Trim().Length == 4 && sResE2.Trim().Length == 4)
            {
                r = new RoteResRow();
                r.ResTimeB = sResB2;
                r.ResTimeE = sResE2;
                ls.Add(r);
            }

            if (sResB3.Trim().Length == 4 && sResE3.Trim().Length == 4)
            {
                r = new RoteResRow();
                r.ResTimeB = sResB3;
                r.ResTimeE = sResE3;
                ls.Add(r);
            }

            if (sResB4.Trim().Length == 4 && sResE4.Trim().Length == 4)
            {
                r = new RoteResRow();
                r.ResTimeB = sResB4;
                r.ResTimeE = sResE4;
                ls.Add(r);
            }

            if (sResB5.Trim().Length == 4 && sResE5.Trim().Length == 4)
            {
                r = new RoteResRow();
                r.ResTimeB = sResB5;
                r.ResTimeE = sResE5;
                ls.Add(r);
            }

            return ls;
        }
        /// <summary>
        /// 取得班別資料
        /// </summary>
        /// <returns>List RoteRow</returns>
        public List<RoteRow> GetRote()
        {
            var Vdb = (from c in dcHr.ROTE
                       select new RoteRow
                       {
                           RoteCode = c.ROTE1.Trim(),
                           RoteName = c.ROTENAME.Trim(),
                           Name = c.ROTENAME.Trim() + "(" + c.ROTE1.Trim() + ")",
                       }).ToList();

            return Vdb;
        }
        /// <summary>
        /// 取得班別資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">日期</param>
        /// <returns>List RoteRow</returns>
        public List<RoteRow> GetRoteByOt(string sNobr = "", DateTime? dDate = null)
        {
            var Vdb = (from c in dcHr.ROTE
                       where dcHr.GetCodeFilterByNobr("ROTE", c.ROTE1, sNobr, dDate.Value.Date).Value
                       && !(c.ON_TIME.Length == 0 && c.OFF_TIME.Length == 0 && c.WK_HRS == 0)
                       //&& c.SORT > 0
                       orderby c.ROTE1
                       select new RoteRow
                       {
                           RoteCode = c.ROTE1.Trim(),
                           RoteName = c.ROTENAME.Trim(),
                           Name = c.ROTENAME.Trim() + "(" + c.ROTE1.Trim() + ")",
                       }).ToList();

            return Vdb;
        }
        /// <summary>
        /// 取得班別資料
        /// </summary>
        /// <returns>List RoteRow</returns>
        public List<RoteRow> GetRoteByOt()
        {
            var Vdb = (from c in dcHr.ROTE
                       where !(c.ON_TIME.Length == 0 && c.OFF_TIME.Length == 0 && c.WK_HRS == 0)
                       orderby c.ROTE1
                       select new RoteRow
                       {
                           RoteCode = c.ROTE1.Trim(),
                           RoteName = c.ROTENAME.Trim(),
                           Name = c.ROTENAME.Trim() + "(" + c.ROTE1.Trim() + ")",
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得班別資料
        /// </summary>
        /// <returns>List RoteRow</returns>
        public List<RoteRow> GetRote(string RoteCode)
        {
            var Vdb = (from c in dcHr.ROTE
                       where c.ROTE1 == RoteCode
                       select new RoteRow
                       {
                           RoteCode = c.ROTE1.Trim(),
                           RoteName = c.ROTENAME.Trim(),
                           Name = c.ROTENAME.Trim() + "(" + c.ROTE_DISP.Trim() + ")",
                       }).ToList();

            return Vdb;
        }
        /// <summary>
        /// 判斷班別是否為夜班
        /// </summary>
        /// <param name="RoteCode">班別</param>
        /// <returns></returns>
        public bool RoteIsNightShift(string RoteCode)
        {
            bool IsNightShift = false;
            List<string> RoteTime = new List<string>();

            var RoteDetail = GetRoteDetail();
            var RoteDetailSelect = RoteDetail.Where(p => p.RoteCode == RoteCode).FirstOrDefault();

            if(RoteDetailSelect!=null)
            {
                RoteTime.Add(RoteDetailSelect.OffTime);
                RoteTime.Add(RoteDetailSelect.MiddleTimeE);
                RoteTime.AddRange(RoteDetailSelect.DayRes.Select(p => p.ResTimeE));

                foreach (var c in RoteTime)
                {
                    if (c.CompareTo("2400") >= 0)
                    {
                        IsNightShift = true;
                        break;
                    }
                }
            }

            return IsNightShift;
        }
    }
}
