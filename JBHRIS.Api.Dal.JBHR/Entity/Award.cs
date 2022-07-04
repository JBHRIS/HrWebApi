using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Award
    {
        public string Nobr { get; set; }
        public DateTime Adate { get; set; }
        public string AwardCode { get; set; }
        public decimal Award1 { get; set; }
        public decimal Award2 { get; set; }
        public decimal Award3 { get; set; }
        public decimal Award4 { get; set; }
        public bool Award5 { get; set; }
        public decimal Award6 { get; set; }
        public decimal Fault1 { get; set; }
        public decimal Fault2 { get; set; }
        public decimal Fault3 { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Note { get; set; }
        public decimal Fault5 { get; set; }
        public decimal Fault4 { get; set; }
        public string Yymm { get; set; }
        public string Up1Name { get; set; }
        public byte[] Up1File { get; set; }
        public string Up2Name { get; set; }
        public byte[] Up2File { get; set; }
        public string Up3Name { get; set; }
        public byte[] Up3File { get; set; }
        public string Up4Name { get; set; }
        public byte[] Up4File { get; set; }
        public string Up5Name { get; set; }
        public byte[] Up5File { get; set; }
        public bool? AwChk { get; set; }
        public bool? AwChk1 { get; set; }
        public bool? AwChk2 { get; set; }
        public bool? AwChk3 { get; set; }
    }
}
