using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public class LeaveCodeRepo : IRepository<Dto.LeaveCodeDto, Dto.LeaveCodeCondition>
    {
        #region IRepository<LeaveCodeDto,LeaveCodeCondition> 成員

        public virtual bool Insert(Dto.LeaveCodeDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Update(Dto.LeaveCodeDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(Dto.LeaveCodeDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual Dto.LeaveCodeDto GetInstanceByID(object id)
        {
            //throw new NotImplementedException();
            return new Dto.LeaveCodeDto
            {
                IncludeHoliday = false,
                Interval = 0.5M,
                LeaveCode = "A",
                LeaveCodeDisp = "A",
                LeaveName = "測試",
                LeaveType = "1",
                Min = 0.5M,
                Unit = "小時",
                CheckBalance = false,
            };
        }

        public virtual List<Dto.LeaveCodeDto> GetDataByCondition(Dto.LeaveCodeCondition condition)
        {
            throw new NotImplementedException();
        }
        public virtual List<Dto.LeaveCodeDto> GetDataByAll()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
