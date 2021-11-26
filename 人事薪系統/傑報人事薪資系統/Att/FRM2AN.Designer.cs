namespace JBHR.Att
{
    partial class FRM2AN
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
            this.jbQuery1 = new JBControls.JBQuery();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bnImport = new System.Windows.Forms.Button();
            this.bnCreateExcel = new System.Windows.Forms.Button();
            this.basDS = new JBHR.Bas.BasDS();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            this.SuspendLayout();
            // 
            // jbQuery1
            // 
            this.jbQuery1.DataGrid = this.dataGridView1;
            this.jbQuery1.Location = new System.Drawing.Point(12, 12);
            this.jbQuery1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.jbQuery1.Name = "jbQuery1";
            this.jbQuery1.QuerySettingString = "FRM2AN";
            this.jbQuery1.RadDataGrid = null;
            this.jbQuery1.Size = new System.Drawing.Size(642, 77);
            this.jbQuery1.SourceTable = null;
            this.jbQuery1.TabIndex = 0;
            this.jbQuery1.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.JbQuery1_RowDelete);
            this.jbQuery1.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.JbQuery1_RowInsert);
            this.jbQuery1.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.JbQuery1_RowUpdate);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(832, 526);
            this.dataGridView1.TabIndex = 1;
            // 
            // bnImport
            // 
            this.bnImport.Location = new System.Drawing.Point(737, 18);
            this.bnImport.Name = "bnImport";
            this.bnImport.Size = new System.Drawing.Size(85, 20);
            this.bnImport.TabIndex = 2;
            this.bnImport.Text = "開始匯入";
            this.bnImport.UseVisualStyleBackColor = true;
            this.bnImport.Click += new System.EventHandler(this.BnImport_Click);
            // 
            // bnCreateExcel
            // 
            this.bnCreateExcel.Location = new System.Drawing.Point(647, 18);
            this.bnCreateExcel.Name = "bnCreateExcel";
            this.bnCreateExcel.Size = new System.Drawing.Size(85, 20);
            this.bnCreateExcel.TabIndex = 3;
            this.bnCreateExcel.Text = "匯出樣板";
            this.bnCreateExcel.UseVisualStyleBackColor = true;
            this.bnCreateExcel.Visible = false;
            this.bnCreateExcel.Click += new System.EventHandler(this.BnCreateExcel_Click);
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FRM2AN
            // 
            this.ClientSize = new System.Drawing.Size(857, 633);
            this.Controls.Add(this.bnCreateExcel);
            this.Controls.Add(this.bnImport);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.jbQuery1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM2AN";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JBControls.JBQuery jbQuery1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bnImport;
        private System.Windows.Forms.Button bnCreateExcel;
        private Bas.BasDS basDS;
    }
}
