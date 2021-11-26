using HR_WebApi.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class AbsenceService : IAbsenceService
    {
        private IAbsence_Normal_GetAbsBalance _absence_Normal_GetAbsBalance;
        private IAbsence_Normal_GetAbsenceCancel _absence_Normal_GetAbsenceCancel;
        private IAbsence_Normal_GetAbsenceTaken _absence_Normal_GetAbsenceTaken;
        private IAbsence_Normal_GetHcode _absence_Normal_GetHcode;
        private IAbsence_Normal_GetPeopleAbs _absence_Normal_GetPeopleAbs;

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
        public List<AbsenceBalanceDto> GetAbsBalance(AbsenceEntryDto absenceEntryDto)
        {
            return _absence_Normal_GetAbsBalance.GetAbsBalance(absenceEntryDto);
        }

        public List<AbsenceCancelDto> GetAbsenceCancel(AbsenceEntryDto absenceEntryDto)
        {
            return _absence_Normal_GetAbsenceCancel.GetAbsenceCancel(absenceEntryDto);
        }

        public List<AbsenceTakenDto> GetAbsenceTaken(AbsenceEntryDto absenceEntryDto)
        {
            return _absence_Normal_GetAbsenceTaken.GetAbsenceTaken(absenceEntryDto);
        }

        public List<HcodeDto> GetHcode()
        {
            return _absence_Normal_GetHcode.GetHcode();
        }

        public List<string> GetPeopleAbs(AbsenceEntryDto absenceEntryDto)
        {
            return _absence_Normal_GetPeopleAbs.GetPeopleAbs(absenceEntryDto);
        }
    }
}
