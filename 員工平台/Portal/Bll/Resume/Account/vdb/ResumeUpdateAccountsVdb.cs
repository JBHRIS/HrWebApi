using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Resume.Vdb
{
    public class ResumeupdateAccountVdb
    {

    }

    public class ResumeupdateAccountConditions : DataConditions
    {

    }
    public class ResumeupdateAccountApiRow : StandardDataBaseApiRow
    {

    }
    public class ResumeupdateAccountRow
    {
        public string Code { get; set; }
        public string SystemGroup { get; set; }

        public string CompanyId { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int RoleKey { get; set; }
        public string Email { get; set; }
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Key3 { get; set; }

        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public string Note { get; set; }
        public string InsertMan { get; set; }
        public DateTime? updateDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
