using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.EEPContent;
using JBAppService.Api.Dto.ItemObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dal.Implement.EEP
{
    public class DeptHandler : IDeptHandler
    {

        private JBEEPContext _context;

        public DeptHandler(JBEEPContext context)
        {
            this._context = context;
        }



        public List<ItemObject> GetDeptCodeList()
        {
            throw new NotImplementedException();
        }
    }
}
