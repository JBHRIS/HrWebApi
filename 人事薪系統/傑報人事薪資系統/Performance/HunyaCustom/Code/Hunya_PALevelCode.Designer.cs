
namespace JBHR.Performance.HunyaCustom.Code
{
    partial class Hunya_PALevelCode
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
            this.btnCodeGroup = new System.Windows.Forms.Button();
            this.fdc = new JBControls.FullDataCtrl();
            this.dgv = new JBControls.DataGridView();
            this.aKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pALevelCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pALevelCodeDISPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pALevelCodeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pALevelWeightingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyManDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PALevelCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hunya_Performance = new JBHR.Performance.HunyaCustom.Hunya_Performance();
            this.lbPALevelCode_Name = new System.Windows.Forms.Label();
            this.txtPALevelCode_Name = new JBControls.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPALevelCode_DISP = new JBControls.TextBox();
            this.lbPALevelCode_DISP = new System.Windows.Forms.Label();
            this.lbPALevelWeighting = new System.Windows.Forms.Label();
            this.txtPALevelWeighting = new JBControls.TextBox();
            this.plFV = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PALevelCodeTableAdapter = new JBHR.Performance.HunyaCustom.Hunya_PerformanceTableAdapters.Hunya_PALevelCodeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PALevelCodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_Performance)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.plFV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
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
            this.fdc.DataSource = this.PALevelCodeBindingSource;
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
            this.pALevelCodeDataGridViewTextBoxColumn,
            this.pALevelCodeDISPDataGridViewTextBoxColumn,
            this.pALevelCodeNameDataGridViewTextBoxColumn,
            this.pALevelWeightingDataGridViewTextBoxColumn,
            this.keyManDataGridViewTextBoxColumn,
            this.keyDateDataGridViewTextBoxColumn,
            this.gIDDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.PALevelCodeBindingSource;
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
            // aKDataGridViewTextBoxColumn
            // 
            this.aKDataGridViewTextBoxColumn.DataPropertyName = "AK";
            this.aKDataGridViewTextBoxColumn.HeaderText = "AK";
            this.aKDataGridViewTextBoxColumn.Name = "aKDataGridViewTextBoxColumn";
            this.aKDataGridViewTextBoxColumn.ReadOnly = true;
            this.aKDataGridViewTextBoxColumn.Visible = false;
            // 
            // pALevelCodeDataGridViewTextBoxColumn
            // 
            this.pALevelCodeDataGridViewTextBoxColumn.DataPropertyName = "PALevelCode";
            this.pALevelCodeDataGridViewTextBoxColumn.HeaderText = "PALevelCode";
            this.pALevelCodeDataGridViewTextBoxColumn.Name = "pALevelCodeDataGridViewTextBoxColumn";
            this.pALevelCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.pALevelCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // pALevelCodeDISPDataGridViewTextBoxColumn
            // 
            this.pALevelCodeDISPDataGridViewTextBoxColumn.DataPropertyName = "PALevelCode_DISP";
            this.pALevelCodeDISPDataGridViewTextBoxColumn.HeaderText = "考核等級代碼";
            this.pALevelCodeDISPDataGridViewTextBoxColumn.Name = "pALevelCodeDISPDataGridViewTextBoxColumn";
            this.pALevelCodeDISPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pALevelCodeNameDataGridViewTextBoxColumn
            // 
            this.pALevelCodeNameDataGridViewTextBoxColumn.DataPropertyName = "PALevelCode_Name";
            this.pALevelCodeNameDataGridViewTextBoxColumn.HeaderText = "考核等級名稱";
            this.pALevelCodeNameDataGridViewTextBoxColumn.Name = "pALevelCodeNameDataGridViewTextBoxColumn";
            this.pALevelCodeNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pALevelWeightingDataGridViewTextBoxColumn
            // 
            this.pALevelWeightingDataGridViewTextBoxColumn.DataPropertyName = "PALevelWeighting";
            this.pALevelWeightingDataGridViewTextBoxColumn.HeaderText = "考核等級權重";
            this.pALevelWeightingDataGridViewTextBoxColumn.Name = "pALevelWeightingDataGridViewTextBoxColumn";
            this.pALevelWeightingDataGridViewTextBoxColumn.ReadOnly = true;
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
            // PALevelCodeBindingSource
            // 
            this.PALevelCodeBindingSource.DataMember = "Hunya_PALevelCode";
            this.PALevelCodeBindingSource.DataSource = this.hunya_Performance;
            // 
            // hunya_Performance
            // 
            this.hunya_Performance.DataSetName = "Hunya_Performance";
            this.hunya_Performance.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbPALevelCode_Name
            // 
            this.lbPALevelCode_Name.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPALevelCode_Name.AutoSize = true;
            this.lbPALevelCode_Name.ForeColor = System.Drawing.Color.Red;
            this.lbPALevelCode_Name.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPALevelCode_Name.Location = new System.Drawing.Point(88, 36);
            this.lbPALevelCode_Name.Name = "lbPALevelCode_Name";
            this.lbPALevelCode_Name.Size = new System.Drawing.Size(77, 12);
            this.lbPALevelCode_Name.TabIndex = 13;
            this.lbPALevelCode_Name.Text = "考核等級名稱";
            // 
            // txtPALevelCode_Name
            // 
            this.txtPALevelCode_Name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPALevelCode_Name.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtPALevelCode_Name.CaptionLabel = null;
            this.txtPALevelCode_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPALevelCode_Name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PALevelCodeBindingSource, "PALevelCode_Name", true));
            this.txtPALevelCode_Name.DecimalPlace = 2;
            this.txtPALevelCode_Name.IsEmpty = false;
            this.txtPALevelCode_Name.Location = new System.Drawing.Point(171, 31);
            this.txtPALevelCode_Name.Mask = "";
            this.txtPALevelCode_Name.MaxLength = 50;
            this.txtPALevelCode_Name.Name = "txtPALevelCode_Name";
            this.txtPALevelCode_Name.PasswordChar = '\0';
            this.txtPALevelCode_Name.ReadOnly = false;
            this.txtPALevelCode_Name.ShowCalendarButton = true;
            this.txtPALevelCode_Name.Size = new System.Drawing.Size(116, 22);
            this.txtPALevelCode_Name.TabIndex = 1;
            this.txtPALevelCode_Name.ValidType = JBControls.TextBox.EValidType.String;
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
            this.tableLayoutPanel1.Controls.Add(this.txtPALevelCode_DISP, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbPALevelCode_DISP, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbPALevelWeighting, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPALevelWeighting, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbPALevelCode_Name, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPALevelCode_Name, 2, 1);
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
            // txtPALevelCode_DISP
            // 
            this.txtPALevelCode_DISP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPALevelCode_DISP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtPALevelCode_DISP.CaptionLabel = null;
            this.txtPALevelCode_DISP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPALevelCode_DISP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PALevelCodeBindingSource, "PALevelCode_DISP", true));
            this.txtPALevelCode_DISP.DecimalPlace = 2;
            this.txtPALevelCode_DISP.IsEmpty = false;
            this.txtPALevelCode_DISP.Location = new System.Drawing.Point(171, 3);
            this.txtPALevelCode_DISP.Mask = "";
            this.txtPALevelCode_DISP.MaxLength = 50;
            this.txtPALevelCode_DISP.Name = "txtPALevelCode_DISP";
            this.txtPALevelCode_DISP.PasswordChar = '\0';
            this.txtPALevelCode_DISP.ReadOnly = false;
            this.txtPALevelCode_DISP.ShowCalendarButton = true;
            this.txtPALevelCode_DISP.Size = new System.Drawing.Size(116, 22);
            this.txtPALevelCode_DISP.TabIndex = 0;
            this.txtPALevelCode_DISP.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // lbPALevelCode_DISP
            // 
            this.lbPALevelCode_DISP.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPALevelCode_DISP.AutoSize = true;
            this.lbPALevelCode_DISP.ForeColor = System.Drawing.Color.Red;
            this.lbPALevelCode_DISP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPALevelCode_DISP.Location = new System.Drawing.Point(88, 8);
            this.lbPALevelCode_DISP.Name = "lbPALevelCode_DISP";
            this.lbPALevelCode_DISP.Size = new System.Drawing.Size(77, 12);
            this.lbPALevelCode_DISP.TabIndex = 0;
            this.lbPALevelCode_DISP.Text = "考核等級代碼";
            // 
            // lbPALevelWeighting
            // 
            this.lbPALevelWeighting.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPALevelWeighting.AutoSize = true;
            this.lbPALevelWeighting.ForeColor = System.Drawing.Color.Red;
            this.lbPALevelWeighting.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPALevelWeighting.Location = new System.Drawing.Point(112, 64);
            this.lbPALevelWeighting.Name = "lbPALevelWeighting";
            this.lbPALevelWeighting.Size = new System.Drawing.Size(53, 12);
            this.lbPALevelWeighting.TabIndex = 1;
            this.lbPALevelWeighting.Text = "等級權數";
            // 
            // txtPALevelWeighting
            // 
            this.txtPALevelWeighting.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPALevelWeighting.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtPALevelWeighting.CaptionLabel = null;
            this.txtPALevelWeighting.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPALevelWeighting.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PALevelCodeBindingSource, "PALevelWeighting", true));
            this.txtPALevelWeighting.DecimalPlace = 2;
            this.txtPALevelWeighting.IsEmpty = false;
            this.txtPALevelWeighting.Location = new System.Drawing.Point(171, 59);
            this.txtPALevelWeighting.Mask = "";
            this.txtPALevelWeighting.MaxLength = -1;
            this.txtPALevelWeighting.Name = "txtPALevelWeighting";
            this.txtPALevelWeighting.PasswordChar = '\0';
            this.txtPALevelWeighting.ReadOnly = false;
            this.txtPALevelWeighting.ShowCalendarButton = true;
            this.txtPALevelWeighting.Size = new System.Drawing.Size(116, 22);
            this.txtPALevelWeighting.TabIndex = 2;
            this.txtPALevelWeighting.ValidType = JBControls.TextBox.EValidType.Decimal;
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
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
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
            this.splitContainer1.TabIndex = 4;
            // 
            // PALevelCodeTableAdapter
            // 
            this.PALevelCodeTableAdapter.ClearBeforeFill = true;
            // 
            // Hunya_PALevelCode
            // 
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "Hunya_PALevelCode";
            this.Text = "Hunya_PALevelCode";
            this.Load += new System.EventHandler(this.Hunya_PALevelCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PALevelCodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_Performance)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.plFV.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCodeGroup;
        private JBControls.FullDataCtrl fdc;
        private JBControls.DataGridView dgv;
        private System.Windows.Forms.Label lbPALevelCode_Name;
        private JBControls.TextBox txtPALevelCode_Name;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private JBControls.TextBox txtPALevelCode_DISP;
        private System.Windows.Forms.Label lbPALevelCode_DISP;
        private System.Windows.Forms.Label lbPALevelWeighting;
        private JBControls.TextBox txtPALevelWeighting;
        private System.Windows.Forms.Panel plFV;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Hunya_Performance hunya_Performance;
        private System.Windows.Forms.BindingSource PALevelCodeBindingSource;
        private Hunya_PerformanceTableAdapters.Hunya_PALevelCodeTableAdapter PALevelCodeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn aKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pALevelCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pALevelCodeDISPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pALevelCodeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pALevelWeightingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyManDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gIDDataGridViewTextBoxColumn;
    }
}
