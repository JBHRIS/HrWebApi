using JBHRIS.Api.Dal.Employee.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Employee.Normal;
using JBHRIS.Api.Dto.Employee.View;
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
        public bool Update(UpdateEmployeeInfoViewDto empInfo)
        {
            var baseRepo = _unitOfWork.Repository<Base>();
            var baseData = baseRepo.Read(p => p.Nobr == empInfo.EmployeeId);
            if (baseData != null)
            {
                baseData.Gsm = empInfo.Gsm;
                baseData.Tel1 = empInfo.CommunicationPhone;
                baseData.Tel2 = empInfo.ResidencePhone;
                baseData.Email = empInfo.Email;
                baseData.Addr1 = empInfo.CommunicationAddress;
                baseData.Addr2 = empInfo.ResidenceAddress;
                baseData.ContMan = empInfo.ContMan;
                baseData.ContRel1 = empInfo.ContRel;
                baseData.ContTel = empInfo.ContTel;
                baseData.ContGsm = empInfo.ContGsm;

                baseData.ContMan2 = empInfo.ContMan2;
                baseData.ContRel2 = empInfo.ContRel2;
                baseData.ContTel2 = empInfo.ContTel2;
                baseData.ContGsm2 = empInfo.ContGsm2;
                baseRepo.Update(baseData);
                baseRepo.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
