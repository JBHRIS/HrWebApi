using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public class AbsEntitleRepo : IRepository<Dto.AbsEntitleDto, Dto.AbsEntitleCondition>
    {
        #region IRepository<AbsEntitleDto,AbsEntitleCondition> 成員
        public string KeyMan = "";
        public virtual bool Insert(Dto.AbsEntitleDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Update(Dto.AbsEntitleDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(Dto.AbsEntitleDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual Dto.AbsEntitleDto GetInstanceByID(object id)
        {
            throw new NotImplementedException();
        }

        public virtual List<Dto.AbsEntitleDto> GetDataByCondition(Dto.AbsEntitleCondition condition)
        {
            throw new NotImplementedException();
        }
        public virtual List<Dto.AbsEntitleDto> GetDataByAbsDto(JBHRIS.BLL.Dto.AbsDto instance)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
