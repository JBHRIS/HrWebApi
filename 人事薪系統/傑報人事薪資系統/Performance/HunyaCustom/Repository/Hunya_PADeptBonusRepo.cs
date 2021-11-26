using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Performance.HunyaCustom.Repository
{
    public class Hunya_PADeptBonusRepo
    {
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        public List<JBModule.Data.Linq.Hunya_PADeptBonus> GetOverlapHunya_PADeptBonus(Hunya_PADeptBonusDto PADeptBonusDto)
        {
            var sql = from a in db.Hunya_PADeptBonus
                      where a.PADept == PADeptBonusDto.PADept
                      && a.YYMM_B.CompareTo(PADeptBonusDto.YYMM_E) <= 0 && a.YYMM_E.CompareTo(PADeptBonusDto.YYMM_B) >= 0
                      select a;
            return sql.ToList();
        }
        public bool InsertHunya_PADeptBonus(Hunya_PADeptBonusDto PADeptBonusDto, out string msg)
        {
            msg = "";
            try
            {
                JBModule.Data.Linq.Hunya_PADeptBonus hunya_PADeptBonus = new JBModule.Data.Linq.Hunya_PADeptBonus();
                hunya_PADeptBonus.PADept = PADeptBonusDto.PADept;
                hunya_PADeptBonus.YYMM_B = PADeptBonusDto.YYMM_B;
                hunya_PADeptBonus.YYMM_E = PADeptBonusDto.YYMM_E;
                hunya_PADeptBonus.PABasicBonus = PADeptBonusDto.PABasicBonus;
                hunya_PADeptBonus.GID = PADeptBonusDto.GID;
                hunya_PADeptBonus.KeyDate = PADeptBonusDto.KeyDate;
                hunya_PADeptBonus.KeyMan = PADeptBonusDto.KeyMan;
                db.Hunya_PADeptBonus.InsertOnSubmit(hunya_PADeptBonus);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateHunya_PADeptBonus(Hunya_PADeptBonusDto PADeptBonusDto, out string msg)
        {
            msg = "";
            try
            {
                JBModule.Data.Linq.Hunya_PADeptBonus hunya_PADeptBonus = new JBModule.Data.Linq.Hunya_PADeptBonus();
                hunya_PADeptBonus.PADept = PADeptBonusDto.PADept;
                hunya_PADeptBonus.YYMM_B = PADeptBonusDto.YYMM_B;
                hunya_PADeptBonus.YYMM_E = PADeptBonusDto.YYMM_E;
                hunya_PADeptBonus.PABasicBonus = PADeptBonusDto.PABasicBonus;
                hunya_PADeptBonus.GID = PADeptBonusDto.GID;
                hunya_PADeptBonus.KeyDate = PADeptBonusDto.KeyDate;
                hunya_PADeptBonus.KeyMan = PADeptBonusDto.KeyMan;
                var PADeptBonus = GetOverlapHunya_PADeptBonus(PADeptBonusDto);
                if (PADeptBonus.Any())
                {
                    JBModule.Message.DbLog.WriteLog("OverLapUpdate", PADeptBonus, "Import", -1);
                    Hunya_PADeptBonusRepo.DataSaveRule(PADeptBonus, hunya_PADeptBonus, db);
                }
                JBModule.Message.DbLog.WriteLog("Insert", hunya_PADeptBonus, "Import", hunya_PADeptBonus.AK);
                db.Hunya_PADeptBonus.InsertOnSubmit(hunya_PADeptBonus);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool DeleteHunya_PADeptBonus(Hunya_PADeptBonusDto PADeptBonusDto, out string msg)
        {
            msg = "";
            try
            {
                var PADeptBonus = GetOverlapHunya_PADeptBonus(PADeptBonusDto);
                if (PADeptBonus.Any())
                {
                    db.Hunya_PADeptBonus.DeleteAllOnSubmit(PADeptBonus);
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
        public static void DataSaveRule(List<JBModule.Data.Linq.Hunya_PADeptBonus> instanceRp, JBModule.Data.Linq.Hunya_PADeptBonus instanceNew, JBModule.Data.Linq.HrDBDataContext dbRP)
        {
            foreach (var item in instanceRp)
            {
                //int Old_Year_E = int.Parse(item.YYMM_E.Substring(0, 4));
                //int Old_Month_E = int.Parse(item.YYMM_E.Substring(4, 2));
                int NEW_Year_B = int.Parse(instanceNew.YYMM_B.Substring(0, 4));
                int NEW_Month_B = int.Parse(instanceNew.YYMM_B.Substring(4, 2));
                //int Old_Year_B = int.Parse(item.YYMM_B.Substring(0, 4));
                //int Old_Month_B = int.Parse(item.YYMM_B.Substring(4, 2));
                int NEW_Year_E = int.Parse(instanceNew.YYMM_E.Substring(0, 4));
                int NEW_Month_E = int.Parse(instanceNew.YYMM_E.Substring(4, 2));

                if (instanceNew.YYMM_B.CompareTo(item.YYMM_B) > 0 && instanceNew.YYMM_E.CompareTo(item.YYMM_E) >= 0)
                    item.YYMM_E = new DateTime(NEW_Year_B, NEW_Month_B, 1).AddMonths(-1).ToString("yyyyMM");
                else if (instanceNew.YYMM_B.CompareTo(item.YYMM_B) <= 0 && instanceNew.YYMM_E.CompareTo(item.YYMM_E) < 0)
                    item.YYMM_B = new DateTime(NEW_Year_E, NEW_Month_E, 1).AddMonths(1).ToString("yyyyMM");
                else if (instanceNew.YYMM_B.CompareTo(item.YYMM_B) <= 0 && instanceNew.YYMM_E.CompareTo(item.YYMM_E) >= 0)
                    dbRP.Hunya_PADeptBonus.DeleteOnSubmit(item);
                else
                {
                    JBModule.Data.Linq.Hunya_PADeptBonus instance2 = new JBModule.Data.Linq.Hunya_PADeptBonus
                    {
                        PADept = instanceNew.PADept,
                        YYMM_B = new DateTime(NEW_Year_E, NEW_Month_E, 1).AddMonths(1).ToString("yyyyMM"),
                        YYMM_E = item.YYMM_E,
                        PABasicBonus = item.PABasicBonus,
                        GID = Guid.NewGuid(),
                        KeyMan = MainForm.USER_NAME,
                        KeyDate = DateTime.Now,
                    };
                    dbRP.Hunya_PADeptBonus.InsertOnSubmit(instance2);
                    item.YYMM_E = new DateTime(NEW_Year_B, NEW_Month_B, 1).AddMonths(-1).ToString("yyyyMM");
                }
            }
            dbRP.SubmitChanges();
        }
    }
}
