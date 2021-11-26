using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eTraining_Admin_Design_trKnotTeaches : JBWebPage
{
    private dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = "結訓條件";
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        pnlKnotTeaches.Visible = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
        txtName.Text = string.Empty;
        pnlKnotTeaches.Visible = false;
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        //重整時不再重覆新增動作
        if (IsRefresh)
        {
            txtName.Text = string.Empty;
            gvKnotTeaches.Rebind();
            return;
        }
        string sCode = Guid.NewGuid().ToString();

        try
        {
            List<trKnotTeaches> Knot = new List<trKnotTeaches>();

            var r = new trKnotTeaches();

            r.KnotTeachesCode = sCode;
            r.KnotTeachesName = txtName.Text;

            Knot.Add(r);

            dcTrain.trKnotTeaches.InsertAllOnSubmit(Knot);
            dcTrain.SubmitChanges();
            gvKnotTeaches.Rebind();

            //Show("已加入");
            
            txtName.Text = string.Empty;
        }
        catch
        {
            //有時間才做判斷錯誤訊息ex:名稱不可重覆
            AlertMsg("新增錯誤");
            txtName.Text = string.Empty;
        }
    }
}