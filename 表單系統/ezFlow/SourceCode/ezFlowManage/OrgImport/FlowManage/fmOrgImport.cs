using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBHR.Dll;

namespace FlowManage
{
    public partial class fmOrgImport : Form
    {
        private dsBaseTableAdapters.EmpTableAdapter taEmp = new FlowManage.dsBaseTableAdapters.EmpTableAdapter();
        private dsBaseTableAdapters.DeptTableAdapter taDept = new FlowManage.dsBaseTableAdapters.DeptTableAdapter();
        private dsBaseTableAdapters.DeptLevelTableAdapter taDeptLevel = new FlowManage.dsBaseTableAdapters.DeptLevelTableAdapter();
        private dsBaseTableAdapters.PosTableAdapter taPos = new FlowManage.dsBaseTableAdapters.PosTableAdapter();
        private dsBaseTableAdapters.PosLevelTableAdapter taPosLevel = new FlowManage.dsBaseTableAdapters.PosLevelTableAdapter();
        private dsBaseTableAdapters.RoleTableAdapter taRole = new FlowManage.dsBaseTableAdapters.RoleTableAdapter();
        private dsBaseTableAdapters.SubWorkTableAdapter taSubWork = new FlowManage.dsBaseTableAdapters.SubWorkTableAdapter();

        private dsBaseTableAdapters.JB_HR_BaseTableAdapter taJB_HR_Base = new FlowManage.dsBaseTableAdapters.JB_HR_BaseTableAdapter();
        private dsBaseTableAdapters.JB_HR_DeptmTableAdapter taJB_HR_Deptm = new FlowManage.dsBaseTableAdapters.JB_HR_DeptmTableAdapter();
        private dsBaseTableAdapters.JB_HR_DeptLevelTableAdapter taJB_HR_DeptLevel = new FlowManage.dsBaseTableAdapters.JB_HR_DeptLevelTableAdapter();
        private dsBaseTableAdapters.JB_HR_JobTableAdapter taJB_HR_Job = new FlowManage.dsBaseTableAdapters.JB_HR_JobTableAdapter();
        private dsBase odsBase = new dsBase();

        private dsFlowTableAdapters.ProcessFlowTableAdapter taProcessFlow = new FlowManage.dsFlowTableAdapters.ProcessFlowTableAdapter();
        private dsFlowTableAdapters.ProcessCheckTableAdapter taProcessCheck = new FlowManage.dsFlowTableAdapters.ProcessCheckTableAdapter();
        private dsFlowTableAdapters.ProcessFlowShareTableAdapter taProcessFlowShare = new FlowManage.dsFlowTableAdapters.ProcessFlowShareTableAdapter();
        private dsFlowTableAdapters.ProcessMultiFlowTableAdapter taProcessMultiFlow = new FlowManage.dsFlowTableAdapters.ProcessMultiFlowTableAdapter();
        private dsFlow odsFlow = new dsFlow();

        private dsMainTableAdapters.OrgImportTableAdapter taOrgImport = new FlowManage.dsMainTableAdapters.OrgImportTableAdapter();
        private dsMain odsMain = new dsMain();
        private DataRow[] rows;

        private dcFlowDataContext dcFlow = new dcFlowDataContext();

        public fmOrgImport()
        {
            InitializeComponent();
        }

        private void fmOrgImport_Load(object sender, EventArgs e)
        {
            SetPageValue();
            CountNowValue();

            btnImport_Click(null, null);
        }

        //設定頁面的值
        private void SetPageValue()
        {
            taOrgImport.Fill(odsMain.OrgImport);
            if (odsMain.OrgImport.Rows.Count > 0)
            {
                dsMain.OrgImportRow r = odsMain.OrgImport.Rows[0] as dsMain.OrgImportRow;
                ckFullImport.Checked = r.bFullImport;
                ckSyncLoginPW.Checked = r.bSyncLoginPW;
                txtFrontLoginID.Text = r.sFrontLoginID;
                txtDeptTopCode.Text = r.sDeptTopCode;
                ckRoleTopEmpty.Checked = r.bRoleTopEmpty;
                checkBox1.Checked = r.bLevel;
            }
        }

        //收集Flow已存在的工號一併匯入
        private List<string> FlowOldNobr()
        {
            var rs = (from c in dcFlow.ProcessFlow select c.Emp_id).Union
                (from c in dcFlow.ProcessCheck select c.Emp_idDefault).Union
                (from c in dcFlow.ProcessCheck select c.Emp_idAgent).Union
                (from c in dcFlow.ProcessCheck select c.Emp_idReal).Union
                (from c in dcFlow.ProcessFlowShare select c.Emp_id).Union
                (from c in dcFlow.ProcessMultiFlow select c.SubInitEmp_id).Union
                (from c in dcFlow.ProcessMultiFlow select c.SubDynamicEmp_id);

            return rs.ToList();
        }

        IQueryable<JB_HR_Base> _BaseData = null;
        private IQueryable<JB_HR_Base> BasData
        {
            get
            {
                if (_BaseData == null)
                {
                    DateTime dDateB = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, 1);

                    List<string> ls = FlowOldNobr();
                    string a = ",";
                    foreach (string s in ls)
                        a += s + ",";

                    string[] sTtsCode = { "1", "4", "6" };
                    dcBasDataContext dcBas = new dcBasDataContext();
                    var dtBas = from c in dcBas.JB_HR_Base
                                where sTtsCode.Contains(Convert.ToString(c.sTtsCode))
                                    //|| ls.Contains(c.sNobr)
                                || a.IndexOf("," + c.sNobr.Trim() + ",") >= 0
                                || dDateB <= c.dOuDate.Value.Date
                                select c;

                    _BaseData = dtBas;
                }

                return _BaseData;
            }
        }

        //總計數目
        private void CountNowValue()
        {
            lblDeptCount.Text = taDept.GetData().Rows.Count.ToString();
            lblEmpCount.Text = taEmp.GetData().Rows.Count.ToString();
            lblJobCount.Text = taPos.GetData().Rows.Count.ToString();

            lblDeptCountNew.Text = Bas.Deptm().Rows.Count.ToString();
            lblEmpCountNew.Text = BasData.Count().ToString();
            lblJobCountNew.Text = Bas.Job().Rows.Count.ToString();
        }

        //匯入基本資料
        private void ImportBase()
        {
            dcFlow = new dcFlowDataContext();

            //先刪除基本資料完整匯入
            if (ckFullImport.Checked)
            {
                dsBase.EmpDataTable dtEmp = new dsBase.EmpDataTable();
                if (ckSyncLoginPW.Checked)
                {
                    lblState.Text = "密碼同步...";
                    Application.DoEvents();
                }

                taEmp.Fill(dtEmp);

                lblState.Text = "刪除基本資料...";
                Application.DoEvents();
                object[] obj = new object[] { "" };
                dcFlow.ExecuteCommand("DELETE FROM Emp", obj);
                dcFlow.ExecuteCommand("DELETE FROM Dept", obj);
                dcFlow.ExecuteCommand("DELETE FROM Pos", obj);
                dcFlow.ExecuteCommand("DELETE FROM DeptLevel", obj);
                dcFlow.ExecuteCommand("DELETE FROM PosLevel", obj);

                //匯入Emp
                string sPW;
                //string[] sTtsCode = { "1", "4", "6" };
                foreach (var r in BasData)
                {
                    pb.Value++;
                    lblState.Text = "基本資料匯入..." + pb.Value * 100 / pb.Maximum + "%"; ;
                    Application.DoEvents();

                    var dtEmpWhere = dtEmp.Where(p => p.id == r.sNobr).FirstOrDefault();
                    sPW = (ckSyncLoginPW.Checked || (dtEmpWhere == null)) ? (r.sPassWord.Length > 0 ? r.sPassWord : r.sNobr) : dtEmpWhere.pw.Trim().Length > 0 ? dtEmpWhere.pw : dtEmpWhere.id;
                    var re = new Emp();
                    re.id = r.sNobr;
                    re.pw = sPW;
                    re.name = dtEmpWhere == null ? r.sNameC : dtEmpWhere.name;  //第一次匯入才需要匯入名字，以後就直接匯入原本的名字20100819
                    //re.isNeedAgent = dtEmpWhere != null ? dtEmpWhere.isNeedAgent : false;
                    re.isNeedAgent = true;
                    re.dateB = dtEmpWhere != null ? dtEmpWhere.dateB : DateTime.Now.Date;
                    re.dateE = dtEmpWhere != null ? dtEmpWhere.dateE : DateTime.Now.Date;
                    re.email = r.sEmail;
                    re.login = dtEmpWhere != null ? dtEmpWhere.login : txtFrontLoginID.Text + r.sNobr;
                    re.sex = Convert.ToString(r.sSex);
                    dcFlow.Emp.InsertOnSubmit(re);
                }

                //匯入Dept
                dsBas.JB_HR_DeptmDataTable dtDeptm = Bas.Deptm();
                List<Dept> lsDept = new List<Dept>();
                List<DeptLevel> lsDeptLevel = new List<DeptLevel>();
                foreach (dsBas.JB_HR_DeptmRow r in dtDeptm.Rows)
                {
                    pb.Value++;
                    lblState.Text = "部門匯入..." + pb.Value * 100 / pb.Maximum + "%"; ;
                    Application.DoEvents();

                    if (r.sDeptCode.Length > 0)
                    {
                        var rd = new Dept();
                        rd.id = r.sDeptCode;
                        rd.idParent = r.sDeptCode == r.sDeptParent || rd.id == txtDeptTopCode.Text ? "" : r.sDeptParent;    //與部門代碼相同或是最上層部門就空白
                        rd.name = r.sDeptName;
                        rd.DeptLevel_id = r.sDeptTree.Length > 0 ? r.sDeptTree : "0";
                        rd.path = "";
                        lsDept.Add(rd);
                        //dcFlow.Dept.InsertOnSubmit(rd);

                        //建立部門所需階層資料
                        if (!lsDeptLevel.Where(p => p.id == rd.DeptLevel_id).Any())
                        {
                            var rdl = new DeptLevel();
                            rdl.id = rd.DeptLevel_id;
                            rdl.name = "部門";
                            rdl.sorting = checkBox1.Checked ? Convert.ToInt32(rd.DeptLevel_id) : Convert.ToInt32(rd.DeptLevel_id) - 1000;
                            lsDeptLevel.Add(rdl);
                        }
                    }
                }

                //建立部門所需階層資料-預設值
                if (!lsDeptLevel.Where(p => p.id == "0").Any())
                {
                    var rdl = new DeptLevel();
                    rdl.id = "0";
                    rdl.name = "部門";
                    rdl.sorting = 0;
                    lsDeptLevel.Add(rdl);
                }

                //匯入Pos
                dsBas.JB_HR_JobDataTable dtJob = Bas.Job();
                List<PosLevel> lsPosLevel = new List<PosLevel>();
                foreach (dsBas.JB_HR_JobRow r in dtJob.Rows)
                {
                    pb.Value++;
                    lblState.Text = "職稱匯入..." + pb.Value * 100 / pb.Maximum + "%";
                    Application.DoEvents();

                    if (r.sJobCode.Length > 0)
                    {
                        var rp = new Pos();
                        rp.id = r.sJobCode;
                        rp.name = r.sJobName;
                        rp.PosLevel_id = r.sJobTree.Length > 0 ? r.sJobTree : "0";
                        dcFlow.Pos.InsertOnSubmit(rp);

                        //建立職稱所需階層資料
                        if (!lsPosLevel.Where(p => p.id == rp.PosLevel_id).Any())
                        {
                            var rpl = new PosLevel();
                            rpl.id = rp.PosLevel_id;
                            rpl.name = "職員";
                            rpl.sorting = checkBox1.Checked ? Convert.ToInt32(rp.PosLevel_id) : Convert.ToInt32(rp.PosLevel_id) - 1000;
                            lsPosLevel.Add(rpl);
                        }
                    }
                }

                //建立職稱所需階層資料-預設值
                if (!lsPosLevel.Where(p => p.id == "0").Any())
                {
                    var rpl = new PosLevel();
                    rpl.id = "0";
                    rpl.name = "職員";
                    rpl.sorting = 0;
                    lsPosLevel.Add(rpl);
                }

                //建立部門從屬關係與產生部門路徑
                var rows = lsDept.Where(p => p.idParent == "");
                pb.Maximum += rows.Count();
                foreach (var r in rows)
                {
                    pb.Value++;
                    lblState.Text = "建立部門從屬關係..." + pb.Value * 100 / pb.Maximum + "%"; ;
                    Application.DoEvents();

                    r.path = "/" + r.name;
                    var rowsDept = lsDept.Where(p => p.idParent == r.id);
                    if (rowsDept.Count() > 0)
                        CreateSubOrgPath(lsDept, rowsDept, r.path);
                }

                dcFlow.PosLevel.InsertAllOnSubmit(lsPosLevel);
                dcFlow.DeptLevel.InsertAllOnSubmit(lsDeptLevel);
                dcFlow.Dept.InsertAllOnSubmit(lsDept);

                dcSubmitChanges(dcFlow);
            }
        }

        //遞回部門路徑
        public void CreateSubOrgPath(List<Dept> lsDept, IEnumerable<Dept> rows, string parentPath)
        {
            foreach (var r in rows)
            {
                r.path = parentPath + "/" + r.name;
                var rowsDept = lsDept.Where(p => p.idParent == r.id);
                if (rowsDept.Count() > 0)
                    CreateSubOrgPath(lsDept, rowsDept, r.path);
            }
        }

        //匯入角色並建立從屬關係
        private void ImportRole()
        {
            dcFlow = new dcFlowDataContext();

            //完整匯入
            if (ckFullImport.Checked)
            {
                lblState.Text = "暫存角色資料..." + pb.Value * 100 / pb.Maximum + "%";
                Application.DoEvents();
                dsBase.RoleDataTable dtRole = new dsBase.RoleDataTable();
                taRole.Fill(dtRole);

                lblState.Text = "刪除角色資料..." + pb.Value * 100 / pb.Maximum + "%";
                Application.DoEvents();
                object[] obj = new object[] { "" };
                dcFlow.ExecuteCommand("DELETE FROM Role", obj);

                DateTime dDateB = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, 1);

                //匯入Role
                string sID;
                string[] sTtsCode = { "1", "4", "6" };
                List<Role> lsRole = new List<Role>();
                foreach (var r in BasData)
                {
                    pb.Value++;
                    lblState.Text = "角色資料匯入..." + pb.Value * 100 / pb.Maximum + "%"; ;
                    Application.DoEvents();

                    sID = r.sDeptmCode + r.sJobCode;
                    sID += Convert.ToBoolean(r.bMang) ? "1" : "0";   //如果是主管，就改變角色代碼
                    var dtRoleWhere = dtRole.Where(p => p.id == sID).FirstOrDefault();

                    var rr = new Role();
                    rr.id = sID;
                    rr.idParent = "";
                    rr.Dept_id = r.sDeptmCode;
                    rr.Pos_id = r.sJobCode;
                    rr.dateB = sTtsCode.Contains(Convert.ToString(r.sTtsCode)) || dDateB <= r.dOuDate.Value.Date ? DateTime.Now.Date : Convert.ToDateTime(r.dAdate).Date;
                    rr.dateE = sTtsCode.Contains(Convert.ToString(r.sTtsCode)) || dDateB <= r.dOuDate.Value.Date ? new DateTime(9999, 12, DateTime.DaysInMonth(9999, 12)).Date : new DateTime(1900, 1, 1).Date;
                    //rr.dateB = DateTime.Now.AddDays(-1).Date;
                    //rr.dateE = new DateTime(9999, 12, 31).Date;
                    rr.Emp_id = r.sNobr;
                    rr.mgDefault = r.bMang;
                    rr.deptMg = r.bMang;
                    lsRole.Add(rr);
                }

                //匯入副職
                taSubWork.Fill(odsBase.SubWork);
                pb.Maximum += odsBase.SubWork.Count;
                foreach (dsBase.SubWorkRow r in odsBase.SubWork.Rows)
                {
                    pb.Value++;
                    lblState.Text = "副職角色資料匯入..." + pb.Value * 100 / pb.Maximum + "%"; ;
                    Application.DoEvents();

                    sID = r.sSubDept + r.sSubJob;
                    sID += r.bSubMang ? "1" : "0";
                    var lsRoleWhere = lsRole.Where(p => p.id == sID).FirstOrDefault();

                    if (lsRoleWhere == null)
                    {
                        var rr = new Role();
                        rr.id = sID;
                        rr.idParent = "";
                        rr.Dept_id = r.sSubDept;
                        rr.Pos_id = r.sSubJob;
                        rr.dateB = DateTime.Now.Date;
                        rr.dateE = new DateTime(9999, 12, DateTime.DaysInMonth(9999, 12)).Date;
                        rr.Emp_id = r.sNobr;
                        rr.mgDefault = r.bSubMang;
                        rr.deptMg = r.bSubMang;
                        lsRole.Add(rr);
                    }
                    else
                    {
                        //取代原本的
                        if (r.bReplace)
                        {
                            lsRoleWhere.Dept_id = r.sSubDept;
                            lsRoleWhere.Pos_id = r.sSubJob;
                            lsRoleWhere.dateE = new DateTime(9999, 12, DateTime.DaysInMonth(9999, 12)).Date;
                            lsRoleWhere.mgDefault = r.bSubMang;
                            lsRoleWhere.deptMg = r.bSubMang;
                        }
                        else
                        {
                            //因為用取代，所以工號不同時才要新增一筆 
                            if (r.sNobr != lsRoleWhere.id)
                            {
                                var rr = new Role();
                                rr.id = sID;
                                rr.idParent = "";
                                rr.Dept_id = r.sSubDept;
                                rr.Pos_id = r.sSubJob;
                                rr.dateB = DateTime.Now.Date;
                                rr.dateE = new DateTime(9999, 12, DateTime.DaysInMonth(9999, 12)).Date;
                                rr.Emp_id = r.sNobr;
                                rr.mgDefault = r.bSubMang;
                                rr.deptMg = r.bSubMang;
                                lsRole.Add(rr);
                            }
                        }
                    }

                }

                //建立角色從屬關係
                var dtBasData = BasData.Where(p => p.bMang == true && sTtsCode.Contains(Convert.ToString(p.sTtsCode)));
                pb.Maximum += dtBasData.Count();
                foreach (var r in dtBasData)
                {
                    pb.Value++;
                    lblState.Text = "建立角色從屬關係..." + pb.Value * 100 / pb.Maximum + "%"; ;
                    Application.DoEvents();

                    sID = r.sDeptmCode + r.sJobCode + "1";

                    var lsRoleWhere = lsRole.Where(p => p.Emp_id != r.sNobr && p.Dept_id == r.sDeptmCode);
                    foreach (var r1 in lsRoleWhere)
                        r1.idParent = (r1.id == sID) ? "" : sID;
                }

                //建立副職角色從屬關係
                var dtSubWorkWhere = odsBase.SubWork.Where(p => p.bSubMang == true);
                pb.Maximum += dtSubWorkWhere.Count();
                foreach (var r in dtSubWorkWhere)
                {
                    pb.Value++;
                    lblState.Text = "建立副職角色從屬關係..." + pb.Value * 100 / pb.Maximum + "%";
                    Application.DoEvents();

                    sID = r.sSubDept + r.sSubJob + "1";

                    var lsRoleWhere = lsRole.Where(p => p.Emp_id != r.sNobr && p.Dept_id == r.sSubDept);
                    foreach (var r1 in lsRoleWhere)
                        r1.idParent = (r1.id == sID) ? "" : sID;
                }

                dcFlow.Role.InsertAllOnSubmit(lsRole);

                dcSubmitChanges(dcFlow);

                //lblState.Text = "修正流程..." + pb.Value * 100 / pb.Maximum + "%";
                //Application.DoEvents();
                //FixPorcess();
            }
        }

        //修正流程
        private void FixPorcess()
        {
            object[] obj = new object[] { "" };

            //修正常態代理人的角色(指定者) 
            dcFlow.ExecuteCommand("UPDATE CheckAgentAlways SET Role_idSource = (SELECT TOP 1 id FROM Role WHERE (Emp_id = CheckAgentAlways.Emp_idSource))", obj);
            //修正常態代理人的角色(被指定者)  
            dcFlow.ExecuteCommand("UPDATE CheckAgentAlways SET Role_idTarget = ISNULL ((SELECT TOP 1 id FROM Role WHERE (Emp_id = CheckAgentAlways.Emp_idTarget)), '')", obj);
            //刪除已不存在的常態代理人工號(指定者)  
            dcFlow.ExecuteCommand("DELETE FROM CheckAgentAlways WHERE (Role_idSource IS NULL)", obj);
            //修正常態代理人的工號，當角色為空白時，工號也為空白(被指定者)  
            dcFlow.ExecuteCommand("UPDATE CheckAgentAlways SET Emp_idTarget = '' WHERE (Role_idTarget = '')", obj);
            //修正順位代理人的角色(指定者)  
            dcFlow.ExecuteCommand("UPDATE CheckAgentDefault SET Role_idSource = (SELECT TOP 1 id FROM Role WHERE (Emp_id = CheckAgentDefault.Emp_idSource))", obj);
            //修正順位代理人的角色(被指定者1)  
            dcFlow.ExecuteCommand("UPDATE CheckAgentDefault SET Role_idTarget1 = ISNULL ((SELECT TOP 1 id FROM Role WHERE (Emp_id = CheckAgentDefault.Emp_idTarget1)), '')", obj);
            //修正順位代理人的角色(被指定者2)  
            dcFlow.ExecuteCommand("UPDATE CheckAgentDefault SET Role_idTarget2 = ISNULL ((SELECT TOP 1 id FROM Role WHERE (Emp_id = CheckAgentDefault.Emp_idTarget2)), '')", obj);
            //修正順位代理人的角色(被指定者3)  
            dcFlow.ExecuteCommand("UPDATE CheckAgentDefault SET Role_idTarget3 = ISNULL ((SELECT TOP 1 id FROM Role WHERE (Emp_id = CheckAgentDefault.Emp_idTarget3)), '')", obj);
            //刪除已不存在的常態代理人工號(指定者)  
            dcFlow.ExecuteCommand("DELETE FROM CheckAgentDefault WHERE (Role_idSource IS NULL)", obj);
            //修正常態代理人的工號，當角色為空白時，工號也為空白(被指定者1)  
            dcFlow.ExecuteCommand("UPDATE CheckAgentDefault SET Emp_idTarget1 = '' WHERE (Role_idTarget1 = '')", obj);
            //修正常態代理人的工號，當角色為空白時，工號也為空白(被指定者2)  
            dcFlow.ExecuteCommand("UPDATE CheckAgentDefault SET Emp_idTarget2 = '' WHERE (Role_idTarget2 = '')", obj);
            //修正常態代理人的工號，當角色為空白時，工號也為空白(被指定者3)  
            dcFlow.ExecuteCommand("UPDATE CheckAgentDefault SET Emp_idTarget3 = '' WHERE (Role_idTarget3 = '')", obj);
            //修正工作職務代理人的角色(指定者)  
            dcFlow.ExecuteCommand("UPDATE WorkAgent SET Role_idSource = (SELECT TOP 1 id FROM Role WHERE (Emp_id = WorkAgent.Emp_idSource))", obj);
            //修正工作職務代理人的角色(被指定者)  
            dcFlow.ExecuteCommand("UPDATE WorkAgent SET Role_idTarget = ISNULL ((SELECT TOP 1 id FROM Role WHERE (Emp_id = WorkAgent.Emp_idTarget)), '')", obj);
            //刪除已不存在的工作職務代理人工號(指定者)  
            dcFlow.ExecuteCommand("DELETE FROM WorkAgent WHERE (Role_idSource IS NULL)", obj);
            //修正工作職務代理人的工號，當角色為空白時，工號也為空白(被指定者)  
            dcFlow.ExecuteCommand("UPDATE WorkAgent SET Emp_idTarget = '' WHERE (Role_idTarget = '')", obj);
            //修正節點(自訂成員)  
            dcFlow.ExecuteCommand("UPDATE NodeCustom SET Role_id = (SELECT TOP 1 id FROM Role WHERE (Emp_id = NodeCustom.Emp_id)) WHERE ((SELECT TOP 1 id FROM Role WHERE (Emp_id = NodeCustom.Emp_id)) IS NOT NULL)", obj);
            //修正節點(動態成員)  
            dcFlow.ExecuteCommand("UPDATE NodeDynamic SET fdRole = (SELECT TOP 1 id FROM Role WHERE (Emp_id = NodeDynamic.fdEmp)) WHERE ((SELECT TOP 1 id FROM Role WHERE (Emp_id = NodeDynamic.fdEmp)) IS NOT NULL)", obj);
            //修正ProcessApParm  
            dcFlow.ExecuteCommand("UPDATE ProcessApParm SET Role_id = (SELECT TOP 1 id FROM Role WHERE (Emp_id = ProcessApParm.Emp_id)) WHERE ((SELECT TOP 1 id FROM Role WHERE (Emp_id = ProcessApParm.Emp_id)) IS NOT NULL)", obj);
            //修正ProcessApView  
            dcFlow.ExecuteCommand("UPDATE ProcessApView SET Role_id = (SELECT TOP 1 id FROM Role WHERE (Emp_id = ProcessApView.Emp_id)) WHERE ((SELECT TOP 1 id FROM Role WHERE (Emp_id = ProcessApView.Emp_id)) IS NOT NULL)", obj);
            //修正ProcessCheck(Default)  
            dcFlow.ExecuteCommand("UPDATE ProcessCheck SET Role_idDefault = (SELECT TOP 1 id FROM Role WHERE (Emp_id = ProcessCheck.Emp_idDefault)) WHERE ((SELECT TOP 1 id FROM Role WHERE (Emp_id = ProcessCheck.Emp_idDefault)) IS NOT NULL)", obj);
            //修正ProcessCheck(Agent)  
            dcFlow.ExecuteCommand("UPDATE ProcessCheck SET Role_idAgent = (SELECT TOP 1 id FROM Role WHERE (Emp_id = ProcessCheck.Emp_idAgent)) WHERE ((SELECT TOP 1 id FROM Role WHERE (Emp_id = ProcessCheck.Emp_idAgent)) IS NOT NULL)", obj);
            //修正ProcessCheck(Real)  
            dcFlow.ExecuteCommand("UPDATE ProcessCheck SET Role_idReal = (SELECT TOP 1 id FROM Role WHERE (Emp_id = ProcessCheck.Emp_idReal)) WHERE ((SELECT TOP 1 id FROM Role WHERE (Emp_id = ProcessCheck.Emp_idReal)) IS NOT NULL)", obj);
            //修正ProcessFlow  
            dcFlow.ExecuteCommand("UPDATE ProcessFlow SET Role_id = (SELECT TOP 1 id FROM Role WHERE (Emp_id = ProcessFlow.Emp_id)) WHERE ((SELECT TOP 1 id FROM Role WHERE (Emp_id = ProcessFlow.Emp_id)) IS NOT NULL)", obj);
            //修正ProcessFlowShare  
            dcFlow.ExecuteCommand("UPDATE ProcessFlowShare SET Role_id = (SELECT TOP 1 id FROM Role WHERE (Emp_id = ProcessFlowShare.Emp_id)) WHERE ((SELECT TOP 1 id FROM Role WHERE (Emp_id = ProcessFlowShare.Emp_id)) IS NOT NULL)", obj);
            //刪除ProcessException  
            //dcFlow.ExecuteCommand("DELETE FROM ProcessException", obj);
            //刪除SubWork 
            //dcFlow.ExecuteCommand("DELETE FROM SubWork", obj);
        }

        private void dcSubmitChanges(dcFlowDataContext dc)
        {
            try
            {
                dc.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
            catch (System.Data.Linq.ChangeConflictException ex)
            {
                foreach (System.Data.Linq.ObjectChangeConflict occ in dc.ChangeConflicts)
                {
                    // *********************************************
                    // 底下三個範例是 3 選 1 喔，不要三行都寫在一起！
                    // **********************************************

                    // 採用資料庫的查詢出來的值，目前物件的值將會被資料庫最新查到的複寫
                    //occ.Resolve(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                    // 採用目前物件中的值，並更新資料庫中的版本
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepCurrentValues);
                    // 僅更新此物件中變更的欄位，僅將變更的欄位寫入資料庫（或稱為合併更新）
                    //occ.Resolve(System.Data.Linq.RefreshMode.KeepChanges);
                }
                // 注意：解決完衝突之後要記得重新再 SubmitChanges() 一次，否則一樣不會更新資料庫
                dc.SubmitChanges();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            pb.Visible = true;
            pb.Value = 0;
            pb.Maximum = Convert.ToInt32(lblDeptCountNew.Text) + Convert.ToInt32(lblEmpCountNew.Text) * 2 + Convert.ToInt32(lblJobCountNew.Text);
            ImportBase();
            ImportRole();

            lblState.Text = "匯入完成";
            pb.Visible = false;
            this.Enabled = true;

            CountNowValue();

            taOrgImport.Fill(odsMain.OrgImport);
            if (odsMain.OrgImport.Rows.Count > 0)
            {
                dsMain.OrgImportRow r = odsMain.OrgImport.Rows[0] as dsMain.OrgImportRow;
                r.bFullImport = ckFullImport.Checked;
                r.bSyncLoginPW = ckSyncLoginPW.Checked;
                r.sFrontLoginID = txtFrontLoginID.Text;
                r.sDeptTopCode = txtDeptTopCode.Text;
                r.bRoleTopEmpty = ckRoleTopEmpty.Checked;
                r.bLevel = checkBox1.Checked;
                taOrgImport.Update(odsMain.OrgImport);
            }

            this.Close();
        }
    }
}