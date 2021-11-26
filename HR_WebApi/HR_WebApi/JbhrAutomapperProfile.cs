using AutoMapper;
using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_WebApi
{
    public class JbhrAutomapperProfile : Profile
    {
        public JbhrAutomapperProfile()
        {
            CreateMap<Tmtable, TmtableDto>();
            CreateMap<TmtableDto, Tmtable>();
            CreateMap<Rotet, RotetDto>();
            CreateMap<Holi, HoliDto>();
            CreateMap<TmtableImport, TmtableImportDto>();
            CreateMap<TmtableImportDto, TmtableDto>();
            CreateMap<Attend, AttendDto>();
            CreateMap<AttendDto, Attend>();
            CreateMap<RotechgDto, Rotechg>();
            CreateMap<Rotechg, RotechgDto>();
        }
    }
}
