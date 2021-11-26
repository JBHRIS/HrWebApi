using JBHRIS.Api.Dal.ezEngineServices;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using JBHRIS.Api.Dto.Vdb;
using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using System.Transactions;
using JBHRIS.Api.Dal.ezEngineServices.Dao;

namespace JBHRIS.Api.Dal.ezFlow.ezEngineServicesImplement
{
    public class Service : IServiceInterface
    {

        private ezFlowContext _context;
        private ICNoticeInterface _ICNoticeInterface;
        private ICFlowManage_Dal _ICFlowManageInterface;
        private ICData_Dal _ICDataInterface;
        private ICProcess_Dal _ICProcessInterface;
        private ICFlowInterface _ICFlowInterface;
        private IEmpDaoInterface _IEmpDaoInterface;

        public Service(ezFlowContext context , 
                       ICNoticeInterface cNoticeInterface , 
                       ICFlowManage_Dal cFlowManageInterface , 
                       ICData_Dal cDataInterface,
                       ICProcess_Dal cProcessInterface,
                       ICFlowInterface cFlowInterface ,
                       IEmpDaoInterface empDaoInterface)
        {
            this._context = context;
            this._ICNoticeInterface = cNoticeInterface;
            this._ICFlowManageInterface = cFlowManageInterface;
            this._ICDataInterface = cDataInterface;
            this._ICProcessInterface = cProcessInterface;
            this._ICFlowInterface = cFlowInterface;
            this._IEmpDaoInterface = empDaoInterface;

        }


        /// <summary>
        /// 增加會簽流程
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="idSubFlowTree"></param>
        /// <param name="idSubInitRole"></param>
        /// <param name="idSubInitEmp"></param>
        /// <param name="idSubDynamicRole"></param>
        /// <param name="idSubDynamicEmp"></param>
        public void AddMultiFlow(int idProcess, string idSubFlowTree, string idSubInitRole, string idSubInitEmp, string idSubDynamicRole, string idSubDynamicEmp)
        {
            ProcessMultiFlow rowProcessMultiFlow = new ProcessMultiFlow();
            rowProcessMultiFlow.ProcessFlow_id = idProcess;
            rowProcessMultiFlow.ProcessNode_auto = 0;
            rowProcessMultiFlow.SubFlowTree_id = idSubFlowTree;
            rowProcessMultiFlow.SubInitRole_id = idSubInitRole;
            rowProcessMultiFlow.SubInitEmp_id = idSubInitEmp;
            rowProcessMultiFlow.SubDynamicRole_id = idSubDynamicRole;
            rowProcessMultiFlow.SubDynamicEmp_id = idSubDynamicEmp;
            this._context.ProcessMultiFlows.Add(rowProcessMultiFlow);

            this._context.SaveChanges();
        }


        /// <summary>
        /// 刪除代理人
        /// </summary>
        /// <param name="sGuid">key</param>
        /// <returns>bool</returns>
        public bool DelCheckAgent(string sGuid)
        {
            bool isOK = false;

            var r = (from c in this._context.CheckAgents
                     where c.Guid == sGuid
                     select c).FirstOrDefault();

            if (r != null)
            {

                var rs = (from c in this._context.CheckAgentFlowTrees
                          where c.CheckAgent_Guid == sGuid
                          select c).ToList();

                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        this._context.CheckAgentFlowTrees.RemoveRange(rs);
                        this._context.CheckAgents.Remove(r);

                        this._context.SaveChanges();

                        scope.Complete();

                        isOK = true;
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                    }
                }
            }

            return isOK;
        }


        /// <summary>
        /// 刪除可代理表單
        /// </summary>
        /// <param name="AutoKey">AutoKey</param>
        /// <returns>bool</returns>
        public bool DelCheckAgentFlowTree(int AutoKey)
        {
            bool isOK = false;

            var r = (from c in this._context.CheckAgentFlowTrees
                     where c.auto == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        this._context.CheckAgentFlowTrees.Remove(r);
                        this._context.SaveChanges();

                        scope.Complete();

                        isOK = true;
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                    }
                }
            }

            return isOK;
        }


        /// <summary>
        /// 刪除代理日期
        /// </summary>
        /// <param name="AutoKey">AutoKey</param>
        /// <returns>bool</returns>
        public bool DelEmpAgentDate(int AutoKey)
        {
            bool isOK = false;

            var r = (from c in this._context.EmpAgentDates
                     where c.auto == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        r.IsValid = false;
                        this._context.SaveChanges();

                        scope.Complete();

                        isOK = true;
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                    }
                }
            }

            return isOK;
        }

        /// <summary>
        /// 刪除動態角色
        /// </summary>
        /// <param name="idProcess">idProcess</param>
        /// <param name="idFlowNode">idFlowNode</param>
        /// <returns>bool</returns>
        public bool DeleteDynamic(int idProcess, string idFlowNode)
        {
            bool isOK = false;
            var rDynamic = (from c in this._context.wfDynamics
                            where c.idProcess == idProcess
                            && c.idFlowNode == idFlowNode
                            select c).FirstOrDefault();
            if (rDynamic != null)
            {
                this._context.wfDynamics.Remove(rDynamic);
            }
            this._context.SaveChanges();
            isOK = true;
            return isOK;
        }

        /// <summary>
        /// 刪除公告
        /// </summary>
        /// <param name="Guid">Guid</param>
        /// <returns>bool</returns>
        public bool DeleteNotice(string Guid)
        {
            return this._ICNoticeInterface.DeleteNotice(Guid);
        }


        /// <summary>
        /// 刪除整個流程
        /// </summary>
        /// <param name="ProcessFlowId">ProcessFlowId</param>
        /// <returns>bool</returns>
        public bool DeleteProcessFlow(int ProcessFlowId)
        {
            var Vdb = this._ICFlowManageInterface.DeleteProcessFlow(ProcessFlowId);
            return Vdb;
        }


        /// <summary>
        /// 以ProcessNodeAuto向下刪除節點(本節點不刪除)
        /// </summary>
        /// <param name="ProcessNodeAuto">ProcessNodeAuto</param>
        /// <returns>bool</returns>
        public bool DeleteProcessNode(int ProcessNodeAuto)
        {
            var Vdb = this._ICFlowManageInterface.DeleteProcessNode(ProcessNodeAuto);
            return Vdb;
        }


        /// <summary>
        /// 取得目前錯誤的流程id
        /// </summary>
        /// <returns>List int</returns>
        public List<int> FlowError()
        {
            var Vdb = (from pf in this._context.ProcessFlows
                       where (!pf.isCancel.Value
                       && pf.isError.Value  //如果只有isError是True
                       && !pf.isFinish.Value)
                       || (!pf.isCancel.Value
                       && !pf.isError.Value
                       && !pf.isFinish.Value    //如果流程正在進行中 但一筆node也不存在
                       && !(from pn in this._context.ProcessNodes where pf.id == pn.ProcessFlow_id select 1).Any())
                       || (!pf.isCancel.Value
                       && !pf.isError.Value
                       && !pf.isFinish.Value    //如果流程正在進行中 但所有node的資料都為true 代表流程已經中斷
                       && (from pn in this._context.ProcessNodes where pf.id == pn.ProcessFlow_id select 1).Any()
                       && !(from pn in this._context.ProcessNodes where !pn.isFinish.Value && pf.id == pn.ProcessFlow_id select 1).Any())
                       || (!pf.isCancel.Value
                       && !pf.isError.Value
                       && pf.isFinish.Value    //如果流程已經結束 但還有node是false
                       && (from pn in this._context.ProcessNodes where pf.id == pn.ProcessFlow_id select 1).Any()
                       && (from pn in this._context.ProcessNodes where !pn.isFinish.Value && pf.id == pn.ProcessFlow_id select 1).Any())
                       select pf.id).ToList();

            return Vdb;
        }


        /// <summary>
        /// 取得流程圖
        /// 未完成
        /// </summary>
        /// <param name="idProcess"></param>
        /// <returns>byte[]</returns>
        public byte[] FlowImage(int idProcess)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 取得流程圖
        /// 未完成
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="x">水平起始位置</param>
        /// <param name="y">垂直起始位置</param>
        /// <param name="iWidth">圖片寬度</param>
        /// <param name="iHeight">圖片高度</param>
        /// <param name="bHeader">是否要表頭</param>
        /// <returns>byte[]</returns>
        public byte[] FlowImage(int idProcess, int x = 0, int y = 0, int iWidth = 600, int iHeight = 0, bool bHeader = true)
        {
            throw new NotImplementedException();
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
            return this._ICFlowManageInterface.FlowResubmit(lsProcessID, idEmp_Agent , bPreviousStep );
        }


        /// <summary>
        /// 將流程分享給別人看
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="idRole_Share"></param>
        /// <param name="idEmp_Share"></param>
        public void FlowShare(int idProcess, string idRole_Share, string idEmp_Share)
        {
            var rProcessFlowShare = (from c in this._context.ProcessFlowShares
                                     where c.ProcessFlow_id == idProcess
                                     && c.Role_id == idRole_Share
                                     && c.Emp_id == idEmp_Share
                                     select c).FirstOrDefault();

            if (rProcessFlowShare == null)
            {
                rProcessFlowShare = new ProcessFlowShare();
                rProcessFlowShare.ProcessFlow_id = idProcess;
                rProcessFlowShare.Role_id = idRole_Share;
                rProcessFlowShare.Emp_id = idEmp_Share;
                rProcessFlowShare.isStarter = false;
                this._context.ProcessFlowShares.Add(rProcessFlowShare);
                this._context.SaveChanges();
            }
        }

        /// <summary>
        /// 簽核
        /// </summary>
        /// <param name="lsProcessID"></param>
        /// <param name="idEmp">簽核者工號</param>
        /// <returns>List int</returns>
        public void FlowSign(List<int> lsProcessID, string idEmp)
        {
            this._ICFlowManageInterface.FlowSign(lsProcessID, idEmp);
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
            return this._ICFlowManageInterface.FlowSignSet(lsProcessID, Man_Default, Man_Agent);
        }

        /// <summary>
        /// 簽核
        /// WorkFinish 
        /// </summary>
        /// <param name="lsProcessID"></param>
        /// <param name="idEmp">簽核者工號</param>
        /// <param name="bSign">是否核准</param>
        /// <param name="sNote">意見</param>
        /// <returns>List int</returns>
        public List<int> FlowSignWorkFinish(List<int> lsProcessID, string idEmp, string sNote, bool bSign = true, bool EmpSameUp = true)
        {


            //WorkFinish();

            return this._ICFlowManageInterface.FlowSignWorkFinish(lsProcessID, idEmp, sNote, bSign,  EmpSameUp);
        }


        /// <summary>
        /// 流程開始傳送
        /// </summary>
        /// <param name="idProcess">idProcess</param>
        /// <param name="idFlowTree">idFlowTree</param>
        /// <param name="idRole_Start">啟始角色</param>
        /// <param name="idEmp_Start">啟始工號</param>
        /// <param name="idRole_Agent">代理啟單人角色</param>
        /// <param name="idEmp_Agent">代理啟單人工號</param>
        /// <param name="EmpSameUp">遇到本點與上點審核者同一人時 是否要繼續向上</param>
        /// <param name="Man_Default">強迫填入審核者</param>
        /// <param name="Man_Agent">強迫填入代理審核者</param>
        /// <returns>bool</returns>
        public bool FlowStart(int idProcess, string idFlowTree, string idRole_Start, string idEmp_Start, string idRole_Agent, string idEmp_Agent, bool EmpSameUp = true, CMan Man_Default = null, CMan Man_Agent = null)
        {
            DateTime dDateNow = DateTime.Now;

            //如果流程失效，就無法繼續
            var rFlowTree = (from c in this._context.FlowTrees
                             where c.id == idFlowTree
                             //&& c.dateB.GetValueOrDefault(dDateNow) <= dDateNow
                             //&& c.dateE.GetValueOrDefault(dDateNow) >= dDateNow
                             select c).FirstOrDefault();

            if (rFlowTree == null)
            {
                this._ICProcessInterface.WriteProcessException(idProcess, 0, 0, MsgType.Warning, "原因：流程不存在或已失效");
                return false;
            }

            //如果流程沒有拉節點，就無法繼續
            var rFlowNode = (from c in this._context.FlowNodes
                             where c.FlowTree_id == idFlowTree
                             && c.nodeType == "1"
                             select c).FirstOrDefault();

            if (rFlowNode == null)
            {
                this._ICProcessInterface.WriteProcessException(idProcess, 0, 0, MsgType.Error, "原因：流程沒有拉開始節點");
                return false;
            }

            //如果 FlowLink 沒拉，也無法繼續 :(
            var rFlowLink = (from c in this._context.FlowLinks
                             where c.FlowTree_id == idFlowTree
                             && c.FlowNode_idSource == rFlowNode.id
                             select c).FirstOrDefault();

            if (rFlowLink == null)
            {
                this._ICProcessInterface.WriteProcessException(idProcess, 0, 0, MsgType.Error, "原因：開始節點沒有拉線到下一點");
                return false;
            }

            var rowProcessFlow = (from c in this._context.ProcessFlows
                                  where c.id == idProcess
                                  select c).FirstOrDefault();

            if (rowProcessFlow == null)
            {
                rowProcessFlow = new ProcessFlow();
                this._context.ProcessFlows.Add(rowProcessFlow);
            }

            rowProcessFlow.id = idProcess;
            rowProcessFlow.ProcessNode_auto = 0;
            rowProcessFlow.FlowTree_id = idFlowTree;
            rowProcessFlow.adate = DateTime.Now;
            rowProcessFlow.Role_id = idRole_Start;
            rowProcessFlow.Emp_id = idEmp_Start;
            rowProcessFlow.isFinish = false;
            rowProcessFlow.isError = false;
            rowProcessFlow.isCancel = false;
            rowProcessFlow.isMultiFlow = false;

            var rowProcessApView = (from c in this._context.ProcessApViews
                                    where c.ProcessFlow_id == idProcess
                                    select c).FirstOrDefault();

            if (rowProcessApView == null)
            {
                rowProcessApView = new ProcessApView();
                this._context.ProcessApViews.Add(rowProcessApView);
            }

            rowProcessApView.ProcessFlow_id = idProcess;
            rowProcessApView.Role_id = idRole_Start;
            rowProcessApView.Emp_id = idEmp_Start;
            rowProcessApView.tag1 = "";
            rowProcessApView.tag2 = "";
            rowProcessApView.tag3 = "";

            var rsProcessFlowShare = (from c in this._context.ProcessFlowShares
                                      where c.ProcessFlow_id == idProcess
                                      select c).ToList();

            if (!rsProcessFlowShare.Where(p => p.Emp_id == idEmp_Start).Any())
            {
                ProcessFlowShare rowProcessFlowShare = new ProcessFlowShare();
                rowProcessFlowShare.ProcessFlow_id = idProcess;
                rowProcessFlowShare.Role_id = idRole_Start;
                rowProcessFlowShare.Emp_id = idEmp_Start;
                rowProcessFlowShare.isStarter = false;
                this._context.ProcessFlowShares.Add(rowProcessFlowShare);
            }

            //申請人 與 被申請人不同的情況下 才需要多寫入一筆
            if (idEmp_Start != idEmp_Agent)
            {
                if (idRole_Agent.Trim().Length > 0 && !rsProcessFlowShare.Where(p => p.Emp_id == idEmp_Agent).Any())
                {
                    ProcessFlowShare rowProcessFlowShare = new ProcessFlowShare();
                    rowProcessFlowShare.ProcessFlow_id = idProcess;
                    rowProcessFlowShare.Role_id = idRole_Agent;
                    rowProcessFlowShare.Emp_id = idEmp_Agent;
                    rowProcessFlowShare.isStarter = true;
                    this._context.ProcessFlowShares.Add(rowProcessFlowShare);
                }
            }

            this._context.SaveChanges();

            List<string> lstNode_Next = this._ICFlowInterface.GetLinkNextNode(idProcess, 0, 0, idFlowTree, rFlowNode.id);
            if (lstNode_Next.Count == 0)
            {
                this._ICProcessInterface.WriteProcessException(idProcess, 0, 0, MsgType.Error, "原因：沒有合適的下一個節點，請檢查線段條件");
                return false;
            }

            bool ret = this._ICFlowInterface.GoToNextNode(idProcess, 0, 0, idFlowTree, rFlowNode.id, idRole_Start, idEmp_Start, lstNode_Next, EmpSameUp, Man_Default, Man_Agent, true);

            return ret;
        }


        /// <summary>
        /// 流程狀態設定
        /// svc 沒有實作內容
        /// </summary>
        /// <param name="lsProcessID"></param>
        /// <param name="State">狀態</param>
        /// <param name="idEmp">動作人工號</param>
        /// <returns>List int</returns>
        public List<int> FlowStateSet(List<int> lsProcessID, FlowState State, string idEmp)
        {
            return this._ICFlowManageInterface.FlowStateSet(lsProcessID, State, idEmp);
        }

        /// <summary>
        /// 是否是管理者
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <returns>bool</returns>
        public bool GetAdmin(string sNobr)
        {
            var r = (from c in this._context.SysAdmins
                     where c.Emp_id == sNobr
                     select c).FirstOrDefault();

            return r != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idApParm">idApParm</param>
        /// <returns>CApParm</returns>
        public CApParmDto GetApParm(int idApParm)
        {
            return GetProcessApParm(idApParm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idApView">idApView</param>
        /// <returns>CApView</returns>
        public CApViewDto GetApView(int idApView)
        {
            return GetProcessApView(idApView);
        }

        /// <summary>
        /// 取得簽核代理人資訊
        /// </summary>
        /// <param name="EmpId">被代理人工號</param>
        /// <returns>List CheckAgentDataRow </returns>
        public List<CheckAgentDataRow> GetCheckAgentData(string EmpId)
        {
            return this._ICDataInterface.GetCheckAgentData(EmpId);
        }

        /// <summary>
        /// 取得可代理表單
        /// </summary>
        /// <param name="CheckAgent_Guid">CheckAgent_Guid</param>
        /// <returns>List CheckAgentFlowTreeDataRow</returns>
        public List<CheckAgentFlowTreeDataRow> GetCheckAgentFlowTreeData(string CheckAgent_Guid)
        {
            return this._ICDataInterface.GetCheckAgentFlowTreeData(CheckAgent_Guid);
        }

        /// <summary>
        /// 取得動態角色
        /// </summary>
        /// <param name="idProcess">idProcess</param>
        /// <param name="idFlowNode">idFlowNode</param>
        /// <returns>bool</returns>
        public List<wfDynamicDto> GetDynamic(int idProcess, string idFlowNode = "0")
        {
            var rsDynamic = (from c in this._context.wfDynamics
                             where c.idProcess == idProcess
                             && (idFlowNode == "0" || c.idFlowNode == idFlowNode)
                             select new wfDynamicDto
                             {
                                 idProcess = c.idProcess,
                                 idFlowNode = c.idFlowNode,
                                 Role_id = c.Role_id,
                                 Emp_id = c.Emp_id
                             }).ToList();

            return rsDynamic;
        }

        /// <summary>
        /// 取得員工編號
        /// </summary>
        /// <param name="sEmpId">員工工號</param>
        /// <returns>List Emp</returns>
        public List<EmpRow> GetEmp(string sEmpId)
        {
            var Vdb = this._IEmpDaoInterface.GetData(sEmpId);
            return Vdb;
        }

        /// <summary>
        /// 代理日期
        /// </summary>
        /// <param name="EmpId">工號</param>
        /// <returns>List EmpAgentDateDataRow</returns>
        public List<EmpAgentDateDataRow> GetEmpAgentDateData(string EmpId)
        {
            return this._ICDataInterface.GetEmpAgentDateData(EmpId);
        }


        /// <summary>
        /// 取得流程的內容網址
        /// </summary>
        /// <param name="iApParmID">檢查表序號</param>
        /// <param name="bOnlyUrl">只顯有網址</param>
        /// <returns>string</returns>
        public string GetFlowParmUrl(int iApParmID, bool bOnlyUrl = false)
        {
            return this._ICDataInterface.GetFlowParmUrl(iApParmID, bOnlyUrl);
        }

        /// <summary>
        /// 取得目前待審核的表單
        /// </summary>
        /// <param name="sNobr">審核者工號</param>
        /// <param name="sAppNobr">申請者工號</param>
        /// <returns>List</returns>
        public List<FlowSignRow> GetFlowSign(string sNobr, string sAppNobr)
        {
            return this._ICDataInterface.GetFlowSign(sNobr, sAppNobr);
        }

        /// <summary>
        /// 取得可申請表單
        /// </summary>
        /// <param name="sNobr">申請人工號</param>
        /// <param name="sDeptm">部門</param>
        /// <returns>List FlowTreeData</returns>
        public List<FlowTreeDataRow> GetFlowTreeData(string sNobr, string sDeptm)
        {
            return this._ICDataInterface.GetFlowTreeData(sNobr, sDeptm);
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
        public List<FlowViewRow> GetFlowView(bool bManage = false, string sNobr = "", DateTime? dDateSignB = null, DateTime? dDateSignE = null, DateTime? dDateAppB = null, DateTime? dDateAppE = null, string sState = "1", string sFormCode = "0", int iProcessID = 0, string sApp = "1")
        {
            return this._ICDataInterface.GetFlowView(bManage, sNobr
            , dDateSignB, dDateSignE
            , dDateAppB, dDateAppE
            , sState, sFormCode
            , iProcessID, sApp);
        }

        /// <summary>
        /// 取得檢視網址
        /// </summary>
        /// <param name="idProcess">流程序號</param>
        /// <param name="bOnlyUrl">只顯有網址</param>
        /// <returns>string</returns>
        public string GetFlowViewUrl(int idProcess, bool bOnlyUrl = false)
        {
            return this._ICDataInterface.GetFlowViewUrl(idProcess, bOnlyUrl); 
        }

        /// <summary>
        /// 取得所有表單代碼及內容
        /// </summary>
        /// <param name="sCode">表單代碼</param>
        /// <returns>List wfForm</returns>
        public List<wfFormDto> GetForm(string sCode)
        {
            var Vdb = (from c in this._context.wfForms
                       where sCode.Length == 0 || c.sFormCode == sCode
                       && c.iSort > 0
                       orderby c.iSort
                       select new wfFormDto
                       {
                           iAutoKey = c.iAutoKey,
                           sFormCode = c.sFormCode,
                           sFormName = c.sFormName,
                           sFlowTree = c.sFlowTree,
                           sStdNote = c.sStdNote,
                           sCheckNote = c.sCheckNote,
                           sViewNote = c.sViewNote,
                           sEtcNote = c.sEtcNote,
                           iDelay = c.iDelay,
                           iAppCount = c.iAppCount,
                           bNote = c.bNote,
                           bSignNote = c.bSignNote,
                           bSignState = c.bSignState,
                           bUploadFile = c.bUploadFile,
                           bAttend = c.bAttend,
                           bAgentApp = c.bAgentApp,
                           b1 = c.b1,
                           b2 = c.b2,
                           b3 = c.b3,
                           b4 = c.b4,
                           b5 = c.b5,
                           s1 = c.s1,
                           s2 = c.s2,
                           s3 = c.s3,
                           s4 = c.s4,
                           s5 = c.s5,
                           sTableName = c.sTableName,
                           sSaveUrl = c.sSaveUrl,
                           sSaveMetod = c.sSaveMetod,
                           iSort = c.iSort,
                           sKeyMan = c.sKeyMan,
                           dKeyDate = c.dKeyDate,
                       }).ToList();

            return Vdb;
        }


        /// <summary>
        /// 取得主流程ID
        /// </summary>
        /// <param name="idSubProcess">子流程ID</param>
        /// <returns>int</returns>
        public int GetMainProcess(int idSubProcess)
        {
            int idProcess = 0;
            var rProcessMultiFlow = (from c in this._context.ProcessMultiFlows
                                     where c.SubProcessFlow_id == idSubProcess
                                     select c).FirstOrDefault();

            if (rProcessMultiFlow != null)
            {
                idProcess = rProcessMultiFlow.ProcessFlow_id.Value;
            }

            return idProcess;
        }


        /// <summary>
        /// 公告新聞
        /// </summary>
        /// <param name="dDate">預設帶入今天所有生效的資料</param>
        /// <returns>List NoticeRow</returns>
        public List<NoticeRow> GetNoticeData(DateTime? dDate = null)
        {
            return this._ICNoticeInterface.GetNoticeData(dDate);
        }


        /// <summary>
        /// 公告新聞
        /// </summary>
        /// <param name="Guid">Guid</param>
        /// <returns>List NoticeRow</returns>
        public List<NoticeRow> GetNoticeRow(string Guid)
        {
            return this._ICNoticeInterface.GetNoticeRow(Guid);
        }


        /// <summary>
        /// 公告新聞
        /// </summary>
        /// <param name="Guid">Guid</param>
        /// <returns>List NoticeRow</returns>
        public CApParmDto GetProcessApParm(int idApParm)
        {
            CApParmDto oCApParm = null;
            var rProcessApParm = (from c in this._context.ProcessApParms
                                  where c.auto == idApParm
                                  select c).FirstOrDefault();

            if (rProcessApParm != null)
            {
                oCApParm = new CApParmDto();
                oCApParm.ProcessFlow_id = rProcessApParm.ProcessFlow_id.Value;
                oCApParm.ProcessNode_auto = rProcessApParm.ProcessNode_auto.Value;
                oCApParm.ProcessCheck_auto = rProcessApParm.ProcessCheck_auto.Value;
                oCApParm.Role_id = rProcessApParm.Role_id;
                oCApParm.Emp_id = rProcessApParm.Emp_id;
            }

            return oCApParm;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idApView">idApView</param>
        /// <returns>CApView</returns>
        public CApViewDto GetProcessApView(int idApView)
        {
            CApViewDto oCApView = null;
            var rProcessApView = (from c in this._context.ProcessApViews
                                  where c.auto == idApView
                                  select c).FirstOrDefault();

            if (rProcessApView != null)
            {
                oCApView = new CApViewDto();
                oCApView.ProcessFlow_id = rProcessApView.ProcessFlow_id.Value;
                oCApView.Role_id = rProcessApView.Role_id;
                oCApView.Emp_id = rProcessApView.Emp_id;
                oCApView.tag1 = rProcessApView.tag1;
                oCApView.tag2 = rProcessApView.tag2;
                oCApView.tag3 = rProcessApView.tag3;
            }

            return oCApView;
        }

        /// <summary>
        /// 取得流程相關資訊
        /// </summary>
        /// <param name="lsProcessID">lsProcessID</param>
        /// <returns> List ProcessDataRow</returns>
        public List<ProcessDataRow> GetProcessData(List<int> lsProcessID)
        {
            return this._ICDataInterface.GetProcessData(lsProcessID);
        }


        /// <summary>
        /// 取得新流程ID
        /// </summary>
        /// <returns>int</returns>
        public int GetProcessID()
        {
            return this._ICProcessInterface.GetProcessID();
        }

        /// <summary>
        /// 取得流程簽核清單
        /// </summary>
        /// <param name="idProcess">idProcess</param>
        /// <returns>List FlowSignRow</returns>
        public List<FlowSignRow> GetProcessNodeList(int idProcess)
        {
            var Vdb = this._ICFlowManageInterface.GetProcessNodeList(idProcess);
            return Vdb;
        }


        /// <summary>
        /// 取得角色資料
        /// </summary>
        /// <param name="idEmp">工號</param>
        /// <param name="idRole">角色</param>
        /// <returns>List RoleRow</returns>
        public List<RoleRow> GetRoleData(string idEmp, string idRole)
        {
            List<RoleRow> Vdb = new List<RoleRow>();

            Vdb = (from role in this._context.Roles
                   join emp in this._context.Emps on role.Emp_id equals emp.id
                   join dept in this._context.Depts on role.Dept_id equals dept.id
                   join pos in this._context.Pos on role.Pos_id equals pos.id
                   where (role.Emp_id == idEmp || idEmp.Length == 0)
                   && (role.id == idRole || idRole.Length == 0)
                   //&& role.sort.GetValueOrDefault(1) == 1
                   orderby role.sort.Value
                   select new RoleRow
                   {
                       RoleId = role.id,
                       RoleName = dept.name + "-" + pos.name,
                       EmpId = emp.id,
                       EmpName = emp.name,
                       DeptId = dept.id,
                       DeptName = dept.name,
                       PosId = pos.id,
                       PosName = pos.name,
                       Manage = role.deptMg.Value,
                   }).ToList();

            return Vdb;
        }


        /// <summary>
        /// 取得驗証網頁相關資料 並填入打開日期
        /// </summary>
        /// <param name="sValidateKey">驗証碼</param>
        /// <returns>wfWebValidate</returns>
        public wfWebValidateDto GetWebValidate(string sValidateKey)
        {
            var r = (from c in this._context.wfWebValidates
                     where c.sValidateKey == sValidateKey
                     select new wfWebValidateDto
                     {
                         iAutoKey = c.iAutoKey,
                         sValidateKey = c.sValidateKey,
                         dDateWriter = c.dDateWriter,
                         dDateOpen = c.dDateOpen,
                         sParm = c.sParm
                     }
                     ).FirstOrDefault();

            if (r.dDateWriter >= DateTime.Now.AddMinutes(-1))
            {
                r.dDateOpen = DateTime.Now;
                this._context.SaveChanges();
            }
            else
            {
                r = null;
            }

            return r;
        }


        /// <summary>
        /// 判斷第一關是否已簽核過
        /// </summary>
        /// <param name="idProcess">idProcess</param>
        /// <returns>bool</returns>
        public bool IsFirstNodeSing(int idProcess)
        {
            var rsProcessNode = (from c in this._context.ProcessNodes
                                 where c.ProcessFlow_id == idProcess
                                 select c).ToList();

            return rsProcessNode.Count > 1;
        }

        /// <summary>
        /// 表單寄信稽催
        /// </summary>
        /// <param name="lsProcessID"></param>
        /// <param name="idEmp">動作人工號</param>
        /// <returns>bool</returns>
        public List<int> ProcessFlowSendMail(List<int> lsProcessID, string idEmp)
        {
            List<int> rsProcessID = new List<int>();

            foreach (var rProcessID in lsProcessID)
            {
                List<string> lsSendMail = new List<string>();
                lsSendMail.Add("");    //給主管審核用

                var rProcessCheck = (from pn in this._context.ProcessNodes
                                     join pc in this._context.ProcessChecks on pn.auto equals pc.ProcessNode_auto
                                     join SM in this._context.wfSendMails on pn.ProcessFlow_id equals SM.idProcess
                                     where pn.ProcessFlow_id == rProcessID
                                     && pn.isFinish == false
                                     orderby SM.iAutoKey
                                     select pc).FirstOrDefault();

                var rwfSendMail = (from SM in this._context.wfSendMails
                                   where SM.idProcess == rProcessID
                                   orderby SM.iAutoKey
                                   select SM).FirstOrDefault();

                //主管
                if (rProcessCheck.Emp_idDefault != "" && rProcessCheck.Emp_idDefault != null)
                {
                    var rAgent = (from c in this._context.Emps
                                  where c.id == rProcessCheck.Emp_idDefault.Trim()
                                  select c).FirstOrDefault();

                    if (rAgent != null && rAgent.email.Trim().Length > 0)
                    {
                        lsSendMail.Add(rAgent.email.Trim());
                        rsProcessID.Add(rProcessID);
                    }

                }

                //代理人
                if (rProcessCheck.Emp_idAgent != "" && rProcessCheck.Emp_idAgent != null)
                {
                    var rAgent = (from c in this._context.Emps
                                  where c.id == rProcessCheck.Emp_idAgent.Trim()
                                  select c).FirstOrDefault();

                    if (rAgent != null && rAgent.email.Trim().Length > 0)
                        lsSendMail.Add(rAgent.email.Trim());
                }

                //通知信件
                foreach (var s in lsSendMail)
                {
                    if (s != "" && s != null)
                    {
                        var rSendMail = new wfSendMail();
                        rSendMail.sProcessID = rProcessID.ToString();
                        rSendMail.idProcess = rProcessID;
                        rSendMail.sGuid = Guid.NewGuid().ToString();
                        rSendMail.sToAddress = s;
                        rSendMail.sSubject = rwfSendMail.sSubject;
                        rSendMail.sBody = rwfSendMail.sBody;
                        rSendMail.bOnly = true;
                        rSendMail.sKeyMan = idEmp;
                        rSendMail.dKeyDate = DateTime.Now;

                        this._context.wfSendMails.Add(rSendMail);
                        this._context.SaveChanges();
                    }
                }
            }

            return rsProcessID;
        }

        /// <summary>
        /// 儲存動態角色
        /// </summary>
        /// <param name="idProcess">idProcess</param>
        /// <param name="idFlowNode">idFlowNode</param>
        /// <param name="idEmp">工號</param>
        /// <param name="idRole">角色 可不填</param>
        /// <returns>bool</returns>
        public bool SaveDynamic(int idProcess, string idFlowNode, string idEmp, string idRole)
        {
            bool isOK = false;

            var rFlowNode = (from c in this._context.FlowNodes
                             where c.id == idFlowNode
                             && c.nodeType == "7"
                             select c).FirstOrDefault();

            if (rFlowNode != null)
            {

                if (idRole.Length == 0)
                {
                    var rRole = (from c in this._context.Roles
                                 where c.Emp_id == idEmp
                                 select c).FirstOrDefault();

                    if (rRole != null)
                        idRole = rRole.id;
                }

                if (idRole.Length > 0)
                {
                    var rDynamic = (from c in this._context.wfDynamics
                                    where c.idProcess == idProcess
                                    && c.idFlowNode == idFlowNode
                                    //&& c.Role_id == idRole
                                    //&& c.Emp_id == idEmp
                                    select c).FirstOrDefault();

                    if (rDynamic == null)
                    {
                        rDynamic = new wfDynamic();
                        this._context.wfDynamics.Add(rDynamic);
                        rDynamic.idProcess = idProcess;
                        rDynamic.idFlowNode = idFlowNode;
                    }

                    rDynamic.Role_id = idRole;
                    rDynamic.Emp_id = idEmp;

                    this._context.SaveChanges();

                    isOK = true;
                }
            }

            return isOK;
        }

        /// <summary>
        /// 存入公告
        /// </summary>
        /// <param name="Row">NoticeRow資料列</param>
        /// <returns>bool</returns>
        public bool SaveNotice(NoticeRow Row)
        {
            return this._ICNoticeInterface.Save(Row);
        }


        public void SetApView(int idProcess, string tag1, string tag2, string tag3)
        {
            var rProcessApView = (from c in this._context.ProcessApViews
                                  where c.ProcessFlow_id == idProcess
                                  select c).FirstOrDefault();

            if (rProcessApView != null)
            {
                rProcessApView.tag1 = tag1;
                rProcessApView.tag2 = tag2;
                rProcessApView.tag3 = tag3;

                this._context.SaveChanges();
            }
        }

        /// <summary>
        /// 設定代理人
        /// </summary>
        /// <param name="Role_idSource">來源角色</param>
        /// <param name="Emp_idSource">來源工號</param>
        /// <param name="Role_idTarget">設定角色</param>
        /// <param name="Emp_idTarget">設定工號</param>
        /// <param name="Sort">順位</param>
        /// <param name="KeyMan">登錄者</param>
        /// <returns>bool</returns>
        public bool SetCheckAgent(string Role_idSource, string Emp_idSource, string Role_idTarget, string Emp_idTarget, int Sort = 1, string KeyMan = "Sys")
        {
            var rCheckAgent = (from c in this._context.CheckAgents
                               where c.Role_idSource == Role_idSource
                               && c.Emp_idSource == Emp_idSource
                               && c.Emp_idTarget == Emp_idTarget
                               select c).FirstOrDefault();

            if (rCheckAgent == null)
            {
                rCheckAgent = new CheckAgent();
                this._context.CheckAgents.Add(rCheckAgent);
            }

            rCheckAgent.Role_idSource = Role_idSource;
            rCheckAgent.Emp_idSource = Emp_idSource;
            rCheckAgent.Role_idTarget = Role_idTarget;
            rCheckAgent.Emp_idTarget = Emp_idTarget;
            rCheckAgent.Sort = Sort;
            rCheckAgent.Guid = Guid.NewGuid().ToString();
            rCheckAgent.KeyMan = KeyMan;
            rCheckAgent.KeyDate = DateTime.Now;

            this._context.SaveChanges();

            return true;
        }

        /// <summary>
        /// 設定可代理表單
        /// </summary>
        /// <param name="CheckAgent_Guid">CheckAgent_Guid</param>
        /// <param name="FlowTreeId">FlowTreeId</param>
        /// <param name="KeyMan">登錄者</param>
        /// <returns>bool</returns>
        public bool SetCheckAgentFlowTree(string CheckAgent_Guid, string FlowTreeId, string KeyMan = "Sys")
        {
            var rCheckAgentFlowTree = (from c in this._context.CheckAgentFlowTrees
                                       where c.CheckAgent_Guid == CheckAgent_Guid
                                       && c.FlowTree_id == FlowTreeId
                                       select c).FirstOrDefault();

            if (rCheckAgentFlowTree == null)
            {
                rCheckAgentFlowTree = new CheckAgentFlowTree();
                this._context.CheckAgentFlowTrees.Add(rCheckAgentFlowTree);
            }

            rCheckAgentFlowTree.CheckAgent_Guid = CheckAgent_Guid;
            rCheckAgentFlowTree.FlowTree_id = FlowTreeId;
            rCheckAgentFlowTree.KeyMan = KeyMan;
            rCheckAgentFlowTree.KeyDate = DateTime.Now;

            this._context.SaveChanges();

            return true;
        }

        /// <summary>
        /// 設定代理日期
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateTimeA">開始日期</param>
        /// <param name="dDateTimeD">結束日期</param>
        /// <param name="KeyMan">登錄者</param>
        /// <returns>bool</returns>
        public bool SetEmpAgentDate(string sNobr, DateTime dDateTimeA, DateTime dDateTimeD, string KeyMan = "Sys")
        {
            var rEmpAgentDate = (from c in this._context.EmpAgentDates
                                 where c.Emp_id == sNobr
                                 && c.dateB == dDateTimeA
                                 && c.dateE == dDateTimeD
                                 && c.IsValid
                                 select c).FirstOrDefault();

            if (rEmpAgentDate == null)
            {
                rEmpAgentDate = new EmpAgentDate();
                this._context.EmpAgentDates.Add(rEmpAgentDate);
            }

            rEmpAgentDate.Emp_id = sNobr;
            rEmpAgentDate.dateB = dDateTimeA;
            rEmpAgentDate.dateE = dDateTimeD;
            rEmpAgentDate.KeyMan = KeyMan;
            rEmpAgentDate.KeyDate = DateTime.Now;
            rEmpAgentDate.IsValid = true;

            this._context.SaveChanges();

            return true;
        }

        /// <summary>
        /// 設定更新流程審核表
        /// </summary>
        /// <param name="sNobr">審核者工號</param>
        /// <param name="iApParmID">檢查表序號</param>
        /// <returns>bool</returns>
        public bool SetProcessApParm(int iApParmID)
        {
            bool bUpdate = false;

            var rProcessApParm = (from c in this._context.ProcessApParms
                                  where c.auto == iApParmID
                                  select c).FirstOrDefault();

            if (rProcessApParm != null)
            {
                var rProcessCheck = (from c in this._context.ProcessChecks
                                     where c.auto == rProcessApParm.ProcessCheck_auto
                                     select c).FirstOrDefault();

                if (rProcessCheck != null)
                {
                    rProcessApParm.Role_id = rProcessCheck.Role_idDefault;
                    rProcessApParm.Emp_id = rProcessCheck.Emp_idDefault;

                    this._context.SaveChanges();

                    bUpdate = true;
                }
            }
            return bUpdate;
        }


        /// <summary>
        /// 設定驗証網頁相關資料
        /// </summary>
        /// <param name="sValidateKey">驗証碼</param>
        /// <param name="sParm">參數內容(有加過密)</param>
        /// <returns>bool</returns>
        public bool SetWebValidate(string sValidateKey, string sParm)
        {
            var r = new wfWebValidate();
            r.sValidateKey = sValidateKey;
            r.dDateWriter = DateTime.Now;
            r.sParm = sParm;
            this._context.wfWebValidates.Add(r);
            this._context.SaveChanges();

            return true;
        }

        /// <summary>
        /// 審核到下一關
        /// </summary>
        /// <param name="idApParm">idApParm</param>
        /// <param name="EmpSameUp">遇到本點與上點審核者同一人時 是否要繼續向上</param>
        /// <param name="Man_Default">強迫填入審核者</param>
        /// <param name="Man_Agent">強迫填入代理審核者</param>
        /// <param name="FlowStart">第一次進入</param>
        /// <returns>bool</returns>
        public bool WorkFinish(int idApParm, bool EmpSameUp = true, CMan Man_Default = null, CMan Man_Agent = null, bool FlowStart = false)
        {
            bool? isOK = WorkFinishAndFlowFinish(idApParm, EmpSameUp, Man_Default, Man_Agent, FlowStart);

            return isOK != null ? isOK.Value : true;
        }

        /// <summary>
        /// 審核到下一關
        /// </summary>
        /// <param name="idApParm">idApParm</param>
        /// <param name="EmpSameUp">遇到本點與上點審核者同一人時 是否要繼續向上</param>
        /// <param name="Man_Default">強迫填入審核者</param>
        /// <param name="Man_Agent">強迫填入代理審核者</param>
        /// <param name="FlowStart">第一次進入</param>
        /// <returns>bool null = 本關卡完成 , True = 流程全部結束 , False = 本關卡失敗</returns>
        public bool? WorkFinishAndFlowFinish(int idApParm, bool EmpSameUp = true, CMan Man_Default = null, CMan Man_Agent = null, bool FlowStart = false)
        {


            CApParmDto apParm = GetProcessApParm(idApParm);

            bool? isOK = null;

            if (apParm != null)
            {
                //檢查前置作業
                if (apParm.Role_id.Trim().Length == 0 || apParm.Emp_id.Trim().Length == 0)
                {
                    this._ICProcessInterface.WriteProcessException(apParm.ProcessFlow_id, apParm.ProcessNode_auto, apParm.ProcessCheck_auto,
                    MsgType.Warning, "原因：ProcessApParm 沒有充足的資訊 已自動新增");

                    if (!SetProcessApParm(idApParm))
                    {
                        this._ICProcessInterface.WriteProcessException(apParm.ProcessFlow_id, apParm.ProcessNode_auto, apParm.ProcessCheck_auto,
                        MsgType.Error, "原因：ProcessApParm 沒有充足的資訊 更新失敗");
                        return false;
                    }

                    apParm = GetProcessApParm(idApParm);
                }

                var rProcess = (from pf in this._context.ProcessFlows
                                join pn in this._context.ProcessNodes on pf.id equals pn.ProcessFlow_id
                                join pc in this._context.ProcessChecks on pn.auto equals pc.ProcessNode_auto
                                join fn in this._context.FlowNodes on pn.FlowNode_id equals fn.id
                                where pf.id == apParm.ProcessFlow_id
                                && pn.auto == apParm.ProcessNode_auto
                                && pc.auto == apParm.ProcessCheck_auto
                                select new
                                {
                                    idProcess = pf.id,
                                    idProcessNode_Source = pn.auto,
                                    idProcessCheck_Source = pc.auto,
                                    idFlowTree = pf.FlowTree_id,
                                    idFlowNode_Finish = pn.FlowNode_id,
                                    idRoleSource = pc.Role_idDefault,
                                    idEmpSource = pc.Emp_idDefault,
                                    NodeType = fn.nodeType,
                                    pn,
                                    pc,
                                }).FirstOrDefault();

                if (rProcess != null)
                {
                    int idProcess = rProcess.idProcess;
                    int idProcessNode_Source = rProcess.idProcessNode_Source;
                    int idProcessCheck_Source = rProcess.idProcessCheck_Source;
                    string idFlowTree = rProcess.idFlowTree;
                    string idFlowNode_Finish = rProcess.idFlowNode_Finish;
                    string idRoleSource = rProcess.idRoleSource;
                    string idEmpSource = rProcess.idEmpSource;
                    string NodeType = rProcess.NodeType;

                    List<string> lstNode_NewNext = new List<string>();

                    //不是主管審核才需要找下一個節點
                    if (NodeType != "3")
                    {

                        lstNode_NewNext = this._ICFlowInterface.GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNode_Finish);
                    }
                    else
                    {
                        lstNode_NewNext.Add(idFlowNode_Finish);
                    }


                    isOK = this._ICFlowInterface.GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNode_Finish, idRoleSource, idEmpSource, lstNode_NewNext, EmpSameUp, Man_Default, Man_Agent, FlowStart);

                    if (isOK.Value)
                    {
                        rProcess.pn.isFinish = true; ;

                        rProcess.pc.Role_idReal = apParm.Role_id;
                        rProcess.pc.Emp_idReal = apParm.Emp_id;
                        rProcess.pc.adate = DateTime.Now;

                        this._context.SaveChanges();

                        isOK = null;

                        if (this._ICFlowInterface.GetisFinishOK())
                        {
                            isOK = this._ICFlowInterface.GetisFinishOK();
                        }
                    }
                }
            }
            return isOK;

        }
    }
}
