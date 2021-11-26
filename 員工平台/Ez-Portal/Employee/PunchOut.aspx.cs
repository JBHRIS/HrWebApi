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
using BL;
using System.Linq;
using System.Collections.Generic;
using Telerik.Web.UI;
public partial class PunchOut : JBWebPage
{
    private BASE_REPO baseRepo = new BASE_REPO();
    private CARD_REPO cardRepo = new CARD_REPO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbName.Text = Juser.NameC;
            var emp = baseRepo.GetByNobr_Dlo(Juser.Nobr);
            if (emp == null)
                pnl1.Enabled = false;
            else
            {
                if (emp.BASETTS[0].COUNT_PASS)
                    pnl1.Enabled = true;
                else
                    pnl1.Enabled = false;
            }

            lbTime.Text = DateTime.Now.ToString("yyyy/MM/dd　HH:mm:ss");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DateTime dt = DateTime.Now;
        CARD obj = new CARD();
        obj.CODE = "Portal";
        obj.NOBR = Juser.Nobr;
        obj.ADATE = dt.Date;
        obj.ONTIME = dt.ToString("HHmm");
        obj.CARDNO = "";
        obj.KEY_DATE = dt;
        obj.KEY_MAN = Juser.Nobr;
        obj.NOT_TRAN = false;
        obj.DAYS = 0;
        obj.LOS = false;
        obj.REASON = "";
        obj.IPADD = SiteHelper.GetClientIP(Page.Request);
        obj.MENO = "";
        obj.SERNO = "";


        var r2 = cardRepo.GetLastestCardByDateNobr(obj.NOBR, obj.ADATE, obj.ONTIME);

        if (r2 == null)
        {
            cardRepo.Add(obj);
            cardRepo.Save();
        }

        var record = cardRepo.GetLastestCardByDateNobr(Juser.Nobr, dt.Date);
        if (record == null)
        {
            Show("找不到 " + dt.ToShortDateString() + " 的卡片");
        }

        Show("最新卡片為 " + record.ADATE.ToString("yyyy/MM/dd") + " 時分:" + record.ONTIME);
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        lbTime.Text = DateTime.Now.ToString("yyyy/MM/dd　HH:mm:ss");
    }
}
