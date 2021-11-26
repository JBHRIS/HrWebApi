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
using BL;

public partial class PublicNews : JBWebPage
{
    private news_REPO nRepo = new news_REPO();
    protected void Page_Load(object sender, EventArgs e) 
    {
        if (!IsPostBack) 
        {
            SiteHelper siteHelper = new SiteHelper();
            DateTime startDatetime, endDatetime;

            siteHelper.SetDateRangeForLatestYear(out startDatetime, out endDatetime);
            rdpBdate.SelectedDate = startDatetime;
            rdpEdate.SelectedDate = endDatetime;

            bindGv();
            if (Request.QueryString["ID"] != null) 
            {
                lb_newid.Text = Request.QueryString["ID"].ToString();   
                FormView1.DataBind();
                for (int i=0;i<GridView1.Rows.Count;i++) //(GridViewRow item in GridView1.Rows)
                {
                    if (GridView1.Rows[i].Cells[1].Text.Trim().Equals(lb_newid.Text))
                        GridView1.SelectedIndex = i;                        
                }
            }
        }
    }

    private void bindGv()
    {
        GridView1.DataSource = nRepo.GetByNobrDept(Juser.Nobr, Juser.Dept,rdpBdate.SelectedDate.Value,rdpEdate.SelectedDate.Value);
        GridView1.DataBind();
    }

    protected void FormView1_ItemDeleting(object sender, FormViewDeleteEventArgs e) {

    }
    protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e) {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //lb_newid.Text = GridView1.SelectedValue.ToString();
        lb_newid.Text = GridView1.SelectedDataKey.Values[0].ToString();
      //lb_newsfileid.Text = GridView1.SelectedDataKey.Values[1].ToString();
        FormView1.DataBind();
    }
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataList dList = (DataList)sender;

        Label _fileServerName = (Label)dList.Items[dList.SelectedIndex].FindControl("fileServerName");
        Label _upfilenameLabel = (Label)dList.Items[dList.SelectedIndex].FindControl("upfilenameLabel");
        FileStream MyFileStream;
        string FileName = "";
        long FileHandle = 0, FileSize = 0;
        FileName = Server.MapPath("./File/" + _fileServerName.Text);
        FileInfo fileInfo = new FileInfo(FileName);

        if (fileInfo.Exists)
        {
            Response.ClearHeaders();
            Response.Clear();
            Response.AddHeader("Accept-Language", "zh-tw");
            Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(_upfilenameLabel.Text, System.Text.Encoding.UTF8));

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
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindGv();
    }
    protected void FormView1_DataBinding(object sender, EventArgs e)
    {
        //確定有讀取公佈欄
        if(nRepo.ReadNewsByIdNobr(lb_newid.Text, Juser.Nobr))
            bindGv();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bindGv();
    }
}
