using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class ROTETCHGRepo
    {
        Linq.HrDBDataContext db = new Linq.HrDBDataContext();
        public Linq.ROTECHG GetOverlapROTECHG(Dto.ROTECHGDto rOTECHGDto)
        {
            var sql = from a in db.ROTECHG
                      where a.NOBR == rOTECHGDto.NOBR
                      && a.ADATE == rOTECHGDto.ADATE
                      select a;
            return sql.FirstOrDefault();
        }
        public bool InsertROTECHG(Dto.ROTECHGDto rOTECHGDto, out string msg)
        {
            msg = "";
            try
            {
                Linq.ROTECHG rOTECHG = new Linq.ROTECHG();
                rOTECHG.NOBR = rOTECHGDto.NOBR;
                rOTECHG.ADATE = rOTECHGDto.ADATE;
                rOTECHG.CODE = "";
                rOTECHG.ROTE = rOTECHGDto.ROTE;
                rOTECHG.KEY_DATE = rOTECHGDto.KEY_DATE;
                rOTECHG.KEY_MAN = rOTECHGDto.KEY_MAN;
                db.ROTECHG.InsertOnSubmit(rOTECHG);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateROTECHG(Dto.ROTECHGDto rOTECHGDto, out string msg)
        {
            msg = "";
            try
            {
                var rOTECHG = GetOverlapROTECHG(rOTECHGDto);
                if (rOTECHG != null)
                {
                    rOTECHG.NOBR = rOTECHGDto.NOBR;
                    rOTECHG.ADATE = rOTECHGDto.ADATE;
                    rOTECHG.CODE = "";
                    rOTECHG.ROTE = rOTECHGDto.ROTE;
                    rOTECHG.KEY_DATE = rOTECHGDto.KEY_DATE;
                    rOTECHG.KEY_MAN = rOTECHGDto.KEY_MAN;
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
        public bool DeleteROTECHG(Dto.ROTECHGDto ROTECHGDto, out string msg)
        {
            msg = "";
            try
            {
                var rOTECHG = GetOverlapROTECHG(ROTECHGDto);
                if (rOTECHG != null)
                {
                    db.ROTECHG.DeleteOnSubmit(rOTECHG);
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
