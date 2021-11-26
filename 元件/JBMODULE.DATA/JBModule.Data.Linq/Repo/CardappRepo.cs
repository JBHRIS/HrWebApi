using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class CardappRepo
    {
        JBModule.Data.Linq.HrDBDataContext db = new Linq.HrDBDataContext();
        public bool CanUpdateCardapp(Dto.CardappDto oldCardappDto, Dto.CardappDto newCardappDto, out string Msg)
        {
            Msg = "";
            var sql = from a in db.CARDAPP
                      where a.CARDNO == newCardappDto.CARDNO && a.EDATE >= newCardappDto.BDATE && newCardappDto.EDATE >= a.BDATE
                      && !(a.BDATE == oldCardappDto.BDATE && a.CARDNO == oldCardappDto.CARDNO)
                      select a;
            if (sql.Any())
                Msg += string.Format("卡號: {0}\n\n生效時間內已有資料" + Environment.NewLine, newCardappDto.CARDNO);
            var sql1 = from a in db.CARDAPP
                       where a.NOBR == newCardappDto.NOBR && a.EDATE >= newCardappDto.BDATE && newCardappDto.EDATE >= a.BDATE
                       && !(a.BDATE == oldCardappDto.BDATE && a.NOBR == oldCardappDto.NOBR)
                       select a;
            if (sql1.Any())
                Msg += string.Format("工號: {0}\n\n生效時間內已有資料" + Environment.NewLine, newCardappDto.NOBR);
            return !(sql.Any() || sql1.Any());
        }
        public bool CanInsertCardapp(Dto.CardappDto newCardappDto, out string Msg)
        {
            Msg = "";
            var sql = from a in db.CARDAPP
                      where a.CARDNO == newCardappDto.CARDNO
                      && a.EDATE >= newCardappDto.BDATE && newCardappDto.EDATE >= a.BDATE
                      select a;
            if (sql.Any())
                Msg += string.Format("卡號: {0}\n\n生效時間內已有資料" + Environment.NewLine, sql.FirstOrDefault().CARDNO);
            var sql1 = from a in db.CARDAPP
                       where a.NOBR == newCardappDto.NOBR
                       && a.EDATE >= newCardappDto.BDATE && newCardappDto.EDATE >= a.BDATE
                       select a;
            if (sql1.Any())
                Msg += string.Format("工號: {0}\n\n生效時間內已有資料" + Environment.NewLine, newCardappDto.NOBR);
            return !(sql.Any() || sql1.Any());
        }
    }
}
