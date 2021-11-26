using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class SCHLRepo
    {
        Linq.HrDBDataContext db = new Linq.HrDBDataContext();
        public Linq.SCHL GetOverlapSCHL(Dto.SCHLDto sCHLDto)
        {
            var sql = from a in db.SCHL
                      where a.NOBR == sCHLDto.NOBR
                      && a.EDUCCODE == sCHLDto.EDUCCODE
                      && a.ADATE == sCHLDto.ADATE
                      select a;
            return sql.FirstOrDefault();
        }
        public bool InsertSCHL(Dto.SCHLDto sCHLDto, out string msg)
        {
            msg = "";
            try
            {
                Linq.SCHL sCHL = new Linq.SCHL();
                sCHL.NOBR = sCHLDto.NOBR;
                sCHL.SCHL1 = sCHLDto.SCHL;
                sCHL.EDUCCODE = sCHLDto.EDUCCODE;
                sCHL.SUBJ = sCHLDto.SUBJ;
                sCHL.SUBJ_DETAIL = sCHLDto.SUBJ_DETAIL;
                sCHL.ADATE = sCHLDto.ADATE;
                sCHL.DATE_B = sCHLDto.DATE_B;
                sCHL.DATE_E = sCHLDto.DATE_E;
                sCHL.OK = sCHLDto.OK;
                sCHL.Graduated = sCHLDto.Graduated;
                sCHL.DayOrNight = sCHLDto.DayOrNight;
                sCHL.MEMO = sCHLDto.MEMO;
                sCHL.SUBJCODE = "";
                sCHL.schl_id = 0;
                sCHL.KEY_DATE = sCHLDto.KEY_DATE;
                sCHL.KEY_MAN = sCHLDto.KEY_MAN;
                db.SCHL.InsertOnSubmit(sCHL);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateSCHL(Dto.SCHLDto sCHLDto, out string msg)
        {
            msg = "";
            try
            {
                var sCHL = GetOverlapSCHL(sCHLDto);
                if (sCHL != null)
                {
                    sCHL.NOBR = sCHLDto.NOBR;
                    sCHL.SCHL1 = sCHLDto.SCHL;
                    sCHL.EDUCCODE = sCHLDto.EDUCCODE;
                    sCHL.SUBJ = sCHLDto.SUBJ;
                    sCHL.SUBJ_DETAIL = sCHLDto.SUBJ_DETAIL;
                    sCHL.ADATE = sCHLDto.ADATE;
                    sCHL.DATE_B = sCHLDto.DATE_B;
                    sCHL.DATE_E = sCHLDto.DATE_E;
                    sCHL.OK = sCHLDto.OK;
                    sCHL.Graduated = sCHLDto.Graduated;
                    sCHL.DayOrNight = sCHLDto.DayOrNight;
                    sCHL.MEMO = sCHLDto.MEMO;
                    sCHL.KEY_DATE = sCHLDto.KEY_DATE;
                    sCHL.KEY_MAN = sCHLDto.KEY_MAN;
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
        public bool DeleteSCHL(Dto.SCHLDto sCHLDto, out string msg)
        {
            msg = "";
            try
            {
                var sCHL = GetOverlapSCHL(sCHLDto);
                if (sCHL != null)
                {
                    db.SCHL.DeleteOnSubmit(sCHL);
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
    }
}
