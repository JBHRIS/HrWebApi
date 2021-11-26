using JBModule.Data.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dapper;
using System.Data.SqlClient;
using System.IO;

namespace JBHR.Sys
{
    public partial class SYS_UserDefineMgt : JBControls.JBForm
    {
        public SYS_UserDefineMgt()
        {
            InitializeComponent();
        }

        //JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        //int SizeOffset = 6;//TableLayoutPanel塞入元件時會有邊緣預留的問題
        List<UserDefineLayout> FrmMap = new List<UserDefineLayout>();
        Dictionary<string, string> TablelayoutList = new Dictionary<string, string>();
        private void SYS_UerDefineMgt_Load(object sender, EventArgs e)
        {
            jbQuery3.Query();
            jbQuery2.Query();
        }

        //點選群組設定顯示細節
        private void UserDefineDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (jbQuery1.SelectedKey != null && !string.IsNullOrEmpty(jbQuery1.SelectedKey.ToString()))
            {
                var SelectedKey = Guid.Parse(jbQuery1.SelectedKey.ToString());
                HrDBDataContext db = new HrDBDataContext();
                var UsDfID = db.UserDefineGroup.Where(p => p.UserDefineGroupID.Equals(SelectedKey)).FirstOrDefault();
                FrmMap = new List<UserDefineLayout>();
                if (!string.IsNullOrEmpty(UsDfID.TableLayoutName) && MainForm.ExTypes.ContainsKey(UsDfID.FormName))
                {
                    Type ThisFormType = MainForm.ExTypes[UsDfID.FormName];
                    Form frm = Activator.CreateInstance(ThisFormType) as Form;
                    List<Control> Ctls = JBTools.Extend.ControlsProcess.GetAllControls(frm);
                    foreach (Control ctl in Ctls)
                    {
                        if (string.Format("{0}-{1}", ctl.Parent.Name, ctl.Name) == UsDfID.TableLayoutName)
                        {
                            TableLayoutPanel tblayout = ctl as TableLayoutPanel;
                            nUDSizeX.Value = tblayout.ColumnCount;
                            nUDSizeY.Value = tblayout.RowCount;
                            this.panelUserDefine.Width = tblayout.Width;
                            this.panelUserDefine.Height = tblayout.Height;
                            this.UserDefineLayout.SuspendLayout();
                            this.UserDefineLayout.ColumnCount = tblayout.ColumnCount;
                            this.UserDefineLayout.RowCount = tblayout.RowCount;
                            this.UserDefineLayout.ColumnStyles.Clear();
                            this.UserDefineLayout.RowStyles.Clear();
                            this.UserDefineLayout.Controls.Clear();
                            Control[] clist = new Control[tblayout.Controls.Count];
                            tblayout.Controls.CopyTo(clist, 0);
                            this.UserDefineLayout.Controls.AddRange(clist);
                            foreach (ColumnStyle item in tblayout.ColumnStyles)
                            {
                                ColumnStyle cs = new ColumnStyle();
                                cs.Width = item.Width;
                                cs.SizeType = item.SizeType;
                                this.UserDefineLayout.ColumnStyles.Add(cs);
                            }
                            foreach (RowStyle item in tblayout.RowStyles)
                            {
                                RowStyle rs = new RowStyle();
                                rs.Height = item.Height;
                                rs.SizeType = item.SizeType;
                                this.UserDefineLayout.RowStyles.Add(rs);
                            }
                            foreach (Control item in this.UserDefineLayout.Controls)
                            {
                                item.Enabled = false;
                                if (item is JBControls.TextBox)
                                    (item as JBControls.TextBox).CaptionLabel = new Label();
                                else if (item is JBControls.PopupTextBox)
                                    (item as JBControls.PopupTextBox).CaptionLabel = new Label();
                            }
                            this.UserDefineLayout.ResumeLayout();
                            break;
                        }
                    }
                }
                //nUDSizeX.Value = UsDfID.ColumnCnt;
                //nUDSizeY.Value = UsDfID.RowCnt;
                nUDItemsWidth.Value = UsDfID.ItemsWidth;
                nUDItemsHeight.Value = UsDfID.ItemsHeight;
                RefresUserDefineLayout(SelectedKey); 
            }
        }

        private void RefresUserDefineLayout(Guid SelectedKey)
        {
            //int tbLayoutX = Convert.ToInt32(nUDSizeX.Value);
            //int tbLayoutY = Convert.ToInt32(nUDSizeY.Value);
            //int itemW = (Convert.ToInt32(nUDItemsWidth.Value) + SizeOffset);
            //int itemH = (Convert.ToInt32(nUDItemsHeight.Value) + SizeOffset);

            SystemFunction.UserDefineLayoutFunc(this.UserDefineLayout, SelectedKey, true);

            #region 新增編輯模式的按鍵事件
            foreach (Control item in UserDefineLayout.Controls)
            {
                if (item.Enabled)
                {
                    switch (item)
                    {
                        case Label _control:
                            _control.Click += Control_Click;
                            break;
                        case TextBox _control:
                            _control.Click += Control_Click;
                            break;
                        case CheckBox _control:
                            _control.Click += Control_Click;
                            break;
                        case DateTimePicker _control:
                            _control.Click += Control_Click;
                            _control.Enter += Control_Click;
                            break;
                        case ComboBox _control:
                            _control.Click += Control_Click;
                            break;
                        case Button _control:
                            _control.Click += Control_Click;
                            break;
                        case NumericUpDown _control:
                            _control.Click += Control_Click;
                            break;
                    }
                }    
            } 
            #endregion
        }

        private void Control_Click(object sender, EventArgs e)
        {
            if (jbQuery1.SelectedKey != null && !string.IsNullOrEmpty(jbQuery1.SelectedKey.ToString()))
            {
                SYS_UserDefineDetail SUDD = new SYS_UserDefineDetail();
                Guid UsDfGRoupID = Guid.Parse(jbQuery1.SelectedKey.ToString());
                Guid UsDfMasterID = Guid.Parse(jbQuery3.SelectedKey.ToString());
                SUDD.UserDefineGroupID = UsDfGRoupID;
                SUDD.UserDefineMasterID = UsDfMasterID;
                if (sender is Button)
                {
                    Button BTN = (sender as Button);
                    SUDD.LayoutColumnProp = int.Parse(BTN.Name.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                    SUDD.LayoutRowProp = int.Parse(BTN.Name.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                }
                else
                {
                    switch (sender)
                    {
                        case Label _control:
                            SUDD.controlID = Guid.Parse(_control.Name);
                            break;
                        case TextBox _control:
                            SUDD.controlID = Guid.Parse(_control.Name);
                            break;
                        case CheckBox _control:
                            SUDD.controlID = Guid.Parse(_control.Name);
                            break;
                        case DateTimePicker _control:
                            SUDD.controlID = Guid.Parse(_control.Name);
                            break;
                        case ComboBox _control:
                            SUDD.controlID = Guid.Parse(_control.Name);
                            break;
                        case NumericUpDown _control:
                            SUDD.controlID = Guid.Parse(_control.Name);
                            break;
                    }
                }
                SUDD.ShowDialog();
                //RefresUserDefineLayout(SelectedKey); 
                UserDefineDataGridView_CellClick(sender, new DataGridViewCellEventArgs(0, 0));
            }
        }

        #region jbQuery相關
        private void jbQuery2_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            if (jbQuery2.SelectedKey != null)
            {
                SYS_UserDefineMgt_ADD_C frm = new SYS_UserDefineMgt_ADD_C();
                frm.Icon = this.Icon;
                frm.COMP = jbQuery2.SelectedKey.ToString();
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                frm.ShowDialog();
                jbQuery2.Query(); 
            }
        }

        private void jbQuery1_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            HrDBDataContext db = new HrDBDataContext();
            var instance = db.UserDefineGroup.SingleOrDefault(p => p.UserDefineGroupID.Equals(Guid.Parse(e.PrimaryKey.ToString())));
            db.UserDefineGroup.DeleteOnSubmit(instance);
            var instance1 = db.UserDefineLayout.Where(p => p.UserDefineGroupID.Equals(Guid.Parse(e.PrimaryKey.ToString())));
            db.UserDefineLayout.DeleteAllOnSubmit(instance1);
            db.SubmitChanges();
            jbQuery1.Query();
        }

        private void jbQuery1_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            if (jbQuery3.SelectedKey != null)
            {
                SYS_UserDefineMgt_ADD frm = new SYS_UserDefineMgt_ADD();
                frm.Icon = this.Icon;
                frm.UserDefineMasterID = Guid.Parse(jbQuery3.SelectedKey.ToString());
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                frm.ShowDialog();
                jbQuery1.Query(); 
            }
        }

        private void jbQuery1_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            if (jbQuery1.SelectedKey != null && jbQuery3.SelectedKey != null)
            {
                SYS_UserDefineMgt_ADD frm = new SYS_UserDefineMgt_ADD();
                frm.Icon = this.Icon;
                frm.UserDefineGroupID = Guid.Parse(jbQuery1.SelectedKey.ToString());
                frm.UserDefineMasterID = Guid.Parse(jbQuery3.SelectedKey.ToString());
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                frm.ShowDialog();
                jbQuery1.Query(); 
            }
        }
        private void jbQuery3_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            SYS_UserDefineMgt_ADD_M frm = new SYS_UserDefineMgt_ADD_M();
            frm.Icon = this.Icon;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            frm.ShowDialog();
            jbQuery3.Query();
        }
        private void jbQuery3_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            if (jbQuery3.SelectedKey != null)
            {
                SYS_UserDefineMgt_ADD_M frm = new SYS_UserDefineMgt_ADD_M();
                frm.Icon = this.Icon;
                frm.UserDefineMasterID = Guid.Parse(jbQuery3.SelectedKey.ToString());
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                frm.ShowDialog();
                jbQuery3.Query();
            }
        }
        private void jbQuery3_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            HrDBDataContext db = new HrDBDataContext();
            var instance = db.UserDefineMaster.SingleOrDefault(p => p.UserDefineMasterID.Equals(Guid.Parse(e.PrimaryKey.ToString())));
            db.UserDefineMaster.DeleteOnSubmit(instance);
            var instance1 = db.MenuGroup.Where(p => p.MenuGroupID.Equals(Guid.Parse(e.PrimaryKey.ToString())));
            db.MenuGroup.DeleteAllOnSubmit(instance1);
            db.SubmitChanges();
            jbQuery3.Query();
        }

        private void MasterUserDefinedataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            JBControls.HrDBDataContext db = new JBControls.HrDBDataContext();
            var jqSetting = db.jqSetting.Where(p => p.QuerySetting == "UserDefineGroupForMaster").FirstOrDefault();
            if (jqSetting != null)
            {
                List<JBControls.jqCondition> jqConditions = new List<JBControls.jqCondition>();
                JBControls.jqCondition jqCondition = new JBControls.jqCondition();
                jqCondition.SettingID = jqSetting.ID;
                jqCondition.Sort = 1;
                jqCondition.TableName = "USERDEFINEGROUP";
                jqCondition.ColumnName = "USERDEFINEMASTERID";
                jqCondition.Comparison = "等於";
                jqCondition.Value = jbQuery3.SelectedKey != null ? jbQuery3.SelectedKey.ToString() : Guid.Empty.ToString();
                jqConditions.Add(jqCondition);
                jbQuery1.Query(jqConditions);
            }
        }

        #endregion

        //改變配置
        private void btnChangeSize_Click(object sender, EventArgs e)
        {
            if (jbQuery1.SelectedKey != null && !string.IsNullOrEmpty(jbQuery1.SelectedKey.ToString()))
            {
                var SelectedKey = Guid.Parse(jbQuery1.SelectedKey.ToString());
                HrDBDataContext db = new HrDBDataContext();
                var UsDfID = db.UserDefineGroup.Where(p => p.UserDefineGroupID.Equals(SelectedKey)).FirstOrDefault();
                var UsDfL = db.UserDefineLayout.Where(p => p.UserDefineGroupID.Equals(SelectedKey));
                if (UsDfL.Any())
                {
                    var MaxX = UsDfL.Select(p => p.LayoutColumn + p.ColumnSpan).Max();
                    var MaxY = UsDfL.Select(p => p.LayoutRow + p.RowSpan).Max();
                    if (Convert.ToInt32(nUDSizeX.Value) < MaxX || Convert.ToInt32(nUDSizeY.Value) < MaxY)
                    {
                        MessageBox.Show("重新配置大小不可小於控制項範圍,否則會造成顯示異常!");
                        if (Convert.ToInt32(nUDSizeX.Value) < MaxX)
                            nUDSizeX.Value = MaxX;
                        if (Convert.ToInt32(nUDSizeY.Value) < MaxY)
                            nUDSizeY.Value = MaxY;
                    }
                }
                UsDfID.ColumnCnt = Convert.ToInt32(nUDSizeX.Value);
                UsDfID.RowCnt = Convert.ToInt32(nUDSizeY.Value);
                UsDfID.ItemsWidth = Convert.ToInt32(nUDItemsWidth.Value);
                UsDfID.ItemsHeight = Convert.ToInt32(nUDItemsHeight.Value);
                db.SubmitChanges();
                RefresUserDefineLayout(SelectedKey); 
            }
        }
        public class UDF_Setting
        {
            public UserDefineGroup MyUserDefineGroup;
            public List<UserDefineLayout> MyUserDefineLayout;
            public List<UserDefineSource> MyUserDefineSource;
        }
        private void btnExportSetting_Click(object sender, EventArgs e)
        {
            if (jbQuery1.SelectedKey != null && !string.IsNullOrEmpty(jbQuery1.SelectedKey.ToString()))
            {
                var SelectedKey = Guid.Parse(jbQuery1.SelectedKey.ToString());
                HrDBDataContext db = new HrDBDataContext();
                var UDFG = db.UserDefineGroup.Where(p => p.UserDefineGroupID.Equals(SelectedKey)).FirstOrDefault();
                //string strJqSetting = Newtonsoft.Json.JsonConvert.SerializeObject(_jqSetting);
                UDF_Setting US = new UDF_Setting();
                US.MyUserDefineGroup = UDFG;
                US.MyUserDefineLayout = db.UserDefineLayout.Where(p => p.UserDefineGroupID.Equals(UDFG.UserDefineGroupID)).ToList();
                US.MyUserDefineSource = new List<UserDefineSource>();
                foreach (var item in US.MyUserDefineLayout)
                {
                    var SourceID = CodeFunction.GetUDFControlTagPropByID(item.ControlID, "SourceID");
                    if (!string.IsNullOrEmpty(SourceID))
                    {
                        var UDFSource = db.UserDefineSource.Where(p => p.SourceID.Equals(Guid.Parse(SourceID))).FirstOrDefault();
                        if (UDFSource != null && !US.MyUserDefineSource.Contains(UDFSource))
                            US.MyUserDefineSource.Add(UDFSource);
                    }
                }

                string strJqSetting = Newtonsoft.Json.JsonConvert.SerializeObject(US);
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "UserDefine Setting|*.ud";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var file_name = sfd.FileName;
                    StreamWriter sw = new StreamWriter(file_name);
                    sw.Write(strJqSetting);
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
        private void btnImportSetting_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "UserDefine Setting|*.ud";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                HrDBDataContext db = new HrDBDataContext();
                string file_name = ofd.FileName;
                StreamReader sr = new StreamReader(file_name);
                var str = sr.ReadToEnd();
                var setting = Newtonsoft.Json.JsonConvert.DeserializeObject<UDF_Setting>(str);
                var sql = db.UserDefineGroup.Where(p => p.UserDefineGroupID.Equals(setting.MyUserDefineGroup.UserDefineGroupID));

                if (!sql.Any())
                {
                    db.UserDefineGroup.InsertOnSubmit(setting.MyUserDefineGroup);

                    foreach (var item in setting.MyUserDefineLayout)
                    {
                        if (!db.UserDefineLayout.Where(p => p.UserDefineGroupID.Equals(item.UserDefineGroupID) && p.ControlID.Equals(item.ControlID)).Any())
                            db.UserDefineLayout.InsertOnSubmit(item);
                    }
                    db.UserDefineSource.InsertAllOnSubmit(setting.MyUserDefineSource);
                    foreach (var item in setting.MyUserDefineSource)
                    {
                        if (!db.UserDefineSource.Where(p => p.SourceID.Equals(item.SourceID)).Any())
                            db.UserDefineSource.InsertOnSubmit(item);
                    }
                    db.SubmitChanges();
                    MessageBox.Show("匯入完成");
                    jbQuery1.Query();
                }
                else
                {
                    MessageBox.Show(string.Format("{0}-{1}的設定已經存在.", setting.MyUserDefineGroup.UserDefineGroupID, setting.MyUserDefineGroup.UserDefineGroupName));
                }
            }
        }

    }
}
