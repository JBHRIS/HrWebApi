using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public class EmpAttRepo : IRepository<Dto.EmpAttDto, Dto.EmpAttCondition>
    {

        #region IRepository<EmpAttDto,EmpAttCondition> 成員

        public virtual bool Insert(Dto.EmpAttDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Update(Dto.EmpAttDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(Dto.EmpAttDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual Dto.EmpAttDto GetInstanceByID(object id)
        {
            throw new NotImplementedException();
        }
        public virtual List<JBHRIS.BLL.Dto.EmpAttDto> GetDataAll()
        {
            throw new NotImplementedException();
        }
        public virtual List<Dto.EmpAttDto> GetDataByCondition(Dto.EmpAttCondition condition)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
