using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class CostRepo
    {
        Linq.HrDBDataContext db = new Linq.HrDBDataContext();
        public Linq.COST GetOverlapCOST(Dto.CostDto costDto)
        {
            var sql = from a in db.COST
                      where a.NOBR == costDto.NOBR
                      && a.DEPTS == costDto.DEPTS
                      select a;
            return sql.FirstOrDefault();
        }
        public bool InsertCOST(Dto.CostDto costDto, out string msg)
        {
            msg = "";
            try
            {
                Linq.COST cost = new Linq.COST();
                cost.NOBR = costDto.NOBR;
                cost.DEPTS = costDto.DEPTS;
                cost.RATE = costDto.RATE;
                cost.CADATE = costDto.CADATE;
                cost.CDDATE = costDto.CDDATE;
                cost.KEY_DATE = costDto.KEY_DATE;
                cost.KEY_MAN = costDto.KEY_MAN;
                db.COST.InsertOnSubmit(cost);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateCOST(Dto.CostDto costDto, out string msg)
        {
            msg = "";
            try
            {
                var cost = GetOverlapCOST(costDto);
                if (cost != null)
                {
                    cost.RATE = costDto.RATE;
                    cost.CADATE = costDto.CADATE;
                    cost.CDDATE = costDto.CDDATE;
                    cost.KEY_DATE = costDto.KEY_DATE;
                    cost.KEY_MAN = costDto.KEY_MAN;
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
        public bool DeleteCOST(Dto.CostDto costDto, out string msg)
        {
            msg = "";
            try
            {
                var cost = GetOverlapCOST(costDto);
                if (cost != null)
                {
                    db.COST.DeleteOnSubmit(cost);
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
