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

public partial class NewPeople : System.Web.UI.Page
{
    public ezClientDSTableAdapters.HrPostTableAdapter HrPostTA = new ezClientDSTableAdapters.HrPostTableAdapter();
    public ezClientDSTableAdapters.HrNoticeFilesTableAdapter HrNoticeFilesTA = new ezClientDSTableAdapters.HrNoticeFilesTableAdapter();
    public AllModule Module = new AllModule();

    ezClientDS oezClientDS = new ezClientDS();
    DataRow[] rows;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            ezClientDS.SysAdminDataTable dtSysAdmin = Module.adSysAdmin.GetDataByEmp(Request.Cookies["ezFlow"]["Emp_id"].ToString());
            btnEdit.Visible = dtSysAdmin.Rows.Count > 0;

            HrPostTA.Fill(oezClientDS.HrPost);
            if (oezClientDS.HrPost.Rows.Count > 0)
            {
                ezClientDS.HrPostRow r = oezClientDS.HrPost.Rows[0] as ezClientDS.HrPostRow;
                lblContent.Text = r.IscontentNull() ? "目前尚未公告任何內容" : r.content;
                txtContent.Value = lblContent.Text;
            }
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        HrPostTA.Fill(oezClientDS.HrPost);
        if (oezClientDS.HrPost.Rows.Count > 1)
        {
            foreach (ezClientDS.HrPostRow r in oezClientDS.HrPost.Rows)
                r.Delete();

            HrPostTA.Update(oezClientDS.HrPost);
        }

        mv.ActiveViewIndex = 1;
    }

    protected void btnN_Click(object sender, EventArgs e)
    {
        mv.ActiveViewIndex = 0;
        gv.DataBind();
    }

    protected void btnY_Click(object sender, EventArgs e)
    {
        ezClientDS.HrPostRow r;

        HrPostTA.Fill(oezClientDS.HrPost);
        rows = oezClientDS.HrPost.Select();
        if (rows.Length > 0)
            r = oezClientDS.HrPost.Rows[0] as ezClientDS.HrPostRow;
        else
            r = oezClientDS.HrPost.NewHrPostRow();

        r.caption = "";
        r.content = txtContent.Value;
        lblContent.Text = txtContent.Value;
        r.adate = DateTime.Now;
        r.Emp_id = Request.Cookies["ezFlow"]["Emp_id"].ToString();

        if (rows.Length == 0)
            oezClientDS.HrPost.AddHrPostRow(r);

        HrPostTA.Update(oezClientDS.HrPost);

        mv.ActiveViewIndex = 0;
        gv.DataBind();
    }

    protected void gvFiles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string CommandName = e.CommandName;
        string CommandArgument = e.CommandArgument.ToString();

        if (CommandName == "Download" || CommandName == "Delete")
        {
            HrNoticeFilesTA.FillByKey(oezClientDS.HrNoticeFiles, int.Parse(CommandArgument));
            ezClientDS.HrNoticeFilesRow r = (ezClientDS.HrNoticeFilesRow)oezClientDS.HrNoticeFiles.Rows[0];

            string FN = Server.MapPath("./Upload/" + r.sServerName);
            FileInfo fi = new FileInfo(FN);

            if (fi.Exists)
            {
                if (CommandName == "Download")
                {
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
                else
                {
                    fi.Delete();

                    if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "ErrorMsg"))
                    {
                        Page.ClientScript.RegisterStartupScript(typeof(string), "ErrorMsg", "alert('刪除完成');", true);
                    }
                }
            }
            else
            {
                if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "ErrorMsg"))
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "ErrorMsg", "alert('系統找不到檔案');", true);
                }
            }
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        FileUpload file = fuP;

        if (!file.HasFile)
        {
            if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "ErrorMsg"))
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), "ErrorMsg", "alert('未指定要上傳的檔案');", true);
            }

            return;
        }

        string fileName = DateTime.Now.ToFileTime().ToString();
        file.PostedFile.SaveAs(Server.MapPath(".") + "\\Upload\\" + fileName);

        HrNoticeFilesTA.Fill(oezClientDS.HrNoticeFiles);

        ezClientDS.HrNoticeFilesRow r = oezClientDS.HrNoticeFiles.NewHrNoticeFilesRow();
        r.HrNotice_iAutoKey = -1;
        r.sServerName = fileName;
        r.sUploadName = file.FileName;
        r.sType = file.PostedFile.ContentType;
        r.iSize = (file.PostedFile.ContentLength / 1024) >= 1 ? file.PostedFile.ContentLength / 1024 : 1;
        r.dDate = DateTime.Now;
        r.sDescription = txtDesc.Text.Trim().Length == 0 ? r.sUploadName : txtDesc.Text;
        oezClientDS.HrNoticeFiles.AddHrNoticeFilesRow(r);

        HrNoticeFilesTA.Update(oezClientDS.HrNoticeFiles);

        txtDesc.Text = "";

        if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "SuccessMsg"))
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), "SuccessMsg", "alert('檔案上傳成功');", true);
        }

        gvFiles.DataBind();
        gv.DataBind();
    }
}