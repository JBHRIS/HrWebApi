using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data
{
    public class ApplicationConfig //
    {
        public string Code = "";
        public string Value = null;
        internal ApplicationConfig()
        {

        }
        internal ApplicationConfig(string code)
        {
            this.Code = code;
        }
        public string GetString(string DefaulValue)
        {
            if (Value == null || Value == "") return DefaulValue;
            return Value;
        }
        public string GetString()
        {
            if (Value == null) throw new Exception("找不到指定的設定檔代碼" + Code);
            return Value;
        }
        public int GetInter(int DefaulValue)
        {
            if (Value == null || Value == "") return DefaulValue;
            int rtn = Convert.ToInt32(Value);
            return rtn;
        }
        public int GetInter()
        {
            if (Value == null) throw new Exception("找不到指定的設定檔代碼" + Code);
            else if (Value == "") throw new Exception("指定的設定檔代碼" + Code + "未設定有效值");
            int rtn = Convert.ToInt32(Value);
            return rtn;
        }
        public DateTime GetDateTime(DateTime DefaulValue)
        {
            if (Value == null || Value == "") return DefaulValue;
            DateTime rtn = Convert.ToDateTime(Value);
            return rtn;
        }
        public DateTime GetDateTime()
        {
            if (Value == null) throw new Exception("找不到指定的設定檔代碼" + Code);
            else if (Value == "") throw new Exception("指定的設定檔代碼" + Code + "未設定有效值");
            DateTime rtn = Convert.ToDateTime(Value);
            return rtn;
        }
        public decimal GetDecimal(decimal DefaulValue)
        {
            if (Value == null || Value == "") return DefaulValue;
            Decimal rtn = Convert.ToDecimal(Value);
            return rtn;
        }
        public decimal GetDecimal()
        {
            if (Value == null) throw new Exception("找不到指定的設定檔代碼" + Code);
            else if (Value == "") throw new Exception("指定的設定檔代碼" + Code + "未設定有效值");
            Decimal rtn = Convert.ToDecimal(Value);
            return rtn;
        }
        public bool GetBoolean(bool DefaulValue)
        {
            if (Value == null || Value == "") return DefaulValue;
            bool rtn = Convert.ToBoolean(Value);
            return rtn;
        }
        public bool GetBoolean()
        {
            if (Value == null) throw new Exception("找不到指定的設定檔代碼" + Code);
            else if (Value == "") throw new Exception("指定的設定檔代碼" + Code + "未設定有效值");
            bool rtn = Convert.ToBoolean(Value);
            return rtn;
        }
    }
    public class ApplicationConfigSettings
    {
        List<ApplicationConfig> configs;
        string _Category, _Comp;
        public ApplicationConfigSettings(string Category, string Comp)
        {
            this._Category = Category;
            this._Comp = Comp;
            var db = new Linq.HrDBDataContext();
            var sql = from a in db.AppConfig
                      where a.Category == Category
                      && a.Comp == Comp
                      select new ApplicationConfig
                      {
                          Code = a.Code,
                          Value = a.Value
                      };
            configs = sql.ToList();
        }
        public ApplicationConfigSettings(string Category, string Nobr, DateTime ddate)
        {
            var db = new Linq.HrDBDataContext();
            var sql = from a in db.BASETTS
                      where a.NOBR == Nobr
                      && ddate <= a.DDATE
                      orderby a.DDATE
                      select new { a.NOBR, a.ADATE, a.DDATE, a.SALADR };
            this._Category = Category;
            if (sql.Any())
            {
                string datagroup = sql.First().SALADR;
                var qq = from a in db.DATAGROUP where a.DATAGROUP1 == datagroup select a;
                if (qq.Any())
                {
                    string Comp = qq.First().COMP;
                    var sql1 = from a in db.AppConfig
                               where a.Category == Category
                               && a.Comp == Comp
                               select new ApplicationConfig
                               {
                                   Code = a.Code,
                                   Value = a.Value
                               };
                    configs = sql1.ToList();
                }
            }
        }
        public ApplicationConfig GetConfig(string Code)
        {
            var confs = from a in configs where a.Code == Code select a;
            if (confs.Any())
            {
                var conf = confs.First();
                return conf;
            }
            else
            {
                return new ApplicationConfig(Code);
            }
        }
        public void CheckParameterAndSetDefault(string Code, string NameP, string Value, string Descr, string ControlType, string DataSource, string DataType)
        {
            if (!configs.Where(p => p.Code == Code).Any())
            {
                var db = new Linq.HrDBDataContext();
                Linq.AppConfig r = new Linq.AppConfig();
                r.Category = _Category;
                r.Code = Code;
                r.Comp = _Comp;
                r.ControlType = ControlType;
                r.DataSource = DataSource;
                r.DataType = DataType;
                r.KeyDate = DateTime.Now;
                r.KeyMan = "JB";
                r.NameP = NameP;
                r.Note = Descr;
                r.Sort = configs.Count;
                r.Value = Value;
                db.AppConfig.InsertOnSubmit(r);
                db.SubmitChanges();
                var ap = new ApplicationConfig();
                ap.Code = r.Code;
                ap.Value = r.Value;
                configs.Add(ap);
            }
        }
    }
}

