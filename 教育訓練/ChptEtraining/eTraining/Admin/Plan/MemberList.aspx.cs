using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Collections;

public partial class eTraining_Admin_Plan_MemberList : System.Web.UI.Page
{
    private dcTrainingDataContext trainingDC = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteHelper util = new SiteHelper();
            util.setDeptTv(tvDept);
            setCbLevel();
            //btnCancel.Attributes["onclick"] = String.Format("CancelEdit;");                
            //tvDept.ExpandAllNodes();
        }
    }

    private void setCbLevel()
    {
        List<JOBL> list = (from c in trainingDC.JOBL
                   select c).ToList();

        cbBeginLevel.Items.Clear();
        cbEndLevel.Items.Clear();

        foreach(var c in list)
        {
            RadComboBoxItem item = new RadComboBoxItem(c.JOB_NAME,c.JOBL1);
            RadComboBoxItem item1 = new RadComboBoxItem(c.JOB_NAME, c.JOBL1);
            cbEndLevel.Items.Add(item);
            cbBeginLevel.Items.Add(item1);
        }

        if (cbBeginLevel.Items.Count > 0)
        {
            cbBeginLevel.Items[0].Selected = true;
        }

        if (cbEndLevel.Items.Count > 0)
        {
            cbEndLevel.Items[0].Selected = true;
        }

       // cbBeginLevel.DataBind();

      //  cbEndLevel.DataBind();
    }

    //private List<string> getDeptList(string deptCode,List<string> deptList,List<DEPT> allDeptList)
    //{
    //    if (!deptList.Contains(deptCode))
    //    {
    //        deptList.Add(deptCode);
    //    }

    //    var list = from c in allDeptList
    //               where c.DEPT_GROUP == deptCode
    //               select c;

    //    foreach (var c in list)
    //    {
    //        getDeptList(c.D_NO, deptList, allDeptList);
    //    }

    //    return deptList;
    //}


    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        int intBeginLevel = Convert.ToInt32(cbBeginLevel.SelectedValue);
        int intEndLevel = Convert.ToInt32(cbEndLevel.SelectedValue);
        IList<RadTreeNode> deptNodes = tvDept.CheckedNodes;

        
        //取得選擇的所有部門及子部門
        List<DEPT> allDeptList = trainingDC.DEPT.ToList<DEPT>();
        List<string> deptList = new List<string>();

        //foreach (RadTreeNode node in nodes)
        //{
        //    List<string> list = getDeptList(node.Value, deptList,allDeptList);
        //}

        //改為取得所有選擇部門，不含子部門
        foreach (RadTreeNode node in deptNodes)
        {
            deptList.Add(node.Value);
        }

        var userList = from b in trainingDC.BASE
                       join t in trainingDC.BASETTS on b.NOBR equals t.NOBR
                       where DateTime.Now.Date >= t.ADATE && DateTime.Now.Date <= t.DDATE &&
                       new string[] { "1", "4", "6" }.Contains(t.TTSCODE) &&
                       deptList.Contains(t.DEPT) &&
                       Convert.ToInt32(t.JOBL) >= intBeginLevel && Convert.ToInt32(t.JOBL) <= intEndLevel
                       select new { b, t };

        int i = userList.Count();

        //全部的需求名單，離線式
        var allStudent = (from c in trainingDC.trTrainingStudentD
                       select c).ToList();

        int year = int.Parse(Request.QueryString["year"]);

        foreach(var data in userList)
        {
            var studentList = from c in allStudent
                          where c.iYear == year && c.sNobr == data.b.NOBR
                          select c;

            //如果沒在名單內的話，就新增名單
            var student= studentList.FirstOrDefault();
            if (student == null)
            {
                trTrainingStudentD row = new trTrainingStudentD();
                row.iYear = year;
                row.sDeptCode = data.t.DEPT;
                row.sJoblCode = data.t.JOBL;
                row.sNobr = data.b.NOBR;
                trainingDC.trTrainingStudentD.InsertOnSubmit(row);
                trainingDC.SubmitChanges();
            }
        }

        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CancelEdit();", true);
    }
}