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
using JB.WebModules;

public partial class Attendance_onlineSing : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!JbUser.NOBR.ToUpper().Trim().Equals("IOT07017"))
        {
            Button1.Visible = false;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       


        if (checkData()) {
            saveData();
        }
    }

    bool checkData() {
        bool isok = true;
        eHRDSTableAdapters.CARDTableAdapter crad = new eHRDSTableAdapters.CARDTableAdapter();
        eHRDS.CARDDataTable crdt = crad.GetDataByNobr(JbUser.NOBR, DateTime.Parse(DateTime.Now.ToShortDateString()));
        if (crdt.Rows.Count > 0) {
            for (int i = 0; i < crdt.Rows.Count; i++) {
                string HH = crdt[i].ONTIME.Substring(0, 2);
                if (DateTime.Now.ToString("HH").Equals(HH)) {
                    Message.Show("同1小時內不可簽到兩次,上次簽到時間為："+crdt[i].ONTIME);

                    return false;
                }
            
            }
        }



        return isok;
    
    }

    void saveData() {
        eHRDSTableAdapters.CARDTableAdapter crad = new eHRDSTableAdapters.CARDTableAdapter();
        eHRDS.CARDDataTable crdt = new eHRDS.CARDDataTable();
        eHRDS.CARDRow crrow = crdt.NewCARDRow();
        crrow.CODE = "1";
        crrow.NOBR = JbUser.NOBR;
        crrow.ADATE = DateTime.Parse(DateTime.Now.ToShortDateString());
        crrow.ONTIME = DateTime.Now.ToString("HHmm");
        crrow.CARDNO = "";
        crrow.KEY_DATE = DateTime.Now;
        crrow.KEY_MAN = JbUser.NAME_C.Trim();
        crrow.NOT_TRAN = false;
        crrow.DAYS = 0;
        crrow.REASON = "";
        crrow.LOS = false;
        crrow.IPADD = getIPAdd();
        crrow.MENO = "";
        crrow.SERNO = "";
        crdt.AddCARDRow(crrow);

        crad.Update(crdt);


        lb_time.Text = crrow.KEY_DATE.ToString();
        lb_ipadd.Text = getIPAdd();
        Message.Show("簽到完成！！");
    }

    string getIPAdd()
    {

        string ip = "";
        ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (ip == string.Empty)
        {
            ip = Request.ServerVariables["REMOTE_ADDR"];
        }
        else
        {

            ip = Request.UserHostAddress;
        }

        return ip;
    }
}
