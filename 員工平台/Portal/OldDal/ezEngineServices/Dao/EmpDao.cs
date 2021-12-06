using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ezEngineServices.Vdb;

namespace ezEngineServices.Dao
{
    public class EmpDao
    {
        private dcFlowDataContext dcFlow;
        private string _ConnectionString;

        public EmpDao()
        {
            dcFlow = new dcFlowDataContext();
            _ConnectionString = dcFlow.Connection.ConnectionString;
        }

        /// <summary>
        /// EmpDao
        /// </summary>
        /// <param name="conn"></param>
        public EmpDao(IDbConnection conn)
        {
            _ConnectionString = conn.ConnectionString;
            dcFlow = new dcFlowDataContext(conn);
        }

        /// <summary>
        /// EmpDao
        /// </summary>
        /// <param name="ConnectionString"></param>
        public EmpDao(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            dcFlow = new dcFlowDataContext(ConnectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public EmpDao(dcFlowDataContext dcFlow)
        {
            _ConnectionString = dcFlow.Connection.ConnectionString;
            this.dcFlow = dcFlow;
        }

        public List<EmpRow> GetData(string EmpId = "")
        {
            var Vdb = (from c in dcFlow.Emp
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
           var Keys = Rows.Select(p=>p.EmpId).ToList();

            var rsEmp = (from c in dcFlow.Emp
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
                    dcFlow.Emp.InsertOnSubmit(rEmp);
                }

                rEmp.pw = Row.Password;
                rEmp.name = Row.Name;
                rEmp.email = Row.Email;
                rEmp.login = Row.LoginId;
                rEmp.sex = (Row.Sex == MultiEnum.SexEnum.Male ? "M" : "F");
            }

            dcFlow.SubmitChanges();

            return true;
        }
    }
}