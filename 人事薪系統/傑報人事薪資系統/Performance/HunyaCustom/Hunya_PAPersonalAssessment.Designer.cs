
namespace JBHR.Performance.HunyaCustom
{
    partial class Hunya_PAPersonalAssessment
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
            this.JQPAPersonalAssessment = new JBControls.JBQuery();
            this.btnImport = new System.Windows.Forms.Button();
            this.v_BASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hunya_Performance = new JBHR.Performance.HunyaCustom.Hunya_Performance();
            this.v_BASETableAdapter = new JBHR.Performance.HunyaCustom.Hunya_PerformanceTableAdapters.V_BASETableAdapter();
            this.hunya_PALevelCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hunya_PALevelCodeTableAdapter = new JBHR.Performance.HunyaCustom.Hunya_PerformanceTableAdapters.Hunya_PALevelCodeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_BASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_Performance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_PALevelCodeBindingSource)).BeginInit();
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
            // JQPAPersonalAssessment
            // 
            this.JQPAPersonalAssessment.bnAddEnable = true;
            this.JQPAPersonalAssessment.bnDelEnable = true;
            this.JQPAPersonalAssessment.bnEditEnable = true;
            this.JQPAPersonalAssessment.bnExportEnable = true;
            this.JQPAPersonalAssessment.DataGrid = this.dgv;
            this.JQPAPersonalAssessment.Location = new System.Drawing.Point(13, 12);
            this.JQPAPersonalAssessment.Name = "JQPAPersonalAssessment";
            this.JQPAPersonalAssessment.QuerySettingString = "View_Hunya_PAPersonalAssessment";
            this.JQPAPersonalAssessment.RadDataGrid = null;
            this.JQPAPersonalAssessment.Size = new System.Drawing.Size(642, 77);
            this.JQPAPersonalAssessment.SortString = "";
            this.JQPAPersonalAssessment.SourceTable = null;
            this.JQPAPersonalAssessment.TabIndex = 6;
            this.JQPAPersonalAssessment.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.JQPAPersonalAssessment_RowDelete);
            this.JQPAPersonalAssessment.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.JQPAPersonalAssessment_RowInsert);
            this.JQPAPersonalAssessment.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.JQPAPersonalAssessment_RowUpdate);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(697, 62);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 15;
            this.btnImport.Text = "開始匯入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // v_BASEBindingSource
            // 
            this.v_BASEBindingSource.DataMember = "V_BASE";
            this.v_BASEBindingSource.DataSource = this.hunya_Performance;
            // 
            // hunya_Performance
            // 
            this.hunya_Performance.DataSetName = "Hunya_Performance";
            this.hunya_Performance.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // hunya_PALevelCodeBindingSource
            // 
            this.hunya_PALevelCodeBindingSource.DataMember = "Hunya_PALevelCode";
            this.hunya_PALevelCodeBindingSource.DataSource = this.hunya_Performance;
            // 
            // hunya_PALevelCodeTableAdapter
            // 
            this.hunya_PALevelCodeTableAdapter.ClearBeforeFill = true;
            // 
            // Hunya_PAPersonalAssessment
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.JQPAPersonalAssessment);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "Hunya_PAPersonalAssessment";
            this.Text = "Hunya_PAPersonalAssessment";
            this.Load += new System.EventHandler(this.Hunya_PAPersonalAssessment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_BASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_Performance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_PALevelCodeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private JBControls.JBQuery JQPAPersonalAssessment;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.BindingSource v_BASEBindingSource;
        private Hunya_Performance hunya_Performance;
        private Hunya_PerformanceTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private System.Windows.Forms.BindingSource hunya_PALevelCodeBindingSource;
        private Hunya_PerformanceTableAdapters.Hunya_PALevelCodeTableAdapter hunya_PALevelCodeTableAdapter;
    }
}
