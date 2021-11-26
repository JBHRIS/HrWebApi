using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Message.Notify
{
 public   class NotifyService
 {
     string _ConnectionString { get; set; }
     string _Company { get; set; }
     public List<System.Data.SqlClient.SqlParameter> parameters = new List<System.Data.SqlClient.SqlParameter>();
     public NotifyService(string ConnectionString, string Company)
     {
         _ConnectionString = ConnectionString;
         _Company = Company;
     }
     public void CheckNotify()
     {
         NotifyManager manager = new NotifyManager(_ConnectionString, _Company);
         var notifyList = manager.GetNotifyHelperList();
         JBModule.Message.TextLog.WriteLog("共取得" + notifyList.Count().ToString() + "通知設定");
         foreach (var helper in notifyList)
         {
             JBModule.Message.TextLog.WriteLog("初始化" + helper.NotifyName + "(" + helper.Company + ")-----------");
             if (!helper.notifyTargetList.Any())
             {
                 JBModule.Message.TextLog.WriteLog("未設定通知對象===>略過");
                 continue;//沒有對象就不動作
             }
             helper._parameters = new List<System.Data.SqlClient.SqlParameter>();
             helper._parameters.Add(new System.Data.SqlClient.SqlParameter("DateBegin", DateTime.Today.AddDays(-1 * helper.NotifyDays)));
             helper._parameters.Add(new System.Data.SqlClient.SqlParameter("DateEnd", DateTime.Today.AddDays(-1 * helper.NotifyDays)));
             helper._parameters.Add(new System.Data.SqlClient.SqlParameter("Company", helper.Company));
             helper._parameters.AddRange(parameters.ToArray());
             var data = helper.GetNotifyData();
             JBModule.Message.TextLog.WriteLog("共取得" + data.Rows.Count.ToString() + "通知內容");
             JBModule.Message.TextLog.WriteLog("加入佇列");
             helper.AddMessageQueue(data);
             JBModule.Message.TextLog.WriteLog("完成");
         }
     }

 }
}
