﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CarId { get; set; }
        public string LicensePlate { get; set; }
        public bool EnableSchedueRent { get; set; }
        public bool? CanRent { get; set; }
        public int? DispBackColor { get; set; }
    }
}
