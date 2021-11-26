using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Att
{
    public class LockAttend
    {
        DbConnection _conn;
        public LockAttend(DbConnection conn)
        {
            _conn = conn;
        }
        public bool Lock(string YYMM, string SEQ, List<string> SaladrList)
        {
            try
            {
                string arrayString = string.Join(",", SaladrList.Select(p => "'" + p + "'").ToArray());
                string AbsLockCmd = string.Format("UPDATE ABS SET nocalc=1 WHERE EXISTS(SELECT 1 FROM WAGE A WHERE A.NOBR=ABS.NOBR AND A.YYMM=ABS.YYMM AND A.YYMM='{0}' AND A.SEQ='{1}' AND A.WK_DAYS>0 AND A.SALADR IN ({2}))", YYMM, SEQ, arrayString);
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();
                SqlCommand cmd = new SqlCommand(AbsLockCmd, _conn as SqlConnection);
                cmd.ExecuteNonQuery();
                string OtLockCmd = string.Format("UPDATE OT SET NOTMODI=1 WHERE EXISTS(SELECT 1 FROM WAGE A WHERE A.NOBR=OT.NOBR AND A.YYMM=OT.YYMM AND A.YYMM='{0}' AND A.SEQ='{1}' AND A.WK_DAYS>0 AND A.SALADR IN ({2}))", YYMM, SEQ, arrayString);
                cmd = new SqlCommand(OtLockCmd, _conn as SqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {               
                return false;
            }
            return true;
        }
        public bool UnLock(string YYMM, string SEQ, List<string> SaladrList)
        {
            try
            {
                string arrayString = string.Join(",", SaladrList.Select(p => "'" + p + "'").ToArray());
                string AbsLockCmd = string.Format("UPDATE ABS SET nocalc=0 WHERE EXISTS(SELECT 1 FROM WAGE A WHERE A.NOBR=ABS.NOBR AND A.YYMM=ABS.YYMM AND A.YYMM='{0}' AND A.SEQ='{1}' AND A.WK_DAYS>0 AND A.SALADR IN ({2}))", YYMM, SEQ, arrayString);
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();
                SqlCommand cmd = new SqlCommand(AbsLockCmd, _conn as SqlConnection);
                cmd.ExecuteNonQuery();
                string OtLockCmd = string.Format("UPDATE OT SET NOTMODI=0 WHERE EXISTS(SELECT 1 FROM WAGE A WHERE A.NOBR=OT.NOBR AND A.YYMM=OT.YYMM AND A.YYMM='{0}' AND A.SEQ='{1}' AND A.WK_DAYS>0 AND A.SALADR IN ({2}))", YYMM, SEQ, arrayString);
                cmd = new SqlCommand(OtLockCmd, _conn as SqlConnection);
                cmd.ExecuteNonQuery();
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
