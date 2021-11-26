using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Performance.HunyaCustom.Repository
{
    public class Hunya_PAPersonalAssessmentRepo
    {
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        public List<JBModule.Data.Linq.Hunya_PAPersonalAssessment> GetOverlapHunya_PAPersonalAssessment(Hunya_PAPersonalAssessmentDto PAPersonalAssessmentDto)
        {
            var sql = from a in db.Hunya_PAPersonalAssessment
                      where a.EmployeeID == PAPersonalAssessmentDto.EmployeeID
                      && a.YYMM == PAPersonalAssessmentDto.YYMM
                      select a;
            return sql.ToList();
        }
        public bool InsertHunya_PAPersonalAssessment(Hunya_PAPersonalAssessmentDto PAPersonalAssessmentDto, out string msg)
        {
            msg = "";
            try
            {
                JBModule.Data.Linq.Hunya_PAPersonalAssessment hunya_PAPersonalAssessment = new JBModule.Data.Linq.Hunya_PAPersonalAssessment();
                hunya_PAPersonalAssessment.EmployeeID = PAPersonalAssessmentDto.EmployeeID;
                hunya_PAPersonalAssessment.YYMM = PAPersonalAssessmentDto.YYMM;
                hunya_PAPersonalAssessment.PALevelCode = PAPersonalAssessmentDto.PALevelCode;
                hunya_PAPersonalAssessment.GID = PAPersonalAssessmentDto.GID;
                hunya_PAPersonalAssessment.KeyDate = PAPersonalAssessmentDto.KeyDate;
                hunya_PAPersonalAssessment.KeyMan = PAPersonalAssessmentDto.KeyMan;
                db.Hunya_PAPersonalAssessment.InsertOnSubmit(hunya_PAPersonalAssessment);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateHunya_PAPersonalAssessment(Hunya_PAPersonalAssessmentDto PAPersonalAssessmentDto, out string msg)
        {
            msg = "";
            try
            {
                JBModule.Data.Linq.Hunya_PAPersonalAssessment hunya_PAPersonalAssessment = new JBModule.Data.Linq.Hunya_PAPersonalAssessment();
                hunya_PAPersonalAssessment.EmployeeID = PAPersonalAssessmentDto.EmployeeID;
                hunya_PAPersonalAssessment.YYMM = PAPersonalAssessmentDto.YYMM;
                hunya_PAPersonalAssessment.PALevelCode = PAPersonalAssessmentDto.PALevelCode;
                hunya_PAPersonalAssessment.GID = PAPersonalAssessmentDto.GID;
                hunya_PAPersonalAssessment.KeyDate = PAPersonalAssessmentDto.KeyDate;
                hunya_PAPersonalAssessment.KeyMan = PAPersonalAssessmentDto.KeyMan;
                var PAPersonalAssessment = GetOverlapHunya_PAPersonalAssessment(PAPersonalAssessmentDto);
                if (PAPersonalAssessment.Any())
                {
                    JBModule.Message.DbLog.WriteLog("OverLapUpdate", PAPersonalAssessment, "Import", -1);
                    Hunya_PAPersonalAssessmentRepo.DataSaveRule(PAPersonalAssessment, hunya_PAPersonalAssessment, db);
                }
                JBModule.Message.DbLog.WriteLog("Insert", hunya_PAPersonalAssessment, "Import", hunya_PAPersonalAssessment.AK);
                db.Hunya_PAPersonalAssessment.InsertOnSubmit(hunya_PAPersonalAssessment);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool DeleteHunya_PAPersonalAssessment(Hunya_PAPersonalAssessmentDto PAPersonalAssessmentDto, out string msg)
        {
            msg = "";
            try
            {
                var PAPersonalAssessment = GetOverlapHunya_PAPersonalAssessment(PAPersonalAssessmentDto);
                if (PAPersonalAssessment.Any())
                {
                    db.Hunya_PAPersonalAssessment.DeleteAllOnSubmit(PAPersonalAssessment);
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
        public static void DataSaveRule(List<JBModule.Data.Linq.Hunya_PAPersonalAssessment> instanceRp, JBModule.Data.Linq.Hunya_PAPersonalAssessment instanceNew, JBModule.Data.Linq.HrDBDataContext dbRP)
        {
            foreach (var item in instanceRp)
            {
                if (item.YYMM == instanceNew.YYMM)
                    dbRP.Hunya_PAPersonalAssessment.DeleteOnSubmit(item);
            }
            dbRP.SubmitChanges();
        }
    }
}
