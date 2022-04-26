using JBModule.Data.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using JBControls;
using System.Dynamic;
using JBTools.Extend;

namespace JBHR.Att.KCRCustom
{
    public partial class FRM2_MealCount : JBControls.JBForm
    {
        public FRM2_MealCount()
        {
            InitializeComponent();
        }
        List<string> filter = new List<string>();
        List<string> columnFilter = new List<string>();
        string ValueField;
        DataTable Source;
        int SplitSize = 1000;
        private void FRM2_MealCount_Load(object sender, EventArgs e)
        {
            var ADate = DateTime.Now.Date;
            dtpCountDate.Value = ADate;
            UpdateMealApplySetting(GetEmployeeList(ADate), ADate);
        }
        private List<string> GetEmployeeList(DateTime ADate)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var EmployeeList = (from bts in db.BASETTS
                                where new string[] { "1", "4", "6" }.Contains(bts.TTSCODE)
                                && bts.ADATE.CompareTo(ADate) <= 0 && bts.DDATE.Value.CompareTo(ADate) >= 0
                                && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(bts.SALADR)
                                select bts.NOBR).ToList();
            return EmployeeList;
        }
        private void UpdateMealApplySetting(List<string> EmployeeList, DateTime ADate,bool GenMealApply = false)
        {
            List<string> HolidayList = new List<string>() { "00", "0X", "0Z" };
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var ApplySettingSql = (from MAS in db.KCR_MealApplySetting
                                   join bts in db.BASETTS on MAS.EmployeeID equals bts.NOBR
                                   join b in db.BASE on bts.NOBR equals b.NOBR
                                   join MG in db.MealGroup on MAS.MealGroup equals MG.MealGroup_Code
                                   join MT in db.MealType on new { MAS.MealGroup, MAS.MealType } equals new { MT.MealGroup, MealType = MT.MealType_Code }
                                   where //MAS.EmployeeID == EmployeeID
                                   new string[] { "1", "4", "6" }.Contains(bts.TTSCODE)
                                   && bts.ADATE.CompareTo(ADate) <= 0 && bts.DDATE.Value.CompareTo(ADate) >= 0
                                   && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(bts.SALADR)
                                   && MAS.ADate.CompareTo(ADate) <= 0 && MAS.DDate.CompareTo(ADate) >= 0
                                   orderby MT.BTime
                                   select new
                                   {
                                       MAS.AutoKey,
                                       MAS.GID,
                                       MAS.EmployeeID,
                                       b.NAME_C,
                                       MG.MealGroup_Code,
                                       MG.MealGroup_DISP,
                                       MG.MealGroup_Name,
                                       MT.MealType_Code,
                                       MT.MealType_Name,
                                       MT.BTime,
                                       MAS.ApplyFlag,
                                       MAS.HoliMealFlag,
                                       MAS.ADate,
                                       MAS.DDate,
                                       MAS.Note,
                                       MAS.Key_Man,
                                       MAS.Key_Date,
                                   });
            var ApplySettingList = ApplySettingSql.ToList();
            var EmpDataSql = (from bts in db.BASETTS
                              join b in db.BASE on bts.NOBR equals b.NOBR
                              join m in (
                                 from mg in db.GetUserDefineValueList("MealGroup")
                                 join mt in db.MealType on mg.Value equals mt.MealGroup
                                 select new { mg, mt = mt.MealType_Code }
                              ) on bts.NOBR equals m.mg.Code
                              //join h in db.HOLICD on bts.HOLI_CODE equals h.HOLI_CODE
                              //join holi in (
                              //   from ho in db.HOLI
                              //   join o in db.OTHCODE on ho.OTHCODE equals o.OTHCODE1
                              //   where o.STDHOLI || o.OTHHOLI
                              //   select ho
                              //) on new { HOLICD = h.HOLI_CODE, ADate } equals new { HOLICD = holi.HOLI_CODE, ADate = holi.H_DATE } into holi1
                              //from holi in holi1.DefaultIfEmpty()
                              join att in (
                                   from at in db.ATTEND
                                   where at.ADATE.CompareTo(ADate) == 0
                                   select at
                              ) on bts.NOBR equals att.NOBR into att1
                              from att in att1.DefaultIfEmpty()
                              where //bts.NOBR == EmployeeID
                              new string[] { "1", "4", "6" }.Contains(bts.TTSCODE)
                              && bts.ADATE.CompareTo(ADate) <= 0 && bts.DDATE.Value.CompareTo(ADate) >= 0
                              && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(bts.SALADR)
                              select new { Basetts = bts, Base = b, holi = att != null && HolidayList.Contains(att.ROTE), MealGroup = m.mg, MealType = m.mt });
            var EmpDataList = EmpDataSql.ToList();
            var MealTypeList = db.MealType.ToList();
            var MealGroupList = db.MealGroup.ToList();
            var UserDefineValueList = db.GetUserDefineValueList("MealType_Holi").ToList();
            var FinalMealTypeList = (from mt in MealTypeList
                                     join mg in MealGroupList on mt.MealGroup equals mg.MealGroup_Code
                                     join udv in UserDefineValueList on string.Format("{0},{1}", mt.MealType_Code, mt.MealGroup) equals udv.Code into udv1
                                     from udv in udv1.DefaultIfEmpty()
                                     select new { mt, mg, holi = udv != null && bool.Parse(udv.Value) }).ToList();
            var HoliFirstMealTypeList = FinalMealTypeList.Where(p => p.holi).GroupBy(q => q.mt.MealGroup).Select(r => new { MealGroup = r.Key, MealType = r.First().mt.MealType_Code });
            var FinalSettingSQL = (from emp in EmpDataList
                                   join fmt in FinalMealTypeList on new { MealGroup = emp.MealGroup.Value, emp.MealType, emp.holi }
                                                               equals new { fmt.mt.MealGroup, MealType = fmt.mt.MealType_Code, fmt.holi }
                                   join hfmt in HoliFirstMealTypeList on new { MealGroup = emp.MealGroup.Value, emp.MealType } equals new { hfmt.MealGroup, hfmt.MealType } into hfmt1
                                   from hfmt in hfmt1.DefaultIfEmpty()
                                   select new
                                   {
                                       員工編號 = emp.Base.NOBR,
                                       員工姓名 = emp.Base.NAME_C,
                                       用餐群組 = fmt.mg.MealGroup_DISP + "-" + fmt.mg.MealGroup_Name,
                                       用餐餐別 = fmt.mt.MealType_Code + "-" + fmt.mt.MealType_Name,
                                       是否用餐 = hfmt != null ? "" : fmt.holi ? "" : "V",
                                       平假日 = fmt.holi ? "假日" : "平日",
                                       備註 = fmt.mt.NOTE,
                                       登錄者 = "程式預設",
                                       登錄日期 = DateTime.Now,
                                       _MealGroup = fmt.mg.MealGroup_Code,
                                       _MealType = fmt.mt.MealType_Code,
                                       _AutoKey = -1,
                                       _GID = Guid.NewGuid(),
                                       _ADate = DateTime.Now.Date,
                                       _DDate = new DateTime(9999, 12, 31),
                                   }).ToList();
            var FinalSettingList = (from fsl in FinalSettingSQL
                                    join asl in ApplySettingList on new { emp = fsl.員工編號, MealGroup = fsl._MealGroup, MealType = fsl._MealType }
                                                               equals new { emp = asl.EmployeeID, MealGroup = asl.MealGroup_Code, MealType = asl.MealType_Code } into asl1
                                    from asl in asl1.DefaultIfEmpty()
                                    orderby fsl.員工編號, fsl.用餐群組, fsl.用餐餐別
                                    select new
                                    {
                                        員工編號 = fsl.員工編號,
                                        員工姓名 = fsl.員工姓名,
                                        用餐群組 = fsl.用餐群組,
                                        用餐餐別 = fsl.用餐餐別,
                                        是否用餐 = asl != null ? (asl.ApplyFlag ? "V" : "") : fsl.是否用餐,
                                        平假日 = asl != null ? (asl.HoliMealFlag ? "假日" : "平日") : fsl.平假日,
                                        備註 = asl != null ? asl.Note : fsl.備註,
                                        登錄者 = asl != null ? asl.Key_Man : fsl.登錄者,
                                        登錄日期 = asl != null ? asl.Key_Date : fsl.登錄日期,
                                        _MealGroup = asl != null ? asl.MealGroup_Code : fsl._MealGroup,
                                        _MealType = asl != null ? asl.MealType_Code : fsl._MealType,
                                        _AutoKey = asl != null ? asl.AutoKey : fsl._AutoKey,
                                        _GID = asl != null ? asl.GID : fsl._GID,
                                        _ADate = asl != null ? asl.ADate : fsl._ADate,
                                        _DDate = asl != null ? asl.DDate : fsl._DDate,
                                    }).ToList();
            if (GenMealApply)
            {
                List<MEALAPPLYRECORD> mEALAPPLYRECORDs = new List<MEALAPPLYRECORD>();
                foreach (var item in FinalSettingList)
                {
                    if (item.是否用餐 == "V")
                    {
                        MEALAPPLYRECORD instance = new MEALAPPLYRECORD()
                        {
                            AUTOKEY = -1,
                            NOBR = item.員工編號,
                            ADATE = ADate,
                            MealGroup = item._MealGroup,
                            MealType = item._MealType,
                            NOTE = item.備註,
                            SERONO = item._GID.ToString(),
                            KEY_MAN = MainForm.USER_NAME,
                            KEY_DATE = DateTime.Now,
                        };
                        mEALAPPLYRECORDs.Add(instance);
                    }
                }
                string MealApplyRecordDeleteSql = "DELETE MealApplyRecord WHERE ADATE = @ADate and NOBR IN @item";
                string delerrMsg = "※產生報餐資料異常※";
                foreach (var item in EmployeeList.Split(SplitSize))
                {
                    object param = new { ADate, item };
                    db.BulkInsertWithDelete(db, mEALAPPLYRECORDs.Where(p => item.Contains(p.NOBR)), MealApplyRecordDeleteSql, param, delerrMsg);
                }

                string ResultStr = string.Format("--依目前設定統計{2}用餐{1}(結算時間 {0}){1}", DateTime.Now, Environment.NewLine, ADate.ToShortDateString()); 
                var CountTable = FinalSettingList.GroupBy(p => new { p.用餐群組, p.用餐餐別 }).Select(p => new { p.Key.用餐群組, p.Key.用餐餐別, 數量 = p.Count(q => q.是否用餐 == "V") });
                foreach (var gp in CountTable.GroupBy(p => p.用餐群組))
                {
                    ResultStr += gp.Key.ToString() + Environment.NewLine;
                    foreach (var item in gp)
                    {
                        if (item.數量 != 0)
                            ResultStr += string.Format(" {0}:{1}{2}", item.用餐餐別, item.數量, Environment.NewLine);
                    }
                         
                }
                txtCountResult.Text = ResultStr;
            }

            #region Linq PIVOT
            var allCols = FinalSettingList.Select(o => o.用餐餐別).Distinct().ToList();
            var res = FinalSettingList.GroupBy(o => new { o.員工編號, o.員工姓名, o.用餐群組, o.平假日 })
                .Select(o =>
                {
                    dynamic d = new ExpandoObject();
                    d.員工編號 = o.Key.員工編號;
                    d.員工姓名 = o.Key.員工姓名;
                    d.用餐群組 = o.Key.用餐群組;
                    d.平假日 = o.Key.平假日;
                    var dict =
                        d as IDictionary<string, object>;
                    allCols.ForEach(c =>
                    {
                        dict[c] = o.Where(p => p.用餐餐別 == c).Select(p => p.是否用餐).FirstOrDefault();
                    });
                    d.備註 = o.FirstOrDefault() != null ? o.First().備註 : String.Empty;
                    d.登錄者 = o.FirstOrDefault() != null ? o.First().登錄者 : "程式預設";
                    d.登錄日期 = o.FirstOrDefault() != null ? o.First().登錄日期 : DateTime.Now;
                    return d;
                }).ToList(); 
            #endregion

            #region ListToDataTable
            Source = new DataTable();
            foreach (var key in ((IDictionary<string, object>)res[0]).Keys)
            {
                Source.Columns.Add(key);
            }
            foreach (var d in res)
            {
                Source.Rows.Add(((IDictionary<string, object>)d).Values.ToArray());
            } 
            #endregion

            #region dgv Bindidng
            dgv.DataSource = null;
            if (string.IsNullOrWhiteSpace(ValueField)) ValueField = Source.Columns[0].ColumnName;
            bsData.DataSource = Source;
            dgv.DataSource = bsData;
            foreach (DataGridViewColumn dc in dgv.Columns)
            {
                if (dc.DataPropertyName != "MultiSelectCheckColumn")
                    dc.ReadOnly = true;
                if (dc.DataPropertyName.IndexOf("_") == 0)//如果用_當第一個字元，視為隱藏欄位
                    dc.Visible = false;
            }
            SetColumnFilter(Source);
            textBoxFilter_TextChanged(null, null); 
            #endregion
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            var ADate = dtpCountDate.Value;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var EmployeeList = GetEmployeeList(ADate);
            var MealApplyRecordSQL = from ma in db.MEALAPPLYRECORD
                                     join mg in db.MealGroup on ma.MealGroup equals mg.MealGroup_Code
                                     join mt in db.MealType on new { ma.MealGroup, ma.MealType } equals new { mt.MealGroup, MealType = mt.MealType_Code }
                                     where
                                     EmployeeList.Contains(ma.NOBR)
                                     && ma.ADATE.CompareTo(ADate) == 0
                                     select new { ma, mt, mg };
            if (MealApplyRecordSQL.Any())
            {
                if (MessageBox.Show("已有統計資料，是否要重新產生?", "重新統計", MessageBoxButtons.YesNoCancel) == DialogResult.No)
                {
                    var MealApplyRecordGp = MealApplyRecordSQL.OrderBy(p => p.mg.MealGroup_DISP + "-" + p.mg.MealGroup_Name)
                                              .ThenBy(p => p.mt.MealType_Code + "-" + p.mt.MealType_Name)
                                              .ToList().GroupBy(p => new
                                              {
                                                  用餐群組 = p.mg.MealGroup_DISP + "-" + p.mg.MealGroup_Name,
                                                  用餐餐別 = p.mt.MealType_Code + "-" + p.mt.MealType_Name,
                                              }).Select(p => new
                                              {
                                                  p.Key.用餐群組,
                                                  p.Key.用餐餐別,
                                                  數量 = p.Count(),
                                              });

                    string ResultStr = string.Format("--依報餐紀錄統計{2}用餐{1}(結算時間 {0}){1}", DateTime.Now, Environment.NewLine, ADate.ToShortDateString());
                    foreach (var gp in MealApplyRecordGp.GroupBy(p => p.用餐群組))
                    {
                        ResultStr += gp.Key.ToString() + Environment.NewLine;
                        foreach (var item in gp)
                            ResultStr += string.Format(" {0}:{1}{2}", item.用餐餐別, item.數量, Environment.NewLine);
                    }
                    txtCountResult.Text = ResultStr;

                    return;
                }
            }
            UpdateMealApplySetting(EmployeeList, ADate, true);

        }
        #region DataGridView Filter Fuction
        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            filter = new List<string>();
            int limitValue = 200;
            string temp_filter = "";
            string[] temp_patterns = textBoxFilter.Lines;
            List<string> patterns = new List<string>();
            int like_count = 0;
            int filterBtnNo = 0;

            clearFilterBtn();
            foreach (var item in temp_patterns)
            {
                if (patterns.Contains(item))
                    continue;
                else
                    patterns.Add(item);
            }
            foreach (var cf in columnFilter)
            {
                if (cf.IndexOf("_") == 0)//如果用_當第一個字元，視為隱藏欄位
                    continue;//隱藏欄位不搜尋
                foreach (var p in patterns)
                {
                    temp_filter = setFilterString(cf, p, "");
                    bsData.Filter = temp_filter;
                    if (dgv.Rows.Count > 0)
                    {
                        if (filter.Count() == filterBtnNo)//有效條件數超過上限
                            filter.Add("");
                        filter[filterBtnNo] = setFilterString(cf, p, filter[filterBtnNo]);
                        like_count++;
                        if (like_count % limitValue == 0)//設定一個Btn幾個條件
                        {
                            filterBtnNo++;
                            //SetFilterBtn(filterBtnNo);
                        }
                    }
                    //int ii = 0;
                    //if (p.Trim().Length == 0)
                    //    continue;
                    //while (ii < 1000)
                    //{
                    //    ii++;
                    //    if (temp_filter.Trim().Length > 0)
                    //        temp_filter += " or ";
                    //    temp_filter += string.Format("{1} like '%{0}%'", p.Trim(), cf);
                    //    bsData.Filter = temp_filter;

                    //}
                }
            }
            if (filterBtnNo > 0 && filter.Count() != filterBtnNo)
            {
                if (!string.IsNullOrWhiteSpace(filter[filterBtnNo]))//確認有篩選條件
                {
                    filterBtnNo++;
                    //SetFilterBtn(filterBtnNo);
                }
            }
            //setPageControls(1);
            bsData.Filter = like_count == 0 ? temp_filter : filter[0];
        }
        void clearFilterBtn()
        {
            List<Button> btnList = new List<Button>();
            foreach (var item in this.Controls)
            {
                if (item is Button)
                {
                    var btn = item as Button;
                    if (btn.Tag != null && btn.Tag.ToString() == "FilterBtn")
                    {
                        btnList.Add(btn);
                    }
                }
            }
            foreach (var it in btnList)
            {
                this.Controls.Remove(it);
            }
        }
        private void bnColumnFilter_Click(object sender, EventArgs e)
        {
            ColumnCheck cck = new ColumnCheck(Source, columnFilter);
            cck.notExistsList = new List<string> { "MultiSelectCheckColumn" };
            foreach (DataGridViewColumn dc in dgv.Columns)
            {
                if (dc.DataPropertyName.IndexOf("_") == 0 || dc.DataPropertyName.IndexOf("-") != -1)//如果用_當第一個字元，視為隱藏欄位
                    cck.notExistsList.Add(dc.DataPropertyName);
            }
            cck.ShowDialog();
            columnFilter = cck.getResult();
            SetColumnFilterNo(columnFilter.Count);
            textBoxFilter_TextChanged(null, null);
        }
        Type[] AcceptType = new Type[] { typeof(string) };
        string setFilterString(string columnName, string likeName, string filterString)
        {
            if (likeName.Trim().Length == 0)
                return filterString;
            if (filterString == null)
                filterString = "";
            else if (filterString.Trim().Length > 0)
                filterString += " or ";
            string Result = "";
            var ColType = Source.Columns[columnName].DataType;
            if (AcceptType.Contains(ColType))
                Result = filterString + string.Format("{1} like '%{0}%'", likeName.Trim(), columnName);
            else Result = filterString + string.Format("CONVERT({1}, 'System.String') like '%{0}%'", likeName.Trim(), columnName);

            return Result;

        }
        void SetColumnFilter(DataTable Source)
        {
            columnFilter.Clear();
            foreach (DataColumn dc in Source.Columns)
            {
                if (dc.ColumnName == "MultiSelectCheckColumn" || dc.ColumnName.IndexOf("-") != -1)//check欄位不搜尋
                    continue;//check欄位不搜尋
                columnFilter.Add(dc.ColumnName);
            }
            SetColumnFilterNo(columnFilter.Count);
        }
        void SetColumnFilterNo(int no)
        {
            bnColumnFilter.Text = string.Format("篩選欄位({0})", no);
        }
        private void textBoxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                e.SuppressKeyPress = true;
                textBoxFilter.SelectAll();
            }
        }
        #endregion

        private void dtpCountDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime ADate = dtpCountDate.Value;
            UpdateMealApplySetting(GetEmployeeList(ADate), ADate);
        }
    }
}
