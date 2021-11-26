using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public class AttendRepo:IRepository<Dto.AttendDto,Dto.AttendCondition>
    {

        #region IRepository<AttendDto,AttendCondition> 成員

        public virtual bool Insert(Dto.AttendDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Update(Dto.AttendDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(Dto.AttendDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual Dto.AttendDto GetInstanceByID(object id)
        {
            throw new NotImplementedException();
        }
        public virtual Dto.AttendDto GetInstanceByEmployeeDate(string EmployeeID,DateTime AttendanceDate)
        {
            throw new NotImplementedException();
        }
        public virtual List<Dto.AttendDto> GetDataByCondition(Dto.AttendCondition condition)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
