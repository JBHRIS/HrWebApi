using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBTools.Extend;
namespace JBHR.Sal
{
    public partial class FRM4P : JBControls.U_PATCH
    {
        JBModule.Data.ApplicationConfigSettings acg = null;
        public FRM4P()
        {
            InitializeComponent();
            this.FieldForm = new FRM4PP();
            this.DataTransfer = new CompensatoryLeaveCashOutTransfer();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            this.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            this.DataTransfer.CheckData.Add("假別代碼", db.HCODE.Select(p => new JBControls.CheckImportData { DisplayCode = p.H_CODE_DISP, RealCode = p.H_CODE, DisplayName = p.H_NAME }).ToList());
            this.DataTransfer.CheckData.Add("員工編號", db.BASE.Where(p => db.GetFilterByNobr(p.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value).Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());

            this.DataTransfer.ColumnList = new Dictionary<string, Tuple<string, Type, string>>();
            //frm.DataTransfer.ColumnList.Add("YYMM", new Tuple<string, Type, string>("計薪年月", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("CashType", new Tuple<string, Type, string>("代金種類", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("EmployeeID", new Tuple<string, Type, string>("員工編號", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("EmployeeName", new Tuple<string, Type, string>("員工姓名", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("DateBegin", new Tuple<string, Type, string>("生效日期", typeof(DateTime), ""));
            this.DataTransfer.ColumnList.Add("DateEnd", new Tuple<string, Type, string>("失效日期", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("DateOut", new Tuple<string, Type, string>("離職日期", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("DateStop", new Tuple<string, Type, string>("留停日期", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("HoliName", new Tuple<string, Type, string>("假別", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("Entitle", new Tuple<string, Type, string>("得假", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("Taken", new Tuple<string, Type, string>("已請", typeof(decimal), ""));
            this.DataTransfer.ColumnList.Add("Balance", new Tuple<string, Type, string>("剩餘", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("Unit", new Tuple<string, Type, string>("單位", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("Btime", new Tuple<string, Type, string>("換補休起時", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("Etime", new Tuple<string, Type, string>("換補休迄時", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("Rate", new Tuple<string, Type, string>("倍率", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("Salary", new Tuple<string, Type, string>("薪資", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("CashOut", new Tuple<string, Type, string>("代金", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("RoteName", new Tuple<string, Type, string>("出勤班別", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("OtRateName", new Tuple<string, Type, string>("加班比率設定", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("Remark", new Tuple<string, Type, string>("備註", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("YYMM", new Tuple<string, Type, string>("計薪年月", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("SEQ", new Tuple<string, Type, string>("期別", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("WarningMsg", new Tuple<string, Type, string>("警告", typeof(string), ""));
            this.DataTransfer.ColumnList.Add("ErrorMsg", new Tuple<string, Type, string>("錯誤註記", typeof(string), ""));
            this.Text = "FRM4PP-產生補休代金";
            SystemFunction.CheckAppConfigRule(btnConfig);
            acg = new JBModule.Data.ApplicationConfigSettings(this.Name, MainForm.COMPANY);
            acg.CheckParameterAndSetDefault("CashOutSalCode", "代金薪資代碼", "", "指定薪資代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            acg.CheckParameterAndSetDefault("CashoutHoliCode", "代金假別代碼", "", "指定補休代金沖假代碼", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1", "String");
            acg.CheckParameterAndSetDefault("LeaveTypeCode", "補休假別種類", "", "指定補休假別種類代碼", "ComboBox", "select HTYPE,HTYPE_DISP +'-'+ TYPE_NAME from HcodeType where dbo.getcodefilter('HcodeType',HTYPE,@userid,@comp,@admin)=1", "String");
            acg.CheckParameterAndSetDefault("DivOfDay", "日薪分母", "30", "日薪分母", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("DivOfHour", "時薪分母", "240", "時薪分母", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("AccumulationBase", "工資計算標準-累計時數", "True", "True:往後累計 False:往前補足", "ComboBox", "select 'True' value , 'True' union select 'False', 'False'", "String");
        }
    }
}
