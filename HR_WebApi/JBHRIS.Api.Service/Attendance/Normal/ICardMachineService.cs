using JBHRIS.Api.Dto.Attendance.Normal;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface ICardMachineService
    {
        CardMachineSettingDto GetCardMachineSetting(string SettingId);
        List<CardTextRecordDto> GetCardTextRecords(string SettingId, string TextFileFolder, string encoding, string FileExtension = ".txt");
        CardTextRecordDto InsertCardTextRecord(CardTextRecordDto cardTextRecord);
    }
}
