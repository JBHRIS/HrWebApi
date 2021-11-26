using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Vdb
{
    public class CApParmDto
    {
        public int ProcessFlow_id;
        public int ProcessNode_auto;
        public int ProcessCheck_auto;
        public string Role_id;
        public string Emp_id;

        public CApParmDto()
        {
            ProcessFlow_id = 0;
            ProcessNode_auto = 0;
            ProcessCheck_auto = 0;
            Role_id = "";
            Emp_id = "";
        }
    }
}
