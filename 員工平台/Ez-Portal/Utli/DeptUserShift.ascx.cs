using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 
using System.Data;
using BL;
public partial class Utli_DeptUserShift : JUserControl,IUC
{
    HRDsTableAdapters.BASETTSTableAdapter basettsAdapter = new HRDsTableAdapters.BASETTSTableAdapter();
    HRDsTableAdapters.BASETableAdapter baseAdapter = new HRDsTableAdapters.BASETableAdapter();
    HRDsTableAdapters.ATTENDTableAdapter attendAdapter = new HRDsTableAdapters.ATTENDTableAdapter();
    AttendDsTableAdapters.ROTETableAdapter roteAdapter = new AttendDsTableAdapters.ROTETableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteHelper siteHelper = new SiteHelper();
            DateTime startDatetime, endDatetime;
            siteHelper.SetDateRange(out startDatetime, out endDatetime, DateTime.Now.Date, JbUser.SalaDr);
            adate.SelectedDate = startDatetime;
            ddate.SelectedDate = endDatetime;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var pg = this.Page as JBWebPage;
        var m = pg.GetType().GetMethod("SetDeptValue");
        m.Invoke(pg, null);
        BindData();
    }


    public void BindData()
    {
        if (adate.SelectedDate == null)
            return;

        if (adate.SelectedDate.Value.AddMonths(6).CompareTo(ddate.SelectedDate.Value)<0)
        {
            JB.WebModules.Message.Show("日期只能查詢6個月內的");
            return;
        }

        DataTable dt = getTable(adate.SelectedDate.Value, ddate.SelectedDate.Value);

        AttendDs.ROTEDataTable roteDT = roteAdapter.GetData();

        string[] deptArr=lblDept.Text.Split(',');
        HRDs.BASETTSDataTable basettsDT = new HRDs.BASETTSDataTable();

        foreach (var d in deptArr)
        {
            basettsDT.Merge(basettsAdapter.GetEmpsLiveByDept(ddate.SelectedDate.Value, adate.SelectedDate.Value, d));
        }

                //過濾資料群組
        //SiteHelper siteHelper = new SiteHelper();
        //basettsDT = siteHelper.GetSelectedEmpData(basettsDT, "NOBR", Juser.SalaDrNobrList) as HRDs.BASETTSDataTable;


        foreach (HRDs.BASETTSRow row in basettsDT.Rows)
        {
            setTableData(dt, roteDT, row.NOBR, adate.SelectedDate.Value, ddate.SelectedDate.Value);
        }

        gvEmpRote.DataSource = dt;
        gvEmpRote.DataBind();
    }

    public void SetValue(string value)
    {
        lblDept.Text = value;
    }

    private void setTableData(DataTable dt, AttendDs.ROTEDataTable roteDT, string nobr, DateTime adate, DateTime ddate)
    {
        int nonWorkDays = 0;
        Double workHours = 0;

        HRDs.BASEDataTable baseDT = baseAdapter.GetData(nobr);
        if (baseDT.Rows.Count == 0)
            return;

        DataRow newRow = dt.NewRow();
        newRow["工號"] = nobr;
        newRow["姓名"] = baseDT[0].NAME_C;
        newRow["英文名"] = baseDT[0].NAME_E;

        HRDs.ATTENDDataTable attendDT = attendAdapter.GetDataByNobrBTWDate(nobr, adate, ddate);

        ROTE_REPO roteRepo = new ROTE_REPO();
        List<ROTE> roteList = roteRepo.GetAll();

        foreach (HRDs.ATTENDRow row in attendDT.Rows)
        {
            if (row.ROTE == "00")
            {
                nonWorkDays++;
            }

            AttendDs.ROTERow roteRow = roteDT.FindByROTE(row.ROTE);
            workHours = workHours + Convert.ToDouble(roteRow.WK_HRS);

            //newRow[row.ADATE.ToString("M-dd")] = row.ROTE;
            var roteObj = roteList.Where(p=>p.ROTE1==row.ROTE).FirstOrDefault();
            newRow[row.ADATE.ToString("M-dd")] = roteObj != null ? roteObj.ROTENAME : "";
        }


        newRow["排休天數"] = nonWorkDays;
        newRow["總工時"] = workHours;
        dt.Rows.Add(newRow);

    }

    private DataTable getTable(DateTime adate, DateTime ddate)
    {
        DataTable dt = new DataTable();

        setBasicCol(dt);

        setDateCol(dt, adate, ddate);

        return dt;
    }

    private void setBasicCol(DataTable dt)
    {
        DataColumn nobr = new DataColumn("工號", typeof(String));
        dt.Columns.Add(nobr);
        DataColumn name = new DataColumn("姓名", typeof(String));
        dt.Columns.Add(name);
        DataColumn nameE = new DataColumn("英文名", typeof(String));
        dt.Columns.Add(nameE);
        DataColumn nonWorkDayCount = new DataColumn("排休天數", typeof(int));
        dt.Columns.Add(nonWorkDayCount);
        DataColumn workHoursCount = new DataColumn("總工時", typeof(double));
        dt.Columns.Add(workHoursCount);
    }

    private void setDateCol(DataTable dt, DateTime adate, DateTime ddate)
    {
        DateTime datetime = adate;

        while (datetime <= ddate)
        {
            DataColumn col = new DataColumn(datetime.ToString("M-dd"), typeof(string));
            dt.Columns.Add(col);
            datetime = datetime.AddDays(1);
        }
    }


    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        BindData();

        Response.ClearContent();
        string excelFileName = "value.xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(excelFileName, System.Text.Encoding.UTF8));
        Response.ContentType = "application/excel";
        Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        gvEmpRote.RenderControl(htmlWrite);
        //GridView4.RenderControl(htmlWrite);
        //GridView5.RenderControl(htmlWrite);
        //GridView3.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString());
        Response.End();
    }
}
