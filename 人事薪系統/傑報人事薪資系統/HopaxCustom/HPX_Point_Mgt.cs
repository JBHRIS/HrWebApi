using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.HopaxCustom
{
    public partial class HPX_Point_Mgt : JBControls.JBForm
    {
        public HPX_Point_Mgt()
        {
            InitializeComponent();
        }
        HPX_WebService.ServiceClient client = new HPX_WebService.ServiceClient();
        JBModule.Data.ApplicationConfigSettings acg = new JBModule.Data.ApplicationConfigSettings("HPX_Point_Mgt", MainForm.COMPANY);
        private void HPX_Point_Mgt_Load(object sender, EventArgs e)
        {
            SystemFunction.CheckAppConfigRule(btnConfig);
            acg.CheckParameterAndSetDefault("WebService_Address", "WebService位置", @"http://localhost:64401/Service.svc", "指定服務位置", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("CheckNobr", "檢核姓名與工號", "True", "檢核姓名是否與工號姓名相符", "ComboBox", "select 'True' value , 'True' union select 'False', 'False'", "String");
            client.Endpoint.Address = new System.ServiceModel.EndpointAddress(acg.GetConfig("WebService_Address").Value);
        }

        private void jbHPX_Point_Mgt_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            HPX_Point_Mgt_ADD frm = new HPX_Point_Mgt_ADD();
            frm.client = client;
            frm.Text = "HPX_Point_Mgt-新增";
            frm.ShowDialog();
        }

        private void jbHPX_Point_Mgt_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            if (jbHPX_Point_Mgt.SelectedKey != null)
            {
                HPX_Point_Mgt_ADD frm = new HPX_Point_Mgt_ADD();
                frm.client = client;
                frm.sno = Convert.ToInt32(jbHPX_Point_Mgt.SelectedKey.ToString());
                frm.Text = "HPX_Point_Mgt-修改";
                frm.ShowDialog();
            }
        }

        private void jbHPX_Point_Mgt_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            client.DeleteHPXPoint(Convert.ToInt32(e.PrimaryKey));
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            //frm.Allow_Repeat_Delete = true;
            //frm.Allow_Repeat_Ignore = true;
            //frm.Allow_Repeat_Override = true;
            frm.TemplateButtonVisible = true;

            frm.Text = "公益點數批次匯入";
            frm.FieldForm = new HPX_Point_MGT_IN();
            HPXPointMGTImport hPXPointMGTImport = new HPXPointMGTImport();
            hPXPointMGTImport.client = client;
            frm.DataTransfer = hPXPointMGTImport;

            Dictionary<string, string> YesNo = new Dictionary<string, string>();
            YesNo.Add("Y","是");
            YesNo.Add("N","否");
            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("工號", db.BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.CheckData.Add("團主否", YesNo.Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("本人參加否", YesNo.Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("活動名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("工號", typeof(string));
            frm.DataTransfer.ColumnList.Add("團主否", typeof(string));
            frm.DataTransfer.ColumnList.Add("本人參加否", typeof(string));
            frm.DataTransfer.ColumnList.Add("備註", typeof(string));
            frm.DataTransfer.ColumnList.Add("承辦人", typeof(string));
            frm.DataTransfer.ColumnList.Add("親友人數", typeof(int));
            frm.DataTransfer.ColumnList.Add("獲得點數", typeof(int));
            frm.DataTransfer.ColumnList.Add("使用點數", typeof(int));
            frm.DataTransfer.ColumnList.Add("使用時間", typeof(DateTime));
            //frm.DataTransfer.ColumnList.Add("剩餘點數", typeof(int?));
            frm.DataTransfer.ColumnList.Add("創建人員", typeof(string));
            frm.DataTransfer.ColumnList.Add("創建日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("最後修改者", typeof(string));
            frm.DataTransfer.ColumnList.Add("最後修改日", typeof(DateTime));

            frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("工號");
            frm.DataTransfer.UnMustColumnList.Add("團主否");
            frm.DataTransfer.UnMustColumnList.Add("本人參加否");
            frm.DataTransfer.UnMustColumnList.Add("備註");
            frm.DataTransfer.UnMustColumnList.Add("承辦人");
            frm.DataTransfer.UnMustColumnList.Add("親友人數");
            frm.DataTransfer.UnMustColumnList.Add("獲得點數");
            frm.DataTransfer.UnMustColumnList.Add("使用點數");
            frm.DataTransfer.UnMustColumnList.Add("使用時間");
            frm.DataTransfer.UnMustColumnList.Add("創建人員");
            frm.DataTransfer.UnMustColumnList.Add("創建日期");
            frm.DataTransfer.UnMustColumnList.Add("最後修改者");
            frm.DataTransfer.UnMustColumnList.Add("最後修改日");

            frm.ShowDialog();
        }
    }
}
