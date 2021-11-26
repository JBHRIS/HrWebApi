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

public partial class FEFC_FL_ABS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            adate.SelectedDate = DateTime.Now;
            ddate.SelectedDate = DateTime.Now;

        }

    }
    protected void nobr_TextChanged(object sender, EventArgs e)
    {
        lb_abs_name.Text = getEmpInfo("F" + nobr.Text.Trim());
        lb_nobr.Text = "F" + nobr.Text.Trim();
        gvAbsView.DataBind();
        
    }
    protected void check_Click(object sender, EventArgs e)
    {
        lScript.Text = "";



        DateTime dDateB = adate.SelectedDate.Value;// Convert.ToDateTime(leaveDateSince.Text);
        DateTime dDateE = adate.SelectedDate.Value; //Convert.ToDateTime(leaveDateEnd.Text);

        string sNobr  = "F"+nobr.Text;
        string sHcode  = leavecategory.SelectedItem.Value;

     
        string sTimeB  = StartDay.SelectedValue + StartMin.SelectedValue;
        string sTimeE  = EndDay.SelectedValue + EndMin.SelectedValue;
    


        //'日期與時間組合
        DateTime dDateTimeB  = dDateB.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(sTimeB));
        DateTime dDateTimeE  = dDateE.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(sTimeE));
       


         JBHR.Dll.dsAtt.JB_HR_RoteDataTable dt = JBHR.Dll.Att.Rote(sNobr, dDateB);
        if( dt.Rows.Count == 0){
            lScript.Text = JBHR.Dll.Tools.MessageShowAlert("您此天沒有班別資料，請人事單位替您產生");
            return;
        }

       // 'Dim ra As JBHR.Dll.dsAtt.JB_HR_RoteRow = dt.Rows("0")

       // '出勤資料檢查

        JBHR.Dll.dsAtt.JB_HR_AttendDataTable dtAttend = JBHR.Dll.Att.Attend(sNobr, dDateB);
        String sRoteCode  =   dtAttend[0].sRoteCode;// CType(dtAttend.Rows(0), JBHR.Dll.dsAtt.JB_HR_AttendRow).sRoteCode;
        if( sRoteCode == "00" ){//     '00代表假日
           //判斷前一日是否有班表

            DateTime dDateB2   = ddate.SelectedDate.Value.AddDays(-1);
             if( JBHR.Dll.Att.AbsCheck.IsWorkDay(sNobr, dDateB2, sHcode) == false){ 
                lScript.Text = JBHR.Dll.Tools.MessageShowAlert("日期區間包含非上班日");
                return;
             }

        }else{

           if( JBHR.Dll.Att.AbsCheck.IsWorkDay(sNobr, dDateB, sHcode) == false){ 
               // ' If JBHR.Dll.Att.AbsCheck.IsWorkDay(sNobr, dDateB, sHcode) = False Or JBHR.Dll.Att.AbsCheck.IsWorkDay(sNobr, dDateE, sHcode) = False Then
                lScript.Text = JBHR.Dll.Tools.MessageShowAlert("日期區間包含非上班日");
                return;
           }
        }





        //'日期時間起迄檢查
      //  if( dDateTimeB >= dDateTimeE ){
      //      lScript.Text = JBHR.Dll.Tools.MessageShowAlert("開始日期時間須小於結束日期時間");
      //      return;
      //  }

        //'請假起迄日期時間是否在上班時間內
        //'If JBHR.Dll.Att.AbsCheck.IsWorkTime(sNobr, dDateB, dDateE, sTimeB, sTimeE, "0", False) = False And ra.sRoteCode <> "H" Then
        //'If JBHR.Dll.Att.AbsCheck.IsWorkTime(sNobr, dDateB, dDateE, sTimeB, sTimeE, "0", False) = False Then

        //'    lScript.Text = JBHR.Dll.Tools.MessageShowAlert("請假起迄日期時間在上班時間內")
        //'    Return
        //'End If

        //'日期時間是否已在HR的資料裡
        if( JBHR.Dll.Att.AbsCheck.IsRepeatData(sNobr, dDateTimeB, dDateTimeE, false) ){
            lScript.Text = JBHR.Dll.Tools.MessageShowAlert("日期時間已在HR的資料裡");
            return;
        }

       // '計算請假時數
       JBHR.Dll.Att.AbsCal.AbsDetail oAbsDetail = JBHR.Dll.Att.AbsCal.AbsCalculationBy24(sNobr, sHcode, dDateB, dDateE, sTimeB, sTimeE, "",0);

        //'檢查請假剩餘時數是否足夠
        if(oAbsDetail.bBalance == false){ 
            lScript.Text = JBHR.Dll.Tools.MessageShowAlert("檢查請假剩餘時數是否足夠");
            return;
        }

        //'檢查請假時數是否符合最小單位
        if( oAbsDetail.bHcodeMin == false){ 
            lScript.Text = JBHR.Dll.Tools.MessageShowAlert("檢查請假時數是否符合最小單位");
            return;
        }

        //'檢查性別
        if( oAbsDetail.bSex == false){ 
            lScript.Text = JBHR.Dll.Tools.MessageShowAlert("性別不符");
            return;
        }

      //  '顯示計算時數/天數
        DayOrHour.Text = oAbsDetail.sHcodeUnit;

        if( oAbsDetail.sHcodeUnit == "天" ){
            LeaveDays.Text = oAbsDetail.iTotalDay.ToString();

        }else{
            LeaveDays.Text = oAbsDetail.iTotalHour.ToString();
        }


        //if( oAbsDetail.sHcodeUnit == "天" ){
        //    TotalHours.Text = Convert.ToString(oAbsDetail.iTotalHour * 8);

        //}else{
        //    TotalHours.Text = oAbsDetail.iTotalHour.ToString();
        //}


       // sHName.Text = leavecategory.SelectedItem.Text;
    }

    string getEmpInfo(string nobr)
    {
        HRDsTableAdapters.EmpInfoTableAdapter empad = new HRDsTableAdapters.EmpInfoTableAdapter();
        HRDs.EmpInfoDataTable empdt = empad.GetDataByNobr(nobr);
        string name = "";
        if (empdt.Rows.Count > 0)
        {
            name = empdt[0].NAME_C;
        }
        return name;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        bool isok = false;

        isok = JBHR.Dll.Att.AbsCal.AbsSaveBy24(lb_nobr.Text, leavecategory.SelectedValue, adate.SelectedDate.Value, ddate.SelectedDate.Value, StartDay.SelectedValue + StartMin.SelectedValue, EndDay.SelectedValue + EndMin.SelectedValue, "", LeaveReason.Text, "Portal", "", 0, "",0);

        if (isok)
        {
            
            lScript.Text = JBHR.Dll.Tools.MessageShowAlert("申請成功！");
        }
        else {
            lScript.Text = JBHR.Dll.Tools.MessageShowAlert("申請失敗！");
        }

        gvAbsView.DataBind();
       
    }
}
