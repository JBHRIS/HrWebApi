﻿using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Interface.System
{
    public interface IGetEmpInterface
    {
        List<EmpDto> GetEmpList();
        List<EmpDto> GetEmpListByEmpId(List<string> EmpIdList);

    }
}
