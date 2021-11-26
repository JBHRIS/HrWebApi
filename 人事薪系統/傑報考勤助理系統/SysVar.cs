using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Sal.Core
{
    public class SysVar
    {
        public static U_SYS1 CompanyVar
        {
            get
            {
                CodeMDDataContext db = new CodeMDDataContext();
                var value = (from a in db.U_SYS1 select a).FirstOrDefault();
                return value;
            }
        }
        public static U_SYS2 SalaryVar
        {
            get
            {
                CodeMDDataContext db = new CodeMDDataContext();
                var value = (from a in db.U_SYS2 select a).FirstOrDefault();
                return value;
            }
        }
        public static U_SYS3 OtVar
        {
            get
            {
                CodeMDDataContext db = new CodeMDDataContext();
                var value = (from a in db.U_SYS3 select a).FirstOrDefault();
                return value;
            }
        }
        public static U_SYS4 LabVar
        {
            get
            {
                CodeMDDataContext db = new CodeMDDataContext();
                var value = (from a in db.U_SYS4 select a).FirstOrDefault();
                return value;
            }
        }
        public static U_SYS5 HealthVar
        {
            get
            {
                CodeMDDataContext db = new CodeMDDataContext();
                var value = (from a in db.U_SYS5 select a).FirstOrDefault();
                return value;
            }
        }
        public static U_SYS6 GroupVar
        {
            get
            {
                CodeMDDataContext db = new CodeMDDataContext();
                var value = (from a in db.U_SYS6 select a).FirstOrDefault();
                return value;
            }
        }
        public static JBModule.Data.Linq.U_SYS7 GetCardVar(int code)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var value = (from a in db.U_SYS7 where a.AUTO==code select a).FirstOrDefault();
            return value;
        }
        public static U_SYS8 YearHolidayVar
        {
            get
            {
                CodeMDDataContext db = new CodeMDDataContext();
                var value = (from a in db.U_SYS8 select a).FirstOrDefault();
                return value;
            }
        }
        public static U_SYS9 TaxVar
        {
            get
            {
                CodeMDDataContext db = new CodeMDDataContext();
                var value = (from a in db.U_SYS9 select a).FirstOrDefault();
                return value;
            }
        }
        public static U_SYS10 MailVar
        {
            get
            {
                CodeMDDataContext db = new CodeMDDataContext();
                var value = (from a in db.U_SYS10 select a).FirstOrDefault();
                return value;
            }
        }
    }
}
