using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Sal.Core
{
    public class InslabCNCalculation : JBModule.Message.ReportStatus
    {
        string _NobrBegin, _NobrEnd, _DetpBegin, _DetpEnd, _YYMM;
        DateTime BaseDate;
        DateTime d1, d2;
        public InslabCNCalculation(string NobrBegin, string NobrEnd, string DetpBegin, string DetpEnd, string YYMM)
        {
            _NobrBegin = NobrBegin;
            _NobrEnd = NobrEnd;
            _DetpBegin = DetpBegin;
            _DetpEnd = DetpEnd;
            _YYMM = YYMM;
            SalaryDate sd = new SalaryDate(_YYMM);
            d1 = sd.FirstDayOfMonth;
            d2 = sd.LastDayOfMonth;
        }
        public void Run()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.InslabCN
                      join b in db.BASETTS on a.Nobr equals b.NOBR
                      join c in db.InsurCnCode on a.InsurCnCode equals c.InsurCnCode1
                      join d in db.InsCnCodeTts on c.InsurCnCode1 equals d.InsurCnCode
                      where a.InDate <= d2 && a.OutDate >= d1
                      && d2 >= b.ADATE && d2 <= b.DDATE.Value
                      && a.Nobr.CompareTo(_NobrBegin) >= 0 && a.Nobr.CompareTo(_NobrEnd) <= 0
                      && b.DEPT.CompareTo(_DetpBegin) >= 0 && b.DEPT.CompareTo(_DetpEnd) <= 0
                      && db.GetFilterByNobr(a.Nobr, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value//權限判斷
                      && new string[] { "1", "2" }.Contains(a.TtsCode)//只抓在保
                      && d2 >= d.Adate && d2 <= d.Ddate//只抓月底當時的有效設定
                      orderby  a.InDate descending
                      select new { a.Nobr, a.InsurCnCode, a.InsCnComp, a.InDate, a.OutDate, InsurCnCodeItem = c, InsCnCodeTts = d, a.Amt };
            var salbasdList = (from a in db.SALBASD
                               join b in db.BASETTS on a.NOBR equals b.NOBR
                               where d2 >= b.ADATE && d2 <= b.DDATE.Value
                               && d2 >= a.ADATE && d2 <= a.DDATE
                               && a.NOBR.CompareTo(_NobrBegin) >= 0 && a.NOBR.CompareTo(_NobrEnd) <= 0
                               && b.DEPT.CompareTo(_DetpBegin) >= 0 && b.DEPT.CompareTo(_DetpEnd) <= 0
                               && a.SAL_CODE=="A01"//只抓本薪
                               select a).ToList();
            var gpSQL = from a in sql group a by new { a.Nobr, a.InsurCnCode, a.InsurCnCodeItem.BaseDate };
            int count = gpSQL.Count();
            Delete();
            int process = 0;
            int i = 0;
            foreach (var it in gpSQL)
            {
                i++;
                process = i * 100 / count;
                this.Report(process, "社會保險計算：" + Resources.Sal.StatusComputing + it.Key.Nobr);
                DateTime BaseDateOfIns = new DateTime(d1.Year, d1.Month, it.Key.BaseDate);
                bool NeedCalc = it.Where(p => p.InDate <= BaseDateOfIns && p.OutDate >= BaseDateOfIns).Any();
                if (NeedCalc)
                {
                    decimal exp = 0, comp = 0;
                    decimal Amt = 0;
                    if (it.First().InsurCnCodeItem.RefBaseSalary)
                    {
                        var salbasdOfNobr = salbasdList.Where(p => p.NOBR == it.Key.Nobr);
                        if (salbasdOfNobr.Any())
                            Amt = salbasdOfNobr.Sum(p => JBModule.Data.CDecryp.Number(p.AMT));
                    }
                    else
                        Amt = JBModule.Data.CDecryp.Number(it.First().Amt);
                    InsuranceCN_Function icf = new InsuranceCN_Function(it.First().InsCnCodeTts, Amt);
                    exp = icf.SelfAmt();
                    comp = icf.CompAmt();
                    JBModule.Data.Linq.ExplabCN r = new JBModule.Data.Linq.ExplabCN();
                    r.AMT = JBModule.Data.CEncrypt.Number(Amt);
                    r.COMP = JBModule.Data.CEncrypt.Number(comp);
                    r.EXP = JBModule.Data.CEncrypt.Number(exp);
                    r.INSUR_TYPE = it.Key.InsurCnCode;
                    r.KEY_DATE = DateTime.Now;
                    r.KEY_MAN = MainForm.USER_NAME;
                    r.NOBR = it.Key.Nobr;
                    r.NOTEDIT = false;
                    r.S_NO = it.OrderBy(p => p.InDate).Last().InsCnComp;
                    r.SAL_CODE = it.First().InsurCnCodeItem.SalCode;
                    r.SAL_YYMM = _YYMM;
                    r.YYMM = _YYMM;
                    db.ExplabCN.InsertOnSubmit(r);
                }
            }
            db.SubmitChanges();
        }
        public void Delete()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            string cmd = "DELETE EXPLABCN WHERE EXISTS(SELECT * FROM BASETTS WHERE BASETTS.NOBR=EXPLABCN.NOBR AND BASETTS.NOBR BETWEEN {0} AND {1} AND DEPT BETWEEN {2} AND {3}) AND YYMM={4} AND " + Sal.Function.GetFilterCmdByNobrOfWrite("EXPLABCN.NOBR");
            db.ExecuteCommand(cmd, new object[] { _NobrBegin, _NobrEnd, _DetpBegin, _DetpEnd, _YYMM });
        }

    }
    public class InsuranceCN_Function
    {
        JBModule.Data.Linq.InsCnCodeTts _insCode;
        decimal amt = 0;
        public InsuranceCN_Function(JBModule.Data.Linq.InsCnCodeTts insCode, decimal Amt)
        {
            _insCode = insCode;
            amt = Amt;
        }
        public decimal SelfAmt()
        {
            //var amt = JBModule.Data.CDecryp.Number(_insCode.Amt);
            var val = amt * _insCode.SelfRate;
            return val;
        }
        public decimal CompAmt()
        {
            //var amt = JBModule.Data.CDecryp.Number(_insCode.Amt);
            var val = amt * _insCode.CompRate;
            return val;
        }
    }
}
