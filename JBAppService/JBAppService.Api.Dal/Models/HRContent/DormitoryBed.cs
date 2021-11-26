using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class DormitoryBed
    {
        public DormitoryBed()
        {
            DormitoryManagement = new HashSet<DormitoryManagement>();
        }

        public int AutoKey { get; set; }
        public int Room { get; set; }
        public string BedId { get; set; }
        public string BedName { get; set; }
        public decimal Cost { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }

        public virtual DormitoryRoom RoomNavigation { get; set; }
        public virtual ICollection<DormitoryManagement> DormitoryManagement { get; set; }
    }
}
