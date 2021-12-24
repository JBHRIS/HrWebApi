using Dapper;
using JBModule.Data.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JBHR
{
    public class CodeFunction
    {
        public string Code;
        public string DisplayName;
        public string Value;
        public string CodeColumn
        {
            get { return Code; }
            set { Code = Value; }
        }
        public CodeFunction()
        {

        }
        public static List<string> GetholicodeList()
        {
            var lst = new List<string>() { "00","0X","0Y","0Z"};
            return lst;
        }
        public static Dictionary<string, string> GetBase()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.BASE
                      where db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.NOBR
                      select new { Key = a.NOBR, Value = a.NOBR + "-" + a.NAME_C };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        public static Dictionary<string, string> GetSalFunction()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.SALFUNCTION
                          //where db.GetCodeFilter("JOB", a.JOB1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.SORT
                      select new { Key = a.AUTO.ToString(), Value = a.AUTO.ToString() + "-" + a.ITEM };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        public static Dictionary<string, string> GetSalFunction(string CalcType)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.SALFUNCTION
                      where a.CALCTYPE == CalcType
                      //where db.GetCodeFilter("JOB", a.JOB1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.SORT
                      select new { Key = a.AUTO.ToString(), Value = a.AUTO.ToString() + "-" + a.ITEM };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //職稱代碼資料
        public static Dictionary<string, string> GetJob()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.JOB
                      where db.GetCodeFilter("JOB", a.JOB1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.JOB_DISP
                      select new { Key = a.JOB1, Value = a.JOB_DISP + "-" + a.JOB_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //職級代碼資料
        public static Dictionary<string, string> GetJobo()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.JOBO
                      orderby a.JOBO1
                      select new { Key = a.JOBO1, Value = a.JOBO1 + "-" + a.JOB_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //職稱代碼資料
        public static Dictionary<string, string> GetJobDisp()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.JOB
                      where db.GetCodeFilter("JOB", a.JOB1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.JOB_DISP
                      select new { Key = a.JOB_DISP, Value = a.JOB_DISP + "-" + a.JOB_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //職等代碼資料
        public static Dictionary<string, string> GetJobl()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.JOBL
                      where db.GetCodeFilter("JOBL", a.JOBL1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.JOBL_DISP
                      select new { Key = a.JOBL1, Value = a.JOBL_DISP + "-" + a.JOB_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //職等代碼資料
        public static Dictionary<string, string> GetJoblDisp()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.JOBL
                      where db.GetCodeFilter("JOBL", a.JOBL1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.JOBL_DISP
                      select new { Key = a.JOBL_DISP, Value = a.JOBL_DISP + "-" + a.JOB_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //職類代碼資料
        public static Dictionary<string, string> GetJobs()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.JOBS
                      where db.GetCodeFilter("JOBS", a.JOBS1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.JOBS_DISP
                      select new { Key = a.JOBS1, Value = a.JOBS_DISP + "-" + a.JOB_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //資料群組代碼資料
        public static Dictionary<string, string> GetDatagroup()
        {
            return GetDatagroup(true);
        }
        public static Dictionary<string, string> GetDatagroup(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in MainForm.WriteRules
                      orderby a.DATAGROUP
                      select new { Key = a.DATAGROUP, Value = ValueWithKey ? a.DATAGROUP + "-" + a.DATAGROUP1.GROUPNAME : a.DATAGROUP1.GROUPNAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        public static Dictionary<string, string> GetDatagroup(string COMP)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var usercomp = MainForm.UserCompList.Where(p => p.COMPANY == COMP);
            if (usercomp.Any())
            {
                var sql = from a in usercomp.First().U_DATAGROUP where a.COMPANY == COMP select new { Key = a.DATAGROUP, Value = a.DATAGROUP + "-" + a.DATAGROUP1.GROUPNAME };
                var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
                return lst;
            }
            else return new Dictionary<string, string>();
        }
        public static Dictionary<string, string> GetDatagroupAll()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DATAGROUP
                      orderby a.DATAGROUP1
                      select new { Key = a.DATAGROUP1, Value = a.DATAGROUP1 + "-" + a.GROUPNAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //編制部門代碼資料
        public static Dictionary<string, string> GetDept_effe()
        {
            var lst = GetDept_effe(DateTime.Today);
            return lst;
        }
        //編制部門代碼資料
        public static Dictionary<string, string> GetDept()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DEPT
                      where db.GetCodeFilter("DEPT", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value

                      orderby a.D_NO_DISP
                      select new { Key = a.D_NO, Value = a.D_NO_DISP + "-" + a.D_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //編制部門代碼資料
        public static Dictionary<string, string> GetDept_effe(DateTime DDATE)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DEPT
                      where db.GetCodeFilter("DEPT", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                       && a.ADATE <= DDATE.Date && a.DDATE >= DDATE.Date
                      orderby a.D_NO_DISP
                      select new { Key = a.D_NO, Value = a.D_NO_DISP + "-" + a.D_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        public static Dictionary<string, string> GetDeptDisp()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DEPT
                      where db.GetCodeFilter("DEPT", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                            && a.ADATE <= System.DateTime.Today && a.DDATE >= System.DateTime.Today
                      orderby a.D_NO_DISP
                      select new { Key = a.D_NO_DISP, Value = a.D_NO_DISP + "-" + a.D_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //成本部門代碼資料
        public static Dictionary<string, string> GetDepts_effe()
        {
            var lst = GetDepts_effe(DateTime.Today);
            return lst;
        }
        //成本部門代碼資料
        public static Dictionary<string, string> GetDepts()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DEPTS
                      where db.GetCodeFilter("DEPTS", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      //&& a.ADATE <= DDATE && a.DDATE >= DDATE
                      orderby a.D_NO_DISP
                      select new { Key = a.D_NO, Value = a.D_NO_DISP + "-" + a.D_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //成本部門代碼資料--過濾失效資料
        public static Dictionary<string, string> GetDepts_effe(DateTime DDATE)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DEPTS
                      where db.GetCodeFilter("DEPTS", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && a.ADATE <= DDATE && a.DDATE >= DDATE
                      orderby a.D_NO_DISP
                      select new { Key = a.D_NO, Value = a.D_NO_DISP + "-" + a.D_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //簽核部門代碼資料--過濾失效資料
        public static Dictionary<string, string> GetDepta_effe()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DEPTA
                      where db.GetCodeFilter("DEPTA", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && a.ADATE <= System.DateTime.Today && a.DDATE >= System.DateTime.Today
                      orderby a.D_NO_DISP
                      select new { Key = a.D_NO, Value = a.D_NO_DISP + "-" + a.D_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //簽核部門代碼資料--過濾失效資料
        public static Dictionary<string, string> GetDepta_effe(DateTime DDATE)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DEPTA
                      where db.GetCodeFilter("DEPTA", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && a.ADATE <= DDATE && a.DDATE >= DDATE
                      orderby a.D_NO_DISP
                      select new { Key = a.D_NO, Value = a.D_NO_DISP + "-" + a.D_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //簽核部門代碼資料
        public static Dictionary<string, string> GetDepta()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DEPTA
                      where db.GetCodeFilter("DEPTA", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.D_NO_DISP
                      select new { Key = a.D_NO, Value = a.D_NO_DISP + "-" + a.D_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //眷屬稱謂代碼資料
        public static Dictionary<string, string> GetRelcode()
        {
            return GetRelcode(true);
        }
        public static Dictionary<string, string> GetRelcode(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.RELCODE
                      orderby a.REL_CODE
                      select new { Key = a.REL_CODE, Value = ValueWithKey ? a.REL_CODE + "-" + a.REL_NAME : a.REL_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //工作地點代碼資料
        public static Dictionary<string, string> GetWorkcd()
        {
            return GetWorkcd(true);
        }
        public static Dictionary<string, string> GetWorkcd(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.WORKCD
                      orderby a.WORK_CODE
                      select new { Key = a.WORK_CODE, Value = ValueWithKey ? a.WORK_CODE + "-" + a.WORK_ADDR : a.WORK_ADDR };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //離職原因代碼資料
        public static Dictionary<string, string> GetOutcd()
        {
            return GetOutcd(true);
        }
        public static Dictionary<string, string> GetOutcd(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.OUTCD
                      orderby a.OUTCD1
                      select new { Key = a.OUTCD1, Value = ValueWithKey ? a.OUTCD1 + "-" + a.OUTNAME : a.OUTNAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //異動因代碼資料
        public static Dictionary<string, string> GetTtscd()
        {
            return GetTtscd(true);
        }
        public static Dictionary<string, string> GetTtscd(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.TTSCD
                      where db.GetCodeFilter("TTSCD", a.TTSCD1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.TTSCD_DISP
                      select new { Key = a.TTSCD1, Value = ValueWithKey ? a.TTSCD_DISP + "-" + a.TTSNAME : a.TTSNAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //員別代碼資料
        public static Dictionary<string, string> GetEmpcd()
        {
            return GetEmpcd(true);
        }
        public static Dictionary<string, string> GetEmpcd(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.EMPCD
                      orderby a.EMPCD1
                      select new { Key = a.EMPCD1, Value = ValueWithKey ? a.EMPCD1 + "-" + a.EMPDESCR : a.EMPDESCR };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //獎懲代碼資料
        public static Dictionary<string, string> GetAwardcd()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.AWARDCD
                      where db.GetCodeFilter("AWARDCD", a.AWARD_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.AWARD_CODE_DISP
                      select new { Key = a.AWARD_CODE, Value = a.AWARD_CODE_DISP + "-" + a.DESCR };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //戶籍地代碼資料
        public static Dictionary<string, string> GetProvcd()
        {
            return GetProvcd(true);
        }
        public static Dictionary<string, string> GetProvcd(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.PROVCD
                      orderby a.PROV_CODE
                      select new { Key = a.PROV_CODE, Value = ValueWithKey? a.PROV_CODE + "-" + a.DESCR : a.DESCR };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //國別代碼資料
        public static Dictionary<string, string> GetCountcd()
        {
            return GetCountcd(true);
        }
        public static Dictionary<string, string> GetCountcd(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.COUNTCD
                      orderby a.CODE
                      select new { Key = a.CODE, Value = ValueWithKey ? a.CODE + "-" + a.DESCR : a.DESCR };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //興趣代碼資料
        public static Dictionary<string, string> GetRelishcd()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.RELISHCD
                      orderby a.RELISH_CODE
                      select new { Key = a.RELISH_CODE, Value = a.RELISH_CODE + "-" + a.RELISH };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //身份別代碼資料
        public static Dictionary<string, string> GetBasecd()
        {
            return GetBasecd(true);
        }
        public static Dictionary<string, string> GetBasecd(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.BASECD
                      orderby a.BASECD1
                      select new { Key = a.BASECD1, Value = ValueWithKey ? a.BASECD1 + "-" + a.BASECDNAME : a.BASECDNAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //銀行代碼資料
        public static Dictionary<string, string> GetBankCode()
        {
            return GetBankCode(true);
        }
        public static Dictionary<string, string> GetBankCode(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.BankCode
                      where db.GetCodeFilter("BankCode", a.Code, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.CODE_DISP
                      select new { Key = a.Code, Value = ValueWithKey ? a.CODE_DISP + "-" + a.BankName : a.BankName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //銀行格式編碼資料
        public static Dictionary<string, string> GetBankFormatEncoding()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.EncodingTable
                      //where db.GetCodeFilter("BankCode", a.Code, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.CodePage
                      select new { Key = a.CodePage.ToString(), Value = a.CodeDSP + "-" + a.CodeName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //合同代碼資料
        public static Dictionary<string, string> GetContractType()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ContractType
                      orderby a.Code
                      select new { Key = a.Code, Value = a.Code + "-" + a.DisplayName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //門禁代碼資料
        public static Dictionary<string, string> GetDoorGuard()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DoorGuard
                      orderby a.Code
                      select new { Key = a.Code, Value = a.Code + "-" + a.DoorName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //錄取管道代碼資料
        public static Dictionary<string, string> GetCandidates_ways()
        {
            return GetCandidates_ways(true);
        }
        public static Dictionary<string, string> GetCandidates_ways(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.CANDIDATES_WAYS
                      orderby a.Code
                      select new { Key = a.Code, Value = ValueWithKey ? a.Code + "-" + a.WayName : a.WayName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //科系代碼資料
        public static Dictionary<string, string> GetSubCode()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.SUBCODE
                      orderby a.SUBCODE1
                      select new { Key = a.SUBCODE1, Value = a.SUBCODE1 + "-" + a.SUBDESC };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //禮卷代碼資料
        public static Dictionary<string, string> GetGiftVoucher()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.GiftVoucher
                      where db.GetCodeFilter("GiftVoucher", a.Code, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.CODE_DISP
                      select new { Key = a.Code, Value = a.CODE_DISP + "-" + a.GiftName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //外派代碼資料
        public static Dictionary<string, string> GetOutPost()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.OutPost
                      where db.GetCodeFilter("OutPost", a.Code, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.CODE_DISP
                      select new { Key = a.Code, Value = a.CODE_DISP + "-" + a.OutPostName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //環境津貼代碼資料
        public static Dictionary<string, string> GetStation()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.STATION
                      where db.GetCodeFilter("STATION", a.Code, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.CODE_DISP
                      select new { Key = a.Code, Value = a.CODE_DISP + "-" + a.StationName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //油資補貼代碼資料
        public static Dictionary<string, string> GetOilSubsidyType()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.OilSubsidyType
                      orderby a.Code
                      select new { Key = a.Code, Value = a.Code + "-" + a.OilSubsidyType1 };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }


        //假別代碼資料
        public static Dictionary<string, string> GetHcode()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.HCODE
                      where db.GetCodeFilter("HCODE", a.H_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.H_CODE_DISP
                      select new { Key = a.H_CODE, Value = a.H_CODE_DISP + "-" + a.H_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //過濾假別屬性假別代碼資料
        public static Dictionary<string, string> GetHcode(bool isEntitle)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.HCODE
                      where db.GetCodeFilter("HCODE", a.H_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && a.FLAG == (isEntitle ? "+" : "-")
                      orderby a.H_CODE_DISP
                      select new { Key = a.H_CODE, Value = a.H_CODE_DISP + "-" + a.H_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        public static Dictionary<string, string> GetHcode(List<string> FlagList,bool DispSortZero = true)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.HCODE
                      where db.GetCodeFilter("HCODE", a.H_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && FlagList.Contains(a.FLAG)
                      && !(!DispSortZero && a.SORT == 0)
                      orderby a.H_CODE_DISP
                      select new { Key = a.H_CODE, Value = a.H_CODE_DISP + "-" + a.H_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //請假類別
        public static Dictionary<string, string> GetHcodeType()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.HcodeType
                      where db.GetCodeFilter("HcodeType", a.HTYPE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.Sort
                      select new { Key = a.HTYPE, Value = a.HTYPE_DISP + "-" + a.TYPE_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //班別代碼資料
        public static Dictionary<string, string> GetRote()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ROTE
                      where db.GetCodeFilter("ROTE", a.ROTE1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.ROTE_DISP
                      select new { Key = a.ROTE1, Value = a.ROTE_DISP + "-" + a.ROTENAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //班別代碼資料
        public static Dictionary<string, string> GetRoteDisp()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ROTE
                      where db.GetCodeFilter("ROTE", a.ROTE1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.ROTE_DISP
                      select new { Key = a.ROTE_DISP, Value = a.ROTE_DISP + "-" + a.ROTENAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //輪班別代碼資料
        public static Dictionary<string, string> GetRotet()
        {
            return GetRotet(true);
        }
        public static Dictionary<string, string> GetRotet(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ROTET
                      where db.GetCodeFilter("ROTET", a.ROTET1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.ROTET_DISP
                      select new { Key = a.ROTET1, Value = ValueWithKey ? a.ROTET_DISP + "-" + a.ROTETNAME : a.ROTETNAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //遺忘刷卡原因代碼資料
        public static Dictionary<string, string> GetCardlosd()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.CARDLOSD
                      orderby a.CODE
                      select new { Key = a.CODE, Value = a.CODE + "-" + a.DESCR };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //加班原因代碼資料
        public static Dictionary<string, string> GetOtrcd()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.OTRCD
                      where db.GetCodeFilter("OTRCD", a.OTRCD1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.OTRCD_DISP
                      select new { Key = a.OTRCD1, Value = a.OTRCD_DISP + "-" + a.OTRNAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //行事曆代碼資料
        public static Dictionary<string, string> GetHolicd()
        {
            return GetHolicd(true);
        }
        public static Dictionary<string, string> GetHolicd(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.HOLICD
                      where db.GetCodeFilter("HOLICD", a.HOLI_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.HOLI_CODE_DISP
                      select new { Key = a.HOLI_CODE, Value = ValueWithKey ? a.HOLI_CODE_DISP + "-" + a.HOLI_NAME : a.HOLI_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //行事曆代碼資料(DISP)
        public static Dictionary<string, string> GetHolicdDisp()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.HOLICD
                      where db.GetCodeFilter("HOLICD", a.HOLI_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.HOLI_CODE_DISP
                      select new { Key = a.HOLI_CODE_DISP, Value = a.HOLI_CODE_DISP + "-" + a.HOLI_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //假日類別代碼設定資料
        public static Dictionary<string, string> GetOthCode()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.OTHCODE
                      orderby a.OTHCODE1
                      select new { Key = a.OTHCODE1, Value = a.OTHCODE1 + "-" + a.OTHNAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //加班比率代碼資料
        public static Dictionary<string, string> GetOtRatecd()
        {
            return GetOtRatecd(true);
        }
        public static Dictionary<string, string> GetOtRatecd(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.OTRATECD
                      orderby a.OTRATE_CODE
                      select new { Key = a.OTRATE_CODE, Value = ValueWithKey ? a.OTRATE_CODE + "-" + a.OTRATE_NAME : a.OTRATE_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //科目代碼資料
        public static Dictionary<string, string> GetAcccd()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ACCCD
                      where db.GetCodeFilter("ACCCD", a.ACCCD1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.ACCCD_DISP
                      select new { Key = a.ACCCD1, Value = a.ACCCD_DISP + "-" + a.ACCNAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //薪別代碼資料
        public static Dictionary<string, string> GetSaltycd()
        {
            return GetSaltycd(true);
        }
        public static Dictionary<string, string> GetSaltycd(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.SALTYCD
                      orderby a.SALTYCD1
                      select new { Key = a.SALTYCD1, Value = ValueWithKey ? a.SALTYCD1 + "-" + a.SALTYNAME : a.SALTYNAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        public static Dictionary<string, string> GetBaseSalCode()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.SALCODE
                      join b in db.SALATTR on a.SAL_ATTR equals b.SALATTR1
                      where db.GetCodeFilter("SALCODE", a.SAL_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && b.BASIC
                      && b.TYPE == "1"//應發
                      orderby a.SAL_CODE_DISP
                      select new { Key = a.SAL_CODE, Value = a.SAL_CODE_DISP + "-" + a.SAL_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //薪資屬性資料
        public static Dictionary<string, string> GetSalattr()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.SALATTR
                      where a.NOT_DISP == false
                      orderby a.SALATTR1
                      select new { Key = a.SALATTR1, Value = a.SALATTR1 + "-" + a.ATTR_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //薪資代碼資料
        public static Dictionary<string, string> GetSalCode()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.SALCODE
                      where db.GetCodeFilter("SALCODE", a.SAL_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.SAL_CODE_DISP
                      select new { Key = a.SAL_CODE, Value = a.SAL_CODE_DISP + "-" + a.SAL_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //公司代碼資料 (公司別)
        public static Dictionary<string, string> GetComp()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.COMP
                      orderby a.COMP1
                      select new { Key = a.COMP1, Value = a.COMP1 + "-" + a.COMPNAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //部門群組代碼資料
        public static Dictionary<string, string> GetDEPT_GROUP()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DEPT
                      where db.GetCodeFilter("DEPT", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.D_NO_DISP
                      select new { Key = a.D_NO, Value = a.D_NO_DISP + "-" + a.D_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }


        //投保單位代碼資料
        public static Dictionary<string, string> GetInsComp()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.INSCOMP
                      where db.GetCodeFilter("INSCOMP", a.S_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.S_NO_DISP
                      select new { Key = a.S_NO, Value = a.S_NO_DISP.Trim() + "-" + a.INSNAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //投保單位代碼資料
        public static Dictionary<string, string> GetInsCompDisp()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.INSCOMP
                      where db.GetCodeFilter("INSCOMP", a.S_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.S_NO_DISP
                      select new { Key = a.S_NO_DISP.Trim(), Value = a.S_NO_DISP.Trim() + "-" + a.INSNAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //勞健保異動原因代碼
        public static Dictionary<string, string> GetInsName()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.INSNAME
                      orderby a.NO
                      select new { Key = a.NO, Value = a.NO + "-" + a.NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //勞保負擔比例代碼資料
        public static Dictionary<string, string> GetLarCode()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.LARCODE
                      orderby a.RATE_CODE
                      select new { Key = a.RATE_CODE, Value = a.RATE_CODE + "-" + a.RATE_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //健保負擔比例代碼資料
        public static Dictionary<string, string> GetHarCode()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.HARCODE
                      orderby a.RATE_CODE
                      select new { Key = a.RATE_CODE, Value = a.RATE_CODE + "-" + a.RATE_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //業別代碼資料
        public static Dictionary<string, string> GetYrina()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.YRINA
                      orderby a.INA_ID
                      select new { Key = a.INA_ID, Value = a.INA_ID + "-" + a.INA_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //稽徵機關代碼資料
        public static Dictionary<string, string> GetYRHSN()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.YRHSN
                      orderby a.CO_CTID, a.CO_ARID
                      select new { Key = a.CO_CTID + a.CO_ARID, Value = a.CO_CTID + a.CO_ARID + "-" + a.H_HSN_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //證別號代碼資料
        public static Dictionary<string, string> GetYrid()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.YRID
                      orderby a.ID_CODE
                      select new { Key = a.ID_CODE, Value = a.ID_CODE + "-" + a.DESCR };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //錯誤註記代碼資料
        public static Dictionary<string, string> GetYrermak()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.YRERMAK
                      orderby a.ERRMARK
                      select new { Key = a.ERRMARK, Value = a.ERRMARK + "-" + a.DESCR };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //錯誤註記代碼資料
        public static Dictionary<string, string> GetYrmark()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.YRMARK
                      orderby a.MARK
                      select new { Key = a.MARK, Value = a.MARK + "-" + a.MARK_DESCR };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //福利別代碼資料
        public static Dictionary<string, string> GetWcode()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.WCODE
                      orderby a.W_CODE
                      select new { Key = a.W_CODE, Value = a.W_CODE + "-" + a.W_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //部門費用代碼資料
        public static Dictionary<string, string> GetEXP_DEPT()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.EXP_DEPT
                      orderby a.D_NO_DISP
                      select new { Key = a.D_NO, Value = a.D_NO_DISP + "-" + a.D_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //考核種類代碼資料
        public static Dictionary<string, string> GetEFFTYPE()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.EFFTYPE
                      orderby a.EFFTYPE_DISP
                      select new { Key = a.EFFTYPE1, Value = a.EFFTYPE_DISP + "-" + a.EFFTYPE_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        public static Dictionary<string, string> GetAssessCat()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.AssessCat
                      orderby a.sName
                      select new { Key = a.sCode, Value = a.sCode + "-" + a.sName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        



        //考績等級代碼資料
        public static Dictionary<string, string> GetEFFLVL()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.EFFLVL
                      orderby a.EFFLVL_DISP
                      select new { Key = a.EFFLVL1, Value = a.EFFLVL_DISP + "-" + a.EFFLVL_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //承辦單位代碼資料
        public static Dictionary<string, string> GetTRCOMP()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.TRCOMPY
                      orderby a.TR_COMP_DISP
                      select new { Key = a.TR_COMP, Value = a.TR_COMP_DISP + "-" + a.TR_COMP_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //課程類別代碼資料
        public static Dictionary<string, string> GetTRTYPE()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.TRTYPE
                      orderby a.TR_TYPE_DISP
                      select new { Key = a.TR_TYPE, Value = a.TR_TYPE_DISP + "-" + a.DESCR };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //課程評估代碼資料
        public static Dictionary<string, string> GetTRASSCODE()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.TRASSCODE
                      orderby a.TR_ASNO_DISP
                      select new { Key = a.TR_ASNO, Value = a.TR_ASNO_DISP + "-" + a.TR_ASNAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //計劃代碼資料
        public static Dictionary<string, string> GetINSGRLV()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.INSGRLV
                      orderby a.PLAN_NO_DISP
                      select new { Key = a.PLAN_NO, Value = a.PLAN_NO_DISP };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //取得所有眷屬身份證號碼資料
        public static Dictionary<string, string> GetFA_IDNO()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = (from a in db.FAMILY
                       where a.FA_IDNO.Length > 0
                       orderby a.FA_IDNO
                       select new { Key = a.FA_IDNO, Value = a.FA_IDNO + "-" + a.FA_NAME }).Distinct();
            int count = sql.Count();

            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //依員工號碼取得眷屬身份證號碼資料
        public static Dictionary<string, string> GetFA_IDNO(string nobr)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = (from a in db.FAMILY
                       where a.FA_IDNO.Length > 0 && a.NOBR == nobr
                       orderby a.FA_IDNO
                       select new { Key = a.FA_IDNO, Value = a.FA_IDNO + "-" + a.FA_NAME }).Distinct();
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        /// <summary>
        /// 所得格式代碼
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetFormat()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.YRFORMAT
                      orderby a.M_FORMAT
                      select new { Key = a.M_FORMAT, Value = a.M_FORMAT + "-" + a.M_FMT_NAME.Trim() };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        /// <summary>
        /// 所得註記代碼
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetForsub(string format)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.TW_TAX_SUBCODE
                      where a.M_FORMAT == format
                      orderby a.M_FORMAT
                      select new { Key = a.AUTO.ToString(), Value = a.M_FORSUB + "-" + a.M_SUB_NAME.Trim() };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //共用代碼資料
        public static Dictionary<string, string> GetMtCode(string category)
        {
            return GetMtCode(category, true);
        }
        public static Dictionary<string, string> GetMtCode(string category , bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.MTCODE
                      where a.CATEGORY == category && a.DISPLAY
                      orderby a.SORT
                      select new { Key = a.CODE, Value = ValueWithKey ? a.CODE + "-" + a.NAME : a.NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //通知種類
        public static Dictionary<string, string> GetNotifyClass()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.NotifyClass
                      where a.Comp == MainForm.COMPANY
                      select new { Key = a.Code, Value = a.DisplayName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //編制課別
        public static Dictionary<string, string> GetLessonType()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.LessonType
                      select new { Key = a.LessonCode, Value = a.LessonCode + "-" + a.LessonName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //成本別
        public static Dictionary<string, string> GetCostType()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.CostType
                      select new { Key = a.CostTypeCode, Value = a.CostTypeCode + "-" + a.CostTypeName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //成本別
        public static Dictionary<string, string> GetBonusGroup()
        {
            return GetBonusGroup(true);
        }
        public static Dictionary<string, string> GetBonusGroup(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.BonusGroup
                      select new { Key = a.Code, Value = ValueWithKey ? a.Code + "-" + a.GroupName : a.GroupName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //組別
        public static Dictionary<string, string> GetGroupType()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.GroupType
                      select new { Key = a.GroupCode, Value = a.GroupCode + "-" + a.GroupName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //責任區別
        public static Dictionary<string, string> GetResponsibilityType()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ResponsibilityType
                      select new { Key = a.ResponsibilityCode, Value = a.ResponsibilityCode + "-" + a.ResponsibilityName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //殘障類別
        public static Dictionary<string, string> GetDisabilityType()
        {
            return GetDisabilityType(true);
        }
        public static Dictionary<string, string> GetDisabilityType(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DisabilityType
                      select new { Key = a.DisabilityCode, Value = ValueWithKey? a.DisabilityCode + "-" + a.DisabilityName : a.DisabilityName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //殘障身分
        public static Dictionary<string, string> GetDisabilityRank()
        {
            return GetDisabilityRank(true);
        }
        public static Dictionary<string, string> GetDisabilityRank(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DisabilityRank
                      select new { Key = a.DisabilityRankCode, Value = ValueWithKey?a.DisabilityRankCode + "-" + a.DisabilityRankName : a.DisabilityRankName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //ERPCODE
        public static Dictionary<string, string> GetERPCODE()
        {
            return GetERPCODE(true);
        }
        public static Dictionary<string, string> GetERPCODE(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ERPCODE
                      select new { Key = a.ERP_CODE, Value = ValueWithKey ? a.ERP_CODE + "-" + a.ERP_NAME : a.ERP_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //教育訓練課程名稱
        public static Dictionary<string, string> GetCOURSE()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.TRCOSC
                      orderby a.DATE_B descending
                      select new { Key = a.GUID, Value = string.Format(@"{3} - {0}-(開課日期:{1} 講師:{2})", a.COURSE, a.DATE_B.ToShortDateString(), a.TR_TEACH, a.CODE) };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        static List<string> _holiList = null;
        public static List<string> GetHolidayRoteList()
        {
            if (_holiList == null)
            {
                var db = new JBModule.Data.Linq.HrDBDataContext();
                _holiList = (from a in db.ROTE where a.ON_TIME.Trim().Length == 0 && a.OFF_TIME.Trim().Length == 0 && a.WK_HRS == 0 select a.ROTE1).ToList();
            }
            return _holiList;
        }
        //餐別代碼
        public static Dictionary<string, string> GetMealType(string mealgroup)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.MealType
                      where a.MealGroup == mealgroup
                      select new { Key = a.MealType_Code, Value = a.MealType_Code + "-" + a.MealType_Name };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        public static Dictionary<string, string> GetMealGroup()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.MealGroup
                      where db.GetCodeFilter("MealGroup", a.MealGroup_Code, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.MealGroup_DISP
                      select new { Key = a.MealGroup_Code, Value = a.MealGroup_DISP + "-" + a.MealGroup_Name };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        public static Dictionary<string, string> GetDiversionAttendType()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DiversionAttendType
                      //where db.GetCodeFilter("MealGroup", a.MealGroup_Code, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.DiversionAttendType1
                      select new { Key = a.DiversionAttendType1, Value = a.DiversionAttendType1 + "-" + a.DiversionAttendTypeName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        public static void SetDefaultValue(object _obj)
        {
            PropertyInfo[] properties = _obj.GetType().GetProperties();
            foreach (PropertyInfo Property in properties)
            {
                string TypeString = Property.PropertyType.FullName;
                switch (TypeString.Trim())
                {
                    case "System.String":
                        Property.SetValue(_obj, "", null);
                        break;
                    case "System.Boolean":
                        Property.SetValue(_obj, false, null);
                        break;
                    case "System.Nullable`1[System.Boolean]":
                        Property.SetValue(_obj, false, null);
                        break;
                    case "System.Nullable`1[System.Decimal]":
                        Property.SetValue(_obj, Convert.ToDecimal(0), null);
                        break;
                    case "System.Decimal":
                        Property.SetValue(_obj, Convert.ToDecimal(0), null);
                        break;
                    case "System.Nullable`1[System.Int32]":
                        Property.SetValue(_obj, 0, null);
                        break;
                    case "System.Int32":
                        Property.SetValue(_obj, 0, null);
                        break;
                    case "System.Int64":
                        Property.SetValue(_obj, 0, null);
                        break;
                    case "System.Int16":
                        Property.SetValue(_obj, 0, null);
                        break;
                    case "System.Nullable`1[System.Double]":
                        Property.SetValue(_obj, Convert.ToDouble(0.00), null);
                        break;
                    case "System.Double":
                        Property.SetValue(_obj, 0.00, null);
                        break;
                    case "System.DateTime":
                        Property.SetValue(_obj, DateTime.Parse("1900/01/01"), null);
                        break;
                    case "System.Nullable`1[System.DateTime]":
                        Property.SetValue(_obj, DateTime.Parse("1900/01/01"), null);
                        break;

                }
            }
        }
        //選單群組
        public static Dictionary<string, string> GetMenuGroupID()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.MenuGroup
                      select new { Key = a.MenuGroupID, Value = a.MenuGroupName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key.ToString(), p => p.Value);
            return lst;
        }

        public static System.Linq.IQueryable<MenuStripStructure> GetMenuStripStructures(string MenuStripName, string MenuStripText, bool CommonItem, string AssemblyName, bool Enable, string ShortcutKeys)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var lst = db.MenuStripStructure.Where(p => p.MenuStripName.Equals(MenuStripName) && p.MenuStripText.Equals(MenuStripText)
                      && p.CommonItem == CommonItem && p.Enable == Enable
                      && (p.AssemblyName.Equals(AssemblyName) || (p.AssemblyName == null && AssemblyName == null))
                      && (p.ShortcutKeys.Equals(ShortcutKeys) || (p.ShortcutKeys == null && ShortcutKeys == null)));
            return lst;
        }

        //使用者自定義欄位
        public static Dictionary<string, string> GetUserDefineGroupID()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.UserDefineGroup
                      select new { Key = a.UserDefineGroupID, Value = a.UserDefineGroupName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key.ToString(), p => p.Value);
            return lst;
        }
        //使用者自定義欄位主檔
        public static Dictionary<string, string> GetUserDefineMasterID()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.UserDefineMaster
                      select new { Key = a.UserDefineMasterID, Value = a.UserDefineMasterName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key.ToString(), p => p.Value);
            return lst;
        }
        public static Guid GetUDFLabelIDbyPorpValue(Guid UserDefineGroupID, string Type, string PorpName, string PropValue)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.UserDefineLayout
                      where a.UserDefineGroupID.Equals(UserDefineGroupID) && (Type != string.Empty ? a.Type == Type : true)//a.Type == "Label"
                      //select new { Label = JsonConvert.DeserializeObject<Dictionary<string, string>>(a.Tag)["Text"].ToString() + "_" + a.ControlID.ToString() };
                      select new { a.Tag, a.ControlID };
            if (sql.Any())
            {
                var lst = sql.Distinct().AsEnumerable().ToList();
                var result = lst.Where(p => JsonConvert.DeserializeObject<Dictionary<string, string>>(p.Tag)[PorpName].ToString() == PropValue).FirstOrDefault();
                return result != null ? result.ControlID : Guid.Empty;
            }
            else
                return Guid.Empty;
        }

        public static string GetUDFControlPropValuebyID(Guid UserDefineGroupID, Guid ControlID, string PorpName)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = (from a in db.UserDefineLayout
                       where a.ControlID.Equals(ControlID)
                       //select new { Label = JsonConvert.DeserializeObject<Dictionary<string, string>>(a.Tag)["Text"].ToString() + "_" + a.ControlID.ToString() };
                       select new { a.Tag, a.ControlID }).FirstOrDefault();
            if (sql != null)
            {
                Dictionary<string, string> TagList = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(sql.Tag))
                    TagList = JsonConvert.DeserializeObject<Dictionary<string, string>>(sql.Tag);//反序列化

                return TagList.ContainsKey(PorpName) ? TagList[PorpName] : string.Empty;
            }
            else
                return string.Empty;
        }

        public static Dictionary<string, string> GetUDFSourcebySourceScript(string SourceScript, string ValueMember, string DisplayMember)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            Dictionary<string, string> lst = new Dictionary<string, string>();

            using (SqlConnection conn = new SqlConnection(db.Connection.ConnectionString))
            {
                if (!string.IsNullOrWhiteSpace(ValueMember) && !string.IsNullOrWhiteSpace(DisplayMember) && !string.IsNullOrWhiteSpace(SourceScript))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@UserId", MainForm.USER_ID, DbType.String, ParameterDirection.Input);
                    parameters.Add("@Company", MainForm.COMPANY, DbType.String, ParameterDirection.Input);
                    parameters.Add("@Admin", MainForm.ADMIN, DbType.Boolean, ParameterDirection.Input);

                    var res = conn.Query(SourceScript, parameters);

                    foreach (dynamic rec in res)
                    {
                        var d = rec as IDictionary<string, object>;
                        char[] delimiterString = { ',' };
                        var Sql = DisplayMember.Split(delimiterString, StringSplitOptions.RemoveEmptyEntries);
                        string DisplayStr = string.Empty;
                        foreach (var item in Sql)
                            DisplayStr += "-" + d[item].ToString();
                        lst.Add(d[ValueMember].ToString(), DisplayStr.Remove(0, 1));
                    }
                }
            }
            return lst;
        }
        public static string GetUDFControlTagPropByID(Guid ControlID, string TagName)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var label = db.UserDefineLayout.Where(p => p.ControlID.Equals(ControlID)).FirstOrDefault();
            if (label != null)
            {
                Dictionary<string, string> TagList = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(label.Tag))
                    TagList = JsonConvert.DeserializeObject<Dictionary<string, string>>(label.Tag);//反序列化

                return TagList.ContainsKey(TagName) ? TagList[TagName].ToString() : string.Empty;
            }
            else
                return string.Empty;
        }
        public static string GetUDFControlTagPropByID(Guid ControlID, string TagName, List<UserDefineLayout> userDefineLayouts)
        {
            var label = userDefineLayouts.Where(p => p.ControlID.Equals(ControlID)).FirstOrDefault();
            if (label != null)
            {
                Dictionary<string, string> TagList = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(label.Tag))
                    TagList = JsonConvert.DeserializeObject<Dictionary<string, string>>(label.Tag);//反序列化

                return TagList.ContainsKey(TagName) ? TagList[TagName].ToString() : string.Empty;
            }
            else
                return string.Empty;
        }

        public static Type GetUDFDataTypeByControlType(string ControlType)
        {
            Type DataType = typeof(object);
            switch (ControlType)
            {
                case "Label":
                    DataType = typeof(string);
                    break;
                case "CheckBox":
                    DataType = typeof(bool);
                    break;
                case "TextBox":
                    DataType = typeof(string);
                    break;
                case "ComboBox":
                    DataType = typeof(string);
                    break;
                case "DateTimePicker":
                    DataType = typeof(DateTime);
                    break;
                case "NumericUpDown":
                    DataType = typeof(decimal);
                    break;
                default:
                    DataType = typeof(object);
                    break;
            }
            return DataType;
        }
        public static Type GetTypeByValidType (string value)
        {
            Type DataType = typeof(string);
            switch (value)
            {
                case "DATETIME":
                    DataType = typeof(DateTime);
                    break;
                case "DATE":
                    DataType = typeof(DateTime);
                    break;
                case "TIME":
                    DataType = typeof(DateTime);
                    break;
                case "INTERGER":
                    DataType = typeof(int);
                    break;
                case "DECIMAL":
                    DataType = typeof(decimal);
                    break;
                case "BOOLEAN":
                    DataType = typeof(bool);
                    break;
            }
            return DataType;
        }
        public static Dictionary<string, string> GetRuleType()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.RuleCode
                      orderby a.RuleCode1
                      select new { Key = a.RuleCode1, Value = a.RuleCode1 + "-" + a.RuleName };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        public static string GetUserDefineValue(JBModule.Data.Linq.HrDBDataContext db, string Code, string ParameterLabel, string DefaultValue)
        {
            //var UDFG = db.COMP1.Where(p => p.COMP == MainForm.COMPANY).First().UserDefineMasterID;
            //var UDL = db.UserDefineLayout.Where(p => p.UserDefineGroupID.Equals(UDFG)).ToList();
            //var UDV = db.UserDefineValue.Where(p=>p.Code == Employee).ToList();
            //var ControlID = (from udl in UDL
            //                where udl.UserDefineGroupID.Equals(UDFG) && udl.Type != "Label" 
            //                && GetUDFControlTagPropByID(udl.ControlID, "ParameterName", UDL) == ParameterLabel
            //                select udl.ControlID).ToList();
            //var ValueSql = from udv in UDV
            //          where db.GetFilterByNobr(Employee, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
            //          && ControlID.Contains(udv.ControlID) && udv.Code == Employee
            //          select new { Key = ParameterLabel, Value = udv.Value };
            return db.GetUserDefineValue(ParameterLabel, Code, DefaultValue);
        }
        public static void UpdateAppconfig(string category, string comp, string code, string value)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var oldappconfig = db.AppConfig.FirstOrDefault(p => p.Category == category && p.Code == code && p.Comp == comp);
            if (oldappconfig != null)
            {
                oldappconfig.Value = value;
                db.SubmitChanges();
            }
        }

        #region 宏亞客制
        public static Dictionary<string, string> GetHunya_PAGroupCode()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.Hunya_PAGroupCode
                      where db.GetCodeFilter("Hunya_PAGroupCode", a.PAGroupCode, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.PAGroupCode_Disp
                      select new { Key = a.PAGroupCode, Value = a.PAGroupCode_Disp + "-" + a.PAGroupCode_Name };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        public static Dictionary<string, string> GetHunya_PALevelCode()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.Hunya_PALevelCode
                      where db.GetCodeFilter("Hunya_PALevelCode", a.PALevelCode, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.PALevelCode_DISP
                      select new { Key = a.PALevelCode, Value = a.PALevelCode_DISP + "-" + a.PALevelCode_Name };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        public static Dictionary<string, string> GetHunya_DIVDAppraisalCode()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.Hunya_DIVDAppraisalCode
                      where db.GetCodeFilter("Hunya_DIVDAppraisalCode", a.DIVDAppraisalCode, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.DIVDAppraisalCode_Disp
                      select new { Key = a.DIVDAppraisalCode, Value = a.DIVDAppraisalCode_Disp + "-" + a.DIVDAppraisalCode_Name };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        public static Dictionary<string, string> GetHunya_ABTypeCode()
        {
            return GetHunya_ABTypeCode(true);
        }

        public static Dictionary<string, string> GetHunya_ABTypeCode(bool ValueWithKey)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.MTCODE
                      where a.CATEGORY == "Hunya_ABAppraisalABTypeCode"
                      orderby a.SORT
                      select new { Key = a.CODE, Value = ValueWithKey ? a.CODE + "-" + a.NAME : a.NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        public static Dictionary<string, string> GetHunya_ABLevelCode()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.Hunya_ABLevelCode
                      where db.GetCodeFilter("Hunya_ABLevelCode", a.ABLevelCode, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.ABLevelCode_DISP
                      select new { Key = a.ABLevelCode, Value = a.ABLevelCode_DISP + "-" + a.ABLevelCode_Name };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        #endregion
    }
}
