using Bll.Dept.Vdb;
using Bll.Performance.Vdb;
using Bll.Tools;
using Dal;
using Dal.Dao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Performance
{
    public partial class MainDeptRating : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;

                ddlMain_DataBind();
                ddlDept_DataBind();
            }

            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnExportExcel);

            lblMsg.Text = "";
        }

        public void ddlMain_DataBind()
        {
            var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);
            var rs = oPerformance.GetPerformanceMain("01");

            var ListDeptCode = dcMain.PerformanceDept.Where(p => p.ManagerId == _User.UserCode).Select(p => p.PerformanceMainCode).ToList();

            rs = rs.Where(p => ListDeptCode.Contains(p.Value)).ToList();

            if (rs.Count == 0)
            {
                lblMsg.Text = "您權限不足或目前還沒有開始打考核";
                return;
            }

            ddlMain.DataSource = rs;
            ddlMain.DataTextField = "Text";
            ddlMain.DataValueField = "Value";
            ddlMain.DataBind();


            if (UnobtrusiveSession.Session["MainCode"] != null)
            {
                var MainCode = UnobtrusiveSession.Session["MainCode"].ToString();
                if (ddlMain.FindItemByValue(MainCode) != null)
                    ddlMain.FindItemByValue(MainCode).Selected = true;
            }

            var ListMainCode = rs.Select(p => p.Value).ToList();
        }

        protected void ddlMain_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            ddlDept_DataBind();
        }

        public void ddlDept_DataBind()
        {
            if (ddlMain.SelectedItem == null)
                return;

            var MainCode = ddlMain.SelectedItem.Value;

            var EmpId = _User.UserCode;

            //取得所有部門
            var rsDeptAll = (from c in dcMain.PerformanceDept
                             where c.PerformanceMainCode == MainCode
                             select new DeptRow
                             {
                                 Code = c.Code,
                                 Name = c.Name,
                                 ParentCode = c.ParentCode,
                                 Id = 0,
                                 ParentId = 0,
                                 ManagerId = c.ManagerId,
                                 PathCode = c.PathCode,
                                 PathName = c.PathName,
                                 DeptTree = c.DeptTree,
                                 DeptTreeB = c.DeptTreeB,
                             }).ToList();

            //取得可簽核部門
            var rsDept = (from c in rsDeptAll
                          where c.ManagerId == EmpId
                          select c).ToList();

            if (rsDept.Count == 0)
            {
                lblMsg.Text = "沒有產生部門";
                return;
            }

            var DeptCode = rsDept.OrderByDescending(p => p.DeptTree).First().Code;

            //加入子部門
            rsDept = rsDeptAll.Where(p => rsDept.Any(c => p.PathCode.IndexOf(c.PathCode) >= 0)).ToList();

            var ListDeptCode = rsDept.Select(p => p.Code).ToList();

            //加入目前可視部門(無踢除重複)
            //lblAllDeptCode.Text = string.Join(",", ListDeptCode.Select(x => x).ToArray<string>());

            //取得人員資料
            var rsBase = (from c in dcMain.PerformanceBase
                          where c.PerformanceMainCode == MainCode
                          && ListDeptCode.Contains(c.PerformanceDeptCode)
                           && c.EmpId != EmpId
                          select c).ToList();

            //取得可傳簽的主流程
            var rsFlowMain = (from f in dcMain.PerformanceFlow
                              join n in dcMain.PerformanceFlowNode on f.Code equals n.PerformanceFlowCode
                              where f.PerformanceMainCode == MainCode
                              && ListDeptCode.Contains(f.PerformanceDeptCode)
                              && !f.IsCancel
                              && !f.IsError
                              && !f.IsFinish
                              && !n.IsFinish
                              && n.EmpIdDefault == EmpId
                              select f).ToList();

            //將代碼及新的id暫存於dc裡
            var ListId = new Dictionary<string, int>();

            //處理代碼資料
            int i = 1;
            foreach (var rVdb in rsDept)
            {
                //產生id
                ListId.Add(rVdb.Code, i);
                rVdb.Id = i;

                i++;
            }

            //計算兩項獎金 本部獎金 / 部門及其向下的獎金

            var DeptTree = rsDept.Max(p => p.DeptTree);

            foreach (var r in rsDept)
            {
                //將上層的代碼轉換為id
                if (ListId.ContainsKey(r.ParentCode))
                    r.ParentId = ListId[r.ParentCode];
                else
                    r.ParentId = 0;  //如果沒有找到 就以0取代

                //待審核
                r.Name = "<font color='#999999'>" + r.Name + "</font>";
                if (rsFlowMain.Any(p => p.PerformanceDeptCode == r.Code))
                    r.Name = "<font color='#7d0000'>" + r.Name + "</font>";

                //統計人數
                var rsBaseByDeptCode = rsBase.Where(p => p.PerformanceDeptCode == r.Code).ToList();
                if (rsBaseByDeptCode.Count > 0)
                    r.Name += "(" + rsBaseByDeptCode.Count + ")";

                if (DeptTree >= r.DeptTreeB)
                {
                    //計算部門及其向下可用獎金
                    ListDeptCode = rsDept.Where(p => p.PathCode.IndexOf("/" + r.Code + "/") >= 0).Select(p => p.Code).ToList();
                    var BonusAdjust = -rsBase.Where(p => ListDeptCode.Contains(p.PerformanceDeptCode)).Sum(p => p.BonusAdjust);
                    r.Name += "｜";
                    r.Name += String.Format("${0:N0}", BonusAdjust);

                    //計算部門及其向下實發總獎金
                    r.Name += "｜";
                    r.Name += String.Format("${0:N0}", rsBase.Where(p => ListDeptCode.Contains(p.PerformanceDeptCode)).Sum(p => p.BonusReal));
                }
            }

            ddlDept.DataSource = rsDept;
            ddlDept.DataValueField = "Code";
            ddlDept.DataTextField = "Name";
            ddlDept.DataFieldID = "Id";
            ddlDept.DataFieldParentID = "ParentId";
            ddlDept.DataBind();

            ddlDept.ExpandAllDropDownNodes();

            if (UnobtrusiveSession.Session["SelectDeptCode"] != null)
                DeptCode = UnobtrusiveSession.Session["SelectDeptCode"].ToString();

            ddlDept.SelectedValue = DeptCode;

        }

        protected void ddlDept_EntryAdded(object sender, DropDownTreeEntryEventArgs e)
        {
            lvMain.Rebind();
        }

        public void _DataBind(string DeptCode)
        {

        }

        public List<RatingRow> ListRating
        {
            get
            {
                var Value = new List<RatingRow>();
                if (WebPage.DataCache &&
                    UnobtrusiveSession.Session["Rating"] != null)
                {
                    Value = (List<RatingRow>)UnobtrusiveSession.Session["Rating"];
                }
                else
                {
                    if (ddlMain.SelectedItem == null || ddlDept.SelectedValue.Length == 0)
                    {
                        lblMsg.Text = "資訊錯誤";
                        return Value;
                    }

                    var MainCode = ddlMain.SelectedItem.Value;
                    var DeptCode = ddlDept.SelectedValue;

                    var EmpId = _User.UserCode;

                    var rMain = (from c in dcMain.PerformanceMain
                                 where c.Code == MainCode
                                 select c).FirstOrDefault();

                    if (rMain == null)
                    {
                        lblMsg.Text = "資訊錯誤";
                        return Value;
                    }

                    var EmpCategoryCode = rMain.EmpCategoryCode;

                    var rsRating = (from c in dcMain.PerformanceRating
                                    where c.EmpCategoryCode == EmpCategoryCode
                                    orderby c.Sort
                                    select c).ToList();

                    var rsDeptRating = (from c in dcMain.PerformanceDeptRating
                                        where c.PerformanceMainCode == MainCode
                                       && c.PerformanceDeptCode == DeptCode
                                        select c).ToList();

                    Value = (from c in rsRating
                             join dr in rsDeptRating on c.Code equals dr.PerformanceRatingCode
                             orderby c.EmpCategoryCode, c.Sort
                             select new RatingRow
                             {
                                 AutoKey = dr.AutoKey,
                                 CompName = "",
                                 EmpCategoryCode = c.EmpCategoryCode,
                                 EmpCategoryName = "",
                                 Code = c.Code,
                                 Name = c.Name,
                                 BonusPerMax = c.BonusPerMax,
                                 BonusPerMin = c.BonusPerMin,
                                 NumPerMax = c.NumPerMax,
                                 NumPerMin = c.NumPerMin,
                                 NumPer = c.NumPer,
                                 NumPerNew = dr.NumPer,
                                 Note = c.Note,
                                 Sort = c.Sort,
                                 Num = c.Num,
                                 CheckNote = c.CheckNote ? "是" : "否",
                                 UpdateMan = c.UpdateMan,
                                 UpdateDate = c.UpdateDate.GetValueOrDefault(oMainDao._NowDate),
                             }).ToList();


                    var rsEmpCategory = oMainDao.ShareCodeNameCode("EmpCategory");

                    foreach (var r in Value)
                    {
                        r.EmpCategoryName = rsEmpCategory.FirstOrDefault(p => p.Code == r.EmpCategoryCode)?.Name ?? r.EmpCategoryName;
                    }

                    UnobtrusiveSession.Session["Rating"] = Value;
                }

                return Value;
            }
        }

        public class RatingRow
        {
            public int AutoKey { get; set; }
            public string CompName { get; set; }
            public string EmpCategoryCode { get; set; }
            public string EmpCategoryName { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public int BonusPerMax { get; set; }
            public int BonusPerMin { get; set; }
            public int NumPerMax { get; set; }
            public int NumPerMin { get; set; }
            public int NumPer { get; set; }
            public int NumPerNew { get; set; }
            public string Note { get; set; }
            public int Sort { get; set; }
            public int Num { get; set; }
            public string CheckNote { get; set; }
            public string UpdateMan { get; set; }
            public DateTime UpdateDate { get; set; }
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            var rs = ListRating;

            //處理html

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("PerformanceRating");
            AccessData.SetColumnsName(dt, ListGroupCode);

            var stream = CNPOI.RenderDataTableToExcel(dt);
            var FileName = Guid.NewGuid().ToString() + ".xls";

            Byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, int.Parse(stream.Length.ToString()));
            stream.Close();

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8));
            //Response.ContentType = "application/vnd.ms-excel";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
            Response.Flush();
            Response.End();
        }


        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            lvMain.DataSource = ListRating;

            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }

        protected void lvMain_DataBound(object sender, EventArgs e)
        {
            if (ddlMain.SelectedItem == null || ddlDept.SelectedValue.Length == 0)
            {
                lblMsg.Text = "資訊錯誤";
                return;
            }

            var MainCode = ddlMain.SelectedItem.Value;
            var DeptCode = ddlDept.SelectedValue;

            var EmpId = _User.UserCode;

            var rMain = (from c in dcMain.PerformanceMain
                         where c.Code == MainCode
                         select c).FirstOrDefault();

            if (rMain == null)
            {
                lblMsg.Text = "資訊錯誤";
                return;
            }

            var EmpCategoryCode = rMain.EmpCategoryCode;

            var rsRatingGroup = (from c in dcMain.PerformanceRatingGroup
                                 select c).ToList();

            var rsRating = (from c in dcMain.PerformanceRating
                            where c.EmpCategoryCode == EmpCategoryCode
                            select c).ToList();

            var rsDeptRating = (from c in dcMain.PerformanceDeptRating
                                where c.PerformanceMainCode == MainCode
                                && c.PerformanceDeptCode == DeptCode
                                select c).ToList();

            foreach (var item in lvMain.Items)
            {
                var AutoKey = Convert.ToInt32(item.GetDataKeyValue("AutoKey"));

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
        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();

        }

        protected void btnSaveRating_Click(object sender, EventArgs e)
        {
            var Msg = SaveRating();

            if (Msg.Length == 0)
                lblMsg.Text = "儲存成功";

            lblMsg.Text = Msg;
        }

        public string SaveRating()
        {
            var Msg = "";

            {

                {
                    if (ddlMain.SelectedItem == null || ddlDept.SelectedValue.Length == 0)
                    {
                        Msg = "資訊錯誤";
                        return Msg;
                    }

                    var MainCode = ddlMain.SelectedItem.Value;
                    var DeptCode = ddlDept.SelectedValue;

                    var EmpId = _User.UserCode;

                    var rMain = (from c in dcMain.PerformanceMain
                                 where c.Code == MainCode
                                 select c).FirstOrDefault();

                    if (rMain == null)
                    {
                        Msg = "資訊錯誤";
                        return Msg;
                    }

                    var EmpCategoryCode = rMain.EmpCategoryCode;

                    var rsRating = (from c in dcMain.PerformanceRating
                                    where c.EmpCategoryCode == EmpCategoryCode
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
                            var AutoKey = Convert.ToInt32(item.GetDataKeyValue("AutoKey"));

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
                }
            }

            return Msg;
        }
    }
}