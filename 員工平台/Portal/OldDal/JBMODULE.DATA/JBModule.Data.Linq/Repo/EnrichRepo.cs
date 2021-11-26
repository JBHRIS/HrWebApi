using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBTools.Extend;
namespace JBModule.Data.Repo
{
    public class EnrichRepo : ObjectRepo
    {
        public EnrichRepo()
        {
            db = JBModule.Data.Linq.DcHelper.GetHrDBDataContext();
        }
        public EnrichRepo(System.Data.IDbConnection connection)
        {
            db = new JBModule.Data.Linq.HrDBDataContext(connection);
        }
        public EnrichRepo(JBModule.Data.Linq.HrDBDataContext context)
        {
            db = context;
        }
        public bool DeleteEnrich(JBModule.Data.Linq.ENRICH Instance, out string Msg)
        {
            //Instance.AMT = JBModule.Data.CEncrypt.Number(Instance.AMT);
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = (from a in db.ENRICH where a.AUTOKEY==Instance.AUTOKEY select a).ToList();
                if (sql.Any())//有資料
                {
                    db.ENRICH.DeleteAllOnSubmit(sql);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }

            return true;
        }
        public bool InsertEnrich(JBModule.Data.Linq.ENRICH Instance, out string Msg)
        {
            Instance.AMT = JBModule.Data.CEncrypt.Number(Instance.AMT);
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                //var sql = (from a in db.ENRICH where a.NOBR == Instance.NOBR && a.FA_IDNO == Instance.FA_IDNO && a.YYMM == Instance.YYMM && a.SEQ == Instance.SEQ && a.SAL_CODE == Instance.SAL_CODE select a).ToList();
                //if (sql.Any())
                //{
                //    Msg += "已存在相同補扣發資料;";
                //    return false;
                //}
                //sql.Add(Instance);

                db.ENRICH.InsertOnSubmit(Instance);
                //foreach (var it in sql.OrderByDescending(pp => pp.YYMM))
                //{
                //    it.DDATE = ddate;
                //    ddate = it.ADATE.AddDays(-1);
                //}
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }

            return true;
        }
        public bool UpdateEnrich(JBModule.Data.Linq.ENRICH Instance, out string Msg)
        {
            var instanceRow = Instance.Clone();
            instanceRow.AMT = JBModule.Data.CEncrypt.Number(Instance.AMT);
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = (from a in db.ENRICH where a.AUTOKEY==instanceRow.AUTOKEY select a).ToList();
                if (sql.Any())
                {

                    //if (sql.Any())
                    //{
                    //    Msg += "已存在更新的薪資異動;";
                    //    return false;
                    //}

                    var rCurrent = sql.First();
                    rCurrent.AMT = instanceRow.AMT;
                    rCurrent.MEMO = instanceRow.MEMO;
                    rCurrent.NOBR = instanceRow.NOBR;
                    rCurrent.KEY_DATE = DateTime.Now;
                    rCurrent.KEY_MAN = instanceRow.KEY_MAN;
                    rCurrent.SAL_CODE = instanceRow.SAL_CODE;
                    rCurrent.SEQ = instanceRow.SEQ;
                    rCurrent.YYMM = instanceRow.YYMM;
                    rCurrent.FA_IDNO = instanceRow.FA_IDNO;
                    
                    //if (sql.First().ADATE == instanceRow.ADATE)
                    //{
                    //    Msg += "已存在相同日期的薪資異動;";
                    //    return false;
                    //}
                }
                //if(sql.Where(pp=>pp.ADATE==r.ADATE))//是否是同一天
                //sql.Add(instanceRow);
                //db.SALBASD.InsertOnSubmit(Instance);
                //DateTime ddate = new DateTime(9999, 12, 31);
                //foreach (var it in sql.OrderByDescending(pp => pp.ADATE))
                //{
                //    it.DDATE = ddate;
                //    ddate = it.ADATE.AddDays(-1);
                //}
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }

            return true;
        }
        public JBModule.Data.Linq.ENRICH GetInstanceByID(int ID)
        {
            var sql = from a in db.ENRICH where a.AUTOKEY == ID select a;
            return sql.FirstOrDefault();
        }
    }
}
