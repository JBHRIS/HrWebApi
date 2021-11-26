using JBHRIS.Api.Bll.Salary.Payroll;
using JBHRIS.Api.Dto.Salary.Payroll;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;


namespace JBHRIS.Api.Service.Salary.Payroll
{
    public class SalaryCalculationService : ISalaryCalculationService
    {
        private ISalaryCalculateModuleFactory _salaryCalculateModuleFactory;
        private ILogger _logger;
        public SalaryCalculationService(ILogger logger)
        {
            _logger = logger;
        }
        public SalaryCalculationService(ISalaryCalculateModuleFactory salaryCalculateModuleFactory, ILogger logger)
        {
            _salaryCalculateModuleFactory = salaryCalculateModuleFactory;
            _logger = logger;
        }
        public SalaryCalculationResult Calculate(SalaryCalculationEntry salaryCalculationEntry)
        {
            _logger.Info("叫用薪資計算服務");
            _logger.Debug("傳入值：{@salaryCalculationEntry}", salaryCalculationEntry);

            SalaryCalculationResult result = new SalaryCalculationResult();
            foreach (string moduleType in salaryCalculationEntry.ModuleTypes)
            {
                _logger.Info("準備取得模組" + moduleType);
                var module = _salaryCalculateModuleFactory.Create(moduleType);
                if (module != null)
                {
                    var moduleResult = module.Calculate(salaryCalculationEntry);
                    result = moduleResult;//todo:未處理細節
                }
                else
                {
                    _logger.Warn("無法取得模組" + moduleType);
                }
            }
            _logger.Info("計算完成");
            _logger.Debug("回傳值", result);
            return result;
        }
    }

}
