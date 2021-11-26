using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class LICANRepo
    {
        Linq.HrDBDataContext db = new Linq.HrDBDataContext();
        public Linq.LICAN GetOverlapLICAN(Dto.LICANDto lICANDto)
        {
            var sql = from a in db.LICAN
                      where a.NOBR == lICANDto.NOBR
                      && a.DESCS == lICANDto.DESCS
                      select a;
            return sql.FirstOrDefault();
        }
        public bool InsertLICAN(Dto.LICANDto lICANDto, out string msg)
        {
            msg = "";
            try
            {
                Linq.LICAN lICAN = new Linq.LICAN();
                lICAN.NOBR = lICANDto.NOBR;
                lICAN.DESCS = lICANDto.DESCS;
                lICAN.COMP = lICANDto.COMP;
                lICAN.MDATE = lICANDto.MDATE;
                lICAN.EDATE = lICANDto.EDATE;
                lICAN.LIC_NO = lICANDto.LIC_NO;
                lICAN.LIC_NOTE = lICANDto.LIC_NOTE;
                lICAN.OWNER = lICANDto.OWNER;
                lICAN.LIC_PASS = lICANDto.LIC_PASS;
                lICAN.lican_id = 0;
                lICAN.KEY_DATE = lICANDto.KEY_DATE;
                lICAN.KEY_MAN = lICANDto.KEY_MAN;
                db.LICAN.InsertOnSubmit(lICAN);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateLICAN(Dto.LICANDto lICANDto, out string msg)
        {
            msg = "";
            try
            {
                var lICAN = GetOverlapLICAN(lICANDto);
                if (lICAN != null)
                {
                    lICAN.COMP = lICANDto.COMP;
                    lICAN.MDATE = lICANDto.MDATE;
                    lICAN.EDATE = lICANDto.EDATE;
                    lICAN.LIC_NO = lICANDto.LIC_NO;
                    lICAN.LIC_NOTE = lICANDto.LIC_NOTE;
                    lICAN.OWNER = lICANDto.OWNER;
                    lICAN.LIC_PASS = lICANDto.LIC_PASS;
                    lICAN.KEY_DATE = lICANDto.KEY_DATE;
                    lICAN.KEY_MAN = lICANDto.KEY_MAN;
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
        public bool DeleteLICAN(Dto.LICANDto lICANDto, out string msg)
        {
            msg = "";
            try
            {
                var lICAN = GetOverlapLICAN(lICANDto);
                if (lICAN != null)
                {
                    db.LICAN.DeleteOnSubmit(lICAN);
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
