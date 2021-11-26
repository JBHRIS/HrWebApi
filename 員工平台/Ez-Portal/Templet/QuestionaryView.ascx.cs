using System;
using System.Linq;
using BL;
using Telerik.Web.UI;

public partial class Templet_QuestionaryView : JBUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnHeader_CheckedChanged(this, null);
        }
    }

    protected void gv_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        if (e.RebindReason == Telerik.Web.UI.GridRebindReason.InitialLoad || e.RebindReason == Telerik.Web.UI.GridRebindReason.ExplicitRebind)
        {
            QAMaster_Repo qamRepo = new QAMaster_Repo();
            var list = qamRepo.GetByNeedFillIn(Juser.Nobr, DateTime.Now);

            if (list.Count == 0)
                this.Visible = false;
            else
                this.Visible = true;

            gv.DataSource = (from c in list
                             select new { c.Id, c.QA_Published.QTpl.Name }).ToList();
        }
    }

    protected void gv_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName.Equals("FillIn"))
        {
            GridDataItem item = null;
            if (e.Item is GridDataItem)
                item = e.Item as GridDataItem;

            string url = @"~/Questionary/QFillInQuestionary.aspx?" + Encrypt.EncryptInforamtion("Code=" + item["Id"].Text);
            Response.Redirect(url);
        }
    }

    protected void btnHeader_CheckedChanged(object sender, EventArgs e)
    {
        if (btnHeader.Checked)
        {
            gv.Rebind();
            gv.Visible = true;
        }
        else
            gv.Visible = false;
    }
}