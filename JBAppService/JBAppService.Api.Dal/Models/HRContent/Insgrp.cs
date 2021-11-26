using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Insgrp
    {
        public string Nobr { get; set; }
        public string FaIdno { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public string Code { get; set; }
        public decimal Amt1 { get; set; }
        public decimal Exp1 { get; set; }
        public decimal Cop1 { get; set; }
        public decimal Amt2 { get; set; }
        public decimal Exp2 { get; set; }
        public decimal Cop2 { get; set; }
        public decimal Amt3 { get; set; }
        public decimal Exp3 { get; set; }
        public decimal Cop3 { get; set; }
        public decimal Amt4 { get; set; }
        public decimal Exp4 { get; set; }
        public decimal Cop4 { get; set; }
        public decimal Amt5 { get; set; }
        public decimal Exp5 { get; set; }
        public decimal Cop5 { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public decimal Amt6 { get; set; }
        public decimal Totexp { get; set; }
        public decimal Copexp { get; set; }
        public string Seq { get; set; }
        public bool Exp3cal { get; set; }
        public bool Exp1cal { get; set; }
        public bool Exp2cal { get; set; }
        public string GrpType { get; set; }
        public string Pan { get; set; }
    }
}
