using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using BL;
using Telerik.Web.UI;

public partial class EmpViewQuestionary : JBWebPage
{
    private string[] DateTimeList = {
                            "yyyy/M/d tt hh:mm:ss",
                            "yyyy/MM/dd tt hh:mm:ss",
                            "yyyy/MM/dd HH:mm:ss",
                            "yyyy/M/d HH:mm:ss",
                            "yyyy/M/d",
                            "yyyy/MM/dd",
                            "yyyy/MM/dd HHmm",
    "yyyy/M/d HHmm"
                        };

    private string winUrl = "SummuryQuestionary.aspx";
    private QAMaster_Repo qamRepo = new QAMaster_Repo();
    private QA_Published_Repo qapRepo = new QA_Published_Repo();

    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gvS);
        RadWindow1.VisibleOnPageLoad = false;
        if (!IsPostBack)
        {
            SiteHelper sh = new SiteHelper();
            sh.SetDateRangeForLatestYear(dpB, dpE);
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        pnlNobrList.Visible = false;
        pnlQList.Visible = true;
    }

    protected void gvQList_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridDataItem item = gvQList.SelectedItems[0] as GridDataItem;
        lblQcode.Text = item["QTplCode"].Text;

        pnlNobrList.Visible = true;
        pnlQList.Visible = false;

        gvS.Visible = true;

        gvS.Rebind();
    }

    protected void gvQList_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName.Equals("Summary"))
        {
            GridDataItem item = e.Item as GridDataItem;

            RadWindow1.NavigateUrl = winUrl + "?Id=" + item["Id"].Text;
            RadWindow1.Height = 600;
            RadWindow1.Width = 800;
            RadWindow1.VisibleOnPageLoad = true;
        }
    }

    protected void gvS_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadWindow1.Height = 600;
        RadWindow1.Width = 800;
        RadWindow1.VisibleOnPageLoad = true;
        RadWindow1.NavigateUrl = @"~/Questionary/QFillInQuestionary.aspx?" + Encrypt.EncryptInforamtion(@"Code=" + gvS.SelectedValue + @"&Mode=View");
    }

    protected void gvS_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        var editableItem = ((GridEditableItem)e.Item);
        var iAutoKey = (int)editableItem.GetDataKeyValue("Id");

        var obj = qamRepo.GetByPk(iAutoKey);
        if (obj != null)
        {
            try
            {
                //update entity's state
                editableItem.UpdateValues(obj);
                qamRepo.Update(obj);
                qamRepo.Save();
            }
            catch (System.Exception)
            {
                RadAjaxPanel1.Alert("錯誤，請確認輸入格式正確");
                e.Canceled = true;
            }
        }
    }

    protected void gvQList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (e.RebindReason == GridRebindReason.ExplicitRebind)
        {
            if (dpE.SelectedDate.HasValue && dpB.SelectedDate.HasValue)
            {
                QA_Published_Repo qapRepo = new QA_Published_Repo();
                var list = qapRepo.GetByDateRangePublished_Dlo(dpB.SelectedDate.Value, dpE.SelectedDate.Value);

                gvQList.DataSource = (from c in list
                                      select new
                                      {
                                          c.FillFormDatetimeB,
                                          c.FillFormDatetimeE,
                                          c.Id,
                                          c.IsPublished,
                                          c.QTplCode,
                                          c.QTpl.Name,
                                          c.IsAnonymous,
                                          c.ViewSummaryClosed,
                                          c.ViewSummaryOpening
                                      }).OrderByDescending(p => p.FillFormDatetimeE).ToList();
            }
        }
    }

    protected void gvS_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        List<QAMaster> list = new List<QAMaster>();
        if (e.RebindReason == GridRebindReason.ExplicitRebind)
        {
            QAMaster_Repo qamRepo = new QAMaster_Repo();
            list.AddRange(qamRepo.GetByPublishId_Dlo(Convert.ToInt32(gvQList.SelectedValue)));
            Session[SessionName] = list;
        }
        else
        {
            var tList = Session[SessionName] as List<QAMaster>;
            if (tList != null)
                list.AddRange(tList);
        }

        gvS.DataSource = (from c in list
                          select new
                          {
                              NAME_C = c.BASE.NAME_C,
                              NOBR = c.BASE.NOBR,
                              DEPT = c.BASE.BASETTS[0].DEPT1.D_NO,
                              c.BASE.BASETTS[0].DEPT1.D_NAME,
                              c.WriteDate,
                              Id = c.Id
                          }).ToList();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        gvQList.Rebind();
    }

    protected void gvQList_ItemDataBound(object sender, GridItemEventArgs e)
    {
        GridDataItem item = e.Item as GridDataItem;
        if (item != null)
        {
            int id = Convert.ToInt32(item["Id"].Text);
            item["Percent"].Text = qamRepo.CountFilledByPublishId(id).ToString() + " / " + qamRepo.CountByPublishId(id).ToString();

            DateTime dateB = DateTime.ParseExact(item["FillFormDatetimeB"].Text, DateTimeList, null, DateTimeStyles.AllowWhiteSpaces);
            DateTime dateE = DateTime.ParseExact(item["FillFormDatetimeE"].Text, DateTimeList, null, DateTimeStyles.AllowWhiteSpaces);

            //顯示統計
            var ckC = item["ViewSummaryClosed"].Controls[0] as CheckBox;
            var ckO = item["ViewSummaryOpening"].Controls[0] as CheckBox;
            var b = qapRepo.CheckRightToViewSummary(dateB, dateE, ckC.Checked, ckO.Checked);

            if (b)
            {
                foreach (WebControl c in item["Summary"].Controls)
                    c.Visible = true;
            }
            else
            {
                foreach (WebControl c in item["Summary"].Controls)
                    c.Visible = false;
            }

            //顯示細節(匿名)
            var ckA = item["IsAnonymous"].Controls[0] as CheckBox;
            //是匿名，看不到別人的問卷
            if (ckA.Checked)
            {
                foreach (WebControl c in item["Select"].Controls)
                    c.Visible = false;
            }
            //不是匿名，看的到別人的問卷
            else
            {
                foreach (WebControl c in item["Select"].Controls)
                    c.Visible = true;
            }
        }
    }
}