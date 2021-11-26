using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dal.Token;
using JBHRIS.Api.Dto.Token.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto._System.View;

namespace JBHRIS.Api.Dal.JBHR.Token
{
    public class ClientToken_View : IClientToken_View
    {
        private IUnitOfWork _unitOfWork;
        public ClientToken_View(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ApiClientRolesDto> GetClentRoleApi(string ClientID)
        {
                var data = from c in _unitOfWork.Repository<SysClients>().Reads()
                           join cm in _unitOfWork.Repository<SysClientByMoudle>().Reads() on c.ClientId equals cm.ClientId
                           into cgrp
                           from cg in cgrp.DefaultIfEmpty()
                           join ma in _unitOfWork.Repository<SysMoudleByApiVoid>().Reads() on cg.MoudleId equals ma.MoudleId
                           into cgmagrp
                           from cgmag in cgmagrp.DefaultIfEmpty()
                           join m in _unitOfWork.Repository<SysMoudles>().Reads() on cgmag.MoudleId equals m.Code
                           into mgrp
                           from mg in mgrp.DefaultIfEmpty()
                           join v in _unitOfWork.Repository<SysApiVoid>().Reads() on cgmag.ApiId equals v.Code
                           into vgrp
                           from vg in vgrp.DefaultIfEmpty()
                           where c.DueDate > DateTime.Now && c.ClientId == ClientID
                           select new ApiClientRolesDto
                           {
                               ClientId = c.ClientId,
                               ClientName = c.ClientName,
                               DueDate = c.DueDate,
                               IsAdminRole = mg.IsAdmin,
                               MoudleId = mg.Code,
                               MoudleName = mg.Name,
                               ApiVoidCode = vg.Code,
                               ApiVoidName = vg.Name
                           };
            return data.ToList();
        }
    }
}
