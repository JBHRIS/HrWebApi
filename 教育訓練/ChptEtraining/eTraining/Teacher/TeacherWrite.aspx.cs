using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;


public partial class eTraining_Teacher_TeacherWrite : JBWebPage
{
    const string SessionName = "TeacherReadRecordSession";
    private ReadRecordSession sessionObj = new ReadRecordSession();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DoHelper doHelper = new DoHelper();
            doHelper.setCbYear(cbxYear);

            if (Session[SessionName] != null)
            {
                ReadRecordSession obj = Session[SessionName] as ReadRecordSession;
                if (obj != null)
                {
                    cbxYear.SelectedIndex = obj.cbxYearSelectedIndex;
                    RadTabStrip1.SelectedIndex = obj.RadTabStrip1;
                    RadMultiPage1.PageViews[obj.RadTabStrip1].Selected = true;
                }
            }
            else
            {
                if (Request["tab"] != null)
                {
                    int tab = Convert.ToInt32(Request["tab"].ToString());
                    RadTabStrip1.SelectedIndex = tab;
                    RadMultiPage1.SelectedIndex = tab;
                }
            }            
        }
    }
    protected void sdsGv_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["@teacher"].Value = User.Identity.Name;
    }

    protected void gv_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        GridDataItem item = null;
        if (e.Item is GridDataItem)
        {
            item = e.Item as GridDataItem;
        }

        if (e.CommandName == "Score")
        {
            Response.Redirect("~/eTraining/Teacher/TrainingStudentScore.aspx" + @"?ID=" + item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString());
        }
        if (e.CommandName == "ScoreForReport")
        {
            Response.Redirect("~/eTraining/Teacher/ScoreStudentReport.aspx" + @"?ID=" + item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString());
        }
    }
    protected void sdsGvQ_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["@teacherCode"].Value = Juser.TeacherCode;
    }
    protected void gvQ_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;

            if (item["dWriteDate"].Text.Trim().Length > 0)
            {
                HyperLink hl = item["Write"].Controls[0] as HyperLink;
                if (hl != null)
                {
                    hl.Text = "已填寫";
                }
            }

        }
    }
    protected void cbxYear_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gv.Rebind();//心得
        gvQ.Rebind();//問卷
        sessionObj.cbxYearSelectedIndex = cbxYear.SelectedIndex;
        sessionObj.RadTabStrip1 = RadTabStrip1.SelectedIndex;
        Session[SessionName] = sessionObj;
    }
    protected void gv_ItemDataBound(object sender, GridItemEventArgs e)
    {
        GridDataItem item;
        if (e.Item is GridDataItem)
        {
            item = e.Item as GridDataItem;
            CheckBox ck = item["bIsNeedStudentScore"].Controls[0] as CheckBox;
            if (ck != null)
            {
                if (!ck.Checked)
                {
                    //item["Score"].Controls[0].Visible = false;
                    item["Score"].Text = "不需評分";
                }
            }

            ck = item["bIsNeedClassRpt"].Controls[0] as CheckBox;
            if (ck != null)
            {
                if (!ck.Checked)
                {
                    item["ScoreForReport"].Text = "不需評分";
                    //item["ScoreForReport"].Controls[0].Visible = false;
                }
            }

        }
    }
    protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
    {
        sessionObj.cbxYearSelectedIndex = cbxYear.SelectedIndex;
        sessionObj.RadTabStrip1 = RadMultiPage1.SelectedIndex;

        if (RadMultiPage1.SelectedIndex == 0)
            gv.Rebind();
        else if (RadMultiPage1.SelectedIndex == 1)
            gvQ.Rebind();

        Session[SessionName] = sessionObj;
    }
}