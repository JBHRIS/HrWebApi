using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto._System.View
{
    public class ApiClientRolesDto
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsAdminRole { get; set; }
        public string MoudleId { get; set; }
        public string MoudleName { get; set; }
        public string ApiVoidCode { get; set; }
        public string ApiVoidName { get; set; }
    }
}
