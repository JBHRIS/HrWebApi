namespace JBHR.Att
{
    partial class FRM2M_Deduction
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
            this.jbMealDeduction = new JBControls.JBQuery();
            this.dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // jbMealDeduction
            // 
            this.jbMealDeduction.bnAddEnable = true;
            this.jbMealDeduction.bnDelEnable = true;
            this.jbMealDeduction.bnEditEnable = true;
            this.jbMealDeduction.bnExportEnable = true;
            this.jbMealDeduction.DataGrid = this.dgv;
            this.jbMealDeduction.Location = new System.Drawing.Point(13, 13);
            this.jbMealDeduction.Name = "jbMealDeduction";
            this.jbMealDeduction.QuerySettingString = "View_MealDeduction";
            this.jbMealDeduction.RadDataGrid = null;
            this.jbMealDeduction.Size = new System.Drawing.Size(642, 77);
            this.jbMealDeduction.SortString = "員工編號,用餐日期,起始時間";
            this.jbMealDeduction.SourceTable = null;
            this.jbMealDeduction.TabIndex = 0;
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
            // FRM2M_Deduction
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.jbMealDeduction);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM2M_Deduction";
            this.Text = "FRM2M_Deduction";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JBControls.JBQuery jbMealDeduction;
        private System.Windows.Forms.DataGridView dgv;
    }
}
