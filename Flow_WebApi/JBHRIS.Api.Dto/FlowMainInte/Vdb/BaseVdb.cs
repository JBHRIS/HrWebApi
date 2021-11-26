using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.FlowMainInte.Vdb
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseVdb
    {
    }


    /// <summary>
    /// 角色資訊
    /// </summary>
    public class BaseRow
    {
        /// <summary>
        /// EmpID
        /// </summary>
        [JsonProperty(PropertyName = "EmpID")]
        public string EmpID { get; set; }
        /// <summary>
        /// 工號
        /// </summary>
        [JsonProperty(PropertyName = "EmpCode")]
        public string EmpCode { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        [JsonProperty(PropertyName = "EmpNameC")]
        public string EmpNameC { get; set; }
        /// <summary>
        /// 英文姓名
        /// </summary>
        [JsonProperty(PropertyName = "EmpNameE")]
        public string EmpNameE { get; set; }
    }

    /// <summary>
    /// 角色資訊
    /// </summary>
    public class BaseInfoRow : BaseRow
    {
        /// <summary>
        /// 編制部門代碼
        /// </summary>
        [JsonProperty(PropertyName = "DeptID")]
        public string DeptID { get; set; }
        /// <summary>
        /// 成本中心代碼
        /// </summary>
        [JsonProperty(PropertyName = "DeptcID")]
        public string DeptcID { get; set; }
        /// <summary>
        /// 簽核部門代碼
        /// </summary>
        [JsonProperty(PropertyName = "DeptaID")]
        public string DeptaID { get; set; }
        /// <summary>
        /// 職稱代碼
        /// </summary>
        [JsonProperty(PropertyName = "JobID")]
        public string JobID { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }
        /// <summary>
        /// 生效日
        /// </summary>
        [JsonProperty(PropertyName = "EffectDate")]
        public DateTime EffectDate { get; set; }
        /// <summary>
        /// 公司別
        /// </summary>
        [JsonProperty(PropertyName = "CompID")]
        public string CompID { get; set; }
        /// <summary>
        /// 薪資群組
        /// </summary>
        [JsonProperty(PropertyName = "GroupID")]
        public string GroupID { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        [JsonProperty(PropertyName = "Sex")]
        public string Sex { get; set; }
        /// <summary>
        /// 主管代碼
        /// </summary>
        [JsonProperty(PropertyName = "ChiefCode")]
        public string ChiefCode { get; set; }
        /// <summary>
        /// 主兼職代碼
        /// </summary>
        [JsonProperty(PropertyName = "PosType")]
        public string PosType { get; set; }
        /// <summary>
        /// 特休基準日
        /// </summary>
        [JsonProperty(PropertyName = "BnftDate")]
        public DateTime BnftDate { get; set; }
        /// <summary>
        /// 是否為助理
        /// </summary>
        [JsonProperty(PropertyName = "IsAssistant")]
        public bool IsAssistant { get; set; }
        /// <summary>
        /// 是否可切換身分
        /// </summary>
        [JsonProperty(PropertyName = "IsChangeEmp")]
        public bool IsChangeEmp { get; set; }
    }

    /// <summary>
    /// 角色資訊
    /// </summary>
    public class BaseInfoDetailRow : BaseInfoRow
    {
        /// <summary>
        /// 生日
        /// </summary>
        [JsonProperty(PropertyName = "Birthday")]
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 身份證字號
        /// </summary>
        [JsonProperty(PropertyName = "IDNo")]
        public string IDNo { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        [JsonProperty(PropertyName = "PassWord")]
        public string PassWord { get; set; }
        /// <summary>
        /// 異動原因代碼
        /// </summary>
        [JsonProperty(PropertyName = "Ttscode")]
        public string Ttscode { get; set; }
        /// <summary>
        /// 離職日
        /// </summary>
        [JsonProperty(PropertyName = "DateOut")]
        public DateTime DateOut { get; set; }
        /// <summary>
        /// 成本中心名稱
        /// </summary>
        [JsonProperty(PropertyName = "DeptcName")]
        public string DeptcName { get; set; }
        /// <summary>
        /// 編制部門名稱
        /// </summary>
        [JsonProperty(PropertyName = "DeptName")]
        public string DeptName { get; set; }
        /// <summary>
        /// 簽核部門名稱
        /// </summary>
        [JsonProperty(PropertyName = "DeptaName")]
        public string DeptaName { get; set; }
        /// <summary>
        /// 職稱名稱
        /// </summary>
        [JsonProperty(PropertyName = "JobName")]
        public string JobName { get; set; }
        /// <summary>
        /// 職等代碼
        /// </summary>
        [JsonProperty(PropertyName = "JoblCode")]
        public string JoblCode { get; set; }
        /// <summary>
        /// 職等名稱
        /// </summary>
        [JsonProperty(PropertyName = "JoblName")]
        public string JoblName { get; set; }
        /// <summary>
        /// 職級代碼
        /// </summary>
        [JsonProperty(PropertyName = "JoboCode")]
        public string JoboCode { get; set; }
        /// <summary>
        /// 職級名稱
        /// </summary>
        [JsonProperty(PropertyName = "JoboName")]
        public string JoboName { get; set; }
        /// <summary>
        /// 職類代碼
        /// </summary>
        [JsonProperty(PropertyName = "JobsCode")]
        public string JobsCode { get; set; }
        /// <summary>
        /// 職類名稱
        /// </summary>
        [JsonProperty(PropertyName = "JobsName")]
        public string JobsName { get; set; }
        /// <summary>
        /// 直間接
        /// </summary>
        [JsonProperty(PropertyName = "DI")]
        public string DI { get; set; }
        /// <summary>
        /// 行事曆
        /// </summary>
        [JsonProperty(PropertyName = "HoliCode")]
        public string HoliCode { get; set; }
        /// <summary>
        /// 公司別名稱
        /// </summary>
        [JsonProperty(PropertyName = "CompName")]
        public string CompName { get; set; }
        /// <summary>
        /// 薪資群組
        /// </summary>
        [JsonProperty(PropertyName = "Saladr")]
        public string Saladr { get; set; }
        /// <summary>
        /// 主管
        /// </summary>
        [JsonProperty(PropertyName = "Mang")]
        public bool Mang { get; set; }
        /// <summary>
        /// 秘書
        /// </summary>
        [JsonProperty(PropertyName = "Mang1")]
        public bool Mang1 { get; set; }
        /// <summary>
        /// 到職日
        /// </summary>
        [JsonProperty(PropertyName = "DateIn")]
        public DateTime DateIn { get; set; }
        /// <summary>
        /// 員別
        /// </summary>
        [JsonProperty(PropertyName = "EmpcdCode")]
        public string EmpcdCode { get; set; }
        /// <summary>
        /// 員別名稱
        /// </summary>
        [JsonProperty(PropertyName = "EmpcdName")]
        public string EmpcdName { get; set; }
        /// <summary>
        /// 工作地
        /// </summary>
        [JsonProperty(PropertyName = "WorkID")]
        public int WorkID { get; set; }
        /// <summary>
        /// 工作地名稱
        /// </summary>
        [JsonProperty(PropertyName = "WorkName")]
        public string WorkName { get; set; }
        /// <summary>
        /// 代理人1
        /// </summary>
        [JsonProperty(PropertyName = "AgentNobr1")]
        public string AgentNobr1 { get; set; }
        /// <summary>
        /// 代理人2
        /// </summary>
        [JsonProperty(PropertyName = "AgentNobr2")]
        public string AgentNobr2 { get; set; }
        /// <summary>
        /// 基底時數
        /// </summary>
        [JsonProperty(PropertyName = "BaseHour")]
        public decimal BaseHour { get; set; }
        /// <summary>
        /// 是否為原住民
        /// </summary>
        [JsonProperty(PropertyName = "Aborigine")]
        public bool Aborigine { get; set; }
        /// <summary>
        /// 輪班別
        /// </summary>
        [JsonProperty(PropertyName = "Rotet")]
        public string Rotet { get; set; }
    }

    /// <summary>
    /// 員工延伸定義
    /// </summary>
    public class BaseParameterRow
    {
        /// <summary>
        /// EmpID
        /// </summary>
        public string EmpID { get; set; }
        /// <summary>
        /// 是否允許請假
        /// </summary>
        public bool IsAllowLeave { get; set; }
        /// <summary>
        /// IsDeformation
        /// </summary>
        public bool IsDeformation { get; set; }
        /// <summary>
        /// IsRestOver
        /// </summary>
        public bool IsRestOver { get; set; }
        /// <summary>
        /// 是否寄信
        /// </summary>
        public bool IsMail { get; set; }
    }

    /// <summary>
    /// 員工基本資料
    /// </summary>
    public class BaseByTreeRow
    {
        /// <summary>
        /// EmpID
        /// </summary>
        public string EmpID { get; set; }
        /// <summary>
        /// 工號
        /// </summary>
        public string EmpCode { get; set; }

        /// <summary>
        /// 中文姓名
        /// </summary>
        public string EmpNameC { get; set; }
        /// <summary>
        /// 英文姓名
        /// </summary>
        public string EmpNameE { get; set; }
        /// <summary>
        /// 職稱代碼
        /// </summary>
        public string JobID { get; set; }
        /// <summary>
        /// 職稱名稱
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// 主管代碼
        /// </summary>
        public string ChiefCode { get; set; }
        /// <summary>
        /// 生效日
        /// </summary>
        public DateTime EffectDate { get; set; }
        /// <summary>
        /// 簽核部門代碼
        /// </summary>
        public string DeptaID { get; set; }
        /// <summary>
        /// 簽核部門名稱
        /// </summary>
        public string DeptaName { get; set; }
        /// <summary>
        /// 簽核部門名稱
        /// </summary>
        public string ParentDeptaName { get; set; }
        /// <summary>
        /// 主兼職代碼
        /// </summary>
        public string PosType { get; set; }
    }

    /// <summary>
    /// 員工基本資料(主管識別)
    /// </summary>
    public class BaseAuthRow
    {
        /// <summary>
        /// EmpID
        /// </summary>
        public string EmpID { get; set; }
        /// <summary>
        /// 編刷部門代碼
        /// </summary>
        public string DeptID { get; set; }
        /// <summary>
        /// 可見假別代碼
        /// </summary>
        public bool DisplayHcode { get; set; }
        /// <summary>
        /// 解除申請七天限制
        /// </summary>
        public bool App7Day { get; set; }
    }

    /// <summary>
    /// 登入者權限判定
    /// </summary>
    public class BaseByAuthRow
    {
        /// <summary>
        /// 管理者
        /// </summary>
        public bool IsAdmin { get; set; }
        /// <summary>
        /// 擁有部門
        /// </summary>
        public List<DeptAuthRow> Dept { get; set; }
        /// <summary>
        /// 擁有員工
        /// </summary>
        public List<BaseAuthRow> Base { get; set; }
    }

    /// <summary>
    /// 特殊呈核流程
    /// </summary>
    public class BaseSpecialFlowRow
    {
        /// <summary>
        /// 特殊呈核流程代碼
        /// </summary>
        public int SpecialFlowID { get; set; }
        /// <summary>
        /// 群組名稱
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 呈核人員工號
        /// </summary>
        public string SourceEmpID { get; set; }
        /// <summary>
        /// 呈核人員姓名
        /// </summary>
        public string SourceName { get; set; }
        /// <summary>
        /// 被呈核人員工號
        /// </summary>
        public string TargetEmpID { get; set; }
        /// <summary>
        /// 被呈核人員姓名
        /// </summary>
        public string TargetName { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 異動人員
        /// </summary>
        public string UpdateMan { set; get; }
        /// <summary>
        /// 異動日期
        /// </summary>
        public DateTime UpdateDate { set; get; }
    }

    /// <summary>
    /// 部門
    /// </summary>
    public class DeptRow
    {
        /// <summary>
        /// 部門代碼
        /// </summary>
        public string DeptID { get; set; }
        /// <summary>
        /// 部門可見代碼
        /// </summary>
        public string DeptCode { get; set; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptNameC { get; set; }
        /// <summary>
        /// 部門名稱E
        /// </summary>
        public string DeptNameE { get; set; }
        /// <summary>
        /// 上層部門代碼
        /// </summary>
        public string ParentID { get; set; }
        /// <summary>
        /// 上層部門代碼
        /// </summary>
        public string ParentName { get; set; }
        /// <summary>
        /// 樹層級
        /// </summary>
        public string Tree { get; set; }
        /// <summary>
        /// 生效日
        /// </summary>
        public DateTime? DateA { get; set; }
        /// <summary>
        /// 失效日
        /// </summary>
        public DateTime? DateD { get; set; }
        /// <summary>
        /// 主管工號
        /// </summary>
        public string Manage { get; set; }
        /// <summary>
        /// 主管信箱
        /// </summary>
        public string ManageMail { get; set; }
        /// <summary>
        /// 樹的路徑
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 部門層級
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 單位層級
        /// </summary>
        public string Superut { get; set; }
        /// <summary>
        /// 部門層級
        /// </summary>
        public decimal Unitlvl { get; set; }
        /// <summary>
        /// 部門請假上限
        /// </summary>
        public int AbsLimit { get; set; }
        /// <summary>
        /// 週起始日
        /// </summary>
        public DateTime? WeekStartDate { get; set; }
        /// <summary>
        /// 向下部門
        /// </summary>
        public List<DeptRow> ChildDept { get; set; }
        /// <summary>
        /// 部門成員
        /// </summary>
        public List<BaseRow> Base { get; set; }
    }

    /// <summary>
    /// 部門授予權限
    /// </summary>
    public class DeptAuthRow
    {
        /// <summary>
        /// 部門代碼
        /// </summary>
        public string DeptID { get; set; }
        /// <summary>
        /// 部門代碼
        /// </summary>
        public string DeptCode { get; set; }
        /// <summary>
        /// 路徑
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 可見假別代碼
        /// </summary>
        public bool DisplayHcode { get; set; }
        /// <summary>
        /// 解除申請七天限制
        /// </summary>
        public bool App7Day { get; set; }
    }

    /// <summary>
    /// 部門
    /// </summary>
    public class DeptByTreeRow
    {
        /// <summary>
        /// 部門代碼
        /// </summary>
        public string DeptID { get; set; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptNameC { get; set; }
        /// <summary>
        /// 上層部門代碼
        /// </summary>
        public string ParentID { get; set; }
        /// <summary>
        /// 上層部門名稱
        /// </summary>
        public string ParentName { get; set; }
        /// <summary>
        /// 部門路徑
        /// </summary>
        public string PathName { get; set; }
        /// <summary>
        /// 樹層級
        /// </summary>
        public string Tree { get; set; }
        /// <summary>
        /// 部門層級
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 主管工號
        /// </summary>
        public string Manage { get; set; }
        /// <summary>
        /// 部門成員
        /// </summary>
        public List<BaseByTreeRow> Base { get; set; }
    }

    /// <summary>
    /// 部門以照層級展開列表
    /// </summary>
    public class DeptLevelListRow
    {
        /// <summary>
        /// 部門層級
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 向下部門
        /// </summary>
        public List<DeptByTreeRow> Dept { get; set; }
    }

    /// <summary>
    /// 主管代填人設定
    /// </summary>
    public class DeptSecretaryRow
    {
        /// <summary>
        /// DeptSecretaryID
        /// </summary>
        public int DeptSecretaryID { get; set; }
        /// <summary>
        /// 部門代碼
        /// </summary>
        public string DeptCode { get; set; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 員工編號
        /// </summary>
        public string EmpID { get; set; }
        /// <summary>
        /// 員工姓名
        /// </summary>
        public string EmpName { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 異動人員
        /// </summary>
        public string UpdateMan { set; get; }
        /// <summary>
        /// 異動日期
        /// </summary>
        public DateTime UpdateDate { set; get; }
    }

    /// <summary>
    /// 人力處管轄單位
    /// </summary>
    public class DeptHumanRow
    {
        /// <summary>
        /// DeptHumanID
        /// </summary>
        public int DeptHumanID { get; set; }
        /// <summary>
        /// 部門代碼
        /// </summary>
        public string DeptCode { get; set; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 員工編號
        /// </summary>
        public string EmpID { get; set; }
        /// <summary>
        /// 員工姓名
        /// </summary>
        public string EmpName { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 異動人員
        /// </summary>
        public string UpdateMan { set; get; }
        /// <summary>
        /// 異動日期
        /// </summary>
        public DateTime UpdateDate { set; get; }
    }

    /// <summary>
    /// 部門
    /// </summary>
    public class DeptByEditRow
    {
        /// <summary>
        /// 部門代碼
        /// </summary>
        public string DeptID { get; set; }
        /// <summary>
        /// 部門可見代碼
        /// </summary>
        public string DeptCode { get; set; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptNameC { get; set; }
        /// <summary>
        /// 部門名稱E
        /// </summary>
        public string DeptNameE { get; set; }
        /// <summary>
        /// 部門請假上限
        /// </summary>
        public int AbsLimit { get; set; }
        /// <summary>
        /// 週起始日
        /// </summary>
        public DateTime? WeekStartDate { get; set; }
        /// <summary>
        /// 異動人員
        /// </summary>
        public string UpdateMan { set; get; }
        /// <summary>
        /// 異動日期
        /// </summary>
        public DateTime UpdateDate { set; get; }
    }

    /// <summary>
    /// 部門請假限額
    /// </summary>
    public class DeptLimitRow
    {
        /// <summary>
        /// 
        /// </summary>
        public int DeptLimitID { get; set; }
        /// <summary>
        /// 部門可見代碼
        /// </summary>
        public string DeptCode { get; set; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 請假日期
        /// </summary>
        public string AbsDate { get; set; }
        /// <summary>
        /// 部門請假上限
        /// </summary>
        public int AbsLimit { get; set; }
        /// <summary>
        /// 異動人員
        /// </summary>
        public string UpdateMan { set; get; }
        /// <summary>
        /// 異動日期
        /// </summary>
        public DateTime UpdateDate { set; get; }
    }

    /// <summary>
    /// 部門請假限額延伸欄位
    /// </summary>
    public class DeptLimitExtendRow : DeptLimitRow
    {
        /// <summary>
        /// 
        /// </summary>
        public string DeptID { get; set; }

        private DateTime? _AbsDate;
        /// <summary>
        /// 開始日期
        /// </summary>
        public new DateTime? AbsDate
        {
            set
            {
                _AbsDate = value;
                base.AbsDate = value.ToString();
            }
            get
            {
                return _AbsDate;
            }
        }
    }

    /// <summary>
    /// 員別
    /// </summary>
    public class IdentityRow
    {
        /// <summary>
        /// IdentityID
        /// </summary>
        public string IdentityID { get; set; }
        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string NameC { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string NameE { get; set; }
        /// <summary>
        /// 順序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 基礎時數
        /// </summary>
        public decimal BaseHour { get; set; }
    }


    /// <summary>
    /// 員工基本資料
    /// </summary>
    public class BaseRowInfo
    {
        /// <summary>
        /// 員工基本資料
        /// </summary>
        //[JsonProperty(PropertyName = "Base")]
        //public Base Base { get; set; }

        /// <summary>
        /// 人事資料
        /// </summary>
        [JsonProperty(PropertyName = "Base")]
        public DeptView DeptView { get; set; }

        /// <summary>
        /// 學歷
        /// </summary>
        [JsonProperty(PropertyName = "SchlView")]
        public List<SchlView> SchlView { get; set; }

        /// <summary>
        /// 在職狀態
        /// </summary>
        [JsonProperty(PropertyName = "Ttscode")]
        public string Ttscode { get; set; }

        /// <summary>
        /// 在職狀態
        /// </summary>
        [JsonProperty(PropertyName = "WorkState")]
        public string WorkState { get; set; }
    }

    public class DeptView
    {


        /// <summary>
        /// 編制部門
        /// </summary>
        [JsonProperty(PropertyName = "Dept")]
        public string Dept { get; set; }

        /// <summary>
        /// 簽核部門
        /// </summary>
        [JsonProperty(PropertyName = "Depta")]
        public string Depta { get; set; }

        /// <summary>
        /// 成本部門
        /// </summary>
        [JsonProperty(PropertyName = "Depts")]
        public string Depts { get; set; }
        /// <summary>
        /// 編制部門
        /// </summary>
        [JsonProperty(PropertyName = "DeptName")]
        public string DeptName { get; set; }

        /// <summary>
        /// 簽核部門
        /// </summary>
        [JsonProperty(PropertyName = "DeptaName")]
        public string DeptaName { get; set; }

        /// <summary>
        /// 成本部門
        /// </summary>
        [JsonProperty(PropertyName = "DeptsName")]
        public string DeptsName { get; set; }

        /// <summary>
        /// 職稱
        /// </summary>
        [JsonProperty(PropertyName = "JobName")]
        public string JobName { get; set; }
    }

    public class SchlView
    {
        /// <summary>
        /// 工號
        /// </summary>
        [JsonProperty(PropertyName = "Nobr")]
        public string Nobr { get; set; }
        /// <summary>
        /// 教育程度
        /// </summary>
        [JsonProperty(PropertyName = "Educcode")]
        public string Educcode { get; set; }
        /// <summary>
        /// 教育程度
        /// </summary>
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        /// <summary>
        /// 生效日期
        /// </summary>
        [JsonProperty(PropertyName = "Adate")]
        public DateTime Adate { get; set; }
        /// <summary>
        /// 學校名稱
        /// </summary>
        [JsonProperty(PropertyName = "Schl1")]
        public string Schl1 { get; set; }
        /// <summary>
        /// 科系
        /// </summary>
        [JsonProperty(PropertyName = "Subj")]
        public string Subj { get; set; }
        /// <summary>
        /// 入學日
        /// </summary>
        [JsonProperty(PropertyName = "DateB")]
        public DateTime DateB { get; set; }
        /// <summary>
        /// 畢業日
        /// </summary>
        [JsonProperty(PropertyName = "DateE")]
        public DateTime DateE { get; set; }
        /// <summary>
        /// 是否畢業
        /// </summary>
        [JsonProperty(PropertyName = "Ok")]
        public bool Ok { get; set; }

    }


    public class Depts
    {
        public string DeptsID { get; set; }
        public string DeptsName { get; set; }
    }
}
