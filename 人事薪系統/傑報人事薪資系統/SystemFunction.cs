using Dapper;
using JBModule.Data.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        //public static void SetComboBoxItems(System.Windows.Forms.ComboBox cbx, Dictionary<string, string> data)
        //{
        //    SetComboBoxItems(cbx, data, false, false, true);
        //}
        //public static void SetComboBoxItems(System.Windows.Forms.ComboBox cbx, Dictionary<string, string> data, bool WithNull, bool enable)
        //{
        //    SetComboBoxItems(cbx, data, WithNull, enable, true);
        //}
        //public static void SetComboBoxItems(System.Windows.Forms.ComboBox cbx, Dictionary<string, string> data, bool WithNull)
        //{
        //    SetComboBoxItems(cbx, data, WithNull, false, true);
        //}
        //public static void SetComboBoxItems(System.Windows.Forms.ComboBox cbx, Dictionary<string, string> data, bool WithNull, bool enable, bool AutoCompleted)
        //{
        //    object CurrentValue = cbx.SelectedValue;
        //    Dictionary<string, string> items = new Dictionary<string, string>();
        //    if (WithNull)
        //    {
        //        items.Add("", "(無)");
        //        foreach (var it in data)
        //            items.Add(it.Key.Trim(), it.Value.Trim());
        //    }
        //    else items = data;
        //    cbx.DisplayMember = "value";
        //    cbx.ValueMember = "key";
        //    cbx.DataSource = items.CopyToDataTable();
        //    if (CurrentValue != null)//避免rebind
        //        cbx.SelectedValue = CurrentValue;
        //    if (items.Count > 0)
        //    {
        //        var maxlenth = items.Values.Max(p => p.Trim().Length);
        //        maxlenth = maxlenth * 11;
        //        if (cbx.DropDownWidth < maxlenth) cbx.DropDownWidth = maxlenth;
        //    }
        //    if (cbx.DataBindings.Count > 0)
        //        cbx.Enabled = false;
        //    if (enable) cbx.Enabled = true;
        //    if (AutoCompleted)
        //    {
        //        if (cbx.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
        //        {
        //            cbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
        //            cbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        //            foreach (var it in data)
        //                cbx.AutoCompleteCustomSource.Add(it.Value);
        //            cbx.Validating += new System.ComponentModel.CancelEventHandler(cbx_Validating);
        //        }
        //    }
        //}
        //static void cbx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    var cbx = sender as System.Windows.Forms.ComboBox;
        //    if (cbx != null)
        //    {
        //        if (cbx.SelectedValue == null)
        //        {
        //            cbx.Focus();
        //        }
        //    }
        //}
        public static void SetComboBoxItems(System.Windows.Forms.ComboBox cbx, Dictionary<string, string> data)
        {
            SetComboBoxItems(cbx, data, false, false, false, true);
        }
        public static void SetComboBoxItems(System.Windows.Forms.ComboBox cbx, Dictionary<string, string> data, bool WithNull, bool enable)
        {
            SetComboBoxItems(cbx, data, WithNull, enable, false, true);
        }
        public static void SetComboBoxItems(System.Windows.Forms.ComboBox cbx, Dictionary<string, string> data, bool WithNull)
        {
            SetComboBoxItems(cbx, data, WithNull, false, false, true);
        }
        public static void SetComboBoxItems(System.Windows.Forms.ComboBox cbx, Dictionary<string, string> data, bool WithNull, bool enable, bool SmartSerch)
        {
            SetComboBoxItems(cbx, data, WithNull, enable, SmartSerch, true);
        }
        /// <summary>
        /// 當啟用SmartSearch時，當要取得原Tag值時須使用combobox.Tag["Tag"]取值
        /// </summary>
        public static void SetComboBoxItems(System.Windows.Forms.ComboBox cbx, Dictionary<string, string> data, bool WithNull, bool enable, bool SmartSerch, bool AutoCompleted)
        {
            if (enable) cbx.Enabled = true;
            if (SmartSerch)
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

                var dic = new Dictionary<string, object>();
                dic.Add("Tag", cbx.Tag);
                dic.Add("DataSource", items);
                dic.Add("OldValue", "");
                cbx.Tag = dic;

                if (CurrentValue != null)//避免rebind
                    cbx.SelectedValue = CurrentValue;

                if (items.Count > 0)
                {
                    var maxlenth = items.Values.Max(p => p.Trim().Length);
                    maxlenth = maxlenth * 11;
                    cbx.DropDownWidth = maxlenth;
                }
                if (cbx.DataBindings.Count > 0)
                    cbx.Enabled = false;
                if (enable) cbx.Enabled = true;
                if (AutoCompleted)
                {
                    if (cbx.DropDownStyle == ComboBoxStyle.DropDown)
                    {
                        cbx.AutoCompleteSource = AutoCompleteSource.ListItems;
                        foreach (var it in data)
                            cbx.AutoCompleteCustomSource.Add(it.Value);
                        //cbx.Validating += new System.ComponentModel.CancelEventHandler(cbx_Validating);
                        cbx.AutoCompleteMode = AutoCompleteMode.Append;
                    }

                    cbx.Enter += Cbx_Enter;
                    cbx.Leave += Cbx_Leave;
                    cbx.TextUpdate += Cbx_TextUpdate;
                }
            }
            else
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
                cbx.DataSource = items.CopyToDataTable();
                cbx.DisplayMember = "value";
                cbx.ValueMember = "key";
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
        }

        private static void Cbx_Enter(object sender, EventArgs e)
        {
            ComboBox CBX = (ComboBox)sender;
            var dataSource = ((Dictionary<string, object>)CBX.Tag)["DataSource"] as Dictionary<string, string>;
            if (!CBX.DroppedDown)
            {
                ((Dictionary<string, object>)CBX.Tag)["OldValue"] = CBX.Text;
                Dictionary<string, string> items = dataSource;
                string[] data = items.Values.ToArray();
                CBX.AutoCompleteMode = AutoCompleteMode.None;
                CBX.DataSource = items.CopyToDataTable();
                CBX.Text = ((Dictionary<string, object>)CBX.Tag)["OldValue"].ToString();
            }
        }

        private static void Cbx_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                ComboBox CBX = (ComboBox)sender;
                int selectionStart = CBX.SelectionStart;
                var dataSource = ((Dictionary<string, object>)CBX.Tag)["DataSource"] as Dictionary<string, string>;
                Dictionary<string, string> items = new Dictionary<string, string>();
                var input = CBX.Text.ToString();
                CBX.BeginUpdate();
                int LastCount = CBX.MaxDropDownItems;
                if (!string.IsNullOrWhiteSpace(input))
                {
                    foreach (var item in dataSource)
                    {
                        if (item.Value.IndexOf(input, StringComparison.CurrentCultureIgnoreCase) != -1)
                            items.Add(item.Key, item.Value);
                    }
                    if (items.Count == 0)
                        items.Add("", "(無)");
                    CBX.DataSource = items.CopyToDataTable();
                }
                else
                {
                    items = dataSource;
                    CBX.DataSource = items.CopyToDataTable();
                }

                if (items.Count > 30)
                    CBX.MaxDropDownItems = 30;
                else if (items.Count < 1)
                    CBX.MaxDropDownItems = 1;
                else
                    CBX.MaxDropDownItems = items.Count;

                if (CBX.MaxDropDownItems < LastCount)
                {
                    CBX.DroppedDown = false;
                    CBX.DroppedDown = true;
                }

                if (!CBX.DroppedDown)
                    CBX.DroppedDown = true;

                CBX.Text = input;
                CBX.SelectionStart = selectionStart;
                CBX.EndUpdate();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static void Cbx_Leave(object sender, EventArgs e)
        {
            ComboBox CBX = (ComboBox)sender;
            CBX.BeginUpdate();
            var dataSource = ((Dictionary<string, object>)CBX.Tag)["DataSource"] as Dictionary<string, string>;
            string input = CBX.Text.ToString();
            Dictionary<string, string> items = dataSource;
            string[] data = items.Values.ToArray();

            CBX.DisplayMember = "value";
            CBX.ValueMember = "key";
            CBX.DataSource = items.CopyToDataTable();

            CBX.AutoCompleteSource = AutoCompleteSource.ListItems;
            if (data.Contains(input))
                CBX.SelectedValue = dataSource.FirstOrDefault(p => p.Value == input).Key;
            else
            {
                foreach (var item in dataSource)
                {
                    if (item.Value.IndexOf(input, StringComparison.CurrentCultureIgnoreCase) != -1)
                    {
                        CBX.SelectedValue = item.Key;
                        break;
                    }
                }
            }
            //CBX.AutoCompleteMode = AutoCompleteMode.Append;
            CBX.EndUpdate();
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

        #region UserDefineLayout
        public static List<Control> UserDefineLayoutSetFrmLayout(Form form, string comp)
        {
            List<Control> ctls = JBTools.Extend.ControlsProcess.GetAllControls(form);
            List<Control> controlList = new List<Control>();
            foreach (Control ctl in ctls)
            {
                if (ctl.GetType().Name.ToUpper() == "TABLELAYOUTPANEL")
                {
                    var UDL = ctl as TableLayoutPanel;
                    HrDBDataContext db = new HrDBDataContext();
                    var compsql = db.COMP1.Where(p => p.COMP == comp).FirstOrDefault();
                    if (compsql != null)
                    {
                        var UsDfMaster = db.UserDefineMaster.Where(p => p.UserDefineMasterID.Equals(compsql.UserDefineMasterID)).FirstOrDefault();
                        if (UsDfMaster != null)
                        {
                            var UsDfID = db.UserDefineGroup.Where(p => p.UserDefineMasterID.Equals(UsDfMaster.UserDefineMasterID) && p.FormName == form.GetType().FullName && p.TableLayoutName == string.Format("{0}-{1}", UDL.Parent.Name, UDL.Name)).FirstOrDefault();
                            if (UsDfID != null)
                                controlList.AddRange(SystemFunction.UserDefineLayoutFunc(UDL, UsDfID.UserDefineGroupID, false, false));
                        }
                    }
                }
            }
            return controlList;
        }

        public static void SetUserDefineEnable(List<Control> controlList, bool is_enable)
        {
            foreach (var item in controlList)
            {
                switch (item)
                {
                    case Label _control:
                        _control.Enabled = is_enable;
                        break;
                    case TextBox _control:
                        _control.Enabled = is_enable;
                        break;
                    case CheckBox _control:
                        _control.Enabled = is_enable;
                        break;
                    case DateTimePicker _control:
                        _control.Enabled = is_enable;
                        break;
                    case ComboBox _control:
                        _control.Enabled = is_enable;
                        break;
                    case NumericUpDown _control:
                        _control.Enabled = is_enable;
                        break;
                }
            }
        }

        public static void UserDefineLayoutGetValue(List<Control> controlList, string code)
        {
            HrDBDataContext db = new HrDBDataContext();
            var udv = db.UserDefineValue.Where(p => p.Code == code);
            foreach (Control ctl in controlList)
            {
                if (udv != null && udv.Where(p => p.ControlID.Equals(Guid.Parse(ctl.Name))).Any())
                {
                    var item = udv.Where(p => p.ControlID.Equals(Guid.Parse(ctl.Name))).FirstOrDefault();
                    switch (ctl)
                    {
                        case TextBox _control:
                            if (item.ValueType == "TextBox")
                                _control.Text = item.Value;
                            break;
                        case CheckBox _control:
                            if (item.ValueType == "CheckBox")
                                _control.Checked = Convert.ToBoolean(item.Value);
                            break;
                        case DateTimePicker _control:
                            if (item.ValueType == "DateTimePicker" && item.Value != null && item.Value.Trim().Length > 0)
                                _control.Value = Convert.ToDateTime(item.Value);
                            break;
                        case ComboBox _control:
                            //if (item.ValueType == "ComboBox" && dbctl.SourceID.Equals(item.SourceID))
                            //    _control.Text = item.Value;
                            if (item.ValueType == "ComboBox")
                            {
                                var dbctl = db.UserDefineLayout.Where(p => p.ControlID.Equals(item.ControlID)).FirstOrDefault();
                                Dictionary<string, string> Tag = JsonConvert.DeserializeObject<Dictionary<string, string>>(dbctl.Tag);//反序列化
                                if (Guid.Parse(Tag["SourceID"]).Equals(item.SourceID))
                                    _control.SelectedValue = item.Value;
                            }
                            break;
                        case NumericUpDown _control:
                            if (item.ValueType == "NumericUpDown")
                                _control.Value = Convert.ToDecimal(item.Value);
                            break;
                    }
                }
                else
                {
                    switch (ctl)
                    {
                        case TextBox _control:
                            _control.Text = string.Empty;
                            break;
                        case CheckBox _control:
                            _control.Checked = false;
                            break;
                        case DateTimePicker _control:
                            _control.Value = new DateTime(1900, 1, 1);
                            break;
                        case ComboBox _control:
                            _control.SelectedIndex = 0;
                            break;
                        case NumericUpDown _control:
                            _control.Value = 0;
                            break;
                    }
                }
            }
        }
        public static string UserDefineLayoutGetControlValue(List<Control> controlList, string ParameterLabel, string defaulValue)
        {
            HrDBDataContext db = new HrDBDataContext();
            foreach (Control ctl in controlList)
            {
                UserDefineLayout instance;
                switch (ctl)
                {
                    case TextBox _control:
                        instance = db.UserDefineLayout.Where(p => p.Tag.Contains(string.Format("\"ParameterName\":\"{0}\"", ParameterLabel)) && p.ControlID.ToString() == _control.Name).FirstOrDefault();
                        if (instance != null)
                            return _control.Text;
                        break;
                    case CheckBox _control:
                        instance = db.UserDefineLayout.Where(p => p.Tag.Contains(string.Format("\"ParameterName\":\"{0}\"", ParameterLabel)) && p.ControlID.ToString() == _control.Name).FirstOrDefault();
                        if (instance != null)
                            return _control.Checked.ToString();
                        break;
                    case DateTimePicker _control:
                        instance = db.UserDefineLayout.Where(p => p.Tag.Contains(string.Format("\"ParameterName\":\"{0}\"", ParameterLabel)) && p.ControlID.ToString() == _control.Name).FirstOrDefault();
                        if (instance != null)
                            return _control.Value.ToString();
                        break;
                    case ComboBox _control:
                        instance = db.UserDefineLayout.Where(p => p.Tag.Contains(string.Format("\"ParameterName\":\"{0}\"", ParameterLabel)) && p.ControlID.ToString() == _control.Name).FirstOrDefault();
                        if (instance != null)
                            return _control.SelectedValue.ToString();
                        break;
                    case NumericUpDown _control:
                        instance = db.UserDefineLayout.Where(p => p.Tag.Contains(string.Format("\"ParameterName\":\"{0}\"", ParameterLabel)) && p.ControlID.ToString() == _control.Name).FirstOrDefault();
                        if (instance != null)
                            return _control.Value.ToString();
                        break;
                }
            }
            return defaulValue;
        }

        public static void UserDefineLayoutSaveValue(List<Control> controlList, string code)
        {
            HrDBDataContext db = new HrDBDataContext();
            foreach (Control ctl in controlList)
            {
                UserDefineValue instance;
                switch (ctl)
                {
                    case TextBox _control:
                        instance = db.UserDefineValue.Where(p => p.Code == code && p.ControlID.ToString() == _control.Name).FirstOrDefault();
                        if (instance != null)
                            instance.Value = _control.Text;
                        else
                        {
                            instance = new UserDefineValue();
                            instance.ControlID = Guid.Parse(_control.Name);
                            instance.ValueType = "TextBox";
                            instance.Value = _control.Text;
                            instance.Code = code;
                            instance.Key_Man = MainForm.USER_ID;
                            instance.Key_Date = DateTime.Now;
                            db.UserDefineValue.InsertOnSubmit(instance);
                        }
                        break;
                    case CheckBox _control:
                        instance = db.UserDefineValue.Where(p => p.Code == code && p.ControlID.ToString() == _control.Name).FirstOrDefault();
                        if (instance != null)
                            instance.Value = _control.Checked.ToString();
                        else
                        {
                            instance = new UserDefineValue();
                            instance.ControlID = Guid.Parse(_control.Name);
                            instance.ValueType = "CheckBox";
                            instance.Value = _control.Checked.ToString();
                            instance.Code = code;
                            instance.Key_Man = MainForm.USER_ID;
                            instance.Key_Date = DateTime.Now;
                            db.UserDefineValue.InsertOnSubmit(instance);
                        }
                        break;
                    case DateTimePicker _control:
                        instance = db.UserDefineValue.Where(p => p.Code == code && p.ControlID.ToString() == _control.Name).FirstOrDefault();
                        if (instance != null)
                            instance.Value = _control.Value.ToString();
                        else
                        {
                            instance = new UserDefineValue();
                            instance.ControlID = Guid.Parse(_control.Name);
                            instance.ValueType = "DateTimePicker";
                            if (_control.Checked)
                                instance.Value = _control.Value.ToString();
                            instance.Code = code;
                            instance.Key_Man = MainForm.USER_ID;
                            instance.Key_Date = DateTime.Now;
                            db.UserDefineValue.InsertOnSubmit(instance);
                        }
                        break;
                    case ComboBox _control:
                        UserDefineLayout UDFL_Combobox = db.UserDefineLayout.Where(p => p.ControlID.ToString() == _control.Name).FirstOrDefault();
                        Dictionary<string, string> comboxboxTag = JsonConvert.DeserializeObject<Dictionary<string, string>>(UDFL_Combobox.Tag);//反序列化
                        instance = db.UserDefineValue.Where(p => p.Code == code && p.ControlID.ToString() == _control.Name && p.SourceID.Equals(Guid.Parse(comboxboxTag["SourceID"].ToString()))).FirstOrDefault();
                        if (instance != null)
                            instance.Value = _control.SelectedValue.ToString();
                        else
                        {
                            instance = new UserDefineValue();
                            instance.ControlID = Guid.Parse(_control.Name);
                            instance.ValueType = "ComboBox";
                            instance.Value = _control.SelectedValue.ToString();
                            instance.Code = code;
                            instance.Key_Man = MainForm.USER_ID;
                            instance.Key_Date = DateTime.Now;
                            string TagStr = db.UserDefineLayout.Where(p => p.ControlID.Equals(Guid.Parse(_control.Name))).FirstOrDefault().Tag;
                            Dictionary<string, string> Tag = JsonConvert.DeserializeObject<Dictionary<string, string>>(TagStr);//反序列化
                            instance.SourceID = Guid.Parse(Tag["SourceID"]);
                            db.UserDefineValue.InsertOnSubmit(instance);
                        }
                        break;
                    case NumericUpDown _control:
                        instance = db.UserDefineValue.Where(p => p.Code == code && p.ControlID.ToString() == _control.Name).FirstOrDefault();
                        if (instance != null)
                            instance.Value = _control.Value.ToString();
                        else
                        {
                            instance = new UserDefineValue();
                            instance.ControlID = Guid.Parse(_control.Name);
                            instance.ValueType = "NumericUpDown";
                            instance.Value = instance.Value = _control.Value.ToString();
                            instance.Code = code;
                            instance.Key_Man = MainForm.USER_ID;
                            instance.Key_Date = DateTime.Now;
                            db.UserDefineValue.InsertOnSubmit(instance);
                        }
                        break;
                }
            }
            db.SubmitChanges();
        }
        /// <summary>
        /// EditMode開啟時,會用button將空位填滿,但須自己新增click事件
        /// </summary>
        public static List<Control> UserDefineLayoutFunc(TableLayoutPanel userdefinelayout, Guid selectedkey, bool editmode, bool enableSW = true)
        {
            HrDBDataContext db = new HrDBDataContext();
            var UsDfID = db.UserDefineGroup.Where(p => p.UserDefineGroupID.Equals(selectedkey)).FirstOrDefault();
            userdefinelayout.SuspendLayout();
            var UsDfLayoutSql = db.UserDefineLayout.Where(p => p.UserDefineGroupID.Equals(selectedkey));
            List<Control> controlList = new List<Control>();
            if (UsDfLayoutSql.Any())
            {
                var UsDfLayout = UsDfLayoutSql.OrderBy(p => p.LayoutRow).OrderBy(p => p.LayoutColumn).ToList();
                foreach (var item in UsDfLayout)
                {
                    Control actionControl = userdefinelayout.GetControlFromPosition(item.LayoutColumn, item.LayoutRow);
                    if (actionControl == null)//!UsedMap[item.LayoutColumn, item.LayoutRow])
                    {
                        Dictionary<string, string> TagList = JsonConvert.DeserializeObject<Dictionary<string, string>>(item.Tag);//反序列化
                        switch (item.Type)
                        {
                            case "Label":
                                Label Ll = new Label();
                                Ll.Name = item.ControlID.ToString();
                                Ll.Text = TagList.ContainsKey("Text") ? TagList["Text"] : string.Empty;
                                Ll.Visible = item.Visible;
                                Ll.Anchor = SetAnchorStyles(item.Anchor);
                                Ll.Dock = SetDockStyle(item.Dock);
                                Ll.AutoSize = true;
                                userdefinelayout.Controls.Add(Ll, item.LayoutColumn, item.LayoutRow);
                                userdefinelayout.SetColumnSpan(Ll, item.ColumnSpan);
                                userdefinelayout.SetRowSpan(Ll, item.RowSpan);
                                //controlList.Add(Ll);
                                break;
                            case "CheckBox":
                                CheckBox CKB = new CheckBox();
                                CKB.Enabled = enableSW;
                                CKB.Name = item.ControlID.ToString();
                                CKB.Text = TagList.ContainsKey("Text") ? TagList["Text"] : string.Empty;
                                CKB.Visible = item.Visible;
                                CKB.Anchor = SetAnchorStyles(item.Anchor);
                                CKB.Dock = SetDockStyle(item.Dock);
                                CKB.Checked = TagList.ContainsKey("Checked") ? Convert.ToBoolean(TagList["Checked"]) : false;//Convert.ToBoolean(item.DefaultValue);
                                CKB.AutoSize = true;
                                userdefinelayout.Controls.Add(CKB, item.LayoutColumn, item.LayoutRow);
                                userdefinelayout.SetColumnSpan(CKB, item.ColumnSpan);
                                userdefinelayout.SetRowSpan(CKB, item.RowSpan);
                                controlList.Add(CKB);
                                break;
                            case "TextBox":
                                TextBox TB = new TextBox();
                                TB.Enabled = enableSW;
                                TB.Name = item.ControlID.ToString();
                                TB.Text = TagList.ContainsKey("Test") ? TagList["Text"] : string.Empty;// item.DefaultValue;
                                TB.Visible = item.Visible;
                                TB.Anchor = SetAnchorStyles(item.Anchor);
                                TB.Dock = SetDockStyle(item.Dock);
                                TB.AutoSize = true;
                                TB.Multiline = true;
                                userdefinelayout.Controls.Add(TB, item.LayoutColumn, item.LayoutRow);
                                userdefinelayout.SetColumnSpan(TB, item.ColumnSpan);
                                userdefinelayout.SetRowSpan(TB, item.RowSpan);
                                controlList.Add(TB);
                                break;
                            case "DateTimePicker":
                                DateTimePicker DTP = new DateTimePicker();
                                DTP.Enabled = enableSW;
                                DTP.Name = item.ControlID.ToString();
                                DTP.Format = DateTimePickerFormat.Custom;
                                if (TagList.ContainsKey("DateTimeValue"))
                                {
                                    DateTime dateTime;
                                    if (DateTime.TryParse(TagList["DateTimeValue"], out dateTime))
                                    {
                                        DTP.Value = Convert.ToDateTime(TagList["DateTimeValue"]);
                                        DTP.CustomFormat = "yyyy/MM/dd";
                                    }
                                    else
                                    {
                                        DTP.Value = DateTime.Today;
                                        DTP.CustomFormat = " ";
                                        DTP.Checked = false;
                                    }
                                }

                                DTP.Visible = item.Visible;
                                DTP.Anchor = SetAnchorStyles(item.Anchor);
                                DTP.Dock = SetDockStyle(item.Dock);
                                DTP.AutoSize = true;
                                //if (EditMode)
                                //    DTP.Click += Control_Click;
                                DTP.ValueChanged += DateTimePicker_ValueChanged;
                                DTP.DropDown += DateTimePicker_DropDown;

                                userdefinelayout.Controls.Add(DTP, item.LayoutColumn, item.LayoutRow);
                                userdefinelayout.SetColumnSpan(DTP, item.ColumnSpan);
                                userdefinelayout.SetRowSpan(DTP, item.RowSpan);
                                controlList.Add(DTP);
                                break;
                            case "ComboBox":
                                ComboBox CB = new ComboBox();
                                CB.Name = item.ControlID.ToString();
                                CB.Visible = item.Visible;
                                CB.Anchor = SetAnchorStyles(item.Anchor);
                                CB.Dock = SetDockStyle(item.Dock);
                                CB.AutoSize = true;
                                //if (EditMode)
                                //    CB.Click += Control_Click;
                                userdefinelayout.Controls.Add(CB, item.LayoutColumn, item.LayoutRow);
                                userdefinelayout.SetColumnSpan(CB, item.ColumnSpan);
                                userdefinelayout.SetRowSpan(CB, item.RowSpan);
                                if (TagList.ContainsKey("SourceID") && TagList["SourceID"] != null && !Guid.Parse(TagList["SourceID"].Trim()).Equals(Guid.Empty))//(item.SourceID != null && !item.SourceID.Equals(Guid.Empty))
                                {
                                    Guid SourceID = Guid.Parse(TagList["SourceID"].Trim());
                                    UserDefineSource UDS = db.UserDefineSource.Where(p => p.SourceID.Equals(SourceID)).FirstOrDefault();
                                    SystemFunction.SetComboBoxItems(CB, CodeFunction.GetUDFSourcebySourceScript(UDS.SourceScript, UDS.ValueMember, UDS.DisplayMember), true, enableSW, true, true);
                                }
                                controlList.Add(CB);
                                break;
                            case "NumericUpDown":
                                NumericUpDown NUD = new NumericUpDown();
                                NUD.Enabled = enableSW;
                                NUD.Name = item.ControlID.ToString();
                                NUD.Visible = item.Visible;
                                NUD.Anchor = SetAnchorStyles(item.Anchor);
                                NUD.Dock = SetDockStyle(item.Dock);
                                NUD.AutoSize = true;
                                NUD.Maximum = TagList.ContainsKey("Maximum") ? Convert.ToDecimal(TagList["Maximum"]) : 100;
                                NUD.Minimum = TagList.ContainsKey("Minimum") ? Convert.ToDecimal(TagList["Minimum"]) : 0;
                                NUD.DecimalPlaces = TagList.ContainsKey("DecimalPlaces") ? Convert.ToInt32(TagList["DecimalPlaces"]) : 0;
                                NUD.Value = TagList.ContainsKey("NumericValue") ? Convert.ToDecimal(TagList["NumericValue"]) : 0;
                                userdefinelayout.Controls.Add(NUD, item.LayoutColumn, item.LayoutRow);
                                userdefinelayout.SetColumnSpan(NUD, item.ColumnSpan);
                                userdefinelayout.SetRowSpan(NUD, item.RowSpan);
                                controlList.Add(NUD);
                                break;
                            default:
                                break;
                        }
                    }
                    else if (actionControl.Name == item.ControlID.ToString())
                    {
                        actionControl.Enabled = enableSW;
                    }
                }
            }

            if (editmode)
            {
                for (int y = 0; y < userdefinelayout.RowCount; y++)
                {
                    for (int x = 0; x < userdefinelayout.ColumnCount; x++)
                    {
                        if (userdefinelayout.GetControlFromPosition(x, y) == null)//!UsedMap[i, y])
                        {
                            Button BTN = new Button();
                            BTN.Name = string.Format("{0},{1}", x.ToString(), y.ToString());
                            BTN.Text = "新增元件";
                            BTN.Visible = true;
                            BTN.Anchor = AnchorStyles.None;
                            BTN.Dock = DockStyle.Fill;
                            //BTN.Click += Control_Click;
                            userdefinelayout.Controls.Add(BTN, x, y);
                            userdefinelayout.SetColumnSpan(BTN, 1);
                            userdefinelayout.SetRowSpan(BTN, 1);
                        }
                    }
                }
            }
            userdefinelayout.ResumeLayout();
            return controlList;
        }
        private static void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            (sender as DateTimePicker).Checked = true;
            (sender as DateTimePicker).CustomFormat = "yyyy/MM/dd";
        }
        private static void DateTimePicker_DropDown(object sender, EventArgs e)
        {
            (sender as DateTimePicker).Value = DateTime.Today;
            (sender as DateTimePicker).Checked = false;
            (sender as DateTimePicker).Format = DateTimePickerFormat.Custom;
            (sender as DateTimePicker).CustomFormat = " ";
        }
        #region DB Data To Dock
        //DB Data To Dock
        public static DockStyle SetDockStyle(string SourceString)
        {
            DockStyle dockStyle = new DockStyle();

            switch (SourceString)
            {
                case "Fill":
                    dockStyle = DockStyle.Fill;
                    break;
                case "Top":
                    dockStyle = DockStyle.Top;
                    break;
                case "Bottom":
                    dockStyle = DockStyle.Bottom;
                    break;
                case "Left":
                    dockStyle = DockStyle.Left;
                    break;
                case "Right":
                    dockStyle = DockStyle.Right;
                    break;
                default:
                    dockStyle = DockStyle.None;
                    break;
            }
            return dockStyle;
        }
        #endregion
        #region DB Data To Anchor
        //DB Data To Anchor
        public static AnchorStyles SetAnchorStyles(string SourceString)
        {
            AnchorStyles anchorStyles = new AnchorStyles();
            string[] StringList = SourceString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in StringList)
            {
                switch (item.Trim())
                {
                    case "Top":
                        anchorStyles = anchorStyles | AnchorStyles.Top;
                        break;
                    case "Bottom":
                        anchorStyles = anchorStyles | AnchorStyles.Bottom;
                        break;
                    case "Left":
                        anchorStyles = anchorStyles | AnchorStyles.Left;
                        break;
                    case "Right":
                        anchorStyles = anchorStyles | AnchorStyles.Right;
                        break;
                    default:
                        anchorStyles = AnchorStyles.None;
                        break;
                }
            }
            return anchorStyles;
        }
        #endregion

        #endregion
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
        public System.Windows.Forms.Control CheckText()
        {
            foreach (var it in checkList)
            {
                if (it is System.Windows.Forms.ComboBox )
                {
                    var ctrl = it as System.Windows.Forms.ComboBox;
                    if (ctrl.Text == null || ctrl.Text.ToString().Trim().Length == 0)
                        return ctrl;
                }
                else if (it is JBControls.ComboBox)
                {
                    var ctrl = it as JBControls.ComboBox;
                    if (ctrl.Text == null || ctrl.Text.ToString().Trim().Length == 0)
                        return ctrl;
                }
                else if(it is System.Windows.Forms.TextBox)
                {
                    var ctrl = it as System.Windows.Forms.TextBox;
                    if (ctrl.Text == null || ctrl.Text.ToString().Trim().Length == 0)
                        return ctrl;
                }
                else if(it is JBControls.TextBox)
                {
                    var ctrl = it as JBControls.TextBox;
                    if (ctrl.Text == null || ctrl.Text.ToString().Trim().Length == 0)
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
    public class CheckYYMMFormatControl
    {
        List<Control> checkReuiredList;
        List<Control> checkYYMMList;
        int LengthMAX = 6;
        public CheckYYMMFormatControl()
        {
            checkReuiredList = new List<Control>();
            checkYYMMList = new List<Control>();
        }
        public System.Windows.Forms.Control CheckRequiredFields()
        {
            foreach (var it in checkReuiredList)
                if (it is System.Windows.Forms.TextBox && string.IsNullOrWhiteSpace(it.Text.ToString()))
                    return it;
            return null;
        }
        public void AddControl(Control control, bool required, bool isEnable = true)
        {
            control.KeyPress += Control_KeyPressTimeCheck;
            control.Enabled = isEnable;

            checkYYMMList.Add(control);
            control.TextChanged += Control_TextChangedYYMM;
            control.Leave += Control_LeaveYYMM;

            if (required)
                checkReuiredList.Add(control);
        }
        private void Control_TextChangedYYMM(object sender, EventArgs e)
        {
            Control_TextChechedYYMMCheck(sender, 10000);
        }
        private void Control_LeaveYYMM(object sender, EventArgs e)
        {
            TextPadLeftBySetting(sender, LengthMAX, '0');
        }

        private void TextPadLeftBySetting(object sender, int LengthMax, Char replaceChar)
        {
            TextBox control = sender as TextBox;
            if (control.Visible && control.Enabled && control.Text.Length > 0 && control.Text.Length < LengthMax)
            {
                MessageBox.Show(string.Format("輸入長度不足,將強制在左側補0,防止資料異常."), "格式錯誤(yyyyMM)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                control.Text = control.Text.PadLeft(LengthMax, replaceChar);
                return;
            }
        }

        private void Control_KeyPressTimeCheck(object sender, KeyPressEventArgs e)
        {
            if (TimeTextInputCheck(sender, e))
                e.Handled = true;
        }
        private bool TimeTextInputCheck(object sender, KeyPressEventArgs e)
        {
            return (sender is TextBox)
                && (((int)e.KeyChar < 48 || (int)e.KeyChar > 57)
                || (sender as TextBox).Text.Length >= LengthMAX && (sender as TextBox).SelectionLength == 0)
               && ((int)e.KeyChar != 8);
        }

        private void Control_TextChechedYYMMCheck(object sender, int YearFormat)
        {
            TextBox control = sender as TextBox;
            int yymm;
            if (control.Visible && control.Enabled && control.Text.Length == LengthMAX)
            {
                if (int.TryParse(control.Text, out yymm))
                {
                    int MinTime = 175301;
                    int MaxTime = (YearFormat - 1) * 100 + 12;
                    if (yymm < MinTime || yymm > MaxTime)
                    {
                        MessageBox.Show(string.Format("此欄位限制輸入計薪年月{1}~{2}.", YearFormat, MinTime, MaxTime), "超過範圍(yyyyMM)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Text = MaxTime.ToString("000000");
                        control.SelectAll();
                        return;
                    }
                    int mins = yymm % 100;
                    if (mins > 12 || mins < 1)
                    {
                        MessageBox.Show(string.Format("月份欄位只能輸入01~12.", YearFormat), "格式錯誤(yyyyMM)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Text = (yymm / 100 * 100 + 12).ToString("000000");
                        control.SelectionStart = 4;
                        control.SelectionLength = 2;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("欄位內容非計薪年月格式(yyyyMM).", YearFormat), "格式錯誤(yyyyMM)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    control.Text = string.Empty;
                    return;
                }
            }
        }
    }
    public class CheckTimeFormatControl
    {
        List<Control> checkReuiredList;
        List<Control> check24TimeList;
        List<Control> check48TimeList;
        public CheckTimeFormatControl()
        {
            checkReuiredList = new List<Control>();
            check24TimeList = new List<Control>();
            check48TimeList = new List<Control>();
        }
        public System.Windows.Forms.Control CheckRequiredFields()
        {
            foreach (var it in checkReuiredList)
                if (it is System.Windows.Forms.TextBox && string.IsNullOrWhiteSpace(it.Text.ToString()))
                    return it;
            return null;
        }
        public void AddControl(Control control, bool is48Time, bool required,bool isEnable =true)
        {
            control.KeyPress += Control_KeyPressTimeCheck;
            control.Enabled = isEnable;
            if (is48Time)
            {
                check48TimeList.Add(control);
                control.TextChanged += Control_TextChanged48Time;
                control.Leave += Control_Leave48Time;
            }
            else
            {
                check24TimeList.Add(control);
                control.TextChanged += Control_TextChanged24Time;
                control.Leave += Control_Leave24Time;
            }

            if (required)
                checkReuiredList.Add(control);
        }
        private void Control_TextChanged24Time(object sender, EventArgs e)
        {
            Control_TextChechedTimeCheck(sender, 24);
        }
        private void Control_Leave24Time(object sender, EventArgs e)
        {
            //Control_TextChechedTimeCheck(sender, 24);
            TextPadLeftBySetting(sender, 4, '0');
        }
        private void Control_TextChanged48Time(object sender, EventArgs e)
        {
            Control_TextChechedTimeCheck(sender, 48);
        }
        private void Control_Leave48Time(object sender, EventArgs e)
        {
            //Control_TextChechedTimeCheck(sender, 48);
            TextPadLeftBySetting(sender, 4, '0');
        }

        private static void TextPadLeftBySetting(object sender, int LengthMax, Char replaceChar)
        {
            TextBox control = sender as TextBox;
            if (control.Visible && control.Enabled && control.Text.Length > 0 && control.Text.Length < LengthMax)
            {
                MessageBox.Show(string.Format("輸入長度不足,將強制在左側補0,防止資料異常."), "格式錯誤(HHmm)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                control.Text = control.Text.PadLeft(LengthMax, replaceChar);
                return;
            }
        }

        private void Control_KeyPressTimeCheck(object sender, KeyPressEventArgs e)
        {
            if (TimeTextInputCheck(sender, e))
                e.Handled = true;
        }
        private static bool TimeTextInputCheck(object sender, KeyPressEventArgs e)
        {
            return (sender is TextBox)
                && (((int)e.KeyChar < 48 || (int)e.KeyChar > 57)
                || (sender as TextBox).Text.Length >= 4 && (sender as TextBox).SelectionLength == 0)
               && ((int)e.KeyChar != 8);
        }

        private static void Control_TextChechedTimeCheck(object sender, int timeFormat)
        {
            TextBox control = sender as TextBox;
            int time;
            if (control.Visible && control.Enabled && control.Text.Length == 4)
            {
                if (int.TryParse(control.Text, out time))
                {
                    if (time < 0000 || time > timeFormat * 100)
                    {
                        MessageBox.Show(string.Format("此欄位限制輸入{0}小時制時間(0000~{0}00).", timeFormat), "超過範圍(HHmm)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Text = (timeFormat * 100).ToString();
                        control.SelectAll();
                        return;
                    }
                    int mins = time % 100;
                    if (mins >= 60)
                    {
                        MessageBox.Show(string.Format("分鐘欄位只能輸入00~59.", timeFormat), "格式錯誤(HHmm)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Text = (time / 100 * 100 + 59).ToString("0000");
                        control.SelectionStart = 2;
                        control.SelectionLength = 2;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("欄位內容非時間格式(HHmm).", timeFormat), "格式錯誤(HHmm)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    control.Text = string.Empty;
                    return;
                }
            }
        }
    }
}
