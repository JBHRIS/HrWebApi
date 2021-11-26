using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using JBHR.BLL.Sys;
using System.Runtime.InteropServices;

namespace JBHR.Sys
{
    public partial class NotifyConfig : Form
    {
        public NotifyConfig()
        {
            InitializeComponent();
        }
        public string Code = "";

        private void btnSave_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.NotifyClass where a.Code == Code && a.Comp == MainForm.COMPANY select a;
            if (sql.Any())
            {
                JBModule.Data.Linq.NotifyClass nClass = sql.First();
                //nClass.Code = txtCode.Text;
                //nClass.DisplayName = txtName.Text;
                nClass.Status = cbxMode.SelectedValue.ToString();
                nClass.Memo = txtMemo.Text;
                nClass.Title = txtTitle.Text;
                nClass.NotifyDay = Convert.ToInt32(txtNotifyDay.Text);
                nClass.Message = txtMessage.InnerHtml != null ? txtMessage.InnerHtml : "";
                //nClass.RelationApp = cbxRelationApp.SelectedValue.ToString();
                db.SubmitChanges();
            }
            this.Close();
        }

        private void NotifyConfig_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> dicMode = new Dictionary<string, string>();
            dicMode.Add("Auto", "自動");
            dicMode.Add("Manual", "手動");
            dicMode.Add("Stop", "停止");
            SystemFunction.SetComboBoxItems(cbxMode, dicMode);
            //SystemFunction.SetComboBoxItems(cbxRelationApp, CodeFunction.GetU_PRG(), true);
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.NotifyClass where a.Code == Code && a.Comp == MainForm.COMPANY select a;
            if (sql.Any())
            {
                JBModule.Data.Linq.NotifyClass nClass = sql.First();
                txtCode.Text = nClass.Code;
                txtName.Text = nClass.DisplayName;
                txtMemo.Text = nClass.Memo;
                txtTitle.Text = nClass.Title;
                txtNotifyDay.Text = nClass.NotifyDay.ToString();
                txtMessage.InnerHtml = nClass.Message;
                cbxMode.SelectedValue = nClass.Status;
                cbxRelationApp.SelectedValue = nClass.RelationApp != null ? nClass.RelationApp : "";
                string assemblyName = nClass.AssemblyName;
                string classType = nClass.ClassName;
                if (assemblyName == null) assemblyName = "JBHR.BLL";
                Assembly assembly = Assembly.Load(assemblyName);
                if (assembly == null)
                    assembly = Assembly.GetExecutingAssembly();
                INotifyObject notifyObject = assembly.CreateInstance(classType) as INotifyObject;
                if (notifyObject != null)
                    SystemFunction.SetComboBoxItems(cbxArgs, notifyObject.EventArgsDictionary);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt is MSDN.Html.Editor.HtmlEditorControl)
                {
                    Clipboard.SetText("{" + cbxArgs.SelectedValue.ToString() + "}");
                    txtMessage.TextPaste();
                }
                else if (txt is TextBox)
                {
                    if (txt != null && pos != -1)
                    {
                        txt.Text = txt.Text.Insert(pos, "{" + cbxArgs.SelectedValue.ToString() + "}");
                    }
                }
            }
            catch (ExternalException ex)
            {
                MessageBox.Show("無法清除剪貼簿，請確認是否有其他軟體再存取剪貼簿(如Teamview等遠端連線軟體)");
            }

        }
        Control txt;
        int pos = -1;
        private void Control_Validating(object sender, CancelEventArgs e)
        {
            pos = -1;
            txt = null;
            var chk = sender as Control;
            if (chk == txtTitle)
                txt = txtTitle;
            else if (chk == txtMessage)
                txt = txtMessage;
            if (txt != null)
            {
                var textbox = txt as TextBox;
                if (textbox != null)
                    pos = textbox.SelectionStart;
                else
                {
                    var richBox = txt as MSDN.Html.Editor.HtmlEditorControl;
                    //if (richBox != null)
                    //    pos = richBox.;
                }

            }
        }
    }
}
