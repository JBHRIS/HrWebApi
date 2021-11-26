using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Bll.Flow.Vdb;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Dal.Entity;

namespace Dal.Dao.Flow
{
    public class MainDao
    {
        private Dal.Entity.dcFlowDataContext dcFlow = new Entity.dcFlowDataContext();

        /// <summary>
        /// 電子簽核資料
        /// </summary>
        /// <param name="conn">連接字串 沒有等於預設</param>
        public MainDao(IDbConnection conn = null)
        {
            dcFlow = new Entity.dcFlowDataContext();

            if (conn != null)
                dcFlow = new Entity.dcFlowDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 電子簽核資料
        /// </summary>
        /// <param name="ConnectionString">連接字串 沒有等於預設</param>
        public MainDao(string ConnectionString = null)
        {
            dcFlow = new Entity.dcFlowDataContext();

            if (ConnectionString != null)
                dcFlow = new Entity.dcFlowDataContext(ConnectionString);
        }

        /// <summary>
        /// 取得申請表單樹
        /// </summary>
        /// <param name="sNobr">申請人工號</param>
        /// <param name="sDeptm">簽核部門</param>
        /// <returns>TreeView</returns>
        public TreeView GetFormTreeToTreeView(string sNobr, string sDeptm = "")
        {
            TreeView tvMain = new TreeView();

            var rSysVar = (from c in dcFlow.SysVar
                           select c).FirstOrDefault();
            if (rSysVar == null) return tvMain;

            var rsFlowTree = (from t in dcFlow.FlowTree
                              where t.dateB.Value.Date <= DateTime.Now.Date
                              && DateTime.Now.Date <= t.dateE.Value.Date
                              && t.isVisible.Value
                              orderby t.FlowGroup_id, t.dateB.Value.Date
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

            var rsFlowGroup = (from g in dcFlow.FlowGroup
                               where g.dateB.Value.Date <= DateTime.Now.Date
                               && DateTime.Now.Date <= g.dateE.Value.Date
                               select g).ToList();

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
                          select new
                          {
                              RoleID = r.id,
                              DeptName = d.name,
                              DeptPath = d.path,
                              PosName = p.name,
                          }).ToList();


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

                    //第一層否果有相同角色 就無需再創建
                    TreeNode findNode_Role = null;
                    foreach (TreeNode node in tvMain.Nodes)
                    {
                        if (node.Value == rRole.RoleID)
                        {
                            findNode_Role = node;
                            break;
                        }
                    }
                    if (findNode_Role == null)
                    {
                        findNode_Role = new TreeNode();
                        findNode_Role.Text = rRole.PosName + "@" + rRole.DeptName;
                        findNode_Role.Value = rRole.RoleID;
                        findNode_Role.ImageUrl = "images/person.bmp";
                        tvMain.Nodes.Add(findNode_Role);
                    }
                    findNode_Role.NavigateUrl = "#";

                    //尋找群組
                    var rFlowGroup = rsFlowGroup.Where(p => p.id == rFlowTree.FlowGroup_id).FirstOrDefault();
                    TreeNode findFlowGroup = null;
                    if (rFlowGroup != null)
                    {
                        //如果還有父群組
                        if (rFlowGroup.idParent != null && rFlowGroup.idParent.Trim().Length > 0)
                        {
                            TreeNode FlowGroupParent = GetFlowGroupNode(findNode_Role, findNode_Role.Value + rFlowGroup.idParent);
                            //如果找不到父群組，則建立父群組，連同子群組一併建立
                            if (FlowGroupParent == null)
                            {
                                var rFlowGroupParent = rsFlowGroup.Where(p => p.id == rFlowGroup.idParent).FirstOrDefault();
                                if (rFlowGroupParent != null)
                                {
                                    FlowGroupParent = new TreeNode();
                                    FlowGroupParent.Text = rFlowGroupParent.name;
                                    FlowGroupParent.Value = findNode_Role.Value + rFlowGroupParent.id;
                                    FlowGroupParent.ImageUrl = "images/folder.bmp";
                                    findNode_Role.ChildNodes.Add(FlowGroupParent);
                                    FlowGroupParent.NavigateUrl = "#";
                                }
                                if (FlowGroupParent != null)
                                {
                                    findFlowGroup = new TreeNode();
                                    findFlowGroup.Text = rFlowGroup.name;
                                    findFlowGroup.Value = findNode_Role.Value + rFlowGroup.id;
                                    findFlowGroup.ImageUrl = "images/folder.bmp";
                                    FlowGroupParent.ChildNodes.Add(findFlowGroup);
                                    findFlowGroup.NavigateUrl = "#";
                                }
                            }
                            else
                            {
                                //父群組找到了，就找看看有沒有符合的子群組
                                findFlowGroup = GetFlowGroupNode(FlowGroupParent, findNode_Role.Value + rFlowGroup.id);
                                if (findFlowGroup == null)
                                {
                                    findFlowGroup = new TreeNode();
                                    findFlowGroup.Text = rFlowGroup.name;
                                    findFlowGroup.Value = findNode_Role.Value + rFlowGroup.id;
                                    findFlowGroup.ImageUrl = "images/folder.bmp";
                                    FlowGroupParent.ChildNodes.Add(findFlowGroup);
                                    findFlowGroup.NavigateUrl = "#";
                                }
                            }
                        }
                        else
                        {
                            //沒有父群組，則直接找尋符合的群組
                            findFlowGroup = GetFlowGroupNode(findNode_Role, findNode_Role.Value + rFlowGroup.id);
                            if (findFlowGroup == null)
                            {
                                findFlowGroup = new TreeNode();
                                findFlowGroup.Text = rFlowGroup.name;
                                findFlowGroup.Value = findNode_Role.Value + rFlowGroup.id;
                                findFlowGroup.ImageUrl = "images/folder.bmp";
                                findNode_Role.ChildNodes.Add(findFlowGroup);
                                findFlowGroup.NavigateUrl = "#";
                            }
                        }
                    }

                    string link = rSysVar.urlRoot + "/Forms/" + rFlowNodeStart.virtualPath + "/" + rFlowNodeForm.apName;

                    TreeNode node_FlowTree = new TreeNode();
                    node_FlowTree.Text = rFlowTree.name;
                    node_FlowTree.Value = rFlowTree.id;
                    node_FlowTree.ImageUrl = "images/html.bmp";
                    node_FlowTree.NavigateUrl = link + "?idFlowTree=" + rFlowTree.id + "&" +
                        "idRole_Start=" + rRole.RoleID + "&idEmp_Start=" + sNobr + "&idRole_Agent=&idEmp_Agent=";
                    node_FlowTree.Target = "frameMain";

                    if (findFlowGroup != null)
                        findFlowGroup.ChildNodes.Add(node_FlowTree);
                }
            }

            foreach (TreeNode node in tvMain.Nodes)
            {
                if (node.ChildNodes.Count > 0) DeleteEmptyNode(node);
                else tvMain.Nodes.Remove(node);
            }

            return tvMain;
        }

        private TreeNode GetFlowGroupNode(TreeNode rNode, string findValue)
        {
            TreeNode findNode = null;
            foreach (TreeNode node in rNode.ChildNodes)
            {
                if (node.Value == findValue)
                {
                    findNode = node;
                    break;
                }
                else
                {
                    if (node.ChildNodes.Count > 0) findNode = GetFlowGroupNode(node, findValue);
                    if (findNode != null) break;
                }
            }
            return findNode;
        }

        private void DeleteEmptyNode(TreeNode rNode)
        {
            foreach (TreeNode sNode in rNode.ChildNodes)
            {
                if (sNode.ChildNodes.Count > 0) DeleteEmptyNode(sNode);
                else
                {
                    if (sNode.NavigateUrl.Trim().Length == 0) rNode.ChildNodes.Remove(sNode);
                }
            }
        }

        /// <summary>
        /// 取得申請表單樹 轉成 HTML
        /// </summary>
        /// <param name="sNobr">申請人工號</param>
        /// <param name="sDeptm">簽核部門</param>
        /// <returns>string</returns>
        public string GetFormTreeToHtmlString(string sNobr, string sDeptm = "")
        {
            TreeView tv = GetFormTreeToTreeView(sNobr, sDeptm);
            StringBuilder sb = new StringBuilder();
            sb.Append("<UL>");
            ParseTreeViewToHTML(tv.Nodes, sb);
            sb.Append("</UL>");

            return sb.ToString();
        }

        /// <summary>
        /// HTML展開
        /// </summary>
        /// <param name="parentNodes">上層節點</param>
        /// <param name="sb">連接字串</param>
        private void ParseTreeViewToHTML(TreeNodeCollection parentNodes, StringBuilder sb)
        {
            foreach (TreeNode node in parentNodes)
            {
                sb.Append("<LI><a href='" + node.NavigateUrl + "'>" + node.Text + "</a></LI>");
                if (node.ChildNodes.Count > 0)
                {
                    sb.Append("<UL>");
                    ParseTreeViewToHTML(node.ChildNodes, sb);
                    sb.Append("</UL>");
                }
            }
        }

        /// <summary>
        /// 取得申請表單樹 轉成 List
        /// </summary>
        /// <param name="sNobr">申請人工號</param>
        /// <param name="sDeptm">簽核部門</param>
        /// <returns>List</returns>
        public List<FormTreeTable> GetFormTreeToList(string sNobr, string sDeptm = "")
        {
            List<FormTreeTable> Vdb = new List<FormTreeTable>();

            TreeView tv = GetFormTreeToTreeView(sNobr, sDeptm);
            StringBuilder sb = new StringBuilder();
            ParseTreeViewToList(tv.Nodes, sb, Vdb);

            return Vdb;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentNodes"></param>
        /// <param name="sb"></param>
        /// <param name="Vdb"></param>
        private void ParseTreeViewToList(TreeNodeCollection parentNodes, StringBuilder sb, List<FormTreeTable> Vdb)
        {
            foreach (TreeNode node in parentNodes)
            {
                FormTreeTable rVdb = new FormTreeTable();
                rVdb.NodeID = node.Value;
                rVdb.ParentNodeID = node.Parent != null ? node.Parent.Value : "";
                rVdb.Text = node.Text;
                rVdb.Value = node.Value;
                rVdb.NavigateUrl = node.NavigateUrl;
                rVdb.Path = node.ValuePath;
                Vdb.Add(rVdb);

                if (node.ChildNodes.Count > 0)
                    ParseTreeViewToList(node.ChildNodes, sb, Vdb);
            }
        }

        /// <summary>
        /// 取得目前待審核的表單
        /// </summary>
        /// <param name="sNobr">審核者工號</param>
        /// <param name="sAppNobr">申請者工號</param>
        /// <returns>List</returns>
        public List<FlowSignTable> GetFlowProgressFlow(string sNobr = "", string sAppNobr = "")
        {
            var Vdb = from pc in dcFlow.ProcessCheck
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
                      //join r1 in dcFlow.Role on pf.Role_id equals r1.id into pf2
                      //from pf2Row in pf2.DefaultIfEmpty()
                      //join d1 in dcFlow.Dept on pf2Row.Dept_id equals d1.id into pf21
                      //from pf21Row in pf21.DefaultIfEmpty()
                      where !pf.isFinish.Value
                      && !pf.isCancel.Value
                      && !pf.isError.Value
                      && !pn.isFinish.Value
                      && ((pc.Emp_idDefault == sNobr || pc.Emp_idAgent == sNobr) || sNobr == "")
                      && (pf.Emp_id == sAppNobr || sAppNobr == "")
                      orderby pn.adate.Value
                      select new FlowSignTable()
                      {
                          ApParmID = 0,
                          ProcessID = pf.id,
                          ProcessCheckAuto = pc.auto,
                          ProcessNodeAuto = pn.auto,
                          AppName = pf1Row != null ? pf1Row.name : "",
                          //AppDept = pf21Row != null ? pf21Row.name : "",
                          //AppDeptPath = pf21Row != null ? pf21Row.path : "",
                          AppDate = pf.adate.Value,
                          FormName = ft.name,
                          FlowProgress = fn.name,
                          CheckName = pc1Row != null ? pc1Row.name : "",
                          AgentName = pc2Row != null ? pc2Row.name : "",
                          PendingDay = Convert.ToInt32((DateTime.Now.Date - pn.adate.Value.Date).TotalDays),
                      };

            //填入表單資訊
            var rsFormApp = (from c in dcFlow.wfFormApp
                             where (from b in Vdb where c.idProcess == b.ProcessID select 1).Any()
                             select new
                             {
                                 c.idProcess,
                                 c.sReserve4,
                                 c.sInfo,
                             }).ToList();

            var rsProcessApParm = (from c in dcFlow.ProcessApParm
                                   where (from b in Vdb
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

            var Vdb1 = Vdb.ToList();

            foreach (var rVdb in Vdb1)
            {
                var rProcessApParm = (from c in rsProcessApParm
                                      where c.ProcessFlow_id == rVdb.ProcessID
                                      && c.ProcessCheck_auto == rVdb.ProcessCheckAuto
                                      && c.ProcessNode_auto == rVdb.ProcessNodeAuto
                                      select c).FirstOrDefault();

                if (rProcessApParm != null)
                    rVdb.ApParmID = rProcessApParm.auto;

                rVdb.AgentState = rVdb.AgentName.Length > 0 ? "代為處理" : "";
                rVdb.ParmUrl = GetFlowParmUrl(rVdb.ApParmID);

                var rFormApp = rsFormApp.Where(p => p.idProcess == rVdb.ProcessID).FirstOrDefault();
                if (rFormApp != null)
                {
                    string sInfo = rFormApp.sInfo != null ? rFormApp.sInfo : "";
                    rVdb.Info = "<span title='" + rVdb.ProcessID + "," + rVdb.ApParmID + "'>" + sInfo + "</span>";

                    try
                    {
                        FormInfo rFormInfo = JsonConvert.DeserializeObject<FormInfo>(sInfo);

                        rVdb.InfoFrom = "<span title='" + rVdb.ProcessID + "," + rVdb.ApParmID + "'>" + rFormInfo.InfoFrom + "</span>";
                        rVdb.InfoTo = rFormInfo.InfoTo;
                        rVdb.InfoType = rFormInfo.InfoType;
                        rVdb.InfoUse = rFormInfo.InfoUse;
                    }
                    catch { }
                }
            }

            return Vdb1;
        }

        /// <summary>
        /// 取得目前待審核的表單的筆數
        /// </summary>
        /// <param name="sNobr">審核者工號</param>
        /// <param name="sAppNobr">申請者工號</param>
        /// <returns>List</returns>
        public int GetFlowProgressFlowCount(string sNobr = "", string sAppNobr = "")
        {
            var Vdb = (from pc in dcFlow.ProcessCheck
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
                       //join r1 in dcFlow.Role on pf.Role_id equals r1.id into pf2
                       //from pf2Row in pf2.DefaultIfEmpty()
                       //join d1 in dcFlow.Dept on pf2Row.Dept_id equals d1.id into pf21
                       //from pf21Row in pf21.DefaultIfEmpty()
                       where !pf.isFinish.Value
                       && !pf.isCancel.Value
                       && !pf.isError.Value
                       && !pn.isFinish.Value
                       && ((pc.Emp_idDefault == sNobr || pc.Emp_idAgent == sNobr) || sNobr == "")
                       && (pf.Emp_id == sAppNobr || sAppNobr == "")
                       orderby pn.adate.Value
                       select new FlowSignTable()
                       {
                           ApParmID = 0,
                           ProcessID = pf.id,
                           ProcessCheckAuto = pc.auto,
                           ProcessNodeAuto = pn.auto,
                           AppName = pf1Row != null ? "<span title='" + pf1Row.id + "'>" + pf1Row.name + "</span>" : "",
                           //AppDept = pf21Row != null ? pf21Row.name : "",
                           //AppDeptPath = pf21Row != null ? pf21Row.path : "",
                           AppDate = pf.adate.Value,
                           FormName = ft.name,
                           FlowProgress = fn.name,
                           CheckName = pc1Row != null ? pc1Row.name : "",
                           AgentName = pc2Row != null ? pc2Row.name : "",
                           PendingDay = Convert.ToInt32((DateTime.Now.Date - pn.adate.Value.Date).TotalDays),
                       }).Count();

            return Vdb;
        }

        /// <summary>
        /// 取得曾經審核的表單
        /// </summary>
        /// <param name="sNobr">審核者工號</param>
        /// <returns>List</returns>
        public List<FlowSignCompleteTable> GetFlowProgressFlowComplete(string sNobr)
        {
            var Vdb = from pc in dcFlow.ProcessCheck
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
                      where pf.isFinish.Value
                      && pn.isFinish.Value
                      && pc.Emp_idReal == sNobr
                      orderby pn.adate.Value
                      select new FlowSignCompleteTable()
                      {
                          ApViewID = 0,
                          ProcessID = pf.id,
                          ProcessCheckAuto = pc.auto,
                          ProcessNodeAuto = pn.auto,
                          AppName = pf1Row != null ? "<span title='" + pf1Row.id + "'>" + pf1Row.name + "</span>" : "",
                          AppDate = pf.adate.Value,
                          FormName = ft.name,
                          FlowProgress = fn.name,
                          AgentName = pc2Row != null ? pc2Row.name : "",
                          PendingDay = Convert.ToInt32((DateTime.Now.Date - pn.adate.Value.Date).TotalDays),
                      };

            //填入表單資訊
            var rsFormApp = (from c in dcFlow.wfFormApp
                             where (from b in Vdb where c.idProcess == b.ProcessID select 1).Any()
                             select new
                             {
                                 c.idProcess,
                                 c.sReserve4,
                             }).ToList();

            var rsProcessApView = (from c in dcFlow.ProcessApView
                                   where (from b in Vdb where c.ProcessFlow_id == b.ProcessID select 1).Any()
                                   select new { c.auto, c.ProcessFlow_id }).ToList();

            var Vdb1 = Vdb.ToList();

            foreach (var rVdb in Vdb1)
            {
                var rProcessApView = (from c in rsProcessApView
                                      where c.ProcessFlow_id == rVdb.ProcessID
                                      select c).FirstOrDefault();

                if (rProcessApView != null)
                {
                    rVdb.ApViewID = rProcessApView.auto;
                    rVdb.FormName = "<span title='" + rVdb.ApViewID + "'>" + rVdb.FormName + "</span>";
                }

                rVdb.AgentState = rVdb.AgentName.Length > 0 ? "代為處理" : "";
                rVdb.ViewUrl = GetFlowViewUrl(rVdb.ApViewID);

                var rFormApp = rsFormApp.Where(p => p.idProcess == rVdb.ProcessID).FirstOrDefault();
                if (rFormApp != null)
                {
                    rVdb.Info = rFormApp.sReserve4 != null ? rFormApp.sReserve4 : "";

                    try
                    {
                        FormInfo rFormInfo = JsonConvert.DeserializeObject<FormInfo>(rVdb.Info);

                        rVdb.InfoFrom = rFormInfo.InfoFrom;
                        rVdb.InfoTo = rFormInfo.InfoTo;
                        rVdb.InfoType = rFormInfo.InfoType;
                        rVdb.InfoUse = rFormInfo.InfoUse;
                    }
                    catch { }
                }
            }

            return Vdb1;
        }

        /// <summary>
        /// 取得流程的內容網址
        /// </summary>
        /// <param name="iApParmID">檢查表序號</param>
        /// <returns>string</returns>
        public string GetFlowParmUrl(int iApParmID)
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
                                            Url = urlRoot + "/Forms/" + virtualPath + "/" + apName + "?ApParm=" + iApParmID.ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return Url;
        }

        /// <summary>
        /// 設定更新流程審核表
        /// </summary>
        /// <param name="sNobr">申請者工號</param>
        /// <param name="iApParmID">檢查表序號</param>
        /// <param name="iProcessCheckAuto">ProcessCheckAuto</param>
        /// <returns>bool</returns>
        public bool SetProcessApParm(string sNobr, int iApParmID, int iProcessCheckAuto)
        {
            bool bUpdate = false;

            var rsRole = (from c in dcFlow.Role
                          where c.Emp_id == sNobr
                          select c).ToList();

            if (rsRole != null)
            {
                var rProcessCheck = (from c in dcFlow.ProcessCheck
                                     where c.auto == iProcessCheckAuto
                                     select c).FirstOrDefault();

                string Role_id = "";
                foreach (var rRole in rsRole)
                {
                    if (rRole.id == rProcessCheck.Role_idDefault || rRole.id == rProcessCheck.Role_idAgent)
                    {
                        Role_id = rRole.id;
                        break;
                    }
                }

                var rProcessApParm = (from c in dcFlow.ProcessApParm
                                      where c.auto == iApParmID
                                      select c).FirstOrDefault();

                if (rProcessApParm != null && Role_id.Length > 0)
                {
                    JBModule.Message.TextLog.WriteLog(iApParmID.ToString());

                    rProcessApParm.Role_id = Role_id;
                    rProcessApParm.Emp_id = sNobr;

                    dcFlow.SubmitChanges();

                    bUpdate = true;
                }
            }

            return bUpdate;
        }

        /// <summary>
        /// 取得目前正在進行中的流程
        /// </summary>
        /// <param name="sNobr">查詢者工號</param>
        /// <returns>List</returns>
        public List<FlowSearchIngTable> GetFlowSearchIng(string sNobr)
        {
            var Vdb = from pf in dcFlow.ProcessFlow
                      join pn in dcFlow.ProcessNode on pf.id equals pn.ProcessFlow_id
                      join pc in dcFlow.ProcessCheck on pn.auto equals pc.ProcessNode_auto
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
                      select new FlowSearchIngTable()
                      {
                          ApViewID = 0,
                          ProcessID = pf.id,
                          FormName = ft.name,
                          FlowProgress = fn.name,
                          AppDate = pf.adate.Value,
                          SignDate = pn.adate.Value,
                          SignName = pc2Row != null ? pc2Row.name : "",
                          AgentName = pc1Row != null ? pc1Row.name : "",
                      };

            var arrPorcessID = Vdb.Select(p => p.ProcessID).ToArray();

            var rsProcessApView = (from c in dcFlow.ProcessApView
                                   where (from b in Vdb where c.ProcessFlow_id.Value == b.ProcessID select 1).Any()
                                   select new { c.auto, c.ProcessFlow_id }).ToList();

            var Vdb1 = Vdb.ToList();

            foreach (var rVdb in Vdb1)
            {
                var rProcessApView = rsProcessApView.Where(p => p.ProcessFlow_id.Value == rVdb.ProcessID).OrderByDescending(p => p.auto).FirstOrDefault();
                if (rProcessApView != null)
                {
                    rVdb.ApViewID = rProcessApView.auto;
                    rVdb.ViewUrl = GetFlowViewUrl(rVdb.ApViewID);
                    rVdb.HistoryUrl = GetFlowHistoryUrl(rVdb.ProcessID);
                }
            }

            return Vdb1;
        }

        /// <summary>
        /// 取得流程的內容網址
        /// </summary>
        /// <param name="iApViewID">檢查表序號</param>
        /// <returns>string</returns>
        public string GetFlowViewUrl(int iApViewID)
        {
            string Url = "";

            if (iApViewID != 0)
            {
                var rSysVar = (from c in dcFlow.SysVar
                               select c).FirstOrDefault();

                if (rSysVar != null)
                {
                    string urlRoot = rSysVar.urlRoot;

                    var rProcessApView = (from c in dcFlow.ProcessApView
                                          where c.auto == iApViewID
                                          select c).FirstOrDefault();

                    if (rProcessApView != null)
                    {
                        var rProcessFlow = (from c in dcFlow.ProcessFlow
                                            where c.id == rProcessApView.ProcessFlow_id.Value
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
                                    string virtualPath = (rNodeStart.virtualPath == null) ? "" : rNodeStart.virtualPath;
                                    string apName = (rNodeStart.viewAp == null) ? "" : rNodeStart.viewAp;
                                    if (virtualPath.Trim().Length > 0 && apName.Trim().Length > 0)
                                    {
                                        Url = urlRoot + "/Forms/" + virtualPath + "/" + apName + "?ApView=" + iApViewID.ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return Url;
        }

        /// <summary>
        /// 取得流程的內容網址
        /// </summary>
        /// <param name="iApViewID">檢查表序號</param>
        /// <returns>string</returns>
        public string GetFlowViewUrlOnlyUrl(int iApViewID)
        {
            string Url = "";

            if (iApViewID != 0)
            {
                var rSysVar = (from c in dcFlow.SysVar
                               select c).FirstOrDefault();

                if (rSysVar != null)
                {
                    string urlRoot = rSysVar.urlRoot;

                    var rProcessApView = (from c in dcFlow.ProcessApView
                                          where c.auto == iApViewID
                                          select c).FirstOrDefault();

                    if (rProcessApView != null)
                    {
                        var rProcessFlow = (from c in dcFlow.ProcessFlow
                                            where c.id == rProcessApView.ProcessFlow_id.Value
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
                                    string virtualPath = (rNodeStart.virtualPath == null) ? "" : rNodeStart.virtualPath;
                                    string apName = (rNodeStart.viewAp == null) ? "" : rNodeStart.viewAp;
                                    if (virtualPath.Trim().Length > 0 && apName.Trim().Length > 0)
                                    {
                                        Url = urlRoot + "/Forms/" + virtualPath + "/" + apName + "?ApView=";
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return Url;
        }

        /// <summary>
        /// 取得流程的流程圖網址
        /// </summary>
        /// <param name="iProcessID">檢查表序號</param>
        /// <returns>string</returns>
        public string GetFlowHistoryUrl(int iProcessID)
        {
            string Url = "";

            if (iProcessID != 0)
            {
                var rSysVar = (from c in dcFlow.SysVar
                               select c).FirstOrDefault();

                if (rSysVar != null)
                {
                    string urlRoot = rSysVar.urlRoot;
                    Url = urlRoot + "/Forms/FlowImage/Output.aspx?idProcess=" + iProcessID.ToString();
                }
            }

            return Url;
        }

        /// <summary>
        /// 取得目前完成的流程
        /// </summary>
        /// <param name="sNobr">查詢者工號</param>
        /// <param name="dAppB">查詢開始日期</param>
        /// <param name="dAppE">查詢結束日期</param>
        /// <returns>List</returns>
        public List<FlowSearchCompleteTable> GetFlowSearchComplete(string sNobr, DateTime dAppB, DateTime dAppE)
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
                       select new FlowSearchCompleteTable()
                       {
                           ApViewID = pav.auto,
                           ViewUrl = GetFlowViewUrl(pav.auto),
                           HistoryUrl = GetFlowHistoryUrl(pf.id),
                           ProcessID = pf.id,
                           FormName = ft.name,
                           AppDate = pf.adate.Value,
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 設定取消流程作業
        /// </summary>
        /// <param name="lsProcessID">List ProcessID</param>
        /// <param name="bCancel">True = 取消流程</param>
        /// <returns>List int</returns>
        public List<int> SetCancelProcessFlow(List<int> lsProcessID, bool bCancel = true)
        {
            List<int> Vdb = new List<int>();

            var rsProcessFlow = (from c in dcFlow.ProcessFlow
                                 where lsProcessID.Contains(c.id)
                                 select c).ToList();

            foreach (var rProcessFlow in rsProcessFlow)
            {
                rProcessFlow.isCancel = bCancel;
                Vdb.Add(rProcessFlow.id);
            }

            dcFlow.SubmitChanges();

            return Vdb;
        }

        /// <summary>
        /// 取得角色
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <returns>string</returns>
        public List<RolesTable> GetRoles(string sNobr)
        {
            var Vdb = (from r in dcFlow.Role
                       join p in dcFlow.Pos
                       on r.Pos_id equals p.id
                       join d in dcFlow.Dept
                       on r.Dept_id equals d.id
                       where r.Emp_id == sNobr
                       select new RolesTable
                       {
                           RoleID = r.id,
                           RoleName = d.name + "@" + p.name,
                           DeptID = d.id,
                           DeptName = d.name,
                           PosID = p.id,
                           PosName = p.name,
                           Manage = r.mgDefault.Value,
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得代理人資訊
        /// </summary>
        /// <param name="sNobr">被代理人工號</param>
        /// <param name="sRole">被代理人角色 空白等於全部取得</param>
        /// <returns></returns>
        public List<CheckAgentDefaultTable> GetAgent(string sNobr, string sRole = "")
        {
            var Vdb = from c in dcFlow.CheckAgentDefault
                      where c.Emp_idSource == sNobr
                      && sRole.Length == 0 || c.Role_idSource == sRole
                      select new CheckAgentDefaultTable
                      {
                          SourceNobr = c.Emp_idSource,
                          SourceRole = c.Role_idSource,
                          TargetNobr1 = c.Emp_idTarget1,
                          TargetRole1 = c.Role_idTarget1,
                          TargetNobr2 = c.Emp_idTarget2,
                          TargetRole2 = c.Role_idTarget2,
                          TargetNobr3 = c.Emp_idTarget3,
                          TargetRole3 = c.Role_idTarget3,
                      };

            var rsEmp = from e in dcFlow.Emp
                        where (from c in Vdb
                               where e.id == c.TargetNobr1
                               || e.id == c.TargetNobr2
                               || e.id == c.TargetNobr3
                               select 1).Any()
                        select e;

            var Vdb1 = Vdb.ToList();

            foreach (var rVdb in Vdb1)
            {
                var rEmp = rsEmp.Where(p => p.id == rVdb.SourceNobr).FirstOrDefault();
                if (rEmp != null)
                {
                    rVdb.SourceName = rEmp.name;
                    rVdb.DateA = rEmp.dateB.Value;
                    rVdb.DateD = rEmp.dateE.Value;
                }

                rEmp = rsEmp.Where(p => p.id == rVdb.TargetNobr1).FirstOrDefault();
                if (rEmp != null)
                    rVdb.TargetName1 = rEmp.name;
                rEmp = rsEmp.Where(p => p.id == rVdb.TargetNobr2).FirstOrDefault();
                if (rEmp != null)
                    rVdb.TargetName2 = rEmp.name;
                rEmp = rsEmp.Where(p => p.id == rVdb.TargetNobr3).FirstOrDefault();
                if (rEmp != null)
                    rVdb.TargetName3 = rEmp.name;
            }

            return Vdb1;
        }

        /// <summary>
        /// 代理人設定
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="sRole">角色</param>
        /// <param name="sAgentNobr1">代理人1</param>
        /// <param name="sAgentNobr2">代理人2</param>
        /// <param name="sAgentNobr3">代理人3</param>
        /// <param name="dDateB">開始代理日期</param>
        /// <param name="dDateE">結束代理日期</param>
        /// <returns>bool</returns>
        public bool SetAgent(string sNobr, string sRole, string sAgentNobr1, string sAgentNobr2, string sAgentNobr3, DateTime dDateB, DateTime dDateE)
        {
            var rEmp = (from c in dcFlow.Emp
                        where c.id == sNobr
                        select c).FirstOrDefault();

            var rsRole = (from c in dcFlow.Role
                          where c.Emp_id == sNobr
                          && c.id == sRole
                          select c).ToList();

            var rsCheckAgentDefault = (from c in dcFlow.CheckAgentDefault
                                       where c.Emp_idSource == sNobr
                                       && c.Role_idSource == sRole
                                       select c).ToList();

            if (sRole.Length == 0)
            {
                rsRole = (from c in dcFlow.Role
                          where c.Emp_id == sNobr
                          select c).ToList();

                rsCheckAgentDefault = (from c in dcFlow.CheckAgentDefault
                                       where c.Emp_idSource == sNobr
                                       select c).ToList();
            }

            if (rsCheckAgentDefault.Any())
                dcFlow.CheckAgentDefault.DeleteAllOnSubmit(rsCheckAgentDefault);

            var rRole1 = (from c in dcFlow.Role
                          where c.Emp_id == sAgentNobr1
                          select c).FirstOrDefault();

            var rRole2 = (from c in dcFlow.Role
                          where c.Emp_id == sAgentNobr2
                          select c).FirstOrDefault();

            var rRole3 = (from c in dcFlow.Role
                          where c.Emp_id == sAgentNobr3
                          select c).FirstOrDefault();

            if (rEmp != null)
            {
                rEmp.dateB = Convert.ToDateTime(dDateB);
                rEmp.dateE = Convert.ToDateTime(dDateE);

                foreach (var rRole in rsRole)
                {
                    var rCheckAgentDefault = new CheckAgentDefault();
                    rCheckAgentDefault.Emp_idSource = rRole.Emp_id;
                    rCheckAgentDefault.Role_idSource = rRole.id;
                    rCheckAgentDefault.Emp_idTarget1 = "";
                    rCheckAgentDefault.Role_idTarget1 = "";
                    rCheckAgentDefault.Emp_idTarget2 = "";
                    rCheckAgentDefault.Role_idTarget2 = "";
                    rCheckAgentDefault.Emp_idTarget3 = "";
                    rCheckAgentDefault.Role_idTarget3 = "";

                    if (rRole1 != null)
                    {
                        rCheckAgentDefault.Emp_idTarget1 = rRole1.Emp_id;
                        rCheckAgentDefault.Role_idTarget1 = rRole1.id;

                        if (rRole2 != null)
                        {
                            rCheckAgentDefault.Emp_idTarget2 = rRole2.Emp_id;
                            rCheckAgentDefault.Role_idTarget2 = rRole2.id;

                            if (rRole3 != null)
                            {
                                rCheckAgentDefault.Emp_idTarget3 = rRole3.Emp_id;
                                rCheckAgentDefault.Role_idTarget3 = rRole3.id;
                            }
                        }
                        else if (rRole3 != null)
                        {
                            rCheckAgentDefault.Emp_idTarget2 = rRole3.Emp_id;
                            rCheckAgentDefault.Role_idTarget2 = rRole3.id;
                        }
                    }
                    else if (rRole2 != null)
                    {
                        rCheckAgentDefault.Emp_idTarget1 = rRole2.Emp_id;
                        rCheckAgentDefault.Role_idTarget1 = rRole2.id;

                        if (rRole3 != null)
                        {
                            rCheckAgentDefault.Emp_idTarget2 = rRole3.Emp_id;
                            rCheckAgentDefault.Role_idTarget2 = rRole3.id;
                        }
                    }
                    else if (rRole3 != null)
                    {
                        rCheckAgentDefault.Emp_idTarget1 = rRole3.Emp_id;
                        rCheckAgentDefault.Role_idTarget1 = rRole3.id;
                    }

                    dcFlow.CheckAgentDefault.InsertOnSubmit(rCheckAgentDefault);
                }

                dcFlow.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}