using JBModule.Data.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JBHR2Service.KCR_Custom.Meal
{
    public class KCR_MealGenerator
    {
        public List<KCR_MealApplySettingEntry> KCR_GetMealApplySettingByEmpID(string EmployeeID, DateTime ADate)
        {
            List<KCR_MealApplySettingEntry> MealApplySettingList = new List<KCR_MealApplySettingEntry>();
            HrDBDataContext db = new HrDBDataContext();
            var MealGroup = db.GetUserDefineValue("MealGroup", EmployeeID, String.Empty);
            if (!string.IsNullOrEmpty(MealGroup))
            {
                JBModule.Message.TextLog.WriteLog(String.Format("{0}取得用餐設定.", EmployeeID));
                try
                {
                    var Sql = (from MAS in db.KCR_MealApplySetting
                               join MT in db.MealType on new { MAS.MealGroup, MAS.MealType } equals new { MT.MealGroup, MealType = MT.MealType_Code }
                               where MAS.EmployeeID == EmployeeID
                               && MAS.ADate.CompareTo(ADate) <= 0 && MAS.DDate.CompareTo(ADate) >= 0
                               orderby MT.BTime
                               select new
                               {
                                   MAS.AutoKey,
                                   MAS.GID,
                                   MAS.EmployeeID,
                                   MAS.MealGroup,
                                   MAS.MealType,
                                   MT.BTime,
                                   MAS.ApplyFlag,
                                   MAS.HoliMealFlag,
                                   MAS.ADate,
                                   MAS.DDate,
                                   MAS.Note,
                                   MAS.Key_Man,
                                   MAS.Key_Date,
                               });
                    var ApplySettingList = Sql.ToList();
                    var EmpDataSql = (from bts in db.BASETTS
                                      join b in db.BASE on bts.NOBR equals b.NOBR
                                      join h in db.HOLICD on bts.HOLI_CODE equals h.HOLI_CODE
                                      from holi in (
                                         from ho in db.HOLI
                                         join o in db.OTHCODE on ho.OTHCODE equals o.OTHCODE1
                                         where o.STDHOLI || o.OTHHOLI
                                         select ho
                                      ).Where(p => p.H_DATE == ADate).DefaultIfEmpty()
                                      where bts.NOBR == EmployeeID
                                      && bts.ADATE.CompareTo(ADate) <= 0 && bts.DDATE.Value.CompareTo(ADate) >= 0
                                      select new { Basetts = bts, Base = b, holi });
                    bool HoliMealflag = EmpDataSql.First().holi != null;
                    if (ApplySettingList.Any() && ApplySettingList.Where(p => p.HoliMealFlag == HoliMealflag).Any())
                    {
                        foreach (var ApplySetting in ApplySettingList.Where(p => p.HoliMealFlag == HoliMealflag))
                        {
                            MealApplySettingList.Add(new KCR_MealApplySettingEntry
                            {
                                AutoKey = ApplySetting.AutoKey,
                                GID = ApplySetting.GID,
                                EmployeeID = ApplySetting.EmployeeID,
                                MealGroup = ApplySetting.MealGroup,
                                MealType = ApplySetting.MealType,
                                BTime = ApplySetting.BTime,
                                ApplyFlag = ApplySetting.ApplyFlag,
                                HoliMealFlag = ApplySetting.HoliMealFlag,
                                ADate = ApplySetting.ADate,
                                DDate = ApplySetting.DDate,
                                Note = ApplySetting.Note,
                                Key_Man = ApplySetting.Key_Man,
                                Key_Date = ApplySetting.Key_Date,
                            });
                        }
                    }
                    else
                    {
                        var MealTypeSQL = from m in db.MealType
                                          where m.MealGroup == MealGroup
                                          select m;
                        var MealTypeList = MealTypeSQL.ToList();
                        var UserDefineValueList = db.GetUserDefineValueList("MealType_Holi").ToList();
                        var FinalMealTypeList = (from m in MealTypeList
                                                 join udv in UserDefineValueList on string.Format("{0},{1}", m.MealType_Code, m.MealGroup) equals udv.Code into udv1
                                                 from udv in udv1.DefaultIfEmpty()
                                                 where (udv != null ? bool.Parse(udv.Value) : false) == HoliMealflag
                                                 select m).ToList();
                        for (int i = 0; i < FinalMealTypeList.Count; i++)
                        {
                            MealApplySettingList.Add(new KCR_MealApplySettingEntry
                            {
                                AutoKey = -1,
                                GID = Guid.NewGuid(),
                                EmployeeID = EmployeeID,
                                MealGroup = MealGroup,
                                MealType = FinalMealTypeList[i].MealType_Code,
                                BTime = FinalMealTypeList[i].BTime,
                                ApplyFlag = (HoliMealflag ? (i == 0 ? true : false) : true),
                                HoliMealFlag = HoliMealflag,
                                ADate = ADate,
                                DDate = new DateTime(9999, 12, 31),
                                Note = String.Empty,
                                Key_Man = EmpDataSql.First().Base.NAME_C,
                                Key_Date = DateTime.Now,
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    JBModule.Message.TextLog.WriteLog(ex, String.Format("{0}取得{1}用餐設定異常.", EmployeeID, ADate));
                }
            }
            else
                JBModule.Message.TextLog.WriteLog(String.Format("{0}無設定用餐群組.", EmployeeID));

            return MealApplySettingList;
        }

        public KCR_MealResult KCR_UpdateMealApplySettingByEmpID(List<KCR_MealApplySettingEntry> MealApplySettingList)
        {
            KCR_MealResult result = new KCR_MealResult();
            HrDBDataContext db = new HrDBDataContext();
            JBModule.Message.TextLog.WriteLog(String.Format("{0}修改用餐設定.",MealApplySettingList[0].Key_Man) ,MealApplySettingList);
            try
            {
                var ApplySettingFullSQL = from a in db.KCR_MealApplySetting
                                          where a.EmployeeID == MealApplySettingList[0].EmployeeID
                                          && a.ADate.CompareTo(MealApplySettingList[0].ADate) <= 0
                                          && a.DDate.CompareTo(MealApplySettingList[0].ADate) >= 0
                                          select a;
                var ApplySettingFullList = ApplySettingFullSQL.ToList();
                foreach (var MealApplySetting in MealApplySettingList)
                {
                    var ApplySettingSQL = from a in ApplySettingFullList
                                          where a.MealGroup.CompareTo(MealApplySetting.MealGroup) == 0
                                          && a.MealType.CompareTo(MealApplySetting.MealType) == 0
                                          select a;
                    var ApplySetting = ApplySettingSQL.FirstOrDefault();
                    if (ApplySetting != null)
                    {
                        if (ApplySetting.GID.CompareTo(MealApplySetting.GID) == 0 && ApplySetting.ADate.CompareTo(MealApplySetting.ADate) == 0)
                        {
                            ApplySetting.ApplyFlag = MealApplySetting.ApplyFlag;
                            ApplySetting.Key_Man = MealApplySetting.Key_Man;
                            ApplySetting.Key_Date = MealApplySetting.Key_Date;
                        }
                        else
                        {
                            KCR_MealApplySetting instance = new KCR_MealApplySetting
                            {
                                //AutoKey = MealApplySetting.AutoKey,
                                GID = Guid.NewGuid(),//MealApplySetting.GID,
                                EmployeeID = MealApplySetting.EmployeeID,
                                MealGroup = MealApplySetting.MealGroup,
                                MealType = MealApplySetting.MealType,
                                ApplyFlag = MealApplySetting.ApplyFlag,
                                HoliMealFlag = MealApplySetting.HoliMealFlag,
                                ADate = MealApplySetting.ADate,
                                DDate = ApplySetting.DDate,
                                Note = MealApplySetting.Note,
                                Key_Man = MealApplySetting.Key_Man,
                                Key_Date = MealApplySetting.Key_Date,
                            };
                            ApplySetting.DDate = MealApplySetting.ADate.AddDays(-1);
                            db.KCR_MealApplySetting.InsertOnSubmit(instance);
                        }
                    }
                    else
                    {
                        KCR_MealApplySetting instance = new KCR_MealApplySetting
                        {
                            //AutoKey = MealApplySetting.AutoKey,
                            GID = MealApplySetting.GID,
                            EmployeeID = MealApplySetting.EmployeeID,
                            MealGroup = MealApplySetting.MealGroup,
                            MealType = MealApplySetting.MealType,
                            ApplyFlag = MealApplySetting.ApplyFlag,
                            HoliMealFlag = MealApplySetting.HoliMealFlag,
                            ADate = MealApplySetting.ADate,
                            DDate = new DateTime(9999,12,31),
                            Note = MealApplySetting.Note,
                            Key_Man = MealApplySetting.Key_Man,
                            Key_Date = MealApplySetting.Key_Date,
                        };
                        db.KCR_MealApplySetting.InsertOnSubmit(instance);
                    }
                }
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                JBModule.Message.TextLog.WriteLog(ex, String.Format("{0}修改用餐設定異常.", MealApplySettingList[0].Key_Man), MealApplySettingList);
                result.ErrorMsg = ex.Message;
                result.StackTrace = ex.StackTrace;
            }
            return result;
        }
    }
}