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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.jqWelf = new JBControls.JBQuery();
            this.btnConfig = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
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
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
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
            this.dgv.TabIndex = 11;
            // 
            // jqWelf
            // 
            this.jqWelf.bnAddEnable = true;
            this.jqWelf.bnDelEnable = true;
            this.jqWelf.bnEditEnable = true;
            this.jqWelf.bnExportEnable = true;
            this.jqWelf.DataGrid = this.dgv;
            this.jqWelf.Location = new System.Drawing.Point(12, 12);
            this.jqWelf.Name = "jqWelf";
            this.jqWelf.QuerySettingString = "FRM62N";
            this.jqWelf.RadDataGrid = null;
            this.jqWelf.Size = new System.Drawing.Size(642, 77);
            this.jqWelf.SortString = "";
            this.jqWelf.SourceTable = null;
            this.jqWelf.TabIndex = 10;
            this.jqWelf.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.jqWelf_RowDelete);
            this.jqWelf.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.jqWelf_RowInsert);
            this.jqWelf.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.jqWelf_RowUpdate);
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.BackgroundImage = global::JBHR.Properties.Resources.Settings_icon;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(747, 66);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(25, 23);
            this.btnConfig.TabIndex = 1021;
            this.btnConfig.Tag = "FRM62N";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // FRM62N
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.jqWelf);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM62N";
            this.Text = "FRM62N";
            this.Load += new System.EventHandler(this.FRM62N_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridView dgv;
        private JBControls.JBQuery jqWelf;
        private System.Windows.Forms.Button btnConfig;
    }
}
