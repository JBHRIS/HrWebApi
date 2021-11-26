using JBHRIS.Api.Dal.JBHR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Api_Test
{
    public class TestConfig
    {
        static JBHRContext jBHRContext;
        public static string HrConntionString = "Data Source=192.168.1.12;Initial Catalog=TestDB;Persist Security Info=True;User ID=jb;Password=^Hsx9bu5t@;";
        public static JBHRContext GetJBHRContext()
        {
            if(jBHRContext==null)
            { 
                var builder = new DbContextOptionsBuilder<JBHRContext>();
                var contextOption = builder.UseSqlServer(TestConfig.HrConntionString).Options;
                jBHRContext = new JBHRContext(contextOption);
            }
            return jBHRContext;
    }
    }
}
