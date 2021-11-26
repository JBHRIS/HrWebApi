namespace JBHR.Med
{
    partial class FRM71N
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colApply = new System.Windows.Forms.DataGridViewButtonColumn();
            this.jbQuery1 = new JBControls.JBQuery();
            this.buttonData = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colApply});
            this.dataGridView1.Location = new System.Drawing.Point(12, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(984, 535);
            this.dataGridView1.TabIndex = 3;
            // 
            // colApply
            // 
            this.colApply.HeaderText = "";
            this.colApply.Name = "colApply";
            this.colApply.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colApply.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // jbQuery1
            // 
            this.jbQuery1.bnAddEnable = true;
            this.jbQuery1.bnDelEnable = true;
            this.jbQuery1.bnEditEnable = true;
            this.jbQuery1.bnExportEnable = true;
            this.jbQuery1.DataGrid = this.dataGridView1;
            this.jbQuery1.Location = new System.Drawing.Point(12, 11);
            this.jbQuery1.Margin = new System.Windows.Forms.Padding(4);
            this.jbQuery1.Name = "jbQuery1";
            this.jbQuery1.QuerySettingString = "TW_TAX";
            this.jbQuery1.RadDataGrid = null;
            this.jbQuery1.Size = new System.Drawing.Size(642, 77);
            this.jbQuery1.SortString = "";
            this.jbQuery1.SourceTable = null;
            this.jbQuery1.TabIndex = 2;
            this.jbQuery1.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.jbQuery1_RowDelete);
            this.jbQuery1.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.jbQuery1_RowInsert);
            this.jbQuery1.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.jbQuery1_RowUpdate);
            // 
            // buttonData
            // 
            this.buttonData.Location = new System.Drawing.Point(882, 14);
            this.buttonData.Name = "buttonData";
            this.buttonData.Size = new System.Drawing.Size(112, 23);
            this.buttonData.TabIndex = 4;
            this.buttonData.Text = "申報資料維護";
            this.buttonData.UseVisualStyleBackColor = true;
            this.buttonData.Click += new System.EventHandler(this.buttonData_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(882, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "申報資料結轉";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(882, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "產生媒體檔";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(782, 65);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(85, 23);
            this.buttonReport.TabIndex = 7;
            this.buttonReport.Text = "產生報表";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // FRM71N
            // 
            this.ClientSize = new System.Drawing.Size(1008, 641);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonData);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.jbQuery1);
            this.FormSize = JBControls.JBForm.FormSizeType.Large;
            this.Name = "FRM71N";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private JBControls.JBQuery jbQuery1;
        private System.Windows.Forms.DataGridViewButtonColumn colApply;
        private System.Windows.Forms.Button buttonData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonReport;
    }
}
