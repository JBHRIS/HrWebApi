using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class BaseTTSDto
    {
        public string NOBR { get; set; } //員工編號 必
        public DateTime ADATE { get; set; } //異動日期 必
        public string TTSCODE { get; set; } //異動狀態 必
        public DateTime? DDATE { get; set; } //失效日期
        public DateTime? INDT { get; set; } //公司到職日期
        public DateTime? CINDT { get; set; } //集團到職日期 必
        public DateTime? OUDT { get; set; } //離職日期
        public DateTime? STDT { get; set; } //停薪日期
        public DateTime? STINDT { get; set; } //停復日期
        public DateTime? STOUDT { get; set; } //停離日期
        public string COMP { get; set; } //公司別 必
        public string DEPT { get; set; } //編制部門 必
        public string DEPTS { get; set; } //成本部門 必
        public string JOB { get; set; } //職稱 必
        public string JOBL { get; set; } //職等 必
        public string CARD { get; set; } //刷卡
        public string ROTET { get; set; } //輪班別 必
        public string DI { get; set; } //直間接 必
        public string KEY_MAN { get; set; } //登錄者
        public DateTime KEY_DATE { get; set; } //登錄日期
        public bool MANG { get; set; } //部門主管
        public decimal YR_DAYS { get; set; } //
        public decimal WK_YRS { get; set; } //外部年資
        public string SALTP { get; set; } //薪別 必
        public string JOBS { get; set; } //職類 必
        public string WORKCD { get; set; } //工作地 必
        public string CARCD { get; set; } //
        public string EMPCD { get; set; } //員別 必
        public string OUTCD { get; set; } //離職原因
        public bool CALABS { get; set; } //不計算請假
        public string CALOT { get; set; } //加班別 必
        public bool FULATT { get; set; } //不計算全勤
        public bool NOTER { get; set; } //不判斷遲到早退
        public bool NOWEL { get; set; } //不計算福利金
        public bool NORET { get; set; } //不計算退休金(新制)
        public bool NOTLATE { get; set; } //可取得認股權證
        public string HOLI_CODE { get; set; } //行事曆 必
        public bool NOOT { get; set; } //不產生加班
        public bool NOSPEC { get; set; } //不計算特休代金
        public bool NOCARD { get; set; } //不計算所得稅
        public bool NOEAT { get; set; } //不代扣伙食費
        public string APGRPCD { get; set; } //
        public string DEPTM { get; set; } //簽核部門 必
        public string TTSCD { get; set; } //異動原因 必
        public string MENO { get; set; } //備註
        public string SALADR { get; set; } //資料群組 必
        public bool NOWAGE { get; set; } //不發薪
        public bool MANGE { get; set; } //可知網頁人事資料
        public decimal RETRATE { get; set; } //員工提撥比率
        public DateTime? RETDATE { get; set; } //加入新制日期
        public string RETCHOO { get; set; } //退休金制度 必
        public DateTime? RETDATE1 { get; set; } //開始提撥日
        public bool ONLYONTIME { get; set; } //只刷上班卡
        public string JOBO { get; set; } //職級 必
        public bool COUNT_PASS { get; set; } //可線上刷卡
        public DateTime? PASS_DATE { get; set; } //考試日期
        public bool MANG1 { get; set; } //可代申請表單
        public DateTime? AP_DATE { get; set; } //試用期滿日
        public decimal GRP_AMT { get; set; } //
        public DateTime? TAX_DATE { get; set; } //居留證起始日
        public bool NOSPAMT { get; set; } //不計算三節獎金
        public bool FIXRATE { get; set; } //所得稅固定稅率扣繳
        public DateTime? TAX_EDATE { get; set; } //居留證到期日
        public bool IS_SELFOUT { get; set; } //自願離職
        public string INSG_TYPE { get; set; } //隸屬獎金
        public string OldSaladr { get; set; } //ERP
        public string STATION { get; set; } //
        public string CardJobName { get; set; } //
        public string CardJobEnName { get; set; } //
        public string OilSubsidy { get; set; } //
        public string CardID { get; set; } //
        public string DoorGuard { get; set; } //
        public string OutPost { get; set; } //
        public bool NOOLDRET { get; set; } //不計算退休金(舊制)
        public DateTime? ReinstateDate { get; set; } //預計復職日
        public string PASS_TYPE { get; set; } //
        public DateTime? AuditDate { get; set; } //
        public string AssessManage1 { get; set; } //
        public string AssessManage2 { get; set; } //
        public string YTAXCN { get; set; } //
    }
}
