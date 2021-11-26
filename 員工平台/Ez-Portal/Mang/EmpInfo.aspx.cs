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
using System.Collections.Generic;
using BL;
using JBHRModel;
using System.Linq;
using Telerik.Web.UI;

public partial class Mang_EmpInfo : JBWebPage
{
    private BASE_REPO baseRepo = new BASE_REPO();
    protected void Page_Load(object sender, EventArgs e)
    {
        win.VisibleOnPageLoad = false;
        ucEmpDeptQS.sHandler += new Templet_EmpDeptQS.SelectedEventHandler(UC_SelectObj);
        if (!IsPostBack)
        {
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.Manager);
            a.InitUC_Cat(1, true);
            a.SetQuickSearchAdvanced(false);
            a.DisplayPushBtn(true);
        }
    }

    private void UC_SelectObj(UC_QS_SelectedObj obj)
    {
        if (obj == null)
        {
            Show("Select Unit or Team Member");
            return;
        }

        getData(obj.DeptList);
        gv.Rebind();
    }

    void getData(List<string> deptList)
    {
        var baseList = baseRepo.GetHiredEmpByDept_Dlo(deptList);
        Session[SessionName] = baseList;
    }

    void getData()
    {
        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj = a.GetSelectedObj();

        if (obj == null)
        {
            Show("Select Unit or Team Member");
            return;
        }

        var baseList = baseRepo.GetHiredEmpByDept_Dlo(obj.DeptList);
        Session[SessionName] = baseList;
    }

    protected void gv_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        if (e.RebindReason == GridRebindReason.InitialLoad)
            return;

        if (e.RebindReason == GridRebindReason.ExplicitRebind)
        {
            if (Session[SessionName] == null)
            {
                getData();
            }
        }
        else
        {
            if (Session[SessionName] == null)
                getData();
        }

        if (Session[SessionName] != null)
        {
            DateTime datetime = DateTime.Now;
            var list = Session[SessionName] as List<BASE>;

            List<EmpInfo1> empList = new List<EmpInfo1>();
            foreach (var c in list)
            {
                EmpInfo1 o = new EmpInfo1();

                o.Addr1 = c.ADDR1;
                o.BirthDate = c.BIRDT;
                o.DeptCode = c.BASETTS[0].DEPT;
                o.DeptName = c.BASETTS[0].DEPT1.D_NAME;
                o.ExtNum = c.SUBTEL;
                o.Gender = c.SEX.Equals("M") ? "男" : "女";
                o.Indt = c.BASETTS[0].INDT;
                o.JobCode = c.BASETTS[0].JOB;
                o.JoblCode = c.BASETTS[0].JOBL;
                o.JoboCode = c.BASETTS[0].JOBO;
                o.JoboName = c.BASETTS[0].JOBO1.JOB_NAME;
                o.JoblName = c.BASETTS[0].JOBL1.JOB_NAME;
                o.JobTitle = c.BASETTS[0].JOB1.JOB_NAME;
                o.MobileNumber = c.GSM;
                o.NameC = c.NAME_C;
                o.NameE = c.NAME_E;
                o.Nobr = c.NOBR;
                o.PhoneNumber = c.TEL1;
                o.Seniority = baseRepo.dc.GetTotalYears(c.NOBR, datetime);
                if (c.SCHL.Count == 0)
                {
                    o.TopSchoolName = "";
                    o.TopSchoolMajorName = "";
                }
                else
                {
                    var s = c.SCHL.OrderByDescending(p => p.DATE_E).FirstOrDefault();
                    o.TopSchoolName = s.SCHL1;
                    o.TopSchoolMajorName = s.SUBJ_DETAIL;
                }

                empList.Add(o);
            }

            gv.DataSource = empList;
        }
    }



    protected void gv_ItemCommand(object sender, GridCommandEventArgs e)
    {

    }
    protected void gv2_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (e.RebindReason == GridRebindReason.ExplicitRebind)
        {
            EmpTts_REPO eRepo = new EmpTts_REPO();
            gv2.DataSource = eRepo.GetByNobr(gv.SelectedValue.ToString()).OrderByDescending(p=>p.adate);
        }
    }
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        gv2.Rebind();
        win.VisibleOnPageLoad = true;
    }
}