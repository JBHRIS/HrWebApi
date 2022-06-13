using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Dapper;
namespace HR_TOOL.CodeGroup
{
    public class CodeFunction
    {

        public static Dictionary<string, Dictionary<string, string>> CodeCache = new Dictionary<string, Dictionary<string, string>>();
        public static void SetCache()
        {
            GetDept();
            GetDepts();
            GetDepta();
            GetHcode();
            GetRote();
            GetSalcode();
            GetAcccd();
            GetJob();
            GetJobs();
            GetJobl();
            GetRotet();
            GetAwardcd();
            GetBankCode();
            GetGiftVoucher();
            GetHOLICD();
            GetINSCOMP();
            GetOTRCD();
            GetOutPost();
            GetSTATION();
            GetTTSCD();
            GetWORKCD();
            //GetInsurCnCode();
            GetOTRATECD();
        }
        public static Dictionary<string, string> GetDept()
        {
            try
            {
                string codeType = "DEPT";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.DEPT select new { Key = a.D_NO, Value = a.D_NAME };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetDepts()
        {
            try
            {
                string codeType = "DEPTS";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.DEPTS select new { Key = a.D_NO, Value = a.D_NAME };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetDepta()
        {
            try
            {
                string codeType = "DEPTA";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.DEPTA select new { Key = a.D_NO, Value = a.D_NAME };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetHcode()
        {
            try
            {
                string codeType = "HCODE";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.HCODE select new { Key = a.H_CODE, Value = a.H_NAME };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetRote()
        {
            try
            {
                string codeType = "ROTE";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.ROTE select new { Key = a.ROTE1, Value = a.ROTENAME };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetRotet()
        {
            try
            {
                string codeType = "ROTET";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.ROTET select new { Key = a.ROTET1, Value = a.ROTETNAME };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetSalcode()
        {
            try
            {
                string codeType = "SALCODE";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.SALCODE select new { Key = a.SAL_CODE, Value = a.SAL_NAME };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetAcccd()
        {
            try
            {
                string codeType = "ACCCD";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.ACCCD select new { Key = a.ACCCD1, Value = a.ACCNAME };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetJob()
        {
            try
            {
                string codeType = "JOB";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.JOB select new { Key = a.JOB1, Value = a.JOB_NAME };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetJobs()
        {
            try
            {
                string codeType = "JOBS";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.JOBS select new { Key = a.JOBS1, Value = a.JOB_NAME };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetJobl()
        {
            try
            {
                string codeType = "JOBL";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.JOBL select new { Key = a.JOBL1, Value = a.JOB_NAME };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetAwardcd()
        {
            try
            {
                string codeType = "AWARDCD";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.AWARDCD select new { Key = a.AWARD_CODE, Value = a.DESCR };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetBankCode()
        {
            try
            {
                string codeType = "BankCode";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.BankCode select new { Key = a.Code, Value = a.BankName };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetGiftVoucher()
        {
            try
            {
                string codeType = "GiftVoucher";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.GiftVoucher select new { Key = a.Code, Value = a.GiftName };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetHOLICD()
        {
            try
            {
                string codeType = "HOLICD";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.HOLICD select new { Key = a.HOLI_CODE, Value = a.HOLI_NAME };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetINSCOMP()
        {
            try
            {
                string codeType = "INSCOMP";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.INSCOMP select new { Key = a.S_NO, Value = a.INSNAME };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetOTRCD()
        {
            try
            {
                string codeType = "OTRCD";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.OTRCD select new { Key = a.OTRCD1, Value = a.OTRNAME };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetOutPost()
        {
            try
            {
                string codeType = "OutPost";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.OutPost select new { Key = a.Code, Value = a.OutPostName };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetSTATION()
        {
            try
            {
                string codeType = "STATION";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.STATION select new { Key = a.Code, Value = a.StationName };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetTTSCD()
        {
            try
            {
                string codeType = "TTSCD";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.TTSCD select new { Key = a.TTSCD1, Value = a.TTSNAME };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            { return new Dictionary<string, string>(); }
        }
        public static Dictionary<string, string> GetWORKCD()
        {
            try
            {
                string codeType = "WORKCD";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.WORKCD select new { Key = a.WORK_CODE, Value = a.WORK_ADDR };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            {
                return new Dictionary<string, string>();
            }
        }
        //public static Dictionary<string, string> GetInsurCnCode()
        //{
        //    string codeType = "InsurCnCode";
        //    if (CodeCache.ContainsKey(codeType))
        //        return CodeCache[codeType];
        //    else
        //    {
        //        var db = new CodeDataDataContext();
        //        var CheckTableExists = db.Connection.QueryFirst<int>("SELECT count(*) FROM SYS.tables WHERE NAME='INSURCNCODE'");
        //        if (CheckTableExists > 0)
        //        {
        //            var sql = db.Connection.Query("SELECT InsurCnCode [Key],InsurCnName [Value] FROM INSURCNCODE");
        //            Dictionary<string, string> lst = new Dictionary<string,string>();
        //            foreach (var it in sql)
        //                lst.Add(it.Key, it.Value);
        //            CodeCache.Add(codeType, lst);
        //            return lst;
        //        }
        //        else return new Dictionary<string, string>();
        //    }
        //}
        //public static List<COMP_DATAGROUP> GetCompDatagroup()
        //{
        //    var db = new CodeDataDataContext();
        //    var sql = from a in db.COMP_DATAGROUP select a;
        //    return sql.ToList();
        //}
        //public static List<COMP_DATAGROUP> GetCompDatagroup()
        //{
        //    var db = new CodeDataDataContext();
        //    var sql = from a in db.COMP_DATAGROUP select a;
        //    return sql.ToList();
        //}
        public static Dictionary<string, string> GetOTRATECD()
        {
            try
            {
                string codeType = "OTRATECD";
                if (CodeCache.ContainsKey(codeType))
                    return CodeCache[codeType];
                else
                {
                    var db = new CodeDataDataContext();
                    var sql = from a in db.OTRATECD select new { Key = a.OTRATE_CODE, Value = a.OTRATE_NAME };
                    var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                    CodeCache.Add(codeType, lst);
                    return lst;
                }
            }
            catch
            {
                return new Dictionary<string, string>();
            }
        }
    }
}
