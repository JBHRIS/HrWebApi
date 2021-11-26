using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Newtonsoft.Json;

namespace JBHR.Bas
{
    public partial class FRM18_IMPORT : JBControls.U_IMPORT
    {
        public FRM18_IMPORT()
        {
            InitializeComponent();
        }

        private void FRM18_IMPORT_Load(object sender, EventArgs e)
        {

        }
    }

    public class ImportFRM18Data : JBControls.ImportTransfer
    {
        #region ImportFRM18Data 成員
        JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM18", MainForm.COMPANY);
        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            var AutoGenerateAbs = true;//Convert.ToBoolean(AppConfig.GetConfig("AutoGenerateAbs").Value);

            ErrMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            try
            {
                #region 存取BASE資料
                JBModule.Data.Dto.BaseDto baseDto = new JBModule.Data.Dto.BaseDto
                {
                    NOBR = TransferRow["員工編號"].ToString(),
                    NAME_C = TransferRow["中文姓名"].ToString(),
                    NAME_E = TransferRow["英文姓名"].ToString(),
                    NAME_P = TransferRow["護照姓名"].ToString(),
                    SEX = TransferRow["性別"].ToString(),
                    BIRDT = Convert.ToDateTime(TransferRow["出生日期"].ToString()),
                    ADDR1 = TransferRow["通訊地址"].ToString(),
                    ADDR2 = TransferRow["戶籍地址"].ToString(),
                    TEL1 = TransferRow["通訊電話"].ToString(),
                    TEL2 = TransferRow["戶籍電話"].ToString(),
                    BBCALL = "",
                    EMAIL = TransferRow["電子郵件"].ToString(),
                    GSM = TransferRow["行動電話"].ToString(),
                    IDNO = TransferRow["身份證號"].ToString(),
                    CONT_MAN = TransferRow["聯絡人1姓名"].ToString(),
                    CONT_TEL = TransferRow["聯絡人1電話"].ToString(),
                    CONT_GSM = TransferRow["聯絡人1行動電話"].ToString(),
                    CONT_MAN2 = TransferRow["聯絡人2姓名"].ToString(),
                    CONT_TEL2 = TransferRow["聯絡人2電話"].ToString(),
                    CONT_GSM2 = TransferRow["聯絡人2行動電話"].ToString(),
                    BLOOD = TransferRow["血型"].ToString(),
                    PASSWORD = TransferRow["密碼"].ToString(),
                    POSTCODE1 = TransferRow["通訊郵遞區號"].ToString(),
                    POSTCODE2 = TransferRow["戶籍郵遞區號"].ToString(),
                    BANK_CODE = TransferRow["外勞銀行"].ToString(),
                    BANKNO = TransferRow["轉帳銀行"].ToString(),
                    ACCOUNT_NO = TransferRow["轉帳帳號"].ToString(),
                    ACCOUNT_NA = "",//TransferRow["中国信托编号"].ToString(),
                    MARRY = TransferRow["婚姻"].ToString(),
                    COUNTRY = TransferRow["國籍"].ToString(),
                    COUNT_MA = string.IsNullOrWhiteSpace(TransferRow["外籍員工"].ToString()) ? false : Convert.ToBoolean(TransferRow["外籍員工"].ToString()),
                    ARMY = TransferRow["兵役"].ToString(),
                    PRO_MAN1 = TransferRow["保證人1姓名"].ToString(),
                    PRO_ADDR1 = TransferRow["保證人1住址"].ToString(),
                    PRO_ID1 = TransferRow["保證人1身份證號"].ToString(),
                    PRO_TEL1 = TransferRow["保證人1電話"].ToString(),
                    PRO_MAN2 = TransferRow["保證人2姓名"].ToString(),
                    PRO_ADDR2 = TransferRow["保證人2住址"].ToString(),
                    PRO_ID2 = TransferRow["保證人2身份證號"].ToString(),
                    PRO_TEL2 = TransferRow["保證人2電話"].ToString(),
                    ARMY_TYPE = "",
                    N_NOBR = TransferRow["殘障類別"].ToString(),
                    NOBR_B = TransferRow["殘障身份"].ToString(),
                    PROVINCE = TransferRow["出生地"].ToString(),
                    BORN_ADDR = "",
                    TAXCNT = string.IsNullOrWhiteSpace(TransferRow["扶養人數"].ToString()) ? 0 : Convert.ToDecimal(TransferRow["扶養人數"].ToString()),
                    KEY_MAN = MainForm.USER_ID,
                    KEY_DATE = DateTime.Now,
                    ID_TYPE = "",
                    TAXNO = TransferRow["護照號碼"].ToString(),
                    PRETAX = string.IsNullOrWhiteSpace(TransferRow["所得稅預扣金額"].ToString()) ? 0 : Convert.ToDecimal(TransferRow["所得稅預扣金額"].ToString()),
                    CONT_REL1 = TransferRow["聯絡人1關係"].ToString(),
                    CONT_REL2 = TransferRow["聯絡人2關係"].ToString(),
                    ACCOUNT_MA = TransferRow["外勞帳號"].ToString(),
                    MATNO = TransferRow["居留證號"].ToString(),
                    SUBTEL = TransferRow["分機"].ToString(),
                    BASECD = TransferRow["身份別"].ToString(),
                    NAME_AD = TransferRow["AD帳號"].ToString(),
                    CandidateWays = TransferRow["錄取管道"].ToString(),
                    AdditionDate = null,
                    AdditionNO = TransferRow["增補單號"].ToString(),
                    AdmitDate = null,
                    IntroductionBonus = false,
                    Introductor = TransferRow["介紹人"].ToString(),
                    Aboriginal = false,
                    Disability = false,
                    Gift = ""
                }; 
                JBModule.Data.Repo.BaseRepo baseRepo = new JBModule.Data.Repo.BaseRepo();
                //Base資料會強制複寫
                var OverlapBaseDto = baseRepo.GetOverlapBASE(baseDto);
                if (OverlapBaseDto != null)
                    baseRepo.UpdateBASE(baseDto, out ErrMsg);
                else
                    baseRepo.InsertBASE(baseDto, out ErrMsg);
                #endregion

                #region 判斷離職、停留、停離等日期須填寫的值
                string NOBR = TransferRow["員工編號"].ToString();
                DateTime ADate = Convert.ToDateTime(TransferRow["異動日期"].ToString());
                var sql = TTS_DateList.Where(p => p.Key == NOBR).First();

                DateTime? DDATE = null, INDT = null, OUDT = null, STDT = null, STINDT = null, STOUDT = null;

                DDATE = sql.Value.Where(p => p.ADATE == ADate).First().DDATE;
                if (DDATE == null)
                    DDATE = new DateTime(9999, 12, 31);

                var GenerateAbs = sql.Value.Where(p => p.ADATE == ADate).First().GenerateAbs;

                foreach (var item in sql.Value)
                {
                    switch (item.TTSCODE)
                    {
                        case "1":
                            INDT = item.ADATE;
                            break;
                        case "2":
                            OUDT = item.ADATE.AddDays(-1);
                            break;
                        case "3":
                            STDT = item.ADATE.AddDays(-1);
                            break;
                        case "4":
                            STINDT = item.ADATE;
                            break;
                        case "42":
                            STDT = sql.Value.OrderBy(p => p.ADATE).Where(p => p.TTSCODE == "2").First().ADATE;
                            STINDT = item.ADATE;
                            item.TTSCODE = "4";
                            break;
                        case "45":
                            STDT = sql.Value.OrderBy(p => p.ADATE).Where(p => p.TTSCODE == "5").First().ADATE;
                            STINDT = item.ADATE;
                            item.TTSCODE = "4";
                            break;
                        case "5":
                            STOUDT = item.ADATE.AddDays(-1);
                            break;
                        case "6":
                            //TransferRow["異動日期"] = item.ADATE;
                            break;
                    }

                    if (item.TTSCODE == TransferRow["異動狀態"].ToString() && item.ADATE == Convert.ToDateTime(TransferRow["異動日期"].ToString()))
                        break;
                }
                #endregion

                #region 存取BASETTS資料
                //DateTime YearDate = baseDto.YearDate.Value;
                JBModule.Data.Dto.BaseTTSDto baseTTSDto = new JBModule.Data.Dto.BaseTTSDto
                {
                    NOBR = TransferRow["員工編號"].ToString(),
                    ADATE = Convert.ToDateTime(TransferRow["異動日期"].ToString()),
                    TTSCODE = TransferRow["異動狀態"].ToString(),
                    DDATE = DDATE,//string.IsNullOrWhiteSpace(TransferRow["失效日期"].ToString()) ? (DateTime?)null : DateTime.Parse(TransferRow["失效日期"].ToString()),
                    INDT = INDT,//string.IsNullOrWhiteSpace(TransferRow["公司到職日期"].ToString()) ? (DateTime?)null : DateTime.Parse(TransferRow["公司到職日期"].ToString()),
                    CINDT = string.IsNullOrWhiteSpace(TransferRow["集團到職日"].ToString()) ? (DateTime?)null : DateTime.Parse(TransferRow["集團到職日"].ToString()),
                    OUDT = OUDT,//string.IsNullOrWhiteSpace(TransferRow["離職日期"].ToString()) ? (DateTime?)null : DateTime.Parse(TransferRow["離職日期"].ToString()),
                    STDT = STDT,//string.IsNullOrWhiteSpace(TransferRow["停薪日期"].ToString()) ? (DateTime?)null : DateTime.Parse(TransferRow["停薪日期"].ToString()),
                    STINDT = STINDT,//string.IsNullOrWhiteSpace(TransferRow["停復日期"].ToString()) ? (DateTime?)null : DateTime.Parse(TransferRow["停復日期"].ToString()),
                    STOUDT = STOUDT,// string.IsNullOrWhiteSpace(TransferRow["停離日期"].ToString()) ? (DateTime?)null : DateTime.Parse(TransferRow["停離日期"].ToString()),
                    COMP = TransferRow["公司別"].ToString(),
                    DEPT = TransferRow["編制部門代碼"].ToString(),
                    DEPTS = TransferRow["成本部門代碼"].ToString(),
                    JOB = TransferRow["職稱代碼"].ToString(),
                    JOBL = TransferRow["職等代碼"].ToString(),
                    CARD = TransferRow["刷卡"].ToString(),
                    ROTET = TransferRow["輪班別"].ToString(),
                    DI = TransferRow["直間接"].ToString(),
                    KEY_MAN = MainForm.USER_ID,
                    KEY_DATE = DateTime.Now,
                    MANG = string.IsNullOrWhiteSpace(TransferRow["部門主管"].ToString()) ? false : Convert.ToBoolean(TransferRow["部門主管"].ToString()),
                    YR_DAYS = 0,
                    WK_YRS = string.IsNullOrWhiteSpace(TransferRow["外部年資"].ToString()) ? 0 : Convert.ToDecimal(TransferRow["外部年資"].ToString()),
                    SALTP = TransferRow["薪別"].ToString(),
                    JOBS = TransferRow["職類代碼"].ToString(),
                    WORKCD = TransferRow["工作地"].ToString(),
                    CARCD = "",
                    EMPCD = TransferRow["員別"].ToString(),
                    OUTCD = TransferRow["離職原因"].ToString(),
                    CALABS = string.IsNullOrWhiteSpace(TransferRow["不計算請假"].ToString()) ? false : Convert.ToBoolean(TransferRow["不計算請假"].ToString()),
                    CALOT = TransferRow["加班比率"].ToString(),
                    FULATT = string.IsNullOrWhiteSpace(TransferRow["不計算全勤"].ToString()) ? false : Convert.ToBoolean(TransferRow["不計算全勤"].ToString()),
                    NOTER = string.IsNullOrWhiteSpace(TransferRow["不判斷遲到早退"].ToString()) ? false : Convert.ToBoolean(TransferRow["不判斷遲到早退"].ToString()),
                    NOWEL = string.IsNullOrWhiteSpace(TransferRow["不計算福利金"].ToString()) ? false : Convert.ToBoolean(TransferRow["不計算福利金"].ToString()),
                    NORET = string.IsNullOrWhiteSpace(TransferRow["不計算退休金(新制)"].ToString()) ? false : Convert.ToBoolean(TransferRow["不計算退休金(新制)"].ToString()),
                    NOTLATE = string.IsNullOrWhiteSpace(TransferRow["可取得認股權證"].ToString()) ? false : Convert.ToBoolean(TransferRow["可取得認股權證"].ToString()),
                    HOLI_CODE = TransferRow["行事曆"].ToString(),
                    NOOT = string.IsNullOrWhiteSpace(TransferRow["不產生加班"].ToString()) ? false : Convert.ToBoolean(TransferRow["不產生加班"].ToString()),
                    NOSPEC = string.IsNullOrWhiteSpace(TransferRow["不計算特休代金"].ToString()) ? false : Convert.ToBoolean(TransferRow["不計算特休代金"].ToString()),
                    NOCARD = string.IsNullOrWhiteSpace(TransferRow["不計算所得稅"].ToString()) ? false : Convert.ToBoolean(TransferRow["不計算所得稅"].ToString()),
                    NOEAT = string.IsNullOrWhiteSpace(TransferRow["不代扣伙食費"].ToString()) ? false : Convert.ToBoolean(TransferRow["不代扣伙食費"].ToString()),
                    APGRPCD = "",
                    DEPTM = TransferRow["簽核部門代碼"].ToString(),
                    TTSCD = TransferRow["異動原因"].ToString(),
                    MENO = TransferRow["備註"].ToString(),
                    SALADR = TransferRow["資料群組"].ToString(),
                    NOWAGE = string.IsNullOrWhiteSpace(TransferRow["不發薪"].ToString()) ? false : Convert.ToBoolean(TransferRow["不發薪"].ToString()),
                    MANGE = string.IsNullOrWhiteSpace(TransferRow["可知網頁人事資料"].ToString()) ? false : Convert.ToBoolean(TransferRow["可知網頁人事資料"].ToString()),
                    RETRATE = string.IsNullOrWhiteSpace(TransferRow["員工提撥比率"].ToString()) ? 0 : Convert.ToDecimal(TransferRow["員工提撥比率"].ToString()),
                    RETDATE = string.IsNullOrWhiteSpace(TransferRow["加入新制日期"].ToString()) ? (DateTime?)null : DateTime.Parse(TransferRow["加入新制日期"].ToString()),
                    RETCHOO = TransferRow["退休金制度"].ToString(),
                    RETDATE1 = string.IsNullOrWhiteSpace(TransferRow["開始提撥日"].ToString()) ? (DateTime?)null : DateTime.Parse(TransferRow["開始提撥日"].ToString()),
                    ONLYONTIME = string.IsNullOrWhiteSpace(TransferRow["只刷上班卡"].ToString()) ? false : Convert.ToBoolean(TransferRow["只刷上班卡"].ToString()),
                    JOBO = TransferRow["職級代碼"].ToString(),
                    COUNT_PASS = string.IsNullOrWhiteSpace(TransferRow["可線上刷卡"].ToString()) ? false : Convert.ToBoolean(TransferRow["可線上刷卡"].ToString()),
                    PASS_DATE = string.IsNullOrWhiteSpace(TransferRow["考試日期"].ToString()) ? (DateTime?)null : DateTime.Parse(TransferRow["考試日期"].ToString()),
                    MANG1 = string.IsNullOrWhiteSpace(TransferRow["可代申請表單"].ToString()) ? false : Convert.ToBoolean(TransferRow["可代申請表單"].ToString()),
                    AP_DATE = string.IsNullOrWhiteSpace(TransferRow["試用期滿日"].ToString()) ? (DateTime?)null : DateTime.Parse(TransferRow["試用期滿日"].ToString()),
                    GRP_AMT = 0,
                    TAX_DATE = string.IsNullOrWhiteSpace(TransferRow["居留證起始日"].ToString()) ? (DateTime?)null : DateTime.Parse(TransferRow["居留證起始日"].ToString()),
                    NOSPAMT = string.IsNullOrWhiteSpace(TransferRow["不計算三節獎金"].ToString()) ? false : Convert.ToBoolean(TransferRow["不計算三節獎金"].ToString()),
                    FIXRATE = string.IsNullOrWhiteSpace(TransferRow["所得稅固定稅率扣繳"].ToString()) ? false : Convert.ToBoolean(TransferRow["所得稅固定稅率扣繳"].ToString()),
                    TAX_EDATE = string.IsNullOrWhiteSpace(TransferRow["居留證到期日"].ToString()) ? (DateTime?)null : DateTime.Parse(TransferRow["居留證到期日"].ToString()),
                    IS_SELFOUT = string.IsNullOrWhiteSpace(TransferRow["自願離職"].ToString()) ? false : Convert.ToBoolean(TransferRow["自願離職"].ToString()),
                    INSG_TYPE = TransferRow["隸屬獎金"].ToString(),
                    OldSaladr = TransferRow["ERP"].ToString(),
                    STATION = "",
                    CardJobName = "",
                    CardJobEnName = "",
                    OilSubsidy = "",
                    CardID = "",
                    DoorGuard = "",
                    OutPost = "",
                    NOOLDRET = string.IsNullOrWhiteSpace(TransferRow["不計算退休金(舊制)"].ToString()) ? false : Convert.ToBoolean(TransferRow["不計算退休金(舊制)"].ToString()),
                    ReinstateDate = string.IsNullOrWhiteSpace(TransferRow["預計復職日"].ToString()) ? (DateTime?)null : DateTime.Parse(TransferRow["預計復職日"].ToString()),
                    PASS_TYPE = "",
                    AuditDate = null,
                    AssessManage1 = "",
                    AssessManage2 = "",
                    YTAXCN = ""
                };

                JBModule.Data.Repo.BaseTTSRepo baseTTSRepo = new JBModule.Data.Repo.BaseTTSRepo();
                var OverlapBaseTTSDto = baseTTSRepo.GetOverlapBASETTS(baseTTSDto);
                if (OverlapBaseTTSDto != null)
                {
                    if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                    {
                        baseTTSRepo.DeleteBASETTS(baseTTSDto, out ErrMsg);
                    }
                    else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                    {
                        baseTTSRepo.UpdateBASETTS(baseTTSDto, out ErrMsg);
                    }
                    else
                    {
                        ErrMsg += "已存在相同的人事異動資料";
                        return false;
                    }
                }
                else
                {
                    #region 自動產生得假
                    baseTTSRepo.InsertBASETTS(baseTTSDto, out ErrMsg);
                    if (AutoGenerateAbs && GenerateAbs)
                    {
                        var sqlHtype = from a in db.HcodeType
                                       where a.AutoCreateHours
                                       && db.GetCodeFilter("HcodeType", a.HTYPE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                       //&&  !HtypeList.Contains(a.HTYPE)
                                       select a.HTYPE;//排除特休彈休(特殊算法)
                        if (sqlHtype.Any())
                        {
                            string nobr = baseTTSDto.NOBR.ToString();
                            DateTime Adate = baseTTSDto.ADATE;
                            //Att.FRM2TG.GenerateAbsEntitle(new List<string> { nobr }, indt, new DateTime(indt.Year, 12, 31), sqlHtype.ToList());
                            var HtypeList = from a in db.HcodeType where sqlHtype.ToList().Contains(a.HTYPE) select a;
                            foreach (var tt in HtypeList)
                            {
                                string hcode = tt.GetCode;
                                var hcoeData = from a in db.HCODE where a.H_CODE == hcode select a;

                                if (!hcoeData.Any())
                                {
                                    TransferRow["警告註記"] = "匯入成功,但自動產生得假時找不到得假假別代碼的設定" + hcode;
                                    return false;
                                }
                                int year = Adate.Year;
                                JBModule.Data.Linq.HCODE hcodeRow = hcoeData.First();
                                var absSQL = (from a in db.ABS
                                                  //join b in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals b.NOBR
                                              where a.H_CODE == hcode
                                              && a.NOBR == nobr
                                              && a.YYMM == year.ToString()
                                              && a.SYSCREATE//系統產生
                                              select a).ToList();

                                var absSQLofNobr = from a in absSQL where a.NOBR == nobr select a;
                                if (absSQLofNobr.Any())
                                {
                                    if (true)
                                    {
                                        var absRow = absSQLofNobr.First();
                                        absRow.TOL_HOURS = hcodeRow.MAX_NUM;
                                        absRow.Balance = absRow.TOL_HOURS - absRow.LeaveHours;
                                        absRow.KEY_DATE = DateTime.Now;
                                        absRow.KEY_MAN = MainForm.USER_NAME;
                                    }
                                }
                                else
                                {
                                    JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                                    abs.NOBR = nobr;
                                    abs.A_NAME = "";
                                    abs.BDATE = new DateTime(Adate.Year, 1, 1);
                                    abs.EDATE = new DateTime(Adate.Year, 12, 31);
                                    abs.BTIME = "";
                                    abs.ETIME = "";
                                    abs.Guid = Guid.NewGuid().ToString();
                                    abs.H_CODE = hcode;
                                    abs.nocalc = false;
                                    abs.NOTE = "";
                                    abs.NOTEDIT = false;
                                    abs.SERNO = Guid.NewGuid().ToString();
                                    abs.SYSCREATE = true;
                                    abs.SYSCREATE1 = false;
                                    abs.TOL_DAY = 0;
                                    abs.YYMM = year.ToString();
                                    abs.TOL_HOURS = hcodeRow.MAX_NUM;
                                    abs.LeaveHours = 0;
                                    abs.Balance = abs.TOL_HOURS - abs.LeaveHours;
                                    abs.KEY_DATE = DateTime.Now;
                                    abs.KEY_MAN = MainForm.USER_NAME;
                                    db.ABS.InsertOnSubmit(abs);
                                }
                                db.SubmitChanges();
                            }
                            TransferRow["警告註記"] = "匯入成功,並產生得假資料.";
                        }
                        JBHR.Att.FRM2I.CreateNewHireYearHoloiday(baseTTSDto.NOBR.ToString(), ((DateTime)INDT).Year, (DateTime)INDT, (DateTime)INDT, true);
                    }
                    #endregion
                }
                #endregion

                #region 失效日刷新機制
                if (DDATE == new DateTime(9999, 12, 31))
                {
                    IEnumerable<JBModule.Data.Linq.BASETTS> basetts = from c in db.BASETTS
                                                                      where c.NOBR.Trim().ToLower() == baseTTSDto.NOBR
                                                                      orderby c.ADATE descending
                                                                      select c;
                    for (int i = 0; i < basetts.Count(); i++)
                    {
                        if (i == 0)
                            basetts.ElementAt(i).DDATE = Convert.ToDateTime("9999/12/31");
                        else
                            basetts.ElementAt(i).DDATE = basetts.ElementAt(i - 1).ADATE.AddDays(-1).Date;
                    }
                    db.SubmitChanges();
                } 
                #endregion
            }
            catch (Exception ex)
            {
                ErrMsg += ex.Message + ";";
                return false;
            }
            return true;
        }


        #endregion

        DataRow DR;
        List<string> keys = new List<string>() { "員工編號" };
        Dictionary<string, List<TTS_Date>> TTS_DateList = new Dictionary<string, List<TTS_Date>>();
        public List<string> MustColumns = new List<string>();
        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            string Msg = "";
            if (DR != null)
            {
                foreach (string key in keys)
                {
                    if (DR[key].ToString() != SourceRow[key].ToString())
                    {
                        DR = null;
                        break;
                    }
                }
            }

            if (DR == null)
            {
                #region 撈取DB資料存至CACHE
                var chkBASETTS = (from a in db.BASETTS
                                  where a.NOBR == SourceRow["員工編號"].ToString()
                                  orderby a.ADATE
                                  select a).ToList();
                var chkBASE = (from a in db.BASE
                               where a.NOBR == SourceRow["員工編號"].ToString()
                               select a).FirstOrDefault();
                if (chkBASETTS.Any())
                {
                    DR = TargetRow.Table.NewRow();
                    List<TTS_Date> TDList = new List<TTS_Date>();
                    foreach (var item in chkBASETTS)
                    {
                        TTS_Date TD = new TTS_Date();
                        TD.TTSCODE = item.TTSCODE;
                        TD.ADATE = item.ADATE;
                        TD.DDATE = item.DDATE;
                        TDList.Add(TD);

                        DR["員工編號"] = item.NOBR;
                        DR["中文姓名"] = chkBASE.NAME_C;
                        DR["英文姓名"] = chkBASE.NAME_E;
                        DR["外籍員工"] = chkBASE.COUNT_MA;
                        DR["異動狀態"] = item.TTSCODE;
                        DR["異動日期"] = item.ADATE;
                        DR["錄取管道"] = chkBASE.CandidateWays;
                        DR["身份證號"] = chkBASE.IDNO;
                        DR["出生日期"] = chkBASE.BIRDT == null ? (object)DBNull.Value : chkBASE.BIRDT;
                        DR["增補單號"] = chkBASE.AdditionNO;
                        DR["性別"] = chkBASE.SEX;
                        DR["血型"] = chkBASE.BLOOD;
                        DR["婚姻"] = chkBASE.MARRY;
                        DR["介紹人"] = chkBASE.Introductor;
                        DR["出生地"] = chkBASE.PROVINCE;
                        DR["兵役"] = chkBASE.ARMY;
                        DR["護照姓名"] = chkBASE.NAME_P;
                        DR["護照號碼"] = chkBASE.TAXNO;
                        DR["居留證號"] = chkBASE.MATNO;
                        DR["殘障類別"] = chkBASE.N_NOBR;
                        DR["殘障身份"] = chkBASE.NOBR_B;
                        DR["國籍"] = chkBASE.COUNTRY;
                        DR["分機"] = chkBASE.SUBTEL;
                        DR["身份別"] = chkBASE.BASECD;
                        DR["行動電話"] = chkBASE.GSM;
                        DR["電子郵件"] = chkBASE.EMAIL;
                        DR["密碼"] = chkBASE.PASSWORD;
                        DR["AD帳號"] = chkBASE.NAME_AD;
                        DR["通訊電話"] = chkBASE.TEL1;
                        DR["通訊郵遞區號"] = chkBASE.POSTCODE1;
                        DR["通訊地址"] = chkBASE.ADDR1;
                        DR["戶籍電話"] = chkBASE.TEL2;
                        DR["戶籍郵遞區號"] = chkBASE.POSTCODE2;
                        DR["戶籍地址"] = chkBASE.ADDR2;
                        DR["集團到職日"] = item.CINDT == null ? (object)DBNull.Value : item.CINDT;
                        DR["試用期滿日"] = item.AP_DATE == null ? (object)DBNull.Value : item.AP_DATE;
                        DR["公司別"] = item.COMP;
                        DR["編制部門代碼"] = item.DEPT;
                        DR["成本部門代碼"] = item.DEPTS;
                        DR["簽核部門代碼"] = item.DEPTM;
                        DR["職稱代碼"] = item.JOB;
                        DR["行事曆"] = item.HOLI_CODE;
                        DR["異動原因"] = item.TTSCD;
                        DR["職類代碼"] = item.JOBS;
                        DR["職等代碼"] = item.JOBL;
                        DR["職級代碼"] = item.JOBO;
                        DR["直間接"] = item.DI;
                        DR["員別"] = item.EMPCD;
                        DR["輪班別"] = item.ROTET;
                        DR["外部年資"] = item.WK_YRS;
                        DR["居留證起始日"] = item.TAX_DATE == null ? (object)DBNull.Value : item.TAX_DATE;
                        DR["居留證到期日"] = item.TAX_EDATE == null ? (object)DBNull.Value : item.TAX_EDATE;
                        DR["預計復職日"] = item.ReinstateDate == null ? (object)DBNull.Value : item.ReinstateDate;
                        DR["工作地"] = item.WORKCD;
                        DR["隸屬獎金"] = item.INSG_TYPE;
                        DR["ERP"] = item.OldSaladr;
                        DR["離職原因"] = item.OUTCD;
                        DR["刷卡"] = item.CARD;
                        DR["薪別"] = item.SALTP;
                        DR["加班比率"] = item.CALOT;
                        DR["資料群組"] = item.SALADR;
                        DR["退休金制度"] = item.RETCHOO;
                        DR["加入新制日期"] = item.RETDATE == null ? (object)DBNull.Value : item.RETDATE;
                        DR["開始提撥日"] = item.RETDATE1 == null ? (object)DBNull.Value : item.RETDATE1;
                        DR["員工提撥比率"] = item.RETRATE;
                        DR["所得稅預扣金額"] = chkBASE.PRETAX;
                        DR["考試日期"] = item.PASS_DATE == null ? (object)DBNull.Value : item.PASS_DATE;
                        DR["轉帳銀行"] = chkBASE.BANKNO;
                        DR["轉帳帳號"] = chkBASE.ACCOUNT_NO;
                        DR["外勞銀行"] = chkBASE.BANK_CODE;
                        DR["外勞帳號"] = chkBASE.ACCOUNT_MA;
                        DR["扶養人數"] = chkBASE.TAXCNT;
                        //DR["備註"] = item.MENO;
                        DR["聯絡人1姓名"] = chkBASE.CONT_MAN;
                        DR["聯絡人1關係"] = chkBASE.CONT_REL1;
                        DR["聯絡人1電話"] = chkBASE.CONT_TEL;
                        DR["聯絡人1行動電話"] = chkBASE.CONT_GSM;
                        DR["聯絡人2姓名"] = chkBASE.CONT_MAN2;
                        DR["聯絡人2關係"] = chkBASE.CONT_REL2;
                        DR["聯絡人2電話"] = chkBASE.CONT_TEL2;
                        DR["聯絡人2行動電話"] = chkBASE.CONT_GSM2;
                        DR["保證人1姓名"] = chkBASE.PRO_MAN1;
                        DR["保證人1身份證號"] = chkBASE.PRO_ID1;
                        DR["保證人1電話"] = chkBASE.PRO_TEL1;
                        DR["保證人1住址"] = chkBASE.PRO_ADDR1;
                        DR["保證人2姓名"] = chkBASE.PRO_MAN2;
                        DR["保證人2身份證號"] = chkBASE.PRO_ID2;
                        DR["保證人2電話"] = chkBASE.PRO_TEL2;
                        DR["保證人2住址"] = chkBASE.PRO_ADDR2;

                        DR["部門主管"] = item.MANG;
                        DR["不計算請假"] = item.CALABS;
                        DR["不計算全勤"] = item.FULATT;
                        DR["不判斷遲到早退"] = item.NOTER;
                        DR["不計算福利金"] = item.NOWEL;
                        DR["不計算退休金(新制)"] = item.NORET;
                        DR["可取得認股權證"] = item.NOTLATE;
                        DR["不產生加班"] = item.NOOT;
                        DR["不計算特休代金"] = item.NOSPEC;
                        DR["不計算所得稅"] = item.NOCARD;
                        DR["不代扣伙食費"] = item.NOEAT;
                        DR["不發薪"] = item.NOWAGE;
                        DR["可知網頁人事資料"] = item.MANGE;
                        DR["只刷上班卡"] = item.ONLYONTIME;
                        DR["可線上刷卡"] = item.COUNT_PASS;
                        DR["可代申請表單"] = item.MANG1;
                        DR["不計算三節獎金"] = item.NOSPAMT;
                        DR["所得稅固定稅率扣繳"] = item.FIXRATE;
                        DR["自願離職"] = item.IS_SELFOUT;
                        DR["不計算退休金(舊制)"] = item.NOOLDRET;
                    }
                    TTS_DateList.Add(TargetRow["員工編號"].ToString(), TDList);
                } 
                #endregion
            }

            #region 歷史資料補值檢核
            if (DR != null)
            {
                foreach (DataColumn dc in TargetRow.Table.Columns)
                {
                    string value = string.Empty;
                    if ((TargetRow[dc.ColumnName] == null || TargetRow[dc.ColumnName].ToString().Trim().Length == 0))
                    {
                        if (ColumnList.ContainsKey(dc.ColumnName))
                        {
                            if (DR.Table.Columns.Contains(dc.ColumnName))
                            {
                                value = DR[dc.ColumnName].ToString();

                                switch (ColumnList[dc.ColumnName].ToString())
                                {
                                    case "System.Decimal":
                                        Decimal valiDecimal = 0;
                                        Decimal nullDecimal = Decimal.TryParse(DR[dc.ColumnName].ToString(), out valiDecimal) ? valiDecimal : 0;
                                        TargetRow[dc.ColumnName] = valiDecimal;
                                        if (SourceRow.Table != null && SourceRow.Table.Columns.Contains(dc.ColumnName))
                                            SourceRow[dc.ColumnName] = valiDecimal;
                                        break;
                                    //case "System.Nullable`1[System.Decimal]":
                                    //    decimal decimalValue1 = 0;
                                    //    if (value.Trim().Length == 0)//null
                                    //        TargetRow[dc.ColumnName] = DBNull.Value;
                                    //    else if (decimal.TryParse(value, out decimalValue1))
                                    //        TargetRow[dc.ColumnName] = decimalValue1;
                                    //    else
                                    //        TargetRow[dc.ColumnName] = 0;
                                    //    break;
                                    case "System.Int":
                                        int validInt = 0;
                                        int nullInt = int.TryParse(DR[dc.ColumnName].ToString(), out validInt) ? validInt : 0;
                                        TargetRow[dc.ColumnName] = validInt;
                                        if (SourceRow.Table != null && SourceRow.Table.Columns.Contains(dc.ColumnName))
                                            SourceRow[dc.ColumnName] = validInt;
                                        break;
                                    case "System.DateTime":
                                        DateTime validValue;
                                        TargetRow[dc.ColumnName] = DateTime.TryParse(DR[dc.ColumnName].ToString(), out validValue) ? validValue : (object)DBNull.Value; 
                                        if (SourceRow.Table != null && SourceRow.Table.Columns.Contains(dc.ColumnName))
                                            SourceRow[dc.ColumnName] = DateTime.TryParse(DR[dc.ColumnName].ToString(), out validValue) ? validValue : (object)DBNull.Value;
                                        break;
                                    case "System.Boolean":
                                        bool validBoolean = false;
                                        bool nullBoolean = Boolean.TryParse(DR[dc.ColumnName].ToString(), out validBoolean) ? validBoolean : false;
                                        TargetRow[dc.ColumnName] = nullBoolean;
                                        if (SourceRow.Table != null && SourceRow.Table.Columns.Contains(dc.ColumnName))
                                            SourceRow[dc.ColumnName] = nullBoolean;
                                        break;
                                    default:
                                        TargetRow[dc.ColumnName] = DR[dc.ColumnName];
                                        if (SourceRow.Table != null && SourceRow.Table.Columns.Contains(dc.ColumnName))
                                            SourceRow[dc.ColumnName] = DR[dc.ColumnName];
                                        break;
                                }
                            }
                        }
                    }
                }
            } 
            #endregion

            //必填欄位檢核
            foreach (var item in MustColumns)
            {
                if (!TargetRow.Table.Columns.Contains(item) || TargetRow[item] == null || TargetRow[item].ToString().Trim().Length == 0)
                    TargetRow["錯誤註記"] += string.Format("{0}不可為空.", item);
            }

            //代碼欄位檢核
            foreach (var item in CheckData)
            {
                if (ColumnValidate(TargetRow, item.Key, TransferCheckDataField.RealCode, out Msg))
                    TargetRow[item.Key] = Msg;
                else
                {
                    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                        TargetRow["錯誤註記"] += Msg;
                }
            }

            #region 匯入資料型態檢核(員工匯入只需DateTime與Boolean)
            foreach (var item in ColumnList)
            {
                if (item.Value == typeof(DateTime) && SourceRow.Table.Columns.Contains(item.Key) && SourceRow[item.Key].ToString().Trim().Length > 0 && !check_DateTime(SourceRow[item.Key].ToString()))
                {
                    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                    {
                        TargetRow["錯誤註記"] += string.Format("{0}日期格式錯誤", item.Key);
                    }
                }
                else if (item.Value == typeof(Boolean) && SourceRow.Table.Columns.Contains(item.Key) && SourceRow[item.Key].ToString().Trim().Length > 0)
                {
                    bool Result = false;
                    if (check_boolean(SourceRow[item.Key].ToString(), out Result))
                        TargetRow[item.Key] = Result;
                    else
                    {
                        if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                        {
                            TargetRow["錯誤註記"] += string.Format("{0}資料格式錯誤(必須為Y/N,是/否,True/False)", item.Key);
                        }
                    }
                }
            }
            #endregion

            #region 異動狀態暫存紀錄
            if (TargetRow["錯誤註記"].ToString().Trim().Length == 0)
            {
                var sql = TTS_DateList.Where(p => p.Key == TargetRow["員工編號"].ToString());
                TTS_Date TD = new TTS_Date();
                TD.TTSCODE = TargetRow["異動狀態"].ToString();
                TD.ADATE = Convert.ToDateTime(TargetRow["異動日期"].ToString());
                if (sql.Any())
                {
                    List<string> preTTSCODE = new List<string>();
                    switch (TD.TTSCODE)
                    {
                        case "1":
                            TD.GenerateAbs = true;
                            break;
                        case "2":
                        case "3":
                        case "6":
                            preTTSCODE.Add("1");
                            preTTSCODE.Add("4");
                            preTTSCODE.Add("42");
                            preTTSCODE.Add("45");
                            preTTSCODE.Add("6");
                            break;
                        //case "3":
                        //    break;
                        case "4":
                            preTTSCODE.Add("2");
                            preTTSCODE.Add("3");
                            preTTSCODE.Add("5");
                            break;
                        case "5":
                            preTTSCODE.Add("3");
                            break;
                        //case "6":
                        //    break;
                        default:
                            break;
                    }

                    var TDList = sql.First().Value;
                    if ( TD.ADATE < TDList[TDList.Count - 1].ADATE )
                    {
                        if (TDList[TDList.Count - 1].TTSCODE == "1")
                            TargetRow["錯誤註記"] += string.Format("{0}到職前不可有異動紀錄", TargetRow["員工編號"].ToString());
                        else
                            TargetRow["錯誤註記"] = string.Format("無法在既有資料間插入異動資料.");
                    }
                    else if (TDList.Where(p => p.TTSCODE == TD.TTSCODE && TD.TTSCODE == "1").Any())
                    {
                        TargetRow["錯誤註記"] += string.Format("員工編號:{0}已有到職紀錄", TargetRow["員工編號"].ToString());
                    }
                    else if (TD.ADATE == TDList[TDList.Count - 1].ADATE)
                    {
                        TargetRow["錯誤註記"] += string.Format("{0}已有異動紀錄", TargetRow["異動日期"].ToString());
                    }
                    else if (TD.ADATE > TDList[TDList.Count - 1].ADATE)
                    {
                        if (preTTSCODE.Contains(TDList[TDList.Count - 1].TTSCODE))
                        {
                            if (TDList[TDList.Count - 1].TTSCODE == "2" || TDList[TDList.Count - 1].TTSCODE == "5")
                            {
                                TD.TTSCODE = TD.TTSCODE + TDList[TDList.Count - 1].TTSCODE;
                            }
                            TDList[TDList.Count - 1].DDATE = TD.ADATE.AddDays(-1);
                            sql.First().Value.Add(TD);
                        }
                        else
                        {
                            var TTSCODEList = CodeFunction.GetMtCode("TTSCODE");
                            TargetRow["錯誤註記"] += string.Format("異動狀態'{0}'的前筆資料必須為", TTSCODEList[TD.TTSCODE]);
                            foreach (var item in preTTSCODE)
                                TargetRow["錯誤註記"] += string.Format("'{0}'", TTSCODEList[item]);
                            TargetRow["錯誤註記"] += ".";
                        }
                    }

                    //for (int i = TDList.Count - 1; i >= 0; i--)
                    //{
                    //    if (i != TDList.Count - 1)
                    //    {
                    //        TargetRow["錯誤註記"] = string.Format("無法在既有資料間插入異動資料.");
                    //        break;
                    //    }
                    //    else if (TDList.Where(p => p.TTSCODE == TD.TTSCODE && TD.TTSCODE == "1").Any())
                    //    {
                    //        TargetRow["錯誤註記"] += string.Format("員工編號:{0}已有到職紀錄", TargetRow["員工編號"].ToString());
                    //        break;
                    //    }
                    //    else if (TD.ADATE == TDList[i].ADATE)
                    //    {
                    //        TargetRow["錯誤註記"] += string.Format("{0}已有異動紀錄", TargetRow["異動日期"].ToString());
                    //        break;
                    //    }
                    //    else if (TD.ADATE > TDList[i].ADATE)
                    //    {
                    //        if (preTTSCODE.Contains(TDList[i].TTSCODE))
                    //        {
                    //            if (TDList[i].TTSCODE == "2" || TDList[i].TTSCODE == "5")
                    //            {
                    //                TD.TTSCODE = TD.TTSCODE + TDList[i].TTSCODE;
                    //            }
                    //            TDList[i].DDATE = TD.ADATE.AddDays(-1);
                    //            if (i == TDList.Count - 1)
                    //                sql.First().Value.Add(TD);
                    //            else
                    //                sql.First().Value.Insert(i, TD);
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            var TTSCODEList = CodeFunction.GetMtCode("TTSCODE");
                    //            TargetRow["錯誤註記"] += string.Format("異動狀態'{0}'的前筆資料必須為", TTSCODEList[TD.TTSCODE]);
                    //            foreach (var item in preTTSCODE)
                    //                TargetRow["錯誤註記"] += string.Format("'{0}'", TTSCODEList[item]);
                    //            TargetRow["錯誤註記"] += ".";
                    //            break;
                    //        }
                    //    }
                    //}
                }
                else
                {
                    List<TTS_Date> TDList = new List<TTS_Date>();
                    if (TD.TTSCODE != "1")
                    {
                        TargetRow["錯誤註記"] += string.Format("{0}到職前不可有異動紀錄", TargetRow["員工編號"].ToString());
                        //return false;
                    }
                    else
                    {
                        TD.GenerateAbs = true;
                        TDList.Add(TD);
                        TTS_DateList.Add(TargetRow["員工編號"].ToString(), TDList);
                    }
                }
            }
            #endregion

            if (TargetRow["員工編號"] != null && check_DateTime(TargetRow["異動日期"].ToString()))
            {
                JBModule.Data.Dto.BaseTTSDto baseTTSDto = new JBModule.Data.Dto.BaseTTSDto
                {
                    NOBR = TargetRow["員工編號"].ToString(),
                    ADATE = Convert.ToDateTime(TargetRow["異動日期"].ToString()),
                    //TTSCODE = TargetRow["異動狀態"].ToString()
                };
                JBModule.Data.Repo.BaseTTSRepo baseTTSRepo = new JBModule.Data.Repo.BaseTTSRepo();
                var OverlapBASETTS = baseTTSRepo.GetOverlapBASETTS(baseTTSDto);
                if (OverlapBASETTS != null)
                {
                    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("警告註記"))
                    {
                        TargetRow["警告註記"] = "重复的资料";
                    }
                } 
            }

            if (string.IsNullOrEmpty(TargetRow["錯誤註記"].ToString()))
            {
                DR = TargetRow;
                if (TargetRow["備註"] != null)
                {
                    TargetRow["備註"] = string.Empty;
                }
                return true;
            }
            else
                return false;
        }
        bool check_DateTime(string sDate)
        {
            var d = DateTime.MaxValue;
            return DateTime.TryParse(sDate, out d);
        }

        bool check_boolean(string sbool, out bool Result)
        {
            switch (sbool.ToUpper())
            {
                case "Y":
                case "是":
                case "TRUE":
                    Result = true;
                    break;
                case "N":
                case "否":
                case "FALSE":
                    Result = false;
                    break;
                default:
                    Result = false;
                    return false;
                    //break;
            }
            return true;
        }


        class TTS_Date
        {
            public string TTSCODE;
            public DateTime ADATE;
            public DateTime? DDATE = null;
            public Boolean GenerateAbs = false;
        }
    }
}
