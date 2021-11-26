namespace JBHR.Att
{
    partial class FRM2M_CardType
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
            this.JQCardType = new JBControls.JBQuery();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnTrans = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // JQCardType
            // 
            this.JQCardType.bnAddEnable = true;
            this.JQCardType.bnDelEnable = true;
            this.JQCardType.bnEditEnable = true;
            this.JQCardType.bnExportEnable = true;
            this.JQCardType.DataGrid = this.dgv;
            this.JQCardType.Location = new System.Drawing.Point(13, 13);
            this.JQCardType.Name = "JQCardType";
            this.JQCardType.QuerySettingString = "View_MealCardType";
            this.JQCardType.RadDataGrid = null;
            this.JQCardType.Size = new System.Drawing.Size(642, 77);
            this.JQCardType.SortString = "";
            this.JQCardType.SourceTable = null;
            this.JQCardType.TabIndex = 0;
            this.JQCardType.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.JQCardType_RowDelete);
            this.JQCardType.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.JQCardType_RowInsert);
            this.JQCardType.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.JQCardType_RowUpdate);
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 96);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(760, 453);
            this.dgv.TabIndex = 1;
            // 
            // btnTrans
            // 
            this.btnTrans.Location = new System.Drawing.Point(697, 17);
            this.btnTrans.Name = "btnTrans";
            this.btnTrans.Size = new System.Drawing.Size(75, 23);
            this.btnTrans.TabIndex = 2;
            this.btnTrans.Text = "刷卡轉餐別";
            this.btnTrans.UseVisualStyleBackColor = true;
            this.btnTrans.Visible = false;
            this.btnTrans.Click += new System.EventHandler(this.btnTrans_Click);
            // 
            // FRM2M_CardType
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnTrans);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.JQCardType);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM2M_CardType";
            this.Text = "FRM2M_CardType";
            this.Load += new System.EventHandler(this.FRM2M_CardType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JBControls.JBQuery JQCardType;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnTrans;
    }
}
