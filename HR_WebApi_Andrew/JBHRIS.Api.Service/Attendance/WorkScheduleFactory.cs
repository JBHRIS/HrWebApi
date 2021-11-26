using JBHRIS.Api.Bll.Attendance;
using JBHRIS.Api.Dto;
using Microsoft.Extensions.Configuration;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JBHRIS.Api.Service.Attendance
{
    public class WorkScheduleFactory : IWorkScheduleFactory
    {
        private ILogger _logger;
        private IConfiguration _configuration;

        public WorkScheduleFactory(ILogger logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public IWorkScheduleCheck Create(string CheckType)
        {
            _logger.Info("產生模組" + CheckType);
            var conf = _configuration.Get<ConfigurationDto>();
            var moduleList = conf.WorkScheduleCheck.WorkScheduleCheckModule.ToList(); ;
            var module = moduleList.SingleOrDefault(p => p.Name == CheckType);
            if (module != null)
            {
                var asmConcrete = Assembly.LoadFrom(conf.SourceDir + module.ConcreteClassAssembly);
                var typeClass = asmConcrete.GetType(module.ConcreteClass);
                var instance = asmConcrete.CreateInstance(module.ConcreteClass) as IWorkScheduleCheck;
                return instance;
            }
            else _logger.Warn("無法產生模組{moduleType}：", CheckType);
            return null;
        }
    }
}
