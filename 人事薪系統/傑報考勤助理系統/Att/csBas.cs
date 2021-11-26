using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data;

namespace JBHR.Att
{
    public class csBaseData
    {
        //最大部門
        public static string DeptMaxCode
        {
            get
            {
                dcBasDataContext dc = new dcBasDataContext();
                IQueryable<DEPT> sql = dc.DEPT;
                string v = sql.Max(d => d.D_NO.Trim());

                return v == null ? "" : v;
            }
        }

        //最小部門
        public static string DeptMinCode
        {
            get
            {
                dcBasDataContext dc = new dcBasDataContext();
                IQueryable<DEPT> sql = dc.DEPT;
                string v = sql.Min(d => d.D_NO.Trim());

                return v == null ? "" : v;
            }
        }

        //最大工號
        public static string NobrMaxCode
        {
            get
            {
                dcBasDataContext dc = new dcBasDataContext();
                IQueryable<BASE> sql = dc.BASE;
                string v = sql.Max(d => d.NOBR.Trim());

                return v == null ? "" : v;
            }
        }

        //最小工號
        public static string NobrMinCode
        {
            get
            {
                dcBasDataContext dc = new dcBasDataContext();
                IQueryable<BASE> sql = dc.BASE;
                string v = sql.Min(d => d.NOBR.Trim());

                return v == null ? "" : v;
            }
        }

        public static string GetDeptCode(string MethodName)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<DEPT> sql = dc.DEPT;
            var a = dc.DEPT.ToList();
            var itm = from c in dc.DEPT select c;
            ParameterExpression param = Expression.Parameter(typeof(DEPT), "c");
            Expression selector = Expression.Property(param, typeof(DEPT).GetProperty("D_NO"));
            Expression pred = Expression.Lambda(selector, param);
            Expression expr = Expression.Call(typeof(Queryable), "Select", new Type[] { typeof(DEPT), typeof(string) }, Expression.Constant(sql), pred);
            //Expression expr = Expression.Call(typeof(Queryable), "Max", new Type[] { typeof(DEPT), typeof(string) }, Expression.Constant(sql), pred);
            //Expression expr = Expression.Call(param,"Max" ,typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) }), Expression.Constant(sql));
            IQueryable<string> query = dc.DEPT.AsQueryable().Provider.CreateQuery<string>(expr);
            System.Data.Common.DbCommand cmd = dc.GetCommand(query);
            string v = sql.Min(d => d.D_NO.Trim());

            return v == null ? "" : v;


            ////依据IQueryable数据源构造一个查询
            //IQueryable<Customer> custs = db.Customers;
            ////组建一个表达式树来创建一个参数
            //ParameterExpression param =     Expression.Parameter(typeof(Customer), "c");
            ////组建表达式树:c.ContactName
            //Expression selector = Expression.Property(param,    typeof(Customer).GetProperty("ContactName"));
            //Expression pred = Expression.Lambda(selector, param);
            ////组建表达式树:Select(c=>c.ContactName)
            //Expression expr = Expression.Call(typeof(Queryable), "Select",    new Type[] { typeof(Customer), typeof(string) },    Expression.Constant(custs), pred);
            ////使用表达式树来生成动态查询
            //IQueryable<string> query = db.Customers.AsQueryable()    .Provider.CreateQuery<string>(expr);
            ////使用GetCommand方法获取SQL语句
            //System.Data.Common.DbCommand cmd = db.GetCommand(query);
        }

    }

    /// <summary>
    /// 加班相關計算
    /// </summary>
    public static class OtCal
    {
        //判斷時間輸入是否正確
        public static bool CheckTimeFormat(string Time)
        {
            if (Time.Length != 4)
                return false;
            int i = 0;
            if (!Int32.TryParse(Time, out i))
                return false;
            int HH, mm;
            HH = Convert.ToInt32(Time.Substring(0, 2));
            mm = Convert.ToInt32(Time.Substring(2, 2));
            if (HH > 48) return false;
            if (mm >= 60) return false;
            if (Time.Substring(2, 2) != "30" && Time.Substring(2, 2) != "15" && Time.Substring(2, 2) != "45" && Time.Substring(2, 2) != "00") return false;
            if (i > 4800) return false;
            return true;
        }

        /// <summary>
        /// 取得班別
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">出勤日期</param>
        /// <param name="sRote">目前班別</param>
        /// <param name="bDayAdd">加日期或減日期 True = 加日期(向前或向後尋找之意)</param>
        /// <returns>string</returns>
        private static string GetRote(string sNobr, DateTime dDate, string sRote, bool bDayAdd)
        {
            if (sRote != "00") return sRote;

            /*
            JBHR.Dll.dsAtt.JB_HR_RoteDataTable dtRote;
            JBHR.Dll.dsAtt.JB_HR_RoteRow r;

            do
            {
                dDate = dDate.AddDays((bDayAdd) ? 1 : -1);
                dtRote = JBHR.Dll.Att.Rote(sNobr, dDate);
                if (dtRote.Count == 0) return sRote;
                r = dtRote.Rows[0] as JBHR.Dll.dsAtt.JB_HR_RoteRow;
                sRote = r.sRoteCode.Trim();
            } while (sRote == "00");
            */
            JBModule.Data.Linq.ROTE ref_rote = Dal.Dao.Att.TransCardDao.TransCardPools.GetRoteCode(sNobr, dDate);
            if (ref_rote == null)
            {
                return null;
            }

            return ref_rote.ROTE1;
        }

        /// <summary>
        /// 計算加班時間(24小時制)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="sRote">班別(預設代0,特殊日期如天災請帶00)</param>
        /// <param name="dDateB">申請開始日期</param>
        /// <param name="dDateE">申請結束日期</param>
        /// <param name="sTimeB">申請開始時間</param>
        /// <param name="sTimeE">申請結束時間</param>
        /// <returns>OtDetail</returns>
        public static JBHR.Dll.Att.OtCal.OtDetail CalculationOtBy24(string sNobr, string sRote, DateTime dDateB, DateTime dDateE, string sTimeB, string sTimeE)
        {
            sTimeB = sTimeB.PadLeft(4, char.Parse("0"));
            sTimeE = sTimeE.PadLeft(4, char.Parse("0"));

            DateTime dDateTimeB, dDateTimeE;

            dDateTimeB = dDateB.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(sTimeB));
            dDateTimeE = dDateE.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(sTimeE));

            List<JBHR.Dll.AttendRote> lsAttendRote = new List<JBHR.Dll.AttendRote>();
            lsAttendRote.Add(JBHR.Dll.Att.rowAttendRote(sNobr, dDateB.AddDays(-1)));
            lsAttendRote.Add(JBHR.Dll.Att.rowAttendRote(sNobr, dDateB));
            //lsAttendRote.Add(rowAttendRote(sNobr, dDateB.AddDays(1)));

            JBHR.Dll.AttendRote rAttendRote = lsAttendRote.Where(p => p.dDateTimeB <= dDateTimeB && p.dDateTimeE >= dDateTimeE).FirstOrDefault();

            if (rAttendRote != null && rAttendRote.dDate.Date < dDateB.Date)
            {
                dDateB = dDateB.AddDays(-1).Date;
                sTimeB = (Convert.ToInt32(sTimeB) + 2400).ToString("0000");
                sTimeE = (Convert.ToInt32(sTimeE) + 2400).ToString("0000");
            }
            else if (dDateB.Date < dDateE.Date)
                sTimeE = (Convert.ToInt32(sTimeE) + 2400).ToString("0000");

            JBHR.Dll.Att.OtCal.OtDetail oOtDetail = CalculationOt(sNobr, sRote, dDateB, sTimeB, sTimeE, false);
            return oOtDetail;
        }
        /// <summary>
        /// 計算加班時間
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="sRote">班別(預設代0,特殊日期如天災請帶00)</param>
        /// <param name="dDate">申請日期</param>
        /// <param name="sTimeB">申請開始時間</param>
        /// <param name="sTimeE">申請結束時間</param>
        /// <returns>OtDetail</returns>
        public static JBHR.Dll.Att.OtCal.OtDetail CalculationOt(string sNobr, string sRote, DateTime dDate, string sTimeB, string sTimeE)
        {
            return CalculationOt(sNobr, sRote, dDate, sTimeB, sTimeE, false);
        }
        /// <summary>
        /// 計算加班時間
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="sRote">班別(預設代0,特殊日期如天災請帶00)</param>
        /// <param name="dDate">申請日期</param>
        /// <param name="sTimeB">申請開始時間</param>
        /// <param name="sTimeE">申請結束時間</param>
        /// <param name="bEat">是否用餐</param>
        /// <returns>OtDetail</returns>
        public static JBHR.Dll.Att.OtCal.OtDetail CalculationOt(string sNobr, string sRote, DateTime dDate, string sTimeB, string sTimeE, bool bEat)
        {
            sTimeB = sTimeB.PadLeft(4, char.Parse("0"));
            sTimeE = sTimeE.PadLeft(4, char.Parse("0"));

            DateTime dDateTimeB, dDateTimeE;
            dDate = dDate.Date;
            dDateTimeB = dDate.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(sTimeB));
            dDateTimeE = dDate.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(sTimeE));

            var rb = JBHR.Dll.Bas.EmpBase(sNobr).FirstOrDefault();
            if (rb == null)
                return null;

            var rd = JBHR.Dll.Bas.Dept(rb.sDeptCode).FirstOrDefault();
            if (rd == null)
                return null;

            JBHR.Dll.Att.OtCal.OtDetail oOtDetail = new JBHR.Dll.Att.OtCal.OtDetail();
            oOtDetail.dDayRes = new JBHR.Dll.Att.OtCal.OtDetail.DayRes[5]; //計算休息次數包含上班時間(最大次數)

            JBHR.Dll.dsAtt.JB_HR_RoteRow rRote;

            rRote = JBHR.Dll.Att.Rote(sNobr, dDate).FirstOrDefault();//個人當天出勤的班別資料
            if (rRote != null)
            {
                //如遇天災日，可代00班使得此天以假日計算之 20100921 by ming
                string sRoteCode = sRote == "00" ? "00" : rRote.sRoteCode; //實際班別

                //不允許是00班
                sRote = (sRote == "0" || sRote == "00" || sRote.Trim().Length == 0) ? rRote.sRoteCode : sRote;
                sRote = GetRote(sNobr, dDate, sRote, true); //再向前找班別
                sRote = GetRote(sNobr, dDate, sRote, false);    //先向後找班別

                oOtDetail.sRote = sRote;

                oOtDetail.bDifferenceRote = !(sRote == rRote.sRoteCode); //班別差異

                rRote = JBHR.Dll.Att.Rote(sRote).FirstOrDefault();
                if (rRote != null)
                {
                    //時間錯誤(不在班別時間裡面)
                    oOtDetail.bTimeError = !(Convert.ToInt32(rRote.sOnTime) <= Convert.ToInt32(sTimeE) && Convert.ToInt32(rRote.sOffTime) >= Convert.ToInt32(sTimeB));

                    int j = 0;
                    oOtDetail.dDayRes[j] = (sRoteCode != "00") ? SetDayRes(oOtDetail.dDayRes, dDateTimeB, dDateTimeE, dDate, rRote.sOnTime, rRote.sOffTime) : null;
                    //不參考用餐時間也不參考休息時間
                    if (!bEat)
                    {
                        if (!rd.bRes || sRoteCode == "00")   //部門有勾的話不參考休息時間，假日一定要參考
                        {
                            j++; oOtDetail.dDayRes[j] = SetDayRes(oOtDetail.dDayRes, dDateTimeB, dDateTimeE, dDate, rRote.sResB1Time, rRote.sResE1Time);
                            j++; oOtDetail.dDayRes[j] = SetDayRes(oOtDetail.dDayRes, dDateTimeB, dDateTimeE, dDate, rRote.sResB2Time, rRote.sResE2Time);
                            j++; oOtDetail.dDayRes[j] = SetDayRes(oOtDetail.dDayRes, dDateTimeB, dDateTimeE, dDate, rRote.sResB3Time, rRote.sResE3Time);
                            j++; oOtDetail.dDayRes[j] = SetDayRes(oOtDetail.dDayRes, dDateTimeB, dDateTimeE, dDate, rRote.sResB4Time, rRote.sResE4Time);
                        }
                    }

                    oOtDetail.bAllDay = (dDateTimeB == dDate.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(rRote.sOnTime))) && (dDateTimeE == dDate.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(rRote.sOffTime)));
                }
            }

            //計算休息時間
            TimeSpan ts;
            foreach (JBHR.Dll.Att.OtCal.OtDetail.DayRes dr in oOtDetail.dDayRes)
            {
                if ((dr != null) && (dr.bHave) && (dr.iHours > 0))
                {
                    dr.dDateB = ((dDateTimeB <= dr.dDateB) && (dDateTimeE >= dr.dDateB)) ? dr.dDateB : dDateTimeB;
                    dr.dDateE = ((dDateTimeB <= dr.dDateE) && (dDateTimeE >= dr.dDateE)) ? dr.dDateE : dDateTimeE;

                    ts = dr.dDateE - dr.dDateB;
                    dr.iHours = Convert.ToDecimal(ts.TotalHours);
                    dr.iMinute = Convert.ToDecimal(ts.TotalMinutes);
                    oOtDetail.iResHour += dr.iHours;
                    oOtDetail.iResMinute += dr.iMinute;
                }
            }

            ts = dDateTimeE - dDateTimeB;

            oOtDetail.iTotalMinute = Convert.ToDecimal(ts.TotalMinutes);
            oOtDetail.iTotalHour = Convert.ToDecimal(ts.TotalHours);
            int iMin = Convert.ToInt32((oOtDetail.iTotalMinute - oOtDetail.iResMinute) % 30);
            oOtDetail.iMinute = ((oOtDetail.iTotalMinute - oOtDetail.iResMinute) - iMin);
            oOtDetail.iHour = oOtDetail.iMinute / 60;

            oOtDetail.iMinute = 0;
            if (oOtDetail.iMinute >= 45)
            {
                oOtDetail.iMinute = 45;
            }
            else if (oOtDetail.iMinute >= 30)
            {
                oOtDetail.iMinute = 30;
            }
            else if (oOtDetail.iMinute >= 15)
            {
                oOtDetail.iMinute = 15;
            }
            else
            {
                oOtDetail.iMinute = 0;
            }

            oOtDetail.iHour = Convert.ToDouble(oOtDetail.iHour) >= 0.25 ? oOtDetail.iHour : 0;

            return oOtDetail;
        }
        /// <summary>
        /// 設定休息時間
        /// </summary>
        /// <param name="dDayRes">目前已加入休息時間(Array)</param>
        /// <param name="dDateTimeB">加班開始日期時間</param>
        /// <param name="dDateTimeE">加班結束日期時間</param>
        /// <param name="dDate">加班日期(未組合的日期)</param>
        /// <param name="sTimeB">休息開始時間</param>
        /// <param name="sTimeE">休息結束時間</param>
        /// <returns>OtDetail.DayRes</returns>
        private static JBHR.Dll.Att.OtCal.OtDetail.DayRes SetDayRes(JBHR.Dll.Att.OtCal.OtDetail.DayRes[] dDayRes, DateTime dDateTimeB, DateTime dDateTimeE, DateTime dDate, string sTimeB, string sTimeE)
        {
            sTimeB = sTimeB.Trim();
            sTimeE = sTimeE.Trim();
            JBHR.Dll.Att.OtCal.OtDetail.DayRes oDayRes = new JBHR.Dll.Att.OtCal.OtDetail.DayRes();

            if ((sTimeB.Length > 0) && (sTimeE.Length > 0))
            {
                oDayRes.dDateB = dDate.Date.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(sTimeB));
                oDayRes.dDateE = dDate.Date.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(sTimeE));
                TimeSpan ts = oDayRes.dDateE - oDayRes.dDateB;
                oDayRes.iHours = Convert.ToDecimal(ts.TotalHours);
                oDayRes.iMinute = Convert.ToDecimal(ts.TotalMinutes);
                oDayRes.bHave = (IsWorkTime(dDayRes, oDayRes)) && (oDayRes.iMinute > 0) && ((dDateTimeB < oDayRes.dDateE) && (dDateTimeE > oDayRes.dDateB));
            }

            return oDayRes;
        }

        /// <summary>
        /// 判斷陣列裡的時間是否與現在要加入的時間重複
        /// </summary>
        /// <param name="dDayRes">目前已加入休息時間(Array)</param>
        /// <param name="oDayRes">要被判斷的時間</param>
        /// <returns>bool</returns>
        private static bool IsWorkTime(JBHR.Dll.Att.OtCal.OtDetail.DayRes[] dDayRes, JBHR.Dll.Att.OtCal.OtDetail.DayRes oDayRes)
        {
            foreach (JBHR.Dll.Att.OtCal.OtDetail.DayRes dr in dDayRes)
                if ((dr != null) && (dr.dDateB < oDayRes.dDateE) && (dr.dDateE > oDayRes.dDateB))
                    return false;

            return true;
        }

    }


    public class csBas
    {
        public class BaseDetailData
        {
            public string sNobr = "";
            public string sNamec = "";
            public DateTime dIn;
            public DateTime dCIn;
            public DateTime dOut;
            public DateTime dSt;
            public DateTime dStIn;
            public DateTime dStOu;
            public string sTtscode = "";
            public string sTtsName = "";

            public BaseDetailData(string sID, DateTime dDate)
            {
                dcBasDataContext dcBas = new dcBasDataContext();
                var sqlBasetts = from BASE in dcBas.BASE
                                 join BASETTS in dcBas.BASETTS on BASE.NOBR equals BASETTS.NOBR
                                 join DEPT in dcBas.DEPT on BASETTS.DEPT equals DEPT.D_NO
                                 join DEPTS in dcBas.DEPTS on BASETTS.DEPTS equals DEPTS.D_NO
                                 join DEPTA in dcBas.DEPTA on BASETTS.DEPTM equals DEPTA.D_NO
                                 join TTSCODE in dcBas.TTSCODE on BASETTS.TTSCODE equals TTSCODE.CODE
                                 where BASE.NOBR.Trim() == sID.Trim()
                                     //&& new string[] { "2", "3", "5" }.Contains(c.TTSCODE)
                                 && BASETTS.ADATE.Date <= dDate.Date && dDate.Date <= BASETTS.DDATE.Value.Date
                                 select new
                                 {
                                     BASE,
                                     BASETTS,
                                     DEPT,
                                     DEPTS,
                                     DEPTA,
                                     TTSCODE
                                 };

                try
                {
                    if (dcBas.Connection.State != ConnectionState.Open) dcBas.Connection.Open();

                    var dr = sqlBasetts.FirstOrDefault();
                    if (dr != null)
                    {
                        sNobr = dr.BASE.NOBR.Trim();
                        sNamec = dr.BASE.NAME_C.Trim();
                        sTtscode = dr.BASETTS.TTSCODE.Trim();
                        sTtsName = dr.TTSCODE.NAME;
                        dCIn = dr.BASETTS.CINDT.Value;
                        dIn = dr.BASETTS.INDT.Value;
                        dSt = dr.BASETTS.STDT.Value;
                        dOut = dr.BASETTS.OUDT.Value;
                        dStIn = dr.BASETTS.STINDT.Value;
                        dStOu = dr.BASETTS.STOUDT.Value;
                    }
                }
                finally
                {
                    dcBas.Connection.Close();
                }
            }
        }
    }

    public class csAtt
    {
        public static decimal SpanHours(DateTime TimeB, DateTime TimeE)
        {
            TimeSpan ts = TimeE - TimeB;
            int h = ts.Hours;
            int m = ts.Minutes;
            decimal mins = m >= 30 ? 0.5M : 0;
            return Convert.ToDecimal(h) + mins;
        }
        public static DateTime AddMinutes(DateTime date, string sTime)
        {
            string[] timeSplit = sTime.Split(':');
            string h, m;
            if (timeSplit.Length != 2)
            {
                string sTime1 = Convert.ToInt32(sTime).ToString("0000");
                h = sTime1.Substring(0, 2);
                m = sTime1.Substring(2);
            }
            else
            {
                h = timeSplit[0];
                m = timeSplit[1];
            }
            int hours, minutes;
            hours = Convert.ToInt32(h);
            minutes = Convert.ToInt32(m);
            DateTime date1 = date.AddHours(hours).AddMinutes(minutes);
            return date1;
        }
        public static string GetYYMM(DateTime date)
        {
            int y, m, d, div;
            div = 1;
            DateTime BDate = date;
            d = date.Day;
            if (d < div) BDate = date.AddMonths(-1);
            y = BDate.Year;
            m = BDate.Month;
            return y.ToString("0000") + m.ToString("00");
        }
        public static decimal GetApproximationValue(decimal value, decimal min, bool isPlace)
        {
            decimal i = Math.Floor(value);
            decimal j = value % 1;
            if (j > min) i = isPlace ? i + 1 : i;
            else if (j > 0 && isPlace) i = i + min;
            return i;
        }
    }

    public class csDataFill
    {
        //假薪關係
        public static void FillHcodesByHcode(dsAtt.HCODESDataTable dt, string sHcode)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<HCODES> sql = from c in dc.HCODES where c.H_CODE == sHcode select c;
            IDataReader dr = null;

            try
            {
                if (dc.Connection.State != ConnectionState.Open) dc.Connection.Open();
                dr = dc.GetCommand(sql).ExecuteReader();
                dt.Load(dr);
                dr.Close();
            }
            finally
            {
                dc.Connection.Close();
            }
        }

        //出勤資料
        public static void FillAttendByDate(dsAtt.ATTENDDataTable dt, DateTime dDate, string sNobr)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<ATTEND> sql = from c in dc.ATTEND where c.ADATE.Date == dDate.Date && c.NOBR.Trim() == sNobr.Trim() select c;
            IDataReader dr = null;

            try
            {
                if (dc.Connection.State != ConnectionState.Open) dc.Connection.Open();
                dr = dc.GetCommand(sql).ExecuteReader();
                dt.Load(dr);
                dr.Close();
            }
            finally
            {
                dc.Connection.Close();
            }
        }

        //出勤刷卡資料
        public static void FillAttcardByDate(dsAtt.ATTCARDDataTable dt, DateTime dDate, string sNobr)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<ATTCARD> sql = from c in dc.ATTCARD where c.ADATE.Date == dDate.Date && c.NOBR.Trim() == sNobr.Trim() select c;
            IDataReader dr = null;

            try
            {
                if (dc.Connection.State != ConnectionState.Open) dc.Connection.Open();
                dr = dc.GetCommand(sql).ExecuteReader();
                dt.Load(dr);
                dr.Close();
            }
            finally
            {
                dc.Connection.Close();
            }
        }
    }

    public class Tools
    {
        public static void SetRowDefaultValue(DataRow row)
        {
            Type t;
            foreach (DataColumn dc in row.Table.Columns)
            {
                t = dc.DataType;
                if (t == typeof(string)) row[dc] = "";
                if (t == typeof(bool)) row[dc] = false;
                if (t == typeof(int)) row[dc] = 0;
                if (t == typeof(decimal)) row[dc] = 0.00;
                if (t == typeof(DateTime)) row[dc] = DateTime.Now;
            }
        }
    }
}