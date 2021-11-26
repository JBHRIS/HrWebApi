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

using System.IO;

public partial class HrNotice : System.Web.UI.Page
{
    ezClientDSTableAdapters.HrNoticeTableAdapter HrNoticeTA = new ezClientDSTableAdapters.HrNoticeTableAdapter();
    ezClientDSTableAdapters.HrNoticeFilesTableAdapter HrNoticeFilesTA = new ezClientDSTableAdapters.HrNoticeFilesTableAdapter();

    ezClientDS oezClientDS = new ezClientDS();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblAutoKey.Text = Request["auto"];

        HrNoticeTA.FillByKey(oezClientDS.HrNotice, int.Parse(lblAutoKey.Text));
        if (oezClientDS.HrNotice.Rows.Count > 0) {
            ezClientDS.HrNoticeRow r = (ezClientDS.HrNoticeRow)oezClientDS.HrNotice.Rows[0];
            lbSubject.Text = r.sCaption;
            lbContent.Text = r.sContent;
            lbDate.Text = r.dDate.ToShortDateString();
        }
    }
    protected void gvFiles_RowCommand(object sender, GridViewCommandEventArgs e) {
        string CommandName = e.CommandName;
        string CommandArgument = e.CommandArgument.ToString();

        if (CommandName == "Download") {
            HrNoticeFilesTA.FillByKey(oezClientDS.HrNoticeFiles, int.Parse(CommandArgument));
            ezClientDS.HrNoticeFilesRow r = (ezClientDS.HrNoticeFilesRow)oezClientDS.HrNoticeFiles.Rows[0];

            string FN = Server.MapPath("./Upload/" + r.sServerName);
            FileInfo fi = new FileInfo(FN);

            if (fi.Exists) {
                Response.ClearHeaders();
                Response.Clear();
                Response.AddHeader("Accept-Language", "zh-tw");
                Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(r.sUploadName, System.Text.Encoding.UTF8));

                Response.AddHeader("Content-Length", fi.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(fi.FullName);
                Response.Flush();
                Response.End();
            }
            else {
                if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "ErrorMsg")) {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "ErrorMsg", "alert('系統找不到檔案');", true);
                }
            }
        }
    }
}
