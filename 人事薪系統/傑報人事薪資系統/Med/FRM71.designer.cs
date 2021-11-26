namespace JBHR.Med
{
    partial class FRM71
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new JBControls.DataGridView();
            this.nOBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yYMMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sEQDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dAMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fORMATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mENODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNAIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tAXNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fORSUBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUPAMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tWAGEDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.medDS = new JBHR.Med.MedDS();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new JBControls.TextBox();
            this.textBox9 = new JBControls.TextBox();
            this.ptxSalcode = new JBControls.PopupTextBox();
            this.tCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxFormat = new JBControls.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.yRFORMATBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtDAmt = new JBControls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxForsub = new JBControls.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSupAmt = new JBControls.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAmt = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox5 = new JBControls.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.yRINABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.comboBoxCompany = new JBControls.ComboBox();
            this.cOMPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new JBControls.TextBox();
            this.textBox6 = new JBControls.TextBox();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.tBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox1 = new JBControls.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainDS = new JBHR.MainDS();
            this.yRFORSUBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yRIDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yRMARKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yRERMAKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yRHSNBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yRINATableAdapter = new JBHR.Med.MedDSTableAdapters.YRINATableAdapter();
            this.yRHSNTableAdapter = new JBHR.Med.MedDSTableAdapters.YRHSNTableAdapter();
            this.cOMPTableAdapter = new JBHR.Med.MedDSTableAdapters.COMPTableAdapter();
            this.yRIDTableAdapter = new JBHR.Med.MedDSTableAdapters.YRIDTableAdapter();
            this.yRERMAKTableAdapter = new JBHR.Med.MedDSTableAdapters.YRERMAKTableAdapter();
            this.yRMARKTableAdapter = new JBHR.Med.MedDSTableAdapters.YRMARKTableAdapter();
            this.yRFORMATTableAdapter = new JBHR.Med.MedDSTableAdapters.YRFORMATTableAdapter();
            this.tWAGEDTableAdapter = new JBHR.Med.MedDSTableAdapters.TWAGEDTableAdapter();
            this.v_BASETableAdapter = new JBHR.MainDSTableAdapters.V_BASETableAdapter();
            this.yRFORSUBTableAdapter = new JBHR.Med.MedDSTableAdapters.YRFORSUBTableAdapter();
            this.tCODETableAdapter = new JBHR.Med.MedDSTableAdapters.TCODETableAdapter();
            this.tBASETableAdapter = new JBHR.Med.MedDSTableAdapters.TBASETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tWAGEDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRFORMATBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRINABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOMPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRFORSUBBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRIDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRMARKBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRERMAKBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRHSNBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(794, 572);
            this.splitContainer1.SplitterDistance = 279;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nOBRDataGridViewTextBoxColumn,
            this.yYMMDataGridViewTextBoxColumn,
            this.sEQDataGridViewTextBoxColumn,
            this.sALCODEDataGridViewTextBoxColumn,
            this.aMTDataGridViewTextBoxColumn,
            this.dAMTDataGridViewTextBoxColumn,
            this.fORMATDataGridViewTextBoxColumn,
            this.mENODataGridViewTextBoxColumn,
            this.iNAIDDataGridViewTextBoxColumn,
            this.tAXNODataGridViewTextBoxColumn,
            this.fORSUBDataGridViewTextBoxColumn,
            this.cOMPDataGridViewTextBoxColumn,
            this.sUPAMTDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tWAGEDBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(794, 279);
            this.dataGridView1.TabIndex = 0;
            // 
            // nOBRDataGridViewTextBoxColumn
            // 
            this.nOBRDataGridViewTextBoxColumn.DataPropertyName = "NOBR";
            this.nOBRDataGridViewTextBoxColumn.HeaderText = "員工編號";
            this.nOBRDataGridViewTextBoxColumn.Name = "nOBRDataGridViewTextBoxColumn";
            this.nOBRDataGridViewTextBoxColumn.ReadOnly = true;
            this.nOBRDataGridViewTextBoxColumn.Width = 78;
            // 
            // yYMMDataGridViewTextBoxColumn
            // 
            this.yYMMDataGridViewTextBoxColumn.DataPropertyName = "YYMM";
            this.yYMMDataGridViewTextBoxColumn.HeaderText = "計薪年月";
            this.yYMMDataGridViewTextBoxColumn.Name = "yYMMDataGridViewTextBoxColumn";
            this.yYMMDataGridViewTextBoxColumn.ReadOnly = true;
            this.yYMMDataGridViewTextBoxColumn.Width = 78;
            // 
            // sEQDataGridViewTextBoxColumn
            // 
            this.sEQDataGridViewTextBoxColumn.DataPropertyName = "SEQ";
            this.sEQDataGridViewTextBoxColumn.HeaderText = "期別";
            this.sEQDataGridViewTextBoxColumn.Name = "sEQDataGridViewTextBoxColumn";
            this.sEQDataGridViewTextBoxColumn.ReadOnly = true;
            this.sEQDataGridViewTextBoxColumn.Width = 54;
            // 
            // sALCODEDataGridViewTextBoxColumn
            // 
            this.sALCODEDataGridViewTextBoxColumn.DataPropertyName = "SAL_CODE";
            this.sALCODEDataGridViewTextBoxColumn.HeaderText = "所得代號";
            this.sALCODEDataGridViewTextBoxColumn.Name = "sALCODEDataGridViewTextBoxColumn";
            this.sALCODEDataGridViewTextBoxColumn.ReadOnly = true;
            this.sALCODEDataGridViewTextBoxColumn.Width = 78;
            // 
            // aMTDataGridViewTextBoxColumn
            // 
            this.aMTDataGridViewTextBoxColumn.DataPropertyName = "AMT";
            this.aMTDataGridViewTextBoxColumn.HeaderText = "金額";
            this.aMTDataGridViewTextBoxColumn.Name = "aMTDataGridViewTextBoxColumn";
            this.aMTDataGridViewTextBoxColumn.ReadOnly = true;
            this.aMTDataGridViewTextBoxColumn.Width = 54;
            // 
            // dAMTDataGridViewTextBoxColumn
            // 
            this.dAMTDataGridViewTextBoxColumn.DataPropertyName = "D_AMT";
            this.dAMTDataGridViewTextBoxColumn.HeaderText = "扣繳稅額";
            this.dAMTDataGridViewTextBoxColumn.Name = "dAMTDataGridViewTextBoxColumn";
            this.dAMTDataGridViewTextBoxColumn.ReadOnly = true;
            this.dAMTDataGridViewTextBoxColumn.Width = 78;
            // 
            // fORMATDataGridViewTextBoxColumn
            // 
            this.fORMATDataGridViewTextBoxColumn.DataPropertyName = "FORMAT";
            this.fORMATDataGridViewTextBoxColumn.HeaderText = "格式";
            this.fORMATDataGridViewTextBoxColumn.Name = "fORMATDataGridViewTextBoxColumn";
            this.fORMATDataGridViewTextBoxColumn.ReadOnly = true;
            this.fORMATDataGridViewTextBoxColumn.Width = 54;
            // 
            // mENODataGridViewTextBoxColumn
            // 
            this.mENODataGridViewTextBoxColumn.DataPropertyName = "MENO";
            this.mENODataGridViewTextBoxColumn.HeaderText = "備註";
            this.mENODataGridViewTextBoxColumn.Name = "mENODataGridViewTextBoxColumn";
            this.mENODataGridViewTextBoxColumn.ReadOnly = true;
            this.mENODataGridViewTextBoxColumn.Width = 54;
            // 
            // iNAIDDataGridViewTextBoxColumn
            // 
            this.iNAIDDataGridViewTextBoxColumn.DataPropertyName = "INA_ID";
            this.iNAIDDataGridViewTextBoxColumn.HeaderText = "業別";
            this.iNAIDDataGridViewTextBoxColumn.Name = "iNAIDDataGridViewTextBoxColumn";
            this.iNAIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iNAIDDataGridViewTextBoxColumn.Width = 54;
            // 
            // tAXNODataGridViewTextBoxColumn
            // 
            this.tAXNODataGridViewTextBoxColumn.DataPropertyName = "TAXNO";
            this.tAXNODataGridViewTextBoxColumn.HeaderText = "租賃稅籍編號";
            this.tAXNODataGridViewTextBoxColumn.Name = "tAXNODataGridViewTextBoxColumn";
            this.tAXNODataGridViewTextBoxColumn.ReadOnly = true;
            this.tAXNODataGridViewTextBoxColumn.Width = 102;
            // 
            // fORSUBDataGridViewTextBoxColumn
            // 
            this.fORSUBDataGridViewTextBoxColumn.DataPropertyName = "FORSUB";
            this.fORSUBDataGridViewTextBoxColumn.HeaderText = "給付項目";
            this.fORSUBDataGridViewTextBoxColumn.Name = "fORSUBDataGridViewTextBoxColumn";
            this.fORSUBDataGridViewTextBoxColumn.ReadOnly = true;
            this.fORSUBDataGridViewTextBoxColumn.Width = 78;
            // 
            // cOMPDataGridViewTextBoxColumn
            // 
            this.cOMPDataGridViewTextBoxColumn.DataPropertyName = "COMP";
            this.cOMPDataGridViewTextBoxColumn.HeaderText = "扣繳公司";
            this.cOMPDataGridViewTextBoxColumn.Name = "cOMPDataGridViewTextBoxColumn";
            this.cOMPDataGridViewTextBoxColumn.ReadOnly = true;
            this.cOMPDataGridViewTextBoxColumn.Width = 78;
            // 
            // sUPAMTDataGridViewTextBoxColumn
            // 
            this.sUPAMTDataGridViewTextBoxColumn.DataPropertyName = "SUP_AMT";
            this.sUPAMTDataGridViewTextBoxColumn.HeaderText = "補充保費";
            this.sUPAMTDataGridViewTextBoxColumn.Name = "sUPAMTDataGridViewTextBoxColumn";
            this.sUPAMTDataGridViewTextBoxColumn.ReadOnly = true;
            this.sUPAMTDataGridViewTextBoxColumn.Width = 78;
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
            // tWAGEDBindingSource
            // 
            this.tWAGEDBindingSource.DataMember = "TWAGED";
            this.tWAGEDBindingSource.DataSource = this.medDS;
            // 
            // medDS
            // 
            this.medDS.DataSetName = "MedDS";
            this.medDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.medDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.medDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnImport);
            this.splitContainer2.Panel2.Controls.Add(this.fullDataCtrl1);
            this.splitContainer2.Size = new System.Drawing.Size(794, 289);
            this.splitContainer2.SplitterDistance = 207;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 207);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox9, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.ptxSalcode, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxFormat, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDAmt, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxForsub, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtSupAmt, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtAmt, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBox5, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label18, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label20, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxCompany, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBox6, 5, 7);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 4, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(777, 196);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(15, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "所得人編號";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(27, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "計薪年月";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(27, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "所得代號";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(232, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "期別";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = this.label2;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tWAGEDBindingSource, "YYMM", true));
            this.textBox2.DecimalPlace = 2;
            this.textBox2.IsEmpty = false;
            this.textBox2.Location = new System.Drawing.Point(86, 31);
            this.textBox2.Mask = "";
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ReadOnly = false;
            this.textBox2.ShowCalendarButton = true;
            this.textBox2.Size = new System.Drawing.Size(90, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBox9
            // 
            this.textBox9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox9.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox9.CaptionLabel = this.label9;
            this.textBox9.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox9.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tWAGEDBindingSource, "SEQ", true));
            this.textBox9.DecimalPlace = 2;
            this.textBox9.IsEmpty = false;
            this.textBox9.Location = new System.Drawing.Point(267, 31);
            this.textBox9.Mask = "";
            this.textBox9.MaxLength = 50;
            this.textBox9.Name = "textBox9";
            this.textBox9.PasswordChar = '\0';
            this.textBox9.ReadOnly = false;
            this.textBox9.ShowCalendarButton = true;
            this.textBox9.Size = new System.Drawing.Size(80, 22);
            this.textBox9.TabIndex = 2;
            this.textBox9.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // ptxSalcode
            // 
            this.ptxSalcode.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxSalcode.CaptionLabel = this.label3;
            this.ptxSalcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.ptxSalcode, 2);
            this.ptxSalcode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tWAGEDBindingSource, "SAL_CODE", true));
            this.ptxSalcode.DataSource = this.tCODEBindingSource;
            this.ptxSalcode.DisplayMember = "t_name";
            this.ptxSalcode.IsEmpty = true;
            this.ptxSalcode.IsEmptyToQuery = true;
            this.ptxSalcode.IsMustBeFound = true;
            this.ptxSalcode.LabelText = "";
            this.ptxSalcode.Location = new System.Drawing.Point(86, 59);
            this.ptxSalcode.Name = "ptxSalcode";
            this.ptxSalcode.ReadOnly = false;
            this.ptxSalcode.ShowDisplayName = true;
            this.ptxSalcode.Size = new System.Drawing.Size(90, 22);
            this.ptxSalcode.TabIndex = 4;
            this.ptxSalcode.ValueMember = "t_code";
            this.ptxSalcode.WhereCmd = "";
            // 
            // tCODEBindingSource
            // 
            this.tCODEBindingSource.DataMember = "TCODE";
            this.tCODEBindingSource.DataSource = this.medDS;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(3, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 39;
            this.label7.Text = "租賃稅籍編號";
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxFormat.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.comboBoxFormat.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxFormat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.comboBoxFormat.CaptionLabel = this.label13;
            this.comboBoxFormat.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tWAGEDBindingSource, "FORMAT", true));
            this.comboBoxFormat.DataSource = this.yRFORMATBindingSource;
            this.comboBoxFormat.DisplayMember = "m_fmt_name";
            this.comboBoxFormat.DropDownCount = 10;
            this.comboBoxFormat.IsDisplayValueLabel = true;
            this.comboBoxFormat.IsEmpty = false;
            this.comboBoxFormat.Location = new System.Drawing.Point(86, 87);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.SelectedValue = "";
            this.comboBoxFormat.Size = new System.Drawing.Size(116, 22);
            this.comboBoxFormat.TabIndex = 5;
            this.comboBoxFormat.ValueMember = "m_format";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(51, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 12;
            this.label13.Text = "格式";
            // 
            // yRFORMATBindingSource
            // 
            this.yRFORMATBindingSource.DataMember = "YRFORMAT";
            this.yRFORMATBindingSource.DataSource = this.medDS;
            // 
            // txtDAmt
            // 
            this.txtDAmt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDAmt.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDAmt.CaptionLabel = this.label5;
            this.txtDAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tWAGEDBindingSource, "D_AMT", true));
            this.txtDAmt.DecimalPlace = 2;
            this.txtDAmt.IsEmpty = true;
            this.txtDAmt.Location = new System.Drawing.Point(267, 115);
            this.txtDAmt.Mask = "";
            this.txtDAmt.MaxLength = -1;
            this.txtDAmt.Name = "txtDAmt";
            this.txtDAmt.PasswordChar = '\0';
            this.txtDAmt.ReadOnly = false;
            this.txtDAmt.ShowCalendarButton = true;
            this.txtDAmt.Size = new System.Drawing.Size(90, 22);
            this.txtDAmt.TabIndex = 10;
            this.txtDAmt.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(208, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "扣繳稅額";
            // 
            // comboBoxForsub
            // 
            this.comboBoxForsub.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxForsub.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.comboBoxForsub.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxForsub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.comboBoxForsub.CaptionLabel = this.label16;
            this.comboBoxForsub.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tWAGEDBindingSource, "FORSUB", true));
            this.comboBoxForsub.DataSource = null;
            this.comboBoxForsub.DisplayMember = "m_sub_name";
            this.comboBoxForsub.DropDownCount = 10;
            this.comboBoxForsub.IsDisplayValueLabel = true;
            this.comboBoxForsub.IsEmpty = true;
            this.comboBoxForsub.Location = new System.Drawing.Point(86, 115);
            this.comboBoxForsub.Name = "comboBoxForsub";
            this.comboBoxForsub.SelectedValue = "";
            this.comboBoxForsub.Size = new System.Drawing.Size(116, 22);
            this.comboBoxForsub.TabIndex = 6;
            this.comboBoxForsub.ValueMember = "m_forsub";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(27, 120);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 15;
            this.label16.Text = "給付項目";
            // 
            // txtSupAmt
            // 
            this.txtSupAmt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSupAmt.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSupAmt.CaptionLabel = this.label11;
            this.txtSupAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSupAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tWAGEDBindingSource, "SUP_AMT", true));
            this.txtSupAmt.DecimalPlace = 2;
            this.txtSupAmt.IsEmpty = true;
            this.txtSupAmt.Location = new System.Drawing.Point(267, 143);
            this.txtSupAmt.Mask = "";
            this.txtSupAmt.MaxLength = -1;
            this.txtSupAmt.Name = "txtSupAmt";
            this.txtSupAmt.PasswordChar = '\0';
            this.txtSupAmt.ReadOnly = false;
            this.txtSupAmt.ShowCalendarButton = true;
            this.txtSupAmt.Size = new System.Drawing.Size(90, 22);
            this.txtSupAmt.TabIndex = 11;
            this.txtSupAmt.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(208, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "補充保費";
            // 
            // txtAmt
            // 
            this.txtAmt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAmt.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAmt.CaptionLabel = this.label4;
            this.txtAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tWAGEDBindingSource, "AMT", true));
            this.txtAmt.DecimalPlace = 2;
            this.txtAmt.IsEmpty = true;
            this.txtAmt.Location = new System.Drawing.Point(267, 87);
            this.txtAmt.Mask = "";
            this.txtAmt.MaxLength = -1;
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.PasswordChar = '\0';
            this.txtAmt.ReadOnly = false;
            this.txtAmt.ShowCalendarButton = true;
            this.txtAmt.Size = new System.Drawing.Size(90, 22);
            this.txtAmt.TabIndex = 9;
            this.txtAmt.ValidType = JBControls.TextBox.EValidType.Decimal;
            this.txtAmt.Validated += new System.EventHandler(this.textBox4_Validated);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(232, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "金額";
            // 
            // comboBox5
            // 
            this.comboBox5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox5.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.comboBox5.BackColor = System.Drawing.Color.Transparent;
            this.comboBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.comboBox5.CaptionLabel = this.label18;
            this.comboBox5.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tWAGEDBindingSource, "INA_ID", true));
            this.comboBox5.DataSource = this.yRINABindingSource;
            this.comboBox5.DisplayMember = "ina_name";
            this.comboBox5.DropDownCount = 10;
            this.comboBox5.IsDisplayValueLabel = true;
            this.comboBox5.IsEmpty = true;
            this.comboBox5.Location = new System.Drawing.Point(86, 143);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.SelectedValue = "";
            this.comboBox5.Size = new System.Drawing.Size(116, 22);
            this.comboBox5.TabIndex = 7;
            this.comboBox5.ValueMember = "ina_id";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(51, 148);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 17;
            this.label18.Text = "業別";
            // 
            // yRINABindingSource
            // 
            this.yRINABindingSource.DataMember = "YRINA";
            this.yRINABindingSource.DataSource = this.medDS;
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(367, 36);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 41;
            this.label20.Text = "扣繳公司";
            // 
            // comboBoxCompany
            // 
            this.comboBoxCompany.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.comboBoxCompany.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxCompany.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.comboBoxCompany.CaptionLabel = this.label20;
            this.comboBoxCompany.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tWAGEDBindingSource, "COMP", true));
            this.comboBoxCompany.DataSource = this.cOMPBindingSource;
            this.comboBoxCompany.DisplayMember = "compname";
            this.comboBoxCompany.DropDownCount = 10;
            this.comboBoxCompany.IsDisplayValueLabel = true;
            this.comboBoxCompany.IsEmpty = false;
            this.comboBoxCompany.Location = new System.Drawing.Point(426, 31);
            this.comboBoxCompany.Name = "comboBoxCompany";
            this.comboBoxCompany.SelectedValue = "";
            this.comboBoxCompany.Size = new System.Drawing.Size(281, 22);
            this.comboBoxCompany.TabIndex = 3;
            this.comboBoxCompany.ValueMember = "comp";
            // 
            // cOMPBindingSource
            // 
            this.cOMPBindingSource.DataMember = "COMP";
            this.cOMPBindingSource.DataSource = this.medDS;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(391, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 39;
            this.label6.Text = "備註";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox3.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox3.CaptionLabel = this.label7;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox3, 3);
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tWAGEDBindingSource, "TAXNO", true));
            this.textBox3.DecimalPlace = 2;
            this.textBox3.IsEmpty = true;
            this.textBox3.Location = new System.Drawing.Point(86, 171);
            this.textBox3.Mask = "";
            this.textBox3.MaxLength = 50;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '\0';
            this.textBox3.ReadOnly = false;
            this.textBox3.ShowCalendarButton = true;
            this.textBox3.Size = new System.Drawing.Size(275, 22);
            this.textBox3.TabIndex = 8;
            this.textBox3.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBox6
            // 
            this.textBox6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox6.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox6.CaptionLabel = this.label6;
            this.textBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox6, 2);
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tWAGEDBindingSource, "MENO", true));
            this.textBox6.DecimalPlace = 2;
            this.textBox6.IsEmpty = true;
            this.textBox6.Location = new System.Drawing.Point(426, 171);
            this.textBox6.Mask = "";
            this.textBox6.MaxLength = 120;
            this.textBox6.Name = "textBox6";
            this.textBox6.PasswordChar = '\0';
            this.textBox6.ReadOnly = false;
            this.textBox6.ShowCalendarButton = true;
            this.textBox6.Size = new System.Drawing.Size(340, 22);
            this.textBox6.TabIndex = 13;
            this.textBox6.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // ptxNobr
            // 
            this.ptxNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobr.CaptionLabel = this.label1;
            this.ptxNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.ptxNobr, 2);
            this.ptxNobr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tWAGEDBindingSource, "NOBR", true));
            this.ptxNobr.DataSource = this.tBASEBindingSource;
            this.ptxNobr.DisplayMember = "name_c";
            this.ptxNobr.IsEmpty = false;
            this.ptxNobr.IsEmptyToQuery = true;
            this.ptxNobr.IsMustBeFound = true;
            this.ptxNobr.LabelText = "";
            this.ptxNobr.Location = new System.Drawing.Point(86, 3);
            this.ptxNobr.Name = "ptxNobr";
            this.ptxNobr.ReadOnly = false;
            this.ptxNobr.ShowDisplayName = true;
            this.ptxNobr.Size = new System.Drawing.Size(90, 22);
            this.ptxNobr.TabIndex = 0;
            this.ptxNobr.ValueMember = "nobr";
            this.ptxNobr.WhereCmd = "";
            this.ptxNobr.QueryCompleted += new JBControls.PopupTextBox.QueryCompletedHandler(this.ptxNobr_QueryCompleted);
            // 
            // tBASEBindingSource
            // 
            this.tBASEBindingSource.DataMember = "TBASE";
            this.tBASEBindingSource.DataSource = this.medDS;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.comboBox1.BackColor = System.Drawing.Color.Transparent;
            this.comboBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.comboBox1.CaptionLabel = null;
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tWAGEDBindingSource, "SALADR", true));
            this.comboBox1.DataSource = null;
            this.comboBox1.DisplayMember = "m_fmt_name";
            this.comboBox1.DropDownCount = 10;
            this.comboBox1.IsDisplayValueLabel = true;
            this.comboBox1.IsEmpty = false;
            this.comboBox1.Location = new System.Drawing.Point(426, 87);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedValue = "";
            this.comboBox1.Size = new System.Drawing.Size(192, 22);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.ValueMember = "m_format";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(367, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "資料群組";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(634, 5);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(78, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "匯入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.button2_Click);
            // 
            // fullDataCtrl1
            // 
            this.fullDataCtrl1.AllowModifyPrimaryKey = false;
            this.fullDataCtrl1.BindingCtrlsAutoInit = true;
            this.fullDataCtrl1.bnAddEnable = true;
            this.fullDataCtrl1.bnAddVisible = true;
            this.fullDataCtrl1.bnCancelEnable = true;
            this.fullDataCtrl1.bnCancelVisible = true;
            this.fullDataCtrl1.bnDelEnable = true;
            this.fullDataCtrl1.bnDelVisible = true;
            this.fullDataCtrl1.bnEditEnable = true;
            this.fullDataCtrl1.bnEditVisible = true;
            this.fullDataCtrl1.bnExportEnable = true;
            this.fullDataCtrl1.bnExportVisible = true;
            this.fullDataCtrl1.bnQueryEnable = true;
            this.fullDataCtrl1.bnQueryVisible = true;
            this.fullDataCtrl1.bnSaveEnable = true;
            this.fullDataCtrl1.bnSaveVisible = true;
            this.fullDataCtrl1.CtrlType = JBControls.FullDataCtrl.ECtrlType.Full;
            this.fullDataCtrl1.DataAdapter = null;
            this.fullDataCtrl1.DataGrid = this.dataGridView1;
            this.fullDataCtrl1.DataSource = this.tWAGEDBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(3, 2);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "year,name_c,nobr";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(639, 73);
            this.fullDataCtrl1.SortFields = "year,name_c,nobr";
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            this.fullDataCtrl1.AfterQuery += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterQuery);
            this.fullDataCtrl1.AfterShow += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterShow);
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
            // yRIDBindingSource
            // 
            this.yRIDBindingSource.DataMember = "YRID";
            this.yRIDBindingSource.DataSource = this.medDS;
            // 
            // yRMARKBindingSource
            // 
            this.yRMARKBindingSource.DataMember = "YRMARK";
            this.yRMARKBindingSource.DataSource = this.medDS;
            // 
            // yRERMAKBindingSource
            // 
            this.yRERMAKBindingSource.DataMember = "YRERMAK";
            this.yRERMAKBindingSource.DataSource = this.medDS;
            // 
            // yRHSNBindingSource
            // 
            this.yRHSNBindingSource.DataMember = "YRHSN";
            this.yRHSNBindingSource.DataSource = this.medDS;
            // 
            // yRINATableAdapter
            // 
            this.yRINATableAdapter.ClearBeforeFill = true;
            // 
            // yRHSNTableAdapter
            // 
            this.yRHSNTableAdapter.ClearBeforeFill = true;
            // 
            // cOMPTableAdapter
            // 
            this.cOMPTableAdapter.ClearBeforeFill = true;
            // 
            // yRIDTableAdapter
            // 
            this.yRIDTableAdapter.ClearBeforeFill = true;
            // 
            // yRERMAKTableAdapter
            // 
            this.yRERMAKTableAdapter.ClearBeforeFill = true;
            // 
            // yRMARKTableAdapter
            // 
            this.yRMARKTableAdapter.ClearBeforeFill = true;
            // 
            // yRFORMATTableAdapter
            // 
            this.yRFORMATTableAdapter.ClearBeforeFill = true;
            // 
            // tWAGEDTableAdapter
            // 
            this.tWAGEDTableAdapter.ClearBeforeFill = true;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // yRFORSUBTableAdapter
            // 
            this.yRFORSUBTableAdapter.ClearBeforeFill = true;
            // 
            // tCODETableAdapter
            // 
            this.tCODETableAdapter.ClearBeforeFill = true;
            // 
            // tBASETableAdapter
            // 
            this.tBASETableAdapter.ClearBeforeFill = true;
            // 
            // FRM71
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 572);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Normal;
            this.KeyPreview = true;
            this.Name = "FRM71";
            this.Text = "FRM51";
            this.Load += new System.EventHandler(this.FRM51_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tWAGEDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medDS)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRFORMATBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRINABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOMPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRFORSUBBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRIDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRMARKBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRERMAKBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRHSNBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private JBControls.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private JBControls.FullDataCtrl fullDataCtrl1;
        private MedDS medDS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private JBControls.TextBox textBox2;
        private JBControls.TextBox txtAmt;
        private JBControls.TextBox txtDAmt;
        private JBControls.TextBox textBox9;
        private JBControls.TextBox txtSupAmt;
        private JBControls.ComboBox comboBox5;
        private JBControls.ComboBox comboBoxForsub;
        private JBControls.ComboBox comboBoxFormat;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label20;
        private JBControls.ComboBox comboBoxCompany;
        private System.Windows.Forms.BindingSource yRINABindingSource;
        private JBHR.Med.MedDSTableAdapters.YRINATableAdapter yRINATableAdapter;
        private System.Windows.Forms.BindingSource yRHSNBindingSource;
        private JBHR.Med.MedDSTableAdapters.YRHSNTableAdapter yRHSNTableAdapter;
        private System.Windows.Forms.BindingSource cOMPBindingSource;
        private JBHR.Med.MedDSTableAdapters.COMPTableAdapter cOMPTableAdapter;
        private System.Windows.Forms.BindingSource yRIDBindingSource;
        private JBHR.Med.MedDSTableAdapters.YRIDTableAdapter yRIDTableAdapter;
        private System.Windows.Forms.BindingSource yRERMAKBindingSource;
        private JBHR.Med.MedDSTableAdapters.YRERMAKTableAdapter yRERMAKTableAdapter;
        private System.Windows.Forms.BindingSource yRMARKBindingSource;
        private JBHR.Med.MedDSTableAdapters.YRMARKTableAdapter yRMARKTableAdapter;
        private System.Windows.Forms.BindingSource yRFORMATBindingSource;
        private MedDSTableAdapters.YRFORMATTableAdapter yRFORMATTableAdapter;
        private System.Windows.Forms.BindingSource tWAGEDBindingSource;
        private MedDSTableAdapters.TWAGEDTableAdapter tWAGEDTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yYMMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sEQDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sALCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dAMTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fORMATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mENODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iNAIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tAXNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fORSUBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sUPAMTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private JBControls.PopupTextBox ptxSalcode;
        private System.Windows.Forms.Label label6;
        private JBControls.TextBox textBox3;
        private JBControls.TextBox textBox6;
        private JBControls.PopupTextBox ptxNobr;
        private MainDS mainDS;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private MainDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private System.Windows.Forms.BindingSource yRFORSUBBindingSource;
        private MedDSTableAdapters.YRFORSUBTableAdapter yRFORSUBTableAdapter;
        private System.Windows.Forms.BindingSource tCODEBindingSource;
        private MedDSTableAdapters.TCODETableAdapter tCODETableAdapter;
        private System.Windows.Forms.BindingSource tBASEBindingSource;
        private MedDSTableAdapters.TBASETableAdapter tBASETableAdapter;
        private JBControls.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
    }
}