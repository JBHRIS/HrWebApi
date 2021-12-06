using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;
using System.IO;
using System.Web.Services.Description;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web.Services.Protocols;
using System.Reflection;

namespace ezEngineServices
{
    public class CFlow
    {
        private dcFlowDataContext dcFlow;
        private string _ConnectionString;

        public CFlow()
        {
            dcFlow = new dcFlowDataContext();
            _ConnectionString = dcFlow.Connection.ConnectionString;
        }

        /// <summary>
        /// CFlow
        /// </summary>
        /// <param name="conn"></param>
        public CFlow(IDbConnection conn)
        {
            _ConnectionString = conn.ConnectionString;
            dcFlow = new dcFlowDataContext(conn);
        }

        /// <summary>
        /// CFlow
        /// </summary>
        /// <param name="ConnectionString"></param>
        public CFlow(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            dcFlow = new dcFlowDataContext(ConnectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public CFlow(dcFlowDataContext dcFlow)
        {
            _ConnectionString = dcFlow.Connection.ConnectionString;
            this.dcFlow = dcFlow;
        }

        public object GetPropertyValue(object obj, string property)
        {
            System.Reflection.PropertyInfo propertyInfo = obj.GetType().GetProperty(property);
            return propertyInfo.GetValue(obj, null);
        }

        //判斷是否要給下一關主管簽核 僅限主管審核節點使用
        public bool IsNextManage(int idProcess, int idProcessNode_Source, int idProcessCheck_Source, string idFlowNode)
        {
            //判斷本點與上一點
            //本點 = 主管審核 與 上點 = 主管審核 則 交由程式判斷

            var r1 = (from c in dcFlow.ProcessNode
                      join n in dcFlow.FlowNode on c.FlowNode_id equals n.id
                      where c.auto == idProcessNode_Source
                      select new
                      {
                          c.ProcessNode_idPrior,
                          n.nodeType,
                      }).First();

            if (r1 != null && r1.nodeType != "3")
            {
                if (r1.ProcessNode_idPrior != 0)
                {
                    var r2 = (from c in dcFlow.ProcessNode
                              join n in dcFlow.FlowNode on c.FlowNode_id equals n.id
                              where c.auto == r1.ProcessNode_idPrior
                              select new
                              {
                                  c.ProcessNode_idPrior,
                                  n.nodeType,
                              }).First();

                    if (r2 != null && r2.nodeType != "3")
                        return true;
                }
            }

            CProcess oCProcess = new CProcess(dcFlow);

            bool bNextManage = false;

            var rsNodeMangLoopBreak = (from c in dcFlow.NodeMangLoopBreak
                                       where c.FlowNode_id == idFlowNode
                                       select c).ToList();

            //如果有資料要判斷才需要進去
            if (rsNodeMangLoopBreak.Count > 0)
            {
                //進來後 預設要給下一關主管
                bNextManage = true;

                foreach (var rNodeMangLoopBreak in rsNodeMangLoopBreak)
                {
                    bool bCriteria = true;

                    string Where = "";
                    string SqlCommandText = "Select 1 From " + rNodeMangLoopBreak.tableName
                        + " Where idProcess = " + idProcess.ToString();

                    for (int i = 1; i <= 6; i++)
                    {
                        string fdName = GetPropertyValue(rNodeMangLoopBreak, "fdName" + i.ToString()).ToString();
                        if (fdName.Length > 0)
                        {
                            string fdType = GetPropertyValue(rNodeMangLoopBreak, "fdType" + i.ToString()).ToString();
                            string criteria = GetPropertyValue(rNodeMangLoopBreak, "criteria" + i.ToString()).ToString();
                            string minValue = GetPropertyValue(rNodeMangLoopBreak, "minValue" + i.ToString()).ToString();
                            string maxValue = GetPropertyValue(rNodeMangLoopBreak, "maxValue" + i.ToString()).ToString();

                            Where = GetCriteriaString(fdName, fdType, criteria, minValue, maxValue);
                            SqlCommandText += Where;
                        }
                    }

                    IEnumerable<int> results = null;

                    try
                    {
                        results = dcFlow.ExecuteQuery<int>(SqlCommandText);
                    }
                    catch (Exception ex)
                    {
                        oCProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
                            MsgType.Error, "錯誤：" + ex.Message);
                    }

                    bCriteria = results != null && results.Count() > 0;
                    if (bCriteria)
                    {
                        //有找到符合的條件 所以不用到下一關了
                        bNextManage = false;
                        break;
                    }
                }
            }

            return bNextManage;
        }

        //從 Source 節點，取得 Target 節點集合
        public List<string> GetLinkNextNode(int idProcess, int idProcessNode_Source, int idProcessCheck_Source, string idFlowTree, string idFlowNode_Source)
        {
            CProcess oCProcess = new CProcess(dcFlow);

            List<string> lstAll = new List<string>();

            var rsFlowLinkSql = from c in dcFlow.FlowLink
                                where c.FlowTree_id == idFlowTree
                                && c.FlowNode_idSource == idFlowNode_Source
                                select c;

            var rsFlowLinkPower = (from c in dcFlow.FlowLinkPower
                                   where (from d in rsFlowLinkSql where d.id == c.FlowLink_id select 1).Any()
                                   select c).ToList();

            var rsFlowLink = rsFlowLinkSql.ToList();

            foreach (var rFlowLink in rsFlowLink)
            {
                bool bCriteria = true;

                if (rFlowLink.linkType == "1")  //有條件的緣色線 只要有符合都要進去
                {
                    bCriteria = false;

                    var rsFlowLinkPowerWhere = rsFlowLinkPower.Where(p => p.FlowLink_id == rFlowLink.id).ToList();

                    foreach (var rFlowLinkPowerWhere in rsFlowLinkPowerWhere)
                    {
                        string Where = "";
                        string SqlCommandText = "Select 1 From " + rFlowLinkPowerWhere.tableName
                            + " Where idProcess = " + idProcess.ToString();

                        for (int i = 1; i <= 6; i++)
                        {
                            string fdName = GetPropertyValue(rFlowLinkPowerWhere, "fdName" + i.ToString()).ToString();
                            if (fdName.Length > 0)
                            {
                                string fdType = GetPropertyValue(rFlowLinkPowerWhere, "fdType" + i.ToString()).ToString();
                                string criteria = GetPropertyValue(rFlowLinkPowerWhere, "criteria" + i.ToString()).ToString();
                                string minValue = GetPropertyValue(rFlowLinkPowerWhere, "minValue" + i.ToString()).ToString();
                                string maxValue = GetPropertyValue(rFlowLinkPowerWhere, "maxValue" + i.ToString()).ToString();

                                Where = GetCriteriaString(fdName, fdType, criteria, minValue, maxValue);
                                SqlCommandText += Where;
                            }
                        }

                        IEnumerable<int> results = null;

                        try
                        {
                            results = dcFlow.ExecuteQuery<int>(SqlCommandText);
                        }
                        catch (Exception ex)
                        {
                            oCProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
                                MsgType.Error, "錯誤：" + ex.Message);
                        }

                        bCriteria = results != null && results.Count() > 0;
                        if (bCriteria) break;
                    }

                    if (bCriteria)
                        lstAll.Add(rFlowLink.FlowNode_idTarget);
                }
                else if (rFlowLink.linkType == "3") //藍色的線一律加入
                    lstAll.Add(rFlowLink.FlowNode_idTarget);
            }

            //完全沒有任何路要走才加入紅色的線
            if (lstAll.Count == 0)
                foreach (var rFlowLink in rsFlowLink)
                    if (rFlowLink.linkType == "2")
                        lstAll.Add(rFlowLink.FlowNode_idTarget);

            return lstAll;
        }

        //取得AND條件字串
        public string GetCriteriaString(string fieldName, string fieldType, string criteria, string minValue, string maxValue)
        {
            string fdCriteria = "", fdValue1 = "", fdValue2 = "";
            string CLIP = "";

            if (fieldName.Trim().Length > 0)
            {
                if (criteria == ">>") fdCriteria = ">";
                if (criteria == "<<") fdCriteria = "<";
                if (criteria == "==") fdCriteria = "=";
                if (criteria == ">=") fdCriteria = ">=";
                if (criteria == "<=") fdCriteria = "<=";
                if (criteria == "<>") fdCriteria = "<>";
                if (criteria == "><") fdCriteria = "BETWEEN";

                if (fieldType == "Boolean" || fieldType == "Numeric")
                {
                    fdValue1 = minValue.Trim();
                    fdValue2 = maxValue.Trim();
                }
                if (fieldType == "DateTime" || fieldType == "String")
                {
                    fdValue1 = "'" + minValue.Trim() + "'";
                    fdValue2 = "'" + maxValue.Trim() + "'";
                }

                if (fdCriteria == "BETWEEN")
                    CLIP = " AND " + fieldName + " " + fdCriteria + " " + fdValue1 + " AND " + fdValue2;
                else
                    CLIP = " AND " + fieldName + " " + fdCriteria + " " + fdValue1;
            }

            return CLIP;
        }

        public bool isFinishOK = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="idProcessNode_Source"></param>
        /// <param name="idProcessCheck_Source"></param>
        /// <param name="idFlowTree"></param>
        /// <param name="idFlowNodeSource"></param>
        /// <param name="idRoleSource"></param>
        /// <param name="idEmpSource"></param>
        /// <param name="lstNode_Next"></param>
        /// <param name="EmpSameUp">遇到本點與上點審核者同一人時 是否要繼續向上</param>
        /// <param name="Man_Default">強迫填入審核者</param>
        /// <param name="Man_Agent">強迫填入代理審核者</param>
        /// <param name="FlowStart">第一次進入</param>
        /// <returns></returns>
        public bool GoToNextNode(int idProcess, int idProcessNode_Source, int idProcessCheck_Source,
            string idFlowTree, string idFlowNodeSource, string idRoleSource, string idEmpSource, List<string> lstNode_Next, bool EmpSameUp = true, CMan Man_Default = null, CMan Man_Agent = null , bool FlowStart = false)
        {
            Service oService = new Service(dcFlow);
            CProcess oCProcess = new CProcess(dcFlow);
            COrg oCOrg = new COrg(dcFlow);

            var rsFlowNode = (from c in dcFlow.FlowNode
                              where c.id == idFlowNodeSource
                              || lstNode_Next.Contains(c.id)
                              select c).ToList();

            //目前節點是否是會簽流程
            var rFlowNode = rsFlowNode.Where(p => p.id == idFlowNodeSource && p.nodeType == "9").FirstOrDefault();
            bool isFromMultiNode = rFlowNode != null;

            bool isOK = true;

            //將目前的角色代入
            CMan Man_Source = new CMan();
            Man_Source.idRole = idRoleSource;
            Man_Source.idEmp = idEmpSource;

            //if (rProcessFlow != null)
            {
                foreach (string sNode_Next in lstNode_Next)
                {
                    List<string> lstNode_NewNext = null;

                    rFlowNode = rsFlowNode.Where(p => p.id == sNode_Next).FirstOrDefault();

                    //CMan Man_Default = null;

                    switch (rFlowNode.nodeType)
                    {
                        case "2": //表單填寫，直接過去吧！
                            lstNode_NewNext = GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, sNode_Next);
                            GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNodeSource, idRoleSource, idEmpSource, lstNode_NewNext, EmpSameUp, Man_Default, Man_Agent , FlowStart);
                            break;
                        case "3": //主管審核
                            //判斷是否要尋找下一個主管 || 如果是第一次進入 就一定要找下一關主管
                            bool bNextManage = FlowStart || IsNextManage(idProcess, idProcessNode_Source, idProcessCheck_Source, sNode_Next);

                            if (Man_Default == null)
                            {
                                if (bNextManage)
                                {
                                    //若承送的工號與抓到的主管同一人，則繼續抓主管(在裡面判斷)
                                    Man_Default = oCOrg.GetManager(idProcess, idRoleSource, EmpSameUp);

                                    if (Man_Default != null)
                                    {
                                        //檢驗主官是否為該部門的主管 下一關的部門path應該被上一關的部門path包含
                                        if (!oCOrg.IsDeptPathTrue(idRoleSource, Man_Default.idRole))
                                        {
                                            oCProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
                                                      MsgType.Error, "錯誤：主官審核此審核關卡並非真正的下一關");
                                            isOK = false;
                                            break;
                                        }

                                        if (!oCOrg.IsManage(Man_Default.idRole, Man_Default.idEmp))
                                        {
                                            oCProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
                                                 MsgType.Error, "錯誤：主管審核並非主管職");
                                            isOK = false;
                                            break;
                                        }
                                    }
                                }
                            }

                            //與上面判斷式不同 Man_Default 有可能因為上面判斷式而改變
                            if (Man_Default == null)
                            {
                                //如果這個節點已經找不到人了就直接往下點進行
                                isOK = true;
                                lstNode_NewNext = GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, sNode_Next);
                                GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNodeSource, idRoleSource, idEmpSource, lstNode_NewNext, EmpSameUp , null , null, FlowStart);

                                //找不到主管才需要寫警告
                                if (bNextManage)
                                    oCProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
                                        MsgType.Warning, "警告：找不到直屬主管");
                            }
                            else //在這個時候有極大的可能已經找到新的主管 所以繼續往上層主管送單
                                oCProcess.WriteProcessNodeAndCheck(idProcessNode_Source, idProcess, sNode_Next, Man_Default, Man_Agent , idEmpSource);
                            break;
                        case "4": //流程起始者
                            if (Man_Default == null)
                                Man_Default = oCOrg.GetFlowInit(idProcess);

                            if (Man_Default == null)
                            {
                                oCProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
                                    MsgType.Error, "錯誤：找不到流程起始者");
                                isOK = false;
                            }
                            else
                            {
                                //如果是同一個人，就直接往下一個節點，會簽流程例外
                                if (Man_Default.idEmp == idEmpSource && !isFromMultiNode && EmpSameUp)
                                {
                                    lstNode_NewNext = GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, sNode_Next);
                                    GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNodeSource, idRoleSource, idEmpSource, lstNode_NewNext, EmpSameUp, null, null, FlowStart);
                                }
                                else
                                {
                                    if (dcFlow.Connection.State == ConnectionState.Closed) dcFlow.Connection.Open();
                                    dcFlow.Transaction = dcFlow.Connection.BeginTransaction();

                                    try
                                    {
                                        int ProcessApParmAuto = oCProcess.WriteProcessNodeAndCheck(idProcessNode_Source, idProcess, sNode_Next, Man_Default, Man_Agent, idEmpSource);

                                        var rNodeDynamic = dcFlow.NodeInit.FirstOrDefault(p => p.FlowNode_id == sNode_Next && p.isNextNodeAutoSign.Value);

                                        //自動再跳下一節點
                                        if (rNodeDynamic != null)
                                            oService.WorkFinish(ProcessApParmAuto);

                                        dcFlow.Transaction.Commit();
                                    }
                                    catch (Exception ex)
                                    {
                                        dcFlow.Transaction.Rollback();
                                        throw ex;
                                    }
                                    finally
                                    {
                                        dcFlow.Connection.Close();
                                    }
                                }
                            }
                            break;
                        case "5": //會簽起始者
                            if (Man_Default == null)
                                Man_Default = oCOrg.GetMultiInit(idProcess, sNode_Next);

                            if (Man_Default == null)
                            {
                                oCProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
                                    MsgType.Error, "錯誤：找不到會簽起始者");
                                isOK = false;
                            }
                            else
                                oCProcess.WriteProcessNodeAndCheck(idProcessNode_Source, idProcess, sNode_Next, Man_Default, Man_Agent, idEmpSource);
                            break;
                        case "6": //自訂簽核者
                            if (Man_Default == null)
                                Man_Default = oCOrg.GetCustom(sNode_Next);

                            if (Man_Default == null)
                            {
                                oCProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
                                    MsgType.Error, "錯誤：找不到自訂成員");
                                isOK = false;
                            }
                            else
                            {
                                //如果是同一個人，就直接往下一個節點，會簽流程例外
                                if (Man_Default.idEmp == idEmpSource && !isFromMultiNode && EmpSameUp)
                                {
                                    lstNode_NewNext = GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, sNode_Next);
                                    GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNodeSource, idRoleSource, idEmpSource, lstNode_NewNext, EmpSameUp);
                                }
                                else
                                    oCProcess.WriteProcessNodeAndCheck(idProcessNode_Source, idProcess, sNode_Next, Man_Default, Man_Agent, idEmpSource);
                            }
                            break;
                        case "7": //動態簽核者
                            if (Man_Default == null)
                                Man_Default = oCOrg.GetDynamic(idProcess, sNode_Next);

                            if (Man_Default == null)
                            {
                                //特殊 如果找不到動能成員 僅讓表單不要簽核過去 但不做任何動作
                                oCProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
                                    MsgType.Warning, "錯誤：找不到動態成員");
                                isOK = false;
                            }
                            else
                            {
                                //如果是同一個人，就直接往下一個節點，會簽流程例外
                                if (Man_Default.idEmp == idEmpSource && !isFromMultiNode && EmpSameUp)
                                {
                                    lstNode_NewNext = GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, sNode_Next);
                                    GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNodeSource, idRoleSource, idEmpSource, lstNode_NewNext, EmpSameUp , null ,null, FlowStart);
                                }
                                else
                                {
                                    if (dcFlow.Connection.State == ConnectionState.Closed) dcFlow.Connection.Open();
                                    dcFlow.Transaction = dcFlow.Connection.BeginTransaction();

                                    try
                                    {
                                        int ProcessApParmAuto = oCProcess.WriteProcessNodeAndCheck(idProcessNode_Source, idProcess, sNode_Next, Man_Default, Man_Agent, idEmpSource);

                                        var rNodeDynamic = dcFlow.NodeDynamic.FirstOrDefault(p => p.FlowNode_id == sNode_Next && p.isNextNodeAutoSign.Value);

                                        //自動再跳下一節點
                                        if (rNodeDynamic != null)
                                            oService.WorkFinish(ProcessApParmAuto);

                                        dcFlow.Transaction.Commit();
                                    }
                                    catch (Exception ex)
                                    {
                                        dcFlow.Transaction.Rollback();
                                        throw ex;
                                    }
                                    finally
                                    {
                                        dcFlow.Connection.Close();
                                    }
                                }                              
                            }
                            break;
                        case "8": //代理起始者
                            if (Man_Default == null)
                                Man_Default = oCOrg.GetAgentInit(idProcess);

                            if (Man_Default == null)
                            {
                                oCProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
                                    MsgType.Error, "錯誤：找不到代理起始者");
                                isOK = false;
                            }
                            else
                            {
                                if (Man_Default.idEmp == idEmpSource && !isFromMultiNode && EmpSameUp)
                                {
                                    lstNode_NewNext = GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, sNode_Next);
                                    GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNodeSource, idRoleSource, idEmpSource, lstNode_NewNext, EmpSameUp);
                                }
                                else
                                    oCProcess.WriteProcessNodeAndCheck(idProcessNode_Source, idProcess, sNode_Next, Man_Default, Man_Agent, idEmpSource);
                            }
                            break;
                        case "9": //會簽流程
                            {
                                //只開ProcessNode不用Check
                                int ProcessNode_auto = oCProcess.CreateProcessNode(idProcessNode_Source, idProcess, sNode_Next);

                                var rsProcessMultiFlowSql = from c in dcFlow.ProcessMultiFlow
                                                            where c.ProcessNode_auto == 0
                                                            && c.ProcessFlow_id == idProcess
                                                            select c;

                                var rsFlowNodeSql = from c in dcFlow.FlowNode
                                                    where (from d in rsProcessMultiFlowSql where d.SubFlowTree_id == c.FlowTree_id select 1).Any()
                                                    && c.nodeType == "1"
                                                    select c;

                                var rsFlowLinkSql = from c in dcFlow.FlowLink
                                                    where (from d in rsFlowNodeSql where d.id == c.FlowNode_idSource select 1).Any()
                                                    && (from e in rsProcessMultiFlowSql where e.SubFlowTree_id == c.FlowTree_id select 1).Any()
                                                    select c;

                                var rsFlowLink = rsFlowLinkSql.ToList();
                                var rsProcessMultiFlow = rsProcessMultiFlowSql.ToList();
                                rsFlowNode = rsFlowNodeSql.ToList();

                                foreach (var rProcessMultiFlow in rsProcessMultiFlow)
                                {
                                    rProcessMultiFlow.ProcessNode_auto = ProcessNode_auto;
                                    int sub_idProcess = oCProcess.GetProcessID(); //先取得 idProcess

                                    //抓取流程的啟始點來呼叫 FlowStart
                                    bool isError = true;
                                    var rFlowNodeStart = rsFlowNode.Where(p => p.FlowTree_id == rProcessMultiFlow.SubFlowTree_id).FirstOrDefault();

                                    string nStart_id = "";
                                    bool hasStart = false;
                                    if (rFlowNodeStart != null)
                                    {
                                        hasStart = true;
                                        nStart_id = rFlowNodeStart.id;
                                    }

                                    //找到起始點後，找起始點的下一點的 FlowNode_id
                                    if (hasStart)
                                    {
                                        var rFlowLink = rsFlowLink.Where(p => p.FlowTree_id == rProcessMultiFlow.SubFlowTree_id && p.FlowNode_idSource == nStart_id).FirstOrDefault();
                                        if (rFlowLink != null)
                                        {
                                            string dynamic_node_id = rFlowLink.FlowNode_idTarget;

                                            rFlowNode = (from c in dcFlow.FlowNode
                                                         where c.id == dynamic_node_id
                                                         && c.nodeType == "7"
                                                         select c).FirstOrDefault();

                                            //認定下一點接的是動態成員
                                            if (rFlowNode != null)
                                            {
                                                var rDynamic = (from c in dcFlow.wfDynamic
                                                                where c.idProcess == sub_idProcess
                                                                && c.idFlowNode == dynamic_node_id
                                                                select c).FirstOrDefault();

                                                if (rDynamic == null)
                                                {
                                                    rDynamic = new wfDynamic();
                                                    rDynamic.idProcess = sub_idProcess;
                                                    rDynamic.idFlowNode = dynamic_node_id;
                                                    dcFlow.wfDynamic.InsertOnSubmit(rDynamic);
                                                }

                                                rDynamic.Role_id = rProcessMultiFlow.SubDynamicRole_id;
                                                rDynamic.Emp_id = rProcessMultiFlow.SubDynamicEmp_id;

                                                dcFlow.SubmitChanges();

                                                isError = false;
                                            }
                                        }
                                    }

                                    if (!isError)
                                    {	//填完動態成員資訊後，啟動子流程，並設定為並行。
                                        oService.FlowStart(sub_idProcess, rProcessMultiFlow.SubFlowTree_id, rProcessMultiFlow.SubInitRole_id, rProcessMultiFlow.SubInitEmp_id);

                                        var rProcessFlow = (from c in dcFlow.ProcessFlow
                                                            where c.id == sub_idProcess
                                                            select c).FirstOrDefault();

                                        if (rProcessFlow != null)
                                        {
                                            rProcessFlow.isMultiFlow = true;
                                            rProcessFlow.ProcessNode_auto = ProcessNode_auto;   //子流程所採用的主流程ProcessNode_auto
                                        }
                                    }
                                    else
                                    {
                                        oCProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
                                               MsgType.Warning, "警告：找不到會簽流程");
                                        isOK = true;
                                    }

                                    rProcessMultiFlow.SubProcessFlow_id = sub_idProcess;
                                }

                                dcFlow.SubmitChanges();
                            }
                            break;
                        case "10": //郵件通知，直接過去吧！
                            lstNode_NewNext = GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, sNode_Next);
                            GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNodeSource, idRoleSource, idEmpSource, lstNode_NewNext, EmpSameUp, Man_Default, Man_Agent);
                            break;
                        case "11": //服務程式，直接過去吧！
                            var rProcessApView = (from c in dcFlow.ProcessApView
                                                  where c.ProcessFlow_id == idProcess
                                                  select c).FirstOrDefault();

                            var rNodeService = (from c in dcFlow.NodeService
                                                where c.FlowNode_id == sNode_Next
                                                select c).FirstOrDefault();

                            if (rProcessApView != null && rNodeService != null)
                            {
                                if (rNodeService.webSrvUrl.Length > 0)
                                {
                                    string Metod =rNodeService.Metod != null && rNodeService.Metod.Length > 0 ? rNodeService.Metod : "Run";

                                    string Url = rNodeService.webSrvUrl;
                                    int LastIndex = Url.LastIndexOf("/");
                                    if (LastIndex >= 0)
                                    {
                                        string FileName = Url.Substring(LastIndex + 1);
                                        string[] arr = FileName.Split('.');

                                        if (arr.Length == 2)
                                        {
                                            if (arr[1] == "asmx")
                                            {
                                                string tUrl = rNodeService.webSrvUrl;//WebService的http形式的地址  
                                                string tNamespace = "";//欲呼叫的WebService的命名空間  
                                                string tClassname = arr[0];//欲呼叫的WebService的類名（不包括命名空間前綴）  
                                                string tMethodname = Metod;//欲呼叫的WebService的方法名  
                                                object[] tArgs = new object[1];//參數列表  
                                                tArgs[0] = rProcessApView.auto;

                                                try
                                                {
                                                    object tReturnValue = InvokeWebservice(tUrl, tNamespace, tClassname, tMethodname, tArgs);
                                                }
                                                catch (Exception ex)
                                                {
                                                    //oCProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
                                                    //    ErrorType.Error, "錯誤：Web Service 呼叫失敗");
                                                    isOK = false;
                                                    throw new ApplicationException("呼叫動態服務失敗");
                                                }
                                            }
                                            else if (arr[1] == "svc")
                                            {
                                                string uri = rNodeService.webSrvUrl;
                                                WcfChannelFactory oWcfChannelFactory = new WcfChannelFactory();
                                                try
                                                {
                                                    object o = oWcfChannelFactory.ExecuteMetod<IService>(uri, Metod, rProcessApView.auto);
                                                }
                                                catch (Exception ex)
                                                {
                                                    //oCProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
                                                    //    ErrorType.Error, "錯誤：Web Service 呼叫失敗");
                                                    isOK = false;
                                                    throw new ApplicationException("呼叫動態服務失敗");
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    oCProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
                                         MsgType.Warning, "警告：Web Service 網址並不存在");
                                    isOK = true;
                                }

                                lstNode_NewNext = GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, sNode_Next);
                                GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNodeSource, idRoleSource, idEmpSource, lstNode_NewNext, EmpSameUp, Man_Default, Man_Agent);
                            }
                            else
                            {
                                oCProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
                                      MsgType.Error, "錯誤：Web Service 呼叫失敗");
                            }

                            break;
                        case "12": //流程結束
                            {
                                var rProcessFlow = (from c in dcFlow.ProcessFlow
                                                    where c.id == idProcess
                                                    select c).FirstOrDefault();

                                rProcessFlow.isFinish = true;
                                dcFlow.SubmitChanges();

                                isFinishOK = true;

                                //子流程回主流程的處理
                                var rProcessMultiFlow = (from c in dcFlow.ProcessMultiFlow
                                                         where c.SubProcessFlow_id == idProcess
                                                         select c).FirstOrDefault();

                                if (rProcessMultiFlow != null)
                                {
                                    int ProcessFlow_id = rProcessMultiFlow.ProcessFlow_id.Value;
                                    int ProcessNode_auto = rProcessMultiFlow.ProcessNode_auto.Value;

                                    var rsProcessMultiFlowSql = from c in dcFlow.ProcessMultiFlow
                                                                where c.ProcessFlow_id == ProcessFlow_id
                                                                && c.ProcessNode_auto == ProcessNode_auto
                                                                select c;

                                    var rsProcessFlow = (from c in dcFlow.ProcessFlow
                                                         where (from d in rsProcessMultiFlowSql where d.SubProcessFlow_id == c.id select 1).Any()
                                                         && !c.isFinish.GetValueOrDefault(false)
                                                         select c).ToList();

                                    bool isAllFinish = !rsProcessFlow.Any();

                                    //當全部完成的話，則主流程繼續往下走。
                                    if (isAllFinish)
                                    {
                                        rProcessFlow = (from c in dcFlow.ProcessFlow
                                                        where c.id == ProcessFlow_id
                                                        select c).FirstOrDefault();

                                        if (rProcessFlow != null)
                                        {
                                            idFlowTree = rProcessFlow.FlowTree_id;

                                            var rProcessNode = (from c in dcFlow.ProcessNode
                                                                where c.auto == ProcessNode_auto
                                                                select c).FirstOrDefault();

                                            if (rProcessNode != null)
                                            {
                                                //結束該點流程
                                                rProcessNode.isFinish = true;
                                                dcFlow.SubmitChanges();

                                                string idFlowNode = rProcessNode.FlowNode_id;
                                                lstNode_NewNext = GetLinkNextNode(ProcessFlow_id, ProcessNode_auto, 0, idFlowTree, idFlowNode);
                                                GoToNextNode(ProcessFlow_id, ProcessNode_auto, 0, idFlowTree, idFlowNode, rProcessMultiFlow.SubInitRole_id, rProcessMultiFlow.SubInitEmp_id, lstNode_NewNext, EmpSameUp, Man_Default, Man_Agent);
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                    }
                }
            }

            return isOK;
        }

        // <summary>   
        /// 動態呼叫Web Service  
        /// </summary>   
        /// <param name="pUrl">WebService的http形式的位址，EX:http://www.yahoo.com/Service/Service.asmx </param>   
        /// <param name="pNamespace">欲呼叫的WebService的namespace</param>   
        /// <param name="pClassname">欲呼叫的WebService的class name</param>   
        /// <param name="pMethodname">欲呼叫的WebService的method name</param>   
        /// <param name="pArgs">參數列表，請將每個參數分別放入object[]中</param>   
        /// <returns>WebService的執行結果</returns>   
        /// <remarks>   
        /// 如果呼叫失敗，將會拋出Exception。請呼叫的時候，適當截獲異常。   
        /// 目前知道有兩個地方可能會發生異常：   
        /// 1、動態構造WebService的時候，CompileAssembly失敗。   
        /// 2、WebService本身執行失敗。   
        /// </remarks>   
        public object InvokeWebservice(string pUrl, string @pNamespace, string pClassname, string pMethodname, object[] pArgs)
        {
            WebClient tWebClient = new WebClient();

            //要加這行：透過目前預設的使用者登入 
            //tWebClient.Credentials = System.Net.CredentialCache.DefaultCredentials;

            //讀取WSDL檔，確認Web Service描述內容  
            Stream tStream = tWebClient.OpenRead(pUrl + "?WSDL");
            ServiceDescription tServiceDesp = ServiceDescription.Read(tStream);
            //將讀取到的WSDL檔描述import近來  
            ServiceDescriptionImporter tServiceDespImport = new ServiceDescriptionImporter();
            tServiceDespImport.AddServiceDescription(tServiceDesp, "", "");
            CodeNamespace tCodeNamespace = new CodeNamespace(@pNamespace);
            //指定要編譯程式  
            CodeCompileUnit tCodeComUnit = new CodeCompileUnit();
            tCodeComUnit.Namespaces.Add(tCodeNamespace);
            tServiceDespImport.Import(tCodeNamespace, tCodeComUnit);

            //以C#的Compiler來進行編譯  
            CSharpCodeProvider tCSProvider = new CSharpCodeProvider();
            ICodeCompiler tCodeCom = tCSProvider.CreateCompiler();

            //設定編譯參數  
            System.CodeDom.Compiler.CompilerParameters tComPara = new System.CodeDom.Compiler.CompilerParameters();
            tComPara.GenerateExecutable = false;
            tComPara.GenerateInMemory = true;

            //取得編譯結果  
            System.CodeDom.Compiler.CompilerResults tComResult = tCodeCom.CompileAssemblyFromDom(tComPara, tCodeComUnit);

            //如果編譯有錯誤的話，將錯誤訊息丟出  
            if (true == tComResult.Errors.HasErrors)
            {
                System.Text.StringBuilder tStr = new System.Text.StringBuilder();
                foreach (System.CodeDom.Compiler.CompilerError tComError in tComResult.Errors)
                {
                    tStr.Append(tComError.ToString());
                    tStr.Append(System.Environment.NewLine);
                }
                throw new Exception(tStr.ToString());
            }

            //取得編譯後產出的Assembly  
            System.Reflection.Assembly tAssembly = tComResult.CompiledAssembly;
            Type tType = tAssembly.GetType(@pNamespace + "." + pClassname, true, true);
            object tTypeInstance = Activator.CreateInstance(tType);
            //若WS有overload的話，需明確指定參數內容  
            Type[] tArgsType = null;
            if (pArgs == null)
            {
                tArgsType = new Type[0];
            }
            else
            {
                int tArgsLength = pArgs.Length;
                tArgsType = new Type[tArgsLength];
                for (int i = 0; i < tArgsLength; i++)
                {
                    tArgsType[i] = pArgs[i].GetType();
                }
            }

            //若沒有overload的話，第二個參數便不需要，這邊要注意的是WsiProfiles.BasicProfile1_1本身不支援Web Service overload，因此需要改成不遵守WsiProfiles.BasicProfile1_1協議  
            System.Reflection.MethodInfo tInvokeMethod = tType.GetMethod(pMethodname, tArgsType);

            //要加這三行：如果是Windows整合驗證的話，透過SoapHttp來對要invoke的目標WS做驗證 
            //SoapHttpClientProtocol webRequest = (SoapHttpClientProtocol)tTypeInstance;
            //webRequest.PreAuthenticate = true;
            //webRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;

            //這二行即可設定Timeout時間為30秒。
            //PropertyInfo propInfo = tTypeInstance.GetType().GetProperty("Timeout");
            //propInfo.SetValue(tTypeInstance, 30000, null);  

            //實際invoke該method  
            return tInvokeMethod.Invoke(tTypeInstance, pArgs);
        }

        /// <summary>
        /// 使用ChannelFactory為wcf用戶端創建獨立通道
        /// </summary>
        public class WcfChannelFactory
        {
            public WcfChannelFactory()
            {
            }

            /// <summary>
            /// 執行方法   WSHttpBinding
            /// </summary>
            /// <typeparam name="T">服務介面</typeparam>
            /// <param name="uri">wcf地址</param>
            /// <param name="methodName">方法名</param>
            /// <param name="args">參數列表</param>
            public object ExecuteMetod<T>(string uri, string methodName, params object[] args)
            {
                BasicHttpBinding binding = new BasicHttpBinding();   //出現異常:遠端伺服器返回錯誤: (415) Cannot process the message because the content type 'text/xml; charset=utf-8' was not the expected type 'application/soap+xml; charset=utf-8'.。
                //WSHttpBinding binding = new WSHttpBinding();
                EndpointAddress endpoint = new EndpointAddress(uri);

                using (ChannelFactory<T> channelFactory = new ChannelFactory<T>(binding, endpoint))
                {
                    T instance = channelFactory.CreateChannel();
                    using (instance as IDisposable)
                    {
                        try
                        {
                            Type type = typeof(T);
                            MethodInfo mi = type.GetMethod(methodName);
                            return mi.Invoke(instance, args);
                        }
                        catch (TimeoutException)
                        {
                            (instance as ICommunicationObject).Abort();
                            throw;
                        }
                        catch (CommunicationException)
                        {
                            (instance as ICommunicationObject).Abort();
                            throw;
                        }
                        catch (Exception vErr)
                        {
                            (instance as ICommunicationObject).Abort();
                            throw;
                        }
                    }
                }
            }

            //nettcpbinding 綁定方式
            public object ExecuteMethod<T>(string pUrl, string pMethodName, params object[] pParams)
            {
                EndpointAddress address = new EndpointAddress(pUrl);
                System.ServiceModel.Channels.Binding bindinginstance = null;
                NetTcpBinding ws = new NetTcpBinding();
                ws.MaxReceivedMessageSize = 20971520;
                ws.Security.Mode = SecurityMode.None;
                bindinginstance = ws;
                using (ChannelFactory<T> channel = new ChannelFactory<T>(bindinginstance, address))
                {
                    T instance = channel.CreateChannel();
                    using (instance as IDisposable)
                    {
                        try
                        {
                            Type type = typeof(T);
                            MethodInfo mi = type.GetMethod(pMethodName);
                            return mi.Invoke(instance, pParams);
                        }
                        catch (TimeoutException)
                        {
                            (instance as ICommunicationObject).Abort();
                            throw;
                        }
                        catch (CommunicationException)
                        {
                            (instance as ICommunicationObject).Abort();
                            throw;
                        }
                        catch (Exception vErr)
                        {
                            (instance as ICommunicationObject).Abort();
                            throw;
                        }
                    }
                }
            }
        }
    }
}