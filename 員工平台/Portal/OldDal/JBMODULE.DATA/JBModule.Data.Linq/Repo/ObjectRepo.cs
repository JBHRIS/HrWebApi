using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace JBModule.Data.Repo
{
    public class ObjectRepo
    {
        internal JBModule.Data.Linq.HrDBDataContext db = null;
        string _username = "";
        string _userid = "";
        public  ObjectRepo()
        {
            db = JBModule.Data.Linq.DcHelper.GetHrDBDataContext();
            var principal = Thread.CurrentPrincipal;
            var identity = principal.Identity;
            UserID = identity.Name;
            UserName = identity.Name;
        }
        public ObjectRepo(System.Data.IDbConnection connection)
        {
            db = new JBModule.Data.Linq.HrDBDataContext(connection);
        }
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        public string UserID
        {
            get;
            set;
        }

    }
}
