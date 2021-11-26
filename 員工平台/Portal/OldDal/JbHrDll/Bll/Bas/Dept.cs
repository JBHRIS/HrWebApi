using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OldBll.Bas.Vdb;

namespace OldBll.Bas
{
    public class Dept
    {
        /// <summary>
        /// 部門向下展開 帶出所有子部門
        /// </summary>
        /// <param name="dcAllDept">部門字典</param>
        /// <param name="lsSearchSourceDept">搜尋來源部門</param>
        /// <returns>部門List</returns>
        public List<string> GetDeptDowmList(Dictionary<string, string> dcAllDept, List<string> lsSearchSourceDept)
        {
            var Vdb = dcAllDept.Where(p => lsSearchSourceDept.Contains(p.Value));
            return Vdb.Any() ? lsSearchSourceDept.Union(GetDeptDowmList(dcAllDept, Vdb.Select(p => p.Key).ToList())).ToList() : lsSearchSourceDept;
        }

        /// <summary>
        /// 尋找父部門到指定的大小
        /// </summary>
        /// <param name="sSearchDept">尋找部門</param>
        /// <param name="lsAllDept">所有部門</param>
        /// <param name="sTree">尋找大小 二位數</param>
        /// <returns>部門string</returns>
        public string GetDeptByTree(string sSearchDept, List<DeptRow> lsAllDept, string sTree = "00")
        {
            DeptRow rAllDept = null;
            string sDept = sSearchDept;

            int i = 0;
            do
            {
                i++;
                rAllDept = lsAllDept.Where(p => p.Code == sDept).FirstOrDefault();
                if (rAllDept != null && rAllDept.Tree.CompareTo(sTree) < 0)
                    sDept = rAllDept.ParentCode;
            } while (rAllDept != null && (rAllDept.Tree.CompareTo(sTree) < 0) && i <= lsAllDept.Count);

            return sDept;
        }

        /// <summary>
        /// 設定部門組織(僅限Dept,Deptm使用)
        /// </summary>
        /// <param name="lsDept">部門資料表</param>
        public void SetDeptPath(List<DeptRow> lsDept)
        {
            string sDept;
            DeptRow rDept;
            int i;

            foreach (var r in lsDept)
            {
                i = 0;
                sDept = r.Code;

                //if (sDept == "AD-3100")
                //    sDept = r.Code;

                do
                {
                    rDept = lsDept.Where(p => p.Code == sDept).FirstOrDefault();
                    if (rDept != null)
                    {
                        r.Path = "/" + rDept.Code + r.Path;

                        if (sDept == rDept.ParentCode)
                            break;

                        sDept = rDept.ParentCode;
                    }

                    i++;
                } while (rDept != null && sDept.Trim().Length > 0 && i <= lsDept.Count);

                r.Path += "/";
            }
        }

        /// <summary>
        /// 找福委名單
        /// </summary>
        /// <param name="lsDept">部門集合</param>
        /// <param name="sDept">起始部門</param>
        /// <param name="Subsidy123">福委123</param>
        /// <returns>string</returns>
        public string GetSubsidyNobr(List<DeptRow> lsDept, string sDept, string Subsidy123)
        {
            var rDept = lsDept.Where(p => p.Code == sDept).FirstOrDefault();
            string sNobr = "";
            int i = 0;

            do
            {
                rDept = lsDept.Where(p => p.Code == sDept).FirstOrDefault();

                if (rDept != null)
                {
                    sDept = rDept.ParentCode;

                    switch (Subsidy123)
                    {
                        case "1":
                            sNobr = rDept.SubsidyNobr1;
                            break;
                        case "2":
                            sNobr = rDept.SubsidyNobr2;
                            break;
                        case "3":
                            sNobr = rDept.SubsidyNobr3;
                            break;
                        default:
                            break;
                    }
                }

                i++;
            } while (rDept != null && rDept.ParentCode.Trim().Length > 0 && sNobr.Length == 0 && i < 10);

            return sNobr;
        }
    }
}