using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Bll.Flow.Vdb;
using JBModule.Data.Dto;
using System.Data;
using Newtonsoft.Json;
using System.ServiceModel.Activation;
using Bll.Att.Vdb;

// 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼、svc 和組態檔中的類別名稱 "Service"。
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class Service : IService
{
    public string GetData(int value)
    {
        return string.Format("You entered: {0}", value);
    }

    public CompositeType GetDataUsingDataContract(CompositeType composite)
    {
        if (composite == null)
        {
            throw new ArgumentNullException("composite");
        }
        if (composite.BoolValue)
        {
            composite.StringValue += "Suffix";
        }
        return composite;
    }

    #region IService 成員

    /// <summary>
    /// 審核表單
    /// </summary>
    /// <param name="lsApParm">ApParm</param>
    /// <param name="sSignNobr">審核者工號</param>
    /// <param name="sNote">審核備註</param>
    /// <param name="bSign">是否核准</param>
    /// <returns>List</returns>
    public List<int> WorkFinish(List<int> lsApParm, string sSignNobr, string sNote = "", bool bSign = true)
    {
        List<int> lsApParmTrue = new List<int>();

        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.FlowFormsDao oFlowFormsDao = new Dal.Dao.Flow.FlowFormsDao(dcFlow.Connection);
        Dal.Dao.Flow.MainDao oMainDao = new Dal.Dao.Flow.MainDao(dcFlow.Connection);

        //var rsFlow = GetFlowProgressFlow(sSignNobr);

        localhost.Service oService = new localhost.Service();

        foreach (var rApParm in lsApParm)
        {
            try
            {
                var rGetApParm = oService.GetApParm(rApParm);

                if (oMainDao.SetProcessApParm(sSignNobr, rApParm, rGetApParm.ProcessCheck_auto))
                {
                    if (oFlowFormsDao.SetFormSignM(rApParm, rGetApParm.ProcessFlow_id, sSignNobr, sNote, bSign))
                        if (bSign)
                        {
                            if (oService.WorkFinish(rApParm))
                                lsApParmTrue.Add(rApParm);
                        }
                        else
                            lsApParmTrue.Add(rApParm);
                }
            }
            catch { }
        }

        return lsApParmTrue;
    }

    /// <summary>
    /// 表單申請樹狀
    /// </summary>
    /// <param name="sNobr">申請者工號</param>
    /// <returns>List</returns>
    public List<FormTreeTable> GetFormTreeToList(string sNobr)
    {
        string sDeptm = "";

        dcHrDataContext dcHr = new dcHrDataContext();
        Dal.Dao.Bas.BasDao oBasDao = new Dal.Dao.Bas.BasDao(dcHr.Connection);
        var rsBasetts = oBasDao.GetBasettsByNobr(sNobr, DateTime.Now.Date);
        var rBasetts = rsBasetts.Where(p => p.DateA <= DateTime.Now.Date && DateTime.Now.Date <= p.DateD).FirstOrDefault();
        if (rBasetts != null)
            sDeptm = rBasetts.Deptm;

        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.MainDao oMainDao = new Dal.Dao.Flow.MainDao(dcFlow.Connection);
        return oMainDao.GetFormTreeToList(sNobr, sDeptm);
    }

    /// <summary>
    /// 審核流程
    /// </summary>
    /// <param name="sNobr">審核者工號</param>
    /// <returns>List</returns>
    public List<FlowSignTable> GetFlowProgressFlow(string sNobr)
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.MainDao oMainDao = new Dal.Dao.Flow.MainDao(dcFlow.Connection);
        return oMainDao.GetFlowProgressFlow(sNobr);
    }

    /// <summary>
    /// 審核流程的筆數
    /// </summary>
    /// <param name="sNobr">審核者工號</param>
    /// <returns>int</returns>
    public int GetFlowProgressFlowCount(string sNobr)
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.MainDao oMainDao = new Dal.Dao.Flow.MainDao(dcFlow.Connection);
        return oMainDao.GetFlowProgressFlowCount(sNobr);
    }

    /// <summary>
    /// 審核流程全部
    /// </summary>
    /// <param name="sNobr">主管工號</param>
    /// <param name="sCheckNobr">申請者工號</param>
    /// <returns>List</returns>
    public List<FlowSignTable> GetFlowProgressFlowAll(string sNobr, string sAppNobr)
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.MainDao oMainDao = new Dal.Dao.Flow.MainDao(dcFlow.Connection);
        return oMainDao.GetFlowProgressFlow(sNobr, sAppNobr);
    }

    /// <summary>
    /// 審核過的流程
    /// </summary>
    /// <param name="sNobr">審核者工號</param>
    /// <returns>List</returns>
    public List<FlowSignCompleteTable> GetFlowProgressFlowComplete(string sNobr)
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.MainDao oMainDao = new Dal.Dao.Flow.MainDao(dcFlow.Connection);
        return oMainDao.GetFlowProgressFlowComplete(sNobr);
    }

    /// <summary>
    /// 審核按鈕動作 審核畫面跳出前 先處理這個事件
    /// </summary>
    /// <param name="sNobr">審核者工號</param>
    /// <param name="iApParmID">ApParmID</param>
    /// <param name="iProcessCheckAuto">ProcessCheckAuto</param>
    /// <returns>bool</returns>
    public bool SetProcessApParm(string sNobr, int iApParmID, int iProcessCheckAuto)
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.MainDao oMainDao = new Dal.Dao.Flow.MainDao(dcFlow.Connection);
        return oMainDao.SetProcessApParm(sNobr, iApParmID, iProcessCheckAuto);
    }

    /// <summary>
    /// 進行中流程查詢
    /// </summary>
    /// <param name="sNobr">查詢工號</param>
    /// <returns>List</returns>
    public List<FlowSearchIngTable> GetFlowSearchIng(string sNobr)
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.MainDao oMainDao = new Dal.Dao.Flow.MainDao(dcFlow.Connection);
        return oMainDao.GetFlowSearchIng(sNobr);
    }

    /// <summary>
    /// 已完成流程查詢
    /// </summary>
    /// <param name="sNobr">查詢工號</param>
    /// <param name="dAppB">查詢開始日期</param>
    /// <param name="dAppE">查詢結束日期</param>
    /// <returns>List</returns>
    public List<FlowSearchCompleteTable> GetFlowSearchComplete(string sNobr, DateTime dAppB, DateTime dAppE)
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.MainDao oMainDao = new Dal.Dao.Flow.MainDao(dcFlow.Connection);
        return oMainDao.GetFlowSearchComplete(sNobr, dAppB, dAppE);
    }

    /// <summary>
    /// 取得角色
    /// </summary>
    /// <param name="sNobr">工號</param>
    /// <returns>string</returns>
    public List<RolesTable> GetRoles(string sNobr)
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.MainDao oMainDao = new Dal.Dao.Flow.MainDao(dcFlow.Connection);
        return oMainDao.GetRoles(sNobr);
    }

    /// <summary>
    /// 取得代理人資訊
    /// </summary>
    /// <param name="sNobr">被代理人工號</param>
    /// <param name="sRole">被代理人角色 空白等於全部取得</param>
    /// <returns></returns>
    public List<CheckAgentDefaultTable> GetAgent(string sNobr, string sRole = "")
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.MainDao oMainDao = new Dal.Dao.Flow.MainDao(dcFlow.Connection);
        return oMainDao.GetAgent(sNobr, sRole);
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
    public bool SetAgent(string sNobr, string sRole, string sAgentNobr1, string sAgentNobr2, string sAgentNobr3, string dDateB, string dDateE)
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.MainDao oMainDao = new Dal.Dao.Flow.MainDao(dcFlow.Connection);
        return oMainDao.SetAgent(sNobr, sRole, sAgentNobr1, sAgentNobr2, sAgentNobr3, dDateB, dDateE);
    }

    /// <summary>
    /// 表單請假資料
    /// </summary>
    /// <param name="dDateB">開始日期</param>
    /// <param name="dDateE">結束日期</param>
    /// <param name="sCat">請假類別0 = 不分,1 = 請假,2 = 公出</param>
    /// <param name="lsDept">部門List 忽略此條件需傳入null或是0筆資料的物件</param>
    /// <param name="lsNobr">工號List 忽略此條件需傳入null或是0筆資料的物件</param>
    /// <param name="lsState">狀態List 忽略此條件需傳入null或是0筆資料的物件1=進行中, 2=駁回, 3=完成</param>
    /// <returns>List</returns>
    public List<FlowAbsTable> GetFlowAbs(DateTime dDateB, DateTime dDateE, string sCat, List<string> lsDept = null, List<string> lsNobr = null, List<string> lsState = null)
    {
        if (lsState == null)
        {
            lsState = new List<string>();
            lsState.Add("1");//預設
        }

        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.FlowFormsDao oFlowFormsDao = new Dal.Dao.Flow.FlowFormsDao(dcFlow.Connection);
        var Vdb = oFlowFormsDao.GetFlowAbs(dDateB, dDateE, sCat, lsDept, lsNobr, lsState);

        dcHrDataContext dcHr = new dcHrDataContext();
        Dal.Dao.Bas.BasDao oBasDao = new Dal.Dao.Bas.BasDao(dcHr.Connection);
        Dal.Dao.Att.HcodeDao oHcodeDao = new Dal.Dao.Att.HcodeDao(dcHr.Connection);

        List<string> lsBaseNobr = Vdb.Select(p => p.Nobr).ToList();

        var rsBase = oBasDao.GetBase(lsBaseNobr);
        var rsHcode = oHcodeDao.GetHocdeDetail();

        foreach (var rVdb in Vdb)
        {
            var rBase = rsBase.Where(p => p.Nobr == rVdb.Nobr).FirstOrDefault();
            if (rBase != null)
                rVdb.NameE = rBase.NameE;

            var rHcode = rsHcode.Where(p => p.Code == rVdb.Hcode).FirstOrDefault();
            if (rHcode != null)
            {
                rVdb.Unit = rHcode.Unit == Bll.MT.mtEnum.HcodeUnit.Day ? "Day" : "Hour";
                rVdb.HcodeName = rHcode.NameC;  //更改成HR系統的假別名稱
            }
        }

        return Vdb;
    }

    /// <summary>
    /// 表單請假資料
    /// </summary>
    /// <param name="dDateB">開始日期</param>
    /// <param name="dDateE">結束日期</param>
    /// <param name="sHcode">假別代碼 空白 = 全部</param>
    /// <param name="sCat">請假類別0 = 不分,1 = 請假,2 = 公出</param>
    /// <param name="lsDept">部門List 忽略此條件需傳入null或是0筆資料的物件</param>
    /// <param name="lsNobr">工號List 忽略此條件需傳入null或是0筆資料的物件</param>
    /// <param name="lsState">狀態List 忽略此條件需傳入null或是0筆資料的物件1=進行中, 2=駁回, 3=完成</param>
    /// <returns>List</returns>
    public List<FlowAbsTable> GetFlowAbs1(DateTime dDateB, DateTime dDateE, string sHcode = "", string sCat = "0", List<string> lsDept = null, List<string> lsNobr = null, List<string> lsState = null)
    {
        if (lsState == null)
        {
            lsState = new List<string>();
            lsState.Add("1");//預設
        }

        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.FlowFormsDao oFlowFormsDao = new Dal.Dao.Flow.FlowFormsDao(dcFlow.Connection);
        var Vdb = oFlowFormsDao.GetFlowAbs(dDateB, dDateE, sHcode, sCat, lsDept, lsNobr, lsState);

        dcHrDataContext dcHr = new dcHrDataContext();
        Dal.Dao.Bas.BasDao oBasDao = new Dal.Dao.Bas.BasDao(dcHr.Connection);
        Dal.Dao.Att.HcodeDao oHcodeDao = new Dal.Dao.Att.HcodeDao(dcHr.Connection);

        List<string> lsBaseNobr = Vdb.Select(p => p.Nobr).ToList();

        var rsBase = oBasDao.GetBase(lsBaseNobr);
        var rsHcode = oHcodeDao.GetHocdeDetail();

        foreach (var rVdb in Vdb)
        {
            var rBase = rsBase.Where(p => p.Nobr == rVdb.Nobr).FirstOrDefault();
            if (rBase != null)
                rVdb.NameE = rBase.NameE;

            var rHcode = rsHcode.Where(p => p.Code == rVdb.Hcode).FirstOrDefault();
            if (rHcode != null)
            {
                rVdb.Unit = rHcode.Unit== Bll.MT.mtEnum.HcodeUnit.Day? "Day" : "Hour";
                rVdb.HcodeName = rHcode.NameC;  //更改成HR系統的假別名稱
            }
        }

        return Vdb;
    }

    /// <summary>
    /// 表單請假資料
    /// </summary>
    /// <param name="dDateB">開始日期</param>
    /// <param name="dDateE">結束日期</param>
    /// <param name="lsDept">部門List 忽略此條件需傳入null或是0筆資料的物件</param>
    /// <param name="lsNobr">工號List 忽略此條件需傳入null或是0筆資料的物件</param>
    /// <param name="lsState">狀態List 忽略此條件需傳入null或是0筆資料的物件1=進行中, 2=駁回, 3=完成</param>
    /// <returns>List</returns>
    public List<FlowOtTable> GetFlowOt(DateTime dDateB, DateTime dDateE, List<string> lsDept = null, List<string> lsNobr = null, List<string> lsState = null)
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();
        if (lsState == null)
        {
            lsState = new List<string>();
            lsState.Add("1");//預設
        }
        Dal.Dao.Flow.FlowFormsDao oFlowFormsDao = new Dal.Dao.Flow.FlowFormsDao(dcFlow.Connection);
        var Vdb = oFlowFormsDao.GetFlowOt(dDateB, dDateE, lsDept, lsNobr, lsState);
        return Vdb;
    }

    /// <summary>
    /// 表單請假資料
    /// </summary>
    /// <param name="dDateB">開始日期</param>
    /// <param name="dDateE">結束日期</param>
    /// <param name="lsDept">部門List 忽略此條件需傳入null或是0筆資料的物件</param>
    /// <param name="lsNobr">工號List 忽略此條件需傳入null或是0筆資料的物件</param>
    /// <param name="lsState">狀態List 忽略此條件需傳入null或是0筆資料的物件1=進行中, 2=駁回, 3=完成</param>
    /// <param name="sOtType">加班類別 忽略此條件需傳入空白 1=加班 , 2=津貼</param>
    /// <returns>List</returns>
    public List<FlowOtTable> GetFlowOt1(DateTime dDateB, DateTime dDateE, List<string> lsDept = null, List<string> lsNobr = null, List<string> lsState = null, string sOtType = "")
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();
        if (lsState == null)
        {
            lsState = new List<string>();
            lsState.Add("1");//預設
        }

        List<string> lsOtType = new List<string>();
        dcHrDataContext dcHr = new dcHrDataContext();
        Dal.Dao.Att.OtDao oOtDao = new Dal.Dao.Att.OtDao(dcHr.Connection);
        if (sOtType.Trim().Length > 0)
            lsOtType = oOtDao.GetOtType(sOtType == "1").Select(p => p.Code).ToList();

        Dal.Dao.Flow.FlowFormsDao oFlowFormsDao = new Dal.Dao.Flow.FlowFormsDao(dcFlow.Connection);
        var Vdb = oFlowFormsDao.GetFlowOt(dDateB, dDateE, lsDept, lsNobr, lsState, lsOtType);
        return Vdb;
    }

    /// <summary>
    /// 取消表單及流程
    /// </summary>
    /// <param name="FormName">暫時沒用到 隨便丟</param>
    /// <param name="lsProcessID">List ProcessID</param>
    /// <param name="bCancel">True = 取消流程</param>
    /// <returns>List</returns>
    public List<int> SetCancelForm(FormCategroy FormName, List<int> lsProcessID, bool bCancel = true)
    {

        dcHrDataContext dcHr = new dcHrDataContext();
        Dal.Dao.Att.AbsDao oAbsDao = new Dal.Dao.Att.AbsDao(dcHr.Connection);
        Dal.Dao.Att.OtDao oOtDao = new Dal.Dao.Att.OtDao(dcHr.Connection);

        List<int> Vdb = new List<int>();

        //先刪除HR資料
        foreach (var iProcessID in lsProcessID)
        {
            string s = oAbsDao.DeleteAbs(iProcessID.ToString());
            s = s.Length > 0 ? s : oOtDao.DeleteOt(iProcessID.ToString());
            if (s.Length > 0)
                Vdb.Add(iProcessID);
        }

        //再刪除Flow資料
        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.FlowFormsDao oFlowFormsDao = new Dal.Dao.Flow.FlowFormsDao(dcFlow.Connection);
        Vdb = oFlowFormsDao.SetCancelForm(Vdb, bCancel);

        return Vdb;
    }

    /// <summary>
    /// 設定表單作業
    /// </summary>
    /// <param name="FormName">表單類別</param>
    /// <param name="sNobr">工號</param>
    /// <param name="dDateB">日期</param>
    /// <param name="sTimeB">時間</param>
    /// <param name="sType">假別或加班類別...</param>
    /// <param name="bCancel">是否取消流程 True = 取消</param>
    /// <returns>List int</returns>
    public List<int> SetCancelFormByHr(FormCategroy FormName, string sNobr, DateTime dDateB, string sTimeB, string sType = "", bool bCancel = true)
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.FlowFormsDao oFlowFormsDao = new Dal.Dao.Flow.FlowFormsDao(dcFlow.Connection);

        var Vdb = oFlowFormsDao.SetCancelForm(FormName, sNobr, dDateB, sTimeB, sType, bCancel);

        return Vdb;
    }

    /// <summary>
    /// 取消流程
    /// </summary>
    /// <param name="lsProcessID">List ProcessID</param>
    /// <param name="bCancel">True = 取消流程</param>
    /// <returns>List</returns>
    public List<int> SetCancelProcess(List<int> lsProcessID, bool bCancel = true)
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.MainDao oMainDao = new Dal.Dao.Flow.MainDao(dcFlow.Connection);

        var Vdb = oMainDao.SetCancelProcessFlow(lsProcessID, bCancel);

        return Vdb;
    }

    /// <summary>
    /// 重設流程
    /// </summary>
    /// <param name="FormName"></param>
    /// <param name="lsProcessID">lsProcessID</param>
    /// <returns>List</returns>
    public List<int> SetResetForm(FormCategroy FormName, List<int> lsProcessID)
    {
        List<int> Vdb = new List<int>();

        localhost.Service oService = new localhost.Service();

        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.FlowFormsDao oFlowFormsDao = new Dal.Dao.Flow.FlowFormsDao(dcFlow.Connection);

        foreach (int iProcessID in lsProcessID)
        {
            string RoleID = "";
            string EmpID = "";
            string FlowTreeID = "";
            string sGuid = oFlowFormsDao.SetResetFormBegin(iProcessID, out RoleID, out EmpID, out FlowTreeID);
            int iPID = oService.GetProcessID();
            if (oFlowFormsDao.SetResetFormAfter(sGuid, iPID, iProcessID))
            {
                if (RoleID.Length > 0 && EmpID.Length > 0 && FlowTreeID.Length > 0)
                {
                    if (oService.FlowStart(iPID, FlowTreeID, RoleID, EmpID, RoleID, EmpID))
                    {
                        Vdb.Add(iProcessID);
                    }
                }
            }
        }

        return Vdb;
    }

    /// <summary>
    /// 假別代碼資料
    /// </summary>
    /// <param name="sCode">假別代碼 空白 = 全部</param>
    /// <returns>HcodeTable</returns>
    public List<HcodeTable> GetHocde(string sCode = "")
    {
        dcHrDataContext dcHr = new dcHrDataContext();
        Dal.Dao.Att.HcodeDao oHcode = new Dal.Dao.Att.HcodeDao(dcHr.Connection);
        var Vdb = oHcode.GetHocde(sCode);

        return Vdb;
    }

    List<AbsenceDetail> _absDetailData;
    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="dDate">查詢日期</param>
    ///// <param name="arrNobr">工號清單</param>
    ///// <param name="Hide">隱藏不顯示資料</param>
    ///// <returns></returns>
    ////[WebMethod(Description = "傳回已存在HR的資料 dDate>查詢日期,Hide>隱藏不顯示資料 , arrDept>部門List 忽略此條件需傳入null或是0筆資料的物件, arrNobr>工號List 忽略此條件需傳入null或是0筆資料的物件", EnableSession = false)]
    //public List<AbsenceDetail> AbsInfoWithHrHide(DateTime dDate, bool Hide, bool WithFlowData, List<string> arrNobr = null)
    //{
    //    List<AbsenceDetail> oo = new List<AbsenceDetail>();
    //    return oo;
    //}
    ///// <summary>
    ///// 取得得假資料
    ///// </summary>
    ///// <param name="dDate"></param>
    ///// <param name="WithFlowData"></param>
    ///// <param name="EmployeeId"></param>
    ///// <returns></returns>
    //public List<AbsenceDetail> GetAbsEntitleByEmployeeIdList(DateTime dDate, bool WithFlowData, List<string> EmployeeId = null)
    //{
    //    return AbsInfoWithHrHide(dDate, false, WithFlowData, EmployeeId);
    //}
    /// <summary>
    /// 取得扣假資料所沖抵的得假
    /// </summary>
    /// <param name="TakenGuid">扣假資料Guid</param>
    /// <returns></returns>
    public List<JBModule.Data.Dto.AbsenceDetail> GetAbsEntitleByTakenGuid(string TakenGuid)
    {
        return JBModule.Data.Repo.AbsenceRepo.GetAbsEntitleByTakenGuid(TakenGuid);
    }
    /// <summary>
    /// 取得得假資料所沖抵的扣假
    /// </summary>
    /// <param name="TakenGuid">得假資料Guid</param>
    /// <returns></returns>
    public List<JBModule.Data.Dto.AbsenceDto> GetAbsTakenByEntitleGuid(string EntitleGuid)
    {
        return JBModule.Data.Repo.AbsenceRepo.GetAbsTakenByEntitleGuid(EntitleGuid);
    }
    /// <summary>
    /// 取得請假紀錄
    /// </summary>
    /// <param name="DateBegin">開始日期</param>
    /// <param name="DateEnd">結束日籍</param>
    /// <param name="WithFlowData">是否取得簽核中資料(未實作)</param>
    /// <param name="EmployeeIdList">工號清單</param>
    /// <returns></returns>
    public List<JBModule.Data.Dto.AbsenceDto> GetAbsTakenByByEmployeeIdList(DateTime DateBegin, DateTime DateEnd, bool WithFlowData, List<string> EmployeeIdList = null)
    {
        return JBModule.Data.Repo.AbsenceRepo.GetAbsTakenByByEmployeeIdList(DateBegin, DateEnd, WithFlowData, EmployeeIdList);
    }
    /// <summary>
    /// 取得請假紀錄
    /// </summary>
    /// <param name="DateBegin">開始日期</param>
    /// <param name="DateEnd">結束日籍</param>
    /// <param name="WithFlowData">是否取得簽核中資料(未實作)</param>
    /// <param name="EmployeeIdList">工號清單</param>
    /// <returns></returns>
    public List<JBModule.Data.Dto.AbsenceDto> GetAbsTakenByByEmployeeIdListHcodeType(DateTime DateBegin, DateTime DateEnd, bool WithFlowData, List<string> EmployeeIdList, List<string> HtypeList)
    {
        return JBModule.Data.Repo.AbsenceRepo.GetAbsTakenByByEmployeeIdList(DateBegin, DateEnd, WithFlowData, EmployeeIdList, HtypeList);
    }
    /// <summary>
    /// 取得得假資料
    /// </summary>
    /// <param name="DateBegin">開始日期</param>
    /// <param name="DateEnd">結束日籍</param>
    /// <param name="WithFlowData">是否取得簽核中資料(未實作)</param>
    /// <param name="EmployeeIdList">工號清單</param>
    /// <returns></returns>
    public List<JBModule.Data.Dto.AbsenceDetail> GetAbsEntitleByEmployeeIdList(DateTime DateBegin, DateTime DateEnd, bool WithFlowData, List<string> EmployeeIdList = null)
    {
        return JBModule.Data.Repo.AbsenceRepo.GetAbsEntitleByEmployeeIdList(DateBegin, DateEnd, WithFlowData, EmployeeIdList);
    }
    /// <summary>
    /// 取得得假資料
    /// </summary>
    /// <param name="DateBegin">開始日期</param>
    /// <param name="DateEnd">結束日籍</param>
    /// <param name="WithFlowData">是否取得簽核中資料(未實作)</param>
    /// <param name="EmployeeIdList">工號清單</param>
    /// <returns></returns>
    public List<JBModule.Data.Dto.AbsenceDetail> GetAbsEntitleByEmployeeIdListHcodeType(DateTime DateBegin, DateTime DateEnd, bool WithFlowData, List<string> EmployeeIdList , List<string> HtypeList)
    {
        return JBModule.Data.Repo.AbsenceRepo.GetAbsEntitleByEmployeeIdList(DateBegin, DateEnd, WithFlowData, EmployeeIdList,HtypeList);
    }

    /// <summary>
    /// 傳回年度請假資訊
    /// </summary>
    /// <param name="EmployeeList">DDate</param>
    /// <param name="DateBegin">請假開始日期</param>
    /// <param name="DateEnd">請假結束日期</param>
    /// <param name="DDate">異動截止日</param>
    /// <returns></returns>    
    public List<JBModule.Data.Repo.SpecialLeaveOfYear> GetYearAbsenceDetail(List<string> EmployeeList, DateTime DateBegin, DateTime DateEnd, DateTime DDate)
    {
        JBModule.Data.Repo.YearAbsenceRepo yearAbs = new JBModule.Data.Repo.YearAbsenceRepo();
        var sql = yearAbs.GetYearAbsenceDetail(EmployeeList, DateBegin, DateEnd, DDate);
        //return GetJson(sql.CopyToDataTable());
        return sql.ToList();
    }
    public JBModule.Data.Linq.BASETTS GetBasettsByDate(string Nobr, DateTime Date)
    {
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        var sql = from a in db.BASETTS where a.NOBR == Nobr && Date >= a.ADATE && Date <= a.DDATE.Value select a;
        if (sql.Any())
        {
            var rr = sql.FirstOrDefault();
            rr.ADATE = Date;
            rr.KEY_DATE = DateTime.Now;
            rr.KEY_MAN = "";
            return rr;
        }
        else return null;
    }
    public bool AddBasetts(JBModule.Data.Linq.BASETTS basettsSet)
    {
        try
        {
            JBModule.Message.TextLog.path = @"D:\JbLog\";
            JBModule.Message.TextLog.WriteLog("新增異動" + basettsSet.NOBR);
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.BASETTS where a.NOBR == basettsSet.NOBR && basettsSet.ADATE >= a.ADATE && basettsSet.ADATE <= a.DDATE.Value select new { a.NOBR, a.ADATE, DDATE = a.DDATE.Value, a.TTSCODE };
            if (!sql.Any()) return false;
            var rBasetts = sql.First();
            if (rBasetts.ADATE == basettsSet.ADATE) return false;
            if (rBasetts.DDATE.Date != DateTime.MaxValue.Date) return false;//如果不是最新的異動
            if (rBasetts.TTSCODE == "1")
            {
                if (!new string[] { "2", "3", "6" }.Contains(basettsSet.TTSCODE)) return false;
            }
            else if (rBasetts.TTSCODE == "2")
            {
                if (!new string[] { "4" }.Contains(basettsSet.TTSCODE)) return false;
            }
            else if (rBasetts.TTSCODE == "3")
            {
                if (!new string[] { "4" }.Contains(basettsSet.TTSCODE)) return false;
            }
            else if (rBasetts.TTSCODE == "4")
            {
                if (!new string[] { "3", "6" }.Contains(basettsSet.TTSCODE)) return false;
            }
            else if (rBasetts.TTSCODE == "5")
            {
                if (!new string[] { "4" }.Contains(basettsSet.TTSCODE)) return false;
            }
            else if (rBasetts.TTSCODE == "6")
            {
                if (!new string[] { "2", "3", "6" }.Contains(basettsSet.TTSCODE)) return false;
            }
            else return false;
            var sql1 = (from a in db.BASETTS where a.NOBR == basettsSet.NOBR select a).ToList();
            sql1.Add(basettsSet);
            DateTime ddate = DateTime.MaxValue;
            foreach (var it in sql1.OrderByDescending(p => p.ADATE))
            {
                it.DDATE = ddate;
                ddate = it.ADATE.AddDays(-1);
            }
            db.BASETTS.InsertOnSubmit(basettsSet);
            db.SubmitChanges();
            return true;
        }
        catch (Exception ex)
        {
            JBModule.Message.TextLog.WriteLog(ex);
            return false;
        }
    }
    /// <summary>
    /// 取得請假類別清單
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, string> GetHoliType()
    {
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        var sql = from a in db.HcodeType where a.Sort > 0 orderby a.Sort select new { a.HTYPE, a.TYPE_NAME };
        var dic = sql.ToDictionary(p => p.HTYPE, p => p.TYPE_NAME);
        return dic;
    }

    #endregion
}
public class AbsenceGet
{
    public string Nobr;
    public DateTime DateBegin;
    public DateTime DateEnd;
    public string Hcode;
    public string Group;
    public string Aname;
    public decimal Hours;
    public string Unit;
    public string Memo = "";
    public int Sort = 100;
}
public class AbsenceUse
{
    public string Nobr;
    public DateTime AppDate;
    public string Hcode;
    public string Aname;
    public string Group;
    public decimal Hours;
    //public string Uint;
}