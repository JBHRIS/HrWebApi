using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Bas.Vdb
{
    public class BasVdb
    {
        /// <summary>
        /// 員工基本資料
        /// </summary>
        public List<BaseTable> BaseData { get; set; }
        /// <summary>
        /// 員工基本資料 細項
        /// </summary>
        public List<BaseDetailTable> BaseDetailData { get; set; }
        /// <summary>
        /// 員工異動資料
        /// </summary>
        public List<BasettsTable> BasettsData { get; set; }
    }

    /// <summary>
    /// 登入資訊
    /// </summary>
    public class LoginAuthRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsPass { get; set; }

    }

    public class BaseRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        public string NameC { get; set; }
        /// <summary>
        /// email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// idno
        /// </summary>
        public string Idno { get; set; }
    }

    public class BaseTable
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        public string NameC { get; set; }
        /// <summary>
        /// 英文姓名
        /// </summary>
        public string NameE { get; set; }
        /// <summary>
        /// 姓名顯示用
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 代理人1
        /// </summary>
        public string AgentNobr1 { get; set; }
    }

    public class BaseDetailTable
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        public string NameC { get; set; }
        /// <summary>
        /// 英文姓名
        /// </summary>
        public string NameE { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        public OldBll.MT.mtEnum.SexCategroy Sex { get; set; }
        /// <summary>
        /// 信箱
        /// </summary>
        public string Mail { get; set; }
        /// <summary>
        /// 身份證字號
        /// </summary>
        public string IDNo { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 異動原因代碼
        /// </summary>
        public string Ttscode { get; set; }
        /// <summary>
        /// 生效日
        /// </summary>
        public DateTime DateA { get; set; }
        /// <summary>
        /// 失效日
        /// </summary>
        public DateTime DateD { get; set; }
        /// <summary>
        /// 離職因
        /// </summary>
        public DateTime DateOut { get; set; }
        /// <summary>
        /// 成本中心代碼
        /// </summary>
        public string DeptsCode { get; set; }
        /// <summary>
        /// 成本中心名稱
        /// </summary>
        public string DeptsName { get; set; }
        /// <summary>
        /// 編制部門代碼
        /// </summary>
        public string DeptCode { get; set; }
        /// <summary>
        /// 編制部門名稱
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 簽核部門代碼
        /// </summary>
        public string DeptmCode { get; set; }
        /// <summary>
        /// 簽核部門名稱
        /// </summary>
        public string DeptmName { get; set; }
        /// <summary>
        /// 簽核部門英文名稱
        /// </summary>
        public string DeptmEName { get; set; }
        /// <summary>
        /// 職稱代碼
        /// </summary>
        public string JobCode { get; set; }
        /// <summary>
        /// 職稱名稱
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// 職稱英文名稱
        /// </summary>
        public string JobEName { get; set; }
        /// <summary>
        /// 職等代碼
        /// </summary>
        public string JoblCode { get; set; }
        /// <summary>
        /// 職等名稱
        /// </summary>
        public string JoblName { get; set; }
        /// <summary>
        /// 職級代碼
        /// </summary>
        public string JoboCode { get; set; }
        /// <summary>
        /// 職級名稱
        /// </summary>
        public string JoboName { get; set; }
        /// <summary>
        /// 職類代碼
        /// </summary>
        public string JobsCode { get; set; }
        /// <summary>
        /// 職類名稱
        /// </summary>
        public string JobsName { get; set; }
        /// <summary>
        /// 直間接
        /// </summary>
        public string DI { get; set; }
        /// <summary>
        /// 輪班序
        /// </summary>
        public string Rotet { get; set; }
        /// <summary>
        /// 加班倍率
        /// </summary>
        public string CalOt { get; set; }
        /// <summary>
        /// 行事曆
        /// </summary>
        public string Holi { get; set; }
        /// <summary>
        /// 公司別
        /// </summary>
        public string Comp { get; set; }
        /// <summary>
        /// 公司別名稱
        /// </summary>
        public string CompName { get; set; }
        /// <summary>
        /// 薪資群組
        /// </summary>
        public string Saladr { get; set; }
        /// <summary>
        /// 主管
        /// </summary>
        public bool Mang { get; set; }
        /// <summary>
        /// 秘書
        /// </summary>
        public bool Mang1 { get; set; }
        /// <summary>
        /// 到職日
        /// </summary>
        public DateTime DateIn { get; set; }
        /// <summary>
        /// 試期期滿日
        /// </summary>
        public DateTime DateAp { get; set; }
        /// <summary>
        /// 試期期通過日
        /// </summary>
        public DateTime DatePass { get; set; }
        /// <summary>
        /// 試用期評核結果
        /// </summary>
        public string PassType { get; set; }
        /// <summary>
        /// 員別
        /// </summary>
        public string Empcd { get; set; }
        /// <summary>
        /// 員別名稱
        /// </summary>
        public string EmpcdName { get; set; }
        /// <summary>
        /// 工作地
        /// </summary>
        public string Workcd { get; set; }
        /// <summary>
        /// 工作地名稱
        /// </summary>
        public string WorkcdName { get; set; }
        /// <summary>
        /// 代理人1
        /// </summary>
        public string AgentNobr1 { get; set; }
        /// <summary>
        /// 代理人2
        /// </summary>
        public string AgentNobr2 { get; set; }
        /// <summary>
        /// 新人試用主管1
        /// </summary>
        public string AssessManage1 { get; set; }
        /// <summary>
        /// 新人試用主管2
        /// </summary>
        public string AssessManage2 { get; set; }
        /// <summary>
        /// 簽核群組
        /// </summary>
        public string SignGroup { get; set; }
        /// <summary>
        /// 責任非責任制 01非責任制
        /// </summary>
        public string Carcd { get; set; }
        /// <summary>
        /// 加班費或補休假
        /// </summary>
        public string OtType { get; set; }
        /// <summary>
        /// 幣別
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 集團部門主管1
        /// </summary>
        public string GroupManage1 { get; set; }
        /// <summary>
        /// 集團部門主管2
        /// </summary>
        public string GroupManage2 { get; set; }
        /// <summary>
        /// 沒吃飯
        /// </summary>
        public bool NoEat { get; set; }
        /// <summary>
        /// 兵役
        /// </summary>
        public string Army { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Station { get; set; }
        /// <summary>
        /// 在職或離職
        /// </summary>
        public bool InOrOutState { get; set; }
        /// <summary>
        /// 年資
        /// </summary>
        public decimal InYear { get; set; }
        /// <summary>
        /// 外藉
        /// </summary>
        public bool CountMa { get; set; }
        /// <summary>
        /// 文員
        /// </summary>
        public bool DocMan { get; set; }
    }

    public class BasettsTable
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 異動原因代碼
        /// </summary>
        public string Ttscode { get; set; }
        /// <summary>
        /// 生效日
        /// </summary>
        public DateTime DateA { get; set; }
        /// <summary>
        /// 失效日
        /// </summary>
        public DateTime DateD { get; set; }
        /// <summary>
        /// 到職日
        /// </summary>
        public DateTime DateIn { get; set; }
        /// <summary>
        /// 離職因
        /// </summary>
        public DateTime DateOut { get; set; }
        /// <summary>
        /// 成本中心
        /// </summary>
        public string Depts { get; set; }
        /// <summary>
        /// 編制部門
        /// </summary>
        public string Dept { get; set; }
        /// <summary>
        /// 簽核部門
        /// </summary>
        public string Deptm { get; set; }
        /// <summary>
        /// 職稱
        /// </summary>
        public string Job { get; set; }
        /// <summary>
        /// 職等
        /// </summary>
        public string Jobl { get; set; }
        /// <summary>
        /// 職類
        /// </summary>
        public string Jobs { get; set; }
        /// <summary>
        /// 直間接
        /// </summary>
        public string DI { get; set; }
        /// <summary>
        /// 輪班序
        /// </summary>
        public string Rotet { get; set; }
        /// <summary>
        /// 加班倍率
        /// </summary>
        public string CalOt { get; set; }
        /// <summary>
        /// 行事曆
        /// </summary>
        public string Holi { get; set; }
        /// <summary>
        /// 公司別
        /// </summary>
        public string Comp { get; set; }
        /// <summary>
        /// 薪資群組
        /// </summary>
        public string Saladr { get; set; }
        /// <summary>
        /// 主管
        /// </summary>
        public bool Mang { get; set; }
        /// <summary>
        /// 秘書
        /// </summary>
        public bool Mang1 { get; set; }
        /// <summary>
        /// 員別
        /// </summary>
        public string Empcd { get; set; }

    }

    public class BaseDetailRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        public string NameC { get; set; }
        /// <summary>
        /// 英文姓名
        /// </summary>
        public string NameE { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 身份證字號
        /// </summary>
        public string IDNo { get; set; }
        /// <summary>
        /// 公司名稱
        /// </summary>
        public string CompName { get; set; }
        /// <summary>
        /// 成本中心名稱
        /// </summary>
        public string DeptsName { get; set; }
        /// <summary>
        /// 編制部門名稱
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 職稱名稱
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// 職等名稱
        /// </summary>
        public string JoblName { get; set; }
        /// <summary>
        /// 職類名稱
        /// </summary>
        public string JobsName { get; set; }
        /// <summary>
        /// 員別名稱
        /// </summary>
        public string EmpcdName { get; set; }
        /// <summary>
        /// 直間接
        /// </summary>
        public string DI { get; set; }
        /// <summary>
        /// 輪班序
        /// </summary>
        public string RotetName { get; set; }
        /// <summary>
        /// 信箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 手機
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 電話1
        /// </summary>
        public string Tel1 { get; set; }
        /// <summary>
        /// 電話2
        /// </summary>
        public string Tel2 { get; set; }
        /// <summary>
        /// 地址1
        /// </summary>
        public string Address1 { get; set; }
        /// <summary>
        /// 地址2
        /// </summary>
        public string Address2 { get; set; }
        /// <summary>
        /// 連絡人姓名
        /// </summary>
        public string ContName { get; set; }
        /// <summary>
        /// 連絡人關係
        /// </summary>
        public string ContRelName { get; set; }
        /// <summary>
        /// 連絡人電話
        /// </summary>
        public string ContTel { get; set; }
        /// <summary>
        /// 連絡人手機
        /// </summary>
        public string ContPhone { get; set; }
    }

    public class BaseBySalaryRow
    {
        public string Nobr { get; set; }
        public DateTime DateIn { get; set; }
        public string NameC { get; set; }
        public string NameE { get; set; }
        public string DeptsCode { get; set; }
        public string DeptsName { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string DeptmCode { get; set; }
        public string DeptmName { get; set; }
        public string JobCode { get; set; }
        public string JobName { get; set; }
        public string JoblCode { get; set; }
        public string JoblName { get; set; }
        public string JoboCode { get; set; }
        public string JoboName { get; set; }
        public string DI { get; set; }
        public string DI_Name { get; set; }
        public string RotetCode { get; set; }
        public string RotetName { get; set; }
        public string CompCode { get; set; }
        public string CompName { get; set; }
        public string EmpcdCode { get; set; }
        public string EmpcdName { get; set; }
        public string WorkcdCode { get; set; }
        public string WorkcdName { get; set; }
        public string CarcdCode { get; set; }
        public string CarcdName { get; set; }

        public string TtscdCode { get; set; }
        public string TtscdName { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string OilSubsidyCode { get; set; }
        public string OilSubsidyName { get; set; }
        public string ApgrpcdCode { get; set; }
        public string ApgrpcdName { get; set; }
        public string SubpoenaCostCode { get; set; }
        public string SubpoenaCostName { get; set; }
        public string ReimburseCode { get; set; }
        public string ReimburseName { get; set; }
        public string InsgTypeCode { get; set; }
        public string InsgTypeName { get; set; }
    }

    /// <summary>
    /// 家屬資料
    /// </summary>
    public class FamilyRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 身分證
        /// </summary>
        public string Idno { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 關係
        /// </summary>
        public string RelName { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
    }

    /// <summary>
    /// 學歷
    /// </summary>
    public class SchlRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 學歷名稱
        /// </summary>
        public string EducName { get; set; }
        /// <summary>
        /// 畢業
        /// </summary>
        public bool Pass { get; set; }
        /// <summary>
        /// 學校名稱
        /// </summary>
        public string SchlName { get; set; }
        /// <summary>
        /// 科系
        /// </summary>
        public string SubjName { get; set; }
        /// <summary>
        /// 開始日
        /// </summary>
        public DateTime DateB { get; set; }
        /// <summary>
        /// 結束日
        /// </summary>
        public DateTime DateE { get; set; }
    }

    /// <summary>
    /// 經歷
    /// </summary>
    public class WorksRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 公司名稱
        /// </summary>
        public string CompName { get; set; }
        /// <summary>
        /// 職稱
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 開始日
        /// </summary>
        public DateTime DateB { get; set; }
        /// <summary>
        /// 結束日
        /// </summary>
        public DateTime DateE { get; set; }
    }

    /// <summary>
    /// 獎懲
    /// </summary>
    public class AwardRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime DateA { get; set; }
        /// <summary>
        /// 獎懲類別名稱
        /// </summary>
        public string AwardName { get; set; }
        /// <summary>
        /// 大功
        /// </summary>
        public decimal Award1 { get; set; }
        /// <summary>
        /// 小功
        /// </summary>
        public decimal Award2 { get; set; }
        /// <summary>
        /// 嘉獎
        /// </summary>
        public decimal Award3 { get; set; }
        /// <summary>
        /// 獎金
        /// </summary>
        public decimal Award4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Award5 { get; set; }
        /// <summary>
        /// 大過
        /// </summary>
        public decimal Fault1 { get; set; }
        /// <summary>
        /// 小過
        /// </summary>
        public decimal Fault2 { get; set; }
        /// <summary>
        /// 警告
        /// </summary>
        public decimal Fault3 { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { get; set; }
    }

    /// <summary>
    /// 代理人資料
    /// </summary>
    public class EmpAgentRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string NameC { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string NameE { get; set; }
        /// <summary>
        /// 顯示名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 代理人工號
        /// </summary>
        public string AgentNobr { get; set; }
        /// <summary>
        /// 代理人姓名
        /// </summary>
        public string AgentNameC { get; set; }
        /// <summary>
        /// 代理人姓名
        /// </summary>
        public string AgentNameE { get; set; }
        /// <summary>
        /// 代理人顯示名
        /// </summary>
        public string AgentName { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { get; set; }
    }
    public class WorkcdRow
    {
        public string WorkcdCode { get; set; }
        public string WorkcdName { get; set; }
    }
    public class UserDefineRow
    {
        public decimal DECIMAL1 { get; set; }
        public decimal DECIMAL2 { get; set; }
        public decimal DECIMAL3 { get; set; }
        public decimal DECIMAL4 { get; set; }
        public decimal DECIMAL5 { get; set; }
        public decimal DECIMAL6 { get; set; }
        public decimal DECIMAL7 { get; set; }
        public decimal DECIMAL8 { get; set; }
        public decimal DECIMAL9 { get; set; }
        public decimal DECIMAL10 { get; set; }
        public string NVARCHAR1 { get; set; }
        public string NVARCHAR2 { get; set; }
        public string NVARCHAR3 { get; set; }
        public string NVARCHAR4 { get; set; }
        public string NVARCHAR5 { get; set; }
        public string NVARCHAR6 { get; set; }
        public string NVARCHAR7 { get; set; }
        public string NVARCHAR8 { get; set; }
        public string NVARCHAR9 { get; set; }
        public string NVARCHAR10 { get; set; }
        public DateTime DATETIME1 { get; set; }
        public DateTime DATETIME2 { get; set; }
        public DateTime DATETIME3 { get; set; }
        public DateTime DATETIME4 { get; set; }
        public DateTime DATETIME5 { get; set; }
        public DateTime DATETIME6 { get; set; }
        public DateTime DATETIME7 { get; set; }
        public DateTime DATETIME8 { get; set; }
        public DateTime DATETIME9 { get; set; }
        public DateTime DATETIME10 { get; set; }
        public string NOBR { get; set; }
        public string KEY_MAN { get; set; }
        public DateTime KEY_DATE { get; set; }

    }
}
