using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HR_TOOL.JBQuery
{
    public partial class QueryColumnOrderByForm : Form
    {
        HrDBDataContext db = new HrDBDataContext();
        public int SettingID = 0;
        List<jqColumn> jqColumnList = new List<jqColumn>();
        public QueryColumnOrderByForm()
        {
            InitializeComponent();
        }

        private void QueryColumnOrderByForm_Load(object sender, EventArgs e)
        {
            var sql = from a in db.jqColumn where a.SettingID == SettingID orderby a.Sort select a;
            jqColumnList = sql.ToList();
            SetListBox();
        }
        void SetListBox()
        {
            var selectedData = from a in jqColumnList where a.Sort > 0 orderby a.Sort select a;
            var rejectData = from a in jqColumnList where a.Sort <= 0 select a;
            listBox1.Items.AddRange(selectedData.Select(p => p.TableName + "." + p.ColumnName).ToArray());
            listBox2.Items.AddRange(rejectData.Select(p => p.TableName + "." + p.ColumnName).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                int idx = listBox1.SelectedIndex;
                int new_idx = idx - 1;
                var itm = listBox1.SelectedItem.ToString();
                listBox1.Items.RemoveAt(idx);
                listBox1.Items.Insert(new_idx, itm);
                listBox1.SelectedIndex = new_idx;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                int idx = listBox1.SelectedIndex;
                int new_idx = idx + 1;
                var itm = listBox1.SelectedItem.ToString();
                listBox1.Items.RemoveAt(idx);
                listBox1.Items.Insert(new_idx, itm);
                listBox1.SelectedIndex = new_idx;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                var itm = listBox2.SelectedItem.ToString();
                listBox2.Items.Remove(itm);
                listBox1.Items.Add(itm);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var itm = listBox1.SelectedItem.ToString();
                listBox1.Items.Remove(itm);
                listBox2.Items.Add(itm);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int i = 0;
            db = new HrDBDataContext();
            db.jqColumn.AttachAll(jqColumnList);
            foreach (string it in listBox1.Items)
            {
                i++;
                var objs = it.Split('.');
                var qq = from a in jqColumnList where a.TableName == objs[0] && a.ColumnName == objs[1] select a;
                if (qq.Any())
                {
                    var r = qq.First();
                    r.Sort = i;
                    var OrignalState = db.jqColumn.GetOriginalEntityState(r);
                    var ModifyCotent = db.jqColumn.GetModifiedMembers(r);
                    if (ModifyCotent.Count() > 0)
                    {
                        r.CreateMan = Main.USER_NAME;
                        r.CreateDate = DateTime.Now;
                    }
                }
            }
            int j = 0;
            foreach (string it in listBox2.Items)
            {
                var objs = it.Split('.');
                var qq = from a in jqColumnList where a.TableName == objs[0] && a.ColumnName == objs[1] select a;
                if (qq.Any())
                {
                    qq.First().Sort = j;
                }
            }
            db.SubmitChanges();
            this.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
