
namespace JBHR.Performance.HunyaCustom
{
    partial class Hunya_PADeptBonus
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
            this.components = new System.ComponentModel.Container();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.JQPADeptBonus = new JBControls.JBQuery();
            this.btnImport = new System.Windows.Forms.Button();
            this.Hunya_PADeptBonusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hunya_Performance = new JBHR.Performance.HunyaCustom.Hunya_Performance();
            this.dEPTTableAdapter = new JBHR.Performance.HunyaCustom.Hunya_PerformanceTableAdapters.DEPTTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hunya_PADeptBonusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_Performance)).BeginInit();
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
            this.dgv.TabIndex = 7;
            // 
            // JQPADeptBonus
            // 
            this.JQPADeptBonus.bnAddEnable = true;
            this.JQPADeptBonus.bnDelEnable = true;
            this.JQPADeptBonus.bnEditEnable = true;
            this.JQPADeptBonus.bnExportEnable = true;
            this.JQPADeptBonus.DataGrid = this.dgv;
            this.JQPADeptBonus.Location = new System.Drawing.Point(13, 12);
            this.JQPADeptBonus.Name = "JQPADeptBonus";
            this.JQPADeptBonus.QuerySettingString = "View_Hunya_PADeptBonus";
            this.JQPADeptBonus.RadDataGrid = null;
            this.JQPADeptBonus.Size = new System.Drawing.Size(642, 77);
            this.JQPADeptBonus.SortString = "";
            this.JQPADeptBonus.SourceTable = null;
            this.JQPADeptBonus.TabIndex = 6;
            this.JQPADeptBonus.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.JQPADeptBonus_RowDelete);
            this.JQPADeptBonus.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.JQPADeptBonus_RowInsert);
            this.JQPADeptBonus.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.JQPADeptBonus_RowUpdate);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(697, 62);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 14;
            this.btnImport.Text = "開始匯入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // Hunya_PADeptBonusBindingSource
            // 
            this.Hunya_PADeptBonusBindingSource.DataMember = "DEPT";
            this.Hunya_PADeptBonusBindingSource.DataSource = this.hunya_Performance;
            // 
            // hunya_Performance
            // 
            this.hunya_Performance.DataSetName = "Hunya_Performance";
            this.hunya_Performance.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dEPTTableAdapter
            // 
            this.dEPTTableAdapter.ClearBeforeFill = true;
            // 
            // Hunya_PADeptBonus
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.JQPADeptBonus);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "Hunya_PADeptBonus";
            this.Text = "Hunya_PADeptBonus";
            this.Load += new System.EventHandler(this.Hunya_PADeptBonus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hunya_PADeptBonusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_Performance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private JBControls.JBQuery JQPADeptBonus;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.BindingSource Hunya_PADeptBonusBindingSource;
        private Hunya_Performance hunya_Performance;
        private Hunya_PerformanceTableAdapters.DEPTTableAdapter dEPTTableAdapter;
    }
}
