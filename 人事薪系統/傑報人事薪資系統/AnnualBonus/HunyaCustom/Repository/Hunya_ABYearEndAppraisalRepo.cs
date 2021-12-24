using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.AnnualBonus.HunyaCustom.Repository
{
    public class Hunya_ABYearEndAppraisalRepo
    {
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        public List<JBModule.Data.Linq.Hunya_ABYearEndAppraisal> GetOverlapHunya_ABYearEndAppraisal(Hunya_ABYearEndAppraisalDto ABPersonalAppraisalDto)
        {
            var sql = from a in db.Hunya_ABYearEndAppraisal
                      where a.EmployeeID == ABPersonalAppraisalDto.EmployeeID
                      && a.YYYY == ABPersonalAppraisalDto.YYYY
                      select a;
            return sql.ToList();
        }
        public bool InsertHunya_ABYearEndAppraisal(Hunya_ABYearEndAppraisalDto ABPersonalAppraisalDto, out string msg)
        {
            msg = "";
            try
            {
                JBModule.Data.Linq.Hunya_ABYearEndAppraisal Hunya_ABYearEndAppraisal = new JBModule.Data.Linq.Hunya_ABYearEndAppraisal
                {
                    EmployeeID = ABPersonalAppraisalDto.EmployeeID,
                    YYYY = ABPersonalAppraisalDto.YYYY,
                    ABScore = ABPersonalAppraisalDto.ABSocre,
                    ABLevelCode = ABPersonalAppraisalDto.ABLevelCode,
                    RealLevelCode = ABPersonalAppraisalDto.RealLevelCode,
                    GID = ABPersonalAppraisalDto.GID,
                    KeyDate = ABPersonalAppraisalDto.KeyDate,
                    KeyMan = ABPersonalAppraisalDto.KeyMan
                };
                db.Hunya_ABYearEndAppraisal.InsertOnSubmit(Hunya_ABYearEndAppraisal);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateHunya_ABYearEndAppraisal(Hunya_ABYearEndAppraisalDto ABPersonalAppraisalDto, out string msg)
        {
            msg = "";
            try
            {
                JBModule.Data.Linq.Hunya_ABYearEndAppraisal Hunya_ABYearEndAppraisal = new JBModule.Data.Linq.Hunya_ABYearEndAppraisal
                {
                    EmployeeID = ABPersonalAppraisalDto.EmployeeID,
                    YYYY = ABPersonalAppraisalDto.YYYY,
                    ABScore = ABPersonalAppraisalDto.ABSocre,
                    ABLevelCode = ABPersonalAppraisalDto.ABLevelCode,
                    RealLevelCode = ABPersonalAppraisalDto.RealLevelCode,
                    GID = ABPersonalAppraisalDto.GID,
                    KeyDate = ABPersonalAppraisalDto.KeyDate,
                    KeyMan = ABPersonalAppraisalDto.KeyMan
                };
                var ABPersonalAppraisal = GetOverlapHunya_ABYearEndAppraisal(ABPersonalAppraisalDto);
                if (ABPersonalAppraisal.Any())
                {
                    JBModule.Message.DbLog.WriteLog("OverLapUpdate", ABPersonalAppraisal, "Import", -1);
                    Hunya_ABYearEndAppraisalRepo.DataSaveRule(ABPersonalAppraisal, Hunya_ABYearEndAppraisal, db);
                }
                JBModule.Message.DbLog.WriteLog("Insert", Hunya_ABYearEndAppraisal, "Import", Hunya_ABYearEndAppraisal.AK);
                db.Hunya_ABYearEndAppraisal.InsertOnSubmit(Hunya_ABYearEndAppraisal);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool DeleteHunya_ABYearEndAppraisal(Hunya_ABYearEndAppraisalDto ABPersonalAppraisalDto, out string msg)
        {
            msg = "";
            try
            {
                var ABPersonalAppraisal = GetOverlapHunya_ABYearEndAppraisal(ABPersonalAppraisalDto);
                if (ABPersonalAppraisal.Any())
                {
                    db.Hunya_ABYearEndAppraisal.DeleteAllOnSubmit(ABPersonalAppraisal);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public static void DataSaveRule(List<JBModule.Data.Linq.Hunya_ABYearEndAppraisal> instanceRp, JBModule.Data.Linq.Hunya_ABYearEndAppraisal instanceNew, JBModule.Data.Linq.HrDBDataContext dbRP)
        {
            foreach (var item in instanceRp)
            {
                if (item.YYYY == instanceNew.YYYY)
                    dbRP.Hunya_ABYearEndAppraisal.DeleteOnSubmit(item);
            }
            dbRP.SubmitChanges();
        }
    }
}

