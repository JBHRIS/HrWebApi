using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
namespace JBHRIS.BLL.Repo
{
    public class AbsRepo : IRepository<Dto.AbsDto, Dto.AbsCondition>
    {
        public static LeaveCodeRepo LeaveCodeRepo;
        #region IRepository<AbsDto,AbsCondition> 成員
        public AbsRepo()
        {
            LeaveCodeRepo = IOC.Container.Resolve<Repo.LeaveCodeRepo>();
        }

        public virtual bool Insert(Dto.AbsDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }
        public virtual bool Insert(List<Dto.AbsDto> instanceList, out string Msg)
        {
            throw new NotImplementedException();
        }
        public virtual bool Update(Dto.AbsDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(Dto.AbsDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public virtual Dto.AbsDto GetInstanceByID(object id)
        {
            throw new NotImplementedException();
        }

        public virtual List<Dto.AbsDto> GetDataByCondition(Dto.AbsCondition condition)
        {
            throw new NotImplementedException();
        }
        protected virtual bool CheckBalanceConflick(Dto.AbsDto instance, out string ErrorMessage)
        {
            throw new NotImplementedException();
        }
        protected virtual bool CheckTimeConflick(Dto.AbsDto instance, out string ErrorMessage)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
