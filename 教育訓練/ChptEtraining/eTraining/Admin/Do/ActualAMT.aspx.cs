using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class eTraining_Admin_Do_SetCourse6 : JBWebPage
{
    dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblClassID.Text = Request.QueryString["ID"].ToString();
            loadActualAMT();
        }
    }
    protected void gvCostItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        int classID = Convert.ToInt32(Request.QueryString["ID"].ToString());

        var data = (from c in dcTraining.trTrainingActualCost
                    where c.trCostItem_sCode == gvCostItem.SelectedValue
                    && c.iClassAutoKey == classID
                    select c).FirstOrDefault();

        if (data == null)
        {
            trTrainingActualCost obj = new trTrainingActualCost();            
            obj.iClassAutoKey = classID;
            obj.iAmt = 0;
            obj.trCostItem_sCode = gvCostItem.SelectedValue.ToString();
            obj.dKeyDate = DateTime.Now;
            obj.sKeyMan = User.Identity.Name;
            dcTraining.trTrainingActualCost.InsertOnSubmit(obj);
            dcTraining.SubmitChanges();
            
            gvActualAmt.Rebind();
            AlertMsg("新增完成");
        }
    }
    protected void btnSaveCost_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in gvActualAmt.Items)
        {
            int key = Convert.ToInt32(item.GetDataKeyValue("iAutoKey").ToString());

            var data = (from c in dcTraining.trTrainingActualCost
                        where c.iAutoKey == key
                        select c).FirstOrDefault();

            if (data != null)
            {
                RadNumericTextBox ntb = item.Cells[2].FindControl("ntb_iAmt") as RadNumericTextBox;
                if (ntb != null)
                {
                    data.iAmt = Convert.ToInt32(ntb.Text);
                    data.dKeyDate = DateTime.Now;
                    data.sKeyMan = User.Identity.Name;
                    dcTraining.SubmitChanges();
                    AlertMsg("已更新");
                }
            }
        }
        //開課資料的EstimateAmt儲存
        saveClassActualAmt();
        loadActualAMT();
    }

    //存檔開課資料檔的 EstimateAmt
    private void saveClassActualAmt()
    {
        var dataList = (from c in dcTraining.trTrainingActualCost
                        where c.iClassAutoKey == Convert.ToInt32(lblClassID.Text)
                        select c).ToList();

        int iAmt = 0;

        foreach (var data in dataList)
        {
            iAmt = iAmt + data.iAmt;
        }

        var cls = (from c in dcTraining.trTrainingDetailM
                   where c.iAutoKey == Convert.ToInt32(lblClassID.Text)
                   select c).FirstOrDefault();

        if (cls != null)
        {
            cls.iActualAMT = iAmt;
            dcTraining.SubmitChanges();
        }

    }


    private void loadActualAMT()
    {
        var cls = (from c in dcTraining.trTrainingDetailM
                   where c.iAutoKey == Convert.ToInt32(lblClassID.Text)
                   select c).FirstOrDefault();

        if (cls != null)
        {
            lblActualAmt.Text = "實際費用：" + cls.iActualAMT.ToString();
        }
    }
    protected void gvActualAmt_ItemDeleted(object sender, GridDeletedEventArgs e)
    {
        saveClassActualAmt();
        loadActualAMT();
    }

    protected void gvCostItem_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    }
    protected void btnAddC_Click(object sender, EventArgs e)
    {
        pnlACost.Visible = false;
        pnlCost.Visible = true;
    }
    protected void btnCostAdd_Click(object sender, EventArgs e)
    {
        pnlACost.Visible = true;
        pnlCost.Visible = false;
    }
    protected void btnCancelC_Click(object sender, EventArgs e)
    {
        btnCostAdd_Click(sender,e);
    }
}