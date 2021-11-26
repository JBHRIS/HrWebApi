
namespace JBHR.HopaxCustom
{
    partial class HPX_Point_Mgt_ADD
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbEmployee_Name = new System.Windows.Forms.Label();
            this.lbActivity_Name = new System.Windows.Forms.Label();
            this.txtActivity_Name = new System.Windows.Forms.TextBox();
            this.txtEmployee_Name = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbMemo = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.lbRemaining_Point = new System.Windows.Forms.Label();
            this.txtRemaining_Point = new JBControls.TextBox();
            this.lbRelatives_Count = new System.Windows.Forms.Label();
            this.txtRelatives_Count = new JBControls.TextBox();
            this.lbGet_Point = new System.Windows.Forms.Label();
            this.txtGet_Point = new JBControls.TextBox();
            this.lbUse_Point = new System.Windows.Forms.Label();
            this.txtUse_Point = new JBControls.TextBox();
            this.lbUse_Date = new System.Windows.Forms.Label();
            this.lbPerson_Join = new System.Windows.Forms.Label();
            this.lbLeader = new System.Windows.Forms.Label();
            this.cbxPerson_Join = new System.Windows.Forms.ComboBox();
            this.cbxLeader = new System.Windows.Forms.ComboBox();
            this.lbEmployee_No = new System.Windows.Forms.Label();
            this.ptxEmployee = new JBControls.PopupTextBox();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBas = new JBHR.Att.dsBas();
            this.lbBook_User = new System.Windows.Forms.Label();
            this.txtBook_User = new System.Windows.Forms.TextBox();
            this.dtpUse_Date = new JBControls.TextBox();
            this.bASETableAdapter = new JBHR.Att.dsBasTableAdapters.BASETableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbEmployee_Name, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbActivity_Name, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtActivity_Name, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtEmployee_Name, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.lbMemo, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtMemo, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lbRemaining_Point, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtRemaining_Point, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbRelatives_Count, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtRelatives_Count, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbGet_Point, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtGet_Point, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbUse_Point, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtUse_Point, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbUse_Date, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbPerson_Join, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbLeader, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxPerson_Join, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbxLeader, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbEmployee_No, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ptxEmployee, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbBook_User, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtBook_User, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.dtpUse_Date, 3, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(391, 256);
            this.tableLayoutPanel1.TabIndex = 65;
            // 
            // lbEmployee_Name
            // 
            this.lbEmployee_Name.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEmployee_Name.AutoSize = true;
            this.lbEmployee_Name.ForeColor = System.Drawing.Color.Red;
            this.lbEmployee_Name.Location = new System.Drawing.Point(48, 42);
            this.lbEmployee_Name.Name = "lbEmployee_Name";
            this.lbEmployee_Name.Size = new System.Drawing.Size(29, 12);
            this.lbEmployee_Name.TabIndex = 47;
            this.lbEmployee_Name.Text = "姓名";
            // 
            // lbActivity_Name
            // 
            this.lbActivity_Name.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbActivity_Name.AutoSize = true;
            this.lbActivity_Name.ForeColor = System.Drawing.Color.Red;
            this.lbActivity_Name.Location = new System.Drawing.Point(24, 10);
            this.lbActivity_Name.Name = "lbActivity_Name";
            this.lbActivity_Name.Size = new System.Drawing.Size(53, 12);
            this.lbActivity_Name.TabIndex = 46;
            this.lbActivity_Name.Text = "活動名稱";
            // 
            // txtActivity_Name
            // 
            this.txtActivity_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtActivity_Name, 3);
            this.txtActivity_Name.Location = new System.Drawing.Point(83, 5);
            this.txtActivity_Name.MaxLength = 100;
            this.txtActivity_Name.Name = "txtActivity_Name";
            this.txtActivity_Name.Size = new System.Drawing.Size(305, 22);
            this.txtActivity_Name.TabIndex = 1;
            // 
            // txtEmployee_Name
            // 
            this.txtEmployee_Name.Location = new System.Drawing.Point(83, 35);
            this.txtEmployee_Name.Name = "txtEmployee_Name";
            this.txtEmployee_Name.Size = new System.Drawing.Size(95, 22);
            this.txtEmployee_Name.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(111, 229);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.btnCancel, 2);
            this.btnCancel.Location = new System.Drawing.Point(220, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbMemo
            // 
            this.lbMemo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbMemo.AutoSize = true;
            this.lbMemo.Location = new System.Drawing.Point(48, 202);
            this.lbMemo.Name = "lbMemo";
            this.lbMemo.Size = new System.Drawing.Size(29, 12);
            this.lbMemo.TabIndex = 51;
            this.lbMemo.Text = "備註";
            // 
            // txtMemo
            // 
            this.txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtMemo, 3);
            this.txtMemo.Location = new System.Drawing.Point(83, 197);
            this.txtMemo.MaxLength = 100;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(305, 22);
            this.txtMemo.TabIndex = 10;
            // 
            // lbRemaining_Point
            // 
            this.lbRemaining_Point.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbRemaining_Point.AutoSize = true;
            this.lbRemaining_Point.ForeColor = System.Drawing.Color.Black;
            this.lbRemaining_Point.Location = new System.Drawing.Point(235, 170);
            this.lbRemaining_Point.Name = "lbRemaining_Point";
            this.lbRemaining_Point.Size = new System.Drawing.Size(53, 12);
            this.lbRemaining_Point.TabIndex = 88;
            this.lbRemaining_Point.Text = "剩餘點數";
            // 
            // txtRemaining_Point
            // 
            this.txtRemaining_Point.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtRemaining_Point.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtRemaining_Point.CaptionLabel = null;
            this.txtRemaining_Point.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRemaining_Point.DecimalPlace = 2;
            this.txtRemaining_Point.IsEmpty = true;
            this.txtRemaining_Point.Location = new System.Drawing.Point(294, 165);
            this.txtRemaining_Point.Mask = "";
            this.txtRemaining_Point.MaxLength = -1;
            this.txtRemaining_Point.Name = "txtRemaining_Point";
            this.txtRemaining_Point.PasswordChar = '\0';
            this.txtRemaining_Point.ReadOnly = true;
            this.txtRemaining_Point.ShowCalendarButton = true;
            this.txtRemaining_Point.Size = new System.Drawing.Size(94, 22);
            this.txtRemaining_Point.TabIndex = 14;
            this.txtRemaining_Point.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // lbRelatives_Count
            // 
            this.lbRelatives_Count.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbRelatives_Count.AutoSize = true;
            this.lbRelatives_Count.ForeColor = System.Drawing.Color.Black;
            this.lbRelatives_Count.Location = new System.Drawing.Point(235, 42);
            this.lbRelatives_Count.Name = "lbRelatives_Count";
            this.lbRelatives_Count.Size = new System.Drawing.Size(53, 12);
            this.lbRelatives_Count.TabIndex = 80;
            this.lbRelatives_Count.Text = "親友人數";
            // 
            // txtRelatives_Count
            // 
            this.txtRelatives_Count.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtRelatives_Count.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtRelatives_Count.CaptionLabel = null;
            this.txtRelatives_Count.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRelatives_Count.DecimalPlace = 2;
            this.txtRelatives_Count.IsEmpty = true;
            this.txtRelatives_Count.Location = new System.Drawing.Point(294, 37);
            this.txtRelatives_Count.Mask = "";
            this.txtRelatives_Count.MaxLength = -1;
            this.txtRelatives_Count.Name = "txtRelatives_Count";
            this.txtRelatives_Count.PasswordChar = '\0';
            this.txtRelatives_Count.ReadOnly = false;
            this.txtRelatives_Count.ShowCalendarButton = true;
            this.txtRelatives_Count.Size = new System.Drawing.Size(94, 22);
            this.txtRelatives_Count.TabIndex = 7;
            this.txtRelatives_Count.ValidType = JBControls.TextBox.EValidType.Integer;
            this.txtRelatives_Count.Leave += new System.EventHandler(this.txtRelatives_Count_Leave);
            // 
            // lbGet_Point
            // 
            this.lbGet_Point.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbGet_Point.AutoSize = true;
            this.lbGet_Point.ForeColor = System.Drawing.Color.Black;
            this.lbGet_Point.Location = new System.Drawing.Point(235, 74);
            this.lbGet_Point.Name = "lbGet_Point";
            this.lbGet_Point.Size = new System.Drawing.Size(53, 12);
            this.lbGet_Point.TabIndex = 82;
            this.lbGet_Point.Text = "獲得點數";
            // 
            // txtGet_Point
            // 
            this.txtGet_Point.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtGet_Point.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtGet_Point.CaptionLabel = null;
            this.txtGet_Point.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtGet_Point.DecimalPlace = 2;
            this.txtGet_Point.IsEmpty = true;
            this.txtGet_Point.Location = new System.Drawing.Point(294, 69);
            this.txtGet_Point.Mask = "";
            this.txtGet_Point.MaxLength = -1;
            this.txtGet_Point.Name = "txtGet_Point";
            this.txtGet_Point.PasswordChar = '\0';
            this.txtGet_Point.ReadOnly = true;
            this.txtGet_Point.ShowCalendarButton = true;
            this.txtGet_Point.Size = new System.Drawing.Size(94, 22);
            this.txtGet_Point.TabIndex = 13;
            this.txtGet_Point.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // lbUse_Point
            // 
            this.lbUse_Point.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbUse_Point.AutoSize = true;
            this.lbUse_Point.ForeColor = System.Drawing.Color.Black;
            this.lbUse_Point.Location = new System.Drawing.Point(235, 106);
            this.lbUse_Point.Name = "lbUse_Point";
            this.lbUse_Point.Size = new System.Drawing.Size(53, 12);
            this.lbUse_Point.TabIndex = 84;
            this.lbUse_Point.Text = "使用點數";
            // 
            // txtUse_Point
            // 
            this.txtUse_Point.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUse_Point.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtUse_Point.CaptionLabel = null;
            this.txtUse_Point.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUse_Point.DecimalPlace = 2;
            this.txtUse_Point.IsEmpty = true;
            this.txtUse_Point.Location = new System.Drawing.Point(294, 101);
            this.txtUse_Point.Mask = "";
            this.txtUse_Point.MaxLength = -1;
            this.txtUse_Point.Name = "txtUse_Point";
            this.txtUse_Point.PasswordChar = '\0';
            this.txtUse_Point.ReadOnly = false;
            this.txtUse_Point.ShowCalendarButton = true;
            this.txtUse_Point.Size = new System.Drawing.Size(94, 22);
            this.txtUse_Point.TabIndex = 9;
            this.txtUse_Point.ValidType = JBControls.TextBox.EValidType.Integer;
            this.txtUse_Point.Leave += new System.EventHandler(this.txtUse_Point_Leave);
            // 
            // lbUse_Date
            // 
            this.lbUse_Date.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbUse_Date.AutoSize = true;
            this.lbUse_Date.ForeColor = System.Drawing.Color.Black;
            this.lbUse_Date.Location = new System.Drawing.Point(235, 138);
            this.lbUse_Date.Name = "lbUse_Date";
            this.lbUse_Date.Size = new System.Drawing.Size(53, 12);
            this.lbUse_Date.TabIndex = 86;
            this.lbUse_Date.Text = "使用時間";
            // 
            // lbPerson_Join
            // 
            this.lbPerson_Join.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPerson_Join.AutoSize = true;
            this.lbPerson_Join.ForeColor = System.Drawing.Color.Black;
            this.lbPerson_Join.Location = new System.Drawing.Point(12, 138);
            this.lbPerson_Join.Name = "lbPerson_Join";
            this.lbPerson_Join.Size = new System.Drawing.Size(65, 12);
            this.lbPerson_Join.TabIndex = 95;
            this.lbPerson_Join.Text = "本人參加否";
            // 
            // lbLeader
            // 
            this.lbLeader.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbLeader.AutoSize = true;
            this.lbLeader.ForeColor = System.Drawing.Color.Black;
            this.lbLeader.Location = new System.Drawing.Point(36, 106);
            this.lbLeader.Name = "lbLeader";
            this.lbLeader.Size = new System.Drawing.Size(41, 12);
            this.lbLeader.TabIndex = 94;
            this.lbLeader.Text = "團主否";
            // 
            // cbxPerson_Join
            // 
            this.cbxPerson_Join.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxPerson_Join.FormattingEnabled = true;
            this.cbxPerson_Join.Location = new System.Drawing.Point(83, 134);
            this.cbxPerson_Join.Name = "cbxPerson_Join";
            this.cbxPerson_Join.Size = new System.Drawing.Size(95, 20);
            this.cbxPerson_Join.TabIndex = 5;
            this.cbxPerson_Join.DropDownClosed += new System.EventHandler(this.cbxPerson_Join_DropDownClosed);
            // 
            // cbxLeader
            // 
            this.cbxLeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxLeader.FormattingEnabled = true;
            this.cbxLeader.Location = new System.Drawing.Point(83, 102);
            this.cbxLeader.Name = "cbxLeader";
            this.cbxLeader.Size = new System.Drawing.Size(95, 20);
            this.cbxLeader.TabIndex = 4;
            this.cbxLeader.DropDownClosed += new System.EventHandler(this.cbxLeader_DropDownClosed);
            // 
            // lbEmployee_No
            // 
            this.lbEmployee_No.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEmployee_No.AutoSize = true;
            this.lbEmployee_No.ForeColor = System.Drawing.Color.Black;
            this.lbEmployee_No.Location = new System.Drawing.Point(48, 74);
            this.lbEmployee_No.Name = "lbEmployee_No";
            this.lbEmployee_No.Size = new System.Drawing.Size(29, 12);
            this.lbEmployee_No.TabIndex = 90;
            this.lbEmployee_No.Text = "工號";
            // 
            // ptxEmployee
            // 
            this.ptxEmployee.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ptxEmployee.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxEmployee.CaptionLabel = null;
            this.ptxEmployee.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxEmployee.DataSource = this.bASEBindingSource;
            this.ptxEmployee.DisplayMember = "name_c";
            this.ptxEmployee.IsEmpty = true;
            this.ptxEmployee.IsEmptyToQuery = true;
            this.ptxEmployee.IsMustBeFound = true;
            this.ptxEmployee.LabelText = "";
            this.ptxEmployee.Location = new System.Drawing.Point(83, 69);
            this.ptxEmployee.Name = "ptxEmployee";
            this.ptxEmployee.ReadOnly = false;
            this.ptxEmployee.ShowDisplayName = true;
            this.ptxEmployee.Size = new System.Drawing.Size(66, 22);
            this.ptxEmployee.TabIndex = 3;
            this.ptxEmployee.ValueMember = "nobr";
            this.ptxEmployee.WhereCmd = "";
            this.ptxEmployee.Leave += new System.EventHandler(this.ptxEmployee_Leave);
            // 
            // bASEBindingSource
            // 
            this.bASEBindingSource.DataMember = "BASE";
            this.bASEBindingSource.DataSource = this.dsBas;
            // 
            // dsBas
            // 
            this.dsBas.DataSetName = "dsBas";
            this.dsBas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbBook_User
            // 
            this.lbBook_User.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbBook_User.AutoSize = true;
            this.lbBook_User.ForeColor = System.Drawing.Color.Black;
            this.lbBook_User.Location = new System.Drawing.Point(36, 170);
            this.lbBook_User.Name = "lbBook_User";
            this.lbBook_User.Size = new System.Drawing.Size(41, 12);
            this.lbBook_User.TabIndex = 78;
            this.lbBook_User.Text = "承辦人";
            // 
            // txtBook_User
            // 
            this.txtBook_User.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBook_User.Location = new System.Drawing.Point(83, 165);
            this.txtBook_User.MaxLength = 50;
            this.txtBook_User.Name = "txtBook_User";
            this.txtBook_User.Size = new System.Drawing.Size(95, 22);
            this.txtBook_User.TabIndex = 6;
            // 
            // dtpUse_Date
            // 
            this.dtpUse_Date.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpUse_Date.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.dtpUse_Date.CaptionLabel = null;
            this.dtpUse_Date.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.dtpUse_Date.DecimalPlace = 2;
            this.dtpUse_Date.IsEmpty = true;
            this.dtpUse_Date.Location = new System.Drawing.Point(294, 133);
            this.dtpUse_Date.Mask = "0000/00/00";
            this.dtpUse_Date.MaxLength = -1;
            this.dtpUse_Date.Name = "dtpUse_Date";
            this.dtpUse_Date.PasswordChar = '\0';
            this.dtpUse_Date.ReadOnly = false;
            this.dtpUse_Date.ShowCalendarButton = true;
            this.dtpUse_Date.Size = new System.Drawing.Size(94, 22);
            this.dtpUse_Date.TabIndex = 10;
            this.dtpUse_Date.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // HPX_Point_Mgt_ADD
            // 
            this.ClientSize = new System.Drawing.Size(415, 280);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HPX_Point_Mgt_ADD";
            this.Load += new System.EventHandler(this.HPX_Point_Mgt_ADD_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbEmployee_Name;
        private System.Windows.Forms.Label lbActivity_Name;
        private System.Windows.Forms.Label lbMemo;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.TextBox txtActivity_Name;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtBook_User;
        private System.Windows.Forms.Label lbBook_User;
        private JBControls.TextBox txtGet_Point;
        private System.Windows.Forms.Label lbGet_Point;
        private JBControls.TextBox txtUse_Point;
        private System.Windows.Forms.Label lbUse_Point;
        private System.Windows.Forms.Label lbRemaining_Point;
        private JBControls.TextBox txtRemaining_Point;
        private System.Windows.Forms.Label lbUse_Date;
        private System.Windows.Forms.Label lbRelatives_Count;
        private JBControls.TextBox txtRelatives_Count;
        private Att.dsBas dsBas;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private Att.dsBasTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.Label lbEmployee_No;
        private System.Windows.Forms.TextBox txtEmployee_Name;
        private JBControls.PopupTextBox ptxEmployee;
        private System.Windows.Forms.ComboBox cbxPerson_Join;
        private System.Windows.Forms.Label lbLeader;
        private System.Windows.Forms.Label lbPerson_Join;
        private System.Windows.Forms.ComboBox cbxLeader;
        private JBControls.TextBox dtpUse_Date;
    }
}
