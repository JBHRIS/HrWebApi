using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public class EntitleCodeRepo : JBHRIS.BLL.IRepository<Dto.EntitleCodeDto, Dto.EntitleCodeCondition>
    {
        #region IRepository<EntitleCodeDto,EntitleCodeCondition> 成員

        public virtual bool Insert(Dto.EntitleCodeDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Update(Dto.EntitleCodeDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(Dto.EntitleCodeDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual Dto.EntitleCodeDto GetInstanceByID(object id)
        {
            throw new NotImplementedException();
        }

        public virtual List<Dto.EntitleCodeDto> GetDataByCondition(Dto.EntitleCodeCondition condition)
        {
            throw new NotImplementedException();
        }
        public virtual List<Dto.EntitleCodeDto> GetDataByAll()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
