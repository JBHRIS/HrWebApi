
namespace JBHR.HopaxCustom
{
    partial class HPX_Point_Mgt
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
            this.btnConfig = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.jbHPX_Point_Mgt = new JBControls.JBQuery();
            this.btnImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnConfig.BackgroundImage = global::JBHR.Properties.Resources.Settings_icon;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(747, 66);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(25, 23);
            this.btnConfig.TabIndex = 1024;
            this.btnConfig.Tag = "HPX_Point_Mgt";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 95);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(760, 454);
            this.dgv.TabIndex = 1023;
            // 
            // jbHPX_Point_Mgt
            // 
            this.jbHPX_Point_Mgt.bnAddEnable = true;
            this.jbHPX_Point_Mgt.bnDelEnable = true;
            this.jbHPX_Point_Mgt.bnEditEnable = true;
            this.jbHPX_Point_Mgt.bnExportEnable = true;
            this.jbHPX_Point_Mgt.DataGrid = this.dgv;
            this.jbHPX_Point_Mgt.Location = new System.Drawing.Point(12, 12);
            this.jbHPX_Point_Mgt.Name = "jbHPX_Point_Mgt";
            this.jbHPX_Point_Mgt.QuerySettingString = "View_HPX_Point_MGT";
            this.jbHPX_Point_Mgt.RadDataGrid = null;
            this.jbHPX_Point_Mgt.Size = new System.Drawing.Size(642, 77);
            this.jbHPX_Point_Mgt.SortString = "";
            this.jbHPX_Point_Mgt.SourceTable = null;
            this.jbHPX_Point_Mgt.TabIndex = 1022;
            this.jbHPX_Point_Mgt.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.jbHPX_Point_Mgt_RowDelete);
            this.jbHPX_Point_Mgt.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.jbHPX_Point_Mgt_RowInsert);
            this.jbHPX_Point_Mgt.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.jbHPX_Point_Mgt_RowUpdate);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(697, 18);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 20);
            this.btnImport.TabIndex = 1025;
            this.btnImport.Text = "匯入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // HPX_Point_Mgt
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.jbHPX_Point_Mgt);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "HPX_Point_Mgt";
            this.Text = "HPX_Point_Mgt-管理公益點數資料";
            this.Load += new System.EventHandler(this.HPX_Point_Mgt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.DataGridView dgv;
        private JBControls.JBQuery jbHPX_Point_Mgt;
        private System.Windows.Forms.Button btnImport;
    }
}
