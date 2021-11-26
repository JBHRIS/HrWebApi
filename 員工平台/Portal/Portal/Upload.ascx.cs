using Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class Upload : System.Web.UI.UserControl
    {
        public string sFormCode = "";
        public string sProcessID = "";
        public string sNobr = "";
        public string sGuid = "";
        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

            }
            int i = 0;
            var FunName = "UploadClick" + i;
            var Script = "function " + FunName + "(btn, args){ $telerik.$(\".ruFileInput\")[" + i + "].click(); }";

            btnUpload.OnClientClicked = FunName;
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), FunName, Script, true);
            //foreach (GridDataItem c in gvFiles.Items)
            //{
            //    var btnDownloadObj = c.FindControl("btnDownload");
            //    var btnDownload = btnDownloadObj as RadButton;

            //    if (btnDownload != null)
            //    {
            //        ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(btnDownload);
            //    }
            //}
        }
        //protected void Page_PreRender(object sender, EventArgs e)
        //{
        //    lblFormCode.Text = sFormCode;
        //    lblNobrS.Text = sNobr;
        //    lblKey1.Text = sGuid;
        //    lblProcessID.Text = sProcessID;
        //    gvFiles.Rebind();

        //}
        protected void gvFiles_ItemCommand(object sender, GridCommandEventArgs e)
        {
            lblFileMsg.Text = "";

            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();

            if (cn == "Download" || cn == "Del")
            {
                var r = (from c in dcFlow.wfFormUploadFile
                         where c.iAutoKey == Convert.ToInt32(ca)
                         select c).FirstOrDefault();

                if (r != null)
                {
                    string FN = Server.MapPath("~/Upload/" + r.sServerName);
                    FileInfo fi = new FileInfo(FN);

                    if (fi.Exists)
                    {
                        if (cn == "Download")
                        {
                            Response.ClearHeaders();
                            Response.Clear();
                            Response.AddHeader("Accept-Language", "zh-tw");
                            Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(r.sUpName, System.Text.Encoding.UTF8));

                            Response.AddHeader("Content-Length", fi.Length.ToString());
                            Response.ContentType = "application/octet-stream";
                            Response.WriteFile(fi.FullName);
                            Response.Flush();
                            Response.End();
                        }
                        else
                        {
                            fi.Delete();
                            dcFlow.wfFormUploadFile.DeleteOnSubmit(r);
                            dcFlow.SubmitChanges();
                            lblFileMsg.Text = "刪除完成";
                            gvFiles.DataBind();
                        }
                    }
                    else
                    {
                        lblFileMsg.Text = "系統找不到檔案";
                    }
                }
            }
        }

        protected void gvFiles_ItemDataBound(object sender, GridItemEventArgs e)
        {
            //Button btnDownload = e.Item.FindControl("btnDownload") as Button;
            //if (btnDownload != null)
            //    ScriptManager.GetCurrent(this).RegisterPostBackControl(btnDownload);

            RadButton btnDelete = e.Item.FindControl("btnDelete") as RadButton;
            if (btnDelete != null)
                btnDelete.Visible = lblStd.Text == "1";

            //RadButton btnDownload = e.Item.FindControl("btnDownload") as RadButton;
            //if (btnDownload != null)
            //    ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(btnDownload);
        }
        public void gvFiles_DataBind(ucFormStd usForm)
        {
            lblFormCode.Text = usForm.sFormCode;
            lblNobrS.Text = usForm.sNobr;
            lblKey1.Text = usForm.sGuid;
            lblProcessID.Text = usForm.sProcessID;
        }
        public void Upload_Upload()
        {
            Upload_Refresh();
        }
        public void Upload_Delete()
        {
            Upload_Refresh();
        }
        public void Upload_Refresh()
        {
            gvFiles.Rebind();
        }
        public void gvFiles_ReBind()
        {
            gvFiles.Rebind();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fu.UploadedFiles.Count == 0)
            {
                lblFileMsg.Text = "沒有選擇上傳任何檔案";
                return;
            }

            foreach (UploadedFile f in fu.UploadedFiles)
            {
                string ServerName = Guid.NewGuid().ToString();

                var rf = new wfFormUploadFile();
                rf.sFormCode = lblFormCode.Text;
                rf.sFormName = "";
                rf.sProcessID = lblProcessID.Text;
                rf.idProcess = 0;
                rf.sNobr = lblNobrS.Text;
                rf.sKey = lblKey1.Text;
                rf.sUpName = f.FileName;
                rf.sServerName = ServerName;
                rf.sDescription = txtDescription.Text;
                rf.sType = f.ContentType == null ? "" : f.ContentType;
                rf.iSize = Convert.ToInt32(f.ContentLength / 1024);
                rf.dKeyDate = DateTime.Now;
                dcFlow.wfFormUploadFile.InsertOnSubmit(rf);
                dcFlow.SubmitChanges();

                string path = Server.MapPath("~/Upload/");
                f.SaveAs(path + ServerName, true);
            }

            lblFileMsg.Text = "上傳完成";
            gvFiles.Rebind();
        }

        protected void gvFiles_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (lblKey1.Text != "")
            {
                var r = (from c in dcFlow.wfFormUploadFile
                         where c.sKey == lblKey1.Text
                         select c).ToList();
                gvFiles.DataSource = r;
            }
        }
        [Bindable(true)]
        public RadGrid _ucGvFile
        {
            get
            {
                return gvFiles;
            }
            set
            {
                gvFiles = value;
            }
        }
    }
}