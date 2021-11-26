using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public class OtRepo : IRepository<Dto.OtDto, Dto.OtCondition>
    {

        #region IRepository<OtDto,OtCondition> 成員

        public virtual bool Insert(Dto.OtDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Update(Dto.OtDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(Dto.OtDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual Dto.OtDto GetInstanceByID(object id)
        {
            throw new NotImplementedException();
        }

        public virtual List<Dto.OtDto> GetDataByCondition(Dto.OtCondition condition)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
