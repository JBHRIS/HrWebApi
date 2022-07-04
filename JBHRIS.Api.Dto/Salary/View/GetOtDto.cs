using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Salary.View
{
    public class GetOtDto
    {
        public string Nobr { get; set; }
        public DateTime BDate { get; set; }
        public string BTime { get; set; }
        public string ETime { get; set; }
        public string YYMM { get; set; }
        public decimal Ot_HOURS { get; set; }
        public decimal Rest_HRS { get; set; }
        public decimal TOT_HOURS { get; set; }

        public decimal NOT_H_133 { get; set; }  //時數
        public decimal TOT_W_133 { get; set; }  //時數
        public decimal NOP_H_133 { get; set; }  //倍率

        public decimal NOT_H_167 { get; set; }  //時數
        public decimal TOT_W_167 { get; set; }  //時數
        public decimal NOP_H_167 { get; set; }  //倍率

        public decimal NOT_H_200 { get; set; }  //時數
        public decimal TOT_W_200 { get; set; }  //時數
        public decimal NOP_H_200 { get; set; }  //倍率

        public decimal NOT_W_133 { get; set; }  //時數
        public decimal NOP_W_133 { get; set; }  //倍率

        public decimal NOT_W_167 { get; set; }  //時數
        public decimal NOP_W_167 { get; set; }  //倍率

        public decimal NOT_W_200 { get; set; }  //時數
        public decimal NOP_W_200 { get; set; }  //倍率

    }
}
