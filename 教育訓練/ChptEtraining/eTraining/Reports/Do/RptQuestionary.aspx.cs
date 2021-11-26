using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using Repo;
using Telerik.Web.UI;
public partial class eTraining_Reports_Do_RptQuestionary:JBWebPage
{
    private string winUrl = "SummuryQuestionary.aspx";

    protected void Page_Load(object sender , EventArgs e)
    {
        if ( !IsPostBack )
        {
            dpB.SelectedDate = new DateTime(DateTime.Now.Year , DateTime.Now.Month , 1);
            dpE.SelectedDate = DateTime.Now;
        }
        win.VisibleOnPageLoad = false;
    }

    protected void btnSearch_Click(object sender , EventArgs e)
    {
        trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
        List<trTrainingDetailM> tdmList = tdmRepo.GetByDateRange_PublishedQA_DLO(dpB.SelectedDate.Value , dpE.SelectedDate.Value);

        QAMaster_Repo qamRepo =new QAMaster_Repo();

        List<ClassQARpt> rptList = new List<ClassQARpt>();

        foreach ( var tdmObj in tdmList )
        {
            if ( tdmObj.ClassQuestionnaire.Count == 0 )
                continue;

            foreach ( var cq in tdmObj.ClassQuestionnaire )
            {
                ClassQARpt r = new ClassQARpt();
                r.AutoKey = cq.iAutoKey;
                r.ClassDateTimeB = tdmObj.dDateTimeA.Value;
                r.ClassName = tdmObj.trCourse.sName;
                if ( cq.dDeadLine.HasValue )
                    r.DeadLine = cq.dDeadLine.Value;
                r.QTplCode = cq.QTpl.Code;
                r.QTplName = cq.QTpl.Name;                
                r.Counter =qamRepo.GetQtyByClassIdQuestionnaireCode(cq.iClassAutoKey,cq.qQuestionaryM,1).ToString()
                    + " / "+qamRepo.GetQtyByClassIdQuestionnaireCode(cq.iClassAutoKey,cq.qQuestionaryM,2).ToString();

                rptList.Add(r);
            }
        }

        gv.DataSource = rptList;
        gv.Rebind();
    }


    protected void gv_ItemCommand(object sender , Telerik.Web.UI.GridCommandEventArgs e)
    {
        if ( e.CommandName.Equals("Select") )
        {
            GridDataItem item = e.Item as GridDataItem;

            win.NavigateUrl = winUrl + "?Id=" + item["AutoKey"].Text;
            win.Height = 600;
            win.Width = 800;
            win.VisibleOnPageLoad = true;
        }
    }
}

public class ClassQARpt
{
    public int AutoKey
    {
        get;
        set;
    }
    public string QTplCode
    {
        get;
        set;
    }
    public string QTplName
    {
        get;
        set;
    }
    public DateTime? DeadLine
    {
        get;
        set;
    }
    public DateTime? ClassDateTimeB
    {
        get;
        set;
    }
    public string ClassName
    {
        get;
        set;
    }

    public string Counter
    {
        get;
        set;
    }
    public ClassQARpt()
    {
    }
}