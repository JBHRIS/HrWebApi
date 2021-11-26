using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class CardRepo
    {
        Linq.HrDBDataContext db = new Linq.HrDBDataContext();
        public Linq.CARD GetOverlapCard(Dto.CardDto cardDto)
        {
            var sql = from a in db.CARD
                      where a.NOBR == cardDto.NOBR
                      && a.ADATE == cardDto.ADATE
                      && a.ONTIME == cardDto.ONTIME
                      select a;
            return sql.FirstOrDefault();
        }
        public bool InsertCard(Dto.CardDto cardDto, out string msg)
        {
            msg = "";
            try
            {
                Linq.CARD card = new Linq.CARD();
                card.NOBR = cardDto.NOBR;
                card.ADATE = cardDto.ADATE;
                card.ONTIME = cardDto.ONTIME;
                card.REASON = cardDto.REASON;
                card.MENO = cardDto.MENO;
                card.LOS = cardDto.LOS;
                card.KEY_DATE = cardDto.KEY_DATE;
                card.KEY_MAN = cardDto.KEY_MAN;
                card.CODE = "";
                card.CARDNO = "";
                card.DAYS = 0;
                card.IPADD = "";
                card.NOT_TRAN = false;
                card.SERNO = "";
                db.CARD.InsertOnSubmit(card);
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateCard(Dto.CardDto cardDto, out string msg)
        {
            msg = "";
            try
            {
                var card = GetOverlapCard(cardDto);
                if (card != null)
                {
                    card.REASON = cardDto.REASON;
                    card.MENO = cardDto.MENO;
                    card.LOS = cardDto.LOS;
                    card.KEY_DATE = cardDto.KEY_DATE;
                    card.KEY_MAN = cardDto.KEY_MAN;
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
        public bool DeleteCard(Dto.CardDto cardDto, out string msg)
        {
            msg = "";
            try
            {
                var card = GetOverlapCard(cardDto);
                if (card != null)
                {
                    db.CARD.DeleteOnSubmit(card);
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
        //public void 
    }
}
