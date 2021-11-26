using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class AwardRepo
    {
        Linq.HrDBDataContext db = new Linq.HrDBDataContext();
        public Linq.AWARD GetOverlapAWARD(Dto.AwardDto awardDto)
        {
            var sql = from a in db.AWARD
                      where a.NOBR == awardDto.NOBR
                      && a.ADATE == awardDto.ADATE
                      select a;
            return sql.FirstOrDefault();
        }
        public bool InsertAWARD(Dto.AwardDto awardDto, out string msg)
        {
            msg = "";
            try
            {
                Linq.AWARD award = new Linq.AWARD();
                award.NOBR = awardDto.NOBR;
                award.ADATE = awardDto.ADATE;
                award.AWARD1 = awardDto.AWARD1;
                award.AWARD2 = awardDto.AWARD2;
                award.AWARD3 = awardDto.AWARD3;
                award.AWARD4 = awardDto.AWARD4;
                award.AWARD5 = false;
                award.AWARD6 = 0;
                award.AWARD_CODE = awardDto.AWARD_CODE;
                award.FAULT1 = awardDto.FAULT1;
                award.FAULT2 = awardDto.FAULT2;
                award.FAULT3 = awardDto.FAULT3;
                award.FAULT4 = awardDto.FAULT4;
                award.FAULT5 = 0;
                award.NOTE = awardDto.NOTE;
                award.YYMM = awardDto.YYMM;
                award.KEY_DATE = awardDto.KEY_DATE;
                award.KEY_MAN = awardDto.KEY_MAN;
                db.AWARD.InsertOnSubmit(award);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateAWARD(Dto.AwardDto awardDto, out string msg)
        {
            msg = "";
            try
            {
                var award = GetOverlapAWARD(awardDto);
                if (award != null)
                {
                    award.AWARD1 = awardDto.AWARD1;
                    award.AWARD2 = awardDto.AWARD2;
                    award.AWARD3 = awardDto.AWARD3;
                    award.AWARD4 = awardDto.AWARD4;
                    //award.AWARD5 = false;
                    //award.AWARD6 = 0;
                    award.AWARD_CODE = awardDto.AWARD_CODE;
                    award.FAULT1 = awardDto.FAULT1;
                    award.FAULT2 = awardDto.FAULT2;
                    award.FAULT3 = awardDto.FAULT3;
                    award.FAULT4 = awardDto.FAULT4;
                    //award.FAULT5 = 0;
                    award.NOTE = awardDto.NOTE;
                    award.YYMM = awardDto.YYMM;
                    award.KEY_DATE = awardDto.KEY_DATE;
                    award.KEY_MAN = awardDto.KEY_MAN;
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
        public bool DeleteAWARD(Dto.AwardDto awardDto, out string msg)
        {
            msg = "";
            try
            {
                var award = GetOverlapAWARD(awardDto);
                if (award != null)
                {
                    db.AWARD.DeleteOnSubmit(award);
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
