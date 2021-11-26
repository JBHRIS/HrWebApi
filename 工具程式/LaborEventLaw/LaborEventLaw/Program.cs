using System;
using System.Collections.Generic;
using System.Linq;
using LaborEventLaw.Normal;
using JBHRIS.BLL.Att.LaborEventLaw;
using LaborEventLaw.LaborEventLaw;
using JBHRIS.BLL.Att.LaborEventLaw.Dto;
using System.Configuration;
using JBModule.Message;

namespace LaborEventLaw
{
    class Program
    {
        public static IEnumerable<string> TTSCODE = new List<string>() { "1", "4", "6" };
        static void Main(string[] args)
        {
            JBHRModelDataContext dcHr = new JBHRModelDataContext();
            
            TextLog.WriteLog("======================程式版本：20200117======================");
            var ts1 = DateTime.Now;
            try
            {
                TextLog.WriteLog("伺服器：" + dcHr.Connection.DataSource + "，資料庫：" + dcHr.Connection.Database);

                IAttCardRepository oAttCardRepository = new AttCardRepository(dcHr);
                IAttendRepository oAttendRepository = new AttendRepository(dcHr);
                IOvertimeRepository oOvertimeRepository = new OvertimeRepository(dcHr);
                ILaborEventLawAbnormalDetectorModel oDetectorModel = new LaborEventLawAbnormalDetectorModel();
                ILaborEventLawAbnormalRepository oRepository = new LaborEventLawAbnormalRepository(dcHr);

                var configs = dcHr.AppConfig.Where(p => p.Category == "ZZ2S" && p.Comp == string.Empty);
                
                DateTime RunDate = DateTime.Today;
                DateTime beginDate = DateTime.Today;
                DateTime endDate = DateTime.Today;
                int beginDayShift = 0;
                int endDayShift = 0;

                bool bSimDateRange = true;

                List<string> compList = new List<string>();
                List<string> empList = new List<string>();

                try
                {
                    string str = string.Empty; 
                    if (configs.Where(p =>p.Code == "beginDate").Any())
                        str = configs.Where(p => p.Code == "beginDate").FirstOrDefault().Value;
                    else
                        str = ConfigurationManager.AppSettings["beginDate"];

                    if (str != null)
                        beginDate = DateTime.Parse(str);
                }
                catch { bSimDateRange = false; }

                try
                {
                    string str = string.Empty;
                    if (configs.Where(p => p.Code == "endDate").Any())
                        str = configs.Where(p => p.Code == "endDate").FirstOrDefault().Value;
                    else
                        str = ConfigurationManager.AppSettings["endDate"];

                    if (str != null)
                        endDate = DateTime.Parse(str);
                }
                catch { bSimDateRange = false; }

                try
                {
                    string str = string.Empty;
                    if (configs.Where(p => p.Code == "comp").Any())
                        str = configs.Where(p => p.Code == "comp").FirstOrDefault().Value;
                    else
                        str = ConfigurationManager.AppSettings["comp"];

                    if (str != null)
                    {
                        compList = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        if (compList.Count > 0)
                            TextLog.WriteLog("篩選公司別：" + str);
                    }
                }
                catch { }

                try
                {
                    string str = string.Empty;
                    if (configs.Where(p => p.Code == "emp").Any())
                        str = configs.Where(p => p.Code == "emp").FirstOrDefault().Value;
                    else
                        str = ConfigurationManager.AppSettings["emp"];

                    if (str != null)
                    {
                        empList = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        if (empList.Count > 0)
                            TextLog.WriteLog("篩選工號：" + str);
                    }
                }
                catch { }

                if (bSimDateRange == false)
                {
                    try
                    {
                        string str = string.Empty;
                        if (configs.Where(p => p.Code == "beginDayShift").Any())
                            str = configs.Where(p => p.Code == "beginDayShift").FirstOrDefault().Value;
                        else
                            str = ConfigurationManager.AppSettings["beginDayShift"];

                        if (str != null)
                        {
                            beginDayShift = Int32.Parse(str);
                        }
                    }
                    catch { }

                    try
                    {
                        string str = string.Empty;
                        if (configs.Where(p => p.Code == "endDayShift").Any())
                            str = configs.Where(p => p.Code == "endDayShift").FirstOrDefault().Value;
                        else
                            str = ConfigurationManager.AppSettings["endDayShift"];

                        if (str != null)
                        {
                            endDayShift = Int32.Parse(str);
                        }
                    }
                    catch { }

                    beginDate = RunDate.AddDays(beginDayShift);
                    endDate = RunDate.AddDays(endDayShift);

                    if (beginDate > endDate)
                    {
                        beginDate = DateTime.Today;
                        endDate = DateTime.Today;
                    }
                }
                TextLog.WriteLog("開始日期：" + beginDate.ToShortDateString());
                TextLog.WriteLog("結束日期：" + endDate.ToShortDateString());

                var NobrList = (from c in dcHr.BASETTS
                                where c.ADATE <= RunDate && RunDate <= c.DDATE
                                && TTSCODE.Contains(c.TTSCODE)
                                && (compList.Count == 0 || compList.Contains(c.COMP))
                                && (empList.Count == 0 || empList.Contains(c.NOBR))
                                select c.NOBR).ToList();

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

                //if (configs.Where(p => p.Code == "OnTimeBufferMins").Any())
                //    OnTimeBufferMins = int.TryParse(configs.Where(p => p.Code == "OnTimeBufferMins").FirstOrDefault().Value, out OnTimeBufferMins) ? OnTimeBufferMins : -1;
                //if (configs.Where(p => p.Code == "OffTimeBufferMins").Any())
                //    OffTimeBufferMins = int.TryParse(configs.Where(p => p.Code == "OffTimeBufferMins").FirstOrDefault().Value, out OffTimeBufferMins) ? OffTimeBufferMins : -1;
                TextLog.WriteLog("開始抓取資料及計算...");
                LaborEventLawAbnormalDetector Caculator = new LaborEventLawAbnormalDetector(oAttendRepository, oOvertimeRepository, oAttCardRepository, oDetectorModel, oRepository);
                List<LaborEventLawAbnormalDto> Result = Caculator.Excute(NobrList, beginDate, endDate, OnTimeBufferMins, OffTimeBufferMins);

                //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                //{
                    try
                    {
                        TextLog.WriteLog("抓取舊資料...");
                        var OldData = Caculator.GetData(NobrList, beginDate, endDate);
                        TextLog.WriteLog("刪除舊資料，Count = " + OldData.Count());
                        Caculator.Delete(OldData);
                        TextLog.WriteLog("寫入新資料，Count = " + Result.Count());
                        Caculator.Save(Result);


                        //scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        TextLog.WriteLog(ex);
                    }

                //}
            }
            catch (Exception GEx)
            {
                TextLog.WriteLog(GEx);
            }

            var ts2 = DateTime.Now;

            TextLog.WriteLog("執行時間：" + (ts2 - ts1).TotalSeconds + "秒");
        }
    }
}
