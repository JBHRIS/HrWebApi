using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Repo;

public partial class eTraining_Teacher_TrainingStudentScore : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] == null)
                throw new ApplicationException("無傳正確參數");

            lbliClassAutokey.Text = Request.QueryString["ID"].ToString();

            var lbl = (from m in dcTrain.trTrainingDetailM
                       join ca in dcTrain.trCategory on m.sKey equals ca.sCode
                       join co in dcTrain.trCourse on m.trCourse_sCode equals co.sCode
                       join d in dcTrain.trAttendClassDate on m.iAutoKey equals d.iClassAutoKey
                       where m.iAutoKey == Convert.ToInt32(lbliClassAutokey.Text)
                       select new
                       {
                           caName = ca.sName,
                           coName = co.sName,
                           dDate = d.dClassDate,
                           dClassRptDeadline =m.dClassRptDeadline
                       }).FirstOrDefault();

            lblCate.Text = lbl.caName;
            lblCourse.Text = lbl.coName;
            lblClassDate.Text = lbl.dDate.ToShortDateString();


            //抓mtCode的是否鎖定心得，如果逾期的話
            mtCode_Repo mtCodeRepo = new mtCode_Repo();
            mtCode mtCodeObj = mtCodeRepo.GetByCategroyCode("ClassPerformance" , "FillDeadLineLock");

            if ( !mtCodeObj.b1.HasValue )
                throw new ApplicationException("Category:ClassPerformance,Code:FillDeadLineLock的b1未設定");


            if ( mtCodeObj.b1.Value )
            {
                if ( lbl.dClassRptDeadline.HasValue && lbl.dClassRptDeadline.Value < DateTime.Now )
                {
                    lblClassMsg.Text = "填寫日期已超過期限" + lbl.dClassRptDeadline.Value.ToShortDateString();
                    btnSend.Enabled = false;
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        doSave();
    }

    private void doSave()
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        GridDataItemCollection items = gv.Items;
        var teacher = (from c in dcTrain.trTeacher
                       where c.sNobr == User.Identity.Name
                       select c).FirstOrDefault();

        string teacherCode = "";

        if (teacher != null)
        {
            teacherCode = teacher.sCode;
        }

        foreach (GridDataItem item in items)
        {
            var obj = (from c in dcTrain.trTrainingStudentM
                       where c.iAutoKey == Convert.ToInt32(item["iAutoKey"].Text)
                       select c).FirstOrDefault();

            if (obj != null)
            {
                RadNumericTextBox ntbScore = item["score"].FindControl("txtScore") as RadNumericTextBox;
                if (ntbScore.Value.HasValue)
                {
                    obj.iScore = Convert.ToInt32(ntbScore.Value);
                }

                RadTextBox ntbNote = item["note"].FindControl("txtPerformance") as RadTextBox;
                obj.sNote1 = ntbNote.Text;
                obj.dTeacherKeyDate = DateTime.Now;
                obj.sTeacherCode = teacherCode;
                dcTrain.SubmitChanges();
            }
        }

        //檢查是否講師已經全部填完心得資料
        trTrainingDetailM_Repo tsmRepo = new trTrainingDetailM_Repo();        
        tsmRepo.CheckIsTeacherFinishClassScore(Convert.ToInt32(Request.QueryString["ID"]));

        gv.Rebind();
    }
    protected void gv_ItemDataBound(object sender, GridItemEventArgs e)
    {
        GridDataItem item = null;
        if (e.Item is GridDataItem)
        {
            item = e.Item as GridDataItem;

            CheckBox ck= item["bPresence"].Controls[0] as CheckBox;
            if(ck!=null && ck.Checked==false)
            {                                
                item["note"].Enabled = false;
                item["score"].Enabled = false;
                RadTextBox ntbNote = item["note"].FindControl("txtPerformance") as RadTextBox;
                ntbNote.Text = "未出席";
            }
        }
    }

}