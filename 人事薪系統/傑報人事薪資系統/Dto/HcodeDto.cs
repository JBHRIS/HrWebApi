using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Dto
{
    public class HcodeDto
    {
        public string Hcode { get; set; }
        public string HcodeDisp { get; set; }
        public string HcodeName { get; set; }
        public string HcodeGroup { get; set; }
        public string Unit { get; set; }
        public decimal Min { get; set; }
        public decimal Interval { get; set; }
        public decimal Calc(DateTime TimeBegin, DateTime TimeEnd, Dto.RoteDto Rote)
        {
            JBTools.Intersection its = new JBTools.Intersection();
            its.Inert(TimeBegin, TimeEnd);
            decimal rest_times = 0;
            if (Rote.RestTimes != null)
            {
                foreach (var it in Rote.RestTimes)
                {
                    JBTools.Intersection itsRest = new JBTools.Intersection();
                    itsRest.Inert(TimeBegin, TimeEnd);
                    itsRest.Inert(it.Key, it.Value);
                    rest_times += itsRest.GetHours();
                }
            }
            decimal taken = its.GetHours() - rest_times;
            taken = JBTools.NumbericConvert.RangeInterval(taken, Interval, JBTools.NumbericConvert.DigitalMode.Ceiling);
            if (taken > 0 && taken < Min) taken = Min;
            if (Unit == "天")
            {
                taken = JBTools.NumbericConvert.RangeInterval(taken / Rote.WorkHours, 0.5M, JBTools.NumbericConvert.DigitalMode.Ceiling);
                if (taken > 1) taken = 1;
            }
            return taken;
        }
    }
}
