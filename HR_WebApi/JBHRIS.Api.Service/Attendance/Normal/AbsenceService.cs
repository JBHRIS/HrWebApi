using HR_WebApi.Api.Dto;
using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Absence.Entry;
using JBHRIS.Api.Dto.Absence.View;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Tools;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Configuration;
using JBHRIS.Api.Dal.Employee;
using JBHRIS.Api.Service.Salary.View;
using System.Security.Claims;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class AbsenceService : IAbsenceService
    {       
        private IConfiguration _configuration;
        private IAbsenceTakenRepository _absenceTakenRepository;
        private IAbsenceCancelRepository _absenceCancelRepository;
        private ILogger _logger;
        private IAbsence_Normal_GetAbsBalance _absence_Normal_GetAbsBalance;
        private IAbsence_Normal_GetHcodeTypes _absence_Normal_GetHcodeTypes;
        private IAbsence_Normal_GetHcodeTypesByHcode _absence_Normal_GetHcodeTypesByHcode;
        private IAttend_View_GetAttendRote _attend_View_GetAttendRote;
        private IAbsence_Normal_GetHcode _absence_Normal_GetHcode;
        private IEmployee_Normal_GetEmployeeInfo _employee_Normal_GetEmployeeInfo;
        private IAttend_View_GetAbsenceTakenView _attend_View_GetAbsenceTakenView;
        private ISalaryViewService _salaryViewService;
        //private IAbsence_Normal_GetAbsenceCancel _absence_Normal_GetAbsenceCancel;
        //private IAbsence_Normal_GetAbsenceTaken _absence_Normal_GetAbsenceTaken;
        //private IAbsence_Normal_GetPeopleAbs _absence_Normal_GetPeopleAbs;

        public AbsenceService(IAbsenceTakenRepository absenceTakenRepository,
            IAbsenceCancelRepository absenceCancelRepository,
            ILogger logger,
            IAbsence_Normal_GetHcodeTypes absence_Normal_GetHcodeTypes,
            IAbsence_Normal_GetHcodeTypesByHcode absence_Normal_GetHcodeTypesByHcode,
            IAbsence_Normal_GetAbsBalance absence_Normal_GetAbsBalance,
            IAttend_View_GetAttendRote attend_View_GetAttendRote,
            IAbsence_Normal_GetHcode absence_Normal_GetHcode,
            IConfiguration configuration,
            IEmployee_Normal_GetEmployeeInfo employee_Normal_GetEmployeeInfo,
            IAttend_View_GetAbsenceTakenView attend_View_GetAbsenceTakenView,
            ISalaryViewService salaryViewService
            //IAbsence_Normal_GetAbsenceCancel absence_Normal_GetAbsenceCancel,
            //IAbsence_Normal_GetAbsenceTaken absence_Normal_GetAbsenceTaken,
            //IAbsence_Normal_GetPeopleAbs absence_Normal_GetPeopleAbs
            )
        {
            _absenceTakenRepository = absenceTakenRepository;
            _absenceCancelRepository = absenceCancelRepository;
            _absence_Normal_GetHcodeTypes = absence_Normal_GetHcodeTypes;
            _absence_Normal_GetHcodeTypesByHcode = absence_Normal_GetHcodeTypesByHcode;
            _logger = logger;
            _absence_Normal_GetAbsBalance = absence_Normal_GetAbsBalance;
            _attend_View_GetAttendRote = attend_View_GetAttendRote;
            _absence_Normal_GetHcode = absence_Normal_GetHcode;
            _configuration = configuration;
            _employee_Normal_GetEmployeeInfo = employee_Normal_GetEmployeeInfo;
            _attend_View_GetAbsenceTakenView = attend_View_GetAbsenceTakenView;
            _salaryViewService = salaryViewService;
            //_absence_Normal_GetAbsenceCancel = absence_Normal_GetAbsenceCancel;
            //_absence_Normal_GetAbsenceTaken = absence_Normal_GetAbsenceTaken;
            //_absence_Normal_GetPeopleAbs = absence_Normal_GetPeopleAbs;
        }

        public List<AbsenceBalanceDto> GetAbsBalance(AbsenceBalanceEntry absenceEntryDto)
        {
            return _absence_Normal_GetAbsBalance.GetAbsBalance(absenceEntryDto);
        }
        /// <summary>
        /// 取得銷假資料
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        public List<AbsenceCancelDto> GetAbsenceCancel(AbsenceEntry absenceEntryDto)
        {
            _logger.Info("開始呼叫AbsenceRepository.GetAbsenceCancel");
            return _absenceCancelRepository.GetAbsenceCancel(absenceEntryDto);
        }
        /// <summary>
        /// 取得請假資料
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        public List<AbsenceTakenDto> GetAbsenceTaken(AbsenceEntry absenceEntryDto)
        {
            _logger.Info("開始呼叫AbsenceRepository.GetAbsenceTaken");
            return _absenceTakenRepository.GetAbsenceTaken(absenceEntryDto);
        }

        public List<HcodeDto> GetHcode()
        {
            return _absence_Normal_GetHcode.GetHcode();
        }

        public List<string> GetPeopleAbs(AbsenceEntry absenceEntryDto)
        {
            throw new NotImplementedException();
            //return _absence_Normal_GetPeopleAbs.GetPeopleAbs(absenceEntryDto);
        }

        public List<HcodeTypeDto> GetHcodeTypes()
        {
            return _absence_Normal_GetHcodeTypes.GetHcodeTypes();
        }

        public List<HcodeDto> GetHcodeTypesByHcode(HcodeTypesByHcodeEntry hcodeTypesByHcodeEntry)
        {
            return _absence_Normal_GetHcodeTypesByHcode.GetHcodeTypesByHcode(hcodeTypesByHcodeEntry);
        }

        
    }
}
