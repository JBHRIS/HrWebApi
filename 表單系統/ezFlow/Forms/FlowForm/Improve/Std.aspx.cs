using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Improve_Std : System.Web.UI.Page
{
    private bool isTest = false;

    private dcFlowDataContext dcFlow = new dcFlowDataContext();
    private dcFormDataContext dcForm = new dcFormDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this).RegisterPostBackControl(btnFile);
        ScriptManager.GetCurrent(this).RegisterPostBackControl(btnUpload);

        if (!IsPostBack)
        {
            lblNobrAppM.Text = Request.QueryString["idEmp_Start"] != null ? Request.QueryString["idEmp_Start"].ToUpper() : lblNobrAppM.Text;
            lblProcessID.Text = Guid.NewGuid().ToString();  //產生一組暫存的序號
            lblDate.Text = DateTime.Now.ToShortDateString();

            if (User.Identity.IsAuthenticated && User.Identity.Name.Trim().Length > 0)
            {
                lblNobrAppM.Text = User.Identity.Name;
                Session["Emp_id"] = User.Identity.Name.Trim();
                Response.Cookies["ezFlow"]["Emp_id"] = User.Identity.Name.Trim();
                Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(1);
            }

            lblNobrAppM.Text = lblNobrAppM.Text.Trim().Length == 0 ? " " : lblNobrAppM.Text;
            lblFlowID.Text = lblNobrAppM.Text;

            if (lblNobrAppM.Text.Trim().Length > 0)
            {
                //var rEmp = JBHR.Dll.Bas.EmpBase(lblNobrAppM.Text).FirstOrDefault();
                //if (rEmp != null)
                //{
                //    lblName.Text = rEmp.sNameC;
                //    lblDept.Text = rEmp.sDeptmCode;
                //    var rDeptm = JBHR.Dll.Bas.Deptm(lblDept.Text).FirstOrDefault();
                //    if (rDeptm != null)
                //        lblDept.Text = rDeptm.sDeptParent;
                //}

                var rRole = (from c in dcFlow.Role
                             where c.Emp_id == lblNobrAppM.Text
                             select c).FirstOrDefault();
                if (rRole != null)
                    lblRoleAppM.Text = rRole.id;
            }
            else
            {
                btnSubmit.Enabled = false;
            }

            SetDefault();
        }

        lblMsg.Text = "";
    }

    private void SetDefault()
    {
        lblFlowTreeID.Text = "79";
        lblTitle.ToolTip = "Improve";
        (Page.Master as mpStd0990111).sFormCode = lblTitle.ToolTip;
        (Page.Master as mpStd0990111).sAppNobr = lblNobrAppM.Text;

        var dtForm = from c in dcFlow.wfForm where c.sFormCode == lblTitle.ToolTip select c;

        if (dtForm.Any())
        {
            var rEmp = JBHR.Dll.Bas.EmpBase(lblNobrAppM.Text).FirstOrDefault();
            if (rEmp != null)
            {
                var rForm = dtForm.First();
                lblTitle.Text = rForm.sFormName;
            }
        }
    }

    protected void btnFlow_Click(object sender, EventArgs e)
    {
        mpePopupFlow.Show();
    }

    protected void btnExitFlow_Click(object sender, EventArgs e)
    {
        mpePopupFlow.Hide();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtTitle.Text.Trim().Length == 0)
        {
            lblMsg.Text = "主旨為必填欄位";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        if (txtNote.Text.Trim().Length == 0)
        {
            lblMsg.Text = "意見為必填欄位";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        dcFlow = new dcFlowDataContext();
        dcForm = new dcFormDataContext();

        var dtBaseM = from role in dcFlow.Role
                      join emp in dcFlow.Emp on role.Emp_id equals emp.id
                      join dept in dcFlow.Dept on role.Dept_id equals dept.id
                      join pos in dcFlow.Pos on role.Pos_id equals pos.id
                      where role.Emp_id == lblNobrAppM.Text
                      select new { role, emp, dept, pos };

        var rEmpBaseM = JBHR.Dll.Bas.EmpBase(lblNobrAppM.Text).FirstOrDefault();

        if (!dtBaseM.Any() || rEmpBaseM == null)
        {
            lblMsg.Text = "資料錯誤，請重新輸入";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        lblProcessID.ToolTip = lblProcessID.Text;

        var rBaseM = dtBaseM.First();

        localhost.Service oService = new localhost.Service();

        //流程從這裡開始
        lblProcessID.Text = oService.GetProcessID().ToString();

        var dtDeptm = JBHR.Dll.Bas.Deptm(rEmpBaseM.sDeptmCode).FirstOrDefault();

        var rm = new wfFormApp();
        rm.sFormCode = lblTitle.ToolTip;
        rm.sFormName = lblTitle.Text;
        rm.sProcessID = lblProcessID.Text;
        rm.idProcess = Convert.ToInt32(rm.sProcessID);
        rm.sNobr = lblNobrAppM.Text;
        rm.sName = rBaseM.emp.name;
        rm.sDept = rBaseM.dept.id;
        rm.sDeptName = rBaseM.dept.name;
        rm.sJob = rBaseM.pos.id;
        rm.sJobName = rBaseM.pos.name;
        rm.sJobl = rEmpBaseM.sJoblCode;
        rm.sRole = rBaseM.role.id;
        rm.sDI = rEmpBaseM.sDI;
        rm.iCateOrder = dtDeptm != null ? Convert.ToInt32(dtDeptm.sDeptTree) : 0;    //被申請者的部門層級
        rm.bDelay = false;  //是否有延遲需要補單
        rm.dDateTimeA = DateTime.Now;
        rm.bAuth = Convert.ToBoolean(rBaseM.role.deptMg);
        rm.bSign = true;
        rm.sState = "1";
        rm.sConditions1 = rm.iCateOrder.ToString(); //目前所簽核到的部門
        dcFlow.wfFormApp.InsertOnSubmit(rm);

        try
        {
            var rs = new wfAppImprove();
            rs.sFormCode = lblTitle.ToolTip;
            rs.sProcessID = lblProcessID.Text;
            rs.idProcess = Convert.ToInt32(rs.sProcessID);
            rs.sNobr = rm.sNobr;
            rs.sName = rm.sName;
            rs.sDept = rm.sDept;
            rs.sDeptName = rm.sDeptName;
            rs.sJob = rm.sJob;
            rs.sJobName = rm.sJobName;
            rs.sJobl = rm.sJobl;
            rs.sRole = rm.sRole;
            rs.sDI = rm.sDI;
            rs.sTitle = txtTitle.Text;
            rs.sCatCode = ddlCat.SelectedItem.Value;
            rs.sCatName = ddlCat.SelectedItem.Text;
            rs.dDateA = DateTime.Now;
            rs.dDateD = DateTime.Now;
            rs.dDate = DateTime.Now.Date;
            rs.bName = cbName.Checked;
            rs.bSign = true;
            rs.sState = "1";
            rs.sNote = txtNote.Text;
            rs.dKeyDate = DateTime.Now;
            rs.sReserve4 = lblProcessID.ToolTip;
            rs.sInfo = rs.sName + "," + rs.sCatName + "," + rs.sTitle;
            dcForm.wfAppImprove.InsertOnSubmit(rs);

            rm.sInfo = rs.sInfo;
            rm.sReserve4 = rs.sInfo;
        }
        catch (Exception ex)
        {
            lblProcessID.Text = lblProcessID.ToolTip;
            lblMsg.Text = "某些資訊錯誤，請重新檢查";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        try
        {
            dcForm.SubmitChanges();
        }
        catch (System.Data.Linq.ChangeConflictException ex)
        {
            foreach (System.Data.Linq.ObjectChangeConflict occ in dcForm.ChangeConflicts)
            {
                // *********************************************
                // 底下三個範例是 3 選 1 喔，不要三行都寫在一起！
                // **********************************************

                // 採用資料庫的查詢出來的值，目前物件的值將會被資料庫最新查到的複寫
                //occ.Resolve(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                // 採用目前物件中的值，並更新資料庫中的版本
                occ.Resolve(System.Data.Linq.RefreshMode.KeepCurrentValues);

                // 僅更新此物件中變更的欄位，僅將變更的欄位寫入資料庫（或稱為合併更新）
                //occ.Resolve(System.Data.Linq.RefreshMode.KeepChanges);
            }

            // 注意：解決完衝突之後要記得重新再 SubmitChanges() 一次，否則一樣不會更新資料庫
            dcForm.SubmitChanges();
        }

        try
        {
            dcFlow.SubmitChanges();
        }
        catch (System.Data.Linq.ChangeConflictException ex)
        {
            foreach (System.Data.Linq.ObjectChangeConflict occ in dcFlow.ChangeConflicts)
            {
                // *********************************************
                // 底下三個範例是 3 選 1 喔，不要三行都寫在一起！
                // **********************************************

                // 採用資料庫的查詢出來的值，目前物件的值將會被資料庫最新查到的複寫
                //occ.Resolve(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                // 採用目前物件中的值，並更新資料庫中的版本
                occ.Resolve(System.Data.Linq.RefreshMode.KeepCurrentValues);

                // 僅更新此物件中變更的欄位，僅將變更的欄位寫入資料庫（或稱為合併更新）
                //occ.Resolve(System.Data.Linq.RefreshMode.KeepChanges);
            }

            // 注意：解決完衝突之後要記得重新再 SubmitChanges() 一次，否則一樣不會更新資料庫
            dcFlow.SubmitChanges();
        }

        if (oService.FlowStart(rm.idProcess, lblFlowTreeID.Text, lblRoleAppM.Text, lblNobrAppM.Text, rBaseM.role.id, rBaseM.role.Emp_id))
        {
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = '../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
            lblProcessID.Text = Guid.NewGuid().ToString();  //產生一組暫存的序號
        }
    }
    protected void btnFile_Click(object sender, EventArgs e)
    {
        lblUploadID.Text = lblNobrAppM.Text;
        lblUploadKey.Text = lblProcessID.Text;
        lblDragNameUpload.Text = lblProcessID.Text;
        lblMsgUpload.Text = "";

        gvUpload.DataBind();
        mpePopupUpload.Show();
    }
    protected void btnExitUpload_Click(object sender, EventArgs e)
    {
        mpePopupUpload.Hide();
    }
    protected void fu_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        lblDragNameUpload.ToolTip = Guid.NewGuid().ToString();

        string savePath = MapPath("~/Upload/" + lblDragNameUpload.ToolTip);
        fu.SaveAs(savePath);

        Session["FileName"] = fu.FileName;
        Session["ServerName"] = lblDragNameUpload.ToolTip;
        Session["FileSize"] = e.filesize;
        Session["ContentType"] = fu.ContentType;

        mpePopupUpload.Show();
    }
    protected void fu_UploadedFileError(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "error", "top.$get(\"" + lblMsgUpload.ClientID + "\").innerHTML = 'Error: " + e.statusMessage + "';", true);
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        mpePopupUpload.Show();
        if (Session["FileName"] == null)
        {
            lblMsgUpload.Text = "檔案正在上傳中或沒有選擇檔案";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsgUpload.Text + "');", true);
            return;
        }

        var r = new wfFormUploadFile();
        r.sFormCode = "Improve";
        r.sFormName = "提案申請單";
        r.sProcessID = lblProcessID.Text;
        r.idProcess = 0;
        r.sKey = lblUploadKey.Text;
        r.sNobr = lblUploadID.Text;
        r.sUpName = Session["FileName"].ToString();
        r.sServerName = Session["ServerName"].ToString();
        r.sDescription = txtUpload.Text;
        r.sType = Session["ContentType"].ToString();
        r.iSize = (Convert.ToInt32(Session["FileSize"]) / 1024) > 0 ? Convert.ToInt32(Session["FileSize"]) / 1024 : 1;
        r.dKeyDate = DateTime.Now;
        dcFlow.wfFormUploadFile.InsertOnSubmit(r);

        dcFlow.SubmitChanges();
        gvUpload.DataBind();

        Session.RemoveAll();
    }

    protected void gvUpload_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblMsgUpload.Text = "";

        mpePopupUpload.Show();

        string cn = e.CommandName;
        string ca = e.CommandArgument.ToString();

        if (cn == "Download" || cn == "Del")
        {
            var r = (from c in dcFlow.wfFormUploadFile
                     where c.iAutoKey == Convert.ToInt32(ca)
                     select c).FirstOrDefault();

            if (r != null)
            {
                string FN = Server.MapPath("../Upload/" + r.sServerName);
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
                        gvUpload.DataBind();
                        lblMsgUpload.Text = "刪除完成";
                    }
                }
                else
                {
                    lblMsgUpload.Text = "系統找不到檔案";
                }
            }
        }
    }
    protected void gvUpload_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Button btnDownload = e.Row.FindControl("btnDownload") as Button;
        if (btnDownload != null)
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnDownload);
    }
}