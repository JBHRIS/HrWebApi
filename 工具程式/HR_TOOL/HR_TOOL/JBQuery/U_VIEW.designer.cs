namespace HR_TOOL.JBQuery
{
    partial class U_VIEW
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.jbQuery1 = new JBControls.JBQuery();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonColimn = new System.Windows.Forms.Button();
            this.buttonRelation = new System.Windows.Forms.Button();
            this.buttonTable = new System.Windows.Forms.Button();
            this.buttonFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // jbQuery1
            // 
            this.jbQuery1.DataGrid = this.dataGridView1;
            this.jbQuery1.Location = new System.Drawing.Point(12, 12);
            this.jbQuery1.Name = "jbQuery1";
            this.jbQuery1.QuerySettingString = "QuerySetting";
            this.jbQuery1.Size = new System.Drawing.Size(642, 77);
            this.jbQuery1.SourceTable = null;
            this.jbQuery1.TabIndex = 0;
            this.jbQuery1.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.jbQuery1_RowDelete);
            this.jbQuery1.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.jbQuery1_RowInsert);
            this.jbQuery1.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.jbQuery1_RowUpdate);
            this.jbQuery1.DataQuerying += new JBControls.JBQuery.DataQueryingEventHandler(this.jbQuery1_DataQuerying);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(840, 514);
            this.dataGridView1.TabIndex = 1;
            // 
            // buttonColimn
            // 
            this.buttonColimn.Location = new System.Drawing.Point(735, 16);
            this.buttonColimn.Name = "buttonColimn";
            this.buttonColimn.Size = new System.Drawing.Size(75, 23);
            this.buttonColimn.TabIndex = 2;
            this.buttonColimn.Text = "欄位設定";
            this.buttonColimn.UseVisualStyleBackColor = true;
            this.buttonColimn.Click += new System.EventHandler(this.buttonColimn_Click);
            // 
            // buttonRelation
            // 
            this.buttonRelation.Location = new System.Drawing.Point(648, 58);
            this.buttonRelation.Name = "buttonRelation";
            this.buttonRelation.Size = new System.Drawing.Size(75, 23);
            this.buttonRelation.TabIndex = 2;
            this.buttonRelation.Text = "關聯設定";
            this.buttonRelation.UseVisualStyleBackColor = true;
            this.buttonRelation.Click += new System.EventHandler(this.buttonRelation_Click);
            // 
            // buttonTable
            // 
            this.buttonTable.Location = new System.Drawing.Point(648, 16);
            this.buttonTable.Name = "buttonTable";
            this.buttonTable.Size = new System.Drawing.Size(75, 23);
            this.buttonTable.TabIndex = 2;
            this.buttonTable.Text = "資料表設定";
            this.buttonTable.UseVisualStyleBackColor = true;
            this.buttonTable.Click += new System.EventHandler(this.buttonTable_Click);
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(735, 58);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter.TabIndex = 2;
            this.buttonFilter.Text = "篩選條件";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // U_VIEW
            // 
            this.ClientSize = new System.Drawing.Size(877, 629);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.buttonRelation);
            this.Controls.Add(this.buttonTable);
            this.Controls.Add(this.buttonColimn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.jbQuery1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "U_VIEW";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JBControls.JBQuery jbQuery1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonColimn;
        private System.Windows.Forms.Button buttonRelation;
        private System.Windows.Forms.Button buttonTable;
        private System.Windows.Forms.Button buttonFilter;
    }
}
