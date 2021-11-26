using JBAppService.Api.Dto.ItemObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dal.Interface
{
    public interface IDeptHandler
    {


        List<ItemObject> GetDeptCodeList();
    }
}
