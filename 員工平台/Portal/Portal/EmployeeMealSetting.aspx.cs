using Bll;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class WebForm1 : WebPageBase
    {
        static string MealApiAddress = ConfigurationManager.AppSettings["MealApiAddress"];
        KCR_MealService.IKCR_MealService kCR_MealService = new KCR_MealService.KCR_MealServiceClient("BasicHttpBinding_IKCR_MealService", MealApiAddress);

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (_User.Role.Contains("Coordinator"))
                    ddlEmp.Enabled = true;
                ddlEmp_DataBind();
                GetData();
                
            }
        }
        private void GetData()
        {
            
            var list = kCR_MealService.KCR_GetMealApplySettingByEmpID(ddlEmp.SelectedValue, DateTime.Now.Date);

            UnobtrusiveSession.Session["list"] = list;
            var MealDay = list.Where(p => p.HoliMealFlag == false);
            //平日用餐選項加入用餐字眼
            foreach (var c in MealDay)
            {
                c.MealTypeName = c.MealTypeName + "用餐";
            }

            ckblMealDay.DataSource = MealDay;
            ckblMealDay.DataBind();

            var MealHoliDay = list.Where(p => p.HoliMealFlag == true).ToList();

            //加入不用餐選項
            KCR_MealService.KCR_MealApplySettingEntry kCR_MealApplySettingEntry = new KCR_MealService.KCR_MealApplySettingEntry
            {
                GID = new Guid(),
                MealTypeName = "不用餐",
            };
            MealHoliDay.Add(kCR_MealApplySettingEntry);

            ckblMealHoliday.DataSource = MealHoliDay;
            ckblMealHoliday.DataBind();

            //平日用餐
            foreach (ButtonListItem item in ckblMealDay.Items)
            {
                var rMeal = list.Where(p => p.GID.ToString() == item.Value).FirstOrDefault();
                if (rMeal != null)
                {
                    item.Selected = rMeal.ApplyFlag;
                }
            }

            //假日用餐
            foreach (ButtonListItem item in ckblMealHoliday.Items)
            {
                var rMeal = list.Where(p => p.GID.ToString() == item.Value).FirstOrDefault();
                if (rMeal != null)
                {
                    item.Selected = rMeal.ApplyFlag;
                }

                //假日用餐不用餐判斷
                if (!list.Where(p => p.HoliMealFlag == true && p.ApplyFlag == true).Any())
                {
                    if (item.Value == kCR_MealApplySettingEntry.GID.ToString())
                    {
                        item.Selected = true;
                    }
                }
            }


        }
        public void ddlEmp_DataBind()
        {
            var rs = AccessData.GetSearchListEmp(_User, CompanySetting);

            foreach (var r in rs)
                r.Sort = 9;

            //按排序 再按照工號
            rs = rs.OrderBy(p => p.Sort).ThenBy(p => p.Value).ToList();

            ddlEmp.DataSource = rs;
            ddlEmp.DataTextField = "Text";
            ddlEmp.DataValueField = "Value";
            ddlEmp.DataBind();

            if (ddlEmp.FindItemByValue(_User.EmpId) != null)
                ddlEmp.FindItemByValue(_User.EmpId).Selected = true;
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            var rsMeal = UnobtrusiveSession.Session["list"] as KCR_MealService.KCR_MealApplySettingEntry[];
            
            foreach (ButtonListItem item in ckblMealDay.Items)
            {
                var rMeal = rsMeal.Where(p => p.GID.ToString() == item.Value).FirstOrDefault();
                if (rMeal != null)
                {
                    rMeal.ApplyFlag = item.Selected;
                    rMeal.ADate = DateTime.Now.Date;
                    rMeal.DDate = new DateTime(9999, 12, 31);
                    rMeal.Key_Man = _User.EmpId;
                    rMeal.Key_Date = DateTime.Now;

                }
                else
                {
                    ResultText.Text = "無該筆餐別設定";
                }
            }

            foreach (ButtonListItem item in ckblMealHoliday.Items)
            {
                var rMeal = rsMeal.Where(p => p.GID.ToString() == item.Value).FirstOrDefault();
                if (rMeal != null)
                {
                    rMeal.ApplyFlag = item.Selected;
                    rMeal.ADate = DateTime.Now.Date;
                    rMeal.DDate = new DateTime(9999, 12, 31);
                    rMeal.Key_Man = _User.EmpId;
                    rMeal.Key_Date = DateTime.Now;

                }
                else
                {
                    ResultText.Text = "無該筆餐別設定";
                }
            }

            if (ckblMealHoliday.SelectedValue == "0")
            {
                var rMealHoly = rsMeal.Where(p => p.HoliMealFlag == true);
                foreach (var c in rMealHoly)
                {
                    c.ApplyFlag = false;
                }
            }


            kCR_MealService.KCR_UpdateMealApplySettingByEmpID(rsMeal);
            GetData();
            ResultText.Text = "餐別設定更新成功";
            ResultText.CssClass = "label-primary";
        }

        protected void ckblMealDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ButtonListItem buttonListItem = sender as ButtonListItem;
            //foreach (ButtonListItem item in ckblMealDay.Items)
            //{
            //}
        }

        protected void ddlEmp_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetData();
            ResultText.Text = "";
            ResultText.CssClass = "label-danger";
        }
    }
}