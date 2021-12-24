
namespace JBHR.AnnualBonus.HunyaCustom.Code
{
    partial class Hunya_ABLevelCode
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.plFV = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtABLevelCode_DISP = new JBControls.TextBox();
            this.ABLevelCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hunya_AnnualBonus = new JBHR.AnnualBonus.HunyaCustom.Hunya_AnnualBonus();
            this.lbABLevelCode_DISP = new System.Windows.Forms.Label();
            this.lbABLevelBonusRate = new System.Windows.Forms.Label();
            this.txtABLevelBonusRate = new JBControls.TextBox();
            this.lbABLevelCode_Name = new System.Windows.Forms.Label();
            this.txtABLevelCode_Name = new JBControls.TextBox();
            this.btnCodeGroup = new System.Windows.Forms.Button();
            this.fdc = new JBControls.FullDataCtrl();
            this.dgv = new JBControls.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ABLevelCodeTableAdapter = new JBHR.AnnualBonus.HunyaCustom.Hunya_AnnualBonusTableAdapters.Hunya_ABLevelCodeTableAdapter();
            this.aKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aBLevelCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aBLevelCodeDISPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aBLevelCodeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aBLevelBonusRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyManDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.plFV.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ABLevelCodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_AnnualBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.txtABLevelCode_DISP, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbABLevelCode_DISP, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbABLevelBonusRate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtABLevelBonusRate, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbABLevelCode_Name, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtABLevelCode_Name, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 85);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtABLevelCode_DISP
            // 
            this.txtABLevelCode_DISP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtABLevelCode_DISP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtABLevelCode_DISP.CaptionLabel = null;
            this.txtABLevelCode_DISP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtABLevelCode_DISP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ABLevelCodeBindingSource, "ABLevelCode_DISP", true));
            this.txtABLevelCode_DISP.DecimalPlace = 2;
            this.txtABLevelCode_DISP.IsEmpty = false;
            this.txtABLevelCode_DISP.Location = new System.Drawing.Point(171, 3);
            this.txtABLevelCode_DISP.Mask = "";
            this.txtABLevelCode_DISP.MaxLength = 50;
            this.txtABLevelCode_DISP.Name = "txtABLevelCode_DISP";
            this.txtABLevelCode_DISP.PasswordChar = '\0';
            this.txtABLevelCode_DISP.ReadOnly = false;
            this.txtABLevelCode_DISP.ShowCalendarButton = true;
            this.txtABLevelCode_DISP.Size = new System.Drawing.Size(116, 22);
            this.txtABLevelCode_DISP.TabIndex = 0;
            this.txtABLevelCode_DISP.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // ABLevelCodeBindingSource
            // 
            this.ABLevelCodeBindingSource.DataMember = "Hunya_ABLevelCode";
            this.ABLevelCodeBindingSource.DataSource = this.hunya_AnnualBonus;
            // 
            // hunya_AnnualBonus
            // 
            this.hunya_AnnualBonus.DataSetName = "Hunya_AnnualBonus";
            this.hunya_AnnualBonus.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbABLevelCode_DISP
            // 
            this.lbABLevelCode_DISP.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbABLevelCode_DISP.AutoSize = true;
            this.lbABLevelCode_DISP.ForeColor = System.Drawing.Color.Red;
            this.lbABLevelCode_DISP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbABLevelCode_DISP.Location = new System.Drawing.Point(88, 8);
            this.lbABLevelCode_DISP.Name = "lbABLevelCode_DISP";
            this.lbABLevelCode_DISP.Size = new System.Drawing.Size(77, 12);
            this.lbABLevelCode_DISP.TabIndex = 3;
            this.lbABLevelCode_DISP.Text = "考績等第代碼";
            // 
            // lbABLevelBonusRate
            // 
            this.lbABLevelBonusRate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbABLevelBonusRate.AutoSize = true;
            this.lbABLevelBonusRate.ForeColor = System.Drawing.Color.Red;
            this.lbABLevelBonusRate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbABLevelBonusRate.Location = new System.Drawing.Point(112, 64);
            this.lbABLevelBonusRate.Name = "lbABLevelBonusRate";
            this.lbABLevelBonusRate.Size = new System.Drawing.Size(53, 12);
            this.lbABLevelBonusRate.TabIndex = 5;
            this.lbABLevelBonusRate.Text = "獎勵比率";
            // 
            // txtABLevelBonusRate
            // 
            this.txtABLevelBonusRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtABLevelBonusRate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtABLevelBonusRate.CaptionLabel = null;
            this.txtABLevelBonusRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtABLevelBonusRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ABLevelCodeBindingSource, "ABLevelBonusRate", true));
            this.txtABLevelBonusRate.DecimalPlace = 2;
            this.txtABLevelBonusRate.IsEmpty = false;
            this.txtABLevelBonusRate.Location = new System.Drawing.Point(171, 59);
            this.txtABLevelBonusRate.Mask = "";
            this.txtABLevelBonusRate.MaxLength = -1;
            this.txtABLevelBonusRate.Name = "txtABLevelBonusRate";
            this.txtABLevelBonusRate.PasswordChar = '\0';
            this.txtABLevelBonusRate.ReadOnly = false;
            this.txtABLevelBonusRate.ShowCalendarButton = true;
            this.txtABLevelBonusRate.Size = new System.Drawing.Size(116, 22);
            this.txtABLevelBonusRate.TabIndex = 2;
            this.txtABLevelBonusRate.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // lbABLevelCode_Name
            // 
            this.lbABLevelCode_Name.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbABLevelCode_Name.AutoSize = true;
            this.lbABLevelCode_Name.ForeColor = System.Drawing.Color.Red;
            this.lbABLevelCode_Name.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbABLevelCode_Name.Location = new System.Drawing.Point(88, 36);
            this.lbABLevelCode_Name.Name = "lbABLevelCode_Name";
            this.lbABLevelCode_Name.Size = new System.Drawing.Size(77, 12);
            this.lbABLevelCode_Name.TabIndex = 4;
            this.lbABLevelCode_Name.Text = "考績等第名稱";
            // 
            // txtABLevelCode_Name
            // 
            this.txtABLevelCode_Name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtABLevelCode_Name.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtABLevelCode_Name.CaptionLabel = null;
            this.txtABLevelCode_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtABLevelCode_Name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ABLevelCodeBindingSource, "ABLevelCode_Name", true));
            this.txtABLevelCode_Name.DecimalPlace = 2;
            this.txtABLevelCode_Name.IsEmpty = false;
            this.txtABLevelCode_Name.Location = new System.Drawing.Point(171, 31);
            this.txtABLevelCode_Name.Mask = "";
            this.txtABLevelCode_Name.MaxLength = 50;
            this.txtABLevelCode_Name.Name = "txtABLevelCode_Name";
            this.txtABLevelCode_Name.PasswordChar = '\0';
            this.txtABLevelCode_Name.ReadOnly = false;
            this.txtABLevelCode_Name.ShowCalendarButton = true;
            this.txtABLevelCode_Name.Size = new System.Drawing.Size(116, 22);
            this.txtABLevelCode_Name.TabIndex = 1;
            this.txtABLevelCode_Name.ValidType = JBControls.TextBox.EValidType.String;
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
            this.fdc.DataSource = this.ABLevelCodeBindingSource;
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
            this.aKDataGridViewTextBoxColumn,
            this.aBLevelCodeDataGridViewTextBoxColumn,
            this.aBLevelCodeDISPDataGridViewTextBoxColumn,
            this.aBLevelCodeNameDataGridViewTextBoxColumn,
            this.aBLevelBonusRateDataGridViewTextBoxColumn,
            this.keyManDataGridViewTextBoxColumn,
            this.keyDateDataGridViewTextBoxColumn,
            this.gIDDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.ABLevelCodeBindingSource;
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
            this.splitContainer1.TabIndex = 5;
            // 
            // ABLevelCodeTableAdapter
            // 
            this.ABLevelCodeTableAdapter.ClearBeforeFill = true;
            // 
            // aKDataGridViewTextBoxColumn
            // 
            this.aKDataGridViewTextBoxColumn.DataPropertyName = "AK";
            this.aKDataGridViewTextBoxColumn.HeaderText = "AK";
            this.aKDataGridViewTextBoxColumn.Name = "aKDataGridViewTextBoxColumn";
            this.aKDataGridViewTextBoxColumn.ReadOnly = true;
            this.aKDataGridViewTextBoxColumn.Visible = false;
            // 
            // aBLevelCodeDataGridViewTextBoxColumn
            // 
            this.aBLevelCodeDataGridViewTextBoxColumn.DataPropertyName = "ABLevelCode";
            this.aBLevelCodeDataGridViewTextBoxColumn.HeaderText = "ABLevelCode";
            this.aBLevelCodeDataGridViewTextBoxColumn.Name = "aBLevelCodeDataGridViewTextBoxColumn";
            this.aBLevelCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.aBLevelCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // aBLevelCodeDISPDataGridViewTextBoxColumn
            // 
            this.aBLevelCodeDISPDataGridViewTextBoxColumn.DataPropertyName = "ABLevelCode_DISP";
            this.aBLevelCodeDISPDataGridViewTextBoxColumn.HeaderText = "考績等第代碼";
            this.aBLevelCodeDISPDataGridViewTextBoxColumn.Name = "aBLevelCodeDISPDataGridViewTextBoxColumn";
            this.aBLevelCodeDISPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aBLevelCodeNameDataGridViewTextBoxColumn
            // 
            this.aBLevelCodeNameDataGridViewTextBoxColumn.DataPropertyName = "ABLevelCode_Name";
            this.aBLevelCodeNameDataGridViewTextBoxColumn.HeaderText = "考績等第名稱";
            this.aBLevelCodeNameDataGridViewTextBoxColumn.Name = "aBLevelCodeNameDataGridViewTextBoxColumn";
            this.aBLevelCodeNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aBLevelBonusRateDataGridViewTextBoxColumn
            // 
            this.aBLevelBonusRateDataGridViewTextBoxColumn.DataPropertyName = "ABLevelBonusRate";
            this.aBLevelBonusRateDataGridViewTextBoxColumn.HeaderText = "考績等第獎勵比率";
            this.aBLevelBonusRateDataGridViewTextBoxColumn.Name = "aBLevelBonusRateDataGridViewTextBoxColumn";
            this.aBLevelBonusRateDataGridViewTextBoxColumn.ReadOnly = true;
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
            // Hunya_ABLevelCode
            // 
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "Hunya_ABLevelCode";
            this.Text = "Hunya_ABLevelCode";
            this.Load += new System.EventHandler(this.Hunya_ABLevelCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.plFV.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ABLevelCodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_AnnualBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private JBControls.DataGridView dgv;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel plFV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private JBControls.TextBox txtABLevelCode_DISP;
        private System.Windows.Forms.Label lbABLevelCode_DISP;
        private System.Windows.Forms.Label lbABLevelBonusRate;
        private JBControls.TextBox txtABLevelBonusRate;
        private System.Windows.Forms.Label lbABLevelCode_Name;
        private JBControls.TextBox txtABLevelCode_Name;
        private System.Windows.Forms.Button btnCodeGroup;
        private JBControls.FullDataCtrl fdc;
        private System.Windows.Forms.BindingSource ABLevelCodeBindingSource;
        private Hunya_AnnualBonus hunya_AnnualBonus;
        private Hunya_AnnualBonusTableAdapters.Hunya_ABLevelCodeTableAdapter ABLevelCodeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn aKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aBLevelCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aBLevelCodeDISPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aBLevelCodeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aBLevelBonusRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyManDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gIDDataGridViewTextBoxColumn;
    }
}
