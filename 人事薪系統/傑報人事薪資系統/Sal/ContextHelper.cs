using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Att
{
    public class ContextHelper
    {
        private static ContextHelper helper = null;
        private static JBModule.Data.Linq.HrDBDataContext entity = null;
        public static JBModule.Data.Linq.HrDBDataContext GetContext()
        {
            if (helper == null)
                helper = new ContextHelper();
            //String connectionPath = helper.GetType().Assembly.CodeBase.Substring(8).Replace("/", "\\");
            if (entity == null)
                //    entity = new WebHREntities(System.Configuration.ConfigurationManager.OpenExeConfiguration("").ConnectionStrings.ConnectionStrings["WebHREntities"].ConnectionString);
                entity = new JBModule.Data.Linq.HrDBDataContext();
            return entity;
        }

        public static void CloseEntity()
        {
            if (entity != null)
                entity.Dispose();
            entity = null;
        }
    }
}
