namespace JBHR.Bas
{
    partial class FRM1G
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
            this.dataGridView1 = new JBControls.DataGridView();
            this.NOBR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.MASTER1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.rELISHCDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DEPT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JOB_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mASTERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bnIMPORT = new System.Windows.Forms.Button();
            this.cbRELISHCD = new System.Windows.Forms.ComboBox();
            this.textBox1 = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.popupTextBox1 = new JBControls.PopupTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.mASTERTableAdapter = new JBHR.Bas.BasDSTableAdapters.MASTERTableAdapter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.rELISHCDTableAdapter = new JBHR.Bas.BasDSTableAdapters.RELISHCDTableAdapter();
            this.v_BASETableAdapter = new JBHR.Bas.BasDSTableAdapters.V_BASETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rELISHCDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mASTERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(626, 441);
            this.splitContainer1.SplitterDistance = 245;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NOBR,
            this.nOBRDataGridViewTextBoxColumn,
            this.MASTER1,
            this.DEPT_NAME,
            this.JOB_NAME,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.MEMO});
            this.dataGridView1.DataSource = this.mASTERBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(626, 245);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // NOBR
            // 
            this.NOBR.DataPropertyName = "NOBR";
            this.NOBR.HeaderText = "員工編號";
            this.NOBR.MinimumWidth = 8;
            this.NOBR.Name = "NOBR";
            this.NOBR.ReadOnly = true;
            // 
            // nOBRDataGridViewTextBoxColumn
            // 
            this.nOBRDataGridViewTextBoxColumn.DataPropertyName = "NOBR";
            this.nOBRDataGridViewTextBoxColumn.DataSource = this.vBASEBindingSource;
            this.nOBRDataGridViewTextBoxColumn.DisplayMember = "NAME_C";
            this.nOBRDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.nOBRDataGridViewTextBoxColumn.HeaderText = "員工姓名";
            this.nOBRDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nOBRDataGridViewTextBoxColumn.Name = "nOBRDataGridViewTextBoxColumn";
            this.nOBRDataGridViewTextBoxColumn.ReadOnly = true;
            this.nOBRDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nOBRDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.nOBRDataGridViewTextBoxColumn.ValueMember = "NOBR";
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.basDS;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MASTER1
            // 
            this.MASTER1.DataPropertyName = "MASTER1";
            this.MASTER1.DataSource = this.rELISHCDBindingSource;
            this.MASTER1.DisplayMember = "RELISH";
            this.MASTER1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.MASTER1.HeaderText = "專長與興趣";
            this.MASTER1.MinimumWidth = 8;
            this.MASTER1.Name = "MASTER1";
            this.MASTER1.ReadOnly = true;
            this.MASTER1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MASTER1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MASTER1.ValueMember = "RELISH_CODE";
            // 
            // rELISHCDBindingSource
            // 
            this.rELISHCDBindingSource.DataMember = "RELISHCD";
            this.rELISHCDBindingSource.DataSource = this.basDS;
            // 
            // DEPT_NAME
            // 
            this.DEPT_NAME.DataPropertyName = "DEPT_NAME";
            this.DEPT_NAME.HeaderText = "部門";
            this.DEPT_NAME.MinimumWidth = 8;
            this.DEPT_NAME.Name = "DEPT_NAME";
            this.DEPT_NAME.ReadOnly = true;
            // 
            // JOB_NAME
            // 
            this.JOB_NAME.DataPropertyName = "JOB_NAME";
            this.JOB_NAME.HeaderText = "職稱";
            this.JOB_NAME.MinimumWidth = 8;
            this.JOB_NAME.Name = "JOB_NAME";
            this.JOB_NAME.ReadOnly = true;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.kEYMANDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄時間";
            this.kEYDATEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // MEMO
            // 
            this.MEMO.DataPropertyName = "MEMO";
            this.MEMO.HeaderText = "備註";
            this.MEMO.MinimumWidth = 8;
            this.MEMO.Name = "MEMO";
            this.MEMO.ReadOnly = true;
            // 
            // mASTERBindingSource
            // 
            this.mASTERBindingSource.DataMember = "MASTER";
            this.mASTERBindingSource.DataSource = this.basDS;
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
            this.splitContainer2.Panel2.Controls.Add(this.fullDataCtrl1);
            this.splitContainer2.Size = new System.Drawing.Size(626, 192);
            this.splitContainer2.SplitterDistance = 112;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.bnIMPORT);
            this.panel1.Controls.Add(this.cbRELISHCD);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.popupTextBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 112);
            this.panel1.TabIndex = 0;
            // 
            // bnIMPORT
            // 
            this.bnIMPORT.Location = new System.Drawing.Point(547, 81);
            this.bnIMPORT.Name = "bnIMPORT";
            this.bnIMPORT.Size = new System.Drawing.Size(75, 23);
            this.bnIMPORT.TabIndex = 12;
            this.bnIMPORT.TabStop = false;
            this.bnIMPORT.Text = "匯入";
            this.bnIMPORT.UseVisualStyleBackColor = true;
            this.bnIMPORT.Click += new System.EventHandler(this.bnIMPORT_Click);
            // 
            // cbRELISHCD
            // 
            this.cbRELISHCD.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.mASTERBindingSource, "MASTER1", true));
            this.cbRELISHCD.FormattingEnabled = true;
            this.cbRELISHCD.Location = new System.Drawing.Point(123, 39);
            this.cbRELISHCD.Name = "cbRELISHCD";
            this.cbRELISHCD.Size = new System.Drawing.Size(300, 20);
            this.cbRELISHCD.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = this.label3;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mASTERBindingSource, "MEMO", true));
            this.textBox1.DecimalPlace = 2;
            this.textBox1.IsEmpty = true;
            this.textBox1.Location = new System.Drawing.Point(123, 65);
            this.textBox1.Mask = "";
            this.textBox1.MaxLength = 500;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = false;
            this.textBox1.ShowCalendarButton = true;
            this.textBox1.Size = new System.Drawing.Size(413, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(88, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "備註";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(52, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "專長與興趣";
            // 
            // popupTextBox1
            // 
            this.popupTextBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.popupTextBox1.CaptionLabel = this.label1;
            this.popupTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.popupTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mASTERBindingSource, "NOBR", true));
            this.popupTextBox1.DataSource = this.vBASEBindingSource;
            this.popupTextBox1.DisplayMember = "name_c";
            this.popupTextBox1.IsEmpty = false;
            this.popupTextBox1.IsEmptyToQuery = true;
            this.popupTextBox1.IsMustBeFound = true;
            this.popupTextBox1.LabelText = "";
            this.popupTextBox1.Location = new System.Drawing.Point(123, 8);
            this.popupTextBox1.Name = "popupTextBox1";
            this.popupTextBox1.QueryFields = "name_e,name_p";
            this.popupTextBox1.ReadOnly = false;
            this.popupTextBox1.ShowDisplayName = true;
            this.popupTextBox1.Size = new System.Drawing.Size(100, 22);
            this.popupTextBox1.TabIndex = 0;
            this.popupTextBox1.ValueMember = "nobr";
            this.popupTextBox1.WhereCmd = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(64, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "員工編號";
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
            this.fullDataCtrl1.DataSource = this.mASTERBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(0, 0);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "nobr,master";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(626, 73);
            this.fullDataCtrl1.SortFields = "nobr";
            this.fullDataCtrl1.TabIndex = 10;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterEdit);
            this.fullDataCtrl1.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeDel);
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            this.fullDataCtrl1.AfterQuery += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterQuery);
            this.fullDataCtrl1.AfterShow += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterShow);
            // 
            // mASTERTableAdapter
            // 
            this.mASTERTableAdapter.ClearBeforeFill = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.mASTERBindingSource;
            // 
            // rELISHCDTableAdapter
            // 
            this.rELISHCDTableAdapter.ClearBeforeFill = true;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // FRM1G
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM1G";
            this.Text = "FRM1G";
            this.Load += new System.EventHandler(this.FRM1G_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rELISHCDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mASTERBindingSource)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private JBControls.FullDataCtrl fullDataCtrl1;
		private JBControls.DataGridView dataGridView1;
        private BasDS basDS;
        private System.Windows.Forms.BindingSource mASTERBindingSource;
		private JBHR.Bas.BasDSTableAdapters.MASTERTableAdapter mASTERTableAdapter;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private JBControls.PopupTextBox popupTextBox1;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mASTERDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource rELISHCDBindingSource;
        private JBHR.Bas.BasDSTableAdapters.RELISHCDTableAdapter rELISHCDTableAdapter;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private JBHR.Bas.BasDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private System.Windows.Forms.Label label3;
        private JBControls.TextBox textBox1;
        private System.Windows.Forms.ComboBox cbRELISHCD;
        private System.Windows.Forms.Button bnIMPORT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOBR;
        private System.Windows.Forms.DataGridViewComboBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn MASTER1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn JOB_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEMO;
    }
}