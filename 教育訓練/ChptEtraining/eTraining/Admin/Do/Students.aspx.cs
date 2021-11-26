using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Net.Mail;
using Repo;
public partial class eTraining_Admin_Do_Students : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();    
    private trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
    DataContext dc = new DataContext();
    bool isExport = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gv);
        if ( Request.QueryString["ID"] != null )
        {
            lblID.Text = Request.QueryString["ID"].ToString();
        }
        else
            throw new ApplicationException("無輸入課程ID");
    }

    //匯出EXCEL BTN已移除
    //protected void btnExcel_Click(object sender, EventArgs e)
    //{
    //    var classObj = (from c in dcTraining.trTrainingDetailM
    //                    join course in dcTraining.trCourse on c.trCourse_sCode equals course.sCode
    //                    join cate in dcTraining.trCategory on c.sKey equals cate.sCode
    //                    where c.iAutoKey == Convert.ToInt32(lblID.Text)
    //                    select new { c,cateName= cate.sName, courseName= course.sName}).FirstOrDefault();

    //    string fileName = classObj.cateName + "-" + classObj.courseName+"學員名單";

    //    isExport = true;
    //    gv.FilterMenu.Visible = true;
    //    gv.ExportSettings.ExportOnlyData = true;
    //    gv.ExportSettings.HideStructureColumns = true;
    //    gv.ExportSettings.IgnorePaging = true;
    //    gv.ExportSettings.OpenInNewWindow = false;
    //    gv.ExportSettings.FileName = fileName;
    //    gv.MasterTableView.ExportToExcel();
    //    //isExport = false;
    //}

    private void loadData()
    {
        int key = Convert.ToInt32(lblStudentKey.Text);
        var data = (from c in dcTraining.trTrainingStudentM
                    where c.iAutoKey == key
                    select c).FirstOrDefault();
        if (data != null)
        {
            tbNote3.Text = data.sNote3;
        }

        cbxStuError.DataBind();
    }

    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnNote.Visible = true;
        lblStudentKey.Text = gv.SelectedValue.ToString();
        loadData();
    }

    protected void gv_ExportCellFormatting(object sender, Telerik.Web.UI.ExportCellFormattingEventArgs e)
    {
        e.Cell.Style["mso-number-format"] = @"\@";
    }
    protected void gv_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (isExport && e.Item is GridFilteringItem)
            e.Item.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnNote.Visible = false;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int key = Convert.ToInt32(lblStudentKey.Text);
        var data = (from c in dcTraining.trTrainingStudentM
                    where c.iAutoKey == key
                    select c).FirstOrDefault();
        if (data != null)
        {
            data.sNote3 = tbNote3.Text;

            dcTraining.SubmitChanges();
            gv.Rebind();
            pnNote.Visible = false;
        }

        var classStudentError = (from c in dcTraining.trClassStudentError
                                 where c.TrainingStudentM_ID == key
                                 select c).ToList();

        //ck有、db沒有的、增加
        foreach (var c in cbxStuError.CheckedItems)
        {
            var o = (from cse in classStudentError
                     where cse.StudentErrorCode == c.Value
                     select cse).FirstOrDefault();

            if (o == null)
            {
                trClassStudentError obj = new trClassStudentError();
                obj.dKeyDate = DateTime.Now;
                obj.sKeyMan = User.Identity.Name;
                obj.StudentErrorCode = c.Value;
                obj.TrainingStudentM_ID = key;
                obj.sNobr = data.sNobr;
                obj.iClassAutoKey = data.iClassAutoKey;
                dcTraining.trClassStudentError.InsertOnSubmit(obj);
            }
        }

        //ck沒有，db有、刪除
        foreach (var c in classStudentError)
        {
            var o = (from i in cbxStuError.CheckedItems
                     where i.Value == c.StudentErrorCode
                     select c).FirstOrDefault();
            if (o == null)
            {
                dcTraining.trClassStudentError.DeleteOnSubmit(c);
            }
        }

        dcTraining.SubmitChanges();
    }

    protected void btnAddStu_Click(object sender, EventArgs e)
    {
        pnlNobr.Visible = true;
        btnClose.Visible = true;
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        pnlNobr.Visible = false;
        btnClose.Visible = false;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in gvNobr.SelectedItems)
        {
            //item["NOBR"]
            int classID = Convert.ToInt32(lblID.Text);            
            tsmRepo.AddStudent(classID, item["NOBR"].Text, User.Identity.Name);
            gv.Rebind();
        }
    }
    protected void cbxStuError_DataBound(object sender, EventArgs e)
    {        
        var classStudentError = (from c in dcTraining.trClassStudentError
                                 where c.TrainingStudentM_ID == Convert.ToInt32(lblStudentKey.Text)
                                 select c).ToList();

        cbxStuError.ClearCheckedItems();

        foreach (var c in classStudentError)
        {
            RadComboBoxItem item = cbxStuError.Items.FindItemByValue(c.StudentErrorCode);
            item.Checked = true;
        }
    }
    protected void gv_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName.Equals("Delete"))
        {
            if (e.Item is GridDataItem)
            {
                string key = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"].ToString();
                GridDataItem item = e.Item as GridDataItem;
                if (item !=null)
                {
                    tsmRepo.DelStudent(Convert.ToInt32(lblID.Text), item["sNobr"].Text);
                    AlertMsg("已刪除");
                    gv.Rebind();
                }
            }

        }
    }
    protected void gv_ItemDataBound(object sender, GridItemEventArgs e)
    {                
            if (e.Item is GridDataItem)
            {                
                GridDataItem item = e.Item as GridDataItem;
                if (item !=null)
                {
                    item["Item"].Text = (item.DataSetIndex + 1).ToString();                    
                }
            }
    }
}