namespace JBHR.Sys
{
    partial class U_NOTIFY
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxNotifyType = new System.Windows.Forms.ComboBox();
            this.cbxTargetType = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHrUser = new System.Windows.Forms.Panel();
            this.ptxHrUser = new JBControls.PopupTextBox();
            this.uUSERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sysDS = new JBHR.Sys.SysDS();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlEmployee = new System.Windows.Forms.Panel();
            this.ptxEmployee = new JBControls.PopupTextBox();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainDS = new JBHR.MainDS();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlEmail = new System.Windows.Forms.Panel();
            this.txtEmail = new JBControls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlDeptManager = new System.Windows.Forms.Panel();
            this.textBox1 = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlSponsor = new System.Windows.Forms.Panel();
            this.textBox2 = new JBControls.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnHruser = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.autoKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notifyTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.targetTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.mTCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.targetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyManDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notifyTemplateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.u_USERTableAdapter = new JBHR.Sys.SysDSTableAdapters.U_USERTableAdapter();
            this.txtMemo = new JBControls.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.v_BASETableAdapter = new JBHR.MainDSTableAdapters.V_BASETableAdapter();
            this.mTCODETableAdapter = new JBHR.MainDSTableAdapters.MTCODETableAdapter();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2.SuspendLayout();
            this.pnlHrUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uUSERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).BeginInit();
            this.pnlEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).BeginInit();
            this.pnlEmail.SuspendLayout();
            this.pnlDeptManager.SuspendLayout();
            this.pnlSponsor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notifyTemplateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "通知種類";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "通知對象";
            // 
            // cbxNotifyType
            // 
            this.cbxNotifyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNotifyType.FormattingEnabled = true;
            this.cbxNotifyType.Location = new System.Drawing.Point(107, 19);
            this.cbxNotifyType.Name = "cbxNotifyType";
            this.cbxNotifyType.Size = new System.Drawing.Size(121, 20);
            this.cbxNotifyType.TabIndex = 1;
            this.cbxNotifyType.SelectedIndexChanged += new System.EventHandler(this.cbxNotifyType_SelectedIndexChanged);
            // 
            // cbxTargetType
            // 
            this.cbxTargetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTargetType.FormattingEnabled = true;
            this.cbxTargetType.Location = new System.Drawing.Point(107, 50);
            this.cbxTargetType.Name = "cbxTargetType";
            this.cbxTargetType.Size = new System.Drawing.Size(121, 20);
            this.cbxTargetType.TabIndex = 1;
            this.cbxTargetType.SelectedIndexChanged += new System.EventHandler(this.cbxTargetType_SelectedIndexChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.pnlHrUser);
            this.flowLayoutPanel2.Controls.Add(this.pnlEmployee);
            this.flowLayoutPanel2.Controls.Add(this.pnlEmail);
            this.flowLayoutPanel2.Controls.Add(this.pnlDeptManager);
            this.flowLayoutPanel2.Controls.Add(this.pnlSponsor);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(41, 76);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(333, 40);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // pnlHrUser
            // 
            this.pnlHrUser.Controls.Add(this.ptxHrUser);
            this.pnlHrUser.Controls.Add(this.label3);
            this.pnlHrUser.Location = new System.Drawing.Point(3, 3);
            this.pnlHrUser.Name = "pnlHrUser";
            this.pnlHrUser.Size = new System.Drawing.Size(317, 28);
            this.pnlHrUser.TabIndex = 4;
            this.pnlHrUser.Visible = false;
            // 
            // ptxHrUser
            // 
            this.ptxHrUser.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxHrUser.CaptionLabel = null;
            this.ptxHrUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxHrUser.DataSource = this.uUSERBindingSource;
            this.ptxHrUser.DisplayMember = "name";
            this.ptxHrUser.IsEmpty = true;
            this.ptxHrUser.IsEmptyToQuery = true;
            this.ptxHrUser.IsMustBeFound = true;
            this.ptxHrUser.LabelText = "";
            this.ptxHrUser.Location = new System.Drawing.Point(63, 3);
            this.ptxHrUser.Name = "ptxHrUser";
            this.ptxHrUser.ReadOnly = false;
            this.ptxHrUser.ShowDisplayName = true;
            this.ptxHrUser.Size = new System.Drawing.Size(121, 22);
            this.ptxHrUser.TabIndex = 5;
            this.ptxHrUser.ValueMember = "user_id";
            this.ptxHrUser.WhereCmd = "";
            // 
            // uUSERBindingSource
            // 
            this.uUSERBindingSource.DataMember = "U_USER";
            this.uUSERBindingSource.DataSource = this.sysDS;
            // 
            // sysDS
            // 
            this.sysDS.DataSetName = "SysDS";
            this.sysDS.Locale = new System.Globalization.CultureInfo("");
            this.sysDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "HR人員";
            // 
            // pnlEmployee
            // 
            this.pnlEmployee.Controls.Add(this.ptxEmployee);
            this.pnlEmployee.Controls.Add(this.label4);
            this.pnlEmployee.Location = new System.Drawing.Point(3, 37);
            this.pnlEmployee.Name = "pnlEmployee";
            this.pnlEmployee.Size = new System.Drawing.Size(420, 28);
            this.pnlEmployee.TabIndex = 5;
            this.pnlEmployee.Visible = false;
            // 
            // ptxEmployee
            // 
            this.ptxEmployee.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxEmployee.CaptionLabel = null;
            this.ptxEmployee.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxEmployee.DataSource = this.vBASEBindingSource;
            this.ptxEmployee.DisplayMember = "name_c";
            this.ptxEmployee.IsEmpty = true;
            this.ptxEmployee.IsEmptyToQuery = true;
            this.ptxEmployee.IsMustBeFound = true;
            this.ptxEmployee.LabelText = "";
            this.ptxEmployee.Location = new System.Drawing.Point(62, 1);
            this.ptxEmployee.Name = "ptxEmployee";
            this.ptxEmployee.ReadOnly = false;
            this.ptxEmployee.ShowDisplayName = true;
            this.ptxEmployee.Size = new System.Drawing.Size(121, 22);
            this.ptxEmployee.TabIndex = 5;
            this.ptxEmployee.ValueMember = "nobr";
            this.ptxEmployee.WhereCmd = "";
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.mainDS;
            // 
            // mainDS
            // 
            this.mainDS.DataSetName = "MainDS";
            this.mainDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.mainDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "員工編號";
            // 
            // pnlEmail
            // 
            this.pnlEmail.Controls.Add(this.txtEmail);
            this.pnlEmail.Controls.Add(this.label5);
            this.pnlEmail.Location = new System.Drawing.Point(3, 71);
            this.pnlEmail.Name = "pnlEmail";
            this.pnlEmail.Size = new System.Drawing.Size(420, 28);
            this.pnlEmail.TabIndex = 6;
            this.pnlEmail.Visible = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtEmail.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtEmail.CaptionLabel = null;
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEmail.DecimalPlace = 2;
            this.txtEmail.IsEmpty = true;
            this.txtEmail.Location = new System.Drawing.Point(63, 2);
            this.txtEmail.Mask = "";
            this.txtEmail.MaxLength = -1;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.ReadOnly = false;
            this.txtEmail.ShowCalendarButton = true;
            this.txtEmail.Size = new System.Drawing.Size(254, 22);
            this.txtEmail.TabIndex = 22;
            this.txtEmail.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "電子郵件";
            // 
            // pnlDeptManager
            // 
            this.pnlDeptManager.Controls.Add(this.textBox1);
            this.pnlDeptManager.Controls.Add(this.label6);
            this.pnlDeptManager.Location = new System.Drawing.Point(3, 105);
            this.pnlDeptManager.Name = "pnlDeptManager";
            this.pnlDeptManager.Size = new System.Drawing.Size(420, 28);
            this.pnlDeptManager.TabIndex = 7;
            this.pnlDeptManager.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = null;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.DecimalPlace = 2;
            this.textBox1.Enabled = false;
            this.textBox1.IsEmpty = true;
            this.textBox1.Location = new System.Drawing.Point(64, 3);
            this.textBox1.Mask = "";
            this.textBox1.MaxLength = -1;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = true;
            this.textBox1.ShowCalendarButton = true;
            this.textBox1.Size = new System.Drawing.Size(121, 22);
            this.textBox1.TabIndex = 23;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "部門主管";
            // 
            // pnlSponsor
            // 
            this.pnlSponsor.Controls.Add(this.textBox2);
            this.pnlSponsor.Controls.Add(this.label7);
            this.pnlSponsor.Location = new System.Drawing.Point(3, 139);
            this.pnlSponsor.Name = "pnlSponsor";
            this.pnlSponsor.Size = new System.Drawing.Size(420, 28);
            this.pnlSponsor.TabIndex = 8;
            this.pnlSponsor.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = null;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.DecimalPlace = 2;
            this.textBox2.Enabled = false;
            this.textBox2.IsEmpty = true;
            this.textBox2.Location = new System.Drawing.Point(63, 3);
            this.textBox2.Mask = "";
            this.textBox2.MaxLength = -1;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ReadOnly = true;
            this.textBox2.ShowCalendarButton = true;
            this.textBox2.Size = new System.Drawing.Size(121, 22);
            this.textBox2.TabIndex = 23;
            this.textBox2.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "當事人";
            // 
            // btnHruser
            // 
            this.btnHruser.Location = new System.Drawing.Point(293, 152);
            this.btnHruser.Name = "btnHruser";
            this.btnHruser.Size = new System.Drawing.Size(81, 23);
            this.btnHruser.TabIndex = 3;
            this.btnHruser.Text = "儲存";
            this.btnHruser.UseVisualStyleBackColor = true;
            this.btnHruser.Click += new System.EventHandler(this.btnHruser_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.autoKeyDataGridViewTextBoxColumn,
            this.notifyTypeDataGridViewTextBoxColumn,
            this.selectButton,
            this.targetTypeDataGridViewTextBoxColumn,
            this.targetDataGridViewTextBoxColumn,
            this.memoDataGridViewTextBoxColumn,
            this.keyDateDataGridViewTextBoxColumn,
            this.keyManDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.notifyTemplateBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(26, 187);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(632, 297);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // autoKeyDataGridViewTextBoxColumn
            // 
            this.autoKeyDataGridViewTextBoxColumn.DataPropertyName = "AutoKey";
            this.autoKeyDataGridViewTextBoxColumn.HeaderText = "AutoKey";
            this.autoKeyDataGridViewTextBoxColumn.Name = "autoKeyDataGridViewTextBoxColumn";
            this.autoKeyDataGridViewTextBoxColumn.Visible = false;
            // 
            // notifyTypeDataGridViewTextBoxColumn
            // 
            this.notifyTypeDataGridViewTextBoxColumn.DataPropertyName = "NotifyType";
            this.notifyTypeDataGridViewTextBoxColumn.HeaderText = "NotifyType";
            this.notifyTypeDataGridViewTextBoxColumn.Name = "notifyTypeDataGridViewTextBoxColumn";
            this.notifyTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // selectButton
            // 
            this.selectButton.FillWeight = 50F;
            this.selectButton.HeaderText = "";
            this.selectButton.Name = "selectButton";
            this.selectButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.selectButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.selectButton.Text = "選取";
            this.selectButton.UseColumnTextForButtonValue = true;
            this.selectButton.Width = 50;
            // 
            // targetTypeDataGridViewTextBoxColumn
            // 
            this.targetTypeDataGridViewTextBoxColumn.DataPropertyName = "TargetType";
            this.targetTypeDataGridViewTextBoxColumn.DataSource = this.mTCODEBindingSource;
            this.targetTypeDataGridViewTextBoxColumn.DisplayMember = "NAME";
            this.targetTypeDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.targetTypeDataGridViewTextBoxColumn.HeaderText = "對象種類";
            this.targetTypeDataGridViewTextBoxColumn.Name = "targetTypeDataGridViewTextBoxColumn";
            this.targetTypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.targetTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.targetTypeDataGridViewTextBoxColumn.ValueMember = "CODE";
            // 
            // mTCODEBindingSource
            // 
            this.mTCODEBindingSource.DataMember = "MTCODE";
            this.mTCODEBindingSource.DataSource = this.mainDS;
            // 
            // targetDataGridViewTextBoxColumn
            // 
            this.targetDataGridViewTextBoxColumn.DataPropertyName = "Target";
            this.targetDataGridViewTextBoxColumn.HeaderText = "對象";
            this.targetDataGridViewTextBoxColumn.Name = "targetDataGridViewTextBoxColumn";
            // 
            // memoDataGridViewTextBoxColumn
            // 
            this.memoDataGridViewTextBoxColumn.DataPropertyName = "Memo";
            this.memoDataGridViewTextBoxColumn.HeaderText = "備註";
            this.memoDataGridViewTextBoxColumn.Name = "memoDataGridViewTextBoxColumn";
            // 
            // keyDateDataGridViewTextBoxColumn
            // 
            this.keyDateDataGridViewTextBoxColumn.DataPropertyName = "KeyDate";
            this.keyDateDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.keyDateDataGridViewTextBoxColumn.Name = "keyDateDataGridViewTextBoxColumn";
            // 
            // keyManDataGridViewTextBoxColumn
            // 
            this.keyManDataGridViewTextBoxColumn.DataPropertyName = "KeyMan";
            this.keyManDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.keyManDataGridViewTextBoxColumn.Name = "keyManDataGridViewTextBoxColumn";
            // 
            // notifyTemplateBindingSource
            // 
            this.notifyTemplateBindingSource.DataSource = typeof(JBModule.Data.Linq.NotifyTemplate);
            // 
            // u_USERTableAdapter
            // 
            this.u_USERTableAdapter.ClearBeforeFill = true;
            // 
            // txtMemo
            // 
            this.txtMemo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMemo.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtMemo.CaptionLabel = null;
            this.txtMemo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMemo.DecimalPlace = 2;
            this.txtMemo.IsEmpty = true;
            this.txtMemo.Location = new System.Drawing.Point(105, 122);
            this.txtMemo.Mask = "";
            this.txtMemo.MaxLength = -1;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.PasswordChar = '\0';
            this.txtMemo.ReadOnly = false;
            this.txtMemo.ShowCalendarButton = true;
            this.txtMemo.Size = new System.Drawing.Size(552, 22);
            this.txtMemo.TabIndex = 26;
            this.txtMemo.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(70, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 24;
            this.label9.Text = "備註";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(114, 152);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(27, 152);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // mTCODETableAdapter
            // 
            this.mTCODETableAdapter.ClearBeforeFill = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(201, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.BackgroundImage = global::JBHR.Properties.Resources.Settings_icon;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(234, 17);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(25, 23);
            this.btnConfig.TabIndex = 31;
            this.btnConfig.Tag = "FRM4I";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(469, 63);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(81, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "發送通知";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(556, 63);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(81, 23);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "檢視通知";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(469, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(81, 22);
            this.dateTimePicker1.TabIndex = 32;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(556, 25);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(81, 22);
            this.dateTimePicker2.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(411, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "通知日期";
            // 
            // U_NOTIFY
            // 
            this.ClientSize = new System.Drawing.Size(686, 495);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnHruser);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.cbxTargetType);
            this.Controls.Add(this.cbxNotifyType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.Name = "U_NOTIFY";
            this.Load += new System.EventHandler(this.U_NOTIFY_Load);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.pnlHrUser.ResumeLayout(false);
            this.pnlHrUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uUSERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).EndInit();
            this.pnlEmployee.ResumeLayout(false);
            this.pnlEmployee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).EndInit();
            this.pnlEmail.ResumeLayout(false);
            this.pnlEmail.PerformLayout();
            this.pnlDeptManager.ResumeLayout(false);
            this.pnlDeptManager.PerformLayout();
            this.pnlSponsor.ResumeLayout(false);
            this.pnlSponsor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notifyTemplateBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxNotifyType;
        private System.Windows.Forms.ComboBox cbxTargetType;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel pnlHrUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlEmployee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHruser;
        private JBControls.PopupTextBox ptxHrUser;
        private JBControls.PopupTextBox ptxEmployee;
        private System.Windows.Forms.Panel pnlEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlDeptManager;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnlSponsor;
        private System.Windows.Forms.Label label7;
        private JBControls.TextBox txtEmail;
        private JBControls.TextBox textBox1;
        private JBControls.TextBox textBox2;
        private SysDS sysDS;
        private System.Windows.Forms.BindingSource uUSERBindingSource;
        private SysDSTableAdapters.U_USERTableAdapter u_USERTableAdapter;
        private System.Windows.Forms.BindingSource notifyTemplateBindingSource;
        private JBControls.TextBox txtMemo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private MainDS mainDS;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private MainDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private System.Windows.Forms.BindingSource mTCODEBindingSource;
        private MainDSTableAdapters.MTCODETableAdapter mTCODETableAdapter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DataGridViewTextBoxColumn autoKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notifyTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn selectButton;
        private System.Windows.Forms.DataGridViewComboBoxColumn targetTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyManDataGridViewTextBoxColumn;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label8;
    }
}
