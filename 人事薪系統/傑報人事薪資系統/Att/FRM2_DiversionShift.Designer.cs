
namespace JBHR.Att
{
    partial class FRM2_DiversionShift
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.JQDiversionShift = new JBControls.JBQuery();
            this.btnImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(13, 95);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(759, 453);
            this.dgv.TabIndex = 5;
            // 
            // JQDiversionShift
            // 
            this.JQDiversionShift.bnAddEnable = true;
            this.JQDiversionShift.bnDelEnable = true;
            this.JQDiversionShift.bnEditEnable = true;
            this.JQDiversionShift.bnExportEnable = true;
            this.JQDiversionShift.DataGrid = this.dgv;
            this.JQDiversionShift.Location = new System.Drawing.Point(13, 12);
            this.JQDiversionShift.Name = "JQDiversionShift";
            this.JQDiversionShift.QuerySettingString = "FRM2_DiversionShift";
            this.JQDiversionShift.RadDataGrid = null;
            this.JQDiversionShift.Size = new System.Drawing.Size(642, 77);
            this.JQDiversionShift.SortString = "";
            this.JQDiversionShift.SourceTable = null;
            this.JQDiversionShift.TabIndex = 4;
            this.JQDiversionShift.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.JQDiversionShift_RowDelete);
            this.JQDiversionShift.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.JQDiversionShift_RowInsert);
            this.JQDiversionShift.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.JQDiversionShift_RowUpdate);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(697, 62);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 12;
            this.btnImport.Text = "開始匯入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // FRM2_DiversionShift
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.JQDiversionShift);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM2_DiversionShift";
            this.Text = "FRM2_DiversionShift";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private JBControls.JBQuery JQDiversionShift;
        private System.Windows.Forms.Button btnImport;
    }
}
