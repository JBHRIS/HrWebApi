using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Telerik.Web.UI;

public partial class SetCourseType : JBWebPage
{
    private dcTrainingDataContext dcTrain = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = "課程類型設定";
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        pnlMethod.Visible = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {        
        txtName.Text = string.Empty;

        pnlMethod.Visible = false;
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        //重整時新增動作不會被重覆
        if (IsRefresh)
        {
            txtName.Text = string.Empty;
            gv.Rebind();
            return;
        }
        string sCode = Guid.NewGuid().ToString(); 

        try
        {
            List<CourseType> Method = new List<CourseType>();

            var r = new CourseType();

            r.sCode = sCode;
            r.sName = txtName.Text;

            Method.Add(r);
            
            dcTrain.CourseType.InsertAllOnSubmit(Method);
            dcTrain.SubmitChanges();
            gv.Rebind();

            //Show("已加入");
                        
            txtName.Text = string.Empty;
        }
        catch (Exception ex)
        {
            AlertMsg("新增錯誤");
            txtName.Text = string.Empty;
        }
    }
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        showCol();
        
        gv.ExportSettings.ExportOnlyData = true;
        gv.ExportSettings.HideStructureColumns = true;
        gv.ExportSettings.IgnorePaging = true;
        gv.ExportSettings.OpenInNewWindow = false;
        gv.ExportSettings.FileName = DateTime.Now.ToShortDateString();        
        gv.MasterTableView.ExportToExcel();        
    }

    private void showCol()
    {
        gv.Columns.FindByUniqueName("sCode").Visible = true;
    }

    private void hideCol()
    {
        gv.Columns.FindByUniqueName("sCode").Visible = false;
    }
    
}