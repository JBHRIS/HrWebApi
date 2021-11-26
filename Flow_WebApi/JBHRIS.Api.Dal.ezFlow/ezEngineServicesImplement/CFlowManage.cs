using JBHRIS.Api.Dal.ezEngineServices;
using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dto.Vdb;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace JBHRIS.Api.Dal.ezFlow.ezEngineServicesImplement
{


    /// <summary>
    /// 2021/02/05
    /// WorkFinish 有重複注入
    /// FlowStart  有重複注入 
    /// </summary>
    public class CFlowManage : ICFlowManage_Dal
    {
        private ezFlowContext _context;
        private ICProcess_Dal _ICProcessInterface;
        
        /// <summary>
        /// 重複注入
        /// </summary>
        //private IServiceInterface _IServiceInterface;
        private ICFlowInterface _ICFlowInterface;

        public CFlowManage(ezFlowContext context 
                            ,ICProcess_Dal cProcessInterface
                            //,IServiceInterface serviceInterface
                            ,ICFlowInterface cFlowInterface
            )
        {
            this._context = context;
            this._ICProcessInterface = cProcessInterface;
            //this._IServiceInterface = serviceInterface;
            this._ICFlowInterface = cFlowInterface;
        }


        /// <summary>
        /// 刪除整個流程
        /// </summary>
        /// <param name="ProcessFlowId"></param>
        /// <returns></returns>
        public bool DeleteProcessFlow(int ProcessFlowId)
        {
            bool Vdb = false;

            var rProcessFlow = (from c in this._context.ProcessFlows
                                where c.id == ProcessFlowId
                                select c).FirstOrDefault();

            if (rProcessFlow != null)
            {
                //改變ProcessFlow的狀態為取消
                rProcessFlow.isCancel = true;
                rProcessFlow.isError = false;
                rProcessFlow.isFinish = false;

                var rsProcessNode = (from c in this._context.ProcessNodes
                                     where c.ProcessFlow_id == ProcessFlowId
                                     orderby c.auto
                                     select c).ToList();

                //刪除多向下所有節點
                foreach (var rNode in rsProcessNode)
                {
                    this._context.ProcessNodes.Remove(rNode);

                    if (rNode.isMulti.Value)
                    {
                        var rsProcessMultiFlow = (from c in this._context.ProcessMultiFlows
                                                  where c.ProcessFlow_id == ProcessFlowId
                                                  && c.ProcessNode_auto == rNode.auto
                                                  orderby c.auto
                                                  select c).ToList();

                        //遞回 刪除所有子流程相關節點
                        foreach (var rProcessMultiFlow in rsProcessMultiFlow)
                            DeleteProcessFlow(rProcessMultiFlow.SubProcessFlow_id.Value);
                    }
                }

                Vdb = true;
            }

            return Vdb;
        }

        /// <summary>
        /// 以ProcessNodeAuto向下刪除節點(本節點不刪除)
        /// </summary>
        /// <param name="ProcessNodeAuto">ProcessNodeAuto</param>
        /// <returns>bool</returns>
        public bool DeleteProcessNode(int ProcessNodeAuto)
        {
            bool Vdb = false;

            //利用ProcessNode反找出ProcessFlow_id
            var rProcessNode = (from c in this._context.ProcessNodes
                                where c.auto == ProcessNodeAuto
                                select c).FirstOrDefault();

            if (rProcessNode != null)
            {
                var rProcessFlow = (from c in this._context.ProcessFlows
                                    where c.id == rProcessNode.ProcessFlow_id
                                    select c).FirstOrDefault();

                if (rProcessFlow != null)
                {
                    //改變ProcessFlow的狀態為未簽結
                    rProcessFlow.isCancel = false;
                    rProcessFlow.isError = false;
                    rProcessFlow.isFinish = false;

                    var rsProcessNode = (from c in this._context.ProcessNodes
                                         where c.ProcessFlow_id == rProcessNode.ProcessFlow_id
                                         && c.auto >= ProcessNodeAuto
                                         orderby c.auto
                                         select c).ToList();

                    //刪除多向下所有節點
                    foreach (var rNode in rsProcessNode)
                    {
                        var rsProcessMultiFlow = (from c in this._context.ProcessMultiFlows
                                                  where c.ProcessFlow_id == rProcessNode.ProcessFlow_id
                                                  && c.ProcessNode_auto == rNode.auto
                                                  orderby c.auto
                                                  select c).ToList();

                        if (rNode.auto == rProcessNode.auto)
                        {
                            //改變ProcessNode的簽核狀態為未簽核
                            rNode.isFinish = false;
                            rNode.adate = DateTime.Now;

                            //若為剛好刪除為子流程 則重新啟動子流程內的節點為初始狀態
                            if (rNode.isMulti.Value)
                            {
                                foreach (var rProcessMultiFlow in rsProcessMultiFlow)
                                {
                                    var rSubProcessNode = (from c in this._context.ProcessNodes
                                                           where c.ProcessFlow_id == rProcessMultiFlow.SubProcessFlow_id
                                                           orderby c.auto
                                                           select c).FirstOrDefault();

                                    if (rSubProcessNode != null)
                                    {
                                        //遞回 重置所有子流程 及其 無限子流程的初始狀態
                                        DeleteProcessNode(rSubProcessNode.auto);
                                    }
                                }
                            }

                        }
                        else
                        {
                            //其它節點 則全部刪除
                            this._context.ProcessNodes.Remove(rNode);

                            //若為子流程 則找出所有子流程一併清除
                            if (rNode.isMulti.Value)
                            {
                                //遞回 刪除所有子流程相關節點
                                foreach (var rProcessMultiFlow in rsProcessMultiFlow)
                                {
                                    DeleteProcessFlow(rProcessMultiFlow.SubProcessFlow_id.Value);
                                }
                            }
                                
                        }
                    }   //end foreach

                    this._context.SaveChanges();

                    Vdb = true;
                }
            }

            return Vdb;
        }


        /// <summary>
        /// 流程重送(含上點重送)
        /// </summary>
        /// <param name="lsProcessID">流程編號</param>
        /// <param name="bPreviousStep">是否上點送重</param>
        /// <param name="idEmp_Agent">代理啟單人工號</param>
        /// <returns>List int</returns>
        public List<int> FlowResubmit(List<int> lsProcessID, string idEmp_Agent, bool bPreviousStep = false)
        {
            

            var rsFlowTree = (from c in this._context.FlowTrees
                              select c).ToList();

            var rsProcessFlowSql = from pf in this._context.ProcessFlows
                                   where lsProcessID.Contains(pf.id)
                                   select pf;

            var rsProcessNodeSql = from pn in this._context.ProcessNodes
                                   where (from pf in rsProcessFlowSql where pn.ProcessFlow_id == pf.id select 1).Any()
                                   select pn;

            var rsProcessCheckSql = from pc in this._context.ProcessChecks
                                    where (from pn in rsProcessNodeSql where pc.ProcessNode_auto == pn.auto select 1).Any()
                                    select pc;

            var rsProcessFlowShareSql = from pfs in this._context.ProcessFlowShares
                                        where (from pf in rsProcessFlowSql where pfs.ProcessFlow_id == pf.id select 1).Any()
                                        select pfs;

            var rsProcessApParm = (from pa in this._context.ProcessApParms
                                   where (from pf in rsProcessFlowSql where pa.ProcessFlow_id == pf.id select 1).Any()
                                   select pa).ToList();

            var rsProcessApView = (from pa in this._context.ProcessApViews
                                   where (from pf in rsProcessFlowSql where pa.ProcessFlow_id == pf.id select 1).Any()
                                   select pa).ToList();

            var rsRole = (from r in this._context.Roles
                          where (from pf in rsProcessFlowSql where r.Emp_id == pf.Emp_id select 1).Any()
                          select r).ToList();

            var rsForm = (from c in this._context.Forms
                          select c).ToList();

            var rsFormApp = (from pa in this._context.FormsApps
                             where (from pf in rsProcessFlowSql where pa.idProcess == pf.id select 1).Any()
                             select pa).ToList();

            var rsFormAppInfo = (from f in this._context.FormsAppInfos
                                 where (from pf in rsProcessFlowSql where f.idProcess == pf.id select 1).Any()
                                 select f).ToList();

            var rsFormSignM = (from f in this._context.FormsSigns
                               where (from pf in rsProcessFlowSql where f.idProcess == pf.id select 1).Any()
                               select f).ToList();

            var rsProcessFlow = rsProcessFlowSql.ToList();
            var rsProcessNode = rsProcessNodeSql.ToList();
            var rsProcessCheck = rsProcessCheckSql.ToList();
            var rsProcessFlowShare = rsProcessFlowShareSql.ToList();

            List<FlowResubmitRow> lsFlowResubmitRow = new List<FlowResubmitRow>();
            List<ProcessFlow> lsDeleteProcessFlow = new List<ProcessFlow>();
            List<ProcessNode> lsDeleteProcessNode = new List<ProcessNode>();
            List<ProcessCheck> lsDeleteProcessCheck = new List<ProcessCheck>();
            List<ProcessFlowShare> lsDeleteProcessFlowShare = new List<ProcessFlowShare>();
            List<ProcessApParm> lsDeleteProcessApParm = new List<ProcessApParm>();
            List<ProcessApView> lsDeleteProcessApView = new List<ProcessApView>();
            List<wfFormSignM> lsDeleteFormSignM = new List<wfFormSignM>();

            string idRole_Agent = "";
            if (idEmp_Agent.Length > 0)
            {
                var rEmpAgent = (from c in this._context.Roles
                                 where c.Emp_id == idEmp_Agent
                                 select c).FirstOrDefault();

                if (rEmpAgent != null)
                    idRole_Agent = rEmpAgent.id;
            }

            foreach (var rProcessFlow in rsProcessFlow)
            {
                var rFlowTree = rsFlowTree.Where(p => p.id == rProcessFlow.FlowTree_id).FirstOrDefault();

                if (rFlowTree != null)
                {
                    var rFormApp = rsFormApp.Where(p => p.idProcess == rProcessFlow.id).FirstOrDefault();
                    if (rFormApp != null)
                    {
                        bool bReSend = false;

                        var rsProcessNodeWhere = rsProcessNode.Where(p => p.ProcessFlow_id == rProcessFlow.id).ToList();

                        //部門層級會影響上點重送造成的錯誤

                        //上點重送
                        if (bPreviousStep)
                        {
                            if (rsProcessNodeWhere.Count > 0)
                            {
                                rsProcessNodeWhere = rsProcessNode.Where(p => p.ProcessFlow_id == rProcessFlow.id).OrderByDescending(p => p.auto).ToList();

                                //一筆以上 才有重送的機會 上點重送
                                if (rsProcessNodeWhere.Count > 1)
                                {
                                    var rProcessNodeWhere = rsProcessNodeWhere.First();

                                    //把上點的Node記下來 等下要重送用
                                    int iProcessNode_idPrior = rProcessNodeWhere.ProcessNode_idPrior.Value;

                                    var rsProcessCheckWhere = rsProcessCheck.Where(p => p.ProcessNode_auto == rProcessNodeWhere.auto).ToList();
                                    if (rsProcessCheckWhere.Count > 0)
                                    {
                                        var rsProcessApParmWhere = (from p in rsProcessApParm
                                                                    where p.ProcessFlow_id == rProcessFlow.id
                                                                    && p.ProcessNode_auto == rProcessNodeWhere.auto
                                                                    && (from pc in rsProcessCheckWhere where p.ProcessCheck_auto == pc.auto select 1).Any()
                                                                    select p).ToList();

                                        var rProcessNotePrior = rsProcessNode.Where(p => p.auto == iProcessNode_idPrior).FirstOrDefault();
                                        if (rProcessNotePrior != null)
                                        {
                                            //找出要重送的關鍵ApParm
                                            var rsProcessCheckPrior = rsProcessCheck.Where(p => p.ProcessNode_auto == iProcessNode_idPrior).ToList();

                                            if (rsProcessCheckPrior.Count > 0)
                                            {
                                                int iReSend = 0;
                                                foreach (var rProcessCheckPrior in rsProcessCheckPrior)
                                                {
                                                    var rProcessApParmPrior = (from p in rsProcessApParm
                                                                               where p.ProcessFlow_id == rProcessFlow.id
                                                                               && p.ProcessNode_auto == iProcessNode_idPrior
                                                                               && p.ProcessCheck_auto == rProcessCheckPrior.auto
                                                                               select p).FirstOrDefault();

                                                    if (rProcessApParmPrior != null)
                                                    {
                                                        FlowResubmitRow rFlowResubmitRow = new FlowResubmitRow();
                                                        rFlowResubmitRow.idProcess = rProcessFlow.id;
                                                        rFlowResubmitRow.idFlowTree = rProcessFlow.FlowTree_id;
                                                        rFlowResubmitRow.idRole_Start = rProcessFlow.Role_id;
                                                        rFlowResubmitRow.idEmp_Start = rProcessFlow.Emp_id;
                                                        rFlowResubmitRow.ApParmAuto = rProcessApParmPrior.auto;
                                                        rFlowResubmitRow.Type = FlowResubmitType.WorkFinish;
                                                        lsFlowResubmitRow.Add(rFlowResubmitRow);

                                                        iReSend++;
                                                    }
                                                }

                                                if (iReSend == rsProcessCheckPrior.Count)
                                                {
                                                    rProcessNotePrior.isFinish = false;
                                                    rProcessFlow.isError = false;
                                                    rProcessFlow.isFinish = false;

                                                    lsDeleteProcessApParm.AddRange(rsProcessApParmWhere);
                                                    lsDeleteProcessCheck.AddRange(rsProcessCheckWhere);
                                                    lsDeleteProcessNode.Add(rProcessNodeWhere);

                                                    bReSend = true;

                                                    //oCProcess.WriteProcessException(rProcessFlow.id, 0, 0, ErrorType.Msg, "訊息：流程上點重送成功");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //如果上點重送不成功 一律原點重送
                        if (!bReSend)
                        {
                            //刪除一切相關的資料進行重送
                            var rsProcessApParmWhere = rsProcessApParm.Where(p => p.ProcessFlow_id == rProcessFlow.id).ToList();
                            var rsProcessApViewWhere = rsProcessApView.Where(p => p.ProcessFlow_id == rProcessFlow.id).ToList();

                            var rsProcessCheckWhere = (from pc in rsProcessCheck
                                                       where (from pn in rsProcessNodeWhere where pc.ProcessNode_auto == pn.auto select 1).Any()
                                                       select pc).ToList();

                            //有可能角色被改變了 所以要驗証角色是否正確
                            var rsRoleWhere = rsRole.Where(p => p.Emp_id == rProcessFlow.Emp_id).ToList();
                            if (rsRoleWhere.Count > 0)
                            {
                                string sRoleID = rProcessFlow.Role_id;

                                var rRoleWhere = rsRoleWhere.Where(p => p.id == sRoleID).FirstOrDefault();
                                if (rRoleWhere == null)
                                    sRoleID = rsRoleWhere.First().id;

                                FlowResubmitRow rFlowResubmitRow = new FlowResubmitRow();
                                rFlowResubmitRow.idProcess = rProcessFlow.id;
                                rFlowResubmitRow.idFlowTree = rProcessFlow.FlowTree_id;
                                rFlowResubmitRow.idRole_Start = sRoleID;
                                rFlowResubmitRow.idEmp_Start = rProcessFlow.Emp_id;
                                rFlowResubmitRow.Type = FlowResubmitType.Start;
                                lsFlowResubmitRow.Add(rFlowResubmitRow);

                                lsDeleteProcessCheck.AddRange(rsProcessCheckWhere);
                                lsDeleteProcessApView.AddRange(rsProcessApViewWhere);
                                lsDeleteProcessApParm.AddRange(rsProcessApParmWhere);
                                lsDeleteProcessNode.AddRange(rsProcessNodeWhere);
                                lsDeleteProcessFlow.Add(rProcessFlow);

                                //刪除所有簽核資料
                                var rsFormSignM_Where = rsFormSignM.Where(p => p.idProcess == rProcessFlow.id).ToList();
                                this._context.FormsSigns.RemoveRange(rsFormSignM_Where);

                                bReSend = true;

                                
                            }
                        }

                        if (!bReSend)
                        {
                            this._ICProcessInterface.WriteProcessException(rProcessFlow.id, 0, 0, MsgType.Msg, "訊息：流程無法重送");
                        }
                        else
                        {
                            //改變流程狀態
                            rFormApp.SignState = "1";

                            rFormApp.Cond01 = "01";

                            var rFormAppInfo = rsFormAppInfo.Where(p => p.idProcess == rProcessFlow.id).FirstOrDefault();
                            if (rFormAppInfo != null)
                                rFormAppInfo.SignState = "1";
                        }
                    }
                    else
                    {
                        this._ICProcessInterface.WriteProcessException(rProcessFlow.id, 0, 0, MsgType.Msg, "訊息：" + rFlowTree.name + "流程無法重送：" + rProcessFlow.id.ToString() + "流程內容已不存在");
                        rProcessFlow.isCancel = true;
                    }
                }
                else
                {
                    this._ICProcessInterface.WriteProcessException(rProcessFlow.id, 0, 0, MsgType.Msg, "訊息：找不到流程結構FlowTree：" + rProcessFlow.id.ToString());
                    rProcessFlow.isCancel = true;
                }
            }

            this._context.ProcessApParms.RemoveRange(lsDeleteProcessApParm);
            this._context.ProcessApViews.RemoveRange(lsDeleteProcessApView);
            this._context.ProcessChecks.RemoveRange(lsDeleteProcessCheck);
            this._context.ProcessFlows.RemoveRange(lsDeleteProcessFlow);
            this._context.ProcessNodes.RemoveRange(lsDeleteProcessNode);

            this._context.SaveChanges();

            List<int> rsProcessID = new List<int>();
            foreach (var rFlowResubmitRow in lsFlowResubmitRow)
            {
                try
                {
                    //子資料表狀態 並不是都會有子流程
                    var rForm = rsForm.Where(p => p.FlowTreeId == rFlowResubmitRow.idFlowTree).FirstOrDefault();
                    if (rForm != null && rForm.Name.Length > 0)
                    {
                        this._context.Database.ExecuteSqlRaw("Update " + rForm.Name + " Set sState = '1' , bSign = '1' Where idProcess = " + rFlowResubmitRow.idProcess);
                    }
                    if (rFlowResubmitRow.Type == FlowResubmitType.Start)
                    {
                        //重複注入
                        //this._IServiceInterface.FlowStart(rFlowResubmitRow.idProcess, rFlowResubmitRow.idFlowTree, rFlowResubmitRow.idRole_Start, rFlowResubmitRow.idEmp_Start, idRole_Agent, idEmp_Agent);
                        this._ICProcessInterface.WriteProcessException(rFlowResubmitRow.idProcess, 0, 0, MsgType.Msg, "訊息：流程原點重送成功");
                    }
                    else if (rFlowResubmitRow.Type == FlowResubmitType.WorkFinish)
                    {
                        //重複注入
                        //this._IServiceInterface.WorkFinish(rFlowResubmitRow.ApParmAuto);
                        this._ICProcessInterface.WriteProcessException(rFlowResubmitRow.idProcess, 0, 0, MsgType.Msg, "訊息：流程上點重送成功");
                    }

                    rsProcessID.Add(rFlowResubmitRow.idProcess);
                }
                catch
                {
                    this._ICProcessInterface.WriteProcessException(rFlowResubmitRow.idProcess, 0, 0, MsgType.Msg, "訊息：流程重送失敗");
                }
            }

            return rsProcessID;
        }


        /// <summary>
        /// 簽核
        /// </summary>
        /// <param name="lsProcessID"></param>
        /// <param name="idEmp">簽核者工號</param>
        /// <returns>List int</returns>
        public void FlowSign(List<int> lsProcessID, string idEmp)
        {
            var rsProcessFlowSql = from pf in this._context.ProcessFlows
                                   where lsProcessID.Contains(pf.id)
                                   select pf;

            var rsFormApp = (from fa in this._context.FormsApps
                             where (from pf in rsProcessFlowSql where fa.idProcess == pf.id select 1).Any()
                             select fa).ToList();

            var rsForm = (from c in this._context.Forms
                          select c).ToList();

            var rsFormSignM = (from c in this._context.FormsSigns
                               where (from pf in rsProcessFlowSql where c.idProcess == pf.id select 1).Any()
                               select c).ToList();

            var rsProcessFlow = rsProcessFlowSql.ToList();

            var rEmpM = (from role in this._context.Roles
                         join emp in this._context.Emps on role.Emp_id equals emp.id
                         join dept in this._context.Depts on role.Dept_id equals dept.id
                         join pos in this._context.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == idEmp
                         select new
                         {
                             RoleId = role.id,
                             EmpNobr = emp.id,
                             EmpName = emp.name,
                             DeptCode = dept.id,
                             DeptName = dept.name,
                             JobCode = pos.id,
                             JobName = pos.name,
                             Auth = role.deptMg.Value,
                             DeptTree = dept.DeptLevel_id,
                         }).FirstOrDefault();

            List<int> rsProcessID = new List<int>();

            foreach (var rProcessFlow in rsProcessFlow)
            {
                if (rEmpM != null)
                {
                    var rForm = rsForm.Where(p => p.FlowTreeId == rProcessFlow.FlowTree_id).FirstOrDefault();

                    var rFormSignM = rsFormSignM.Where(p => p.EmpId == idEmp && p.idProcess == rProcessFlow.id).FirstOrDefault();

                    //寫入簽核資料
                    if (rFormSignM == null)
                    {
                        rFormSignM = new FormsSign();
                        this._context.FormsSigns.Add(rFormSignM);
                    }

                    rFormSignM.idProcess = rProcessFlow.id;
                    rFormSignM.FormsCode = rForm != null ? rForm.Code : "";
                    //rFormSignM.sFormName = rForm != null ? rForm.sFormName : "";
                    //rFormSignM.sKey1 = Guid.NewGuid().ToString();
                    rFormSignM.ProcessId = rFormSignM.idProcess.ToString();
                    //rFormSignM.sNobr = idEmp;
                    rFormSignM.EmpId = rEmpM.EmpNobr;
                    rFormSignM.EmpName = rEmpM.EmpName;
                    rFormSignM.RoleId = rEmpM.RoleId;
                    rFormSignM.DeptCode = rEmpM.DeptCode;
                    rFormSignM.DeptName = rEmpM.DeptName;
                    rFormSignM.JobCode = rEmpM.JobCode;
                    rFormSignM.JobName = rEmpM.JobName;
                    rFormSignM.Note = "";
                    rFormSignM.Sign = true;
                    rFormSignM.InsertDate = DateTime.Now;
                    rFormSignM.InsertMan = rEmpM.EmpNobr;

                    var rFormApp = rsFormApp.Where(p => p.idProcess == rProcessFlow.id).FirstOrDefault();
                    if (rFormApp != null)
                    {
                        rFormApp.Note = "";
                        rFormApp.Sign = true;
                        rFormApp.Cond01 = rEmpM.DeptTree;
                        rFormApp.SignState = !rFormApp.Sign ? "2" : rFormApp.SignState;
                        rFormApp.DateTimeD = DateTime.Now;

                        if (rForm != null)
                        {
                            this._context.Database.ExecuteSqlRaw("Update " + rForm.Name + " Set bSign = {0} , sState = {1} Where idProcess = {2}", true, rFormApp.SignState, rProcessFlow.id);
                        }
                    }
                }
            }

            this._context.SaveChanges();
        }

        /// <summary>
        /// 指定簽核人員
        /// </summary>
        /// <param name="lsProcessID"></param>
        /// <param name="Man_Default">簽核者 物件內容可只填工號</param>
        /// <param name="Man_Agent">代理簽核者 物件內容可只填工號</param>
        /// <returns>List int</returns>
        public List<int> FlowSignSet(List<int> lsProcessID, CMan Man_Default = null, CMan Man_Agent = null)
        {
            var rsProcessFlowSql = from pf in this._context.ProcessFlows
                                   where lsProcessID.Contains(pf.id)
                                   select pf;

            var rsProcessNodeSql = from pn in this._context.ProcessNodes
                                   where (from pf in rsProcessFlowSql where pn.ProcessFlow_id == pf.id select 1).Any()
                                   select pn;

            var rsProcessCheckSql = from pc in this._context.ProcessChecks
                                    where (from pn in rsProcessNodeSql where pc.ProcessNode_auto == pn.auto select 1).Any()
                                    select pc;

            var rsProcessApParm = (from pa in this._context.ProcessApParms
                                   where (from pf in rsProcessFlowSql where pa.ProcessFlow_id == pf.id select 1).Any()
                                   select pa).ToList();

            var rsProcessFlow = rsProcessFlowSql.ToList();
            var rsProcessNode = rsProcessNodeSql.ToList();
            var rsProcessCheck = rsProcessCheckSql.ToList();

            List<int> rsProcessID = new List<int>();

            if (Man_Default != null && Man_Default.idRole.Length == 0 && Man_Default.idEmp.Length > 0)
            {
                var rRole = (from c in this._context.Roles
                             where c.Emp_id == Man_Default.idEmp
                             select c).FirstOrDefault();

                if (rRole == null)
                    Man_Default = null;
                else
                    Man_Default.idRole = rRole.id;
            }

            if (Man_Agent != null && Man_Agent.idRole.Length == 0 && Man_Agent.idEmp.Length > 0)
            {
                var rRole = (from c in this._context.Roles
                             where c.Emp_id == Man_Agent.idEmp
                             select c).FirstOrDefault();

                if (rRole == null)
                    Man_Agent = null;
                else
                    Man_Agent.idRole = rRole.id;
            }

            if (Man_Agent == null && Man_Default == null)
                return rsProcessID;

            foreach (var rProcessFlow in rsProcessFlow)
            {
                var rProcessNode = rsProcessNode.Where(p => p.ProcessFlow_id == rProcessFlow.id).FirstOrDefault();
                if (rProcessNode != null)
                {
                    rProcessNode = rsProcessNode.Where(p => p.ProcessFlow_id == rProcessFlow.id).OrderByDescending(p => p.auto).First();

                    var rProcessCheck = rsProcessCheck.Where(p => p.ProcessNode_auto == rProcessNode.auto).FirstOrDefault();
                    if (rProcessCheck != null)
                    {
                        var rProcessApParm = rsProcessApParm.Where(p => p.ProcessFlow_id == rProcessFlow.id && p.ProcessNode_auto == rProcessNode.auto && p.ProcessCheck_auto == rProcessCheck.auto).FirstOrDefault();
                        if (rProcessApParm != null)
                        {
                            if (Man_Default != null)
                            {
                                rProcessCheck.Role_idDefault = Man_Default.idRole;
                                rProcessCheck.Emp_idDefault = Man_Default.idEmp;

                                rProcessApParm.Role_id = Man_Default.idRole;
                                rProcessApParm.Emp_id = Man_Default.idEmp;
                            }

                            if (Man_Agent != null)
                            {
                                rProcessCheck.Role_idAgent = Man_Agent.idRole;
                                rProcessCheck.Emp_idAgent = Man_Agent.idEmp;
                            }

                            rsProcessID.Add(rProcessFlow.id);
                        }
                    }
                }
            }

            this._context.SaveChanges();

            return rsProcessID;
        }

        /// <summary>
        /// 簽核
        /// </summary>
        /// <param name="lsProcessID"></param>
        /// <param name="idEmp">簽核者工號</param>
        ///  <param name="bSign">是否核准</param>
        /// <param name="sNote">意見</param>
        /// <returns>List int</returns>
        public List<int> FlowSignWorkFinish(List<int> lsProcessID, string idEmp, string sNote, bool bSign = true, bool EmpSameUp = true)
        {
            var rsProcessFlowSql = from pf in this._context.ProcessFlows
                                   where lsProcessID.Contains(pf.id)
                                   select pf;

            var rsProcessNodeSql = from pn in this._context.ProcessNodes
                                   where (from pf in rsProcessFlowSql where pn.ProcessFlow_id == pf.id select 1).Any()
                                   orderby pn.auto descending
                                   select pn;

            var rsProcessCheckSql = from pc in this._context.ProcessChecks
                                    where (from pn in rsProcessNodeSql where pc.ProcessNode_auto == pn.auto select 1).Any()
                                    select pc;

            var rsProcessApParm = (from pa in this._context.ProcessApParms
                                   where (from pf in rsProcessFlowSql where pa.ProcessFlow_id == pf.id select 1).Any()
                                   select pa).ToList();

            var rsFormApp = (from fa in this._context.FormsApps
                             where (from pf in rsProcessFlowSql where fa.idProcess == pf.id select 1).Any()
                             select fa).ToList();

            var rsForm = (from c in this._context.Forms
                          select c).ToList();

            var rsFormSignM = (from c in this._context.FormsSigns
                               where (from pf in rsProcessFlowSql where c.idProcess == pf.id select 1).Any()
                               select c).ToList();

            var rsProcessFlow = rsProcessFlowSql.ToList();
            var rsProcessNode = rsProcessNodeSql.ToList();
            var rsProcessCheck = rsProcessCheckSql.ToList();

            var rEmpM = (from role in this._context.Roles
                         join emp in this._context.Emps on role.Emp_id equals emp.id
                         join dept in this._context.Depts on role.Dept_id equals dept.id
                         join pos in this._context.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == idEmp
                         select new
                         {
                             RoleId = role.id,
                             EmpNobr = emp.id,
                             EmpName = emp.name,
                             DeptCode = dept.id,
                             DeptName = dept.name,
                             JobCode = pos.id,
                             JobName = pos.name,
                             Auth = role.deptMg.Value,
                             DeptTree = dept.DeptLevel_id,
                         }).FirstOrDefault();

            List<int> rsProcessID = new List<int>();

            foreach (var rProcessFlow in rsProcessFlow)
            {
                var rProcessNode = rsProcessNode.Where(p => p.ProcessFlow_id == rProcessFlow.id).FirstOrDefault();
                if (rProcessNode != null)
                {
                    rProcessNode = rsProcessNode.Where(p => p.ProcessFlow_id == rProcessFlow.id).OrderByDescending(p => p.auto).First();

                    var rProcessCheck = rsProcessCheck.Where(p => p.ProcessNode_auto == rProcessNode.auto).FirstOrDefault();
                    if (rProcessCheck != null)
                    {
                        var rEmpSign = (from role in this._context.Roles
                                        join dept in this._context.Depts on role.Dept_id equals dept.id
                                        where role.Emp_id == rProcessCheck.Emp_idDefault
                                        select new
                                        {
                                            DeptTree = dept.DeptLevel_id,
                                        }).FirstOrDefault();

                        var rProcessApParm = rsProcessApParm.Where(p => p.ProcessFlow_id == rProcessFlow.id && p.ProcessNode_auto == rProcessNode.auto && p.ProcessCheck_auto == rProcessCheck.auto).FirstOrDefault();
                        if (rProcessApParm != null)
                        {
                            if (rEmpM != null)
                            {
                                var rForm = rsForm.Where(p => p.FlowTreeId == rProcessFlow.FlowTree_id).FirstOrDefault();

                                var rFormSignM = rsFormSignM.Where(p => p.EmpId == idEmp && p.idProcess == rProcessFlow.id).FirstOrDefault();

                                //寫入簽核資料
                                if (rFormSignM == null)
                                {
                                    rFormSignM = new FormsSign();
                                    this._context.FormsSigns.Add(rFormSignM);
                                }

                                rFormSignM.idProcess = rProcessFlow.id;
                                rFormSignM.FormsCode = rForm != null ? rForm.Code : "";
                                //rFormSignM.FormName = rForm != null ? rForm.Name : "";
                                //rFormSignM.sKey1 = Guid.NewGuid().ToString();
                                rFormSignM.ProcessId = rFormSignM.idProcess.ToString();
                                //rFormSignM.sNobr = idEmp;
                                rFormSignM.EmpId = rEmpM.EmpNobr;
                                rFormSignM.EmpName = rEmpM.EmpName;
                                rFormSignM.RoleId = rEmpM.RoleId;
                                rFormSignM.DeptCode = rEmpM.DeptCode;
                                rFormSignM.DeptName = rEmpM.DeptName;
                                rFormSignM.JobCode = rEmpM.JobCode;
                                rFormSignM.JobName = rEmpM.JobName;
                                rFormSignM.Note = sNote;
                                rFormSignM.Sign = true;
                                rFormSignM.InsertDate = DateTime.Now;

                                var rFormApp = rsFormApp.Where(p => p.idProcess == rProcessFlow.id).FirstOrDefault();
                                if (rFormApp != null)
                                {
                                    rFormApp.Note = sNote;
                                    rFormApp.Sign = bSign;
                                    rFormApp.Cond01 = rEmpSign.DeptTree;
                                    rFormApp.SignState = !rFormApp.Sign ? "2" : rFormApp.SignState;
                                    rFormApp.DateTimeD = DateTime.Now;

                                    if (rForm != null)
                                    {
                                        this._context.Database.ExecuteSqlRaw("Update " + rForm.Name + " Set bSign = {0} , sState = {1} Where idProcess = {2}", bSign, rFormApp.SignState, rProcessFlow.id);
                                    }
                                }
                            }

                            this._context.SaveChanges();

                            
                            //重複注入
                            //if (this._IServiceInterface.WorkFinish(rProcessApParm.auto, EmpSameUp))
                            //{
                            //    rsProcessID.Add(rProcessFlow.id);
                            //}
                        }
                    }
                }
            }

            return rsProcessID;
        }

        /// <summary>
        /// 流程狀態設定
        /// </summary>
        /// <param name="lsProcessID"></param>
        /// <param name="State">狀態</param>
        /// <param name="idEmp">動作人工號</param>
        /// <returns>List int</returns>
        public List<int> FlowStateSet(List<int> lsProcessID, FlowState State, string idEmp)
        {
           

            string sState = "";
            string sSign = "0";
            switch (State)
            {
                case FlowState.Approve:
                    sState = "3";
                    sSign = "1";
                    break;
                case FlowState.Reject:
                    sState = "2";
                    break;
                case FlowState.Cancel:
                    sState = "4";
                    break;
                case FlowState.Delete:
                    sState = "5";
                    break;
                case FlowState.Take:
                    sState = "7";
                    break;
            }

            var rsProcessFlowSql = from pf in this._context.ProcessFlows
                                   where lsProcessID.Contains(pf.id)
                                   select pf;

            var rsProcessNodeSql = from pn in this._context.ProcessNodes
                                   where (from pf in rsProcessFlowSql where pn.ProcessFlow_id == pf.id select 1).Any()
                                   select pn;

            var rsProcessCheckSql = from pc in this._context.ProcessChecks
                                    where (from pn in rsProcessNodeSql where pc.ProcessNode_auto == pn.auto select 1).Any()
                                    select pc;

            var rsProcessFlowShareSql = from pfs in this._context.ProcessFlowShares
                                        where (from pf in rsProcessFlowSql where pfs.ProcessFlow_id == pf.id select 1).Any()
                                        select pfs;

            var rsProcessApParm = (from pa in this._context.ProcessApParms
                                   where (from pf in rsProcessFlowSql where pa.ProcessFlow_id == pf.id select 1).Any()
                                   select pa).ToList();

            var rsProcessApView = (from pa in this._context.ProcessApViews
                                   where (from pf in rsProcessFlowSql where pa.ProcessFlow_id == pf.id select 1).Any()
                                   select pa).ToList();

            var rsForm = (from c in this._context.Forms
                          select c).ToList();

            var rsFormApp = (from pa in this._context.FormsApps
                             where (from pf in rsProcessFlowSql where pa.idProcess == pf.id select 1).Any()
                             select pa).ToList();

            var rsFormAppInfo = (from f in this._context.FormsAppInfos
                                 where (from pf in rsProcessFlowSql where f.idProcess == pf.id select 1).Any()
                                 select f).ToList();

            var rsFormSignM = (from f in this._context.FormsSigns
                               where (from pf in rsProcessFlowSql where f.idProcess == pf.id select 1).Any()
                               select f).ToList();

            var rEmpM = (from role in this._context.Roles
                         join emp in this._context.Emps on role.Emp_id equals emp.id
                         join dept in this._context.Depts on role.Dept_id equals dept.id
                         join pos in this._context.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == idEmp
                         select new
                         {
                             RoleId = role.id,
                             EmpNobr = emp.id,
                             EmpName = emp.name,
                             DeptCode = dept.id,
                             DeptName = dept.name,
                             JobCode = pos.id,
                             JobName = pos.name,
                             Auth = role.deptMg.Value,
                         }).FirstOrDefault();

            var rsProcessFlow = rsProcessFlowSql.ToList();
            var rsProcessNode = rsProcessNodeSql.ToList();
            var rsProcessCheck = rsProcessCheckSql.ToList();
            var rsProcessFlowShare = rsProcessFlowShareSql.ToList();

            List<WebServiceRow> rsWebServiceRow = new List<WebServiceRow>();

            List<int> rsProcessID = new List<int>();

            foreach (var rProcessFlow in rsProcessFlow)
            {
                string sFormCode = "";
                string sFormName = "";

                var rForm = rsForm.Where(p => p.FlowTreeId == rProcessFlow.FlowTree_id).FirstOrDefault();
                if (rForm != null)
                {
                    //子資料表狀態 並不是都會有子流程
                    if (rForm.TableName.Length > 0)
                        if (State == FlowState.Delete)//刪除實體資料
                        {

                            this._context.Database.ExecuteSqlRaw("Delete From " + rForm.TableName + " Where idProcess = " + rProcessFlow.id);
                        }
                        else
                        {

                            this._context.Database.ExecuteSqlRaw("Update " + rForm.TableName + " Set SignState = '" + State + "' , Sign = " + sSign + " Where idProcess = " + rProcessFlow.id);

                            var rFormApp = rsFormApp.Where(p => p.idProcess == rProcessFlow.id).FirstOrDefault();
                            if (rFormApp != null)
                            {
                                rFormApp.SignState = sState;
                                rFormApp.Sign = sState == "3";
                            }

                            var rFormAppInfo = rsFormAppInfo.Where(p => p.idProcess == rProcessFlow.id).FirstOrDefault();

                            if (rFormAppInfo != null)
                                rFormAppInfo.SignState = sState;

                            sFormCode = rForm.Code;
                            sFormName = rForm.Name;
                        }

                    //只有核准或駁回才呼叫服務 這裡有一個問題 會與服務發生衝突(所以流程結束後再呼叫服務)
                    if (rForm.SaveMethod.Length > 0 && (State == FlowState.Approve || State == FlowState.Reject))
                    {
                        //核准或駁回都要將Node全部變成True以防止又被誤判出來
                        var rsProcessNodeWhere = rsProcessNode.Where(p => p.ProcessFlow_id == rProcessFlow.id).ToList();

                        foreach (var rProcessNodeWhere in rsProcessNodeWhere)
                            rProcessNodeWhere.isFinish = true;

                        if (true)
                        {
                            string Method = rForm.SaveMethod.Length > 0 ? rForm.SaveMethod : "Run";

                            string Url = rForm.SaveUrl;
                            int LastIndex = Url.LastIndexOf("/");
                            if (LastIndex >= 0)
                            {
                                string FileName = Url.Substring(LastIndex + 1);
                                string[] arr = FileName.Split('.');

                                var rProcessApView = rsProcessApView.Where(p => p.ProcessFlow_id == rProcessFlow.id).FirstOrDefault();

                                if (rProcessApView != null && arr.Length == 2)
                                {
                                    WebServiceRow rWebServiceRow = new WebServiceRow();
                                    rWebServiceRow.idProcess = rProcessFlow.id;
                                    rWebServiceRow.ProcessApViewAuto = rProcessApView.auto;
                                    rWebServiceRow.ServiceUrl = rForm.SaveUrl;//WebService的http形式的地址
                                    rWebServiceRow.Namespace = "";//欲呼叫的WebService的命名空間
                                    rWebServiceRow.ClassName = arr[0];//欲呼叫的WebService的類名（不包括命名空間前綴）
                                    rWebServiceRow.MethodName = Method;//欲呼叫的WebService的方法名

                                    if (arr[1] == "asmx")
                                    {
                                        rWebServiceRow.Type = WebServiceType.asmx;
                                        rsWebServiceRow.Add(rWebServiceRow);
                                    }
                                    else if (arr[1] == "svc")
                                    {
                                        rWebServiceRow.Type = WebServiceType.svc;
                                        rsWebServiceRow.Add(rWebServiceRow);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        rsProcessID.Add(rProcessFlow.id);

                    }
                }

                if (State != FlowState.Delete)
                {
                    //寫入簽核資料
                    var rFormSignM = new wfFormSignM();
                    rFormSignM.idProcess = rProcessFlow.id;
                    rFormSignM.sFormCode = sFormCode;
                    rFormSignM.sFormName = sFormName;
                    //rFormSignM.sKey1 = Guid.NewGuid().ToString();
                    rFormSignM.sProcessID = rFormSignM.idProcess.ToString();
                    rFormSignM.sNobr = idEmp;
                    rFormSignM.sName = "Sys";
                    rFormSignM.sDeptName = "Top";
                    if (rEmpM != null)
                    {
                        rFormSignM.sNobr = rEmpM.EmpNobr;
                        rFormSignM.sName = rEmpM.EmpName;
                        rFormSignM.sRole = rEmpM.RoleId;
                        rFormSignM.sDept = rEmpM.DeptCode;
                        rFormSignM.sDeptName = rEmpM.DeptName;
                        rFormSignM.sJob = rEmpM.JobCode;
                        rFormSignM.sJobName = rEmpM.JobName;
                    }
                    rFormSignM.sNote = State.ToString();
                    rFormSignM.bSign = sState == "3";
                    rFormSignM.dKeyDate = DateTime.Now;
                    this._context.wfFormSignMs.Add(rFormSignM);

                    rProcessFlow.isFinish = false;
                    rProcessFlow.isError = false;
                    rProcessFlow.isCancel = false;

                    if (State == FlowState.Approve || State == FlowState.Reject) rProcessFlow.isFinish = true;
                    if (State == FlowState.Cancel || State == FlowState.Take) rProcessFlow.isCancel = true;
                }
            }

            //刪除一切相關資料 慎用！
            if (State == FlowState.Delete)
            {
                this._context.FormsSigns.RemoveRange(rsFormSignM);
                this._context.FormsAppInfos.RemoveRange(rsFormAppInfo);
                this._context.FormsApps.RemoveRange(rsFormApp);

                this._context.ProcessApViews.RemoveRange(rsProcessApView);
                this._context.ProcessApParms.RemoveRange(rsProcessApParm);
                this._context.ProcessFlowShares.RemoveRange(rsProcessFlowShare);
                this._context.ProcessChecks.RemoveRange(rsProcessCheck);
                this._context.ProcessNodes.RemoveRange(rsProcessNode);
                this._context.ProcessFlows.RemoveRange(rsProcessFlow);
            }

            this._context.SaveChanges();

            //開始呼叫服務
            foreach (var r in rsWebServiceRow)
            {
                if (r.Type == WebServiceType.asmx)
                {
                    object[] tArgs = new object[1];//參數列表  
                    tArgs[0] = r.ProcessApViewAuto;

                    try
                    {
                        object tReturnValue = this._ICFlowInterface.InvokeWebservice(r.ServiceUrl, r.Namespace, r.ClassName, r.MethodName, tArgs);rsProcessID.Add(r.idProcess);
                    }
                    catch (Exception ex)
                    {
                        this._ICProcessInterface.WriteProcessException(r.idProcess, 0, 0, MsgType.Msg, "訊息：呼叫動態服務失敗");
                    }
                }
                else if (r.Type == WebServiceType.svc)
                {
                    ////未完成
                    ////CFlow.WcfChannelFactory oWcfChannelFactory = new CFlow.WcfChannelFactory();
                    //try
                    //{
                    //    //未完成
                    //    //object o = oWcfChannelFactory.ExecuteMetod<IService>(r.ServiceUrl, r.MethodName, r.ProcessApViewAuto);
                    //    rsProcessID.Add(r.idProcess);
                    //}
                    //catch (Exception ex)
                    //{
                    //    this._ICProcessInterface.WriteProcessException(r.idProcess, 0, 0, MsgType.Msg, "訊息：呼叫動態服務失敗");
                    //}
                }
            }

            return rsProcessID;
        }

        /// <summary>
        /// 取得流程簽核清單
        /// </summary>
        /// <param name="idProcess">idProcess</param>
        /// <returns>List FlowSignRow</returns>
        public List<FlowSignRow> GetProcessNodeList(int idProcess)
        {
            var Vdb = (from pn in this._context.ProcessNodes
                       join pc in this._context.ProcessChecks on pn.auto equals pc.ProcessNode_auto into pn1
                       from pn1Row in pn1.DefaultIfEmpty()
                       join pf in this._context.ProcessFlows on pn.ProcessFlow_id equals pf.id
                       join fn in this._context.FlowNodes on pn.FlowNode_id equals fn.id
                       join ft in this._context.FlowTrees on pf.FlowTree_id equals ft.id
                       join e1 in this._context.Emps on pn1Row.Emp_idDefault equals e1.id into pc1
                       from pc1Row in pc1.DefaultIfEmpty()
                       join e2 in this._context.Emps on pn1Row.Emp_idAgent equals e2.id into pc2
                       from pc2Row in pc2.DefaultIfEmpty()
                       join e3 in this._context.Emps on pf.Emp_id equals e3.id into pf1
                       from pf1Row in pf1.DefaultIfEmpty()
                       join r1 in this._context.Roles on new { EmpId = pf.Emp_id, RoleId = pf.Role_id } equals new { EmpId = r1.Emp_id, RoleId = r1.id } into pf2
                       from pf2Row in pf2.DefaultIfEmpty()
                       join d1 in this._context.Depts on pf2Row.Dept_id equals d1.id into pf21
                       from pf21Row in pf21.DefaultIfEmpty()
                       join w in this._context.wfForms on pf.FlowTree_id equals w.sFlowTree into pf3
                       from pf3Row in pf3.DefaultIfEmpty()
                       where pn.ProcessFlow_id == idProcess
                       orderby pn.auto
                       select new FlowSignRow
                       {
                           ApParmID = 0,
                           ParmUrl = "",
                           ProcessID = pf.id,
                           ProcessCheckAuto = pn1Row != null ? pn1Row.auto : 0,
                           ProcessNodeAuto = pn.auto,
                           AppEmpId = pf.Emp_id,
                           AppRoleId = pf.Role_id,
                           AppName = pf1Row != null ? pf1Row.name : "",
                           AppDept = pf21Row != null ? pf21Row.name : "",
                           AppDeptPath = pf21Row != null ? pf21Row.path : "",
                           AppDate = pf.adate.Value,
                           FlowTreeId = ft.id,
                           FlowTreeName = ft.name,
                           FlowNodeId = fn.id,
                           FlowNodeName = fn.name,
                           NodeType = fn.nodeType,
                           CheckName = pc1Row != null ? pc1Row.name : "",
                           AgentName = pc2Row != null ? pc2Row.name : "",
                           CheckDate = pn.adate.GetValueOrDefault(DateTime.Now),
                           Multi = pn.isMulti.Value,
                           NodeFinish = pn.isFinish.Value,
                           PendingDay = Convert.ToInt32((DateTime.Now.Date - pn.adate.Value.Date).TotalDays),
                           Batch = pf3Row != null ? pf3Row.b1.GetValueOrDefault(true) : true,
                       }).ToList();

            foreach (var rVdb in Vdb)
            {
                var rsProcessMultiFlow = (from c in this._context.ProcessMultiFlows
                                          where c.ProcessFlow_id == rVdb.ProcessID
                                          && c.ProcessNode_auto == rVdb.ProcessNodeAuto
                                          orderby c.auto
                                          select c).ToList();

                foreach (var rProcessMultiFlow in rsProcessMultiFlow)
                {
                    rVdb.SubProcessIds += rProcessMultiFlow.SubProcessFlow_id.ToString() + ",";
                }
            }

            return Vdb.ToList();
        }
    }
}
