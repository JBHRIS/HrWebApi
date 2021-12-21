namespace JBHR.AnnualBonus.HunyaCustom
{
    partial class Hunya_ABPersonalBonus
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
            this.btnCalculate = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.JQABPersonalBonus = new JBControls.JBQuery();
            this.v_BASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hunya_AnnualBonus = new JBHR.AnnualBonus.HunyaCustom.Hunya_AnnualBonus();
            this.v_BASETableAdapter = new JBHR.AnnualBonus.HunyaCustom.Hunya_AnnualBonusTableAdapters.V_BASETableAdapter();
            this.hunya_ABLevelCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hunya_ABLevelCodeTableAdapter = new JBHR.AnnualBonus.HunyaCustom.Hunya_AnnualBonusTableAdapters.Hunya_ABLevelCodeTableAdapter();
            this.btnConfig = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_BASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_AnnualBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_ABLevelCodeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(663, 12);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(109, 20);
            this.btnCalculate.TabIndex = 16;
            this.btnCalculate.Text = "計算年終獎金";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
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
            this.dgv.TabIndex = 15;
            // 
            // JQABPersonalBonus
            // 
            this.JQABPersonalBonus.bnAddEnable = true;
            this.JQABPersonalBonus.bnDelEnable = true;
            this.JQABPersonalBonus.bnEditEnable = true;
            this.JQABPersonalBonus.bnExportEnable = true;
            this.JQABPersonalBonus.DataGrid = this.dgv;
            this.JQABPersonalBonus.Location = new System.Drawing.Point(13, 12);
            this.JQABPersonalBonus.Name = "JQABPersonalBonus";
            this.JQABPersonalBonus.QuerySettingString = "View_Hunya_ABPersonalBonus";
            this.JQABPersonalBonus.RadDataGrid = null;
            this.JQABPersonalBonus.Size = new System.Drawing.Size(642, 77);
            this.JQABPersonalBonus.SortString = "";
            this.JQABPersonalBonus.SourceTable = null;
            this.JQABPersonalBonus.TabIndex = 14;
            this.JQABPersonalBonus.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.JQABPersonalBonus_RowDelete);
            this.JQABPersonalBonus.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.JQABPersonalBonus_RowInsert);
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
            // btnConfig
            // 
            this.btnConfig.BackgroundImage = global::JBHR.Properties.Resources.Settings_icon;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(747, 66);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(25, 23);
            this.btnConfig.TabIndex = 31;
            this.btnConfig.TabStop = false;
            this.btnConfig.Tag = "Hunya_ABPersonalBonus";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // Hunya_ABPersonalBonus
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.JQABPersonalBonus);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "Hunya_ABPersonalBonus";
            this.Text = "Hunya_ABPersonalBonus";
            this.Load += new System.EventHandler(this.Hunya_ABPersonalBonus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_BASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_AnnualBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_ABLevelCodeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.DataGridView dgv;
        private JBControls.JBQuery JQABPersonalBonus;
        private System.Windows.Forms.BindingSource v_BASEBindingSource;
        private Hunya_AnnualBonus hunya_AnnualBonus;
        private Hunya_AnnualBonusTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private System.Windows.Forms.BindingSource hunya_ABLevelCodeBindingSource;
        private Hunya_AnnualBonusTableAdapters.Hunya_ABLevelCodeTableAdapter hunya_ABLevelCodeTableAdapter;
        private System.Windows.Forms.Button btnConfig;
    }
}
