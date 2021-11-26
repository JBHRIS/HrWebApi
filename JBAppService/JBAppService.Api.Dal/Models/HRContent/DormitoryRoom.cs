using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class DormitoryRoom
    {
        public DormitoryRoom()
        {
            DormitoryBed = new HashSet<DormitoryBed>();
        }

        public int AutoKey { get; set; }
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }

        public virtual ICollection<DormitoryBed> DormitoryBed { get; set; }
    }
}
