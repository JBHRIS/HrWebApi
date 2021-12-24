using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.AnnualBonus.HunyaCustom.Repository
{
    public class Hunya_ABPersonalBonusRepo
    {
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        public List<JBModule.Data.Linq.Hunya_ABPersonalBonus> GetOverlapHunya_ABPersonalBonus(Hunya_ABPersonalBonusDto ABPersonalAppraisalDto)
        {
            var sql = from a in db.Hunya_ABPersonalBonus
                      where a.EmployeeID == ABPersonalAppraisalDto.EmployeeID
                      && a.YYYY == ABPersonalAppraisalDto.YYYY
                      select a;
            return sql.ToList();
        }
        public bool InsertHunya_ABPersonalBonus(Hunya_ABPersonalBonusDto ABPersonalAppraisalDto, out string msg)
        {
            msg = "";
            try
            {
                JBModule.Data.Linq.Hunya_ABPersonalBonus Hunya_ABPersonalBonus = new JBModule.Data.Linq.Hunya_ABPersonalBonus
                {
                    EmployeeID = ABPersonalAppraisalDto.EmployeeID,
                    YYYY = ABPersonalAppraisalDto.YYYY,
                    DailySalary = ABPersonalAppraisalDto.DailySalary,
                    BonusDays = ABPersonalAppraisalDto.BonusDays,
                    MeritDays = ABPersonalAppraisalDto.MeritDays,
                    BonusRate = ABPersonalAppraisalDto.BonusRate,
                    OnJobDays = ABPersonalAppraisalDto.OnJobDays,
                    Amount = ABPersonalAppraisalDto.Amount,
                    GID = ABPersonalAppraisalDto.GID,
                    KeyDate = ABPersonalAppraisalDto.KeyDate,
                    KeyMan = ABPersonalAppraisalDto.KeyMan
                };
                db.Hunya_ABPersonalBonus.InsertOnSubmit(Hunya_ABPersonalBonus);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateHunya_ABPersonalBonus(Hunya_ABPersonalBonusDto ABPersonalAppraisalDto, out string msg)
        {
            msg = "";
            try
            {
                JBModule.Data.Linq.Hunya_ABPersonalBonus Hunya_ABPersonalBonus = new JBModule.Data.Linq.Hunya_ABPersonalBonus
                {
                    EmployeeID = ABPersonalAppraisalDto.EmployeeID,
                    YYYY = ABPersonalAppraisalDto.YYYY,
                    DailySalary = ABPersonalAppraisalDto.DailySalary,
                    BonusDays = ABPersonalAppraisalDto.BonusDays,
                    MeritDays = ABPersonalAppraisalDto.MeritDays,
                    BonusRate = ABPersonalAppraisalDto.BonusRate,
                    OnJobDays = ABPersonalAppraisalDto.OnJobDays,
                    Amount = ABPersonalAppraisalDto.Amount,
                    GID = ABPersonalAppraisalDto.GID,
                    KeyDate = ABPersonalAppraisalDto.KeyDate,
                    KeyMan = ABPersonalAppraisalDto.KeyMan
                };
                var ABPersonalAppraisal = GetOverlapHunya_ABPersonalBonus(ABPersonalAppraisalDto);
                if (ABPersonalAppraisal.Any())
                {
                    JBModule.Message.DbLog.WriteLog("OverLapUpdate", ABPersonalAppraisal, "Import", -1);
                    Hunya_ABPersonalBonusRepo.DataSaveRule(ABPersonalAppraisal, Hunya_ABPersonalBonus, db);
                }
                JBModule.Message.DbLog.WriteLog("Insert", Hunya_ABPersonalBonus, "Import", Hunya_ABPersonalBonus.AK);
                db.Hunya_ABPersonalBonus.InsertOnSubmit(Hunya_ABPersonalBonus);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool DeleteHunya_ABPersonalBonus(Hunya_ABPersonalBonusDto ABPersonalAppraisalDto, out string msg)
        {
            msg = "";
            try
            {
                var ABPersonalAppraisal = GetOverlapHunya_ABPersonalBonus(ABPersonalAppraisalDto);
                if (ABPersonalAppraisal.Any())
                {
                    db.Hunya_ABPersonalBonus.DeleteAllOnSubmit(ABPersonalAppraisal);
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
        public static void DataSaveRule(List<JBModule.Data.Linq.Hunya_ABPersonalBonus> instanceRp, JBModule.Data.Linq.Hunya_ABPersonalBonus instanceNew, JBModule.Data.Linq.HrDBDataContext dbRP)
        {
            foreach (var item in instanceRp)
            {
                if (item.YYYY == instanceNew.YYYY)
                    dbRP.Hunya_ABPersonalBonus.DeleteOnSubmit(item);
            }
            dbRP.SubmitChanges();
        }
    }
}
