using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Att
{
    public class AbsenceUtility
    {
        DbConnection _conn;
        public AbsenceUtility(DbConnection conn)
        {
            _conn = conn;
        }
        public bool DisposeAbsenceWhenStopOrOut(string EmployeeId)
        {
            try
            {
                string AbsCmd = string.Format("update ABS set TOL_DAY=TOL_HOURS, TOL_HOURS=0,Balance=0-LeaveHours where exists(select 1 from HCODE where HCODE.H_CODE=ABS.H_CODE and HCODE.FLAG='+') and exists(select * from BASETTS where NOBR='{0}' and TTSCODE in ('2','3','5') and BASETTS.NOBR=ABS.NOBR and ABS.BDATE between BASETTS.ADATE and BASETTS.DDATE) and TOL_HOURS!=0", EmployeeId);
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();
                SqlCommand cmd = new SqlCommand(AbsCmd, _conn as SqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool DropAbsenceWhenStopOrOut(string EmployeeId)
        {
            try
            {
                string AbsCmd = string.Format("DELETE ABS where exists(select 1 from HCODE where HCODE.H_CODE=ABS.H_CODE and HCODE.FLAG='+') and exists(select * from BASETTS where NOBR='{0}' and TTSCODE in ('2','3','5') and BASETTS.NOBR=ABS.NOBR and ABS.BDATE between BASETTS.ADATE and BASETTS.DDATE) and TOL_HOURS!=0", EmployeeId);
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();
                SqlCommand cmd = new SqlCommand(AbsCmd, _conn as SqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
