using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Collections;
using System.Net.Mail;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;

namespace JBHR.Dll
{
    //public class AggDelegate
    //{
    //    public List<int> Values;
    //    delegate T Func<T>(T a, T b);
    //    static T Aggregate<T>(List<T> l, Func<T> f)
    //    {
    //        T result = default(T);
    //        bool firstLoop = true;
    //        foreach (T value in l)
    //        {
    //            if (firstLoop)
    //            {
    //                result = value;
    //                firstLoop = false;
    //            }
    //            else
    //            {
    //                result = f(result, value);
    //            }
    //        }
    //        return result;
    //    }
    //    public static void Demo()
    //    {
    //        AggDelegate l = new AggDelegate();
    //        int sum;
    //        sum = Aggregate(
    //        l.Values,
    //        delegate(int a, int b) { return a + b; }
    //        );
    //        Console.WriteLine("Sum = {0}", sum);
    //    }
    //    // Ö
    //}

    /// <summary>
    /// 相關基本資料(個人、部門、職稱…等)
    /// </summary>
    public static class Bas
    {
        //private static void FillData<T>(DbCommand cmd, T dt) where T : DataTable
        //{
        //    IDataReader dr = null;

        //    try
        //    {
        //        if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();
        //        dr = cmd.ExecuteReader();
        //        dt.Load(dr);
        //    }
        //    catch (Exception ex)
        //    {
        //        try
        //        {
        //            Tools.CreateTextFile("C:\\Error\\FillData" + DateTime.Now.ToFileTime().ToString() + ".txt", ex.ToString());
        //        }
        //        catch
        //        {
        //            throw ex;
        //        }
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dr.Close();
        //        cmd.Connection.Close();
        //    }
        //}

        /// <summary>
        /// 員工基本資料
        /// </summary>
        /// <param name="sNobr">工號或姓名</param>
        /// <returns>JB_HR_BaseDataTable</returns>
        public static dsBas.JB_HR_BaseDataTable EmpBase(string sNobr)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_Base> sql = from c in dc.JB_HR_Base select c;
            if (sNobr.Trim().Length > 0)
                sql = from c in dc.JB_HR_Base where c.sNobr.Trim() == sNobr.Trim() || c.sNameC.Trim() == sNobr.Trim() select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_BaseDataTable dt = new dsBas.JB_HR_BaseDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 多個員工基本資料(依照編制部門)
        /// </summary>
        /// <param name="sDeptCode">編制部門代碼</param>
        /// <returns>JB_HR_BaseDataTable</returns>
        public static dsBas.JB_HR_BaseDataTable EmpBaseByDept(string sDeptCode)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_Base> sql = from c in dc.JB_HR_Base
                                         where c.sDeptCode.Trim() == sDeptCode.Trim()
                                         select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_BaseDataTable dt = new dsBas.JB_HR_BaseDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 多個員工基本資料(依照編制部門向下展開)
        /// </summary>
        /// <param name="sDeptCode">編制部門代碼</param>
        /// <param name="sDI">直間接(DI=所有)</param>
        /// <returns>JB_HR_BaseDataTable</returns>
        public static dsBas.JB_HR_BaseDataTable EmpBaseByDeptAll(string sDeptCode, string sDI)
        {
            dsBas.JB_HR_DeptDataTable dtDept = Dept(DateTime.Now);
            string[] arrDept = dtDept.Where(p => p.sDeptPathCode.IndexOf("/" + sDeptCode + "/") >= 0).Select(p => p.sDeptCode).ToArray();

            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_Base> sql = from c in dc.JB_HR_Base
                                         where arrDept.Contains(c.sDeptCode.Trim())
                                         && (sDI == "DI" || c.sDI == sDI)
                                         orderby c.sName
                                         select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_BaseDataTable dt = new dsBas.JB_HR_BaseDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 多個員工基本資料(依照簽核部門)
        /// </summary>
        /// <param name="sDeptCode">編制部門代碼</param>
        /// <returns>JB_HR_BaseDataTable</returns>
        public static dsBas.JB_HR_BaseDataTable EmpBaseByDeptm(string sDeptCode)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_Base> sql = from c in dc.JB_HR_Base
                                         where c.sDeptmCode.Trim() == sDeptCode.Trim()
                                         select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_BaseDataTable dt = new dsBas.JB_HR_BaseDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 多個員工基本資料(依照簽核部門向下展開)
        /// </summary>
        /// <param name="sDeptCode">編制部門代碼</param>
        /// <param name="sDI">直間接(DI=所有)</param>
        /// <returns>JB_HR_BaseDataTable</returns>
        public static dsBas.JB_HR_BaseDataTable EmpBaseByDeptmAll(string sDeptCode, string sDI)
        {
            dsBas.JB_HR_DeptmDataTable dtDept = Deptm();
            string[] arrDept = dtDept.Where(p => p.sDeptPathCode.IndexOf("/" + sDeptCode + "/") >= 0).Select(p => p.sDeptCode).ToArray();

            string[] arrTtscode = { "1", "4", "6" };
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_Base> sql = from c in dc.JB_HR_Base
                                         where arrDept.Contains(c.sDeptmCode.Trim())
                                         && (sDI == "DI" || c.sDI == sDI)
                                         && (arrTtscode.Contains(c.sTtsCode.Trim())
                                         || c.dOuDate.Date >= DateTime.Now.Date.AddDays(-10))                                         
                                         orderby c.sName
                                         select c;

            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_BaseDataTable dt = new dsBas.JB_HR_BaseDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 多個員工基本資料(依照簽核部門向下展開)
        /// </summary>
        /// <param name="sDeptCode">編制部門代碼</param>
        /// <param name="sDI">直間接(DI=所有)</param>
        /// <param name="sUserID">登入者工號</param>
        /// <param name="sComp">公司別</param>
        /// <param name="bAdmin">是否管理權限</param>
        /// <returns>JB_HR_BaseDataTable</returns>
        public static dsBas.JB_HR_BaseDataTable EmpBaseByDeptmAllByAuth(string sDeptCode, string sDI, string sUserID, string sComp, bool bAdmin)
        {
            dsBas.JB_HR_DeptmDataTable dtDept = Deptm();
            string[] arrDept = dtDept.Where(p => p.sDeptPathCode.IndexOf("/" + sDeptCode + "/") >= 0).Select(p => p.sDeptCode).ToArray();

            string[] arrTtscode = { "1", "4", "6" };
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_Base> sql = from c in dc.JB_HR_Base
                                         where arrDept.Contains(c.sDeptmCode.Trim())
                                         && (sDI == "DI" || c.sDI == sDI)
                                         && (arrTtscode.Contains(c.sTtsCode.Trim())
                                         || c.dOuDate.Date >= DateTime.Now.Date.AddDays(-10))
                                         && dc.GetFilterByNobr(c.sNobr.Trim(), sUserID, sComp, bAdmin).Value
                                         orderby c.sName
                                         select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_BaseDataTable dt = new dsBas.JB_HR_BaseDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 多個員工基本資料(依照簽核部門向下展開)薪資群組
        /// </summary>
        /// <param name="sDeptCode">簽核部門代碼</param>
        /// <param name="sSalaryGroup">薪資群組(sSalaryGroup=AB)</param>
        /// <returns>JB_HR_BaseDataTable</returns>
        public static dsBas.JB_HR_BaseDataTable EmpBaseByDeptmSalary(string sDeptCode, string sSalaryGroup)
        {
            dsBas.JB_HR_DeptmDataTable dtDept = Deptm();
            string[] arrDept = dtDept.Where(p => p.sDeptPathCode.IndexOf("/" + sDeptCode + "/") >= 0).Select(p => p.sDeptCode).ToArray();

            string[] arrTtscode = { "1", "4", "6" };
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_Base> sql = from c in dc.JB_HR_Base
                                         where arrDept.Contains(c.sDeptmCode.Trim())
                                         && (sSalaryGroup == "AB" || c.sSaladr == sSalaryGroup)
                                         && arrTtscode.Contains(c.sTtsCode.Trim())
                                         orderby c.sName
                                         select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_BaseDataTable dt = new dsBas.JB_HR_BaseDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 多個員工基本資料(依照簽核部門向下展開)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="sDI">直間接(DI=所有)</param>
        /// <returns>JB_HR_BaseDataTable</returns>
        public static dsBas.JB_HR_BaseDataTable EmpBaseByNobrDeptmAll(string sNobr, string sDI)
        {
            dcBasDataContext dcBas = new dcBasDataContext();

            string[] arrDept = { };

            dsBas.JB_HR_DeptmDataTable dtDept = Deptm();

            if (sNobr.Trim().Length > 0)
            {
                var rEmp = EmpBase(sNobr).FirstOrDefault();

                if (rEmp != null)
                {
                    dsBas.JB_HR_DeptmRow rDeptm = null;
                    string sDept = rEmp.sDeptmCode;

                    do
                    {
                        rDeptm = dtDept.Where(p => p.sDeptCode == sDept).FirstOrDefault();
                        if (rDeptm.sDeptTree.CompareTo("75") < 0)
                            sDept = rDeptm.sDeptParent;
                    } while (rDeptm != null && rDeptm.sDeptTree.CompareTo("75") < 0);

                    arrDept = dtDept.Where(p => p.sDeptPathCode.IndexOf("/" + sDept + "/") >= 0).Select(p => p.sDeptCode).ToArray();

                    var rsDept = dtDept.Where(p => p.sNobr == sNobr);
                    foreach (var rDept in rsDept)
                        arrDept = dtDept.Where(p => p.sDeptPathCode.IndexOf("/" + rDept.sDeptCode + "/") >= 0).Select(p => p.sDeptCode).ToArray().Union(arrDept).ToArray();
                }
            }

            string[] arrTtscode = { "1", "4", "6" };
            dcBasDataContext dc = new dcBasDataContext();

            IQueryable<JB_HR_Base> sql = from c in dc.JB_HR_Base
                                         where (arrDept.Contains(c.sDeptmCode.Trim()) || sNobr == "0")
                                         && (sDI == "DI" || c.sDI == sDI)
                                         && (arrTtscode.Contains(c.sTtsCode.Trim())
                                         || c.dOuDate.Date >= DateTime.Now.Date.AddDays(-10))
                                         select c;

            var rU_USER = dc.U_USER.Where(p => p.NOBR == sNobr).FirstOrDefault();
            if (rU_USER != null)
            {
                sql = from c in dc.JB_HR_Base
                      where (arrDept.Contains(c.sDeptmCode.Trim()) || sNobr == "0"
                      || dc.GetFilterByNobr(c.sNobr, rU_USER.USER_ID, "JB-TRANSCARD", rU_USER.ADMIN).Value)
                      && (sDI == "DI" || c.sDI == sDI)
                      && (arrTtscode.Contains(c.sTtsCode.Trim())
                      || c.dOuDate.Date >= DateTime.Now.Date.AddDays(-10))
                      select c;
            }

            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_BaseDataTable dt = new dsBas.JB_HR_BaseDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 員工異動資料(依照工號)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <returns>JB_HR_BaseTtsDataTable</returns>
        public static dsBas.JB_HR_BaseTtsDataTable BaseTts(string sNobr)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_BaseTts> sql = from c in dc.JB_HR_BaseTts
                                            where c.sNobr.Trim() == sNobr.Trim()
                                            orderby c.dAdate.Date
                                            select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_BaseTtsDataTable dt = new dsBas.JB_HR_BaseTtsDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 員工異動資料(某一日期Between)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">日期</param>
        /// <returns>JB_HR_BaseTtsDataTable</returns>
        public static dsBas.JB_HR_BaseTtsDataTable BaseTts(string sNobr, DateTime dDate)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_BaseTts> sql = from c in dc.JB_HR_BaseTts
                                            where c.sNobr.Trim() == sNobr.Trim()
                                            && Convert.ToDateTime(c.dAdate).Date <= dDate.Date
                                            && dDate.Date <= Convert.ToDateTime(c.dDdate.Value).Date
                                            orderby c.dAdate.Date
                                            select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_BaseTtsDataTable dt = new dsBas.JB_HR_BaseTtsDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 員工異動資料(日期區間所包含的資料)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateA">開始日期</param>
        /// <param name="dDateD">結束日期</param>
        /// <returns>JB_HR_BaseTtsDataTable</returns>
        public static dsBas.JB_HR_BaseTtsDataTable BaseTts(string sNobr, DateTime dDateA, DateTime dDateD)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_BaseTts> sql = from c in dc.JB_HR_BaseTts
                                            where c.sNobr.Trim() == sNobr.Trim()
                                            && Convert.ToDateTime(c.dAdate).Date <= dDateD.Date
                                            && dDateA.Date <= Convert.ToDateTime(c.dDdate.Value).Date
                                            orderby c.dAdate.Date
                                            select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_BaseTtsDataTable dt = new dsBas.JB_HR_BaseTtsDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 員工異動資料(日期區間所包含的資料)
        /// </summary>
        /// <param name="sNobrB">開始工號</param>
        /// <param name="sNobrE">結束工號</param>
        /// <param name="dDateA">開始日期</param>
        /// <param name="dDateD">結束日期</param>
        /// <returns>JB_HR_BaseTtsDataTable</returns>
        public static dsBas.JB_HR_BaseTtsDataTable BaseTts(string sNobrB, string sNobrE, DateTime dDateA, DateTime dDateD)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_BaseTts> sql = from c in dc.JB_HR_BaseTts
                                            where c.sNobr.Trim().CompareTo(sNobrB.Trim()) >= 0
                                            && c.sNobr.Trim().CompareTo(sNobrE.Trim()) <= 0
                                            && Convert.ToDateTime(c.dAdate).Date <= dDateD.Date
                                            && dDateA.Date <= Convert.ToDateTime(c.dDdate.Value).Date
                                            orderby c.dAdate.Date
                                            select c;
            int count = sql.Count();
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_BaseTtsDataTable dt = new dsBas.JB_HR_BaseTtsDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 員工異動資料(日期區間所包含的資料)
        /// </summary>
        /// <param name="sNobrB">開始工號</param>
        /// <param name="sNobrE">結束工號</param>
        /// <param name="dDateA">開始日期</param>
        /// <param name="dDateD">結束日期</param>
        /// <param name="sUserID">登入者工號</param>
        /// <param name="sComp">公司別</param>
        /// <param name="bAdmin">是否管理權限</param>
        /// <returns>JB_HR_BaseTtsDataTable</returns>
        public static dsBas.JB_HR_BaseTtsDataTable BaseTts(string sNobrB, string sNobrE, DateTime dDateA, DateTime dDateD, string sUserID, string sComp, bool bAdmin)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_BaseTts> sql = from c in dc.JB_HR_BaseTts
                                            where c.sNobr.Trim().CompareTo(sNobrB.Trim()) >= 0
                                            && c.sNobr.Trim().CompareTo(sNobrE.Trim()) <= 0
                                            && Convert.ToDateTime(c.dAdate).Date <= dDateD.Date
                                            && dDateA.Date <= Convert.ToDateTime(c.dDdate.Value).Date
                                            && dc.GetFilterByNobr(c.sNobr.Trim(), sUserID, sComp, bAdmin).Value
                                            orderby c.dAdate.Date
                                            select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_BaseTtsDataTable dt = new dsBas.JB_HR_BaseTtsDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 員工卡號資料
        /// </summary>
        /// <param name="sNobr">工號(空白 = 全部員工)</param>
        /// <returns>JB_HR_CardAppDataTable</returns>
        public static dsBas.JB_HR_CardAppDataTable CardApp(string sNobr)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_CardApp> sql = from c in dc.JB_HR_CardApp select c;
            if (sNobr.Trim().Length > 0)
                sql = from c in dc.JB_HR_CardApp where c.sNobr == sNobr.Trim() orderby c.dDateB descending select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_CardAppDataTable dt = new dsBas.JB_HR_CardAppDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 資料群組
        /// </summary>
        /// <returns>JB_HR_DataGroupDataTable</returns>
        public static dsBas.JB_HR_DataGroupDataTable DataGroup()
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_DataGroup> sql = from c in dc.JB_HR_DataGroup select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_DataGroupDataTable dt = new dsBas.JB_HR_DataGroupDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 編制部門資料
        /// </summary>
        /// <param name="dDate">區間內日期,允許null,若要取得目前生效之部門,請帶入今天之日期</param>
        /// <returns>JB_HR_DeptDataTable</returns>
        public static dsBas.JB_HR_DeptDataTable Dept(DateTime? dDate)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_Dept> sql = from c in dc.JB_HR_Dept select c;
            if (dDate != null)
                sql = from c in dc.JB_HR_Dept where Convert.ToDateTime(c.dAdate).Date <= Convert.ToDateTime(dDate).Date && Convert.ToDateTime(dDate).Date <= Convert.ToDateTime(c.dDdate).Date select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_DeptDataTable dt = new dsBas.JB_HR_DeptDataTable();
            dt.FillData(dr);
            SetDeptPath(dt);

            return dt;
        }

        /// <summary>
        /// 編制部門資料
        /// </summary>
        /// <param name="sDeptCode">部門代碼</param>
        /// <returns>JB_HR_DeptDataTable</returns>
        public static dsBas.JB_HR_DeptDataTable Dept(string sDeptCode)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_Dept> sql = from c in dc.JB_HR_Dept
                                         where c.sDeptCode == sDeptCode
                                         select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_DeptDataTable dt = new dsBas.JB_HR_DeptDataTable();
            dt.FillData(dr);
            SetDeptPath(dt);

            return dt;
        }

        /// <summary>
        /// 成本部門資料
        /// </summary>
        /// <returns>JB_HR_DeptsDataTable</returns>
        public static dsBas.JB_HR_DeptsDataTable Depts()
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_Depts> sql = from c in dc.JB_HR_Depts
                                          select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_DeptsDataTable dt = new dsBas.JB_HR_DeptsDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 成本部門資料
        /// </summary>
        /// <param name="dDate">區間內日期,允許null,若要取得目前生效之部門,請帶入今天之日期</param>
        /// <returns>JB_HR_DeptsDataTable</returns>
        public static dsBas.JB_HR_DeptsDataTable Depts(DateTime? dDate)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_Depts> sql = from c in dc.JB_HR_Depts select c;
            if (dDate != null)
                sql = from c in dc.JB_HR_Depts
                      where Convert.ToDateTime(c.dAdate).Date <= Convert.ToDateTime(dDate).Date
                      && Convert.ToDateTime(dDate).Date <= Convert.ToDateTime(c.dDdate).Date
                      select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_DeptsDataTable dt = new dsBas.JB_HR_DeptsDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 成本部門資料
        /// </summary>
        /// <param name="sDeptCode">部門代碼</param>
        /// <returns>JB_HR_DeptsDataTable</returns>
        public static dsBas.JB_HR_DeptsDataTable Depts(string sDeptCode)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_Depts> sql = from c in dc.JB_HR_Depts
                                          where c.sDeptCode == sDeptCode
                                          select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_DeptsDataTable dt = new dsBas.JB_HR_DeptsDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 簽核部門資料
        /// </summary>
        /// <returns>JB_HR_DeptmDataTable</returns>
        public static dsBas.JB_HR_DeptmDataTable Deptm()
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_Deptm> sql = from c in dc.JB_HR_Deptm select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_DeptmDataTable dt = new dsBas.JB_HR_DeptmDataTable();
            dt.FillData(dr);
            SetDeptPath(dt);

            return dt;
        }

        /// <summary>
        /// 簽核部門資料
        /// </summary>
        /// <param name="sDeptCode">部門代碼</param>
        /// <returns>JB_HR_DeptmDataTable</returns>
        public static dsBas.JB_HR_DeptmDataTable Deptm(string sDeptCode)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_Deptm> sql = from c in dc.JB_HR_Deptm
                                          where c.sDeptCode == sDeptCode
                                          select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_DeptmDataTable dt = new dsBas.JB_HR_DeptmDataTable();
            dt.FillData(dr);
            SetDeptPath(dt);

            return dt;
        }

        /// <summary>
        /// 簽核部門資料
        /// </summary>
        /// <param name="dDate">日期</param>
        /// <returns>JB_HR_DeptmDataTable</returns>
        public static dsBas.JB_HR_DeptmDataTable Deptm(DateTime dDate)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_Deptm> sql = from c in dc.JB_HR_Deptm
                                          select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_DeptmDataTable dt = new dsBas.JB_HR_DeptmDataTable();
            dt.FillData(dr);
            SetDeptPath(dt);

            return dt;
        }

        /// <summary>
        /// 取得部門直屬主管(該部門沒有主管則會一直往上抓取)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="sDeptm">部門</param>
        /// <returns>string</returns>
        public static string GetDeptmManage(string sNobr, string sDeptm)
        {
            string[] arr = { "1", "4", "6" };

            if (sDeptm == string.Empty)
            {
                var rBase = EmpBase(sNobr).Where(p => arr.Contains(p.sTtsCode)).FirstOrDefault();
                if (rBase != null)
                    sDeptm = rBase.sDeptmCode;

                if (sDeptm == string.Empty)
                    return sNobr;

                //先抓部門裡設定的主管不是空白就直接使用
                var rDeptm = Deptm(sDeptm).FirstOrDefault();
                if (rDeptm != null && rDeptm.sNobr.Trim().Length > 0 && rDeptm.sNobr.Trim() != sNobr)
                    return rDeptm.sNobr.Trim();
            }

            bool bDo = true;

            do
            {
                var rsBases = EmpBaseByDeptm(sDeptm).Where(p => arr.Contains(p.sTtsCode) && p.bMang);
                if (rsBases.Count() == 0 || rsBases.First().sNobr == sNobr)
                {
                    var rDeptm = Deptm().Where(p => p.sDeptCode == sDeptm).FirstOrDefault();
                    if (rDeptm == null || rDeptm.sDeptParent.Trim() == string.Empty)
                        break;

                    //尋找簽核部門的主管
                    if (rDeptm != null && rDeptm.sNobr.Trim().Length > 0 && rDeptm.sNobr.Trim() != sNobr)
                    {
                        sNobr = rDeptm.sNobr.Trim();
                        break;
                    }

                    sDeptm = rDeptm.sDeptParent;
                }
                else
                {
                    sNobr = rsBases.First().sNobr.Trim();
                    break;
                }
            } while (bDo);

            return sNobr;
        }

        /// <summary>
        /// 設定部門組織(僅限Dept,Deptm使用)
        /// </summary>
        /// <param name="dt">部門資料表</param>
        private static void SetDeptPath(DataTable dt)
        {
            string sDept;
            DataRow[] rows;
            int i;
            foreach (DataRow r in dt.Rows)
            {
                i = 0;
                sDept = r["sDeptCode"].ToString();

                do
                {
                    rows = dt.Select("sDeptCode = '" + sDept + "'");
                    if (rows.Length > 0)
                    {
                        r["sDeptPathCode"] = "/" + rows[0]["sDeptCode"].ToString().Trim() + r["sDeptPathCode"].ToString();
                        r["sDeptPathName"] = "/" + rows[0]["sDeptName"].ToString().Trim() + r["sDeptPathName"].ToString();

                        if (sDept == rows[0]["sDeptParent"].ToString().Trim())
                            break;

                        sDept = rows[0]["sDeptParent"].ToString().Trim();
                    }

                    i++;
                } while (rows.Length > 0 && sDept.Trim().Length > 0 && i <= dt.Rows.Count);

                r["sDeptPathCode"] = r["sDeptPathCode"].ToString() + "/";
                r["sDeptPathName"] = r["sDeptPathName"].ToString() + "/";
            }
        }

        /// <summary>
        /// 部門階層
        /// </summary>
        /// <returns>JB_HR_DeptLevelDataTable</returns>
        public static dsBas.JB_HR_DeptLevelDataTable DeptLevel()
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_DeptLevel> sql = from c in dc.JB_HR_DeptLevel select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_DeptLevelDataTable dt = new dsBas.JB_HR_DeptLevelDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 職稱資料
        /// </summary>
        /// <returns>JB_HR_JobDataTable</returns>
        public static dsBas.JB_HR_JobDataTable Job()
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_Job> sql = from c in dc.JB_HR_Job select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_JobDataTable dt = new dsBas.JB_HR_JobDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 職等資料
        /// </summary>
        /// <returns>JB_HR_JoblDataTable</returns>
        public static dsBas.JB_HR_JoblDataTable Jobl()
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_Jobl> sql = from c in dc.JB_HR_Jobl select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_JoblDataTable dt = new dsBas.JB_HR_JoblDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 異動原因
        /// </summary>
        /// <returns>JB_HR_TtscdDataTable</returns>
        public static dsBas.JB_HR_TtscdDataTable Ttscd()
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_Ttscd> sql = from c in dc.JB_HR_Ttscd select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_TtscdDataTable dt = new dsBas.JB_HR_TtscdDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 是否計薪前鎖檔(True = 已鎖檔)
        /// </summary>
        /// <param name="dDate">觸發日期(通常為請假或加班之時間)</param>
        /// <param name="sSaladr">薪資群組</param>
        /// <returns>bool</returns>
        public static bool IsDataPassB(DateTime dDate, string sSaladr)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_DataPass> sql = from c in dc.JB_HR_DataPass
                                             where Convert.ToDateTime(c.dDate).Date == dDate.Date
                                             && c.sSaladr == sSaladr
                                             select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_DataPassDataTable dt = new dsBas.JB_HR_DataPassDataTable();
            dt.FillData(dr);

            return dt.Rows.Count > 0;
        }

        /// <summary>
        /// 是否計薪前鎖檔(True = 已鎖檔)
        /// </summary>
        /// <param name="dDate">觸發日期(通常為請假或加班之時間)</param>
        /// <param name="sSaladr">薪資群組</param>
        /// <returns>bool</returns>
        public static bool IsDataPaB(DateTime dDate, string sSaladr)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_DataPa> sql = from c in dc.JB_HR_DataPa
                                           where Convert.ToDateTime(c.dDate).Date == dDate.Date
                                           && c.sSaladr == sSaladr
                                           select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_DataPaDataTable dt = new dsBas.JB_HR_DataPaDataTable();
            dt.FillData(dr);

            return dt.Rows.Count > 0;
        }

        /// <summary>
        /// 是否計薪後鎖檔(True = 已鎖檔)
        /// </summary>
        /// <param name="dDate">觸發日期(通常為請假或加班之日期)</param>
        /// <param name="sSeq">計薪期別(預設為2)</param>
        /// <param name="sSaladr">薪資群組</param>
        /// <returns>bool</returns>
        public static bool IsDataPassE(DateTime dDate, string sSeq, string sSaladr)
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_LockWage> sql = from c in dc.JB_HR_LockWage 
                                             where c.sYYMM.Trim() == Tools.DateToYyMm(dDate)
                                             && Convert.ToString(c.sSeq).Trim() == sSeq
                                             && c.sSaladr == sSaladr
                                             select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_LockWageDataTable dt = new dsBas.JB_HR_LockWageDataTable();
            dt.FillData(dr);

            return dt.Rows.Count > 0;
        }

        /// <summary>
        /// 寫入U_TTS(Log)
        /// </summary>
        /// <param name="sProName">程式名稱</param>
        /// <param name="iOpCode">異動代碼(1 = 新增,2 = 修改,3 = 刪除)</param>
        /// <param name="sCont">內容</param>
        /// <param name="sKeyMan">登錄者</param>
        public static void InsertLog(string sProName, int iOpCode, string sCont, string sKeyMan)
        {
            dsBasTableAdapters.U_TTSTableAdapter ta = new JBHR.Dll.dsBasTableAdapters.U_TTSTableAdapter();
            dsBas.U_TTSDataTable dt = new dsBas.U_TTSDataTable();
            dsBas.U_TTSRow r = dt.NewU_TTSRow();
            r.PRG_NAME = sProName;
            r.OP_CODE = iOpCode;
            r.CONT = sCont;
            r.KEY_MAN = sKeyMan;
            r.KEY_DATE = DateTime.Now;
            r.KEY_TIME = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
            dt.AddU_TTSRow(r);
            ta.Update(r);

            //var r = new U_TTS
            //{
            //    PRG_NAME = sProName,
            //    OP_CODE = iOpCode,
            //    CONT = sCont,
            //    KEY_MAN = sKeyMan,
            //    KEY_DATE = DateTime.Now,
            //    KEY_TIME = DateTime.Now.ToString("HH:mm:ss")
            //};
            //dcBasDataContext dc = new dcBasDataContext();
            //dc.U_TTS.InsertOnSubmit(r);
            //dc.SubmitChanges();
        }

        /// <summary>
        /// DataRow的資料轉成String
        /// </summary>
        /// <param name="r">DataRow</param>
        /// <returns>string</returns>
        public static string SetRowValueToLog(DataRow r)
        {
            string s = "";

            if (r != null)
                foreach (DataColumn dc in r.Table.Columns)
                    s += "," + Convert.ToString(r[dc]);

            return s;
        }

        /// <summary>
        /// Object的資料轉成String
        /// </summary>
        /// <param name="r">Object</param>
        /// <returns>string</returns>
        public static string SetRowValueToLog(object r)
        {
            string s = "";

            // get the properties of the LINQ Object        
            PropertyInfo[] props = r.GetType().GetProperties();

            // iterate through each property of the class
            foreach (PropertyInfo prop in props)
                s += "," + Convert.ToString(prop.GetValue(r, null));

            return s;
        }
    }

    /// <summary>
    /// 相關出勤資料
    /// </summary>
    public static class Att
    {
        /// <summary>
        /// 個人出勤資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">出勤日期</param>
        /// <returns>JB_HR_AttendDataTable</returns>
        public static dsAtt.JB_HR_AttendDataTable Attend(string sNobr, DateTime dDate)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Attend> sql = from a in dc.JB_HR_Attend
                                           where a.sNobr.Trim() == sNobr.Trim() && a.dAdate.Date == dDate
                                           select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AttendDataTable dt = new dsAtt.JB_HR_AttendDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人出勤資料(日期區間)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="dDateE">區間結束日期</param>
        /// <returns>JB_HR_AttendDataTableb</returns>
        public static dsAtt.JB_HR_AttendDataTable Attend(string sNobr, DateTime dDateB, DateTime dDateE)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Attend> sql = from a in dc.JB_HR_Attend
                                           where a.sNobr.Trim() == sNobr.Trim()
                                           && a.dAdate.Date >= dDateB && a.dAdate.Date <= dDateE
                                           select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AttendDataTable dt = new dsAtt.JB_HR_AttendDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人出勤資料(工號、日期區間)
        /// </summary>
        /// <param name="sNobrB">開始工號</param>
        /// <param name="sNobrE">結束工號</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="dDateE">區間結束日期</param>
        /// <returns>JB_HR_AttendDataTableb</returns>
        public static dsAtt.JB_HR_AttendDataTable Attend(string sNobrB, string sNobrE, DateTime dDateB, DateTime dDateE)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Attend> sql = from a in dc.JB_HR_Attend
                                           where a.sNobr.Trim().CompareTo(sNobrB.Trim()) >= 0
                                           && a.sNobr.Trim().CompareTo(sNobrE.Trim()) <= 0
                                           && a.dAdate.Date >= dDateB && a.dAdate.Date <= dDateE
                                           select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AttendDataTable dt = new dsAtt.JB_HR_AttendDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人出勤資料(工號、日期區間)
        /// </summary>
        /// <param name="sNobrB">開始工號</param>
        /// <param name="sNobrE">結束工號</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="dDateE">區間結束日期</param>
        /// <param name="sUserID">登入者工號</param>
        /// <param name="sComp">公司別</param>
        /// <param name="bAdmin">是否管理權限</param>
        /// <returns>JB_HR_AttendDataTableb</returns>
        public static dsAtt.JB_HR_AttendDataTable Attend(string sNobrB, string sNobrE, DateTime dDateB, DateTime dDateE, string sUserID, string sComp, bool bAdmin)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Attend> sql = from a in dc.JB_HR_Attend
                                           where a.sNobr.Trim().CompareTo(sNobrB.Trim()) >= 0
                                           && a.sNobr.Trim().CompareTo(sNobrE.Trim()) <= 0
                                           && a.dAdate.Date >= dDateB && a.dAdate.Date <= dDateE
                                          && dc.GetFilterByNobr(a.sNobr, sUserID, sComp, bAdmin).Value
                                           select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AttendDataTable dt = new dsAtt.JB_HR_AttendDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 班別資料(加班單專用)
        /// </summary>
        /// <returns>JB_HR_RoteDataTable</returns>
        public static dsAtt.JB_HR_RoteDataTable RoteByDisplay()
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Rote> sql = from c in dc.JB_HR_Rote
                                         where c.iSort > 0
                                         orderby c.iSort
                                         select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_RoteDataTable dt = new dsAtt.JB_HR_RoteDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 班別資料(加班單專用 依公司顯示)
        /// </summary>
        /// <returns>JB_HR_RoteDataTable</returns>
        public static dsAtt.JB_HR_RoteDataTable RoteByDisplay(string sRote)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Rote> sql = from c in dc.JB_HR_Rote
                                         where c.iSort > 0
                                         && c.sRoteCode.IndexOf(sRote.Trim()) >= 0
                                         orderby c.iSort
                                         select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_RoteDataTable dt = new dsAtt.JB_HR_RoteDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 班別資料(顯示用)
        /// </summary>
        /// <returns>JB_HR_RoteDataTable</returns>
        public static dsAtt.JB_HR_RoteDataTable Rote()
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Rote> sql = from c in dc.JB_HR_Rote
                                         where c.iSort != 0
                                         orderby c.iSort
                                         select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_RoteDataTable dt = new dsAtt.JB_HR_RoteDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 班別資料
        /// </summary>
        /// <param name="sRoteCode">班別代碼(空字串等於取得所有資料)</param>
        /// <returns>JB_HR_RoteDataTable</returns>
        public static dsAtt.JB_HR_RoteDataTable Rote(string sRoteCode)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Rote> sql = from c in dc.JB_HR_Rote orderby c.iSort select c;
            if (sRoteCode.Trim().Length > 0)
                sql = from c in dc.JB_HR_Rote where c.sRoteCode.Trim() == sRoteCode.Trim() select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_RoteDataTable dt = new dsAtt.JB_HR_RoteDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 班別資料
        /// </summary>
        /// <param name="sRoteCode">班別代碼(空字串等於取得所有資料)</param>
        /// <param name="bWorkDay">工作班別 True = 是</param>
        /// <returns>JB_HR_RoteDataTable</returns>
        public static dsAtt.JB_HR_RoteDataTable Rote(string sRoteCode, bool bWorkDay)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Rote> sql = from c in dc.JB_HR_Rote where (bWorkDay ? c.iDkHrs > 0 && c.iWkHrs > 0 : c.iDkHrs == 0 && c.iWkHrs == 0) select c;
            if (sRoteCode.Trim().Length > 0)
                sql = from c in dc.JB_HR_Rote where c.sRoteCode.Trim() == sRoteCode.Trim() && (bWorkDay ? c.iDkHrs > 0 && c.iWkHrs > 0 : c.iDkHrs == 0 && c.iWkHrs == 0) select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_RoteDataTable dt = new dsAtt.JB_HR_RoteDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人出勤班別資料(某一日期)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">出勤日期</param>
        /// <returns>JB_HR_RoteDataTable</returns>
        public static dsAtt.JB_HR_RoteDataTable Rote(string sNobr, DateTime dDate)
        {
            dcAttDataContext dc = new dcAttDataContext();
            var sql = from a in dc.JB_HR_Attend
                      join r in dc.JB_HR_Rote on a.sRoteCode equals r.sRoteCode
                      where a.sNobr.Trim() == sNobr.Trim() && a.dAdate.Date == dDate
                      select new { a.dAdate, r };
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_RoteDataTable dt = new dsAtt.JB_HR_RoteDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人出勤班別資料(日期區間)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="dDateE">區間結束日期</param>
        /// <returns>JB_HR_RoteDataTable</returns>
        public static dsAtt.JB_HR_RoteDataTable Rote(string sNobr, DateTime dDateB, DateTime dDateE)
        {
            dcAttDataContext dc = new dcAttDataContext();
            var sql = from a in dc.JB_HR_Attend
                      join r in dc.JB_HR_Rote on a.sRoteCode equals r.sRoteCode
                      where a.sNobr.Trim() == sNobr.Trim()
                      && a.dAdate.Date >= dDateB && a.dAdate.Date <= dDateE
                      select new { a.dAdate, r };
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_RoteDataTable dt = new dsAtt.JB_HR_RoteDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人出勤刷卡資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <returns>JB_HR_AttCardDataTable</returns>
        public static dsAtt.JB_HR_AttCardDataTable AttCard(string sNobr)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_AttCard> sql = from a in dc.JB_HR_AttCard where a.sNobr.Trim() == sNobr.Trim() select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AttCardDataTable dt = new dsAtt.JB_HR_AttCardDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人出勤刷卡資料(某一天)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">日期</param>
        /// <returns>JB_HR_AttCardDataTable</returns>
        public static dsAtt.JB_HR_AttCardDataTable AttCard(string sNobr, DateTime dDate)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_AttCard> sql = from a in dc.JB_HR_AttCard where a.sNobr.Trim() == sNobr.Trim() && a.dAdate.Date == dDate.Date select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AttCardDataTable dt = new dsAtt.JB_HR_AttCardDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人出勤刷卡資料(日期區間)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="dDateE">區間結束日期</param>
        /// <returns>JB_HR_AttCardDataTable</returns>
        public static dsAtt.JB_HR_AttCardDataTable AttCard(string sNobr, DateTime dDateB, DateTime dDateE)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_AttCard> sql = from a in dc.JB_HR_AttCard where a.sNobr.Trim() == sNobr.Trim() && dDateB.Date <= a.dAdate.Date && a.dAdate.Date <= dDateE.Date select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AttCardDataTable dt = new dsAtt.JB_HR_AttCardDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人出勤刷卡資料(工號區間+日期區間)
        /// </summary>
        /// <param name="sNobrB">區間開始工號</param>
        /// <param name="sNobrE">區間結束工號</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="dDateE">區間結束日期</param>
        /// <returns>JB_HR_AttCardDataTable</returns>
        public static dsAtt.JB_HR_AttCardDataTable AttCard(string sNobrB, string sNobrE, DateTime dDateB, DateTime dDateE)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_AttCard> sql = from a in dc.JB_HR_AttCard
                                            where a.sNobr.Trim().CompareTo(sNobrB.Trim()) >= 0
                                            && a.sNobr.Trim().CompareTo(sNobrE.Trim()) <= 0
                                            && dDateB.Date <= a.dAdate.Date
                                            && a.dAdate.Date <= dDateE.Date
                                            select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AttCardDataTable dt = new dsAtt.JB_HR_AttCardDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人出勤刷卡資料(工號區間+日期區間)
        /// </summary>
        /// <param name="sNobrB">區間開始工號</param>
        /// <param name="sNobrE">區間結束工號</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="dDateE">區間結束日期</param>
        /// <param name="sUserID">登入者工號</param>
        /// <param name="sComp">公司別</param>
        /// <param name="bAdmin">是否管理權限</param>
        /// <returns>JB_HR_AttCardDataTable</returns>
        public static dsAtt.JB_HR_AttCardDataTable AttCard(string sNobrB, string sNobrE, DateTime dDateB, DateTime dDateE, string sUserID, string sComp, bool bAdmin)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_AttCard> sql = from a in dc.JB_HR_AttCard
                                            where a.sNobr.Trim().CompareTo(sNobrB.Trim()) >= 0
                                            && a.sNobr.Trim().CompareTo(sNobrE.Trim()) <= 0
                                            && dDateB.Date <= a.dAdate.Date
                                            && a.dAdate.Date <= dDateE.Date
                                            && dc.GetFilterByNobr(a.sNobr, sUserID, sComp, bAdmin).Value
                                            select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AttCardDataTable dt = new dsAtt.JB_HR_AttCardDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人請假資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <returns>JB_HR_AbsUnionDataTable</returns>
        public static dsAtt.JB_HR_AbsUnionDataTable Abs(string sNobr)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_AbsUnion> sql = from a in dc.JB_HR_AbsUnion where a.sNobr.Trim() == sNobr.Trim() select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AbsUnionDataTable dt = new dsAtt.JB_HR_AbsUnionDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人請假資料(某日期以後)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <returns>JB_HR_AbsUnionDataTable</returns>
        public static dsAtt.JB_HR_AbsUnionDataTable Abs(string sNobr, DateTime dDateB)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_AbsUnion> sql = from a in dc.JB_HR_AbsUnion
                                             where a.sNobr.Trim() == sNobr.Trim()
                                                 && dDateB.Date <= Convert.ToDateTime(a.dDateB).Date
                                             select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AbsUnionDataTable dt = new dsAtt.JB_HR_AbsUnionDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人請假資料(某計薪年月(YYMM)之後的加項或減項)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="sYYMM">計薪年月(5碼年月,如09809,預設可帶空白會帶「今天」)</param>
        /// <param name="bCatAdd">加項或減項 True = 加項</param>
        /// <returns>JB_HR_AbsUnionDataTable</returns>
        public static dsAtt.JB_HR_AbsUnionDataTable Abs(string sNobr, string sYYMM, bool bCatAdd)
        {
            int iSalaryDay = 0;
            var rEmpBase = JBHR.Dll.Bas.EmpBase(sNobr).FirstOrDefault();
            if (rEmpBase != null)
            {
                var rDataGroup = JBHR.Dll.Bas.DataGroup().Where(p => p.sDataGroup == rEmpBase.sSaladr).FirstOrDefault();
                if (rDataGroup != null)
                {
                    iSalaryDay = SalaryDay(rDataGroup.sComp);
                }
            }

            sYYMM = sYYMM.Trim().Length > 0 ? sYYMM : SetYYMM(DateTime.Now.Date, "2", iSalaryDay, rEmpBase.sSaladr);
            string[] sCat = bCatAdd ? new string[] { "0", "1", "3", "5" } : new string[] { "0", "2", "4", "6" };
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_AbsUnion> sql = from a in dc.JB_HR_AbsUnion
                                             where a.sNobr.Trim() == sNobr.Trim()
                                                 && Convert.ToInt32(sYYMM) <= Convert.ToInt32(a.sYYMM)
                                                 && sCat.Contains(Convert.ToString(a.sYearRest).Trim())
                                             select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AbsUnionDataTable dt = new dsAtt.JB_HR_AbsUnionDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人請假資料(日期區間的加項或減項)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="dDateE">區間結束日期</param>
        /// <param name="bCatAdd">加項或減項 True = 加項</param>
        /// <returns>JB_HR_AbsUnionDataTable</returns>
        public static dsAtt.JB_HR_AbsUnionDataTable Abs(string sNobr, DateTime dDateB, DateTime dDateE, bool bCatAdd)
        {
            string[] sCat = bCatAdd ? new string[] { "0", "1", "3", "5" } : new string[] { "0", "2", "4", "6" };
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_AbsUnion> sql = from a in dc.JB_HR_AbsUnion
                                             where a.sNobr.Trim() == sNobr.Trim()
                                             && dDateB.Date <= Convert.ToDateTime(a.dDateB).Date
                                             && Convert.ToDateTime(a.dDateB).Date <= dDateE.Date
                                             && sCat.Contains(Convert.ToString(a.sYearRest).Trim())
                                             select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AbsUnionDataTable dt = new dsAtt.JB_HR_AbsUnionDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人請假資料(日期區間的加項或減項代碼)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="sCat">加項或減項代碼</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="dDateE">區間結束日期</param>
        /// <returns>JB_HR_AbsUnionDataTable</returns>
        public static dsAtt.JB_HR_AbsUnionDataTable Abs(string sNobr, string sCat, DateTime dDateB, DateTime dDateE)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_AbsUnion> sql = from a in dc.JB_HR_AbsUnion
                                             where a.sNobr.Trim() == sNobr.Trim()
                                             && dDateB.Date <= Convert.ToDateTime(a.dDateB).Date
                                             && Convert.ToDateTime(a.dDateB).Date <= dDateE.Date
                                             && a.sYearRest.Trim() == sCat
                                             select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AbsUnionDataTable dt = new dsAtt.JB_HR_AbsUnionDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人請假資料(某日期以後,且單一假別代碼)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="sHcode">假別代碼</param>
        /// <returns>JB_HR_AbsUnionDataTable</returns>
        public static dsAtt.JB_HR_AbsUnionDataTable Abs(string sNobr, DateTime dDateB, string sHcode)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_AbsUnion> sql = from a in dc.JB_HR_AbsUnion
                                             where a.sNobr.Trim() == sNobr.Trim()
                                                 && dDateB.Date <= Convert.ToDateTime(a.dDateB).Date
                                                 && a.sHoliCode == sHcode
                                             select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AbsUnionDataTable dt = new dsAtt.JB_HR_AbsUnionDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人請假資料(日期區間)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="dDateE">區間結束日期</param>
        /// <returns>JB_HR_AbsUnionDataTable</returns>
        public static dsAtt.JB_HR_AbsUnionDataTable Abs(string sNobr, DateTime dDateB, DateTime dDateE)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_AbsUnion> sql = from a in dc.JB_HR_AbsUnion where a.sNobr.Trim() == sNobr.Trim() && dDateB.Date <= Convert.ToDateTime(a.dDateB).Date && Convert.ToDateTime(a.dDateB).Date <= dDateE.Date select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AbsUnionDataTable dt = new dsAtt.JB_HR_AbsUnionDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人請假資料(日期區間,且單一假別代碼)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="dDateE">區間結束日期</param>
        /// <param name="sHcode">假別代碼</param>
        /// <returns>JB_HR_AbsUnionDataTable</returns>
        public static dsAtt.JB_HR_AbsUnionDataTable Abs(string sNobr, DateTime dDateB, DateTime dDateE, string sHcode)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_AbsUnion> sql = from a in dc.JB_HR_AbsUnion
                                             where a.sNobr.Trim() == sNobr.Trim()
                                                 && dDateB.Date <= Convert.ToDateTime(a.dDateB).Date && Convert.ToDateTime(a.dDateB).Date <= dDateE.Date
                                                 && a.sHoliCode == sHcode
                                             select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AbsUnionDataTable dt = new dsAtt.JB_HR_AbsUnionDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人請假資料(某日期以後)
        /// </summary>
        /// <param name="sNobrB">區間開始工號</param>
        /// <param name="sNobrE">區間結束工號</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="dDateE">區間結束日期</param>
        /// <param name="sTemp">無義</param>
        /// <returns>JB_HR_AbsUnionDataTable</returns>
        public static dsAtt.JB_HR_AbsUnionDataTable Abs(string sNobrB, string sNobrE, DateTime dDateB, DateTime dDateE, string sTemp)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_AbsUnion> sql = from a in dc.JB_HR_AbsUnion
                                             where a.sNobr.Trim().CompareTo(sNobrB.Trim()) >= 0
                                             && a.sNobr.Trim().CompareTo(sNobrE.Trim()) <= 0
                                             && dDateB.Date <= a.dDateB.Date
                                             && a.dDateB.Date <= dDateE.Date
                                             select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AbsUnionDataTable dt = new dsAtt.JB_HR_AbsUnionDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人請假資料(某日期以後)
        /// </summary>
        /// <param name="sNobrB">區間開始工號</param>
        /// <param name="sNobrE">區間結束工號</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="dDateE">區間結束日期</param>
        /// <param name="sTemp">無義</param>
        /// <param name="sUserID">登入者工號</param>
        /// <param name="sComp">公司別</param>
        /// <param name="bAdmin">是否管理權限</param>
        /// <returns>JB_HR_AbsUnionDataTable</returns>
        public static dsAtt.JB_HR_AbsUnionDataTable Abs(string sNobrB, string sNobrE, DateTime dDateB, DateTime dDateE, string sTemp, string sUserID, string sComp, bool bAdmin)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_AbsUnion> sql = from a in dc.JB_HR_AbsUnion
                                             where a.sNobr.Trim().CompareTo(sNobrB.Trim()) >= 0
                                             && a.sNobr.Trim().CompareTo(sNobrE.Trim()) <= 0
                                             && dDateB.Date <= a.dDateB.Date
                                             && a.dDateB.Date <= dDateE.Date
                                             && dc.GetFilterByNobr(a.sNobr, sUserID, sComp, bAdmin).Value
                                             select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AbsUnionDataTable dt = new dsAtt.JB_HR_AbsUnionDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人得假資料
        /// </summary>
        /// <param name="sNobr">區間開始工號</param>
        /// <param name="sHcode">假別代碼</param>
        /// <param name="dDate">區間開始日期</param>
        /// <returns>JB_HR_AbsUnionDataTable</returns>
        public static dsAtt.JB_HR_AbstDataTable Abst(string sNobr, string sHcode, DateTime dDate)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Abst> sql = from a in dc.JB_HR_Abst
                                         where a.sNobr.Trim() == sNobr.Trim()
                                         && a.sHoliCode == sHcode
                                         && dDate.Date >= a.dDateB.Date
                                         && a.dDateE.Date >= dDate.Date
                                         select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AbstDataTable dt = new dsAtt.JB_HR_AbstDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人得假資料
        /// </summary>
        /// <param name="sNobr">區間開始工號</param>
        /// <param name="sHcode">假別代碼</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="dDateE">區間結束日期</param>
        /// <returns>JB_HR_AbsUnionDataTable</returns>
        public static dsAtt.JB_HR_AbstDataTable Abst(string sNobr, string sHcode, DateTime dDateB, DateTime dDateE)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Abst> sql = from a in dc.JB_HR_Abst
                                         where a.sNobr.Trim() == sNobr.Trim()
                                         && a.sHoliCode == sHcode
                                         && dDateB.Date <= a.dDateB.Date
                                         && a.dDateB.Date <= dDateE.Date
                                         select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_AbstDataTable dt = new dsAtt.JB_HR_AbstDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人加班資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <returns>JB_HR_OtDataTable</returns>
        public static dsAtt.JB_HR_OtDataTable Ot(string sNobr)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Ot> sql = from a in dc.JB_HR_Ot where a.sNobr.Trim() == sNobr.Trim() select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_OtDataTable dt = new dsAtt.JB_HR_OtDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人加班資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="sYYMM">計薪年月</param>
        /// <param name="sCat">類別</param>
        /// <returns>JB_HR_OtDataTable</returns>
        public static dsAtt.JB_HR_OtDataTable Ot(string sNobr, string sYYMM, string sCat)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Ot> sql = from a in dc.JB_HR_Ot 
                                       where a.sNobr.Trim() == sNobr.Trim()
                                       && a.sYYMM == sYYMM
                                       select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_OtDataTable dt = new dsAtt.JB_HR_OtDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 計算加班時數(日期區間)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="sCat">計算類別0=假日,1=平日,2=不分</param>
        /// <returns>decimal</returns>
        public static decimal OtHoursSum(string sNobr, DateTime dDateB, DateTime dDateE, string sCat)
        {
            decimal Hours = 0;
            dcAttDataContext dc = new dcAttDataContext();
            var sql = from a in dc.JB_HR_Ot
                      join b in dc.JB_HR_Attend
                      on new { a.sNobr, a.dDateB.Date } equals new { b.sNobr, b.dAdate.Date }
                      where a.sNobr.Trim() == sNobr.Trim() && dDateB.Date <= Convert.ToDateTime(a.dDateB).Date
                      && Convert.ToDateTime(a.dDateB).Date <= dDateE.Date
                      select new { a, b };

            var s1 = sql.Where(p => p.b.sRoteCode == "00");
            var s2 = sql.Where(p => p.b.sRoteCode != "00");

            Hours += (sCat == "0" || sCat == "2") && s1.Any() ? s1.Sum(p => p.a.iOtHrs) : 0;
            Hours += (sCat == "1" || sCat == "2") && s2.Any() ? s2.Sum(p => p.a.iOtHrs) : 0;

            //select a.iOtHrs;
            //Hours = Convert.ToDecimal(sql.Sum());

            return Hours;
        }

        /// <summary>
        /// 計算加班時數(計薪年月)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="sYYMM">計薪年月</param>
        /// <returns>decimal</returns>
        public static decimal OtHoursSum(string sNobr, string sYYMM)
        {
            decimal Hours = 0;
            dcAttDataContext dc = new dcAttDataContext();
            var sql = (from a in dc.JB_HR_Ot
                       join b in dc.JB_HR_Attend
                       on new { a.sNobr, a.dDateB.Date } equals new { b.sNobr, b.dAdate.Date }
                       where a.sYYMM == sYYMM
                       && a.sNobr == sNobr
                       select new
                       {
                           RoteCode = b.sRoteCode,
                           OtHrs = a.iOtHrs,
                           RestHrs = a.iRestHrs,
                       }).ToList();

            var Rote00 = sql.Where(p => p.RoteCode == "00" && (p.OtHrs + p.RestHrs) > 8).Sum(p => p.OtHrs + p.RestHrs - 8);
            var Rote = sql.Where(p => p.RoteCode != "00").Sum(p => p.OtHrs + p.RestHrs);
            Hours = Rote00 + Rote;

            return Hours;
        }

        /// <summary>
        /// 個人加班資料(日期區間)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="dDateE">區間結束日期</param>
        /// <returns>JB_HR_OtDataTable</returns>
        public static dsAtt.JB_HR_OtDataTable Ot(string sNobr, DateTime dDateB, DateTime dDateE)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Ot> sql = from a in dc.JB_HR_Ot where a.sNobr.Trim() == sNobr.Trim() && dDateB.Date <= Convert.ToDateTime(a.dDateB).Date && Convert.ToDateTime(a.dDateB).Date <= dDateE.Date select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_OtDataTable dt = new dsAtt.JB_HR_OtDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人加班資料(日期區間)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="dDateE">區間結束日期</param>
        /// <returns>JB_HR_OtDataTable</returns>
        public static dsAtt.JB_HR_Ot1DataTable Ot1(string sNobr, DateTime dDateB, DateTime dDateE)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Ot1> sql = from a in dc.JB_HR_Ot1 where a.sNobr.Trim() == sNobr.Trim() && dDateB.Date <= Convert.ToDateTime(a.dDateB).Date && Convert.ToDateTime(a.dDateB).Date <= dDateE.Date select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_Ot1DataTable dt = new dsAtt.JB_HR_Ot1DataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人加班資料(工號、日期區間)
        /// </summary>
        /// <param name="sNobrB">工號開始</param>
        /// <param name="sNobrE">工號結束</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="dDateE">區間結束日期</param>
        /// <returns>JB_HR_OtDataTable</returns>
        public static dsAtt.JB_HR_OtDataTable Ot(string sNobrB, string sNobrE, DateTime dDateB, DateTime dDateE)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Ot> sql = from a in dc.JB_HR_Ot
                                       where a.sNobr.Trim().CompareTo(sNobrB.Trim()) >= 0
                                       && a.sNobr.Trim().CompareTo(sNobrE.Trim()) <= 0
                                       && dDateB.Date <= Convert.ToDateTime(a.dDateB).Date
                                       && Convert.ToDateTime(a.dDateB).Date <= dDateE.Date
                                       select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_OtDataTable dt = new dsAtt.JB_HR_OtDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 個人加班資料(工號、日期區間)
        /// </summary>
        /// <param name="sNobrB">工號開始</param>
        /// <param name="sNobrE">工號結束</param>
        /// <param name="dDateB">區間開始日期</param>
        /// <param name="dDateE">區間結束日期</param>
        /// <param name="sUserID">登入者工號</param>
        /// <param name="sComp">公司別</param>
        /// <param name="bAdmin">是否管理權限</param>
        /// <returns>JB_HR_OtDataTable</returns>
        public static dsAtt.JB_HR_OtDataTable Ot(string sNobrB, string sNobrE, DateTime dDateB, DateTime dDateE, string sUserID, string sComp, bool bAdmin)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Ot> sql = from a in dc.JB_HR_Ot
                                       where a.sNobr.Trim().CompareTo(sNobrB.Trim()) >= 0
                                       && a.sNobr.Trim().CompareTo(sNobrE.Trim()) <= 0
                                       && dDateB.Date <= Convert.ToDateTime(a.dDateB).Date
                                       && Convert.ToDateTime(a.dDateB).Date <= dDateE.Date
                                       && dc.GetFilterByNobr(a.sNobr, sUserID, sComp, bAdmin).Value
                                       select a;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_OtDataTable dt = new dsAtt.JB_HR_OtDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 假別資料(顯示用)
        /// </summary>
        /// <returns>JB_HR_HcodeDataTable</returns>
        public static dsAtt.JB_HR_HcodeDataTable Hcode()
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Hcode> sql = from c in dc.JB_HR_Hcode
                                          where c.iSort != 0
                                          orderby c.iSort
                                          select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_HcodeDataTable dt = new dsAtt.JB_HR_HcodeDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 假別資料
        /// </summary>
        /// <param name="sHcode">假別代碼(空字串等於取得所有資料)</param>
        /// <returns>JB_HR_HcodeDataTable</returns>
        public static dsAtt.JB_HR_HcodeDataTable Hcode(string sHcode)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Hcode> sql = from c in dc.JB_HR_Hcode select c;
            if (sHcode.Trim().Length > 0)
                sql = from c in dc.JB_HR_Hcode where c.sHcode.Trim() == sHcode.Trim() orderby c.iSort select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_HcodeDataTable dt = new dsAtt.JB_HR_HcodeDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 假別資料(顯示可請的假別)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">現在日期</param>
        /// <returns>JB_HR_HcodeDataTable</returns>
        public static dsAtt.JB_HR_HcodeDataTable HcodeByDisplay(string sNobr, DateTime? dDate)
        {
            dDate = dDate != null ? dDate : DateTime.Now.Date;
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Hcode> sql = from c in dc.JB_HR_Hcode
                                          where c.iSort > 0
                                          && dc.GetCodeFilterByNobr("HCODE", c.sHcode, sNobr, dDate).Value
                                          orderby c.iSort
                                          select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_HcodeDataTable dt = new dsAtt.JB_HR_HcodeDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 假別資料-延伸
        /// </summary>
        /// <returns>JB_HR_ExtTableDataTable</returns>
        public static dsBas.JB_HR_ExtTableDataTable HcodeExt()
        {
            dcBasDataContext dc = new dcBasDataContext();
            IQueryable<JB_HR_ExtTable> sql = from c in dc.JB_HR_ExtTable
                                             where c.sTableName == "HCODE"
                                             select c;
            DbCommand dr = dc.GetCommand(sql);
            dsBas.JB_HR_ExtTableDataTable dt = new dsBas.JB_HR_ExtTableDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 加班班別資料
        /// </summary>
        /// <param name="sCode">加班班別代碼(空字串等於取得所有資料)</param>
        /// <returns>JB_HR_OtRateDataTable</returns>
        public static dsAtt.JB_HR_OtRateDataTable OtRate(string sCode)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_OtRate> sql = from c in dc.JB_HR_OtRate select c;
            if (sCode.Trim().Length > 0)
                sql = from c in dc.JB_HR_OtRate
                      where Convert.ToString(c.sOtRateCode).Trim() == sCode.Trim() || sCode.Trim() == "0"
                      select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_OtRateDataTable dt = new dsAtt.JB_HR_OtRateDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 加班原因資料(顯示用)
        /// </summary>
        /// <returns>JB_HR_OtrcdDataTable</returns>
        public static dsAtt.JB_HR_OtrcdDataTable Otrcd()
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Otrcd> sql = from c in dc.JB_HR_Otrcd
                                          where c.iSort > 0
                                          orderby c.iSort
                                          select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_OtrcdDataTable dt = new dsAtt.JB_HR_OtrcdDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 加班原因資料
        /// </summary>
        /// <param name="sCode">加班原因代碼(空字串等於取得所有資料)</param>
        /// <returns>JB_HR_OtrcdDataTable</returns>
        public static dsAtt.JB_HR_OtrcdDataTable Otrcd(string sCode)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Otrcd> sql = from c in dc.JB_HR_Otrcd select c;
            if (sCode.Trim().Length > 0)
                sql = from c in dc.JB_HR_Otrcd
                      where c.sOtrCode.Trim() == sCode.Trim() || sCode == "0"
                      select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_OtrcdDataTable dt = new dsAtt.JB_HR_OtrcdDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 加班原因資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">現在日期</param>
        /// <returns>JB_HR_OtrcdDataTable</returns>
        public static dsAtt.JB_HR_OtrcdDataTable OtrcdDisplay(string sNobr, DateTime? dDate)
        {
            dDate = dDate != null ? dDate : DateTime.Now.Date;
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Otrcd> sql = from c in dc.JB_HR_Otrcd
                                          where c.iSort > 0
                                          && dc.GetCodeFilterByNobr("OTRCD", c.sOtrCode, sNobr, dDate).Value
                                          orderby c.iSort
                                          select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_OtrcdDataTable dt = new dsAtt.JB_HR_OtrcdDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 刷卡資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <returns>JB_HR_CardDataTable</returns>
        public static dsAtt.JB_HR_CardDataTable Card(string sNobr)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Card> sql = from c in dc.JB_HR_Card where c.sNobr == sNobr select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_CardDataTable dt = new dsAtt.JB_HR_CardDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 刷卡資料(某一天日期)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">刷卡日期</param>
        /// <returns>JB_HR_CardDataTable</returns>
        public static dsAtt.JB_HR_CardDataTable Card(string sNobr, DateTime dDate)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Card> sql = from c in dc.JB_HR_Card where c.sNobr == sNobr && c.dAdate.Date == dDate.Date select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_CardDataTable dt = new dsAtt.JB_HR_CardDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 刷卡資料(某一日期區間)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">刷卡開始日期</param>
        /// <param name="dDateE">刷卡結束日期</param>
        /// <returns>JB_HR_CardDataTable</returns>
        public static dsAtt.JB_HR_CardDataTable Card(string sNobr, DateTime dDateB, DateTime dDateE)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Card> sql = from c in dc.JB_HR_Card
                                         where c.sNobr == sNobr
                                         && dDateB.Date <= c.dAdate.Date && c.dAdate.Date <= dDateE.Date
                                         select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_CardDataTable dt = new dsAtt.JB_HR_CardDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 刷卡資料(工號、日期區間)
        /// </summary>
        /// <param name="sNobrB">區間開始工號</param>
        /// <param name="sNobrE">區間結束工號</param>
        /// <param name="dDateB">刷卡開始日期</param>
        /// <param name="dDateE">刷卡結束日期</param>
        /// <returns>JB_HR_CardDataTable</returns>
        public static dsAtt.JB_HR_CardDataTable Card(string sNobrB, string sNobrE, DateTime dDateB, DateTime dDateE)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Card> sql = from c in dc.JB_HR_Card
                                         where c.sNobr.Trim().CompareTo(sNobrB.Trim()) >= 0
                                         && c.sNobr.Trim().CompareTo(sNobrE.Trim()) <= 0
                                         && dDateB.Date <= c.dAdate.Date
                                         && c.dAdate.Date <= dDateE.Date
                                         select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_CardDataTable dt = new dsAtt.JB_HR_CardDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 刷卡資料(工號、日期區間)
        /// </summary>
        /// <param name="sNobrB">區間開始工號</param>
        /// <param name="sNobrE">區間結束工號</param>
        /// <param name="dDateB">刷卡開始日期</param>
        /// <param name="dDateE">刷卡結束日期</param>
        /// <param name="sUserID">登入者工號</param>
        /// <param name="sComp">公司別</param>
        /// <param name="bAdmin">是否管理權限</param>
        /// <returns>JB_HR_CardDataTable</returns>
        public static dsAtt.JB_HR_CardDataTable Card(string sNobrB, string sNobrE, DateTime dDateB, DateTime dDateE, string sUserID, string sComp, bool bAdmin)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Card> sql = from c in dc.JB_HR_Card
                                         where c.sNobr.Trim().CompareTo(sNobrB.Trim()) >= 0
                                         && c.sNobr.Trim().CompareTo(sNobrE.Trim()) <= 0
                                         && dDateB.Date <= c.dAdate.Date
                                         && c.dAdate.Date <= dDateE.Date
                                         && dc.GetFilterByNobr(c.sNobr.Trim(), sUserID, sComp, bAdmin).Value
                                         select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_CardDataTable dt = new dsAtt.JB_HR_CardDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 忘刷原因資料
        /// </summary>
        /// <returns>JB_HR_ReasonDataTable</returns>
        public static dsAtt.JB_HR_ReasonDataTable Reason()
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Reason> sql = from c in dc.JB_HR_Reason
                                           where c.iSort > 0
                                           orderby c.iSort
                                           select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_ReasonDataTable dt = new dsAtt.JB_HR_ReasonDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 忘刷原因資料
        /// </summary>
        /// <param name="sCode">忘刷原因代碼(空字串等於取得所有資料)</param>
        /// <returns>JB_HR_ReasonDataTable</returns>
        public static dsAtt.JB_HR_ReasonDataTable Reason(string sCode)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Reason> sql = from c in dc.JB_HR_Reason
                                           orderby c.iSort
                                           select c;
            if (Convert.ToString(sCode).Trim().Length > 0)
                sql = from c in dc.JB_HR_Reason
                      where Convert.ToString(c.sReasonCode).Trim() == sCode.Trim()
                      || sCode == "0"
                      orderby c.iSort
                      select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_ReasonDataTable dt = new dsAtt.JB_HR_ReasonDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 換班資料(帶「0」或空字串為全部資料)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <returns>JB_HR_RotechgDataTable</returns>
        public static dsAtt.JB_HR_RotechgDataTable Rotechg(string sNobr)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Rotechg> sql = from c in dc.JB_HR_Rotechg select c;
            if (Convert.ToString(sNobr).Trim().Length > 0)
                sql = from c in dc.JB_HR_Rotechg
                      where c.sNobr.Trim() == Convert.ToString(sNobr)
                      || sNobr == "0"
                      select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_RotechgDataTable dt = new dsAtt.JB_HR_RotechgDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 換班資料(單一日期)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">日期</param>
        /// <returns>JB_HR_RotechgDataTable</returns>
        public static dsAtt.JB_HR_RotechgDataTable Rotechg(string sNobr, DateTime dDate)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Rotechg> sql = from c in dc.JB_HR_Rotechg
                                            where c.sNobr == Convert.ToString(sNobr)
                                            && c.dAdate.Date == dDate.Date
                                            select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_RotechgDataTable dt = new dsAtt.JB_HR_RotechgDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 換班資料(單一工號的日期區間)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <returns>JB_HR_RotechgDataTable</returns>
        public static dsAtt.JB_HR_RotechgDataTable Rotechg(string sNobr, DateTime dDateB, DateTime dDateE)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Rotechg> sql = from c in dc.JB_HR_Rotechg
                                            where c.sNobr == Convert.ToString(sNobr)
                                            && c.dAdate.Date >= dDateB.Date
                                            && c.dAdate.Date <= dDateE.Date
                                            select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_RotechgDataTable dt = new dsAtt.JB_HR_RotechgDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 換班資料(多個工號的日期區間)
        /// </summary>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <returns>JB_HR_RotechgDataTable</returns>
        public static dsAtt.JB_HR_RotechgDataTable Rotechg(DateTime dDateB, DateTime dDateE)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Rotechg> sql = from c in dc.JB_HR_Rotechg
                                            where c.dAdate.Date >= dDateB.Date
                                            && c.dAdate.Date <= dDateE.Date
                                            select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_RotechgDataTable dt = new dsAtt.JB_HR_RotechgDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 行事曆代碼資料(帶「0」或空字串為全部資料)
        /// </summary>
        /// <param name="sCode">代碼(帶「0」或空字串為全部資料)</param>
        /// <returns>JB_HR_HolicdDataTable</returns>
        public static dsAtt.JB_HR_HolicdDataTable Holicd(string sCode)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Holicd> sql = from c in dc.JB_HR_Holicd select c;
            if (sCode.Trim().Length > 0)
                sql = from c in dc.JB_HR_Holicd
                      where c.sHoliCode.ToString() == sCode.Trim()
                      || sCode.Trim() == "0"
                      select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_HolicdDataTable dt = new dsAtt.JB_HR_HolicdDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 輪班序代碼資料(帶「0」或空字串為全部資料)
        /// </summary>
        /// <param name="sCode">代碼(帶「0」或空字串為全部資料)</param>
        /// <returns>JB_HR_RotetDataTable</returns>
        public static dsAtt.JB_HR_RotetDataTable Rotet(string sCode)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Rotet> sql = from c in dc.JB_HR_Rotet select c;
            if (sCode.Trim().Length > 0)
                sql = from c in dc.JB_HR_Rotet
                      where c.sRotet.ToString() == sCode.Trim()
                       || sCode.Trim() == "0"
                      select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_RotetDataTable dt = new dsAtt.JB_HR_RotetDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 員工班表(每人一個月一筆資料)
        /// </summary>
        /// <returns>JB_HR_TmTableDataTable</returns>
        public static dsAtt.JB_HR_TmTableDataTable TmTable()
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_TmTable> sql = from c in dc.JB_HR_TmTable select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_TmTableDataTable dt = new dsAtt.JB_HR_TmTableDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 員工班表(每人一個月一筆資料)
        /// </summary>
        /// <param name="sYYMM">年年年月月</param>
        /// <param name="sNobr">工號</param>
        /// <returns>JB_HR_TmTableDataTable</returns>
        public static dsAtt.JB_HR_TmTableDataTable TmTable(string sYYMM, string sNobr)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_TmTable> sql = from c in dc.JB_HR_TmTable
                                            where c.sYYMM.Trim() == sYYMM
                                            && c.sNobr.Trim() == sNobr
                                            select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_TmTableDataTable dt = new dsAtt.JB_HR_TmTableDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 休假行事曆(帶「0」或空字串為全部資料)
        /// </summary>
        /// <param name="sHoliCode">行事曆代碼(帶「0」或空字串為全部資料)</param>
        /// <returns>JB_HR_HoliDataTable</returns>
        public static dsAtt.JB_HR_HoliDataTable Holi(string sHoliCode)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Holi> sql = from c in dc.JB_HR_Holi select c;
            if (sHoliCode.Trim().Length > 0)
                sql = from c in dc.JB_HR_Holi
                      where Convert.ToString(c.sHoliCode).Trim() == sHoliCode
                      || sHoliCode.Trim() == "0"
                      select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_HoliDataTable dt = new dsAtt.JB_HR_HoliDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 休假行事曆
        /// </summary>
        /// <param name="sHoliCode">行事曆代碼</param>
        /// <param name="dDate">日期</param>
        /// <returns>JB_HR_HoliDataTable</returns>
        public static dsAtt.JB_HR_HoliDataTable Holi(string sHoliCode, DateTime dDate)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Holi> sql = from c in dc.JB_HR_Holi
                                         where Convert.ToString(c.sHoliCode).Trim() == sHoliCode.Trim()
                                         && c.dDate.Date == dDate.Date
                                         select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_HoliDataTable dt = new dsAtt.JB_HR_HoliDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 休假行事曆(日期區間)
        /// </summary>
        /// <param name="sHoliCode">行事曆代碼</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <returns>JB_HR_HoliDataTable</returns>
        public static dsAtt.JB_HR_HoliDataTable Holi(string sHoliCode, DateTime dDateB, DateTime dDateE)
        {
            dcAttDataContext dc = new dcAttDataContext();
            IQueryable<JB_HR_Holi> sql = from c in dc.JB_HR_Holi
                                         where Convert.ToString(c.sHoliCode).Trim() == sHoliCode.Trim()
                                         && c.dDate.Date >= dDateB.Date
                                         && c.dDate.Date <= dDateE.Date
                                         select c;
            DbCommand dr = dc.GetCommand(sql);
            dsAtt.JB_HR_HoliDataTable dt = new dsAtt.JB_HR_HoliDataTable();
            dt.FillData(dr);

            return dt;
        }

        /// <summary>
        /// 計薪年月(5碼年月,如09809)
        /// </summary>
        /// <param name="dDate">觸發日期(通常為請假或加班之日期)</param>
        /// <param name="sSeq">計薪期別(預設為2)</param>
        /// <param name="iSalaryDay">開始計薪日(預設為0)</param>
        /// <param name="sSaladr">薪資群組</param>
        /// <returns>string</returns>
        public static string SetYYMM(DateTime dDate, string sSeq, int iSalaryDay, string sSaladr)
        {
            while (Bas.IsDataPassB(dDate, sSaladr))
                dDate = dDate.AddDays(1);

            while (Bas.IsDataPaB(dDate, sSaladr))
                dDate = dDate.AddDays(1);

            sSeq = sSeq.Trim().Length > 0 ? sSeq : "2";

            dDate = dDate.Day > iSalaryDay ? dDate.AddMonths(1) : dDate;
            while (Bas.IsDataPassE(dDate, sSeq , sSaladr))
                dDate = dDate.AddMonths(1);

            string yymm = Tools.DateToYyMm(dDate);
            //string yymm = Convert.ToString(dDate.Year - 1911) + dDate.Month.ToString().PadLeft(2, char.Parse("0"));
            //yymm = yymm.PadLeft(5, char.Parse("0"));
            return yymm;
        }

        /// <summary>
        /// 計薪日期
        /// </summary>
        //public static int SalaryDay
        //{
        //    get
        //    {
        //        dcBasDataContext dc = new dcBasDataContext();
        //        var sql = (from c in dc.U_SYS2 select c).FirstOrDefault();
        //        return (sql != null) ? Convert.ToInt32(sql.ATTMONTH) : Convert.ToInt32(ConfigurationSettings.AppSettings["iSalaryDay"]);
        //    }
        //}

        /// <summary>
        /// 計薪日期
        /// </summary>
        /// <param name="sComp">公司別</param>
        /// <returns>int</returns>
        public static int SalaryDay(string sComp)
        {
            int i = 0;

            dcBasDataContext dc = new dcBasDataContext();
            var sql = (from c in dc.U_SYS2
                       where c.Comp.Trim() == sComp
                       select c).FirstOrDefault();

            if (sql != null && sql.ATTMONTH != null)
                i = sql.ATTMONTH.Value;

            return i;
        }

        /// <summary>
        /// 轉換時段為HHMM的格式
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">日期</param>
        /// <param name="bDateStr">是否為申請開始日期 True = 是</param>
        /// <param name="bTimeStr">是否為上午時段 True = 是</param>
        /// <returns>string</returns>
        public static string ConvertTime(string sNobr, DateTime dDate, bool bDateStr, bool bTimeStr)
        {
            string sTime = "";
            dsAtt.JB_HR_RoteDataTable dtRote = Rote(sNobr, dDate.Date);
            if (dtRote.Rows.Count > 0)
            {
                dsAtt.JB_HR_RoteRow r = dtRote.Rows[0] as dsAtt.JB_HR_RoteRow;
                if (bDateStr)
                    sTime = bTimeStr ? r.sOnTime.Trim() : r.sResE1Time.Trim();
                else
                    sTime = bTimeStr ? r.sResB1Time.Trim() : r.sOffTime.Trim();
            }

            return sTime;
        }

        /// <summary>
        /// 請假檢查
        /// </summary>
        public static class AbsCheck
        {
            /// <summary>
            /// 是否為上班日 True = 要計算(包含假別是否要包含假日)
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDate">日期</param>
            /// <param name="sHcode">假別</param>
            /// <returns>bool</returns>
            public static bool IsWorkDay(string sNobr, DateTime dDate, string sHcode)
            {
                bool bWorkDay = false;  //預設不用上班
                dsAtt.JB_HR_HcodeDataTable dtHcode = Hcode(sHcode);
                dsAtt.JB_HR_AttendDataTable dtAttend = Attend(sNobr, dDate);

                //如果該假別包含假日計算,則不用考慮是否為假日班
                if (dtAttend.Rows.Count > 0)
                {
                    dsAtt.JB_HR_AttendRow r = dtAttend.Rows[0] as dsAtt.JB_HR_AttendRow;
                    bWorkDay = r.sRoteCode.Trim() != "00"; //不是假日都是要上班日

                    //不用上班日再進來判斷是否要含假日
                    if (dtHcode.Rows.Count > 0 && !bWorkDay)
                    {
                        dsAtt.JB_HR_HcodeRow r1 = dtHcode.Rows[0] as dsAtt.JB_HR_HcodeRow;
                        bWorkDay = r1.bInHoli;  //bInHoli = False = 不用計算 = 不用上班
                    }
                }

                return bWorkDay;
            }

            /// <summary>
            /// 是否為工作時間 True = 開始「和」結束時間是工作時間
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDateB">開始日期(非經過加總後的日期)</param>
            /// <param name="dDateE">結束日期(非經過加總後的日期)</param>
            /// <param name="sTimeB">開始時間(4位數)</param>
            /// <param name="sTimeE">結束時間(4位數)</param>
            /// <param name="sRoteCode">加班班別,強制指定加班的班別,為預設班別時,以日期的班別為主,班別為假日班時,再取得預設班別(預設班別設0)</param>
            /// <param name="bInHoli">包含假日班一樣要判斷是否為工作時間 True = 要判斷</param>
            /// <returns>bool</returns>
            public static bool IsWorkTime(string sNobr, DateTime dDateB, DateTime dDateE, string sTimeB, string sTimeE, string sRoteCode, bool bInHoli)
            {
                bool bWorkTime = false;
                DateTime dDateTimeB, dDateTimeE, dDateTimeB1, dDateTimeE1;
                dDateTimeB = dDateB.Date.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeB));    //加班開始日期時間
                dDateTimeE = dDateE.Date.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeE));    //加班結束日期時間
                dsAtt.JB_HR_RoteDataTable dtRoteB = (sRoteCode == "0" || sRoteCode.Trim().Length == 0) ? Rote(sNobr, dDateB) : Rote(sRoteCode);   //一定要依據日期來取得班別資料
                dsAtt.JB_HR_RoteDataTable dtRoteE = (sRoteCode == "0" || sRoteCode.Trim().Length == 0) ? Rote(sNobr, dDateE) : Rote(sRoteCode);   //一定要依據日期來取得班別資料

                if (dtRoteB.Rows.Count > 0 && dtRoteE.Rows.Count > 0)
                {
                    dsAtt.JB_HR_RoteRow rB = dtRoteB.Rows[0] as dsAtt.JB_HR_RoteRow;
                    dsAtt.JB_HR_RoteRow rE = dtRoteE.Rows[0] as dsAtt.JB_HR_RoteRow;

                    //如果是假日班需要尋找預設班別來取代原本的班別資料(某些公司需要)
                    if ((rB.sRoteCode == "00" || rE.sRoteCode == "00") && bInHoli)
                    {
                        //從員工基本資料取得預設班別代碼
                        dsBas.JB_HR_BaseDataTable dtBase = Bas.EmpBase(sNobr);
                        if (dtBase.Rows.Count > 0)
                        {
                            dsBas.JB_HR_BaseRow r1 = dtBase.Rows[0] as dsBas.JB_HR_BaseRow;
                            dtRoteB = Rote(r1.sRotet);   //輪班序暫代班別代碼
                            if (dtRoteB.Rows.Count > 0)
                            {
                                rB = rB.sRoteCode == "00" ? dtRoteB.Rows[0] as dsAtt.JB_HR_RoteRow : rB;
                                rE = rE.sRoteCode == "00" ? dtRoteB.Rows[0] as dsAtt.JB_HR_RoteRow : rE;
                            }
                        }
                    }
                    else if (rB.sRoteCode == "00" || rE.sRoteCode == "00")
                        return bWorkTime;   //其中有一個是假日班,就直接出去！

                    //先判斷請假開始日期時間
                    dDateTimeB1 = dDateB.Date.AddMinutes(Tools.ConvertHhMmToMinutes(rB.sOnTime)); //上班時間
                    dDateTimeE1 = dDateB.Date.AddMinutes(Tools.ConvertHhMmToMinutes(rB.sOffTime));    //下班時間
                    bWorkTime = dDateTimeB1 <= dDateTimeB && dDateTimeB <= dDateTimeE1;

                    //再判斷請假結束日期時間
                    dDateTimeB1 = dDateE.Date.AddMinutes(Tools.ConvertHhMmToMinutes(rE.sOnTime)); //上班時間
                    dDateTimeE1 = dDateE.Date.AddMinutes(Tools.ConvertHhMmToMinutes(rE.sOffTime));    //下班時間
                    bWorkTime = bWorkTime && (dDateTimeB1 <= dDateTimeE && dDateTimeE <= dDateTimeE1);
                }

                return bWorkTime;
            }

            /// <summary>
            /// 是否為工作時間 True = 是工作時間(簡易型判斷,可知道某一日期時間是否是工作時間)
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDateTime">日期時間(欲判斷之參數,且要完整的日期及時間)</param>
            /// <param name="dDate">日期(取得班別上下班時間之依據)</param>
            /// <returns>bool</returns>
            public static bool IsWorkTime(string sNobr, DateTime dDateTime, DateTime dDate)
            {
                bool bWorkTime = false;
                DateTime dDateTimeB, dDateTimeE;
                dsAtt.JB_HR_RoteDataTable dtRote = Rote(sNobr, dDate.Date);  //一定要依據請假的日期來取得班別資料
                if (dtRote.Rows.Count > 0)
                {
                    dsAtt.JB_HR_RoteRow r = dtRote.Rows[0] as dsAtt.JB_HR_RoteRow;
                    if (r.sRoteCode.Trim() == "00") return false;

                    dDateTimeB = dDate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(r.sOnTime)); //上班時間
                    dDateTimeE = dDate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(r.sAttEnd));    //請假下班時間

                    bWorkTime = dDateTimeB <= dDateTime && dDateTime <= dDateTimeE;
                }

                return bWorkTime;
            }

            /// <summary>
            /// 檢查請假資料是否重複 True = 重複
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDateTimeB">開始日期時間</param>
            /// <param name="dDateTimeE">結束日期時間</param>
            /// <param name="bCatAdd">加減項 True = 加項</param>
            /// <returns>bool</returns>
            public static bool IsRepeatData(string sNobr, DateTime dDateTimeB, DateTime dDateTimeE, bool bCatAdd)
            {
                bool bIsRepeatData = false;
                DateTime dDateB = dDateTimeB.Date.AddDays(-1);  //取得前一日開始的資料(為防止48小時的資料沒取得)

                string[] sCat = bCatAdd ? new string[] { "0", "1", "3", "5" } : new string[] { "0", "2", "4", "6" };
                dsAtt.JB_HR_AbsUnionDataTable dtAbs = Abs(sNobr, dDateB.Date, dDateTimeE.Date);
                var dtAbsWhere = dtAbs.Where(p => sCat.Contains(p.sYearRest)
                    && p.dDateB.Date.AddMinutes(Tools.ConvertHhMmToMinutes(p.sTimeB)) < dDateTimeE
                    && p.dDateE.Date.AddMinutes(Tools.ConvertHhMmToMinutes(p.sTimeE)) > dDateTimeB
                    && p.sTimeB.Trim().Length > 0 && p.sTimeE.Trim().Length > 0);

                if (bCatAdd)
                    dtAbsWhere = dtAbs.Where(p => sCat.Contains(p.sYearRest)
                    && p.dDateB.Date.AddMinutes(Tools.ConvertHhMmToMinutes(p.sTimeB)) == dDateTimeB);

                bIsRepeatData = dtAbsWhere.Count() > 0;
                return bIsRepeatData;
            }
        }

        /// <summary>
        /// 加班檢查
        /// </summary>
        public static class OtCheck
        {
            /// <summary>
            /// 是否為工作時間 True = 開始「或」結束時間是工作時間
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDate">日期(非經過加總後的日期)</param>
            /// <param name="sTimeB">開始時間(4位數)</param>
            /// <param name="sTimeE">結束時間(4位數)</param>
            /// <param name="sRoteCode">加班班別,強制指定加班的班別,為預設班別時,以日期的班別為主,班別為假日班時,再取得預設班別(預設班別設0)</param>
            /// <param name="bInHoli">包含假日班一樣要判斷是否為工作時間 True = 要判斷</param>
            /// <returns>bool</returns>
            public static bool IsWorkTime(string sNobr, DateTime dDate, string sTimeB, string sTimeE, string sRoteCode, bool bInHoli)
            {
                bool bWorkTime = false;
                DateTime dDateTimeB, dDateTimeE, dDateTimeB1, dDateTimeE1;
                dDateTimeB = dDate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeB));    //加班開始日期時間
                dDateTimeE = dDate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeE));    //加班結束日期時間
                dsAtt.JB_HR_RoteDataTable dtRote = (sRoteCode == "0" || sRoteCode.Trim().Length == 0) ? Rote(sNobr, dDate) : Rote(sRoteCode);   //一定要依據日期來取得班別資料

                if (dtRote.Rows.Count > 0)
                {
                    dsAtt.JB_HR_RoteRow r = dtRote.Rows[0] as dsAtt.JB_HR_RoteRow;

                    //如果是假日班需要尋找預設班別來取代原本的班別資料(某些公司需要)
                    if (r.sRoteCode == "00" && bInHoli)
                    {
                        //從員工基本資料取得預設班別代碼
                        dsBas.JB_HR_BaseDataTable dtBase = Bas.EmpBase(sNobr);
                        if (dtBase.Rows.Count > 0)
                        {
                            dsBas.JB_HR_BaseRow r1 = dtBase.Rows[0] as dsBas.JB_HR_BaseRow;
                            dtRote = Rote(r1.sRotet);   //輪班序暫代班別代碼
                            if (dtRote.Rows.Count > 0)
                                r = dtRote.Rows[0] as dsAtt.JB_HR_RoteRow;
                        }
                    }

                    dDateTimeB1 = dDate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(r.sOnTime)); //上班時間
                    dDateTimeE1 = dDate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(r.sOffTime));    //下班時間

                    bWorkTime = dDateTimeB1 < dDateTimeB && dDateTimeB < dDateTimeE1; //判斷開始時間為考量上班前可能先加班   
                    bWorkTime = bWorkTime || (dDateTimeB1 < dDateTimeE && dDateTimeE < dDateTimeE1);
                    bWorkTime = dDateTimeB == dDateTimeB1 && dDateTimeE == dDateTimeE1;
                }

                return bWorkTime;
            }

            /// <summary>
            /// 是否為工作時間 True = 是工作時間(簡易型判斷,可知道某一日期時間是否是工作時間)
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDateTime">日期時間(欲判斷之參數,且要完整的日期及時間)</param>
            /// <param name="dDate">日期(取得班別上下班時間之依據)</param>
            /// <returns>bool</returns>
            public static bool IsWorkTime(string sNobr, DateTime dDateTime, DateTime dDate)
            {
                bool bWorkTime = false;
                DateTime dDateTimeB, dDateTimeE;
                dsAtt.JB_HR_RoteDataTable dtRote = Rote(sNobr, dDate.Date);  //一定要依據日期來取得班別資料
                if (dtRote.Rows.Count > 0)
                {
                    dsAtt.JB_HR_RoteRow r = dtRote.Rows[0] as dsAtt.JB_HR_RoteRow;
                    if (r.sRoteCode.Trim() == "00") return false;

                    dDateTimeB = dDate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(r.sOnTime)); //上班時間
                    dDateTimeE = dDate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(r.sOffTime));    //下班時間

                    bWorkTime = dDateTimeB < dDateTime && dDateTime < dDateTimeE;
                }

                return bWorkTime;
            }

            /// <summary>
            /// 是否為刷卡時間 True = 是刷卡時間
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDate">日期</param>
            /// <param name="sTimeB">開始時間</param>
            /// <param name="sTimeE">結束時間</param>
            /// <returns>bool</returns>
            public static bool IsCardTime(string sNobr, DateTime dDate, string sTimeB, string sTimeE)
            {
                bool bCardTime = false;
                DateTime dDateTimeB, dDateTimeE, dDateTimeB1, dDateTimeE1;
                dDateTimeB = dDate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeB));    //加班開始日期時間
                dDateTimeE = dDate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeE));    //加班結束日期時間
                dsAtt.JB_HR_AttCardDataTable dtAttCard = AttCard(sNobr, dDate.Date);

                if (dtAttCard.Rows.Count > 0)
                {
                    dsAtt.JB_HR_AttCardRow r = dtAttCard.Rows[0] as dsAtt.JB_HR_AttCardRow;
                    dDateTimeB1 = dDate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(r.sT1)); //刷卡開時時間
                    dDateTimeE1 = dDate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(r.sT2));    //刷卡結束時間

                    bCardTime = dDateTimeB1 <= dDateTimeB && dDateTimeB <= dDateTimeE1;
                    bCardTime = bCardTime && (dDateTimeB1 <= dDateTimeE && dDateTimeE <= dDateTimeE1);
                }

                return bCardTime;
            }

            /// <summary>
            /// 檢查加班資料是否重複 True = 重複
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDateTimeB">開始日期時間</param>
            /// <param name="dDateTimeE">結束日期時間</param>
            /// <returns>bool</returns>
            public static bool IsRepeatData(string sNobr, DateTime dDateTimeB, DateTime dDateTimeE)
            {
                bool bIsRepeatData = false;
                DateTime dDateB = dDateTimeB.Date.AddDays(-1);  //取得前一日開始的資料(為防止48小時的資料沒取得)

                dsAtt.JB_HR_OtDataTable dtOt = Ot(sNobr, dDateB, dDateTimeE);
                var dtOtWhere = dtOt.Where(p => p.dDateB.Date.AddMinutes(Tools.ConvertHhMmToMinutes(p.sTimeB)) < dDateTimeE
                    && p.dDateB.Date.AddMinutes(Tools.ConvertHhMmToMinutes(p.sTimeE)) > dDateTimeB);

                bIsRepeatData = dtOtWhere.Count() > 0;
                return bIsRepeatData;
            }

            /// <summary>
            /// 檢查加班資料是否重複 True = 重複
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDateTimeB">開始日期時間</param>
            /// <param name="dDateTimeE">結束日期時間</param>
            /// <returns>bool</returns>
            public static bool IsRepeatData1(string sNobr, DateTime dDateTimeB, DateTime dDateTimeE)
            {
                bool bIsRepeatData = false;
                DateTime dDateB = dDateTimeB.Date.AddDays(-1);  //取得前一日開始的資料(為防止48小時的資料沒取得)

                dsAtt.JB_HR_Ot1DataTable dtOt = Ot1(sNobr, dDateB, dDateTimeE);
                var dtOtWhere = dtOt.Where(p => p.dDateB.Date.AddMinutes(Tools.ConvertHhMmToMinutes(p.sTimeB)) < dDateTimeE
                    && p.dDateB.Date.AddMinutes(Tools.ConvertHhMmToMinutes(p.sTimeE)) > dDateTimeB);

                bIsRepeatData = dtOtWhere.Count() > 0;
                return bIsRepeatData;
            }
        }

        /// <summary>
        /// 刷卡檢查
        /// </summary>
        public static class CardCheck
        {
            /// <summary>
            /// 檢查刷卡時間是否重複 True = 重複
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDate">刷卡日期</param>
            /// <param name="sTime">刷卡時間</param>
            /// <returns>bool</returns>
            public static bool IsRepeatTime(string sNobr, DateTime dDate, string sTime)
            {
                bool bIsRepeatTime = false;
                dsAtt.JB_HR_CardDataTable dtCard = Card(sNobr, dDate.Date);
                var dtCardWhere = dtCard.Where(p => p.sOnTime.Trim() == sTime);

                bIsRepeatTime = dtCardWhere.Count() > 0;
                return bIsRepeatTime;
            }
        }

        /// <summary>
        /// 請假相關計算
        /// </summary>
        public static class AbsCal
        {
            /// <summary>
            /// 請假詳細結構資料
            /// </summary>
            public class AbsDetail
            {
                public decimal iDay;    //天數
                public decimal iHour;   //時數
                public decimal iRealHour;   //未進位實際時數
                public decimal iMin; //分鐘數
                public decimal iTotalDay;   //總天數
                public decimal iTotalHour;  //總時數
                public decimal iTotalMin;    //總分鐘數
                public decimal iWorkHour;    //計算原本應上班工時(總)
                public decimal iWorkHourAvg; //計算原本應上班工時(平)
                public decimal iWorkHourMin;   //最小請假時數
                public decimal iHcodeMin;    //請假代碼的最小時數
                public decimal iAbsUint;    //請假最小間距
                public decimal iHcodeMinMax;    //多天請假最少請多少
                public string sHcodeUnit;   //請假代碼的最小時數單位
                public bool bAllDay;    //判斷是否請全天 True = 每一天都是全天
                public bool bHcodeMin;  //是否符合最小請假時數 True = 符合
                public bool bSex; //是否符合請假性別 True = 符合
                public bool bAbsUint;    //是否符合最小隔格 True = 符合
                public bool bInHoliday; //假日是否要計算 True = 要
                public bool bBalance;   //剩餘時數是否足夠 True = 足夠
                public DayDate[] dDayDate; //每一天的日期

                /// <summary>
                /// 建構子
                /// </summary>
                public AbsDetail()
                {
                    iDay = 0;
                    iHour = 0;
                    iMin = 0;
                    iRealHour = 0;
                    iTotalDay = 0;
                    iTotalHour = 0;
                    iTotalMin = 0;
                    iWorkHour = 0;
                    iWorkHourAvg = 0;
                    iWorkHourMin = 0;
                    iHcodeMin = 0;
                    iAbsUint = 0;
                    iHcodeMinMax = 0;
                    sHcodeUnit = "小時";
                    bAllDay = true;
                    bHcodeMin = true;
                    bSex = false;
                    bAbsUint = true;
                    bInHoliday = false;
                    bBalance = false;
                }

                /// <summary>
                /// 每一天的日期
                /// </summary>
                public class DayDate
                {
                    public string sRote;    //每一天的班別
                    public string sRoteOld; //原本的班別(給假日班使用)
                    public DateTime dDateA; //系統每一天的開始日期
                    public DateTime dDateD;  //系統每一天的結束日期
                    public string sTimeA;   //系統每天開始時間
                    public string sTimeD;   //系統每天結束時間
                    public DateTime dDatetimeA; //系統每天的開始日期時間
                    public DateTime dDatetimeD; //系統每天的結束日期時間
                    public DateTime dDateB; //每一天的開始日期
                    public DateTime dDateE;  //每一天的結束日期
                    public string sTimeB;   //每天開始時間
                    public string sTimeE;   //每天結束時間
                    public DateTime dDatetimeB; //每天的開始日期時間
                    public DateTime dDatetimeE; //每天的結束日期時間
                    public decimal iWkHrs;  //每天的工作時數
                    public decimal iDkHrs; //每天的投入工時
                    public decimal iDay; //每一天的請假天數
                    public decimal iHour;    //每一天的時數
                    public decimal iMin;    //每一天的分鐘數
                    public decimal iOldHour; //原本的每一天的時數
                    public decimal iOldMin;  //原本的每一天的分鐘數
                    public decimal iOt;  //每天非法加班時數
                    public decimal iWk; //工作時數
                    public decimal iDk; //投入時數
                    public string sTime;    //真正的下班時間
                    public DateTime dDatetime;  //實際下班日期時間
                    public bool bDate;  //判斷是否為下午
                    public bool bAllDay;    //判斷是否請全天
                    public bool bOt;    //判斷是否為未休假時數 請未休假加班時數
                    public string sResB; //中間開始
                    public string sResE; //中間結束
                    public DayRes[] dDayRes;    //每一天的休息時間

                    /// <summary>
                    /// 建構子
                    /// </summary>
                    public DayDate()
                    {
                        sRote = "00";
                        sRoteOld = "00";
                        dDateA = DateTime.Now;
                        dDateD = DateTime.Now;
                        sTimeA = "0000";
                        sTimeD = "0000";
                        dDatetimeA = DateTime.Now;
                        dDatetimeD = DateTime.Now;
                        dDateB = DateTime.Now;
                        dDateE = DateTime.Now;
                        sTimeB = "0000";
                        sTimeE = "0000";
                        dDatetimeB = DateTime.Now;
                        dDatetimeE = DateTime.Now;
                        iWkHrs = 0;
                        iDkHrs = 0;
                        iDay = 0;
                        iHour = 0;
                        iMin = 0;
                        iOldHour = 0;
                        iOldMin = 0;
                        iOt = 0;
                        iWk = 0;
                        iDk = 0;
                        sTime = "0000";
                        dDatetime = DateTime.Now;
                        bDate = false;
                        bAllDay = false;
                        bOt = false;
                        sResB = "0000";
                        sResE = "0000";
                    }

                    /// <summary>
                    /// 每一天的休息時間
                    /// </summary>
                    public class DayRes
                    {
                        public DateTime dDatetimeA; //開始休息日期
                        public DateTime dDatetimeD;  //結束休息日期
                        public decimal iHours;   //休息總時數
                        public decimal iMinute; //休息總分鐘數

                        /// <summary>
                        /// 建構子
                        /// </summary>
                        public DayRes()
                        {
                            dDatetimeA = DateTime.Now.Date;
                            dDatetimeD = DateTime.Now.Date;
                            iHours = 0;
                            iMinute = 0;
                        }
                    }
                }
            }

            /// <summary>
            /// 設定休息時間
            /// </summary>
            /// <param name="dDate">日期</param>
            /// <param name="sTimeB">開始時間</param>
            /// <param name="sTimeE">結束時間</param>
            /// <returns>AbsDetail.DayDate.DayRes</returns>
            private static AbsDetail.DayDate.DayRes SetDayRes(DateTime dDate, string sTimeB, string sTimeE)
            {
                sTimeB.Trim();
                sTimeE.Trim();

                AbsDetail.DayDate.DayRes oDayRes = new AbsDetail.DayDate.DayRes();

                if ((sTimeB.Length > 0) && (sTimeE.Length > 0))
                {
                    oDayRes.dDatetimeA = dDate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeB));
                    oDayRes.dDatetimeD = dDate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeE));
                    TimeSpan ts = oDayRes.dDatetimeD - oDayRes.dDatetimeA;
                    oDayRes.iHours = Convert.ToDecimal(ts.TotalHours);
                    oDayRes.iMinute = Convert.ToDecimal(ts.TotalMinutes);
                }

                return oDayRes;
            }

            /// <summary>
            /// 請假計算(以隔間單位來計算)
            /// </summary>
            /// <param name="iHcodeUnit">最小單位</param>
            /// <param name="iAbsUnit">間隔單位</param>
            /// <param name="iAbsHour">請假時數或天數</param>
            /// <returns>decimal</returns>
            private static decimal CalAbsUint(decimal iHcodeUnit, decimal iAbsUnit, decimal iAbsHour)
            {
                decimal i = iHcodeUnit;
                //間隔單位一定要大於零而且請假時間也要大於零
                while ((iAbsUnit > 0) && (iAbsHour > 0) && (i < iAbsHour))
                    i += iAbsUnit;

                return i;
            }

            /// <summary>
            /// 請假間隔判斷
            /// </summary>
            /// <param name="iAbsUint">間隔單位</param>
            /// <param name="iAbsHour">請假時數或天數</param>
            /// <returns>bool</returns>
            private static bool IsAbsUint(decimal iAbsUint, decimal iAbsHour)
            {
                //間隔單位一定要大於零而且請假時間也要大於零
                while ((iAbsUint > 0) && (iAbsHour > 0) && (iAbsHour >= iAbsUint))
                    iAbsHour -= iAbsUint;

                return (iAbsHour == 0) || (iAbsUint == 0);
            }

            /// <summary>
            /// 請假計算核心(24小時)
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="sHcode">假別代碼</param>
            /// <param name="dDateB">開始日期</param>
            /// <param name="dDateE">結束日期</param>
            /// <param name="sTimeB">開始時間</param>
            /// <param name="sTimeE">結束時間</param>
            /// <param name="sName">對沖對象(通常婚假、喪假、產假可用)</param>
            /// <returns>AbsDetail</returns>
            public static AbsDetail AbsCalculationBy24(string sNobr, string sHcode, DateTime dDateB, DateTime dDateE, string sTimeB, string sTimeE, string sName)
            {
                sTimeB = sTimeB.PadLeft(4, char.Parse("0"));
                sTimeE = sTimeE.PadLeft(4, char.Parse("0"));

                dsAtt.JB_HR_RoteDataTable dtRote;
                dsAtt.JB_HR_RoteRow rRote;
                int mm;

                //如果結束日期是假日班的話，就往後推一天
                mm = 0;
                do
                {
                    dtRote = Att.Rote(sNobr, dDateB.Date.AddDays(mm));
                    rRote = dtRote.FirstOrDefault();
                    if (rRote == null)
                        break;

                    mm++;
                } while (rRote.sRoteCode == "00");

                if (rRote != null)
                {
                    int b, e, i;
                    int.TryParse(rRote.sOnTime, out b);
                    int.TryParse(rRote.sOffTime, out e);
                    int.TryParse(sTimeB, out i);

                    //若是不在此天的上下班時間裡
                    if (b > i || i > e)
                    {
                        //日期減一天，時間加24小時
                        dDateB = dDateB.AddDays(-1).Date;
                        sTimeB = Convert.ToString(i + 2400).PadLeft(4, char.Parse("0"));
                    }
                }

                //如果結束日期是假日班的話，就往前推一天
                mm = 0;
                do
                {
                    dtRote = Att.Rote(sNobr, dDateE.Date.AddDays(mm));
                    rRote = dtRote.FirstOrDefault();
                    if (rRote == null)
                        break;

                    mm--;
                } while (rRote.sRoteCode == "00");

                if (rRote != null)
                {
                    int b, e, i;
                    int.TryParse(rRote.sOnTime, out b);
                    int.TryParse(rRote.sOffTime, out e);
                    int.TryParse(sTimeE, out i);

                    //若是不在此天的上下班時間裡
                    if (b > i || i > e)
                    {
                        //日期減一天，時間加24小時
                        dDateE = dDateE.AddDays(-1).Date;
                        sTimeE = Convert.ToString(i + 2400).PadLeft(4, char.Parse("0"));
                    }
                }

                AbsDetail oAbsDetail = AbsCalculation(sNobr, sHcode, dDateB, dDateE, sTimeB, sTimeE, sName);
                return oAbsDetail;
            }

            /// <summary>
            /// 請假計算核心
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="sHcode">假別代碼</param>
            /// <param name="dDateB">開始日期</param>
            /// <param name="dDateE">結束日期</param>
            /// <param name="sTimeB">開始時間</param>
            /// <param name="sTimeE">結束時間</param>
            /// <param name="sName">對沖對象(通常婚假、喪假、產假可用)</param>
            /// <returns>AbsDetail</returns>
            public static AbsDetail AbsCalculation(string sNobr, string sHcode, DateTime dDateB, DateTime dDateE, string sTimeB, string sTimeE, string sName)
            {
                return AbsCalculation(sNobr, sHcode, dDateB, dDateE, sTimeB, sTimeE, sName, 0);
            }

            /// <summary>
            /// 請假計算核心
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="sHcode">假別代碼</param>
            /// <param name="dDateB">開始日期</param>
            /// <param name="dDateE">結束日期</param>
            /// <param name="sTimeB">開始時間</param>
            /// <param name="sTimeE">結束時間</param>
            /// <param name="sName">對沖對象(通常婚假、喪假、產假可用)</param>
            /// <param name="iProceedingHour">進行中時數</param>
            /// <returns>AbsDetail</returns>
            public static AbsDetail AbsCalculation(string sNobr, string sHcode, DateTime dDateB, DateTime dDateE, string sTimeB, string sTimeE, string sName, decimal iProceedingHour)
            {
                sTimeB = sTimeB.PadLeft(4, char.Parse("0"));
                sTimeE = sTimeE.PadLeft(4, char.Parse("0"));

                DateTime dDateTimeB, dDateTimeE;
                dDateTimeB = dDateB.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeB));
                dDateTimeE = dDateE.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeE));

                AbsDetail oAbsDetail = new AbsDetail();

                //取得個人相關資料
                dsBas.JB_HR_BaseDataTable dtBase = Bas.EmpBase(sNobr);
                if (dtBase.Rows.Count == 0) return null;
                dsBas.JB_HR_BaseRow rBase = dtBase.Rows[0] as dsBas.JB_HR_BaseRow;

                //取得假別相關資料
                dsAtt.JB_HR_HcodeDataTable dtHcode = Hcode(sHcode);
                if (dtHcode.Rows.Count == 0) return null;
                dsAtt.JB_HR_HcodeRow rHcode = dtHcode.Rows[0] as dsAtt.JB_HR_HcodeRow;
                oAbsDetail.iHcodeMin = Convert.ToDecimal(rHcode.iMin);
                oAbsDetail.sHcodeUnit = rHcode.sUnit;
                oAbsDetail.iAbsUint = rHcode.iAbsUint;
                oAbsDetail.bInHoliday = rHcode.bInHoli;
                oAbsDetail.bSex = rHcode.sSex.Trim().Length == 0 || rHcode.sSex == rBase.sSex;

                //延伸假別資料
                var rHcodeExt = Att.HcodeExt().Where(p => p.sKeyColumnName == "H_CODE" && p.sKeyColumnValue == sHcode && p.sColumnName == "MINMAX").FirstOrDefault();
                oAbsDetail.iHcodeMinMax = rHcodeExt != null ? Convert.ToDecimal(rHcodeExt.sColumnValue) : oAbsDetail.iHcodeMin;

                TimeSpan ts;
                ts = dDateTimeE.Date - dDateB.Date; //最大的日期(經過分鐘數相加)減掉最小的日期
                oAbsDetail.dDayDate = new AbsCal.AbsDetail.DayDate[ts.Days + 1];  //取得最大天數所以用計算後的結束時間來減沒計算的開始時間
                //設定每天請假的上下班時間及休息時間
                dsAtt.JB_HR_RoteDataTable dtRote = Rote(sNobr, dDateB, dDateTimeE), dtRoteDefault;
                dsAtt.JB_HR_RoteRow rRote;
                int d = 0;  //第一筆班別

                string sRoteHoli = dtRote.Where(p => p.sRoteCode != "00").OrderBy(p => p.dAdate.Date).FirstOrDefault().sRoteCode;

                for (DateTime i = dDateB.Date; i <= dDateTimeE.Date; i = i.Date.AddDays(1))
                {
                    rRote = dtRote.Where(row => row.dAdate == i).FirstOrDefault();
                    if (rRote != null)
                    {
                        oAbsDetail.dDayDate[d] = new AbsDetail.DayDate();
                        oAbsDetail.dDayDate[d].sRoteOld = rRote.sRoteCode;

                        //如果包含假日,且是假日班
                        if (rRote.sRoteCode == "00" && oAbsDetail.bInHoliday)
                        {
                            dtRoteDefault = Rote(sRoteHoli);
                            if (dtRoteDefault.Rows.Count > 0)
                                rRote = dtRoteDefault.Rows[0] as dsAtt.JB_HR_RoteRow;
                        }

                        oAbsDetail.dDayDate[d].sTime = rRote.sAttEnd.Trim() == "0000" || rRote.sAttEnd.Trim().Length == 0 ? oAbsDetail.dDayDate[d].sTimeE : rRote.sAttEnd.Trim();   //實際下班時間
                        oAbsDetail.dDayDate[d].dDatetime = i.AddMinutes(Tools.ConvertHhMmToMinutes(oAbsDetail.dDayDate[d].sTime));

                        oAbsDetail.dDayDate[d].sRote = rRote.sRoteCode;

                        oAbsDetail.dDayDate[d].dDateA = i.Date;
                        oAbsDetail.dDayDate[d].dDateD = i.Date;
                        oAbsDetail.dDayDate[d].sTimeA = rRote.sOnTime;
                        oAbsDetail.dDayDate[d].sTimeD = rRote.sOffTime;
                        oAbsDetail.dDayDate[d].dDatetimeA = i.AddMinutes(Tools.ConvertHhMmToMinutes(rRote.sOnTime));
                        oAbsDetail.dDayDate[d].dDatetimeD = oAbsDetail.dDayDate[d].dDatetime;// i.AddMinutes(Tools.ConvertHhMmToMinutes(rRote.sOffTime));

                        oAbsDetail.dDayDate[d].dDateB = i.Date;
                        oAbsDetail.dDayDate[d].dDateE = i.Date;
                        oAbsDetail.dDayDate[d].sTimeB = ((oAbsDetail.dDayDate[d].dDatetimeA <= dDateTimeB) && (oAbsDetail.dDayDate[d].dDatetimeD > dDateTimeB)) ? sTimeB : oAbsDetail.dDayDate[d].sTimeA;  //如果請假開始時間等於當天上班時間，就以請假開始時間做當天計算
                        oAbsDetail.dDayDate[d].sTimeE = ((oAbsDetail.dDayDate[d].dDatetimeA < dDateTimeE) && (oAbsDetail.dDayDate[d].dDatetimeD >= dDateTimeE)) ? sTimeE : oAbsDetail.dDayDate[d].sTimeD;  //如果請假結束時間等於當天上班時間，就以請假結束時間做當天計算
                        oAbsDetail.dDayDate[d].dDatetimeB = i.AddMinutes(Tools.ConvertHhMmToMinutes(oAbsDetail.dDayDate[d].sTimeB));
                        oAbsDetail.dDayDate[d].dDatetimeE = i.AddMinutes(Tools.ConvertHhMmToMinutes(oAbsDetail.dDayDate[d].sTimeE));

                        oAbsDetail.dDayDate[d].iWkHrs = rRote.iWkHrs;
                        oAbsDetail.dDayDate[d].iDkHrs = rRote.iDkHrs;

                        oAbsDetail.dDayDate[d].iDay = 1;
                        oAbsDetail.dDayDate[d].iOt = rRote.iMoHrs;
                        oAbsDetail.dDayDate[d].iHour = rRote.iWkHrs - oAbsDetail.dDayDate[d].iOt;
                        oAbsDetail.dDayDate[d].iWk = rRote.iWkHrs;
                        oAbsDetail.dDayDate[d].iDk = rRote.iDkHrs;
                        oAbsDetail.dDayDate[d].iOldHour = oAbsDetail.dDayDate[d].iHour;
                        oAbsDetail.dDayDate[d].iOldMin = oAbsDetail.dDayDate[d].iHour * 60;

                        oAbsDetail.dDayDate[d].sResB = rRote.sResBTime;
                        oAbsDetail.dDayDate[d].sResE = rRote.sResETime;
                        oAbsDetail.dDayDate[d].dDayRes = new AbsDetail.DayDate.DayRes[4];   //休息時間分為四個時段，必需寫死，增加休息時間於此
                        oAbsDetail.dDayDate[d].dDayRes[0] = SetDayRes(i, rRote.sResB1Time, rRote.sResE1Time);
                        oAbsDetail.dDayDate[d].dDayRes[1] = SetDayRes(i, rRote.sResB2Time, rRote.sResE2Time);
                        oAbsDetail.dDayDate[d].dDayRes[2] = SetDayRes(i, rRote.sResB3Time, rRote.sResE3Time);
                        oAbsDetail.dDayDate[d].dDayRes[3] = SetDayRes(i, rRote.sResB4Time, rRote.sResE4Time);
                    }
                    d++;
                }

                decimal tsDiffH, tsDiffM;   //休息的小時及分鐘加總
                decimal th, tm; //暫存的總時數及總分鐘

                //更正每天請假天數及時數並加總
                foreach (AbsDetail.DayDate dd in oAbsDetail.dDayDate)
                {
                    if (dd != null)
                    {
                        //條件有重複性，但因為日後有可能各有不同，因此不做條件合併處理(公因式分解)
                        //請假結束時間只要大於當天上班開始時間而且請假開始時間要小於當天上班結束時間，就代表此天要做計算，而且不等於假日班
                        if (dDateTimeE > dd.dDatetimeB && dDateTimeB < dd.dDatetimeE && dd.sRote != "00")
                        {
                            tsDiffH = 0;
                            tsDiffM = 0;
                            dd.bAllDay = false;

                            //如果申請開始日期時間小於等於上班開始日期時間「且」「實際」下班結束日期時間小於等於申請結束日期時間
                            if ((dd.dDatetimeB <= dd.dDatetimeA) && (dd.dDatetime <= dDateTimeE))
                            {
                                dd.bAllDay = true;
                                //dd.iHour = dd.iDkHrs;
                            }
                            else
                            {
                                foreach (AbsDetail.DayDate.DayRes dr in dd.dDayRes)
                                {
                                    //休息時間大於零
                                    if (dr.iMinute > 0 && ((dd.dDatetimeB <= dr.dDatetimeD) && (dd.dDatetimeE >= dr.dDatetimeA)))
                                    {
                                        dr.dDatetimeA = ((dd.dDatetimeB <= dr.dDatetimeA) && (dd.dDatetimeE >= dr.dDatetimeA)) ? dr.dDatetimeA : dd.dDatetimeB;
                                        dr.dDatetimeD = ((dd.dDatetimeB <= dr.dDatetimeD) && (dd.dDatetimeE >= dr.dDatetimeD)) ? dr.dDatetimeD : dd.dDatetimeE;

                                        ts = dr.dDatetimeD - dr.dDatetimeA;
                                        dr.iHours = Convert.ToDecimal(ts.TotalHours);
                                        dr.iMinute = Convert.ToDecimal(ts.TotalMinutes);
                                        tsDiffH += dr.iHours;
                                        tsDiffM += dr.iMinute;
                                    }
                                }

                                ts = dd.dDatetimeE - dd.dDatetimeB;
                                th = Convert.ToDecimal(ts.TotalHours);
                                tm = Convert.ToDecimal(ts.TotalMinutes);
                                //th = (th >= dd.iOldHour) ? dd.iOldHour : th;
                                dd.iDay = (th - tsDiffH) / dd.iHour;
                                dd.iHour = th - tsDiffH;
                                dd.iMin = (tm - tsDiffM);
                            }

                            //特殊規則,以0.5進位
                            //CalDayByCom(dd);

                            //實際時數
                            oAbsDetail.iRealHour += dd.iHour;

                            //判斷是否為整天，若是有一天不是整天，那麼全部就不算整天
                            oAbsDetail.bAllDay = oAbsDetail.bAllDay ? dd.bAllDay : oAbsDetail.bAllDay;

                            //最小時數或天數判斷
                            dd.iHour = dd.iHour >= oAbsDetail.iHcodeMin ? dd.iHour : oAbsDetail.iHcodeMin;

                            dd.iHour = CalAbsUint(oAbsDetail.iHcodeMin, oAbsDetail.iAbsUint, dd.iHour);

                            //判斷是否超過每1天的天數或時數並做加總(實際要存入HR的時數或天數)
                            oAbsDetail.iTotalDay += (dd.iDay > 1) ? 1 : dd.iDay;
                            oAbsDetail.iTotalHour += (dd.iHour > dd.iOldHour) ? dd.iOldHour : dd.iHour;
                            oAbsDetail.iTotalMin += dd.iMin;
                        }
                        else
                        {
                            dd.iDay = 0;
                            dd.iHour = 0;
                        }

                        //顯示用
                        if (dd.iDay >= 1)
                            oAbsDetail.iDay++;
                        else
                            oAbsDetail.iHour += dd.iHour;
                    }
                }

                oAbsDetail.bHcodeMin = (oAbsDetail.sHcodeUnit == "天") ? (oAbsDetail.iTotalDay >= oAbsDetail.iHcodeMin) : (oAbsDetail.iTotalHour >= oAbsDetail.iHcodeMin);
                oAbsDetail.bAbsUint = (oAbsDetail.bAllDay) || IsAbsUint(oAbsDetail.iAbsUint, (oAbsDetail.sHcodeUnit == "天") ? (oAbsDetail.iTotalDay - oAbsDetail.iHcodeMin) : (oAbsDetail.iTotalHour - oAbsDetail.iHcodeMin)); //天數或時數總和先減掉最小的單位數再判斷是否符合隔格單位

                oAbsDetail.iTotalDay = (oAbsDetail.sHcodeUnit == "天") ? CalAbsUint(oAbsDetail.iHcodeMin, oAbsDetail.iAbsUint, oAbsDetail.iTotalDay - Convert.ToDecimal(0.1)) : 0;    //要減二小時約0.1天
                oAbsDetail.iTotalHour = (oAbsDetail.sHcodeUnit == "小時") ? CalAbsUint(oAbsDetail.iHcodeMin, oAbsDetail.iAbsUint, oAbsDetail.iTotalHour) : 0;

                //無特殊情況天數或時數時，再採用
                //oAbsDetail.iDay = (oAbsDetail.sHcodeUnit == "天") ? oAbsDetail.iDay : 0;
                //oAbsDetail.iHour = (oAbsDetail.sHcodeUnit == "小時") ? oAbsDetail.iHour : 0;

                oAbsDetail.bBalance = IsBalance(sNobr, sHcode, dDateB, (oAbsDetail.sHcodeUnit == "天") ? oAbsDetail.iTotalDay : oAbsDetail.iTotalHour, sName, iProceedingHour);

                return oAbsDetail;
            }

            /// <summary>
            /// 三洋
            /// </summary>
            /// <param name="dd">每日</param>
            private static void CalDayByCom(AbsDetail.DayDate dd)
            {
                dd.iDay = dd.iDay >= 1 ? 1 : Convert.ToDecimal(0.5);
                dd.iHour = dd.iHour > 4 ? dd.iOldHour : 4;
            }

            /// <summary>
            /// 是否有剩餘時數 True = 有
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="sHcode">假別代碼</param>
            /// <param name="dDate">請假日期</param>
            /// <param name="iUse">使用天數或時數</param>
            /// <param name="sName">對沖對象</param>
            /// <param name="iProceedingHour">進行中時數</param>
            /// <returns>bool</returns>
            public static bool IsBalance(string sNobr, string sHcode, DateTime dDate, decimal iUse, string sName, decimal iProceedingHour)
            {
                bool bBalance = false;
                dsAtt.JB_HR_HcodeDataTable dtHcode = Att.Hcode(sHcode);

                if (dtHcode.Rows.Count > 0)
                {
                    bBalance = true;

                    dsAtt.JB_HR_HcodeRow rh = dtHcode.Rows[0] as dsAtt.JB_HR_HcodeRow;
                    sHcode = rh.sYearRest == "0" ? sHcode : rh.sYearRest;   //特、彈、補
                    if (!rh.bCheck) return true;    //不用檢查直接出去

                    dsAtt.AbsInfoDataDataTable dtAbsInfoData = AbsInfo(sNobr, dDate.Date);
                    var dtAbsInfoDataHcode = dtAbsInfoData.Where(p => p.sHoliCode == sHcode && p.sName == sName);
                    var rAbsInfoDataHcode = dtAbsInfoDataHcode.FirstOrDefault();
                    if (rAbsInfoDataHcode == null && rh.sYearRest != "0") return false; //沒有請過此假直接出去

                    //每一種的max
                    decimal iMax = Convert.ToDecimal(rh.iMax);
                    if (rAbsInfoDataHcode != null)
                    {
                        //if (rh.sHcode == "F" || rh.sYearRest != "0" || rh.sHcode == "B" || rh.sHcode == "C")
                            iMax = rAbsInfoDataHcode.iBalance;
                    }

                    //如果是生理假(1個月只能請一次。)
                    if (rh.sGroupCode == "C")
                    {
                        iMax = rh.iMax;
                        var rEmp = Bas.EmpBase(sNobr).FirstOrDefault();
                        if (rEmp == null) return false;

                        var rDataGroup = Bas.DataGroup().Where(p => p.sDataGroup == rEmp.sSaladr).FirstOrDefault();
                        if (rDataGroup == null) return false;

                        dcBasDataContext dc = new dcBasDataContext();

                        var rU_SYS2 = dc.U_SYS2.Where(p => p.Comp == rDataGroup.sComp).FirstOrDefault();
                        if (rU_SYS2 == null) return false;

                        int iAttDay =  rU_SYS2.ATTMONTH.Value;

                        DateTime dDateB = DateTime.Now;
                        DateTime dDateE = DateTime.Now;

                        if (dDate.Day > iAttDay)
                            dDate = dDate.AddMonths(1);

                        dDateE = new DateTime(dDate.Year, dDate.Month
                               , DateTime.DaysInMonth(dDate.Year, dDate.Month) <= iAttDay
                               ? DateTime.DaysInMonth(dDate.Year, dDate.Month) : iAttDay);

                        //加一天減一個月
                        dDateB = dDateE.AddDays(1).AddMonths(-1);

                        dDateB = new DateTime(dDate.Year, dDate.Month, 1);
                        dDateE = new DateTime(dDate.Year, dDate.Month, DateTime.DaysInMonth(dDate.Year, dDate.Month));

                        dsAtt.JB_HR_AbsUnionDataTable dtAbs = Att.Abs(sNobr, dDateB, dDateE, sHcode);
                        //bBalance = (dtAbs.Rows.Count == 0);  //沒有請過生理假
                        decimal i = 0;
                        if (dtAbs.Count > 0)
                            i = dtAbs.Sum(p => p.iUse);

                        bBalance = (iMax - i - iUse - iProceedingHour) >= 0;

                        //再檢查病假
                        var rAbs = dtAbsInfoData.Where(p => p.sHoliCode == rh.sDcode).FirstOrDefault();
                        iMax = rAbs != null ? rAbs.iBalance : rh.iMax;
                    }
                    else if (rh.sGroupCode == "B")   //家庭照顧假七天
                    {
                        iMax = rh.iMax;
                        DateTime dDateB = new DateTime(dDate.Year, 1, 1);   //預設以請假當月1日為準
                        DateTime dDateE = new DateTime(dDate.Year, 12, 31);

                        dsAtt.JB_HR_AbsUnionDataTable dtAbs = Att.Abs(sNobr, dDateB, dDateE, sHcode);
                        decimal i = 0;
                        if (dtAbs.Count > 0)
                            i = dtAbs.Sum(p => p.iUse);

                        bBalance = (iMax - i - iUse - iProceedingHour) >= 0;

                        //再檢查事假
                        var rAbs = dtAbsInfoData.Where(p => p.sHoliCode == rh.sDcode).FirstOrDefault();
                        iMax = rAbs != null ? rAbs.iBalance : rh.iMax;
                    }

                    bBalance = bBalance ? (iMax - iUse - iProceedingHour) >= 0 : bBalance;
                }

                return bBalance;
            }

            /// <summary>
            /// 請假資訊(橫向檢視)
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDate">請假日期</param>
            /// <param name="sName">對沖對象</param>
            /// <returns>DataTable</returns>
            public static DataTable AbsView(string sNobr, DateTime dDate, string sName)
            {
                dsAtt.AbsInfoDataDataTable dtAbsInfoData = AbsInfo(sNobr, dDate.Date);
                DataRow[] rows = dtAbsInfoData.Select("bDisplayform = 1", "sHoliCode");

                DataTable dtAbsInfo = new DataTable();
                dtAbsInfo.Columns.Add("sName", typeof(string)).DefaultValue = "";
                foreach (dsAtt.AbsInfoDataRow r in rows)
                    if (!dtAbsInfo.Columns.Contains(r.sHoliCode))
                        if (r.sName == "" || r.sName == sName)
                            if ((r.iMax > 0 && r.sYearRest != "0") || r.iUse > 0 || (r.iBalance > 0 && r.sYearRest != "0"))
                                dtAbsInfo.Columns.Add(r.sHoliCode, typeof(decimal));

                DataRow ra;
                //ra = dtAbsInfo.NewRow();
                //ra["sName"] = "全部";
                //foreach (dsAtt.AbsInfoDataRow r in dtAbsInfoData.Rows)
                //    if (dtAbsInfo.Columns.Contains(r.sHoliCode))
                //        ra[r.sHoliCode.Trim()] = (r.sYearRest.Trim() == "0") ? r.iUse : r.iMax;
                //dtAbsInfo.Rows.Add(ra);

                ra = dtAbsInfo.NewRow();
                ra["sName"] = "已請";
                foreach (dsAtt.AbsInfoDataRow r in dtAbsInfoData.Rows)
                    if (dtAbsInfo.Columns.Contains(r.sHoliCode))
                        ra[r.sHoliCode] = r.iUseDisplay;
                dtAbsInfo.Rows.Add(ra);

                ra = dtAbsInfo.NewRow();
                ra["sName"] = "剩餘";
                foreach (dsAtt.AbsInfoDataRow r in dtAbsInfoData.Rows)
                    if (dtAbsInfo.Columns.Contains(r.sHoliCode))
                        if (r.sYearRest != "0")
                            ra[r.sHoliCode] = r.iBalance;
                dtAbsInfo.Rows.Add(ra);

                DataColumnCollection dcc = dtAbsInfo.Columns;
                dcc["sName"].ColumnName = " ";
                foreach (DataColumn dc in dcc)
                {
                    rows = dtAbsInfoData.Select("sHoliCode = '" + dc.ColumnName + "'");
                    if (rows.Length > 0)
                    {
                        dsAtt.AbsInfoDataRow r = (dsAtt.AbsInfoDataRow)rows[0];
                        dc.ColumnName = r.sHoliName + "(" + r.sUint + ")";
                    }
                }

                return dtAbsInfo;
            }

            /// <summary>
            /// 計算請假資訊
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDate">請假日期</param>
            /// <returns>AbsInfoDataDataTable</returns>
            public static dsAtt.AbsInfoDataDataTable AbsInfo(string sNobr, DateTime dDate)
            {
                dsAtt.AbsInfoDataDataTable dtAbsInfoData = new dsAtt.AbsInfoDataDataTable();

                dsBas.JB_HR_BaseRow rEmpBase = JBHR.Dll.Bas.EmpBase(sNobr).FirstOrDefault();
                if (rEmpBase != null)
                {
                    DateTime dDateB, dDateE;
                    dDateB = new DateTime(dDate.Year, 1, 1).Date;
                    dDateE = new DateTime(dDate.Year, 12, 31).Date;

                    InsertAbs246(dtAbsInfoData, sNobr, dDateB, dDateE, dDate.Date, "1", "2", "特休");
                    InsertAbs246(dtAbsInfoData, sNobr, dDateB, dDateE, dDate.Date, "3", "4", "補休");
                    InsertAbs246(dtAbsInfoData, sNobr, dDateB, dDateE, dDate.Date, "5", "6", "彈休");
                    InsertAbsT(dtAbsInfoData, sNobr, dDate.Date);
                    InsertAbsDcode(dtAbsInfoData, sNobr, dDateB, dDateE, dDate.Date);
                }

                return dtAbsInfoData;
            }

            /// <summary>
            /// 顯示今年度特休延的剩餘天數
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDateB">計算開始日期</param>
            /// <param name="dDateE">計算結束日期</param>
            /// <param name="dDate">請假日期</param>
            /// <param name="sCatAdd">加項</param>
            /// <param name="sCatSubtract">減項</param>
            /// <returns>decimal</returns>
            public static decimal HcodeByW1(string sNobr, DateTime dDateB, DateTime dDateE, DateTime dDate, string sCatAdd, string sCatSubtract)
            {
                decimal iW1 = 0;
                string[] sYearRest = { sCatAdd, sCatSubtract };
                dcAttDataContext dc = new dcAttDataContext();
                var sql = from a in dc.JB_HR_AbsUnion
                          join h in dc.JB_HR_Hcode
                          on a.sHoliCode equals h.sHcode
                          where a.sNobr == sNobr
                          && sYearRest.Contains(Convert.ToString(h.sYearRest))
                          && dDateB <= Convert.ToDateTime(a.dDateB).Date && Convert.ToDateTime(a.dDateB).Date <= dDateE
                          select new { Abs = a, Hcode = h };

                decimal iMax, iUse;
                var dt = sql.ToList();
                var dtAbsCatAdd = dt.Where(p => Convert.ToString(p.Hcode.sYearRest) == sCatAdd && p.Abs.sHoliCode == "W1");
                var rAbs = dtAbsCatAdd.FirstOrDefault();    //取得第一筆資料

                if (rAbs != null)
                {
                    //計算可請上限數及已請數
                    iMax = dtAbsCatAdd.Sum(p => Convert.ToDecimal(p.Abs.iUse));
                    iUse = dt.Where(p => Convert.ToString(p.Hcode.sYearRest) == sCatSubtract).Sum(p => Convert.ToDecimal(p.Abs.iUse));

                    iW1 = iMax - iUse;
                }

                return iW1 > 0 ? iW1 : 0;
            }

            /// <summary>
            /// 特休、補休、彈休計算
            /// </summary>
            /// <param name="dtAbsInfoData">AbsInfoDataDataTable</param>
            /// <param name="sNobr">工號</param>
            /// <param name="dDateB">計算開始日期</param>
            /// <param name="dDateE">計算結束日期</param>
            /// <param name="dDate">請假日期</param>
            /// <param name="sCatAdd">加項</param>
            /// <param name="sCatSubtract">減項</param>
            /// <param name="sHoliName">假別名稱</param>
            private static void InsertAbs246(dsAtt.AbsInfoDataDataTable dtAbsInfoData, string sNobr, DateTime dDateB, DateTime dDateE, DateTime dDate, string sCatAdd, string sCatSubtract, string sHoliName)
            {
                string[] sYearRest = { sCatAdd, sCatSubtract };
                dcAttDataContext dc = new dcAttDataContext();
                var sql = from a in dc.JB_HR_AbsUnion
                          join h in dc.JB_HR_Hcode
                          on a.sHoliCode equals h.sHcode
                          where a.sNobr == sNobr
                          && sYearRest.Contains(Convert.ToString(h.sYearRest))
                          && dDateB <= Convert.ToDateTime(a.dDateB).Date && Convert.ToDateTime(a.dDateB).Date <= dDateE
                          select new { Abs = a, Hcode = h };

                decimal iMax, iUse;
                var dt = sql.ToList();
                var dtAbsCatAdd = dt.Where(p => Convert.ToString(p.Hcode.sYearRest) == sCatAdd && dDateB <= Convert.ToDateTime(p.Abs.dDateB).Date && Convert.ToDateTime(p.Abs.dDateB).Date <= dDate);
                var rAbs = dtAbsCatAdd.FirstOrDefault();    //取得第一筆資料

                if (rAbs != null)
                {
                    //計算可請上限數及已請數
                    iMax = dtAbsCatAdd.Sum(p => Convert.ToDecimal(p.Abs.iUse));
                    iUse = dt.Where(p => Convert.ToString(p.Hcode.sYearRest) == sCatSubtract).Sum(p => Convert.ToDecimal(p.Abs.iUse));

                    dsAtt.AbsInfoDataRow r = dtAbsInfoData.NewAbsInfoDataRow();
                    SetAbsInfoDataRowData(r, sCatSubtract, sHoliName, rAbs.Hcode.bInHoli, Convert.ToDecimal(rAbs.Hcode.iMin)
                        , Convert.ToDecimal(rAbs.Hcode.iAbsUint), rAbs.Hcode.sUnit, iUse, iMax, iMax - iUse
                        , Convert.ToString(rAbs.Hcode.sYearRest), rAbs.Hcode.sDcode, Convert.ToBoolean(rAbs.Hcode.bCheck)
                        , Convert.ToBoolean(rAbs.Hcode.bDisplayForm), dDateB, dDateE, "" , iUse);
                    dtAbsInfoData.AddAbsInfoDataRow(r);
                }
            }

            /// <summary>
            /// 產生得假資料，如喪假、產假、婚假，以請假當天尋找得假資料，生失效日為已休的計算區間，喪假必須例外處理
            /// </summary>
            /// <param name="dtAbsInfoData">AbsInfoDataDataTable</param>
            /// <param name="sNobr">工號</param>
            /// <param name="dDate">請假日期</param>
            private static void InsertAbsT(dsAtt.AbsInfoDataDataTable dtAbsInfoData, string sNobr, DateTime dDate)
            {
                //得假資料
                dcAttDataContext dc = new dcAttDataContext();
                var sqlAbst = from a in dc.JB_HR_Abst
                              join h in dc.JB_HR_Hcode
                              on a.sHoliCode equals h.sHcode
                              where a.sNobr == sNobr
                              && a.dDateB <= dDate && dDate <= a.dDateE
                              && Convert.ToString(h.sYearRest) == "0"
                              select new { Abst = a, Hcode = h };
                var dtAbst = sqlAbst.ToList();

                //請假資料
                var sqlAbs = from a in dc.JB_HR_AbsUnion
                             join h in dc.JB_HR_Hcode
                             on a.sHoliCode equals h.sHcode
                             where a.sNobr == sNobr
                             && Convert.ToString(h.sYearRest) == "0"
                             select new { Abs = a, Hcode = h };
                var dtAbs = sqlAbs.ToList();

                decimal iMax, iUse;
                foreach (var ra in dtAbst)
                {
                    var dtAbsDate = dtAbs.Where(p =>
                        Convert.ToDateTime(ra.Abst.dDateB).Date <= Convert.ToDateTime(p.Abs.dDateB).Date
                        && Convert.ToDateTime(p.Abs.dDateB).Date <= Convert.ToDateTime(ra.Abst.dDateE).Date
                        && Convert.ToString(p.Abs.sName).Trim() == Convert.ToString(ra.Abst.sAname).Trim()
                        && (p.Abs.sHoliCode == ra.Abst.sHoliCode
                        || p.Abs.sHoliCode == ra.Abst.sT1Code
                        || p.Abs.sHoliCode == ra.Abst.sT2Code
                        || p.Abs.sHoliCode == ra.Abst.sT3Code));
                    var rAbs = dtAbsDate.FirstOrDefault();

                    iMax = Convert.ToDecimal(ra.Abst.iTolHours);
                    iUse = dtAbsDate.Count() > 0 ? Convert.ToDecimal(dtAbsDate.Sum(p => p.Abs.iUse)) : 0;

                    dsAtt.AbsInfoDataRow r = dtAbsInfoData.NewAbsInfoDataRow();
                    SetAbsInfoDataRowData(r, ra.Hcode.sHcode, ra.Hcode.sHname, ra.Hcode.bInHoli, Convert.ToDecimal(ra.Hcode.iMin)
                        , Convert.ToDecimal(ra.Hcode.iAbsUint), ra.Hcode.sUnit, iUse, iMax, iMax - iUse
                        , Convert.ToString(ra.Hcode.sYearRest), ra.Hcode.sDcode, Convert.ToBoolean(ra.Hcode.bCheck)
                        , Convert.ToBoolean(ra.Hcode.bDisplayForm), Convert.ToDateTime(ra.Abst.dDateB), Convert.ToDateTime(ra.Abst.dDateE), ra.Abst.sAname , iUse);
                    dtAbsInfoData.AddAbsInfoDataRow(r);
                }
            }

            /// <summary>
            /// 最大可休時數或天數相關假，如事假、病假，並將關聯相加，以及一般的假，例如公出、公傷
            /// </summary>
            /// <param name="dtAbsInfoData">AbsInfoDataDataTable</param>
            /// <param name="sNobr">工號</param>
            /// <param name="dDateB">計算開始日期</param>
            /// <param name="dDateE">計算結束日期</param>
            /// <param name="dDate">請假日期</param>
            private static void InsertAbsDcode(dsAtt.AbsInfoDataDataTable dtAbsInfoData, string sNobr, DateTime dDateB, DateTime dDateE, DateTime dDate)
            {
                dcAttDataContext dc = new dcAttDataContext();
                var sql = from a in dc.JB_HR_AbsUnion
                          join h in dc.JB_HR_Hcode
                          on a.sHoliCode equals h.sHcode
                          where a.sNobr == sNobr
                          && Convert.ToString(h.sYearRest) == "0"
                          && dDateB <= a.dDateB && a.dDateB <= dDateE
                          select new { Abs = a, Hcode = h };

                decimal iMax, iUse, iUseDisplay;
                var dt = sql.ToList();

                var dtHcode = Att.Hcode("").Where(p => p.sYearRest == "0");
                foreach (var rh in dtHcode)
                {
                    //先檢查是否有重複的資料
                    if (dtAbsInfoData.Where(p => p.sHoliCode == rh.sHcode).Count() == 0)
                    {
                        iMax = Convert.ToDecimal(rh.iMax);// +Convert.ToDecimal(dtHcode.Where(p => p.sHcode == rh.sDcode).Sum(p => p.iMax));
                        var dtAbsHcode = dt.Where(p => p.Abs.sHoliCode == rh.sHcode
                               || p.Abs.sHoliCode == rh.sDcode);

                        //計算單獨的時數
                        var dtAbsHcode1 = dt.Where(p => p.Abs.sHoliCode == rh.sHcode);

                        var rAbs = dtAbsHcode.FirstOrDefault();
                        if (rAbs != null)
                        {
                            iUse = Convert.ToDecimal(dtAbsHcode.Sum(p => p.Abs.iUse));

                            iUseDisplay = Convert.ToDecimal(dtAbsHcode1.Sum(p => p.Abs.iUse));

                            dsAtt.AbsInfoDataRow r = dtAbsInfoData.NewAbsInfoDataRow();
                            SetAbsInfoDataRowData(r, rh.sHcode, rh.sHname, rh.bInHoli, Convert.ToDecimal(rh.iMin)
                                , Convert.ToDecimal(rh.iAbsUint), rh.sUnit, iUse, iMax, iMax - iUse
                                , Convert.ToString(rh.sYearRest), rh.sDcode, Convert.ToBoolean(rh.bCheck)
                                , Convert.ToBoolean(rh.bDisplayForm), dDateB, dDateE, "", iUseDisplay);
                            dtAbsInfoData.AddAbsInfoDataRow(r);
                        }
                    }
                }
            }

            /// <summary>
            /// 設定AbsInfoData
            /// </summary>
            /// <param name="r">AbsInfoDataRow</param>
            /// <param name="sHoliCode">假別代碼</param>
            /// <param name="sHoliName">假別名稱</param>
            /// <param name="bInHoli">是否包含假日 True = 是</param>
            /// <param name="iMin">最小單位數</param>
            /// <param name="iInterval">最小間隔單位數</param>
            /// <param name="sUint">單位(天/小時)</param>
            /// <param name="iUse">已使用數</param>
            /// <param name="iMax">上限數</param>
            /// <param name="iBalance">剩餘數</param>
            /// <param name="sYearRest">年補休特性</param>
            /// <param name="sDcode">關聯假別代碼</param>
            /// <param name="bChe">是否要檢查 True = 是</param>
            /// <param name="bDisplayform">是否要顯示請假資訊 True = 是</param>
            /// <param name="dDateB">計算開始日期</param>
            /// <param name="dDateE">計算結束日期</param>
            /// <param name="sName">對沖對象</param>
            /// <param name="iUseDisplay">真實顯示時數</param>
            private static void SetAbsInfoDataRowData(dsAtt.AbsInfoDataRow r, string sHoliCode, string sHoliName, bool bInHoli, decimal iMin, decimal iInterval, string sUint, decimal iUse, decimal iMax, decimal iBalance, string sYearRest, string sDcode, bool bChe, bool bDisplayform, DateTime dDateB, DateTime dDateE, string sName , decimal iUseDisplay = 0)
            {
                r.sHoliCode = sHoliCode;
                r.sHoliName = sHoliName;
                r.bInHoli = bInHoli;
                r.iMin = iMin;
                r.iInterval = iInterval;
                r.sUint = sUint;
                r.iUseDisplay = iUseDisplay;
                r.iUse = iUse;
                r.iMax = iMax;
                r.iBalance = iBalance;
                r.sYearRest = sYearRest;
                r.sDcode = sDcode;
                r.bChe = bChe;
                r.bDisplayform = bDisplayform;
                r.dDateB = dDateB;
                r.dDateE = dDateE;
                r.sName = sName;
            }

            /// <summary>
            /// 取得每個員工特、彈、補的得假與請假詳細資料
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDate">當天日期</param>
            /// <param name="dDateB">計算開始日期</param>
            /// <param name="dDateE">計算結束日期</param>
            /// <param name="sCatAdd">加項</param>
            /// <param name="sCatSubtract">減項</param>
            /// <returns>傳回一個詳細的資料表</returns>
            public static dsAtt.AbsPersonalDataTable AbsPersonal(string sNobr, DateTime dDate, DateTime dDateB, DateTime dDateE, string sCatAdd, string sCatSubtract)
            {
                dsAtt odsMain = new dsAtt();
                dsAtt.AbsPersonalDataTable dtAbsPersonal = new dsAtt.AbsPersonalDataTable();
                int i = 0;
                decimal iUseAddTotal = 0, iUseSubtractTotal = 0, iBalance = 0, iBalanceTemp = 0, iUse;

                //放入加項
                dsAtt.JB_HR_AbsUnionDataTable dtAbs = Att.Abs(sNobr, sCatAdd, dDateB, dDateE);
                DataRow[] rows = dtAbs.Select("", "dDateB , sTimeB");
                foreach (dsAtt.JB_HR_AbsUnionRow ra in rows)
                {
                    dsAtt.AbsPersonalRow rp = odsMain.AbsPersonal.NewAbsPersonalRow();
                    Tools.SetRowDefaultValue(rp);

                    foreach (DataColumn dc in odsMain.AbsPersonal.Columns)
                        if (dtAbs.Columns.Contains(dc.ToString()))
                            rp[dc] = ra[dc.ToString()];

                    i++;
                    rp.iAutoKey = i;
                    rp.dDateTimeB = rp.dDateB.AddMinutes(Tools.ConvertHhMmToMinutes(rp.sTimeB));
                    rp.dDateTimeE = rp.dDateE.AddMinutes(Tools.ConvertHhMmToMinutes(rp.sTimeE));
                    rp.sCat = sCatAdd;
                    rp.iUseAdd = rp.iUse;
                    iUseAddTotal += rp.iUse;
                    rp.iBalanceTemp = rp.iUse;  //把剩餘時數放到暫時的變數裡
                    rp.iUseAddTotal = iUseAddTotal;

                    odsMain.AbsPersonal.AddAbsPersonalRow(rp);
                }

                //放入減項
                dtAbs = Att.Abs(sNobr, sCatSubtract, dDateB, dDateE);
                rows = dtAbs.Select("", "dDateB , sTimeB");
                foreach (dsAtt.JB_HR_AbsUnionRow ra in rows)
                {
                    dsAtt.AbsPersonalRow rp = odsMain.AbsPersonal.NewAbsPersonalRow();
                    Tools.SetRowDefaultValue(rp);

                    i++;
                    rp.iAutoKey = i;
                    foreach (DataColumn dc in odsMain.AbsPersonal.Columns)
                        if (dtAbs.Columns.Contains(dc.ToString()))
                            rp[dc] = ra[dc.ToString()];

                    rp.dDateTimeB = rp.dDateB.AddMinutes(Tools.ConvertHhMmToMinutes(rp.sTimeB));
                    rp.dDateTimeE = rp.dDateE.AddMinutes(Tools.ConvertHhMmToMinutes(rp.sTimeE));
                    rp.sCat = sCatSubtract;
                    rp.iUseSubtract = rp.iUse;
                    iUseSubtractTotal += rp.iUse;
                    rp.iUseSubtractTotal = iUseSubtractTotal;

                    odsMain.AbsPersonal.AddAbsPersonalRow(rp);
                }

                //排序重放入dt
                DataRow[] rowsA;
                i = 0;
                iBalance = 0;
                rows = odsMain.AbsPersonal.Select("", "dDateTimeB");
                foreach (dsAtt.AbsPersonalRow r in rows)
                {
                    iBalanceTemp = 0;
                    iUse = r.iUse;

                    //如果是減項
                    if (r.sCat == sCatSubtract)
                    {
                        rowsA = dtAbsPersonal.Select("sCat = '" + sCatAdd + "' AND iBalanceTemp > 0", "dDateTimeB");
                        foreach (dsAtt.AbsPersonalRow r1 in rowsA)
                        {
                            //請假日一定要在生失效日裡
                            if ((r1.dDateTimeB <= r.dDateTimeB) && (r1.dDateTimeE >= r.dDateTimeB))
                            {
                                iBalanceTemp = r1.iBalanceTemp - iUse;
                                r1.iBalanceTemp = (iBalanceTemp >= 0) ? iBalanceTemp : 0;

                                if (iBalanceTemp >= 0)
                                    break;
                                else
                                    iUse = Math.Abs(iBalanceTemp);
                            }
                        }

                        iBalance = iBalance - r.iUse;
                    }
                    else
                    {
                        iBalance = iBalance + r.iUse;
                    }

                    //加減方式是錯的

                    r.iBalance = iBalance;

                    dsAtt.AbsPersonalRow ra = dtAbsPersonal.NewAbsPersonalRow();
                    ra.ItemArray = r.ItemArray;
                    i++;
                    ra.iAutoKey = i;
                    ra.sName = JBHR.Dll.Bas.EmpBase(ra.sNobr).FirstOrDefault().sNameC;
                    dtAbsPersonal.AddAbsPersonalRow(ra);
                }

                return dtAbsPersonal;
            }

            /// <summary>
            /// 將請假資料存入HR.ABS實體資料表 True = 存入成功
            /// </summary>
            /// <param name="sNobr">請假人工號</param>
            /// <param name="sHcode">請假假別</param>
            /// <param name="dDateB">開始日期</param>
            /// <param name="dDateE">結束日期</param>
            /// <param name="sTimeB">開始時間</param>
            /// <param name="sTimeE">結束時間</param>
            /// <param name="sDeptCode">部門</param>
            /// <param name="sNote">原因</param>
            /// <param name="sKeyMan">申請者工號或姓名</param>
            /// <param name="sName">沖假對象</param>
            /// <param name="iException">例外時數</param>
            /// <param name="sSerno">表單編號</param>
            /// <returns>bool</returns>
            public static bool AbsSaveBy24(string sNobr, string sHcode, DateTime dDateB, DateTime dDateE, string sTimeB, string sTimeE, string sDeptCode, string sNote, string sKeyMan, string sName, decimal iException, string sSerno)
            {
                sTimeB = sTimeB.PadLeft(4, char.Parse("0"));
                sTimeE = sTimeE.PadLeft(4, char.Parse("0"));

                bool bSave = false;

                dsAtt.JB_HR_RoteDataTable dtRote = Att.Rote(sNobr, dDateB.Date);
                var rRote = dtRote.FirstOrDefault();

                if (rRote != null)
                {
                    int b, e, i;
                    int.TryParse(rRote.sOnTime, out b);
                    int.TryParse(rRote.sOffTime, out e);
                    int.TryParse(sTimeB, out i);

                    //若是不在此天的上下班時間裡
                    if (b > i || i > e)
                    {
                        //日期減一天，時間加24小時
                        dDateB = dDateB.AddDays(-1).Date;
                        sTimeB = Convert.ToString(i + 2400).PadLeft(4, char.Parse("0"));
                    }
                }

                dtRote = Att.Rote(sNobr, dDateE.Date);
                rRote = dtRote.FirstOrDefault();

                if (rRote != null)
                {
                    int b, e, i;
                    int.TryParse(rRote.sOnTime, out b);
                    int.TryParse(rRote.sOffTime, out e);
                    int.TryParse(sTimeE, out i);

                    //若是不在此天的上下班時間裡
                    if (b > i || i > e)
                    {
                        //日期減一天，時間加24小時
                        dDateE = dDateE.AddDays(-1).Date;
                        sTimeE = Convert.ToString(i + 2400).PadLeft(4, char.Parse("0"));
                    }
                }

                bSave = AbsSave(sNobr, sHcode, dDateB, dDateE, sTimeB, sTimeE, sDeptCode, sNote, sKeyMan, sName, iException, sSerno);
                return bSave;
            }

            /// <summary>
            /// 將請假資料存入HR.ABS實體資料表 True = 存入成功
            /// </summary>
            /// <param name="sNobr">請假人工號</param>
            /// <param name="sHcode">請假假別</param>
            /// <param name="dDateB">開始日期</param>
            /// <param name="dDateE">結束日期</param>
            /// <param name="sTimeB">開始時間</param>
            /// <param name="sTimeE">結束時間</param>
            /// <param name="sDeptCode">部門</param>
            /// <param name="sNote">原因</param>
            /// <param name="sKeyMan">申請者工號或姓名</param>
            /// <param name="sName">沖假對象</param>
            /// <param name="iException">例外時數</param>
            /// <returns>bool</returns>
            public static bool AbsSaveBy24(string sNobr, string sHcode, DateTime dDateB, DateTime dDateE, string sTimeB, string sTimeE, string sDeptCode, string sNote, string sKeyMan, string sName, decimal iException)
            {
                sTimeB = sTimeB.PadLeft(4, char.Parse("0"));
                sTimeE = sTimeE.PadLeft(4, char.Parse("0"));

                return AbsSaveBy24(sNobr, sHcode, dDateB, dDateE, sTimeB, sTimeB, sDeptCode, sNote, sKeyMan, sName, iException, "");
            }

            /// <summary>
            /// 將請假資料存入HR.ABS實體資料表 True = 存入成功
            /// </summary>
            /// <param name="sNobr">請假人工號</param>
            /// <param name="sHcode">請假假別</param>
            /// <param name="dDateB">開始日期</param>
            /// <param name="dDateE">結束日期</param>
            /// <param name="sTimeB">開始時間</param>
            /// <param name="sTimeE">結束時間</param>
            /// <param name="sDeptCode">部門</param>
            /// <param name="sNote">原因</param>
            /// <param name="sKeyMan">申請者工號或姓名</param>
            /// <param name="sName">沖假對象</param>
            /// <param name="iException">例外時數</param>
            /// <param name="sSerno">表單編號</param>
            /// <returns>bool</returns>
            public static bool AbsSave(string sNobr, string sHcode, DateTime dDateB, DateTime dDateE, string sTimeB, string sTimeE, string sDeptCode, string sNote, string sKeyMan, string sName, decimal iException, string sSerno)
            {
                sTimeB = sTimeB.PadLeft(4, char.Parse("0"));
                sTimeE = sTimeE.PadLeft(4, char.Parse("0"));

                bool bSave = false;

                dsAttTableAdapters.ABSTableAdapter taABS = new JBHR.Dll.dsAttTableAdapters.ABSTableAdapter();
                dsAttTableAdapters.ABS1TableAdapter taABS1 = new JBHR.Dll.dsAttTableAdapters.ABS1TableAdapter();

                dsAtt odsAtt = new dsAtt();
                dsAtt.ABSRow ra;
                dsAtt.ABS1Row ra1;
                decimal th;

                int iSalaryDay = 0;
                var rEmpBase = JBHR.Dll.Bas.BaseTts(sNobr, dDateB).FirstOrDefault();
                if (rEmpBase != null)
                {
                    sDeptCode = sDeptCode.Trim().Length == 0 ? rEmpBase.sDeptsCode : sDeptCode;

                    var rDataGroup = JBHR.Dll.Bas.DataGroup().Where(p => p.sDataGroup == rEmpBase.sSaladr).FirstOrDefault();
                    if (rDataGroup != null)
                        iSalaryDay = SalaryDay(rDataGroup.sComp);
                }

                JBHR.Dll.Att.AbsCal.AbsDetail oAbsDetail = JBHR.Dll.Att.AbsCal.AbsCalculation(sNobr, sHcode, dDateB, dDateE, sTimeB, sTimeE, sName);

                foreach (JBHR.Dll.Att.AbsCal.AbsDetail.DayDate dd in oAbsDetail.dDayDate)
                {
                    if (dd != null && (dd.iDay > 0 || dd.iHour > 0))
                    {
                        //檢查資料是否有重複
                        if (!JBHR.Dll.Att.AbsCheck.IsRepeatData(sNobr, dd.dDatetimeB, dd.dDatetimeE, false))
                        {
                            th = oAbsDetail.sHcodeUnit == "天" ? dd.iDay : dd.iHour;

                            //代碼「O」為公出假
                            //if (sHcode == "O")
                            //{
                            //    ra1 = odsAtt.ABS1.NewABS1Row();
                            //    Tools.SetRowDefaultValue(ra1);
                            //    ra1.NOBR = sNobr;
                            //    ra1.BDATE = dd.dDateB.Date;
                            //    ra1.EDATE = dd.dDateB.Date;
                            //    ra1.BTIME = dd.sTimeB;
                            //    ra1.ETIME = dd.sTimeE;
                            //    ra1.H_CODE = sHcode;
                            //    ra1.TOL_HOURS = iException > 0 ? iException : th;
                            //    ra1.KEY_MAN = sKeyMan;
                            //    ra1.DEPT = sDeptCode;
                            //    ra1.NOTE = sNote;// +";" + dd.sRote.Trim();
                            //    ra1.YYMM = JBHR.Dll.Att.SetYYMM(dd.dDateB.Date, "2", iSalaryDay, rEmpBase.sSaladr);
                            //    ra1.SERNO = sSerno;
                            //    odsAtt.ABS1.AddABS1Row(ra1);

                            //    taABS1.Update(odsAtt.ABS1);

                            //    JBHR.Dll.Bas.InsertLog("Abs1", 1, JBHR.Dll.Bas.SetRowValueToLog(ra1), sKeyMan);
                            //    bSave = true;
                            //}
                            //else
                            {
                                ra = odsAtt.ABS.NewABSRow();
                                Tools.SetRowDefaultValue(ra);
                                ra.NOBR = sNobr;
                                ra.BDATE = dd.dDateB.Date;
                                ra.EDATE = dd.dDateB.Date;
                                ra.BTIME = dd.sTimeB;
                                ra.ETIME = dd.sTimeE;
                                ra.H_CODE = sHcode;
                                ra.TOL_HOURS = iException > 0 ? iException : th;
                                ra.KEY_MAN = sKeyMan;
                                ra.YYMM = JBHR.Dll.Att.SetYYMM(dd.dDateB.Date, "2", iSalaryDay, rEmpBase.sSaladr);
                                ra.NOTE = sNote;// +";" + dd.sRote.Trim();
                                ra.SERNO = sSerno;
                                ra.A_NAME = sName;
                                odsAtt.ABS.AddABSRow(ra);

                                taABS.Update(odsAtt.ABS);

                                //dcAttDataContext dcAtt = new dcAttDataContext();
                                //var raa = new ABS();
                                //Tools.SetRowDefaultValue(raa);
                                //raa.NOBR = sNobr;
                                //raa.BDATE = dd.dDateB.Date;
                                //raa.EDATE = dd.dDateB.Date;
                                //raa.BTIME = dd.sTimeB;
                                //raa.ETIME = dd.sTimeE;
                                //raa.H_CODE = sHcode;
                                //raa.TOL_HOURS = iException > 0 ? iException : th;
                                //raa.KEY_MAN = sKeyMan;
                                //raa.YYMM = JBHR.Dll.Att.SetYYMM(dd.dDateB.Date, "2", iSalaryDay, rEmpBase.sSaladr);
                                //raa.NOTE = sNote;// +";" + dd.sRote.Trim();
                                //raa.SERNO = sSerno;
                                //raa.A_NAME = sName;
                                //dcAtt.ABS.InsertOnSubmit(raa);
                                //dcAtt.SubmitChanges();

                                JBHR.Dll.Bas.InsertLog("Abs", 1, JBHR.Dll.Bas.SetRowValueToLog(ra), sKeyMan);
                                bSave = true;
                            }
                        }
                    }
                }

                try
                {
                    dcAttDataContext dcAtt = new dcAttDataContext();
                    Dal.Dao.Att.TransCardDao target = new Dal.Dao.Att.TransCardDao(dcAtt.Connection);
                    target.TransCard(sNobr, sNobr, "0", "z", dDateB, dDateE, sKeyMan, true, true, true, "", "JB-TRANSCARD", true, 3);
                }
                catch (Exception ex)
                {
                    try
                    {
                        Tools.CreateTextFile("C:\\Error\\Abs" + DateTime.Now.ToFileTime().ToString() + ".txt", ex.ToString());
                    }
                    catch { }
                }

                return bSave;
            }

            /// <summary>
            /// 將請假資料存入HR.ABS實體資料表 True = 存入成功
            /// </summary>
            /// <param name="sNobr">請假人工號</param>
            /// <param name="sHcode">請假假別</param>
            /// <param name="dDateB">開始日期</param>
            /// <param name="dDateE">結束日期</param>
            /// <param name="sTimeB">開始時間</param>
            /// <param name="sTimeE">結束時間</param>
            /// <param name="sDeptCode">部門</param>
            /// <param name="sNote">原因</param>
            /// <param name="sKeyMan">申請者工號或姓名</param>
            /// <param name="sName">沖假對象</param>
            /// <param name="iException">例外時數</param>
            /// <returns>bool</returns>
            public static bool AbsSave(string sNobr, string sHcode, DateTime dDateB, DateTime dDateE, string sTimeB, string sTimeE, string sDeptCode, string sNote, string sKeyMan, string sName, decimal iException)
            {
                sTimeB = sTimeB.PadLeft(4, char.Parse("0"));
                sTimeE = sTimeE.PadLeft(4, char.Parse("0"));

                return AbsSave(sNobr, sHcode, dDateB, dDateE, sTimeB, sTimeE, sDeptCode, sNote, sKeyMan, sName, iException, "");
            }
        }

        /// <summary>
        /// 銷假所需
        /// </summary>
        public static class Absc
        {
            /// <summary>
            /// 帶出可銷假日期
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="sYYMM">計薪年月(5碼年月,如09809,預設可帶空白會帶「今天」)</param>
            /// <param name="sAdd">可銷假的假別代碼,例如：,A,B,C,</param>
            /// <returns>TextValueDataTable</returns>
            public static dsBas.TextValueDataTable AbscDate(string sNobr, string sYYMM, string sAdd)
            {
                var rEmp = JBHR.Dll.Bas.EmpBase(sNobr).FirstOrDefault();

                dsBas.TextValueDataTable dt = new dsBas.TextValueDataTable();
                DateTime dDate = DateTime.Now.Date;
                DateTime dDateB = new DateTime(dDate.Year, 1, 1).AddMonths(-1);
                DateTime dDateE = new DateTime(dDate.Year, 12, 31).AddMonths(1);
                dsAtt.JB_HR_AbsUnionDataTable dtAbs = Abs(sNobr, dDateB, dDateE, false);
                foreach (dsAtt.JB_HR_AbsUnionRow ra in dtAbs.Rows)
                {
                    var bLock = Bas.IsDataPassB(ra.dDateB.Date, rEmp.sSaladr) || Bas.IsDataPaB(ra.dDateB.Date, rEmp.sSaladr);

                    if (!bLock)
                    {
                        if (sAdd.Trim().Length == 0 || sAdd.Trim().IndexOf(ra.sHoliCode) >= 0)
                        {
                            if (ra.sTimeB.Trim().Length == 4 && ra.sTimeE.Trim().Length == 4)
                            {
                                dsBas.TextValueRow r = dt.NewTextValueRow();
                                r.sText = ra.dDateB.ToShortDateString();
                                r.sValue = r.sText;
                                dt.AddTextValueRow(r);
                            }
                        }
                    }
                }

                return dt;
            }

            /// <summary>
            /// 由日期所關聯的時間
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="sYYMM">計薪年月(5碼年月,如09809,預設可帶空白會帶「今天」)</param>
            /// <param name="dDate">銷假日期</param>
            /// <returns>TextValueDataTable</returns>
            public static dsBas.TextValueDataTable AbscTime(string sNobr, string sYYMM, DateTime? dDate)
            {
                dsBas.TextValueDataTable dt = new dsBas.TextValueDataTable();
                DateTime dDateB = new DateTime(dDate.Value.Year, 1, 1).AddMonths(-1);
                DateTime dDateE = new DateTime(dDate.Value.Year, 12, 31).AddMonths(1);
                dsAtt.JB_HR_AbsUnionDataTable dtAbs = Abs(sNobr, dDateB, dDateE, false);
                foreach (dsAtt.JB_HR_AbsUnionRow ra in dtAbs.Rows)
                {
                    if (dDate != null && ra.dDateB.Date == Convert.ToDateTime(dDate).Date)
                    {
                        dsBas.TextValueRow r = dt.NewTextValueRow();
                        r.sText = (Convert.ToInt32(ra.sTimeB) >= 2400 ? (Convert.ToInt32(ra.sTimeB) - 2400).ToString("0000") : ra.sTimeB) + "-" + (Convert.ToInt32(ra.sTimeE) >= 2400 ? (Convert.ToInt32(ra.sTimeE) - 2400).ToString("0000") : ra.sTimeE);
                        r.sValue = ra.sTimeB;
                        dt.AddTextValueRow(r);
                    }
                }

                return dt;
            }

            /// <summary>
            /// 由日期及時間所關聯出的假別
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="sYYMM">計薪年月(5碼年月,如09809,預設可帶空白會帶「今天」)</param>
            /// <param name="dDate">銷假日期</param>
            /// <param name="sTime">銷假時間</param>
            /// <returns>TextValueDataTable</returns>
            public static dsBas.TextValueDataTable AbscHcode(string sNobr, string sYYMM, DateTime? dDate, string sTime)
            {
                dsBas.TextValueDataTable dt = new dsBas.TextValueDataTable();
                DateTime dDateB = new DateTime(dDate.Value.Year, 1, 1).AddMonths(-1);
                DateTime dDateE = new DateTime(dDate.Value.Year, 12, 31).AddMonths(1);
                dsAtt.JB_HR_AbsUnionDataTable dtAbs = Abs(sNobr, dDateB, dDateE, false);
                var dtHcode = from a in dtAbs
                              where a.dDateB.Date == Convert.ToDateTime(dDate).Date
                              && a.sTimeB.Trim() == sTime
                              select a;

                var temp = dtHcode.FirstOrDefault();
                if (temp != null)
                {
                    dsBas.TextValueRow r = dt.NewTextValueRow();
                    r.sText = temp.sHoliName;
                    r.sValue = temp.sHoliCode;
                    dt.AddTextValueRow(r);
                }

                return dt;
            }

            /// <summary>
            /// 刪除請假資料
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDateB">開始日期</param>
            /// <param name="sTimeB">開始時間</param>
            /// <param name="sHcode">假別代碼</param>
            /// <param name="sKeyMan">登錄者</param>
            /// <returns>bool</returns>
            public static bool AbsDelete(string sNobr, DateTime dDateB, string sTimeB, string sHcode, string sKeyMan)
            {
                bool bDelete = false;
                dsAttTableAdapters.ABSTableAdapter taABS = new JBHR.Dll.dsAttTableAdapters.ABSTableAdapter();
                dsAttTableAdapters.ABS1TableAdapter taABS1 = new JBHR.Dll.dsAttTableAdapters.ABS1TableAdapter();
                dsAttTableAdapters.ABSCTableAdapter taABSC = new JBHR.Dll.dsAttTableAdapters.ABSCTableAdapter();

                //刪除之前先把值拿出來放到ABSC裡面
                DataRow[] rs = taABS.GetDataByKey(sNobr, dDateB.Date, sTimeB, sHcode).Select();
                if (rs.Length > 0)
                {
                    JBHR.Dll.dsAtt.ABSRow ra = rs[0] as JBHR.Dll.dsAtt.ABSRow;

                    JBHR.Dll.dsAtt.ABSCDataTable dt = new dsAtt.ABSCDataTable();
                    JBHR.Dll.dsAtt.ABSCRow rac = dt.NewABSCRow();
                    foreach (DataColumn dc in ra.Table.Columns)
                        if (rac.Table.Columns.Contains(dc.ToString()))
                            rac[dc.ToString()] = ra[dc.ToString()];

                    //rac.ItemArray = ra.ItemArray;
                    rac.KEY_DATE = DateTime.Now;
                    rac.KEY_MAN = sKeyMan;
                    //rac.SERNO = sSerno;
                    dt.AddABSCRow(rac);
                    taABSC.Update(rac);
                }

                bDelete = taABS.Delete(sNobr, dDateB, sTimeB, sHcode) > 0;
                bDelete = bDelete || taABS1.Delete(sNobr, dDateB, sTimeB) > 0;

                if (bDelete)
                {
                    JBHR.Dll.Bas.InsertLog("Absc", 3, sNobr + "," + dDateB.ToShortDateString() + "," + sTimeB + "," + sHcode, sKeyMan);

                    //刷卡轉出勤
                    try
                    {
                        dcAttDataContext dcAtt = new dcAttDataContext();
                        Dal.Dao.Att.TransCardDao target = new Dal.Dao.Att.TransCardDao(dcAtt.Connection);
                        target.TransCard(sNobr, sNobr, "0", "z", dDateB, dDateB, sKeyMan, true, true, true, "", "JB-TRANSCARD", true, 3);
                        //TransCard(sNobr, sNobr, "", "", dDate.AddDays(-1), dDate, sKeyMan, true, true, true);

                        TransCard(sNobr, sNobr, "", "", dDateB.AddDays(-1), dDateB, sKeyMan, true, true, true);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Tools.CreateTextFile("C:\\Error\\Absc" + DateTime.Now.ToFileTime().ToString() + ".txt", ex.ToString());
                        }
                        catch { }
                    }
                }

                return bDelete;
            }
        }

        /// <summary>
        /// 刷卡相關
        /// </summary>
        public static class CardCal
        {
            /// <summary>
            /// 新增刷卡資料
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDate">刷卡日期</param>
            /// <param name="sTime">刷卡時間</param>
            /// <param name="sReason">忘刷原因代碼</param>
            /// <param name="sKeyMan">登錄者</param>
            /// <param name="sNote">備註</param>
            ///  <param name="sSerno">單號</param>
            /// <returns>bool</returns>
            public static bool CardSave(string sNobr, DateTime dDate, string sTime, string sReason, string sKeyMan, string sNote, string sSerno)
            {
                bool bCardSave = false;
                bCardSave = CardCheck.IsRepeatTime(sNobr, dDate.Date, sTime.Trim());
                if (!bCardSave)
                {
                    //取得卡號
                    dsBas.JB_HR_CardAppDataTable dtCardApp = Bas.CardApp(sNobr);
                    string sCardNo = dtCardApp.Rows.Count > 0 ? (dtCardApp.Rows[0] as dsBas.JB_HR_CardAppRow).sCardNo : "";

                    dsAttTableAdapters.CARDTableAdapter taCARD = new JBHR.Dll.dsAttTableAdapters.CARDTableAdapter();
                    dsAtt.CARDDataTable dtCARD = new dsAtt.CARDDataTable();
                    dsAtt.CARDRow r = dtCARD.NewCARDRow();
                    Tools.SetRowDefaultValue(r);
                    r.CODE = "1";
                    r.NOBR = sNobr.Trim();
                    r.ADATE = dDate.Date;
                    r.ONTIME = sTime.Trim();
                    r.CARDNO = sNobr.Trim();// sCardNo;
                    r.REASON = sReason.Trim();
                    r.LOS = true;   //是忘刷了
                    r.KEY_MAN = sKeyMan;
                    r.SERNO = sSerno;
                    r.MENO = sNote;
                    dtCARD.AddCARDRow(r);
                    taCARD.Update(dtCARD);

                    dcAttDataContext dcAtt = new dcAttDataContext();
                    Dal.Dao.Att.TransCardDao target = new Dal.Dao.Att.TransCardDao(dcAtt.Connection);

                    //刷卡轉出勤
                    try
                    {
                        target.TransCard(sNobr, sNobr, "0", "z", dDate.AddDays(-1), dDate, sKeyMan, true, true, true, "", "JB-TRANSCARD", true,1);
                        //TransCard(sNobr, sNobr, "", "", dDate.AddDays(-1), dDate, sKeyMan, true, true, true);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Tools.CreateTextFile("C:\\Error\\Card" + DateTime.Now.ToFileTime().ToString() + ".txt", dcAtt.Connection.ConnectionString + "\n" + ex.ToString());
                        }
                        catch { }
                    }

                    bCardSave = true;
                }

                return bCardSave;
            }

            /// <summary>
            /// 新增刷卡資料
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDate">刷卡日期</param>
            /// <param name="sTime">刷卡時間</param>
            /// <param name="sReason">忘刷原因代碼</param>
            /// <param name="sKeyMan">登錄者</param>
            /// <returns>bool</returns>
            public static bool CardSave(string sNobr, DateTime dDate, string sTime, string sReason, string sKeyMan)
            {
                return CardSave(sNobr, dDate, sTime, sReason, sKeyMan, "", "");
            }
        }

        /// <summary>
        /// 加班相關計算
        /// </summary>
        public static class OtCal
        {
            public class OtDetail
            {
                public decimal iHour;   //時數
                public decimal iMinute;  //分鐘數
                public decimal iResHour; //休息時數
                public decimal iResMinute;   //休息分鐘數
                public decimal iTotalHour;
                public decimal iTotalMinute;
                public string sRote;
                public DayRes[] dDayRes;
                public bool bAllDay;
                public bool bDifferenceRote;    //不同班別
                public bool bTimeError;     //申請時間不在班別的時間裡

                /// <summary>
                /// 建構子
                /// </summary>
                public OtDetail()
                {
                    iHour = 0;
                    iMinute = 0;
                    iResHour = 0;
                    iResMinute = 0;
                    iTotalHour = 0;
                    iTotalMinute = 0;
                    sRote = "";
                    bAllDay = false;
                    bDifferenceRote = false;
                    bTimeError = false;
                }

                /// <summary>
                /// 休息時間
                /// </summary>
                public class DayRes
                {
                    public DateTime dDateB; //開始休息日期
                    public DateTime dDateE;  //結束休息日期
                    public decimal iHours;   //休息總時數
                    public decimal iMinute; //休息總分鐘數
                    public bool bHave;  //此時段是否有在加班時間裡面

                    /// <summary>
                    /// 建構子
                    /// </summary>
                    public DayRes()
                    {
                        dDateB = DateTime.Now.Date;
                        dDateE = DateTime.Now.Date;
                        iHours = 0;
                        iMinute = 0;
                        bHave = false;
                    }
                }
            }

            /// <summary>
            /// 設定休息時間
            /// </summary>
            /// <param name="dDayRes">目前已加入休息時間(Array)</param>
            /// <param name="dDateTimeB">加班開始日期時間</param>
            /// <param name="dDateTimeE">加班結束日期時間</param>
            /// <param name="dDate">加班日期(未組合的日期)</param>
            /// <param name="sTimeB">休息開始時間</param>
            /// <param name="sTimeE">休息結束時間</param>
            /// <returns>OtDetail.DayRes</returns>
            private static OtDetail.DayRes SetDayRes(OtDetail.DayRes[] dDayRes, DateTime dDateTimeB, DateTime dDateTimeE, DateTime dDate, string sTimeB, string sTimeE)
            {
                sTimeB = sTimeB.Trim();
                sTimeE = sTimeE.Trim();
                OtDetail.DayRes oDayRes = new OtDetail.DayRes();

                if ((sTimeB.Length > 0) && (sTimeE.Length > 0))
                {
                    oDayRes.dDateB = dDate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeB));
                    oDayRes.dDateE = dDate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeE));
                    TimeSpan ts = oDayRes.dDateE - oDayRes.dDateB;
                    oDayRes.iHours = Convert.ToDecimal(ts.TotalHours);
                    oDayRes.iMinute = Convert.ToDecimal(ts.TotalMinutes);
                    oDayRes.bHave = (IsWorkTime(dDayRes, oDayRes)) && (oDayRes.iMinute > 0) && ((dDateTimeB < oDayRes.dDateE) && (dDateTimeE > oDayRes.dDateB));
                }

                return oDayRes;
            }

            /// <summary>
            /// 判斷陣列裡的時間是否與現在要加入的時間重複
            /// </summary>
            /// <param name="dDayRes">目前已加入休息時間(Array)</param>
            /// <param name="oDayRes">要被判斷的時間</param>
            /// <returns>bool</returns>
            private static bool IsWorkTime(OtDetail.DayRes[] dDayRes, OtDetail.DayRes oDayRes)
            {
                foreach (OtDetail.DayRes dr in dDayRes)
                    if ((dr != null) && (dr.dDateB < oDayRes.dDateE) && (dr.dDateE > oDayRes.dDateB))
                        return false;

                return true;
            }

            /// <summary>
            /// 取得班別
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDate">出勤日期</param>
            /// <param name="sRote">目前班別</param>
            /// <param name="bDayAdd">加日期或減日期 True = 加日期(向前或向後尋找之意)</param>
            /// <returns>string</returns>
            private static string GetRote(string sNobr, DateTime dDate, string sRote, bool bDayAdd)
            {
                if (sRote != "00") return sRote;

                dsAtt.JB_HR_RoteDataTable dtRote;
                dsAtt.JB_HR_RoteRow r;

                do
                {
                    dDate = dDate.AddDays((bDayAdd) ? 1 : -1);
                    dtRote = Rote(sNobr, dDate);
                    if (dtRote.Count == 0) return sRote;
                    r = dtRote.Rows[0] as dsAtt.JB_HR_RoteRow;
                    sRote = r.sRoteCode.Trim();
                } while (sRote == "00");

                return sRote;
            }

            /// <summary>
            /// 計算間隔時間
            /// </summary>
            /// <param name="iUnit">間隔時數</param>
            /// <param name="iHour">加班時數</param>
            /// <returns>decimal</returns>
            private static decimal CalOtUint(double iUnit, double iHour)
            {
                double i = 0;
                //間隔單位一定要大於零而且請假時間也要大於零
                while ((iUnit > 0) && (iHour > 0) && (i <= (iHour - iUnit)))
                    i += iUnit;

                return Convert.ToDecimal(i);
            }

            /// <summary>
            /// 計算加班時間(24小時制)
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="sRote">班別(預設代0,特殊日期如天災請帶00)</param>
            /// <param name="dDateB">申請開始日期</param>
            /// <param name="dDateE">申請結束日期</param>
            /// <param name="sTimeB">申請開始時間</param>
            /// <param name="sTimeE">申請結束時間</param>
            /// <returns>OtDetail</returns>
            public static OtDetail CalculationOtBy24(string sNobr, string sRote, DateTime dDateB, DateTime dDateE, string sTimeB, string sTimeE)
            {
                sTimeB = sTimeB.PadLeft(4, char.Parse("0"));
                sTimeE = sTimeE.PadLeft(4, char.Parse("0"));

                DateTime dDateTimeB, dDateTimeE;

                dDateTimeB = dDateB.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeB));
                dDateTimeE = dDateE.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeE));

                //if (dDateB.Date < dDateE.Date)
                //    sTimeE = (Convert.ToInt32(sTimeE) + 2400).ToString("0000");

                ////取得今天第一個刷卡時間，是否為離開時間
                //dsAtt.JB_HR_CardDataTable dtCard = JBHR.Dll.Att.Card(sNobr, dDateB.Date);
                //if (dtCard.Count > 0)
                //{
                //    var lsCard = dtCard.OrderBy(p => p.sOnTime).ToList();
                //    if (lsCard[0].sCode.Trim() == "離開")
                //    {
                //        //找到大夜班的話，就日期減一天，時間加24小時
                //        string sR = GetRote(sNobr, dDateB.Date, "00", false); //再向前找班別
                //        var rRote = JBHR.Dll.Att.Rote(sR).FirstOrDefault();
                //        if (rRote != null && Convert.ToInt32(rRote.sOffTime) > 2400)
                //        //if ("3,B,I,J".Contains(sR))
                //        {
                //            dDateB = dDateB.AddDays(-1).Date;
                //            sTimeB = (Convert.ToInt32(sTimeB) + 2400).ToString("0000");
                //            sTimeE = (Convert.ToInt32(sTimeE) + 2400).ToString("0000");
                //        }
                //    }
                //}

                List<AttendRote> lsAttendRote = new List<AttendRote>();
                lsAttendRote.Add(rowAttendRote(sNobr, dDateB.AddDays(-1)));
                lsAttendRote.Add(rowAttendRote(sNobr, dDateB));
                //lsAttendRote.Add(rowAttendRote(sNobr, dDateB.AddDays(1)));

                AttendRote rAttendRote = lsAttendRote.Where(p => p.dDateTimeB <= dDateTimeB && p.dDateTimeE >= dDateTimeE).FirstOrDefault();

                if (rAttendRote != null && rAttendRote.dDate.Date < dDateB.Date)
                {
                    dDateB = dDateB.AddDays(-1).Date;
                    sTimeB = (Convert.ToInt32(sTimeB) + 2400).ToString("0000");
                    sTimeE = (Convert.ToInt32(sTimeE) + 2400).ToString("0000");
                }
                else if (dDateB.Date < dDateE.Date)
                    sTimeE = (Convert.ToInt32(sTimeE) + 2400).ToString("0000");

                OtDetail oOtDetail = CalculationOt(sNobr, sRote, dDateB, sTimeB, sTimeE, false);
                return oOtDetail;
            }
            /// <summary>
            /// 計算加班時間
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="sRote">班別(預設代0,特殊日期如天災請帶00)</param>
            /// <param name="dDate">申請日期</param>
            /// <param name="sTimeB">申請開始時間</param>
            /// <param name="sTimeE">申請結束時間</param>
            /// <returns>OtDetail</returns>
            public static OtDetail CalculationOt(string sNobr, string sRote, DateTime dDate, string sTimeB, string sTimeE)
            {
                return CalculationOt(sNobr, sRote, dDate, sTimeB, sTimeE, false);
            }
            /// <summary>
            /// 計算加班時間
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="sRote">班別(預設代0,特殊日期如天災請帶00)</param>
            /// <param name="dDate">申請日期</param>
            /// <param name="sTimeB">申請開始時間</param>
            /// <param name="sTimeE">申請結束時間</param>
            /// <param name="bEat">是否用餐</param>
            /// <returns>OtDetail</returns>
            public static OtDetail CalculationOt(string sNobr, string sRote, DateTime dDate, string sTimeB, string sTimeE, bool bEat)
            {
                sTimeB = sTimeB.PadLeft(4, char.Parse("0"));
                sTimeE = sTimeE.PadLeft(4, char.Parse("0"));

                DateTime dDateTimeB, dDateTimeE, dDateTimeA, dDateTimeD;
                dDate = dDate.Date;
                dDateTimeB = dDate.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeB));
                dDateTimeE = dDate.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeE));

                var rb = JBHR.Dll.Bas.EmpBase(sNobr).FirstOrDefault();
                if (rb == null)
                    return null;

                var rd = JBHR.Dll.Bas.Dept(rb.sDeptCode).FirstOrDefault();
                if (rd == null)
                    return null;

                OtDetail oOtDetail = new OtDetail();
                oOtDetail.dDayRes = new OtDetail.DayRes[5]; //計算休息次數包含上班時間(最大次數)

                dsAtt.JB_HR_RoteRow rRote;

                //假日固定加10分鐘 20121207
                int iAddMin = 0;

                bool isHoliDay = false;
                rRote = Rote(sNobr, dDate).FirstOrDefault();
                if (rRote != null)
                {
                    isHoliDay = rRote.sRoteCode == "00";

                    //如遇天災日，可代00班使得此天以假日計算之 20100921 by ming
                    string sRoteCode = sRote == "00" ? "00" : rRote.sRoteCode; //實際班別

                    //不允許是00班
                    sRote = (sRote == "0" || sRote == "00" || sRote.Trim().Length == 0) ? rRote.sRoteCode : sRote;
                    sRote = GetRote(sNobr, dDate, sRote, false);    //先向後找班別
                    sRote = GetRote(sNobr, dDate, sRote, true); //再向前找班別

                    oOtDetail.sRote = sRote;

                    oOtDetail.bDifferenceRote = !(sRote == rRote.sRoteCode); //班別差異

                    rRote = Rote(sRote).FirstOrDefault();
                    if (rRote != null)
                    {
                        dDateTimeA = dDate.AddMinutes(Tools.ConvertHhMmToMinutes(rRote.sOnTime));
                        dDateTimeD = dDate.AddMinutes(Tools.ConvertHhMmToMinutes(rRote.sOffTime));

                        //時間錯誤(不在班別時間裡面)
                        oOtDetail.bTimeError = !(Convert.ToInt32(rRote.sOnTime) <= Convert.ToInt32(sTimeE) && Convert.ToInt32(rRote.sOffTime) >= Convert.ToInt32(sTimeB));

                        int j = 0;
                        oOtDetail.dDayRes[j] = (sRoteCode != "00") ? SetDayRes(oOtDetail.dDayRes, dDateTimeB, dDateTimeE, dDate, rRote.sOnTime, rRote.sOffTime) : null;
                        //不參考用餐時間也不參考休息時間
                        if (!bEat)
                        {
                            if (!rd.bRes || sRoteCode == "00")   //部門有勾的話不參考休息時間，假日一定要參考
                            {
                                j++; oOtDetail.dDayRes[j] = SetDayRes(oOtDetail.dDayRes, dDateTimeB, dDateTimeE, dDate, rRote.sResB1Time, rRote.sResE1Time);
                                j++; oOtDetail.dDayRes[j] = SetDayRes(oOtDetail.dDayRes, dDateTimeB, dDateTimeE, dDate, rRote.sResB2Time, rRote.sResE2Time);
                                j++; oOtDetail.dDayRes[j] = SetDayRes(oOtDetail.dDayRes, dDateTimeB, dDateTimeE, dDate, rRote.sResB3Time, rRote.sResE3Time);
                                j++; oOtDetail.dDayRes[j] = SetDayRes(oOtDetail.dDayRes, dDateTimeB, dDateTimeE, dDate, rRote.sResB4Time, rRote.sResE4Time);
                            }
                        }

                        oOtDetail.bAllDay = (dDateTimeB == dDate.AddMinutes(Tools.ConvertHhMmToMinutes(rRote.sOnTime))) && (dDateTimeE == dDate.AddMinutes(Tools.ConvertHhMmToMinutes(rRote.sOffTime)));
                    }
                }

                //計算休息時間
                TimeSpan ts;
                foreach (OtDetail.DayRes dr in oOtDetail.dDayRes)
                {
                    if ((dr != null) && (dr.bHave) && (dr.iHours > 0))
                    {
                        dr.dDateB = ((dDateTimeB <= dr.dDateB) && (dDateTimeE >= dr.dDateB)) ? dr.dDateB : dDateTimeB;
                        dr.dDateE = ((dDateTimeB <= dr.dDateE) && (dDateTimeE >= dr.dDateE)) ? dr.dDateE : dDateTimeE;

                        ts = dr.dDateE - dr.dDateB;
                        dr.iHours = Convert.ToDecimal(ts.TotalHours);
                        dr.iMinute = Convert.ToDecimal(ts.TotalMinutes);
                        oOtDetail.iResHour += dr.iHours;
                        oOtDetail.iResMinute += dr.iMinute;
                    }
                }

                ts = dDateTimeE - dDateTimeB;

                oOtDetail.iTotalMinute = Convert.ToDecimal(ts.TotalMinutes) + iAddMin;
                oOtDetail.iTotalHour = Convert.ToDecimal(ts.TotalHours);
                int iMin = Convert.ToInt32((oOtDetail.iTotalMinute - oOtDetail.iResMinute) % 30);
                oOtDetail.iMinute = ((oOtDetail.iTotalMinute - oOtDetail.iResMinute) - iMin);
                oOtDetail.iHour = oOtDetail.iMinute / 60;

                oOtDetail.iMinute = oOtDetail.iMinute >= 30 ? oOtDetail.iMinute : 0;
                oOtDetail.iHour = Convert.ToDouble(oOtDetail.iHour) >= 0.5 ? oOtDetail.iHour : 0;

                return oOtDetail;
            }

            /// <summary>
            /// 判斷加班班別
            /// </summary>
            /// <param name="sTimeB">加起開始時間</param>
            /// <param name="bNightamt">是否輪班 True = 是</param>
            /// <returns>string</returns>
            //public static string OtRote(string sTimeB, bool bNightamt)
            //{
            //    string sRote = "";

            //    //夜班津貼
            //    var dtRoteWhere = Att.Rote("").Where(p => bNightamt ? p.iNightamt > 0 : p.iNightamt == 0)
            //        .Where(p => Convert.ToInt32(p.sOnTime) <= Convert.ToInt32(sTimeB) && Convert.ToInt32(p.sOffTime) > Convert.ToInt32(sTimeB));

            //    if (dtRoteWhere.Count() == 1)
            //        sRote = dtRoteWhere.First().sRoteCode;

            //    return sRote;
            //}

            /// <summary>
            /// 判斷加班班別
            /// </summary>
            /// <param name="sTimeB">加起開始時間</param>
            /// <param name="bNightamt">是否輪班 True = 是</param>
            /// <returns>dsAtt.JB_HR_RoteDataTable</returns>
            public static dsAtt.JB_HR_RoteDataTable OtRote(string sTimeB, bool bNightamt)
            {
                var dtRoteWhere = Att.Rote("").Where(p => Convert.ToInt32(p.sOnTime) <= Convert.ToInt32(sTimeB) && Convert.ToInt32(p.sOffTime) > Convert.ToInt32(sTimeB));

                dsAtt.JB_HR_RoteDataTable dt = new dsAtt.JB_HR_RoteDataTable();
                foreach (var r in dtRoteWhere)
                    dt.ImportRow(r);

                return dt;
            }

            /// <summary>
            ///  將加班資料存入HR.ABS實體資料表 True = 存入成功(24小時制)
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="sRote">班別(預設帶0)</param>
            /// <param name="dDateB">申請開始日期</param>
            /// <param name="dDateE">申請結束日期</param>
            /// <param name="sTimeB">加班開始時間</param>
            /// <param name="sTimeE">加班結束時間</param>
            /// <param name="sOtcatCode">加班別(1=加班費,2=補休假)</param>
            /// <param name="sOtrcdCode">加班原因代碼</param>
            /// <param name="sDeptCode">加班部門(預設帶0)</param>
            /// <param name="iEat">用餐費用</param>
            /// <param name="sNote">加班理由</param>
            /// <param name="sKeyMan">登錄者</param>
            /// <param name="iException">例外時數</param>
            /// <param name="sSerno">單號</param>
            /// <returns>bool</returns>
            public static bool OtSaveBy24(string sNobr, string sRote, DateTime dDateB, DateTime dDateE, string sTimeB, string sTimeE, string sOtcatCode, string sOtrcdCode, string sDeptCode, int iEat, string sNote, string sKeyMan, decimal iException, string sSerno)
            {
                sTimeB = sTimeB.PadLeft(4, char.Parse("0"));
                sTimeE = sTimeE.PadLeft(4, char.Parse("0"));

                DateTime dDateTimeB, dDateTimeE;

                dDateTimeB = dDateB.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeB));
                dDateTimeE = dDateE.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeE));

                bool bOtSave = false;
                //if (dDateB.Date < dDateE.Date)
                //    sTimeE = (Convert.ToInt32(sTimeE) + 2400).ToString("0000");

                ////取得今天第一個刷卡時間，是否為離開時間
                //dsAtt.JB_HR_CardDataTable dtCard = JBHR.Dll.Att.Card(sNobr, dDateB.Date);
                //if (dtCard.Count > 0)
                //{
                //    var lsCard = dtCard.OrderBy(p => p.sOnTime).ToList();
                //    if (lsCard[0].sCode.Trim() == "離開")
                //    {
                //        //找到大夜班的話，就日期減一天，時間加24小時
                //        string sR = GetRote(sNobr, dDateB.Date, "00", false); //再向前找班別
                //        var rRote = JBHR.Dll.Att.Rote(sR).FirstOrDefault();
                //        if (rRote != null && Convert.ToInt32(rRote.sOffTime) > 2400)
                //        //if ("3,B,I,J".Contains(sR))
                //        {
                //            dDateB = dDateB.AddDays(-1).Date;
                //            sTimeB = (Convert.ToInt32(sTimeB) + 2400).ToString("0000");
                //            sTimeE = (Convert.ToInt32(sTimeE) + 2400).ToString("0000");
                //        }
                //    }
                //}

                List<AttendRote> lsAttendRote = new List<AttendRote>();
                lsAttendRote.Add(rowAttendRote(sNobr, dDateB.AddDays(-1)));
                lsAttendRote.Add(rowAttendRote(sNobr, dDateB));
                //lsAttendRote.Add(rowAttendRote(sNobr, dDateB.AddDays(1)));

                AttendRote rAttendRote = lsAttendRote.Where(p => p.dDateTimeB <= dDateTimeB && p.dDateTimeE >= dDateTimeE).FirstOrDefault();

                if (rAttendRote != null && rAttendRote.dDate.Date < dDateB.Date)
                {
                    dDateB = dDateB.AddDays(-1).Date;
                    sTimeB = (Convert.ToInt32(sTimeB) + 2400).ToString("0000");
                    sTimeE = (Convert.ToInt32(sTimeE) + 2400).ToString("0000");
                }
                else if (dDateB.Date < dDateE.Date)
                    sTimeE = (Convert.ToInt32(sTimeE) + 2400).ToString("0000");

                bOtSave = OtSave(sNobr, sRote, dDateB, sTimeB, sTimeE, sOtcatCode, sOtrcdCode, sDeptCode, iEat, sNote, sKeyMan, iException, sSerno, false);
                return bOtSave;
            }

            /// <summary>
            ///  將加班資料存入HR.ABS實體資料表 True = 存入成功(24小時制)
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="sRote">班別(預設代0,特殊日期如天災請帶00)</param>
            /// <param name="dDateB">申請開始日期</param>
            /// <param name="dDateE">申請結束日期</param>
            /// <param name="sTimeB">加班開始時間</param>
            /// <param name="sTimeE">加班結束時間</param>
            /// <param name="sOtcatCode">加班別(1=加班費,2=補休假)</param>
            /// <param name="sOtrcdCode">加班原因代碼</param>
            /// <param name="sDeptCode">加班部門(預設帶0)</param>
            /// <param name="iEat">用餐費用</param>
            /// <param name="sNote">加班理由</param>
            /// <param name="sKeyMan">登錄者</param>
            /// <param name="iException">例外時數</param>
            /// <returns>bool</returns>
            public static bool OtSaveBy24(string sNobr, string sRote, DateTime dDateB, DateTime dDateE, string sTimeB, string sTimeE, string sOtcatCode, string sOtrcdCode, string sDeptCode, int iEat, string sNote, string sKeyMan, decimal iException)
            {
                return OtSaveBy24(sNobr, sRote, dDateB, dDateE, sTimeB, sTimeE, sOtcatCode, sOtrcdCode, sDeptCode, iEat, sNote, sKeyMan, iException, "");
            }

            /// <summary>
            ///  將加班資料存入HR.OT實體資料表 True = 存入成功
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="sRote">班別(預設代0,特殊日期如天災請帶00)</param>
            /// <param name="dDate">加班日期</param>
            /// <param name="sTimeB">加班開始時間</param>
            /// <param name="sTimeE">加班結束時間</param>
            /// <param name="sOtcatCode">加班別(1=加班費,2=補休假)</param>
            /// <param name="sOtrcdCode">加班原因代碼</param>
            /// <param name="sDeptCode">加班部門(預設帶0)</param>
            /// <param name="iEat">用餐費用</param>
            /// <param name="sNote">加班理由</param>
            /// <param name="sKeyMan">登錄者</param>
            /// <param name="iException">例外時數</param>
            /// <param name="sSerno">單號</param>
            /// <param name="bEat">是否用餐</param>
            /// <returns>bool</returns>
            public static bool OtSave(string sNobr, string sRote, DateTime dDate, string sTimeB, string sTimeE, string sOtcatCode, string sOtrcdCode, string sDeptCode, int iEat, string sNote, string sKeyMan, decimal iException, string sSerno, bool bEat)
            {
                sTimeB = sTimeB.PadLeft(4, char.Parse("0"));
                sTimeE = sTimeE.PadLeft(4, char.Parse("0"));

                bool bOtSave = false;

                dsAttTableAdapters.ABSTableAdapter taABS = new JBHR.Dll.dsAttTableAdapters.ABSTableAdapter();
                dsAttTableAdapters.OTTableAdapter taOT = new JBHR.Dll.dsAttTableAdapters.OTTableAdapter();
                dsAtt odsAtt = new dsAtt();

                dsBas.JB_HR_BaseRow rb = Bas.EmpBase(sNobr).FirstOrDefault();
                if (rb != null)
                {
                    DateTime dDateTimeB, dDateTimeE, dDateD;
                    dDate = dDate.Date;
                    dDateTimeB = dDate.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeB));
                    dDateTimeE = dDate.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeE));

                    //直接加2個月 間接加6個月 都到月底 但如果超過今年年底的話 就以今年年底為底
                    //int iMonth = rb.sDI == "D" ? 2 : 6;
                    //dDateD = dDate.AddMonths(iMonth);
                    //dDateD = new DateTime(dDateD.Year, dDateD.Month, DateTime.DaysInMonth(dDateD.Year, dDateD.Month)).Date;
                    //dDateD = dDateD > new DateTime(dDate.Year, 12, 31) || rb.sSaladr == "AA04TP" ? new DateTime(dDate.Year, 12, 31) : dDateD;
                    //生技的人員 直接到年底

                    dDateD = dDate.AddMonths(3);

                    JBHR.Dll.Att.OtCal.OtDetail oOtDetail = JBHR.Dll.Att.OtCal.CalculationOt(sNobr, sRote, dDate, sTimeB, sTimeE, bEat);

                    int iSalaryDay = 0;
                    var rEmpBase = JBHR.Dll.Bas.BaseTts(sNobr, dDate).FirstOrDefault();
                    if (rEmpBase != null)
                    {
                        var rDataGroup = JBHR.Dll.Bas.DataGroup().Where(p => p.sDataGroup == rEmpBase.sSaladr).FirstOrDefault();
                        if (rDataGroup != null)
                        {
                            iSalaryDay = SalaryDay(rDataGroup.sComp);
                        }
                    }

                    //新增加班資料
                    if (!OtCheck.IsRepeatData(sNobr, dDateTimeB, dDateTimeE))
                    {
                        dsAtt.OTRow ro = odsAtt.OT.NewOTRow();
                        Tools.SetRowDefaultValue(ro);
                        ro.NOBR = sNobr;
                        ro.BDATE = dDate;
                        ro.BTIME = sTimeB;
                        ro.ETIME = sTimeE;
                        ro.TOT_HOURS = (iException > 0) ? iException : Convert.ToDecimal(oOtDetail.iHour);
                        ro.OT_HRS = (sOtcatCode == "1") ? ro.TOT_HOURS : 0;
                        ro.REST_HRS = (sOtcatCode == "2") ? ro.TOT_HOURS : 0;
                        ro.OT_DEPT = sDeptCode.Trim().Length > 0 && sDeptCode.Trim() != "0" ? sDeptCode : rb.sDeptsCode;
                        ro.KEY_MAN = sKeyMan;
                        ro.NOTE = sNote;// +";" + oOtDetail.sRote;
                        ro.YYMM = Att.SetYYMM(dDate, "2", iSalaryDay, rEmpBase.sSaladr);
                        ro.OTRCD = sOtrcdCode;
                        ro.OT_EDATE = dDateD;
                        ro.OT_ROTE = sRote.Trim().Length > 0 && sRote.Trim() != "0" ? sRote : oOtDetail.sRote;  //班別
                        ro.NOFOOD1 = iEat > 0;
                        ro.OT_FOOD1 = iEat;
                        ro.SERNO = sSerno;
                        odsAtt.OT.AddOTRow(ro);
                        taOT.Update(ro);

                        Bas.InsertLog("Ot", 1, Bas.SetRowValueToLog(ro), sKeyMan);

                        try
                        {
                            Att.TransCard(sNobr, sNobr, "", "", dDate.AddDays(-1), dDate, sKeyMan, true, true, true);
                        }
                        catch { }
                    }

                    //新增請假資料
                    if (!AbsCheck.IsRepeatData(sNobr, dDateTimeB, dDateTimeE, true) && (sOtcatCode == "2"))
                    {
                        //JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM211", sNobr, dDateTimeB.Date);
                        //var CompseCode = AppConfig.GetConfig("ComposeLeaveGetCode").GetString();

                        dsAtt.ABSRow ra = odsAtt.ABS.NewABSRow();
                        Tools.SetRowDefaultValue(ra);
                        ra.NOBR = sNobr;
                        ra.BDATE = dDate;
                        ra.EDATE = dDateD;
                        ra.BTIME = sTimeB;
                        ra.ETIME = sTimeE;
                        ra.H_CODE = "W4";
                        ra.TOL_HOURS = (iException > 0) ? iException : Convert.ToDecimal(oOtDetail.iHour);
                        ra.KEY_MAN = sKeyMan;
                        ra.YYMM = Att.SetYYMM(dDate, "2", iSalaryDay, rEmpBase.sSaladr);
                        ra.NOTE = sNote;// +";" + oOtDetail.sRote;
                        ra.SERNO = sSerno;
                        ra.Balance = ra.TOL_HOURS;
                        ra.LeaveHours = 0;
                        ra.Guid = Guid.NewGuid().ToString();
                        odsAtt.ABS.AddABSRow(ra);
                        taABS.Update(ra);

                        Bas.InsertLog("OtAbs", 1, Bas.SetRowValueToLog(ra), sKeyMan);
                    }

                    dcAttDataContext dcAtt = new dcAttDataContext();
                    Dal.Dao.Att.TransCardDao target = new Dal.Dao.Att.TransCardDao(dcAtt.Connection);
                    target.TransCard(sNobr, sNobr, "0", "z", dDate, dDate, sKeyMan, true, true, true, "", "JB-TRANSCARD", true, 3);

                    bOtSave = true;
                }

                return bOtSave;
            }

            /// <summary>
            ///  將加班資料存入HR.OT1實體資料表 True = 存入成功
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="sRote">班別(預設代0,特殊日期如天災請帶00)</param>
            /// <param name="dDate">加班日期</param>
            /// <param name="sTimeB">加班開始時間</param>
            /// <param name="sTimeE">加班結束時間</param>
            /// <param name="sOtcatCode">加班別(1=加班費,2=補休假)</param>
            /// <param name="sOtrcdCode">加班原因代碼</param>
            /// <param name="sDeptCode">加班部門(預設帶0)</param>
            /// <param name="iEat">用餐費用</param>
            /// <param name="sNote">加班理由</param>
            /// <param name="sKeyMan">登錄者</param>
            /// <param name="iException">例外時數</param>
            /// <param name="sSerno">單號</param>
            /// <param name="bEat">是否用餐</param>
            /// <returns>bool</returns>
            public static bool Ot1Save(string sNobr, string sRote, DateTime dDate, string sTimeB, string sTimeE, string sOtcatCode, string sOtrcdCode, string sDeptCode, int iEat, string sNote, string sKeyMan, decimal iException, string sSerno, bool bEat)
            {
                sTimeB = sTimeB.PadLeft(4, char.Parse("0"));
                sTimeE = sTimeE.PadLeft(4, char.Parse("0"));

                bool bOtSave = false;

                dsAttTableAdapters.ABSTableAdapter taABS = new JBHR.Dll.dsAttTableAdapters.ABSTableAdapter();
                dsAttTableAdapters.OT1TableAdapter taOT = new JBHR.Dll.dsAttTableAdapters.OT1TableAdapter();
                dsAtt odsAtt = new dsAtt();

                dsBas.JB_HR_BaseRow rb = Bas.EmpBase(sNobr).FirstOrDefault();
                if (rb != null)
                {
                    DateTime dDateTimeB, dDateTimeE, dDateD;
                    dDate = dDate.Date;
                    dDateTimeB = dDate.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeB));
                    dDateTimeE = dDate.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeE));

                    //直接加2個月 間接加6個月 都到月底 但如果超過今年年底的話 就以今年年底為底
                    int iMonth = rb.sDI == "D" ? 2 : 6;
                    dDateD = dDate.AddMonths(iMonth);
                    dDateD = new DateTime(dDateD.Year, dDateD.Month, DateTime.DaysInMonth(dDateD.Year, dDateD.Month)).Date;
                    dDateD = dDateD > new DateTime(dDate.Year, 12, 31) || rb.sSaladr == "AA04TP" ? new DateTime(dDate.Year, 12, 31) : dDateD;
                    //生技的人員 直接到年底

                    JBHR.Dll.Att.OtCal.OtDetail oOtDetail = JBHR.Dll.Att.OtCal.CalculationOt(sNobr, sRote, dDate, sTimeB, sTimeE, bEat);

                    int iSalaryDay = 0;
                    var rEmpBase = JBHR.Dll.Bas.BaseTts(sNobr, dDate).FirstOrDefault();
                    if (rEmpBase != null)
                    {
                        var rDataGroup = JBHR.Dll.Bas.DataGroup().Where(p => p.sDataGroup == rEmpBase.sSaladr).FirstOrDefault();
                        if (rDataGroup != null)
                        {
                            iSalaryDay = SalaryDay(rDataGroup.sComp);
                        }
                    }

                    //新增加班資料
                    if (!OtCheck.IsRepeatData1(sNobr, dDateTimeB, dDateTimeE))
                    {
                        dsAtt.OT1Row ro = odsAtt.OT1.NewOT1Row();
                        Tools.SetRowDefaultValue(ro);
                        ro.NOBR = sNobr;
                        ro.BDATE = dDate;
                        ro.BTIME = sTimeB;
                        ro.ETIME = sTimeE;
                        ro.TOT_HOURS = (iException > 0) ? iException : Convert.ToDecimal(oOtDetail.iHour);
                        ro.OT_HRS = (sOtcatCode == "1") ? ro.TOT_HOURS : 0;
                        ro.REST_HRS = (sOtcatCode == "2") ? ro.TOT_HOURS : 0;
                        ro.OT_DEPT = sDeptCode.Trim().Length > 0 && sDeptCode.Trim() != "0" ? sDeptCode : rb.sDeptsCode;
                        ro.KEY_MAN = sKeyMan;
                        ro.NOTE = sNote;// +";" + oOtDetail.sRote;
                        ro.YYMM = Att.SetYYMM(dDate, "2", iSalaryDay, rEmpBase.sSaladr);
                        ro.OTRCD = sOtrcdCode;
                        ro.OT_EDATE = dDateD;
                        ro.OT_ROTE = sRote.Trim().Length > 0 && sRote.Trim() != "0" ? sRote : oOtDetail.sRote;  //班別
                        ro.NOFOOD1 = iEat > 0;
                        ro.OT_FOOD1 = iEat;
                        ro.SERNO = sSerno;
                        odsAtt.OT1.AddOT1Row(ro);
                        taOT.Update(ro);

                        Bas.InsertLog("Ot1", 1, Bas.SetRowValueToLog(ro), sKeyMan);
                    }

                    bOtSave = true;
                }

                return bOtSave;
            }

            /// <summary>
            ///  將加班資料存入HR.ABS實體資料表 True = 存入成功
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="sRote">班別(預設帶0)</param>
            /// <param name="dDate">加班日期</param>
            /// <param name="sTimeB">加班開始時間</param>
            /// <param name="sTimeE">加班結束時間</param>
            /// <param name="sOtcatCode">加班別(1=加班費,2=補休假)</param>
            /// <param name="sOtrcdCode">加班原因代碼</param>
            /// <param name="sDeptCode">加班部門(預設帶0)</param>
            /// <param name="iEat">用餐費用</param>
            /// <param name="sNote">加班理由</param>
            /// <param name="sKeyMan">登錄者</param>
            /// <param name="iException">例外時數</param>
            /// <returns>bool</returns>
            public static bool OtSave(string sNobr, string sRote, DateTime dDate, string sTimeB, string sTimeE, string sOtcatCode, string sOtrcdCode, string sDeptCode, int iEat, string sNote, string sKeyMan, decimal iException)
            {
                return OtSave(sNobr, sRote, dDate, sTimeB, sTimeE, sOtcatCode, sOtrcdCode, sDeptCode, iEat, sNote, sKeyMan, iException, "", false);
            }
        }

        /// <summary>
        /// 調班
        /// </summary>
        public static class ShiftRote
        {
            /// <summary>
            /// 將調班資料存入HR.TMTABLE實體資料表(單筆) True = 存入成功
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="sYYMM">年月</param>
            /// <param name="sDays">每日(D1到D31,字串必須按照規定格式，例D1=A,D2=B,D3=6,D4=9)</param>
            /// <param name="sKeyMan">登錄者</param>
            /// <returns>bool</returns>
            public static bool TmTableSave(string sNobr, string sYYMM, string sDays, string sKeyMan)
            {
                bool bTmTableSave = false;

                dsAttTableAdapters.TMTABLETableAdapter taTMTABLE = new JBHR.Dll.dsAttTableAdapters.TMTABLETableAdapter();
                dsAtt.TMTABLEDataTable dtTMTABLE = new dsAtt.TMTABLEDataTable();

                taTMTABLE.FillByKey(dtTMTABLE, sYYMM, sNobr);
                if (dtTMTABLE.Rows.Count > 0)
                {
                    dsAtt.TMTABLERow rt = dtTMTABLE.Rows[0] as dsAtt.TMTABLERow;
                    rt.KEY_MAN = sKeyMan;
                    rt.KEY_DATE = DateTime.Now;

                    //跑D1到D31的回圈
                    string[] arrDay, arrDays = sDays.Split(char.Parse(","));
                    foreach (string s in arrDays)
                    {
                        arrDay = s.Split(char.Parse("="));
                        if (arrDay.Length >= 2)
                            rt[arrDay[0].ToString()] = arrDay[1].ToString();
                    }

                    taTMTABLE.Update(rt);

                    Bas.InsertLog("TmTable", 1, Bas.SetRowValueToLog(rt), sKeyMan);

                    bTmTableSave = true;
                }


                return bTmTableSave;
            }

            /// <summary>
            /// 確定互調班別是否正確(False = 其中有一位員工被換班日期不是假日班)
            /// </summary>
            /// <param name="sNobrA">原班別工號</param>
            /// <param name="dDateA">原班別日期</param>
            /// <param name="sNobrB">調班後工號</param>
            /// <param name="dDateB">調班後日期</param>
            /// <returns>bool</returns>
            public static bool IsRoteHoliday(string sNobrA, DateTime dDateA, string sNobrB, DateTime dDateB)
            {
                bool bRoteHoliday = false;
                var a = Att.Attend(sNobrA, dDateB).FirstOrDefault();
                var b = Att.Attend(sNobrB, dDateA).FirstOrDefault();

                if (a != null && b != null)
                    bRoteHoliday = a.sRoteCode == "00" && b.sRoteCode == "00";

                return bRoteHoliday;
            }

            /// <summary>
            /// 將調班資料存入HR.ROTECHG實體資料表(單筆) True = 存入成功
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDate">調班日期</param>
            /// <param name="sRoteCode">調班班別</param>
            /// <param name="sNote">備註</param>
            /// <param name="sKeyMan">登錄者</param>
            /// <param name="sSerno">表單編號</param>
            /// <param name="bTransAtt">重新轉換班表</param>
            /// <returns>bool</returns>
            public static bool RotechgSave(string sNobr, DateTime dDate, string sRoteCode, string sNote, string sKeyMan, string sSerno, bool bTransAtt)
            {
                bool bRotechgSave = false;
                dsAttTableAdapters.ROTECHGTableAdapter taROTECHG = new JBHR.Dll.dsAttTableAdapters.ROTECHGTableAdapter();
                dsAtt odsAtt = new dsAtt();

                dsAtt.ROTECHGRow r;

                taROTECHG.FillByDate(odsAtt.ROTECHG, dDate.Date, sNobr);
                if (odsAtt.ROTECHG.Rows.Count == 0)
                {
                    r = odsAtt.ROTECHG.NewROTECHGRow();
                    Tools.SetRowDefaultValue(r);
                    r.NOBR = sNobr;
                    r.ADATE = dDate.Date;
                }
                else
                    r = odsAtt.ROTECHG.Rows[0] as dsAtt.ROTECHGRow;

                r.ROTE = sRoteCode;
                r.KEY_MAN = sKeyMan;
                r.KEY_DATE = DateTime.Now;

                if (odsAtt.ROTECHG.Rows.Count == 0)
                    odsAtt.ROTECHG.AddROTECHGRow(r);

                bRotechgSave = taROTECHG.Update(r) > 0;

                if (bRotechgSave && bTransAtt)
                    TransAtt.AttEnd(sNobr, dDate, sKeyMan);

                return bRotechgSave;
            }

            /// <summary>
            /// 將調班資料存入HR.ROTECHG實體資料表(互調) True = 存入成功
            /// </summary>
            /// <param name="sNobrA">原班別工號</param>
            /// <param name="dDateA">原班別日期</param>
            /// <param name="sNobrB">調班後工號</param>
            /// <param name="dDateB">調班後日期</param>
            /// <param name="sNote">備註</param>
            /// <param name="sKeyMan">登錄者</param>
            /// <param name="sSerno">表單編號</param>
            /// <param name="bTransAtt">重新轉換班表</param>
            /// <returns>bool</returns>
            public static bool RotechgSave(string sNobrA, DateTime dDateA, string sNobrB, DateTime dDateB, string sNote, string sKeyMan, string sSerno, bool bTransAtt)
            {
                bool bRotechgSave = false;

                var a = Att.Attend(sNobrA, dDateA).FirstOrDefault();
                var b = Att.Attend(sNobrA, dDateB).FirstOrDefault();
                var c = Att.Attend(sNobrB, dDateA).FirstOrDefault();
                var d = Att.Attend(sNobrB, dDateB).FirstOrDefault();

                if (sNobrA == sNobrB || dDateA.Date == dDateB.Date)   //如果調班是同一人或日期同一天
                {
                    RotechgSave(sNobrA, dDateA, d.sRoteCode, sNote, sKeyMan, sSerno, true);
                    RotechgSave(sNobrB, dDateB, a.sRoteCode, sNote, sKeyMan, sSerno, true);
                }
                else if (a != null && b != null && c != null && d != null)
                {
                    RotechgSave(sNobrA, dDateA, c.sRoteCode, sNote, sKeyMan, sSerno, true);
                    RotechgSave(sNobrA, dDateB, d.sRoteCode, sNote, sKeyMan, sSerno, true);
                    RotechgSave(sNobrB, dDateA, a.sRoteCode, sNote, sKeyMan, sSerno, true);
                    RotechgSave(sNobrB, dDateB, b.sRoteCode, sNote, sKeyMan, sSerno, true);

                    bRotechgSave = true;
                }

                return bRotechgSave;
            }

            /// <summary>
            /// 將調班資料存入HR.BASETTS實體資料表(長調) True = 存入成功
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDate">(異動)調班日期</param>
            /// <param name="sRotetCode">輪班序代碼</param>
            /// <param name="sHoliCode">行事曆代碼</param>
            /// <param name="sOtRateCode">加班別代碼</param>
            /// <param name="sNote">備註</param>
            /// <param name="sKeyMan">登錄者</param>
            /// <param name="sSerno">表單編號</param>
            /// <param name="bTransAtt">重新轉換班表</param>
            /// <returns>bool</returns>
            public static bool BaseTtsSave(string sNobr, DateTime dDate, string sRotetCode, string sHoliCode, string sOtRateCode, string sNote, string sKeyMan, string sSerno, bool bTransAtt)
            {
                bool bBaseTtsSave = false;

                dcBasDataContext dcBas = new dcBasDataContext();

                var lsA = (from c in dcBas.BASETTS
                           where c.NOBR.Trim() == sNobr.Trim()
                           select c).ToList();

                var rbA = lsA.Where(p => p.ADATE.Date <= dDate.Date && p.DDATE.Value >= dDate.Date).FirstOrDefault();

                if (rbA == null)
                    return bBaseTtsSave;

                var rTtscd = (from a in dcBas.JB_HR_Ttscd
                              where a.sCodeDisp == "C11"
                              && dcBas.GetCodeFilterByNobr("TTSCD", a.sCode, sNobr, dDate.Date).Value
                              select a).FirstOrDefault();

                string sTtscd = "";
                if (rTtscd != null)
                    sTtscd = rTtscd.sCode;

                if (rbA.ADATE.Date == dDate.Date)
                {
                    rbA.ROTET = sRotetCode;
                    rbA.HOLI_CODE = sHoliCode;
                    rbA.CALOT = sOtRateCode;
                    rbA.TTSCODE = "6";
                    rbA.TTSCD = sTtscd;
                    rbA.KEY_MAN = sKeyMan;
                    rbA.KEY_DATE = DateTime.Now;
                }
                else
                {
                    var rbB = rbA.Clone<BASETTS>();
                    rbB.ROTET = sRotetCode;
                    rbB.HOLI_CODE = sHoliCode;
                    rbB.CALOT = sOtRateCode;
                    rbB.ADATE = dDate.Date;
                    rbB.TTSCODE = "6";
                    rbB.TTSCD = sTtscd;
                    rbB.KEY_MAN = sKeyMan;
                    rbB.KEY_DATE = DateTime.Now;
                    lsA.Add(rbB);
                    dcBas.BASETTS.InsertOnSubmit(rbB);
                }

                var ls = lsA.OrderByDescending(p => p.ADATE.Date).ToList();

                DateTime dt = new DateTime(9999, 12, 31).Date;

                foreach (var r in ls)
                {
                    r.DDATE = dt;
                    dt = r.ADATE.Date.AddSeconds(-1);
                }

                //dcBas.BASETTS.InsertOnSubmit(rbB);
                dcBas.SubmitChanges();

                //執行班表重新產生
                if (bTransAtt)
                    TransAtt.TransAll(sNobr, dDate, sKeyMan);             

                Bas.InsertLog("BaseTts", 1, Bas.SetRowValueToLog(rbA), sKeyMan);

                bBaseTtsSave = true;
                return bBaseTtsSave;
            }
        }

        /// <summary>
        /// 當天的上班區間
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">出勤日期</param>
        /// <returns>AttendRote</returns>
        public static AttendRote rowAttendRote(string sNobr, DateTime dDate)
        {
            dDate = dDate.Date;

            AttendRote rAttendRote = new AttendRote();

            JBHR.Dll.dsAtt.JB_HR_RoteDataTable dtRote = Att.Rote("");
            JBHR.Dll.dsAtt.JB_HR_AttendDataTable dtAttend = Att.Attend(sNobr, sNobr, dDate, dDate);   //最主要的資料表，包含出勤資料

            string sTimeB, sTimeE;
            DateTime dDateTimeB, dDateTimeE;

            JBHR.Dll.dsAtt.JB_HR_AttendRow rAttend = dtAttend.Where(p => p.dAdate.Date == dDate).FirstOrDefault();
            if (rAttend != null)
            {
                JBHR.Dll.dsAtt.JB_HR_RoteRow rRote = dtRote.Where(p => p.sRoteCode.Trim() == rAttend.sRoteCode.Trim()).FirstOrDefault();
                if (rRote != null && rRote.sRoteCode != "00")
                {
                    sTimeE = rRote.sOffTime2.Trim();   //今天的最晚下班時間
                    JBHR.Dll.dsAtt.JB_HR_AttendRow rAttendOld = dtAttend.Where(p => p.sNobr.Trim() == rAttend.sNobr.Trim() && p.dAdate.Date == rAttend.dAdate.Date.AddDays(-1)).FirstOrDefault();
                    JBHR.Dll.dsAtt.JB_HR_RoteRow rRoteOffTime = rAttendOld != null ? dtRote.Where(p => p.sRoteCode.Trim() == rAttendOld.sRoteCode.Trim()).FirstOrDefault() : null;
                    //考慮昨天有可能是假日，所以不可以用昨天的最晚下班時間為今天的上班時間
                    sTimeB = rRoteOffTime != null && rRoteOffTime.sOffTime2.Trim().Length > 0 ? rRoteOffTime.sOffTime2.Trim() : sTimeE;

                    dDateTimeB = rAttend.dAdate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeB));  //因為是24小時制，所以要用今天的日期加上昨天的最晚下班時間
                    dDateTimeE = rAttend.dAdate.Date.AddDays(1).AddMinutes(Tools.ConvertHhMmToMinutes(sTimeE));    //因為是24小時制，所以要用明天的日期加上今天的最晚下班時間

                    rAttendRote.sNobr = sNobr;
                    rAttendRote.dDate = dDate;
                    rAttendRote.dDateB = dDateTimeB.Date;
                    rAttendRote.dDateE = dDateTimeE.Date;
                    rAttendRote.sTimeB = sTimeB;
                    rAttendRote.sTimeE = (Convert.ToInt32(sTimeE) + 2400).ToString("0000");
                    rAttendRote.dDateTimeB = dDateTimeB;
                    rAttendRote.dDateTimeE = dDateTimeE;
                    rAttendRote.sOffTime2 = rRote.sOffTime2.Trim();
                }
            }
            return rAttendRote;
        }

        /// <summary>
        /// 刷卡轉出勤
        /// </summary>
        /// <param name="sNobrB">開始工號</param>
        /// <param name="sNobrE">結束工號</param>
        /// <param name="sDeptB">開始部門</param>
        /// <param name="sDeptE">結束部門</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="sKeyMan">登錄者</param>
        /// <param name="bAttCard">轉換刷卡時間</param>
        /// <param name="bAttEnd">判斷異常</param>
        /// <param name="bEzAttCard">簡單轉換True = 簡單(一天多筆的情況，才需要複雜的判斷)，False 則會參考資料庫來判斷(Parts)</param>
        /// <returns>bool</returns>
        public static int TransCard(string sNobrB, string sNobrE, string sDeptB, string sDeptE, DateTime dDateB, DateTime dDateE, string sKeyMan, bool bAttCard, bool bAttEnd, bool bEzAttCard)
        {
            //JB-TRANSCARD 志興說這是最高權限的出口
            return TransCard(sNobrB, sNobrE, sDeptB, sDeptE, dDateB, dDateE, sKeyMan, bAttCard, bAttEnd, bEzAttCard, "", "JB-TRANSCARD", true, "0");
        }

        /// <summary>
        /// 刷卡轉出勤(HR系統專用)
        /// </summary>
        /// <param name="sNobrB">開始工號</param>
        /// <param name="sNobrE">結束工號</param>
        /// <param name="sDeptB">開始部門</param>
        /// <param name="sDeptE">結束部門</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="sKeyMan">登錄者</param>
        /// <param name="bAttCard">轉換刷卡時間</param>
        /// <param name="bAttEnd">判斷異常</param>
        /// <param name="bEzAttCard">簡單轉換True = 簡單(一天多筆的情況，才需要複雜的判斷)，False 則會參考資料庫來判斷(Parts)</param>
        /// <param name="sRoteCode">班別</param>
        /// <returns>bool</returns>
        public static int TransCard(string sNobrB, string sNobrE, string sDeptB, string sDeptE, DateTime dDateB, DateTime dDateE, string sKeyMan, bool bAttCard, bool bAttEnd, bool bEzAttCard, string sRoteCode)
        {
            //JB-TRANSCARD 志興說這是最高權限的出口
            return TransCard(sNobrB, sNobrE, sDeptB, sDeptE, dDateB, dDateE, sKeyMan, bAttCard, bAttEnd, bEzAttCard, "", "JB-TRANSCARD", true, sRoteCode);
        }

        /// <summary>
        /// 刷卡轉出勤
        /// </summary>
        /// <param name="sNobrB">開始工號</param>
        /// <param name="sNobrE">結束工號</param>
        /// <param name="sDeptB">開始部門</param>
        /// <param name="sDeptE">結束部門</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="sKeyMan">登錄者</param>
        /// <param name="bAttCard">轉換刷卡時間</param>
        /// <param name="bAttEnd">判斷異常</param>
        /// <param name="bEzAttCard">簡單轉換True = 簡單(一天多筆的情況，才需要複雜的判斷)，False 則會參考資料庫來判斷(Parts)</param>
        /// <param name="sUserID">登入者工號</param>
        /// <param name="sComp">公司別</param>
        /// <param name="bAdmin">是否管理權限</param>
        /// <param name="sRoteCode">班別</param>
        /// <returns>bool</returns>
        public static int TransCard(string sNobrB, string sNobrE, string sDeptB, string sDeptE, DateTime dDateB, DateTime dDateE, string sKeyMan, bool bAttCard, bool bAttEnd, bool bEzAttCard, string sUserID, string sComp, bool bAdmin, string sRoteCode)
        {
            int iTransCount = 0;

            //Card 24 小時制

            dcAttDataContext dcAtt = new dcAttDataContext();

            //所有資料預抓取前一天及後一天的區間

            JBHR.Dll.dsBas.JB_HR_BaseTtsDataTable dtBaseTts = Bas.BaseTts(sNobrB, sNobrE, dDateB.Date.AddDays(-1), dDateE.Date.AddDays(1), sUserID, sComp, bAdmin);   //需要取得某些設定檔，需要用日期來尋找，因為一個人有可能多筆
            JBHR.Dll.dsBas.JB_HR_DeptDataTable dtDept = Bas.Dept(DateTime.Now);
            JBHR.Dll.dsAtt.JB_HR_RoteDataTable dtRote = Att.Rote("");
            JBHR.Dll.dsAtt.JB_HR_AttendDataTable dtAttend = Att.Attend(sNobrB, sNobrE, dDateB.Date.AddDays(-1), dDateE.Date.AddDays(1), sUserID, sComp, bAdmin);   //最主要的資料表，包含出勤資料
            JBHR.Dll.dsAtt.JB_HR_AttCardDataTable dtAttCard = Att.AttCard(sNobrB, sNobrE, dDateB.Date.AddDays(-1), dDateE.Date.AddDays(1), sUserID, sComp, bAdmin);
            JBHR.Dll.dsAtt.JB_HR_CardDataTable dtCard = Att.Card(sNobrB, sNobrE, dDateB.Date.AddDays(-1), dDateE.Date.AddDays(1), sUserID, sComp, bAdmin);
            JBHR.Dll.dsAtt.JB_HR_AbsUnionDataTable dtAbs = Att.Abs(sNobrB, sNobrE, dDateB.Date.AddDays(-1), dDateE.Date.AddDays(1), "", sUserID, sComp, bAdmin);
            JBHR.Dll.dsAtt.JB_HR_OtDataTable dtOt = Att.Ot(sNobrB, sNobrE, dDateB.AddDays(-1), dDateE.AddDays(1), sUserID, sComp, bAdmin);

            var iqATTEND = (from c in dcAtt.ATTEND
                          
                            where c.NOBR.Trim().CompareTo(sNobrB) >= 0
                            && c.NOBR.Trim().CompareTo(sNobrE) <= 0
                            && c.ADATE.Date >= dDateB.Date
                            && c.ADATE.Date <= dDateE.Date
                            && dcAtt.GetFilterByNobr(c.NOBR.Trim(), sUserID, sComp, bAdmin).Value
                            select c).ToList();
            var iqATTCARD = (from a in dcAtt.ATTCARD
                             where a.NOBR.CompareTo(sNobrB) >= 0 && a.NOBR.CompareTo(sNobrE) <= 0
                             && a.ADATE.Date >= dDateB.Date && a.ADATE.Date <= dDateE.Date
                              && dcAtt.GetFilterByNobr(a.NOBR.Trim(), sUserID, sComp, bAdmin).Value
                             select a).ToList();

            sDeptB = sDeptB.Trim().Length > 0 ? sDeptB : dtDept.Min(p => p.sDeptCode);
            sDeptE = sDeptE.Trim().Length > 0 ? sDeptE : dtDept.Max(p => p.sDeptCode);

            string sTimeB, sTimeE;
            DateTime dDateTime, dDateTimeB, dDateTimeE;

            //每個人每一天的迴圈
            foreach (JBHR.Dll.dsAtt.JB_HR_AttendRow rAttend in dtAttend.Rows)
            {
                if (dDateB.Date <= rAttend.dAdate.Date && dDateE.Date >= rAttend.dAdate.Date)
                {
                    var dtBaseTtsWhere = dtBaseTts.Where(p => p.sNobr.Trim() == rAttend.sNobr.Trim() && p.sDeptCode.Trim().CompareTo(sDeptB.Trim()) >= 0 && p.sDeptCode.Trim().CompareTo(sDeptE.Trim()) <= 0 && rAttend.dAdate.Date >= p.dAdate && rAttend.dAdate.Date <= p.dDdate);
                    if (dtBaseTtsWhere.Any())
                    {
                        var rb = dtBaseTtsWhere.First();
                        string sRote = rAttend.sRoteCode.Trim();

                        //假日先以平日的班別置換
                        if (sRote == "00")
                        {
                            //先往前抓，如果前一天是00再往後抓
                            var rR = dtAttend.Where(p => p.sNobr == rAttend.sNobr && p.dAdate == rAttend.dAdate.Date.AddDays(-1)).FirstOrDefault();
                            if (rR == null || rR.sRoteCode == "00")
                            {
                                int i = 1;
                                do
                                {
                                    rR = dtAttend.Where(p => p.sNobr == rAttend.sNobr && p.dAdate == rAttend.dAdate.Date.AddDays(i)).FirstOrDefault();
                                    i++;
                                    if (rR != null)
                                        sRote = rR.sRoteCode;
                                } while (rR != null && rR.sRoteCode == "00");
                            }
                            else if (rR != null)
                                sRote = rR.sRoteCode;

                            //假日加班班別
                            var rOtWhere = dtOt.Where(p => p.sNobr.Trim() == rAttend.sNobr && p.dDateB.Date == rAttend.dAdate.Date).FirstOrDefault();
                            if (rOtWhere != null)
                                sRote = rOtWhere.sOtRote;
                        }

                        JBHR.Dll.dsAtt.JB_HR_RoteRow rRote = dtRote.Where(p => p.sRoteCode.Trim() == sRote.Trim()).FirstOrDefault();
                        if (rRote != null)
                        {
                            iTransCount++;

                            sTimeE = rRote.sOffTime2.Trim();   //今天的最晚下班時間
                            JBHR.Dll.dsAtt.JB_HR_AttendRow rAttendOld = dtAttend.Where(p => p.sNobr.Trim() == rAttend.sNobr.Trim() && p.dAdate.Date == rAttend.dAdate.Date.AddDays(-1)).FirstOrDefault();
                            JBHR.Dll.dsAtt.JB_HR_RoteRow rRoteOffTime = rAttendOld != null ? dtRote.Where(p => p.sRoteCode.Trim() == rAttendOld.sRoteCode.Trim()).FirstOrDefault() : null;
                            //考慮昨天有可能是假日，所以不可以用昨天的最晚下班時間為今天的上班時間
                            sTimeB = rRoteOffTime != null && rRoteOffTime.sOffTime2.Trim().Length > 0 ? rRoteOffTime.sOffTime2.Trim() : sTimeE;

                            dDateTimeB = rAttend.dAdate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeB));  //因為是24小時制，所以要用今天的日期加上昨天的最晚下班時間
                            dDateTimeE = rAttend.dAdate.Date.AddDays(1).AddMinutes(Tools.ConvertHhMmToMinutes(sTimeE));    //因為是24小時制，所以要用明天的日期加上今天的最晚下班時間

                            //填入該員工的刷卡資料，為防止例外情況，所以開始時間減1天，結束時間加1天
                            List<dsAtt.JB_HR_CardRow> lsCardWhere = dtCard.Where(p => p.sNobr.Trim().ToUpper() == rAttend.sNobr.Trim().ToUpper() && p.dAdate.Date >= rAttend.dAdate.Date.AddDays(-1) && p.dAdate.Date <= rAttend.dAdate.Date.AddDays(1) && !p.bNotTran).ToList();

                            //將資料填入暫存的Card的資料表裡，以利判斷
                            List<Card> lsCard = new List<Card>();
                            foreach (dsAtt.JB_HR_CardRow rc in lsCardWhere)
                            {
                                dDateTime = rc.dAdate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(rc.sOnTime.Trim()));

                                //判斷刷卡時間是否在最早與最晚的上下班時間裡
                                if ((dDateTimeB <= dDateTime) && (dDateTime <= dDateTimeE))
                                {
                                    var rCard = new Card();
                                    rCard.dAdate = rc.dAdate.Date;
                                    rCard.sOnTime = rc.sOnTime.Trim();
                                    rCard.dDateTime = rc.dAdate.Date.AddMinutes(Tools.ConvertHhMmToMinutes(rc.sOnTime.Trim()));
                                    rCard.bLos = rc.bLos && Reason(rc.sReasonCode.Trim()).FirstOrDefault() != null ? Reason(rc.sReasonCode.Trim()).FirstOrDefault().bAtt : false;     //是否忘刷(影響出勤)
                                    rCard.sCode = rc.sCode.Trim();
                                    lsCard.Add(rCard);
                                }
                            }

                            lsCard = lsCard.OrderBy(p => p.dAdate).ThenBy(p => p.sOnTime).ToList();

                            List<ATTCARD> lsAttcard = new List<ATTCARD>();

                            //寫入ATTCARD
                            if (bAttCard)
                            {
                                var lsATTCARD = from c in iqATTCARD
                                                where c.NOBR.Trim() == rAttend.sNobr.Trim()
                                                && c.ADATE.Date == rAttend.dAdate.Date
                                                select c;

                                lsAttcard = lsATTCARD.ToList();

                                //有打勾代表不再做任何修改
                                if (!lsATTCARD.Any() || (lsATTCARD.Any() && !lsATTCARD.ToList()[0].NOMODY))
                                {
                                    if (lsATTCARD.Any())
                                        dcAtt.ATTCARD.DeleteAllOnSubmit(lsATTCARD);

                                    if (rRote.sRoteCode != "00")
                                    {
                                        List<ATTCARD> ls = new List<ATTCARD>();

                                        //dcAtt.SubmitChanges();
                                        int j = bEzAttCard ? (lsCard.Count > 0 ? 1 : 0) : Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lsCard.Count) / 2));    //先除以2，再無條件進位

                                        int t, x1, x2;
                                        for (int i = 0; i < j; i++)
                                        {
                                            x1 = (i == 0) ? 0 : (i * 2);
                                            x2 = bEzAttCard ? (lsCard.Count - 1) : (x1 + 1);    //採用簡單判斷法，則取總筆數減1即可

                                            var rac = new ATTCARD();
                                            Tools.SetRowDefaultValue(rac);
                                            rac.NOBR = rAttend.sNobr.Trim();
                                            rac.ADATE = rAttend.dAdate.Date;
                                            rac.SER = 1;
                                            rac.KEY_MAN = sKeyMan;
                                            rac.KEY_DATE = Convert.ToDateTime(DateTime.Now.ToString());     //捨去毫秒的白痴寫法

                                            //T1的時間
                                            JBHR.Dll.Card rc = lsCard[x1];
                                            rac.T1 = rAttend.dAdate.Date < rc.dAdate.Date ? Convert.ToString(int.Parse(rc.sOnTime) + 2400) : rc.sOnTime;
                                            t = Tools.ConvertHhMmToMinutes(rac.T1);
                                            rac.TT1 = (t > 1440) ? Tools.SplitTimeToHhMm(DateTime.Now.Date.AddMinutes(t - 1440)) : rac.T1;   //有可能超過24小時，因此需要先轉換成24小時制
                                            rac.LOST1 = rc.bLos;

                                            //有(x2)以上的刷卡資料(T2的時間)
                                            if (lsCard.Count > x2 && lsCard.Count > 1)
                                            {
                                                rc = lsCard[x2];
                                                rac.T2 = rAttend.dAdate.Date < rc.dAdate.Date ? Convert.ToString(int.Parse(rc.sOnTime) + 2400) : rc.sOnTime;
                                                t = Tools.ConvertHhMmToMinutes(rac.T2);
                                                rac.TT2 = (t > 1440) ? Tools.SplitTimeToHhMm(DateTime.Now.Date.AddMinutes(t - 1440)) : rac.T2;   //有可能超過24小時，因此需要先轉換成24小時制 
                                                rac.LOST2 = rc.bLos;
                                            }

                                            ls.Add(rac);

                                            lsAttcard = ls;

                                            dcAtt.ATTCARD.InsertOnSubmit(rac);
                                        }
                                    }
                                }
                            }

                            //判斷出勤寫入ATTEND  //只有一種條件不用判斷
                            if (bAttEnd && rRote.sRoteCode != "00" && !(lsAttcard.Count > 0 && lsAttcard[0].NOMODY))
                            {
                                var ra = (from c in iqATTEND
                                          where c.NOBR.Trim() == rAttend.sNobr.Trim()
                                          && c.ADATE.Date == rAttend.dAdate.Date
                                          select c).FirstOrDefault();

                                if (ra != null)
                                {
                                    DateTime dDateTimeA, dDateTimeD;    //實際出勤上下班日期時間
                                    DateTime dDateTimeA1;   //加入可遲到分鐘數後
                                    DateTime dDateTimeA2, dDateTimeD2;  //加入彈性分鐘數後
                                    string sTimeA, sTimeD;  //實際上下班時間

                                    ra.LATE_MINS = 0;   //遲到分鐘數
                                    ra.E_MINS = 0;  //早退分鐘數
                                    ra.ABS = false; //是否有請假(true == 曠職)
                                    ra.FORGET = 0;

                                    sTimeA = rRote.sOnTime.Trim();   //實際上班時間
                                    sTimeD = rRote.sOffTime.Trim(); //實際下班時間
                                    dDateTimeA = ra.ADATE.Date.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeA));
                                    dDateTimeD = ra.ADATE.Date.AddMinutes(Tools.ConvertHhMmToMinutes(sTimeD));

                                    dDateTimeA1 = dDateTimeA.AddMinutes(Convert.ToDouble(rRote.iAlllates));    //先加入可遲到分鐘數
                                    dDateTimeA2 = dDateTimeA.AddMinutes(Convert.ToDouble(rRote.iAlllates1));   //再加入彈性分鐘數

                                    //忘刷次數小於等於1：比對請假資料
                                    //忘刷次數大於等於2：比對上下班時間
                                    //請假時間不正確再比對請假資料

                                    //當天假日的話，就不判斷異常
                                    if (rAttend.sRoteCode != "00" && rb.sCard == "Y")
                                    {
                                        List<Attend> lsAttend = new List<Attend>();

                                        if (lsAttcard.Any())
                                            ra.FORGET = lsAttcard.Where(p => p.LOST1).Count() + lsAttcard.Where(p => p.LOST2).Count();

                                        //先重新組合請假資料
                                        string[] arrYearRest = { "0", "2", "4", "6" };
                                        var lsAbsWhere = dtAbs.Where(p => p.sNobr.Trim() == rAttend.sNobr.Trim() && p.dDateB.Date == rAttend.dAdate.Date && arrYearRest.Contains(p.sYearRest.Trim()));  //當天請假資料

                                        //Type = 1 = 出勤
                                        //Type = 2 = 休息
                                        //Type = 3 = 請假

                                        //請假
                                        foreach (var rAbs in lsAbsWhere)
                                        {
                                            //開始與結束時間一定要有值
                                            if (rAbs.sTimeB.Trim().Length > 0 && rAbs.sTimeE.Trim().Length > 0)
                                            {
                                                var rAtt = new Attend();
                                                rAtt.dDateB = rAbs.dDateB;
                                                rAtt.dDateE = rAbs.dDateE;
                                                rAtt.sTimeB = rAbs.sTimeB.Trim();
                                                rAtt.sTimeE = rAbs.sTimeE.Trim();
                                                rAtt.dDateTimeB = rAtt.dDateB.AddMinutes(Tools.ConvertHhMmToMinutes(rAtt.sTimeB));
                                                rAtt.dDateTimeE = rAtt.dDateE.AddMinutes(Tools.ConvertHhMmToMinutes(rAtt.sTimeE));
                                                rAtt.iSort = 0;
                                                rAtt.sType = "3";
                                                lsAttend.Add(rAtt);
                                            }
                                        }

                                        //出勤
                                        foreach (var rAttcard in lsAttcard)
                                        {
                                            var rAtt = new Attend();
                                            rAtt.dDateB = rAttcard.ADATE.Date;
                                            rAtt.dDateE = rAttcard.ADATE.Date;
                                            rAtt.sTimeB = rAttcard.T1.Trim();
                                            rAtt.sTimeE = rAttcard.T2.Trim().Length == 4 ? rAttcard.T2.Trim() : rAtt.sTimeB;
                                            rAtt.dDateTimeB = rAtt.dDateB.AddMinutes(Tools.ConvertHhMmToMinutes(rAtt.sTimeB));
                                            rAtt.dDateTimeE = rAtt.dDateE.AddMinutes(Tools.ConvertHhMmToMinutes(rAtt.sTimeE));
                                            rAtt.iSort = 0;
                                            rAtt.sType = "1";
                                            lsAttend.Add(rAtt);
                                        }

                                        //製做一個休息時間區間的陣列
                                        Dictionary<string, string> dtRes = new Dictionary<string, string>();
                                        if (rRote.sResB1Time.Trim().Length == 4 && rRote.sResE1Time.Trim().Length == 4) dtRes.Add(rRote.sResB1Time.Trim(), rRote.sResE1Time.Trim());
                                        if (rRote.sResB2Time.Trim().Length == 4 && rRote.sResE2Time.Trim().Length == 4) dtRes.Add(rRote.sResB2Time.Trim(), rRote.sResE2Time.Trim());
                                        if (rRote.sResB3Time.Trim().Length == 4 && rRote.sResE3Time.Trim().Length == 4) dtRes.Add(rRote.sResB3Time.Trim(), rRote.sResE3Time.Trim());
                                        if (rRote.sResB4Time.Trim().Length == 4 && rRote.sResE4Time.Trim().Length == 4) dtRes.Add(rRote.sResB4Time.Trim(), rRote.sResE4Time.Trim());

                                        foreach (var rRes in dtRes)
                                        {
                                            //一定要有在出勤時間裡才需要被加進來
                                            if (rRote.sOnTime.Trim().CompareTo(rRes.Value) <= 0
                                            && rRote.sOffTime.Trim().CompareTo(rRes.Key) >= 0)
                                            {
                                                var rAtt = new Attend();
                                                rAtt.dDateB = rAttend.dAdate.Date;
                                                rAtt.dDateE = rAttend.dAdate.Date;
                                                rAtt.sTimeB = rRes.Key;
                                                rAtt.sTimeE = rRes.Value;
                                                rAtt.dDateTimeB = rAtt.dDateB.AddMinutes(Tools.ConvertHhMmToMinutes(rAtt.sTimeB));
                                                rAtt.dDateTimeE = rAtt.dDateE.AddMinutes(Tools.ConvertHhMmToMinutes(rAtt.sTimeE));
                                                rAtt.iSort = 0;
                                                rAtt.sType = "2";
                                                lsAttend.Add(rAtt);
                                            }
                                        }

                                        var tlAttend = lsAttend.OrderBy(p => p.dDateTimeB).ThenBy(p => p.sType).ToList();

                                        int iE_MINS = 0, iLATE_MINS = 0;    //早退、遲到

                                        //如果沒有出勤也沒有請假資料就是曠職
                                        if (tlAttend.Where(p => p.sType == "1" || p.sType == "3").Count() == 0)
                                            ra.ABS = true;
                                        else
                                        {
                                            //第一筆如果不是出勤資料，則應該是上午請假
                                            //反之如下
                                            //取得實際出勤的上下班時間(應加入彈性分鐘數)
                                            if (tlAttend[0].sType == "1")
                                            {
                                                dDateTimeA2 = (dDateTimeA <= tlAttend[0].dDateTimeB && tlAttend[0].dDateTimeB <= dDateTimeA2) ? tlAttend[0].dDateTimeB : dDateTimeA;
                                                dDateTimeD = dDateTimeD.AddMinutes((dDateTimeA2 - dDateTimeA).Minutes);
                                                dDateTimeA = dDateTimeA2;
                                            }

                                            DateTime dDateTimeX;
                                            dDateTimeX = dDateTimeA;

                                            TimeSpan ts;

                                            for (int z = 0; z <= tlAttend.Count - 1; z++)
                                            {
                                                var rAtt = tlAttend[z];

                                                rAtt.dDateTimeB = rAtt.dDateTimeB >= dDateTimeD ? dDateTimeD : rAtt.dDateTimeB;

                                                if (dDateTimeX < rAtt.dDateTimeB)
                                                {
                                                    ts = rAtt.dDateTimeB - dDateTimeX;
                                                    if (rAtt.sType != "3" || z == 0)  //正常出勤，第一次進來一定算遲到
                                                        if (rAtt.sType == "2" && z == 0)
                                                            iLATE_MINS += Convert.ToInt32(ts.TotalMinutes); //遲到       
                                                        else if (rAtt.sType == "2")
                                                            iE_MINS += Convert.ToInt32(ts.TotalMinutes);    //早退
                                                        else
                                                            iLATE_MINS += Convert.ToInt32(ts.TotalMinutes); //遲到       
                                                    else if (rAtt.sType == "3")
                                                        iE_MINS += Convert.ToInt32(ts.TotalMinutes);    //早退
                                                }

                                                dDateTimeX = dDateTimeX >= rAtt.dDateTimeE ? dDateTimeX : rAtt.dDateTimeE;

                                                //如果出勤資料的結束時間大於出勒應下班時間就直接結束
                                                if (dDateTimeD <= rAtt.dDateTimeE || z == tlAttend.Count - 1)
                                                {
                                                    //如果最後一次進來再比較一次算出早退分鐘數
                                                    if (dDateTimeX < dDateTimeD)
                                                    {
                                                        ts = dDateTimeD - dDateTimeX;
                                                        iE_MINS += Convert.ToInt32(ts.TotalMinutes);
                                                    }

                                                    break;
                                                }
                                            }
                                        }

                                        ra.E_MINS = iE_MINS;
                                        ra.LATE_MINS = iLATE_MINS;
                                    }

                                    ra.E_MINS = rb.bOnlyOnTime ? 0 : ra.E_MINS; //如果有勾只刷上班卡，那麼就不用判斷早退 by 20100324 瑤姐
                                    ra.FORGET = ra.FORGET >= 1 ? 1 : ra.FORGET;
                                    //不計算遲到跟早退 by 20100324 瑤姐
                                    if (rb.bNoTer)
                                    {
                                        ra.E_MINS = 0;
                                        ra.LATE_MINS = 0;
                                        ra.ABS = false;
                                        ra.FORGET = 0;
                                    }

                                    ra.KEY_MAN = sKeyMan;
                                    ra.KEY_DATE = Convert.ToDateTime(DateTime.Now.ToString());  //捨去毫秒
                                }   //end ra
                            }   //end 判斷出勤寫入attend
                        }   //end rote != null
                        //dcAtt.SubmitChanges();
                    }   //end basetts have data
                }   //end date 
            }   //foreach

            dcAtt.SubmitChanges();

            return iTransCount;
        }

        /// <summary>
        /// 刷卡轉出勤
        /// </summary>
        public static class TransAtt
        {
            /// <summary>
            /// 先轉員工個人單月班表再轉出勤
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDate">日期(會自動轉成月份)</param>
            /// <param name="sKeyMan">登錄者</param>
            /// <returns>bool</returns>
            public static bool TransAll(string sNobr, DateTime dDate, string sKeyMan)
            {
                bool bTransAtt = false;

                TmTable(sNobr, dDate, sKeyMan);
                AttEnd(sNobr, dDate, sKeyMan);

                bTransAtt = true;
                return bTransAtt;
            }

            /// <summary>
            /// 產生員工個人單月班表
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDate">日期(會自動轉成月份)</param>
            /// <param name="sKeyMan">登錄者</param>
            /// <returns>bool</returns>
            public static bool TmTable(string sNobr, DateTime dDate, string sKeyMan)
            {
                bool bTmTable = false;

                //將整個月的日期區間設定設定出來
                DateTime dDateB, dDateE, dDateA, dDateD;
                dDateB = Tools.DateOfStartOrEnd(dDate, true);
                dDateE = Tools.DateOfStartOrEnd(dDate, false);

                //取得本月跟上月的yymm
                string sYymmNow, sYymmOld;
                sYymmNow = Tools.DateToYyMm(dDate);
                sYymmOld = Tools.DateToYyMm(dDate.AddMonths(-1));

                var rTmTable = Att.TmTable(sYymmOld, sNobr).FirstOrDefault();

                string sInHoli; //假日輪班
                string sRote;   //班別代碼
                string sDay;    //每日代碼(欄位專用)
                int iNO;   //上個月輪班的最後一個班別
                Hashtable htRote; //班表暫存區R1-R10

                iNO = (rTmTable != null) ? Convert.ToInt32(rTmTable.iNo) : 1;

                dsAttTableAdapters.TMTABLETableAdapter taTMTABLE = new JBHR.Dll.dsAttTableAdapters.TMTABLETableAdapter();
                taTMTABLE.Delete(sYymmNow, sNobr);

                dsAtt odsAtt = new dsAtt();

                var rt = odsAtt.TMTABLE.NewTMTABLERow();
                Tools.SetRowDefaultValue(rt);
                rt.NOBR = sNobr;
                rt.YYMM = sYymmNow;

                var dtBaseTts = Bas.BaseTts(sNobr, dDateB, dDateE);

                if (dtBaseTts.Any())
                {
                    var tlBaseTts = dtBaseTts.OrderBy(p => p.dAdate).ToList();

                    //開始替每個人產生輪班資料，由於每個人於當月有可能會有異動
                    foreach (var rBaseTts in tlBaseTts)
                    {
                        var rRotet = Att.Rotet(rBaseTts.sRotet).FirstOrDefault();  //取得輪班序代碼

                        if (rRotet != null)
                        {
                            //先依照假日輪班來決定是否要參考行事曆(Holi)
                            sInHoli = rRotet.sInHoli;
                            htRote = new Hashtable();

                            //將輪班班別放入Hashtable(htRote)
                            for (int i = 1; i <= 10; i++)
                            {
                                sRote = "sR" + i.ToString(); //先將欄位名稱拼出來並檢查該欄位是否存在
                                if (rRotet.Table.Columns.Contains(sRote))
                                {
                                    sRote = Convert.ToString(rRotet[sRote]).Trim();
                                    //判斷值的字串是否大於零
                                    if (sRote.Length > 0)
                                        htRote.Add(i, sRote);
                                }
                            }

                            //由於一個月可能有一次以上的異動班別，因此需要一段區間來當做班別的產生
                            dDateA = (rBaseTts.dAdate.Date <= dDateB) ? dDateB : rBaseTts.dAdate.Date;
                            dDateD = (rBaseTts.dDdate.Date >= dDateE) ? dDateE : rBaseTts.dDdate.Date;

                            var dtHoli = Att.Holi(rBaseTts.sHoliCode, dDateA, dDateD);  //假日

                            for (DateTime i = dDateA; i <= dDateD; i = i.AddDays(1))
                            {
                                sDay = "D" + i.Day.ToString();  //每日欄位名稱

                                //行事曆
                                var rHoli = dtHoli.Where(p => p.dDate == i.Date).FirstOrDefault();
                                if (rHoli != null && sInHoli != "1")
                                {
                                    rt[sDay] = "00";

                                    if (sInHoli == "2")
                                        continue;
                                }

                                //輪班頻率
                                switch (rRotet.sFreq.Trim())
                                {
                                    case "1":  //每日
                                        //用本月第一天所要接續的班進行遞增(目前班別小於總班別進行加1否則班別序等於1)
                                        iNO = (iNO < htRote.Count) ? ++iNO : 1;
                                        break;
                                    case "2":   //每週
                                        //判斷是否為星期一，是星期一就跳下週的輪班序；否則就照原本輪班序跑
                                        iNO = (i.DayOfWeek == DayOfWeek.Monday) ? ((iNO < htRote.Count) ? ++iNO : 1) : iNO;
                                        break;
                                    case "3":   //每月
                                        iNO = (i.Day == 1) ? ((iNO < htRote.Count) ? ++iNO : 1) : iNO;
                                        break;
                                    case "4":   //自訂天數
                                        break;
                                    case "5":   //指定一週
                                        break;
                                    case "6":   //上下月
                                        break;
                                    default:    //不可預期
                                        break;
                                }

                                rt[sDay] = htRote[iNO];

                                //假日輪班
                                switch (sInHoli)
                                {
                                    case "1":   //1.假日輪班
                                        break;
                                    case "2":   //2.影響輪班頻率
                                        rt[sDay] = (rHoli != null) ? "00" : htRote[iNO];
                                        break;
                                    case "3":   //3.不影響輪班頻率
                                        rt[sDay] = (rHoli != null) ? "00" : htRote[iNO];
                                        break;
                                    default:    //不可預期
                                        break;
                                }

                                //把短期調班的日期訂正過來  20090313 BY MING 修正為不同步更改TMTABLE的資料(暫不實作)

                            } //end for
                        }
                    }

                    rt.KEY_MAN = sKeyMan + "e";
                    rt.KEY_DATE = DateTime.Now;
                    rt.NO = iNO;
                    odsAtt.TMTABLE.AddTMTABLERow(rt);
                    taTMTABLE.Update(odsAtt.TMTABLE);

                    bTmTable = true;
                }

                return bTmTable;
            }

            /// <summary>
            /// 產生員工個人出勤資料
            /// </summary>
            /// <param name="sNobr">工號</param>
            /// <param name="dDate">日期</param>
            /// <param name="sKeyMan">登錄者</param>
            /// <returns>bool</returns>
            public static bool AttEnd(string sNobr, DateTime dDate, string sKeyMan)
            {
                bool bAttEnd = false;

                //將整個月的日期區間設定設定出來
                DateTime dDateB, dDateE;
                dDateB = Tools.DateOfStartOrEnd(dDate, true);
                dDateE = Tools.DateOfStartOrEnd(dDate, false);

                //取得本月跟上月的yymm
                string sYymmNow = Tools.DateToYyMm(dDate);

                string sRote;   //班別代碼
                dsAtt.ATTENDRow rATTEND;

                var rTmTable = Att.TmTable(sYymmNow, sNobr).FirstOrDefault();
                if (rTmTable != null)
                {
                    dsAttTableAdapters.ATTENDTableAdapter taATTEND = new JBHR.Dll.dsAttTableAdapters.ATTENDTableAdapter();
                    dsAtt odsAtt = new dsAtt();

                    taATTEND.FillByRange(odsAtt.ATTEND, sNobr, dDateB, dDateE);

                    for (DateTime i = dDateB; i <= dDateE; i = i.AddDays(1))
                    {
                        sRote = "D" + i.Day.ToString(); //先將欄位名稱拼出來並檢查該欄位是否存在
                        if (rTmTable.Table.Columns.Contains(sRote))
                        {
                            sRote = rTmTable[sRote].ToString().Trim();

                            //把短期調班的日期訂正過來
                            var rRotechg = Att.Rotechg(sNobr, i.Date).FirstOrDefault();
                            if (rRotechg != null)
                                sRote = rRotechg.sRoteCode;

                            //判斷值的字串是否大於零
                            if (sRote.Length > 0)
                            {
                                rATTEND = odsAtt.ATTEND.Where(p => p.ADATE.Date == i.Date).FirstOrDefault();
                                if (rATTEND == null)
                                {
                                    rATTEND = odsAtt.ATTEND.NewATTENDRow();
                                    Tools.SetRowDefaultValue(rATTEND);
                                    rATTEND.NOBR = sNobr;
                                    rATTEND.ADATE = i.Date;
                                    rATTEND.ROTE = sRote;
                                    rATTEND.KEY_MAN = sKeyMan + "e";
                                    odsAtt.ATTEND.AddATTENDRow(rATTEND);
                                }
                                else
                                {
                                    rATTEND = rATTEND as dsAtt.ATTENDRow;
                                    rATTEND.ROTE = sRote;
                                    rATTEND.KEY_DATE = DateTime.Now;
                                    rATTEND.KEY_MAN = sKeyMan + "e";
                                }
                            }
                        } //end if    
                    }   //end for

                    taATTEND.Update(odsAtt.ATTEND);
                    bAttEnd = true;

                    try
                    {
                        dcAttDataContext dcAtt = new dcAttDataContext();
                        Dal.Dao.Att.TransCardDao target = new Dal.Dao.Att.TransCardDao(dcAtt.Connection);
                        target.TransCard(sNobr, sNobr, "0", "z", dDateB, dDateE, sKeyMan, true, true, true, "", "JB-TRANSCARD", true, 3);
                        //TransCard(sNobr, sNobr, "", "", dDateB.AddDays(-1), dDateE, sKeyMan, true, true, true);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Tools.CreateTextFile("C:\\Error\\Abs" + DateTime.Now.ToFileTime().ToString() + ".txt", ex.ToString());
                        }
                        catch { }
                    }   
                }

                return bAttEnd;
            }
        }
    }

    /// <summary>
    /// 存入HR
    /// </summary>
    public static class HR_Active
    {
        /// <summary>
        /// 將請假資料存入HR.ABS實體資料表 True = 存入成功
        /// </summary>
        /// <param name="sNobr">請假人工號</param>
        /// <param name="sHcode">請假假別</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="sTimeB">開始時間</param>
        /// <param name="sTimeE">結束時間</param>
        /// <param name="sDeptCode">部門</param>
        /// <param name="sNote">原因</param>
        /// <param name="sKeyMan">申請者工號或姓名</param>
        /// <param name="sName">沖假對象</param>
        /// <param name="iException">例外時數</param>
        /// <returns>bool</returns>
        public static bool AbsSave(string sNobr, string sHcode, DateTime dDateB, DateTime dDateE, string sTimeB, string sTimeE, string sDeptCode, string sNote, string sKeyMan, string sName, decimal iException)
        {
            sTimeB = sTimeB.PadLeft(4, char.Parse("0"));
            sTimeE = sTimeE.PadLeft(4, char.Parse("0"));

            bool bAbsSave = JBHR.Dll.Att.AbsCal.AbsSave(sNobr, sHcode, dDateB, dDateE, sTimeB, sTimeE, sDeptCode, sNote, sKeyMan, sName, iException);
            return bAbsSave;
        }

        /// <summary>
        ///  將加班資料存入HR.Ot實體資料表 True = 存入成功
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="sRote">班別(預設帶0)</param>
        /// <param name="dDate">加班日期</param>
        /// <param name="sTimeB">加班開始時間</param>
        /// <param name="sTimeE">加班結束時間</param>
        /// <param name="sOtcatCode">加班別(1=加班費,2=補休假)</param>
        /// <param name="sOtrcdCode">加班原因代碼</param>
        /// <param name="sDeptCode">加班部門(預設帶0)</param>
        /// <param name="iEat">用餐費用</param>
        /// <param name="sNote">加班理由</param>
        /// <param name="sKeyMan">登錄者</param>
        /// <param name="iException">例外時數</param>
        /// <returns>bool</returns>
        public static bool OtSave(string sNobr, string sRote, DateTime dDate, string sTimeB, string sTimeE, string sOtcatCode, string sOtrcdCode, string sDeptCode, int iEat, string sNote, string sKeyMan, decimal iException)
        {
            bool bOtSave = JBHR.Dll.Att.OtCal.OtSave(sNobr, sRote, dDate, sTimeB, sTimeE, sOtcatCode, sOtrcdCode, sDeptCode, iEat, sNote, sKeyMan, iException);
            return bOtSave;
        }

        /// <summary>
        /// 刪除請假資料True = 存入成功
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="sTimeB">開始時間</param>
        /// <param name="sHcode">假別代碼</param>
        /// <param name="sKeyMan">登錄者</param>
        /// <returns>bool</returns>
        public static bool AbsDelete(string sNobr, DateTime dDateB, string sTimeB, string sHcode, string sKeyMan)
        {
            bool bDelete = JBHR.Dll.Att.Absc.AbsDelete(sNobr, dDateB, sTimeB, sHcode, sKeyMan);
            return bDelete;
        }

        /// <summary>
        /// 新增刷卡資料True = 存入成功
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">刷卡日期</param>
        /// <param name="sTime">刷卡時間</param>
        /// <param name="sReason">忘刷原因代碼</param>
        /// <param name="sKeyMan">登錄者</param>
        /// <returns>bool</returns>
        public static bool CardSave(string sNobr, DateTime dDate, string sTime, string sReason, string sKeyMan)
        {
            bool bCardSave = JBHR.Dll.Att.CardCal.CardSave(sNobr, dDate, sTime, sReason, sKeyMan);
            return bCardSave;
        }
    }

    /// <summary>
    /// 工具(時間轉換,寄信)
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// 編碼工具
        /// </summary>
        public static class EncodeTool
        {
            /// <summary>
            /// 編碼
            /// </summary>
            /// <param name="sData">要編碼字串</param>
            /// <returns>string</returns>
            public static string Encode(String sData)
            {
                try { return System.Convert.ToBase64String(System.Text.UTF8Encoding.UTF8.GetBytes(sData)); }
                catch { return ""; }
            }

            /// <summary>
            /// 解碼
            /// </summary>
            /// <param name="sData">要解碼字串</param>
            /// <returns>string</returns>
            public static string Decode(String sData)
            {
                try { return System.Text.UTF8Encoding.UTF8.GetString(System.Convert.FromBase64String(sData)); }
                catch { return ""; }
            }

            /// <summary>
            /// 解碼後轉成Hashtable
            /// </summary>
            /// <param name="sDo">解碼後的字串</param>
            /// <returns></returns>
            public static Hashtable QueryValue(string sDo)
            {
                string[] s = sDo.Split('&');
                Hashtable ht = new Hashtable();
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i].IndexOf("=") > 0)
                    {
                        string key = "";
                        string values = "";
                        key = s[i].Substring(0, s[i].IndexOf("="));
                        values = s[i].Substring(s[i].IndexOf("=") + 1);
                        ht.Add(key, values);
                    }
                }
                return ht;
            }
        }

        /// <summary>
        /// 提示訊息
        /// </summary>
        /// <param name="sAlert">訊息</param>
        /// <returns>string</returns>
        public static string MessageShowAlert(string sAlert)
        {
            string str = "<script language=javascript>";
            str += "alert('系統訊息提示：\\n" + sAlert + "')";
            str += "</" + "script>";
            return str;
        }

        /// <summary>
        /// 提示訊息(完整Script)
        /// </summary>
        /// <param name="sScript">Script語法</param>
        /// <returns>string</returns>
        public static string ShowScript(string sScript)
        {
            string str = "<script language=javascript>";
            str += sScript;
            str += "</" + "script>";
            return str;
        }

        /// <summary>
        /// 轉換時間為分鐘數
        /// </summary>
        /// <param name="sTime">時間(為4為位之數值)</param>
        /// <returns>int</returns>
        public static int ConvertHhMmToMinutes(string sTime)
        {
            sTime = (sTime.Trim().Length < 4) ? "0000" : sTime;
            return Convert.ToInt32(sTime.Substring(0, 2)) * 60 + int.Parse(sTime.Substring(2, 2));
        }

        /// <summary>
        /// 轉換時間為分鐘數
        /// </summary>
        /// <param name="sTime">時間(為4為位之數值)</param>
        /// <param name="bStart">當轉換時間格式不正確時,預帶之轉換時間bStart = True = "0000"</param>
        /// <returns>int</returns>
        public static int ConvertHhMmToMinutes(string sTime, bool bStart)
        {
            sTime = (sTime.Trim().Length < 4) ? bStart ? "0000" : "2400" : sTime;
            return Convert.ToInt32(sTime.Substring(0, 2)) * 60 + int.Parse(sTime.Substring(2, 2));
        }

        /// <summary>
        /// 轉換分鐘為時間
        /// </summary>
        /// <param name="iMinutes">分鐘數</param>
        /// <returns>string</returns>
        public static string ConvertMinutesToHhMm(int iMinutes)
        {
            return Convert.ToInt32(iMinutes / 60).ToString("00") + (iMinutes % 60).ToString("00");
        }

        /// <summary>
        /// 分割時間字串為小時或分鐘
        /// </summary>
        /// <param name="sTime">時間(為4為位之數值,不足4位時會向前補零)</param>
        /// <param name="bHour">bHour = True = 取得小時</param>
        /// <returns>string</returns>
        public static string SplitTimeToHhOrMm(string sTime, bool bHour)
        {
            sTime = (sTime.Trim().Length < 4) ? sTime.PadLeft(4, char.Parse("0")) : sTime;
            return bHour ? sTime.Substring(0, 2) : sTime.Substring(2, 2);
        }

        /// <summary>
        /// 分割時間字串為標準時間ex: 12 : 30 : 00
        /// </summary>
        /// <param name="sTime">時間(為4為位之數值,不足4位時會向前補零)</param>
        /// <returns>string</returns>
        public static string SplitTimeToHhMmSs(string sTime)
        {
            sTime = (sTime.Trim().Length < 4) ? sTime.PadLeft(4, char.Parse("0")) : sTime;
            return sTime.Substring(0, 2) + ":" + sTime.Substring(2, 2) + ":00";
        }

        /// <summary>
        /// 將日期轉成HHMM
        /// </summary>
        /// <param name="dDate">日期</param>
        /// <returns>string</returns>
        public static string SplitTimeToHhMm(DateTime dDate)
        {
            return dDate.Hour.ToString().PadLeft(2, char.Parse("0")) + dDate.Minute.ToString().PadLeft(2, char.Parse("0"));
        }

        /// <summary>
        /// 取得整月的開始日期或結束日期
        /// </summary>
        /// <param name="dDate">日期</param>
        /// <param name="bStart">bStart = True = 開始日期</param>
        /// <returns>DateTime</returns>
        public static DateTime DateOfStartOrEnd(DateTime dDate, bool bStart)
        {
            int yy = dDate.Year;
            int mm = dDate.Month;
            int dd = bStart ? 1 : DateTime.DaysInMonth(yy, mm);
            return new DateTime(yy, mm, dd);
        }

        /// <summary>
        /// 取得整月的開始日期或結束日期
        /// </summary>
        /// <param name="sYYMM"></param>
        /// <param name="bStart">bStart = True = 開始日期</param>
        /// <returns>DateTime</returns>
        public static DateTime DateOfStartOrEnd(string sYYMM, bool bStart)
        {
            sYYMM = sYYMM.Trim().Length == 6 ? sYYMM : (DateTime.Now.Year).ToString("0000") + (DateTime.Now.Month).ToString("00");
            int yy = Convert.ToInt32(sYYMM.Substring(0, 4));
            int mm = Convert.ToInt32(sYYMM.Substring(4));
            int dd = bStart ? 1 : DateTime.DaysInMonth(yy, mm);
            return new DateTime(yy, mm, dd);
        }

        /// <summary>
        /// 日期轉換成YYMM
        /// </summary>
        /// <param name="dDate">日期</param>
        /// <returns>string</returns>
        public static string DateToYyMm(DateTime dDate)
        {
            string yyyy = dDate.Year.ToString("0000");
            string mm = dDate.Month.ToString("00");
            return yyyy + mm;
        }

        /// <summary>
        /// YYMM轉換成日期
        /// </summary>
        /// <param name="sYYMM">YYMM</param>
        /// <param name="iDay">日</param>
        /// <returns>DateTime</returns>
        public static DateTime YyMnToDate(string sYYMM, int iDay)
        {
            int yy = Convert.ToInt32(sYYMM.Substring(0, 4));
            int mm = Convert.ToInt32(sYYMM.Substring(4));
            DateTime dDate;
            try
            {
                dDate = new DateTime(yy, mm, iDay);
            }
            catch
            {
                dDate = new DateTime(yy, mm, 1);
            }

            return dDate;
        }

        private static string YymmToYyymm(string yymm)
        {
            string yyy = (Convert.ToInt32(yymm.Substring(0, 4))).ToString() + "年";
            string mm = yymm.Substring(4, 2) + "月";
            string yyymm = yyy + mm;

            return yyymm;
        }

        /// <summary>
        /// 將Hashtable轉換為DataTable
        /// </summary>
        /// <param name="ht">Hashtable</param>
        /// <param name="sTextName">主鍵的欄位名稱(預設名稱為 t)</param>
        /// <param name="sValueName">值的欄位名稱(預設名稱為 v)</param>
        /// <returns>DataTable</returns>
        public static DataTable ConvertHashtableToDataTable(Hashtable ht, string sTextName, string sValueName)
        {
            sTextName = sTextName.Trim().Length == 0 ? "t" : sTextName;
            sValueName = sValueName.Trim().Length == 0 ? "v" : sValueName;
            DataTable dt = new DataTable();
            dt.Columns.Add(sTextName).DefaultValue = "";
            dt.Columns.Add(sValueName).DefaultValue = "";

            foreach (DictionaryEntry de in ht)
            {
                DataRow r = dt.NewRow();
                r[sTextName] = de.Key;
                r[sValueName] = de.Value;
                dt.Rows.Add(r);
            }

            return dt;
        }

        /// <summary>
        /// 填入所有預設資料
        /// </summary>
        /// <param name="row">Row</param>
        public static void SetRowDefaultValue(DataRow row)
        {
            Type t;
            foreach (DataColumn dc in row.Table.Columns)
            {
                t = dc.DataType;
                if (t == typeof(string)) row[dc] = "";
                if (t == typeof(bool)) row[dc] = false;
                if (t == typeof(int)) row[dc] = 0;
                if (t == typeof(decimal)) row[dc] = 0;
                if (t == typeof(double)) row[dc] = 0;
                if (t == typeof(DateTime)) row[dc] = DateTime.Now;
            }
        }
        /// <summary>
        /// 填入所有預設資料
        /// </summary>
        /// <param name="LinqObj">object</param>
        public static void SetRowDefaultValue(object LinqObj)
        {
            // get the properties of the LINQ Object        
            PropertyInfo[] props = LinqObj.GetType().GetProperties();

            // iterate through each property of the class
            foreach (PropertyInfo prop in props)
            {
                // attempt to discover any metadata relating to underlying data columns
                try
                {
                    // get any column attributes created by the linq designer
                    object[] customAttributes = prop.GetCustomAttributes(typeof(System.Data.Linq.Mapping.ColumnAttribute), false);

                    // if the property has an attribute letting us know that the underlying column data cannot be null
                    //if (((System.Data.Linq.Mapping.ColumnAttribute)(customAttributes[0])).DbType.ToLower().IndexOf("not null") != -1)
                    if (true)
                    {
                        // if the current property is null or Linq has set a date time to its default '01/01/0001 00:00:00'
                        //if (prop.GetValue(LinqObj, null) == null || prop.GetValue(LinqObj, null).ToString() == (new DateTime(1, 1, 1, 0, 0, 0)).ToString())
                        if (true)
                        {
                            // set the default values here : could re-query the database, but would be expensive so just use defaults coded here
                            switch (prop.PropertyType.ToString())
                            {
                                // System.String / NVarchar
                                case "System.String":
                                    prop.SetValue(LinqObj, string.Empty, null);
                                    break;
                                case "System.Boolean":
                                    prop.SetValue(LinqObj, false, null);
                                    break;
                                case "System.Nullable`1[System.Decimal]":
                                case "System.Decimal":
                                    prop.SetValue(LinqObj, 0M, null);
                                    break;
                                case "System.Nullable`1[System.Int32]":
                                case "System.Int32":
                                case "System.Int64":
                                case "System.Int16":
                                    prop.SetValue(LinqObj, 0, null);
                                    break;
                                case "System.DateTime":
                                    prop.SetValue(LinqObj, DateTime.Now, null);
                                    break;
                            }
                        }
                    }
                }
                catch
                {
                    // could do something here ...
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dc">dcAttDataContext</param>
        public static void dcSubmitChanges(dcAttDataContext dc)
        {
            try
            {
                dc.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
            catch (System.Data.Linq.ChangeConflictException ex)
            {
                foreach (System.Data.Linq.ObjectChangeConflict occ in dc.ChangeConflicts)
                {
                    // *********************************************
                    // 底下三個範例是 3 選 1 喔，不要三行都寫在一起！
                    // **********************************************

                    // 採用資料庫的查詢出來的值，目前物件的值將會被資料庫最新查到的複寫
                    //occ.Resolve(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                    // 採用目前物件中的值，並更新資料庫中的版本
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepCurrentValues);
                    // 僅更新此物件中變更的欄位，僅將變更的欄位寫入資料庫（或稱為合併更新）
                    //occ.Resolve(System.Data.Linq.RefreshMode.KeepChanges);
                }
                // 注意：解決完衝突之後要記得重新再 SubmitChanges() 一次，否則一樣不會更新資料庫
                dc.SubmitChanges();
            }
        }

        /// <summary>
        /// 交換變數
        /// </summary>
        /// <typeparam name="T">型別</typeparam>
        /// <param name="lhs">左變數</param>
        /// <param name="rhs">右變數</param>
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        private delegate void AsyncMethodCaller(string sMailServerName, string sFrom, bool bIsUseDefaultCredentials, string sFromID, string sFromPW, string sTo, string sSubject, string sBody, out int threadId);

        /// <summary>
        /// 傳送信件射後不理
        /// </summary>
        /// <param name="sMailServerName">郵件伺服器IP或Name</param>
        /// <param name="sFrom">寄件者Mail</param>
        /// <param name="bIsUseDefaultCredentials">True = 要驗証</param>
        /// <param name="sFromID">寄件者帳號(若是需要驗証,則就需要輸入寄件者帳號)</param>
        /// <param name="sFromPW">寄件者密碼(若是需要驗証,則就需要輸入寄件者密碼)</param>
        /// <param name="sTo">收件者Mail</param>
        /// <param name="sSubject">主旨</param>
        /// <param name="sBody">內文</param>
        public static void SendMailThread(string sMailServerName, string sFrom, bool bIsUseDefaultCredentials, string sFromID, string sFromPW, string sTo, string sSubject, string sBody)
        {
            int threadId = 0;

            AsyncMethodCaller caller = new AsyncMethodCaller(SendMail);

            IAsyncResult result = caller.BeginInvoke(sMailServerName, sFrom, bIsUseDefaultCredentials, sFromID, sFromPW, sTo, sSubject, sBody, out threadId, null, null);
        }

        private static void SendMail(string sMailServerName, string sFrom, bool bIsUseDefaultCredentials, string sFromID, string sFromPW, string sTo, string sSubject, string sBody, out int threadId)
        {
            threadId = 0;
            SendMail(sMailServerName, sFrom, bIsUseDefaultCredentials, sFromID, sFromPW, sTo, sSubject, sBody);
        }

        /// <summary>
        /// 傳送信件
        /// </summary>
        /// <param name="sMailServerName">郵件伺服器IP或Name</param>
        /// <param name="sFrom">寄件者Mail</param>
        /// <param name="bIsUseDefaultCredentials">True = 要驗証</param>
        /// <param name="sFromID">寄件者帳號(若是需要驗証,則就需要輸入寄件者帳號)</param>
        /// <param name="sFromPW">寄件者密碼(若是需要驗証,則就需要輸入寄件者密碼)</param>
        /// <param name="sTo">收件者Mail</param>
        /// <param name="sSubject">主旨</param>
        /// <param name="sBody">內文</param>
        public static void SendMail(string sMailServerName, string sFrom, bool bIsUseDefaultCredentials, string sFromID, string sFromPW, string sTo, string sSubject, string sBody)
        {
            //sMailServerName = "IP";
            //sFrom = "mail";
            //bIsUseDefaultCredentials = true;
            //sFromID= "id";
            //sFromPW = "pw";

            try
            {
                using (MailMessage message =
                    new MailMessage(sFrom, sTo, sSubject, sBody))
                {
                    message.IsBodyHtml = true;
                    message.Priority = MailPriority.High;
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.SubjectEncoding = System.Text.Encoding.UTF8;

                    SmtpClient mailClient = new SmtpClient(sMailServerName);
                    mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                    if (bIsUseDefaultCredentials) mailClient.UseDefaultCredentials = true;
                    else
                    {
                        mailClient.UseDefaultCredentials = false;
                        mailClient.Credentials = new System.Net.NetworkCredential(sFromID, sFromPW);
                    }

                    mailClient.Send(message);

                    dcBasDataContext dcBas = new dcBasDataContext();
                    MAILQUEUE r = new MAILQUEUE();
                    r.GUID = Guid.NewGuid().ToString();
                    r.FROM_ADDR = sFrom;
                    r.FROM_NAME = "";
                    r.TO_ADDR = sTo;
                    r.TO_NAME = "";
                    r.SUBJECT = sSubject;
                    r.BODY = sBody;
                    r.RETRY = 0;
                    r.SUCCESS = true;
                    r.SUSPEND = false;
                    r.FREEZE_TIME = DateTime.Now;
                    r.KEY_DATE = DateTime.Now;
                    r.KEY_MAN = "Flow";
                    dcBas.MAILQUEUE.InsertOnSubmit(r);
                    dcBas.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    CreateTextFile("C:\\Error\\SendMail" + DateTime.Now.ToFileTime().ToString() + ".txt", ex.ToString());
                }
                catch
                {
                    throw ex;
                }
                //throw ex;
            }
        }

        /// <summary>
        /// 產生錯誤訊息到檔案
        /// </summary>
        /// <param name="sFileName">檔案路徑+檔案名稱</param>
        /// <param name="sError">攔結之錯誤訊息</param>
        public static void CreateTextFile(string sFileName, string sError)
        {
            StreamWriter sw = File.CreateText(@sFileName);
            sw.Write(sError);
            sw.Close();
        }

        /// <summary>
        /// 傳回DataTable的結構
        /// </summary>
        /// <param name="dt">資料表</param>
        /// <returns>DataTable</returns>
        public static DataTable DataStructure(DataTable dt)
        {
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("欄位名稱").DefaultValue = "";
            dtTemp.Columns.Add("中文對照").DefaultValue = "";
            dtTemp.Columns.Add("型態").DefaultValue = "";
            dtTemp.Columns.Add("長度").DefaultValue = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                DataRow r = dtTemp.NewRow();
                r["欄位名稱"] = dc.ColumnName;
                r["中文對照"] = "";
                r["型態"] = dc.DataType.ToString();
                r["長度"] = dc.MaxLength;
                dtTemp.Rows.Add(r);
            }

            return dtTemp;
        }

        /// <summary>
        /// 轉換DataTable為Html(單欄)
        /// </summary>
        /// <param name="dt">資料表</param>
        /// <param name="dc">欄位名稱</param>
        /// <param name="ColumnNum">每欄幾列</param>
        /// <returns>string</returns>
        public static string ConvertDataTableToHtml(DataTable dt, string dc, int ColumnNum = 4)
        {
            string htmlString = "";

            if (dt == null || dt.Rows.Count == 0) return htmlString;

            ColumnNum = ColumnNum > dt.Rows.Count ? dt.Rows.Count : ColumnNum;

            StringBuilder htmlBuilder = new StringBuilder();

            //Create Top Portion of HTML Document
            htmlBuilder.Append("<html>");
            htmlBuilder.Append("<head>");
            htmlBuilder.Append("<title>");
            htmlBuilder.Append("Page-");
            htmlBuilder.Append(Guid.NewGuid().ToString());
            htmlBuilder.Append("</title>");
            htmlBuilder.Append("</head>");
            htmlBuilder.Append("<body>");
            htmlBuilder.Append("<table border='1px' cellpadding='5' cellspacing='0' ");
            htmlBuilder.Append("style='border: solid 1px Black; font-size: small;'>");
            htmlBuilder.Append("<tr align='left' valign='top'>");

            int j = dt.Rows.Count + ((dt.Rows.Count % ColumnNum == 0) ? 0 : (ColumnNum - (dt.Rows.Count % ColumnNum)));
            for (int i = 0; i < j; i++)
            {
                if (i != 0 && i % ColumnNum == 0)
                    htmlBuilder.Append("</tr><tr align='left' valign='top'>");

                htmlBuilder.Append("<td align='left' valign='top'>");
                htmlBuilder.Append(dt.Rows.Count <= i || dt.Rows[i][dc].ToString().Length == 0 ? "&nbsp;" : dt.Rows[i][dc].ToString());
                htmlBuilder.Append("</td>");
            }

            htmlBuilder.Append("</tr>");

            //Create Bottom Portion of HTML Document
            htmlBuilder.Append("</table>");
            htmlBuilder.Append("</body>");
            htmlBuilder.Append("</html>");

            //Create String to be Returned
            htmlString = htmlBuilder.ToString();

            return htmlString;
        }

        /// <summary>
        /// 轉換DataTable為Html
        /// </summary>
        /// <param name="targetTable">DataTable</param>
        /// <returns>static</returns>
        public static string ConvertToHtmlFile(DataTable targetTable)
        {
            string htmlString = "";
            if (targetTable == null)
                throw new System.ArgumentNullException("targetTable");

            StringBuilder htmlBuilder = new StringBuilder();

            //Create Top Portion of HTML Document
            htmlBuilder.Append("<html>");
            htmlBuilder.Append("<head>");
            htmlBuilder.Append("<title>");
            htmlBuilder.Append("Page-");
            htmlBuilder.Append(Guid.NewGuid().ToString());
            htmlBuilder.Append("</title>");
            htmlBuilder.Append("</head>");
            htmlBuilder.Append("<body>");
            htmlBuilder.Append("<table border='1px' cellpadding='5' cellspacing='0' ");
            htmlBuilder.Append("style='border: solid 1px Black; font-size: small;'>");

            //Create Header Row
            htmlBuilder.Append("<tr align='left' valign='top'>");
            foreach (DataColumn targetColumn in targetTable.Columns)
            {
                htmlBuilder.Append("<td align='left' valign='top'>");
                htmlBuilder.Append(targetColumn.ColumnName);
                htmlBuilder.Append("</td>");
            }
            htmlBuilder.Append("</tr>");

            //Create Data Rows
            foreach (DataRow myRow in targetTable.Rows)
            {
                htmlBuilder.Append("<tr align='left' valign='top'>");
                foreach (DataColumn targetColumn in targetTable.Columns)
                {
                    htmlBuilder.Append("<td align='left' valign='top'>");
                    htmlBuilder.Append(myRow[targetColumn.ColumnName].ToString().Length == 0 ? "&nbsp;" : myRow[targetColumn.ColumnName].ToString());
                    htmlBuilder.Append("</td>");
                }
                htmlBuilder.Append("</tr>");
            }

            //Create Bottom Portion of HTML Document
            htmlBuilder.Append("</table>");
            htmlBuilder.Append("</body>");
            htmlBuilder.Append("</html>");

            //Create String to be Returned
            htmlString = htmlBuilder.ToString();

            return htmlString;
        }
    }
}