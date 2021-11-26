using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Mail;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Mail.View
{
    public interface IParameter_View_GetParameter
    {
        public List<ParameterDto> GetParameter();
    }
}
