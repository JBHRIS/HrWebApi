using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal.Entity.edmx;

namespace Dal.Dao
{
    internal class ContextHelper
    {
        private static ContextHelper helper = null;
        private static Entities entity = null;
        internal static Entities GetContext()
        {
            if (helper == null)
                helper = new ContextHelper();
            String connectionPath = helper.GetType().Assembly.CodeBase.Substring(8).Replace("/", "\\");
            if (entity == null)
                entity = new Entities(System.Configuration.ConfigurationManager.OpenExeConfiguration(connectionPath).ConnectionStrings.ConnectionStrings["WebHREntities"].ConnectionString);

            return entity;
        }

        internal static void CloseEntity()
        {
            if (entity != null)
                entity.Dispose();
            entity = null;
        }
    }
}
