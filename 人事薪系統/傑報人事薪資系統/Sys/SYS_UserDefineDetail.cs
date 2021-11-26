using JBModule.Data.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Dapper;
using Newtonsoft.Json;
using System.Windows.Forms.Design;
using System.Drawing.Design;

namespace JBHR.Sys
{
    public partial class SYS_UserDefineDetail : JBControls.JBForm
    {
        public SYS_UserDefineDetail()
        {
            InitializeComponent();
        }
        public Guid controlID { set; get; }
        public Guid UserDefineGroupID { set; get; }
        public Guid UserDefineMasterID { set; get; }
        public int LayoutColumnProp { set; get; }
        public int LayoutRowProp { set; get; }

        enum CRUD { Create, Read, Update, Delete };

        LabelControl new_Label = new LabelControl();
        CheckBoxControl new_CheckBox = new CheckBoxControl();
        TextBoxControl new_TextBox = new TextBoxControl();
        DateTimePickerControl new_DateTimePicker = new DateTimePickerControl();
        ComboBoxControl new_ComboBox = new ComboBoxControl();
        NumericUpDownControl new_NumericUpDown = new NumericUpDownControl();
        UserDefineLayout instance = null;
        HrDBDataContext db = new HrDBDataContext();
        CRUD EditType = CRUD.Read;
        string ControlTypeProp = "rbRemove";

        private void SYS_UserDefineDetail_Load(object sender, EventArgs e)
        {
            if (controlID != null && !controlID.Equals(Guid.Empty))
            {
                instance = db.UserDefineLayout.Where(p => p.UserDefineGroupID == UserDefineGroupID && p.ControlID == controlID).First();
                LayoutColumnProp = instance.LayoutColumn;
                LayoutRowProp = instance.LayoutRow;
                EditType = CRUD.Update;
            }
            else
            {
                instance = new UserDefineLayout();
                instance.UserDefineGroupID = UserDefineGroupID;
                instance.ControlID = Guid.NewGuid();
                Dictionary<string, string> TagList = new Dictionary<string, string>();
                TagList.Add("Text", string.Empty);
                instance.Tag = JsonConvert.SerializeObject(TagList);
                string tagstring = JsonConvert.SerializeObject(TagList);
                instance.Type = "Label";
                instance.Anchor = AnchorStyles.Right.ToString();
                instance.Dock = DockStyle.None.ToString();
                instance.LayoutColumn = LayoutColumnProp;
                instance.LayoutRow = LayoutRowProp;
                instance.ColumnSpan = 1;
                instance.RowSpan = 1;
                rbLabel.Checked = true;
                rbRemoveAt.Enabled = false;
                lbRemoveAt.Enabled = false;
                EditType = CRUD.Create;
            }

            ControlTypeProp = "rb" + instance.Type;
            switch (ControlTypeProp)
            {
                case "rbLabel":
                    rbLabel.Checked = true;
                    break;
                case "rbCheckBox":
                    rbCheckBox.Checked = true;
                    break;
                case "rbTextBox":
                    rbTextBox.Checked = true;
                    break;
                case "rbDateTimePicker":
                    rbDateTimePicker.Checked = true;
                    break;
                case "rbComboBox":
                    rbComboBox.Checked = true;
                    break;
                case "rbNumericUpDown":
                    rbNumericUpDown.Checked = true;
                    break;
                default:
                    rbRemoveAt.Checked = true;
                    break;
            }
        }

        #region 切換選擇的控制項
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton RB = (sender as RadioButton);
            if (RB.Checked == true)
            {
                propertyGrid1.Enabled = true;
                lbRemoveAt.Enabled = false;
                label1.Enabled = false;
                checkBox1.Enabled = false;
                textBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
                comboBox1.Enabled = false;
                numericUpDown1.Enabled = false;
                ControlTypeProp = RB.Name;
                propertyGrid1.PropertySort = PropertySort.Categorized;
                Dictionary<string, string> TagList = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(instance.Tag))
                    TagList = JsonConvert.DeserializeObject<Dictionary<string, string>>(instance.Tag);//反序列化
                switch (RB.Name)
                {
                    case "rbLabel":
                        new_Label.GroupID = instance.UserDefineGroupID;
                        new_Label.ID = instance.ControlID;
                        new_Label.Column = instance.LayoutColumn;
                        new_Label.Row = instance.LayoutRow;
                        new_Label.Anchor = SystemFunction.SetAnchorStyles(instance.Anchor);
                        new_Label.Dock = SystemFunction.SetDockStyle(instance.Dock);
                        new_Label.ColumnSpan = instance.ColumnSpan;
                        new_Label.RowSpan = instance.RowSpan;
                        new_Label.Text = TagList.ContainsKey("Text") ? TagList["Text"] : string.Empty;
                        propertyGrid1.SelectedObject = new_Label;
                        label1.Enabled = true;
                        break;
                    case "rbCheckBox":
                        new_CheckBox.GroupID = instance.UserDefineGroupID;
                        new_CheckBox.ID = instance.ControlID;
                        new_CheckBox.Column = instance.LayoutColumn;
                        new_CheckBox.Row = instance.LayoutRow;
                        new_CheckBox.Anchor = SystemFunction.SetAnchorStyles(instance.Anchor);
                        new_CheckBox.Dock = SystemFunction.SetDockStyle(instance.Dock);
                        new_CheckBox.ColumnSpan = instance.ColumnSpan;
                        new_CheckBox.RowSpan = instance.RowSpan;
                        new_CheckBox.Checked = TagList.ContainsKey("Checked") ? Convert.ToBoolean(TagList["Checked"]) : false;
                        new_CheckBox.Text = TagList.ContainsKey("Text") ? TagList["Text"] : string.Empty;
                        new_CheckBox.BindingID = new_CheckBox.ID;
                        new_CheckBox.ParameterName = TagList.ContainsKey("ParameterName") ? TagList["ParameterName"] : string.Empty;
                        propertyGrid1.SelectedObject = new_CheckBox;
                        checkBox1.Enabled = true;
                        break;
                    case "rbTextBox":
                        new_TextBox.GroupID = instance.UserDefineGroupID;
                        new_TextBox.ID = instance.ControlID;
                        new_TextBox.Column = instance.LayoutColumn;
                        new_TextBox.Row = instance.LayoutRow;
                        new_TextBox.Anchor = SystemFunction.SetAnchorStyles(instance.Anchor);
                        new_TextBox.Dock = SystemFunction.SetDockStyle(instance.Dock);
                        new_TextBox.ColumnSpan = instance.ColumnSpan;
                        new_TextBox.RowSpan = instance.RowSpan;
                        new_TextBox.Text = TagList.ContainsKey("Text") ? TagList["Text"] : string.Empty;
                        //new_TextBox.BindngLabel = TagList.ContainsKey("BindngLabel") ? TagList["BindngLabel"] : string.Empty;
                        new_TextBox.BindingID = TagList.ContainsKey("BindingID") ? Guid.Parse(TagList["BindingID"]) : Guid.Empty;
                        new_TextBox.ParameterName = TagList.ContainsKey("ParameterName") ? TagList["ParameterName"] : string.Empty;
                        propertyGrid1.SelectedObject = new_TextBox;
                        textBox1.Enabled = true;
                        break;
                    case "rbDateTimePicker":
                        new_DateTimePicker.GroupID = instance.UserDefineGroupID;
                        new_DateTimePicker.ID = instance.ControlID;
                        new_DateTimePicker.Column = instance.LayoutColumn;
                        new_DateTimePicker.Row = instance.LayoutRow;
                        new_DateTimePicker.Anchor = SystemFunction.SetAnchorStyles(instance.Anchor);
                        new_DateTimePicker.Dock = SystemFunction.SetDockStyle(instance.Dock);
                        new_DateTimePicker.ColumnSpan = instance.ColumnSpan;
                        new_DateTimePicker.RowSpan = instance.RowSpan;
                        //new_DateTimePicker.Value = TagList.ContainsKey("DateTimeValue") ? Convert.ToDateTime(TagList["DateTimeValue"]) : DateTime.Now;
                        if (TagList.ContainsKey("DateTimeValue"))
                        {
                            DateTime dateTime;
                            new_DateTimePicker.DateTimeValue = DateTime.TryParse(TagList["DateTimeValue"], out dateTime) ? dateTime : (DateTime?)null;
                        }
                        //new_DateTimePicker.BindngLabel = TagList.ContainsKey("BindngLabel") ? TagList["BindngLabel"] : string.Empty;
                        new_DateTimePicker.BindingID = TagList.ContainsKey("BindingID") ? Guid.Parse(TagList["BindingID"]) : Guid.Empty;
                        new_DateTimePicker.ParameterName = TagList.ContainsKey("ParameterName") ? TagList["ParameterName"] : string.Empty;
                        propertyGrid1.SelectedObject = new_DateTimePicker;
                        dateTimePicker1.Enabled = true;
                        break;
                    case "rbComboBox":
                        new_ComboBox.GroupID = instance.UserDefineGroupID;
                        new_ComboBox.ID = instance.ControlID;
                        new_ComboBox.Column = instance.LayoutColumn;
                        new_ComboBox.Row = instance.LayoutRow;
                        new_ComboBox.Anchor = SystemFunction.SetAnchorStyles(instance.Anchor);
                        new_ComboBox.Dock = SystemFunction.SetDockStyle(instance.Dock);
                        new_ComboBox.ColumnSpan = instance.ColumnSpan;
                        new_ComboBox.RowSpan = instance.RowSpan;
                        new_ComboBox.SourceID = TagList.ContainsKey("SourceID") ? Guid.Parse(TagList["SourceID"]) : Guid.Empty;
                        var UDS = db.UserDefineSource.Where(p => p.SourceID.Equals(new_ComboBox.SourceID)).FirstOrDefault();
                        if (UDS != null)
                        {
                            new_ComboBox.SourceType = UDS.SourceType;
                            new_ComboBox.DataSource = UDS.SourceName;
                            new_ComboBox.ValueMember = UDS.ValueMember;
                            new_ComboBox.DisplayMember = UDS.DisplayMember;
                            new_ComboBox.SourceScript = UDS.SourceScript;
                            new_ComboBox.SortField = UDS.SortFeild;
                            new_ComboBox.WhereField = UDS.WhereFeild;
                            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetUDFSourcebySourceScript(UDS.SourceScript, UDS.ValueMember, UDS.DisplayMember), true, true, true, true);
                        }

                        //new_ComboBox.BindngLabel = TagList.ContainsKey("BindngLabel") ? TagList["BindngLabel"] : string.Empty;
                        new_ComboBox.BindingID = TagList.ContainsKey("BindingID") ? Guid.Parse(TagList["BindingID"]) : Guid.Empty;
                        new_ComboBox.ParameterName = TagList.ContainsKey("ParameterName") ? TagList["ParameterName"] : string.Empty;
                        propertyGrid1.SelectedObject = new_ComboBox;
                        comboBox1.Enabled = true;
                        break;
                    case "rbNumericUpDown":
                        new_NumericUpDown.GroupID = instance.UserDefineGroupID;
                        new_NumericUpDown.ID = instance.ControlID;
                        new_NumericUpDown.Column = instance.LayoutColumn;
                        new_NumericUpDown.Row = instance.LayoutRow;
                        new_NumericUpDown.Anchor = SystemFunction.SetAnchorStyles(instance.Anchor);
                        new_NumericUpDown.Dock = SystemFunction.SetDockStyle(instance.Dock);
                        new_NumericUpDown.ColumnSpan = instance.ColumnSpan;
                        new_NumericUpDown.RowSpan = instance.RowSpan;
                        new_NumericUpDown.Maximum = TagList.ContainsKey("Maximum") ? Convert.ToDecimal(TagList["Maximum"]) : 100;
                        new_NumericUpDown.Minimum = TagList.ContainsKey("Minimum") ? Convert.ToDecimal(TagList["Minimum"]) : 0;
                        new_NumericUpDown.DecimalPlaces = TagList.ContainsKey("DecimalPlaces") ? Convert.ToInt32(TagList["DecimalPlaces"]) : 0;
                        new_NumericUpDown.NumericValue = TagList.ContainsKey("NumericValue") ? Convert.ToDecimal(TagList["NumericValue"]) : 0;
                        //new_NumericUpDown.BindngLabel = TagList.ContainsKey("BindngLabel") ? TagList["BindngLabel"] : string.Empty;
                        new_NumericUpDown.BindingID = TagList.ContainsKey("BindingID") ? Guid.Parse(TagList["BindingID"]) : Guid.Empty;
                        new_NumericUpDown.ParameterName = TagList.ContainsKey("ParameterName") ? TagList["ParameterName"] : string.Empty;
                        propertyGrid1.SelectedObject = new_NumericUpDown;
                        numericUpDown1.Enabled = true;
                        break;
                    default:
                        propertyGrid1.SelectedObject = null;
                        propertyGrid1.Enabled = false;
                        lbRemoveAt.Enabled = true;
                        break;
                }
            }
        }
        #endregion

        #region 控制項屬性設定
        class LabelControl
        {
            [Browsable(false)]
            public string Tag { set; get; }

            #region 元件屬性:GroupID ID Name(停用) Anchor Dock ColumnSpan RowSpan
            private Guid _groupID;
            [Category("a.元件"), DisplayName("GroupID"), Browsable(false)] //[ReadOnly(true)]
            public Guid GroupID
            {
                get { return _groupID; }
                set { _groupID = value; }
            }

            private Guid _id;
            [Category("a.元件"), DisplayName("ID"), Browsable(false)] //[ReadOnly(true)]
            public Guid ID
            {
                get { return _id; }
                set { _id = value; }
            }

            //private string _name;// = Guid.NewGuid();
            //[Category("a.元件"), DisplayName("名稱"), ReadOnly(true)]
            //[Description("給予元件一個名稱讓系統分辨它是誰,建議使用英文命名.")]
            //public string Name
            //{
            //    get { return _name; }
            //    set { _name = value; }
            //} 

            private AnchorStyles _anchor = AnchorStyles.Right;
            [Category("a.元件"), DisplayName("錨定")]//[ReadOnly(true)]
            [Description("設定控制項繫結至的容器邊緣.")]
            public AnchorStyles Anchor
            {
                get { return _anchor; }
                set { _anchor = value; }
            }

            private DockStyle _dock = DockStyle.None;
            [Category("a.元件"), DisplayName("停駐")]//[ReadOnly(true)]
            [Description("設定停駐在其父控制項的控制項框線.")]
            public DockStyle Dock
            {
                get { return _dock; }
                set { _dock = value; }
            }

            public int Column;
            private int _ColumnSpan = 1;
            [Category("a.元件"), DisplayName("資料行範圍")]//[ReadOnly(true)]
            [Description("設定此控制項會向右展幾格.")]
            public int ColumnSpan
            {
                get { return _ColumnSpan; }
                set
                {
                    value = CheckLayoutRange(_groupID, _id, Column, Row, value, _rowSpan, true);
                    _ColumnSpan = value;
                }
            }

            public int Row;
            private int _rowSpan = 1;
            [Category("a.元件"), DisplayName("資料列範圍")]//[ReadOnly(true)]
            [Description("設定此控制項會向下展幾格.")]
            public int RowSpan
            {
                get { return _rowSpan; }
                set
                {
                    value = CheckLayoutRange(_groupID, _id, Column, Row, _ColumnSpan, value, false);
                    _rowSpan = value;
                }
            }
            #endregion

            #region 標籤屬性:Text
            private string _text = "b.標籤";
            [Category("b.標籤"), DisplayName("顯示文字")]
            [Description("顯示在畫面上的文字.")]
            public string Text
            {
                get { return _text; }
                set { _text = value; }
            } 
            #endregion
        }

        class CheckBoxControl
        {
            [Browsable(false)]
            public string Tag { set; get; }

            #region 元件屬性:GroupID ID Name(停用) Anchor Dock ColumnSpan RowSpan
            private Guid _groupID;
            [Category("a.元件"), DisplayName("GroupID"), Browsable(false)] //[ReadOnly(true)]
            public Guid GroupID
            {
                get { return _groupID; }
                set { _groupID = value; }
            }

            private Guid _id;
            [Category("a.元件"), DisplayName("ID"), Browsable(false)]//[ReadOnly(true)]
            public Guid ID
            {
                get { return _id; }
                set { _id = value; }
            }

            //private string _name;// = Guid.NewGuid();
            //[Category("a.元件"), DisplayName("名稱"), ReadOnly(true)]
            //[Description("給予元件一個名稱讓系統分辨它是誰,建議使用英文命名.")]
            //public string Name
            //{
            //    get { return _name; }
            //    set { _name = value; }
            //}

            private AnchorStyles _anchor = AnchorStyles.Left;
            [Category("a.元件"), DisplayName("錨定")]//[ReadOnly(true)]
            [Description("設定控制項繫結至的容器邊緣.")]
            public AnchorStyles Anchor
            {
                get { return _anchor; }
                set { _anchor = value; }
            }

            private DockStyle _dock = DockStyle.None;
            [Category("a.元件"), DisplayName("停駐")]//[ReadOnly(true)]
            [Description("設定停駐在其父控制項的控制項框線.")]
            public DockStyle Dock
            {
                get { return _dock; }
                set { _dock = value; }
            }

            public int Column;
            private int _ColumnSpan = 1;
            [Category("a.元件"), DisplayName("資料行範圍")]//[ReadOnly(true)]
            [Description("設定此控制項會向右展幾格.")]
            public int ColumnSpan
            {
                get { return _ColumnSpan; }
                set
                {
                    value = CheckLayoutRange(_groupID, _id, Column, Row, value, _rowSpan, true);
                    _ColumnSpan = value;
                }
            }

            public int Row;
            private int _rowSpan = 1;
            [Category("a.元件"), DisplayName("資料列範圍")]//[ReadOnly(true)]
            [Description("設定此控制項會向下展幾格.")]
            public int RowSpan
            {
                get { return _rowSpan; }
                set
                {
                    value = CheckLayoutRange(_groupID, _id, Column, Row, _ColumnSpan, value, false);
                    _rowSpan = value;
                }
            }
            #endregion

            #region 標籤屬性:Text
            private string _text = "勾選項目";
            [Category("b.標籤"), DisplayName("顯示文字")]
            [Description("顯示在畫面上的文字.")]
            public string Text
            {
                get { return _text; }
                set { _text = value; }
            }
            #endregion

            #region 設定值屬性:Checked
            private bool _checked = false;
            [Category("c.設定值"), DisplayName("預設勾選")]
            [Description("當頁面開啟時,預設為勾選或不勾選.")]
            public bool Checked
            {
                get { return _checked; }
                set { _checked = value; }
            }
            #endregion

            #region 聯繫屬性:BindngLabel BindingID ParameterName
            private string _bindngLabel = "";
            [Category("d.聯繫"), DisplayName("聯繫標籤元件")]
            [Description("使用匯入功能時所聯繫標籤名稱.")]
            [TypeConverter(typeof(BindingLabelClassConverter)), Browsable(false)]
            public string BindngLabel
            {
                get { return _bindngLabel; }
                set
                {
                    var guid = CodeFunction.GetUDFLabelIDbyPorpValue(_groupID, "Label", "Text", value);
                    if (!_bindngID.Equals(guid))
                        _bindngID = guid;
                    _bindngLabel = value;
                }
            }

            private Guid _bindngID = Guid.Empty;
            [Category("d.聯繫"), DisplayName("聯繫標籤元件ID"), Browsable(false)]
            [Description("使用匯入功能時所聯繫標籤ID.")]
            public Guid BindingID
            {
                get { return _bindngID; }
                set
                {
                    string TempStr = CodeFunction.GetUDFControlPropValuebyID(_groupID, value, "Text");
                    if (TempStr != _bindngLabel)
                        _bindngLabel = TempStr;
                    _bindngID = value;
                }
            }

            private string _parameterName = string.Empty;
            [Category("d.聯繫"), DisplayName("參數命名"), Browsable(true)]
            [Description("用於程式開發時系統抓取參數的依據.")]
            public string ParameterName
            {
                get { return _parameterName; }
                set { _parameterName = value; }
            }
            #endregion
        }

        class TextBoxControl
        {
            [Browsable(false)]
            public string Tag { set; get; }

            #region 元件屬性:GroupID ID Name(停用) Anchor Dock ColumnSpan RowSpan
            private Guid _groupID;
            [Category("a.元件"), DisplayName("GroupID"), Browsable(false)] //[ReadOnly(true)]
            public Guid GroupID
            {
                get { return _groupID; }
                set { _groupID = value; }
            }

            private Guid _id;
            [Category("a.元件"), DisplayName("ID"), Browsable(false)]//[ReadOnly(true)]
            public Guid ID
            {
                get { return _id; }
                set { _id = value; }
            }

            //private string _name;// = Guid.NewGuid();
            //[Category("a.元件"), DisplayName("名稱"), ReadOnly(true)]
            //[Description("給予元件一個名稱讓系統分辨它是誰,建議使用英文命名.")]
            //public string Name
            //{
            //    get { return _name; }
            //    set { _name = value; }
            //}

            private AnchorStyles _anchor = AnchorStyles.Left;
            [Category("a.元件"), DisplayName("錨定")]//[ReadOnly(true)]
            [Description("設定控制項繫結至的容器邊緣.")]
            public AnchorStyles Anchor
            {
                get { return _anchor; }
                set { _anchor = value; }
            }

            private DockStyle _dock = DockStyle.None;
            [Category("a.元件"), DisplayName("停駐")]//[ReadOnly(true)]
            [Description("設定停駐在其父控制項的控制項框線.")]
            public DockStyle Dock
            {
                get { return _dock; }
                set { _dock = value; }
            }

            public int Column;
            private int _ColumnSpan = 1;
            [Category("a.元件"), DisplayName("資料行範圍")]//[ReadOnly(true)]
            [Description("設定此控制項會向右展幾格.")]
            public int ColumnSpan
            {
                get { return _ColumnSpan; }
                set
                {
                    value = CheckLayoutRange(_groupID, _id, Column, Row, value, _rowSpan, true);
                    _ColumnSpan = value;
                }
            }

            public int Row;
            private int _rowSpan = 1;
            [Category("a.元件"), DisplayName("資料列範圍")]//[ReadOnly(true)]
            [Description("設定此控制項會向下展幾格.")]
            public int RowSpan
            {
                get { return _rowSpan; }
                set
                {
                    value = CheckLayoutRange(_groupID, _id, Column, Row, _ColumnSpan, value, false);
                    _rowSpan = value;
                }
            }
            #endregion

            #region 設定值屬性:Text
            private string _text = "";
            [Category("c.設定值"), DisplayName("預設內容")]
            [Description("當頁面開啟時,預設填入的內容.")]
            public string Text
            {
                get { return _text; }
                set { _text = value; }
            }
            #endregion

            #region 聯繫屬性:BindngLabel BindingID ParameterName
            private string _bindngLabel = "";
            [Category("d.聯繫"), DisplayName("聯繫標籤元件")]
            [Description("使用匯入功能時所聯繫標籤名稱.")]
            [TypeConverter(typeof(BindingLabelClassConverter))]
            public string BindngLabel
            {
                get { return _bindngLabel; }
                set
                {
                    var guid = CodeFunction.GetUDFLabelIDbyPorpValue(_groupID, "Label", "Text", value);
                    if (!_bindngID.Equals(guid))
                        _bindngID = guid;
                    _bindngLabel = value;
                }
            }

            private Guid _bindngID = Guid.Empty;
            [Category("d.聯繫"), DisplayName("聯繫標籤元件ID"), Browsable(false)]
            [Description("使用匯入功能時所聯繫標籤ID.")]
            public Guid BindingID
            {
                get { return _bindngID; }
                set
                {
                    string TempStr = CodeFunction.GetUDFControlPropValuebyID(_groupID, value, "Text");
                    if (TempStr != _bindngLabel)
                        _bindngLabel = TempStr;
                    _bindngID = value;
                }
            }

            private string _parameterName = string.Empty;
            [Category("d.聯繫"), DisplayName("參數命名"), Browsable(true)]
            [Description("用於程式開發時系統抓取參數的依據.")]
            public string ParameterName
            {
                get { return _parameterName; }
                set { _parameterName = value; }
            }
            #endregion
        }

        class DateTimePickerControl
        {
            [Browsable(false)]
            public string Tag { set; get; }

            #region 元件屬性:GroupID ID Name(停用) Anchor Dock ColumnSpan RowSpan
            private Guid _groupID;
            [Category("a.元件"), DisplayName("GroupID"), Browsable(false)] //[ReadOnly(true)]
            public Guid GroupID
            {
                get { return _groupID; }
                set { _groupID = value; }
            }

            private Guid _id;
            [Category("a.元件"), DisplayName("ID"), Browsable(false)]//[ReadOnly(true)]
            public Guid ID
            {
                get { return _id; }
                set { _id = value; }
            }

            //private string _name;// = Guid.NewGuid();
            //[Category("a.元件"), DisplayName("名稱"), ReadOnly(true)]
            //[Description("給予元件一個名稱讓系統分辨它是誰,建議使用英文命名.")]
            //public string Name
            //{
            //    get { return _name; }
            //    set { _name = value; }
            //}

            private AnchorStyles _anchor = AnchorStyles.Left;
            [Category("a.元件"), DisplayName("錨定")]//[ReadOnly(true)]
            [Description("設定控制項繫結至的容器邊緣.")]
            public AnchorStyles Anchor
            {
                get { return _anchor; }
                set { _anchor = value; }
            }

            private DockStyle _dock = DockStyle.None;
            [Category("a.元件"), DisplayName("停駐")]//[ReadOnly(true)]
            [Description("設定停駐在其父控制項的控制項框線.")]
            public DockStyle Dock
            {
                get { return _dock; }
                set { _dock = value; }
            }

            public int Column;
            private int _ColumnSpan = 1;
            [Category("a.元件"), DisplayName("資料行範圍")]//[ReadOnly(true)]
            [Description("設定此控制項會向右展幾格.")]
            public int ColumnSpan
            {
                get { return _ColumnSpan; }
                set
                {
                    value = CheckLayoutRange(_groupID, _id, Column, Row, value, _rowSpan, true);
                    _ColumnSpan = value;
                }
            }

            public int Row;
            private int _rowSpan = 1;
            [Category("a.元件"), DisplayName("資料列範圍")]//[ReadOnly(true)]
            [Description("設定此控制項會向下展幾格.")]
            public int RowSpan
            {
                get { return _rowSpan; }
                set
                {
                    value = CheckLayoutRange(_groupID, _id, Column, Row, _ColumnSpan, value, false);
                    _rowSpan = value;
                }
            }
            #endregion

            #region 設定值屬性:DateTimeValue
            public bool Checked = false;
            private DateTime? _dateTimeValue;// = DateTime.Today;
            [Category("c.設定值"), DisplayName("預設時間")]
            [Description("當頁面開啟時會預設帶入的時間")]
            public DateTime? DateTimeValue
            {
                get { return _dateTimeValue; }
                set
                {
                    Checked = value != null ? true : false;
                    _dateTimeValue = value;
                }
            }
            #endregion

            #region 聯繫屬性:BindngLabel BindingID ParameterName
            private string _bindngLabel = "";
            [Category("d.聯繫"), DisplayName("聯繫標籤元件")]
            [Description("使用匯入功能時所聯繫標籤名稱.")]
            [TypeConverter(typeof(BindingLabelClassConverter))]
            public string BindngLabel
            {
                get { return _bindngLabel; }
                set
                {
                    var guid = CodeFunction.GetUDFLabelIDbyPorpValue(_groupID, "Label", "Text", value);
                    if (!_bindngID.Equals(guid))
                        _bindngID = guid;
                    _bindngLabel = value;
                }
            }

            private Guid _bindngID = Guid.Empty;
            [Category("d.聯繫"), DisplayName("聯繫標籤元件ID"), Browsable(false)]
            [Description("使用匯入功能時所聯繫標籤ID.")]
            public Guid BindingID
            {
                get { return _bindngID; }
                set
                {
                    string TempStr = CodeFunction.GetUDFControlPropValuebyID(_groupID, value, "Text");
                    if (TempStr != _bindngLabel)
                        _bindngLabel = TempStr;
                    _bindngID = value;
                }
            }

            private string _parameterName = string.Empty;
            [Category("d.聯繫"), DisplayName("參數命名"), Browsable(true)]
            [Description("用於程式開發時系統抓取參數的依據.")]
            public string ParameterName
            {
                get { return _parameterName; }
                set { _parameterName = value; }
            }
            #endregion
        }

        class ComboBoxControl
        {
            [Browsable(false)]
            public string Tag { set; get; }

            #region 元件屬性:GroupID ID Name(停用) Anchor Dock ColumnSpan RowSpan
            private Guid _groupID;
            [Category("a.元件"), DisplayName("GroupID"), Browsable(false)] //[ReadOnly(true)]
            public Guid GroupID
            {
                get { return _groupID; }
                set { _groupID = value; }
            }

            private Guid _id;
            [Category("a.元件"), DisplayName("ID"), Browsable(false)]//[ReadOnly(true)]
            public Guid ID
            {
                get { return _id; }
                set { _id = value; }
            }

            //private string _name;// = Guid.NewGuid();
            //[Category("a.元件"), DisplayName("名稱"), ReadOnly(true)]
            //[Description("給予元件一個名稱讓系統分辨它是誰,建議使用英文命名")]
            //public string Name
            //{
            //    get { return _name; }
            //    set { _name = value; }
            //}

            private AnchorStyles _anchor = AnchorStyles.Left;
            [Category("a.元件"), DisplayName("錨定")]
            //[ReadOnly(true)]
            [Description("設定控制項繫結至的容器邊緣.")]
            public AnchorStyles Anchor
            {
                get { return _anchor; }
                set { _anchor = value; }
            }

            private DockStyle _dock = DockStyle.None;
            [Category("a.元件"), DisplayName("停駐")]//[ReadOnly(true)]
            [Description("設定停駐在其父控制項的控制項框線.")]
            public DockStyle Dock
            {
                get { return _dock; }
                set { _dock = value; }
            }

            public int Column;
            private int _ColumnSpan = 1;
            [Category("a.元件"), DisplayName("資料行範圍")]//[ReadOnly(true)]
            [Description("設定此控制項會向右展幾格.")]
            public int ColumnSpan
            {
                get { return _ColumnSpan; }
                set
                {
                    value = CheckLayoutRange(_groupID, _id, Column, Row, value, _rowSpan, true);
                    _ColumnSpan = value;
                }
            }

            public int Row;
            private int _rowSpan = 1;
            [Category("a.元件"), DisplayName("資料列範圍")]//[ReadOnly(true)]
            [Description("設定此控制項會向下展幾格.")]
            public int RowSpan
            {
                get { return _rowSpan; }
                set
                {
                    value = CheckLayoutRange(_groupID, _id, Column, Row, _ColumnSpan, value, false);
                    _rowSpan = value;
                }
            }
            #endregion

            #region 標籤屬性:Text(停用)
            //private string _text = "";
            //[Category("b.標籤"), DisplayName("顯示文字")]
            //[Description("顯示在畫面上的文字")]
            //public string Text
            //{
            //    get { return _text; }
            //    set { _text = value; }
            //} 
            #endregion

            #region 資料屬性:SelectedValue(停用) ValueMember DisplayMember SourceType DataSource SortField WhereField
            //private string _selectedValue = "";
            //[Category("c.資料"), DisplayName("預設選定的內容")]
            //[Description("資料內容以MTCode為主，以類別分類，需新增資料時可以至'系統維護->系統代碼設'定新增")]
            //public string SelectedValue
            //{
            //    get { return _selectedValue; }
            //    set { _selectedValue = value; }
            //}
            private string _sourceType = "MTCODE";
            [Category("c.資料"), DisplayName("來源型態"), Browsable(true)]//[ReadOnly(true)]
            [Description("選擇資料來源的型態")]
            [TypeConverter(typeof(SourceTypeClassConverter))]
            public string SourceType
            {
                get { return _sourceType; }
                set
                {
                    if (_sourceType != value)
                    {
                        _dataSource = string.Empty;
                        SourceID = Guid.Empty;
                        Tag = string.Empty;
                        DataSource = string.Empty;
                        SortField = string.Empty;
                        WhereField = string.Empty;
                        if (value == "MTCODE")
                        {
                            ValueMember = "CODE";
                            DisplayMember = "NAME";
                        }
                        else
                        {
                            ValueMember = string.Empty;
                            DisplayMember = string.Empty;
                        }
                    }
                    _sourceType = value;
                }
            }

            public Guid SourceID = Guid.Empty;
            private string _dataSource = "";
            public string SourceScript = "";
            [Category("c.資料"), DisplayName("資料表來源")]
            [Description("當來源以MTCode為主時，以類別分類，需新增資料時可以至'系統維護->系統代碼設定'新增")]
            [TypeConverter(typeof(DataSourceClassConverter))]
            public string DataSource
            {
                get { return _dataSource; }
                set
                {
                    if (_dataSource != value)
                    {
                        SourceID = Guid.Empty;
                        if (_sourceType == "MTCODE")
                        {
                            Dictionary<string, string> TagList = SetSorceParamters(_valueMember, _displayMember, _sourceType, value, _sortField, _whereField);
                            Tag = JsonConvert.SerializeObject(TagList);
                        }
                        else
                        {
                            ValueMember = string.Empty;
                            DisplayMember = string.Empty;
                        }
                        SortField = string.Empty;
                        WhereField = string.Empty;
                    }
                    _dataSource = value;
                }
            }

            private string _valueMember = "CODE";
            [Category("c.資料"), DisplayName("實際存取的值"), Browsable(true)]//[ReadOnly(true)]
            [Description("實際存取的屬性")]
            [TypeConverter(typeof(TableColumnClassConverter))]
            public string ValueMember
            {
                get { return _valueMember; }
                set
                {
                    if (_valueMember != value)
                    {
                        SourceID = Guid.Empty;
                        Dictionary<string, string> TagList = SetSorceParamters(value, _displayMember, _sourceType, _dataSource, _sortField, _whereField);
                        Tag = JsonConvert.SerializeObject(TagList);
                    }
                    _valueMember = value;
                }
            }

            private string _displayMember = "NAME";
            [Category("c.資料"), DisplayName("用於顯示的值"), Browsable(true)]//[ReadOnly(true)]
            [Description("實際顯示的屬性")]
            //[TypeConverter(typeof(TableColumnClassConverter))]
            [Editor(typeof(CheckedListBoxUITypeEditor), typeof(UITypeEditor))]
            public string DisplayMember
            {
                get { return _displayMember; }
                set
                {
                    if (_displayMember != value)
                    {
                        SourceID = Guid.Empty;
                        Dictionary<string, string> TagList = SetSorceParamters(_valueMember, value, _sourceType, _dataSource, _sortField, _whereField);
                        Tag = JsonConvert.SerializeObject(TagList);
                    }
                    _displayMember = value;
                }
            }

            private string _sortField = string.Empty;
            [Category("c.資料"), DisplayName("資料排序"), Browsable(true)]//[ReadOnly(true)]
            [Description("對應SQL Order by之後的欄位")]
            //[TypeConverter(typeof(TableColumnClassConverter))]
            [Editor(typeof(CheckedListBoxUITypeEditor), typeof(UITypeEditor))]
            public string SortField
            {
                get { return _sortField; }
                set
                {
                    if (_sortField != value)
                    {
                        SourceID = Guid.Empty;
                        Dictionary<string, string> TagList = SetSorceParamters(_valueMember, _displayMember, _sourceType, _dataSource, value, _whereField);
                        Tag = JsonConvert.SerializeObject(TagList);
                    }
                    _sortField = value;
                }
            }
            private string _whereField = string.Empty;
            [Category("c.資料"), DisplayName("篩選條件"), Browsable(true)]//[ReadOnly(true)]
            [Description("對應SQL WHERE之後的語法")]
            public string WhereField
            {
                get { return _whereField; }
                set
                {
                    if (_whereField != value)
                    {
                        SourceID = Guid.Empty;
                        Dictionary<string, string> TagList = SetSorceParamters(_valueMember, _displayMember, _sourceType, _dataSource, _sortField, value);
                        Tag = JsonConvert.SerializeObject(TagList);
                    }
                    _whereField = value;
                }
            }
            private Dictionary<string, string> SetSorceParamters(string valueMember, string displayMember, string sourceType, string dataSource, string sortField, string whereField)
            {
                Dictionary<string, string> TagList = new Dictionary<string, string>();
                TagList.Add("ValueMember", valueMember);
                TagList.Add("DisplayMember", displayMember);
                if (_sourceType == "MTCODE")
                    TagList.Add("SourceScript", string.Format("Select {0},{1} from {2} Where Category = '{3}'", valueMember, displayMember, sourceType, dataSource));
                else
                    TagList.Add("SourceScript", string.Format("Select {0},{1} from {2}", valueMember, displayMember, dataSource));
                if (!string.IsNullOrWhiteSpace(whereField))
                    TagList["SourceScript"] += " Where " + whereField;
                if (!string.IsNullOrWhiteSpace(sortField))
                    TagList["SourceScript"] += " Order By " + sortField;
                SourceScript = TagList["SourceScript"];
                return TagList;
            }
            #endregion

            #region 聯繫屬性:BindngLabel BindingID ParameterName
            private string _bindngLabel = "";
            [Category("d.聯繫"), DisplayName("聯繫標籤元件")]
            [Description("使用匯入功能時所聯繫標籤名稱.")]
            [TypeConverter(typeof(BindingLabelClassConverter))]
            public string BindngLabel
            {
                get { return _bindngLabel; }
                set
                {
                    var guid = CodeFunction.GetUDFLabelIDbyPorpValue(_groupID, "Label", "Text", value);
                    if (!_bindngID.Equals(guid))
                        _bindngID = guid;
                    _bindngLabel = value;
                }
            }

            private Guid _bindngID = Guid.Empty;
            [Category("d.聯繫"), DisplayName("聯繫標籤元件ID"), Browsable(false)]
            [Description("使用匯入功能時所聯繫標籤ID.")]
            public Guid BindingID
            {
                get { return _bindngID; }
                set
                {
                    string TempStr = CodeFunction.GetUDFControlPropValuebyID(_groupID, value, "Text");
                    if (TempStr != _bindngLabel)
                        _bindngLabel = TempStr;
                    _bindngID = value;
                }
            }

            private string _parameterName = string.Empty;
            [Category("d.聯繫"), DisplayName("參數命名"), Browsable(true)]
            [Description("用於程式開發時系統抓取參數的依據.")]
            public string ParameterName
            {
                get { return _parameterName; }
                set { _parameterName = value; }
            }
            #endregion
        }

        class NumericUpDownControl
        {
            [Browsable(false)]
            public string Tag { set; get; }

            #region 元件屬性:GroupID ID Name(停用) Anchor Dock ColumnSpan RowSpan
            private Guid _groupID;
            [Category("a.元件"), DisplayName("GroupID"), Browsable(false)] //[ReadOnly(true)]
            public Guid GroupID
            {
                get { return _groupID; }
                set { _groupID = value; }
            }

            private Guid _id;
            [Category("a.元件"), DisplayName("ID"), Browsable(false)]//[ReadOnly(true)]
            public Guid ID
            {
                get { return _id; }
                set { _id = value; }
            }

            //private string _name;// = Guid.NewGuid();
            //[Category("a.元件"), DisplayName("名稱"), ReadOnly(true)]
            //[Description("給予元件一個名稱讓系統分辨它是誰,建議使用英文命名.")]
            //public string Name
            //{
            //    get { return _name; }
            //    set { _name = value; }
            //}

            private AnchorStyles _anchor = AnchorStyles.Left;
            [Category("a.元件"), DisplayName("錨定")]//[ReadOnly(true)]
            [Description("設定控制項繫結至的容器邊緣.")]
            public AnchorStyles Anchor
            {
                get { return _anchor; }
                set { _anchor = value; }
            }

            private DockStyle _dock = DockStyle.None;
            [Category("a.元件"), DisplayName("停駐")]//[ReadOnly(true)]
            [Description("設定停駐在其父控制項的控制項框線.")]
            public DockStyle Dock
            {
                get { return _dock; }
                set { _dock = value; }
            }

            public int Column;
            private int _ColumnSpan = 1;
            [Category("a.元件"), DisplayName("資料行範圍")]//[ReadOnly(true)]
            [Description("設定此控制項會向右展幾格.")]
            public int ColumnSpan
            {
                get { return _ColumnSpan; }
                set
                {
                    value = CheckLayoutRange(_groupID, _id, Column, Row, value, _rowSpan, true);
                    _ColumnSpan = value;
                }
            }

            public int Row;
            private int _rowSpan = 1;
            [Category("a.元件"), DisplayName("資料列範圍")]//[ReadOnly(true)]
            [Description("設定此控制項會向下展幾格.")]
            public int RowSpan
            {
                get { return _rowSpan; }
                set
                {
                    value = CheckLayoutRange(_groupID, _id, Column, Row, _ColumnSpan, value, false);
                    _rowSpan = value;
                }
            }
            #endregion

            #region 設定值屬性:Maximum Minimum DecimalPlaces NumericValue
            private decimal _maximum = 1000;
            [Category("c.設定值"), DisplayName("最大值")]
            [Description("表示數值按鈕的最大值")]
            public Decimal Maximum
            {
                get { return _maximum; }
                set { _maximum = value; }
            }

            private decimal _minimum = 0;
            [Category("c.設定值"), DisplayName("最小值")]
            [Description("表示數值按鈕的最小值")]
            public Decimal Minimum
            {
                get { return _minimum; }
                set { _minimum = value; }
            }

            private int _decimalPlaces = 2;
            [Category("c.設定值"), DisplayName("小數位數")]
            [Description("表示要顯示的小數位數")]
            public int DecimalPlaces
            {
                get { return _decimalPlaces; }
                set
                {
                    if (value > 29)
                        value = 29;
                    else if (value < 0)
                        value = 0;
                    _decimalPlaces = value;
                }
            }

            private decimal _numericValue = 0.00M;
            [Category("c.設定值"), DisplayName("預設數值")]
            [Description("當頁面開啟時會預設帶入的數值")]
            public Decimal NumericValue
            {
                get { return _numericValue; }
                set
                {
                    if (value > _maximum)
                        value = _maximum;
                    else if (value < _minimum)
                        value = _minimum;
                    _numericValue = decimal.Round(value, _decimalPlaces);
                    //_value = value;
                }
            }
            #endregion

            #region 聯繫屬性:BindngLabel BindingID ParameterName
            private string _bindngLabel = "";
            [Category("d.聯繫"), DisplayName("聯繫標籤元件")]
            [Description("使用匯入功能時所聯繫標籤名稱.")]
            [TypeConverter(typeof(BindingLabelClassConverter))]
            public string BindngLabel
            {
                get { return _bindngLabel; }
                set
                {
                    var guid = CodeFunction.GetUDFLabelIDbyPorpValue(_groupID, "Label", "Text", value);
                    if (!_bindngID.Equals(guid))
                        _bindngID = guid;
                    _bindngLabel = value;
                }
            }

            private Guid _bindngID = Guid.Empty;
            [Category("d.聯繫"), DisplayName("聯繫標籤元件ID"), Browsable(false)]
            [Description("使用匯入功能時所聯繫標籤ID.")]
            public Guid BindingID
            {
                get { return _bindngID; }
                set
                {
                    string TempStr = CodeFunction.GetUDFControlPropValuebyID(_groupID, value, "Text");
                    if (TempStr != _bindngLabel)
                        _bindngLabel = TempStr;
                    _bindngID = value;
                }
            }

            private string _parameterName = string.Empty;
            [Category("d.聯繫"), DisplayName("參數命名"), Browsable(true)]
            [Description("用於程式開發時系統抓取參數的依據.")]
            public string ParameterName
            {
                get { return _parameterName; }
                set { _parameterName = value; }
            }
            #endregion
        }
        /// <summary>
        /// 調整配置大小的檢核
        /// </summary>
        /// <param name="GroupID"></param>
        /// <param name="ControlID"></param>
        /// <param name="culoum"></param>
        /// <param name="row"></param>
        /// <param name="culoumSpan"></param>
        /// <param name="rowSpan"></param>
        /// <param name="CR_SW"></param>
        /// <returns></returns>
        private static int CheckLayoutRange(Guid GroupID, Guid ControlID, int culoum, int row, int culoumSpan, int rowSpan, bool CR_SW)
        {
            int Return;
            if (culoumSpan < 1 || rowSpan <1)
            {
                MessageBox.Show("輸入數值不可以小於1");
                if (CR_SW)
                    culoumSpan = 1;
                else
                    rowSpan = 1;
            }
            else 
            {
                HrDBDataContext db = new HrDBDataContext();
                UserDefineLayout UDL = db.UserDefineLayout.Where(p => p.ControlID.Equals(ControlID)).FirstOrDefault();
                Guid gd = Guid.Empty;
                if (UDL != null)
                    gd = UDL.UserDefineGroupID;
                else
                    gd = GroupID;

                UserDefineGroup UDG = db.UserDefineGroup.Where(p => p.UserDefineGroupID.Equals(gd)).FirstOrDefault();
                int x1 = culoum, x2 = culoum + culoumSpan;
                int y1 = row, y2 = row + rowSpan;
                if (x2 > UDG.ColumnCnt || y2 > UDG.RowCnt)
                {
                    MessageBox.Show("輸入參數已超過配置最大值.");
                    if (CR_SW)
                        culoumSpan = UDG.ColumnCnt - culoum;
                    else
                        rowSpan = UDG.RowCnt - row;
                }
                else
                { 
                    var RepUDL = db.UserDefineLayout.Where(p => p.UserDefineGroupID.Equals(gd) && !p.ControlID.Equals(ControlID)
                    && (x1 <= p.LayoutColumn && p.LayoutColumn < x2) && (y1 <= p.LayoutRow && p.LayoutRow < y2));
                    if (RepUDL.Any())
                    {
                        MessageBox.Show("指定範圍內已有存在的控制項.");
                        culoumSpan = RepUDL.Select(p => p.LayoutColumn).Max() - x1;
                        rowSpan =RepUDL.Select(p => p.LayoutRow).Max() - y1;
                    } 
                }
            }

            if (CR_SW)
                Return = culoumSpan;
            else
                Return = rowSpan;

            return Return;
        }

        #region 屬性視窗下拉設定
        /// <summary>
        /// propertyGrid 資料型態下拉實作
        /// </summary>
        public class SourceTypeClassConverter : StringConverter
        {
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }

            public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                List<string> lst = new List<string>();
                lst.Add("MTCODE");
                lst.Add("DB");
                //lst.Add("TextFile");
                return new StandardValuesCollection(lst);
            }

            //@! true: disable text editting.    false: enable text editting;
            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            {
                return true;
            }
        }
        /// <summary>
        /// propertyGrid 資料來源下拉實作
        /// </summary>
        public class DataSourceClassConverter : StringConverter
        {
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }

            public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                //@! 編輯下拉框中的items
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

                ComboBoxControl instance = context.Instance as ComboBoxControl;

                if (instance.SourceType == "MTCODE")
                {
                    var sql = from a in db.MTCODE
                              where a.DISPLAY
                              select a.CATEGORY;
                    var lst = sql.Distinct().AsEnumerable().ToList();
                    return new StandardValuesCollection(lst);
                }
                else
                {
                    string SourceScript = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME";
                    var lst = CodeFunction.GetUDFSourcebySourceScript(SourceScript, "TABLE_NAME", "TABLE_NAME").Values.ToList();
                    return new StandardValuesCollection(lst);
                }
            }

            //@! true: disable text editting.    false: enable text editting;
            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            {
                return true;
            }
        }
        /// <summary>
        /// propertyGrid 資料來源欄位下拉實作
        /// </summary>
        public class TableColumnClassConverter : StringConverter
        {
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }

            public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                //@! 編輯下拉框中的items
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                ComboBoxControl instance = context.Instance as ComboBoxControl;

                string ColumnStr = string.Empty;
                if (instance.SourceType == "MTCODE")
                    ColumnStr = string.Format("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND COLUMN_NAME != 'Category'", instance.SourceType);
                else
                    ColumnStr = string.Format("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}'", instance.DataSource);

                var lst = CodeFunction.GetUDFSourcebySourceScript(ColumnStr, "COLUMN_NAME", "COLUMN_NAME").Values.ToList();
                return new StandardValuesCollection(lst);
            }

            //@! true: disable text editting.    false: enable text editting;
            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            {
                return true;
            }
        }
        /// <summary>
        /// propertyGrid 標籤聯繫下拉實作
        /// </summary>
        public class BindingLabelClassConverter : StringConverter
        {
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }

            public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                Guid UDFG_ID = Guid.Empty;
                switch (context.Instance)
                {
                    //case LabelControl _control:
                    //    UDFG_ID = _control.GroupID;
                    //    break;
                    //case CheckBoxControl _control:
                    //    UDFG_ID = _control.GroupID;
                    //    break;
                    case TextBoxControl _control:
                        UDFG_ID = _control.GroupID;
                        break;
                    case DateTimePickerControl _control:
                        UDFG_ID = _control.GroupID;
                        break;
                    case ComboBoxControl _control:
                        UDFG_ID = _control.GroupID;
                        break;
                    case NumericUpDownControl _control:
                        UDFG_ID = _control.GroupID;
                        break;
                }

                var sql = from a in db.UserDefineLayout
                          where a.UserDefineGroupID.Equals(UDFG_ID) && a.Type == "Label"
                          //select new { Label = JsonConvert.DeserializeObject<Dictionary<string, string>>(a.Tag)["Text"].ToString() + "_" + a.ControlID.ToString() };
                          select new { a.Tag, a.ControlID };
                var lst = sql.Distinct().AsEnumerable().ToList();
                List<string> result = lst.Select(p=> JsonConvert.DeserializeObject<Dictionary<string, string>>(p.Tag)["Text"].ToString()).ToList();
                result.Add(string.Empty);
                return new StandardValuesCollection(result);
            }

            //@! true: disable text editting.    false: enable text editting;
            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            {
                return true;
            }
        }
        #endregion

        public class CheckedListBoxUITypeEditor : System.Drawing.Design.UITypeEditor
        {
            public CheckedListBox _checklisbox = new CheckedListBox();
            private IWindowsFormsEditorService _es;
            //private List<string> _result = new List<string>();
            public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
            {
                return System.Drawing.Design.UITypeEditorEditStyle.DropDown;
            }
            public override bool IsDropDownResizable => true;
            public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                if (provider != null)
                    _es = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;

                if (_es != null)
                {
                    LoadValues(context,value);
                    _es.DropDownControl(_checklisbox);
                }

                string _result = string.Empty;
                foreach (string str in _checklisbox.CheckedItems)
                    _result += "," + str;

                return _result.Remove(0, 1);//JsonConvert.SerializeObject(_result);
            }

            public void LoadValues(System.ComponentModel.ITypeDescriptorContext context,object value)
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                ComboBoxControl instance = context.Instance as ComboBoxControl;

                string ColumnStr = string.Empty;
                if (instance.SourceType == "MTCODE")
                    ColumnStr = string.Format("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND COLUMN_NAME != 'Category'", instance.SourceType);
                else
                    ColumnStr = string.Format("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}'", instance.DataSource);

                var lst = CodeFunction.GetUDFSourcebySourceScript(ColumnStr, "COLUMN_NAME", "COLUMN_NAME").Values.ToList();
                _checklisbox.Items.Clear();
                foreach (var item in lst)
                    _checklisbox.Items.Add(item, false);
                char[] delimiterString = { ',' };
                var Sql = ((string)value).Split(delimiterString, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in Sql)
                {
                    int index = _checklisbox.Items.IndexOf(item);
                    if (index >= 0)
                        _checklisbox.SetItemChecked(index, true);
                }
            }
        }
        #endregion

        #region 屬性變更連動存取
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            new_CheckBox.Checked = checkBox1.Checked;
            propertyGrid1.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            new_TextBox.Text = textBox1.Text;
            propertyGrid1.Refresh();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.PropertyDescriptor.Name == "Anchor")
                instance.Anchor = e.ChangedItem.Value.ToString();
            else if (e.ChangedItem.PropertyDescriptor.Name == "Dock")
                instance.Dock = e.ChangedItem.Value.ToString();
            else if (e.ChangedItem.PropertyDescriptor.Name == "ColumnSpan")
                instance.ColumnSpan = int.Parse(e.ChangedItem.Value.ToString());
            else if (e.ChangedItem.PropertyDescriptor.Name == "RowSpan")
                instance.RowSpan = int.Parse(e.ChangedItem.Value.ToString());
            else
            {
                object SObj = propertyGrid1.SelectedObject;
                string TypeStr = SObj.GetType().Name;

                Dictionary<string, string> TagList = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(instance.Tag))
                    TagList = JsonConvert.DeserializeObject<Dictionary<string, string>>(instance.Tag);//反序列化

                string Name = e.ChangedItem.PropertyDescriptor.Name;
                List<string> CheckProp = new List<string>();
                switch (TypeStr)
                {
                    case "LabelControl":
                        CheckProp.Add("Text");

                        if (Name == "Text")
                            label1.Text = e.ChangedItem.Value.ToString();
                        break;
                    case "CheckBoxControl":
                        CheckProp.Add("Text");
                        CheckProp.Add("Checked");
                        CheckProp.Add("ParameterName");

                        if (Name == "Text")
                            checkBox1.Text = e.ChangedItem.Value.ToString();
                        else if (Name == "Checked")
                            checkBox1.Checked = Convert.ToBoolean(e.ChangedItem.Value.ToString());
                        break;
                    case "TextBoxControl":
                        CheckProp.Add("Text");
                        CheckProp.Add("BindngLabel");
                        CheckProp.Add("BindingID");
                        CheckProp.Add("ParameterName");

                        if (Name == "Text")
                            textBox1.Text = e.ChangedItem.Value.ToString();
                        break;
                    case "DateTimePickerControl":
                        CheckProp.Add("DateTimeValue");
                        CheckProp.Add("BindngLabel");
                        CheckProp.Add("BindingID");
                        CheckProp.Add("ParameterName");

                        if (Name == "DateTimeValue")
                            dateTimePicker1.Value = Convert.ToDateTime(e.ChangedItem.Value.ToString());
                        break;
                    case "ComboBoxControl":
                        //CheckProp.Add("SourceID");
                        CheckProp.Add("BindngLabel");
                        CheckProp.Add("BindingID");
                        CheckProp.Add("ParameterName");

                        if (Name == "DataSource" || Name == "ValueMember" || Name == "DisplayMember" || Name == "SortField" || Name == "WhereField")
                        {
                            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetUDFSourcebySourceScript(new_ComboBox.SourceScript, new_ComboBox.ValueMember, new_ComboBox.DisplayMember), true, true, true, true);
                            comboBox1.SelectedIndex = 0;
                        }
                        break;
                    case "NumericUpDownControl":
                        CheckProp.Add("DecimalPlaces");
                        CheckProp.Add("Maximum");
                        CheckProp.Add("Minimum");
                        CheckProp.Add("NumericValue");
                        CheckProp.Add("BindngLabel");
                        CheckProp.Add("BindingID");
                        CheckProp.Add("ParameterName");

                        Decimal tempvalue = numericUpDown1.Value;
                        if (Name == "DecimalPlaces")
                            numericUpDown1.DecimalPlaces = Convert.ToInt32(e.ChangedItem.Value.ToString());
                        else if (Name == "Maximum")
                            numericUpDown1.Maximum = Convert.ToDecimal(e.ChangedItem.Value.ToString());
                        else if (Name == "Minimum")
                            numericUpDown1.Minimum = Convert.ToDecimal(e.ChangedItem.Value.ToString());
                        else if (Name == "NumericValue")
                            numericUpDown1.Value = Convert.ToDecimal(e.ChangedItem.Value.ToString());
                        break;
                    default:

                        break;
                }

                if (CheckProp.Contains(Name) && TagList.ContainsKey(Name))
                    TagList[Name] = e.ChangedItem.Value.ToString();
                else if (CheckProp.Contains(Name))
                    TagList.Add(Name, e.ChangedItem.Value.ToString());

                instance.Tag = JsonConvert.SerializeObject(TagList);
            }
        } 
        #endregion

        #region 儲存設定
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool VisibleProp = true;
            Dictionary<string,string> TagProp = new Dictionary<string, string>();
            switch (ControlTypeProp)
            {
                case "rbLabel":
                    if (new_Label.Text != null && new_Label.Text.Trim().Length > 0)
                        TagProp.Add("Text", new_Label.Text);
                    else
                        TagProp.Add("Text", "Label");
                    break;
                case "rbCheckBox":
                    TagProp.Add("Text", new_CheckBox.Text);
                    TagProp.Add("Checked", new_CheckBox.Checked.ToString());
                    TagProp.Add("BindingID", new_CheckBox.BindingID.ToString());
                    TagProp.Add("ParameterName", new_CheckBox.ParameterName.ToString());
                    break;
                case "rbTextBox":
                    TagProp.Add("Text", new_TextBox.Text);
                    TagProp.Add("BindingID", new_TextBox.BindingID.ToString());
                    //TagProp.Add("BindngLabel", new_TextBox.BindngLabel);
                    TagProp.Add("ParameterName", new_TextBox.ParameterName.ToString());
                    break;
                case "rbDateTimePicker":
                    if (new_DateTimePicker.Checked)
                        TagProp.Add("DateTimeValue", new_DateTimePicker.DateTimeValue.ToString());
                    else
                        TagProp.Add("DateTimeValue", string.Empty);
                    TagProp.Add("BindingID", new_DateTimePicker.BindingID.ToString());
                    //TagProp.Add("BindngLabel", new_DateTimePicker.BindngLabel);
                    TagProp.Add("ParameterName", new_DateTimePicker.ParameterName.ToString());
                    break;
                case "rbComboBox":
                    if (new_ComboBox.SourceID.Equals(Guid.Empty))
                    {
                        UserDefineSource UDS = db.UserDefineSource.Where(p => p.SourceType == new_ComboBox.SourceType && p.ValueMember == new_ComboBox.ValueMember
                                    && p.DisplayMember == new_ComboBox.DisplayMember && p.SourceScript == new_ComboBox.SourceScript
                                    && p.SortFeild == new_ComboBox.SortField && p.WhereFeild == new_ComboBox.WhereField).FirstOrDefault();
                        if (UDS == null)
                        {
                            UDS = new UserDefineSource();
                            UDS.SourceID = Guid.NewGuid();
                            UDS.SourceName = new_ComboBox.DataSource;
                            UDS.SourceType = new_ComboBox.SourceType;
                            UDS.ValueMember = new_ComboBox.ValueMember;
                            UDS.DisplayMember = new_ComboBox.DisplayMember;
                            UDS.SourceScript = new_ComboBox.SourceScript;
                            UDS.SortFeild = new_ComboBox.SortField;
                            UDS.WhereFeild = new_ComboBox.WhereField;
                            db.UserDefineSource.InsertOnSubmit(UDS);
                            db.SubmitChanges();
                        }
                        TagProp.Add("SourceID", UDS.SourceID.ToString());
                    }
                    else
                        TagProp.Add("SourceID", new_ComboBox.SourceID.ToString());
                    TagProp.Add("BindingID", new_ComboBox.BindingID.ToString());
                    //TagProp.Add("BindngLabel", new_ComboBox.BindngLabel);
                    TagProp.Add("ParameterName", new_ComboBox.ParameterName.ToString());
                    break;
                case "rbNumericUpDown":
                    TagProp.Add("Maximum",new_NumericUpDown.Maximum.ToString());
                    TagProp.Add("Minimum", new_NumericUpDown.Minimum.ToString());
                    TagProp.Add("DecimalPlaces", new_NumericUpDown.DecimalPlaces.ToString());
                    TagProp.Add("NumericValue", new_NumericUpDown.NumericValue.ToString());
                    TagProp.Add("BindingID", new_NumericUpDown.BindingID.ToString());
                    //TagProp.Add("BindngLabel", new_NumericUpDown.BindngLabel);
                    TagProp.Add("ParameterName", new_NumericUpDown.ParameterName.ToString());
                    break;
                default:
                    EditType = CRUD.Delete;
                    break;
            }

            string tempCType = ControlTypeProp.Substring(2);
            if (EditType == CRUD.Create)
                db.UserDefineLayout.InsertOnSubmit(instance);
            else
            {
                if (instance.Type != tempCType)
                {
                    var sql = db.UserDefineValue.Where(p => p.ControlID.Equals(instance.ControlID));
                    if (sql.Any())
                    {
                        if (MessageBox.Show("此控制項已存有員工資料，請問是否繼續變更設定?" + Environment.NewLine +
                            " 是 = 變更設定.   否 = 取消變更.", "控制項變更警告"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            //db.UserDefineLayout.DeleteOnSubmit(instance);
                            instance.UserDefineGroupID = Guid.Empty;
                            db.SubmitChanges();
                            if (EditType == CRUD.Delete)
                            {
                                this.Close();
                                return;
                            }
                            else
                            {
                                instance = new UserDefineLayout();
                                instance.UserDefineGroupID = UserDefineGroupID;
                                instance.ControlID = Guid.NewGuid();
                                //instance.ControlName = instance.ControlID.ToString();
                                db.UserDefineLayout.InsertOnSubmit(instance);
                            }
                        }
                        else
                        {
                            this.Close();
                            return;
                        }
                    }
                    else if (EditType == CRUD.Delete)
                    {
                        instance.UserDefineGroupID = Guid.Empty;
                        db.SubmitChanges();
                        this.Close();
                        return;
                    }
                }
            }
            instance.Type = tempCType;
            instance.Visible = VisibleProp;
            instance.Tag = JsonConvert.SerializeObject(TagProp);
            instance.Key_Date = DateTime.Now;
            instance.Key_Man = MainForm.USER_ID;
            db.SubmitChanges();
            this.Close();
        } 
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
