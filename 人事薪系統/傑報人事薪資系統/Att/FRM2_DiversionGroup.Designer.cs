
namespace JBHR.Att
{
    partial class FRM2_DiversionGroup
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
            this.JQDiversionGroup = new JBControls.JBQuery();
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
            this.dgv.TabIndex = 3;
            // 
            // JQDiversionGroup
            // 
            this.JQDiversionGroup.bnAddEnable = true;
            this.JQDiversionGroup.bnDelEnable = true;
            this.JQDiversionGroup.bnEditEnable = true;
            this.JQDiversionGroup.bnExportEnable = true;
            this.JQDiversionGroup.DataGrid = this.dgv;
            this.JQDiversionGroup.Location = new System.Drawing.Point(13, 12);
            this.JQDiversionGroup.Name = "JQDiversionGroup";
            this.JQDiversionGroup.QuerySettingString = "FRM2_DiversionGroup";
            this.JQDiversionGroup.RadDataGrid = null;
            this.JQDiversionGroup.Size = new System.Drawing.Size(642, 77);
            this.JQDiversionGroup.SortString = "";
            this.JQDiversionGroup.SourceTable = null;
            this.JQDiversionGroup.TabIndex = 2;
            this.JQDiversionGroup.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.JQDiversionGroup_RowDelete);
            this.JQDiversionGroup.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.JQDiversionGroup_RowInsert);
            this.JQDiversionGroup.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.JQDiversionGroup_RowUpdate);
            // 
            // FRM2_DiversionGroup
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.JQDiversionGroup);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM2_DiversionGroup";
            this.Text = "FRM2_DiversionGroup";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private JBControls.JBQuery JQDiversionGroup;
    }
}
