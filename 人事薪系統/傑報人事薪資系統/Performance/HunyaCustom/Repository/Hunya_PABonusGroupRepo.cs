using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Performance.HunyaCustom.Repository
{
    public class Hunya_PABonusGroupRepo
    {
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        public List<JBModule.Data.Linq.Hunya_PABonusGroup> GetOverlapHunya_PABonusGroup(Hunya_PABonusGroupDto PABonusGroupDto)
        {
            var sql = from a in db.Hunya_PABonusGroup
                      where a.EmployeeID == PABonusGroupDto.EmployeeID
                      && a.YYMM_B.CompareTo(PABonusGroupDto.YYMM_E) <= 0 && a.YYMM_E.CompareTo(PABonusGroupDto.YYMM_B) >= 0
                      select a;
            return sql.ToList();
        }
        public bool InsertHunya_PABonusGroup(Hunya_PABonusGroupDto PABonusGroupDto, out string msg)
        {
            msg = "";
            try
            {
                JBModule.Data.Linq.Hunya_PABonusGroup hunya_PABonusGroup = new JBModule.Data.Linq.Hunya_PABonusGroup();
                hunya_PABonusGroup.EmployeeID = PABonusGroupDto.EmployeeID;
                hunya_PABonusGroup.YYMM_B = PABonusGroupDto.YYMM_B;
                hunya_PABonusGroup.YYMM_E = PABonusGroupDto.YYMM_E;
                hunya_PABonusGroup.PAGroupCode = PABonusGroupDto.PAGroupCode;
                hunya_PABonusGroup.GID = PABonusGroupDto.GID;
                hunya_PABonusGroup.KeyDate = PABonusGroupDto.KeyDate;
                hunya_PABonusGroup.KeyMan = PABonusGroupDto.KeyMan;
                db.Hunya_PABonusGroup.InsertOnSubmit(hunya_PABonusGroup);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateHunya_PABonusGroup(Hunya_PABonusGroupDto PABonusGroupDto, out string msg)
        {
            msg = "";
            try
            {
                JBModule.Data.Linq.Hunya_PABonusGroup hunya_PABonusGroup = new JBModule.Data.Linq.Hunya_PABonusGroup();
                hunya_PABonusGroup.EmployeeID = PABonusGroupDto.EmployeeID;
                hunya_PABonusGroup.YYMM_B = PABonusGroupDto.YYMM_B;
                hunya_PABonusGroup.YYMM_E = PABonusGroupDto.YYMM_E;
                hunya_PABonusGroup.PAGroupCode = PABonusGroupDto.PAGroupCode;
                hunya_PABonusGroup.GID = PABonusGroupDto.GID;
                hunya_PABonusGroup.KeyDate = PABonusGroupDto.KeyDate;
                hunya_PABonusGroup.KeyMan = PABonusGroupDto.KeyMan;
                var PABonusGroup = GetOverlapHunya_PABonusGroup(PABonusGroupDto);
                if (PABonusGroup.Any())
                {
                    JBModule.Message.DbLog.WriteLog("OverLapUpdate", PABonusGroup, "Import", -1);
                    Hunya_PABonusGroupRepo.DataSaveRule(PABonusGroup, hunya_PABonusGroup, db);
                }
                JBModule.Message.DbLog.WriteLog("Insert", hunya_PABonusGroup, "Import", hunya_PABonusGroup.AK);
                db.Hunya_PABonusGroup.InsertOnSubmit(hunya_PABonusGroup);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool DeleteHunya_PABonusGroup(Hunya_PABonusGroupDto PABonusGroupDto, out string msg)
        {
            msg = "";
            try
            {
                var PABonusGroup = GetOverlapHunya_PABonusGroup(PABonusGroupDto);
                if (PABonusGroup.Any())
                {
                    db.Hunya_PABonusGroup.DeleteAllOnSubmit(PABonusGroup);
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

        public static void DataSaveRule(List<JBModule.Data.Linq.Hunya_PABonusGroup> instanceRp, JBModule.Data.Linq.Hunya_PABonusGroup instanceNew, JBModule.Data.Linq.HrDBDataContext dbRP)
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
                    dbRP.Hunya_PABonusGroup.DeleteOnSubmit(item);
                else
                {
                    JBModule.Data.Linq.Hunya_PABonusGroup instance2 = new JBModule.Data.Linq.Hunya_PABonusGroup
                    {
                        EmployeeID = instanceNew.EmployeeID,
                        YYMM_B = new DateTime(NEW_Year_E, NEW_Month_E, 1).AddMonths(1).ToString("yyyyMM"),
                        YYMM_E = item.YYMM_E,
                        PAGroupCode = item.PAGroupCode,
                        GID = Guid.NewGuid(),
                        KeyMan = MainForm.USER_NAME,
                        KeyDate = DateTime.Now,
                    };
                    dbRP.Hunya_PABonusGroup.InsertOnSubmit(instance2);
                    item.YYMM_E = new DateTime(NEW_Year_B, NEW_Month_B, 1).AddMonths(-1).ToString("yyyyMM");
                }
            }
            dbRP.SubmitChanges();
        }
    }
}
