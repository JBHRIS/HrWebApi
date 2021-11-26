
namespace JBHR.Att
{
    partial class FRM27A
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
            this.jbAttend = new JBControls.JBQuery();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 95);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(760, 454);
            this.dgv.TabIndex = 1025;
            // 
            // jbAttend
            // 
            this.jbAttend.bnAddEnable = true;
            this.jbAttend.bnDelEnable = true;
            this.jbAttend.bnEditEnable = true;
            this.jbAttend.bnExportEnable = true;
            this.jbAttend.DataGrid = this.dgv;
            this.jbAttend.Location = new System.Drawing.Point(12, 12);
            this.jbAttend.Name = "jbAttend";
            this.jbAttend.QuerySettingString = "View_FRM27A";
            this.jbAttend.RadDataGrid = null;
            this.jbAttend.Size = new System.Drawing.Size(642, 77);
            this.jbAttend.SortString = "";
            this.jbAttend.SourceTable = null;
            this.jbAttend.TabIndex = 1024;
            this.jbAttend.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.jbAttend_RowUpdate);
            // 
            // FRM27A
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.jbAttend);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM27A";
            this.Load += new System.EventHandler(this.FRM27A_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private JBControls.JBQuery jbAttend;
    }
}
