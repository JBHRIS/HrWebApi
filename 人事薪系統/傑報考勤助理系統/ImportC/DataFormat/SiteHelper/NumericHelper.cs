using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.ImportC.DataFormat.SiteHelper
{
    class NumericHelper
    {
        public bool CheckNum(string strNum) {
            bool flag = true;
            try
            {
                Convert.ToDecimal(strNum);
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }





    }
}
