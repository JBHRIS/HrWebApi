using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ezEngineServices
{
    public class COrg
    {
        private dcFlowDataContext dcFlow;
        private string _ConnectionString;

        public COrg()
        {
            dcFlow = new dcFlowDataContext();
            _ConnectionString = dcFlow.Connection.ConnectionString;
        }

        /// <summary>
        /// COrg
        /// </summary>
        /// <param name="conn"></param>
        public COrg(IDbConnection conn)
        {
            _ConnectionString = conn.ConnectionString;
            dcFlow = new dcFlowDataContext(conn);
        }

        /// <summary>
        /// COrg
        /// </summary>
        /// <param name="ConnectionString"></param>
        public COrg(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            dcFlow = new dcFlowDataContext(ConnectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public COrg(dcFlowDataContext dcFlow)
        {
            _ConnectionString = dcFlow.Connection.ConnectionString;
            this.dcFlow = dcFlow;
        }

        //取得代理人
        public CMan GetAgent(int idProcess, string Role_idSource, string Emp_idSource)
        {
            //資料宣告
            CMan Man = null;
            string FlowTree_id = "";

            //找出表單id，如果傳進來的是子流程，則找出主流程序
            var rProcessMultiFlow = (from c in dcFlow.ProcessMultiFlow
                                     where c.SubProcessFlow_id == idProcess
                                     select c).FirstOrDefault();

            if (rProcessMultiFlow != null)
            {
                idProcess = rProcessMultiFlow.ProcessFlow_id.Value;
                FlowTree_id = rProcessMultiFlow.SubFlowTree_id;
            }

            var rProcessFlow = (from c in dcFlow.ProcessFlow
                                join r in dcFlow.Role on new { Role = c.Role_id, Emp = c.Emp_id } equals new { Role = r.id, Emp = r.Emp_id }
                                join d in dcFlow.Dept on r.Dept_id equals d.id
                                where c.id == idProcess
                                select new
                                {
                                    FlowTree_id = c.FlowTree_id,
                                    DeptId = d.id,
                                    DeptName = d.name,
                                    DeptPath = d.path,
                                }).FirstOrDefault();

            if (rProcessFlow != null)
            {
                FlowTree_id = rProcessFlow.FlowTree_id;

                if (FlowTree_id.Length > 0)
                {
                    DateTime dDate = DateTime.Now;

                    //角色生效而且不在代理的區間
                    var rsCheckAgentSql = from c in dcFlow.CheckAgent
                                          where c.Role_idSource == Role_idSource
                                          && c.Emp_idSource == Emp_idSource
                                          && (from r in dcFlow.Role
                                              where dDate.Date >= r.dateB.GetValueOrDefault(dDate).Date
                                              && dDate.Date <= r.dateE.GetValueOrDefault(dDate).Date
                                              && r.id == c.Role_idTarget
                                              && r.Emp_id == c.Emp_idTarget
                                              select 1).Any()
                                          && !(from e in dcFlow.EmpAgentDate
                                               where e.Emp_id == c.Emp_idTarget
                                               && dDate >= e.dateB
                                               && dDate <= e.dateE
                                               && e.IsValid
                                               select 1).Any()
                                          orderby c.Sort
                                          select c;

                    //可代理的單據
                    var rsCheckAgentFlowTree = (from c in dcFlow.CheckAgentFlowTree
                                                where (from d in rsCheckAgentSql where d.Guid == c.CheckAgent_Guid select 1).Any()
                                                select c).ToList();

                    //可簽核的部門
                    var rsCheckAgentDept = (from c in dcFlow.CheckAgentDept
                                            join e in dcFlow.Dept on c.Dept_id equals e.id
                                            where (from d in rsCheckAgentSql where d.Guid == c.CheckAgent_Guid select 1).Any()
                                            select new { c, e.name }).ToList();

                    var rsCheckAgent = rsCheckAgentSql.ToList();

                    foreach (var rCheckAgent in rsCheckAgent)
                    {
                        var rsCheckAgentFlowTreeWhere = rsCheckAgentFlowTree.Where(p => p.CheckAgent_Guid == rCheckAgent.Guid).ToList();
                        if (rsCheckAgentFlowTreeWhere.Count == 0 || rsCheckAgentFlowTreeWhere.Where(p => p.FlowTree_id == FlowTree_id).Any())
                        {
                            var rsCheckAgentDeptWhere = rsCheckAgentDept.Where(p => p.c.CheckAgent_Guid == rCheckAgent.Guid).ToList();
                            if (rsCheckAgentDeptWhere.Count == 0
                                || rsCheckAgentDeptWhere.Where(p => p.c.Dept_id == rProcessFlow.DeptId).Any()
                                || rsCheckAgentDeptWhere.Where(p => rProcessFlow.DeptPath.IndexOf(p.name) >= 0 && p.c.IsAllSub.Value).Any())
                            {
                                Man = new CMan();
                                Man.idRole = rCheckAgent.Role_idTarget;
                                Man.idEmp = rCheckAgent.Emp_idTarget;

                                break;
                            }
                        }
                    }
                }
            }

            return Man;
        }

        //取得主管
        public CMan GetManager(int idProcess, string Role_idMinion, bool EmpSameUp = true)
        {
            CMan Man = null;

            DateTime dDate = DateTime.Now.Date;

            //分兩個階段找主管 先從角色找主管 再從部門找主管 角色先找到就先出去

            bool IsGo = true;

            do
            {
                //先採用角色取得上層主管
                var rRole = (from r in dcFlow.Role
                             where r.id == Role_idMinion
                             && dDate.Date >= r.dateB.GetValueOrDefault(dDate).Date
                             && dDate.Date <= r.dateE.GetValueOrDefault(dDate).Date
                             //&& r.idParent.Length > 0
                             select r).FirstOrDefault();

                if (rRole != null)
                {
                    Role_idMinion = rRole.idParent;
                    string sNobr = rRole.Emp_id;    //最原始的工號
                    string sDept = rRole.Dept_id;

                    //尋找上層角色的工號
                    var rRoleParent = (from r in dcFlow.Role
                                       where r.id == Role_idMinion
                                       && dDate.Date >= r.dateB.GetValueOrDefault(dDate).Date
                                       && dDate.Date <= r.dateE.GetValueOrDefault(dDate).Date
                                       && r.deptMg.Value    //判斷一定要是主管
                                       select r).FirstOrDefault();

                    //有找到上層角色 且本層與上層角色id不可以相同
                    if (rRoleParent != null && rRole.id != rRoleParent.id)
                    {
                        bool IsOK = true;

                        //如果遇到上層與本層同工號是否要繼續向上
                        if (rRoleParent.Emp_id == sNobr)
                            IsOK = !EmpSameUp;

                        if (IsOK)
                        {
                            Man = new CMan();
                            Man.idRole = rRoleParent.id;
                            Man.idEmp = rRoleParent.Emp_id;

                            IsGo = false;
                            break;
                        }
                    }
                    else  //有可能上層角色是空白的 所以必須要用部門來判斷
                    {
                        CProcess oCProcess = new CProcess(dcFlow);
                        oCProcess.WriteProcessException(idProcess, 0, 0, MsgType.Warning, "警告：" + rRole.id + "/" + rRole.Emp_id + "從角色裡無法找到主管");

                        //角色不存在 則採用部門向上尋找
                        Dept rDept = null;

                        do
                        {
                            rDept = (from d in dcFlow.Dept
                                     where d.id == sDept
                                     select d).FirstOrDefault();

                            if (rDept == null)
                            {
                                IsGo = false;
                                break;
                            }

                            //把上層部門記下來 準備下次搜尋
                            sDept = rDept.idParent;

                            //用找到的部門到角色裡尋找主管
                            var rRoleManage = (from r in dcFlow.Role
                                               where r.Dept_id == rDept.id
                                               && r.id != rRole.id
                                               && dDate.Date >= r.dateB.GetValueOrDefault(dDate).Date
                                               && dDate.Date <= r.dateE.GetValueOrDefault(dDate).Date
                                               && r.deptMg.Value
                                               orderby r.Emp_id
                                               select r).FirstOrDefault();

                            //一定要找到角色 而且角色不能等於原本的角色 第一次進來 有可能自己就是主管
                            if (rRoleManage != null && rRole != rRoleManage)
                            {
                                bool IsOK = true;

                                //如果遇到上層與本層同工號是否要繼續向上
                                if (rRoleManage.Emp_id == sNobr)
                                    IsOK = !EmpSameUp;

                                if (IsOK)
                                {
                                    Man = new CMan();
                                    Man.idRole = rRoleManage.id;
                                    Man.idEmp = rRoleManage.Emp_id;

                                    IsGo = false;
                                    break;
                                }
                            }

                            //目前部門跟上層部門相同
                            if (rDept.id == rDept.idParent)
                            {
                                IsGo = false;
                                break;
                            }
                        } while (IsGo);
                    }
                }
                else
                    IsGo = false;

            } while (IsGo);

            return Man;
        }

        //判斷是否是主管
        public bool IsManage(string Role, string Nobr)
        {
            var r = (from c in dcFlow.Role
                     where c.id == Role
                     && c.Emp_id == Nobr
                     && c.deptMg.Value
                     select c).FirstOrDefault();

            return r != null;
        }

        //檢驗主官是否為該部門的主管 下一關的部門path應該被上一關的部門path包含
        public bool IsDeptPathTrue(string OldRole, string NewRole)
        {
            string PathOld = (from r in dcFlow.Role
                              join d in dcFlow.Dept on r.Dept_id equals d.id
                              where r.id == OldRole
                              select d.path).FirstOrDefault();

            string PathNew = (from r in dcFlow.Role
                              join d in dcFlow.Dept on r.Dept_id equals d.id
                              where r.id == NewRole
                              select d.path).FirstOrDefault();

            if (PathOld == null || PathNew == null)
                return false;

            return PathOld.IndexOf(PathNew) >= 0;
        }

        //取得流程起始者
        public CMan GetFlowInit(int idProcess)
        {
            CMan Man = null;

            var rProcessFlow = (from c in dcFlow.ProcessFlow
                                where c.id == idProcess
                                select c).FirstOrDefault();

            if (rProcessFlow != null)
            {
                Man = new CMan();
                Man.idRole = rProcessFlow.Role_id;
                Man.idEmp = rProcessFlow.Emp_id;
            }

            return Man;
        }

        //會簽起始者
        public CMan GetMultiInit(int idProcess, string idFlowNode_MultiStart)
        {
            CMan Man = null;

            var rProcessCheck = (from pn in dcFlow.ProcessNode
                                 join pc in dcFlow.ProcessCheck on pn.auto equals pc.ProcessNode_auto
                                 where pn.ProcessFlow_id == idProcess
                                 && pn.FlowNode_id == idFlowNode_MultiStart
                                 select pc).FirstOrDefault();

            if (rProcessCheck != null)
            {
                Man = new CMan();
                Man.idRole = rProcessCheck.Role_idReal;
                Man.idEmp = rProcessCheck.Emp_idReal;
            }
            return Man;
        }

        //自訂簽核者
        public CMan GetCustom(string idFlowNode_Custom)
        {
            CMan Man = null;

            var rNodeCustom = (from c in dcFlow.NodeCustom
                               where c.FlowNode_id == idFlowNode_Custom
                               && c.Role_id.Trim().Length > 0
                               //&& c.Emp_id.Trim().Length > 0
                               select c).FirstOrDefault();

            if (rNodeCustom != null)
            {
                if (rNodeCustom.Emp_id.Trim().Length > 0)
                {
                    Man = new CMan();
                    Man.idRole = rNodeCustom.Role_id;
                    Man.idEmp = rNodeCustom.Emp_id;
                }
                else
                {
                    //給同角色的人員
                    DateTime dDate = DateTime.Now;
                    var rRole = (from r in dcFlow.Role
                                 where r.id == rNodeCustom.Role_id
                                 && dDate.Date >= r.dateB.GetValueOrDefault(dDate).Date
                                 && dDate.Date <= r.dateE.GetValueOrDefault(dDate).Date
                                 orderby r.Emp_id
                                 select r).FirstOrDefault();

                    if (rRole != null)
                    {
                        Man = new CMan();
                        Man.idRole = rRole.id;
                        Man.idEmp = rRole.Emp_id;
                    }
                }
            }

            return Man;
        }

        //動態簽核者
        public CMan GetDynamic(int idProcess, string idFlowNode_Dynamic)
        {
            CMan Man = null;

            var rDynamic = (from c in dcFlow.wfDynamic
                            where c.idProcess == idProcess
                            && c.idFlowNode == idFlowNode_Dynamic
                            && c.Role_id.Length > 0
                            select c).FirstOrDefault();

            if (rDynamic != null)
            {
                if (rDynamic.Emp_id.Trim().Length > 0)
                {
                    Man = new CMan();
                    Man.idRole = rDynamic.Role_id;
                    Man.idEmp = rDynamic.Emp_id;
                }
                else
                {
                    //給同角色的人員
                    DateTime dDate = DateTime.Now;
                    var rRole = (from r in dcFlow.Role
                                 where r.id == rDynamic.Role_id
                                 && dDate.Date >= r.dateB.GetValueOrDefault(dDate).Date
                                 && dDate.Date <= r.dateE.GetValueOrDefault(dDate).Date
                                 orderby r.Emp_id
                                 select r).FirstOrDefault();

                    if (rRole != null)
                    {
                        Man = new CMan();
                        Man.idRole = rRole.id;
                        Man.idEmp = rRole.Emp_id;
                    }
                }
            }

            return Man;
        }

        //代理起始者
        public CMan GetAgentInit(int idProcess)
        {
            CMan Man = null;

            var rProcessFlowShare = (from c in dcFlow.ProcessFlowShare
                                     where c.ProcessFlow_id == idProcess
                                     && c.isStarter.GetValueOrDefault(false)
                                     select c).FirstOrDefault();

            if (rProcessFlowShare != null)
            {
                Man = new CMan();
                Man.idRole = rProcessFlowShare.Role_id;
                Man.idEmp = rProcessFlowShare.Emp_id;
            }

            return Man;
        }
    }
}