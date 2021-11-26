using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public class CardRepo : IRepository<Dto.CardDto, Dto.CardCondition>
    {
        #region IRepository<CardDto,CardCondition> 成員

        public virtual bool Insert(Dto.CardDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Update(Dto.CardDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(Dto.CardDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual Dto.CardDto GetInstanceByID(object id)
        {
            throw new NotImplementedException();
        }

        public virtual List<Dto.CardDto> GetDataByCondition(Dto.CardCondition condition)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
