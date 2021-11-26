using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sys
{
    public partial class DEPT_DATAID : Form
    {
        public DEPT_DATAID()
        {
            InitializeComponent();
        }
        List<JBModule.Data.Linq.DEPT> DeptaList = new List<JBModule.Data.Linq.DEPT>();
        List<JBModule.Data.Linq.U_DATAID> dataidList = new List<JBModule.Data.Linq.U_DATAID>();
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        private void DEPT_DATAID_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableVBase(this.mainDS.V_BASE);
            this.u_USERTableAdapter.Fill(this.sysDS.U_USER);
            DeptaList = (from a in db.DEPT where DateTime.Today >= a.ADATE && DateTime.Today <= a.DDATE.Value select a).ToList();
            LoadDeptTree();
            treeView1.ExpandAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cc = LoadDataID(ptxNobr.Text);
            MessageBox.Show("讀取完成,共" + cc.ToString() + "筆設定");

        }
        void LoadDeptTree()
        {
            treeView1.Nodes.Clear();
            var sql = from a in DeptaList where a.DEPT_GROUP == "" select a;
            foreach (var r in sql)
            {
                TreeNode td = new TreeNode();
                td.Text = r.D_NAME;
                td.Tag = r.D_NO.ToString();
                treeView1.Nodes.Add(td);
                LoadDeptNodes(td);
            }
        }
        void LoadDeptNodes(TreeNode ParentNode)
        {
            var sql = from a in DeptaList where a.DEPT_GROUP == ParentNode.Tag.ToString() select a;
            foreach (var r in sql)
            {
                TreeNode td = new TreeNode();
                td.Text = r.D_NAME;
                td.Tag = r.D_NO.ToString();
                ParentNode.Nodes.Add(td);
                LoadDeptNodes(td);
            }
        }
        int LoadDataID(string Nobr)
        {
            int count = 0;
            dataidList = (from a in db.U_DATAID where a.USER_ID == Nobr && a.SYSTEM == "Portal" select a).ToList();
            foreach (TreeNode td in treeView1.Nodes)
            {
                var query = from a in dataidList where a.DEPT == td.Tag.ToString() select a;
                if (query.Any())
                {
                    td.Checked = true;
                    td.ForeColor = Color.Blue;
                }
                else
                {
                    td.Checked = false;
                    td.ForeColor = Color.Black;
                }
                CheckDataID(td);
            }
            count = dataidList.Count();
            return count;
        }
        void CheckDataID(TreeNode node)
        {
            foreach (TreeNode td in node.Nodes)
            {
                var query = from a in dataidList where a.DEPT == td.Tag.ToString() select a;
                if (query.Any())
                {
                    td.Checked = true;
                    td.ForeColor = Color.Blue;
                }
                else
                {
                    td.Checked = false;
                    td.ForeColor = Color.Black;
                }
                CheckDataID(td);
            }
        }
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                e.Node.ForeColor = Color.Blue;
            }
            else
            {
                e.Node.ForeColor = Color.Black;
            }
            ChildNodeCheck(e.Node, e.Node.Checked);
        }
        void ChildNodeCheck(TreeNode node, bool isCheck)
        {
            foreach (TreeNode td in node.Nodes)
            {
                td.Checked = isCheck;
                if (isCheck)
                {
                    td.Checked = true;
                    td.ForeColor = Color.Blue;
                }
                else
                {
                    td.Checked = false;
                    td.ForeColor = Color.Black;
                }
                ChildNodeCheck(td, isCheck);
            }
        }
        void SaveDataID(string Nobr, TreeNode node)
        {
            foreach (TreeNode nd in node.Nodes)
            {
                if (nd.Checked)
                {
                    JBModule.Data.Linq.U_DATAID dataid = new JBModule.Data.Linq.U_DATAID();
                    dataid.DEPT = nd.Tag.ToString();
                    dataid.KEY_DATE = DateTime.Now;
                    dataid.KEY_MAN = MainForm.USER_NAME;
                    dataid.SYSTEM = "Portal";
                    dataid.USER_ID = Nobr;
                    db.U_DATAID.InsertOnSubmit(dataid);
                }
                SaveDataID(Nobr, nd);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (ptxNobr.Text.Trim().Length > 0)
            {
                try
                {
                    db = new JBModule.Data.Linq.HrDBDataContext();
                    if (db.Connection.State != ConnectionState.Open)
                        db.Connection.Open();
                    db.Transaction = db.Connection.BeginTransaction();
                    db.ExecuteCommand("DELETE U_DATAID WHERE USER_ID={0} AND SYSTEM={1}", new object[] { ptxNobr.Text, "Portal" });
                    foreach (TreeNode nd in treeView1.Nodes)
                    {
                        if (nd.Checked)
                        {
                            JBModule.Data.Linq.U_DATAID dataid = new JBModule.Data.Linq.U_DATAID();
                            dataid.DEPT = nd.Tag.ToString();
                            dataid.KEY_DATE = DateTime.Now;
                            dataid.KEY_MAN = MainForm.USER_NAME;
                            dataid.SYSTEM = "Portal";
                            dataid.USER_ID = ptxNobr.Text;
                            db.U_DATAID.InsertOnSubmit(dataid);
                        }
                        SaveDataID(ptxNobr.Text, nd);
                    }
                    db.SubmitChanges();
                    db.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    db.Transaction.Rollback();
                }
                MessageBox.Show("助理設定變更完成");
            }
            else MessageBox.Show("請先選擇助理工號");
        }
    }
}
