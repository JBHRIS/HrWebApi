using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace JBModule.Message.Notify
{
    public class NotifyManager
    {
        string _ConnectionString = "";
        string _Company = "";
        public NotifyManager(string ConnectionString,string Company)
        {
            _ConnectionString = ConnectionString;
            _Company = Company;
        }
        public List<SqlParameter> Parameters { get; set; }
        public List<NotifyHelper> GetNotifyHelperList()
        {
            var  db = new DBDataContext(_ConnectionString);
            var sql = db.NotifyClass;//.Where(p => p.Comp == _Company);//Select(p => new NotifyHelper(_ConnectionString, Parameters) { QueryString = p.AssemblyName, Body = p.Message, Title = p.Title, TargetField = p.ClassName, NotifyDays = p.NotifyDay });
            List<NotifyHelper> results = new List<NotifyHelper>();
            foreach (var it in sql)
            {
                var helper = new NotifyHelper(_ConnectionString, Parameters) { QueryString = it.AssemblyName, Body = it.Message, Title = it.Title, TargetField = it.ClassName, NotifyDays = it.NotifyDay, Company=it.Comp, };
                var notifyTargetList = db.NotifyTemplate.Where(pp => pp.Comp == it.Comp && pp.NotifyType == it.Code)
                    .Select(pp => new NotifyTarget { Target = pp.Target, targetTypeEnum = helper.ConvertToTargetType(pp.TargetType) }).ToList();
                helper.notifyTargetList = notifyTargetList;
                results.Add(helper);
            }
            return results;
        }
        public NotifyHelper GetNotifyHelper(string Code)
        {
            var db = new DBDataContext(_ConnectionString);
            var sql = db.NotifyClass.Where(p => p.Code == Code && p.Comp == _Company).Select(p => new NotifyHelper(_ConnectionString, Parameters) { Company = p.Comp, QueryString = p.AssemblyName, Body = p.Message, Title = p.Title, TargetField = p.ClassName, NotifyDays=p.NotifyDay, }).ToList();
            foreach(var it in sql)
            {
                var notifyTargetList = db.NotifyTemplate.Where(pp => pp.Comp == it.Company && pp.NotifyType==Code)
                    .Select(pp=>new NotifyTarget { Target=pp.Target, targetTypeEnum=it.ConvertToTargetType(pp.TargetType)  }).ToList();
                it.notifyTargetList = notifyTargetList;
            }
            return sql.SingleOrDefault();
        }
        public void CheckNewNotify(string Comp)
        {
            DBDataContext db = new DBDataContext(_ConnectionString);
            var notifyClassComp = db.NotifyClass.Where(p => p.Comp == Comp).ToList();
            var notifyClassTemp = db.NotifyClassTemp;
            foreach (var it in notifyClassTemp)
            {
                var notifyExists = notifyClassComp.Where(p => p.Code == it.Code);
                if (!notifyExists.Any())
                {
                    var instance = new NotifyClass
                    {
                        AssemblyName = it.AssemblyName,
                        ClassName = it.ClassName,
                        Code = it.Code,
                        Comp = Comp,
                        DisplayName = it.DisplayName,
                        KeyDate = DateTime.Now,
                        KeyMan = it.KeyMan,
                        Memo = it.Memo,
                        Message = it.Message,
                        NotifyDay = it.NotifyDay,
                        RelationApp = it.RelationApp,
                        Sort = it.Sort,
                        Status = it.Status,
                        Title = it.Title,
                    };
                    db.NotifyClass.InsertOnSubmit(instance);
                }
            }
            db.SubmitChanges();
        }
    }
    public class NotifyHelper
    {
        string _ConnectionString = "";
        public List<SqlParameter> _parameters=new List<SqlParameter>();
        public string NotifyType { get; set; }
        public string NotifyName { get; set; }
        public string Company { get; set; }
        public string QueryString { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string TargetField { get; set; }
        public int NotifyDays { get; set; }
        public List<NotifyTarget> notifyTargetList { get; set; }
        public NotifyHelper(string ConnectionString, List<SqlParameter> parameters)
        {
            _ConnectionString = ConnectionString;
            _parameters =parameters;
            notifyTargetList = new List<NotifyTarget>();
        }
        public System.Data.DataTable GetNotifyData()
        {
            SqlConnection conn = new SqlConnection(_ConnectionString);
            using (conn)
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                var cmd = new SqlCommand(QueryString, conn);
                foreach (var pp in _parameters)
                {
                    try
                    {
                        cmd.Parameters.Add(new SqlParameter(pp.ParameterName,pp.Value));
                    }
                    catch (Exception ex)
                    {
                        DbLog.WriteLog(ex, "寫入Parameter發生錯誤");
                    }
                }
                var dr = cmd.ExecuteReader();
                var dt = new System.Data.DataTable();
                dt.Load(dr);
                return dt;
            }
        }
        public string GenerateContentFromTemplate(string template,Dictionary<string,string> fields)
        {
            string result = template;
            foreach(var it in fields)
            {
                result = result.Replace("{" + it.Key + "}", it.Value);
            }
            return result;
        }
        public NotifyMessage CreateNotifyMessage(Dictionary<string,string> fields)
        {
            NotifyMessage msg = new NotifyMessage();
            msg.Subject = GenerateContentFromTemplate(this.Title, fields);
            msg.Body = GenerateContentFromTemplate(Body, fields);
            msg.Target = fields[this.TargetField];
            return msg;
        }
        public void AddMessageQueue(System.Data.DataTable queryData )
        {            
            foreach(System.Data.DataRow r in queryData.Rows)
            {
                Dictionary<string, string> dicFields = new Dictionary<string, string>();
                foreach(System.Data.DataColumn dc in queryData.Columns)
                {
                    dicFields.Add(dc.ColumnName, r[dc.ColumnName].ToString());
                }
                var msg = CreateNotifyMessage(dicFields);
                string err = "";
                if(!SaveToQueue(msg,out err))
                {
                    JBModule.Message.DbLog.WriteLog(err, msg, this.GetType().Name, -1);
                }
            }
        }
        public NotifyTarget TargetGenerator(string Sponsor, TargetTypeEnum targetType,string target)
        {
            NotifyTarget notifyTarget = new NotifyTarget
            {
                Sponsor = Sponsor,
                targetTypeEnum = targetType,
                Target = target,
            };
            switch (targetType)
            {
                case TargetTypeEnum.Employee:
                    notifyTarget = GetEmployee(notifyTarget);
                    break;
                case TargetTypeEnum.HrUser:
                    notifyTarget = GetHrUser(notifyTarget);
                    break;
                case TargetTypeEnum.Sponsor:
                    notifyTarget = GetEmployee(notifyTarget);
                    break;
                case TargetTypeEnum.DeptManager:
                    notifyTarget = GetDeptManager(notifyTarget);
                    break;
                default:
                    notifyTarget.Email = target;
                    notifyTarget.Target = target;
                    notifyTarget.TargetName = target;
                    break;
            }
            return notifyTarget;
        }
        NotifyTarget GetEmployee(NotifyTarget notifytarget)
        {
            DBDataContext db = new DBDataContext();
            var sql = from a in db.BASE where a.NOBR == notifytarget.Target select new { a.NOBR, a.NAME_C, a.EMAIL };
            if (sql.Any())
            {
                var r = sql.First();
                NotifyTarget target = new NotifyTarget();
                target.Target = r.NOBR;
                target.TargetName = r.NAME_C;
                target.Email = r.EMAIL;
                return target;
            }
            else throw new Exception("找不到員工編號" + notifytarget.Target);
        }
        NotifyTarget GetHrUser(NotifyTarget notifytarget)
        {
            DBDataContext db = new DBDataContext();
            var sql = from a in db.U_USER where a.USER_ID == notifytarget.Target && a.SYSTEM == "JBHR" select new { a.USER_ID, a.NAME, a.E_MAIL };
            if (sql.Any())
            {
                var r = sql.First();
                NotifyTarget target = new NotifyTarget();
                target.Target = r.USER_ID;
                target.TargetName = r.NAME;
                target.Email = r.E_MAIL;
                return target;
            }
            else throw new Exception("找不到HrID " + notifytarget);
        }
        NotifyTarget GetDeptManager(NotifyTarget notifytarget)
        {
            DBDataContext db = new DBDataContext();
            var sql = from a in db.BASETTS
                      join b in db.DEPT on a.DEPT equals b.D_NO
                      where DateTime.Today >= a.ADATE && DateTime.Today <= a.DDATE.Value
                      && a.NOBR == notifytarget.Target
                      select new { a.NOBR, DeptManager = b.NOBR };
            if (sql.Any())
            {
                var r = sql.First();
                var value = GetEmployee(notifytarget);
                return value;
            }
            else throw new Exception("找不到員工編號" + notifytarget.Target + "的主管");
        }
        public bool SaveToQueue(NotifyMessage msg,out string ErrorMessage)
        {
            ErrorMessage = "";
            try
            {
                foreach (var it in notifyTargetList)
                {
                    var target = TargetGenerator(msg.Target, it.targetTypeEnum, it.Target);
                    Mail mail = new Mail();
                    mail.AddMailQueue(target.Email, msg.Subject, msg.Body);
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                DbLog.WriteLog(ex, this.GetType().Name,-1);
            }
            return false;
        }
        public System.Data.DataColumnCollection GetColumns()
        {
            SqlConnection conn = new SqlConnection(_ConnectionString);
            using(conn)
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                var cmd = new SqlCommand(QueryString, conn);
                foreach (var pp in _parameters)
                    cmd.Parameters.Add(pp);
                var dr = cmd.ExecuteReader();
                var dt = new System.Data.DataTable();
                dt.Load(dr);
                return dt.Columns;
            }
        }
     public   TargetTypeEnum ConvertToTargetType(string TargetType)
        {
            TargetTypeEnum type = TargetTypeEnum.None;
            switch (TargetType)
            {
                case "Sponsor":
                    type = TargetTypeEnum.Sponsor;
                    break;
                case "DeptManager":
                    type = TargetTypeEnum.DeptManager;
                    break;
                case "HrUser":
                    type = TargetTypeEnum.HrUser;
                    break;
                case "Employee":
                    type = TargetTypeEnum.Employee;
                    break;
                case "Email":
                    type = TargetTypeEnum.Email;
                    break;
            }
            return type;
        }
        public enum TargetTypeEnum
        {
            Sponsor,
            DeptManager,
            HrUser,
            Employee,
            Email,
            None
        }
    }
}
