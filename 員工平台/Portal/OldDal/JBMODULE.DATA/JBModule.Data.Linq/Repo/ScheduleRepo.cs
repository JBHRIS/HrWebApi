using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class ScheduleRepo : JBHRIS.BLL.Repo.IScheduleRepo
    {
        public ScheduleRepo()
        {
            MaxRetry = 5;
        }
        #region IScheduleRepo 成員

        public List<JBHRIS.BLL.Repo.ISchedule> GetScheduleList()
        {
            JBModule.Data.Linq.HrDBDataContext db = new Linq.HrDBDataContext();
            var sql = (from a in db.ScheduleQueue
                       join b in db.ScheduleItem on a.ScheduleID equals b.Auto
                       where a.RunTime < DateTime.Now && !a.IsSuccess && a.Retry < MaxRetry
                       select new { ScheduleQueue = a, ScheduleItem = b }).ToList();
            List<JBHRIS.BLL.Repo.ISchedule> scheduleList = new List<JBHRIS.BLL.Repo.ISchedule>();
            foreach (var it in sql)
            {
                var assembly = JBTools.IO.FindAssembly.GetAssembly(it.ScheduleItem.AssemblyName);
                if (assembly != null)
                {
                    var cls = assembly.CreateInstance(it.ScheduleItem.ClassName) as JBHRIS.BLL.Repo.ISchedule;
                    if (cls != null)
                    {
                        scheduleList.Add(cls);
                    }
                }
            }
            return scheduleList;
        }

        #endregion

        #region IScheduleRepo 成員

        public int MaxRetry
        {
            get;

            set;
        }

        #endregion
    }
}
