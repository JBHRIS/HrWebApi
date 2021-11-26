using Dal;
using Dal.Dao;
using Dal.Dao.Share;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MonitorShare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("版本：2020120101\n");

            var DateB = DateTime.Now;
            Console.Write("開始日期時間：" + DateB + "\n");

            Console.BackgroundColor = ConsoleColor.Green;

            var _ReadKey = ConfigurationManager.AppSettings["ReadKey"] == "1";

            Console.Write("結束必須按任意鍵：" + _ReadKey + "\n");

            dcShareDataContext dcShare = new dcShareDataContext();
            Console.Write("資料庫：" + dcShare.Connection.Database + "\n");

            Console.ResetColor(); //將控制檯的前景色和背景色設為預設值

            var oMain = new MainDao(dcShare);

            var oShareSendQueue = new ShareSendQueueDao(dcShare);

            //寄信
            {
                var oShareDefault = new ShareDefaultDao(dcShare);
                var rMail = oShareDefault.DefaultMail;

                var MaxRetry = rMail.MaxRetry;

                var _MonitorSendMail = System.Configuration.ConfigurationSettings.AppSettings["MonitorSendMail"] == "1";

                if (_MonitorSendMail)
                {
                    //寄送 還沒完成 且 沒有暫停的郵件 且 小於寄送上限
                    //var ShareSendQueueCond = new ShareSendQueueConditions();
                    //ShareSendQueueCond.ListSendTypeCode = new List<string>();
                    //ShareSendQueueCond.ListSendTypeCode.Add("01");
                    //var rsSendQueue = oShareSendQueue.GetShareSendQueueNotSend(ShareSendQueueCond);

                    var rsSendQueue = (from c in dcShare.ShareSendQueue
                                       where c.Status == "1"
                                       && c.SendTypeCode == "01"
                                       && !c.Sucess && !c.Suspend
                                       && c.Retry < MaxRetry
                                       select c).ToList();

                    foreach (var rSendQueue in rsSendQueue)
                    {
                        var Subject = rSendQueue.Subject;
                        var Body = rSendQueue.Body;
                        var ToAddr = rSendQueue.ToAddr;
                        var ToName = rSendQueue.ToName;
                        var ToMain = new MailAddress(ToAddr, ToName);
                        var Sucess = oShareSendQueue.SendMail(ToMain, Subject, Body);

                        if (Sucess)
                        {
                            //修改內容
                            rSendQueue.Retry = rSendQueue.Retry + 1;
                            rSendQueue.Sucess = true;
                            rSendQueue.DateSend = DateTime.Now;

                            var oMessageLog = oMain.MessageLog("0", "SendMail", JsonConvert.SerializeObject(rSendQueue), "MonitorShare", "", "System");

                            Console.Write("姓名：" + ToName + ",信箱：" + ToAddr + ",主旨：" + Subject + "\n");
                        }
                    }

                    dcShare.SubmitChanges();
                }
            }

            Console.Write("程式執行結束\n");

            var DateE = DateTime.Now;
            Console.Write("結束日期時間：" + DateE + "\n");

            TimeSpan ts = DateE - DateB;
            Console.Write("共花：" + ts.TotalSeconds + "秒完成\n");

            if (_ReadKey)
            {
                Console.Write("按下任意鍵繼續...\n");
                Console.ReadKey();
            }
        }
    }
}