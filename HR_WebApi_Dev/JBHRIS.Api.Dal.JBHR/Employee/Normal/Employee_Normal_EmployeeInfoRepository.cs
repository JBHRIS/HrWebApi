using JBHRIS.Api.Dal.Employee.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Employee.Normal;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee.Normal
{
    public class Employee_Normal_EmployeeInfoRepository : IEmployee_Normal_EmployeeInfoRepository
    {
        private IUnitOfWork _unitOfWork;

        public Employee_Normal_EmployeeInfoRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool Update(EmployeeInfoDto empInfo)
        {
            var baseRepo = _unitOfWork.Repository<Base>();
            var baseData = baseRepo.Read(p => p.Nobr == empInfo.EmployeeId);
            if (baseData != null)
            {
                baseData.Addr1 = empInfo.Address1;
                baseData.Addr2 = empInfo.Address2;
                baseData.Birdt = empInfo.Birthday;
                baseData.Idno = empInfo.IdNo;
                baseData.NameP = empInfo.PassportId;
                baseData.Matno = empInfo.ResidentCertificateId;
                baseData.Sex = empInfo.Sex;
                baseData.Tel1 = empInfo.TelphoneNo;
                baseRepo.Update(baseData);
                return true;
            }
            else return false;
        }
    }
}
