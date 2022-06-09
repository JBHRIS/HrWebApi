using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Sal.Core
{
    public class SalaryVar
    {
        static List<SALATTR> _Salattr;
        static List<SALCODE> _Salcode;
        static List<SALTYCD> _Saltycd;
        static List<LARCODE> _Larcode;
        static List<HARCODE> _Harcode;
        static List<INSURLV> _INSURLV;
        static decimal _hrate = MainForm.HealthConfig.HEACOMPRATE.Value;
        static decimal _avgFamily = MainForm.HealthConfig.COMPERSONCNT.Value;
        static decimal _funRate = 0.00025M;
        static decimal _retRate = MainForm.LabConfig.NRETIRERATE.Value;
        public static void SetLarcodeNull()
        {
            if (_Larcode != null)
                _Larcode = null;
        }
        public static void SetHarcodeNull()
        {
            if (_Harcode != null)
                _Harcode = null;
        }
        public static List<SALATTR> dtSalattr
        {
            get
            {
                SalaryMDDataContext smd = new SalaryMDDataContext();
                if (_Salattr == null)
                {
                    var sql1 = from attr in smd.SALATTR select attr;
                    _Salattr = sql1.ToList();
                }
                return _Salattr;
            }
        }
        public static SALATTR GetSalattr(string code)
        {
            var itm = from a in dtSalattr where a.SALATTR1 == code select a;
            var ans = itm.FirstOrDefault();
            return ans;
        }
        public static List<SALCODE> dtSalcode
        {
            get
            {
                SalaryMDDataContext smd = new SalaryMDDataContext();
                if (_Salcode == null)
                {
                    var sql1 = from sal in smd.SALCODE select sal;
                    _Salcode = sql1.ToList();
                }
                return _Salcode;
            }
        }
        public static SALCODE GetSalcode(string code)
        {
            var itm = from a in dtSalcode where a.SAL_CODE == code select a;
            var ans = itm.FirstOrDefault();
            return ans;
        }
        public static List<SALTYCD> dtSaltycd
        {
            get
            {
                CodeMDDataContext cdc = new CodeMDDataContext();
                if (_Saltycd == null)
                {
                    var sql1 = from sal in cdc.SALTYCD select sal;
                    _Saltycd = sql1.ToList();
                }
                return _Saltycd;
            }
        }
        public static SALTYCD GetSaltycd(string code)
        {
            var itm = from a in dtSaltycd where a.SALTYCD1.Trim() == code select a;
            var ans = itm.FirstOrDefault();
            return ans;
        }
        public static OTRATECD GetOtRateCode(string code)
        {
            CodeMDDataContext cdc = new CodeMDDataContext();
            var itm = from a in cdc.OTRATECD where a.OTRATE_CODE.Trim() == code select a;
            var ans = itm.FirstOrDefault();
            if (ans == null) throw new Exception("找不到加班比例代碼" + code);
            return ans;
        }

        public static List<LARCODE> dtLarcode
        {
            get
            {
                CodeMDDataContext cdc = new CodeMDDataContext();
                if (_Larcode == null)
                {
                    var sql1 = from sal in cdc.LARCODE select sal;
                    _Larcode = sql1.ToList();
                }
                return _Larcode;
            }
        }
        public static LARCODE GetLarCode(string code)
        {
            var itm = from a in dtLarcode where a.RATE_CODE.Trim() == code.Trim() select a;
            var ans = itm.FirstOrDefault();
            if (ans == null) throw new Exception("找不到勞保身分別代碼" + code);
            return ans;
        }

        public static List<HARCODE> dtHarcode
        {
            get
            {
                CodeMDDataContext cdc = new CodeMDDataContext();
                if (_Harcode == null)
                {
                    var sql1 = from sal in cdc.HARCODE select sal;
                    _Harcode = sql1.ToList();
                }
                return _Harcode;
            }
        }
        public static HARCODE GetHarCode(string code)
        {
            var itm = from a in dtHarcode where a.RATE_CODE.Trim() == code.Trim() select a;
            var ans = itm.FirstOrDefault();
            if (ans == null) throw new Exception("找不到健保身分別代碼" + code);
            return ans;
        }

        public static List<INSURLV> dtInsurlv
        {
            get
            {
                SalaryMDDataContext smd = new SalaryMDDataContext();
                if (_INSURLV == null)
                {
                    var sql1 = from A in smd.INSURLV select A;
                    _INSURLV = sql1.ToList();
                }
                return _INSURLV;
            }
        }
        public static INSURLV GetInsurlv(decimal code)
        {
            var itm = from a in dtInsurlv where a.AMT == code select a;
            var ans = itm.FirstOrDefault();
            return ans;
        }

        //public static List<FRM4CERM.HCODESRATE> dtHcodesrate
        //{
        //    get
        //    {
        //        SalaryMDDataContext smd = new SalaryMDDataContext();
        //        if (_INSURLV == null)
        //        {
        //            var sql1 = from A in smd.INSURLV select A;
        //            _INSURLV = sql1.ToList();
        //        }
        //        return _INSURLV;
        //    }
        //}
        //public static INSURLV GetHcodesrate(decimal code)
        //{
        //    var itm = from a in dtInsurlv where a.AMT == code select a;
        //    var ans = itm.FirstOrDefault();
        //    return ans;
        //}
        public static decimal HeaRate
        {
            get { return _hrate; }
        }
        public static decimal AvgFamily
        {
            get { return _avgFamily; }
        }
        public static decimal FudRate
        {
            get { return _funRate; }
        }
        public static decimal RetRate
        {
            get { return _retRate; }
        }
    }
}
