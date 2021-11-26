using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Bll.Salary.Payroll
{
    public interface ISalaryEncrypt
    {
       decimal Encode(decimal DecodeAmt);
       decimal Decode(decimal DecodeAmt);
    }
}
