using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bll.Bas.Vdb;
using System.Data;
using JBModule.Data.Linq;
using Bll.Tools;

namespace Dal.Dao.Bas
{
    public class BasDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;
        private string[] arrTtscode = { "1", "4", "6" };
        private DateTime DateNow = DateTime.Now.Date;

        /// <summary>
        /// 員工基本資料
        /// </summary>
        /// <param name="conn">連接字串 沒有等於預設</param>
        public BasDao(IDbConnection conn = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (conn != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 員工基本資料
        /// </summary>
        /// <param name="ConnectionString"></param>
        public BasDao(string ConnectionString = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (ConnectionString != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(ConnectionString);
        }

        /// <summary>
        /// 取得員工基本資料
        /// </summary>
        /// <param name="sNobr">工號 空白等於全部</param>
        /// <param name="bIn">是否一定要在職</param>
        /// <returns>BaseTable</returns>
        public List<BaseTable> GetBase(string sNobr = "", bool bIn = true)
        {
            var Vdb = (from b in dcHr.BASE
                       join b1 in dcHr.BASETTS
                       on b.NOBR.Trim() equals b1.NOBR.Trim()
                       where (bIn ? arrTtscode.Contains(b1.TTSCODE.Trim()) : true)
                       && (sNobr == "" || b1.NOBR.Trim() == sNobr)
                       && b1.ADATE.Date.CompareTo(DateNow) <= 0
                       && DateNow.CompareTo(b1.DDATE.Value.Date) <= 0
                       select new BaseTable
                       {
                           Nobr = b.NOBR.Trim(),
                           NameC = b.NAME_C.Trim(),
                           NameE = b.NAME_E.Trim(),
                           Name = b.NAME_C.Trim() + "," + b1.NOBR.Trim(),
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得員工基本資料 依工號 包含離職員工
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <returns>BaseTable</returns>
        public List<BaseTable> GetBase(string sNobr)
        {
            var Vdb = (from b in dcHr.BASE
                       where b.NOBR.Trim() == sNobr.Trim()
                       select new BaseTable
                       {
                           Nobr = b.NOBR.Trim(),
                           NameC = b.NAME_C.Trim(),
                           NameE = b.NAME_E.Trim(),
                           Name = b.NAME_C.Trim() + "," + b.NOBR.Trim(),
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得員工基本資料 依工號 包含離職員工
        /// </summary>
        /// <param name="lsNobr">工號</param>
        /// <returns>BaseTable</returns>
        public List<BaseTable> GetBase(List<string> lsNobr)
        {
            var Vdb = (from b in dcHr.BASE
                       where lsNobr.Contains(b.NOBR.Trim())
                       select new BaseTable
                       {
                           Nobr = b.NOBR.Trim(),
                           NameC = b.NAME_C.Trim(),
                           NameE = b.NAME_E.Trim(),
                           Name = b.NAME_C.Trim() + "," + b.NOBR.Trim(),
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得員工基本資料 依工號
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="sDeptCate">1 = 編制部門 , 2 = 簽核部門</param>
        /// <param name="bDeptDown">部門是否向下</param>
        /// <param name="bIn">是否一定要在職</param>
        /// <returns>BaseTable</returns>
        public List<BaseTable> GetBaseByNobr(string sNobr, string sDeptCate = "1", bool bDeptDown = true, bool bIn = true)
        {
            //取得員工部門
            var rBasetts = (from b1 in dcHr.BASETTS
                            where b1.NOBR.Trim() == sNobr
                            && b1.ADATE.Date.CompareTo(DateNow) <= 0
                            && DateNow.CompareTo(b1.DDATE.Value.Date) <= 0
                            select b1).FirstOrDefault();

            List<string> lsDept = new List<string>();

            string sDept = "";

            DeptDao oDeptDao = new DeptDao(dcHr.Connection);
            Bll.Bas.Dept oDept = new Bll.Bas.Dept();
            Dictionary<string, string> dcDept = new Dictionary<string, string>();
            List<DeptRow> rsDept = new List<DeptRow>();

            if (rBasetts != null)
            {
                if (sDeptCate == "1")
                {
                    rsDept = oDeptDao.GetDept();

                    var rsDeptByNobr = rsDept.Where(p => p.Manage == sNobr).ToList();
                    foreach (var rDept in rsDeptByNobr)
                        lsDept.Add(rDept.Code.Trim());

                    sDept = rBasetts.DEPT.Trim();
                }
                else
                {
                    rsDept = oDeptDao.GetDeptm();

                    var rsDeptByNobr = rsDept.Where(p => p.Manage == sNobr).ToList();
                    foreach (var rDept in rsDeptByNobr)
                        lsDept.Add(rDept.Code.Trim());

                    sDept = rBasetts.DEPTM.Trim();
                }

                if (!lsDept.Contains(sDept))
                    lsDept.Add(sDept);
            }

            if (bDeptDown)
            {
                dcDept = rsDept.ToDictionary(p => p.Code, p => p.ParentCode);
                lsDept = oDept.GetDeptDowmList(dcDept, lsDept);
            }

            var Vdb = (from b in dcHr.BASE
                       join b1 in dcHr.BASETTS
                       on b.NOBR.Trim() equals b1.NOBR.Trim()
                       where (bIn ? arrTtscode.Contains(b1.TTSCODE.Trim()) : true)
                       && b1.ADATE.Date.CompareTo(DateNow) <= 0
                       && DateNow.CompareTo(b1.DDATE.Value.Date) <= 0
                       && lsDept.Contains((sDeptCate == "1") ? b1.DEPT.Trim() : b1.DEPTM.Trim())
                       select new BaseTable
                       {
                           Nobr = b.NOBR.Trim(),
                           NameC = b.NAME_C.Trim(),
                           NameE = b.NAME_E.Trim(),
                           Name = b.NAME_C.Trim() + "," + b.NOBR.Trim(),
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得員工基本資料 依工號
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">生效日期</param>
        /// <returns>BaseTable</returns>
        public List<BaseDetailTable> GetBaseByNobr(string sNobr, DateTime dDate)
        {
            var Vdb = (from b1 in dcHr.BASETTS
                       join b in dcHr.BASE
                       on b1.NOBR.Trim() equals b.NOBR.Trim()
                       join d in dcHr.DEPT
                       on b1.DEPT.Trim() equals d.D_NO.Trim()
                       join ds in dcHr.DEPTS
                       on b1.DEPTS.Trim() equals ds.D_NO.Trim()
                       join dm in dcHr.DEPTA
                       on b1.DEPTM.Trim() equals dm.D_NO.Trim()
                       join j in dcHr.JOB
                       on b1.JOB.Trim() equals j.JOB1.Trim()
                       join jl in dcHr.JOBL
                       on b1.JOBL.Trim() equals jl.JOBL1.Trim()
                       join wc in dcHr.WORKCD
                       on b1.WORKCD.Trim() equals wc.WORK_CODE.Trim()
                       where b1.NOBR.Trim() == sNobr
                       && b1.ADATE.Date <= dDate.Date
                       && dDate.Date <= b1.DDATE.Value.Date
                       select new BaseDetailTable
                       {
                           Nobr = b1.NOBR.Trim(),
                           NameC = b.NAME_C.Trim(),
                           NameE = b.NAME_E.Trim(),
                           Birthday = b.BIRDT.Value.Date,
                           Sex = b.SEX.Trim() == "M" ? Bll.MT.mtEnum.SexCategroy.Male : Bll.MT.mtEnum.SexCategroy.Female,
                           IDNo = b.IDNO.Trim(),
                           PassWord = b.PASSWORD.Trim(),
                           DateA = b1.ADATE.Date,
                           DateD = b1.DDATE.Value.Date,
                           DateOut = b1.OUDT.GetValueOrDefault(new DateTime(1900, 1, 1)),
                           DateIn = b1.INDT.GetValueOrDefault(new DateTime(1900, 1, 1)),
                           Ttscode = b1.TTSCODE.Trim(),
                           Comp = b1.COMP.Trim(),
                           DI = b1.DI.Trim(),
                           JobCode = b1.JOB.Trim(),
                           JobName = j.JOB_NAME.Trim(),
                           JobEName = j.JOB_ENAME,
                           JoblCode = b1.JOBL.Trim(),
                           JoblName = jl.JOB_NAME.Trim(),
                           DeptCode = b1.DEPT.Trim(),
                           DeptName = d.D_NAME.Trim(),
                           DeptmCode = b1.DEPTM.Trim(),
                           DeptmName = dm.D_NAME.Trim(),
                           DeptsCode = b1.DEPTS.Trim(),
                           DeptsName = ds.D_NAME.Trim(),
                           CalOt = b1.CALOT.Trim(),
                           Holi = b1.HOLI_CODE.Trim(),
                           Mang = b1.MANG,
                           Mang1 = b1.MANG1,
                           Rotet = b1.ROTET.Trim(),
                           Saladr = b1.SALADR.Trim(),
                           Workcd = b1.WORKCD.Trim(),
                           WorkcdName = wc.WORK_ADDR.Trim(),
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得員工基本資料 依工號
        /// </summary>
        /// <param name="lsNobr">工號</param>
        /// <param name="dDate">生效日期</param>
        /// <returns>BaseTable</returns>
        public List<BaseDetailTable> GetBaseByNobr(List<string> lsNobr, DateTime dDate)
        {
            var Vdb = (from b1 in dcHr.BASETTS
                       join b in dcHr.BASE
                       on b1.NOBR.Trim() equals b.NOBR.Trim()
                       join d in dcHr.DEPT
                       on b1.DEPT.Trim() equals d.D_NO.Trim()
                       join ds in dcHr.DEPTS
                       on b1.DEPTS.Trim() equals ds.D_NO.Trim()
                       join dm in dcHr.DEPTA
                       on b1.DEPTM.Trim() equals dm.D_NO.Trim()
                       join j in dcHr.JOB
                       on b1.JOB.Trim() equals j.JOB1.Trim()
                       join jl in dcHr.JOBL
                       on b1.JOBL.Trim() equals jl.JOBL1.Trim()
                       where lsNobr.Contains(b1.NOBR.Trim())
                       && b1.ADATE.Date <= dDate.Date
                       && dDate.Date <= b1.DDATE.Value.Date
                       select new BaseDetailTable
                       {
                           Nobr = b1.NOBR.Trim(),
                           NameC = b.NAME_C.Trim(),
                           NameE = b.NAME_E.Trim(),
                           Birthday = b.BIRDT.Value.Date,
                           Sex = b.SEX.Trim() == "M" ? Bll.MT.mtEnum.SexCategroy.Male : Bll.MT.mtEnum.SexCategroy.Female,
                           IDNo = b.IDNO.Trim(),
                           PassWord = b.PASSWORD.Trim(),
                           DateA = b1.ADATE.Date,
                           DateD = b1.DDATE.Value.Date,
                           DateOut = b1.OUDT.GetValueOrDefault(new DateTime(1900, 1, 1)),
                           Ttscode = b1.TTSCODE.Trim(),
                           Comp = b1.COMP.Trim(),
                           DI = b1.DI.Trim(),
                           JobCode = b1.JOB.Trim(),
                           JobName = j.JOB_NAME.Trim(),
                           JoblCode = b1.JOBL.Trim(),
                           JoblName = jl.JOB_NAME.Trim(),
                           DeptCode = b1.DEPT.Trim(),
                           DeptName = d.D_NAME.Trim(),
                           DeptmCode = b1.DEPTM.Trim(),
                           DeptmName = dm.D_NAME.Trim(),
                           DeptsCode = b1.DEPTS.Trim(),
                           DeptsName = ds.D_NAME.Trim(),
                           CalOt = b1.CALOT.Trim(),
                           Holi = b1.HOLI_CODE.Trim(),
                           Mang = b1.MANG,
                           Mang1 = b1.MANG1,
                           Rotet = b1.ROTET.Trim(),
                           Saladr = b1.SALADR.Trim(),
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得員工基本資料 依部門
        /// </summary>
        /// <param name="sDept">部門</param>
        /// <param name="sDeptCate">1 = 編制部門 , 2 = 簽核部門</param>
        /// <param name="bDeptDown">部門是否向下</param>
        /// <param name="bIn">是否一定要在職</param>
        /// <returns>BaseTable</returns>
        public List<BaseTable> GetBaseByDept(string sDept = "", string sDeptCate = "1", bool bDeptDown = true, bool bIn = true)
        {
            List<string> lsDept = new List<string>();

            DeptDao oDeptDao = new DeptDao(dcHr.Connection);
            Bll.Bas.Dept oDept = new Bll.Bas.Dept();
            Dictionary<string, string> dcDept = new Dictionary<string, string>();
            List<DeptRow> rsDept = new List<DeptRow>();


            if (sDeptCate == "1")
            {
                rsDept = oDeptDao.GetDept();
            }
            else
            {
                rsDept = oDeptDao.GetDeptm();
            }

            if (!lsDept.Contains(sDept))
                lsDept.Add(sDept);

            if (bDeptDown)
            {
                dcDept = rsDept.ToDictionary(p => p.Code, p => p.ParentCode);
                lsDept = oDept.GetDeptDowmList(dcDept, lsDept);
            }

            var Vdb = (from b in dcHr.BASE
                       join b1 in dcHr.BASETTS
                       on b.NOBR.Trim() equals b1.NOBR.Trim()
                       where (bIn ? arrTtscode.Contains(b1.TTSCODE.Trim()) : true)
                       && b1.ADATE.Date.CompareTo(DateNow) <= 0
                       && DateNow.CompareTo(b1.DDATE.Value.Date) <= 0
                       && lsDept.Contains((sDeptCate == "1") ? b1.DEPT.Trim() : b1.DEPTM.Trim())
                       select new BaseTable
                       {
                           Nobr = b.NOBR.Trim(),
                           NameC = b.NAME_C.Trim(),
                           NameE = b.NAME_E.Trim(),
                           Name = b.NAME_C.Trim() + "," + b.NOBR.Trim(),
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得員工異動資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">生效日</param>
        /// <returns>BasettsTable</returns>
        public List<BasettsTable> GetBasettsByNobr(string sNobr, DateTime? dDate)
        {
            var Vdb = (from b1 in dcHr.BASETTS
                       where b1.NOBR.Trim() == sNobr
                       && dDate == null ? true : (b1.ADATE.Date <= dDate.Value.Date && dDate.Value.Date <= b1.DDATE.Value.Date)
                       select new BasettsTable
                       {
                           Nobr = b1.NOBR.Trim(),
                           DateA = b1.ADATE.Date,
                           DateD = b1.DDATE.Value.Date,
                           DateIn = b1.INDT.GetValueOrDefault(new DateTime(1900, 1, 1)),
                           DateOut = b1.OUDT.GetValueOrDefault(new DateTime(1900, 1, 1)),
                           Ttscode = b1.TTSCODE.Trim(),
                           Comp = b1.COMP.Trim(),
                           DI = b1.DI.Trim(),
                           Job = b1.JOB.Trim(),
                           Jobl = b1.JOBL.Trim(),
                           Dept = b1.DEPT.Trim(),
                           Deptm = b1.DEPTM.Trim(),
                           Depts = b1.DEPTS.Trim(),
                           CalOt = b1.CALOT.Trim(),
                           Holi = b1.HOLI_CODE.Trim(),
                           Mang = b1.MANG,
                           Mang1 = b1.MANG1,
                           Rotet = b1.ROTET.Trim(),
                           Saladr = b1.SALADR.Trim(),
                       }).ToList();

            return Vdb;
        }
        /// <summary>
        /// 將調班資料存入HR.BASETTS實體資料表(長調) True = 存入成功
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">(異動)調班日期</param>
        /// <param name="sRotetCode">輪班序代碼</param>
        /// <param name="sHoliCode">行事曆代碼</param>
        /// <param name="sOtRateCode">加班率代碼</param>
        /// <param name="sNote">備註</param>
        /// <param name="sKeyMan">登錄者</param>
        /// <param name="sSerno">表單編號</param>
        /// <param name="bTransAtt">重新轉換班表</param>
        /// <returns>bool</returns>
        public bool BasettsSaveByShiftLong(string sNobr, DateTime dDate, string sRotetCode = "", string sHoliCode = "", string sOtRateCode = "", string sNote = "", string sKeyMan = "System", string sSerno = "", bool bTransAtt = true)
        {
            bool bBaseTtsSave = false;

            var lsA = (from c in dcHr.BASETTS
                       where c.NOBR.Trim() == sNobr.Trim()
                       select c).ToList();

            var rbA = lsA.Where(p => p.ADATE.Date <= dDate.Date && p.DDATE.Value >= dDate.Date).FirstOrDefault();

            if (rbA == null)
                return bBaseTtsSave;

            string sTtscd = "C11";

            if (rbA.ADATE.Date == dDate.Date)
            {
                if (sRotetCode.Length > 0)
                    rbA.ROTET = sRotetCode;
                if (sHoliCode.Length > 0)
                    rbA.HOLI_CODE = sHoliCode;
                if (sOtRateCode.Length > 0)
                    rbA.CALOT = sOtRateCode;
                rbA.TTSCODE = "6";
                rbA.TTSCD = sTtscd;
                rbA.KEY_MAN = sKeyMan;
                rbA.KEY_DATE = DateTime.Now;
            }
            else
            {
                var rbB = new BASETTS();
                rbA.CloneProperties<BASETTS>(rbB);
                if (sRotetCode.Length > 0)
                    rbB.ROTET = sRotetCode;
                if (sHoliCode.Length > 0)
                    rbB.HOLI_CODE = sHoliCode;
                //if (sHoliCode.Length > 0)
                //    rbB.HOLICD = dcHr.HOLICD.Single(p => p.HOLI_CODE == sHoliCode);
                if (sOtRateCode.Length > 0)
                    rbB.CALOT = sOtRateCode;
                rbB.ADATE = dDate.Date;
                rbB.TTSCODE = "6";
                rbB.TTSCD = sTtscd;
                rbB.KEY_MAN = sKeyMan;
                rbB.KEY_DATE = DateTime.Now;
                lsA.Add(rbB);
                dcHr.BASETTS.InsertOnSubmit(rbB);
            }

            var ls = lsA.OrderByDescending(p => p.ADATE.Date).ToList();

            DateTime dt = new DateTime(9999, 12, 31).Date;

            foreach (var r in ls)
            {
                r.DDATE = dt;
                dt = r.ADATE.Date.AddSeconds(-1);
            }

            dcHr.SubmitChanges();

            //執行班表重新產生

            bBaseTtsSave = true;
            return bBaseTtsSave;
        }
        /// <summary>
        /// 主要駐地城市
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public List<WorkRow> GetWorkcd(string sCode = "")
        {
            var Vdb = (from c in dcHr.WORKCD
                       where (sCode == "" || c.WORK_CODE.Trim() == sCode || c.WORK_ADDR.Trim() == sCode)
                       select new WorkRow
                       {
                           Code = c.WORK_CODE.Trim(),
                           Name = c.WORK_ADDR.Trim(),

                       }).ToList();

            return Vdb;
        }
        /// <summary>
        /// 異動原因
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public List<TtscdRow> GetTTSCD(string sCode = "")
        {
            var Vdb = (from c in dcHr.TTSCD
                       where sCode == "" || c.TTSCD1 == sCode
                       select new TtscdRow
                       {
                           Code = c.TTSCD_DISP.Trim(),
                           Name = c.TTSNAME.Trim(),
                           DisplayName = c.TTSNAME + "(" + c.TTSCD_DISP + ")",
                       }).ToList();

            return Vdb;
        }
        /// <summary>
        /// 取得所有在職員工
        /// </summary>
        /// <param name="dDate"></param>
        /// <returns></returns>
        public List<BaseTable> GetAllEmp()
        {
            var Vdb = (from b1 in dcHr.BASETTS
                       join b in dcHr.BASE on b1.NOBR equals b.NOBR
                       where arrTtscode.Contains(b1.TTSCODE.Trim())
                         && b1.ADATE.Date.CompareTo(DateNow) <= 0
                         && DateNow.CompareTo(b1.DDATE.Value.Date) <= 0
                       select new BaseTable
                       {
                           Nobr = b.NOBR.Trim(),
                           NameC = b.NAME_C.Trim(),
                           NameE = b.NAME_E.Trim(),
                           Name = b.NAME_C.Trim() + "," + b.NOBR.Trim(),
                       }).ToList();
            return Vdb;
        }
        /// <summary>
        /// 取得員工基本資料 依姓名 
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <returns>BaseTable</returns>
        public List<BaseTable> GetBaseByName(string sName)
        {
            var Vdb = (from b in dcHr.BASE
                       join b1 in dcHr.BASETTS on b.NOBR equals b1.NOBR
                       where b.NAME_C.Trim() == sName.Trim()
                       select new BaseTable
                       {
                           Nobr = b.NOBR.Trim(),
                           NameC = b.NAME_C.Trim(),
                           NameE = b.NAME_E.Trim(),
                           Name = b.NAME_C.Trim() + "," + b.NOBR.Trim(),
                       }).ToList();

            return Vdb;
        }
        /// <summary>
        /// 取得員工入口角色依功號
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <returns></returns>
        public List<sysUserRole> GetPortalRoleByNobr(string sNobr)
        {
            var Vdb = (from c in dcHr.sysUserRole
                       where c.NOBR == sNobr
                       select c).ToList();
            return Vdb;
        }
    }
}