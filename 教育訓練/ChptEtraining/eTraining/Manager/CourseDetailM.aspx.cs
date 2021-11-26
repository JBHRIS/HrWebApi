using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Repo;

public partial class eTraining_Manager_CourseDetailM : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gvNobr);
        if (!IsPostBack)
        {
            SiteHelper siteHelper = new SiteHelper();
            siteHelper.SetDeptTvByDeptID(tvDept, Juser.Dept);
            tvDept.ExpandAllNodes();
            if (tvDept.Nodes.Count > 0)
                tvDept.Nodes[0].Selected = true;

            var dept = (from c in dcTrain.BASETTS
                        where c.NOBR == Page.User.Identity.Name &&
                        DateTime.Now.Date >= c.ADATE && DateTime.Now.Date <= c.DDATE
                        select c.DEPT).FirstOrDefault();

            lbldept.Text = dept.ToString();
        }
    }

    protected void gvNobr_ItemCommand(object sender, GridCommandEventArgs e)
    {

        if (e.Item is GridDataItem)
        {
            GridDataItem itm = (GridDataItem)e.Item;        
            string key =  itm.OwnerTableView.DataKeyValues[itm.ItemIndex]["NOBR"].ToString();
            int classID = Convert.ToInt32(Request.QueryString["ClassID"]);

            if (e.CommandName == "Reg")
            {
                var st = (from c in dcTrain.trTrainingStudentM
                          where c.iClassAutoKey == classID && c.sNobr == key
                          select c).FirstOrDefault();

                if (st != null)
                {
                    RadAjaxPanel1.Alert("此員工已報名");
                    return;
                }

                trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
                try
                {
                    tsmRepo.AddStudent(classID , key,User.Identity.Name);
                }
                catch (Exception ex)
                {
                    RadAjaxPanel1.Alert(ex.Message);
                }
                //Show("報名成功!!!!");
                //RadAjaxPanel1.Alert("報名成功!!");
                gvNobr.Rebind();
            }
            else if ( e.CommandName == "DeReg" )
            {
                trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();                
                tsmRepo.DelStudent(classID , key);
                gvNobr.Rebind();
                //RadAjaxPanel1.Alert("已取消報名");
            }
        }
    }
    protected void gvNobr_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem itm = (GridDataItem)e.Item;
            if (itm["stKey"].Text.Trim().Length == 0)
            {
                itm["Reg"].Enabled = true;
                itm["DeReg"].Enabled = false;
            }
            else
            {
                itm["Reg"].Enabled = false;
                itm["DeReg"].Enabled = true;
            }

        }
    }
    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        if (ViewState["URL"] != null)
        {
            Response.Redirect(ViewState["URL"].ToString());
        }
    }
    protected void tvDept_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        gvNobr.Rebind();
    }
}