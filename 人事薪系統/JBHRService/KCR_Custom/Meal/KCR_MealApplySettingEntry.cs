using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JBHR2Service.KCR_Custom.Meal
{
    public class KCR_MealApplySettingEntry
    {
		//編號
		public int AutoKey { get; set; }
		//識別碼
		public Guid GID { get; set; }
		//員工編號
		public string EmployeeID { get; set; }
		//用餐群組
		public string MealGroup { get; set; }
		//用餐群組名稱
		public string MealGroupName { get; set; }
		//用餐餐別
		public string MealType { get; set; }
		//餐別名稱
		public string MealTypeName { get; set; }
		//餐別時間(排序用)
		public String BTime { get; set; }
        //用餐旗標
        public bool ApplyFlag { get; set; }
		//假日旗標
		public bool HoliMealFlag { get; set; }
		//生效日期
		public DateTime ADate { get; set; }
		//失效日期
		public DateTime DDate { get; set; }
		//備註
		public string Note { get; set; }
		//登錄者
        public string Key_Man { get; set; }
		//登錄日期
        public DateTime Key_Date { get; set; }
    }
}