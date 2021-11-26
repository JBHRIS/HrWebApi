using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public class RoteRepo : IRepository<Dto.RoteDto, Dto.RoteCondition>
    {
        #region IRepository<RoteDto,RoteCondition> 成員

        public virtual bool Insert(Dto.RoteDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Update(Dto.RoteDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(Dto.RoteDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual Dto.RoteDto GetInstanceByID(object id)
        {
            throw new NotImplementedException();
        }

        public virtual List<Dto.RoteDto> GetDataByCondition(Dto.RoteCondition condition)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
