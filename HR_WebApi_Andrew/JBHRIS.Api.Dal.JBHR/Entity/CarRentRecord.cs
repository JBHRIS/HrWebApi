using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class CarRentRecord
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int UsedTimeHours { get; set; }
        public int UsedTimeMins { get; set; }
        public int UsedTotalMins { get; set; }
        public string Destination { get; set; }
        public string Contents { get; set; }
        public string WritedBy { get; set; }
        public DateTime? WritedDate { get; set; }
        public bool Cancel { get; set; }
        public string Canceler { get; set; }
        public int? MileageBeforeRent { get; set; }
        public int? MileageAfterRent { get; set; }
    }
}
