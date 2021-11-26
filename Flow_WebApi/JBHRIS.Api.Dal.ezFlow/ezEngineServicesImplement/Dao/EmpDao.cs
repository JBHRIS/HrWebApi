using JBHRIS.Api.Dal.ezEngineServices.Dao;
using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dto.Vdb;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.ezFlow.ezEngineServicesImplement.Dao
{
    public class EmpDao : IEmpDaoInterface
    {
        private ezFlowContext _context;

        public EmpDao(ezFlowContext context)
        {
            this._context = context;
        }
        public List<EmpRow> GetData(string EmpId)
        {
            var Vdb = (from c in _context.Emps
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

            var rsEmp = (from c in _context.Emps
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
                    _context.Emps.Add(rEmp);
                }

                rEmp.pw = Row.Password;
                rEmp.name = Row.Name;
                rEmp.email = Row.Email;
                rEmp.login = Row.LoginId;
                rEmp.sex = (Row.Sex == MultiEnum.SexEnum.Male ? "M" : "F");
            }

            _context.SaveChanges();

            return true;
        }
    }
}
