using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ezEngineServices.core.Vdb;
using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;

namespace ezEngineServices.core.Dao
{
    public class EmpDao
    {
        private ezFlowContext dcFlow;

        public EmpDao()
        {
            dcFlow = new ezFlowContext();
        }

        public EmpDao(ezFlowContext dcFlow)
        {
            this.dcFlow = dcFlow;
        }

        public List<EmpRow> GetData(string EmpId = "")
        {
            var Vdb = (from c in dcFlow.Emps
                       where c.id == EmpId || EmpId.Length == 0
                       select new EmpRow
                       {
                           EmpId = c.id,
                           DisplayName = c.name + "," + c.id,
                           Email = c.email,
                           LoginId = c.login,
                           Name = c.name,
                           Password = c.pw,
                           Sex = (c.sex == "M" ? MultiEnum.SexEnum.Male : MultiEnum.SexEnum.Female),
                       }).ToList();

            return Vdb;
        }

        public bool Save(EmpRow Row)
        {
            List<EmpRow> rsEmp = new List<EmpRow>();
            rsEmp.Add(Row);
            return Save(rsEmp);
        }

        public bool Save(List<EmpRow> Rows)
        {
            var Keys = Rows.Select(p => p.EmpId).ToList();

            var rsEmp = (from c in dcFlow.Emps
                         where Keys.Contains(c.id)
                         select c).ToList();

            foreach (var Row in Rows)
            {
                var rEmp = rsEmp.Where(p => p.id == Row.EmpId).FirstOrDefault();

                if (rEmp == null)
                {
                    rEmp = new Emp();
                    rEmp.id = Row.EmpId;
                    rEmp.isNeedAgent = true;
                    rEmp.dateB = new DateTime(1900, 1, 1).Date;
                    rEmp.dateE = new DateTime(1900, 1, 1).Date;
                    dcFlow.Emps.Add(rEmp);
                }

                rEmp.pw = Row.Password;
                rEmp.name = Row.Name;
                rEmp.email = Row.Email;
                rEmp.login = Row.LoginId;
                rEmp.sex = (Row.Sex == MultiEnum.SexEnum.Male ? "M" : "F");
            }

            dcFlow.SaveChanges();

            return true;
        }
    }
}
