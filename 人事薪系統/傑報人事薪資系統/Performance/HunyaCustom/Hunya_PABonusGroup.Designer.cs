
namespace JBHR.Performance.HunyaCustom
{
    partial class Hunya_PABonusGroup
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
            this.JQPABonusGroup = new JBControls.JBQuery();
            this.btnImport = new System.Windows.Forms.Button();
            this.hunya_PAGroupCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hunya_Performance = new JBHR.Performance.HunyaCustom.Hunya_Performance();
            this.hunya_PAGroupCodeTableAdapter = new JBHR.Performance.HunyaCustom.Hunya_PerformanceTableAdapters.Hunya_PAGroupCodeTableAdapter();
            this.V_BASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v_BASETableAdapter = new JBHR.Performance.HunyaCustom.Hunya_PerformanceTableAdapters.V_BASETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_PAGroupCodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_Performance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_BASEBindingSource)).BeginInit();
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
            this.dgv.TabIndex = 5;
            // 
            // JQPABonusGroup
            // 
            this.JQPABonusGroup.bnAddEnable = true;
            this.JQPABonusGroup.bnDelEnable = true;
            this.JQPABonusGroup.bnEditEnable = true;
            this.JQPABonusGroup.bnExportEnable = true;
            this.JQPABonusGroup.DataGrid = this.dgv;
            this.JQPABonusGroup.Location = new System.Drawing.Point(13, 12);
            this.JQPABonusGroup.Name = "JQPABonusGroup";
            this.JQPABonusGroup.QuerySettingString = "View_Hunya_PABonusGroup";
            this.JQPABonusGroup.RadDataGrid = null;
            this.JQPABonusGroup.Size = new System.Drawing.Size(642, 77);
            this.JQPABonusGroup.SortString = "";
            this.JQPABonusGroup.SourceTable = null;
            this.JQPABonusGroup.TabIndex = 4;
            this.JQPABonusGroup.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.JQPABonusGroup_RowDelete);
            this.JQPABonusGroup.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.JQPABonusData_RowInsert);
            this.JQPABonusGroup.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.JQPABonusGroup_RowUpdate);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(697, 62);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 13;
            this.btnImport.Text = "開始匯入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // hunya_PAGroupCodeBindingSource
            // 
            this.hunya_PAGroupCodeBindingSource.DataMember = "Hunya_PAGroupCode";
            this.hunya_PAGroupCodeBindingSource.DataSource = this.hunya_Performance;
            // 
            // hunya_Performance
            // 
            this.hunya_Performance.DataSetName = "Hunya_Performance";
            this.hunya_Performance.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hunya_PAGroupCodeTableAdapter
            // 
            this.hunya_PAGroupCodeTableAdapter.ClearBeforeFill = true;
            // 
            // V_BASEBindingSource
            // 
            this.V_BASEBindingSource.DataMember = "V_BASE";
            this.V_BASEBindingSource.DataSource = this.hunya_Performance;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // Hunya_PABonusGroup
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.JQPABonusGroup);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "Hunya_PABonusGroup";
            this.Text = "Hunya_PABonusGroup";
            this.Load += new System.EventHandler(this.Hunya_PABonusGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_PAGroupCodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_Performance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_BASEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private JBControls.JBQuery JQPABonusGroup;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.BindingSource hunya_PAGroupCodeBindingSource;
        private Hunya_Performance hunya_Performance;
        private Hunya_PerformanceTableAdapters.Hunya_PAGroupCodeTableAdapter hunya_PAGroupCodeTableAdapter;
        private System.Windows.Forms.BindingSource V_BASEBindingSource;
        private Hunya_PerformanceTableAdapters.V_BASETableAdapter v_BASETableAdapter;
    }
}
