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

public partial class Utli_ShowTask : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string aaa = Request.QueryString["keyid"];
        if (!IsPostBack)
        {
            HRDs.rq_TaskDataTable rq_task = new HRDsTableAdapters.rq_TaskTableAdapter().GetDataBy_id(Convert.ToInt32(Request.QueryString["keyid"]));
            if (rq_task.Rows.Count > 0)
            {
                app_nobr.Text = rq_task.Rows[0]["app_nobr"].ToString();
                app_name.Text = rq_task.Rows[0]["app_name"].ToString();
                exe_nobr.Text = rq_task.Rows[0]["exe_nobr"].ToString();
                exe_name.Text = rq_task.Rows[0]["exe_name"].ToString();
                tasks.Text = rq_task.Rows[0]["tasks"].ToString();
                if (rq_task.Rows[0]["orders"].ToString().Trim() == "1")
                    RadioButtonList1.Items[0].Selected = true;
                if (rq_task.Rows[0]["orders"].ToString().Trim() == "2")
                    RadioButtonList1.Items[1].Selected = true;
                if (rq_task.Rows[0]["orders"].ToString().Trim() == "3")
                    RadioButtonList1.Items[2].Selected = true;
                if (rq_task.Rows[0]["orders"].ToString().Trim() == "4")
                    RadioButtonList1.Items[3].Selected = true;
                ExpireDate.SelectedDate = DateTime.Parse(rq_task.Rows[0]["ExpireDate"].ToString());
                Reminday.Text = rq_task.Rows[0]["Reminday"].ToString();
                Schedule.Text = rq_task.Rows[0]["Schedule"].ToString();
                La_Upfilename.Text = rq_task.Rows[0]["Filename"].ToString();
                Descs.Value = rq_task.Rows[0]["Descs"].ToString();
                File_name.Text = rq_task.Rows[0]["Upfilename"].ToString();
            }
        }
    }

    protected void File_name_Click(object sender, EventArgs e)
    {
        //DataList dList = (DataList)sender;
        //Label _fileServerName = (Label)FormView1.FindControl("Load_File");
        //LinkButton _upfilenameLabel = (LinkButton)FormView1.FindControl("File_name");
        FileStream MyFileStream;
        string FileName = "";
        long FileHandle = 0, FileSize = 0;
        FileName = Server.MapPath("../File/" + La_Upfilename.Text);
        FileInfo fileInfo = new FileInfo(FileName);

        if (fileInfo.Exists)
        {
            Response.ClearHeaders();
            Response.Clear();
            Response.AddHeader("Accept-Language", "zh-tw");
            Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(File_name.Text, System.Text.Encoding.UTF8));

            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
        }
        else
        {
            //找不到檔案：
        }
        Response.End();
    }
}
