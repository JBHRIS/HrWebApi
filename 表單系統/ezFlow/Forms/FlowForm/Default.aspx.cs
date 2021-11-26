using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class _Default : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        //ezFlow.Flow oFlow = new ezFlow.Flow();


        //GridView1.DataSource = oFlow.wfFormApp;
        //GridView1.DataBind();

        //string[] arr = ("ming").Split(',');

        //string sss = htmlSign(266);

        //JBHR.Dll.dsAtt.JB_HR_CardDataTable dtCard = JBHR.Dll.Att.Card("970378", Convert.ToDateTime("2012/3/2"));
        //if (dtCard.Rows.Count > 0)
        //    Label1.Text = JBHR.Dll.Tools.ConvertDataTableToHtml(dtCard, "sOnTime", 10);

        //string bbb = "";
        //string aaa = "123" +
        //    bbb == "" ? "456" : "789" +
        //    "000";

        //string ccc = "865";

        //string sNobr = "10200007"; // TODO: 初始化為適當值
        //DateTime dDate = new DateTime(2012, 12, 29); // TODO: 初始化為適當值
        //string sTime = "0828"; // TODO: 初始化為適當值
        //string sReason = ""; // TODO: 初始化為適當值
        //string sKeyMan = "JJ"; // TODO: 初始化為適當值
        //string sNote = "NN"; // TODO: 初始化為適當值
        //string sSerno = "JJ"; // TODO: 初始化為適當值
        //JBHR.Dll.Att.CardCal.CardSave(sNobr, dDate, sTime, sReason, sKeyMan, sNote, sSerno);

        int iAttDay = 25;

        DateTime dDate = new DateTime(2013, 1, 30);
        DateTime dDateB = DateTime.Now;
        DateTime dDateE = DateTime.Now;

        if (dDate.Day > iAttDay)
            dDate = dDate.AddMonths(1);

        dDateE = new DateTime(dDate.Year, dDate.Month
               , DateTime.DaysInMonth(dDate.Year, dDate.Month) <= iAttDay
               ? DateTime.DaysInMonth(dDate.Year, dDate.Month) : iAttDay);

        //加一天減一個月
        dDateB = dDateE.AddDays(1).AddMonths(-1);

        WebServiceAbs.WebService o = new WebServiceAbs.WebService();
        //string sss = o.AbsCancel("10201015", "2013/02/25", "2013-02-25", "", "", "JJ", "aaa");
 
        //用部門取得資料
        List<string> lsDept = new List<string>();
        List<string> lsNobr = new List<string>();
        lsDept.Add("AGFAAAB");
        string aaa = o.AbsGoIng(lsDept.ToArray(), lsNobr.ToArray());

        //用工號取得資料
        lsDept = new List<string>();
        lsNobr = new List<string>();
        lsNobr.Add("10100634");
        aaa = o.AbsGoIng(lsDept.ToArray(), lsNobr.ToArray());

        //取得全部在途中資料
        lsDept = new List<string>();
        lsNobr = new List<string>();
        aaa = o.AbsGoIng(lsDept.ToArray(), lsNobr.ToArray());

        //取得某一員工的請假資料
        dDateB = new DateTime(2013, 1, 1);
        dDateE = new DateTime(2013, 12, 31);
        lsNobr.Add("10100030");
        aaa = o.AbsData(dDateB, dDateE, lsDept.ToArray(), lsNobr.ToArray());

        lsDept = new List<string>();
        lsNobr = new List<string>();
        lsNobr.Add("10100955");
        List<string> lsState = new List<string>();
        lsState.Add("1");
        lsState.Add("2");
        lsState.Add("3");
        aaa = AbsFlow(new DateTime(2013, 1, 1), new DateTime(2013, 8, 22), "2", null, lsNobr, lsState);


        //JBHR.Dll.dcBasDataContext dcBas = new JBHR.Dll.dcBasDataContext();

        //var rTtscd = (from a in dcBas.JB_HR_Ttscd
        //              where a.sCodeDisp == "C11"
        //              && dcBas.GetCodeFilterByNobr("TTSCD", a.sCode, "10400034", dDate.Date).Value
        //              select a).FirstOrDefault();

        //JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM211", "10400034", dDate.Date);
        //var CompseCode = AppConfig.GetConfig("ComposeLeaveGetCode").GetString();

        //var ccc = JBHR.Dll.Att.OtHoursSum("10202693", "201304");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Flow.transHtml("Abs1/Check.aspx?ApView=24267", "~/Upload/" + "bbb.html");
    }

    public string AbsFlow(DateTime dDateB, DateTime dDateE, string sCat, List<string> arrDept = null, List<string> arrNobr = null, List<string> arrState = null)
    {
        if (arrDept == null)
            arrDept = new List<string>();

        if (arrNobr == null)
            arrNobr = new List<string>();

        if (arrState == null)
            arrState = new List<string>();

        List<string> lsAbsCat = new List<string>();

        if (sCat == "0")
        {
            lsAbsCat.Add("Abs");
            lsAbsCat.Add("Abs1");
        }
        else if (sCat == "2")
            lsAbsCat.Add("Abs1");
        else
            lsAbsCat.Add("Abs");


        DataTable dt = new DataTable();
        dt.Columns.Add("sNobr", typeof(string)).DefaultValue = "";
        dt.Columns.Add("sNameC", typeof(string)).DefaultValue = "";
        dt.Columns.Add("sNameE", typeof(string)).DefaultValue = "";
        dt.Columns.Add("dDateB", typeof(string)).DefaultValue = DateTime.Now.ToShortDateString();
        dt.Columns.Add("dDateE", typeof(string)).DefaultValue = DateTime.Now.ToShortDateString();
        dt.Columns.Add("sTimeB", typeof(string)).DefaultValue = "";
        dt.Columns.Add("sTimeE", typeof(string)).DefaultValue = "";
        dt.Columns.Add("sHcode", typeof(string)).DefaultValue = "";
        dt.Columns.Add("sHcodeName", typeof(string)).DefaultValue = "";
        dt.Columns.Add("iTotalDay", typeof(decimal)).DefaultValue = 0;
        dt.Columns.Add("iTotalHour", typeof(decimal)).DefaultValue = 0;
        dt.Columns.Add("sUnit", typeof(string)).DefaultValue = "";
        dt.Columns.Add("sNote", typeof(string)).DefaultValue = "";
        dt.Columns.Add("sYYMM", typeof(string)).DefaultValue = "";
        dt.Columns.Add("sState", typeof(string)).DefaultValue = "";

        dcFlowDataContext dcFlow = new dcFlowDataContext();
        dcFormDataContext dcForm = new dcFormDataContext();

        var lsProcessID = (from c in dcFlow.wfFormApp
                           where (arrState.Contains(c.sState) || arrState.Count == 0)
                           && lsAbsCat.Contains(c.sFormCode)
                           //&& (c.sFormCode == "Abs" || c.sFormCode == "Abs1")
                           select c.sProcessID).ToList();

        var lsAbs = (from c in dcForm.wfAppAbs
                     where lsProcessID.Contains(c.sProcessID)
                     && (arrState.Contains(c.sState) || arrState.Count == 0)
                     && (arrDept.Contains(c.sDept) || arrDept.Count == 0)
                     && (arrNobr.Contains(c.sNobr) || arrNobr.Count == 0)
                     && dDateB.Date < c.dDateE.Date
                     && dDateE.Date > c.dDateB.Date
                     select c).ToList();

        var lsNobr = lsAbs.Select(p => p.sNobr).ToArray();

        var dcBas = new JBHR.Dll.dcBasDataContext();

        var rsEmp = (from c in dcBas.JB_HR_Base
                     where lsNobr.Contains(c.sNobr)
                     select new
                     {
                         Nobr = c.sNobr,
                         NameE = c.sNameE,
                     }).ToList();

        //var arrHcode = JBHR.Dll.Att.Hcode().Where(p => p.bDisplayForm).Select(p => p.sHcode).ToArray();
        var rsHcode = JBHR.Dll.Att.Hcode("").ToList();

        DataRow r;
        foreach (var rAbs in lsAbs)
        {
            var rEmp = rsEmp.Where(p => p.Nobr == rAbs.sNobr).FirstOrDefault();

            var rHcode = rsHcode.Where(p => p.sHcode == rAbs.sHcode).FirstOrDefault();
            if (rHcode != null)
            {
                r = dt.NewRow();
                r["sNobr"] = rAbs.sNobr;
                r["sNameC"] = rAbs.sName;
                r["sNameE"] = rEmp != null ? rEmp.NameE : "";
                r["dDateB"] = rAbs.dDateB.ToShortDateString();
                r["dDateE"] = rAbs.dDateE.ToShortDateString();
                r["sTimeB"] = rAbs.sTimeB;
                r["sTimeE"] = rAbs.sTimeE;
                r["sHcode"] = rAbs.sHcode;
                r["sHcodeName"] = rAbs.sHname;
                r["iTotalDay"] = rAbs.iTotalDay;
                r["iTotalHour"] = rAbs.iTotalHour;
                r["sUnit"] = rHcode.sUnit;
                r["sNote"] = rAbs.sNote;
                r["sYYMM"] = rAbs.sSalYYMM;
                r["sState"] = rAbs.sState;
                dt.Rows.Add(r);
            }
        }

        return GetJson(dt);
    }
    public string GetJson(DataTable dt)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row; foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, dr[col]);
            }
            rows.Add(row);
        }
        return serializer.Serialize(rows);
    }

    public string htmlSign(int iProcessID)
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();

        var dtSignM = (from c in dcFlow.wfFormSignM
                       where c.idProcess == iProcessID
                       orderby c.dKeyDate
                       select c).CopyToDataTable();

        dtSignM.Columns.Remove("iAutoKey");
        dtSignM.Columns.Remove("sFormCode");
        dtSignM.Columns.Remove("sFormName");
        dtSignM.Columns.Remove("sProcessID");
        dtSignM.Columns.Remove("idProcess");
        dtSignM.Columns.Remove("sKey");
        dtSignM.Columns.Remove("sNobr");
        dtSignM.Columns.Remove("sDept");
        dtSignM.Columns.Remove("sDeptName");
        dtSignM.Columns.Remove("sJob");
        dtSignM.Columns.Remove("sJobName");
        dtSignM.Columns.Remove("sRole");
        dtSignM.Columns.Remove("bSign");
        dtSignM.Columns.Remove("sSign");

        dtSignM.Columns["sName"].ColumnName = "姓名";
        dtSignM.Columns["sNote"].ColumnName = "簽核內容";
        dtSignM.Columns["dKeyDate"].ColumnName = "簽核日期時間";

        return JBHR.Dll.Tools.ConvertToHtmlFile(dtSignM);
    }
}
