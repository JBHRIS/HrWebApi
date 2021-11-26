using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dto.Attendance.Action
{
    public class TmtableDto
    {
        public string Yymm { get; set; }
        public string Nobr { get; set; }
        public string D1 { get; set; }
        public string D2 { get; set; }
        public string D3 { get; set; }
        public string D4 { get; set; }
        public string D5 { get; set; }
        public string D6 { get; set; }
        public string D7 { get; set; }
        public string D8 { get; set; }
        public string D9 { get; set; }
        public string D10 { get; set; }
        public string D11 { get; set; }
        public string D12 { get; set; }
        public string D13 { get; set; }
        public string D14 { get; set; }
        public string D15 { get; set; }
        public string D16 { get; set; }
        public string D17 { get; set; }
        public string D18 { get; set; }
        public string D19 { get; set; }
        public string D20 { get; set; }
        public string D21 { get; set; }
        public string D22 { get; set; }
        public string D23 { get; set; }
        public string D24 { get; set; }
        public string D25 { get; set; }
        public string D26 { get; set; }
        public string D27 { get; set; }
        public string D28 { get; set; }
        public string D29 { get; set; }
        public string D30 { get; set; }
        public string D31 { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public decimal No { get; set; }
        public decimal Holis { get; set; }
        public decimal FreqNo { get; set; }
        public Dictionary<int, string> GetRoteList()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            for (int i = 1; i < 31; i++)
            {
                var value = this.GetType().GetProperty("D" + i.ToString()).GetValue(this).ToString();
                if (value.Trim().Length > 0)
                    result.Add(i, value);
            }
            return result;
        }
    }
}