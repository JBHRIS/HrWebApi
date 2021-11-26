using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Mail
{
    public class ParameterDto
    {
        public int Auto { get; set; }
        public int ParmgroupAuto { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Note { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Note3 { get; set; }
        public string Note4 { get; set; }
        public string Note5 { get; set; }
        public bool Display { get; set; }
    }
}
