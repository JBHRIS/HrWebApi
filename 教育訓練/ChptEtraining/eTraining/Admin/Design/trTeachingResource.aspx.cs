using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eTraining_Admin_Design_trTeachingResource : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = "教學資源";
        }
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {
        //重整時新增動作不會被重覆
        if (IsRefresh)
        {
            txtName.Text = string.Empty;
            gvResource.Rebind();
            return;
        }
        string sCode = Guid.NewGuid().ToString();

        try
        {
            List<trTeachingResource> Resource = new List<trTeachingResource>();

            var r = new trTeachingResource();

            r.ResourceCode = sCode;
            r.ResourceName = txtName.Text;
            Resource.Add(r);

            dcTrain.trTeachingResource.InsertAllOnSubmit(Resource);

            dcTrain.SubmitChanges();
            gvResource.Rebind();

            txtName.Text = string.Empty;

            //Show("已加入");

            //pnlResource.Visible = false;
        }
        catch 
        {
            //有時間再做精準錯誤訊息ex:名稱不可重覆
            AlertMsg("新增錯誤");
            txtName.Text = string.Empty;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        pnlResource.Visible = true;
    }
    protected void RadButton2_Click(object sender, EventArgs e)
    {
        txtName.Text = string.Empty;

        pnlResource.Visible = false;
    }
}