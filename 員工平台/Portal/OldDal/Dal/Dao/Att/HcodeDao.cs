using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OldBll.Att.Vdb;

namespace OldDal.Dao.Att
{
    public class HcodeDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;

        /// <summary>
        /// 假別代碼
        /// </summary>
        /// <param name="conn"></param>
        public HcodeDao(IDbConnection conn = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (conn != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 假別代碼
        /// </summary>
        /// <param name="ConnectionString"></param>
        public HcodeDao(string ConnectionString = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (ConnectionString != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(ConnectionString);
        }

        /// <summary>
        /// 假別代碼資料
        /// </summary>
        /// <param name="sCode">假別代碼</param>
        /// <param name="bDisplay">只列出要顯示的</param>
        /// <returns>HcodeTable</returns>
        public List<HcodeTable> GetHocde(string sCode = "", bool bDisplay = true)
        {
            var Vdb = (from h in dcHr.HCODE
                       where (sCode == "" || h.H_CODE == sCode)
                       && (bDisplay ? (h.SORT > 0 && h.FLAG == "-") : true)
                       orderby h.SORT
                       select new HcodeTable
                       {
                           Code = h.H_CODE.Trim(),
                           NameC = h.H_NAME.Trim(),
                           NameE = h.H_ENAME.Trim(),
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 假別代碼資料
        /// </summary>
        /// <param name="sCode">假別代碼</param>
        /// <param name="bDisplay">只列出要顯示的</param>
        /// <returns>HcodeTable</returns>
        public List<HcodeDetailTable> GetHocdeDetail(string sCode = "", bool bDisplay = true)
        {
            var Vdb = (from h in dcHr.HCODE
                       where (sCode == "" || h.H_CODE == sCode)
                       && (bDisplay ? (h.SORT > 0 && h.FLAG == "-") : true)
                       orderby h.SORT
                       select new HcodeDetailTable
                       {
                           Code = h.H_CODE.Trim(),
                           NameC = h.H_NAME.Trim(),
                           NameE = h.H_ENAME.Trim(),
                           InHoli = h.IN_HOLI,
                           Min = h.MIN_NUM,
                           Interval = h.ABSUNIT,
                           Max = h.MAX_NUM,
                           Unit = h.UNIT.Trim() == "天" ? OldBll.MT.mtEnum.HcodeUnit.Day : (h.UNIT.Trim() == "分钟" || h.UNIT == "分" || h.UNIT == "分鐘") ? OldBll.MT.mtEnum.HcodeUnit.Minute : OldBll.MT.mtEnum.HcodeUnit.Hour,
                           Sex = h.SEX.Trim() == "F" ? OldBll.MT.mtEnum.SexCategroy.Female : h.SEX.Trim() == "M" ? OldBll.MT.mtEnum.SexCategroy.Male : OldBll.MT.mtEnum.SexCategroy.Both,
                           DisplayForm = h.DISPLAYFORM,
                           CheckBalance = h.CHE,
                           CheckUploadFlie = false,
                           Sort = h.SORT,
                           YearRest = h.YEAR_REST.Trim(),
                           Dcode = h.DCODE.Trim(),
                           CalUnit = h.DATEUNIT.Trim().Length == 0 || h.DATEUNIT.Trim() == "年" ? OldBll.MT.mtEnum.HcodeUnit.Year : OldBll.MT.mtEnum.HcodeUnit.Month,

                       }).ToList();

            return Vdb;
        }
        /// <summary>
        /// 假別代碼依資料群組資料
        /// </summary>
        /// <param name="sCode">假別代碼</param>
        /// <param name="bDisplay">只列出要顯示的</param>
        ///  <param name="sNobr">工號</param>
        ///  <param name="dDate">日期</param>
        /// <returns>HcodeTable</returns>
        public List<HcodeTable> GetHocdeByFilter(string sCode = "", bool bDisplay = true, string sNobr = "", DateTime? dDate = null)
        {
            var Vdb = (from h in dcHr.HCODE
                       where (sCode == "" || h.H_CODE == sCode)
                       && (bDisplay ? (h.SORT > 0 && h.FLAG == "-") : true)
                       && dcHr.GetCodeFilterByNobr("HCODE", h.H_CODE, sNobr, dDate.Value.Date).Value
                       orderby h.SORT
                       select new HcodeTable
                       {
                           Code = h.H_CODE.Trim(),
                           NameC = h.H_NAME.Trim(),
                           NameE = h.H_NAME.Trim() + "(" + h.H_CODE.Trim() + ")",
                           Unit = h.UNIT.Trim() == "天" ? OldBll.MT.mtEnum.HcodeUnit.Day : h.UNIT.Trim() == "小時" || h.UNIT.Trim() == "小时" ? OldBll.MT.mtEnum.HcodeUnit.Hour : OldBll.MT.mtEnum.HcodeUnit.Minute,
                       }).ToList();

            return Vdb;
        }
    }
}