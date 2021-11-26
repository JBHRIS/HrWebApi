using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dto
{
    public class ApiRolesDto
    {
        public string Nobr { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public bool IsAdminRole { get; set; }
        public string PageCode { get; set; }
        public string PageName { get; set; }
        public string ApiVoidCode { get; set; }
        public string ApiVoidName { get; set; }
    }
}
