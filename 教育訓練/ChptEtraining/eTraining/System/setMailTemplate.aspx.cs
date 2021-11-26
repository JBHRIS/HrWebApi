using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;

public partial class eTraining_System_setMailTemplate : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            changeMode("v");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (lblMode.Text == "i")
        {
            trMailTemplate obj = new trMailTemplate();

            obj.dKeyDate = DateTime.Now;
            obj.dKeyMan = User.Identity.Name;
            obj.sName = tbName.Text;
            obj.sMailSubject = tbSubject.Text;
            //obj.sMailContent = CKEditorControl1.Text;
            obj.sMailContent = edt.Content;

            dcTraining.trMailTemplate.InsertOnSubmit(obj);
            dcTraining.SubmitChanges();
            gv.Rebind();
            AlertMsg("新增完成");
        }
        else
        {
            var data = (from c in dcTraining.trMailTemplate
                        where c.iAutoKey == Convert.ToInt32(lblAutoKey.Text)
                        select c).FirstOrDefault();

            if (data != null)
            {
                data.dKeyDate = DateTime.Now;
                data.dKeyMan = User.Identity.Name;
                data.sName = tbName.Text;
                data.sMailSubject = tbSubject.Text;
                //data.sMailContent = CKEditorControl1.Text;
                data.sMailContent = edt.Content;
                dcTraining.SubmitChanges();
                gv.Rebind();
                AlertMsg("更新完成");

            }

        }

    }
    protected void gv_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            string key = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"].ToString();
            lblAutoKey.Text = key;
            changeMode("e");

        }
    }

    private void changeMode(string mode)
    {
        lblMode.Text = mode;

        if (mode == "v")
        {

            lblAutoKey.Text = "";


            setPanelDefault();
        }
        else if (mode == "i")
        {
            tbName.Text = "";
            tbSubject.Text = "";
            edt.Content = "";
            //CKEditorControl1.Text = "";
            //pnView.Visible = false;
            //pnEdit.Visible = true;

        }
        else if (mode == "e")
        {
            loadEditData();
            //pnView.Visible = false;
            //pnEdit.Visible = true;

        }
    }

    private void setPanelDefault()
    {
        pnView.Visible = true;
        pnEdit.Visible = true;
    }

    private void loadEditData()
    {
        var data = (from c in dcTraining.trMailTemplate
                    where c.iAutoKey == Convert.ToInt32(lblAutoKey.Text)
                    select c).FirstOrDefault();

        if (data != null)
        {
            tbName.Text = data.sName;
            tbSubject.Text = data.sMailSubject;
            edt.Content = data.sMailContent;
            //CKEditorControl1.Text = data.sMailContent;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        changeMode("i");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        tbName.Text = "";
        tbSubject.Text = "";
        edt.Content = "";
        //CKEditorControl1.Text = "";
    }
    protected void gvNotifyCustomVariable_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        NotifyCustomVariable_Repo ncvRepo = new NotifyCustomVariable_Repo();
        gvNotifyCustomVariable.DataSource = ncvRepo.GetAll();
    }
    protected void gvNotifyCustomVariable_EditCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {

    }
    protected void gvNotifyCustomVariable_ItemUpdated(object sender, Telerik.Web.UI.GridUpdatedEventArgs e)
    {

    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {
        if (tbCode.Text.Trim().Length == 0 || edt2.Content.Trim().Length == 0)
        {
            RadAjaxPanel1.Alert("代碼及替換文字皆需要輸入值");
            return;
        }

        NotifyCustomVariable_Repo ncvRepo = new NotifyCustomVariable_Repo();
        NotifyCustomVariable ncv = ncvRepo.GetByPk(tbCode.Text);
        try
        {
            if (ncv == null)
            {
                ncv = new NotifyCustomVariable();
                ncv.Text = edt2.Content;
                ncv.Code = tbCode.Text;
                ncvRepo.Add(ncv);
                ncvRepo.Save();
            }
            else
            {
                ncv.Text = edt2.Content;
                ncvRepo.Update(ncv);
                ncvRepo.Save();
            }

            gvNotifyCustomVariable.Rebind();
        }
        catch (Exception ex)
        {
            RadAjaxPanel1.Alert(ex.Message);
        }
    }
    protected void gvNotifyCustomVariable_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadNcv(gvNotifyCustomVariable.SelectedValue.ToString());
    }

    private void loadNcv(string Acode)
    {
        NotifyCustomVariable_Repo ncvRepo = new NotifyCustomVariable_Repo();
        NotifyCustomVariable obj = ncvRepo.GetByPk(Acode);
        if (obj == null)
            return;

        NotifyCustomVariable ncv = new NotifyCustomVariable();
        tbCode.Text = obj.Code;
        edt2.Content = obj.Text;
    }
}