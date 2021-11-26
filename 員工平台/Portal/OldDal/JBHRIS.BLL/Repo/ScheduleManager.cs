using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public class ScheduleManager
    {
        IRepoHelper helper;
        public ScheduleManager(IRepoHelper Helper)
        {
            helper = Helper;
        }

        /// <summary>
        /// 取得待執行排程清單(現在含之前未完成的項目)
        /// </summary>
        /// <returns></returns>
        List<ISchedule> GetScheduleList()
        {
            var scheduleRepo = helper.GetScheduleRepo();
            return scheduleRepo.GetScheduleList();
        }

        public virtual bool Run(out string Msg)
        {
            Msg = "";
            foreach (var it in GetScheduleList())
            {
                string ScheduleMsg = "";
                if (!it.Run(out ScheduleMsg))
                    helper.GetLogger().WriteLog(new Dto.LogMessage { Message = ScheduleMsg, minlevel = "Error" });
                else helper.GetLogger().WriteLog(new Dto.LogMessage { Message = "1234", minlevel = "Error" });
            }
            return true;
        }
    }
}
