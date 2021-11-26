namespace JBHR.Att
{
    partial class FRM272A
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new JBControls.DataGridView();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.bASEBAKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.bASEBAKTableAdapter = new JBHR.Att.dsAttTableAdapters.BASEBAKTableAdapter();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.nOBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAMECDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBAKBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.nOBRDataGridViewTextBoxColumn,
            this.nAMECDataGridViewTextBoxColumn,
            this.bDATEDataGridViewTextBoxColumn,
            this.eDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bASEBAKBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(546, 168);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ptxNobr
            // 
            this.ptxNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobr.CaptionLabel = null;
            this.ptxNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobr.DataSource = this.bASEBAKBindingSource;
            this.ptxNobr.DisplayMember = "name_c";            
            this.ptxNobr.IsEmpty = true;
            this.ptxNobr.IsEmptyToQuery = true;
            //this.ptxNobr.IsLeaveToQuery = false;
            //this.ptxNobr.IsQuery = true;
            this.ptxNobr.LabelText = "";
            this.ptxNobr.Location = new System.Drawing.Point(12, 12);
            this.ptxNobr.Name = "ptxNobr";
            this.ptxNobr.QueryFields = "nobr,bdate,edate,name_c";
            this.ptxNobr.ReadOnly = false;
            //this.ptxNobr.ShowExceptionMsg = true;
            this.ptxNobr.Size = new System.Drawing.Size(61, 22);
            this.ptxNobr.TabIndex = 1;
            this.ptxNobr.ValueMember = "nobr";
            this.ptxNobr.WhereCmd = "";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(134, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "加入";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // bASEBAKBindingSource
            // 
            this.bASEBAKBindingSource.DataMember = "BASEBAK";
            this.bASEBAKBindingSource.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bASEBAKTableAdapter
            // 
            this.bASEBAKTableAdapter.ClearBeforeFill = true;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 60F;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Text = "加入";
            this.Column1.ToolTipText = "加入";
            this.Column1.UseColumnTextForButtonValue = true;
            this.Column1.Width = 60;
            // 
            // nOBRDataGridViewTextBoxColumn
            // 
            this.nOBRDataGridViewTextBoxColumn.DataPropertyName = "NOBR";
            this.nOBRDataGridViewTextBoxColumn.HeaderText = "員工編號";
            this.nOBRDataGridViewTextBoxColumn.Name = "nOBRDataGridViewTextBoxColumn";
            // 
            // nAMECDataGridViewTextBoxColumn
            // 
            this.nAMECDataGridViewTextBoxColumn.DataPropertyName = "NAME_C";
            this.nAMECDataGridViewTextBoxColumn.HeaderText = "員工姓名";
            this.nAMECDataGridViewTextBoxColumn.Name = "nAMECDataGridViewTextBoxColumn";
            // 
            // bDATEDataGridViewTextBoxColumn
            // 
            this.bDATEDataGridViewTextBoxColumn.DataPropertyName = "BDATE";
            this.bDATEDataGridViewTextBoxColumn.HeaderText = "開始日期";
            this.bDATEDataGridViewTextBoxColumn.Name = "bDATEDataGridViewTextBoxColumn";
            // 
            // eDATEDataGridViewTextBoxColumn
            // 
            this.eDATEDataGridViewTextBoxColumn.DataPropertyName = "EDATE";
            this.eDATEDataGridViewTextBoxColumn.HeaderText = "結束日期";
            this.eDATEDataGridViewTextBoxColumn.Name = "eDATEDataGridViewTextBoxColumn";
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            // 
            // FRM272A
            // 
            this.ClientSize = new System.Drawing.Size(570, 220);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.ptxNobr);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM272A";
            this.Load += new System.EventHandler(this.FRM272A_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBAKBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JBControls.DataGridView dataGridView1;
        private JBControls.PopupTextBox ptxNobr;
        private System.Windows.Forms.Button btnAdd;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource bASEBAKBindingSource;
        private JBHR.Att.dsAttTableAdapters.BASEBAKTableAdapter bASEBAKTableAdapter;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAMECDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
    }
}
