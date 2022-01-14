using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Employee.View
{
    public class HunyaEmployeeInfoViewDto
    {
        /// <summary>
        /// 異動日期
        /// </summary>
        public DateTime EditDate { get; set; }
        /// <summary>
        /// 員工代碼
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 員工姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// EMAIL
        /// </summary>
        public string EMail { get; set; }
        /// <summary>
        /// 登入AD帳號
        /// </summary>
        public string LoginID { get; set; }
        /// <summary>
        /// 英文姓名
        /// </summary>
        public string EnglishName { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 擔任編制部門主管
        /// </summary>
        public bool SupervisorDept { get; set; }
        /// <summary>
        /// 擔任簽核部門主管
        /// </summary>
        public bool SupervisorDepta { get; set; }
        /// <summary>
        /// 簽核層級
        /// </summary>
        public string Signoff { get; set; }
        /// <summary>
        /// 編制部門代碼
        /// </summary>
        public string DeptId { get; set; }
        /// <summary>
        /// 編制部門顯示代碼
        /// </summary>
        public string DeptIdDisp { get; set; }
        /// <summary>
        /// 編制部門名稱
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 簽核部門代碼
        /// </summary>
        public string DeptaId { get; set; }
        /// <summary>
        /// 簽核部門顯示代碼
        /// </summary>
        public string DeptaIdDisp { get; set; }
        /// <summary>
        /// 簽核部門名稱
        /// </summary>
        public string DeptaName { get; set; }
        /// <summary>
        /// 成本部門代碼
        /// </summary>
        public string DeptsId { get; set; }
        /// <summary>
        /// 成本部門顯示代碼
        /// </summary>
        public string DeptsIdDisp { get; set; }
        /// <summary>
        /// 成本部門名稱
        /// </summary>
        public string DeptsName { get; set; }
        /// <summary>
        /// 職稱代碼
        /// </summary>
        public string JobTitle { get; set; }
        /// <summary>
        /// 職稱顯示代碼
        /// </summary>
        public string JobTitleDisp { get; set; }
        /// <summary>
        /// 職稱名稱
        /// </summary>
        public string JobTitleName { get; set; }
        /// <summary>
        /// 職等代碼
        /// </summary>
        public string JobLevel { get; set; }
        /// <summary>
        /// 職等顯示代碼
        /// </summary>
        public string JobLevelDisp { get; set; }
        /// <summary>
        /// 職等名稱
        /// </summary>
        public string JobLevelName { get; set; }
        /// <summary>
        /// 職級代碼
        /// </summary>
        public string JobRank { get; set; }
        /// <summary>
        /// 職級顯示代碼
        /// </summary>
        public string JobRankDisp { get; set; }
        /// <summary>
        /// 職級名稱
        /// </summary>
        public string JobRankName { get; set; }
        /// <summary>
        /// 國籍
        /// </summary>
        public string Nationality { get; set; }
        /// <summary>
        /// 分機
        /// </summary>
        public string Ext { get; set; }
        /// <summary>
        /// 工作地點代碼
        /// </summary>
        public string WorkPlaceCode { get; set; }
        /// <summary>
        /// 工作地點名稱
        /// </summary>
        public string WorkPlaceName { get; set; }
        /// <summary>
        /// 資料群組
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// 到職日期
        /// </summary>
        public DateTime? OnBoardDate { get; set; }
        /// <summary>
        /// 離職日期
        /// </summary>
        public DateTime? ResignDate { get; set; }
        /// <summary>
        /// 公司代號
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 工廠代號
        /// </summary>
        public string Plant { get; set; }
        /// <summary>
        /// 銷售組織
        /// </summary>
        public string SalesOrg { get; set; }
        /// <summary>
        /// 採購組織
        /// </summary>
        public string PurchaseOrg { get; set; }
    }
}
