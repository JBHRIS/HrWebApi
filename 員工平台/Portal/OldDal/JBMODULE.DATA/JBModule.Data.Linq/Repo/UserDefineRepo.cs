using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class UserDefineRepo
    {
        Linq.HrDBDataContext db = new Linq.HrDBDataContext();

        public List<Linq.UserDefineValue> GetOverlapUserDefine(List<Dto.UserDefineDto> userDefineDtoList)
        {
            var sql = from a in db.UserDefineValue
                      where (from udf in userDefineDtoList select new {udf.NOBR, udf.ControlID }).Contains(new { a.NOBR, a.ControlID })
                      //&& a.ControlID == userDefineDto.ControlID
                      select a;

            return sql.ToList();
        }
        public bool InsertUserDefine(List<Dto.UserDefineDto> userDefineDtoList, out string msg)
        {
            msg = "";
            try
            {
                foreach (var userDefineDto in userDefineDtoList)
                {
                    Linq.UserDefineValue userDefineValue = new Linq.UserDefineValue();
                    userDefineValue.NOBR = userDefineDto.NOBR;
                    userDefineValue.ControlID = userDefineDto.ControlID;
                    userDefineValue.SourceID = userDefineDto.SourceID;
                    userDefineValue.ValueType = userDefineDto.ValueTYPE;
                    userDefineValue.Value = userDefineDto.Value;
                    userDefineValue.Key_Date = userDefineDto.Key_Date;
                    userDefineValue.Key_Man = userDefineDto.Key_Man;
                    db.UserDefineValue.InsertOnSubmit(userDefineValue);
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateUserDefine(List<Dto.UserDefineDto> userDefineDtoList, out string msg)
        {
            msg = "";
            try
            {
                foreach (var userDefineDto in userDefineDtoList)
                {
                    Linq.UserDefineValue userDefineValue = new Linq.UserDefineValue();
                    var sql = from a in db.UserDefineValue
                              where a.NOBR == userDefineDto.NOBR && a.ControlID.Equals(userDefineDto.ControlID)
                              select a;
                    if (sql.Any())
                        userDefineValue = sql.First();
                    userDefineValue.NOBR = userDefineDto.NOBR;
                    userDefineValue.ControlID = userDefineDto.ControlID;
                    userDefineValue.SourceID = userDefineDto.SourceID;
                    userDefineValue.ValueType = userDefineDto.ValueTYPE;
                    userDefineValue.Value = userDefineDto.Value;
                    userDefineValue.Key_Date = userDefineDto.Key_Date;
                    userDefineValue.Key_Man = userDefineDto.Key_Man;
                    if (!sql.Any())
                        db.UserDefineValue.InsertOnSubmit(userDefineValue);
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool DeleteUserDefine(List<Dto.UserDefineDto> userDefineDtoList, out string msg)
        {
            msg = "";
            try
            {
                foreach (var userDefineDto in userDefineDtoList)
                {
                    Linq.UserDefineValue userDefineValue = new Linq.UserDefineValue();
                    var sql = from a in db.UserDefineValue
                              where a.NOBR == userDefineDto.NOBR && a.ControlID.Equals(userDefineDto.ControlID)
                              select a;
                    if (sql.Any())
                        db.UserDefineValue.DeleteAllOnSubmit(sql.ToList());
                }
                db.SubmitChanges();
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
