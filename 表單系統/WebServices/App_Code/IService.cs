using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Bll.Flow.Vdb;
using JBModule.Data.Dto;
using Bll.Att.Vdb;

// 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼和組態檔中的介面名稱 "IService"。
[ServiceContract(Namespace = "http://jbjob.com.tw/Flow")]
public interface IService
{

    [OperationContract]
    string GetData(int value);

    [OperationContract]
    CompositeType GetDataUsingDataContract(CompositeType composite);

    [OperationContract]
    List<FormTreeTable> GetFormTreeToList(string sNobr);

    [OperationContract]
    List<FlowSignTable> GetFlowProgressFlow(string sNobr = "");

    [OperationContract]
    int GetFlowProgressFlowCount(string sNobr = "");

    [OperationContract]
    List<FlowSignTable> GetFlowProgressFlowAll(string sNobr, string sAppNobr);

    [OperationContract]
    List<FlowSignCompleteTable> GetFlowProgressFlowComplete(string sNobr);

    [OperationContract]
    bool SetProcessApParm(string sNobr, int iApParmID, int iProcessCheckAuto);

    [OperationContract]
    List<FlowSearchIngTable> GetFlowSearchIng(string sNobr);

    [OperationContract]
    List<FlowSearchCompleteTable> GetFlowSearchComplete(string sNobr, DateTime dAppB, DateTime dAppE);

    [OperationContract]
    List<RolesTable> GetRoles(string sNobr);

    [OperationContract]
    List<CheckAgentDefaultTable> GetAgent(string sNobr, string sRole = "");

    [OperationContract]
    bool SetAgent(string sNobr, string sRole, string sAgentNobr1, string sAgentNobr2, string sAgentNobr3, string dDateB, string dDateE);

    [OperationContract]
    List<FlowAbsTable> GetFlowAbs(DateTime dDateB, DateTime dDateE, string sCat, List<string> lsDept = null, List<string> lsNobr = null, List<string> lsState = null);

    [OperationContract]
    List<FlowAbsTable> GetFlowAbs1(DateTime dDateB, DateTime dDateE, string sHcode = "", string sCat = "0", List<string> lsDept = null, List<string> lsNobr = null, List<string> lsState = null);

    [OperationContract]
    List<FlowOtTable> GetFlowOt(DateTime dDateB, DateTime dDateE, List<string> lsDept = null, List<string> lsNobr = null, List<string> lsState = null);

    [OperationContract]
    List<FlowOtTable> GetFlowOt1(DateTime dDateB, DateTime dDateE, List<string> lsDept = null, List<string> lsNobr = null, List<string> lsState = null, string sOtType = "");

    [OperationContract]
    List<int> WorkFinish(List<int> lsApParm, string sSignNobr, string sNote = "", bool bSign = true);

    [OperationContract]
    List<int> SetCancelForm(FormCategroy FormName, List<int> lsProcessID, bool bCancel = true);

    [OperationContract]
    List<int> SetResetForm(FormCategroy FormName, List<int> lsProcessID);

    [OperationContract]
    List<int> SetCancelFormByHr(FormCategroy FormName, string sNobr, DateTime dDateB, string sTimeB, string sType = "", bool bCancel = true);

    [OperationContract]
    List<int> SetCancelProcess(List<int> lsProcessID, bool bCancel = true);

    [OperationContract]
    List<HcodeTable> GetHocde(string sCode = "");

    //[OperationContract]
    //List<AbsenceDetail> AbsInfoWithHrHide(DateTime dDate, bool Hide, bool WithFlowData, List<string> arrNobr = null);
    //[OperationContract]
    //List<AbsenceDetail> AbsInfoWithHR(DateTime dDate, bool WithFlowData, List<string> arrNobr = null);
    [OperationContract]
    List<JBModule.Data.Repo.SpecialLeaveOfYear> GetYearAbsenceDetail(List<string> EmployeeList, DateTime DateBegin, DateTime DateEnd, DateTime DDate);
    [OperationContract]
    JBModule.Data.Linq.BASETTS GetBasettsByDate(string Nobr, DateTime Date);
    [OperationContract]
    bool AddBasetts(JBModule.Data.Linq.BASETTS basettsSet);
    [OperationContract]
    List<JBModule.Data.Dto.AbsenceDetail> GetAbsEntitleByTakenGuid(string TakenGuid);
    [OperationContract]
    List<JBModule.Data.Dto.AbsenceDto> GetAbsTakenByEntitleGuid(string EntitleGuid);
    [OperationContract]
    List<JBModule.Data.Dto.AbsenceDto> GetAbsTakenByByEmployeeIdList(DateTime DateBegin, DateTime DateEnd, bool WithFlowData, List<string> EmployeeIdList = null);
    [OperationContract]
    List<JBModule.Data.Dto.AbsenceDetail> GetAbsEntitleByEmployeeIdList(DateTime DateBegin, DateTime DateEnd, bool WithFlowData, List<string> EmployeeIdList = null);
    [OperationContract]
    List<JBModule.Data.Dto.AbsenceDto> GetAbsTakenByByEmployeeIdListHcodeType(DateTime DateBegin, DateTime DateEnd, bool WithFlowData, List<string> EmployeeIdList, List<string> HtypeList);
    [OperationContract]
    List<JBModule.Data.Dto.AbsenceDetail> GetAbsEntitleByEmployeeIdListHcodeType(DateTime DateBegin, DateTime DateEnd, bool WithFlowData, List<string> EmployeeIdList, List<string> HtypeList);
    [OperationContract]
    Dictionary<string, string> GetHoliType();
    // TODO: 在此新增您的服務作業
}

//使用下列範例中所示的資料合約，新增複合型別至服務作業。
[DataContract]
public class CompositeType
{
    bool boolValue = true;
    string stringValue = "Hello ";

    [DataMember]
    public bool BoolValue
    {
        get { return boolValue; }
        set { boolValue = value; }
    }

    [DataMember]
    public string StringValue
    {
        get { return stringValue; }
        set { stringValue = value; }
    }
}