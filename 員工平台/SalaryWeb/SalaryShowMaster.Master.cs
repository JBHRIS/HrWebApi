using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SalaryWeb
{
    public partial class SalaryShowMaster : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        // 設定是否固定時間內更新頁面
        private void Refresh()
        {
            const string DeadlineQueryName = "Deadline";

            string deadlineStr = (Request.QueryString[DeadlineQueryName] as string) ?? "-1";

            int deadline;
            bool canParseDeadline = int.TryParse(deadlineStr, out deadline);

            if (canParseDeadline && deadline > 0)
            {
                HtmlGenericControl refreshControl = new HtmlGenericControl("meta");
                refreshControl.Attributes["http-equiv"] = "refresh";
                refreshControl.Attributes["content"] = deadline.ToString();
                Page.Header.Controls.Add(refreshControl);
            }
        }
    }
}