using JBHRIS.Api.Dto.Attendance.Normal;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface ICardMachineSettingDal
    {
        CardMachineSettingDto GetCardMachineSetting(string settingId);
    }
}