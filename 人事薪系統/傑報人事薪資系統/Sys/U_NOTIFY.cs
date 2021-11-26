using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.Linq;
using System.Reflection;
using JBHR.BLL.Sys;
namespace JBHR.Sys
{
    public partial class U_NOTIFY : JBControls.JBForm
    {
        public U_NOTIFY()
        {
            InitializeComponent();
        }
        JBModule.Data.Linq.HrDBDataContext db;
        JBModule.Data.Linq.NotifyTemplate template;
        private void U_NOTIFY_Load(object sender, EventArgs e)
        {
            CheckNotifyClass();
            this.mTCODETableAdapter.FillByCategory(this.mainDS.MTCODE, "NotifyTarget");
            //this.v_BASETableAdapter.Fill(this.mainDS.V_BASE);
            Sal.Function.SetAvaliableVBase(this.mainDS.V_BASE);
            db = new JBModule.Data.Linq.HrDBDataContext();
            this.u_USERTableAdapter.Fill(this.sysDS.U_USER);
            SystemFunction.SetComboBoxItems(cbxNotifyType, CodeFunction.GetNotifyClass());
            SystemFunction.SetComboBoxItems(cbxTargetType, CodeFunction.GetMtCode("NotifyTarget"));
            PanelControl();
            GetData();
            SetEnable(false);
        }
        void PanelControl()
        {
            pnlEmployee.Visible = false;
            pnlHrUser.Visible = false;
            pnlEmail.Visible = false;
            pnlDeptManager.Visible = false;
            pnlSponsor.Visible = false;
            string value = "";
            if (cbxTargetType.SelectedIndex == -1)
                cbxTargetType.SelectedIndex = 0;
            switch (cbxTargetType.SelectedValue.ToString())
            {
                case "HrUser":
                    pnlHrUser.Visible = true;
                    break;
                case "Employee":
                    pnlEmployee.Visible = true;
                    break;
                case "Email":
                    pnlEmail.Visible = true;
                    break;
                case "DeptManager":
                    pnlDeptManager.Visible = true;
                    break;
                case "Sponsor":
                    pnlSponsor.Visible = true;
                    break;
            }
        }

        private void btnHruser_Click(object sender, EventArgs e)
        {
            switch (cbxTargetType.SelectedValue.ToString())
            {
                case "HrUser":
                    SaveHrUser();
                    break;
                case "Employee":
                    SaveEmployee();
                    break;
                case "Email":
                    SaveEmail();
                    break;
                case "DeptManager":
                    SaveDeptManager();
                    break;
                case "Sponsor":
                    SaveSponsor();
                    break;
            }
        }
        void SaveHrUser()
        {
            bool isAdd = false;
            JBModule.Data.Linq.NotifyTemplate nt;
            if (template == null)
            {
                nt = new JBModule.Data.Linq.NotifyTemplate();
                isAdd = true;
            }
            else
            {
                var sql = from a in db.NotifyTemplate where a.AutoKey == template.AutoKey select a;
                nt = sql.First();
            }

            nt.KeyDate = DateTime.Now;
            nt.KeyMan = MainForm.USER_NAME;
            nt.Comp = MainForm.COMPANY;
            nt.Memo = txtMemo.Text;
            nt.NotifyDay = 0;
            nt.NotifyType = cbxNotifyType.SelectedValue.ToString();
            nt.Target = ptxHrUser.Text;
            nt.TargetType = cbxTargetType.SelectedValue.ToString();
            if (isAdd)
                db.NotifyTemplate.InsertOnSubmit(nt);
            db.SubmitChanges();
            Init();
            GetData();
        }
        void SaveDeptManager()
        {
            bool isAdd = false;
            JBModule.Data.Linq.NotifyTemplate nt;
            if (template == null)
            {
                nt = new JBModule.Data.Linq.NotifyTemplate();
                isAdd = true;
            }
            else
            {
                var sql = from a in db.NotifyTemplate where a.AutoKey == template.AutoKey select a;
                nt = sql.First();
            }

            nt.KeyDate = DateTime.Now;
            nt.KeyMan = MainForm.USER_NAME;
            nt.Comp = MainForm.COMPANY;
            nt.Memo = txtMemo.Text;
            nt.NotifyDay = 0;
            nt.NotifyType = cbxNotifyType.SelectedValue.ToString();
            nt.Target = "";
            nt.TargetType = cbxTargetType.SelectedValue.ToString();
            if (isAdd)
                db.NotifyTemplate.InsertOnSubmit(nt);
            db.SubmitChanges();
            Init();
            GetData();
        }
        void SaveEmail()
        {
            bool isAdd = false;
            JBModule.Data.Linq.NotifyTemplate nt;
            if (template == null)
            {
                nt = new JBModule.Data.Linq.NotifyTemplate();
                isAdd = true;
            }
            else
            {
                var sql = from a in db.NotifyTemplate where a.AutoKey == template.AutoKey select a;
                nt = sql.First();
            }

            nt.KeyDate = DateTime.Now;
            nt.KeyMan = MainForm.USER_NAME;
            nt.Comp = MainForm.COMPANY;
            nt.Memo = txtMemo.Text;
            nt.NotifyDay = 0;
            nt.NotifyType = cbxNotifyType.SelectedValue.ToString();
            nt.Target = txtEmail.Text;
            nt.TargetType = cbxTargetType.SelectedValue.ToString();
            if (isAdd)
                db.NotifyTemplate.InsertOnSubmit(nt);
            db.SubmitChanges();
            Init();
            GetData();
        }
        void SaveEmployee()
        {
            bool isAdd = false;
            JBModule.Data.Linq.NotifyTemplate nt;
            if (template == null)
            {
                nt = new JBModule.Data.Linq.NotifyTemplate();
                isAdd = true;
            }
            else
            {
                var sql = from a in db.NotifyTemplate where a.AutoKey == template.AutoKey select a;
                nt = sql.First();
            }

            nt.KeyDate = DateTime.Now;
            nt.KeyMan = MainForm.USER_NAME;
            nt.Comp = MainForm.COMPANY;
            nt.Memo = txtMemo.Text;
            nt.NotifyDay = 0;
            nt.NotifyType = cbxNotifyType.SelectedValue.ToString();
            nt.Target = ptxEmployee.Text;
            nt.TargetType = cbxTargetType.SelectedValue.ToString();
            if (isAdd)
                db.NotifyTemplate.InsertOnSubmit(nt);
            db.SubmitChanges();
            Init();
            GetData();
        }
        void SaveSponsor()
        {
            bool isAdd = false;
            JBModule.Data.Linq.NotifyTemplate nt;
            if (template == null)
            {
                nt = new JBModule.Data.Linq.NotifyTemplate();
                isAdd = true;
            }
            else
            {
                var sql = from a in db.NotifyTemplate where a.AutoKey == template.AutoKey select a;
                nt = sql.First();
            }

            nt.KeyDate = DateTime.Now;
            nt.KeyMan = MainForm.USER_NAME;
            nt.Comp = MainForm.COMPANY;
            nt.Memo = txtMemo.Text;
            nt.NotifyDay = 0;
            nt.NotifyType = cbxNotifyType.SelectedValue.ToString();
            nt.Target = "";
            nt.TargetType = cbxTargetType.SelectedValue.ToString();
            if (isAdd)
                db.NotifyTemplate.InsertOnSubmit(nt);
            db.SubmitChanges();
            Init();
            GetData();
        }
        void Init()
        {
            ptxEmployee.Text = "";
            txtMemo.Text = "";

            SetEnable(false);
        }
        void SetEnable(bool Enable)
        {
            txtMemo.Enabled = Enable;
            cbxTargetType.Enabled = Enable;
            flowLayoutPanel2.Enabled = Enable;
        }

        private void cbxTargetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelControl();
        }
        void GetData()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.NotifyTemplate where a.NotifyType == cbxNotifyType.SelectedValue.ToString() && a.Comp == MainForm.COMPANY select a;
            notifyTemplateBindingSource.DataSource = sql;
        }

        private void cbxNotifyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            template = null;
            Init();
            SetEnable(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isAdd = false;
            JBModule.Data.Linq.NotifyTemplate nt;
            if (template == null)
            {
                nt = new JBModule.Data.Linq.NotifyTemplate();
                isAdd = true;
            }
            else
            {
                var sql = from a in db.NotifyTemplate where a.AutoKey == template.AutoKey select a;
                nt = sql.First();
            }
            if (!isAdd)
                db.NotifyTemplate.DeleteOnSubmit(nt);
            db.SubmitChanges();
            Init();
            GetData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var itm = dataGridView1.Rows[e.RowIndex].DataBoundItem as JBModule.Data.Linq.NotifyTemplate;
            if (itm != null)
            {
                template = itm;
                txtMemo.Text = template.Memo;
                cbxNotifyType.SelectedValue = template.NotifyType;
                ptxHrUser.Text = template.Target;
                cbxTargetType.SelectedValue = template.TargetType;
                ptxEmployee.Text = template.Target;
                SetEnable(true);
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Init();
        }
        void CheckNotifyClass()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            Dictionary<string, string> ClassList = new Dictionary<string, string>();
            ClassList.Add("JBHR.BLL.Sys.BirthdayNotifyObject", "JBHR.BLL");
            ClassList.Add("JBHR.BLL.Sys.ContractNotifyObject", "JBHR.BLL");
            ClassList.Add("JBHR.BLL.Sys.TrialExpireNotifyObject", "JBHR.BLL");
            ClassList.Add("JBHR.BLL.Sys.ARCExpireNotifyObject", "JBHR.BLL");
            //ClassList.Add("JBHR.CustomBLL.Sys.CindtDayIntervalNotifyObject", "JBHR.CustomBLL");
            //ClassList.Add("JBHR.CustomBLL.Sys.PassportExpireNotifyObject", "JBHR.CustomBLL");
            //ClassList.Add("JBHR.CustomBLL.Sys.ExpectReinstatementNotifyObject", "JBHR.CustomBLL");
            var sql = (from a in db.NotifyClass where a.Comp == MainForm.COMPANY select a).ToList();
            foreach (var it in ClassList)
            {
                string assemblyName = it.Value;
                string classType = it.Key;
                if (assemblyName == null) assemblyName = "JBHR.BLL";
                Assembly assembly = Assembly.Load(assemblyName);
                if (assembly == null)
                    assembly = Assembly.GetExecutingAssembly();
                INotifyObject notifyObject = assembly.CreateInstance(classType) as INotifyObject;
                if (notifyObject == null) continue;
                JBModule.Data.Linq.NotifyClass nClass = new JBModule.Data.Linq.NotifyClass();
                nClass.AssemblyName = assemblyName;
                nClass.ClassName = classType;
                nClass.Comp = MainForm.COMPANY;
                nClass.Code = notifyObject.NotifyCode;
                nClass.DisplayName = notifyObject.NotifyName;
                nClass.KeyDate = DateTime.Now;
                nClass.KeyMan = MainForm.USER_NAME;
                nClass.Memo = "";
                nClass.Message = "";
                nClass.Sort = 0;
                nClass.Status = "Auto";
                nClass.Title = "";
                var Query = from a in sql where a.Code == nClass.Code select a;
                if (!Query.Any())
                    db.NotifyClass.InsertOnSubmit(nClass);
            }
            db.SubmitChanges();

        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (cbxNotifyType.SelectedValue != null)
            {
                NotifyConfig frm = new NotifyConfig();
                frm.Code = cbxNotifyType.SelectedValue.ToString();
                frm.ShowDialog();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            JBHR.BLL.Sys.NotifyService nService = new NotifyService();
            int i = 0;
            nService.TransTodoList = true;
            i += nService.CheckNotify(new List<string>(), dateTimePicker1.Value, dateTimePicker2.Value, cbxNotifyType.SelectedValue.ToString(), MainForm.COMPANY, "Auto");
            i += nService.CheckNotify(new List<string>(), dateTimePicker1.Value, dateTimePicker2.Value, cbxNotifyType.SelectedValue.ToString(), MainForm.COMPANY, "Manual");
            MessageBox.Show("發送完成，共" + i.ToString() + "筆通知", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool isAdd = false;
            JBModule.Data.Linq.NotifyTemplate nt;
            if (template == null)
            {
                nt = new JBModule.Data.Linq.NotifyTemplate();
                isAdd = true;
            }
            else
            {
                var sql = from a in db.NotifyTemplate where a.AutoKey == template.AutoKey select a;
                nt = sql.First();
            }

            nt.KeyDate = DateTime.Now;
            nt.KeyMan = MainForm.USER_NAME;
            nt.Comp = MainForm.COMPANY;
            nt.Memo = txtMemo.Text;
            nt.NotifyDay = 0;
            nt.NotifyType = cbxNotifyType.SelectedValue.ToString();
            nt.Target = "";
            nt.TargetType = cbxTargetType.SelectedValue.ToString();
            if (isAdd)
                db.NotifyTemplate.InsertOnSubmit(nt);
            db.SubmitChanges();
            Init();
            GetData();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            JBHR.BLL.Sys.NotifyService nService = new NotifyService();
            int i = 0;
            var ntf = nService.GetNotifyMessage(new List<string>(), dateTimePicker1.Value.Date, dateTimePicker2.Value.Date.AddDays(1).AddMilliseconds(-1), cbxNotifyType.SelectedValue.ToString(), MainForm.COMPANY, "Auto");
            var ntf1 = nService.GetNotifyMessage(new List<string>(), dateTimePicker1.Value.Date, dateTimePicker2.Value.Date.AddDays(1).AddMilliseconds(-1), cbxNotifyType.SelectedValue.ToString(), MainForm.COMPANY, "Manual");
            //i += nService.CheckNotify(new List<string>(), DateTime.Today, DateTime.Today, cbxNotifyType.SelectedValue.ToString(), MainForm.COMPANY, "Manual");
            ntf.AddRange(ntf1);
            Sal.PreviewForm frm = new Sal.PreviewForm();
            var targetTypeList = (from a in db.MTCODE where a.CATEGORY == "notifytarget" select new { a.CODE, a.NAME }).ToList();
            var Query = from a in ntf
                        join b in targetTypeList on a.TargetType.ToString() equals b.CODE
                        select new { NotifyMessage = a, TargetType = b };
            frm.DataTable = Query.Select(p => new { 提醒日期 = p.NotifyMessage.EventDate, 標題 = p.NotifyMessage.NotifyEvent.Title, 內容 = p.NotifyMessage.NotifyEvent.Message, 通知對象類型 = p.TargetType.NAME, 通知對象 = p.NotifyMessage.TargetName, EMAIL = p.NotifyMessage.TargetEmail }).CopyToDataTable();
            frm.Text = "檢視通知內容";
            frm.Width = 800;
            frm.ShowDialog();
        }

    }
}
