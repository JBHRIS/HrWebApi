using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Linq;
 
using System.Collections.Generic;
using BL;
using JBHRModel;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;
public partial class Mang_EmpSelect_hr :JBWebPage {
    private DEPT_REPO dept_repo = new DEPT_REPO();
    protected void Page_Load(object sender, EventArgs e) {
        //SelectEmpHr1.sHandler += new Templet_SelectEmpHr.SelectEmpEventHandler(UC_SelectEmp);

        ucEmpDeptQS.sHandler += new Templet_EmpDeptQS.SelectedEventHandler(UC_SelectObj);

        if (!IsPostBack)
        {
            //SiteHelper.SetAllDeptTree(TreeView1);
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.HR);
            a.InitUC_Cat(0);
            //EmpBase1.Visible = false;
            //EmpFamilyInfo1.Visible = false;
            //EmpInfoState1.Visible = false;
            //EmployeeContact1.Visible = false;
            //EmployeeContactPeople1.Visible = false;
            //EmpTtsInfo1.Visible = false;
            //EmployeeSecretarySetting1.Visible = false;
        }
        else {

            EmpBase1.Visible = true;
            EmpFamilyInfo1.Visible = true;
            EmpInfoState1.Visible = true;
            EmployeeContact1.Visible = true;
            EmployeeContactPeople1.Visible = true;
            EmpTtsInfo1.Visible = true;
            EmployeeSecretarySetting1.Visible = true;
        
        }
    }
    private void UC_SelectObj(UC_QS_SelectedObj obj)
    {
        loadDate();
    }

    //protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e) {
    //    lb_dept.Text = TreeView1.SelectedNode.Value;
    //    try
    //    {
    //        //GridView1.SelectedIndex = -1;
    //        try
    //        {
    //            (SelectEmpHr1 as IUC).SetValue(lb_dept.Text);
    //            (SelectEmpHr1 as IUC).BindData();
    //            lb_nobr.Text = "";
    //            loadDate();
    //            //GridView1.DataBind();
    //            //GridView1.SelectedIndex = 0;
    //            //loadDate();
    //        }
    //        catch { }
    //       // loadDate();
    //    }
    //    catch { }
    //}

    //private void UC_SelectEmp(string nobr)
    //{
    //    lb_nobr.Text = nobr;
    //    loadDate();
    //}

    //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) {
    // //   Session["nobr"] = GridView1.SelectedValue;
    //    loadDate();
       
    //}
    void loadDate()
    {

        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj = a.GetSelectedObj();

        if (obj == null)
        {
            Show("Select Unit or Team Member");
            return;
        }

        ((Label)EmpBase1.FindControl("lb_nobr")).Text = obj.Key;
        ((ICU)EmpBase1).bindGrid();
        ((Label)EmpFamilyInfo1.FindControl("lb_nobr")).Text = obj.Key;
        ((Label)EmpInfoState1.FindControl("lb_nobr")).Text = obj.Key;
        ((ICU)EmpInfoState1).bindGrid();

        ((Label)EmployeeContact1.FindControl("lb_nobr")).Text = obj.Key;
        ((Label)EmployeeContactPeople1.FindControl("lb_nobr")).Text = obj.Key;
        ((Label)EmpTtsInfo1.FindControl("lb_nobr")).Text = obj.Key;

        IUC ucEmployeeSecretarySetting = EmployeeSecretarySetting1 as IUC;
        ucEmployeeSecretarySetting.SetValue(obj.Key);
        ucEmployeeSecretarySetting.BindData();
        AbsList1.SetValue(obj.Key);
        AbsList1.BindData();
    }

    protected void RBL_deptr_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void RBL_deptr_TextChanged(object sender, EventArgs e) {

    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        
      
 

    }

    protected void btnExcelSecretary_Click(object sender , EventArgs e)
    {
        BASETTS_REPO basettsRepo = new BASETTS_REPO();
        List<BASETTS> basettsList= basettsRepo.GetHired_Inc();
        var list = basettsList.FindAll(c => c.MANG1 == true);
        var l = (from c in list
                 select new
                 {
                     部門 = c.DEPT1.D_NAME ,
                     工號 = c.BASE.NOBR,
                     姓名 = c.BASE.NAME_C,
                     英文名 = c.BASE.NAME_E,
                     職稱 = c.JOB1.JOB_NAME
                 }).ToList();

        DataTable dt= l.CopyToDataTable();
        IWorkbook workbook = DataTableRenderToExcel.RenderDataTableToExcel(dt);

        HttpResponse response = HttpContext.Current.Response;
        //HttpUtility.UrlEncode(_upfilenameLabel.Text, System.Text.Encoding.UTF8))
        MemoryStream ms = new MemoryStream();
        workbook.Write(ms);
        response.AddHeader("Content-Disposition" , string.Format("attachment; filename=" + HttpUtility.UrlEncode("Secretary" , System.Text.Encoding.UTF8) + ".xls"));
        response.BinaryWrite(ms.ToArray());
        response.End();        
        ms.Dispose();

    }
}
