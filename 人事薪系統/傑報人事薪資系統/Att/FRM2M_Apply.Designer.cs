namespace JBHR.Att
{
    partial class FRM2M_Apply
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
            this.JQMealApply = new JBControls.JBQuery();
            this.dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // JQMealApply
            // 
            this.JQMealApply.bnAddEnable = true;
            this.JQMealApply.bnDelEnable = true;
            this.JQMealApply.bnEditEnable = true;
            this.JQMealApply.bnExportEnable = true;
            this.JQMealApply.DataGrid = this.dgv;
            this.JQMealApply.Location = new System.Drawing.Point(13, 13);
            this.JQMealApply.Name = "JQMealApply";
            this.JQMealApply.QuerySettingString = "View_MealApplyRecord";
            this.JQMealApply.RadDataGrid = null;
            this.JQMealApply.Size = new System.Drawing.Size(642, 77);
            this.JQMealApply.SortString = "";
            this.JQMealApply.SourceTable = null;
            this.JQMealApply.TabIndex = 0;
            this.JQMealApply.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.JQMealApply_RowDelete);
            this.JQMealApply.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.JQMealApply_RowInsert);
            this.JQMealApply.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.JQMealApply_RowUpdate);
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(13, 96);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(759, 453);
            this.dgv.TabIndex = 1;
            // 
            // FRM2M_Apply
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.JQMealApply);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM2M_Apply";
            this.Text = "FRM2M_Apply";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JBControls.JBQuery JQMealApply;
        private System.Windows.Forms.DataGridView dgv;
    }
}
