using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Collections;
using Repo;
public partial class eTraining_Admin_Plan_DeptPicker:JBWebPage
{
    private dcTrainingDataContext trainingDC = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Request.QueryString["year"] ==null)
                throw new ApplicationException("未傳入正確參數");

            SiteHelper util = new SiteHelper();
            util.setDeptTv(tvDept);
        }
    }



    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        IList<RadTreeNode> deptNodes = tvDept.CheckedNodes;
        
        //取得選擇的所有部門及子部門
        //List<string> deptList = new List<string>();
        ////改為取得所有選擇部門，不含子部門
        //foreach (RadTreeNode node in deptNodes)
        //{
        //    deptList.Add(node.Value);
        //}

        int year = int.Parse(Request.QueryString["year"]);

        QuestDept_Repo qdRepo = new QuestDept_Repo();
        List<QuestDept> qdList= qdRepo.GetByYear(year);

        foreach ( RadTreeNode node in deptNodes )
        {
            var obj = (from c in qdList
                       where c.DeptCode == node.Value
                       select c).FirstOrDefault();

            if ( obj == null )
            {
                obj = new QuestDept();
                obj.DeptCode = node.Value;
                obj.Year = year;
                qdRepo.Add(obj);                
            }
        }

        qdRepo.Save();

        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CancelEdit();", true);
    }
}