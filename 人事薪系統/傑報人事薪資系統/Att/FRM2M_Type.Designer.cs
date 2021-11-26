namespace JBHR.Att
{
    partial class FRM2M_Type
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
            this.fdc = new JBControls.FullDataCtrl();
            this.dgv = new JBControls.DataGridView();
            this.mEALTYPEDISPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mEALTYPENAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bTIMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eTIMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mEALTYPEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.lbCode = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbBTime = new System.Windows.Forms.Label();
            this.lbETime = new System.Windows.Forms.Label();
            this.lbNOTE = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtBTime = new System.Windows.Forms.TextBox();
            this.txtETime = new System.Windows.Forms.TextBox();
            this.txtCODE = new JBControls.TextBox();
            this.txtCODE_Name = new JBControls.TextBox();
            this.txtNOTE = new System.Windows.Forms.TextBox();
            this.plFV = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mealTypeTableAdapter = new JBHR.Att.dsAttTableAdapters.MealTypeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mEALTYPEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.plFV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
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
            this.fdc.DataSource = this.mEALTYPEBindingSource;
            this.fdc.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fdc.EnableAutoClone = false;
            this.fdc.GroupCmd = "";
            this.fdc.Location = new System.Drawing.Point(2, 2);
            this.fdc.Name = "fdc";
            this.fdc.RecentQuerySql = "";
            this.fdc.SelectCmd = "";
            this.fdc.ShowExceptionMsg = true;
            this.fdc.Size = new System.Drawing.Size(628, 73);
            this.fdc.TabIndex = 0;
            this.fdc.WhereCmd = "";
            this.fdc.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterAdd);
            this.fdc.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterDel);
            this.fdc.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fdc_BeforeSave);
            this.fdc.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterSave);
            this.fdc.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterExport);
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
            this.mEALTYPEDISPDataGridViewTextBoxColumn,
            this.mEALTYPENAMEDataGridViewTextBoxColumn,
            this.bTIMEDataGridViewTextBoxColumn,
            this.eTIMEDataGridViewTextBoxColumn,
            this.nOTEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.mEALTYPEBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(736, 331);
            this.dgv.TabIndex = 7;
            // 
            // mEALTYPEDISPDataGridViewTextBoxColumn
            // 
            this.mEALTYPEDISPDataGridViewTextBoxColumn.DataPropertyName = "MEALTYPE_CODE";
            this.mEALTYPEDISPDataGridViewTextBoxColumn.HeaderText = "用餐種類代碼";
            this.mEALTYPEDISPDataGridViewTextBoxColumn.Name = "mEALTYPEDISPDataGridViewTextBoxColumn";
            this.mEALTYPEDISPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mEALTYPENAMEDataGridViewTextBoxColumn
            // 
            this.mEALTYPENAMEDataGridViewTextBoxColumn.DataPropertyName = "MEALTYPE_NAME";
            this.mEALTYPENAMEDataGridViewTextBoxColumn.HeaderText = "用餐種類名稱";
            this.mEALTYPENAMEDataGridViewTextBoxColumn.Name = "mEALTYPENAMEDataGridViewTextBoxColumn";
            this.mEALTYPENAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bTIMEDataGridViewTextBoxColumn
            // 
            this.bTIMEDataGridViewTextBoxColumn.DataPropertyName = "BTIME";
            this.bTIMEDataGridViewTextBoxColumn.HeaderText = "開始名稱";
            this.bTIMEDataGridViewTextBoxColumn.Name = "bTIMEDataGridViewTextBoxColumn";
            this.bTIMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eTIMEDataGridViewTextBoxColumn
            // 
            this.eTIMEDataGridViewTextBoxColumn.DataPropertyName = "ETIME";
            this.eTIMEDataGridViewTextBoxColumn.HeaderText = "結束時間";
            this.eTIMEDataGridViewTextBoxColumn.Name = "eTIMEDataGridViewTextBoxColumn";
            this.eTIMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nOTEDataGridViewTextBoxColumn
            // 
            this.nOTEDataGridViewTextBoxColumn.DataPropertyName = "NOTE";
            this.nOTEDataGridViewTextBoxColumn.HeaderText = "備註";
            this.nOTEDataGridViewTextBoxColumn.Name = "nOTEDataGridViewTextBoxColumn";
            this.nOTEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mEALTYPEBindingSource
            // 
            this.mEALTYPEBindingSource.DataMember = "MealType";
            this.mEALTYPEBindingSource.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbCode
            // 
            this.lbCode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbCode.AutoSize = true;
            this.lbCode.ForeColor = System.Drawing.Color.Red;
            this.lbCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbCode.Location = new System.Drawing.Point(3, 8);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(77, 12);
            this.lbCode.TabIndex = 0;
            this.lbCode.Text = "用餐種類代碼";
            // 
            // lbName
            // 
            this.lbName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbName.AutoSize = true;
            this.lbName.ForeColor = System.Drawing.Color.Red;
            this.lbName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbName.Location = new System.Drawing.Point(3, 36);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(77, 12);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "用餐種類名稱";
            // 
            // lbBTime
            // 
            this.lbBTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbBTime.AutoSize = true;
            this.lbBTime.ForeColor = System.Drawing.Color.Red;
            this.lbBTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbBTime.Location = new System.Drawing.Point(27, 64);
            this.lbBTime.Name = "lbBTime";
            this.lbBTime.Size = new System.Drawing.Size(53, 12);
            this.lbBTime.TabIndex = 3;
            this.lbBTime.Text = "開始時間";
            // 
            // lbETime
            // 
            this.lbETime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbETime.AutoSize = true;
            this.lbETime.ForeColor = System.Drawing.Color.Red;
            this.lbETime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbETime.Location = new System.Drawing.Point(27, 92);
            this.lbETime.Name = "lbETime";
            this.lbETime.Size = new System.Drawing.Size(53, 12);
            this.lbETime.TabIndex = 3;
            this.lbETime.Text = "結束時間";
            // 
            // lbNOTE
            // 
            this.lbNOTE.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbNOTE.AutoSize = true;
            this.lbNOTE.ForeColor = System.Drawing.Color.Black;
            this.lbNOTE.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbNOTE.Location = new System.Drawing.Point(51, 120);
            this.lbNOTE.Name = "lbNOTE";
            this.lbNOTE.Size = new System.Drawing.Size(29, 12);
            this.lbNOTE.TabIndex = 5;
            this.lbNOTE.Text = "備註";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lbCode, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbBTime, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbETime, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtBTime, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtETime, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtCODE, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCODE_Name, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbNOTE, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtNOTE, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, -2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(734, 141);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtBTime
            // 
            this.txtBTime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mEALTYPEBindingSource, "BTIME", true));
            this.txtBTime.Location = new System.Drawing.Point(86, 59);
            this.txtBTime.Name = "txtBTime";
            this.txtBTime.Size = new System.Drawing.Size(100, 22);
            this.txtBTime.TabIndex = 2;
            // 
            // txtETime
            // 
            this.txtETime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mEALTYPEBindingSource, "ETIME", true));
            this.txtETime.Location = new System.Drawing.Point(86, 87);
            this.txtETime.Name = "txtETime";
            this.txtETime.Size = new System.Drawing.Size(100, 22);
            this.txtETime.TabIndex = 3;
            // 
            // txtCODE
            // 
            this.txtCODE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCODE.CaptionLabel = null;
            this.txtCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCODE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mEALTYPEBindingSource, "MEALTYPE_CODE", true));
            this.txtCODE.DecimalPlace = 2;
            this.txtCODE.IsEmpty = false;
            this.txtCODE.Location = new System.Drawing.Point(86, 3);
            this.txtCODE.Mask = "";
            this.txtCODE.MaxLength = 50;
            this.txtCODE.Name = "txtCODE";
            this.txtCODE.PasswordChar = '\0';
            this.txtCODE.ReadOnly = false;
            this.txtCODE.ShowCalendarButton = true;
            this.txtCODE.Size = new System.Drawing.Size(122, 22);
            this.txtCODE.TabIndex = 0;
            this.txtCODE.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtCODE_Name
            // 
            this.txtCODE_Name.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCODE_Name.CaptionLabel = null;
            this.txtCODE_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCODE_Name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mEALTYPEBindingSource, "MEALTYPE_NAME", true));
            this.txtCODE_Name.DecimalPlace = 2;
            this.txtCODE_Name.IsEmpty = false;
            this.txtCODE_Name.Location = new System.Drawing.Point(86, 31);
            this.txtCODE_Name.Mask = "";
            this.txtCODE_Name.MaxLength = 50;
            this.txtCODE_Name.Name = "txtCODE_Name";
            this.txtCODE_Name.PasswordChar = '\0';
            this.txtCODE_Name.ReadOnly = false;
            this.txtCODE_Name.ShowCalendarButton = true;
            this.txtCODE_Name.Size = new System.Drawing.Size(122, 22);
            this.txtCODE_Name.TabIndex = 1;
            this.txtCODE_Name.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtNOTE
            // 
            this.txtNOTE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtNOTE, 3);
            this.txtNOTE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mEALTYPEBindingSource, "NOTE", true));
            this.txtNOTE.Location = new System.Drawing.Point(86, 115);
            this.txtNOTE.MaxLength = 500;
            this.txtNOTE.Multiline = true;
            this.txtNOTE.Name = "txtNOTE";
            this.txtNOTE.Size = new System.Drawing.Size(645, 23);
            this.txtNOTE.TabIndex = 4;
            // 
            // plFV
            // 
            this.plFV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plFV.Controls.Add(this.tableLayoutPanel1);
            this.plFV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plFV.Location = new System.Drawing.Point(0, 0);
            this.plFV.Name = "plFV";
            this.plFV.Size = new System.Drawing.Size(736, 144);
            this.plFV.TabIndex = 1;
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
            this.splitContainer1.Size = new System.Drawing.Size(736, 561);
            this.splitContainer1.SplitterDistance = 331;
            this.splitContainer1.TabIndex = 1;
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
            this.splitContainer2.Panel2.Controls.Add(this.fdc);
            this.splitContainer2.Size = new System.Drawing.Size(736, 226);
            this.splitContainer2.SplitterDistance = 144;
            this.splitContainer2.TabIndex = 0;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // mealTypeTableAdapter
            // 
            this.mealTypeTableAdapter.ClearBeforeFill = true;
            // 
            // FRM2M_Type
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(736, 561);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "FRM2M_Type";
            this.Text = "FRM2M_Type";
            this.Load += new System.EventHandler(this.FRM2M_Type_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mEALTYPEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.plFV.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JBControls.FullDataCtrl fdc;
        private JBControls.DataGridView dgv;
        private dsAtt dsAtt;
        private System.Windows.Forms.Label lbCode;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbBTime;
        private System.Windows.Forms.Label lbETime;
        private System.Windows.Forms.Label lbNOTE;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel plFV;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn mEALTYPECDDISPDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtBTime;
        private System.Windows.Forms.TextBox txtETime;
        private JBControls.TextBox txtCODE;
        private JBControls.TextBox txtCODE_Name;
        private System.Windows.Forms.TextBox txtNOTE;
        private System.Windows.Forms.BindingSource mEALTYPEBindingSource;
        private dsAttTableAdapters.MealTypeTableAdapter mealTypeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn mEALTYPEDISPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mEALTYPENAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bTIMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eTIMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
    }
}
