using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
namespace JBHRIS.BLL.Att
{
    public class AbsenceEntitleController
    {
        public Repo.AbsEntitleRepo AbsEntitleRepo;
        public Repo.EntitleCodeRepo EntitleCodeRepo;
        public static string CreateMan = "JB";
        public AbsenceEntitleController()
        {
            AbsEntitleRepo = IOC.Container.Resolve<Repo.AbsEntitleRepo>();
            EntitleCodeRepo = IOC.Container.Resolve<Repo.EntitleCodeRepo>();
        }
        public bool InsertAbsenceEntitle(Dto.AbsEntitleDto instance, out string ErrorMsg)
        {
            instance.CreateMan = CreateMan;
            return AbsEntitleRepo.Insert(instance, out ErrorMsg);
        }
        public bool UpdateAbsenceEntitle(Dto.AbsEntitleDto instance, out string ErrorMsg)
        {
            instance.CreateMan = CreateMan;
            return AbsEntitleRepo.Update(instance, out ErrorMsg);
        }
        public bool DeleteAbsenceEntitle(Dto.AbsEntitleDto instance, out string ErrorMsg)
        {
            return AbsEntitleRepo.Delete(instance, out ErrorMsg);
        }
    }
}
