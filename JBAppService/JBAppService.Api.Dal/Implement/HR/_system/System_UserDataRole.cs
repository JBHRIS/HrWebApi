using JBAppService.Api.Dal.Interface._system;
using JBAppService.Api.Dal.Models.HRContent;
using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBAppService.Api.Dal.Implement.HR._system
{
    public class System_UserDataRole : ISystem_UserDataRole
    {
        private JBHRContext _context;
        public System_UserDataRole(JBHRContext context)
        {
            this._context = context;
        }

        public List<HrDataRoleDto> GetDataRolesById(string userId)
        {
            List<HrDataRoleDto> result = new List<HrDataRoleDto>();


            bool isAdmin = (from u in this._context.UUser
                            where u.UserId == userId
                            select u
                           ).Any();

            if (isAdmin)
            {
                result = (from r in this._context.Datagroup
                          select new HrDataRoleDto
                          {
                              DataGroup = r.Datagroup1,
                              ReadRule = true,
                              WriteRule = true
                          }
                          ).ToList();
            }
            else {

                result = (from r in this._context.UDatagroup
                          where r.UserId == userId
                          select new HrDataRoleDto
                          {
                              DataGroup = r.Datagroup,
                              ReadRule = r.Readrule,
                              WriteRule = r.Writerule
                          }).ToList();
            }

            return result;
        }
    }
}
