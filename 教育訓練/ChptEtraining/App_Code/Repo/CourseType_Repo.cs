using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
namespace Repo
{    
    /// <summary>
    /// DEPT_Repo 的摘要描述
    /// </summary>
    /// 
    public class CourseType_Repo
    {
        private dcTrainingDataContext dc;        

        public CourseType_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public CourseType_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }


        public List<CourseType> GetAll()
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.CourseType                        
                        select c).ToList();
            }
        }
    }
}