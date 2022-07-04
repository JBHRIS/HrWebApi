using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dal.Mail.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Dal.JBHR.Mail.View
{
    public class Parameter_View_GetParameter : IParameter_View_GetParameter
    {
        private IUnitOfWork _unitOfWork;
        public Parameter_View_GetParameter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ParameterDto> GetParameter()
        {
            var Repo = _unitOfWork.Repository<Parameter>();
            var Data = Repo.Reads().Select(r => new ParameterDto
            {
                Auto  = r.Auto,
                ParmgroupAuto =r.ParmgroupAuto,
                Code =r.Code,
                Type =r.Type,
                Value =r.Value,
                KeyDate =r.KeyDate,
                KeyMan =r.KeyMan,
                Note =r.Note,
                Note1 =r.Note1,
                Note2 =r.Note2,
                Note3 =r.Note3,
                Note4 =r.Note4,
                Note5 =r.Note5,
                Display =r.Display,
            }).ToList();
            return Data;
        }
    }
}
