using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class eTraining_Admin_Plan_MustTrainingAdd : System.Web.UI.Page
{
    const string JOB_NODE_TEXT ="全選";
    const string JOB_NODE_VALUE ="selectAll";
    dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteHelper util = new SiteHelper();
            util.setDeptTv(tvDept);
            tvDept.ExpandAllNodes();

            setJobTvData();
            tvJob.ExpandAllNodes();
        }
    }
    private void setJobTvData()
    {

        var list = dcTraining.JOB.ToList();
        Telerik.Web.UI.RadTreeNode pNode = new Telerik.Web.UI.RadTreeNode();
        pNode.Text = JOB_NODE_TEXT;
        pNode.Value = JOB_NODE_VALUE;

        foreach (var r in list)
        {
            Telerik.Web.UI.RadTreeNode node = new Telerik.Web.UI.RadTreeNode();
            node.Text = r.JOB_NAME;
            node.Value = r.JOB1;
            pNode.Nodes.Add(node);
            //tvJob.Nodes.Add(node);
        }

        tvJob.Nodes.Add(pNode);
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        IList<RadTreeNode> deptNodes = tvDept.CheckedNodes;
        IList<RadTreeNode> jobNodes = tvJob.CheckedNodes;

        for(int i=0;i<jobNodes.Count;i++)
        {
            if (jobNodes[i].Value == JOB_NODE_VALUE)
            {
                jobNodes.RemoveAt(i);    
            }
        }

        string course = Request.QueryString["pid"];
        string category = Request.QueryString["pid2"];


        //離線式
        var allRequiredUnit = (from c in dcTraining.trTrainingPlanRequiredUnit
                               //where c.sCategory == category
                               select c).ToList();


        foreach (RadTreeNode deptNode in deptNodes)
        {
            foreach (RadTreeNode jobNode in jobNodes)
            {
                var list = from c in allRequiredUnit
                           where c.dept_sCode == deptNode.Value && c.job_sCode == jobNode.Value
                           select c;

                //如果沒在名單內的話，就新增名單
                var row = list.FirstOrDefault();
                if (row == null)
                {
                    trTrainingPlanRequiredUnit obj = new trTrainingPlanRequiredUnit();
                    obj.dept_sCode = deptNode.Value;
                    obj.job_sCode = jobNode.Value;
                    //obj.trCourse_sCode = course;
                    //obj.sCategory = category;

                    dcTraining.trTrainingPlanRequiredUnit.InsertOnSubmit(obj);
                    dcTraining.SubmitChanges();
                }
            }
        }

        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CancelEdit();", true);
    }
}