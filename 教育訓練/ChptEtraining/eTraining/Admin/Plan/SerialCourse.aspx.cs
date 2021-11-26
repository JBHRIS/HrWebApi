using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class eTraining_Admin_Plan_SerialCourse : System.Web.UI.Page
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteHelper util = new SiteHelper();
            util.SetTvCourseCat(tv);

            util.SetTvNonSerialCourse(tv);
            util.SetTvCourseCheckable(tv);
        }
    }

    protected void gv_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {

        if (e.Item is GridDataItem)
        {
            RadButton btn = (RadButton)e.Item.Cells[3].FindControl("btnAdd");   
            string sCode = e.Item.Cells[3].Text;

            btn.CommandArgument = sCode;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        RadButton btn = (RadButton)sender;
        lblSerialCourseCode.Text = btn.CommandArgument;
        pnSerialCourserAdd.Visible = true;
        pnSerialCourseView.Visible = false;

        var data = (from c in dcTraining.trCourse where c.sCode == lblSerialCourseCode.Text select c).FirstOrDefault();
        lblSerialCourseName.Text = "目前設定序列課程：" + data.sName;
    }
    protected void btnAddItem_Click(object sender, EventArgs e)
    {
        IList<RadTreeNode> tvNodelist = tv.CheckedNodes;

        foreach (RadTreeNode node in tvNodelist)
        {
            if (!SiteHelper.lbHasValue(lbSelected, node.Value))
            {
                RadListBoxItem lb = new RadListBoxItem(node.Text, node.Value);
                lbSelected.Items.Add(lb);
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        var list = from c in dcTraining.trSerialCourse
                   where c.sSerialCourseCode == lblSerialCourseCode.Text
                   select c;


        dcTraining.trSerialCourse.DeleteAllOnSubmit(list);

        int order = 1;
        foreach (RadListBoxItem item in lbSelected.Items)
        {
            trSerialCourse obj = new trSerialCourse();

            obj.sSerialCourseCode = lblSerialCourseCode.Text;
            obj.iOrder = order++;
            obj.sCourseCode = item.Value;
            obj.sKeyMan = User.Identity.Name;
            obj.dKeyDate = DateTime.Now;

            dcTraining.trSerialCourse.InsertOnSubmit(obj);
        }

        dcTraining.SubmitChanges();

        lbSelected.DataBind();

        setPageDefault();
        gvDetail.Rebind();
    }

    private void setPageDefault()
    {
        pnSerialCourseView.Visible = true;
        pnSerialCourserAdd.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        setPageDefault();
    }
}