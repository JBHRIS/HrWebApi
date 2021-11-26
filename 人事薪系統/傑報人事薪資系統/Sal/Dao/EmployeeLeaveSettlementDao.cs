using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Att.Dao
{
    internal class EmployeeLeaveSettlementDao
    {
        JBModule.Data.Linq.HrDBDataContext entity = null;
        internal List<Vdb.OutEmployeeInfo> GetOutEmpList(string NobrB, string NobrE, DateTime DateOutB, DateTime DateOutE)
        {
            entity = ContextHelper.GetContext();
            var sql = from a in entity.BASETTS
                      join b in entity.BASE on a.NOBR equals b.NOBR
                      where DateOutE >= a.ADATE && DateOutE <= a.DDATE.Value
                      && a.OUDT.Value >= DateOutB && a.OUDT.Value <= DateOutE
                      && a.NOBR.CompareTo(NobrB) >= 0 && a.NOBR.CompareTo(NobrE) <= 0
                      && entity.GetFilterByNobr(a.NOBR,MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value 
                      select new Vdb.OutEmployeeInfo()
                      {
                          EmployeeId = b.NOBR,
                          EmployeeName = b.NAME_C,
                          OutDate = a.OUDT.Value,
                          BaseSalaryInfoList = (from sa in entity.SALBASD
                                                join sc in entity.SALCODE on sa.SAL_CODE equals sc.SAL_CODE
                                                where sc.ABSPAY && sa.NOBR == a.NOBR && a.OUDT.Value >= sa.ADATE && a.OUDT.Value <= sa.DDATE
                                                select new Att.Vdb.EmployeeBaseSalaryInfo { EmployeeId = a.NOBR, Salcode = sa.SAL_CODE, Amt = JBModule.Data.CDecryp.Number(sa.AMT) }
                                                  ).ToList(),
                          AbsInfoList = (from ab in entity.ABS
                                         join hc in entity.HCODE on ab.H_CODE equals hc.H_CODE
                                         where ab.NOBR == a.NOBR && ab.BDATE.Year == a.OUDT.Value.Year
                                         select new Att.Vdb.EmployeeAbsenceInfo { EmployeeId = a.NOBR, Hcode = ab.H_CODE, TotalHours = ab.TOL_HOURS, Type = hc.YEAR_REST }).ToList()
                      };
            return sql.ToList();
        }
        internal List<Vdb.EmployeeLeaveInfo> GetEmpLeaveInfoList(List<Vdb.OutEmployeeInfo> selectdEmps)
        {
            entity = ContextHelper.GetContext();
            var MaxOutDate = selectdEmps.Max(p => p.OutDate).AddDays(1);
            var Emps = selectdEmps.Select(p => p.EmployeeId);
            var sql = from a in entity.BASETTS
                      join b in entity.BASE on a.NOBR equals b.NOBR
                      where MaxOutDate >= a.ADATE && MaxOutDate <= a.DDATE.Value
                      && Emps.Contains(a.NOBR)
                      let outDate = a.OUDT.Value
                      let specialLeaveHours = GetLeaveHours(selectdEmps.Find(p => p.EmployeeId == a.NOBR), a.OUDT.Value, LeaveType.SpecialLeave)
                      let compensatedLeaveHours = GetLeaveHours(selectdEmps.Find(p => p.EmployeeId == a.NOBR), a.OUDT.Value, LeaveType.CompensatedLeave)
                      let optionalLeaveHours = GetLeaveHours(selectdEmps.Find(p => p.EmployeeId == a.NOBR), a.OUDT.Value, LeaveType.OptionalLeave)
                      let baseSalary = GetBaseSalary(selectdEmps.Find(p => p.EmployeeId == a.NOBR), outDate)
                      let foodSalary = GetFoodSalary(selectdEmps.Find(p => p.EmployeeId == a.NOBR), outDate)
                      select new Vdb.EmployeeLeaveInfo
                      {
                          EmployeeId = a.NOBR,
                          EmployeeName = b.NAME_C,
                          OutDate = outDate,//=MaxOutDate,
                          SpecialLeaveHours = specialLeaveHours,//= GetLeaveHours(a.NOBR, a.OUDT.Value, LeaveType.SpecialLeave),
                          CompensatedLeaveHours = compensatedLeaveHours,//= GetLeaveHours(a.NOBR, a.OUDT.Value, LeaveType.CompensatedLeave),
                          OptionalLeaveHours = optionalLeaveHours,//= GetLeaveHours(a.NOBR, a.OUDT.Value, LeaveType.OptionalLeave),
                          BaseSalary = baseSalary,
                          FoodSalary = foodSalary,
                          SpecialLeaveBonus = CalcBonus(specialLeaveHours, compensatedLeaveHours, optionalLeaveHours, baseSalary, foodSalary, LeaveType.SpecialLeave),
                          CompensatedLeaveBonus = CalcBonus(specialLeaveHours, compensatedLeaveHours, optionalLeaveHours, baseSalary, foodSalary, LeaveType.CompensatedLeave),
                          OptionalLeaveBonus = CalcBonus(specialLeaveHours, compensatedLeaveHours, optionalLeaveHours, baseSalary, foodSalary, LeaveType.OptionalLeave),
                      };
            //foreach (var it in sql)
            //    it.BaseSalary = 10000;
            //return null;
            return sql.ToList();
        }
        internal decimal GetLeaveHours(Vdb.OutEmployeeInfo emp, DateTime DDate, LeaveType leaveType)
        {
            int iYearRest = 0;
            switch (leaveType)
            {
                case LeaveType.SpecialLeave:
                    iYearRest = 1;
                    break;
                case LeaveType.CompensatedLeave:
                    iYearRest = 3;
                    break;
                case LeaveType.OptionalLeave:
                    iYearRest = 5;
                    break;
            }
            string GetCode, UseCode;
            GetCode = iYearRest.ToString();
            UseCode = (iYearRest + 1).ToString();

            var absData = emp.AbsInfoList;
            var salbasdData = emp.BaseSalaryInfoList;

            entity = ContextHelper.GetContext();
            var getSQL = from a in absData
                         where a.Type == GetCode
                         select a;
            var useSQL = from a in absData
                         where a.Type == UseCode
                         select a;
            decimal getHrs = 0.00M;
            if (getSQL.Any())
                getHrs = getSQL.Sum(p => p.TotalHours);
            decimal useHrs = 0.00M;
            if (useSQL.Any())
                useHrs = useSQL.Sum(p => p.TotalHours);
            decimal totalHrs = getHrs - useHrs;
            return totalHrs;
        }
        internal decimal GetBaseSalary(Vdb.OutEmployeeInfo emp, DateTime DDate)
        {
            var salaryData = emp.BaseSalaryInfoList;
            string FilterSalaryCode = "G01";
            entity = ContextHelper.GetContext();
            var sql = from a in salaryData
                      where a.Salcode != FilterSalaryCode
                      select a.Amt;
            var value = sql.ToList().Sum(p => p);
            return value;
        }
        internal decimal GetFoodSalary(Vdb.OutEmployeeInfo emp, DateTime DDate)
        {
            var salaryData = emp.BaseSalaryInfoList;
            string FilterSalaryCode = "G01";
            entity = ContextHelper.GetContext();
            var sql = from a in salaryData
                      where a.Salcode == FilterSalaryCode
                      select a.Amt;
            var value = sql.ToList().Sum(p => p);
            return value;
            return value;
        }
        internal decimal CalcBonus(decimal SpecialLeaveHours, decimal CompensatedLeaveHours, decimal OptionalLeaveHours, decimal BaseSalary, decimal FoodSalary, LeaveType leaveType)
        {
            /*
             * 此作業有兩個主要功能：
      1.員工離職時有欠公司時數(特休、補休、彈休)，系統會
           依如有特休有時數先扣特休    13
           依如有補休有時數先扣補休    3
           依如有彈休有時數先扣彈休   -16

           最後還有欠時數再公司扣款規定去扣款，且直接匯入當月薪資。
             特休代金 ((基本薪+伙食津貼+職務津貼)/240 )* 剩餘時數  
             補休代金 ((基本薪+職務津貼)/240 ) * 剩餘時數  
             彈休代金 ((基本薪+伙食津貼+職務津貼)/240 )* 剩餘時數 


      2.員工離職時還有剩於時數(特休、補休、彈休)，系統會依公司規定產生代金金額，且直接匯入當月薪資。
             特休代金 ((基本薪+伙食津貼+職務津貼)/240 )* 剩餘時數  
             補休代金 ((基本薪+職務津貼)/240 ) * 剩餘時數  
             彈休代金 ((基本薪+伙食津貼+職務津貼)/240 )* 剩餘時數
            */
            decimal SpecialHrs, CompensatedHrs, OptionalHrs;
            SpecialHrs = SpecialLeaveHours;
            CompensatedHrs = CompensatedLeaveHours;
            OptionalHrs = OptionalLeaveHours;

            #region 特休超休
            if (SpecialHrs < 0)//特休超休
            {
                if (CompensatedHrs > 0)//先扣補休
                {
                    if (CompensatedHrs + SpecialHrs >= 0)//補休夠扣
                    {
                        CompensatedHrs += SpecialHrs;
                        SpecialHrs = 0;
                    }
                    else//不夠扣
                    {
                        CompensatedHrs = 0;
                        SpecialHrs += CompensatedHrs;
                    }
                }
                if (SpecialHrs < 0 && OptionalHrs > 0)//再扣彈休(如果補休還不夠扣)
                {
                    if (OptionalHrs + SpecialHrs >= 0)//彈休夠扣
                    {
                        OptionalHrs += SpecialHrs;
                        SpecialHrs = 0;
                    }
                    else//不夠扣
                    {
                        OptionalHrs = 0;
                        SpecialHrs += OptionalHrs;
                    }
                }
            }
            #endregion

            #region 補休超休
            if (CompensatedHrs < 0)//補休超休
            {
                if (SpecialHrs > 0)//先扣特休
                {
                    if (SpecialHrs + CompensatedHrs >= 0)//特休夠扣
                    {
                        SpecialHrs += CompensatedHrs;
                        CompensatedHrs = 0;
                    }
                    else//不夠扣
                    {
                        SpecialHrs = 0;
                        CompensatedHrs += SpecialHrs;
                    }
                }
                if (CompensatedHrs < 0 && OptionalHrs > 0)//再扣彈休(如果特休還不夠扣)
                {
                    if (OptionalHrs + CompensatedHrs >= 0)//彈休夠扣
                    {
                        OptionalHrs += CompensatedHrs;
                        CompensatedHrs = 0;
                    }
                    else//不夠扣
                    {
                        OptionalHrs = 0;
                        CompensatedHrs += OptionalHrs;
                    }
                }
            }
            #endregion

            #region 彈休超休
            if (OptionalHrs < 0)//彈休超休
            {
                if (SpecialHrs > 0)//先扣特休
                {
                    if (SpecialHrs + OptionalHrs >= 0)//特休夠扣
                    {
                        SpecialHrs += OptionalHrs;
                        OptionalHrs = 0;
                    }
                    else//不夠扣
                    {
                        SpecialHrs = 0;
                        OptionalHrs += SpecialHrs;
                    }
                }
                if (OptionalHrs < 0 && CompensatedHrs > 0)//再扣補休(如果特休還不夠扣)
                {
                    if (CompensatedHrs + OptionalHrs >= 0)//特休夠扣
                    {
                        CompensatedHrs += OptionalHrs;
                        OptionalHrs = 0;
                    }
                    else//不夠扣
                    {
                        CompensatedHrs = 0;
                        OptionalHrs += SpecialHrs;
                    }
                }
            }
            #endregion

            decimal value = 0.00M;
            switch (leaveType)
            {
                case LeaveType.SpecialLeave:
                    value = Math.Round((BaseSalary + FoodSalary) / 240 * SpecialHrs, MidpointRounding.AwayFromZero);
                    break;
                case LeaveType.CompensatedLeave:
                    value = Math.Round((BaseSalary) / 240 * CompensatedHrs, MidpointRounding.AwayFromZero);
                    break;
                case LeaveType.OptionalLeave:
                    value = Math.Round((BaseSalary + FoodSalary) / 240 * OptionalHrs, MidpointRounding.AwayFromZero);
                    break;
            }
            return value;
        }
        internal enum LeaveType
        {
            SpecialLeave,
            CompensatedLeave,
            OptionalLeave,
        }
        internal int InsertData(List<JBModule.Data.Linq.ABS> absList, List<JBModule.Data.Linq.ENRICH> enrichList)
        {
            entity = ContextHelper.GetContext();
            entity.ABS.InsertAllOnSubmit(absList);
            entity.ENRICH.InsertAllOnSubmit(enrichList);
            entity.SubmitChanges();
            return absList.Count + enrichList.Count;
        }
    }
}
