using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eTraining_Admin_Design_trClassroom : JBWebPage
{
    private dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = "訓練地點";
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        pnlClassroom.Visible = true;           
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtName.Text = string.Empty;
        txtaddr.Text = string.Empty;

        pnlClassroom.Visible = false;
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        //重整時新增動作不會被重覆
        if (IsRefresh)
        {
            txtaddr.Text = string.Empty;
            txtName.Text = string.Empty;
            gvClassroom.Rebind();
            return;
        }



        string sCode = Guid.NewGuid().ToString();

        try
        {
            var r = new trClassroom();

            r.sCode = sCode;
            r.sName = txtName.Text;
            r.sAddr = txtaddr.Text;
            r.sKeyMan = User.Identity.Name;
            r.dKeyDate = DateTime.Now;

            dcTrain.trClassroom.InsertOnSubmit(r);
            dcTrain.SubmitChanges();
            gvClassroom.Rebind();

            //Show("已加入");
            txtName.Text = string.Empty;
            txtaddr.Text = string.Empty;


        }
        catch
        {
            //有時間才做精準錯誤訊息ex:名稱不可重覆
            AlertMsg("新增錯誤");
            txtName.Text = string.Empty;
            txtaddr.Text = string.Empty;
        }
    }
}