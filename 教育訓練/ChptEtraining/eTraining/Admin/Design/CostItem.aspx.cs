using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eTraining_Admin_Design_CostItem : JBWebPage
{
    private dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = "費用項目";
        }
    }
    protected void btnAddCost_Click(object sender, EventArgs e)
    {
        pnlAddCost.Visible = true;
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        //重新整理不再重覆新增動作
        if (IsRefresh)
        {
            txtsName.Text = string.Empty;
            gvCost.Rebind();
            return;
        }
        List<trCostItem> Cost = new List<trCostItem>();

        string sCode = Guid.NewGuid().ToString(); 

        var r = new trCostItem();

        r.trCostItemCode = sCode;
        r.trCostItemName = txtsName.Text;

        Cost.Add(r);
        try
        {

            dcTrain.trCostItem.InsertAllOnSubmit(Cost);
            dcTrain.SubmitChanges();
            gvCost.Rebind();

            //Show("已加入");

            //清空txt資料
            txtsName.Text = string.Empty;
        }
        catch
        {
            //有時間才做精準錯誤訊息ex:名稱不可重覆
            AlertMsg("新增錯誤");
            txtsName.Text = string.Empty;
        }

        //pnlAddCost.Visible = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //清空txt資料
        txtsName.Text = string.Empty;

        pnlAddCost.Visible = false;
    }
}