using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class FormCard : WebPageBase
    {
        private dcHrDataContext dcHR = new dcHrDataContext();
        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompanySetting != null)
            {
                dcHR.Connection.ConnectionString = CompanySetting.ConnHr;
                dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
            }
            if (!IsPostBack)
            {
                OldDal.Dao.Att.CardDao oCardDao = new OldDal.Dao.Att.CardDao(dcHR.Connection);
                var CardData = oCardDao.GetData(_User.EmpId, DateTime.Now);
                if (CardData.Count > 0)
                {
                    lblCardTime.Text = CardData[CardData.Count - 1].keyDate.ToString();
                }
            }
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            var Ip = WebPage.GetClientIP(Context);
            lblCardIP.Text = Ip;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            OldDal.Dao.Att.CardDao oCardDao = new OldDal.Dao.Att.CardDao(dcHR.Connection);
            var DateB = DateTime.Now;
            var TimeB = DateB.ToString("HHmm");
            var Ip = WebPage.GetClientIP(Context);
            lblCardIP.Text = Ip;
            var result = oCardDao.SaveCard(_User.EmpId, DateB.Date, TimeB, "", sKeyMan: "Portal", isLos: false,IP: lblCardIP.Text);
            if (result)
            {
                lblCardTime.Text = DateB.ToString();
                lblMsg.CssClass = "badge badge-primary animated shake";
                lblMsg.Text = "打卡成功";
            }
            else
            {
                lblMsg.CssClass = "badge badge-danger animated shake";
                lblMsg.Text = "打卡失敗，請勿在同一分鐘內連續打卡";
            }
        }
    }
}