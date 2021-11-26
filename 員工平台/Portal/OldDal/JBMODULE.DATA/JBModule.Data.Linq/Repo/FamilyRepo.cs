using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class FamilyRepo
    {
        Linq.HrDBDataContext db = new Linq.HrDBDataContext();
        public Linq.FAMILY_IN GetOverlapFAMILY(Dto.FamilyDto familyDto)
        {
            var sql = from a in db.FAMILY_IN
                      where a.NOBR == familyDto.NOBR
                      && a.FA_IDNO == familyDto.FA_IDNO
                      select a;
            return sql.FirstOrDefault();
        }
        public bool InsertFAMILY(Dto.FamilyDto familyDto, out string msg)
        {
            msg = "";
            try
            {
                Linq.FAMILY_IN family = new Linq.FAMILY_IN();
                family.FA_IDNO = familyDto.FA_IDNO;
                family.FA_NAME = familyDto.FA_NAME;
                family.REL_CODE = familyDto.REL_CODE;
                family.FA_BIRDT = familyDto.FA_BIRDT;
                family.NOBR = familyDto.NOBR;
                family.ADDR = familyDto.ADDR;
                family.KEY_DATE = familyDto.KEY_DATE;
                family.KEY_MAN = familyDto.KEY_MAN;
                family.TEL = "";
                family.GSM = "";
                family.BBC = "";
                family.TAX = false;
                family.LIVE = false;
                family.EDUCODE = "";
                family.COMPNY = "";
                family.TITLE = "";
                db.FAMILY_IN.InsertOnSubmit(family);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateFAMILY(Dto.FamilyDto familyDto, out string msg)
        {
            msg = "";
            try
            {
                var family = GetOverlapFAMILY(familyDto);
                if (family != null)
                {

                    family.FA_IDNO = familyDto.FA_IDNO;
                    family.FA_NAME = familyDto.FA_NAME;
                    family.REL_CODE = familyDto.REL_CODE;
                    family.FA_BIRDT = familyDto.FA_BIRDT;
                    family.NOBR = familyDto.NOBR;
                    family.ADDR = familyDto.ADDR;
                    family.KEY_DATE = familyDto.KEY_DATE;
                    family.KEY_MAN = familyDto.KEY_MAN;
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
        public bool DeleteFAMILY(Dto.FamilyDto familyDto, out string msg)
        {
            msg = "";
            try
            {
                var family = GetOverlapFAMILY(familyDto);
                if (family != null)
                {
                    db.FAMILY_IN.DeleteOnSubmit(family);
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
