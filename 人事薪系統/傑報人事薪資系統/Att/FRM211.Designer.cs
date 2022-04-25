namespace JBHR.Att
{
    partial class FRM211
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv = new JBControls.DataGridView();
            this.H_CODE_DISP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hENAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uNITDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yEARRESTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bsHCODE = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.sEXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mINNUMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dISAPPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mAXNUMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aBSUNITDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sORTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mANGDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nOTDELDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nOTSUMDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.eFFFOODDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.aTTDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.STATION = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.eFNIGHTDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cALOTDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.iNHOLIDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cHEDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dISPLAYFORMDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnConfig = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox1 = new JBControls.CheckBox();
            this.checkBox2 = new JBControls.CheckBox();
            this.checkBox5 = new JBControls.CheckBox();
            this.checkBox3 = new JBControls.CheckBox();
            this.checkBox4 = new JBControls.CheckBox();
            this.checkBox6 = new JBControls.CheckBox();
            this.checkBox7 = new JBControls.CheckBox();
            this.checkBox8 = new JBControls.CheckBox();
            this.checkBox9 = new JBControls.CheckBox();
            this.checkBox10 = new JBControls.CheckBox();
            this.checkBox11 = new JBControls.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox8 = new JBControls.TextBox();
            this.textBox6 = new JBControls.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox5 = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new JBControls.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox3 = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new JBControls.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox7 = new JBControls.TextBox();
            this.comboBoxFlag = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxHtype = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.buttonLNG = new System.Windows.Forms.Button();
            this.btnCodeGroup = new System.Windows.Forms.Button();
            this.btnFRM211D = new System.Windows.Forms.Button();
            this.fdc = new JBControls.FullDataCtrl();
            this.bsYEAR_REST = new System.Windows.Forms.BindingSource(this.components);
            this.dsView = new JBHR.Att.dsView();
            this.bsUNIT = new System.Windows.Forms.BindingSource(this.components);
            this.bsSEX = new System.Windows.Forms.BindingSource(this.components);
            this.taUNIT = new JBHR.Att.dsViewTableAdapters.UNITTableAdapter();
            this.taYEAR_REST = new JBHR.Att.dsViewTableAdapters.YEAR_RESTTableAdapter();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.taSEX = new JBHR.Att.dsViewTableAdapters.SEXTableAdapter();
            this.hCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taHCODE = new JBHR.Att.dsAttTableAdapters.HCODETableAdapter();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox9 = new JBControls.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsHCODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsYEAR_REST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUNIT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hCODEBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(784, 561);
            this.splitContainer1.SplitterDistance = 279;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
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
            this.H_CODE_DISP,
            this.hNAMEDataGridViewTextBoxColumn,
            this.hENAMEDataGridViewTextBoxColumn,
            this.uNITDataGridViewTextBoxColumn,
            this.yEARRESTDataGridViewTextBoxColumn,
            this.dCODEDataGridViewTextBoxColumn,
            this.sEXDataGridViewTextBoxColumn,
            this.mINNUMDataGridViewTextBoxColumn,
            this.dISAPPDataGridViewTextBoxColumn,
            this.mAXNUMDataGridViewTextBoxColumn,
            this.aBSUNITDataGridViewTextBoxColumn,
            this.sORTDataGridViewTextBoxColumn,
            this.mANGDataGridViewCheckBoxColumn,
            this.nOTDELDataGridViewCheckBoxColumn,
            this.nOTSUMDataGridViewCheckBoxColumn,
            this.eFFFOODDataGridViewCheckBoxColumn,
            this.aTTDataGridViewCheckBoxColumn,
            this.STATION,
            this.eFNIGHTDataGridViewCheckBoxColumn,
            this.cALOTDataGridViewCheckBoxColumn,
            this.iNHOLIDataGridViewCheckBoxColumn,
            this.cHEDataGridViewCheckBoxColumn,
            this.dISPLAYFORMDataGridViewCheckBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.bsHCODE;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(784, 279);
            this.dgv.TabIndex = 7;
            // 
            // H_CODE_DISP
            // 
            this.H_CODE_DISP.DataPropertyName = "H_CODE_DISP";
            this.H_CODE_DISP.HeaderText = "假別代碼";
            this.H_CODE_DISP.Name = "H_CODE_DISP";
            this.H_CODE_DISP.ReadOnly = true;
            this.H_CODE_DISP.Width = 78;
            // 
            // hNAMEDataGridViewTextBoxColumn
            // 
            this.hNAMEDataGridViewTextBoxColumn.DataPropertyName = "H_NAME";
            this.hNAMEDataGridViewTextBoxColumn.HeaderText = "假別名稱";
            this.hNAMEDataGridViewTextBoxColumn.Name = "hNAMEDataGridViewTextBoxColumn";
            this.hNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.hNAMEDataGridViewTextBoxColumn.Width = 78;
            // 
            // hENAMEDataGridViewTextBoxColumn
            // 
            this.hENAMEDataGridViewTextBoxColumn.DataPropertyName = "H_ENAME";
            this.hENAMEDataGridViewTextBoxColumn.HeaderText = "英文假別名稱";
            this.hENAMEDataGridViewTextBoxColumn.Name = "hENAMEDataGridViewTextBoxColumn";
            this.hENAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.hENAMEDataGridViewTextBoxColumn.Width = 102;
            // 
            // uNITDataGridViewTextBoxColumn
            // 
            this.uNITDataGridViewTextBoxColumn.DataPropertyName = "UNIT";
            this.uNITDataGridViewTextBoxColumn.HeaderText = "單位";
            this.uNITDataGridViewTextBoxColumn.Name = "uNITDataGridViewTextBoxColumn";
            this.uNITDataGridViewTextBoxColumn.ReadOnly = true;
            this.uNITDataGridViewTextBoxColumn.Width = 54;
            // 
            // yEARRESTDataGridViewTextBoxColumn
            // 
            this.yEARRESTDataGridViewTextBoxColumn.DataPropertyName = "YEAR_REST";
            this.yEARRESTDataGridViewTextBoxColumn.HeaderText = "年補休特性";
            this.yEARRESTDataGridViewTextBoxColumn.Name = "yEARRESTDataGridViewTextBoxColumn";
            this.yEARRESTDataGridViewTextBoxColumn.ReadOnly = true;
            this.yEARRESTDataGridViewTextBoxColumn.Width = 90;
            // 
            // dCODEDataGridViewTextBoxColumn
            // 
            this.dCODEDataGridViewTextBoxColumn.DataPropertyName = "DCODE";
            this.dCODEDataGridViewTextBoxColumn.DataSource = this.bsHCODE;
            this.dCODEDataGridViewTextBoxColumn.DisplayMember = "H_NAME";
            this.dCODEDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dCODEDataGridViewTextBoxColumn.HeaderText = "合併檢查假別";
            this.dCODEDataGridViewTextBoxColumn.Name = "dCODEDataGridViewTextBoxColumn";
            this.dCODEDataGridViewTextBoxColumn.ReadOnly = true;
            this.dCODEDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dCODEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dCODEDataGridViewTextBoxColumn.ValueMember = "H_CODE";
            this.dCODEDataGridViewTextBoxColumn.Width = 102;
            // 
            // bsHCODE
            // 
            this.bsHCODE.DataMember = "HCODE";
            this.bsHCODE.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sEXDataGridViewTextBoxColumn
            // 
            this.sEXDataGridViewTextBoxColumn.DataPropertyName = "SEX";
            this.sEXDataGridViewTextBoxColumn.HeaderText = "指定性別";
            this.sEXDataGridViewTextBoxColumn.Name = "sEXDataGridViewTextBoxColumn";
            this.sEXDataGridViewTextBoxColumn.ReadOnly = true;
            this.sEXDataGridViewTextBoxColumn.Width = 78;
            // 
            // mINNUMDataGridViewTextBoxColumn
            // 
            this.mINNUMDataGridViewTextBoxColumn.DataPropertyName = "MIN_NUM";
            this.mINNUMDataGridViewTextBoxColumn.HeaderText = "最小數";
            this.mINNUMDataGridViewTextBoxColumn.Name = "mINNUMDataGridViewTextBoxColumn";
            this.mINNUMDataGridViewTextBoxColumn.ReadOnly = true;
            this.mINNUMDataGridViewTextBoxColumn.Width = 66;
            // 
            // dISAPPDataGridViewTextBoxColumn
            // 
            this.dISAPPDataGridViewTextBoxColumn.DataPropertyName = "DIS_APP";
            this.dISAPPDataGridViewTextBoxColumn.HeaderText = "扣考核分數";
            this.dISAPPDataGridViewTextBoxColumn.Name = "dISAPPDataGridViewTextBoxColumn";
            this.dISAPPDataGridViewTextBoxColumn.ReadOnly = true;
            this.dISAPPDataGridViewTextBoxColumn.Width = 90;
            // 
            // mAXNUMDataGridViewTextBoxColumn
            // 
            this.mAXNUMDataGridViewTextBoxColumn.DataPropertyName = "MAX_NUM";
            this.mAXNUMDataGridViewTextBoxColumn.HeaderText = "可休最大數(年)";
            this.mAXNUMDataGridViewTextBoxColumn.Name = "mAXNUMDataGridViewTextBoxColumn";
            this.mAXNUMDataGridViewTextBoxColumn.ReadOnly = true;
            this.mAXNUMDataGridViewTextBoxColumn.Width = 114;
            // 
            // aBSUNITDataGridViewTextBoxColumn
            // 
            this.aBSUNITDataGridViewTextBoxColumn.DataPropertyName = "ABSUNIT";
            this.aBSUNITDataGridViewTextBoxColumn.HeaderText = "請假每間隔最小分鐘數";
            this.aBSUNITDataGridViewTextBoxColumn.Name = "aBSUNITDataGridViewTextBoxColumn";
            this.aBSUNITDataGridViewTextBoxColumn.ReadOnly = true;
            this.aBSUNITDataGridViewTextBoxColumn.Width = 150;
            // 
            // sORTDataGridViewTextBoxColumn
            // 
            this.sORTDataGridViewTextBoxColumn.DataPropertyName = "SORT";
            this.sORTDataGridViewTextBoxColumn.HeaderText = "排序";
            this.sORTDataGridViewTextBoxColumn.Name = "sORTDataGridViewTextBoxColumn";
            this.sORTDataGridViewTextBoxColumn.ReadOnly = true;
            this.sORTDataGridViewTextBoxColumn.Width = 54;
            // 
            // mANGDataGridViewCheckBoxColumn
            // 
            this.mANGDataGridViewCheckBoxColumn.DataPropertyName = "MANG";
            this.mANGDataGridViewCheckBoxColumn.HeaderText = "系統";
            this.mANGDataGridViewCheckBoxColumn.Name = "mANGDataGridViewCheckBoxColumn";
            this.mANGDataGridViewCheckBoxColumn.ReadOnly = true;
            this.mANGDataGridViewCheckBoxColumn.Width = 35;
            // 
            // nOTDELDataGridViewCheckBoxColumn
            // 
            this.nOTDELDataGridViewCheckBoxColumn.DataPropertyName = "NOT_DEL";
            this.nOTDELDataGridViewCheckBoxColumn.HeaderText = "不列印";
            this.nOTDELDataGridViewCheckBoxColumn.Name = "nOTDELDataGridViewCheckBoxColumn";
            this.nOTDELDataGridViewCheckBoxColumn.ReadOnly = true;
            this.nOTDELDataGridViewCheckBoxColumn.Width = 47;
            // 
            // nOTSUMDataGridViewCheckBoxColumn
            // 
            this.nOTSUMDataGridViewCheckBoxColumn.DataPropertyName = "NOT_SUM";
            this.nOTSUMDataGridViewCheckBoxColumn.HeaderText = "不彙總";
            this.nOTSUMDataGridViewCheckBoxColumn.Name = "nOTSUMDataGridViewCheckBoxColumn";
            this.nOTSUMDataGridViewCheckBoxColumn.ReadOnly = true;
            this.nOTSUMDataGridViewCheckBoxColumn.Width = 47;
            // 
            // eFFFOODDataGridViewCheckBoxColumn
            // 
            this.eFFFOODDataGridViewCheckBoxColumn.DataPropertyName = "EFF_FOOD";
            this.eFFFOODDataGridViewCheckBoxColumn.HeaderText = "影響誤餐費";
            this.eFFFOODDataGridViewCheckBoxColumn.Name = "eFFFOODDataGridViewCheckBoxColumn";
            this.eFFFOODDataGridViewCheckBoxColumn.ReadOnly = true;
            this.eFFFOODDataGridViewCheckBoxColumn.Width = 71;
            // 
            // aTTDataGridViewCheckBoxColumn
            // 
            this.aTTDataGridViewCheckBoxColumn.DataPropertyName = "ATT";
            this.aTTDataGridViewCheckBoxColumn.HeaderText = "影響全勤";
            this.aTTDataGridViewCheckBoxColumn.Name = "aTTDataGridViewCheckBoxColumn";
            this.aTTDataGridViewCheckBoxColumn.ReadOnly = true;
            this.aTTDataGridViewCheckBoxColumn.Width = 59;
            // 
            // STATION
            // 
            this.STATION.DataPropertyName = "STATION";
            this.STATION.HeaderText = "影響環境津貼";
            this.STATION.Name = "STATION";
            this.STATION.ReadOnly = true;
            this.STATION.Width = 83;
            // 
            // eFNIGHTDataGridViewCheckBoxColumn
            // 
            this.eFNIGHTDataGridViewCheckBoxColumn.DataPropertyName = "EF_NIGHT";
            this.eFNIGHTDataGridViewCheckBoxColumn.HeaderText = "影響輪班津貼";
            this.eFNIGHTDataGridViewCheckBoxColumn.Name = "eFNIGHTDataGridViewCheckBoxColumn";
            this.eFNIGHTDataGridViewCheckBoxColumn.ReadOnly = true;
            this.eFNIGHTDataGridViewCheckBoxColumn.Width = 83;
            // 
            // cALOTDataGridViewCheckBoxColumn
            // 
            this.cALOTDataGridViewCheckBoxColumn.DataPropertyName = "CALOT";
            this.cALOTDataGridViewCheckBoxColumn.HeaderText = "當日上班算加班";
            this.cALOTDataGridViewCheckBoxColumn.Name = "cALOTDataGridViewCheckBoxColumn";
            this.cALOTDataGridViewCheckBoxColumn.ReadOnly = true;
            this.cALOTDataGridViewCheckBoxColumn.Width = 95;
            // 
            // iNHOLIDataGridViewCheckBoxColumn
            // 
            this.iNHOLIDataGridViewCheckBoxColumn.DataPropertyName = "IN_HOLI";
            this.iNHOLIDataGridViewCheckBoxColumn.HeaderText = "含假日(不計班別津貼)";
            this.iNHOLIDataGridViewCheckBoxColumn.Name = "iNHOLIDataGridViewCheckBoxColumn";
            this.iNHOLIDataGridViewCheckBoxColumn.ReadOnly = true;
            this.iNHOLIDataGridViewCheckBoxColumn.Width = 131;
            // 
            // cHEDataGridViewCheckBoxColumn
            // 
            this.cHEDataGridViewCheckBoxColumn.DataPropertyName = "CHE";
            this.cHEDataGridViewCheckBoxColumn.HeaderText = "檢查假別剩餘時數";
            this.cHEDataGridViewCheckBoxColumn.Name = "cHEDataGridViewCheckBoxColumn";
            this.cHEDataGridViewCheckBoxColumn.ReadOnly = true;
            this.cHEDataGridViewCheckBoxColumn.Width = 107;
            // 
            // dISPLAYFORMDataGridViewCheckBoxColumn
            // 
            this.dISPLAYFORMDataGridViewCheckBoxColumn.DataPropertyName = "DISPLAYFORM";
            this.dISPLAYFORMDataGridViewCheckBoxColumn.HeaderText = "請假資訊顯示與否";
            this.dISPLAYFORMDataGridViewCheckBoxColumn.Name = "dISPLAYFORMDataGridViewCheckBoxColumn";
            this.dISPLAYFORMDataGridViewCheckBoxColumn.ReadOnly = true;
            this.dISPLAYFORMDataGridViewCheckBoxColumn.Width = 107;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYMANDataGridViewTextBoxColumn.Width = 66;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYDATEDataGridViewTextBoxColumn.Width = 78;
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
            this.splitContainer2.Panel1.Controls.Add(this.btnConfig);
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.comboBox3);
            this.splitContainer2.Panel1.Controls.Add(this.textBox9);
            this.splitContainer2.Panel1.Controls.Add(this.label14);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.buttonLNG);
            this.splitContainer2.Panel2.Controls.Add(this.btnCodeGroup);
            this.splitContainer2.Panel2.Controls.Add(this.btnFRM211D);
            this.splitContainer2.Panel2.Controls.Add(this.fdc);
            this.splitContainer2.Size = new System.Drawing.Size(784, 278);
            this.splitContainer2.SplitterDistance = 197;
            this.splitContainer2.TabIndex = 1;
            // 
            // btnConfig
            // 
            this.btnConfig.BackgroundImage = global::JBHR.Properties.Resources.Settings_icon;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(758, 3);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(25, 23);
            this.btnConfig.TabIndex = 1;
            this.btnConfig.TabStop = false;
            this.btnConfig.Tag = "FRM211";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.checkBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkBox5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.checkBox3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.checkBox4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.checkBox6, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBox7, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkBox8, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.checkBox9, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.checkBox10, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.checkBox11, 0, 5);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(401, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(304, 164);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox1.AutoSize = true;
            this.checkBox1.CaptionLabel = null;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsHCODE, "MANG", true));
            this.checkBox1.IsImitateCaption = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "系統";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox2.AutoSize = true;
            this.checkBox2.CaptionLabel = null;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsHCODE, "NOT_DEL", true));
            this.checkBox2.IsImitateCaption = true;
            this.checkBox2.Location = new System.Drawing.Point(3, 31);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(60, 16);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.TabStop = false;
            this.checkBox2.Text = "不列印";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox5.AutoSize = true;
            this.checkBox5.CaptionLabel = null;
            this.checkBox5.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsHCODE, "ATT", true));
            this.checkBox5.IsImitateCaption = true;
            this.checkBox5.Location = new System.Drawing.Point(3, 109);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(72, 16);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.TabStop = false;
            this.checkBox5.Text = "影響全勤";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox3.AutoSize = true;
            this.checkBox3.CaptionLabel = null;
            this.checkBox3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsHCODE, "NOT_SUM", true));
            this.checkBox3.IsImitateCaption = true;
            this.checkBox3.Location = new System.Drawing.Point(3, 57);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(60, 16);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.TabStop = false;
            this.checkBox3.Text = "不彙總";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox4.AutoSize = true;
            this.checkBox4.CaptionLabel = null;
            this.checkBox4.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsHCODE, "EFF_FOOD", true));
            this.checkBox4.IsImitateCaption = true;
            this.checkBox4.Location = new System.Drawing.Point(3, 83);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(84, 16);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.TabStop = false;
            this.checkBox4.Text = "影響誤餐費";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox6.AutoSize = true;
            this.checkBox6.CaptionLabel = null;
            this.checkBox6.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsHCODE, "EF_NIGHT", true));
            this.checkBox6.IsImitateCaption = true;
            this.checkBox6.Location = new System.Drawing.Point(105, 5);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(96, 16);
            this.checkBox6.TabIndex = 6;
            this.checkBox6.TabStop = false;
            this.checkBox6.Text = "影響輪班津貼";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox7.AutoSize = true;
            this.checkBox7.CaptionLabel = null;
            this.checkBox7.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsHCODE, "CALOT", true));
            this.checkBox7.IsImitateCaption = true;
            this.checkBox7.Location = new System.Drawing.Point(105, 31);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(108, 16);
            this.checkBox7.TabIndex = 7;
            this.checkBox7.TabStop = false;
            this.checkBox7.Text = "當日上班算加班";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox8.AutoSize = true;
            this.checkBox8.CaptionLabel = null;
            this.checkBox8.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsHCODE, "IN_HOLI", true));
            this.checkBox8.IsImitateCaption = true;
            this.checkBox8.Location = new System.Drawing.Point(105, 57);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(144, 16);
            this.checkBox8.TabIndex = 8;
            this.checkBox8.TabStop = false;
            this.checkBox8.Text = "含假日(不計班別津貼)";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox9.AutoSize = true;
            this.checkBox9.CaptionLabel = null;
            this.checkBox9.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsHCODE, "CHE", true));
            this.checkBox9.IsImitateCaption = true;
            this.checkBox9.Location = new System.Drawing.Point(105, 83);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(120, 16);
            this.checkBox9.TabIndex = 9;
            this.checkBox9.TabStop = false;
            this.checkBox9.Text = "檢查假別剩餘時數";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox10.AutoSize = true;
            this.checkBox10.CaptionLabel = null;
            this.checkBox10.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsHCODE, "DISPLAYFORM", true));
            this.checkBox10.IsImitateCaption = true;
            this.checkBox10.Location = new System.Drawing.Point(105, 109);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(120, 16);
            this.checkBox10.TabIndex = 10;
            this.checkBox10.TabStop = false;
            this.checkBox10.Text = "請假資訊顯示與否";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox11.AutoSize = true;
            this.checkBox11.CaptionLabel = null;
            this.checkBox11.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsHCODE, "STATION", true));
            this.checkBox11.IsImitateCaption = true;
            this.checkBox11.Location = new System.Drawing.Point(3, 139);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(96, 16);
            this.checkBox11.TabIndex = 5;
            this.checkBox11.TabStop = false;
            this.checkBox11.Text = "影響環境津貼";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.textBox8, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox6, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox5, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox4, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label12, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox7, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxFlag, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.comboBox4, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label13, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxHtype, 3, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(401, 164);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // textBox8
            // 
            this.textBox8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox8.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox8.CaptionLabel = null;
            this.textBox8.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox8.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHCODE, "ABSUNIT", true));
            this.textBox8.DecimalPlace = 2;
            this.textBox8.IsEmpty = true;
            this.textBox8.Location = new System.Drawing.Point(287, 81);
            this.textBox8.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.textBox8.Mask = "";
            this.textBox8.MaxLength = -1;
            this.textBox8.Name = "textBox8";
            this.textBox8.PasswordChar = '\0';
            this.textBox8.ReadOnly = false;
            this.textBox8.ShowCalendarButton = true;
            this.textBox8.Size = new System.Drawing.Size(60, 22);
            this.textBox8.TabIndex = 9;
            this.textBox8.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // textBox6
            // 
            this.textBox6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox6.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox6.CaptionLabel = this.label9;
            this.textBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHCODE, "MAX_NUM", true));
            this.textBox6.DecimalPlace = 2;
            this.textBox6.IsEmpty = true;
            this.textBox6.Location = new System.Drawing.Point(287, 55);
            this.textBox6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.textBox6.Mask = "";
            this.textBox6.MaxLength = -1;
            this.textBox6.Name = "textBox6";
            this.textBox6.PasswordChar = '\0';
            this.textBox6.ReadOnly = false;
            this.textBox6.ShowCalendarButton = true;
            this.textBox6.Size = new System.Drawing.Size(60, 22);
            this.textBox6.TabIndex = 8;
            this.textBox6.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(192, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "可休最大數(年)";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox5.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox5.CaptionLabel = this.label4;
            this.textBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHCODE, "H_ENAME", true));
            this.textBox5.DecimalPlace = 2;
            this.textBox5.IsEmpty = true;
            this.textBox5.Location = new System.Drawing.Point(86, 55);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.textBox5.Mask = "";
            this.textBox5.MaxLength = 50;
            this.textBox5.Name = "textBox5";
            this.textBox5.PasswordChar = '\0';
            this.textBox5.ReadOnly = false;
            this.textBox5.ShowCalendarButton = true;
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 2;
            this.textBox5.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "英文假別名稱";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox4.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox4.CaptionLabel = this.label10;
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHCODE, "DIS_APP", true));
            this.textBox4.DecimalPlace = 2;
            this.textBox4.IsEmpty = true;
            this.textBox4.Location = new System.Drawing.Point(287, 29);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.textBox4.Mask = "";
            this.textBox4.MaxLength = -1;
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '\0';
            this.textBox4.ReadOnly = false;
            this.textBox4.ShowCalendarButton = true;
            this.textBox4.Size = new System.Drawing.Size(60, 22);
            this.textBox4.TabIndex = 7;
            this.textBox4.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(216, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "扣考核分數";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox3.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox3.CaptionLabel = this.label3;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHCODE, "H_NAME", true));
            this.textBox3.DecimalPlace = 2;
            this.textBox3.IsEmpty = false;
            this.textBox3.Location = new System.Drawing.Point(86, 29);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.textBox3.Mask = "";
            this.textBox3.MaxLength = 50;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '\0';
            this.textBox3.ReadOnly = false;
            this.textBox3.ShowCalendarButton = true;
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 1;
            this.textBox3.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(27, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "假別名稱";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = this.label2;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHCODE, "MIN_NUM", true));
            this.textBox2.DecimalPlace = 2;
            this.textBox2.IsEmpty = true;
            this.textBox2.Location = new System.Drawing.Point(287, 3);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.textBox2.Mask = "";
            this.textBox2.MaxLength = -1;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ReadOnly = false;
            this.textBox2.ShowCalendarButton = true;
            this.textBox2.Size = new System.Drawing.Size(60, 22);
            this.textBox2.TabIndex = 6;
            this.textBox2.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(240, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "最小數";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(51, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "單位";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(51, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "特性";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(192, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "請假間隔最小數";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(27, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "假別代碼";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = this.label1;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHCODE, "H_CODE_DISP", true));
            this.textBox1.DecimalPlace = 2;
            this.textBox1.IsEmpty = false;
            this.textBox1.Location = new System.Drawing.Point(86, 3);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.textBox1.Mask = "";
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = false;
            this.textBox1.ShowCalendarButton = true;
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(252, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 10;
            this.label12.Text = "排序";
            // 
            // textBox7
            // 
            this.textBox7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox7.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox7.CaptionLabel = this.label12;
            this.textBox7.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox7.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHCODE, "SORT", true));
            this.textBox7.DecimalPlace = 2;
            this.textBox7.IsEmpty = true;
            this.textBox7.Location = new System.Drawing.Point(287, 107);
            this.textBox7.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.textBox7.Mask = "";
            this.textBox7.MaxLength = -1;
            this.textBox7.Name = "textBox7";
            this.textBox7.PasswordChar = '\0';
            this.textBox7.ReadOnly = false;
            this.textBox7.ShowCalendarButton = true;
            this.textBox7.Size = new System.Drawing.Size(60, 22);
            this.textBox7.TabIndex = 10;
            this.textBox7.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // comboBoxFlag
            // 
            this.comboBoxFlag.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsHCODE, "FLAG", true));
            this.comboBoxFlag.FormattingEnabled = true;
            this.comboBoxFlag.Location = new System.Drawing.Point(86, 107);
            this.comboBoxFlag.Name = "comboBoxFlag";
            this.comboBoxFlag.Size = new System.Drawing.Size(100, 20);
            this.comboBoxFlag.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsHCODE, "UNIT", true));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(86, 81);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 20);
            this.comboBox1.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(27, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "指定性別";
            // 
            // comboBox4
            // 
            this.comboBox4.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsHCODE, "SEX", true));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(86, 133);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(100, 20);
            this.comboBox4.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(228, 141);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 10;
            this.label13.Text = "請假類別";
            // 
            // comboBoxHtype
            // 
            this.comboBoxHtype.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsHCODE, "HTYPE", true));
            this.comboBoxHtype.FormattingEnabled = true;
            this.comboBoxHtype.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxHtype.Location = new System.Drawing.Point(287, 133);
            this.comboBoxHtype.Name = "comboBoxHtype";
            this.comboBoxHtype.Size = new System.Drawing.Size(75, 20);
            this.comboBoxHtype.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(707, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "合併檢查假別";
            this.label7.Visible = false;
            // 
            // comboBox3
            // 
            this.comboBox3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsHCODE, "DCODE", true));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(711, 139);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(100, 20);
            this.comboBox3.TabIndex = 6;
            this.comboBox3.Visible = false;
            // 
            // buttonLNG
            // 
            this.buttonLNG.Location = new System.Drawing.Point(630, 49);
            this.buttonLNG.Name = "buttonLNG";
            this.buttonLNG.Size = new System.Drawing.Size(75, 23);
            this.buttonLNG.TabIndex = 2;
            this.buttonLNG.TabStop = false;
            this.buttonLNG.Text = "語系設定";
            this.buttonLNG.UseVisualStyleBackColor = true;
            this.buttonLNG.Click += new System.EventHandler(this.ButtonLNG_Click);
            // 
            // btnCodeGroup
            // 
            this.btnCodeGroup.Location = new System.Drawing.Point(707, 6);
            this.btnCodeGroup.Name = "btnCodeGroup";
            this.btnCodeGroup.Size = new System.Drawing.Size(75, 23);
            this.btnCodeGroup.TabIndex = 1;
            this.btnCodeGroup.TabStop = false;
            this.btnCodeGroup.Text = "代碼群組";
            this.btnCodeGroup.UseVisualStyleBackColor = true;
            this.btnCodeGroup.Click += new System.EventHandler(this.btnCodeGroup_Click);
            // 
            // btnFRM211D
            // 
            this.btnFRM211D.ForeColor = System.Drawing.Color.Red;
            this.btnFRM211D.Location = new System.Drawing.Point(630, 6);
            this.btnFRM211D.Name = "btnFRM211D";
            this.btnFRM211D.Size = new System.Drawing.Size(75, 23);
            this.btnFRM211D.TabIndex = 0;
            this.btnFRM211D.TabStop = false;
            this.btnFRM211D.Text = "假薪關係";
            this.btnFRM211D.UseVisualStyleBackColor = true;
            this.btnFRM211D.Click += new System.EventHandler(this.btnFRM211D_Click);
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
            this.fdc.DataSource = this.bsHCODE;
            this.fdc.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fdc.EnableAutoClone = false;
            this.fdc.GroupCmd = "";
            this.fdc.Location = new System.Drawing.Point(0, 3);
            this.fdc.Name = "fdc";
            this.fdc.QueryFields = "h_code,h_name";
            this.fdc.RecentQuerySql = "";
            this.fdc.SelectCmd = "";
            this.fdc.ShowExceptionMsg = true;
            this.fdc.Size = new System.Drawing.Size(635, 73);
            this.fdc.SortFields = "h_code,h_name";
            this.fdc.TabIndex = 0;
            this.fdc.WhereCmd = "";
            this.fdc.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterAdd);
            this.fdc.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterEdit);
            this.fdc.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fdc_BeforeDel);
            this.fdc.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterDel);
            this.fdc.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fdc_BeforeSave);
            this.fdc.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterSave);
            this.fdc.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterExport);
            // 
            // bsYEAR_REST
            // 
            this.bsYEAR_REST.DataMember = "YEAR_REST";
            this.bsYEAR_REST.DataSource = this.dsView;
            // 
            // dsView
            // 
            this.dsView.DataSetName = "dsView";
            this.dsView.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bsUNIT
            // 
            this.bsUNIT.DataMember = "UNIT";
            this.bsUNIT.DataSource = this.dsView;
            // 
            // bsSEX
            // 
            this.bsSEX.DataMember = "SEX";
            this.bsSEX.DataSource = this.dsView;
            // 
            // taUNIT
            // 
            this.taUNIT.ClearBeforeFill = true;
            // 
            // taYEAR_REST
            // 
            this.taYEAR_REST.ClearBeforeFill = true;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.DataSource = this.bsHCODE;
            // 
            // taSEX
            // 
            this.taSEX.ClearBeforeFill = true;
            // 
            // hCODEBindingSource
            // 
            this.hCODEBindingSource.DataMember = "HCODE";
            this.hCODEBindingSource.DataSource = this.dsAtt;
            // 
            // taHCODE
            // 
            this.taHCODE.ClearBeforeFill = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(27, 175);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 7;
            this.label14.Text = "前台備註";
            // 
            // textBox9
            // 
            this.textBox9.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox9.CaptionLabel = null;
            this.textBox9.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox9.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHCODE, "Remark", true));
            this.textBox9.DecimalPlace = 2;
            this.textBox9.IsEmpty = true;
            this.textBox9.Location = new System.Drawing.Point(86, 170);
            this.textBox9.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.textBox9.Mask = "";
            this.textBox9.MaxLength = 500;
            this.textBox9.Name = "textBox9";
            this.textBox9.PasswordChar = '\0';
            this.textBox9.ReadOnly = false;
            this.textBox9.ShowCalendarButton = true;
            this.textBox9.Size = new System.Drawing.Size(619, 22);
            this.textBox9.TabIndex = 0;
            this.textBox9.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // FRM211
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Normal;
            this.KeyPreview = true;
            this.Name = "FRM211";
            this.Tag = "Att.FRM211";
            this.Text = "FRM211";
            this.Load += new System.EventHandler(this.FRM211_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsHCODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsYEAR_REST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUNIT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hCODEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private JBControls.FullDataCtrl fdc;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource bsHCODE;
        private JBHR.Att.dsAttTableAdapters.HCODETableAdapter taHCODE;
        private JBControls.DataGridView dgv;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.BindingSource bsYEAR_REST;
        private dsView dsView;
        private System.Windows.Forms.BindingSource bsUNIT;
        private JBHR.Att.dsViewTableAdapters.UNITTableAdapter taUNIT;
        private JBHR.Att.dsViewTableAdapters.YEAR_RESTTableAdapter taYEAR_REST;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private JBControls.CheckBox checkBox1;
        private JBControls.CheckBox checkBox2;
        private JBControls.CheckBox checkBox3;
        private JBControls.CheckBox checkBox4;
        private JBControls.CheckBox checkBox5;
        private JBControls.CheckBox checkBox6;
        private JBControls.CheckBox checkBox7;
        private JBControls.CheckBox checkBox8;
        private JBControls.CheckBox checkBox9;
        private JBControls.CheckBox checkBox10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private JBControls.TextBox textBox8;
        private System.Windows.Forms.Label label11;
        private JBControls.TextBox textBox6;
        private System.Windows.Forms.Label label9;
        private JBControls.TextBox textBox5;
        private System.Windows.Forms.Label label4;
        private JBControls.TextBox textBox4;
        private System.Windows.Forms.Label label10;
        private JBControls.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private JBControls.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private JBControls.TextBox textBox1;
        private System.Windows.Forms.BindingSource bsSEX;
        private JBHR.Att.dsViewTableAdapters.SEXTableAdapter taSEX;
        private System.Windows.Forms.Button btnFRM211D;
        private System.Windows.Forms.BindingSource hCODEBindingSource;
        private System.Windows.Forms.Label label12;
        private JBControls.TextBox textBox7;
        private System.Windows.Forms.Button btnCodeGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn hCODEDISPDataGridViewTextBoxColumn;
        private JBControls.CheckBox checkBox11;
        private System.Windows.Forms.DataGridViewTextBoxColumn H_CODE_DISP;
        private System.Windows.Forms.DataGridViewTextBoxColumn hNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hENAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uNITDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yEARRESTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sEXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mINNUMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dISAPPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mAXNUMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aBSUNITDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sORTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mANGDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn nOTDELDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn nOTSUMDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn eFFFOODDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aTTDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn STATION;
        private System.Windows.Forms.DataGridViewCheckBoxColumn eFNIGHTDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cALOTDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn iNHOLIDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cHEDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dISPLAYFORMDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBoxFlag;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.ComboBox comboBoxHtype;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonLNG;
        private JBControls.TextBox textBox9;
        private System.Windows.Forms.Label label14;
    }
}