using System;
using System.Collections.Generic;
using System.Linq;
using BL;
using Telerik.Web.UI;

public partial class ManageQuestionary : JBWebPage
{
    private string winUrl = "SummuryQuestionary.aspx";
    private QAMaster_Repo qamRepo = new QAMaster_Repo();

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
        GridDataItem item = e.Item as GridDataItem;
        if (e.CommandName.Equals("Summary"))
        {
            RadWindow1.NavigateUrl = winUrl + "?Id=" + item["Id"].Text;
            RadWindow1.Height = 600;
            RadWindow1.Width = 800;
            RadWindow1.VisibleOnPageLoad = true;
        }
        if (e.CommandName.Equals("cmdDelete"))
        {
            QA_Published_Repo qapRepo = new QA_Published_Repo();
            var qapObj = qapRepo.GetByPk(Convert.ToInt32(item["Id"].Text));
            qapObj.Cancel = true;
            qapRepo.Update(qapObj);
            qapRepo.Save();

            gvQList.Rebind();
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
                var list = qapRepo.GetByDateRange_Dlo(dpB.SelectedDate.Value, dpE.SelectedDate.Value);
                gvQList.DataSource = (from c in list
                                      select new
                                      {
                                          c.FillFormDatetimeB,
                                          c.FillFormDatetimeE,
                                          c.Id,
                                          c.IsPublished,
                                          c.QTplCode,
                                          c.QTpl.Name,
                                          c.ViewSummaryClosed,
                                          c.ViewSummaryOpening,
                                          c.IsAnonymous
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
        }
    }
}