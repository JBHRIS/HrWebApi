using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class WorksRepo
    {
        Linq.HrDBDataContext db = new Linq.HrDBDataContext();
        public Linq.WORKS GetOverlapWORKS(Dto.WorksDto worksDto)
        {
            var sql = from a in db.WORKS
                      where a.NOBR == worksDto.NOBR
                      && a.COMPANY == worksDto.COMPANY
                      && a.BDATE == worksDto.BDATE
                      select a;
            return sql.FirstOrDefault();
        }
        public bool InsertWORKS(Dto.WorksDto worksDto, out string msg)
        {
            msg = "";
            try
            {
                Linq.WORKS works = new Linq.WORKS();
                works.NOBR = worksDto.NOBR;
                works.COMPANY = worksDto.COMPANY;
                works.TITLE = worksDto.TITLE;
                works.BDATE = worksDto.BDATE;
                works.EDATE = worksDto.EDATE;
                works.JOB = worksDto.JOB;
                works.NOTE = worksDto.NOTE;
                works.TRADE_CODE = "";
                works.IN_MARK = false;
                works.IN_CABINET = false;
                works.VOLUME = 0;
                works.DIR_TITLE = "";
                works.SEC_TITLE = "";
                works.PEOPLE = 0;
                works.TEL_NO = "";
                works.ADDR = "";
                works.work_id = 0;
                works.KEY_DATE = worksDto.KEY_DATE;
                works.KEY_MAN = worksDto.KEY_MAN;
                db.WORKS.InsertOnSubmit(works);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateWORKS(Dto.WorksDto worksDto, out string msg)
        {
            msg = "";
            try
            {
                var works = GetOverlapWORKS(worksDto);
                if (works != null)
                {
                    works.TITLE = worksDto.TITLE;
                    //works.BDATE = worksDto.BDATE;
                    works.EDATE = worksDto.EDATE;
                    works.JOB = worksDto.JOB;
                    works.NOTE = worksDto.NOTE;
                    //works.TRADE_CODE = "";
                    //works.IN_MARK = false;
                    //works.IN_CABINET = false;
                    //works.VOLUME = 0;
                    //works.DIR_TITLE = "";
                    //works.SEC_TITLE = "";
                    //works.PEOPLE = 0;
                    //works.TEL_NO = "";
                    //works.ADDR = "";
                    //works.work_id = 0;
                    works.KEY_DATE = worksDto.KEY_DATE;
                    works.KEY_MAN = worksDto.KEY_MAN;
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
        public bool DeleteWORKS(Dto.WorksDto worksDto, out string msg)
        {
            msg = "";
            try
            {
                var works = GetOverlapWORKS(worksDto);
                if (works != null)
                {
                    db.WORKS.DeleteOnSubmit(works);
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
