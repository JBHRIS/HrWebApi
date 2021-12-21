using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.AnnualBonus.HunyaCustom.Repository
{
    public class Hunya_ABPersonalAppraisalRepo
    {
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        public List<JBModule.Data.Linq.Hunya_ABPersonalAppraisal> GetOverlapHunya_ABPersonalAppraisal(Hunya_ABPersonalAppraisalDto ABPersonalAppraisalDto)
        {
            var sql = from a in db.Hunya_ABPersonalAppraisal
                      where a.EmployeeID == ABPersonalAppraisalDto.EmployeeID
                      && a.YYYY == ABPersonalAppraisalDto.YYYY
                      && a.ABTypeCode == ABPersonalAppraisalDto.ABTypeCode
                      select a;
            return sql.ToList();
        }
        public bool InsertHunya_ABPersonalAppraisal(Hunya_ABPersonalAppraisalDto ABPersonalAppraisalDto, out string msg)
        {
            msg = "";
            try
            {
                JBModule.Data.Linq.Hunya_ABPersonalAppraisal hunya_ABPersonalAppraisal = new JBModule.Data.Linq.Hunya_ABPersonalAppraisal
                {
                    EmployeeID = ABPersonalAppraisalDto.EmployeeID,
                    YYYY = ABPersonalAppraisalDto.YYYY,
                    ABTypeCode = ABPersonalAppraisalDto.ABTypeCode,
                    ABScore = ABPersonalAppraisalDto.ABSocre,
                    ABLevelCode = ABPersonalAppraisalDto.ABLevelCode,
                    GID = ABPersonalAppraisalDto.GID,
                    KeyDate = ABPersonalAppraisalDto.KeyDate,
                    KeyMan = ABPersonalAppraisalDto.KeyMan
                };
                db.Hunya_ABPersonalAppraisal.InsertOnSubmit(hunya_ABPersonalAppraisal);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateHunya_ABPersonalAppraisal(Hunya_ABPersonalAppraisalDto ABPersonalAppraisalDto, out string msg)
        {
            msg = "";
            try
            {
                JBModule.Data.Linq.Hunya_ABPersonalAppraisal hunya_ABPersonalAppraisal = new JBModule.Data.Linq.Hunya_ABPersonalAppraisal
                {
                    EmployeeID = ABPersonalAppraisalDto.EmployeeID,
                    YYYY = ABPersonalAppraisalDto.YYYY,
                    ABTypeCode = ABPersonalAppraisalDto.ABTypeCode,
                    ABScore = ABPersonalAppraisalDto.ABSocre,
                    ABLevelCode = ABPersonalAppraisalDto.ABLevelCode,
                    GID = ABPersonalAppraisalDto.GID,
                    KeyDate = ABPersonalAppraisalDto.KeyDate,
                    KeyMan = ABPersonalAppraisalDto.KeyMan
                };
                var ABPersonalAppraisal = GetOverlapHunya_ABPersonalAppraisal(ABPersonalAppraisalDto);
                if (ABPersonalAppraisal.Any())
                {
                    JBModule.Message.DbLog.WriteLog("OverLapUpdate", ABPersonalAppraisal, "Import", -1);
                    Hunya_ABPersonalAppraisalRepo.DataSaveRule(ABPersonalAppraisal, hunya_ABPersonalAppraisal, db);
                }
                JBModule.Message.DbLog.WriteLog("Insert", hunya_ABPersonalAppraisal, "Import", hunya_ABPersonalAppraisal.AK);
                db.Hunya_ABPersonalAppraisal.InsertOnSubmit(hunya_ABPersonalAppraisal);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool DeleteHunya_ABPersonalAppraisal(Hunya_ABPersonalAppraisalDto ABPersonalAppraisalDto, out string msg)
        {
            msg = "";
            try
            {
                var ABPersonalAppraisal = GetOverlapHunya_ABPersonalAppraisal(ABPersonalAppraisalDto);
                if (ABPersonalAppraisal.Any())
                {
                    db.Hunya_ABPersonalAppraisal.DeleteAllOnSubmit(ABPersonalAppraisal);
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
        public static void DataSaveRule(List<JBModule.Data.Linq.Hunya_ABPersonalAppraisal> instanceRp, JBModule.Data.Linq.Hunya_ABPersonalAppraisal instanceNew, JBModule.Data.Linq.HrDBDataContext dbRP)
        {
            foreach (var item in instanceRp)
            {
                if (item.YYYY == instanceNew.YYYY && item.ABTypeCode == instanceNew.ABTypeCode)
                    dbRP.Hunya_ABPersonalAppraisal.DeleteOnSubmit(item);
            }
            dbRP.SubmitChanges();
        }
    }
}
