using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class AbsEntitleRepo : JBHRIS.BLL.Repo.AbsEntitleRepo
    {

        JBModule.Data.Linq.HrDBDataContext db;
        public AbsEntitleRepo()
        {
            db = new Linq.HrDBDataContext();
        }
        public AbsEntitleRepo(System.Data.IDbConnection connection)
        {
            db = new Linq.HrDBDataContext(connection);
        }
        public AbsEntitleRepo(JBModule.Data.Linq.HrDBDataContext _db)
        {
            db = _db;
        }
        public override bool Insert(JBHRIS.BLL.Dto.AbsEntitleDto instance, out string Msg)
        {
            try
            {
                Msg = "";
                //JBModule.Data.Linq.HrDBDataContext db = new Linq.HrDBDataContext();
                JBModule.Data.Linq.ABS abs = new Linq.ABS
                {
                    A_NAME = "",
                    BDATE = instance.BeginDate,
                    BTIME = "0000" + DateTime.Now.ToOADate().ToString(),
                    EDATE = instance.EndDate,
                    ETIME = "",
                    H_CODE = instance.HolidayCode,
                    KEY_DATE = instance.CreateTime,
                    KEY_MAN = instance.CreateMan,
                    NOBR = instance.EmployeeID,
                    nocalc = false,
                    NOTE = instance.Remark,
                    NOTEDIT = false,
                    SERNO = Guid.NewGuid().ToString(),
                    SYSCREATE = false,
                    //SYSCREATE1 = false,
                    TOL_DAY = 0,
                    TOL_HOURS = instance.Entitle,
                    YYMM = "",
                    Balance = instance.Balance,
                    Guid = Guid.NewGuid().ToString(),
                    LeaveHours = instance.Taken,
                    SYSCREATE1 = false,
                };
                db.ABS.InsertOnSubmit(abs);
                try
                {
                    db.SubmitChanges();
                }
                catch (System.Data.SqlClient.SqlException sqe)
                {
                    if (sqe.Number == 2627)
                    {
                        abs.BTIME = "0000" + DateTime.Now.ToOADate().ToString();
                        db.SubmitChanges();
                    }
                    else throw sqe;
                }
                return true;
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }
        }
    }
}
