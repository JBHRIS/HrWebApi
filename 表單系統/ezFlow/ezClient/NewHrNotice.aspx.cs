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

public partial class NewHrNotice : System.Web.UI.Page
{
    ezClientDSTableAdapters.HrNoticeTableAdapter HrNoticeTA = new ezClientDSTableAdapters.HrNoticeTableAdapter();
    ezClientDSTableAdapters.HrNoticeFilesTableAdapter HrNoticeFilesTA = new ezClientDSTableAdapters.HrNoticeFilesTableAdapter();

    ezClientDS oezClientDS = new ezClientDS();

    protected void Page_Load(object sender, EventArgs e) { }

    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e) {
        string CommandName = e.CommandName;
        string CommandArgument = e.CommandArgument.ToString();

        //新增公告
        if (CommandName == "NewNotice") {
            lblAutoKey.Text = "0";

            mv.ActiveViewIndex = 1;
        }
        else if (CommandName == "SelectNotice") {
            lblAutoKey.Text = CommandArgument;

            mv.ActiveViewIndex = 1;

            HrNoticeTA.FillByKey(oezClientDS.HrNotice, int.Parse(lblAutoKey.Text));
            ezClientDS.HrNoticeRow r = (ezClientDS.HrNoticeRow)oezClientDS.HrNotice.Rows[0];
            txtCaption.Text = r.sCaption;
            txtContent.Value = r.sContent;
            txtDateA.Text = r.dDateA.ToShortDateString();
            txtDateD.Text = r.dDateD.ToShortDateString();
            lblMan.Text = r.sKeyMan;
            lblDate.Text = r.dDate.ToShortDateString();
        }
        else if (CommandName == "SelectFiles") {
            lblAutoKey.Text = CommandArgument;

            mv.ActiveViewIndex = 2;
        }
        else if (CommandName == "Delete") {
            HrNoticeFilesTA.FillByHrNotice_iAutoKey(oezClientDS.HrNoticeFiles, int.Parse(CommandArgument));

            foreach (ezClientDS.HrNoticeFilesRow r in oezClientDS.HrNoticeFiles.Rows) {
                string FN = Server.MapPath("./Upload/" + r.sServerName);
                FileInfo fi = new FileInfo(FN);
                fi.Delete();
                r.Delete();
            }

            HrNoticeFilesTA.Update(oezClientDS.HrNoticeFiles);

            if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "SuccessMsg")) {
                Page.ClientScript.RegisterStartupScript(typeof(string), "SuccessMsg", "alert('刪除成功');", true);
            }
        }
        else if (CommandName == "View") {
            string link = "MyFrame.aspx?url=HrNotice.aspx?auto=" + CommandArgument;
            string script = "var sFeatures = 'dialogWidth:760px;dialogHeight:500px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
                "window.showModalDialog('" + link + "', '', sFeatures);";
            if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "HrPost"))
                Page.ClientScript.RegisterStartupScript(typeof(string), "HrPost", script, true);
        }

        btnSend.CommandName = lblAutoKey.Text == "0" ? "Add" : "Update";
        btnSend.Text = lblAutoKey.Text == "0" ? "新增" : "修改";
    }

    protected void btnSend_Click(object sender, EventArgs e) {
        ezClientDS.HrNoticeRow r;
        DateTime DateA = new DateTime(1900, 1, 1);
        DateTime DateD = new DateTime(9999, 12, 31);

        try {
            DateA = DateTime.Parse(txtDateA.Text);
            DateD = DateTime.Parse(txtDateD.Text);
        }
        catch {
            if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "ErrorMsg")) {
                Page.ClientScript.RegisterStartupScript(typeof(string), "ErrorMsg", "alert('日期格式錯誤');", true);
            }

            return;
        }

        if (txtCaption.Text.Trim().Length == 0) {
            if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "ErrorMsg")) {
                Page.ClientScript.RegisterStartupScript(typeof(string), "ErrorMsg", "alert('主旨一定要輸入');", true);
            }

            return;
        }

        //新增
        if (btnSend.CommandName == "Add") {
            HrNoticeTA.Fill(oezClientDS.HrNotice);
            r = oezClientDS.HrNotice.NewHrNoticeRow();
        }
        else {  //修改
            HrNoticeTA.FillByKey(oezClientDS.HrNotice, int.Parse(lblAutoKey.Text));
            r = (ezClientDS.HrNoticeRow)oezClientDS.HrNotice.Rows[0];
        }

        r.sCaption = txtCaption.Text;
        r.sContent = txtContent.Value;
        r.dDateA = DateA;
        r.dDateD = DateD;
        r.sKeyMan = Request.Cookies["ezFlow"]["Emp_id"].ToString();
        r.dDate = DateTime.Now;

        if (btnSend.CommandName == "Add") {
            oezClientDS.HrNotice.AddHrNoticeRow(r);
        }

        HrNoticeTA.Update(oezClientDS.HrNotice);

        txtCaption.Text = "";
        txtContent.Value = "";

        gv.DataBind();
        mv.ActiveViewIndex = 0;

        if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "SuccessMsg")) {
            Page.ClientScript.RegisterStartupScript(typeof(string), "SuccessMsg", "alert('完成');", true);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e) {
        mv.ActiveViewIndex = 0;
        gv.DataBind();
    }

    //上傳檔案
    protected void btnUpload_Click(object sender, EventArgs e) {
        FileUpload file = fuNotice;

        if (!file.HasFile) {
            if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "ErrorMsg")) {
                Page.ClientScript.RegisterStartupScript(typeof(string), "ErrorMsg", "alert('未指定要上傳的檔案');", true);
            }

            return;
        }

        string fileName = DateTime.Now.ToFileTime().ToString();
        file.PostedFile.SaveAs(Server.MapPath(".") + "\\Upload\\" + fileName);

        HrNoticeFilesTA.Fill(oezClientDS.HrNoticeFiles);

        ezClientDS.HrNoticeFilesRow r = oezClientDS.HrNoticeFiles.NewHrNoticeFilesRow();
        r.HrNotice_iAutoKey = int.Parse(lblAutoKey.Text);
        r.sServerName = fileName;
        r.sUploadName = file.FileName;
        r.sType = file.PostedFile.ContentType;
        r.iSize = (file.PostedFile.ContentLength / 1024) >= 1 ? file.PostedFile.ContentLength / 1024 : 1;
        r.dDate = DateTime.Now;
        r.sDescription = txtDesc.Text.Trim().Length == 0 ? r.sUploadName : txtDesc.Text;
        oezClientDS.HrNoticeFiles.AddHrNoticeFilesRow(r);

        HrNoticeFilesTA.Update(oezClientDS.HrNoticeFiles);

        txtDesc.Text = "";

        if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "SuccessMsg")) {
            Page.ClientScript.RegisterStartupScript(typeof(string), "SuccessMsg", "alert('檔案上傳成功');", true);
        }

        gvFiles.DataBind();
    }

    protected void gvFiles_RowCommand(object sender, GridViewCommandEventArgs e) {
        string CommandName = e.CommandName;
        string CommandArgument = e.CommandArgument.ToString();

        if (CommandName == "Download" || CommandName == "Delete") {
            HrNoticeFilesTA.FillByKey(oezClientDS.HrNoticeFiles, int.Parse(CommandArgument));
            ezClientDS.HrNoticeFilesRow r = (ezClientDS.HrNoticeFilesRow)oezClientDS.HrNoticeFiles.Rows[0];

            string FN = Server.MapPath("./Upload/" + r.sServerName);
            FileInfo fi = new FileInfo(FN);

            if (fi.Exists) {
                if (CommandName == "Download") {
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
                    fi.Delete();

                    if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "ErrorMsg")) {
                        Page.ClientScript.RegisterStartupScript(typeof(string), "ErrorMsg", "alert('刪除完成');", true);
                    }
                }
            }
            else {
                if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "ErrorMsg")) {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "ErrorMsg", "alert('系統找不到檔案');", true);
                }
            }
        }
    }
}
