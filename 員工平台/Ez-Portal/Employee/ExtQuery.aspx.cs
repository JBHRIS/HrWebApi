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
using BL;
using System.Linq;
using System.Collections.Generic;
using Telerik.Web.UI;
public partial class ExtQuery : JBWebPage
{
    private BASE_REPO baseRepo = new BASE_REPO();
    protected void Page_Load(object sender, EventArgs e)
    {        
        ucEmpDeptQS.sHandler += new Templet_EmpDeptQS.SelectedEventHandler(UC_SelectObj);
        
        if (!IsPostBack)
        {
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.HR);
            a.DisplayPushBtn(true);
            a.SetQuickSearchAdvanced(true);
        }
    }

    private void UC_SelectObj(UC_QS_SelectedObj obj)
    {
        if (obj == null)
        {
            Show("Select Unit or Team Member");
            return;
        }

        List<EmpInfo1> empInfoList = new List<EmpInfo1>();

        if (obj.SelectedType == EnumUC_QS_SelectedType.Emp)
        {            
          empInfoList=(from c in baseRepo.GetEmpByExtTelSearch_Dlo(obj.Key)
           select new EmpInfo1
           {
               Nobr = c.NOBR,
               NameC = c.NAME_C,
               NameE = c.NAME_E,
               JobCode = c.BASETTS[0].JOB,
               JobTitle = c.BASETTS[0].JOB1.JOB_NAME,
               DeptCode = c.BASETTS[0].DEPT,
               DeptName = c.BASETTS[0].DEPT1.D_NAME,
               ExtNum = c.SUBTEL
           }).ToList();
          
        }
        else
        {
            foreach (var d in obj.DeptList)
            {
                empInfoList.AddRange(
                    (from c in baseRepo.GetEmpByDept_Dlo(d)
                     select new EmpInfo1
                     {
                         Nobr = c.NOBR,
                         NameC = c.NAME_C,
                         NameE = c.NAME_E,
                         JobCode = c.BASETTS[0].JOB,
                         JobTitle = c.BASETTS[0].JOB1.JOB_NAME,
                         DeptCode = c.BASETTS[0].DEPT,
                         DeptName = c.BASETTS[0].DEPT1.D_NAME,
                         ExtNum = c.SUBTEL                         
                     }).ToList());
            }
        }

        gv.DataSource = empInfoList;
        gv.Rebind();
    }


    private void bindData()
    {
        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj = a.GetSelectedObj();
        UC_SelectObj(obj);
    }


    protected void gv_ItemCommand(object sender , Telerik.Web.UI.GridCommandEventArgs e)
    {
        if ( e.CommandName.Equals("cmdEdit") )
        {
            GridDataItem item = e.Item as GridDataItem;
            lblNobr.Text = item["Nobr"].Text;
            BASE bObj= baseRepo.GetByNobr(lblNobr.Text);
            tbExtNum.Text = bObj.SUBTEL;
            pnlEdit.Visible = true;
        }
    }
    protected void btnSave_Click(object sender , EventArgs e)
    {
        BASE bObj = baseRepo.GetByNobr(lblNobr.Text);
        bObj.SUBTEL=tbExtNum.Text;
        baseRepo.Update(bObj);
        baseRepo.Save();
        tbExtNum.Text = "";
        pnlEdit.Visible = false;
        bindData();        
    }
    protected void btnCancel_Click(object sender , EventArgs e)
    {
        tbExtNum.Text = "";
        pnlEdit.Visible = false;
    }
    protected void gv_ItemDataBound(object sender , GridItemEventArgs e)
    {
        if ( e.Item is GridDataItem )
        {
            GridDataItem item = e.Item as GridDataItem;

            if (!Juser.CoordinatorDeptList.Any(p => p.DeptId == item["DeptCode"].Text))
            {
                if (!Juser.IsInRole("HR"))
                {
                    foreach (Control c in item["cmdEdit"].Controls)
                    {
                        c.Visible = false;
                    }
                }
            }
        }
    }
}
