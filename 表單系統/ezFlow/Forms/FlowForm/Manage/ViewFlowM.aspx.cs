using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Manage_ViewFlowM : System.Web.UI.Page
{
    dcFlowDataContext dcFlow = new dcFlowDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated && User.Identity.Name.Trim().Length > 0)
        {
            lblNobr.Text = User.Identity.Name;
            Session["Emp_id"] = User.Identity.Name.Trim();
            Response.Cookies["ezFlow"]["Emp_id"] = User.Identity.Name.Trim();
            Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(1);
        }

        BindForm();
        ScriptManager.GetCurrent(this).RegisterPostBackControl(btnExport);
    }

    private void BindForm()
    {
        var lsForm = (from c in dcFlow.wfForm
                      select c).ToList();

        DataTable dtForm = new DataTable();
        dtForm.Columns.Add("sNobr", typeof(string)).DefaultValue = "";
        dtForm.Columns.Add("sName", typeof(string)).DefaultValue = "";
        //dtForm.Columns.Add("sDeptCode", typeof(string)).DefaultValue = "";
        dtForm.Columns.Add("sDeptName", typeof(string)).DefaultValue = "";

        foreach (var rForm in lsForm)
            dtForm.Columns.Add(rForm.sFormCode, typeof(int)).DefaultValue = 0;

        var lsProcess = from pc in dcFlow.ProcessCheck
                        join pn in dcFlow.ProcessNode on pc.ProcessNode_auto equals pn.auto
                        join pf in dcFlow.ProcessFlow on pn.ProcessFlow_id equals pf.id
                        where !Convert.ToBoolean(pn.isFinish)
                        && !Convert.ToBoolean(pf.isFinish)
                        && !Convert.ToBoolean(pf.isError)
                        && !Convert.ToBoolean(pf.isCancel)
                        //&& pf.FlowTree_id == lblCount.ToolTip
                        //&& (pc.Emp_idDefault == lblNobr.Text || pc.Emp_idAgent == lblNobr.Text)
                        group new {  pf } by pc.Emp_idDefault into gpNobr
                        orderby gpNobr.Key
                        select gpNobr;

        DataRow r;
        foreach (var rProcess in lsProcess)
        {
            var rBase = JBHR.Dll.Bas.EmpBase(rProcess.Key).FirstOrDefault();

            if (rBase != null)
            {
                var rDept = JBHR.Dll.Bas.Deptm(rBase.sDeptmCode).FirstOrDefault();

                r = dtForm.NewRow();
                r["sNobr"] = rProcess.Key;
                r["sName"] = rBase.sNameC;
                //r["sDeptCode"] = rBase.sDeptmCode;
                r["sDeptName"] = rDept != null ? rDept.sDeptName : "";

                foreach (var rForm in lsForm)
                    r[rForm.sFormCode] = rProcess.Where(p => p.pf.FlowTree_id == rForm.sFlowTree).Count();

                dtForm.Rows.Add(r);
            }
        }

        lblCount.Text = dtForm.Rows.Count.ToString();

        r = dtForm.NewRow();
        r["sNobr"] = "總計";
        r["sName"] = "";
        //r["sDeptCode"] = "";
        r["sDeptName"] = "";

        foreach (var rForm in lsForm)
            r[rForm.sFormCode] =dtForm.Compute("Sum(" + rForm.sFormCode + ")", "").ToString().Length > 0 ? Convert.ToInt32(dtForm.Compute("Sum(" + rForm.sFormCode + ")", "")) : 0;

        dtForm.Rows.Add(r);

        dtForm.Columns["sNobr"].ColumnName = "工號";
        dtForm.Columns["sName"].ColumnName = "姓名";
        //dtForm.Columns["sDeptCode"].ColumnName = "部門代碼";
        dtForm.Columns["sDeptName"].ColumnName = "部門名稱";

        foreach (var rForm in lsForm)
        {
            if (Convert.ToInt32(dtForm.Compute("Sum(" + rForm.sFormCode + ")", "")) > 0)
                dtForm.Columns[rForm.sFormCode].ColumnName = rForm.sFormName;
            else
                dtForm.Columns.Remove(rForm.sFormCode);
        }

        gvForm.DataSource = dtForm;
        gvForm.DataBind();
    }

    public override void VerifyRenderingInServerForm(Control control) { }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Flow.ExportXls(gvForm);
    }
    protected void gvForm_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        sa.gv.RowDataBoundColorChange(e);
    }
}
