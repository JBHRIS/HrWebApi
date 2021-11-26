
namespace JBHR.Performance.HunyaCustom.Code
{
    partial class Hunya_PAGroupCode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtPABounsGroup_DISP = new JBControls.TextBox();
            this.PAGroupCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hunya_Performance = new JBHR.Performance.HunyaCustom.Hunya_Performance();
            this.lbPABounsGroup_DISP = new System.Windows.Forms.Label();
            this.txtPABasicValue = new JBControls.TextBox();
            this.lbPABonusBase = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv = new JBControls.DataGridView();
            this.aKDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pAGroupCodeDispDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pAGroupCodeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pABounsBaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyManDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.plFV = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbPABounsGroup_Name = new System.Windows.Forms.Label();
            this.txtPABounsGroup_Name = new JBControls.TextBox();
            this.btnPAFuntion = new System.Windows.Forms.Button();
            this.chkOtherBonusFlag = new JBControls.CheckBox();
            this.lbPAFunction = new System.Windows.Forms.Label();
            this.lbOtherBonusDept = new System.Windows.Forms.Label();
            this.cbxOtherBonusDept = new System.Windows.Forms.ComboBox();
            this.btnCodeGroup = new System.Windows.Forms.Button();
            this.fdc = new JBControls.FullDataCtrl();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.aKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAGroupCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAGroupCodeTableAdapter = new JBHR.Performance.HunyaCustom.Hunya_PerformanceTableAdapters.Hunya_PAGroupCodeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PAGroupCodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_Performance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.plFV.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPABounsGroup_DISP
            // 
            this.txtPABounsGroup_DISP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtPABounsGroup_DISP.CaptionLabel = null;
            this.txtPABounsGroup_DISP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPABounsGroup_DISP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PAGroupCodeBindingSource, "PAGroupCode_Disp", true));
            this.txtPABounsGroup_DISP.DecimalPlace = 2;
            this.txtPABounsGroup_DISP.IsEmpty = false;
            this.txtPABounsGroup_DISP.Location = new System.Drawing.Point(171, 3);
            this.txtPABounsGroup_DISP.Mask = "";
            this.txtPABounsGroup_DISP.MaxLength = 50;
            this.txtPABounsGroup_DISP.Name = "txtPABounsGroup_DISP";
            this.txtPABounsGroup_DISP.PasswordChar = '\0';
            this.txtPABounsGroup_DISP.ReadOnly = false;
            this.txtPABounsGroup_DISP.ShowCalendarButton = true;
            this.txtPABounsGroup_DISP.Size = new System.Drawing.Size(116, 22);
            this.txtPABounsGroup_DISP.TabIndex = 0;
            this.txtPABounsGroup_DISP.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // PAGroupCodeBindingSource
            // 
            this.PAGroupCodeBindingSource.DataMember = "Hunya_PAGroupCode";
            this.PAGroupCodeBindingSource.DataSource = this.hunya_Performance;
            // 
            // hunya_Performance
            // 
            this.hunya_Performance.DataSetName = "Hunya_Performance";
            this.hunya_Performance.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbPABounsGroup_DISP
            // 
            this.lbPABounsGroup_DISP.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPABounsGroup_DISP.AutoSize = true;
            this.lbPABounsGroup_DISP.ForeColor = System.Drawing.Color.Red;
            this.lbPABounsGroup_DISP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPABounsGroup_DISP.Location = new System.Drawing.Point(64, 8);
            this.lbPABounsGroup_DISP.Name = "lbPABounsGroup_DISP";
            this.lbPABounsGroup_DISP.Size = new System.Drawing.Size(101, 12);
            this.lbPABounsGroup_DISP.TabIndex = 0;
            this.lbPABounsGroup_DISP.Text = "績效獎金群組代碼";
            // 
            // txtPABasicValue
            // 
            this.txtPABasicValue.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtPABasicValue.CaptionLabel = null;
            this.txtPABasicValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPABasicValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PAGroupCodeBindingSource, "PABasicValue", true));
            this.txtPABasicValue.DecimalPlace = 2;
            this.txtPABasicValue.IsEmpty = false;
            this.txtPABasicValue.Location = new System.Drawing.Point(171, 59);
            this.txtPABasicValue.Mask = "";
            this.txtPABasicValue.MaxLength = -1;
            this.txtPABasicValue.Name = "txtPABasicValue";
            this.txtPABasicValue.PasswordChar = '\0';
            this.txtPABasicValue.ReadOnly = false;
            this.txtPABasicValue.ShowCalendarButton = true;
            this.txtPABasicValue.Size = new System.Drawing.Size(116, 22);
            this.txtPABasicValue.TabIndex = 2;
            this.txtPABasicValue.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // lbPABonusBase
            // 
            this.lbPABonusBase.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPABonusBase.AutoSize = true;
            this.lbPABonusBase.ForeColor = System.Drawing.Color.Red;
            this.lbPABonusBase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPABonusBase.Location = new System.Drawing.Point(112, 64);
            this.lbPABonusBase.Name = "lbPABonusBase";
            this.lbPABonusBase.Size = new System.Drawing.Size(53, 12);
            this.lbPABonusBase.TabIndex = 1;
            this.lbPABonusBase.Text = "獎金基數";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(784, 441);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 3;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aKDataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.pAGroupCodeDispDataGridViewTextBoxColumn,
            this.pAGroupCodeNameDataGridViewTextBoxColumn,
            this.pABounsBaseDataGridViewTextBoxColumn,
            this.keyManDataGridViewTextBoxColumn,
            this.keyDateDataGridViewTextBoxColumn,
            this.gIDDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.PAGroupCodeBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(784, 266);
            this.dgv.TabIndex = 7;
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // aKDataGridViewTextBoxColumn1
            // 
            this.aKDataGridViewTextBoxColumn1.DataPropertyName = "AK";
            this.aKDataGridViewTextBoxColumn1.HeaderText = "AK";
            this.aKDataGridViewTextBoxColumn1.Name = "aKDataGridViewTextBoxColumn1";
            this.aKDataGridViewTextBoxColumn1.ReadOnly = true;
            this.aKDataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PAGroupCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "PAGroupCode";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // pAGroupCodeDispDataGridViewTextBoxColumn
            // 
            this.pAGroupCodeDispDataGridViewTextBoxColumn.DataPropertyName = "PAGroupCode_Disp";
            this.pAGroupCodeDispDataGridViewTextBoxColumn.HeaderText = "獎金群組代碼";
            this.pAGroupCodeDispDataGridViewTextBoxColumn.Name = "pAGroupCodeDispDataGridViewTextBoxColumn";
            this.pAGroupCodeDispDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pAGroupCodeNameDataGridViewTextBoxColumn
            // 
            this.pAGroupCodeNameDataGridViewTextBoxColumn.DataPropertyName = "PAGroupCode_Name";
            this.pAGroupCodeNameDataGridViewTextBoxColumn.HeaderText = "獎金群組名稱";
            this.pAGroupCodeNameDataGridViewTextBoxColumn.Name = "pAGroupCodeNameDataGridViewTextBoxColumn";
            this.pAGroupCodeNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pABounsBaseDataGridViewTextBoxColumn
            // 
            this.pABounsBaseDataGridViewTextBoxColumn.DataPropertyName = "PABasicValue";
            this.pABounsBaseDataGridViewTextBoxColumn.HeaderText = "獎金基數";
            this.pABounsBaseDataGridViewTextBoxColumn.Name = "pABounsBaseDataGridViewTextBoxColumn";
            this.pABounsBaseDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // keyManDataGridViewTextBoxColumn
            // 
            this.keyManDataGridViewTextBoxColumn.DataPropertyName = "KeyMan";
            this.keyManDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.keyManDataGridViewTextBoxColumn.Name = "keyManDataGridViewTextBoxColumn";
            this.keyManDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // keyDateDataGridViewTextBoxColumn
            // 
            this.keyDateDataGridViewTextBoxColumn.DataPropertyName = "KeyDate";
            this.keyDateDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.keyDateDataGridViewTextBoxColumn.Name = "keyDateDataGridViewTextBoxColumn";
            this.keyDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gIDDataGridViewTextBoxColumn
            // 
            this.gIDDataGridViewTextBoxColumn.DataPropertyName = "GID";
            this.gIDDataGridViewTextBoxColumn.HeaderText = "GID";
            this.gIDDataGridViewTextBoxColumn.Name = "gIDDataGridViewTextBoxColumn";
            this.gIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.gIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.plFV);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnCodeGroup);
            this.splitContainer2.Panel2.Controls.Add(this.fdc);
            this.splitContainer2.Size = new System.Drawing.Size(784, 171);
            this.splitContainer2.SplitterDistance = 89;
            this.splitContainer2.TabIndex = 0;
            // 
            // plFV
            // 
            this.plFV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plFV.Controls.Add(this.tableLayoutPanel1);
            this.plFV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plFV.Location = new System.Drawing.Point(0, 0);
            this.plFV.Name = "plFV";
            this.plFV.Size = new System.Drawing.Size(784, 89);
            this.plFV.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.389716F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.52909F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.txtPABounsGroup_DISP, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbPABounsGroup_DISP, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbPABonusBase, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPABasicValue, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbPABounsGroup_Name, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPABounsGroup_Name, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnPAFuntion, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkOtherBonusFlag, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbPAFunction, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbOtherBonusDept, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxOtherBonusDept, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 85);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbPABounsGroup_Name
            // 
            this.lbPABounsGroup_Name.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPABounsGroup_Name.AutoSize = true;
            this.lbPABounsGroup_Name.ForeColor = System.Drawing.Color.Red;
            this.lbPABounsGroup_Name.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPABounsGroup_Name.Location = new System.Drawing.Point(64, 36);
            this.lbPABounsGroup_Name.Name = "lbPABounsGroup_Name";
            this.lbPABounsGroup_Name.Size = new System.Drawing.Size(101, 12);
            this.lbPABounsGroup_Name.TabIndex = 13;
            this.lbPABounsGroup_Name.Text = "績效獎金群組名稱";
            // 
            // txtPABounsGroup_Name
            // 
            this.txtPABounsGroup_Name.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtPABounsGroup_Name.CaptionLabel = null;
            this.txtPABounsGroup_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPABounsGroup_Name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PAGroupCodeBindingSource, "PAGroupCode_Name", true));
            this.txtPABounsGroup_Name.DecimalPlace = 2;
            this.txtPABounsGroup_Name.IsEmpty = false;
            this.txtPABounsGroup_Name.Location = new System.Drawing.Point(171, 31);
            this.txtPABounsGroup_Name.Mask = "";
            this.txtPABounsGroup_Name.MaxLength = 50;
            this.txtPABounsGroup_Name.Name = "txtPABounsGroup_Name";
            this.txtPABounsGroup_Name.PasswordChar = '\0';
            this.txtPABounsGroup_Name.ReadOnly = false;
            this.txtPABounsGroup_Name.ShowCalendarButton = true;
            this.txtPABounsGroup_Name.Size = new System.Drawing.Size(116, 22);
            this.txtPABounsGroup_Name.TabIndex = 1;
            this.txtPABounsGroup_Name.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // btnPAFuntion
            // 
            this.btnPAFuntion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnPAFuntion, 2);
            this.btnPAFuntion.Location = new System.Drawing.Point(467, 32);
            this.btnPAFuntion.Name = "btnPAFuntion";
            this.btnPAFuntion.Size = new System.Drawing.Size(289, 20);
            this.btnPAFuntion.TabIndex = 5;
            this.btnPAFuntion.Text = "請選擇績效獎金公式";
            this.btnPAFuntion.UseVisualStyleBackColor = true;
            // 
            // chkOtherBonusFlag
            // 
            this.chkOtherBonusFlag.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkOtherBonusFlag.AutoSize = true;
            this.chkOtherBonusFlag.CaptionLabel = null;
            this.chkOtherBonusFlag.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.PAGroupCodeBindingSource, "PAOtherBonusFlag", true));
            this.chkOtherBonusFlag.IsImitateCaption = true;
            this.chkOtherBonusFlag.Location = new System.Drawing.Point(377, 6);
            this.chkOtherBonusFlag.Name = "chkOtherBonusFlag";
            this.chkOtherBonusFlag.Size = new System.Drawing.Size(84, 16);
            this.chkOtherBonusFlag.TabIndex = 3;
            this.chkOtherBonusFlag.TabStop = false;
            this.chkOtherBonusFlag.Text = "第二段獎金";
            this.chkOtherBonusFlag.UseVisualStyleBackColor = true;
            // 
            // lbPAFunction
            // 
            this.lbPAFunction.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPAFunction.AutoSize = true;
            this.lbPAFunction.ForeColor = System.Drawing.Color.Red;
            this.lbPAFunction.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPAFunction.Location = new System.Drawing.Point(408, 36);
            this.lbPAFunction.Name = "lbPAFunction";
            this.lbPAFunction.Size = new System.Drawing.Size(53, 12);
            this.lbPAFunction.TabIndex = 39;
            this.lbPAFunction.Text = "獎金公式";
            // 
            // lbOtherBonusDept
            // 
            this.lbOtherBonusDept.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbOtherBonusDept.AutoSize = true;
            this.lbOtherBonusDept.Location = new System.Drawing.Point(470, 8);
            this.lbOtherBonusDept.Name = "lbOtherBonusDept";
            this.lbOtherBonusDept.Size = new System.Drawing.Size(53, 12);
            this.lbOtherBonusDept.TabIndex = 40;
            this.lbOtherBonusDept.Text = "對應部門";
            // 
            // cbxOtherBonusDept
            // 
            this.cbxOtherBonusDept.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxOtherBonusDept.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.PAGroupCodeBindingSource, "PAOtherBonusDept", true));
            this.cbxOtherBonusDept.FormattingEnabled = true;
            this.cbxOtherBonusDept.Location = new System.Drawing.Point(529, 4);
            this.cbxOtherBonusDept.Name = "cbxOtherBonusDept";
            this.cbxOtherBonusDept.Size = new System.Drawing.Size(121, 20);
            this.cbxOtherBonusDept.TabIndex = 4;
            // 
            // btnCodeGroup
            // 
            this.btnCodeGroup.Location = new System.Drawing.Point(637, 5);
            this.btnCodeGroup.Name = "btnCodeGroup";
            this.btnCodeGroup.Size = new System.Drawing.Size(75, 23);
            this.btnCodeGroup.TabIndex = 4;
            this.btnCodeGroup.TabStop = false;
            this.btnCodeGroup.Text = "代碼群組";
            this.btnCodeGroup.UseVisualStyleBackColor = true;
            this.btnCodeGroup.Click += new System.EventHandler(this.btnCodeGroup_Click);
            // 
            // fdc
            // 
            this.fdc.AllowModifyPrimaryKey = false;
            this.fdc.BindingCtrlsAutoInit = true;
            this.fdc.bnAddEnable = true;
            this.fdc.bnAddVisible = true;
            this.fdc.bnCancelEnable = true;
            this.fdc.bnCancelVisible = true;
            this.fdc.bnDelEnable = true;
            this.fdc.bnDelVisible = true;
            this.fdc.bnEditEnable = true;
            this.fdc.bnEditVisible = true;
            this.fdc.bnExportEnable = true;
            this.fdc.bnExportVisible = true;
            this.fdc.bnQueryEnable = true;
            this.fdc.bnQueryVisible = true;
            this.fdc.bnSaveEnable = true;
            this.fdc.bnSaveVisible = true;
            this.fdc.CtrlType = JBControls.FullDataCtrl.ECtrlType.Full;
            this.fdc.DataAdapter = null;
            this.fdc.DataGrid = this.dgv;
            this.fdc.DataSource = this.PAGroupCodeBindingSource;
            this.fdc.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fdc.EnableAutoClone = false;
            this.fdc.GroupCmd = "";
            this.fdc.Location = new System.Drawing.Point(2, 2);
            this.fdc.Name = "fdc";
            this.fdc.RecentQuerySql = "";
            this.fdc.SelectCmd = "";
            this.fdc.ShowExceptionMsg = true;
            this.fdc.Size = new System.Drawing.Size(632, 73);
            this.fdc.TabIndex = 0;
            this.fdc.WhereCmd = "";
            this.fdc.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterAdd);
            this.fdc.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterEdit);
            this.fdc.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterDel);
            this.fdc.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fdc_BeforeSave);
            this.fdc.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterSave);
            this.fdc.AfterCancel += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterCancel);
            this.fdc.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterExport);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // aKDataGridViewTextBoxColumn
            // 
            this.aKDataGridViewTextBoxColumn.DataPropertyName = "AK";
            this.aKDataGridViewTextBoxColumn.HeaderText = "AK";
            this.aKDataGridViewTextBoxColumn.Name = "aKDataGridViewTextBoxColumn";
            this.aKDataGridViewTextBoxColumn.Visible = false;
            // 
            // PAGroupCode
            // 
            this.PAGroupCode.DataPropertyName = "PAGroupCode";
            this.PAGroupCode.HeaderText = "PAGroupCode";
            this.PAGroupCode.Name = "PAGroupCode";
            // 
            // PAGroupCodeTableAdapter
            // 
            this.PAGroupCodeTableAdapter.ClearBeforeFill = true;
            // 
            // Hunya_PAGroupCode
            // 
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "Hunya_PAGroupCode";
            this.Text = "Hunya_PAGroupCode";
            this.Load += new System.EventHandler(this.Hunya_PAGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PAGroupCodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_Performance)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.plFV.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JBControls.TextBox txtPABounsGroup_DISP;
        private System.Windows.Forms.Label lbPABounsGroup_DISP;
        private JBControls.TextBox txtPABasicValue;
        private System.Windows.Forms.Label lbPABonusBase;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private JBControls.DataGridView dgv;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel plFV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private JBControls.FullDataCtrl fdc;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.BindingSource PAGroupCodeBindingSource;
        private Hunya_PerformanceTableAdapters.Hunya_PAGroupCodeTableAdapter PAGroupCodeTableAdapter;
        private Hunya_Performance hunya_Performance;
        private System.Windows.Forms.Button btnCodeGroup;
        private System.Windows.Forms.Label lbPABounsGroup_Name;
        private JBControls.TextBox txtPABounsGroup_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn pAGroupCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAGroupCode_Disp;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAGroupCode_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn aKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAGroupCode;
        private JBControls.CheckBox chkOtherBonusFlag;
        private System.Windows.Forms.Button btnPAFuntion;
        private System.Windows.Forms.Label lbPAFunction;
        private System.Windows.Forms.DataGridViewTextBoxColumn aKDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pAGroupCodeDispDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pAGroupCodeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pABounsBaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyManDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lbOtherBonusDept;
        private System.Windows.Forms.ComboBox cbxOtherBonusDept;
    }
}
