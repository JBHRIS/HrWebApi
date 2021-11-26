namespace JBHR.Att
{
    partial class FRM2KB
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
            this.btnTran = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnGetData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnOverWrite = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.dataGridView2 = new JBControls.DataGridView();
            this.nOBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oNTIMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cARDNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cARDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.cARDTableAdapter = new JBHR.Att.dsAttTableAdapters.CARDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cARDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(592, 351);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnTran
            // 
            this.btnTran.Location = new System.Drawing.Point(426, 3);
            this.btnTran.Name = "btnTran";
            this.btnTran.Size = new System.Drawing.Size(75, 23);
            this.btnTran.TabIndex = 1;
            this.btnTran.Text = "轉入";
            this.btnTran.UseVisualStyleBackColor = true;
            this.btnTran.Click += new System.EventHandler(this.btnTran_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 6);
            this.dateTimePicker1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(156, 22);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(612, 428);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.btnGetData);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.dateTimePicker2);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.btnTran);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(604, 402);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "匯入";
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(345, 3);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 4;
            this.btnGetData.Text = "讀取";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "~";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(183, 6);
            this.dateTimePicker2.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(156, 22);
            this.dateTimePicker2.TabIndex = 2;
            this.dateTimePicker2.Value = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.btnInsert);
            this.tabPage2.Controls.Add(this.btnExport);
            this.tabPage2.Controls.Add(this.btnOverWrite);
            this.tabPage2.Controls.Add(this.btnDeleteAll);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(604, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "衝突";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(168, 6);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 3;
            this.btnInsert.Text = "全部寫入";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(249, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "全部匯出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnOverWrite
            // 
            this.btnOverWrite.Location = new System.Drawing.Point(87, 6);
            this.btnOverWrite.Name = "btnOverWrite";
            this.btnOverWrite.Size = new System.Drawing.Size(75, 23);
            this.btnOverWrite.TabIndex = 1;
            this.btnOverWrite.Text = "全部覆蓋";
            this.btnOverWrite.UseVisualStyleBackColor = true;
            this.btnOverWrite.Click += new System.EventHandler(this.btnOverWrite_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(6, 6);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAll.TabIndex = 1;
            this.btnDeleteAll.Text = "全部刪除";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nOBRDataGridViewTextBoxColumn,
            this.aDATEDataGridViewTextBoxColumn,
            this.oNTIMEDataGridViewTextBoxColumn,
            this.cARDNODataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.cARDBindingSource;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView2.Location = new System.Drawing.Point(6, 35);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(592, 361);
            this.dataGridView2.TabIndex = 0;
            // 
            // nOBRDataGridViewTextBoxColumn
            // 
            this.nOBRDataGridViewTextBoxColumn.DataPropertyName = "NOBR";
            this.nOBRDataGridViewTextBoxColumn.HeaderText = "員工編號";
            this.nOBRDataGridViewTextBoxColumn.Name = "nOBRDataGridViewTextBoxColumn";
            // 
            // aDATEDataGridViewTextBoxColumn
            // 
            this.aDATEDataGridViewTextBoxColumn.DataPropertyName = "ADATE";
            this.aDATEDataGridViewTextBoxColumn.HeaderText = "刷卡日期";
            this.aDATEDataGridViewTextBoxColumn.Name = "aDATEDataGridViewTextBoxColumn";
            // 
            // oNTIMEDataGridViewTextBoxColumn
            // 
            this.oNTIMEDataGridViewTextBoxColumn.DataPropertyName = "ONTIME";
            this.oNTIMEDataGridViewTextBoxColumn.HeaderText = "刷卡時間";
            this.oNTIMEDataGridViewTextBoxColumn.Name = "oNTIMEDataGridViewTextBoxColumn";
            // 
            // cARDNODataGridViewTextBoxColumn
            // 
            this.cARDNODataGridViewTextBoxColumn.DataPropertyName = "CARDNO";
            this.cARDNODataGridViewTextBoxColumn.HeaderText = "刷卡卡號";
            this.cARDNODataGridViewTextBoxColumn.Name = "cARDNODataGridViewTextBoxColumn";
            // 
            // cARDBindingSource
            // 
            this.cARDBindingSource.DataMember = "CARD";
            this.cARDBindingSource.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cARDTableAdapter
            // 
            this.cARDTableAdapter.ClearBeforeFill = true;
            // 
            // FRM2KB
            // 
            this.ClientSize = new System.Drawing.Size(636, 452);
            this.Controls.Add(this.tabControl1);
            this.Name = "FRM2KB";
            this.Load += new System.EventHandler(this.FRM2KB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cARDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JBControls.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnTran;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private JBControls.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnOverWrite;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button btnGetData;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource cARDBindingSource;
        private JBHR.Att.dsAttTableAdapters.CARDTableAdapter cARDTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oNTIMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cARDNODataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnInsert;
    }
}
