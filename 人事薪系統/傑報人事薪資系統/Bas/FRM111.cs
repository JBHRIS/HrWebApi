using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Bas
{
    public partial class FRM111 : JBControls.JBForm
    {
        public FRM111()
        {
            InitializeComponent();
        }
        CheckControl cc;//必要欄位檢查
        BasDS.DEPTDataTable TreeData = null;
        private void FRM111_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();//必要欄位檢查
            //cc.AddControl(cbxDeptTree);
            SystemFunction.SetComboBoxItems(cbDEPT_GROUP, CodeFunction.GetDept_effe(), true, false, true);      //部門群組
            SystemFunction.SetComboBoxItems(cbxDeptTree, CodeFunction.GetDept_effe(), true, false, true);      //部門群組
            //cbDEPT_GROUP.Enabled = false;
            SystemFunction.CheckCodeConfigRule(btnCodeGroup);//**代碼權限設定**
            Sal.Function.SetAvaliableVBase(this.basDS.V_BASE);

            this.dEPTTableAdapter.FillByValid(this.basDS.DEPT, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.dEPTTableAdapter.FillByValid(this.basDS1.DEPT, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.basDS1.DEPT.Load(this.basDS.DEPT.CreateDataReader());

            fullDataCtrl1.DataAdapter = dEPTTableAdapter;
            GetTreeData();
            ExpandDeptTree();
            //var sql = from a in this.basDS1.DEPT where a.DEPT_GROUP == "" select a;
            //foreach (var row in sql)
            //{
            //    TreeNode node = new TreeNode(row.D_NAME.Trim());
            //    node.Tag = row.D_NO.Trim();
            //    node.Expand();
            //    treeView1.Nodes.Add(node);
            //    CreateDeptTree(row, node);
            //}

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }
            fullDataCtrl1.CodeColumn = "DEPT.D_NO";//**代碼權限設定**
            fullDataCtrl1.CodeSource = "DEPT";//**代碼權限設定**
            fullDataCtrl1.Init_Ctrls();
            var data = GetDeptLeaveManagers();
            if (data.Any())
                btnMang_Click(null, null);
        }
        void ExpandDeptTree()
        {
            var sql = from a in TreeData where a.DEPT_GROUP == "" select a;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var baseSQL = from a in db.BASE
                          join b in db.BASETTS on a.NOBR equals b.NOBR
                          where
                          //db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                          && DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                          && !new string[] { "2", "5" }.Contains(b.TTSCODE)
                          select new { NOBR = (b.MANG ? "*" : "") + a.NOBR + "-" + a.NAME_C, b.DEPT };
            //var mangSQL = from a in db.BASE
            //              join b in db.BASETTS on a.NOBR equals b.NOBR
            //              where db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
            //              && DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
            //              && b.MANG
            //              select new { a.NOBR, b.DEPT };
            var dicEmp = baseSQL.ToDictionary(p => p.NOBR, p => p.DEPT);
            //var dicMang = mangSQL.ToDictionary(p => p.NOBR, p => p.DEPT);
            List<TreeNode> treeNodes = new List<TreeNode>();
            foreach (var row in sql)
            {
                TreeNode node = new TreeNode(row.D_NAME.Trim());
                node.Tag = row.D_NO.Trim();
                node.ToolTipText = row.D_NO_DISP.Trim();
                node.Expand();
                var fm = new Font(treeView1.Font, FontStyle.Bold);
                node.NodeFont = fm;
                //treeView1.Nodes.Add(node);
                treeNodes.Add(node);
                CreateDeptTree(row, node, dicEmp);
            }
            treeView1.Nodes.Clear();
            treeView1.Nodes.AddRange(treeNodes.ToArray());
        }
        private void CreateDeptTree(Bas.BasDS.DEPTRow pRow, TreeNode pNode, Dictionary<string, string> EmpData)
        {
            //Bas.BasDS.DEPTDataTable DEPTDataTable = dEPTTableAdapter.GetDataByDEPTGROUP(pRow.D_NO.Trim());
            //var sql = from a in this.basDS1.DEPT where a.DEPT_GROUP == pRow.D_NO.Trim() select a;

            //20121129 request by 葉玉蘭 20121205 edit by serlina 編製部門代碼的組織樹只要顯示目前生效的 
            CreateEmpTree(pNode, EmpData);
            var sql = from a in TreeData where a.DEPT_GROUP == pRow.D_NO.Trim() && a.ADATE <= System.DateTime.Today && a.DDATE >= System.DateTime.Today select a;
            foreach (var row in sql)
            {
                TreeNode node = new TreeNode(row.D_NAME.Trim());
                node.Tag = row.D_NO.Trim();
                node.ToolTipText = row.D_NO_DISP.Trim();
                node.Expand();
                var fm = new Font(treeView1.Font, FontStyle.Bold);
                node.NodeFont = fm;
                pNode.Nodes.Add(node);
                //CreateEmpTree(node, EmpData);
                CreateDeptTree(row, node, EmpData);
            }
        }
        private void CreateEmpTree(TreeNode pNode, Dictionary<string, string> EmpData)
        {
            var query = from a in EmpData where a.Value == pNode.Tag.ToString() select a;

            pNode.Text += "(" + query.Count() + ")";

            foreach (var row in query)
            {
                TreeNode node = new TreeNode(row.Key.Trim());
                node.Tag = row.Value.Trim();
                //node.ToolTipText = row.Key.Trim();
                if (node.Text.IndexOf("*") == 0)
                    node.ForeColor = Color.Red;
                node.Expand();
                pNode.Nodes.Add(node);
                //CreateDeptTree(row, node, EmpData);
            }
        }
        void GetTreeData()
        {
            TreeData = new BasDS.DEPTDataTable();
            dEPTTableAdapter.Fill(TreeData, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
        }
        BasDS.DEPTDataTable GetDataByDEPTGROUP(string PID)
        {
            BasDS.DEPTDataTable TreeDataNodes = new BasDS.DEPTDataTable();
            var data = from a in TreeData where a.DEPT_GROUP == PID select a;
            foreach (var it in data)
                TreeDataNodes.ImportRow(it);
            return TreeDataNodes;
        }
        private void CreateDeptTree(Bas.BasDS.DEPTRow pRow, TreeNode pNode)
        {
            //Bas.BasDS.DEPTDataTable DEPTDataTable = dEPTTableAdapter.GetDataByDEPTGROUP(pRow.D_NO.Trim());
            //var sql = from a in this.basDS1.DEPT where a.DEPT_GROUP == pRow.D_NO.Trim() select a;

            //20121129 request by 葉玉蘭 20121205 edit by serlina 編製部門代碼的組織樹只要顯示目前生效的 

            Bas.BasDS.DEPTDataTable DEPTDataTable = GetDataByDEPTGROUP(pRow.D_NO.Trim());
            foreach (var row in DEPTDataTable)
            {
                TreeNode node = new TreeNode(row.D_NAME.Trim());
                node.Tag = row.D_NO.Trim();
                node.Expand();
                pNode.Nodes.Add(node);
                CreateDeptTree(row, node);
            }
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);

                //treeView1.Nodes.Clear();
                GetTreeData();
                //Bas.BasDS.DEPTDataTable p_DEPTDataTable = GetDataByDEPTGROUP("");
                //foreach (var row in p_DEPTDataTable)
                //{
                //    TreeNode node = new TreeNode(row.D_NAME.Trim());
                //    node.Tag = row.D_NO.Trim();
                //    node.Expand();
                //    treeView1.Nodes.Add(node);
                //    CreateDeptTree(row, node);
                //}
                treeView1.SuspendLayout();
                ExpandDeptTree();
                treeView1.ResumeLayout();

                this.basDS1.DEPT.Clear();
                this.basDS1.DEPT.Load(this.basDS.DEPT.CreateDataReader());
            }
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!e.Cancel)
            {
                var ctrl = cc.CheckRequiredFields();//必要欄位檢查
                if (ctrl != null)//必要欄位檢查
                {
                    MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctrl.Focus();
                    e.Cancel = true;
                    return;
                }
                if (Convert.ToDateTime(e.Values["adate"]) > Convert.ToDateTime(e.Values["ddate"]))
                {
                    e.Cancel = true;
                    MessageBox.Show(Resources.Bas.DeptDateErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)//**代碼權限設定**20121017
                {
                    e.Values["D_NO"] = Guid.NewGuid().ToString();
                    if (e.Values["DEPT_TREE"].ToString().Trim().Length == 0)
                        e.Values["DEPT_TREE"] = e.Values["D_NO"];
                }
                

                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
                
                if (cbDEPT_GROUP.SelectedValue != null && isLoop(e.Values["D_NO"].ToString(), e.Values["D_NO"].ToString(), cbDEPT_GROUP.SelectedValue.ToString()))
                {
                    MessageBox.Show("為防止部門層級無限迴圈，請重新選取「部門群組」。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbDEPT_GROUP.Focus();
                    e.Cancel = true;
                    return;
                }
                if (CheckRepeat(e.Values["D_NO"].ToString(), e.Values["D_NO_DISP"].ToString()))//**代碼權限設定**20121017
                {
                    MessageBox.Show(Resources.Sys.CodeRepeat, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
                GetTreeData();
                //treeView1.Nodes.Clear();
                //Bas.BasDS.DEPTDataTable p_DEPTDataTable = GetDataByDEPTGROUP("");
                //foreach (var row in p_DEPTDataTable)
                //{
                //    TreeNode node = new TreeNode(row.D_NAME.Trim());
                //    node.Tag = row.D_NO.Trim();
                //    node.Expand();
                //    treeView1.Nodes.Add(node);
                //    CreateDeptTree(row, node);
                //}
                treeView1.SuspendLayout();
                ExpandDeptTree();
                treeView1.ResumeLayout();
                foreach (TreeNode node in treeView1.Nodes)
                {
                    TreeNode retNode = FindNode(node, textBox1.Text);
                    if (retNode != null)
                    {
                        treeView1.SelectedNode = retNode;
                    }
                }

                this.basDS1.DEPT.Clear();
                this.basDS1.DEPT.Load(this.basDS.DEPT.CreateDataReader());
                SystemFunction.SetComboBoxItems(cbxDeptTree, CodeFunction.GetDept_effe(), true);      //部門群組
                SystemFunction.SetComboBoxItems(cbDEPT_GROUP, CodeFunction.GetDept_effe(), true);      //部門群組
            }
        }

        private TreeNode FindNode(TreeNode pNode, string d_no)
        {
            if (pNode.Tag.ToString().Trim() == d_no.Trim()) return pNode;
            else
            {
                TreeNode retNode = null;
                foreach (TreeNode node in pNode.Nodes)
                {
                    retNode = FindNode(node, d_no);
                    if (retNode != null && retNode.Tag.ToString().Trim() == d_no.Trim()) break;
                }
                return retNode;
            }
        }

        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (dEPTBindingSource.Count > 0)
            {
                if (treeView1.SelectedNode != null)
                {
                    int index = dEPTBindingSource.Find("d_no", treeView1.SelectedNode.Tag);
                    if (index != -1) dEPTBindingSource.Position = index;
                    else dEPTBindingSource.Position = 0;
                }
            }
            SetCode(JBControls.FullDataCtrl.EEditType.None);
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (dEPTBindingSource.Count > 0)
            {
                int index = dEPTBindingSource.Find("d_no", treeView1.SelectedNode.Tag);
                if (index != -1) dEPTBindingSource.Position = index;
                else dEPTBindingSource.Position = 0;
            }
        }

        private void dataGridViewEx1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            foreach (TreeNode node in treeView1.Nodes)
            {
                TreeNode retNode = FindNode(node, (dEPTBindingSource[e.RowIndex] as DataRowView)["d_no"].ToString());
                if (retNode != null)
                {
                    treeView1.SelectedNode = retNode;
                    break;
                }
            }
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                if (treeView1.SelectedNode != null)
                {
                    e.Values["DEPT_GROUP"] = treeView1.SelectedNode.Tag;
                }
                e.Values["adate"] = DateTime.Now.ToString("yyyy/MM/dd");
                e.Values["ddate"] = "9999/12/31";
                textBox5.Text = Sal.Function.GetDate();
            }
            SetCode(JBControls.FullDataCtrl.EEditType.Add);
        }
        private void btnCodeGroup_Click(object sender, EventArgs e)//**代碼權限設定**
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (dEPTBindingSource.Current == null) return;
                BasDS.DEPTRow r = ((dEPTBindingSource.Current as DataRowView).Row as BasDS.DEPTRow);
                if (r != null)//**代碼權限設定**20121017
                {
                    Sys.SYS_CODE frm = new Sys.SYS_CODE();
                    frm.Source = "DEPT";
                    frm.Code = r.D_NO;
                    frm.Text += "(" + r.D_NAME + ")";
                    frm.ShowDialog();
                }
            }
        }
        bool CheckRepeat(string Code, string Disp)//**代碼權限設定**20121017
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DEPT
                      where a.D_NO != Code && a.D_NO_DISP == Disp
                     && db.GetCodeFilter("DEPT", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, true).Value//管理者權限設定true,才可以抓到該公司所有代碼
                      select a;
            return sql.Any();
        }

        private void textBox5_Validated(object sender, EventArgs e)
        {
            SetCode(fullDataCtrl1.EditType);
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            SetCode(JBControls.FullDataCtrl.EEditType.Modify);
        }

        private void btnMang_Click(object sender, EventArgs e)
        {
            Sal.PreviewForm frm = new Sal.PreviewForm();
            var data = GetDeptLeaveManagers();
            frm.DataTable = data.Select(p => new { 部門代碼 = p.Dept, 部門名稱 = p.DeptName, 主管工號 = p.Nobr, 主管姓名 = p.NameC }).CopyToDataTable();
            frm.Width = 550;
            frm.Form_Title = "離職主管名單";
            frm.ShowDialog();
            if (frm.SelectKey.Trim().Length > 0)
            {
                NavigateToDept(frm.SelectKey);
            }
        }
        public static List<DeptLeaveManager> GetDeptLeaveManagers()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            var sql = from a in db.BASETTS//非在職人員名單
                      where !ttscodeList.Contains(a.TTSCODE)
                      && DateTime.Today >= a.ADATE && DateTime.Today <= a.DDATE.Value
                      //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(a.SALADR)
                      select a;
            var DeptData = from a in db.DEPT
                           join c in db.BASE on a.NOBR equals c.NOBR
                           where db.GetCodeFilter("DEPT", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                           && a.ADATE != null && DateTime.Today >= a.ADATE.Value
                           && a.DDATE != null && DateTime.Today <= a.DDATE.Value
                           && (from b in sql where a.NOBR == b.NOBR select b).Any()
                           select new DeptLeaveManager { Dept = a.D_NO_DISP, DeptName = a.D_NAME, NameC = c.NAME_C, Nobr = a.NOBR };
            return DeptData.ToList();
        }
        bool isLoop(string OrgDept, string dept, string deptGroup)
        {
            if (string.IsNullOrWhiteSpace(deptGroup))
                return false;
            if (OrgDept == deptGroup)
                return true;
            string dg = GetDeptGroup(deptGroup);
            if (isLoop(OrgDept, deptGroup, dg))
            {
                return true;
            }
            return false;
            
        }
        string GetDeptGroup(string dept)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DEPT where a.D_NO == dept select a;
            if (sql.Any())
            {
                if (sql.First().D_NO_DISP == textBox1.Text)
                {
                    return cbDEPT_GROUP.SelectedValue.ToString();
                }
                return sql.First().DEPT_GROUP;
            }
            return null;
        }
        public void NavigateToDept(string DeptCode)
        {
            int index = dEPTBindingSource.Find("d_no", DeptCode);
            if (index != -1) dEPTBindingSource.Position = index;
            else dEPTBindingSource.Position = 0;
        }

        void SetCode(JBControls.FullDataCtrl.EEditType editType)
        {
             if (editType == JBControls.FullDataCtrl.EEditType.None)
                SystemFunction.SetComboBoxItems(cbDEPT_GROUP, CodeFunction.GetDept(), true, false, true);
            else
            {
                if (cbxAvailableCode.Checked)
                    SystemFunction.SetComboBoxItems(cbDEPT_GROUP, CodeFunction.GetDept(), true, true, true);
                else
                    SystemFunction.SetComboBoxItems(cbDEPT_GROUP, CodeFunction.GetDept_effe(Convert.ToDateTime(textBox5.Text)), true, true, true);
            }
        }

        private void cbxAvailableCode_CheckedChanged(object sender, EventArgs e)
        {
            SetCode(fullDataCtrl1.EditType);
        }
    }
    public class DeptLeaveManager
    {
        public string Nobr;
        public string NameC;
        public string Dept;
        public string DeptName;
    }
}
