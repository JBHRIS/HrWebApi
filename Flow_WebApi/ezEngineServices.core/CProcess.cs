using ezEngineServices.core.Vdb;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;

namespace ezEngineServices.core
{
    public class CProcess
    {
        private ezFlowContext dcFlow;

        public CProcess()
        {
            dcFlow = new ezFlowContext();
        }

        public CProcess(ezFlowContext dcFlow)
        {
            this.dcFlow = dcFlow;
        }

        public void WriteProcessException(int idProcess, int idProcessNode, int idProcessCheck, MsgType errorType, string errorMsg)
        {
            ProcessException rowProcessException = new ProcessException();

            rowProcessException.ProcessFlow_id = idProcess;
            rowProcessException.ProcessNode_auto = idProcessNode;
            rowProcessException.ProcessCheck_auto = idProcessCheck;
            switch (errorType)
            {
                case MsgType.Error:
                    rowProcessException.errorType = "1";
                    break;
                case MsgType.Cancel:
                    rowProcessException.errorType = "2";
                    break;
                case MsgType.Warning:
                    rowProcessException.errorType = "3";
                    break;
                case MsgType.Msg:
                    rowProcessException.errorType = "4";
                    break;
            }
            rowProcessException.errorMsg = errorMsg;
            rowProcessException.adate = DateTime.Now;
            rowProcessException.isOK = false;
            dcFlow.ProcessExceptions.Add(rowProcessException);

            //流程發生異常 改變狀態
            var rProcessFlow = (from c in dcFlow.ProcessFlows
                                where c.id == idProcess
                                select c).FirstOrDefault();

            if (rProcessFlow != null)
            {
                if (errorType == MsgType.Error) rProcessFlow.isError = true;
                if (errorType == MsgType.Cancel) rProcessFlow.isCancel = true;
            }

            dcFlow.SaveChanges();
        }

        public int CreateProcessNode(int idProcessNode_Prior, int idProcess, string idFlowNode)
        {
            var rProcessNode = (from c in dcFlow.ProcessNodes
                                where c.ProcessFlow_id == idProcess
                                && c.ProcessNode_idPrior == idProcessNode_Prior
                                && c.FlowNode_id == idFlowNode
                                select c).FirstOrDefault();

            var rFlowNode = (from c in dcFlow.FlowNodes
                             where c.id == idFlowNode
                             select c).FirstOrDefault();

            if (rProcessNode == null)
            {
                rProcessNode = new ProcessNode();
                rProcessNode.ProcessFlow_id = idProcess;
                rProcessNode.ProcessNode_idPrior = idProcessNode_Prior;
                rProcessNode.FlowNode_id = idFlowNode;
                dcFlow.ProcessNodes.Add(rProcessNode);
            }

            rProcessNode.adate = DateTime.Now;
            rProcessNode.isFinish = false;
            rProcessNode.isMulti = rFlowNode != null && rFlowNode.nodeType == "9";

            dcFlow.SaveChanges();

            return rProcessNode.auto;
        }

        public int WriteProcessNodeAndCheck(int idProcessNode_Prior, int idProcess, string idFlowNode, CMan Man_Default, CMan Man_Agent, string idEmpSource)
        {
            int ProcessNode_auto = CreateProcessNode(idProcessNode_Prior, idProcess, idFlowNode);

            ProcessCheck rProcessCheck = new ProcessCheck();
            rProcessCheck.ProcessNode_auto = ProcessNode_auto;
            rProcessCheck.Role_idDefault = Man_Default.idRole;
            rProcessCheck.Emp_idDefault = Man_Default.idEmp;
            rProcessCheck.Role_idAgent = "";
            rProcessCheck.Emp_idAgent = "";
            rProcessCheck.Role_idReal = "";
            rProcessCheck.Emp_idReal = "";
            rProcessCheck.adate = new DateTime(1900, 1, 1);
            dcFlow.ProcessChecks.Add(rProcessCheck);
            dcFlow.SaveChanges();

            //給特別的代理人簽核
            if (Man_Agent != null)
            {
                rProcessCheck.Role_idAgent = Man_Agent.idRole;
                rProcessCheck.Emp_idAgent = Man_Agent.idEmp;
            }
            else
            {
                DateTime dDate = DateTime.Now;

                //由系統判斷是否要找代理人
                var rEmpAgentDate = (from c in dcFlow.EmpAgentDates
                                     where c.Emp_id == Man_Default.idEmp
                                     && dDate >= c.dateB
                                     && dDate <= c.dateE
                                     && c.IsValid
                                     select c).FirstOrDefault();

                CProcess oCProcess = new CProcess(dcFlow);

                oCProcess.WriteProcessException(idProcess, 0, 0, MsgType.Msg, "訊息：尋找啟動代理人");

                if (rEmpAgentDate != null)
                {
                    oCProcess.WriteProcessException(idProcess, 0, 0, MsgType.Msg, "訊息：找到代理人");

                    COrg oCorg = new COrg(dcFlow);
                    Man_Agent = oCorg.GetAgent(idProcess, Man_Default.idRole, Man_Default.idEmp);

                    if (Man_Agent != null && Man_Agent.idEmp != idEmpSource)
                    {
                        oCProcess.WriteProcessException(idProcess, 0, 0, MsgType.Msg, "訊息：寫入代理人");

                        rProcessCheck.Role_idAgent = Man_Agent.idRole;
                        rProcessCheck.Emp_idAgent = Man_Agent.idEmp;
                    }
                }
            }

            var rProcessApParm = (from c in dcFlow.ProcessApParms
                                  where c.ProcessFlow_id == idProcess
                                  && c.ProcessNode_auto == ProcessNode_auto
                                  && c.ProcessCheck_auto == rProcessCheck.auto
                                  select c).FirstOrDefault();

            if (rProcessApParm == null)
            {
                rProcessApParm = new ProcessApParm();
                rProcessApParm.ProcessFlow_id = idProcess;
                rProcessApParm.ProcessNode_auto = ProcessNode_auto;
                rProcessApParm.ProcessCheck_auto = rProcessCheck.auto;
                dcFlow.ProcessApParms.Add(rProcessApParm);
            }

            //原本的核心是沒有預先寫入 為了防止有人沒有點擊處理就能簽核 但批次審核會有問題 因此一律先填寫進去
            rProcessApParm.Role_id = Man_Default.idRole;
            rProcessApParm.Emp_id = Man_Default.idEmp;

            dcFlow.SaveChanges();

            return rProcessApParm.auto;
        }

        public int GetProcessID()
        {
            int id = 0;

            do
            {
                var rProcessID = new ProcessID();
                dcFlow.ProcessIDs.Add(rProcessID);
                dcFlow.SaveChanges();

                id = rProcessID.value;

                //防止寫到相同的 id 有可能導別間系統時資料沒有清掉
                var rProcessFlow = (from c in dcFlow.ProcessFlows
                                    where c.id == id
                                    select c).FirstOrDefault();

                if (rProcessFlow == null)
                    break;
            } while (true);

            return id;
        }
    }
}
