using System;
using System.Collections.Generic;
using System.Linq;
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
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in MainForm.WriteRules
                      orderby a.DATAGROUP
                      select new { Key = a.DATAGROUP, Value = a.DATAGROUP + "-" + a.DATAGROUP1.GROUPNAME };
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
        public static Dictionary<string, string> GetDept()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DEPT
                      where db.GetCodeFilter("DEPT", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                            && a.ADATE <= System.DateTime.Today && a.DDATE >= System.DateTime.Today
                      orderby a.D_NO_DISP
                      select new { Key = a.D_NO, Value = a.D_NO_DISP + "-" + a.D_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //編制部門代碼資料
        public static Dictionary<string, string> GetDept_effe()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DEPT
                      where db.GetCodeFilter("DEPT", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && a.ADATE <= System.DateTime.Today && a.DDATE >= System.DateTime.Today
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
        public static Dictionary<string, string> GetDepts()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DEPTS
                      where db.GetCodeFilter("DEPTS", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && a.ADATE <= System.DateTime.Today && a.DDATE >= System.DateTime.Today
                      orderby a.D_NO_DISP
                      select new { Key = a.D_NO, Value = a.D_NO_DISP + "-" + a.D_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //成本部門代碼資料--過濾失效資料
        public static Dictionary<string, string> GetDepts_effe()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DEPTS
                      where db.GetCodeFilter("DEPTS", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && a.ADATE <= System.DateTime.Today && a.DDATE >= System.DateTime.Today
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
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.RELCODE
                      orderby a.REL_CODE
                      select new { Key = a.REL_CODE, Value = a.REL_CODE + "-" + a.REL_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //工作地點代碼資料
        public static Dictionary<string, string> GetWorkcd()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.WORKCD
                      orderby a.WORK_CODE
                      select new { Key = a.WORK_CODE, Value = a.WORK_CODE + "-" + a.WORK_ADDR };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //離職原因代碼資料
        public static Dictionary<string, string> GetOutcd()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.OUTCD
                      orderby a.OUTCD1
                      select new { Key = a.OUTCD1, Value = a.OUTCD1 + "-" + a.OUTNAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //異動因代碼資料
        public static Dictionary<string, string> GetTtscd()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.TTSCD
                      where db.GetCodeFilter("TTSCD", a.TTSCD1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.TTSCD_DISP
                      select new { Key = a.TTSCD1, Value = a.TTSCD_DISP + "-" + a.TTSNAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //員別代碼資料
        public static Dictionary<string, string> GetEmpcd()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.EMPCD
                      orderby a.EMPCD1
                      select new { Key = a.EMPCD1, Value = a.EMPCD1 + "-" + a.EMPDESCR };
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
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.PROVCD
                      orderby a.PROV_CODE
                      select new { Key = a.PROV_CODE, Value = a.PROV_CODE + "-" + a.DESCR };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //國別代碼資料
        public static Dictionary<string, string> GetCountcd()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.COUNTCD
                      orderby a.CODE
                      select new { Key = a.CODE, Value = a.CODE + "-" + a.DESCR };
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
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.BASECD
                      orderby a.BASECD1
                      select new { Key = a.BASECD1, Value = a.BASECD1 + "-" + a.BASECDNAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //銀行代碼資料
        public static Dictionary<string, string> GetBankCode()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.BankCode
                      where db.GetCodeFilter("BankCode", a.Code, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.CODE_DISP
                      select new { Key = a.Code, Value = a.CODE_DISP + "-" + a.BankName };
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
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.CANDIDATES_WAYS
                      orderby a.Code
                      select new { Key = a.Code, Value = a.Code + "-" + a.WayName };
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
        //助理系統只看扣假
        public static Dictionary<string, string> GetHcode_Assist()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.HCODE
                      where db.GetCodeFilter("HCODE", a.H_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          //&& a.H_CODE[0].ToString() != "W"
                      && !new string[] { "1", "3", "5", "7", "9" }.Contains(a.YEAR_REST)
                      orderby a.H_CODE_DISP
                      select new { Key = a.H_CODE, Value = a.H_CODE_DISP + "-" + a.H_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //過濾假別屬性假別代碼資料
        public static Dictionary<string, string> GetHcode(string htype)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.HCODE
                      where db.GetCodeFilter("HCODE", a.H_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && a.HTYPE == htype
                      orderby a.H_CODE_DISP
                      select new { Key = a.H_CODE, Value = a.H_CODE_DISP + "-" + a.H_NAME };
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
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ROTET
                      where db.GetCodeFilter("ROTET", a.ROTET1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.ROTET_DISP
                      select new { Key = a.ROTET1, Value = a.ROTET_DISP + "-" + a.ROTETNAME };
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
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.HOLICD
                      where db.GetCodeFilter("HOLICD", a.HOLI_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.HOLI_CODE_DISP
                      select new { Key = a.HOLI_CODE, Value = a.HOLI_CODE_DISP + "-" + a.HOLI_NAME };
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
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.OTRATECD
                      orderby a.OTRATE_CODE
                      select new { Key = a.OTRATE_CODE, Value = a.OTRATE_CODE + "-" + a.OTRATE_NAME };
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
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.SALTYCD
                      orderby a.SALTYCD1
                      select new { Key = a.SALTYCD1, Value = a.SALTYCD1 + "-" + a.SALTYNAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

        //薪資屬性資料
        public static Dictionary<string, string> GetSalattr()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.SALATTR
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
                      select new { Key = a.M_FORMAT, Value = a.M_FORMAT + "-" + a.M_FMT_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
        //共用代碼資料
        public static Dictionary<string, string> GetMtCode(string category)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.MTCODE
                      where a.CATEGORY == category && a.DISPLAY
                      orderby a.CODE
                      select new { Key = a.CODE, Value = a.CODE + "-" + a.NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }

    }
}
