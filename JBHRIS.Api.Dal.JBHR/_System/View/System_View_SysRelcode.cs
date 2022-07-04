using JBHRIS.Api.Dal._System.View;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Dal.JBHR._System.View
{
    public class System_View_SysRelcode : ISystem_View_SysRelcode
    {
        public System_View_SysRelcode GetRelcode()
        {
            throw new NotImplementedException();
        }

        private IUnitOfWork _unitOfWork;

        public System_View_SysRelcode(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public List<RelcodeDto> GetRelcodeView()
        {
            var sql = from r in _unitOfWork.Repository<Relcode>().Reads()
                      select new RelcodeDto { RelCode1 = r.RelCode1, RelName = r.RelName };
            return sql.ToList();
        }
    }
}
