using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class TBaseRepo
    {
        Linq.HrDBDataContext db = new Linq.HrDBDataContext();
        public Linq.TBASE GetOverlapTBASE(Dto.TBaseDto tbaseDto)
        {
            var sql = from a in db.TBASE
                      where a.INCOMP == tbaseDto.INCOMP && a.NOBR == tbaseDto.NOBR
                      select a;
            return sql.FirstOrDefault();

        }

        public bool InsertTBASE(Dto.TBaseDto tbaseDto, out string msg)
        {
            msg = "";
            try
            {
                Linq.TBASE tBASE = new Linq.TBASE();
                tBASE.INCOMP = tbaseDto.INCOMP;
                tBASE.NOBR = tbaseDto.NOBR;
                tBASE.NAME_C = tbaseDto.NAME_C;
                tBASE.ADDR = tbaseDto.ADDR;
                tBASE.TEL = tbaseDto.TEL;
                tBASE.EMAIL = tbaseDto.EMAIL;
                tBASE.GSM = tbaseDto.GSM;
                tBASE.IDNO = tbaseDto.IDNO;
                tBASE.KEY_MAN = tbaseDto.KEY_MAN;
                tBASE.KEY_DATE = tbaseDto.KEY_DATE;
                tBASE.IDCODE = tbaseDto.IDCODE;
                tBASE.POSTCODE1 = tbaseDto.POSTCODE1;
                tBASE.POSTCODE2 = tbaseDto.POSTCODE2;
                tBASE.SALADR = tbaseDto.SALADR;
                tBASE.TAXNO = tbaseDto.TAXNO;
                db.TBASE.InsertOnSubmit(tBASE);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateTBASE(Dto.TBaseDto tbaseDto, out string msg)
        {
            msg = "";
            try
            {
                Linq.TBASE tBASE = GetOverlapTBASE(tbaseDto);
                if (tBASE != null)
                {
                    tBASE.INCOMP = tbaseDto.INCOMP;
                    tBASE.NOBR = tbaseDto.NOBR;
                    tBASE.NAME_C = tbaseDto.NAME_C;
                    tBASE.ADDR = tbaseDto.ADDR;
                    tBASE.TEL = tbaseDto.TEL;
                    tBASE.EMAIL = tbaseDto.EMAIL;
                    tBASE.GSM = tbaseDto.GSM;
                    tBASE.IDNO = tbaseDto.IDNO;
                    tBASE.KEY_MAN = tbaseDto.KEY_MAN;
                    tBASE.KEY_DATE = tbaseDto.KEY_DATE;
                    tBASE.IDCODE = tbaseDto.IDCODE;
                    tBASE.POSTCODE1 = tbaseDto.POSTCODE1;
                    tBASE.POSTCODE2 = tbaseDto.POSTCODE2;
                    tBASE.SALADR = tbaseDto.SALADR;
                    tBASE.TAXNO = tbaseDto.TAXNO;

                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool DeleteTBASE(Dto.TBaseDto tbaseDto, out string msg)
        {
            msg = "";
            try
            {
                var tBASE = GetOverlapTBASE(tbaseDto);
                if (tBASE != null)
                {
                    db.TBASE.DeleteOnSubmit(tBASE);
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
