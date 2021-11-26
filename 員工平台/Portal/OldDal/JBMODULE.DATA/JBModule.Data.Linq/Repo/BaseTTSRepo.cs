using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class BaseTTSRepo
    {
        Linq.HrDBDataContext db = new Linq.HrDBDataContext();
        public Linq.BASETTS GetOverlapBASETTS(Dto.BaseTTSDto baseTTSDto)
        {
            var sql = from a in db.BASETTS
                      where a.NOBR == baseTTSDto.NOBR
                      && a.ADATE == baseTTSDto.ADATE
                      //&& a.TTSCODE == baseTTSDto.TTSCODE
                      select a;
            return sql.FirstOrDefault();
        }
        public bool InsertBASETTS(Dto.BaseTTSDto baseTTSDto, out string msg)
        {
            msg = "";
            try
            {
                Linq.BASETTS bASETTS = new Linq.BASETTS();
                bASETTS.NOBR = baseTTSDto.NOBR;
                bASETTS.ADATE = baseTTSDto.ADATE;
                bASETTS.TTSCODE = baseTTSDto.TTSCODE;
                bASETTS.DDATE = baseTTSDto.DDATE;
                bASETTS.INDT = baseTTSDto.INDT;
                bASETTS.CINDT = baseTTSDto.CINDT;
                bASETTS.OUDT = baseTTSDto.OUDT;
                bASETTS.STDT = baseTTSDto.STDT;
                bASETTS.STINDT = baseTTSDto.STINDT;
                bASETTS.STOUDT = baseTTSDto.STOUDT;
                bASETTS.COMP = baseTTSDto.COMP;
                bASETTS.DEPT = baseTTSDto.DEPT;
                bASETTS.DEPTS = baseTTSDto.DEPTS;
                bASETTS.JOB = baseTTSDto.JOB;
                bASETTS.JOBL = baseTTSDto.JOBL;
                bASETTS.CARD = baseTTSDto.CARD;
                bASETTS.ROTET = baseTTSDto.ROTET;
                bASETTS.DI = baseTTSDto.DI;
                bASETTS.KEY_MAN = baseTTSDto.KEY_MAN;
                bASETTS.KEY_DATE = baseTTSDto.KEY_DATE;
                bASETTS.MANG = baseTTSDto.MANG;
                bASETTS.YR_DAYS = baseTTSDto.YR_DAYS;
                bASETTS.WK_YRS = baseTTSDto.WK_YRS;
                bASETTS.SALTP = baseTTSDto.SALTP;
                bASETTS.JOBS = baseTTSDto.JOBS;
                bASETTS.WORKCD = baseTTSDto.WORKCD;
                bASETTS.CARCD = baseTTSDto.CARCD;
                bASETTS.EMPCD = baseTTSDto.EMPCD;
                bASETTS.OUTCD = baseTTSDto.OUTCD;
                bASETTS.CALABS = baseTTSDto.CALABS;
                bASETTS.CALOT = baseTTSDto.CALOT;
                bASETTS.FULATT = baseTTSDto.FULATT;
                bASETTS.NOTER = baseTTSDto.NOTER;
                bASETTS.NOWEL = baseTTSDto.NOWEL;
                bASETTS.NORET = baseTTSDto.NORET;
                bASETTS.NOTLATE = baseTTSDto.NOTLATE;
                bASETTS.HOLI_CODE = baseTTSDto.HOLI_CODE;
                bASETTS.NOOT = baseTTSDto.NOOT;
                bASETTS.NOSPEC = baseTTSDto.NOSPEC;
                bASETTS.NOCARD = baseTTSDto.NOCARD;
                bASETTS.NOEAT = baseTTSDto.NOEAT;
                bASETTS.APGRPCD = baseTTSDto.APGRPCD;
                bASETTS.DEPTM = baseTTSDto.DEPTM;
                bASETTS.TTSCD = baseTTSDto.TTSCD;
                bASETTS.MENO = baseTTSDto.MENO;
                bASETTS.SALADR = baseTTSDto.SALADR;
                bASETTS.NOWAGE = baseTTSDto.NOWAGE;
                bASETTS.MANGE = baseTTSDto.MANGE;
                bASETTS.RETRATE = baseTTSDto.RETRATE;
                bASETTS.RETDATE = baseTTSDto.RETDATE;
                bASETTS.RETCHOO = baseTTSDto.RETCHOO;
                bASETTS.RETDATE1 = baseTTSDto.RETDATE1;
                bASETTS.ONLYONTIME = baseTTSDto.ONLYONTIME;
                bASETTS.JOBO = baseTTSDto.JOBO;
                bASETTS.COUNT_PASS = baseTTSDto.COUNT_PASS;
                bASETTS.PASS_DATE = baseTTSDto.PASS_DATE;
                bASETTS.MANG1 = baseTTSDto.MANG1;
                bASETTS.AP_DATE = baseTTSDto.AP_DATE;
                bASETTS.GRP_AMT = baseTTSDto.GRP_AMT;
                bASETTS.TAX_DATE = baseTTSDto.TAX_DATE;
                bASETTS.NOSPAMT = baseTTSDto.NOSPAMT;
                bASETTS.FIXRATE = baseTTSDto.FIXRATE;
                bASETTS.TAX_EDATE = baseTTSDto.TAX_EDATE;
                bASETTS.IS_SELFOUT = baseTTSDto.IS_SELFOUT;
                bASETTS.INSG_TYPE = baseTTSDto.INSG_TYPE;
                bASETTS.OldSaladr = baseTTSDto.OldSaladr;
                bASETTS.STATION = baseTTSDto.STATION;
                bASETTS.CardJobName = baseTTSDto.CardJobName;
                bASETTS.CardJobEnName = baseTTSDto.CardJobEnName;
                bASETTS.OilSubsidy = baseTTSDto.OilSubsidy;
                bASETTS.CardID = baseTTSDto.CardID;
                bASETTS.DoorGuard = baseTTSDto.DoorGuard;
                bASETTS.OutPost = baseTTSDto.OutPost;
                bASETTS.NOOLDRET = baseTTSDto.NOOLDRET;
                bASETTS.ReinstateDate = baseTTSDto.ReinstateDate;
                bASETTS.PASS_TYPE = baseTTSDto.PASS_TYPE;
                bASETTS.AuditDate = baseTTSDto.AuditDate;
                //bASETTS.AssessManage1 = baseTTSDto.AssessManage1;
                //bASETTS.AssessManage2 = baseTTSDto.AssessManage2;
                //bASETTS.YTAXCN = baseTTSDto.YTAXCN;
                db.BASETTS.InsertOnSubmit(bASETTS);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool UpdateBASETTS(Dto.BaseTTSDto baseTTSDto, out string msg)
        {
            msg = "";
            try
            {
                var bASETTS = GetOverlapBASETTS(baseTTSDto);
                if (bASETTS != null)
                {
                    //bASETTS.NOBR = baseTTSDto.NOBR;
                    //bASETTS.ADATE = baseTTSDto.ADATE;
                    bASETTS.TTSCODE = baseTTSDto.TTSCODE;
                    bASETTS.DDATE = baseTTSDto.DDATE;
                    bASETTS.INDT = baseTTSDto.INDT;
                    bASETTS.CINDT = baseTTSDto.CINDT;
                    bASETTS.OUDT = baseTTSDto.OUDT;
                    bASETTS.STDT = baseTTSDto.STDT;
                    bASETTS.STINDT = baseTTSDto.STINDT;
                    bASETTS.STOUDT = baseTTSDto.STOUDT;
                    bASETTS.COMP = baseTTSDto.COMP;
                    bASETTS.DEPT = baseTTSDto.DEPT;
                    bASETTS.DEPTS = baseTTSDto.DEPTS;
                    bASETTS.JOB = baseTTSDto.JOB;
                    bASETTS.JOBL = baseTTSDto.JOBL;
                    bASETTS.CARD = baseTTSDto.CARD;
                    bASETTS.ROTET = baseTTSDto.ROTET;
                    bASETTS.DI = baseTTSDto.DI;
                    bASETTS.KEY_MAN = baseTTSDto.KEY_MAN;
                    bASETTS.KEY_DATE = baseTTSDto.KEY_DATE;
                    bASETTS.MANG = baseTTSDto.MANG;
                    bASETTS.YR_DAYS = baseTTSDto.YR_DAYS;
                    bASETTS.WK_YRS = baseTTSDto.WK_YRS;
                    bASETTS.SALTP = baseTTSDto.SALTP;
                    bASETTS.JOBS = baseTTSDto.JOBS;
                    bASETTS.WORKCD = baseTTSDto.WORKCD;
                    bASETTS.CARCD = baseTTSDto.CARCD;
                    bASETTS.EMPCD = baseTTSDto.EMPCD;
                    bASETTS.OUTCD = baseTTSDto.OUTCD;
                    bASETTS.CALABS = baseTTSDto.CALABS;
                    bASETTS.CALOT = baseTTSDto.CALOT;
                    bASETTS.FULATT = baseTTSDto.FULATT;
                    bASETTS.NOTER = baseTTSDto.NOTER;
                    bASETTS.NOWEL = baseTTSDto.NOWEL;
                    bASETTS.NORET = baseTTSDto.NORET;
                    bASETTS.NOTLATE = baseTTSDto.NOTLATE;
                    bASETTS.HOLI_CODE = baseTTSDto.HOLI_CODE;
                    bASETTS.NOOT = baseTTSDto.NOOT;
                    bASETTS.NOSPEC = baseTTSDto.NOSPEC;
                    bASETTS.NOCARD = baseTTSDto.NOCARD;
                    bASETTS.NOEAT = baseTTSDto.NOEAT;
                    bASETTS.APGRPCD = baseTTSDto.APGRPCD;
                    bASETTS.DEPTM = baseTTSDto.DEPTM;
                    bASETTS.TTSCD = baseTTSDto.TTSCD;
                    bASETTS.MENO = baseTTSDto.MENO;
                    bASETTS.SALADR = baseTTSDto.SALADR;
                    bASETTS.NOWAGE = baseTTSDto.NOWAGE;
                    bASETTS.MANGE = baseTTSDto.MANGE;
                    bASETTS.RETRATE = baseTTSDto.RETRATE;
                    bASETTS.RETDATE = baseTTSDto.RETDATE;
                    bASETTS.RETCHOO = baseTTSDto.RETCHOO;
                    bASETTS.RETDATE1 = baseTTSDto.RETDATE1;
                    bASETTS.ONLYONTIME = baseTTSDto.ONLYONTIME;
                    bASETTS.JOBO = baseTTSDto.JOBO;
                    bASETTS.COUNT_PASS = baseTTSDto.COUNT_PASS;
                    bASETTS.PASS_DATE = baseTTSDto.PASS_DATE;
                    bASETTS.MANG1 = baseTTSDto.MANG1;
                    bASETTS.AP_DATE = baseTTSDto.AP_DATE;
                    bASETTS.GRP_AMT = baseTTSDto.GRP_AMT;
                    bASETTS.TAX_DATE = baseTTSDto.TAX_DATE;
                    bASETTS.NOSPAMT = baseTTSDto.NOSPAMT;
                    bASETTS.FIXRATE = baseTTSDto.FIXRATE;
                    bASETTS.TAX_EDATE = baseTTSDto.TAX_EDATE;
                    bASETTS.IS_SELFOUT = baseTTSDto.IS_SELFOUT;
                    bASETTS.INSG_TYPE = baseTTSDto.INSG_TYPE;
                    bASETTS.OldSaladr = baseTTSDto.OldSaladr;
                    bASETTS.STATION = baseTTSDto.STATION;
                    bASETTS.CardJobName = baseTTSDto.CardJobName;
                    bASETTS.CardJobEnName = baseTTSDto.CardJobEnName;
                    bASETTS.OilSubsidy = baseTTSDto.OilSubsidy;
                    bASETTS.CardID = baseTTSDto.CardID;
                    bASETTS.DoorGuard = baseTTSDto.DoorGuard;
                    bASETTS.OutPost = baseTTSDto.OutPost;
                    bASETTS.NOOLDRET = baseTTSDto.NOOLDRET;
                    bASETTS.ReinstateDate = baseTTSDto.ReinstateDate;
                    bASETTS.PASS_TYPE = baseTTSDto.PASS_TYPE;
                    bASETTS.AuditDate = baseTTSDto.AuditDate;
                    //bASETTS.AssessManage1 = baseTTSDto.AssessManage1;
                    //bASETTS.AssessManage2 = baseTTSDto.AssessManage2;
                    //bASETTS.YTAXCN = baseTTSDto.YTAXCN;

                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        public bool DeleteBASETTS(Dto.BaseTTSDto baseTTSDto, out string msg)
        {
            msg = "";
            try
            {
                var bASETTS = GetOverlapBASETTS(baseTTSDto);
                if (bASETTS != null)
                {
                    db.BASETTS.DeleteOnSubmit(bASETTS);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
    }
}
