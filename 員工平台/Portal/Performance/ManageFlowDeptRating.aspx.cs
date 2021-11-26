using Bll;
using Bll.Tools;
using Dal;
using Dal.Dao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Performance
{
    public partial class ManageFlowDeptRating : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                lblAutoKey.Text = "";
                if (Request.QueryString["AutoKey"] == null)
                {
                    UnobtrusiveSession.Session["AutoKey"] = null;
                    UnobtrusiveSession.Session["MainCode"] = null;
                }
                else
                    lblAutoKey.Text = (string)UnobtrusiveSession.Session["AutoKey"];

                if (UnobtrusiveSession.Session["AutoKey"] == null)
                    btnReturn_Click(null, null);

                _DataBind();
                LoadData(lblAutoKey.Text);
            }
        }

        public void _DataBind()
        {
            string Key = lblAutoKey.Text.Length > 0 ? lblAutoKey.Text : "-1";
            var AutoKey = Convert.ToInt32(Key);
        }

        public void LoadData(string Key = "")
        {
            Key = Key.Length > 0 ? Key : "-1";
            var AutoKey = Convert.ToInt32(Key);
        }

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            string Key = lblAutoKey.Text.Length > 0 ? lblAutoKey.Text : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var rDept = (from c in dcMain.PerformanceDept
                         where c.AutoKey == AutoKey
                         select c).FirstOrDefault();

            if (rDept == null)
                return;

            var MainCode = rDept.PerformanceMainCode;
            var DeptCode = rDept.Code;
            var CompCode = "A";

            var rMain = (from c in dcMain.PerformanceMain
                         where c.Code == MainCode
                         select c).FirstOrDefault();

            if (rMain != null)
            {
                var rsRating = (from c in dcMain.PerformanceRating
                                where c.EmpCategoryCode == rMain.EmpCategoryCode
                                //&& c.CompCode == CompCode
                                orderby c.Sort
                                select c).ToList();

                var rsDeptRating = (from c in dcMain.PerformanceDeptRating
                                    where c.PerformanceMainCode == MainCode
                                   && c.PerformanceDeptCode == DeptCode
                                    select c).ToList();

                var rs = (from r in rsRating
                          join dr in rsDeptRating on r.Code equals dr.PerformanceRatingCode
                          orderby r.Sort
                          select new
                          {
                              dr.AutoKey,
                              dr.PerformanceRatingCode,
                              PerformanceRatingName = r.Name,
                              r.BonusPerMax,
                              r.BonusPerMin,
                              r.NumPerMax,
                              r.NumPerMin,
                              r.NumPer,
                              NumPerNew = dr.NumPer,
                          });

                lvMain.DataSource = rs;

                var Script = "$(document).ready(function() {$('.footable').footable();});";
                ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
            }
        }

        protected void lvMain_DataBound(object sender, EventArgs e)
        {
            string Key = lblAutoKey.Text.Length > 0 ? lblAutoKey.Text : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var rDept = (from c in dcMain.PerformanceDept
                         where c.AutoKey == AutoKey
                         select c).FirstOrDefault();

            if (rDept == null)
                return;

            var MainCode = rDept.PerformanceMainCode;
            var DeptCode = rDept.Code;
            var CompCode = "A";

            var rMain = (from c in dcMain.PerformanceMain
                         where c.Code == MainCode
                         select c).FirstOrDefault();

            if (rMain != null)
            {
                var EmpCategoryCode = rMain.EmpCategoryCode;

                var rsRatingGroup = (from c in dcMain.PerformanceRatingGroup
                                     select c).ToList();

                var rsRating = (from c in dcMain.PerformanceRating
                                where c.EmpCategoryCode == EmpCategoryCode
                                && c.CompCode == CompCode
                                select c).ToList();

                var rsDeptRating = (from c in dcMain.PerformanceDeptRating
                                    where c.PerformanceMainCode == MainCode
                                    && c.PerformanceDeptCode == DeptCode
                                    select c).ToList();

                foreach (var item in lvMain.Items)
                {
                     AutoKey = Convert.ToInt32(item.GetDataKeyValue("AutoKey"));

                    var txtNumPerNewObj = item.FindControl("txtNumPerNew");
                    var ttNumPerNewObj = item.FindControl("ttNumPerNew");

                    if (AutoKey >= 0)
                    {
                        var txtNumPerNew = txtNumPerNewObj as RadNumericTextBox;
                        var ttNumPerNew = ttNumPerNewObj as RadToolTip;

                        var rDeptRating = rsDeptRating.FirstOrDefault(p => p.AutoKey == AutoKey);
                        if (rDeptRating != null)
                        {
                            var NumPerNew = "評等限制條件：";

                            var rRating = rsRating.FirstOrDefault(p => p.Code == rDeptRating.PerformanceRatingCode);
                            if (rRating != null)
                            {
                                NumPerNew += "<br>人數上限：" + rRating.NumPerMax + "%";
                                NumPerNew += "<br>人數下限：" + rRating.NumPerMin + "%";

                                var rRatingGroup = rsRatingGroup.FirstOrDefault(p => p.Code == rRating.PerformanceRatingGroupCode);
                                if (rRatingGroup != null)
                                {
                                    var rsRatingTemp = rsRating.Where(p => p.PerformanceRatingGroupCode == rRatingGroup.Code).OrderBy(p => p.Sort).ToList();
                                    var Temp = "(";
                                    foreach (var rRatingTemp in rsRatingTemp)
                                        Temp += "[" + rRatingTemp.Name + "]";
                                    Temp += ")";

                                    NumPerNew += "<br>評等總合限制條件：" + Temp;
                                    NumPerNew += "<br>人數上限：" + rRatingGroup.NumPerMax + "%";
                                    NumPerNew += "<br>人數下限：" + rRatingGroup.NumPerMin + "%";
                                }
                            }

                            ttNumPerNew.TargetControlID = txtNumPerNew.ClientID;
                            ttNumPerNew.Text = NumPerNew;
                        }
                    }
                }
            }
        }

        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var Msg = SaveRating();

            if (Msg.Length == 0)
            {
                Msg = "儲存成功";
                Response.Redirect("ManageFlowDept.aspx");
            }
            else
                lblMsg.Text = Msg;
        }

        public string SaveRating()
        {
            var Msg = "";

            string Key = lblAutoKey.Text.Length > 0 ? lblAutoKey.Text : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var rDept = (from c in dcMain.PerformanceDept
                         where c.AutoKey == AutoKey
                         select c).FirstOrDefault();

            if (rDept == null)
                return "部門不存在"; ;

            var MainCode = rDept.PerformanceMainCode;
            var DeptCode = rDept.Code;
            var CompCode = "A";

            var rMain = (from c in dcMain.PerformanceMain
                         where c.Code == MainCode
                         select c).FirstOrDefault();

            if (rMain != null)
            {
                var EmpCategoryCode = rMain.EmpCategoryCode;

                var rsRating = (from c in dcMain.PerformanceRating
                                where c.EmpCategoryCode == EmpCategoryCode
                                && c.CompCode == CompCode
                                select c).ToList();

                var rsDeptRating = (from c in dcMain.PerformanceDeptRating
                                    where c.PerformanceMainCode == MainCode
                                    && c.PerformanceDeptCode == DeptCode
                                    select c).ToList();

                var NumPerTotal = 0;
                bool NumPerRange = true;
                Dictionary<string, int> dc = new Dictionary<string, int>();
                foreach (var item in lvMain.Items)
                {
                    var txtNumPerNewObj = item.FindControl("txtNumPerNew");

                    if (txtNumPerNewObj != null)
                    {
                         AutoKey = Convert.ToInt32(item.GetDataKeyValue("AutoKey"));

                        var r = rsDeptRating.FirstOrDefault(p => p.AutoKey == AutoKey);
                        if (r != null)
                        {
                            var txtNumPerNew = txtNumPerNewObj as RadNumericTextBox;
                            var NumPer = txtNumPerNew.Text.ParseInt(0);
                            r.NumPer = NumPer;

                            var RatingCode = r.PerformanceRatingCode;
                            var rRating = rsRating.FirstOrDefault(p => p.Code == RatingCode);
                            if (rRating == null)
                            {
                                Msg = "評等代碼不存在(系統錯誤)";
                                break;
                            }

                            //群組的總和
                            var RatingGroupCode = rRating.PerformanceRatingGroupCode;
                            if (RatingGroupCode.Length > 0)
                                if (dc.ContainsKey(RatingGroupCode))
                                    dc[RatingGroupCode] += NumPer;
                                else dc.Add(RatingGroupCode, NumPer);

                            //每個項目需檢核是否有在區間內
                            //總合所有項目必須100%
                            NumPerRange = rsRating.Any(p => p.Code == RatingCode && p.NumPerMin <= NumPer && NumPer <= p.NumPerMax);
                            NumPerTotal += NumPer;

                            if (!NumPerRange)
                                break;
                        }
                    }
                }

                if (!NumPerRange)
                {
                    Msg = "評等人數不符規範，請調整！";
                    return Msg;
                }

                if (NumPerTotal != 100)
                {
                    Msg = "評等總合必須剛好100%";
                    return Msg;
                }

                var ListRatingGroupCode = dc.Select(p => p.Key).ToList();
                var rsRatingGroup = (from c in dcMain.PerformanceRatingGroup
                                     where ListRatingGroupCode.Contains(c.Code)
                                     select c).ToList();

                NumPerRange = true;
                foreach (var rRatingGroup in rsRatingGroup)
                {
                    var NumPer = dc[rRatingGroup.Code];
                    NumPerRange = rRatingGroup.NumPerMin <= NumPer && NumPer <= rRatingGroup.NumPerMax;

                    if (!NumPerRange)
                        break;
                }

                if (!NumPerRange)
                {
                    Msg = "所有評等人數必須在限定範圍內(群組總合)";
                    return Msg;
                }

                dcMain.SubmitChanges();

                oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(rsDeptRating), "", "Performance-儲存評等", "", _User.UserCode);
            }

            return Msg;
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (UnobtrusiveSession.Session["ActivePage"] != null)
            {
                var ReturnPage = (string)UnobtrusiveSession.Session["ActivePage"];

                Response.Redirect(ReturnPage);
            }
            else
                Response.Redirect("Index.aspx");
        }

    }
}