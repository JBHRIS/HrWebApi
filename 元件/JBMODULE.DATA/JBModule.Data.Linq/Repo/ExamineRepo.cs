using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class ExamineRepo
    {
        Linq.HrDBDataContext db = new Linq.HrDBDataContext();
        public Linq.EFFEMPLOY GetOverlapExamine(Dto.ExamineDto examineDto)
        {
            var sql = from a in db.EFFEMPLOY
                      where a.NOBR == examineDto.NOBR
                      //&& a.EFFLVL == examineDto.EFFLVL
                      && a.YYMM == examineDto.YYMM
                      && a.EFFTYPE == examineDto.EFFTYPE
                      select a;
            return sql.FirstOrDefault();
        }
        public bool InsertExamine(Dto.ExamineDto examineDto, out string msg)
        {
            msg = "";
            try
            {
                Linq.EFFEMPLOY examine = new Linq.EFFEMPLOY();
                examine.EFFLVL = examineDto.EFFLVL;
                examine.EFFSCORE = examineDto.EFFSCORE;
                examine.EFFTYPE = examineDto.EFFTYPE;
                examine.NOBR = examineDto.NOBR;
                examine.IMPORT = examineDto.IMPORT;
                examine.YYMM = examineDto.YYMM;
                examine.KEY_DATE = examineDto.KEY_DATE;
                examine.KEY_MAN = examineDto.KEY_MAN;
                db.EFFEMPLOY.InsertOnSubmit(examine);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateExamine(Dto.ExamineDto examineDto, out string msg)
        {
            msg = "";
            try
            {
                var examine = GetOverlapExamine(examineDto);
                if (examine != null)
                {
                    examine.EFFLVL = examineDto.EFFLVL;
                    examine.EFFSCORE = examineDto.EFFSCORE;
                    examine.EFFTYPE = examineDto.EFFTYPE;
                    examine.IMPORT = examineDto.IMPORT;
                    examine.YYMM = examineDto.YYMM;
                    examine.KEY_DATE = examineDto.KEY_DATE;
                    examine.KEY_MAN = examineDto.KEY_MAN;
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
        public bool DeleteExamine(Dto.ExamineDto examineDto, out string msg)
        {
            msg = "";
            try
            {
                var examine = GetOverlapExamine(examineDto);
                if (examine != null)
                {
                    db.EFFEMPLOY.DeleteOnSubmit(examine);
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
