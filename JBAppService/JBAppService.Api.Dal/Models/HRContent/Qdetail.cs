﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Qdetail
    {
        public int Id { get; set; }
        public int QtplCategoryId { get; set; }
        public int QqitemId { get; set; }
        public int Sequence { get; set; }
        public bool IsRequired { get; set; }
    }
}
