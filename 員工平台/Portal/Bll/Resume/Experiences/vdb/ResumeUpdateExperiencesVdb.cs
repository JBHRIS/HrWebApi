using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Resume.Experiences.Vdb
{
    class ResumeUpdateExperiencesVdb
    {

    }
    public class ResumeUpdateExperiencesConditions : DataConditions
    {
        public string Code { get; set; }

        public string ResumeCode { get; set; }
        public string ExperiencesCode { get; set; }
        public string School { get; set; }
        public string Major { get; set; }
        public string MajorDetail { get; set; }
        public DateTime? AdmissionTime { get; set; }
        public DateTime? GeraduationTime { get; set; }
        public bool DaySchool { get; set; }
        public bool Graduation { get; set; }
        public string Note { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
    public class ResumeUpdateExperiencesApiRow : StandardDataBaseApiRow
    {

    }
    public class ResumeUpdateExperiencesRow
    {
     

    }
}