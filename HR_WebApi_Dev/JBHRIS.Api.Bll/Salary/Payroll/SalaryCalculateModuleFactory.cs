using JBHRIS.Api.Dto;
using Microsoft.Extensions.Configuration;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JBHRIS.Api.Bll.Salary.Payroll
{
    public class SalaryCalculateModuleFactory : ISalaryCalculateModuleFactory
    {
        private ILogger _logger;
        private IConfiguration _configuration;

        public SalaryCalculateModuleFactory(ILogger logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public ISalaryCalculateModule Create(string moduleType)
        {
            _logger.Info("產生模組" + moduleType);
            var conf = _configuration.Get<ConfigurationDto>();
            var moduleList = conf.SalaryCalculateModules.SalaryModule.ToList(); ;
            var module = moduleList.SingleOrDefault(p => p.Name == moduleType);
            if (module != null)
            {
                var asmConcrete = Assembly.LoadFrom(conf.SourceDir + module.ConcreteClassAssembly);
                var typeClass = asmConcrete.GetType(module.ConcreteClass);
                var instance = asmConcrete.CreateInstance(module.ConcreteClass) as ISalaryCalculateModule;
                return instance;
            }
            else _logger.Warn("無法產生模組{moduleType}：", moduleType);
            return null;
        }
    }
}
