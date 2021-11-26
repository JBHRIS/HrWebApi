using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Telerik.Web.UI;

public partial class Admin_Design_trTeachingMethod : JBWebPage
{
    private dcTrainingDataContext dcTrain = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = "教學方式";
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        pnlMethod.Visible = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {        
        txtName.Text = string.Empty;

        pnlMethod.Visible = false;
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        //重整時新增動作不會被重覆
        if (IsRefresh)
        {
            txtName.Text = string.Empty;
            gvMethod.Rebind();
            return;
        }
        string sCode = Guid.NewGuid().ToString(); 

        try
        {
            List<trTeachingMethod> Method = new List<trTeachingMethod>();

            var r = new trTeachingMethod();

            r.sCode = sCode;
            r.sName = txtName.Text;

            Method.Add(r);

            dcTrain.trTeachingMethod.InsertAllOnSubmit(Method);
            dcTrain.SubmitChanges();
            gvMethod.Rebind();

            //Show("已加入");
                        
            txtName.Text = string.Empty;
        }
        catch (Exception ex)
        {
            AlertMsg("新增錯誤");
            txtName.Text = string.Empty;
        }
    }
}