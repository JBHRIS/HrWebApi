using HR_WebApi.Api.Dto;
using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class AbsenceService : IAbsenceService
    {
        private IAbsenceTakenRepository _absenceTakenRepository;
        private IAbsenceCancelRepository _absenceCancelRepository;
        private ILogger _logger;
        private IAbsence_Normal_GetAbsBalance _absence_Normal_GetAbsBalance;
        private IAbsence_Normal_GetAbsenceCancel _absence_Normal_GetAbsenceCancel;
        private IAbsence_Normal_GetAbsenceTaken _absence_Normal_GetAbsenceTaken;
        private IAbsence_Normal_GetHcode _absence_Normal_GetHcode;
        private IAbsence_Normal_GetPeopleAbs _absence_Normal_GetPeopleAbs;

        public AbsenceService(IAbsenceTakenRepository absenceTakenRepository, IAbsenceCancelRepository absenceCancelRepository, ILogger logger)
        {
            _absenceTakenRepository = absenceTakenRepository;
            _absenceCancelRepository = absenceCancelRepository;
            _logger = logger;
        }

        public AbsenceService(IAbsence_Normal_GetAbsBalance absence_Normal_GetAbsBalance, IAbsence_Normal_GetAbsenceCancel absence_Normal_GetAbsenceCancel
            , IAbsence_Normal_GetAbsenceTaken absence_Normal_GetAbsenceTaken, IAbsence_Normal_GetHcode absence_Normal_GetHcode
            , IAbsence_Normal_GetPeopleAbs absence_Normal_GetPeopleAbs)
        {
            _absence_Normal_GetAbsBalance = absence_Normal_GetAbsBalance;
            _absence_Normal_GetAbsenceCancel = absence_Normal_GetAbsenceCancel;
            _absence_Normal_GetAbsenceTaken = absence_Normal_GetAbsenceTaken;
            _absence_Normal_GetHcode = absence_Normal_GetHcode;
            _absence_Normal_GetPeopleAbs = absence_Normal_GetPeopleAbs;
        }
        public List<AbsenceBalanceDto> GetAbsBalance(AbsenceEntry absenceEntryDto)
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
            return _absence_Normal_GetPeopleAbs.GetPeopleAbs(absenceEntryDto);
        }
    }
}
