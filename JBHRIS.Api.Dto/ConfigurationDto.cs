using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBHRIS.Api.Dto
{
    public partial class ConfigurationDto
    {
        public JWT JWT { get; set; }
        public Logging Logging { get; set; }
        public Connectionstrings ConnectionStrings { get; set; }
        public Fileupload FileUpload { get; set; }
        public Hcodeunitstring HcodeUnitString { get; set; }
        public string SourceDir { get; set; }
        public Moduleregister ModuleRegister { get; set; }
        public Salarycalculatemodules SalaryCalculateModules { get; set; }
        public Modulesettings ModuleSettings { get; set; }
        public Workschedulecheck WorkScheduleCheck { get; set; }
        public string AllowedHosts { get; set; }
    }

    public class JWT
    {
        public string issuer { get; set; }
        public string signKey { get; set; }
        public string expires { get; set; }
        public string NameClaim { get; set; }
        public string RoleClaim { get; set; }
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

    public class Connectionstrings
    {
        public string DefaultConnection { get; set; }
        public Subscriptionconnection[] SubscriptionConnection { get; set; }
        public string HangfireConnection { get; set; }
    }

    public class Subscriptionconnection
    {
        public string Name { get; set; }
        public string ConnectionStrings { get; set; }
    }

    public class Fileupload
    {
        public string Path { get; set; }
        public string LimitFileSizeMB { get; set; }
    }

    public class Hcodeunitstring
    {
        public string[] Day { get; set; }
        public string[] Hour { get; set; }
        public string[] Minute { get; set; }
    }

    public class Moduleregister
    {
        public Module[] Module { get; set; }
    }

    public class Module
    {
        public string InterfaceAssembly { get; set; }
        public string Interface { get; set; }
        public string ConcreteClassAssembly { get; set; }
        public string ConcreteClass { get; set; }
        public string Description { get; set; }
    }

    public class Salarycalculatemodules
    {
        public Salarymodule[] SalaryModule { get; set; }
    }

    public class Salarymodule
    {
        public string Name { get; set; }
        public string ConcreteClassAssembly { get; set; }
        public string ConcreteClass { get; set; }
        public string Description { get; set; }
    }

    public class Modulesettings
    {
        public Module1[] Modules { get; set; }
    }

    public class Module1
    {
        public string ModuleType { get; set; }
        public Assemblyinfo[] AssemblyInfos { get; set; }
    }

    public class Assemblyinfo
    {
        public string Name { get; set; }
        public string ConcreteClassAssembly { get; set; }
        public string ConcreteClass { get; set; }
        public string Description { get; set; }
    }

    public class Workschedulecheck
    {
        public Workschedulecheckmodule[] WorkScheduleCheckModule { get; set; }
    }

    public class Workschedulecheckmodule
    {
        public string Name { get; set; }
        public string ConcreteClassAssembly { get; set; }
        public string ConcreteClass { get; set; }
        public string Description { get; set; }
    }


}
