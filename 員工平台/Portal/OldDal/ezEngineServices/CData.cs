using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace ezEngineServices
{
    public class CData
    {
        private dcFlowDataContext dcFlow;
        private string _ConnectionString;

        public CData()
        {
            dcFlow = new dcFlowDataContext();
            _ConnectionString = dcFlow.Connection.ConnectionString;
        }

        /// <summary>
        /// CData
        /// </summary>
        /// <param name="conn"></param>
        public CData(IDbConnection conn)
        {
            _ConnectionString = conn.ConnectionString;
            dcFlow = new dcFlowDataContext(conn);
        }

        /// <summary>
        /// CData
        /// </summary>
        /// <param name="ConnectionString"></param>
        public CData(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            dcFlow = new dcFlowDataContext(ConnectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public CData(dcFlowDataContext dcFlow)
        {
            _ConnectionString = dcFlow.Connection.ConnectionString;
            this.dcFlow = dcFlow;
        }

        /// <summary>
        /// 取得流程相關資訊
        /// </summary>
        /// <param name="lsProcessID">lsProcessID</param>
        /// <returns> List ProcessDataRow</returns>
        public List<ProcessDataRow> GetProcessData(List<int> lsProcessID)
        {
            DateTime dDateNow = DateTime.Now.Date;

            List<ProcessDataRow> Vdb = new List<ProcessDataRow>();

            var rsFlowNode = (from c in dcFlow.FlowNode
                              select c).ToList();

            var rsFlowTree = (from c in dcFlow.FlowTree
                              select c).ToList();

            var rsProcessFlowSql = from pf in dcFlow.ProcessFlow
                                   where lsProcessID.Contains(pf.id)
                                   select pf;

            var rsProcessNodeSql = from pn in dcFlow.ProcessNode
                                   where (from pf in rsProcessFlowSql where pn.ProcessFlow_id == pf.id select 1).Any()
                                   select pn;

            var rsProcessMultiFlow = (from pn in dcFlow.ProcessMultiFlow
                                      where (from pf in rsProcessFlowSql where pn.ProcessFlow_id == pf.id select 1).Any()
                                      select pn).ToList();

            var rsProcessCheckSql = from pc in dcFlow.ProcessCheck
                                    where (from pn in rsProcessNodeSql where pc.ProcessNode_auto == pn.auto select 1).Any()
                                    select pc;

            var rsProcessFlowShareSql = from pfs in dcFlow.ProcessFlowShare
                                        where (from pf in rsProcessFlowSql where pfs.ProcessFlow_id == pf.id select 1).Any()
                                        select pfs;

            var rsProcessApParm = (from pa in dcFlow.ProcessApParm
                                   where (from pf in rsProcessFlowSql where pa.ProcessFlow_id == pf.id select 1).Any()
                                   select pa).ToList();

            var rsProcessApView = (from pa in dcFlow.ProcessApView
                                   where (from pf in rsProcessFlowSql where pa.ProcessFlow_id == pf.id select 1).Any()
                                   select pa).ToList();

            var rsRole = (from r in dcFlow.Role
                          where (from pf in rsProcessFlowSql where r.Emp_id == pf.Emp_id select 1).Any()
                          select r).ToList();

            var rsForm = (from c in dcFlow.wfForm
                          select c).ToList();

            var rsFormApp = (from pa in dcFlow.wfFormApp
                             where (from pf in rsProcessFlowSql where pa.idProcess == pf.id select 1).Any()
                             select pa).ToList();

            var rsFormAppInfo = (from f in dcFlow.wfFormAppInfo
                                 where (from pf in rsProcessFlowSql where f.idProcess == pf.id select 1).Any()
                                 select f).ToList();

            var rsFormSignM = (from f in dcFlow.wfFormSignM
                               where (from pf in rsProcessFlowSql where f.idProcess == pf.id select 1).Any()
                               select f).ToList();

            var rsProcessFlow = rsProcessFlowSql.ToList();
            var rsProcessNode = rsProcessNodeSql.ToList();
            var rsProcessCheck = rsProcessCheckSql.ToList();
            var rsProcessFlowShare = rsProcessFlowShareSql.ToList();

            foreach (var rProcessFlow in rsProcessFlow)
            {
                ProcessDataRow rProcessDataRow = new ProcessDataRow();
                rProcessDataRow.idProcess = rProcessFlow.id;    //表單編號
                rProcessDataRow.ProcessNodeFormImg = FlowImages.Form;
                rProcessDataRow.ProcessNodeFlowEndImg = FlowImages.FlowEnd;

                var rFlowNode = rsFlowNode.Where(p => p.FlowTree_id == rProcessFlow.FlowTree_id && p.nodeType == "1").FirstOrDefault();
                if (rFlowNode != null)
                    rProcessDataRow.ProcessNodeFormName = rFlowNode.name;

                rFlowNode = rsFlowNode.Where(p => p.FlowTree_id == rProcessFlow.FlowTree_id && p.nodeType == "12").FirstOrDefault();
                if (rFlowNode != null)
                    rProcessDataRow.ProcessNodeFlowEndName = rFlowNode.name;

                rProcessDataRow.FlowTreeId = rProcessFlow.FlowTree_id;  //FlowTree_id
                rProcessDataRow.ProcessDate = rProcessFlow.adate.Value; //起單時間
                rProcessDataRow.ProcessRoleId = rProcessFlow.Role_id;   //起單者角色
                rProcessDataRow.ProcessEmpId = rProcessFlow.Emp_id; //起單者工號
                rProcessDataRow.ProcessFinish = rProcessFlow.isFinish.Value;    //流程是否結束

                var rEmp = (from c in dcFlow.Emp
                            where c.id == rProcessFlow.Emp_id
                            select c).FirstOrDefault();

                if (rEmp != null)
                    rProcessDataRow.ProcessEmpName = rEmp.name;

                var rFlowTree = rsFlowTree.Where(p => p.id == rProcessFlow.FlowTree_id).FirstOrDefault();
                if (rFlowTree != null)
                    rProcessDataRow.FlowTreeName = rFlowTree.name;  //表單名稱

                var rFormApp = rsFormApp.Where(p => p.idProcess == rProcessFlow.id).FirstOrDefault();
                if (rFormApp != null)
                {
                    rProcessDataRow.DateTimeA = rProcessFlow.adate.Value;// rFormApp.dDateTimeA.GetValueOrDefault(new DateTime(1900, 1, 1));
                    rProcessDataRow.DateTimeD = rFormApp.dDateTimeD.GetValueOrDefault(new DateTime(1900, 1, 1));
                    rProcessDataRow.FlowAppName = rFormApp.sFormName;   //表單自訂名稱 
                }

                var rsProcessNodeWhere = rsProcessNode.Where(p => p.ProcessFlow_id == rProcessFlow.id).ToList();
                if (rsProcessNodeWhere.Count > 0)
                {
                    rProcessDataRow.lsProcessSignRow = new List<ProcessSignRow>();

                    //展開各階簽核狀況
                    rsProcessNodeWhere = rsProcessNode.Where(p => p.ProcessFlow_id == rProcessFlow.id).OrderBy(p => p.adate.Value).ToList();
                    foreach (var rProcessNode in rsProcessNodeWhere)
                    {
                        var rProcessSignRow = new ProcessSignRow();
                        rProcessSignRow.ProcessNodeId = rProcessNode.FlowNode_id;

                        rFlowNode = rsFlowNode.Where(p => p.id == rProcessNode.FlowNode_id).FirstOrDefault();
                        if (rFlowNode != null)
                        {
                            rProcessSignRow.ProcessNodeName = rFlowNode.name;
                            rProcessSignRow.ProcessNodeType = rFlowNode.nodeType;

                            switch (rFlowNode.nodeType)
                            {
                                case "3":
                                    rProcessSignRow.ProcessNodeImg = FlowImages.Mang;
                                    break;
                                case "4":
                                    rProcessSignRow.ProcessNodeImg = FlowImages.FlowInit;
                                    break;
                                case "5":
                                    rProcessSignRow.ProcessNodeImg = FlowImages.MultiStart;
                                    break;
                                case "6":
                                    rProcessSignRow.ProcessNodeImg = FlowImages.Custom;
                                    break;
                                case "7":
                                    rProcessSignRow.ProcessNodeImg = FlowImages.Dynamic;
                                    break;
                                case "8":
                                    rProcessSignRow.ProcessNodeImg = FlowImages.AgentInit;
                                    break;
                                case "9":
                                    rProcessSignRow.ProcessNodeImg = FlowImages.MultiFlow;
                                    break;
                            }
                        }

                        rProcessSignRow.ProcessNodeDate = rProcessNode.adate.Value;
                        rProcessSignRow.ProcessNodeFinish = rProcessNode.isFinish.Value;
                        rProcessSignRow.ProcessNodeMulti = rProcessNode.isMulti.Value;

                        rProcessDataRow.ProcessNodeAuto = rProcessNode.auto;    //ProcessNode.auto

                        //計算閒置幾天
                        rProcessDataRow.PendingDay = 0;
                        if (!rProcessNode.isFinish.Value)
                        {
                            TimeSpan ts = dDateNow - rProcessNode.adate.Value.Date;
                            rProcessDataRow.PendingDay = Convert.ToInt32(ts.TotalDays);
                        }

                        var rProcessCheck = rsProcessCheck.Where(p => p.ProcessNode_auto == rProcessNode.auto).FirstOrDefault();
                        if (rProcessCheck != null)
                        {
                            rProcessSignRow.ProcessCheckDate = rProcessCheck.adate.Value;
                            rProcessSignRow.Emp_idDefault = rProcessCheck.Emp_idDefault;
                            rProcessSignRow.Emp_idAgent = rProcessCheck.Emp_idAgent;
                            rProcessSignRow.Emp_idReal = rProcessCheck.Emp_idReal;

                            rProcessDataRow.ProcessCheckAuto = rProcessCheck.auto;   //ProcessCheck.auto;

                            rProcessDataRow.Emp_idDefault = rProcessCheck.Emp_idDefault;
                            rProcessDataRow.Emp_idAgent = rProcessCheck.Emp_idAgent;
                            rProcessDataRow.Emp_idReal = rProcessCheck.Emp_idReal;

                            rEmp = (from c in dcFlow.Emp
                                    where c.id == rProcessCheck.Emp_idDefault
                                    select c).FirstOrDefault();

                            if (rEmp != null)
                            {
                                rProcessSignRow.Emp_NameDefault = rEmp.name;
                                rProcessDataRow.Emp_NameDefault = rEmp.name;
                            }

                            rEmp = (from c in dcFlow.Emp
                                    where c.id == rProcessCheck.Emp_idAgent
                                    select c).FirstOrDefault();

                            if (rEmp != null)
                            {
                                rProcessSignRow.Emp_NameAgent = rEmp.name;
                                rProcessDataRow.Emp_NameAgent = rEmp.name;
                            }

                            rEmp = (from c in dcFlow.Emp
                                    where c.id == rProcessCheck.Emp_idReal
                                    select c).FirstOrDefault();

                            if (rEmp != null)
                            {
                                rProcessSignRow.Emp_NameReal = rEmp.name;
                                rProcessDataRow.Emp_NameReal = rEmp.name;
                            }

                            var rProcessApParm = (from p in rsProcessApParm
                                                  where p.ProcessFlow_id == rProcessFlow.id
                                                  && p.ProcessNode_auto == rProcessNode.auto
                                                  && p.ProcessCheck_auto == rProcessCheck.auto
                                                  select p).FirstOrDefault();

                            if (rProcessApParm != null)
                                rProcessDataRow.ProcessApParmAuto = rProcessApParm.auto;    //ProcessApParm.auto
                        }

                        //如果有子流程 再向下展開
                        List<int> lsProcessIDs = new List<int>();
                        var rsProcessMultiFlowWhere = rsProcessMultiFlow.Where(p => p.ProcessFlow_id == rProcessFlow.id).ToList();
                        foreach (var rProcessMultiFlowWhere in rsProcessMultiFlowWhere)
                            if (rProcessMultiFlowWhere.SubProcessFlow_id != null)
                                lsProcessIDs.Add(rProcessMultiFlowWhere.SubProcessFlow_id.Value);

                        if (lsProcessIDs.Count > 0)
                            rProcessSignRow.lsProcessDataRow = GetProcessData(lsProcessIDs);

                        rProcessDataRow.lsProcessSignRow.Add(rProcessSignRow);
                    } //end foreach
                }

                var rProcessApView = rsProcessApView.Where(p => p.ProcessFlow_id == rProcessFlow.id).FirstOrDefault();
                if (rProcessApView != null)
                    rProcessDataRow.ProcessApViewAuto = rProcessApView.auto;    //ProcessApView.auto

                Vdb.Add(rProcessDataRow);
            }

            //List<string> lsEmp = new List<string>();
            //lsEmp = lsEmp.Union(Vdb.Select(p => p.Emp_idDefault)).Union(Vdb.Select(p => p.Emp_idAgent)).Union(Vdb.Select(p => p.Emp_idReal)).ToList();

            //var rsEmp = (from c in dcFlow.Emp
            //             where lsEmp.Contains(c.id)
            //             select c).ToList();

            //foreach (var rVdb in Vdb)
            //{
            //    var rEmp = rsEmp.Where(p => p.id == rVdb.Emp_idDefault).FirstOrDefault();
            //    if (rEmp != null)
            //        rVdb.Emp_NameDefault = rEmp.name;

            //    rEmp = rsEmp.Where(p => p.id == rVdb.Emp_idAgent).FirstOrDefault();
            //    if (rEmp != null)
            //        rVdb.Emp_NameAgent = rEmp.name;

            //    rEmp = rsEmp.Where(p => p.id == rVdb.Emp_idReal).FirstOrDefault();
            //    if (rEmp != null)
            //        rVdb.Emp_NameReal = rEmp.name;
            //}

            return Vdb;
        }

        /// <summary>
        /// 取得可申請表單
        /// </summary>
        /// <param name="sNobr">申請人工號</param>
        /// <param name="sDeptm">部門</param>
        /// <returns>List FlowTreeData</returns>
        public List<FlowTreeDataRow> GetFlowTreeData(string sNobr, string sDeptm = "")
        {
            var rsFlowTree = (from t in dcFlow.FlowTree
                              where t.dateB.Value.Date <= DateTime.Now.Date
                              && DateTime.Now.Date <= t.dateE.Value.Date
                              && t.isVisible.Value
                              && t.Sort != null && t.Sort.Value > 0
                              orderby t.Sort, t.FlowGroup_id, t.dateB.Value.Date
                              select t).ToList();

            var rsFlowTreePower = (from t in dcFlow.FlowTreePower
                                   select t).ToList();

            var rsFlowTreePowerRoleOnly = (from t in dcFlow.FlowTreePowerRoleOnly
                                           select t).ToList();

            var rsFlowNode = (from n in dcFlow.FlowNode
                              join ns in dcFlow.NodeStart on n.id equals ns.FlowNode_id into nns
                              from nnsRow in nns.DefaultIfEmpty()
                              join nf in dcFlow.NodeForm on n.id equals nf.FlowNode_id into nnf
                              from nnfRow in nnf.DefaultIfEmpty()
                              where n.nodeType == "1"
                              || n.nodeType == "2"
                              select new
                              {
                                  n.id,
                                  n.nodeType,
                                  n.FlowTree_id,
                                  virtualPath = nnsRow != null ? nnsRow.virtualPath : string.Empty,
                                  apName = nnfRow != null ? nnfRow.apName : string.Empty,
                              }).ToList();

            //用工號取出角色
            var rsRole = (from r in dcFlow.Role
                          join d in dcFlow.Dept
                          on r.Dept_id equals d.id
                          join p in dcFlow.Pos
                          on r.Pos_id equals p.id
                          join e in dcFlow.Emp
                          on r.Emp_id equals e.id
                          where r.Emp_id == sNobr
                          && (r.Dept_id == sDeptm || sDeptm == "")
                          && (r.sort.GetValueOrDefault(1) == 1)
                          select new
                          {
                              RoleID = r.id,
                              DeptID = d.id,
                              DeptName = d.name,
                              DeptPath = d.path,
                              PosID = p.id,
                              PosName = p.name,
                              Manage = r.deptMg.Value,
                          }).ToList();

            List<FlowTreeDataRow> lsFlowTreeData = new List<FlowTreeDataRow>();

            foreach (var rRole in rsRole)
            {
                List<string> lsFlowTreeID = new List<string>();

                //取得表單的權限(依照部門)
                lsFlowTreeID.AddRange(rsFlowTreePower.Where(p =>
                    (p.isAllSub.Value && rRole.DeptPath.IndexOf(p.Dept_path) >= 0)
                    || (!p.isAllSub.Value && rRole.DeptPath == p.Dept_path)
                    ).Select(p => p.FlowTree_id));

                //取得表單的權限(依照角色)
                lsFlowTreeID.AddRange(rsFlowTreePowerRoleOnly.Where(p =>
                    p.Role_id == rRole.RoleID
                    ).Select(p => p.FlowTree_id));

                var rsFlowTreeWhere = rsFlowTree.Where(p => lsFlowTreeID.Contains(p.id)).ToList();

                foreach (var rFlowTree in rsFlowTreeWhere)
                {
                    //沒有流程開始的節點就立刻出去
                    var rFlowNodeStart = rsFlowNode.Where(p => p.FlowTree_id == rFlowTree.id && p.nodeType == "1" && p.virtualPath.Trim().Length > 0).FirstOrDefault();
                    if (rFlowNodeStart == null) continue;

                    //沒有填寫表單的節點就立刻出去
                    var rFlowNodeForm = rsFlowNode.Where(p => p.FlowTree_id == rFlowTree.id && p.nodeType == "2" && p.apName.Trim().Length > 0).FirstOrDefault();
                    if (rFlowNodeForm == null) continue;

                    //相同的表單不要再寫一次
                    if (!lsFlowTreeData.Where(p => p.FlowTreeId == rFlowTree.id).Any())
                    {
                        FlowTreeDataRow rFlowTreeData = new FlowTreeDataRow();
                        rFlowTreeData.FlowTreeId = rFlowTree.id;
                        rFlowTreeData.FlowTreeName = rFlowTree.name;
                        rFlowTreeData.RoleId = rRole.RoleID;
                        rFlowTreeData.DeptId = rRole.DeptID;
                        rFlowTreeData.PosId = rRole.PosID;
                        rFlowTreeData.Manage = rRole.Manage;
                        rFlowTreeData.Url = rFlowNodeStart.virtualPath + "/" + rFlowNodeForm.apName;
                        rFlowTreeData.Parm = "idFlowTree=" + rFlowTree.id + "&idRole_Start=" + rRole.RoleID + "&idEmp_Start=" + sNobr + "&idRole_Agent=&idEmp_Agent=";
                        rFlowTreeData.ViewUrl = rFlowTreeData.Url + "?" + rFlowTreeData.Parm;
                        rFlowTreeData.ViewImage = CImage.ImageToBuffer(FlowImages.FormView, System.Drawing.Imaging.ImageFormat.Jpeg);
                        rFlowTreeData.Sort = rFlowTree.Sort == null ? 99 : rFlowTree.Sort.Value;
                        lsFlowTreeData.Add(rFlowTreeData);
                    }
                }
            }

            lsFlowTreeData = lsFlowTreeData.OrderBy(p => p.Sort).ToList();

            return lsFlowTreeData;
        }

        /// <summary>
        /// 取得目前待審核的表單
        /// </summary>
        /// <param name="sNobr">審核者工號</param>
        /// <param name="sAppNobr">申請者工號</param>
        /// <returns>List</returns>
        public List<FlowSignRow> GetFlowSign(string sNobr = "", string sAppNobr = "")
        {
            var ProcessSql = from pc in dcFlow.ProcessCheck
                             join pn in dcFlow.ProcessNode on pc.ProcessNode_auto equals pn.auto
                             join pf in dcFlow.ProcessFlow on pn.ProcessFlow_id equals pf.id
                             join fn in dcFlow.FlowNode on pn.FlowNode_id equals fn.id
                             join ft in dcFlow.FlowTree on pf.FlowTree_id equals ft.id
                             join e1 in dcFlow.Emp on pc.Emp_idDefault equals e1.id into pc1
                             from pc1Row in pc1.DefaultIfEmpty()
                             join e2 in dcFlow.Emp on pc.Emp_idAgent equals e2.id into pc2
                             from pc2Row in pc2.DefaultIfEmpty()
                             join e3 in dcFlow.Emp on pf.Emp_id equals e3.id into pf1
                             from pf1Row in pf1.DefaultIfEmpty()
                             join r1 in dcFlow.Role on new { EmpId = pf.Emp_id, RoleId = pf.Role_id } equals new { EmpId = r1.Emp_id, RoleId = r1.id } into pf2
                             from pf2Row in pf2.DefaultIfEmpty()
                             join d1 in dcFlow.Dept on pf2Row.Dept_id equals d1.id into pf21
                             from pf21Row in pf21.DefaultIfEmpty()
                             join w in dcFlow.wfForm on pf.FlowTree_id equals w.sFlowTree into pf3
                             from pf3Row in pf3.DefaultIfEmpty()
                             where !pf.isFinish.Value
                             && !pf.isCancel.Value
                             && !pf.isError.Value
                             && !pn.isFinish.Value
                             && ((pc.Emp_idDefault == sNobr || pc.Emp_idAgent == sNobr) || sNobr == "")
                             && (pf.Emp_id == sAppNobr || sAppNobr == "")
                             orderby pn.adate.Value
                             select new FlowSignRow()
                             {
                                 ApParmID = 0,
                                 ParmUrl = "",
                                 ProcessID = pf.id,
                                 ProcessCheckAuto = pc.auto,
                                 ProcessNodeAuto = pn.auto,
                                 AppEmpId = pf.Emp_id,
                                 AppRoleId = pf.Role_id,
                                 AppName = pf1Row != null ? pf1Row.name : "",
                                 AppDept = pf21Row != null ? pf21Row.name : "",
                                 //AppDeptPath = pf21Row != null ? pf21Row.path : "",
                                 AppDate = pf.adate.Value,
                                 FlowTreeId = ft.id,
                                 FlowTreeName = ft.name,
                                 FlowNodeId = fn.id,
                                 FlowNodeName = fn.name,
                                 NodeType = fn.nodeType,
                                 CheckName = pc1Row != null ? pc1Row.name : "",
                                 AgentName = pc2Row != null ? pc2Row.name : "",
                                 PendingDay = Convert.ToInt32((DateTime.Now.Date - pn.adate.Value.Date).TotalDays),
                                 Batch = pf3Row != null ? pf3Row.b1.GetValueOrDefault(true) : true,
                             };

            //填入表單資訊
            var rsFormApp = (from c in dcFlow.wfFormApp
                             where (from b in ProcessSql where c.idProcess == b.ProcessID select 1).Any()
                             select new
                             {
                                 c.idProcess,
                                 c.sReserve4,
                                 c.sJsonInfo,
                                 c.sInfo,
                             }).ToList();

            var rsProcessApParm = (from c in dcFlow.ProcessApParm
                                   where (from b in ProcessSql
                                          where c.ProcessFlow_id == b.ProcessID
                                          && c.ProcessCheck_auto == b.ProcessCheckAuto
                                          && c.ProcessNode_auto == b.ProcessNodeAuto
                                          select 1).Any()
                                   select new
                                   {
                                       c.auto,
                                       c.ProcessFlow_id,
                                       c.ProcessCheck_auto,
                                       c.ProcessNode_auto,
                                   }).ToList();

            var Vdb = ProcessSql.ToList();

            var lsFlowTreeId = Vdb.Select(p => p.FlowTreeId).Distinct().ToList();
            var rsFlowTreePath = GetFlowTreePath(lsFlowTreeId);

            var lsFlowNodeId = Vdb.Select(p => p.FlowNodeId).Distinct().ToList();
            var rsFlowNodeAppName = GetFlowNodeAppName(lsFlowNodeId);

            foreach (var rVdb in Vdb)
            {
                //表單資訊
                var rFormApp = rsFormApp.Where(p => p.idProcess == rVdb.ProcessID).FirstOrDefault();
                if (rFormApp != null)
                    rVdb.Info = rFormApp.sInfo;

                //目錄位置
                string Path = "";
                var rFlowTreePath = rsFlowTreePath.Where(p => p.FlowTreeId == rVdb.FlowTreeId).FirstOrDefault();
                if (rFlowTreePath != null)
                    Path = rFlowTreePath.FlowTreePath;

                //檔案名稱
                string ApName = "";
                var rFlowNodeAppName = rsFlowNodeAppName.Where(p => p.FlowNodeId == rVdb.FlowNodeId).FirstOrDefault();
                if (rFlowNodeAppName != null)
                    ApName = rFlowNodeAppName.ApName;

                //ApParmID
                int ApParmId = 0;
                var rProcessApParm = (from c in rsProcessApParm
                                      where c.ProcessFlow_id == rVdb.ProcessID
                                      && c.ProcessCheck_auto == rVdb.ProcessCheckAuto
                                      && c.ProcessNode_auto == rVdb.ProcessNodeAuto
                                      select c).FirstOrDefault();

                if (rProcessApParm != null)
                {
                    ApParmId = rProcessApParm.auto;
                    rVdb.ApParmID = ApParmId;

                    rVdb.ParmUrl = Path + "/" + ApName + "?ApParm=" + ApParmId.ToString();
                }
            }

            return Vdb;
        }

        /// <summary>
        /// 流程檢視
        /// </summary>
        /// <param name="bManage">是否主管</param>
        /// <param name="sNobr">管理者或被查詢者工號</param>
        /// <param name="dDateSignB">簽核開始日期</param>
        /// <param name="dDateSignE">簽核結束日期</param>
        /// <param name="dDateAppB">申請開始日期</param>
        /// <param name="dDateAppE">申請結束日期</param>
        /// <param name="sState">狀態</param>
        /// <param name="sFormCode">查詢表單代碼</param>
        /// <param name="iProcessID">流程序號</param>
        /// <param name="sApp">查詢角色</param>
        /// <returns>List FlowViewRow</returns>
        public List<FlowViewRow> GetFlowView(bool bManage = false, string sNobr = ""
            , DateTime? dDateSignB = null, DateTime? dDateSignE = null
            , DateTime? dDateAppB = null, DateTime? dDateAppE = null
            , string sState = "1", string sFormCode = "0"
            , int iProcessID = 0, string sApp = "1")
        {
            DateTime dDate = DateTime.Now.Date;

            var arrForm = (from c in dcFlow.wfForm
                           where c.iSort > 0
                           orderby c.iSort
                           select c.sFormCode).ToList();

            List<FlowViewRow> Vdb = new List<FlowViewRow>();

            //管理者可以看全部
            if (bManage)
            {
                //審核者
                var rsProcessNode = (from pn in dcFlow.ProcessNode
                                     join pc in dcFlow.ProcessCheck on pn.auto equals pc.ProcessNode_auto
                                     where (sNobr == "" || pc.Emp_idDefault == sNobr || pc.Emp_idAgent == sNobr || pc.Emp_idReal == sNobr)
                                     && dDateSignB <= pc.adate.GetValueOrDefault(dDate)
                                     && pc.adate.GetValueOrDefault(dDate) <= dDateSignE
                                     orderby pc.adate.Value descending
                                     select pn.ProcessFlow_id).ToList().Take(200);

                //被申請人
                var rsFormAppInfo = (from s in dcFlow.wfFormAppInfo
                                     where (sNobr == "" || s.sNobr == sNobr)
                                     && dDateAppB <= s.dKeyDate.GetValueOrDefault(dDate)
                                     && s.dKeyDate.GetValueOrDefault(dDate) <= dDateAppE
                                     && s.sState == sState
                                     orderby s.idProcess descending
                                     select s.idProcess).ToList().Take(200);

                //申請人
                Vdb = (from m in dcFlow.wfFormApp
                       join pf in dcFlow.ProcessFlow on m.idProcess equals pf.id
                       join f in dcFlow.wfForm on pf.FlowTree_id equals f.sFlowTree
                       where ((sFormCode == "0" && arrForm.Contains(m.sFormCode)) || m.sFormCode == sFormCode)
                       && (iProcessID == 0 || m.idProcess == iProcessID)
                       && (sApp == "1"
                       ? ((sNobr == "" || m.sNobr == sNobr)
                       && dDateAppB <= m.dDateTimeA.GetValueOrDefault(dDate)
                       && m.dDateTimeA.GetValueOrDefault(dDate) <= dDateAppE
                       && m.sState == sState)
                       : (sApp == "2"
                       ? rsFormAppInfo.Contains(m.idProcess)
                       : rsProcessNode.Contains(m.idProcess)))
                       orderby m.idProcess descending
                       select new FlowViewRow
                       {
                           ProcessID = m.idProcess,
                           FormName = f.sFormName,
                           Info = m.sInfo,
                           Nobr = m.sNobr,
                           Name = m.sName,
                           DeptName = m.sDeptName,
                           PendingDay = 0,// (p.PendingDay > 0 ? p.PendingDay : 0),
                           ManageName = "",//p.ManageName,
                           AgentManageName = "",// p.AgentManageName,
                           RealManageName = "",
                           SignDate = new DateTime(1900, 1, 1).Date,
                       }).ToList();
            }
            else
            {
                //審核者
                var rsProcessNode = (from pn in dcFlow.ProcessNode
                                    join pc in dcFlow.ProcessCheck on pn.auto equals pc.ProcessNode_auto
                                    where (pc.Emp_idDefault == sNobr || pc.Emp_idAgent == sNobr || pc.Emp_idReal == sNobr)
                                    && dDateSignB <= pc.adate.GetValueOrDefault(dDate)
                                    && pc.adate.GetValueOrDefault(dDate) <= dDateSignE
                                     orderby pc.adate.Value descending
                                    select pn.ProcessFlow_id).ToList().Take(200);

                //被申請人
                var rsFormAppInfo = (from s in dcFlow.wfFormAppInfo
                                    where (s.sNobr == sNobr)
                                    && dDateAppB <= s.dKeyDate.GetValueOrDefault(dDate)
                                    && s.dKeyDate.GetValueOrDefault(dDate) <= dDateAppE
                                    && s.sState == sState
                                    orderby s.idProcess descending
                                    select s.idProcess).ToList().Take(200);

                //申請人
                //只有申請者的角度可以套用狀態
                Vdb = (from m in dcFlow.wfFormApp
                       join pf in dcFlow.ProcessFlow on m.idProcess equals pf.id
                       join f in dcFlow.wfForm on pf.FlowTree_id equals f.sFlowTree
                       where ((sFormCode == "0" && arrForm.Contains(m.sFormCode)) || m.sFormCode == sFormCode)
                       && (iProcessID == 0 || m.idProcess == iProcessID)
                       && (sApp == "1"
                       ? ((m.sNobr == sNobr)
                       && dDateAppB <= m.dDateTimeA.GetValueOrDefault(dDate)
                       && m.dDateTimeA.GetValueOrDefault(dDate) <= dDateAppE
                       && m.sState == sState)
                       : (sApp == "2"
                       ? rsFormAppInfo.Contains(m.idProcess)
                       : rsProcessNode.Contains(m.idProcess)))
                       orderby m.idProcess descending
                       select new FlowViewRow
                       {
                           ProcessID = m.idProcess,
                           FormName = f.sFormName,
                           Info = m.sInfo,
                           Nobr = m.sNobr,
                           Name = m.sName,
                           DeptName = m.sDeptName,
                           PendingDay = 0,// (p.PendingDay > 0 ? p.PendingDay : 0),
                           ManageName = "",//p.ManageName,
                           AgentManageName = "",// p.AgentManageName,
                           RealManageName = "",
                           SignDate = new DateTime(1900, 1, 1).Date,
                       }).ToList();
            }

            return Vdb;
        }

        /// <summary>
        /// 取得簽核代理人資訊
        /// </summary>
        /// <param name="EmpId">被代理人工號</param>
        /// <returns>List CheckAgentDataRow </returns>
        public List<CheckAgentDataRow> GetCheckAgentData(string EmpId)
        {
            DateTime dDate = DateTime.Now.Date;

            var rsCheckAgent = (from ca in dcFlow.CheckAgent
                                where ca.Emp_idSource == EmpId
                                select ca).ToList();

            var lsGuid = rsCheckAgent.Select(p => p.Guid).ToList();

            var rsForm = (from c in dcFlow.CheckAgentFlowTree
                          join d in dcFlow.wfForm on c.FlowTree_id equals d.sFlowTree
                          where lsGuid.Contains(c.CheckAgent_Guid)
                          orderby d.iSort
                          select new
                          {
                              Guid = c.CheckAgent_Guid,
                              FormName = d.sFormName,
                          }).ToList();

            var lsRole = rsCheckAgent.Select(p => p.Role_idSource).ToList();
            lsRole = lsRole.Union(rsCheckAgent.Select(p => p.Role_idTarget).ToList()).ToList();

            var rsRole = (from c in dcFlow.Role
                          where lsRole.Contains(c.id)
                          && c.dateB.Value.Date <= dDate && dDate <= c.dateE.Value.Date
                          select c).ToList();

            var lsDept = rsRole.Select(p => p.Dept_id).ToList();
            var lsPos = rsRole.Select(p => p.Pos_id).ToList();
            var lsEmp = rsRole.Select(p => p.Emp_id).ToList();

            var rsDept = (from c in dcFlow.Dept
                          where lsDept.Contains(c.id)
                          select c).ToList();

            var rsPos = (from c in dcFlow.Pos
                         where lsPos.Contains(c.id)
                         select c).ToList();

            var rsEmp = (from c in dcFlow.Emp
                         where lsEmp.Contains(c.id)
                         select c).ToList();

            List<CheckAgentDataRow> Vdb = new List<CheckAgentDataRow>();

            foreach (var rCheckAgent in rsCheckAgent)
            {
                CheckAgentDataRow r = new CheckAgentDataRow();

                r.Guid = rCheckAgent.Guid;
                r.Dept_nameSource = "";
                r.Pos_nameSource = "";
                r.Emp_idTarget = rCheckAgent.Emp_idTarget;
                r.Emp_nameTarget = "";
                r.Dept_nameTarget = "";
                r.Pos_nameTarget = "";
                r.Form = "";
                r.Sort = rCheckAgent.Sort.Value;
                r.KeyMan = rCheckAgent.KeyMan;
                r.KeyDate = rCheckAgent.KeyDate.Value;

                var rRole = rsRole.Where(p => p.id == rCheckAgent.Role_idSource && p.Emp_id == rCheckAgent.Emp_idSource).FirstOrDefault();
                if (rRole != null)
                {
                    var rDept = rsDept.Where(p => p.id == rRole.Dept_id).FirstOrDefault();
                    if (rDept != null)
                        r.Dept_nameSource = rDept.name;

                    var rPos = rsPos.Where(p => p.id == rRole.Pos_id).FirstOrDefault();
                    if (rPos != null)
                        r.Pos_nameSource = rPos.name;
                }

                rRole = rsRole.Where(p => p.id == rCheckAgent.Role_idTarget && p.Emp_id == rCheckAgent.Emp_idTarget).FirstOrDefault();
                if (rRole != null)
                {
                    var rDept = rsDept.Where(p => p.id == rRole.Dept_id).FirstOrDefault();
                    if (rDept != null)
                        r.Dept_nameTarget = rDept.name;

                    var rPos = rsPos.Where(p => p.id == rRole.Pos_id).FirstOrDefault();
                    if (rPos != null)
                        r.Pos_nameTarget = rPos.name;

                    var rEmp = rsEmp.Where(p => p.id == rRole.Emp_id).FirstOrDefault();
                    if (rEmp != null)
                        r.Emp_nameTarget = rEmp.name;
                }

                var rsFormWhere = rsForm.Where(p => p.Guid == rCheckAgent.Guid).ToList();
                foreach (var rCheckAgentFlowTree in rsFormWhere)
                    r.Form += rCheckAgentFlowTree.FormName + "<BR>";

                r.Form = r.Form.Length == 0 ? "全部" : r.Form;

                Vdb.Add(r);
            }

            return Vdb;
        }

        /// <summary>
        /// 取得可代理表單
        /// </summary>
        /// <param name="CheckAgent_Guid">CheckAgent_Guid</param>
        /// <returns>List CheckAgentFlowTreeDataRow</returns>
        public List<CheckAgentFlowTreeDataRow> GetCheckAgentFlowTreeData(string CheckAgent_Guid)
        {
            var Vdb = (from c in dcFlow.CheckAgentFlowTree
                       join f in dcFlow.FlowTree on c.FlowTree_id equals f.id
                       where c.CheckAgent_Guid == CheckAgent_Guid
                       orderby f.id
                       select new CheckAgentFlowTreeDataRow
                       {
                           auto = c.auto,
                           FlowTree_id = c.FlowTree_id,
                           FormName = f.name,
                           KeyMan = c.KeyMan,
                           KeyDate = c.KeyDate.Value,
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 代理日期
        /// </summary>
        /// <param name="EmpId">工號</param>
        /// <returns>List EmpAgentDateDataRow</returns>
        public List<EmpAgentDateDataRow> GetEmpAgentDateData(string EmpId)
        {
            var Vdb = (from c in dcFlow.EmpAgentDate
                       where c.Emp_id == EmpId
                       && c.IsValid
                       select new EmpAgentDateDataRow
                       {
                           auto = c.auto,
                           dateB = c.dateB,
                           dateE = c.dateE,
                           KeyMan = c.KeyMan,
                           KeyDate = c.KeyDate.Value,
                       }).ToList();

            return Vdb;
        }



        /// <summary>
        /// 取得目前正在進行中的流程
        /// </summary>
        /// <param name="sNobr">查詢者工號</param>
        /// <returns>List</returns>
        public List<FlowSearchIngRow> GetFlowSearchIng(string sNobr)
        {
            var ProcessSql = from pf in dcFlow.ProcessFlow
                             join pn in dcFlow.ProcessNode on pf.id equals pn.ProcessFlow_id
                             join pc in dcFlow.ProcessCheck on pn.auto equals pc.ProcessNode_auto
                             join pa in dcFlow.ProcessApView on pf.id equals pa.ProcessFlow_id
                             join ft in dcFlow.FlowTree on pf.FlowTree_id equals ft.id
                             join fn in dcFlow.FlowNode on pn.FlowNode_id equals fn.id
                             join pfs in dcFlow.ProcessFlowShare on pf.id equals pfs.ProcessFlow_id
                             join e1 in dcFlow.Emp on pc.Emp_idAgent equals e1.id into pc1
                             from pc1Row in pc1.DefaultIfEmpty()
                             join e2 in dcFlow.Emp on pc.Emp_idDefault equals e2.id into pc2
                             from pc2Row in pc2.DefaultIfEmpty()
                             where !pf.isFinish.Value
                             && !pf.isCancel.Value
                             && !pf.isError.Value
                             && !pn.isFinish.Value
                             && pfs.Emp_id == sNobr
                             orderby pf.adate.Value
                             select new FlowSearchIngRow()
                             {
                                 ApViewID = pa.auto,
                                 ProcessID = pf.id,
                                 FormName = ft.name,
                                 FlowNodeName = fn.name,
                                 AppDate = pf.adate.Value,
                                 SignDate = pn.adate.Value,
                                 SignName = pc2Row != null ? pc2Row.name : "",
                                 AgentName = pc1Row != null ? pc1Row.name : "",
                                 FlowTreeId = ft.id,
                             };

            var Vdb = ProcessSql.ToList();

            var lsFlowTreeId = Vdb.Select(p => p.FlowTreeId).Distinct().ToList();
            var rsFlowTreePath = GetFlowTreePath(lsFlowTreeId);

            foreach (var rVdb in Vdb)
            {
                var rFlowTreePath = rsFlowTreePath.Where(p => p.FlowTreeId == rVdb.FlowTreeId).FirstOrDefault();
                if (rFlowTreePath != null)
                    rVdb.ViewUrl = rFlowTreePath.FlowTreePath + "/" + rFlowTreePath.ViewApName + "?ApView=" + rVdb.ApViewID.ToString();
            }

            return Vdb;
        }

        /// <summary>
        /// 取得目前完成的流程
        /// </summary>
        /// <param name="sNobr">查詢者工號</param>
        /// <param name="dAppB">查詢開始日期</param>
        /// <param name="dAppE">查詢結束日期</param>
        /// <returns>List</returns>
        public List<FlowSearchCompleteRow> GetFlowSearchComplete(string sNobr, DateTime dAppB, DateTime dAppE)
        {
            var Vdb = (from pf in dcFlow.ProcessFlow
                       join pav in dcFlow.ProcessApView on pf.id equals pav.ProcessFlow_id.Value
                       join ft in dcFlow.FlowTree on pf.FlowTree_id equals ft.id
                       where pf.isFinish.Value
                       && !pf.isCancel.Value
                       && !pf.isError.Value
                       && pf.Emp_id == sNobr
                       && dAppB.Date <= pf.adate.Value.Date
                       && pf.adate.Value.Date <= dAppE.Date
                       select new FlowSearchCompleteRow()
                       {
                           ApViewID = pav.auto,
                           ProcessID = pf.id,
                           FormName = ft.name,
                           AppDate = pf.adate.Value,
                           FlowTreeId = pf.FlowTree_id,
                       }).ToList();

            var lsFlowTreeId = Vdb.Select(p => p.FlowTreeId).Distinct().ToList();
            var rsFlowTreePath = GetFlowTreePath(lsFlowTreeId);

            foreach (var rVdb in Vdb)
            {
                var rFlowTreePath = rsFlowTreePath.Where(p => p.FlowTreeId == rVdb.FlowTreeId).FirstOrDefault();
                if (rFlowTreePath != null)
                    rVdb.ViewUrl = rFlowTreePath.FlowTreePath + "/" + rFlowTreePath.ViewApName + "?ApView=" + rVdb.ApViewID.ToString();
            }

            return Vdb;
        }

        /// <summary>
        /// 取得流程目錄位置
        /// </summary>
        /// <param name="lsFlowTreeId">lsFlowTreeId</param>
        /// <returns>List FlowTreePathRow</returns>
        public List<FlowTreePathRow> GetFlowTreePath(List<string> lsFlowTreeId = null)
        {
            var Vdb = (from fn in dcFlow.FlowNode
                       join ns in dcFlow.NodeStart on fn.id equals ns.FlowNode_id
                       where fn.nodeType == "1"
                       && (lsFlowTreeId == null
                       || (lsFlowTreeId != null && lsFlowTreeId.Contains(fn.FlowTree_id)))
                       select new FlowTreePathRow
                       {
                           FlowTreeId = fn.FlowTree_id,
                           FlowTreePath = ns.virtualPath,
                           ViewApName = ns.viewAp,
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得程式檔案名稱
        /// </summary>
        /// <param name="lsFlowNodeId">lsFlowNodeId</param>
        /// <returns>List FlowNodeApNameRow</returns>
        public List<FlowNodeApNameRow> GetFlowNodeAppName(List<string> lsFlowNodeId)
        {
            var Vdb = new List<FlowNodeApNameRow>();

            var rsFlowNode = (from c in dcFlow.FlowNode
                              where lsFlowNodeId.Contains(c.id)
                              select c).ToList();

            foreach (var rFlowNode in rsFlowNode)
            {
                string apName = "";

                switch (rFlowNode.nodeType)
                {
                    case "3": //主管審核
                        var rNodeMang = (from c in dcFlow.NodeMang
                                         where c.FlowNode_id == rFlowNode.id
                                         select c).FirstOrDefault();

                        if (rNodeMang != null)
                            apName = rNodeMang.apName;
                        break;
                    case "4": //流程起始者
                        var rNodeInit = (from c in dcFlow.NodeInit
                                         where c.FlowNode_id == rFlowNode.id
                                         select c).FirstOrDefault();

                        if (rNodeInit != null)
                            apName = rNodeInit.apName;
                        break;
                    case "5": //會簽起始者
                        var rNodeMultiInit = (from c in dcFlow.NodeMultiInit
                                              where c.FlowNode_id == rFlowNode.id
                                              select c).FirstOrDefault();

                        if (rNodeMultiInit != null)
                            apName = rNodeMultiInit.apName;
                        break;
                    case "6": //自定簽核者
                        var rNodeCustom = (from c in dcFlow.NodeCustom
                                           where c.FlowNode_id == rFlowNode.id
                                           select c).FirstOrDefault();

                        if (rNodeCustom != null)
                            apName = rNodeCustom.apName;
                        break;
                    case "7": //動態簽核者
                        var rNodeDynamic = (from c in dcFlow.NodeDynamic
                                            where c.FlowNode_id == rFlowNode.id
                                            select c).FirstOrDefault();

                        if (rNodeDynamic != null)
                            apName = rNodeDynamic.apName;
                        break;
                    case "8": //流程代理者
                        var rNodeAgentInit = (from c in dcFlow.NodeAgentInit
                                              where c.FlowNode_id == rFlowNode.id
                                              select c).FirstOrDefault();

                        if (rNodeAgentInit != null)
                            apName = rNodeAgentInit.apName;
                        break;
                }

                FlowNodeApNameRow rFlowNodeAppNameRow = new FlowNodeApNameRow();
                rFlowNodeAppNameRow.FlowNodeId = rFlowNode.id;
                rFlowNodeAppNameRow.ApName = apName;
                Vdb.Add(rFlowNodeAppNameRow);
            }

            return Vdb;
        }

        /// <summary>
        /// 取得檢視網址
        /// </summary>
        /// <param name="idProcess">流程序號</param>
        /// <param name="bOnlyUrl">只顯有網址</param>
        /// <returns>string</returns>
        public string GetFlowViewUrl(int idProcess, bool bOnlyUrl = false)
        {
            string Url = "";
            var rNodeStart = (from pf in dcFlow.ProcessFlow
                              join fn in dcFlow.FlowNode on pf.FlowTree_id equals fn.FlowTree_id
                              join ns in dcFlow.NodeStart on fn.id equals ns.FlowNode_id
                              where pf.id == idProcess
                              && fn.nodeType == "1"
                              select new
                              {
                                  ViewUrl = ns.virtualPath + "/" + ns.viewAp,
                              }).FirstOrDefault();

            if (rNodeStart != null)
            {
                var rProcessApView = (from c in dcFlow.ProcessApView
                                      where c.ProcessFlow_id == idProcess
                                      select c).FirstOrDefault();

                if (rProcessApView != null)
                {
                    Url = rNodeStart.ViewUrl;
                    if (!bOnlyUrl)
                        Url = rNodeStart.ViewUrl + "?ApView=" + rProcessApView.auto;
                }
            }

            return Url;
        }

        /// <summary>
        /// 取得流程的內容網址
        /// </summary>
        /// <param name="iApParmID">檢查表序號</param>
        /// <param name="bOnlyUrl">只顯有網址</param>
        /// <returns>string</returns>
        public string GetFlowParmUrl(int iApParmID, bool bOnlyUrl = false)
        {
            string Url = "";

            if (iApParmID != 0)
            {
                var rSysVar = (from c in dcFlow.SysVar
                               select c).FirstOrDefault();

                if (rSysVar != null)
                {
                    string urlRoot = rSysVar.urlRoot;

                    var rProcessApParm = (from c in dcFlow.ProcessApParm
                                          where c.auto == iApParmID
                                          select c).FirstOrDefault();

                    if (rProcessApParm != null)
                    {
                        var rProcessFlow = (from c in dcFlow.ProcessFlow
                                            where c.id == rProcessApParm.ProcessFlow_id
                                            select c).FirstOrDefault();

                        if (rProcessFlow != null)
                        {
                            var rFlowNode = (from c in dcFlow.FlowNode
                                             where c.nodeType == "1"
                                             && c.FlowTree_id == rProcessFlow.FlowTree_id
                                             select c).FirstOrDefault();

                            if (rFlowNode != null)
                            {
                                var rNodeStart = (from c in dcFlow.NodeStart
                                                  where c.FlowNode_id == rFlowNode.id
                                                  select c).FirstOrDefault();

                                if (rNodeStart != null)
                                {
                                    string virtualPath = rNodeStart.virtualPath;

                                    var rProcessNode = (from c in dcFlow.ProcessNode
                                                        where c.auto == rProcessApParm.ProcessNode_auto
                                                        select c).FirstOrDefault();

                                    if (rProcessNode != null)
                                    {
                                        var rFlowNodeCheck = (from c in dcFlow.FlowNode
                                                              where c.id == rProcessNode.FlowNode_id
                                                              select c).FirstOrDefault();

                                        string apName = "";

                                        switch (rFlowNodeCheck.nodeType)
                                        {
                                            case "3": //主管審核
                                                var rNodeMang = (from c in dcFlow.NodeMang
                                                                 where c.FlowNode_id == rFlowNodeCheck.id
                                                                 select c).FirstOrDefault();

                                                if (rNodeMang != null)
                                                    apName = rNodeMang.apName;
                                                break;
                                            case "4": //流程起始者
                                                var rNodeInit = (from c in dcFlow.NodeInit
                                                                 where c.FlowNode_id == rFlowNodeCheck.id
                                                                 select c).FirstOrDefault();

                                                if (rNodeInit != null)
                                                    apName = rNodeInit.apName;
                                                break;
                                            case "5": //會簽起始者
                                                var rNodeMultiInit = (from c in dcFlow.NodeMultiInit
                                                                      where c.FlowNode_id == rFlowNodeCheck.id
                                                                      select c).FirstOrDefault();

                                                if (rNodeMultiInit != null)
                                                    apName = rNodeMultiInit.apName;
                                                break;
                                            case "6": //自定簽核者
                                                var rNodeCustom = (from c in dcFlow.NodeCustom
                                                                   where c.FlowNode_id == rFlowNodeCheck.id
                                                                   select c).FirstOrDefault();

                                                if (rNodeCustom != null)
                                                    apName = rNodeCustom.apName;
                                                break;
                                            case "7": //動態簽核者
                                                var rNodeDynamic = (from c in dcFlow.NodeDynamic
                                                                    where c.FlowNode_id == rFlowNodeCheck.id
                                                                    select c).FirstOrDefault();

                                                if (rNodeDynamic != null)
                                                    apName = rNodeDynamic.apName;
                                                break;
                                            case "8": //流程代理者
                                                var rNodeAgentInit = (from c in dcFlow.NodeAgentInit
                                                                      where c.FlowNode_id == rFlowNodeCheck.id
                                                                      select c).FirstOrDefault();

                                                if (rNodeAgentInit != null)
                                                    apName = rNodeAgentInit.apName;
                                                break;
                                        }

                                        if (apName.Trim().Length > 0)
                                        {
                                            Url = urlRoot + "/Forms/" + virtualPath + "/" + apName;
                                            if (!bOnlyUrl)
                                                Url += "?ApParm=" + iApParmID.ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return Url;
        }


    }
}
