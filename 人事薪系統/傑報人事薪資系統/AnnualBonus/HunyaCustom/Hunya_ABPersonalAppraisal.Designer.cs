namespace JBHR.AnnualBonus.HunyaCustom
{
    partial class Hunya_ABPersonalAppraisal
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
            this.JQABPersonalAppraisal = new JBControls.JBQuery();
            this.v_BASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hunya_AnnualBonus = new JBHR.AnnualBonus.HunyaCustom.Hunya_AnnualBonus();
            this.v_BASETableAdapter = new JBHR.AnnualBonus.HunyaCustom.Hunya_AnnualBonusTableAdapters.V_BASETableAdapter();
            this.hunya_ABLevelCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hunya_ABLevelCodeTableAdapter = new JBHR.AnnualBonus.HunyaCustom.Hunya_AnnualBonusTableAdapters.Hunya_ABLevelCodeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_BASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_AnnualBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_ABLevelCodeBindingSource)).BeginInit();
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
            // JQABPersonalAppraisal
            // 
            this.JQABPersonalAppraisal.bnAddEnable = true;
            this.JQABPersonalAppraisal.bnDelEnable = true;
            this.JQABPersonalAppraisal.bnEditEnable = true;
            this.JQABPersonalAppraisal.bnExportEnable = true;
            this.JQABPersonalAppraisal.DataGrid = this.dgv;
            this.JQABPersonalAppraisal.Location = new System.Drawing.Point(13, 12);
            this.JQABPersonalAppraisal.Name = "JQABPersonalAppraisal";
            this.JQABPersonalAppraisal.QuerySettingString = "View_Hunya_ABPersonalAppraisal";
            this.JQABPersonalAppraisal.RadDataGrid = null;
            this.JQABPersonalAppraisal.Size = new System.Drawing.Size(642, 77);
            this.JQABPersonalAppraisal.SortString = "";
            this.JQABPersonalAppraisal.SourceTable = null;
            this.JQABPersonalAppraisal.TabIndex = 16;
            this.JQABPersonalAppraisal.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.JQABPersonalAppraisal_RowDelete);
            this.JQABPersonalAppraisal.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.JQABPersonalAppraisal_RowInsert);
            this.JQABPersonalAppraisal.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.JQABPersonalAppraisal_RowUpdate);
            // 
            // v_BASEBindingSource
            // 
            this.v_BASEBindingSource.DataMember = "V_BASE";
            this.v_BASEBindingSource.DataSource = this.hunya_AnnualBonus;
            // 
            // hunya_AnnualBonus
            // 
            this.hunya_AnnualBonus.DataSetName = "Hunya_AnnualBonus";
            this.hunya_AnnualBonus.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // hunya_ABLevelCodeBindingSource
            // 
            this.hunya_ABLevelCodeBindingSource.DataMember = "Hunya_ABLevelCode";
            this.hunya_ABLevelCodeBindingSource.DataSource = this.hunya_AnnualBonus;
            // 
            // hunya_ABLevelCodeTableAdapter
            // 
            this.hunya_ABLevelCodeTableAdapter.ClearBeforeFill = true;
            // 
            // Hunya_ABPersonalAppraisal
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.JQABPersonalAppraisal);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "Hunya_ABPersonalAppraisal";
            this.Text = "Hunya_ABPersonalAppraisal";
            this.Load += new System.EventHandler(this.Hunya_ABPersonalAppraisal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_BASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_AnnualBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_ABLevelCodeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridView dgv;
        private JBControls.JBQuery JQABPersonalAppraisal;
        private System.Windows.Forms.BindingSource v_BASEBindingSource;
        private Hunya_AnnualBonus hunya_AnnualBonus;
        private Hunya_AnnualBonusTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private System.Windows.Forms.BindingSource hunya_ABLevelCodeBindingSource;
        private Hunya_AnnualBonusTableAdapters.Hunya_ABLevelCodeTableAdapter hunya_ABLevelCodeTableAdapter;
    }
}
