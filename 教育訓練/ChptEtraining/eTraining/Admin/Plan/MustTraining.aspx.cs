using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


public partial class eTraining_Admin_Plan_MustTraining : JBWebPage
{
    const string JOB_NODE_TEXT = "全選";
    const string JOB_NODE_VALUE = "selectAll";

    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            changeMode("v");

            if (Request.QueryString["code"] != null && Request.QueryString["Category"] != null)
            {
                lblCode.Text = Request.QueryString["code"];
                lblCategory.Text = Request.QueryString["Category"];


                if (lblCategory.Text == "Category")
                {
                    var list = (from c in dcTraining.trCategory
                                where c.sCode == lblCode.Text
                                select c).FirstOrDefault();

                    if (list == null)
                    {
                        throw new Exception("無類別或代碼");
                    }

                    lblMsg.Text = "設定課程類別：" + list.sName;
                    
                    
                }
                else
                {
                    var list = (from c in dcTraining.trCourse
                                where c.sCode == lblCode.Text
                                select c).FirstOrDefault();

                    if (list == null)
                    {
                        throw new Exception("無類別或代碼");
                    }

                    lblMsg.Text = "設定課程：" + list.sName;
                }

                SiteHelper util = new SiteHelper();
                util.setDeptTv(tvDept);
                //tvDept.ExpandAllNodes();
                tvDept.CollapseAllNodes();

                setJobTvData();
                //tvJob.ExpandAllNodes();
                tvJob.CollapseAllNodes();

            }
            else
            {
                throw new Exception("無傳入query string");                
            }
        }
        

    }

    private void changeMode(string mode)
    {
        lblMode.Text = mode;
        //lbManager.Items.Clear();

        //clearGvPerson();

        if (mode == "v")
        {
            pnView.Visible = true;
            pnEdit.Visible = false;
        }
        else if (mode == "i")
        {
            tvDept.UncheckAllNodes();
            tvJob.UncheckAllNodes();
            //SiteHelper util = new SiteHelper();
            //util.setDeptTv(tvDept);
            ////tvDept.ExpandAllNodes();
            //tvDept.CollapseAllNodes();

            //setJobTvData();
            ////tvJob.ExpandAllNodes();
            //tvJob.CollapseAllNodes();

            pnView.Visible = false;
            pnEdit.Visible = true;
            //setLblYYMM();
        }
    }

    private void setJobTvData()
    {

        var list = (from c in dcTraining.JOB orderby c.JOB_NAME ascending select c).ToList();
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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        changeMode("i");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        IList<RadTreeNode> deptNodes = tvDept.CheckedNodes;
        IList<RadTreeNode> jobNodes = tvJob.CheckedNodes;

        if (deptNodes.Count == 0)
        {
            RadAjaxPanel1.Alert("請選擇部門");
            return;
        }

        if (jobNodes.Count == 0)
        {
            RadAjaxPanel1.Alert("請選擇職稱");
            return;
        }

        //有點選全選的話，把全選先拿掉，以免匯入
        for (int i = 0; i < jobNodes.Count; i++)
        {
            if (jobNodes[i].Value == JOB_NODE_VALUE)
            {
                jobNodes.RemoveAt(i);
            }
        }

        //string course = Request.QueryString["pid"];
        //string category = Request.QueryString["pid2"];
        var allRequiredUnit = (from c in dcTraining.trTrainingPlanRequiredUnit
                               where c.sMode == lblCategory.Text && c.sCode == lblCode.Text
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
                    obj.sMode = lblCategory.Text;
                    obj.sCode = lblCode.Text;
                                   
                    dcTraining.trTrainingPlanRequiredUnit.InsertOnSubmit(obj);
                }
            }

            dcTraining.SubmitChanges();
        }

        RadAjaxPanel1.Alert("新增完成");
        gv.Rebind();
        changeMode("v");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        changeMode("v");
    }
    protected void btnBackCat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/eTraining/Admin/Plan/trCategory.aspx");
    }

    protected void btnBackCo_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/eTraining/Admin/Plan/trCourse.aspx");
    }
}