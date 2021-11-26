using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto
{
    public class ConfigurationDto
    {
        public Logging Logging { get; set; }
        public string SourceDir { get; set; }
        public Moduleregister ModuleRegister { get; set; }
        public Salarycalculatemodules SalaryCalculateModules { get; set; }
        public Workschedulecheck WorkScheduleCheck { get; set; }
        public string AllowedHosts { get; set; }
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
