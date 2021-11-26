
namespace JBHR.Dividend.HunyaCustom
{
    partial class Hunya_DIVDPersonalAppraisal
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
            this.btnImport = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.JQDIVDPersonalAppraisal = new JBControls.JBQuery();
            this.hunya_DIVDAppraisalCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hunya_Dividend = new JBHR.Dividend.HunyaCustom.Hunya_Dividend();
            this.hunya_DIVDAppraisalCodeTableAdapter = new JBHR.Dividend.HunyaCustom.Hunya_DividendTableAdapters.Hunya_DIVDAppraisalCodeTableAdapter();
            this.V_BaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v_BASETableAdapter = new JBHR.Dividend.HunyaCustom.Hunya_DividendTableAdapters.V_BASETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_DIVDAppraisalCodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_Dividend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_BaseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(697, 62);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 18;
            this.btnImport.Text = "開始匯入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
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
            this.dgv.TabIndex = 17;
            // 
            // JQDIVDPersonalAppraisal
            // 
            this.JQDIVDPersonalAppraisal.bnAddEnable = true;
            this.JQDIVDPersonalAppraisal.bnDelEnable = true;
            this.JQDIVDPersonalAppraisal.bnEditEnable = true;
            this.JQDIVDPersonalAppraisal.bnExportEnable = true;
            this.JQDIVDPersonalAppraisal.DataGrid = this.dgv;
            this.JQDIVDPersonalAppraisal.Location = new System.Drawing.Point(13, 12);
            this.JQDIVDPersonalAppraisal.Name = "JQDIVDPersonalAppraisal";
            this.JQDIVDPersonalAppraisal.QuerySettingString = "View_Hunya_DIVDPersonalAppraisal";
            this.JQDIVDPersonalAppraisal.RadDataGrid = null;
            this.JQDIVDPersonalAppraisal.Size = new System.Drawing.Size(642, 77);
            this.JQDIVDPersonalAppraisal.SortString = "";
            this.JQDIVDPersonalAppraisal.SourceTable = null;
            this.JQDIVDPersonalAppraisal.TabIndex = 16;
            this.JQDIVDPersonalAppraisal.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.JQDIVDPersonalAppraisal_RowDelete);
            this.JQDIVDPersonalAppraisal.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.JQDIVDPersonalAppraisal_RowInsert);
            this.JQDIVDPersonalAppraisal.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.JQDIVDPersonalAppraisal_RowUpdate);
            // 
            // hunya_DIVDAppraisalCodeBindingSource
            // 
            this.hunya_DIVDAppraisalCodeBindingSource.DataMember = "Hunya_DIVDAppraisalCode";
            this.hunya_DIVDAppraisalCodeBindingSource.DataSource = this.hunya_Dividend;
            // 
            // hunya_Dividend
            // 
            this.hunya_Dividend.DataSetName = "Hunya_Dividend";
            this.hunya_Dividend.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hunya_DIVDAppraisalCodeTableAdapter
            // 
            this.hunya_DIVDAppraisalCodeTableAdapter.ClearBeforeFill = true;
            // 
            // V_BaseBindingSource
            // 
            this.V_BaseBindingSource.DataMember = "V_BASE";
            this.V_BaseBindingSource.DataSource = this.hunya_Dividend;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // Hunya_DIVDPersonalAppraisal
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.JQDIVDPersonalAppraisal);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "Hunya_DIVDPersonalAppraisal";
            this.Text = "Hunya_DIVDPersonalAppraisal";
            this.Load += new System.EventHandler(this.Hunya_DIVDPersonalAppraisal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_DIVDAppraisalCodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_Dividend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_BaseBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridView dgv;
        private JBControls.JBQuery JQDIVDPersonalAppraisal;
        private System.Windows.Forms.BindingSource hunya_DIVDAppraisalCodeBindingSource;
        private Hunya_Dividend hunya_Dividend;
        private Hunya_DividendTableAdapters.Hunya_DIVDAppraisalCodeTableAdapter hunya_DIVDAppraisalCodeTableAdapter;
        private System.Windows.Forms.BindingSource V_BaseBindingSource;
        private Hunya_DividendTableAdapters.V_BASETableAdapter v_BASETableAdapter;
    }
}
