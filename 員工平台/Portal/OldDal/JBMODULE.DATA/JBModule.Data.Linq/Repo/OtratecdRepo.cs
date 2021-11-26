using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class OtratecdRepo
    {
        Linq.HrDBDataContext db = new Linq.HrDBDataContext();
        public OtratecdRepo(System.Data.IDbConnection db_con)
        {
            db = new Linq.HrDBDataContext(db_con);
        }
        public decimal GetOtHrsBySal(string otratecd, decimal realHrs)
        {
            decimal value = realHrs;
            var sql = (from a in db.OTRATECD
                       where a.OTRATE_CODE == otratecd
                       select a).FirstOrDefault();
            if (sql == null) return value;
            if (value >= sql.OT_REST_TIME_B1 && value <= sql.OT_REST_TIME_E1)
                value = sql.OT_REST_HOURS1;
            else if (value >= sql.OT_REST_TIME_B2 && value <= sql.OT_REST_TIME_E2)
                value = sql.OT_REST_HOURS2;
            else if (value >= sql.OT_REST_TIME_B3 && value <= sql.OT_REST_TIME_E3)
                value = sql.OT_REST_HOURS3;
            return value;
        }
    }
}
