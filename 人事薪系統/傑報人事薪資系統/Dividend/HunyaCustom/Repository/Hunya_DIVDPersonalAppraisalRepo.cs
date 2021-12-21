using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Dividend.HunyaCustom.Repository
{
    public class Hunya_DIVDPersonalAppraisalRepo
    {
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        public List<JBModule.Data.Linq.Hunya_DIVDPersonalAppraisal> GetOverlapHunya_DIVDPersonalAppraisal(Hunya_DIVDPersonalAppraisalDto PAPersonalAssessmentDto)
        {
            var sql = from a in db.Hunya_DIVDPersonalAppraisal
                      where a.EmployeeID == PAPersonalAssessmentDto.EmployeeID
                      && a.YYYY == PAPersonalAssessmentDto.YYYY
                      select a;
            return sql.ToList();
        }
        public bool InsertHunya_DIVDPersonalAppraisal(Hunya_DIVDPersonalAppraisalDto PAPersonalAssessmentDto, out string msg)
        {
            msg = "";
            try
            {
                JBModule.Data.Linq.Hunya_DIVDPersonalAppraisal Hunya_DIVDPersonalAppraisal = new JBModule.Data.Linq.Hunya_DIVDPersonalAppraisal
                {
                    EmployeeID = PAPersonalAssessmentDto.EmployeeID,
                    YYYY = PAPersonalAssessmentDto.YYYY,
                    DIVDAppraisalCode = PAPersonalAssessmentDto.DIVDAppraisalCode,
                    GID = PAPersonalAssessmentDto.GID,
                    KeyDate = PAPersonalAssessmentDto.KeyDate,
                    KeyMan = PAPersonalAssessmentDto.KeyMan
                };
                db.Hunya_DIVDPersonalAppraisal.InsertOnSubmit(Hunya_DIVDPersonalAppraisal);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateHunya_DIVDPersonalAppraisal(Hunya_DIVDPersonalAppraisalDto PAPersonalAssessmentDto, out string msg)
        {
            msg = "";
            try
            {
                JBModule.Data.Linq.Hunya_DIVDPersonalAppraisal Hunya_DIVDPersonalAppraisal = new JBModule.Data.Linq.Hunya_DIVDPersonalAppraisal
                {
                    EmployeeID = PAPersonalAssessmentDto.EmployeeID,
                    YYYY = PAPersonalAssessmentDto.YYYY,
                    DIVDAppraisalCode = PAPersonalAssessmentDto.DIVDAppraisalCode,
                    GID = PAPersonalAssessmentDto.GID,
                    KeyDate = PAPersonalAssessmentDto.KeyDate,
                    KeyMan = PAPersonalAssessmentDto.KeyMan
                };
                var PAPersonalAssessment = GetOverlapHunya_DIVDPersonalAppraisal(PAPersonalAssessmentDto);
                if (PAPersonalAssessment.Any())
                {
                    JBModule.Message.DbLog.WriteLog("OverLapUpdate", PAPersonalAssessment, "Import", -1);
                    Hunya_DIVDPersonalAppraisalRepo.DataSaveRule(PAPersonalAssessment, Hunya_DIVDPersonalAppraisal, db);
                }
                JBModule.Message.DbLog.WriteLog("Insert", Hunya_DIVDPersonalAppraisal, "Import", Hunya_DIVDPersonalAppraisal.AK);
                db.Hunya_DIVDPersonalAppraisal.InsertOnSubmit(Hunya_DIVDPersonalAppraisal);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool DeleteHunya_DIVDPersonalAppraisal(Hunya_DIVDPersonalAppraisalDto PAPersonalAssessmentDto, out string msg)
        {
            msg = "";
            try
            {
                var PAPersonalAssessment = GetOverlapHunya_DIVDPersonalAppraisal(PAPersonalAssessmentDto);
                if (PAPersonalAssessment.Any())
                {
                    db.Hunya_DIVDPersonalAppraisal.DeleteAllOnSubmit(PAPersonalAssessment);
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
        public static void DataSaveRule(List<JBModule.Data.Linq.Hunya_DIVDPersonalAppraisal> instanceRp, JBModule.Data.Linq.Hunya_DIVDPersonalAppraisal instanceNew, JBModule.Data.Linq.HrDBDataContext dbRP)
        {
            foreach (var item in instanceRp)
            {
                if (item.YYYY == instanceNew.YYYY)
                    dbRP.Hunya_DIVDPersonalAppraisal.DeleteOnSubmit(item);
            }
            dbRP.SubmitChanges();
        }
    }
}
