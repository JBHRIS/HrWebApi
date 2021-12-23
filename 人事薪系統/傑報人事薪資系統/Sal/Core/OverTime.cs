using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Sal.Core.OvertTime
{
    public class OverTime
    {
        SalaryMDDataContext smd = new SalaryMDDataContext();
        CodeMDDataContext cdc = new CodeMDDataContext();
        BASE rBase;
        public List<JBModule.Data.Linq.OTRATECD_ROTE> OTRATECD_ROTEList = new List<JBModule.Data.Linq.OTRATECD_ROTE>();
        public decimal NoTaxHours = 46;
        string EmpID="";
        public OverTime(string nobr)//以每人為基準
        {
            EmpID = nobr;
            var sql = from b in smd.BASE where b.NOBR == nobr select b;
            if (!sql.Any()) throw new Exception("找不到員工編號" + nobr + "的員工資料");
            rBase = sql.First();
            decimal NoTaxHrsMale = MainForm.OvertimeConfig.MALEMAXHRS.Value;
            decimal NoTaxHrsFemale = MainForm.OvertimeConfig.FEMALEMAXHRS.Value;
            NoTaxHours = rBase.SEX.Trim() == "M" ? NoTaxHrsMale : NoTaxHrsFemale;
        }
        public void SetOtRate(JBModule.Data.Linq.OT ot, OTRATECD otrcd, decimal CurrentOtHrs, string AttRote, bool SYS_OT)
        {
            //var att = from a in cdc.ATTEND where a.NOBR == ot.NOBR && a.ADATE == ot.BDATE select a;
            //if (att.Any())
            //{                
            ot.WOT_133 = 0;
            ot.WOT_166 = 0;
            ot.WOT_200 = 0;

            ot.HOT_133 = 0;
            ot.HOT_166 = 0;
            ot.HOT_200 = 0;

            ot.NOP_H_133 = 0;
            ot.NOP_H_167 = 0;
            ot.NOP_H_200 = 0;
            ot.NOP_W_133 = 0;
            ot.NOP_W_167 = 0;
            ot.NOP_W_200 = 0;

            //拆開倍率時數
            if (AttRote == "00")//假日
            {
                if (otrcd.OTH_REST_TIME_B1 < ot.OT_HRS && otrcd.OTH_REST_TIME_E1 >= ot.OT_HRS)
                    ot.OT_HRS = otrcd.OTH_REST_HOURS1;
                ot.HOT_133 = Function.RangeMix(otrcd.OT133HTIME_B, otrcd.OT133HTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                ot.HOT_166 = Function.RangeMix(otrcd.OT167HTIME_B, otrcd.OT167HTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                ot.HOT_200 = Function.RangeMix(otrcd.OT200HTIME_B, otrcd.OT200HTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);

                if (otrcd.OTRATE_TYPEH == "1")
                {
                    ot.NOP_H_133 = otrcd.OT133HRATE;
                    ot.NOP_H_167 = otrcd.OT167HRATE;
                    ot.NOP_H_200 = otrcd.OT200HRATE;
                    ot.NOP_W_133 = otrcd.OT133HRATE;
                    ot.NOP_W_167 = otrcd.OT167HRATE;
                    ot.NOP_W_200 = otrcd.OT200HRATE;
                }
                else if (otrcd.OTRATE_TYPEH == "2")
                {
                    ot.NOP_H_133 = otrcd.OT133HAMT;
                    ot.NOP_H_167 = otrcd.OT167HAMT;
                    ot.NOP_H_200 = otrcd.OT200HAMT;
                    ot.NOP_W_133 = otrcd.OT133HAMT;
                    ot.NOP_W_167 = otrcd.OT167HAMT;
                    ot.NOP_W_200 = otrcd.OT200HAMT;
                }
            }
            else if (AttRote == "0X")//休息日
            {
                if (otrcd.OT_REST_TIME_B1 < ot.OT_HRS && otrcd.OT_REST_TIME_E1 >= ot.OT_HRS)
                    ot.OT_HRS = otrcd.OT_REST_HOURS1;
                else if (otrcd.OT_REST_TIME_B2 < ot.OT_HRS && otrcd.OT_REST_TIME_E2 >= ot.OT_HRS)
                    ot.OT_HRS = otrcd.OT_REST_HOURS2;
                else if (otrcd.OT_REST_TIME_B3 < ot.OT_HRS && otrcd.OT_REST_TIME_E3 >= ot.OT_HRS)
                    ot.OT_HRS = otrcd.OT_REST_HOURS3;
                ot.WOT_133 = Function.RangeMix(otrcd.OT133RTIME_B, otrcd.OT133RTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                ot.WOT_166 = Function.RangeMix(otrcd.OT167RTIME_B, otrcd.OT167RTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                ot.WOT_200 = Function.RangeMix(otrcd.OT200RTIME_B, otrcd.OT200RTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);


                if (otrcd.OTRATE_TYPER == "1")
                {
                    ot.NOP_H_133 = otrcd.OT133RRATE;
                    ot.NOP_H_167 = otrcd.OT167RRATE;
                    ot.NOP_H_200 = otrcd.OT200RRATE;
                    ot.NOP_W_133 = otrcd.OT133RRATE;
                    ot.NOP_W_167 = otrcd.OT167RRATE;
                    ot.NOP_W_200 = otrcd.OT200RRATE;
                }
                else if (otrcd.OTRATE_TYPER == "2")
                {
                    ot.NOP_H_133 = otrcd.OT133RAMT;
                    ot.NOP_H_167 = otrcd.OT167RAMT;
                    ot.NOP_H_200 = otrcd.OT200RAMT;
                    ot.NOP_W_133 = otrcd.OT133RAMT;
                    ot.NOP_W_167 = otrcd.OT167RAMT;
                    ot.NOP_W_200 = otrcd.OT200RAMT;
                }
            }
            else if (AttRote == "0Z")//例假日
            {
                if (otrcd.OTN_REST_TIME_B1 < ot.OT_HRS && otrcd.OTN_REST_TIME_E1 >= ot.OT_HRS)
                    ot.OT_HRS = otrcd.OTN_REST_HOURS1;
                ot.HOT_133 = Function.RangeMix(otrcd.OT133NTIME_B, otrcd.OT133NTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                ot.HOT_166 = Function.RangeMix(otrcd.OT167NTIME_B, otrcd.OT167NTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                ot.HOT_200 = Function.RangeMix(otrcd.OT200NTIME_B, otrcd.OT200NTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);

                if (otrcd.OTRATE_TYPEN == "1")
                {
                    ot.NOP_H_133 = otrcd.OT133NRATE;
                    ot.NOP_H_167 = otrcd.OT167NRATE;
                    ot.NOP_H_200 = otrcd.OT200NRATE;
                    ot.NOP_W_133 = otrcd.OT133NRATE;
                    ot.NOP_W_167 = otrcd.OT167NRATE;
                    ot.NOP_W_200 = otrcd.OT200NRATE;
                }
                else if (otrcd.OTRATE_TYPEN == "2")
                {
                    ot.NOP_H_133 = otrcd.OT133NAMT;
                    ot.NOP_H_167 = otrcd.OT167NAMT;
                    ot.NOP_H_200 = otrcd.OT200NAMT;
                    ot.NOP_W_133 = otrcd.OT133NAMT;
                    ot.NOP_W_167 = otrcd.OT167NAMT;
                    ot.NOP_W_200 = otrcd.OT200NAMT;
                }
            }
            else//延長工時
            {
                ot.WOT_133 = Function.RangeMix(otrcd.OT133WTIME_B, otrcd.OT133WTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                ot.WOT_166 = Function.RangeMix(otrcd.OT167WTIME_B, otrcd.OT167WTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                ot.WOT_200 = Function.RangeMix(otrcd.OT200WTIME_B, otrcd.OT200WTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);


                if (otrcd.OTRATE_TYPEW == "1")
                {
                    ot.NOP_H_133 = otrcd.OT133WRATE;
                    ot.NOP_H_167 = otrcd.OT167WRATE;
                    ot.NOP_H_200 = otrcd.OT200WRATE;
                    ot.NOP_W_133 = otrcd.OT133WRATE;
                    ot.NOP_W_167 = otrcd.OT167WRATE;
                    ot.NOP_W_200 = otrcd.OT200WRATE;
                }
                else if (otrcd.OTRATE_TYPEW == "2")
                {
                    ot.NOP_H_133 = otrcd.OT133WAMT;
                    ot.NOP_H_167 = otrcd.OT167WAMT;
                    ot.NOP_H_200 = otrcd.OT200WAMT;
                    ot.NOP_W_133 = otrcd.OT133WAMT;
                    ot.NOP_W_167 = otrcd.OT167WAMT;
                    ot.NOP_W_200 = otrcd.OT200WAMT;
                }
            }
        }
        public void SetOtRate(JBModule.Data.Linq.OT_B ot, OTRATECD otrcd, decimal CurrentOtHrs, string AttRote, bool SYS_OT)
        {
            //var att = from a in cdc.ATTEND where a.NOBR == ot.NOBR && a.ADATE == ot.BDATE select a;
            //if (att.Any())
            //{                
            ot.WOT_133 = 0;
            ot.WOT_166 = 0;
            ot.WOT_200 = 0;

            ot.HOT_133 = 0;
            ot.HOT_166 = 0;
            ot.HOT_200 = 0;
            //var attend = att.First();
            ot.NOP_H_133 = otrcd.OT133HRATE;
            ot.NOP_H_167 = otrcd.OT167HRATE;
            ot.NOP_H_200 = otrcd.OT200HRATE;
            ot.NOP_W_133 = otrcd.OT133WRATE;
            ot.NOP_W_167 = otrcd.OT167WRATE;
            ot.NOP_W_200 = otrcd.OT200WRATE;
            //拆開倍率時數
            if (AttRote == "00")//假日
            {
                if (otrcd.OTN_REST_TIME_B1 < ot.OT_HRS && otrcd.OTN_REST_TIME_E1 >= ot.OT_HRS)
                    ot.OT_HRS = otrcd.OTN_REST_HOURS1;
                ot.HOT_133 = Function.RangeMix(otrcd.OT133HTIME_B, otrcd.OT133HTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                ot.HOT_166 = Function.RangeMix(otrcd.OT167HTIME_B, otrcd.OT167HTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                ot.HOT_200 = Function.RangeMix(otrcd.OT200HTIME_B, otrcd.OT200HTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);

                ot.NOP_H_133 = otrcd.OT133HRATE;
                ot.NOP_H_167 = otrcd.OT167HRATE;
                ot.NOP_H_200 = otrcd.OT200HRATE;
                ot.NOP_W_133 = otrcd.OT133HRATE;
                ot.NOP_W_167 = otrcd.OT167HRATE;
                ot.NOP_W_200 = otrcd.OT200HRATE;
            }
            else if (AttRote == "0X")//休息日
            {
                if (otrcd.OT_REST_TIME_B1 < ot.OT_HRS && otrcd.OT_REST_TIME_E1 >= ot.OT_HRS)
                    ot.OT_HRS = otrcd.OT_REST_HOURS1;
                else if (otrcd.OT_REST_TIME_B2 < ot.OT_HRS && otrcd.OT_REST_TIME_E2 >= ot.OT_HRS)
                    ot.OT_HRS = otrcd.OT_REST_HOURS2;
                else if (otrcd.OT_REST_TIME_B3 < ot.OT_HRS && otrcd.OT_REST_TIME_E3 >= ot.OT_HRS)
                    ot.OT_HRS = otrcd.OT_REST_HOURS3;
                ot.WOT_133 = Function.RangeMix(otrcd.OT133RTIME_B, otrcd.OT133RTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                ot.WOT_166 = Function.RangeMix(otrcd.OT167RTIME_B, otrcd.OT167RTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                ot.WOT_200 = Function.RangeMix(otrcd.OT200RTIME_B, otrcd.OT200RTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);

                ot.NOP_H_133 = otrcd.OT133RRATE;
                ot.NOP_H_167 = otrcd.OT167RRATE;
                ot.NOP_H_200 = otrcd.OT200RRATE;
                ot.NOP_W_133 = otrcd.OT133RRATE;
                ot.NOP_W_167 = otrcd.OT167RRATE;
                ot.NOP_W_200 = otrcd.OT200RRATE;
            }
            else if (AttRote == "0Z")//例假日
            {
                if (otrcd.OTH_REST_TIME_B1 < ot.OT_HRS && otrcd.OTH_REST_TIME_E1 >= ot.OT_HRS)
                    ot.OT_HRS = otrcd.OTH_REST_HOURS1;
                ot.HOT_133 = Function.RangeMix(otrcd.OT133NTIME_B, otrcd.OT133NTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                ot.HOT_166 = Function.RangeMix(otrcd.OT167NTIME_B, otrcd.OT167NTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                ot.HOT_200 = Function.RangeMix(otrcd.OT200NTIME_B, otrcd.OT200NTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);

                ot.NOP_H_133 = otrcd.OT133NRATE;
                ot.NOP_H_167 = otrcd.OT167NRATE;
                ot.NOP_H_200 = otrcd.OT200NRATE;
                ot.NOP_W_133 = otrcd.OT133NRATE;
                ot.NOP_W_167 = otrcd.OT167NRATE;
                ot.NOP_W_200 = otrcd.OT200NRATE;
            }
            else//延長工時
            {
                ot.WOT_133 = Function.RangeMix(otrcd.OT133WTIME_B, otrcd.OT133WTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                ot.WOT_166 = Function.RangeMix(otrcd.OT167WTIME_B, otrcd.OT167WTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                ot.WOT_200 = Function.RangeMix(otrcd.OT200WTIME_B, otrcd.OT200WTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
            }
        }
        public decimal GetOtRate(DateTime OtDate, string AttRote, decimal TotalHours, decimal CurrentOtHrs)
        {
            //if (TotalHours == 0) return 0;//避免除0錯誤
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.BASETTS
                      join b in db.OTRATECD on a.CALOT equals b.OTRATE_CODE
                      where a.NOBR == EmpID && OtDate >= a.ADATE && OtDate <= a.DDATE.Value
                      select b;

            decimal rate = 0;
            if (sql.Any())
            {
                var otrcd = sql.First();
                var ot = new JBModule.Data.Linq.OT();
                ot.OT_HRS = TotalHours;
                ot.TOT_HOURS = TotalHours;
                ot.REST_HRS = 0;
                ot.WOT_133 = 0;
                ot.WOT_166 = 0;
                ot.WOT_200 = 0;

                ot.HOT_133 = 0;
                ot.HOT_166 = 0;
                ot.HOT_200 = 0;
                //var attend = att.First();
                ot.NOP_H_133 = otrcd.OT133HRATE;
                ot.NOP_H_167 = otrcd.OT167HRATE;
                ot.NOP_H_200 = otrcd.OT200HRATE;
                ot.NOP_W_133 = otrcd.OT133WRATE;
                ot.NOP_W_167 = otrcd.OT167WRATE;
                ot.NOP_W_200 = otrcd.OT200WRATE;
                //拆開倍率時數
                if (AttRote == "00")//假日
                {
                    //if (otrcd.OTH_REST_TIME_B1 < ot.OT_HRS && otrcd.OTH_REST_TIME_E1 >= ot.OT_HRS)
                    //    ot.OT_HRS = otrcd.OTH_REST_HOURS1;
                    ot.HOT_133 = Function.RangeMix(otrcd.OT133HTIME_B, otrcd.OT133HTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                    ot.HOT_166 = Function.RangeMix(otrcd.OT167HTIME_B, otrcd.OT167HTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                    ot.HOT_200 = Function.RangeMix(otrcd.OT200HTIME_B, otrcd.OT200HTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);

                    ot.NOP_H_133 = otrcd.OT133HRATE;
                    ot.NOP_H_167 = otrcd.OT167HRATE;
                    ot.NOP_H_200 = otrcd.OT200HRATE;
                }
                else if (AttRote == "0X")//休息日
                {
                    //if (otrcd.OT_REST_TIME_B1 < ot.OT_HRS && otrcd.OT_REST_TIME_E1 >= ot.OT_HRS)
                    //    ot.OT_HRS = otrcd.OT_REST_HOURS1;
                    //else if (otrcd.OT_REST_TIME_B2 < ot.OT_HRS && otrcd.OT_REST_TIME_E2 >= ot.OT_HRS)
                    //    ot.OT_HRS = otrcd.OT_REST_HOURS2;
                    //else if (otrcd.OT_REST_TIME_B3 < ot.OT_HRS && otrcd.OT_REST_TIME_E3 >= ot.OT_HRS)
                    //    ot.OT_HRS = otrcd.OT_REST_HOURS3;
                    ot.WOT_133 = Function.RangeMix(otrcd.OT133RTIME_B, otrcd.OT133RTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                    ot.WOT_166 = Function.RangeMix(otrcd.OT167RTIME_B, otrcd.OT167RTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                    ot.WOT_200 = Function.RangeMix(otrcd.OT200RTIME_B, otrcd.OT200RTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);

                    ot.NOP_H_133 = otrcd.OT133RRATE;
                    ot.NOP_H_167 = otrcd.OT167RRATE;
                    ot.NOP_H_200 = otrcd.OT200RRATE;
                    ot.NOP_W_133 = otrcd.OT133RRATE;
                    ot.NOP_W_167 = otrcd.OT167RRATE;
                    ot.NOP_W_200 = otrcd.OT200RRATE;
                }
                else if (AttRote == "0Z")//例假日
                {
                    //if (otrcd.OTN_REST_TIME_B1 < ot.OT_HRS && otrcd.OTN_REST_TIME_E1 >= ot.OT_HRS)
                    //    ot.OT_HRS = otrcd.OTN_REST_HOURS1;
                    ot.HOT_133 = Function.RangeMix(otrcd.OT133NTIME_B, otrcd.OT133NTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                    ot.HOT_166 = Function.RangeMix(otrcd.OT167NTIME_B, otrcd.OT167NTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                    ot.HOT_200 = Function.RangeMix(otrcd.OT200NTIME_B, otrcd.OT200NTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);

                    ot.NOP_H_133 = otrcd.OT133NRATE;
                    ot.NOP_H_167 = otrcd.OT167NRATE;
                    ot.NOP_H_200 = otrcd.OT200NRATE;
                    ot.NOP_W_133 = otrcd.OT133NRATE;
                    ot.NOP_W_167 = otrcd.OT167NRATE;
                    ot.NOP_W_200 = otrcd.OT200NRATE;
                }
                else//延長工時
                {
                    ot.WOT_133 = Function.RangeMix(otrcd.OT133WTIME_B, otrcd.OT133WTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                    ot.WOT_166 = Function.RangeMix(otrcd.OT167WTIME_B, otrcd.OT167WTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                    ot.WOT_200 = Function.RangeMix(otrcd.OT200WTIME_B, otrcd.OT200WTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                }
                rate = (ot.WOT_133 * ot.NOP_W_133 + ot.WOT_166 * ot.NOP_W_167 + ot.WOT_200 * ot.NOP_W_200 + ot.HOT_133 * ot.NOP_H_133 + ot.HOT_166 * ot.NOP_H_167 + ot.HOT_200 * ot.NOP_H_200);// TotalHours;
            }
            return rate;//沒有的話就傳本身
        }
        public decimal GetOtRate(DateTime OtDate, string AttRote, string OtRateCode, decimal TotalHours, decimal CurrentOtHrs)
        {
            //if (TotalHours == 0) return 0;//避免除0錯誤
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = db.OTRATECD.Where(p => p.OTRATE_CODE == OtRateCode);

            decimal rate = 0;
            if (sql.Any())
            {
                var otrcd = sql.First();
                var ot = new JBModule.Data.Linq.OT();
                ot.OT_HRS = TotalHours;
                ot.TOT_HOURS = TotalHours;
                ot.REST_HRS = 0;
                ot.WOT_133 = 0;
                ot.WOT_166 = 0;
                ot.WOT_200 = 0;

                ot.HOT_133 = 0;
                ot.HOT_166 = 0;
                ot.HOT_200 = 0;
                //var attend = att.First();
                ot.NOP_H_133 = otrcd.OT133HRATE;
                ot.NOP_H_167 = otrcd.OT167HRATE;
                ot.NOP_H_200 = otrcd.OT200HRATE;
                ot.NOP_W_133 = otrcd.OT133WRATE;
                ot.NOP_W_167 = otrcd.OT167WRATE;
                ot.NOP_W_200 = otrcd.OT200WRATE;
                //拆開倍率時數
                if (AttRote == "00")//例假日
                {
                    //if (otrcd.OTH_REST_TIME_B1 < ot.OT_HRS && otrcd.OTH_REST_TIME_E1 >= ot.OT_HRS)
                    //    ot.OT_HRS = otrcd.OTH_REST_HOURS1;
                    ot.HOT_133 = Function.RangeMix(otrcd.OT133HTIME_B, otrcd.OT133HTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                    ot.HOT_166 = Function.RangeMix(otrcd.OT167HTIME_B, otrcd.OT167HTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                    ot.HOT_200 = Function.RangeMix(otrcd.OT200HTIME_B, otrcd.OT200HTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);

                    ot.NOP_H_133 = otrcd.OT133HRATE;
                    ot.NOP_H_167 = otrcd.OT167HRATE;
                    ot.NOP_H_200 = otrcd.OT200HRATE;
                }
                else if (AttRote == "0X")//休息日
                {
                    //if (otrcd.OT_REST_TIME_B1 < ot.OT_HRS && otrcd.OT_REST_TIME_E1 >= ot.OT_HRS)
                    //    ot.OT_HRS = otrcd.OT_REST_HOURS1;
                    //else if (otrcd.OT_REST_TIME_B2 < ot.OT_HRS && otrcd.OT_REST_TIME_E2 >= ot.OT_HRS)
                    //    ot.OT_HRS = otrcd.OT_REST_HOURS2;
                    //else if (otrcd.OT_REST_TIME_B3 < ot.OT_HRS && otrcd.OT_REST_TIME_E3 >= ot.OT_HRS)
                    //    ot.OT_HRS = otrcd.OT_REST_HOURS3;
                    ot.WOT_133 = Function.RangeMix(otrcd.OT133RTIME_B, otrcd.OT133RTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                    ot.WOT_166 = Function.RangeMix(otrcd.OT167RTIME_B, otrcd.OT167RTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                    ot.WOT_200 = Function.RangeMix(otrcd.OT200RTIME_B, otrcd.OT200RTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);

                    ot.NOP_H_133 = otrcd.OT133RRATE;
                    ot.NOP_H_167 = otrcd.OT167RRATE;
                    ot.NOP_H_200 = otrcd.OT200RRATE;
                    ot.NOP_W_133 = otrcd.OT133RRATE;
                    ot.NOP_W_167 = otrcd.OT167RRATE;
                    ot.NOP_W_200 = otrcd.OT200RRATE;
                }
                else if (AttRote == "0Z")//假日
                {
                    //if (otrcd.OTN_REST_TIME_B1 < ot.OT_HRS && otrcd.OTN_REST_TIME_E1 >= ot.OT_HRS)
                    //    ot.OT_HRS = otrcd.OTN_REST_HOURS1;
                    ot.HOT_133 = Function.RangeMix(otrcd.OT133NTIME_B, otrcd.OT133NTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                    ot.HOT_166 = Function.RangeMix(otrcd.OT167NTIME_B, otrcd.OT167NTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                    ot.HOT_200 = Function.RangeMix(otrcd.OT200NTIME_B, otrcd.OT200NTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);

                    ot.NOP_H_133 = otrcd.OT133NRATE;
                    ot.NOP_H_167 = otrcd.OT167NRATE;
                    ot.NOP_H_200 = otrcd.OT200NRATE;
                    ot.NOP_W_133 = otrcd.OT133NRATE;
                    ot.NOP_W_167 = otrcd.OT167NRATE;
                    ot.NOP_W_200 = otrcd.OT200NRATE;
                }
                else//延長工時
                {
                    ot.WOT_133 = Function.RangeMix(otrcd.OT133WTIME_B, otrcd.OT133WTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                    ot.WOT_166 = Function.RangeMix(otrcd.OT167WTIME_B, otrcd.OT167WTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                    ot.WOT_200 = Function.RangeMix(otrcd.OT200WTIME_B, otrcd.OT200WTIME_E, CurrentOtHrs, CurrentOtHrs + ot.OT_HRS);
                }
                rate = (ot.WOT_133 * ot.NOP_W_133 + ot.WOT_166 * ot.NOP_W_167 + ot.WOT_200 * ot.NOP_W_200 + ot.HOT_133 * ot.NOP_H_133 + ot.HOT_166 * ot.NOP_H_167 + ot.HOT_200 * ot.NOP_H_200);// TotalHours;
            }
            return rate;//沒有的話就傳本身
        }
    }
    public class OtTaxRate
    {
        string ATT_ROTE = "";
        decimal NoTaxHoursOfDay = 0;
        public decimal DailyMaxHrs = 12;
        decimal not_hrs = 0;
        decimal tot_hrs = 0;
        decimal noTaxMax = 0;
        bool SYS_OT = false;
        bool DailyHrsMaxSW = false;
        public OtTaxRate(string att_rote, bool sys_ot, bool dailyHrsMaxSW = false)//以每天為基準
        {
            this.ATT_ROTE = att_rote;
            this.SYS_OT = sys_ot;
            if (this.ATT_ROTE == "00" || this.ATT_ROTE == "0Z")
            {
                NoTaxHoursOfDay = 8;//設定假日免稅上限
                DailyMaxHrs = 4;
            }
            DailyHrsMaxSW = dailyHrsMaxSW;
            //else if (this.ATT_ROTE == "0X")
            //    DailyMaxHrs = 12;
            //else
            //    DailyMaxHrs = 4;
        }
        public decimal SetOtTax(decimal NOTAXMAX, decimal Hrs)
        {
            decimal FreeNoTaxHrs = 0;//不計入46小時
            decimal NoTaxHrs = 0;//今天還可以申請免稅的時數
            decimal TaxHrs = 0;//今天還可以申請應稅的時數
            not_hrs = 0;
            tot_hrs = 0;
            if (Hrs == 0) return NOTAXMAX;//不計算

            FreeNoTaxHrs = Hrs <= NoTaxHoursOfDay ? Hrs : NoTaxHoursOfDay;//免稅時數等於分段時數或是剩餘的本日免稅上限時數            
            NoTaxHrs = Hrs <= NoTaxHoursOfDay ? 0 : Hrs - FreeNoTaxHrs;//應稅時數等於0或是分段時數與剩餘上限的差
            NoTaxHoursOfDay -= FreeNoTaxHrs;
            //if (this.ATT_ROTE != "00" && this.ATT_ROTE != "0Z")//如果不是假日班且非系統加班，必須再判斷免稅時數有無超出每月上限
            {
                decimal i, j, k;
                i = NoTaxHrs <= NOTAXMAX ? NoTaxHrs : NOTAXMAX;//如果時數小於剩餘的免稅時數，就全部都是免稅，否則就是剩餘時數
                j = NoTaxHrs <= NOTAXMAX ? 0 : NoTaxHrs - NOTAXMAX;//時數小於剩餘時數，無應稅時數，否則就是
                NoTaxHrs = i;
                NOTAXMAX -= NoTaxHrs;//沖抵免稅時數                
                TaxHrs += j;//如果超出的部分，在累加到應稅裡
                if (DailyHrsMaxSW)//if (this.ATT_ROTE != "00" && this.ATT_ROTE != "0Z")
                {
                    k = NoTaxHrs - DailyMaxHrs;
                    NoTaxHrs = k > 0 ? DailyMaxHrs : NoTaxHrs;
                    TaxHrs = k > 0 ? TaxHrs + k : TaxHrs;
                    DailyMaxHrs = k > 0 ? 0 : DailyMaxHrs - NoTaxHrs;
                    NOTAXMAX += k > 0 ? k : 0;
                }
            }
            not_hrs = NoTaxHrs + FreeNoTaxHrs;
            tot_hrs = TaxHrs;
            return NOTAXMAX;
        }
        public decimal Not_Hours
        {
            get { return this.not_hrs; }
        }
        public decimal Tot_Hours
        {
            get { return tot_hrs; }
        }
    }
}
