using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public class IncomeOfYearRepo:IRepository<JBHRIS.BLL.Dto.IncomeOfYearDto,JBHRIS.BLL.Dto.IncomeOfYearCondition>
    {
        #region IRepository<IncomeOfYearDto,IncomeOfYearCondition> 成員
        public string KeyMan = "";
        public virtual bool Insert(Dto.IncomeOfYearDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Update(Dto.IncomeOfYearDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(Dto.IncomeOfYearDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual Dto.IncomeOfYearDto GetInstanceByID(object id)
        {
            throw new NotImplementedException();
        }

        public virtual List<Dto.IncomeOfYearDto> GetDataByCondition(Dto.IncomeOfYearCondition condition)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
