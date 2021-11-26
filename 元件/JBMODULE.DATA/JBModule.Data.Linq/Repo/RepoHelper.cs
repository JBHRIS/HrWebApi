using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class RepoHelper : JBHRIS.BLL.Repo.IRepoHelper
    {
        public JBModule.Data.Repo.AbsenceRepo GetAbsenceRepo()
        {
            JBModule.Data.Repo.AbsenceRepo absRepo = new JBModule.Data.Repo.AbsenceRepo();
            return absRepo;
        }



        #region IRepoHelper 成員

        public JBHRIS.BLL.Repo.IAbsRepo GetAbsRepo()
        {
            JBHRIS.BLL.Repo.IAbsRepo absRepo = new Repo.AbsRepo();
            return absRepo;
        }

        public JBHRIS.BLL.Repo.IScheduleRepo GetScheduleRepo()
        {
            JBHRIS.BLL.Repo.IScheduleRepo repo = new ScheduleRepo();
            return repo;
        }

        public JBHRIS.BLL.Repo.ScheduleManager GetScheduleManager()
        {
            JBHRIS.BLL.Repo.ScheduleManager mng = new JBHRIS.BLL.Repo.ScheduleManager(this);
            return mng;
        }

        public JBHRIS.BLL.Repo.ILogger GetLogger()
        {
            return new JBModule.Data.Repo.NLogger();
        }

        #endregion
    }
}
