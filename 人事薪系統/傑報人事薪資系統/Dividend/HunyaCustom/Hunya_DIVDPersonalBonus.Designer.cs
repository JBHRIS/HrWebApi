
namespace JBHR.Dividend.HunyaCustom
{
    partial class Hunya_DIVDPersonalBonus
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
            this.btnCalculate = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.JQDIVDPersonalBonus = new JBControls.JBQuery();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(663, 18);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(109, 20);
            this.btnCalculate.TabIndex = 13;
            this.btnCalculate.Text = "計算紅利獎金";
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
            this.dgv.TabIndex = 12;
            // 
            // JQDIVDPersonalBonus
            // 
            this.JQDIVDPersonalBonus.bnAddEnable = true;
            this.JQDIVDPersonalBonus.bnDelEnable = true;
            this.JQDIVDPersonalBonus.bnEditEnable = true;
            this.JQDIVDPersonalBonus.bnExportEnable = true;
            this.JQDIVDPersonalBonus.DataGrid = this.dgv;
            this.JQDIVDPersonalBonus.Location = new System.Drawing.Point(13, 12);
            this.JQDIVDPersonalBonus.Name = "JQDIVDPersonalBonus";
            this.JQDIVDPersonalBonus.QuerySettingString = "View_Hunya_DIVDPersonalBonus";
            this.JQDIVDPersonalBonus.RadDataGrid = null;
            this.JQDIVDPersonalBonus.Size = new System.Drawing.Size(642, 77);
            this.JQDIVDPersonalBonus.SortString = "";
            this.JQDIVDPersonalBonus.SourceTable = null;
            this.JQDIVDPersonalBonus.TabIndex = 11;
            this.JQDIVDPersonalBonus.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.JQDIVDPersonalBonus_RowDelete);
            // 
            // Hunya_DIVDPersonalBonus
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.JQDIVDPersonalBonus);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "Hunya_DIVDPersonalBonus";
            this.Text = "Hunya_DIVDPersonalBonus";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.DataGridView dgv;
        private JBControls.JBQuery JQDIVDPersonalBonus;
    }
}
