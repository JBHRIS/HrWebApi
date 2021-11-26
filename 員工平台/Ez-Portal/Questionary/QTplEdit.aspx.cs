using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

public partial class eTraining_Questionary_QTplEdit : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (Request.QueryString["Id"] == null)
        {
            pnlAdd.Visible = true;
            pnlEdit.Visible = false;
        }
        else
        {
            loadData(Request.QueryString["Id"]);
            pnlAdd.Visible = false;
            pnlEdit.Visible = true;
        }
    }

    private void loadData(string id)
    {
        sCodeTextBox.Text = id;
        QTpl_Repo qRepo = new QTpl_Repo();
        var o = qRepo.GetByPk(id);
        if (o != null)
        {
            tbName_E.Text = o.Name;
            etHeader_E.Content = o.HeaderText;
            etFooter_E.Content = o.FooterText;
        }
    }

    protected void fv_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        e.NewValues["KeyMan"] = User.Identity.Name;
        e.NewValues["KeyDate"] = DateTime.Now;
    }

    protected void fv_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
    }

    protected void fv_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        e.Values["Code"] = Guid.NewGuid().ToString();
        e.Values["KeyMan"] = User.Identity.Name;
        e.Values["KeyDate"] = DateTime.Now;
        e.Values["BeenUsed"] = false;
    }

    protected void fv_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
    }

    protected void fv_ItemDeleting(object sender, FormViewDeleteEventArgs e)
    {
    }

    protected void fv_ItemDeleted(object sender, FormViewDeletedEventArgs e)
    {
    }

    protected void InsertCancelButton_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), this.GetType().ToString(), "CancelEdit();", true);
    }

    protected void UpdateCancelButton_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), this.GetType().ToString(), "CancelEdit();", true);
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        QTpl_Repo qRepo = new QTpl_Repo();
        var o = qRepo.GetByPk(sCodeTextBox.Text);
        if (o != null)
        {
            o.Name = tbName_E.Text;
            o.HeaderText = etHeader_E.Content;
            o.FooterText = etFooter_E.Content;
            qRepo.Update(o);
            qRepo.Save();
        }
        ClientScript.RegisterStartupScript(Page.GetType(), this.GetType().ToString(), "CloseAndRebind();", true);
    }

    protected void InsertButton_Click(object sender, EventArgs e)
    {
        QTpl_Repo qRepo = new QTpl_Repo();
        QTpl o = new QTpl();
        o.BeenUsed = false;
        o.Code = Guid.NewGuid().ToString();
        o.FillerCategory = cbxFillerCategory.SelectedValue;
        o.FillFormSpan = Convert.ToInt32(ntbFillFormSpan.Value);
        o.FooterText = etFooterText.Content;
        o.HeaderText = etHeaderText.Content;
        o.Name = sNameTextBox.Text;
        o.KeyDate = DateTime.Now;
        o.KeyMan = Juser.Nobr;
        qRepo.Add(o);

        qRepo.Save();

        ClientScript.RegisterStartupScript(Page.GetType(), this.GetType().ToString(), "CloseAndRebind('navigateToInserted');", true);
    }
}