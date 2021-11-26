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

public partial class Employee_EmpInfoStateByUser :JBUserControl,ICU {
    protected void Page_Load(object sender, EventArgs e) {

        //if (!IsPostBack) {
        //    lb_nobr.Text = JbUser.NOBR;
        //    bindGrid();
        //}
   
        
    }

    #region ICU 成員

    public void bindGrid() {
       


        DataTable dt = new DataTable();
        dt.Columns.Add("類別");
        dt.Columns.Add("日期");

        HRDsTableAdapters.basettsTableAdapter ttsad = new HRDsTableAdapters.basettsTableAdapter();
        HRDs.basettsDataTable ttsdt = ttsad.GetData(lb_nobr.Text);

        for (int i = 0; i < ttsdt.Rows.Count; i++) {
            DataRow newRow = dt.NewRow();

            switch (ttsdt[i].TTSCODE.Trim()) {
                case "1":
                    newRow[0] = "到職";
                    newRow[1] = ttsdt[i].INDT.ToShortDateString();

                    break;
                case "2":
                    newRow[0] = "離職";
                    newRow[1] = ttsdt[i].OUDT.ToShortDateString();

                    break;
                case "3":
                    newRow[0] = "留職停薪";
                    newRow[1] = ttsdt[i].STDT.ToShortDateString();

                    break;
                case "4":
                    newRow[0] = "留停復職";
                    newRow[1] = ttsdt[i].STINDT.ToShortDateString();

                    break;
                case "5":
                    newRow[0] = "留停離職";
                    newRow[1] = ttsdt[i].STOUDT.ToShortDateString();

                    break;

            }

            dt.Rows.Add(newRow);
        }

        double inCompYear = 0;
        double leCompYear = 0;
        double chCompYear = 0;

        DateTime endDate = new DateTime();
        HRDs.basettsDataTable ttsNowInfodt = ttsad.GetDataByNowInfo(lb_nobr.Text);
        if (ttsNowInfodt.Rows.Count <= 0)
            return;


        switch (ttsNowInfodt[0].TTSCODE.Trim()) {
            case "1":
            case "4":
            case "6":
                lb_state.Text = "在職中.";
                endDate = DateTime.Now;
                break;
            case "2":
                lb_state.Text = "已離職.";
                endDate = ttsNowInfodt[0].OUDT;
                break;
            case "3":
                lb_state.Text = "留停中.";
                endDate = ttsNowInfodt[0].STINDT;
                break;
            case "5":
                lb_state.Text = "留停離職.";
                endDate = ttsNowInfodt[0].STOUDT;
                break;

        }


        TimeSpan ts = (TimeSpan)(endDate - DateTime.Parse(ttsNowInfodt[0].INDT.ToShortDateString()));
        inCompYear = Math.Round((double)ts.Days / 365, 2, MidpointRounding.AwayFromZero);

        HRDs.basettsRow[] ttsrows = (HRDs.basettsRow[])ttsdt.Select("ttscode='4'");
        for (int i = 0; i < ttsrows.Length; i++) {
            TimeSpan tss = (TimeSpan)(ttsrows[i].STINDT - ttsrows[i].STDT);
            leCompYear += Math.Round((double)tss.Days / 365, 2, MidpointRounding.AwayFromZero);

        }



        DateTime indt = ttsNowInfodt[0].INDT;

        int mo = 0;
        int ye = 0;
        indt.AddDays(leCompYear);
        indt = indt.AddMonths(1);
        for (; indt < DateTime.Now;)
        {
          
            if (mo == 12)
            {
                ye += 1;
                mo = 0;
            }
            mo += 1;
            indt = indt.AddMonths(1);
            if (indt > DateTime.Now)
                break;

        }
     
        

        chCompYear = inCompYear - leCompYear;
        lb_year.Text = chCompYear.ToString();

        lb_year.Text = ye + "年" + mo.ToString() + "月";
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    #endregion
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        //GridView1.Rows[0].Cells[0].Width = 100;
    }
}
