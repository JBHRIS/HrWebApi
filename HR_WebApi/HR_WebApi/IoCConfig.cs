using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using JBHRIS.Api.Service.Employee.Normal;
using Autofac;
using Autofac.Core;
using JBHRIS.Api.Service._System;

namespace HR_WebApi
{
    public class IoCConfig
    {
        public IoCConfig()
        {

        }
        /// <summary>
        /// 設定註冊服務
        /// </summary>
        /// <param name="Configuration">設定檔</param>
        /// <param name="services">服務集合</param>
        /// <returns></returns>
        public static IServiceCollection Configure(IConfiguration Configuration, IServiceCollection services)
        {
            //CompositeIocConfig services = new CompositeIocConfig(_services, containerBuilder);
            services.AddSingleton<NLog.ILogger>(NLog.LogManager.GetLogger("HR"));

            services.AddScoped<JBHRIS.Api.Service.Salary.Payroll.ISalaryCalculationService, JBHRIS.Api.Service.Salary.Payroll.SalaryCalculationService>();
            services.AddScoped<JBHRIS.Api.Bll.Salary.Payroll.ISalaryCalculateModule, JBHRIS.Api.Bll.Salary.Payroll.SalaryCalculateModule>();
            services.AddScoped<JBHRIS.Api.Bll.Salary.Payroll.ISalaryCalculateModuleFactory, JBHRIS.Api.Bll.Salary.Payroll.SalaryCalculateModuleFactory>();
            
            #region Service
            
            services.AddScoped<JBHRIS.Api.Service.Employee.Normal.IEmployeeInfoService, JBHRIS.Api.Service.Employee.Normal.EmployeeInfoService>();
            services.AddScoped<JBHRIS.Api.Service.Employee.Normal.IEmployeeListService, JBHRIS.Api.Service.Employee.Normal.EmployeeListService>();
            services.AddScoped<JBHRIS.Api.Service.Employee.Normal.IEmployeeRoleService, JBHRIS.Api.Service.Employee.Normal.EmployeeRoleService>();
            services.AddScoped<JBHRIS.Api.Service.Employee.View.IEmployeeViewService, JBHRIS.Api.Service.Employee.View.EmployeeViewService>();
            services.AddScoped<JBHRIS.Api.Service.Employee.View.IDeptViewService, JBHRIS.Api.Service.Employee.Normal.DeptViewService>();
            services.AddScoped<JBHRIS.Api.Service.Employee.View.IJobViewService, JBHRIS.Api.Service.Employee.View.JobViewService>();
            services.AddScoped<JBHRIS.Api.Service.Employee.View.IUserPasswordService, JBHRIS.Api.Service.Employee.View.UserPasswordService>();
            services.AddScoped<JBHRIS.Api.Service.Employee.View.IEmployeeJobStatusService, JBHRIS.Api.Service.Employee.View.EmployeeJobStatusService>();
            services.AddScoped<JBHRIS.Api.Service.UserInfoService, JBHRIS.Api.Service.UserInfoService>();
            services.AddScoped<JBHRIS.Api.Service.UserValidateService, JBHRIS.Api.Service.UserValidateService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.IWorkScheduleFactory, JBHRIS.Api.Service.Attendance.WorkScheduleFactory>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.IWorkScheduleCheckService, JBHRIS.Api.Service.Attendance.WorkScheduleCheckService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.IWorkFromHomeService, JBHRIS.Api.Service.Attendance.WorkFromHomeService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.ITemperoturyReportService, JBHRIS.Api.Service.Attendance.TemperoturyReportService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.IWorkLogService, JBHRIS.Api.Service.Attendance.WorkLogService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Normal.ICardService, JBHRIS.Api.Service.Attendance.Normal.CardService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Normal.IAttCardService, JBHRIS.Api.Service.Attendance.Normal.AttCardService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Normal.IRoteChangeService, JBHRIS.Api.Service.Attendance.Normal.RoteChangeService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Normal.IShiftChangeService, JBHRIS.Api.Service.Attendance.Normal.ShiftChangeService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Normal.IAbsenceService, JBHRIS.Api.Service.Attendance.Normal.AbsenceService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Normal.IAbsenceCancelService, JBHRIS.Api.Service.Attendance.Normal.AbsenceCancelService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Normal.IAttendanceService, JBHRIS.Api.Service.Attendance.Normal.AttendanceService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Normal.IOvertimeService, JBHRIS.Api.Service.Attendance.Normal.OvertimeService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Normal.IDiversionGroupService, JBHRIS.Api.Service.Attendance.Normal.DiversionGroupService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Normal.IDiversionShiftService, JBHRIS.Api.Service.Attendance.Normal.DiversionShiftService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Normal.IDiversionAttendTypeService, JBHRIS.Api.Service.Attendance.Normal.DiversionAttendTypeService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.View.IAbsenceEntitleViewService, JBHRIS.Api.Service.Attendance.View.AbsenceEntitleViewService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.View.IAbsenceTakenViewService, JBHRIS.Api.Service.Attendance.View.AbsenceTakenViewService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.View.IOverTimeViewService, JBHRIS.Api.Service.Attendance.View.OverTimeViewService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.View.ICardViewService, JBHRIS.Api.Service.Attendance.View.CardViewService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.View.IAbnormalViewService, JBHRIS.Api.Service.Attendance.View.AbnormalViewService>();
            services.AddScoped<JBHRIS.Api.Service._System.View.ISysRoleViewService, JBHRIS.Api.Service._System.View.SysRoleViewService>();
            services.AddScoped<JBHRIS.Api.Service._System.View.ISysRolePageService, JBHRIS.Api.Service._System.View.SysRolePageService>();
            services.AddScoped<JBHRIS.Api.Service._System.View.ISysPageApiVoidService, JBHRIS.Api.Service._System.View.SysPageApiVoidService>();
            services.AddScoped<JBHRIS.Api.Service._System.View.ISysUserRoleViewService, JBHRIS.Api.Service._System.View.SysUserRoleViewService>();
            services.AddScoped<JBHRIS.Api.Service._System.View.ISysApiVoidBlackListService, JBHRIS.Api.Service._System.View.SysApiVoidBlackListService>();
            services.AddScoped<JBHRIS.Api.Service._System.View.ISysApiVoidWhiteListService, JBHRIS.Api.Service._System.View.SysApiVoidWhiteListService>();
            services.AddScoped<JBHRIS.Api.Service._System.View.ISysApiVoidService, JBHRIS.Api.Service._System.View.SysApiVoidService>();
            services.AddScoped<JBHRIS.Api.Service._System.View.ISysNewsService, JBHRIS.Api.Service._System.View.SysNewsService>();
            services.AddScoped<JBHRIS.Api.Service.Token.IRefreshTokenService, JBHRIS.Api.Service.Token.RefreshTokenService>();
            services.AddScoped<JBHRIS.Api.Service.Token.IClientTokenService, JBHRIS.Api.Service.Token.ClientTokenService>();
            services.AddScoped<JBHRIS.Api.Service.Menu.View.IMenuService, JBHRIS.Api.Service.Menu.View.MenuService>();
            services.AddScoped<JBHRIS.Api.Service.Files.View.IFilesService, JBHRIS.Api.Service.Files.View.FilesService>();
            services.AddScoped<JBHRIS.Api.Service.Salary.View.ISalaryViewService, JBHRIS.Api.Service.Salary.View.SalaryViewService>();
            services.AddScoped<JBHRIS.Api.Service.Mail.View.IMailService, JBHRIS.Api.Service.Mail.View.MailService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.ITranscardService, JBHRIS.Api.Service.Attendance.Normal.TranscardService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.ITransCardService, JBHRIS.Api.Service.Attendance.TransCardService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Normal.IAbsenceCalculateService, JBHRIS.Api.Service.Attendance.Normal.AbsenceCalculateService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Action.ITimetableGenerateService, JBHRIS.Api.Service.Attendance.Action.TimetableGenerateService>();
            services.AddScoped<CurrentUser, CurrentUser>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Action.IAttendanceGenerateService, JBHRIS.Api.Service.Attendance.Action.AttendanceGenerateService>();
            
            services.AddScoped<JBHRIS.Api.Service.Attendance.Normal.IAbnormalService, JBHRIS.Api.Service.Attendance.Normal.AbnormalService>();


            #endregion

            #region Dal

            services.AddScoped<JBHRIS.Api.Dal.Employee.IEmployee_Normal_GetEmployeeInfo, JBHRIS.Api.Dal.JBHR.Employee.Employee_Normal_GetEmployeeInfo>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.IEmployee_Normal_GetPeopleByDept, JBHRIS.Api.Dal.JBHR.Employee.Employee_Normal_GetPeopleByDept>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.IEmployee_Normal_GetPeopleByDepta, JBHRIS.Api.Dal.JBHR.Employee.Employee_Normal_GetPeopleByDepta>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.Normal.IEmployee_Normal_EmployeeInfoRepository, JBHRIS.Api.Dal.JBHR.Employee.Normal.Employee_Normal_EmployeeInfoRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.Normal.IEmployee_Normal_GetPeopleByLeaveDate, JBHRIS.Api.Dal.JBHR.Employee.Employee_Normal_GetPeopleByLeaveDate>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.Normal.IEmployee_Normal_GetPeopleByOnBoardDate, JBHRIS.Api.Dal.JBHR.Employee.Normal.Employee_Normal_GetPeopleByOnBoardDate>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetEmployee, JBHRIS.Api.Dal.JBHR.Employee.Employee_View_GetEmployee>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetEmployeeJob, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetEmployeeJob>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetDept, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetDept>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetDepts, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetDepts>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetDepta, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetDepta>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetJob, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetJob>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetJobl, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetJobl>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetJobo, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetJobo>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetJobs, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetJobs>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_EmployeeJobStatus, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_EmployeeJobStatus>();
            services.AddScoped<JBHRIS.Api.Dal._System.IUserValidateDal, JBHRIS.Api.Dal.JBHR._System.UserValidateDal>();
            services.AddScoped<EmployeeRoleService, EmployeeRoleService>();

            services.AddScoped<JBHRIS.Api.Dal.Employee.Normal.IEmployee_Normal_EmployeePasswordRepository, JBHRIS.Api.Dal.JBHR.Employee.Normal.Employee_Normal_EmployeePasswordRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.Normal.IEmployee_Normal_GetPeopleByBirthday, JBHRIS.Api.Dal.JBHR.Employee.Employee_Normal_GetPeopleByBirthday>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetEmployeeBirthday, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetEmployeeBirthday>();

            services.AddScoped<JBHRIS.Api.Dal.Attendance.IWorkscheduleCheck_ScheduleTypeRepository, JBHRIS.Api.Dal.JBHR.Attendance.WorkscheduleCheck_ScheduleTypeRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.ICalendarHolidayRepository, JBHRIS.Api.Dal.JBHR.Attendance.CalendarHolidayRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.ICard_Normal_UpdateAttCard, JBHRIS.Api.Dal.JBHR.Attendance.Normal.Card_Normal_UpdateAttCard>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.ICard_Normal_GetCardApply, JBHRIS.Api.Dal.JBHR.Attendance.Normal.Card_Normal_GetCardApply>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.ICard_Normal_SaveAttCard, JBHRIS.Api.Dal.JBHR.Attendance.Normal.Card_Normal_SaveAttCard>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.ICard_Normal_GetAttCard, JBHRIS.Api.Dal.JBHR.Attendance.Normal.Card_Normal_GetAttCard>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.ICardReasonRepository, JBHRIS.Api.Dal.JBHR.Attendance.Normal.CardReasonRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.ICardRepository, JBHRIS.Api.Dal.JBHR.Attendance.Normal.CardRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.ICard_Normal_SaveForgetCard, JBHRIS.Api.Dal.JBHR.Attendance.Normal.Card_Normal_SaveForgetCard>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.ICard_Normal_CheckForgetCard, JBHRIS.Api.Dal.JBHR.Attendance.Normal.Card_Normal_CheckForgetCard>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IRoteChangeRepository, JBHRIS.Api.Dal.JBHR.Attendance.Normal.RoteChangeRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IRote_Normal_CheckLongShiftChange, JBHRIS.Api.Dal.JBHR.Attendance.Normal.Rote_Normal_CheckLongShiftChange>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IShiftChange_Normal_SaveDayShiftChange, JBHRIS.Api.Dal.JBHR.Attendance.Normal.ShiftChange_Normal_SaveDayShiftChange>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IShiftChange_Normal_CheckDayShiftChange, JBHRIS.Api.Dal.JBHR.Attendance.Normal.ShiftChange_Normal_CheckDayShiftChange>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IAbsenceTakenRepository, JBHRIS.Api.Dal.JBHR.Attendance.Normal.AbsenceTakenRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IAbsenceCancelRepository, JBHRIS.Api.Dal.JBHR.Attendance.Normal.AbsenceCancelRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IAbsenceCancel_Normal_GetCancelableLeave, JBHRIS.Api.Dal.JBHR.Attendance.Normal.AbsenceCancel_Normal_GetCancelableLeave>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.ICardMachineSettingDal, JBHRIS.Api.Dal.JBHR.Attendance.Normal.CardMachineSettingDal>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IAbsence_Normal_GetHcodeTypes, JBHRIS.Api.Dal.JBHR.Attendance.Normal.Absence_Normal_GetHcodeTypes>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IAbsence_Normal_GetHcodeTypesByHcode, JBHRIS.Api.Dal.JBHR.Attendance.Normal.Absence_Normal_GetHcodeTypesByHcode>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IAbsence_Normal_GetAbsBalance, JBHRIS.Api.Dal.JBHR.Attendance.Normal.Absence_Normal_GetAbsBalance>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IAbsence_Normal_GetHcode, JBHRIS.Api.Dal.JBHR.Attendance.Normal.Absence_Normal_GetHcode>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IAttend_Normal_InsertAttend, JBHRIS.Api.Dal.JBHR.Attendance.Normal.Attend_Normal_InsertAttend>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IAttend_Normal_UpdateAttend, JBHRIS.Api.Dal.JBHR.Attendance.Normal.Attend_Normal_UpdateAttend>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IDiversionGroup_Normal_GetDiversionGroup, JBHRIS.Api.Dal.JBHR.Attendance.Normal.DiversionGroup_Normal_GetDiversionGroup>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IDiversionShift_Normal_GetDiversionShift, JBHRIS.Api.Dal.JBHR.Attendance.Normal.DiversionShift_Normal_GetDiversionShift>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IDiversionAttendType_Normal_GetDiversionAttendType, JBHRIS.Api.Dal.JBHR.Attendance.Normal.DiversionAttendType_Normal_GetDiversionAttendType>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IWorkFromHome_Normal_GetTemperoturyReport, JBHRIS.Api.Dal.JBHR.Attendance.Normal.WorkFromHome_Normal_GetTemperoturyReport>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IWorkFromHome_Normal_InsertTemperoturyReport, JBHRIS.Api.Dal.JBHR.Attendance.Normal.WorkFromHome_Normal_InsertTemperoturyReport>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IWorkFromHome_Normal_UpdateTemperoturyReport, JBHRIS.Api.Dal.JBHR.Attendance.Normal.WorkFromHome_Normal_UpdateTemperoturyReport>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IWorkFromHome_Normal_DeleteTemperoturyReport, JBHRIS.Api.Dal.JBHR.Attendance.Normal.WorkFromHome_Normal_DeleteTemperoturyReport>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IWorkFromHome_Normal_GetWorkLog, JBHRIS.Api.Dal.JBHR.Attendance.Normal.WorkFromHome_Normal_GetWorkLog>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IWorkFromHome_Normal_InsertWorkLog, JBHRIS.Api.Dal.JBHR.Attendance.Normal.WorkFromHome_Normal_InsertWorkLog>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IWorkFromHome_Normal_UpdateWorkLog, JBHRIS.Api.Dal.JBHR.Attendance.Normal.WorkFromHome_Normal_UpdateWorkLog>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IWorkFromHome_Normal_DeleteWorkLog, JBHRIS.Api.Dal.JBHR.Attendance.Normal.WorkFromHome_Normal_DeleteWorkLog>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IOvertime_Normal_GetOvertimeByDate, JBHRIS.Api.Dal.JBHR.Attendance.Normal.Overtime_Normal_GetOvertimeByDate>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.View.IAttend_View_GetAttendRote, JBHRIS.Api.Dal.JBHR.Attendance.View.Attend_View_GetAttendRote>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.View.IAttend_View_Abnormal, JBHRIS.Api.Dal.JBHR.Attendance.View.Attend_View_Abnormal>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.View.IAttend_View_GetAbsenceEntitleView, JBHRIS.Api.Dal.JBHR.Attendance.View.Attend_View_GetAbsenceEntitleView>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.View.IAttend_View_GetAbsenceTakenView, JBHRIS.Api.Dal.JBHR.Attendance.View.Attend_View_GetAbsenceTakenView>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.View.IAttend_View_GetOvertimeSearch, JBHRIS.Api.Dal.JBHR.Attendance.View.Attend_View_GetOvertimeSearch>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.View.IAttend_View_GetCardSearch, JBHRIS.Api.Dal.JBHR.Attendance.View.Attend_View_GetCardSearch>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.View.IAttend_View_GetAbnormalSearch, JBHRIS.Api.Dal.JBHR.Attendance.View.Attend_View_GetAbnormalSearch>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IAttend_Abs_Absd_CompositeDal, JBHRIS.Api.Dal.JBHR.Attendance.View.Attend_Abs_Absd_CompositeDal>();

            services.AddScoped<JBHRIS.Api.Dal._System.ISystem_UserDal, JBHRIS.Api.Dal.JBHR._System.System_UserDal>();
            services.AddScoped<JBHRIS.Api.Dal._System.ISystem_UserDataRole, JBHRIS.Api.Dal.JBHR._System.System_UserDataRole>();
            services.AddScoped<JBHRIS.Api.Dal._System.View.ISystem_View_SysRelcode, JBHRIS.Api.Dal.JBHR._System.View.System_View_SysRelcode>();
            services.AddScoped<JBHRIS.Api.Dal.Token.IRefreshToken_View, JBHRIS.Api.Dal.JBHR.Token.RefreshToken_View>();
            services.AddScoped<JBHRIS.Api.Dal.Token.IClientToken_View, JBHRIS.Api.Dal.JBHR.Token.ClientToken_View>();
            services.AddScoped<JBHRIS.Api.Dal.Menu.View.IMenu_View_GetMenu, JBHRIS.Api.Dal.JBHR.Menu.View.Menu_View_GetMenu>();
            services.AddScoped<JBHRIS.Api.Dal.Files.View.IFileInfo_View_GetFileInfo, JBHRIS.Api.Dal.JBHR.Files.View.FileInfo_View_GetFileInfo>();
            services.AddScoped<JBHRIS.Api.Dal.Files.View.IFileInfo_View_ImportExceltToTmtTableImport, JBHRIS.Api.Dal.JBHR.Files.View.FileInfo_View_ImportExceltToTmtTableImport>();

            services.AddScoped<JBHRIS.Api.Dal.Salary.View.ISalary_View_SalaryView, JBHRIS.Api.Dal.JBHR.Salary.View.Salary_View_SalaryView>();
            services.AddScoped<JBHRIS.Api.Dal.Salary.View.ISalary_View_SalaryChangeView, JBHRIS.Api.Dal.JBHR.Salary.View.Salary_View_SalaryChangeView>();

            services.AddScoped<JBHRIS.Api.Dal._System.View.ISystem_View_SysRole, JBHRIS.Api.Dal.JBHR._System.System_View_SysRole>();
            services.AddScoped<JBHRIS.Api.Dal._System.View.ISystem_View_SysRolePage, JBHRIS.Api.Dal.JBHR._System.System_View_SysRolePage>();
            services.AddScoped<JBHRIS.Api.Dal._System.View.ISystem_View_SysPageApiVoid, JBHRIS.Api.Dal.JBHR._System.System_View_SysPageApiVoid>();
            services.AddScoped<JBHRIS.Api.Dal._System.View.ISystem_View_SysUserRole, JBHRIS.Api.Dal.JBHR._System.System_View_SysUserRole>();
            services.AddScoped<JBHRIS.Api.Dal._System.View.ISystem_View_SysApiVoidBlackList, JBHRIS.Api.Dal.JBHR._System.System_View_SysApiVoidBlackList>();
            services.AddScoped<JBHRIS.Api.Dal._System.View.ISystem_View_SysApiVoidWhiteList, JBHRIS.Api.Dal.JBHR._System.System_View_SysApiVoidWhiteList>();
            services.AddScoped<JBHRIS.Api.Dal._System.View.ISystem_View_SysApiVoid, JBHRIS.Api.Dal.JBHR._System.System_View_SysApiVoid>();
            services.AddScoped<JBHRIS.Api.Dal._System.View.ISystem_View_SysNews, JBHRIS.Api.Dal.JBHR._System.View.System_View_SysNews>();

            services.AddScoped<JBHRIS.Api.Dal.Mail.View.IMailqueue_View_GetMailqueue, JBHRIS.Api.Dal.JBHR.Mail.View.Mailqueue_View_GetMailqueue>();
            services.AddScoped<JBHRIS.Api.Dal.Mail.View.IParameter_View_GetParameter, JBHRIS.Api.Dal.JBHR.Mail.View.Parameter_View_GetParameter>();

            #endregion

            #region Bll

            services.AddScoped<JBHRIS.Api.Bll.Attendance.Normal.ICardTextRecordConvertBll, JBHRIS.Api.Bll.Attendance.CardTextRecordConvertBll>();
            services.AddScoped<JBHRIS.Api.Bll.Salary.Payroll.ISalaryEncrypt, JBHRIS.Api.Bll.Salary.Payroll.SalaryEncrypt>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.IWorkScheduleFactory, JBHRIS.Api.Service.Attendance.WorkScheduleFactory>();
            services.AddScoped<JBHRIS.Api.Bll.Attendance.Action.IAbsence_Action_CalculateBll, JBHRIS.Api.Bll.Attendance.Action.Absence_Action_CalculateBll>();
            services.AddScoped<JBHRIS.Api.Bll.Attendance.IAttendCardBll, JBHRIS.Api.Bll.Attendance.AttendCardBll>();
            services.AddScoped<JBHRIS.Api.Bll.Attendance.Action.ITimetableGenerateBll, JBHRIS.Api.Bll.Attendance.Action.TmtableGenerateBll>();
            services.AddScoped<JBHRIS.Api.Bll.Attendance.Action.IAttendanceGenerateBll, JBHRIS.Api.Bll.Attendance.Action.AttendanceGenerateBll>();
            #endregion

            services.AddScoped<JBHRIS.Api.Dal.JBHR.Repository.IUnitOfWork, JBHRIS.Api.Dal.JBHR.Repository.JbhrUnitOfWork>();
            services.AddScoped<DbContext, JBHRIS.Api.Dal.JBHR.JBHRContext>();

            return services;
        }
    }
    public class CompositeIocConfig//<TSource, TTarget> where TSource : TTarget
    {
        private IServiceCollection _services;
        private ContainerBuilder _containerBuilder;
        public CompositeIocConfig(IServiceCollection services, ContainerBuilder containerBuilder)
        {
            _services = services;
            _containerBuilder = containerBuilder;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        public void AddScoped<TSource, TTarget>() where TSource : class where TTarget : class, TSource
        {
            _services.AddScoped<TSource, TTarget>();
            _containerBuilder.RegisterType<TTarget>().As<TSource>();
        }
        public void AddSingleton<TSource>(TSource target) where TSource : class// where TTarget : class, TSource
        {
            _services.AddSingleton<NLog.ILogger>(NLog.LogManager.GetLogger("HR"));
            _containerBuilder.RegisterInstance(NLog.LogManager.GetLogger("HR")).As<TSource>();
        }
    }
}
