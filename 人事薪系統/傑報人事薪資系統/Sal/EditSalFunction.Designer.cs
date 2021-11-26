namespace JBHR.Sal
{
    partial class EditSalFunction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSalFunction));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.aUTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CALCTYPE = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.mTCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainDS = new JBHR.MainDS();
            this.ITEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SORT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CALC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.REF = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SCRIPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALFUNCTIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.sALFUNCTIONTableAdapter = new JBHR.Sal.SalaryDSTableAdapters.SALFUNCTIONTableAdapter();
            this.mTCODETableAdapter = new JBHR.MainDSTableAdapters.MTCODETableAdapter();
            this.btnSAVE = new System.Windows.Forms.Button();
            this.btnCLOSE = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALFUNCTIONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aUTODataGridViewTextBoxColumn,
            this.CALCTYPE,
            this.ITEM,
            this.SORT,
            this.CALC,
            this.REF,
            this.SCRIPT});
            this.dataGridView1.DataSource = this.sALFUNCTIONBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 4);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1206, 397);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserAddedRow);
            // 
            // aUTODataGridViewTextBoxColumn
            // 
            this.aUTODataGridViewTextBoxColumn.DataPropertyName = "AUTO";
            this.aUTODataGridViewTextBoxColumn.HeaderText = "AUTO";
            this.aUTODataGridViewTextBoxColumn.MinimumWidth = 8;
            this.aUTODataGridViewTextBoxColumn.Name = "aUTODataGridViewTextBoxColumn";
            this.aUTODataGridViewTextBoxColumn.ReadOnly = true;
            this.aUTODataGridViewTextBoxColumn.Width = 90;
            // 
            // CALCTYPE
            // 
            this.CALCTYPE.DataPropertyName = "CALCTYPE";
            this.CALCTYPE.DataSource = this.mTCODEBindingSource;
            this.CALCTYPE.DisplayMember = "NAME";
            this.CALCTYPE.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.CALCTYPE.HeaderText = "計算類別";
            this.CALCTYPE.MinimumWidth = 8;
            this.CALCTYPE.Name = "CALCTYPE";
            this.CALCTYPE.ValueMember = "CODE";
            this.CALCTYPE.Width = 86;
            // 
            // mTCODEBindingSource
            // 
            this.mTCODEBindingSource.DataMember = "MTCODE";
            this.mTCODEBindingSource.DataSource = this.mainDS;
            this.mTCODEBindingSource.Sort = "SORT";
            // 
            // mainDS
            // 
            this.mainDS.DataSetName = "MainDS";
            this.mainDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.mainDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ITEM
            // 
            this.ITEM.DataPropertyName = "ITEM";
            this.ITEM.HeaderText = "項目名稱";
            this.ITEM.MinimumWidth = 8;
            this.ITEM.Name = "ITEM";
            this.ITEM.Width = 116;
            // 
            // SORT
            // 
            this.SORT.DataPropertyName = "SORT";
            this.SORT.HeaderText = "排序";
            this.SORT.MinimumWidth = 8;
            this.SORT.Name = "SORT";
            this.SORT.Width = 80;
            // 
            // CALC
            // 
            this.CALC.DataPropertyName = "CALC";
            this.CALC.HeaderText = "使用";
            this.CALC.MinimumWidth = 8;
            this.CALC.Name = "CALC";
            this.CALC.Width = 50;
            // 
            // REF
            // 
            this.REF.DataPropertyName = "REF";
            this.REF.HeaderText = "參數";
            this.REF.MinimumWidth = 8;
            this.REF.Name = "REF";
            this.REF.Width = 50;
            // 
            // SCRIPT
            // 
            this.SCRIPT.DataPropertyName = "SCRIPT";
            this.SCRIPT.HeaderText = "公式";
            this.SCRIPT.MinimumWidth = 8;
            this.SCRIPT.Name = "SCRIPT";
            this.SCRIPT.Width = 80;
            // 
            // sALFUNCTIONBindingSource
            // 
            this.sALFUNCTIONBindingSource.DataMember = "SALFUNCTION";
            this.sALFUNCTIONBindingSource.DataSource = this.salaryDS;
            // 
            // salaryDS
            // 
            this.salaryDS.DataSetName = "JohnnyDBDataSet";
            this.salaryDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.salaryDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sALFUNCTIONTableAdapter
            // 
            this.sALFUNCTIONTableAdapter.ClearBeforeFill = true;
            // 
            // mTCODETableAdapter
            // 
            this.mTCODETableAdapter.ClearBeforeFill = true;
            // 
            // btnSAVE
            // 
            this.btnSAVE.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSAVE.Location = new System.Drawing.Point(482, 17);
            this.btnSAVE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(84, 40);
            this.btnSAVE.TabIndex = 1;
            this.btnSAVE.Text = "儲存";
            this.btnSAVE.UseVisualStyleBackColor = true;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // btnCLOSE
            // 
            this.btnCLOSE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCLOSE.Location = new System.Drawing.Point(640, 17);
            this.btnCLOSE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCLOSE.Name = "btnCLOSE";
            this.btnCLOSE.Size = new System.Drawing.Size(84, 40);
            this.btnCLOSE.TabIndex = 1;
            this.btnCLOSE.Text = "關閉";
            this.btnCLOSE.UseVisualStyleBackColor = true;
            this.btnCLOSE.Click += new System.EventHandler(this.btnCLOSE_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.25123F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.74877F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1212, 487);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnSAVE, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCLOSE, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 409);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1206, 74);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // EditSalFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 487);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EditSalFunction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditSalFunction";
            this.Load += new System.EventHandler(this.EditSalFunction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALFUNCTIONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource sALFUNCTIONBindingSource;
        private SalaryDSTableAdapters.SALFUNCTIONTableAdapter sALFUNCTIONTableAdapter;
        private System.Windows.Forms.BindingSource mTCODEBindingSource;
        private MainDSTableAdapters.MTCODETableAdapter mTCODETableAdapter;
        private System.Windows.Forms.Button btnSAVE;
        private System.Windows.Forms.Button btnCLOSE;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MainDS mainDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn aUTODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn CALCTYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn SORT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CALC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn REF;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCRIPT;
    }
}