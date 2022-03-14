using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto
{

    public class ConfigurationDto
    {
        public Jwtsettings JwtSettings { get; set; }
        public Connectionstrings ConnectionStrings { get; set; }
        public string HostAPI { get; set; }
        public string ClientId { get; set; }
        public Fileupload FileUpload { get; set; }
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
    }

    public class Jwtsettings
    {
        public string NameClaim { get; set; }
        public string RoleClaim { get; set; }
        public string Issuer { get; set; }
        public string SignKey { get; set; }
        public string EmpID { get; set; }
    }

    public class Connectionstrings
    {
        public string HRConnectionStrings { get; set; }
        public string OLDHRConnectionStrings { get; set; }
        public string ezFlowConnectionStrings { get; set; }
        public string OldezFlowConnectionStrings { get; set; }
        public string ShareConnectionStrings { get; set; }
    }

    public class Fileupload
    {
        public string Path { get; set; }
        public string LimitFileSizeMB { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }
        public string MicrosoftHostingLifetime { get; set; }
    }

}
