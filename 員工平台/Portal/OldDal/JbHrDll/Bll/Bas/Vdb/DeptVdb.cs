using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Bas.Vdb
{
    public class DeptVdb
    {
    }

    public class DeptRow
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ParentCode { get; set; }
        public string Tree { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public string Manage { get; set; }
        public string ManageMail { get; set; }
        public string Mail1 { get; set; }
        public string Mail2 { get; set; }
        public string Mail3 { get; set; }
        public string Path { get; set; }
        public string SubsidyNobr1 { get; set; }
        public string SubsidyNobr2 { get; set; }
        public string SubsidyNobr3 { get; set; }
        public bool Ovt { get; set; }
        public bool Ovt1 { get; set; }
        public bool PassM { get; set; }
        public string DisplayCode { get; set; }
    }

    public class DeptsRow
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int SetPeople { get; set; }
        public int NowPeople { get; set; }
    }

    public class DeptLevelRow
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
    }
}