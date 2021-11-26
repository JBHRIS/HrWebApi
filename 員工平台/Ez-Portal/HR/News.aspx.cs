using BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Telerik.Web.UI;

public partial class HR_News : JBWebPage
{
    private news_REPO nRepo = new news_REPO();
    private UPFILE_REPO uRepo = new UPFILE_REPO();
    private NewsTarget_REPO ntRepo = new NewsTarget_REPO();

    protected override void OnInit(EventArgs e)
    {
        CanCopy = true;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //SelectEmp31.sHandler += new Templet_SelectEmp3.SelectEmpEventHandler(UC_SelectEmp);
        if (!IsPostBack)
        {
            changeFormMode(FormMode.View);
            SiteHelper.SetAllDeptTree(tvDept);
        }
    }

    protected void gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (e.RebindReason == GridRebindReason.ExplicitRebind || e.RebindReason == GridRebindReason.InitialLoad)
        {
            var list = nRepo.GetNewsDtoAll();
            Session[SessionName] = list;
            gv.DataSource = list;
        }
        else
        {
            if (Session[SessionName] != null)
                gv.DataSource = Session[SessionName];
        }
    }

    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridDataItem item = gv.SelectedItems[0] as GridDataItem;
        loadDetail(item["news_id"].Text);
        changeFormMode(FormMode.Update);
    }

    private void loadDetail(string newsId)
    {
        var obj = nRepo.GetByPk(newsId);
        news_idTextBox.Text = obj.news_id;
        rdiDeadLine.SelectedDate = obj.post_deadline;
        news_headTextBox.Text = obj.news_head;
        edt.Content = obj.news_body;
        lb_newsfileid.Text = obj.newsfileid;
        lblId.Text = obj.news_id;
        ck_is_on.Checked = obj.is_on;

        if (obj.PublishAllEmp.Equals("1"))
            rblTargetType.SelectedIndex = 0;
        else
            rblTargetType.SelectedIndex = 1;

        gvAttachment.Rebind();
        gvTarget.Rebind();
    }

    protected void gv_ItemCommand(object sender, GridCommandEventArgs e)
    {
        GridDataItem item = e.Item as GridDataItem;

        var list = Session[SessionName] as List<NewsDto>;
        if (list == null)
        {
            Show("請重新reload頁面");
            return;
        }

        if (e.CommandName.Equals("cmdDown"))
        {
            var cacheFObj = (from c in list where c.news_id == item["news_id"].Text select c).FirstOrDefault();
            int fIndex = list.IndexOf(cacheFObj);
            if (list[fIndex + 1] != null)
            {
                var fstObj = nRepo.GetByPk(item["news_id"].Text);
                var sndObj = nRepo.GetByPk(list[fIndex + 1].news_id);

                long sort = fstObj.sort;
                fstObj.sort = sndObj.sort;
                sndObj.sort = sort;
                nRepo.Update(fstObj);
                nRepo.Update(sndObj);
                nRepo.Save();
                gv.Rebind();
            }
            else
                return;
        }
        if (e.CommandName.Equals("cmdUp"))
        {
            var cacheFObj = (from c in list where c.news_id == item["news_id"].Text select c).FirstOrDefault();
            int fIndex = list.IndexOf(cacheFObj);
            if (list[fIndex - 1] != null)
            {
                var fstObj = nRepo.GetByPk(item["news_id"].Text);
                var sndObj = nRepo.GetByPk(list[fIndex - 1].news_id);

                long sort = fstObj.sort;
                fstObj.sort = sndObj.sort;
                sndObj.sort = sort;
                nRepo.Update(fstObj);
                nRepo.Update(sndObj);
                nRepo.Save();
                gv.Rebind();
            }
            else
                return;
        }
        if (e.CommandName.Equals("cmdDelete"))
        {
            news_REPO nRepo = new news_REPO();
            var o = nRepo.GetByPk(item["news_id"].Text);
            if (o.is_on)
            {
                Show("發佈中，無法刪除");
                return;
            }
            else
            {
                nRepo.Delete(o);
                nRepo.Save();
                gv.Rebind();
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FormMode fm = (FormMode)Enum.Parse(typeof(FormMode), lblFormStatus.Text);
        if (fm == FormMode.Insert)
        {
            news obj = new news();
            if (news_idTextBox.Text.Trim().Equals(""))
            {
                Show("文號必須輸入!!");
                return;
            }
            obj.news_id = news_idTextBox.Text;
            obj.news_body = edt.Content;
            obj.news_head = news_headTextBox.Text;
            obj.post_date = DateTime.Now;
            obj.post_deadline = rdiDeadLine.SelectedDate.Value;
            obj.newsfileid = Guid.NewGuid().ToString();
            obj.PublishAllEmp = rblTargetType.SelectedValue;
            obj.sort = DateTime.Now.Ticks;
            obj.is_on = ck_is_on.Checked;

            nRepo.Add(obj);
            nRepo.Save();
            loadDetail(obj.news_id);
            changeFormMode(FormMode.Update);
        }
        else if (fm == FormMode.Update)
        {
            var obj = nRepo.GetByPk(news_idTextBox.Text);
            obj.news_body = edt.Content;
            obj.news_head = news_headTextBox.Text;
            obj.post_date = DateTime.Now;
            obj.post_deadline = rdiDeadLine.SelectedDate.Value;
            obj.PublishAllEmp = rblTargetType.SelectedValue;
            obj.is_on = ck_is_on.Checked;

            nRepo.Update(obj);
            nRepo.Save();
            changeFormMode(FormMode.View);
        }
        gv.Rebind();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        changeFormMode(FormMode.View);
    }

    private void changeFormMode(FormMode m)
    {
        if (m == FormMode.Update)
        {
            btnAdd.Visible = false;
            pnlDetail.Visible = true;
            news_idTextBox.Enabled = false;
            up.Enabled = true;
            btnUpload.Enabled = true;
            pnlSelectEmp.Enabled = true;
            pnlSelectDept.Enabled = true;
            ts.SelectedIndex = 0;
            mp.SelectedIndex = 0;
            gv.Visible = false;
            btnSendMail.Enabled = true;
        }
        else if (m == FormMode.ViewDetail)
        {
            btnAdd.Visible = false;
            btnSave.Visible = false;
        }
        else if (m == FormMode.Insert)
        {
            btnAdd.Visible = false;
            pnlDetail.Visible = true;
            rdiDeadLine.SelectedDate = new DateTime(9999, 12, 31);
            lblId.Text = "";
            news_idTextBox.Enabled = true;
            ts.SelectedIndex = 0;
            mp.SelectedIndex = 0;
            gv.Visible = false;
            btnSendMail.Enabled = false;
        }
        else if (m == FormMode.View)
        {
            btnAdd.Visible = true;
            pnlDetail.Visible = false;
            lblId.Text = "";
            news_headTextBox.Text = "";
            news_idTextBox.Text = "";
            lb_newsfileid.Text = "";
            edt.Content = "";
            up.Enabled = false;
            pnlSelectEmp.Enabled = false;
            pnlSelectDept.Enabled = false;
            btnUpload.Enabled = false;
            ck_is_on.Checked = false;
            gvAttachment.Rebind();
            gvTarget.Rebind();
            gv.Visible = true;
        }

        lblFormStatus.Text = m.ToString();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        changeFormMode(FormMode.Insert);
    }

    protected void gvAttachment_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (e.RebindReason == GridRebindReason.ExplicitRebind)
        {
            var list = uRepo.GetByNewsFileId(lb_newsfileid.Text);
            gvAttachment.DataSource = list;
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string dir = Server.MapPath("..") + "\\File\\";

        var nObj = nRepo.GetByPk(lblId.Text);
        uRepo.dc = nRepo.dc;

        foreach (UploadedFile f in up.UploadedFiles)
        {
            string fileName = Guid.NewGuid().ToString();
            string fullFilePath = dir + fileName;

            f.SaveAs(fullFilePath);

            if (File.Exists(fullFilePath))
            {
                UPFILE uObj = new UPFILE();
                uObj.NEWSFILEID = lb_newsfileid.Text;
                uObj.UPFILENAME = f.GetName();
                uObj.SERVERFILENAME = fileName;
                uObj.FILETYPE = f.ContentType;
                uObj.UPTYPE = "A";
                uObj.UPFILEDATE = DateTime.Now;
                uObj.FILESIZE = Math.Round(double.Parse(f.ContentLength.ToString()) / 1024, 2) + "KB";
                uObj.FILEDESC = tbFileDesc.Text;
                uObj.NOBR = Juser.Nobr;
                uRepo.Add(uObj);

                nObj.AttachmentCount = nObj.AttachmentCount + 1;
                nRepo.Update(nObj);
                uRepo.Save();
            }
            else
            {
                Show(f.GetName() + "錯誤");
                gvAttachment.Rebind();
                gv.Rebind();
                return;
            }
        }

        gvAttachment.Rebind();
        gv.Rebind();
    }

    protected void btnAddEmp_Click(object sender, EventArgs e)
    {
        var ntList = ntRepo.GetByNewsId(lblId.Text);

        ISelectEmp ss = SelectEmp31 as ISelectEmp;
        var plist = ss.GetSelectedEmps();

        foreach (var emp in plist)
        {
            if (ntList.Find(p => p.EmpNo == emp) == null)
            {
                NewsTarget obj = new NewsTarget();
                obj.news_id = lblId.Text;
                obj.EmpNo = emp;
                ntRepo.Add(obj);
            }
        }

        ntRepo.Save();
        gvTarget.Rebind();
    }

    protected void btnAddDept_Click(object sender, EventArgs e)
    {
        var ntList = ntRepo.GetByNewsId(lblId.Text);

        foreach (var n in tvDept.CheckedNodes)
        {
            if (ntList.Find(p => p.DetpCode == n.Value) == null)
            {
                NewsTarget obj = new NewsTarget();
                obj.news_id = lblId.Text;
                obj.DetpCode = n.Value;
                ntRepo.Add(obj);
            }
        }

        ntRepo.Save();
        gvTarget.Rebind();
    }

    protected void gvTarget_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (e.RebindReason == GridRebindReason.ExplicitRebind)
        {
            var list = ntRepo.GetByNewsId_Dlo(lblId.Text);

            List<NewsTargetView> viewList = new List<NewsTargetView>();

            foreach (var l in list)
            {
                NewsTargetView obj = new NewsTargetView();
                obj.Id = l.Id;
                obj.NewsId = l.news_id;
                obj.DeptCode = l.DetpCode;
                obj.Nobr = l.EmpNo;

                if (l.BASE != null)
                    obj.EmpName = l.BASE.NAME_C;
                if (l.DEPT != null)
                    obj.DeptName = l.DEPT.D_NAME;

                viewList.Add(obj);
            }

            gvTarget.DataSource = viewList;
        }
    }

    private class NewsTargetView
    {
        public string Nobr { get; set; }

        public string EmpName { get; set; }

        public string DeptCode { get; set; }

        public string DeptName { get; set; }

        public int Id { get; set; }

        public string NewsId { get; set; }
    }

    protected void gvTarget_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName.Equals("cmdDel"))
        {
            GridDataItem item = e.Item as GridDataItem;
            int id = Convert.ToInt32(item["Id"].Text);
            var obj = ntRepo.GetById(id);
            ntRepo.Delete(obj);
            ntRepo.Save();
            gvTarget.Rebind();
        }
    }

    protected void btnSendMail_Click(object sender, EventArgs e)
    {
        news_REPO nRepo = new news_REPO();
        var nObj = nRepo.GetByPk_Dlo(lblId.Text);
        BASE_REPO baseRepo = new BASE_REPO();
        string dir = Server.MapPath("..") + "\\File\\";

        HR_File_REPO fileRepo = new HR_File_REPO();
        string groupID = Guid.NewGuid().ToString();

        List<BASE> baseList = new List<BASE>();

        //全體員工
        if (nObj.PublishAllEmp.Equals("1"))
        {
            baseList.AddRange(baseRepo.GetHiredEmp_Dlo());
        }
        else
        {
            foreach (var t in nObj.NewsTarget)
            {
                if (t.DEPT == null)
                    baseList.Add(baseRepo.GetByNobr_Dlo(t.EmpNo));
                else
                    baseList.AddRange(baseRepo.GetEmpByDept_Dlo(t.DetpCode));
            }
        }

        if (baseList.Count > 0)
        {
            foreach (var a in nObj.UPFILE)
            {
                HR_File f = new HR_File();
                f.CreatedBy = Juser.Nobr;
                f.CreatedDate = DateTime.Now;
                f.FileBinary = File.ReadAllBytes(dir + a.SERVERFILENAME);
                f.FileName = a.UPFILENAME;
                f.FileDesc = a.FILEDESC;
                f.FileType = a.FILETYPE;
                f.ID = Guid.NewGuid().ToString();
                f.GroupID = groupID;
                fileRepo.Add(f);
            }

            JBModule.Message.Mail mail = new JBModule.Message.Mail();
            foreach (var emp in baseList)
            {
                mail.AddMailQueue(emp.EMAIL, nObj.news_head, nObj.news_body, groupID);
            }

            nObj.LatestSendMailDate = DateTime.Now;
            nRepo.Update(nObj);
            nRepo.Save();
            gv.Rebind();
            Show("已寄送");
        }
    }

    protected void gvAttachment_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName.Equals("cmdDel"))
        {
            string fileName = "";

            GridDataItem item = e.Item as GridDataItem;
            UPFILE_REPO uRepo = new UPFILE_REPO();
            news_REPO nRepo = new news_REPO(uRepo.dc);

            var obj = uRepo.GetByPk(Convert.ToInt32(item["AUTOKEY"].Text));

            //var nObj = nRepo.GetBy

            fileName = obj.SERVERFILENAME;
            uRepo.Delete(obj);

            var nObj = nRepo.GetByPk(lblId.Text);
            nObj.AttachmentCount = nObj.AttachmentCount - 1;
            nRepo.Update(nObj);
            uRepo.Save();

            string dir = Server.MapPath("..") + "\\File\\";
            File.Delete(dir + fileName);
            gvAttachment.Rebind();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        NewsTarget_REPO ntRepo = new NewsTarget_REPO();
        var list = ntRepo.GetByNewsId(lblId.Text);
        foreach (var i in list)
        {
            ntRepo.Delete(i);
        }
        ntRepo.Save();
        gvTarget.Rebind();
    }
}