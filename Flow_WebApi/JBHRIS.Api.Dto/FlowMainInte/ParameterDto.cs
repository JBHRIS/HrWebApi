using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using System;
using System.Collections.Generic;
using System.Text;
using static JBHRIS.Api.Dto.FlowMainInte.Vdb.MultiEnum;

namespace JBHRIS.Api.Dto.FlowMainInte
{
    /// <summary>
    /// 
    /// </summary>
    public class ParameterDto
    {
    }


    public class DeptDto
    {
        public DeptDto() { }

        public string DateB { get; set; }
        public string DateE { get; set; }
        public string DeptID { get; set; }
    }

    public class DeptListDto
    {
        public DeptListDto() { }

        public string DateB { get; set; }
        public string DateE { get; set; }
        public string[] DeptID { get; set; }
    }


    public class EmpIDDto
    {
        public EmpIDDto() { }

        public string DateB { get; set; }
        public string DateE { get; set; }
        public string EmpID { get; set; }
    }

    public class EmpIDListDto
    {
        public EmpIDListDto() { }

        public DateTime DateB { get; set; }
        public DateTime DateE { get; set; }
        public string[] ListEmpID { get; set; }
    }
    public class DateEmpIDListDto
    {
        public DateEmpIDListDto() { }

        public DateTime[] DateList { get; set; }
        public string[] EmpIDList { get; set; }
    }

    public class GetManInfoDto
    {

        public List<string> ListEmpID { get; set; }
        public string EffectDate { get; set; }
    }

    public class FlowSignRoleDto
    {
        public FlowSignRoleDto()
        {

        }

        public string SignEmpID { get; set; }
        public string SignRoleID { get; set; }
        public string RealSignEmpID { get; set; }
        public string RealSignRoleID { get; set; }
        public string FlowTreeID { get; set; }
        public string SignDate { get; set; }
    }


    public class RoteIDDto
    {
        public RoteIDDto()
        {

        }

        public string[] ListRoteID { get; set; }
    }


    public class AttendInfoDto
    {
        public AttendInfoDto()
        {

        }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public List<string> ListEmpID { get; set; }
        public string EffectDate { get; set; }
        public string Display { get; set; }
        public List<string> ListState { get; set; }
    }


    public class FlowStateDto
    {
        public FlowStateDto()
        {

        }

        public List<int> ListProcessFlowID { get; set; }

        public FlowState enumState { get; set; }
        public string EmpID { get; set; }
        public string SignEmpID { get; set; }
    }

    public class GetFlowSignRoleDto
    {

        public GetFlowSignRoleDto() { }
        public string SignEmpID { get; set; }
        public string SignRoleID { get; set; }
        public string RealSignEmpID { get; set; }
        public string RealSignRoleID { get; set; }
        public string FlowTreeID { get; set; }
        public string SignDate { get; set; }
    }

    public class GetAttendExceptionalCountDto
    {
        public GetAttendExceptionalCountDto() { }

        public string DateB { get; set; }
        public string DateE { get; set; }
        public string[] ListEmpID { get; set; }
    }

    public class GetAttendExceptionalByDeptDto
    {
        public GetAttendExceptionalByDeptDto() { }

        public string DateB { get; set; }
        public string DateE { get; set; }
        public string DeptaID { get; set; }
    }



    public class AccountDTO
    {

        public AccountDTO()
        {

        }
        public string Account { get; set; }

        public string Password { get; set; }
    }

    //public class AccountVdb
    //{
    //    /// <summary>
    //    /// 是否驗證通過
    //    /// </summary>
    //    public bool Verification { get; set; }
    //    /// <summary>
    //    /// 帳號
    //    /// </summary>
    //    public string Account { get; set; }
    //    /// <summary>
    //    /// 密碼
    //    /// </summary>
    //    public string Password { get; set; }
    //    /// <summary>
    //    /// 訊息
    //    /// </summary>
    //    public string Message { get; set; }


    //}

    public class AbscSaveAndFlowStartDto
    {
        public AbscFlowAppRow FlowApp { get; set; }

        public FlowDynamicRow FlowDynamic { get; set; }
    }

    public class CardSaveAndFlowStartDto
    {
        public CardFlowAppRow FlowApp { get; set; }

        public FlowDynamicRow FlowDynamic { get; set; }
    }

    public class ReissueCardSaveAndFlowStartDto
    {
        public ReissueCardFlowAppRow FlowApp { get; set; }

        public FlowDynamicRow FlowDynamic { get; set; }
    }

    public class GetNewsByDateNowDto
    {
        public string DateNow { get; set; }
        public bool Miniature { get; set; }
    }

    public class CardSaveByFlowDto
    {
        public string EmpID { get; set; }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public string CauseID1 { get; set; }
        public string CauseID2 { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public string Serno { get; set; }
    }

    public class CardCheckDto
    {
        public string EmpID { get; set; }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public string CauseID1 { get; set; }
        public string CauseID2 { get; set; }
    }

    public class Payslip_ParaDto
    {
        public int year { get; set; }
        public int Month { get; set; }
        public string period { get; set; }
        public string salpw { get; set; }
    }

    public class GetCardFlowAppsDto
    {
        public int ProcessFlowID { get; set; }

        public bool Miniature { get; set; }
    }

    public class BaseDto
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string EmpCode { get; set; }
        public string AppEmpCode { get; set; }
        public string EffectDate { get; set; }
    }

    public class FromEmpIDgetDeptDto
    {

        public string EmpID { get; set; }
        public string EffectDate { get; set; }
    }

    public class FromDeptaBySignDto
    {
        public string EmpID { get; set; }
        public string DeptID { get; set; }
        public string EffectDate { get; set; }
    }

    public class FormEmpDto
    {
        public string EmpCode { get; set; }
        public string Key { get; set; }
        public string EffectDate { get; set; }
    }

    public class MyActionDTO
    {
        public string[] ListEmpID { get; set; }
        public string EffectDate { get; set; }

    }



    public class GetDeptaByEmpDto
    {
        public string EmpCode { get; set; }
        public string DeptID { get; set; }
        public int Level { get; set; }
        public string DeptNameKey { get; set; }
        public string EmpCodeOrNameKey { get; set; }
        public string EffectDate { get; set; }
        public bool IsTop { get; set; }
        public bool IsShift { get; set; }
    }


    public class GetAttendDto
    {
        public string DateB { get; set; }
        public string DateE { get; set; }
        public string[] ListEmpID { get; set; }
        public string[] ListRoteID { get; set; }
    }

    public class GetFormInfoDto
    {
        public string FormCode { get; set; }
        public string FlowTreeID { get; set; }
    }

    public class HoliDayBalanceDto
    {
        public string EmpID { get; set; }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public string HoliDayID { get; set; }
        public string KeyName { get; set; }
        public string EventDate { get; set; }
        public List<AbsFlowAppsRow> ListAbsFlow { get; set; }
        public bool Miniature { get; set; }
    }


    public class AbsSaveAndFlowStartDto
    {
        public AbsFlowAppRow FlowApp { get; set; }

        public FlowDynamicRow FlowDynamic { get; set; }
    }

    public class GetCalculateFlowDataDto
    {
        public string EmpID { get; set; }
        public string HoliDayID { get; set; }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public bool CalculateWorkTime { get; set; }
        public bool CalculateRes { get; set; }
        public bool FixedCycle { get; set; }
        public decimal Exception { get; set; }
        public string RoteID { get; set; }
        public bool Time24 { get; set; }
        public string KeyName { get; set; }
        public string EventDate { get; set; }
        public string AgentNobr1 { get; set; }
        public string AgentName1 { get; set; }
        public string AgentNote { get; set; }
        public List<AbsFlowAppsRow> FlowApps { get; set; }
    }

    public class GetFlowViewAbsDto
    {
        public List<string> ListEmpID { get; set; }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public string FormCode { get; set; }
        public string State { get; set; }
        public int ProcessFlowID { get; set; }
        public string Cond1 { get; set; }
        public string Cond2 { get; set; }
        public string Cond3 { get; set; }
        public bool Handle { get; set; }
    }

    public class GetEventDateDto
    {
        public string EmpID { get; set; }
        public string HolidayID { get; set; }
        public int TakeNum { get; set; }
    }








    public class CardDto
    {
        public string Code { get; set; }
        public string Message { get; set; }
        //public string TokenKey { get; set; }
    }
    public class CondDto
    {
        public CondDto() { }
        public Cond cond { get; set; }
    }
    public class Cond
    {
        public Cond() { }
        public Auth Auth { get; set; }
        public string EmpID { get; set; }
        public string DateB { get; set; }
        public string TimeB { get; set; }
        public string ReasonCode { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public string Serno { get; set; }
        /// <summary>
        /// 經度
        /// </summary>
        //public decimal Longitude { get; set; }
        /// <summary>
        /// 緯度
        /// </summary>
        // public decimal Latitude { get; set; }
        public LocationGps LocationGps { get; set; }
        public string LocationIp { get; set; }
        public string ActionType { get; set; }
        public string PunchType { get; set; }

        public string ConnectType { get; set; }
    }


    public class LocationGps
    {
        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }



    }

    public class Auth
    {
        public Auth() { }
        public string TokenKey { get; set; }
        public string PrivateKe { get; set; }
    }





    public class OtCheckDto
    {
        public string EmpID { get; set; }
        public string OtCat { get; set; }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public string CauseID { get; set; }
        public string RoteID { get; set; }
        public bool Card { get; set; }
        public bool Time24 { get; set; }
    }
    public class OtDeleteCheckDto
    {
        public string EmpID { get; set; }
        public string DateB { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public bool CheckAbsPlus { get; set; }
    }

    public class OtDeleteCheckBySernoDto
    {
        public string AppSerno { get; set; }
        public bool CheckAbsPlus { get; set; }
    }


    public class OtDeleteBySernoDto
    {
        public string AppSerno { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public string Serno { get; set; }
    }

    public class OtDeleteDto
    {
        public string EmpID { get; set; }
        public string DateB { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public string Serno { get; set; }
    }

    public class GetOtDto
    {

        public string DateB { get; set; }
        public string DateE { get; set; }
        public string[] ListEmpID { get; set; }
    }


    public class GetOtBy46Dto
    {
        public string DateB { get; set; }
        public string DateE { get; set; }
        public string EmpID { get; set; }
        public bool For46 { get; set; }
    }

    public class OtSaveDto
    {
        public string EmpID { get; set; }
        public string OtCat { get; set; }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public string DateA { get; set; }
        public string DateD { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public decimal Amount { get; set; }
        public string CauseID { get; set; }
        public string RoteID { get; set; }
        public string DeptcID { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public string Serno { get; set; }
        public bool Time24 { get; set; }
    }

    public class GetCalculateDto
    {
        public string EmpID { get; set; }
        public string OtCat { get; set; }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public string CauseID { get; set; }
        public string RoteID { get; set; }
        public bool CalculateRes { get; set; }
        public bool CalculateAtt { get; set; }
        public bool Time24 { get; set; }
    }


    public class GetAbsPlusRangeDto
    {

        public string EmpID { get; set; }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public List<string> ListEmpID { get; set; }
        public List<string> ListHolidayID { get; set; }
    }

    public class GetAbsPlusDto
    {

        public string DateB { get; set; }
        public List<string> ListEmpID { get; set; }
        public List<string> ListHolidayID { get; set; }
    }


    public class GetAbsDetailByDeptCodeDto
    {
        public string DateB { get; set; }
        public string DateE { get; set; }
        public List<string> ListDeptCode { get; set; }
    }


    public class GetAbsDetailDto
    {
        public string DateB { get; set; }

        public string DateE { get; set; }
        public string[] ListEmpID { get; set; }
    }

    public class GetAbsByDeptCodeDto
    {


        public string DateB { get; set; }
        public string DateE { get; set; }
        public string[] ListDeptCode { get; set; }
    }

    public class GetAbsDto
    {

        public string DateB { get; set; }
        public string DateE { get; set; }
        public string[] ListEmpID { get; set; }
    }

    public class GetBalanceDto
    {

        public string EmpID { get; set; }
        public string DateB { get; set; }
        public string HoliDayID { get; set; }
        public List<AbsFlowRow> ListAbsFlow { get; set; }
    }


    public class AbsCheckDto
    {
        public string EmpID { get; set; }
        public string HoliDayID { get; set; }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public string KeyName { get; set; }
        public string EventDate { get; set; }
        public decimal ProcessUse { get; set; }
        public bool Time24 { get; set; }
    }

    public class AbsSaveDto
    {
        public string EmpID { get; set; }
        public string HoliDayID { get; set; }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public string KeyName { get; set; }
        public string EventDate { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public string Serno { get; set; }
        public string DeptcID { get; set; }
        public bool CalculateWorkTime { get; set; }
        public bool CalculateRes { get; set; }
        public bool FixedCycle { get; set; }
        public decimal Exception { get; set; }
        public string RoteID { get; set; }
        public bool Time24 { get; set; }
    }

    public class GetAbsDetailByListEmpIDDto
    {

        public string DateB { get; set; }
        public string DateE { get; set; }
        public List<string> ListEmpID { get; set; }
    }

    public class GetAbsCalculateDto
    {
        public string EmpID { get; set; }
        public string HoliDayID { get; set; }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public bool CalculateWorkTime { get; set; }
        public bool CalculateRes { get; set; }
        public bool FixedCycle { get; set; }
        public decimal Exception { get; set; }
        public string RoteID { get; set; }
        public bool Time24 { get; set; }
        public string KeyName { get; set; }
        public string EventDate { get; set; }
        public List<AbsFlowAppsRow> AbsFlowAppsList { get; set; }
    }


    public class AbstpDto
    {
        public string EmpID { get; set; }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public string HolidayCode { get; set; }
    }

    public class GetHoliDayBalanceDto
    {
        public string EmpID { get; set; }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public string HoliDayID { get; set; }
        public string KeyName { get; set; }
        public string EventDate { get; set; }
        public List<AbsFlowAppsRow> FlowApps { get; set; }
        public bool Miniature { get; set; }
    }


    public class GetBaseByFormDeptDto
    {
        public string EmpCode { get; set; }
        public string Key { get; set; }
        public string EffectDate { get; set; }
    }

    public class GetBaseByListDeptIDDto
    {
        public List<string> ListDeptID { get; set; }
        public string EffectDate { get; set; }
    }


    public class MidifyPassWord
    {

        public string Account { get; set; }

        public string OldPassWord { get; set; }
        public string NewPassWord { get; set; }
    }



    public class OTSaveAndFlowStartDto
    {
        //public OTFlowAppRow FlowApp { get; set; }

        public FlowDynamicRow FlowDynamic { get; set; }
    }
}
