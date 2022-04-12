using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Interface
{
   
    public interface ISystem_ShareCompany_View
    {

        List<ShareCompanyVdb> GetShareCompanyIdAndName();

    }
}
