
namespace JBHR.HopaxCustom
{
    partial class HPX_Plate_Mgt
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
            this.jbHPX_Plate_Mgt = new JBControls.JBQuery();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnConfig = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // jbHPX_Plate_Mgt
            // 
            this.jbHPX_Plate_Mgt.bnAddEnable = true;
            this.jbHPX_Plate_Mgt.bnDelEnable = true;
            this.jbHPX_Plate_Mgt.bnEditEnable = true;
            this.jbHPX_Plate_Mgt.bnExportEnable = true;
            this.jbHPX_Plate_Mgt.DataGrid = this.dgv;
            this.jbHPX_Plate_Mgt.Location = new System.Drawing.Point(12, 12);
            this.jbHPX_Plate_Mgt.Name = "jbHPX_Plate_Mgt";
            this.jbHPX_Plate_Mgt.QuerySettingString = "View_HPX_Plate_MGT";
            this.jbHPX_Plate_Mgt.RadDataGrid = null;
            this.jbHPX_Plate_Mgt.Size = new System.Drawing.Size(642, 77);
            this.jbHPX_Plate_Mgt.SortString = "員工編號,車種,車牌號碼";
            this.jbHPX_Plate_Mgt.SourceTable = null;
            this.jbHPX_Plate_Mgt.TabIndex = 1;
            this.jbHPX_Plate_Mgt.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.jbHPX_Plate_Mgt_RowDelete);
            this.jbHPX_Plate_Mgt.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.jbHPX_Plate_Mgt_RowInsert);
            this.jbHPX_Plate_Mgt.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.jbHPX_Plate_Mgt_RowUpdate);
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
            this.dgv.TabIndex = 2;
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnConfig.BackgroundImage = global::JBHR.Properties.Resources.Settings_icon;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(747, 66);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(25, 23);
            this.btnConfig.TabIndex = 1021;
            this.btnConfig.Tag = "HPX_Plate_Mgt";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // HPX_Plate_Mgt
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.jbHPX_Plate_Mgt);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "HPX_Plate_Mgt";
            this.Text = "HPX_Plate_Mgt-管理車牌資料";
            this.Load += new System.EventHandler(this.HPX_Plate_Mgt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JBControls.JBQuery jbHPX_Plate_Mgt;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnConfig;
    }
}
