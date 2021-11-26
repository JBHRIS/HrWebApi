using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Employee.Vdb
{
    public class UpdateEmployeeInfoVdb
    {
    }

    public class UpdateEmployeeInfoConditions : DataConditions
    {
        public string employeeId { get; set; }
        public string gsm { get; set; }
        public string residencePhone { get; set; }
        public string communicationPhone { get; set; }
        public string email { get; set; }
        public string residenceAddress { get; set; }
        public string communicationAddress { get; set; }
        public string contMan { get; set; }
        public string contTel { get; set; }
        public string contGsm { get; set; }
        public string contRel { get; set; }
        public string contMan2 { get; set; }
        public string contTel2 { get; set; }
        public string contGsm2 { get; set; }
        public string contRel2 { get; set; }
        public UpdateEmployeeInfoConditions()
        {
            employeeId = "";
            gsm = "";
            residenceAddress = "";
            residencePhone = "";
            communicationAddress = "";
            communicationPhone = "";
            email = "";
            contMan = "";
            contTel = "";
            contGsm = "";
            contRel = "";
            contMan2 = "";
            contTel2 = "";
            contGsm2 = "";
            contRel2 = "";
        }
    }


    public class UpdateEmployeeInfoApiRow : StandardDataBaseApiRow
    {
        public bool result { get; set; }
    }

    public class UpdateEmployeeInfoRow : StandardDataRow
    {
        public bool result { get; set; }
    }
    
}