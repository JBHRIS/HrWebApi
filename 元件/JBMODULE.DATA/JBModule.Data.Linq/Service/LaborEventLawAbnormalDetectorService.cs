using JBHRIS.BLL.Att.LaborEventLaw;
using JBHRIS.BLL.Att.LaborEventLaw.Dto;
using JBModule.Data.Repo;
using JBModule.Message;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace JBModule.Data.Service
{
    public class LaborEventLawAbnormalDetectorService
    {
        private IAttendRepository _attendRepository;
        private IOvertimeRepository _overtimeRepository;
        private IAttCardRepository _attCardRepository;
        private ILaborEventLawAbnormalDetectorModel _laborEventLawAbnormalDetectorModel;
        private ILaborEventLawAbnormalRepository _laborEventLawAbnormalRepository;
        public string UserName = "JB";
        public LaborEventLawAbnormalDetectorService(JBModule.Data.Linq.HrDBDataContext db)
        {
            _attendRepository = new AttendRepository(db);
            _overtimeRepository = new OvertimeRepository(db);
            _attCardRepository =new AttCardRepository(db);
            _laborEventLawAbnormalDetectorModel = new LaborEventLawAbnormalDetectorModel();
            _laborEventLawAbnormalRepository =new LaborEventLawAbnormalRepository(db);
        }
        public LaborEventLawAbnormalDetectorService(IAttendRepository attendRepository, IOvertimeRepository overtimeRepository, IAttCardRepository attCardRepository, ILaborEventLawAbnormalDetectorModel laborEventLawAbnormalDetectorModel, ILaborEventLawAbnormalRepository laborEventLawAbnormalRepository)
        {
            _attendRepository = attendRepository;
            _overtimeRepository = overtimeRepository;
            _attCardRepository = attCardRepository;
            _laborEventLawAbnormalDetectorModel = laborEventLawAbnormalDetectorModel;
            _laborEventLawAbnormalRepository = laborEventLawAbnormalRepository;
        }
        public bool Run(List<string> employeeList, DateTime DateBegin, DateTime DateEnd)
        {
            LaborEventLawAbnormalDetector Caculator = new LaborEventLawAbnormalDetector(_attendRepository, _overtimeRepository, _attCardRepository, _laborEventLawAbnormalDetectorModel, _laborEventLawAbnormalRepository);
            JBModule.Data.Linq.HrDBDataContext db = new Linq.HrDBDataContext();
            var configs = db.AppConfig.Where(p => p.Category == "ZZ2S" && p.Comp == string.Empty);
            int OnTimeBufferMins = -1;
            int OffTimeBufferMins = -1;
            try
            {
                string str = string.Empty;
                if (configs.Where(p => p.Code == "OnTimeBufferMins").Any())
                    str = configs.Where(p => p.Code == "OnTimeBufferMins").FirstOrDefault().Value;
                else
                    str = ConfigurationManager.AppSettings["OnTimeBufferMins"];

                if (str != null)
                {
                    OnTimeBufferMins = Int32.Parse(str);
                }
            }
            catch { OnTimeBufferMins = 15; }

            try
            {
                string str = string.Empty;
                if (configs.Where(p => p.Code == "OffTimeBufferMins").Any())
                    str = configs.Where(p => p.Code == "OffTimeBufferMins").FirstOrDefault().Value;
                else
                    str = ConfigurationManager.AppSettings["OffTimeBufferMins"];

                if (str != null)
                {
                    OffTimeBufferMins = Int32.Parse(str);
                }
            }
            catch { OffTimeBufferMins = 15; }

            List<LaborEventLawAbnormalDto> Result = Caculator.Excute(employeeList, DateBegin, DateEnd, OnTimeBufferMins, OffTimeBufferMins);
            try
            {
                TextLog.WriteLog("抓取舊資料...");
                var OldData = Caculator.GetData(employeeList, DateBegin, DateEnd);
                TextLog.WriteLog("刪除舊資料，Count = " + OldData.Count());
                Caculator.Delete(OldData);
                TextLog.WriteLog("寫入新資料，Count = " + Result.Count());
                foreach (var rr in Result)
                    rr.CreateMan = UserName;
                Caculator.Save(Result);


                //scope.Complete();
            }
            catch (Exception ex)
            {
                TextLog.WriteLog(ex);
            }
            return true;
        }
    }
}
