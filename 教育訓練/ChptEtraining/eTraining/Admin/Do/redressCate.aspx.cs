using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eTraining_Reports_Admin_Do_redressCate :JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        pnl.Visible = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnl.Visible = false;
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        List<trStudentError> StudentError = new List<trStudentError>();
        
        string sCode = Guid.NewGuid().ToString();

        var r = new trStudentError();

        r.sCode = sCode;
        r.sName = txtName.Text;

        StudentError.Add(r);

        try
        {
            dcTrain.trStudentError.InsertAllOnSubmit(StudentError);
            dcTrain.SubmitChanges();

            gv.Rebind();
            txtName.Text = "";
        }
        catch
        {
            AlertMsg("新增錯誤");
            txtName.Text = "";
        }
    }
}