using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR
{
    public class SystemFunction
    {
        public static bool CheckAppConfigRule(System.Windows.Forms.Button btn)
        {
            bool rtn = true;
            btn.Visible = rtn;
            btn.Click += new EventHandler(btn_Click);
            return rtn;
        }

        static void btn_Click(object sender, EventArgs e)
        {
            ConfigManager frm = new ConfigManager();
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            frm.Category = btn.Tag.ToString();
            frm.ShowDialog();
        }
        public static bool CheckRule(System.Windows.Forms.Button btn)
        {
            bool rtn = false;
            rtn = MainForm.ADMIN;
            btn.Visible = rtn;
            return rtn;
        }
        public static bool CheckCodeConfigRule(System.Windows.Forms.Button btn)
        {
            bool rtn = MainForm.SYSTEMRULE;
            btn.Visible = rtn;
            btn.Visible = true;//20130301暫時修改成都可以看(如果可以進來這隻程式)
            return rtn;
        }
        public static bool CheckMtCodeCodeConfigRule(System.Windows.Forms.Button btn, string Category)
        {
            bool rtn = MainForm.SYSTEMRULE;
            btn.Enabled = rtn;
            btn.Tag = Category;
            return rtn;
        }
        public static void SetComboBoxItems(System.Windows.Forms.ComboBox cbx, Dictionary<string, string> data)
        {
            SetComboBoxItems(cbx, data, false, false, true);
        }
        public static void SetComboBoxItems(System.Windows.Forms.ComboBox cbx, Dictionary<string, string> data, bool WithNull, bool enable)
        {
            SetComboBoxItems(cbx, data, WithNull, enable, true);
        }
        public static void SetComboBoxItems(System.Windows.Forms.ComboBox cbx, Dictionary<string, string> data, bool WithNull)
        {
            SetComboBoxItems(cbx, data, WithNull, false, true);
        }
        public static void SetComboBoxItems(System.Windows.Forms.ComboBox cbx, Dictionary<string, string> data, bool WithNull, bool enable, bool AutoCompleted)
        {
            object CurrentValue = cbx.SelectedValue;
            Dictionary<string, string> items = new Dictionary<string, string>();
            if (WithNull)
            {
                items.Add("", "(無)");
                foreach (var it in data)
                    items.Add(it.Key.Trim(), it.Value.Trim());
            }
            else items = data;


            cbx.DisplayMember = "value";
            cbx.ValueMember = "key";
            cbx.DataSource = items.CopyToDataTable();
            
            if (CurrentValue != null)//避免rebind
                cbx.SelectedValue = CurrentValue;
            if (items.Count > 0)
            {
                var maxlenth = items.Values.Max(p => p.Trim().Length);
                maxlenth = maxlenth * 11;
                if (cbx.DropDownWidth < maxlenth) cbx.DropDownWidth = maxlenth;
            }
            if (cbx.DataBindings.Count > 0)
                cbx.Enabled = false;
            if (enable) cbx.Enabled = true;
            if (AutoCompleted)
            {
                if (cbx.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
                {
                    cbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                    cbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
                    foreach (var it in data)
                        cbx.AutoCompleteCustomSource.Add(it.Value);
                    cbx.Validating += new System.ComponentModel.CancelEventHandler(cbx_Validating);
                }
            }
        }

        static void cbx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var cbx = sender as System.Windows.Forms.ComboBox;
            if (cbx != null)
            {
                if (cbx.SelectedValue == null)
                {
                    cbx.Focus();
                }
            }
        }

        public static void SetJBComboBoxItems(JBControls.ComboBox cbx, Dictionary<string, string> data)
        {
            SetJBComboBoxItems(cbx, data, false);
        }
        public static void SetJBComboBoxItems(JBControls.ComboBox cbx, Dictionary<string, string> data, bool WithNull)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            if (WithNull)
                items.Add("", "(無)");

            cbx.AddItem(data);
            cbx.DisplayMember = "value";
            cbx.ValueMember = "key";
        }

    }
    public class CheckControl
    {
        List<System.Windows.Forms.Control> checkList;
        public CheckControl()
        {
            checkList = new List<System.Windows.Forms.Control>();
        }
        public System.Windows.Forms.Control CheckRequiredFields()
        {
            foreach (var it in checkList)
            {
                if (it is System.Windows.Forms.ComboBox)
                {
                    var ctrl = it as System.Windows.Forms.ComboBox;
                    if (ctrl.SelectedValue == null || ctrl.SelectedValue.ToString().Trim().Length == 0)
                        return ctrl;
                }
            }
            return null;
        }
        public void AddControl(System.Windows.Forms.Control ctrl)
        {
            checkList.Add(ctrl);
        }

    }
}
