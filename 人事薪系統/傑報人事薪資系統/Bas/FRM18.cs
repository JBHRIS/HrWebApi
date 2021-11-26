using JBModule.Data.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Bas
{
    public partial class FRM18 : JBControls.JBForm
    {
        public FRM18()
        {
            InitializeComponent();
			fullDataCtrl1.bnAddEnable = false;
			fullDataCtrl1.bnEditEnable = false;
			fullDataCtrl1.bnDelEnable = false;			
        }

        private void FRM18_Load(object sender, EventArgs e)
        {
            this.jOBOTableAdapter.Fill(this.basDS.JOBO);
            this.rOTETTableAdapter.Fill(this.dsAtt.ROTET, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.hOLICDTableAdapter.Fill(this.dsAtt.HOLICD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.outPostTableAdapter.Fill(this.basDS.OutPost, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.giftVoucherTableAdapter.Fill(this.basDS.GiftVoucher, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.bankCodeTableAdapter.Fill(this.basDS.BankCode, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.dEPTTableAdapter.FillByValid(this.basDS.DEPT, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.dEPTSTableAdapter.FillBy(this.basDS.DEPTS, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.dEPTATableAdapter.Fill(this.basDS.DEPTA, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.jOBLTableAdapter.Fill(this.basDS.JOBL, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.jOBSTableAdapter.Fill(this.basDS.JOBS, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.jOBTableAdapter.Fill(this.basDS.JOB, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.bASEALLTableAdapter.FillByInit(this.basDS.BASEALL);
            this.tTSCDTableAdapter.Fill(this.basDS.TTSCD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            Sal.Function.SetAvaliableVBase(this.basDS.V_BASE);
            fullDataCtrl1.DataAdapter = bASEALLTableAdapter;
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd("BASETTS");
			fullDataCtrl1.Init_Ctrls();
        }

		private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
            //BasDataClassesDataContext db = new BasDataClassesDataContext();

            //if (!MainForm.MANGSUPER)
            //{
            //    DataTable dt = (fullDataCtrl1.DataSource.DataSource as DataSet).Tables[fullDataCtrl1.DataSource.DataMember];
            //    foreach (var row in dt.AsEnumerable())
            //    {
            //        var data = (from c in db.V_BASE where c.NOBR.Trim() == row["nobr"].ToString().Trim() && c.SALADR == MainForm.WORKADR select c).FirstOrDefault();
            //        if (data == null)
            //        {
            //            row.Delete();
            //        }
            //    }

            //    dt.AcceptChanges();
            //}

            //if (checkBox1.Checked)
            //{
            //    string dt = DateTime.Now.ToString("yyyy/MM/dd");
            //    bASEALLBindingSource.Filter = "'" + dt + "' >= adate and '" + dt + "' <= ddate";
            //}
            //else bASEALLBindingSource.Filter = "";

            //fullDataCtrl1.Init_Ctrls();
		}

		private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
			DataView dv = ((dataGridViewEx1.DataSource as BindingSource).DataSource as DataSet).Tables[(dataGridViewEx1.DataSource as BindingSource).DataMember].DefaultView;
			dv.RowFilter = (dataGridViewEx1.DataSource as BindingSource).Filter;

			JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
			System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
		}

		private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
            //BasDataClassesDataContext db = new BasDataClassesDataContext();

            //if (!MainForm.MANGSUPER)
            //{
            //    DataTable dt = (fullDataCtrl1.DataSource.DataSource as DataSet).Tables[fullDataCtrl1.DataSource.DataMember];
            //    foreach (var row in dt.AsEnumerable())
            //    {
            //        var data = (from c in db.V_BASE where c.NOBR.Trim() == row["nobr"].ToString().Trim() && c.SALADR == MainForm.WORKADR select c).FirstOrDefault();
            //        if (data == null)
            //        {
            //            row.Delete();
            //        }
            //    }

            //    dt.AcceptChanges();
            //}

            //if (checkBox1.Checked)
            //{
            //    string dt = DateTime.Now.ToString("yyyy/MM/dd");
            //    bASEALLBindingSource.Filter = "'" + dt + "' >= adate and '" + dt + "' <= ddate";
            //}
            //else bASEALLBindingSource.Filter = "";

            //fullDataCtrl1.Init_Ctrls();
		}

        private void buttonSpL_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要產生到職半年特休", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var it in basDS.BASEALL)
                {
                    JBHR.Att.FRM2I.CreateNewHireYearHoloiday(it.NOBR, it.INDT.Year, it.INDT, it.INDT, true);
                }
                MessageBox.Show("產生完畢", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnUserDefineImport_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sqlcomp = db.COMP1.Where(p => p.COMP == MainForm.COMPANY).FirstOrDefault();
            var UsDfMaster = sqlcomp.UserDefineMasterID != null ? db.UserDefineMaster.Where(p => p.UserDefineMasterID.Equals(sqlcomp.UserDefineMasterID)).FirstOrDefault() : null;
            List<UserDefineLayout> UsDfLayoutList = new List<UserDefineLayout>();
            var UsDfGroupList = UsDfMaster != null ? db.UserDefineGroup.Where(p => p.UserDefineMasterID.Equals(UsDfMaster.UserDefineMasterID) && p.FormName == "JBHR.BAS.FRM12") : null;
            if (UsDfGroupList != null && UsDfGroupList.Any())
            {
                foreach (var UsDfGroup in UsDfGroupList)
                {
                    var UsDfLayout = db.UserDefineLayout.Where(p => p.UserDefineGroupID.Equals(UsDfGroup.UserDefineGroupID));
                    if (UsDfLayout.Any())
                        UsDfLayoutList.AddRange(UsDfLayout.ToList());
                }
            }
            if (sqlcomp.UserDefineMasterID == null || UsDfMaster == null || UsDfGroupList == null || UsDfLayoutList.Count == 0)
                MessageBox.Show("並無使用者自定義欄位的設定.");
            else
            {
                JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
                frm.Text = "FRM18-自定欄位匯入";

                frm.ColumnStyle = JBTools.IO.LoadExcelColumnNameStyle.DefinedColumn;
                frm.Allow_Repeat_Delete = false;
                frm.Allow_Repeat_Ignore = false;
                frm.Allow_Repeat_Override = true;
                frm.TemplateButtonVisible = true;

                frm.Allow_MatchField = false;
                frm.AutoMatchMode = true;

                frm.FieldForm = new FRM18_UserDF_Import();
                ImportUserDefineData IUDFD = new ImportUserDefineData();

                //IUDFD.UDFG = UDFG;
                IUDFD.UDFL = UsDfLayoutList.ToList();
                //frm.DataTransfer = IUDFD;

                IUDFD.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
                IUDFD.CheckData.Add("員工編號", this.basDS.V_BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());

                var comboboxList = UsDfLayoutList.Where(p => p.Type.ToUpper() == "COMBOBOX");
                foreach (var combobox in comboboxList)
                {
                    Dictionary<string, string> TagList = new Dictionary<string, string>();
                    if (!string.IsNullOrEmpty(combobox.Tag))
                        TagList = JsonConvert.DeserializeObject<Dictionary<string, string>>(combobox.Tag);//反序列化

                    //取得combobox需對應的匯入名稱
                    string column = string.Empty;
                    if (TagList.ContainsKey("BindingID"))
                    {
                        var Label = db.UserDefineLayout.Where(p => p.ControlID.Equals(Guid.Parse(TagList["BindingID"]))).FirstOrDefault();
                        column = Label != null ? CodeFunction.GetUDFControlTagPropByID(Label.ControlID, "Text") : string.Empty;
                    }
                    UserDefineSource UDFS = new UserDefineSource();
                    if (TagList.ContainsKey("SourceID"))
                        UDFS = db.UserDefineSource.Where(p => p.SourceID.Equals(Guid.Parse(TagList["SourceID"]))).FirstOrDefault();

                    //檢核資料鏈結
                    if (!string.IsNullOrEmpty(column) && UDFS != null)
                        IUDFD.CheckData.Add(column, CodeFunction.GetUDFSourcebySourceScript(UDFS.SourceScript, UDFS.ValueMember, UDFS.DisplayMember).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[0] }).ToList());
                }

                IUDFD.ColumnList = new Dictionary<string, Type>();
                IUDFD.UnMustColumnList = new List<string>();
                IUDFD.ColumnList.Add("員工編號", typeof(string));

                var inputList = UsDfLayoutList.Where(p => p.Type.ToUpper() != "LABEL");
                foreach (var input in inputList)
                {
                    string Label = CodeFunction.GetUDFControlTagPropByID(input.ControlID, "BindingID");
                    string column = Label != string.Empty ? CodeFunction.GetUDFControlTagPropByID(Guid.Parse(Label), "Text") : string.Empty;
                    if (!string.IsNullOrEmpty(column))
                    {
                        IUDFD.ColumnList.Add(column, CodeFunction.GetUDFDataTypeByControlType(input.Type));
                        IUDFD.UnMustColumnList.Add(column);
                        IUDFD.ColumnForControlID.Add(column, input.ControlID);
                    }
                }

                //IUDFD.ColumnList.Add("備註欄", typeof(string));
                IUDFD.ColumnList.Add("警告注记", typeof(string));
                IUDFD.ColumnList.Add("错误注记", typeof(string));

                frm.DataTransfer = IUDFD;
                frm.ShowDialog();
            }
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            string FileName = "FRM18_Template.xls";
            string sourcePath = Application.StartupPath + @"\Bas\Excel";
            string targetPath = @"C:\TEMP\";

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, FileName);
            string destFile = System.IO.Path.Combine(targetPath, FileName);

            // To copy a folder's contents to a new location:
            // Create a new target folder. 
            // If the directory already exists, this method does not create a new directory.
            System.IO.Directory.CreateDirectory(targetPath);

            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);

            System.Diagnostics.Process.Start("C:\\TEMP\\" + FileName);
        }

        private void bnIMPORT_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.ColumnStyle = JBTools.IO.LoadExcelColumnNameStyle.DefinedColumn;
            frm.Allow_Repeat_Delete = false;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = false;
            frm.Default_Repeat_Option = JBControls.U_IMPORT.Allow_Repeat_Ignore_String;
            frm.Allow_MatchField = false;
            frm.AutoMatchMode = true;

            ImportFRM18Data importFRM18Data = new ImportFRM18Data();

            #region 必填欄位設定
            importFRM18Data.MustColumns.Add("員工編號");
            importFRM18Data.MustColumns.Add("中文姓名");
            importFRM18Data.MustColumns.Add("異動狀態");
            importFRM18Data.MustColumns.Add("異動日期");
            importFRM18Data.MustColumns.Add("性別");
            importFRM18Data.MustColumns.Add("出生日期");
            importFRM18Data.MustColumns.Add("密碼");
            importFRM18Data.MustColumns.Add("集團到職日");
            importFRM18Data.MustColumns.Add("公司別");
            importFRM18Data.MustColumns.Add("編制部門代碼");
            importFRM18Data.MustColumns.Add("成本部門代碼");
            importFRM18Data.MustColumns.Add("簽核部門代碼");
            importFRM18Data.MustColumns.Add("職稱代碼");
            importFRM18Data.MustColumns.Add("行事曆");
            importFRM18Data.MustColumns.Add("異動原因");
            importFRM18Data.MustColumns.Add("職類代碼");
            importFRM18Data.MustColumns.Add("職等代碼");
            importFRM18Data.MustColumns.Add("職級代碼");
            importFRM18Data.MustColumns.Add("直間接");
            importFRM18Data.MustColumns.Add("員別");
            importFRM18Data.MustColumns.Add("輪班別");
            importFRM18Data.MustColumns.Add("工作地");
            importFRM18Data.MustColumns.Add("刷卡");
            importFRM18Data.MustColumns.Add("薪別");
            importFRM18Data.MustColumns.Add("加班比率");
            importFRM18Data.MustColumns.Add("資料群組");
            importFRM18Data.MustColumns.Add("退休金制度");
            #endregion

            frm.FieldForm = new JBControls.U_FIELD();
            frm.DataTransfer = importFRM18Data;//new ImportFRM18Data();

            //frm.TemplateButtonVisible = true;
            frm.SortString = "員工編號 ASC,異動日期 ASC";

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();

            frm.DataTransfer.CheckData.Add("錄取管道", CodeFunction.GetCandidates_ways(false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("性別", CodeFunction.GetMtCode("SEX", false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("血型", CodeFunction.GetMtCode("BLOOD", false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("婚姻", CodeFunction.GetMtCode("MARRY", false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("出生地", CodeFunction.GetProvcd(false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("兵役", CodeFunction.GetMtCode("ARMY", false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("殘障類別", CodeFunction.GetDisabilityType(false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("殘障身份", CodeFunction.GetDisabilityRank(false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("國籍", CodeFunction.GetCountcd(false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("身份別", CodeFunction.GetBasecd(false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("聯絡人1關係", CodeFunction.GetRelcode(false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("聯絡人2關係", CodeFunction.GetRelcode(false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("異動狀態", CodeFunction.GetMtCode("TTSCODE", false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            var UserCompsql = from a in MainForm.UserCompList
                              join b in db.COMP on a.COMPANY equals b.COMP1
                              select new { COMPID = b.COMP1, COMPNAME = b.COMPNAME };
            frm.DataTransfer.CheckData.Add("公司別", UserCompsql.ToList().Select(p => new JBControls.CheckImportData { DisplayCode = p.COMPID, RealCode = p.COMPID, DisplayName = p.COMPNAME }).ToList());
            frm.DataTransfer.CheckData.Add("編制部門代碼", this.basDS.DEPT.Select(p => new JBControls.CheckImportData { DisplayCode = p.D_NO_DISP, RealCode = p.D_NO, DisplayName = p.D_NAME ,CheckValue1 = p.D_NO }).ToList());
            frm.DataTransfer.CheckData.Add("成本部門代碼", this.basDS.DEPTS.Select(p => new JBControls.CheckImportData { DisplayCode = p.D_NO_DISP, RealCode = p.D_NO, DisplayName = p.D_NAME, CheckValue1 = p.D_NO }).ToList());
            frm.DataTransfer.CheckData.Add("簽核部門代碼", this.basDS.DEPTA.Select(p => new JBControls.CheckImportData { DisplayCode = p.D_NO_DISP, RealCode = p.D_NO, DisplayName = p.D_NAME, CheckValue1 = p.D_NO }).ToList());
            frm.DataTransfer.CheckData.Add("直間接", CodeFunction.GetMtCode("DI", false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("異動原因", this.basDS.TTSCD.Select(p => new JBControls.CheckImportData { DisplayCode = p.TTSCD_DISP, RealCode = p.TTSCD, DisplayName = p.TTSNAME }).ToList());
            frm.DataTransfer.CheckData.Add("薪別", CodeFunction.GetSaltycd(false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("加班比率", CodeFunction.GetOtRatecd(false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("資料群組", CodeFunction.GetDatagroup(false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("職稱代碼", this.basDS.JOB.Select(p => new JBControls.CheckImportData { DisplayCode = p.JOB_DISP, RealCode = p.JOB, DisplayName = p.JOB_NAME, CheckValue1 = p.JOB }).ToList());
            frm.DataTransfer.CheckData.Add("職類代碼", this.basDS.JOBS.Select(p => new JBControls.CheckImportData { DisplayCode = p.JOBS_DISP, RealCode = p.JOBS, DisplayName = p.JOB_NAME, CheckValue1 = p.JOBS }).ToList());
            frm.DataTransfer.CheckData.Add("職等代碼", this.basDS.JOBL.Select(p => new JBControls.CheckImportData { DisplayCode = p.JOBL_DISP, RealCode = p.JOBL, DisplayName = p.JOB_NAME, CheckValue1 = p.JOBL }).ToList());
            frm.DataTransfer.CheckData.Add("職級代碼", this.basDS.JOBO.Select(p => new JBControls.CheckImportData { DisplayCode = p.JOBO, RealCode = p.JOBO, DisplayName = p.JOB_NAME, CheckValue1 = p.JOBO }).ToList());
            frm.DataTransfer.CheckData.Add("員別", CodeFunction.GetEmpcd(false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("輪班別", this.dsAtt.ROTET.Select(p => new JBControls.CheckImportData { DisplayCode = p.ROTET_DISP, RealCode = p.ROTET, DisplayName = p.ROTETNAME, CheckValue1 = p.ROTET }).ToList());
            frm.DataTransfer.CheckData.Add("行事曆", this.dsAtt.HOLICD.Select(p => new JBControls.CheckImportData { DisplayCode = p.HOLI_CODE_DISP, RealCode = p.HOLI_CODE, DisplayName = p.HOLI_NAME, CheckValue1 = p.HOLI_CODE }).ToList());
            frm.DataTransfer.CheckData.Add("工作地", CodeFunction.GetWorkcd(false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("轉帳銀行", this.basDS.BankCode.Select(p => new JBControls.CheckImportData { DisplayCode = p.CODE_DISP, RealCode = p.Code, DisplayName = p.BankName }).ToList());
            frm.DataTransfer.CheckData.Add("外勞銀行", this.basDS.BankCode.Select(p => new JBControls.CheckImportData { DisplayCode = p.CODE_DISP, RealCode = p.Code, DisplayName = p.BankName }).ToList());
            frm.DataTransfer.CheckData.Add("隸屬獎金", CodeFunction.GetBonusGroup(false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("ERP", CodeFunction.GetERPCODE(false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("離職原因", CodeFunction.GetOutcd(false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("退休金制度", CodeFunction.GetMtCode("RETCHOO", false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("刷卡", new string[] { "Y", "N" }.Select(p => new JBControls.CheckImportData { DisplayCode = p, RealCode = p, DisplayName = p }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();

            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("中文姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("英文姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("外籍員工", typeof(bool));
            frm.DataTransfer.ColumnList.Add("異動狀態", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動日期", typeof(DateTime));

            frm.DataTransfer.ColumnList.Add("錄取管道", typeof(string));
            frm.DataTransfer.ColumnList.Add("身份證號", typeof(string));
            frm.DataTransfer.ColumnList.Add("出生日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("增補單號", typeof(string));
            frm.DataTransfer.ColumnList.Add("性別", typeof(string));
            frm.DataTransfer.ColumnList.Add("血型", typeof(string));
            frm.DataTransfer.ColumnList.Add("婚姻", typeof(string));
            frm.DataTransfer.ColumnList.Add("介紹人", typeof(string));
            frm.DataTransfer.ColumnList.Add("出生地", typeof(string));
            frm.DataTransfer.ColumnList.Add("兵役", typeof(string));
            frm.DataTransfer.ColumnList.Add("護照姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("護照號碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("居留證號", typeof(string));
            frm.DataTransfer.ColumnList.Add("殘障類別", typeof(string));
            frm.DataTransfer.ColumnList.Add("殘障身份", typeof(string));
            frm.DataTransfer.ColumnList.Add("國籍", typeof(string));
            frm.DataTransfer.ColumnList.Add("分機", typeof(string));
            frm.DataTransfer.ColumnList.Add("身份別", typeof(string));
            frm.DataTransfer.ColumnList.Add("行動電話", typeof(string));
            frm.DataTransfer.ColumnList.Add("電子郵件", typeof(string));
            frm.DataTransfer.ColumnList.Add("密碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("AD帳號", typeof(string));
            frm.DataTransfer.ColumnList.Add("通訊電話", typeof(string));
            frm.DataTransfer.ColumnList.Add("通訊郵遞區號", typeof(string));
            frm.DataTransfer.ColumnList.Add("通訊地址", typeof(string));
            frm.DataTransfer.ColumnList.Add("戶籍電話", typeof(string));
            frm.DataTransfer.ColumnList.Add("戶籍郵遞區號", typeof(string));
            frm.DataTransfer.ColumnList.Add("戶籍地址", typeof(string));
            frm.DataTransfer.ColumnList.Add("集團到職日", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("試用期滿日", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("公司別", typeof(string));
            frm.DataTransfer.ColumnList.Add("編制部門代碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("編制部門名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("成本部門代碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("成本部門名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("簽核部門代碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("簽核部門名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("職稱代碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("職稱名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("行事曆", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動原因", typeof(string));
            frm.DataTransfer.ColumnList.Add("職類代碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("職類名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("職等代碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("職等名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("職級代碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("職級名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("直間接", typeof(string));
            frm.DataTransfer.ColumnList.Add("員別", typeof(string));
            frm.DataTransfer.ColumnList.Add("輪班別", typeof(string));
            frm.DataTransfer.ColumnList.Add("外部年資", typeof(string));
            frm.DataTransfer.ColumnList.Add("居留證起始日", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("居留證到期日", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("預計復職日", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("工作地", typeof(string));
            frm.DataTransfer.ColumnList.Add("隸屬獎金", typeof(string));
            frm.DataTransfer.ColumnList.Add("ERP", typeof(string));
            frm.DataTransfer.ColumnList.Add("離職原因", typeof(string));
            frm.DataTransfer.ColumnList.Add("刷卡", typeof(string));
            frm.DataTransfer.ColumnList.Add("薪別", typeof(string));
            frm.DataTransfer.ColumnList.Add("加班比率", typeof(string));
            frm.DataTransfer.ColumnList.Add("資料群組", typeof(string));
            frm.DataTransfer.ColumnList.Add("退休金制度", typeof(string));
            frm.DataTransfer.ColumnList.Add("加入新制日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("開始提撥日", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("員工提撥比率", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("所得稅預扣金額", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("考試日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("轉帳銀行", typeof(string));
            frm.DataTransfer.ColumnList.Add("轉帳帳號", typeof(string));
            frm.DataTransfer.ColumnList.Add("外勞銀行", typeof(string));
            frm.DataTransfer.ColumnList.Add("外勞帳號", typeof(string));
            frm.DataTransfer.ColumnList.Add("扶養人數", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("備註", typeof(string));
            frm.DataTransfer.ColumnList.Add("聯絡人1姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("聯絡人1關係", typeof(string));
            frm.DataTransfer.ColumnList.Add("聯絡人1電話", typeof(string));
            frm.DataTransfer.ColumnList.Add("聯絡人1行動電話", typeof(string));
            frm.DataTransfer.ColumnList.Add("聯絡人2姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("聯絡人2關係", typeof(string));
            frm.DataTransfer.ColumnList.Add("聯絡人2電話", typeof(string));
            frm.DataTransfer.ColumnList.Add("聯絡人2行動電話", typeof(string));
            frm.DataTransfer.ColumnList.Add("保證人1姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("保證人1身份證號", typeof(string));
            frm.DataTransfer.ColumnList.Add("保證人1電話", typeof(string));
            frm.DataTransfer.ColumnList.Add("保證人1住址", typeof(string));
            frm.DataTransfer.ColumnList.Add("保證人2姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("保證人2身份證號", typeof(string));
            frm.DataTransfer.ColumnList.Add("保證人2電話", typeof(string));
            frm.DataTransfer.ColumnList.Add("保證人2住址", typeof(string));

            frm.DataTransfer.ColumnList.Add("部門主管", typeof(bool));
            frm.DataTransfer.ColumnList.Add("不計算請假", typeof(bool));
            frm.DataTransfer.ColumnList.Add("不計算全勤", typeof(bool));
            frm.DataTransfer.ColumnList.Add("不判斷遲到早退", typeof(bool));
            frm.DataTransfer.ColumnList.Add("不計算福利金", typeof(bool));
            frm.DataTransfer.ColumnList.Add("不計算退休金(新制)", typeof(bool));
            frm.DataTransfer.ColumnList.Add("可取得認股權證", typeof(bool));
            frm.DataTransfer.ColumnList.Add("不產生加班", typeof(bool));
            frm.DataTransfer.ColumnList.Add("不計算特休代金", typeof(bool));
            frm.DataTransfer.ColumnList.Add("不計算所得稅", typeof(bool));
            frm.DataTransfer.ColumnList.Add("不代扣伙食費", typeof(bool));
            frm.DataTransfer.ColumnList.Add("不發薪", typeof(bool));
            frm.DataTransfer.ColumnList.Add("可知網頁人事資料", typeof(bool));
            frm.DataTransfer.ColumnList.Add("只刷上班卡", typeof(bool));
            frm.DataTransfer.ColumnList.Add("可線上刷卡", typeof(bool));
            frm.DataTransfer.ColumnList.Add("可代申請表單", typeof(bool));
            frm.DataTransfer.ColumnList.Add("不計算三節獎金", typeof(bool));
            frm.DataTransfer.ColumnList.Add("所得稅固定稅率扣繳", typeof(bool));
            frm.DataTransfer.ColumnList.Add("自願離職", typeof(bool));
            frm.DataTransfer.ColumnList.Add("不計算退休金(舊制)", typeof(bool));

            //frm.DataTransfer.ColumnList.Add("備注", typeof(string));
            frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            #region 因要使用自訂檢核須將所有欄位改為非必須
            frm.DataTransfer.UnMustColumnList.Add("員工編號");
            frm.DataTransfer.UnMustColumnList.Add("中文姓名");
            frm.DataTransfer.UnMustColumnList.Add("英文姓名");
            frm.DataTransfer.UnMustColumnList.Add("外籍員工");
            frm.DataTransfer.UnMustColumnList.Add("異動狀態");
            frm.DataTransfer.UnMustColumnList.Add("異動日期");
            frm.DataTransfer.UnMustColumnList.Add("錄取管道");
            frm.DataTransfer.UnMustColumnList.Add("身份證號");
            frm.DataTransfer.UnMustColumnList.Add("出生日期");
            frm.DataTransfer.UnMustColumnList.Add("增補單號");
            frm.DataTransfer.UnMustColumnList.Add("性別");
            frm.DataTransfer.UnMustColumnList.Add("血型");
            frm.DataTransfer.UnMustColumnList.Add("婚姻");
            frm.DataTransfer.UnMustColumnList.Add("介紹人");
            frm.DataTransfer.UnMustColumnList.Add("出生地");
            frm.DataTransfer.UnMustColumnList.Add("兵役");
            frm.DataTransfer.UnMustColumnList.Add("護照姓名");
            frm.DataTransfer.UnMustColumnList.Add("護照號碼");
            frm.DataTransfer.UnMustColumnList.Add("居留證號");
            frm.DataTransfer.UnMustColumnList.Add("殘障類別");
            frm.DataTransfer.UnMustColumnList.Add("殘障身份");
            frm.DataTransfer.UnMustColumnList.Add("國籍");
            frm.DataTransfer.UnMustColumnList.Add("分機");
            frm.DataTransfer.UnMustColumnList.Add("身份別");
            frm.DataTransfer.UnMustColumnList.Add("行動電話");
            frm.DataTransfer.UnMustColumnList.Add("電子郵件");
            frm.DataTransfer.UnMustColumnList.Add("密碼");
            frm.DataTransfer.UnMustColumnList.Add("AD帳號");
            frm.DataTransfer.UnMustColumnList.Add("通訊電話");
            frm.DataTransfer.UnMustColumnList.Add("通訊郵遞區號");
            frm.DataTransfer.UnMustColumnList.Add("通訊地址");
            frm.DataTransfer.UnMustColumnList.Add("戶籍電話");
            frm.DataTransfer.UnMustColumnList.Add("戶籍郵遞區號");
            frm.DataTransfer.UnMustColumnList.Add("戶籍地址");
            frm.DataTransfer.UnMustColumnList.Add("集團到職日");
            frm.DataTransfer.UnMustColumnList.Add("試用期滿日");
            frm.DataTransfer.UnMustColumnList.Add("公司別");
            frm.DataTransfer.UnMustColumnList.Add("編制部門代碼");
            frm.DataTransfer.UnMustColumnList.Add("編制部門名稱");
            frm.DataTransfer.UnMustColumnList.Add("成本部門代碼");
            frm.DataTransfer.UnMustColumnList.Add("成本部門名稱");
            frm.DataTransfer.UnMustColumnList.Add("簽核部門代碼");
            frm.DataTransfer.UnMustColumnList.Add("簽核部門名稱");
            frm.DataTransfer.UnMustColumnList.Add("職稱代碼");
            frm.DataTransfer.UnMustColumnList.Add("職稱名稱");
            frm.DataTransfer.UnMustColumnList.Add("行事曆");
            frm.DataTransfer.UnMustColumnList.Add("異動原因");
            frm.DataTransfer.UnMustColumnList.Add("職類代碼");
            frm.DataTransfer.UnMustColumnList.Add("職類名稱");
            frm.DataTransfer.UnMustColumnList.Add("職等代碼");
            frm.DataTransfer.UnMustColumnList.Add("職等名稱");
            frm.DataTransfer.UnMustColumnList.Add("職級代碼");
            frm.DataTransfer.UnMustColumnList.Add("職級名稱");
            frm.DataTransfer.UnMustColumnList.Add("直間接");
            frm.DataTransfer.UnMustColumnList.Add("員別");
            frm.DataTransfer.UnMustColumnList.Add("輪班別");
            frm.DataTransfer.UnMustColumnList.Add("外部年資");
            frm.DataTransfer.UnMustColumnList.Add("居留證起始日");
            frm.DataTransfer.UnMustColumnList.Add("居留證到期日");
            frm.DataTransfer.UnMustColumnList.Add("預計復職日");
            frm.DataTransfer.UnMustColumnList.Add("工作地");
            frm.DataTransfer.UnMustColumnList.Add("隸屬獎金");
            frm.DataTransfer.UnMustColumnList.Add("ERP");
            frm.DataTransfer.UnMustColumnList.Add("離職原因");
            frm.DataTransfer.UnMustColumnList.Add("刷卡");
            frm.DataTransfer.UnMustColumnList.Add("薪別");
            frm.DataTransfer.UnMustColumnList.Add("加班比率");
            frm.DataTransfer.UnMustColumnList.Add("資料群組");
            frm.DataTransfer.UnMustColumnList.Add("退休金制度");
            frm.DataTransfer.UnMustColumnList.Add("加入新制日期");
            frm.DataTransfer.UnMustColumnList.Add("開始提撥日");
            frm.DataTransfer.UnMustColumnList.Add("員工提撥比率");
            frm.DataTransfer.UnMustColumnList.Add("所得稅預扣金額");
            frm.DataTransfer.UnMustColumnList.Add("考試日期");
            frm.DataTransfer.UnMustColumnList.Add("轉帳銀行");
            frm.DataTransfer.UnMustColumnList.Add("轉帳帳號");
            frm.DataTransfer.UnMustColumnList.Add("外勞銀行");
            frm.DataTransfer.UnMustColumnList.Add("外勞帳號");
            frm.DataTransfer.UnMustColumnList.Add("扶養人數");
            frm.DataTransfer.UnMustColumnList.Add("備註");
            frm.DataTransfer.UnMustColumnList.Add("聯絡人1姓名");
            frm.DataTransfer.UnMustColumnList.Add("聯絡人1關係");
            frm.DataTransfer.UnMustColumnList.Add("聯絡人1電話");
            frm.DataTransfer.UnMustColumnList.Add("聯絡人1行動電話");
            frm.DataTransfer.UnMustColumnList.Add("聯絡人2姓名");
            frm.DataTransfer.UnMustColumnList.Add("聯絡人2關係");
            frm.DataTransfer.UnMustColumnList.Add("聯絡人2電話");
            frm.DataTransfer.UnMustColumnList.Add("聯絡人2行動電話");
            frm.DataTransfer.UnMustColumnList.Add("保證人1姓名");
            frm.DataTransfer.UnMustColumnList.Add("保證人1身份證號");
            frm.DataTransfer.UnMustColumnList.Add("保證人1電話");
            frm.DataTransfer.UnMustColumnList.Add("保證人1住址");
            frm.DataTransfer.UnMustColumnList.Add("保證人2姓名");
            frm.DataTransfer.UnMustColumnList.Add("保證人2身份證號");
            frm.DataTransfer.UnMustColumnList.Add("保證人2電話");
            frm.DataTransfer.UnMustColumnList.Add("保證人2住址");

            frm.DataTransfer.UnMustColumnList.Add("部門主管");
            frm.DataTransfer.UnMustColumnList.Add("不計算請假");
            frm.DataTransfer.UnMustColumnList.Add("不計算全勤");
            frm.DataTransfer.UnMustColumnList.Add("不判斷遲到早退");
            frm.DataTransfer.UnMustColumnList.Add("不計算福利金");
            frm.DataTransfer.UnMustColumnList.Add("不計算退休金(新制)");
            frm.DataTransfer.UnMustColumnList.Add("可取得認股權證");
            frm.DataTransfer.UnMustColumnList.Add("不產生加班");
            frm.DataTransfer.UnMustColumnList.Add("不計算特休代金");
            frm.DataTransfer.UnMustColumnList.Add("不計算所得稅");
            frm.DataTransfer.UnMustColumnList.Add("不代扣伙食費");
            frm.DataTransfer.UnMustColumnList.Add("不發薪");
            frm.DataTransfer.UnMustColumnList.Add("可知網頁人事資料");
            frm.DataTransfer.UnMustColumnList.Add("只刷上班卡");
            frm.DataTransfer.UnMustColumnList.Add("可線上刷卡");
            frm.DataTransfer.UnMustColumnList.Add("可代申請表單");
            frm.DataTransfer.UnMustColumnList.Add("不計算三節獎金");
            frm.DataTransfer.UnMustColumnList.Add("所得稅固定稅率扣繳");
            frm.DataTransfer.UnMustColumnList.Add("自願離職");
            frm.DataTransfer.UnMustColumnList.Add("不計算退休金(舊制)");
            #endregion

            frm.ShowDialog();
        }
    }
}
