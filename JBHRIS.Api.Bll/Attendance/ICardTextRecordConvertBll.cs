using JBHRIS.Api.Dto.Attendance.Normal;
using JBHRIS.Api.Dto.Employee.Normal;
using System.Collections.Generic;

namespace JBHRIS.Api.Bll.Attendance.Normal
{
    public interface ICardTextRecordConvertBll
    {
        CardTextRecordDto Convert_CardTextRecord_To_CardRecord(CardMachineSettingDto cardMachineSetting, List<CardApplyDto> cardApplyDtos,  CardTextRecordDto inputCardText);
    }
}