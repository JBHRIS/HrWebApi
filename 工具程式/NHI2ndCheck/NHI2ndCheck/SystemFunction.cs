using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class SystemFunction
    {
      

      
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

    }
   
