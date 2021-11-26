using JBAppService.Api.Dal.Interface._system;
using JBAppService.Api.Dal.Models.HRContent;
using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBAppService.Api.Dal.Implement.HR._system
{
    public class System_UserDal : ISystem_UserDal
    {

        private JBHRContext _context;
        public System_UserDal(JBHRContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public HrUserDto GetUserByBindingID(string userId)
        {
            HrUserDto dto = new HrUserDto();

            dto = (from u in this._context.UUser
                   where u.UserId == userId
                   select new HrUserDto
                   {
                       UserId = u.UserId,
                       Admin = u.Admin
                   }).FirstOrDefault();

            return dto;
        }
    }
}
