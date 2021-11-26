using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.Linq;

namespace JBHR.Bas
{
    public partial class BASETTSI1 : JBControls.U_FIELD
    {
        public BASETTSI1()
        {
            InitializeComponent();
            BindingControls.Add(cbxAdate);
            BindingControls.Add(cbNobr);
            BindingControls.Add(cbxTtscode);
            BindingControls.Add(cbxField1);
            BindingControls.Add(cbxField2);
            BindingControls.Add(cbxField3);
            BindingControls.Add(cbxField4);
            BindingControls.Add(cbxField5);
            BindingControls.Add(cbxField6);
            BindingControls.Add(cbxTts1);
            BindingControls.Add(cbxTts2);
            BindingControls.Add(cbxTts3);
            BindingControls.Add(cbxTts4);
            BindingControls.Add(cbxTts5);
            BindingControls.Add(cbxTts6);
            //SystemFunction.SetComboBoxItems(cbxTtscode, CodeFunction.GetMtCode("TTSCODE"));
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            CombinationData = new DataTable();
            foreach (var it in BindingControls)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = it.Tag.ToString();
                CombinationData.Columns.Add(dc);
            }

            foreach (DataRow r in Source.Rows)
            {
                DataRow ri = CombinationData.NewRow();
                SetBindingData(ri, r);
                CombinationData.Rows.Add(ri);
            }
            this.Close();
        }

        private void BASETTSI_Load(object sender, EventArgs e)
        {
            var TtsFieldList = CheckData["異動欄位"];
            var TtsFieldData = TtsFieldList.ToDictionary(p => p.DisplayName, p => p.DisplayName);
            SystemFunction.SetComboBoxItems(cbxTts1, TtsFieldData, true);
            SystemFunction.SetComboBoxItems(cbxTts2, TtsFieldData, true);
            SystemFunction.SetComboBoxItems(cbxTts3, TtsFieldData, true);
            SystemFunction.SetComboBoxItems(cbxTts4, TtsFieldData, true);
            SystemFunction.SetComboBoxItems(cbxTts5, TtsFieldData, true);
            SystemFunction.SetComboBoxItems(cbxTts6, TtsFieldData, true);
            var TtscodeList = CheckData["異動代碼"];
            var TtscodedData = TtscodeList.ToDictionary(p => p.DisplayName, p => p.DisplayName);
            SystemFunction.SetComboBoxItems(cbxTtscode, TtscodedData, false);
            LoadColumnSettings();
        }
    }
    public class ImportTransferToBasetts : JBControls.ImportTransfer
    {

        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            string Msg = "";
            string EmployeeID = SourceRow["員工編號"].ToString();
            DateTime Adate = Convert.ToDateTime(SourceRow["異動日期"]);
            var rCurrent = GetBasettsRow(EmployeeID, Adate);
            if (!rCurrent.Any())
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] += "找不到可異動的資料;";
                    return false;
                }
            }
            if (ColumnValidate(TargetRow, "員工編號", TransferCheckDataField.DisplayName, out Msg))
            {
                TargetRow["員工姓名"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }
            if (ColumnValidate(SourceRow, "異動代碼", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["異動狀態"] = SourceRow["異動代碼"];
                if (!CheckTtscode(rCurrent[0]["TTSCODE"].ToString(), Msg))
                {
                    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                    {
                        TargetRow["錯誤註記"] = "異動違規(" + rCurrent[0]["TTSCODE"].ToString() + "," + Msg + ")";
                        return false;
                    }
                }
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }
            var basetts = GetBasettsRow(TargetRow["員工編號"].ToString(), Convert.ToDateTime(TargetRow["異動日期"]));
            if (basetts.Count() == 0)
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] += "無異動資料可異動";
                }
            }
            for (int i = 1; i < 7; i++)
            {
                if (TargetRow["異動後資料" + i.ToString()] != null && TargetRow["異動欄位" + i.ToString()] != null && TargetRow["異動後資料" + i.ToString()].ToString().Trim().Length > 0 && TargetRow["異動欄位" + i.ToString()].ToString().Trim().Length > 0)
                {
                    if (CheckData.ContainsKey(TargetRow["異動欄位" + i.ToString()].ToString()) && !ColumnValidate(TargetRow["異動後資料" + i.ToString()].ToString(), TargetRow["異動欄位" + i.ToString()].ToString(), TransferCheckDataField.DisplayName, out Msg))
                    {
                        if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                        {
                            TargetRow["錯誤註記"] += Msg + ";";
                        }
                    }


                    if (basetts.Count() > 1)//當前不只一筆有效異動
                    {
                        if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                        {
                            TargetRow["錯誤註記"] += "異動資料異常，有重疊的異動區間;";
                        }
                    }
                    else if (basetts.Count() > 0)//只有一筆
                    {
                        var rBasetts = basetts[0];
                        var Field = TargetRow["異動欄位" + i.ToString()].ToString();//取得對應欄位名稱
                        var ttsFieldList = CheckData["異動欄位"];//取出異動欄位清單
                        var TableColumn = ttsFieldList.Single(pp => pp.DisplayName == Field);//取得對應的資料表欄位名稱
                        var ColumnValue = rBasetts[TableColumn.RealCode].ToString();//目前的值(DB=>RealCode)
                        var DisplayValue = ColumnValue;
                        if (CheckData.ContainsKey(Field))//若有設定，置換顯示(避免顯示RealCode的Guid)
                        {
                            var chkData = CheckData[Field];
                            var chk = chkData.Where(p => p.RealCode == ColumnValue);
                            if (chk.Any())
                                DisplayValue = chk.First().DisplayCode;
                        }
                        TargetRow["異動前資料" + i.ToString()] = DisplayValue;
                    }


                }

            }
            return true;
        }
        bool CheckTtscode(string Current, string Tts)
        {
            var ttsData = new List<string>();
            ttsData.Add("0");
            ttsData.Add("1");
            ttsData.Add("2");
            ttsData.Add("3");
            ttsData.Add("4");
            ttsData.Add("5");
            ttsData.Add("6");
            switch (Current)
            {
                case "0":
                    ttsData.Remove("0");
                    //ttsData.Remove("1");
                    ttsData.Remove("2");
                    ttsData.Remove("3");
                    ttsData.Remove("4");
                    ttsData.Remove("5");
                    ttsData.Remove("6");
                    //SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true);
                    break;
                case "1":
                    //TTSCODEBindingSource.Filter = "code in (2,3,6)";
                    ttsData.Remove("0");
                    ttsData.Remove("1");
                    //ttsData.Remove("2");
                    //ttsData.Remove("3");
                    ttsData.Remove("4");
                    ttsData.Remove("5");
                    //ttsData.Remove("6");
                    //SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true);
                    break;
                case "2":
                    ttsData.Remove("0");
                    ttsData.Remove("1");
                    ttsData.Remove("2");
                    ttsData.Remove("3");
                    //ttsData.Remove("4");
                    ttsData.Remove("5");
                    ttsData.Remove("6");
                    //SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true);
                    break;
                case "3":
                    ttsData.Remove("0");
                    ttsData.Remove("1");
                    ttsData.Remove("2");
                    ttsData.Remove("3");
                    //ttsData.Remove("4");
                    //ttsData.Remove("5");
                    ttsData.Remove("6");
                    //SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true);
                    break;
                case "4":
                    ttsData.Remove("0");
                    ttsData.Remove("1");
                    //ttsData.Remove("2");
                    //ttsData.Remove("3");
                    ttsData.Remove("4");
                    ttsData.Remove("5");
                    //ttsData.Remove("6");
                    //SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true);
                    break;
                case "5":
                    ttsData.Remove("0");
                    ttsData.Remove("1");
                    ttsData.Remove("2");
                    ttsData.Remove("3");
                    //ttsData.Remove("4");
                    ttsData.Remove("5");
                    ttsData.Remove("6");
                    //SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true);
                    break;
                case "6":
                    ttsData.Remove("0");
                    ttsData.Remove("1");
                    //ttsData.Remove("2");
                    //ttsData.Remove("3");
                    ttsData.Remove("4");
                    ttsData.Remove("5");
                    //ttsData.Remove("6");
                    //SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true);
                    break;
            }
            return ttsData.Contains(Tts);
        }
        DataRow[] GetBasettsRow(string EmployeeID, DateTime TtsDate)
        {
            DataTable dt = new DataTable();
            System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(string.Format("SELECT * FROM BASETTS WHERE NOBR='{0}' AND '{1}' BETWEEN ADATE AND DDATE", EmployeeID, TtsDate.ToString("yyyy/MM/dd")), Properties.Settings.Default.JBHRConnectionString);
            System.Data.SqlClient.SqlCommandBuilder cmdBu = new System.Data.SqlClient.SqlCommandBuilder(ad);
            ad.Fill(dt);
            return dt.Select();
        }
        DataTable GetBasettsAll(string EmployeeID)
        {
            DataTable dt = new DataTable();
            System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(string.Format("SELECT * FROM BASETTS WHERE NOBR='{0}' ", EmployeeID), Properties.Settings.Default.JBHRConnectionString);
            System.Data.SqlClient.SqlCommandBuilder cmdBu = new System.Data.SqlClient.SqlCommandBuilder(ad);
            ad.Fill(dt);
            return dt;
        }
        bool InsertBasettsRow(DataRow rBasetts, out string Msg)
        {
            DataTable dt = rBasetts.Table;
            Msg = "";
            try
            {
                var EmployeeID = rBasetts["NOBR"].ToString();
                var TtsDate = Convert.ToDateTime(rBasetts["ADATE"]);
                var basettsRows = GetBasettsRow(EmployeeID, TtsDate);
                if (basettsRows.Count() == 1)
                {
                    var basettsRowCurrent = basettsRows[0];
                    //var rAdd = basettsRowCurrent.Table.NewRow();
                    dt.ImportRow(basettsRowCurrent);
                    var ddate = Convert.ToDateTime(basettsRowCurrent["DDATE"]);
                    var adate = Convert.ToDateTime(basettsRowCurrent["ADATE"]);
                    if (ddate != new DateTime(9999, 12, 31))
                    {
                        Msg = "已存在較新的人事異動";
                        return false;
                    }
                    if (adate == TtsDate)
                    {
                        Msg = "已存在相同異動日期的人事異動";
                        return false;
                    }
                    var rows = dt.Select(string.Format("ADATE='{0}'", basettsRowCurrent["ADATE"]));
                    if (rows.Any())
                        rows[0]["DDATE"] = TtsDate.AddDays(-1);
                    if (rBasetts["TTSCODE"].ToString() == "2")
                    {
                        rBasetts["OUDT"] = Convert.ToDateTime(rBasetts["ADATE"]).AddDays(-1).Date;
                    }
                    else if (rBasetts["TTSCODE"].ToString() == "3")
                    {
                        rBasetts["STDT"] = Convert.ToDateTime(rBasetts["ADATE"]).AddDays(-1).Date;
                    }
                    else if (rBasetts["TTSCODE"].ToString() == "4")
                    {
                        rBasetts["STINDT"] = Convert.ToDateTime(rBasetts["ADATE"]).Date;
                    }
                    else if (rBasetts["TTSCODE"].ToString() == "5")
                    {
                        rBasetts["STOUDT"] = Convert.ToDateTime(rBasetts["ADATE"]).AddDays(-1).Date;
                    }
                    else if (rBasetts["TTSCODE"].ToString() == "1")
                    {
                        rBasetts["OUDT"] = DBNull.Value;
                    }
                    if (!CheckTtscode(basettsRowCurrent["TTSCODE"].ToString(), rBasetts["TTSCODE"].ToString()))
                    {
                        Msg = "異動違規(" + basettsRowCurrent["TTSCODE"].ToString() + "," + rBasetts["TTSCODE"].ToString() + ")";
                        return false;
                    }
                    dt.Rows.Add(rBasetts);
                }
                rBasetts["KEY_DATE"] = DateTime.Now;
                rBasetts["KEY_MAN"] = MainForm.USER_NAME;
                System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(string.Format("SELECT * FROM BASETTS WHERE NOBR='{0}' AND '{1}' BETWEEN ADATE AND DDATE", EmployeeID, TtsDate.ToString("yyyy/MM/dd")), Properties.Settings.Default.JBHRConnectionString);
                System.Data.SqlClient.SqlCommandBuilder cmdBu = new System.Data.SqlClient.SqlCommandBuilder(ad);
                ad.InsertCommand = cmdBu.GetInsertCommand();
                ad.UpdateCommand = cmdBu.GetUpdateCommand();
                ad.Update(dt);
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }
            return true;
        }
        bool UpdateBasettsRow(DataRow rBasetts, out string Msg)
        {
            DataTable dt = rBasetts.Table;
            Msg = "";
            try
            {
                var EmployeeID = rBasetts["NOBR"].ToString();
                var TtsDate = Convert.ToDateTime(rBasetts["ADATE"]);
                var basettsRows = GetBasettsRow(EmployeeID, TtsDate);
                if (basettsRows.Count() == 1)
                {
                    var basettsRowCurrent = basettsRows[0];
                    rBasetts["KEY_DATE"] = DateTime.Now;
                    rBasetts["KEY_MAN"] = MainForm.USER_NAME;
                    //var rAdd = basettsRowCurrent.Table.NewRow();
                    dt.ImportRow(basettsRowCurrent);
                    var ddate = Convert.ToDateTime(basettsRowCurrent["DDATE"]);
                    var adate = Convert.ToDateTime(basettsRowCurrent["ADATE"]);
                    if (ddate != new DateTime(9999, 12, 31))
                    {
                        Msg = "已存在較新的人事異動";
                        return false;
                    }
                    if (adate != TtsDate)
                    {
                        Msg = "無資料可更新";
                        return false;
                    }
                    var rows = dt.Select(string.Format("ADATE='{0}'", TtsDate.ToShortDateString()));
                    if (rows.Any())
                    {
                        var row = rows[0];
                        foreach (DataColumn dc in dt.Columns)
                        {
                            row[dc.ColumnName] = rBasetts[dc.ColumnName];
                        }
                    }
                    //dt.Rows.Add(rBasetts);

                }

                System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(string.Format("SELECT * FROM BASETTS WHERE NOBR='{0}' AND '{1}' BETWEEN ADATE AND DDATE", EmployeeID, TtsDate.ToString("yyyy/MM/dd")), Properties.Settings.Default.JBHRConnectionString);
                System.Data.SqlClient.SqlCommandBuilder cmdBu = new System.Data.SqlClient.SqlCommandBuilder(ad);
                //ad.InsertCommand = cmdBu.GetInsertCommand();
                ad.UpdateCommand = cmdBu.GetUpdateCommand();
                ad.Update(dt);
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }
            return true;
        }
        bool DeleteBasettsRow(DataRow rBasetts, out string Msg)
        {
            //DataTable dt = rBasetts.Table;
            Msg = "";
            try
            {
                var EmployeeID = rBasetts["NOBR"].ToString();
                var TtsDate = Convert.ToDateTime(rBasetts["ADATE"]);
                var basettsDt = GetBasettsAll(EmployeeID);
                if (basettsDt.Rows.Count > 0)
                {
                    //var basettsRowCurrent = basettsRows[0];
                    //foreach (DataRow row in basettsDt.Rows)
                    //    dt.ImportRow(row);
                    var ddate = Convert.ToDateTime(rBasetts["DDATE"]);
                    var adate = Convert.ToDateTime(rBasetts["ADATE"]);
                    if (ddate != new DateTime(9999, 12, 31))
                    {
                        Msg = "只可刪除最新的異動資料";
                        return false;
                    }
                    if (adate != TtsDate)
                    {
                        Msg = "無資料可刪除";
                        return false;
                    }

                    var rowsUpdate = basettsDt.Select(string.Format("ADATE<>'{0}'", TtsDate.ToShortDateString())).OrderByDescending(p => p["ADATE"]);
                    if (rowsUpdate.Any())
                    {
                        var row = rowsUpdate.First();
                        row["DDATE"] = new DateTime(9999, 12, 31);
                    }

                    var rowsDelete = basettsDt.Select(string.Format("ADATE='{0}'", TtsDate.ToShortDateString()));
                    if (rowsDelete.Any())
                    {
                        var row = rowsDelete[0];
                        row.Delete();
                    }

                    //dt.Rows.Add(rBasetts);

                }

                System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(string.Format("SELECT * FROM BASETTS WHERE NOBR='{0}' AND '{1}' BETWEEN ADATE AND DDATE", EmployeeID, TtsDate.ToString("yyyy/MM/dd")), Properties.Settings.Default.JBHRConnectionString);
                System.Data.SqlClient.SqlCommandBuilder cmdBu = new System.Data.SqlClient.SqlCommandBuilder(ad);
                //ad.InsertCommand = cmdBu.GetInsertCommand();
                ad.DeleteCommand = cmdBu.GetDeleteCommand();
                ad.Update(basettsDt);
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }
            return true;
        }

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrorMsg)
        {
            ErrorMsg = "";
            var EmployeeID = TransferRow["員工編號"].ToString();
            var TtsDate = Convert.ToDateTime(TransferRow["異動日期"]);
            var basettsRows = GetBasettsRow(EmployeeID, TtsDate);
            if (basettsRows.Count() == 1)
            {
                var basettsRowCurrent = basettsRows[0];
                var rAdd = basettsRowCurrent.Table.NewRow();
                rAdd.ItemArray = basettsRowCurrent.ItemArray;

                int InsertFieldCount = 0;
                for (int i = 1; i < 7; i++)
                {
                    if (TransferRow["異動後資料" + i.ToString()] != null && TransferRow["異動欄位" + i.ToString()] != null && TransferRow["異動後資料" + i.ToString()].ToString().Trim().Length > 0 && TransferRow["異動欄位" + i.ToString()].ToString().Trim().Length > 0)
                    {
                        InsertFieldCount++;
                        var Field = TransferRow["異動欄位" + i.ToString()].ToString();
                        var ttsFieldList = CheckData["異動欄位"];
                        var TableColumn = ttsFieldList.Single(pp => pp.DisplayName == Field);

                        if (CheckData.ContainsKey(TransferRow["異動欄位" + i.ToString()].ToString()))
                        {
                            if (ColumnValidate(TransferRow["異動後資料" + i.ToString()].ToString(), TransferRow["異動欄位" + i.ToString()].ToString(), TransferCheckDataField.RealCode, out ErrorMsg))
                                rAdd[TableColumn.RealCode] = ErrorMsg;
                        }
                        else rAdd[TableColumn.RealCode] = TransferRow["異動後資料" + i.ToString()].ToString();
                    }
                }
                if (InsertFieldCount == 0)
                {
                    if (TransferRow.Table != null && TransferRow.Table.Columns.Contains("錯誤註記"))
                    {
                        TransferRow["錯誤註記"] += "異動欄位未設定;";
                        return false;
                    }
                }
                rAdd["ADATE"] = TransferRow["異動日期"];
                if (ColumnValidate(TransferRow["異動狀態"].ToString(), "異動代碼", TransferCheckDataField.RealCode, out ErrorMsg))
                {
                    rAdd["TTSCODE"] = ErrorMsg;
                }
                else
                    if (TransferRow.Table != null && TransferRow.Table.Columns.Contains("錯誤註記"))
                    {
                        TransferRow["錯誤註記"] += ErrorMsg;
                        return false;
                    }



                if (Convert.ToDateTime(basettsRowCurrent["ADATE"]) == TtsDate)//重複
                {
                    if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                    {
                        if (!UpdateBasettsRow(rAdd, out ErrorMsg))
                        {
                            if (TransferRow.Table != null && TransferRow.Table.Columns.Contains("錯誤註記"))
                            {
                                TransferRow["錯誤註記"] += ErrorMsg;
                            }
                        }
                    }
                    else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                    {
                        if (!DeleteBasettsRow(rAdd, out ErrorMsg))
                        {
                            if (TransferRow.Table != null && TransferRow.Table.Columns.Contains("錯誤註記"))
                            {
                                TransferRow["錯誤註記"] += ErrorMsg;
                            }
                        }
                    }
                    else
                    {
                        if (TransferRow.Table != null && TransferRow.Table.Columns.Contains("錯誤註記"))
                        {
                            ErrorMsg = "已存在相同異動日期的人事異動";
                            TransferRow["錯誤註記"] += ErrorMsg;
                            return false;
                        }
                    }
                }
                else
                {
                    if (RepeatSelectionString != JBControls.U_IMPORT.Allow_Repeat_Delete_String)//刪除不寫入
                        if (!InsertBasettsRow(rAdd, out ErrorMsg))
                        {
                            if (TransferRow.Table != null && TransferRow.Table.Columns.Contains("錯誤註記"))
                            {
                                TransferRow["錯誤註記"] += ErrorMsg;
                            }
                        }
                }

            }
            else
            {
                ErrorMsg += "找不到當前的異動資料";
                if (TransferRow.Table != null && TransferRow.Table.Columns.Contains("錯誤註記"))
                {
                    TransferRow["錯誤註記"] += ErrorMsg;
                }
                return false;
            }
            return true;
        }
    }
}
