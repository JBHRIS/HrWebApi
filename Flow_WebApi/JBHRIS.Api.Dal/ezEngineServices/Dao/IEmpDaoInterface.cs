using JBHRIS.Api.Dto.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.ezEngineServices.Dao
{
    public interface IEmpDaoInterface
    {

        public List<EmpRow> GetData(string EmpId);

        public bool Save(EmpRow Row);

        public bool Save(List<EmpRow> Rows);


    }
}
