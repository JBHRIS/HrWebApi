using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Resume.Base.Vdb
{
    public class ResumeInsertBaseVdb
    {

    }

    public class ResumeDeleteBaseConditions : DataConditions
    {
        public string Code { get; set; }
        public string ResumeCode { get; set; }
        public string NameC { get; set; }
        public string NameE { get; set; }
        public string AdmitChannel { get; set; }
        public string IdNo { get; set; }
        public DateTime? BirthDate { get; set; }
        public string FillupNo { get; set; }
        public string Sex { get; set; }
        public string Blood { get; set; }
        public string Marriage { get; set; }
        public string Introducer { get; set; }
        public string BirthPlace { get; set; }
        public bool Army { get; set; }
        public string PassportName { get; set; }
        public string PassPortNo { get; set; }
        public string ArcNo { get; set; }
        public string DisabledType { get; set; }
        public string Country { get; set; }
        public string ExtenstionNumber { get; set; }
        public string PersonalStatus { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Account_AD { get; set; }
        public string Photo { get; set; }
        public string Hobby { get; set; }
        public string CurrentTel { get; set; }
        public string CurrentAdd { get; set; }
        public string PermanentTel { get; set; }
        public string PemanentAdd { get; set; }
        public string DependantIdno { get; set; }
        public string DependantName { get; set; }
        public string DependantType { get; set; }
        public string DependantBirthDate { get; set; }
        public string DependantAddress { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
    public class ResumeDeleteBaseApiRow : StandardDataBaseApiRow
    {

    }
    public class ResumeDeleteBaseRow
    {
       

    }
}
