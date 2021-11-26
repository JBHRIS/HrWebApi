using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Att.Controller
{
    public class EmployeeLeaveSettlementController
    {
        public Vdb.EmployeeLeaveSettlementVdb _vdb;
        Dao.EmployeeLeaveSettlementDao dao;
        /// <summary>
        /// 取得離職員工清單
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<Vdb.OutEmployeeInfo> GetOutEmployeeList(Vdb.EmployeeLeaveSettlementCondition condition)
        {
            _vdb = new Vdb.EmployeeLeaveSettlementVdb();
            _vdb.Condition = condition;
            dao = new Dao.EmployeeLeaveSettlementDao();
            _vdb.OutEmployeeInfoList = dao.GetOutEmpList(condition.EmployeeIdBegin, condition.EmployeeIdEnd, condition.OutDateBegin, condition.OutDateEnd);
            return _vdb.OutEmployeeInfoList;
        }
        /// <summary>
        /// 產生員工特休剩餘時數及代金資訊
        /// </summary>
        /// <param name="selectedOutEmployeeList"></param>
        /// <returns></returns>
        public List<Vdb.EmployeeLeaveInfo> GenerateEmployeeLeaveInfoList(List<Vdb.OutEmployeeInfo> selectedOutEmployeeList)
        {
            var sql = from a in selectedOutEmployeeList
                      let specialLeaveHours = dao.GetLeaveHours(a, a.OutDate, Dao.EmployeeLeaveSettlementDao.LeaveType.SpecialLeave)
                      let compensatedLeaveHours = dao.GetLeaveHours(a, a.OutDate, Dao.EmployeeLeaveSettlementDao.LeaveType.CompensatedLeave)
                      let optionalLeaveHours = dao.GetLeaveHours(a, a.OutDate, Dao.EmployeeLeaveSettlementDao.LeaveType.OptionalLeave)
                      let baseSalary = dao.GetBaseSalary(a, a.OutDate)
                      let foodSalary = dao.GetFoodSalary(a, a.OutDate)
                      select new Vdb.EmployeeLeaveInfo
                      {
                          EmployeeId = a.EmployeeId,
                          EmployeeName = a.EmployeeName,
                          OutDate = a.OutDate,//=MaxOutDate,
                          SpecialLeaveHours = specialLeaveHours,//= GetLeaveHours(a.NOBR, a.OUDT.Value, LeaveType.SpecialLeave),
                          CompensatedLeaveHours = compensatedLeaveHours,//= GetLeaveHours(a.NOBR, a.OUDT.Value, LeaveType.CompensatedLeave),
                          OptionalLeaveHours = optionalLeaveHours,//= GetLeaveHours(a.NOBR, a.OUDT.Value, LeaveType.OptionalLeave),
                          BaseSalary = baseSalary,
                          FoodSalary = foodSalary,
                          SpecialLeaveBonus = dao.CalcBonus(specialLeaveHours, compensatedLeaveHours, optionalLeaveHours, baseSalary, foodSalary, Dao.EmployeeLeaveSettlementDao.LeaveType.SpecialLeave),
                          CompensatedLeaveBonus = dao.CalcBonus(specialLeaveHours, compensatedLeaveHours, optionalLeaveHours, baseSalary, foodSalary, Dao.EmployeeLeaveSettlementDao.LeaveType.CompensatedLeave),
                          OptionalLeaveBonus = dao.CalcBonus(specialLeaveHours, compensatedLeaveHours, optionalLeaveHours, baseSalary, foodSalary, Dao.EmployeeLeaveSettlementDao.LeaveType.OptionalLeave),
                      };
            //foreach (var it in sql)
            //    it.BaseSalary = 10000;
            //return null;
            _vdb.EmployeeLeaveInfoList = sql.ToList();
            return _vdb.EmployeeLeaveInfoList;

        }
        public int GenerateLeaveToBonus(List<Vdb.EmployeeLeaveInfo> EmployeeLeaveInfoList, string YYMM, string SEQ)
        {
            string SpecialDCode, CompensateHCode, OptionalHCode;
            string SpecialSalCode, CompensateSalCode, OptionalSalCode;
            SpecialDCode = "W4";
            CompensateHCode = "W7";
            OptionalHCode = "W11";
            SpecialSalCode = "H04";
            CompensateSalCode = "H04";
            OptionalSalCode = "H04";
            List<JBModule.Data.Linq.ABS> absList = new List<JBModule.Data.Linq.ABS>();
            List<JBModule.Data.Linq.ENRICH> enrichList = new List<JBModule.Data.Linq.ENRICH>();
            foreach (var it in EmployeeLeaveInfoList)
            {
                JBModule.Data.Linq.ABS abs;
                if (it.SpecialLeaveHours != 0)
                {
                    abs = new JBModule.Data.Linq.ABS();
                    abs.NOBR = it.EmployeeId;
                    abs.A_NAME = "";
                    abs.BDATE = it.OutDate;
                    abs.BTIME = "";
                    abs.EDATE = it.OutDate;
                    abs.ETIME = "";
                    abs.H_CODE = SpecialDCode;
                    abs.KEY_DATE = DateTime.Now;
                    abs.KEY_MAN = MainForm.USER_NAME;
                    abs.NOTE = "FRM4R未休假獎金結轉" + YYMM;
                    abs.NOTEDIT = true;
                    abs.SERNO = "";
                    abs.SYSCREATE = true;
                    abs.TOL_DAY = 0;
                    abs.TOL_HOURS = it.SpecialLeaveHours;
                    abs.YYMM = YYMM;
                    absList.Add(abs);
                }

                if (it.CompensatedLeaveHours != 0)
                {
                    abs = new JBModule.Data.Linq.ABS();
                    abs.NOBR = it.EmployeeId;
                    abs.A_NAME = "";
                    abs.BDATE = it.OutDate;
                    abs.BTIME = "";
                    abs.EDATE = it.OutDate;
                    abs.ETIME = "";
                    abs.H_CODE = CompensateHCode;
                    abs.KEY_DATE = DateTime.Now;
                    abs.KEY_MAN = MainForm.USER_NAME;
                    abs.NOTE = "FRM4R未休假獎金結轉" + YYMM;
                    abs.NOTEDIT = true;
                    abs.SERNO = "";
                    abs.SYSCREATE = true;
                    abs.TOL_DAY = 0;
                    abs.TOL_HOURS = it.CompensatedLeaveHours;
                    abs.YYMM = YYMM;
                    absList.Add(abs);
                }

                if (it.OptionalLeaveHours != 0)
                {
                    abs = new JBModule.Data.Linq.ABS();
                    abs.NOBR = it.EmployeeId;
                    abs.A_NAME = "";
                    abs.BDATE = it.OutDate;
                    abs.BTIME = "";
                    abs.EDATE = it.OutDate;
                    abs.ETIME = "";
                    abs.H_CODE = OptionalHCode;
                    abs.KEY_DATE = DateTime.Now;
                    abs.KEY_MAN = MainForm.USER_NAME;
                    abs.NOTE = "FRM4R未休假獎金結轉" + YYMM;
                    abs.NOTEDIT = true;
                    abs.SERNO = "";
                    abs.SYSCREATE = true;
                    abs.TOL_DAY = 0;
                    abs.TOL_HOURS = it.OptionalLeaveHours;
                    abs.YYMM = YYMM;
                    absList.Add(abs);
                }
                JBModule.Data.Linq.ENRICH enrich;
                if (it.SpecialLeaveBonus != 0)
                {
                    enrich = new JBModule.Data.Linq.ENRICH();
                    enrich.AMT = JBModule.Data.CEncrypt.Number(it.SpecialLeaveBonus);
                    enrich.FA_IDNO = "";
                    enrich.IMPORT = true;
                    enrich.KEY_DATE = DateTime.Now;
                    enrich.KEY_MAN = MainForm.USER_NAME;
                    enrich.MEMO = "FRM4R未休假獎金結轉" + YYMM;
                    enrich.NOBR = it.EmployeeId;
                    enrich.SAL_CODE = SpecialSalCode;
                    enrich.SEQ = SEQ;
                    enrich.YYMM = YYMM;
                    enrichList.Add(enrich);
                }

                if (it.CompensatedLeaveBonus != 0)
                {
                    enrich = new JBModule.Data.Linq.ENRICH();
                    enrich.AMT = JBModule.Data.CEncrypt.Number(it.SpecialLeaveBonus);
                    enrich.FA_IDNO = "";
                    enrich.IMPORT = true;
                    enrich.KEY_DATE = DateTime.Now;
                    enrich.KEY_MAN = MainForm.USER_NAME;
                    enrich.MEMO = "FRM4R未休假獎金結轉" + YYMM;
                    enrich.NOBR = it.EmployeeId;
                    enrich.SAL_CODE = CompensateSalCode;
                    enrich.SEQ = SEQ;
                    enrich.YYMM = YYMM;
                    enrichList.Add(enrich);
                }

                if (it.OptionalLeaveBonus != 0)
                {
                    enrich = new JBModule.Data.Linq.ENRICH();
                    enrich.AMT = JBModule.Data.CEncrypt.Number(it.SpecialLeaveBonus);
                    enrich.FA_IDNO = "";
                    enrich.IMPORT = true;
                    enrich.KEY_DATE = DateTime.Now;
                    enrich.KEY_MAN = MainForm.USER_NAME;
                    enrich.MEMO = "FRM4R未休假獎金結轉" + YYMM;
                    enrich.NOBR = it.EmployeeId;
                    enrich.SAL_CODE = OptionalSalCode;
                    enrich.SEQ = SEQ;
                    enrich.YYMM = YYMM;
                    enrichList.Add(enrich);
                }
            }
            return dao.InsertData(absList, enrichList);
        }
    }
}
