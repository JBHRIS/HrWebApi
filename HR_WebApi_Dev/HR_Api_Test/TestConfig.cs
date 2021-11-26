using JBHRIS.Api.Dal.JBHR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Test
{
    public class TestConfig
    {
        static JBHRContext jBHRContext;
        //public static string HrConntionString = "Data Source=192.168.1.12;Initial Catalog=TestDB;Persist Security Info=True;User ID=jb;Password=^Hsx9bu5t@;";
        public static JBHRContext GetJBHRContext()
        {
            DbContextOptions<JBHRContext> options = new DbContextOptionsBuilder<JBHRContext>()
                    .UseInMemoryDatabase("HR")
                    .Options;
            JBHRContext context = new JBHRContext(options);
            return context;
        }
    }
}
