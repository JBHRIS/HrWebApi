
namespace JBHR.Dividend.HunyaCustom.Code
{
    partial class Hunya_DIVDJobWeighting
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
            this.aKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.fdc = new JBControls.FullDataCtrl();
            this.dgv = new JBControls.DataGridView();
            this.aKDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIVDJOB_DISPDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.jobBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hunya_Dividend = new JBHR.Dividend.HunyaCustom.Hunya_Dividend();
            this.DIVDJOB_NameDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dIVDWeightingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyManDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hunya_DIVDJobWeightingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxJOB_DISP = new System.Windows.Forms.ComboBox();
            this.lbJOB = new System.Windows.Forms.Label();
            this.lbDIVDWeighting = new System.Windows.Forms.Label();
            this.txtDIVDWeighting = new JBControls.TextBox();
            this.plFV = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.PAGroupCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.jOBTableAdapter = new JBHR.Dividend.HunyaCustom.Hunya_DividendTableAdapters.JOBTableAdapter();
            this.hunya_DIVDJobWeightingTableAdapter = new JBHR.Dividend.HunyaCustom.Hunya_DividendTableAdapters.Hunya_DIVDJobWeightingTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_Dividend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_DIVDJobWeightingBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.plFV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // aKDataGridViewTextBoxColumn
            // 
            this.aKDataGridViewTextBoxColumn.DataPropertyName = "AK";
            this.aKDataGridViewTextBoxColumn.HeaderText = "AK";
            this.aKDataGridViewTextBoxColumn.Name = "aKDataGridViewTextBoxColumn";
            this.aKDataGridViewTextBoxColumn.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
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
            this.fdc.DataSource = this.hunya_DIVDJobWeightingBindingSource;
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
            this.aKDataGridViewTextBoxColumn1,
            this.DIVDJOB_DISPDataGridViewComboBoxColumn,
            this.DIVDJOB_NameDataGridViewComboBoxColumn,
            this.dIVDWeightingDataGridViewTextBoxColumn,
            this.keyManDataGridViewTextBoxColumn,
            this.keyDateDataGridViewTextBoxColumn,
            this.gIDDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.hunya_DIVDJobWeightingBindingSource;
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
            // aKDataGridViewTextBoxColumn1
            // 
            this.aKDataGridViewTextBoxColumn1.DataPropertyName = "AK";
            this.aKDataGridViewTextBoxColumn1.HeaderText = "AK";
            this.aKDataGridViewTextBoxColumn1.Name = "aKDataGridViewTextBoxColumn1";
            this.aKDataGridViewTextBoxColumn1.ReadOnly = true;
            this.aKDataGridViewTextBoxColumn1.Visible = false;
            // 
            // DIVDJOB_DISPDataGridViewComboBoxColumn
            // 
            this.DIVDJOB_DISPDataGridViewComboBoxColumn.DataPropertyName = "DIVDJOB";
            this.DIVDJOB_DISPDataGridViewComboBoxColumn.DataSource = this.jobBindingSource;
            this.DIVDJOB_DISPDataGridViewComboBoxColumn.DisplayMember = "JOB_DISP";
            this.DIVDJOB_DISPDataGridViewComboBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.DIVDJOB_DISPDataGridViewComboBoxColumn.HeaderText = "職務代碼";
            this.DIVDJOB_DISPDataGridViewComboBoxColumn.Name = "DIVDJOB_DISPDataGridViewComboBoxColumn";
            this.DIVDJOB_DISPDataGridViewComboBoxColumn.ReadOnly = true;
            this.DIVDJOB_DISPDataGridViewComboBoxColumn.ValueMember = "JOB";
            // 
            // jobBindingSource
            // 
            this.jobBindingSource.DataMember = "JOB";
            this.jobBindingSource.DataSource = this.hunya_Dividend;
            // 
            // hunya_Dividend
            // 
            this.hunya_Dividend.DataSetName = "Hunya_Dividend";
            this.hunya_Dividend.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DIVDJOB_NameDataGridViewComboBoxColumn
            // 
            this.DIVDJOB_NameDataGridViewComboBoxColumn.DataPropertyName = "DIVDJOB";
            this.DIVDJOB_NameDataGridViewComboBoxColumn.DataSource = this.jobBindingSource;
            this.DIVDJOB_NameDataGridViewComboBoxColumn.DisplayMember = "JOB_NAME";
            this.DIVDJOB_NameDataGridViewComboBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.DIVDJOB_NameDataGridViewComboBoxColumn.HeaderText = "職務名稱";
            this.DIVDJOB_NameDataGridViewComboBoxColumn.Name = "DIVDJOB_NameDataGridViewComboBoxColumn";
            this.DIVDJOB_NameDataGridViewComboBoxColumn.ReadOnly = true;
            this.DIVDJOB_NameDataGridViewComboBoxColumn.ValueMember = "JOB";
            // 
            // dIVDWeightingDataGridViewTextBoxColumn
            // 
            this.dIVDWeightingDataGridViewTextBoxColumn.DataPropertyName = "DIVDWeighting";
            this.dIVDWeightingDataGridViewTextBoxColumn.HeaderText = "分配權重";
            this.dIVDWeightingDataGridViewTextBoxColumn.Name = "dIVDWeightingDataGridViewTextBoxColumn";
            this.dIVDWeightingDataGridViewTextBoxColumn.ReadOnly = true;
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
            // hunya_DIVDJobWeightingBindingSource
            // 
            this.hunya_DIVDJobWeightingBindingSource.DataMember = "Hunya_DIVDJobWeighting";
            this.hunya_DIVDJobWeightingBindingSource.DataSource = this.hunya_Dividend;
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
            this.tableLayoutPanel1.Controls.Add(this.cbxJOB_DISP, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbJOB, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbDIVDWeighting, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDIVDWeighting, 2, 1);
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
            // cbxJOB_DISP
            // 
            this.cbxJOB_DISP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxJOB_DISP, 2);
            this.cbxJOB_DISP.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.hunya_DIVDJobWeightingBindingSource, "DIVDJOB", true));
            this.cbxJOB_DISP.FormattingEnabled = true;
            this.cbxJOB_DISP.Location = new System.Drawing.Point(171, 4);
            this.cbxJOB_DISP.Name = "cbxJOB_DISP";
            this.cbxJOB_DISP.Size = new System.Drawing.Size(194, 20);
            this.cbxJOB_DISP.TabIndex = 24;
            // 
            // lbJOB
            // 
            this.lbJOB.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbJOB.AutoSize = true;
            this.lbJOB.ForeColor = System.Drawing.Color.Red;
            this.lbJOB.Location = new System.Drawing.Point(112, 8);
            this.lbJOB.Name = "lbJOB";
            this.lbJOB.Size = new System.Drawing.Size(53, 12);
            this.lbJOB.TabIndex = 25;
            this.lbJOB.Text = "職務代碼";
            // 
            // lbDIVDWeighting
            // 
            this.lbDIVDWeighting.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDIVDWeighting.AutoSize = true;
            this.lbDIVDWeighting.ForeColor = System.Drawing.Color.Red;
            this.lbDIVDWeighting.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbDIVDWeighting.Location = new System.Drawing.Point(112, 36);
            this.lbDIVDWeighting.Name = "lbDIVDWeighting";
            this.lbDIVDWeighting.Size = new System.Drawing.Size(53, 12);
            this.lbDIVDWeighting.TabIndex = 26;
            this.lbDIVDWeighting.Text = "分配權重";
            // 
            // txtDIVDWeighting
            // 
            this.txtDIVDWeighting.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDIVDWeighting.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDIVDWeighting.CaptionLabel = null;
            this.txtDIVDWeighting.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDIVDWeighting.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hunya_DIVDJobWeightingBindingSource, "DIVDWeighting", true));
            this.txtDIVDWeighting.DecimalPlace = 2;
            this.txtDIVDWeighting.IsEmpty = false;
            this.txtDIVDWeighting.Location = new System.Drawing.Point(171, 31);
            this.txtDIVDWeighting.Mask = "";
            this.txtDIVDWeighting.MaxLength = -1;
            this.txtDIVDWeighting.Name = "txtDIVDWeighting";
            this.txtDIVDWeighting.PasswordChar = '\0';
            this.txtDIVDWeighting.ReadOnly = false;
            this.txtDIVDWeighting.ShowCalendarButton = false;
            this.txtDIVDWeighting.Size = new System.Drawing.Size(116, 22);
            this.txtDIVDWeighting.TabIndex = 28;
            this.txtDIVDWeighting.ValidType = JBControls.TextBox.EValidType.Decimal;
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
            this.splitContainer2.Panel2.Controls.Add(this.fdc);
            this.splitContainer2.Size = new System.Drawing.Size(784, 171);
            this.splitContainer2.SplitterDistance = 89;
            this.splitContainer2.TabIndex = 0;
            // 
            // PAGroupCode
            // 
            this.PAGroupCode.DataPropertyName = "PAGroupCode";
            this.PAGroupCode.HeaderText = "PAGroupCode";
            this.PAGroupCode.Name = "PAGroupCode";
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
            // jOBTableAdapter
            // 
            this.jOBTableAdapter.ClearBeforeFill = true;
            // 
            // hunya_DIVDJobWeightingTableAdapter
            // 
            this.hunya_DIVDJobWeightingTableAdapter.ClearBeforeFill = true;
            // 
            // Hunya_DIVDJobWeighting
            // 
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "Hunya_DIVDJobWeighting";
            this.Text = "Hunya_DIVDJobWeighting";
            this.Load += new System.EventHandler(this.Hunya_DIVDJobLWeighting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_Dividend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_DIVDJobWeightingBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.plFV.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn aKDataGridViewTextBoxColumn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private JBControls.DataGridView dgv;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel plFV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private JBControls.FullDataCtrl fdc;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAGroupCode;
        private System.Windows.Forms.ComboBox cbxJOB_DISP;
        private System.Windows.Forms.Label lbJOB;
        private System.Windows.Forms.Label lbDIVDWeighting;
        private Hunya_Dividend hunya_Dividend;
        private System.Windows.Forms.DataGridViewTextBoxColumn dIVDJOBLDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource jobBindingSource;
        private Hunya_DividendTableAdapters.JOBTableAdapter jOBTableAdapter;
        private System.Windows.Forms.BindingSource hunya_DIVDJobWeightingBindingSource;
        private Hunya_DividendTableAdapters.Hunya_DIVDJobWeightingTableAdapter hunya_DIVDJobWeightingTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn aKDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn DIVDJOB_DISPDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn DIVDJOB_NameDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dIVDWeightingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyManDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gIDDataGridViewTextBoxColumn;
        private JBControls.TextBox txtDIVDWeighting;
    }
}
