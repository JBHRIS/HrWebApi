
namespace JBHR.Performance.HunyaCustom
{
    partial class Hunya_PAPersonalBonus
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.JQPAPersonalBonus = new JBControls.JBQuery();
            this.btnCalculate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
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
            this.dgv.TabIndex = 9;
            // 
            // JQPAPersonalBonus
            // 
            this.JQPAPersonalBonus.bnAddEnable = true;
            this.JQPAPersonalBonus.bnDelEnable = true;
            this.JQPAPersonalBonus.bnEditEnable = true;
            this.JQPAPersonalBonus.bnExportEnable = true;
            this.JQPAPersonalBonus.DataGrid = this.dgv;
            this.JQPAPersonalBonus.Location = new System.Drawing.Point(13, 12);
            this.JQPAPersonalBonus.Name = "JQPAPersonalBonus";
            this.JQPAPersonalBonus.QuerySettingString = "View_Hunya_PAPersonalBonus";
            this.JQPAPersonalBonus.RadDataGrid = null;
            this.JQPAPersonalBonus.Size = new System.Drawing.Size(642, 77);
            this.JQPAPersonalBonus.SortString = "";
            this.JQPAPersonalBonus.SourceTable = null;
            this.JQPAPersonalBonus.TabIndex = 8;
            this.JQPAPersonalBonus.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.JQPAPersonalBonus_RowDelete);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(663, 18);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(109, 20);
            this.btnCalculate.TabIndex = 10;
            this.btnCalculate.Text = "計算績效獎金";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // Hunya_PAPersonalBonus
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.JQPAPersonalBonus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "Hunya_PAPersonalBonus";
            this.Text = "Hunya_PAPersonalBonus";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private JBControls.JBQuery JQPAPersonalBonus;
        private System.Windows.Forms.Button btnCalculate;
    }
}
