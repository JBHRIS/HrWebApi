using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test_Std : System.Web.UI.Page
{
    private dcFlowDataContext dcFlow = new dcFlowDataContext();
    private dcFormDataContext dcForm = new dcFormDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            lblNobrAppM.Text = Request.QueryString["idEmp_Start"] != null ? Request.QueryString["idEmp_Start"].ToUpper() : lblNobrAppM.Text;
            lblProcessID.Text = Guid.NewGuid().ToString();  //產生一組暫存的序號

            SetDefault();
        }
    }
    private void SetDefault()
    {
        lblTitle.ToolTip = "Test";
        (Page.Master as mpStd0990111).sFormCode = lblTitle.ToolTip;

        var dtForm = from c in dcFlow.wfForm where c.sFormCode == lblTitle.ToolTip select c;

        if (dtForm.Any())
        {
            var rForm = dtForm.First();
            lblTitle.Text = rForm.sFormName;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        localhost.Service oService = new localhost.Service();
        int iProcessID = oService.GetProcessID();

        var dtBase = from role in dcFlow.Role
                     join emp in dcFlow.Emp on role.Emp_id equals emp.id
                     join dept in dcFlow.Dept on role.Dept_id equals dept.id
                     join pos in dcFlow.Pos on role.Pos_id equals pos.id
                     where role.Emp_id == lblNobrAppM.Text
                     select new { role, emp, dept, pos };

        if (dtBase.Any())
        {
            var dtDeptm = JBHR.Dll.Bas.Deptm(dtBase.First().dept.id).FirstOrDefault();

            var rm = new wfFormApp();
            rm.sFormCode = lblTitle.ToolTip;
            rm.sFormName = lblTitle.Text;
            rm.sProcessID = iProcessID.ToString();
            rm.idProcess = iProcessID;
            rm.sNobr = lblNobrAppM.Text;
            rm.sName = "";
            rm.sDept = "";
            rm.sDeptName = "";
            rm.sJob = "";
            rm.sJobName = "";
            rm.sRole = "";
            rm.iCateOrder = dtDeptm != null ? Convert.ToInt32(dtDeptm.sDeptTree) : 0;    //被申請者的部門層級
            rm.bDelay = false;  //是否有延遲需要補單
            rm.dDateTimeA = DateTime.Now;
            rm.bAuth = false;
            rm.bSign = true;
            rm.sState = "1";
            rm.sConditions1 = rm.iCateOrder.ToString(); //目前所簽核到的部門
            dcFlow.wfFormApp.InsertOnSubmit(rm);
            dcFlow.SubmitChanges();

            if (oService.FlowStart(iProcessID, Request["idFlowTree"], Request["idRole_Start"], Request["idEmp_Start"], Request["idRole_Start"], Request["idEmp_Start"]))
                Page.ClientScript.RegisterStartupScript(typeof(string), "OpenWork", "alert('您的申請單已成功送出了');self.location = '../../FlowImage/Output.aspx?idProcess=" + iProcessID.ToString() + "';", true);

        }
    }
}