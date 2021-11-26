using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM27A : JBControls.JBForm
    {
        public FRM27A()
        {
            InitializeComponent();
        }
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        private void FRM27A_Load(object sender, EventArgs e)
        {

        }

        private void jbAttend_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            if (jbAttend.SelectKeys.Count > 0)
            {
                List<Dictionary<string, string>> values = new List<Dictionary<string, string>>();
                foreach (var item in jbAttend.SelectKeys)
                    values.Add(ToDictionary<string>(item)); 

                FRM27A_ADD frm = new FRM27A_ADD();
                frm.Text = "FRM27A-假日班別批次修改";
                frm.keys = values;
                frm.ShowDialog();
            }
            else
                MessageBox.Show("請勾選欲調整的資料");
        }

        private static Dictionary<string, TValue> ToDictionary<TValue>(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, TValue>>(json);
            return dictionary;
        }
    }
}
