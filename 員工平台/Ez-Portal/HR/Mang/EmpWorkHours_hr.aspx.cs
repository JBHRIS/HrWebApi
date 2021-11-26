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
using System.Linq;
using System.Text;

public partial class HR_Mang_EmpWorkHours_hr : JBWebPage
{
    private JBHRModel.JBHRModelDataContext oc = new JBHRModel.JBHRModelDataContext();
    //private JBHRDataContext oc = new JBHRDataContext();
    private  const string SESSION_NAME = "WORK_HOURS";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // string dept = "ZZ";// JbUser.DepartmentCode;
            Session[SESSION_NAME] = null;
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1");
            ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        GetData();        
    }
    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        if (Session[SESSION_NAME] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, GridView2, (AttendDs.WorkHoursDataTable)Session[SESSION_NAME], HttpUtility.UrlEncode("員工工時",Encoding.UTF8));
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }

    void GetData()
    {
        AttendDs.WorkHoursDataTable workHrsDT = new AttendDs.WorkHoursDataTable();

        //var basetts = (from c in oc.BASETTS where c.ADATE <= ddate.SelectedDate.Value
        //               && c.DDATE >= adate.SelectedDate.Value && new string[] { "1", "4", "6" }.Contains(c.TTSCODE)
        //               select c).ToList();
        var basetts = (from c in oc.BASETTS
                       where c.ADATE <= ddate.SelectedDate.Value
                           && c.DDATE >= adate.SelectedDate.Value && new string[] { "1", "4", "6" }.Contains(c.TTSCODE)
                       select c).ToList();
                       //select c).WhereIn(p => p.TTSCODE, new string[] { "1", "4", "6" }).ToList();
        //       select c).WhereIn(p=>p.TTSCODE,ttsArray).ToList();

        basetts = basetts.FindAll(p => Juser.SalaDrNobrList.Contains(p.NOBR));



        var holi = (from c in oc.HOLI where c.H_DATE <= ddate.SelectedDate.Value && c.H_DATE >= adate.SelectedDate.Value select c).ToList();
        var b = (from c in oc.BASE select c).ToList();
        var ot = (from c in oc.OT where c.BDATE <= ddate.SelectedDate.Value  && c.BDATE >= adate.SelectedDate.Value select c).ToList();
        var dept = (from c in oc.DEPT select c).ToList();
        var job = (from c in oc.JOB select c).ToList();
        var rote12 = (from c in oc.ROTE where c.WK_HRS == 12 select c).ToList();
        //var attend = (from c in oc.ATTEND where c.ADATE <= ddate.SelectedDate.Value && c.ADATE >= adate.SelectedDate.Value && c.ROTE !="00" select c).ToList();

        TimeSpan ts= ddate.SelectedDate.Value - adate.SelectedDate.Value;        

        foreach (var item in basetts)
        {
            //排除掉，當月有異動資料的人，選最後的一筆
            var data = (from c in basetts where c.NOBR == item.NOBR && c.ADATE > item.ADATE select c).FirstOrDefault();

            if (data !=null)
            {
                continue;
            }

            int bWrokDays = (from c in holi where c.HOLI_CODE == item.HOLI_CODE select c).Count();
            var objB = (from c in b where c.NOBR == item.NOBR select c).FirstOrDefault();
            var objDept = (from c in dept where c.D_NO == item.DEPT select c).FirstOrDefault();
            var objJob = (from c in job where c.JOB1 == item.JOB select c).FirstOrDefault();

            AttendDs.WorkHoursRow workHrsRow = workHrsDT.NewWorkHoursRow();
            
            //基準工時=當月天數-行事曆休假天數
            workHrsRow.BaseWorkHours = (ts.Days-bWrokDays+1)*8;
            if (objDept != null)
                workHrsRow.DeptName = objDept.D_NAME;
            if (objB != null)
            {
                workHrsRow.Name_C = objB.NAME_C;
                workHrsRow.Name_E = objB.NAME_E;
            }
            if (objJob != null)
                workHrsRow.JobName = objJob.JOB_NAME;

            workHrsRow.Nobr = item.NOBR;
            workHrsRow.Indt = item.CINDT.Value.ToShortDateString();

            //工作天數 排班工時=當月出勤上班日*8
            var attendDays = (from c in oc.ATTEND where c.ADATE <= ddate.SelectedDate.Value && c.ADATE >= adate.SelectedDate.Value 
                              && c.ROTE != "00" && c.NOBR ==item.NOBR select c).ToList();

            //實際工時=當月出勤時數加總(attend.att_hrs)
            workHrsRow.RealWorkHours = Convert.ToDouble((from c in attendDays select c.ATT_HRS).Sum());
            //workHrsRow.RealWorkHours = attendDays.Count * 8;


            //固定加班時數=(select sum(ot_hrs) from ot where nobr=@nobr and bdate between @d1 and @d2 and syscreat=1)
            workHrsRow.OtHours = Convert.ToDouble((from c in ot where c.NOBR == item.NOBR && c.SYSCREAT == true select c.OT_HRS).Sum()); 

            workHrsRow.OtHoursAmt = workHrsRow.OtHours + workHrsRow.RealWorkHours - workHrsRow.BaseWorkHours;

            //是否顯示
            if (ckRealLessThenBase.Checked == true)
            {
                if (workHrsRow.RealWorkHours >= workHrsRow.BaseWorkHours)
                    continue;
            }            
            
            workHrsDT.Rows.Add(workHrsRow);
        }

        Session[SESSION_NAME] = workHrsDT;
        GridView2.DataSource = workHrsDT;
         GridView2.DataBind(); 

   
    //  Session["mealMoney"] = dt;
      //GridView2.DataSource = dt;
     // GridView2.DataBind(); 
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session[SESSION_NAME] != null)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = (AttendDs.WorkHoursDataTable)Session[SESSION_NAME];
            GridView2.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }
}
