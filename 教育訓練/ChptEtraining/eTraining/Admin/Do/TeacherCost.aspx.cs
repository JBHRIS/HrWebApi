using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
using Telerik.Web.UI;
public partial class eTraining_Admin_Do_TeacherCost : JBWebPage
{
    private ClassTeacher_Repo classTeacherRepo = new ClassTeacher_Repo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            lblID.Text = Request.QueryString["ID"].ToString();
        }
        else
            throw new ApplicationException("無輸入課程ID");
    }


    protected void gv_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        var list = classTeacherRepo.GetByClassKey_DLO(Convert.ToInt32(lblID.Text));
        gv.DataSource = (from c in list
                         select new
                         {
                             TeacherName = c.trTeacher.sName,
                             IsEntTeacher = c.trTeacher.bEntTeacherType,
                             Charge = c.Charge,
                             Nobr = c.trTeacher.sNobr,
                             iAutoKey = c.iAutoKey,
                             Minutes = c.Minutes
                         }).ToList();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        int classID = Convert.ToInt32(Request.QueryString["ID"].ToString());

        trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
        trTrainingDetailM classObj = tdmRepo.GetByPK(classID);

        List<ClassTeacher> classTeacherList = classTeacherRepo.GetByClassKey(classID);

        foreach (GridDataItem item in gv.Items)
        {
            ClassTeacher classTeacherObj = classTeacherRepo.GetByPkFromList(Convert.ToInt32(item["iAutoKey"].Text), classTeacherList);
            RadNumericTextBox ntb = item["Charge"].FindControl("ntbCharge") as RadNumericTextBox;
            if (ntb != null)
            {                
                if (ntb.Value.HasValue)
                    classTeacherObj.Charge = Convert.ToInt32(ntb.Value);
                else
                    classTeacherObj.Charge = null;
            }

            RadNumericTextBox ntbM = item["Minutes"].FindControl("ntbMinutes") as RadNumericTextBox;
            if (ntbM != null)
            {
                if (ntbM.Value.HasValue)
                {
                    classTeacherObj.Minutes = Convert.ToInt32(ntbM.Value * 60);
                }
                else
                    classTeacherObj.Minutes = null;
            }            
        }

        Course course = new Course();
        if (!course.ValidateClassTeacher(classObj, classTeacherList))
        {
            AlertMsg("講師時數或費用與課程不合");
            return;
        }

        classTeacherRepo.Update(classTeacherList);
        classTeacherRepo.Save();     
        gv.Rebind();
        AlertMsg("已存檔");
    }
    protected void gv_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;

            if (item != null)
            {
                RadNumericTextBox ntb = item["Minutes"].FindControl("ntbMinutes") as RadNumericTextBox;
                if (ntb.Value.HasValue)
                {
                    ntb.Text = string.Format("{0:#,0.0}", ntb.Value / 60);
                }
            }
        }
    }
}