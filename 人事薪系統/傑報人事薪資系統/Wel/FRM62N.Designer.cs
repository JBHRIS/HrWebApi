namespace JBHR.Wel
{
    partial class FRM62N
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
            this.btnImport = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.jbQuery1 = new JBControls.JBQuery();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(650, 15);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(85, 23);
            this.btnImport.TabIndex = 12;
            this.btnImport.Text = "匯入";
            this.btnImport.UseVisualStyleBackColor = true;
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
            this.dataGridView1.Size = new System.Drawing.Size(760, 454);
            this.dataGridView1.TabIndex = 11;
            // 
            // jbQuery1
            // 
            this.jbQuery1.bnAddEnable = true;
            this.jbQuery1.bnDelEnable = true;
            this.jbQuery1.bnEditEnable = true;
            this.jbQuery1.bnExportEnable = true;
            this.jbQuery1.DataGrid = this.dataGridView1;
            this.jbQuery1.Location = new System.Drawing.Point(12, 12);
            this.jbQuery1.Name = "jbQuery1";
            this.jbQuery1.QuerySettingString = "FRM4LN";
            this.jbQuery1.RadDataGrid = null;
            this.jbQuery1.Size = new System.Drawing.Size(642, 77);
            this.jbQuery1.SortString = "";
            this.jbQuery1.SourceTable = null;
            this.jbQuery1.TabIndex = 10;
            // 
            // FRM62N
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.jbQuery1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM62N";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridView dataGridView1;
        private JBControls.JBQuery jbQuery1;
    }
}
