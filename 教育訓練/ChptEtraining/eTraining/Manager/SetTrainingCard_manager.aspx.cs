using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Repo;

public partial class eTraining_Manager_SetTrainingCard_manager : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gv);
        if (!IsPostBack)
        {
            var dept = (from c in dcTrain.BASETTS
                        where c.NOBR == User.Identity.Name
                        && DateTime.Now.Date >= c.ADATE && DateTime.Now.Date <= c.DDATE
                        && new string[] { "1", "4", "6" }.Contains(c.TTSCODE)
                        select c).FirstOrDefault();

            if (dept != null)
            {
                lblDept.Text = dept.DEPT;
            }

        }
        this.Title = "指定OJT訓練卡";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if ( gvTP.SelectedValue == null )
        {
            AlertMsg("請選擇範本");
            return;
        }

        trOJTStudentM_Repo ojtSM_Repo = new trOJTStudentM_Repo(dcTrain);

        foreach (GridDataItem i in gv.Items)
        {
            //新增
            if (i["OJT_sCode"].Text.Trim().Length == 0 && i.Selected == true)
            {
                //addOJT_Students(i["NOBR"].Text,gvTP.SelectedValue.ToString());

                var ojtSM = ojtSM_Repo.GetByNobrOjtCode(i["NOBR"].Text, gvTP.SelectedValue.ToString());

                if (ojtSM == null)
                {
                    trOJTStudentM obj = new trOJTStudentM();
                    obj.OJT_sCode = gvTP.SelectedValue.ToString();
                    obj.sNobr = i["NOBR"].Text;
                    obj.sKeyMan = User.Identity.Name;
                    obj.dKeyDate = DateTime.Now;
                    ojtSM_Repo.Add(obj);
                }
            }

            //刪除
            if (i["OJT_sCode"].Text.Trim().Length > 0 && i.Selected == false)
            {
                var ojtSM = ojtSM_Repo.GetByNobrOjtCode(i["NOBR"].Text, gvTP.SelectedValue.ToString());

                if (ojtSM != null)
                {
                    ojtSM_Repo.Delete(ojtSM);
                }
            }
        }

        ojtSM_Repo.Save();
        gv.Rebind();

        pnlMember.Visible = false;
        pnlTP.Visible = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlMember.Visible = false;
        pnlTP.Visible = true;
    }
    protected void gvTP_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlMember.Visible = true;
        pnlTP.Visible = false;
        gv.Rebind();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        RadButton btnView = (RadButton)sender;
        lblOJTcodeV.Text = btnView.CommandArgument;
        pnlView.Visible = true;
        pnlTP.Visible = false;
    }
    protected void btnBACKL_Click(object sender, EventArgs e)
    {
        pnlView.Visible = false;
        pnlTP.Visible = true;
    }
    protected void gv_ItemDataBound(object sender , GridItemEventArgs e)
    {
        if ( e.Item is GridDataItem )
        {
            GridDataItem item = e.Item as GridDataItem;
            if ( item["OJT_sCode"].Text.Trim().Length > 0 )
                item.Selected = true;
            else
                item.Selected = false;

        }
    }
}