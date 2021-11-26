using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public class AttendCardRepo:IRepository<Dto.AttcardDto,Dto.AttcardCondition>
    {
        #region IRepository<AttcardDto,AttcardCondition> 成員

        public virtual bool Insert(Dto.AttcardDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Update(Dto.AttcardDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(Dto.AttcardDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }
        public virtual List<Dto.AttcardDto> GetInstanceByEmployeeDate(string EmployeeID,DateTime AttendanceDate)
        {
            throw new NotImplementedException();
        }
        public virtual Dto.AttcardDto GetInstanceByID(object id)
        {
            throw new NotImplementedException();
        }

        public virtual List<Dto.AttcardDto> GetDataByCondition(Dto.AttcardCondition condition)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
