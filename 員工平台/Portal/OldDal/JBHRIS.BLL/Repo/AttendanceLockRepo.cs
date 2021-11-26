using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public class AttendanceLockRepo : IRepository<Dto.AttendanceLockDto, Dto.AttendanceLockCondition>
    {
        public static int AttendanceCloseDay = 31;
        Dictionary<DateTime, Dto.AttendanceLockDto> _Cache = new Dictionary<DateTime, Dto.AttendanceLockDto>();
        #region IRepository<AttendanceLockDto,AttendanceLockCondition> 成員

        public bool Insert(Dto.AttendanceLockDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public bool Update(Dto.AttendanceLockDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Dto.AttendanceLockDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public Dto.AttendanceLockDto GetInstanceByID(object id)
        {
            throw new NotImplementedException();
        }

        public virtual List<Dto.AttendanceLockDto> GetDataByCondition(Dto.AttendanceLockCondition condition)
        {
            throw new NotImplementedException();
        }
        public virtual List<Dto.AttendanceLockDto> GetCacheDataByCondition(Dto.AttendanceLockCondition condition)
        {
            List<Dto.AttendanceLockDto> results = new List<Dto.AttendanceLockDto>();
            for (DateTime dd = condition.DateBegin; dd <= condition.DateEnd; dd = dd.AddDays(1))
            {
                if (_Cache.ContainsKey(dd))
                    results.Add(_Cache[dd]);
                else
                {
                    Dto.AttendanceLockCondition cond = new Dto.AttendanceLockCondition();
                    cond.DateBegin = dd;
                    cond.DateEnd = dd;
                    var data = GetDataByCondition(condition);
                    if (data.Any())
                    {
                        results.Add(new Dto.AttendanceLockDto
                        {
                            AttendanceDate = dd,
                            LockedDatagroupList = data.First().LockedDatagroupList,
                        });
                    }
                    else
                    {
                        results.Add(new Dto.AttendanceLockDto
                        {
                            AttendanceDate = dd,
                            LockedDatagroupList = new List<string>(),//留空，代表無鎖檔，但是已快取
                        });
                    }
                }
            }
            return results;
        }
        public virtual string GetDatagroup(string EmployeeID, DateTime AttendanceDate)
        {
            throw new NotImplementedException();
        }
        public virtual string GetYYMM(string EmployeeID, DateTime AttendanceDate)
        {
            DateTime chkDate = AttendanceDate;
            Dto.AttendanceLockCondition cond = new Dto.AttendanceLockCondition();
            cond.DateBegin = AttendanceDate;
            cond.DateEnd = AttendanceDate;
            var data = GetCacheDataByCondition(cond);
            var datagroup = GetDatagroup(EmployeeID, AttendanceDate);
            var chk = from a in data where a.LockedDatagroupList.Contains(datagroup) && a.AttendanceDate == AttendanceDate select a;
            if (chk.Any())
            {
                chkDate = chkDate.AddMonths(1);
                return GetYYMM(EmployeeID, chkDate);
            }
            if(chkDate.Day>AttendanceCloseDay)
                chkDate = chkDate.AddMonths(1);
            return chkDate.ToString("yyyyMM");
        }

        #endregion
    }
}
