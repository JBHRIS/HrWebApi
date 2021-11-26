using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dto.ItemObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBAppService.Api.Dal.Models.HRContent;

namespace JBAppService.Api.Dal.Implement.HR
{
    public class DeptHandler : IDeptHandler
    {

        private JBHRContext _context;

        public DeptHandler(JBHRContext context)
        {
            this._context = context;
        }

        public List<ItemObject> GetDeptCodeList()
        {
            List<ItemObject> result = new List<ItemObject>();


            //result = (from dept in _context.Dept
                      
            //           ).ToList();


            return result;

        }


        
    }
}
