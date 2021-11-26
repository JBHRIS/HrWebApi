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
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using BL;
public partial class AbsList : JBUserControl,IUC
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //DataTable dt;


        ////dt = JbHrCL.AbsCS.GetAbsInfo(lblNobr.Text, DateTime.Now, DateTime.Parse(Convert.ToString(DateTime.Now.Year) + "/01/01"),        
        ////   DateTime.Parse(DateTime.Now.Year.ToString() + "/12/31"));
        ////dt = JBHR.Dll.Att.AbsCal.AbsView(lblNobr.Text, DateTime.Now, "");
        //dt = JBHR.Dll.Att.AbsCal.AbsView(lblNobr.Text, DateTime.Now, "");

        //for (int i = 0; i < dt.Columns.Count; i++)
        //{
        //    if (dt.Columns[i].ColumnName.Trim().Equals("喪假(天)"))
        //    {
        //        //F
        //        eHRDSTableAdapters.ABSTTableAdapter abstad = new eHRDSTableAdapters.ABSTTableAdapter();
        //        eHRDS.ABSTDataTable abstdt = abstad.GetData(lblNobr.Text, DateTime.Now.ToShortDateString());
        //        //eHRDS.ABSTDataTable abstdt = abstad.GetData(lblNobr.Text, DateTime.Now.ToShortDateString());
        //        if (abstdt.Rows.Count == 0)
        //            continue;
        //        if (!abstdt[0].H_CODE.Trim().Equals("F"))
        //            continue;

        //        //string sT1, sT2, sT3, sName;

        //        dt.Rows[1][i] = Convert.ToString(abstdt[0].TOL_HOURS - decimal.Parse(dt.Rows[0][i].ToString()));

        //    }
        //}

        //GridView1.DataSource = dt;

        //// GridView1.DataSource = JbHrCL.AbsCS.GetAbsInfo(lblNobr.Text, DateTime.Parse("2008/12/30"),DateTime.Parse("2008/1/1"),
        ////        DateTime.Parse("2008/12/31"));
        //GridView1.DataBind();

        if (!IsPostBack)
        {
            setAbsData();

        }
    }

    void setAbsData()
    {
        string nobr = JbUser.NOBR;
        //別家公司用的，先mark起來
        //string nobr = lblNobr.Text;
        DateTime adate;
        DateTime ddate;

        adate = DateTime.Parse(Convert.ToString(DateTime.Now.Year) + "/01/01");
        //ddate = DateTime.Now;
        ddate = DateTime.Parse(DateTime.Now.Year.ToString() + "/12/31");

        decimal a1 = 0;//去年度剩餘年假
        decimal a2 = 0;//今年度年假
        decimal a3 = 0;//今年已請天數
        decimal a4 = 0;//可累計之天數
        decimal a5 = 0;//今年度剩餘天數
        decimal a6 = 0;//本月份已請天數
        decimal a7 = 0;//去年度剩餘年假未休天數


        eHRDSTableAdapters.AbsInfoTableAdapter absad = new eHRDSTableAdapters.AbsInfoTableAdapter();
        eHRDS.AbsInfoDataTable absdt = absad.GetData(nobr, adate, ddate);
        for (int i = 0; i < absdt.Rows.Count; i++)
        {
            if (absdt[i].H_NAME.Trim().Equals("特休(延)"))
            {
                a1 += absdt[i].TOL_HOURS;
            }
            else if (absdt[i].H_NAME.Trim().Equals("特休(得)"))
            {
                a2 += absdt[i].TOL_HOURS;
            }
            else
            {
                a3 += absdt[i].TOL_HOURS;
                if (DateTime.Now.Month == absdt[i].BDATE.Month)
                {
                    a6 += absdt[i].TOL_HOURS;
                }
            }
        }

        if ((a1 - a3) < 0)
        {
            a4 = a2 - Math.Abs((a1 - a3));
        }
        else
        {
            a4 = a2;
        }
        //    a4 = ;
        a5 = (a1 + a2) - a3;
        if ((a1 - a3) > 0)
        {
            a7 = a1 - a3;
        }

        DataTable dt = new DataTable();
        dt.Columns.Add("a1");
        dt.Columns.Add("a2");
        dt.Columns.Add("a3");
        dt.Columns.Add("a4");
        dt.Columns.Add("a5");
        dt.Columns.Add("a6");
        dt.Columns.Add("a7");


        DataRow row = dt.NewRow();
        row[0] = Math.Round(a1, 1);
        row[1] = Math.Round(a2, 1);
        row[2] = Math.Round(a3, 1);
        row[3] = Math.Round(a4, 1);
        row[4] = Math.Round(a5, 1);
        row[5] = Math.Round(a6, 1);
        row[6] = Math.Round(a7, 1);

        dt.Rows.Add(row);

        GridView2.DataSource = dt;
        GridView2.DataBind();


        //JbFlow.WebServiceSoapClient flowService = new JbFlow.WebServiceSoapClient();
        //string s = flowService.AbsInfoWithHrHide(DateTime.Now.Date, true, new JbFlow.ArrayOfString() { lblNobr.Text });

        //Newtonsoft.Json.Linq.JArray empAbsArr = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(s);
        //List<AbsenceDetailDto> flowAbsList = empAbsArr.ToObject<List<AbsenceDetailDto>>();

        //GridView4.DataSource = flowAbsList;
        //GridView4.DataBind();

        //GridView5.DataSource = flowAbsList.FindAll(p => p.GetHrs != 0);
        //GridView5.DataBind();
    }

    #region IUC 成員

    //public void BindData()
    //{
    //    JbFlow.WebServiceSoapClient flowService = new JbFlow.WebServiceSoapClient();

    //    string empAbsStr= flowService.AbsData(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 12, 31), new JbFlow.ArrayOfString(), new JbFlow.ArrayOfString() { lblNobr.Text });
    //    Newtonsoft.Json.Linq.JArray empAbsArr = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(empAbsStr);
    //    List<FlowProcessingDto> flowAbsList = empAbsArr.ToObject<List<FlowProcessingDto>>();

    //    string flowPsStr = flowService.AbsGoIng(new JbFlow.ArrayOfString(), new JbFlow.ArrayOfString() { lblNobr.Text });
    //    Newtonsoft.Json.Linq.JArray arr = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(flowPsStr);
    //    List<FlowProcessingDto> flowPsList = arr.ToObject<List<FlowProcessingDto>>();

    //    List<string> absCodeList = (from c in flowPsList select c.sHcode).ToList();
    //    absCodeList.AddRange((from c in flowAbsList select c.sHcode).ToList());

    //    absCodeList = (from c in absCodeList select c).Distinct().ToList();

    //    DataTable dt = new DataTable();
    //    dt.Columns.Add("LeaveName", typeof(string));
    //    dt.Columns.Add("LeaveCode", typeof(string));
    //    dt.Columns.Add("Unit", typeof(string));
    //    dt.Columns.Add("Approved", typeof(decimal));
    //    dt.Columns.Add("Processing", typeof(decimal));
        
    //    HCODE_REPO hcodeRepo = new HCODE_REPO();
    //    List<HCODE> hcodeList = hcodeRepo.GetAll();

    //    foreach (string item in absCodeList)
    //    {
    //        HCODE hcodeObj = (from c in hcodeList where c.H_CODE == item select c).FirstOrDefault();
    //        DataRow row = dt.NewRow();
    //        row["LeaveCode"] = item;
    //        row["LeaveName"] = hcodeObj.H_NAME;
    //        row["Unit"] = hcodeObj.UNIT;

    //        if (hcodeObj.UNIT.Equals("天"))
    //        {
    //            row["Approved"] = (from c in flowAbsList where c.sHcode == item select c.iTotalDay).Sum();
    //            row["Processing"] = (from c in flowPsList where c.sHcode == item select c.iTotalDay).Sum();                
    //        }
    //        else
    //        {
    //            row["Approved"] = (from c in flowAbsList where c.sHcode == item select c.iTotalHour).Sum();
    //            row["Processing"] = (from c in flowPsList where c.sHcode == item select c.iTotalHour).Sum(); 
    //        }


    //        dt.Rows.Add(row);
    //    }

    //    GridView1.DataSource = dt;
    //    GridView1.DataBind();
    //    setAbsData();
    //}

    public void BindData()
    {
        DataTable dt;
        dt = JBHR.Dll.Att.AbsCal.AbsView(lblNobr.Text, DateTime.Now, "");

        for (int i = 0; i < dt.Columns.Count; i++)
        {
            if (dt.Columns[i].ColumnName.Trim().Equals("喪假(天)"))
            {
                //F
                eHRDSTableAdapters.ABSTTableAdapter abstad = new eHRDSTableAdapters.ABSTTableAdapter();
                eHRDS.ABSTDataTable abstdt = abstad.GetData(lblNobr.Text, DateTime.Now.ToShortDateString());
                //eHRDS.ABSTDataTable abstdt = abstad.GetData(lblNobr.Text, DateTime.Now.ToShortDateString());
                if (abstdt.Rows.Count == 0)
                    continue;
                if (!abstdt[0].H_CODE.Trim().Equals("F"))
                    continue;

                //string sT1, sT2, sT3, sName;

                dt.Rows[1][i] = Convert.ToString(abstdt[0].TOL_HOURS - decimal.Parse(dt.Rows[0][i].ToString()));
            }
        }

        GridView1.DataSource = dt;

        // GridView1.DataSource = JbHrCL.AbsCS.GetAbsInfo(lblNobr.Text, DateTime.Parse("2008/12/30"),DateTime.Parse("2008/1/1"),
        //        DateTime.Parse("2008/12/31"));

        //隱藏剩餘
        if (dt.Rows.Count > 1)
        {
            dt.Rows[1].Delete();
        }


        //處理在途中
        try
        {
            //JbFlow.WebServiceSoapClient flowService = new JbFlow.WebServiceSoapClient();
            //string flowPsStr = flowService.AbsGoIng(new JbFlow.ArrayOfString(), new JbFlow.ArrayOfString() { lblNobr.Text });
            //Newtonsoft.Json.Linq.JArray arr = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(flowPsStr);
            //List<FlowProcessingDto> flowPsList = arr.ToObject<List<FlowProcessingDto>>();

            //List<string> absCodeList = (from c in flowPsList select c.sHcode).Distinct().ToList();

            DataTable dt3 = new DataTable();
            dt3.Columns.Add("LeaveName", typeof(string));
            dt3.Columns.Add("LeaveCode", typeof(string));
            dt3.Columns.Add("Unit", typeof(string));
            dt3.Columns.Add("Approved", typeof(decimal));
            dt3.Columns.Add("Processing", typeof(decimal));

            HCODE_REPO hcodeRepo = new HCODE_REPO();
            List<HCODE> hcodeList = hcodeRepo.GetAll();

            //foreach (string item in absCodeList)
            //{
            //    HCODE hcodeObj = (from c in hcodeList where c.H_CODE == item select c).FirstOrDefault();
            //    DataRow row = dt3.NewRow();
            //    row["LeaveCode"] = item;
            //    row["LeaveName"] = hcodeObj.H_NAME;
            //    row["Unit"] = hcodeObj.UNIT;

            //    if (hcodeObj.UNIT.Equals("天"))
            //        row["Processing"] = (from c in flowPsList where c.sHcode == item select c.iTotalDay).Sum();
            //    else
            //        row["Processing"] = (from c in flowPsList where c.sHcode == item select c.iTotalHour).Sum();

            //    dt3.Rows.Add(row);
            //}

            GridView3.DataSource = dt3;
            GridView3.DataBind();
        }
        catch
        {

        }

        dt.Rows[0][0] = "已核准";

        GridView1.DataBind();
        setAbsData();
    }

    public void SetValue(string value)
    {
        lblNobr.Text = value;
    }

    #endregion
}
