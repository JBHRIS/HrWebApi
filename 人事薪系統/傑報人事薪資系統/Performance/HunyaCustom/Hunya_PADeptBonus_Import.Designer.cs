
namespace JBHR.Performance.HunyaCustom
{
    partial class Hunya_PADeptBonus_Import
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnImport = new System.Windows.Forms.Button();
            this.cbxPADept = new System.Windows.Forms.ComboBox();
            this.lbPADept = new System.Windows.Forms.Label();
            this.cbxPABasicBonus = new System.Windows.Forms.ComboBox();
            this.lbPABasicBonus = new System.Windows.Forms.Label();
            this.lbYYMM_E = new System.Windows.Forms.Label();
            this.cbxYYMM_E = new System.Windows.Forms.ComboBox();
            this.lbYYMM_B = new System.Windows.Forms.Label();
            this.cbxYYMM_B = new System.Windows.Forms.ComboBox();
            this.lbPADeptName = new System.Windows.Forms.Label();
            this.cbxPADeptName = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.30131F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.69869F));
            this.tableLayoutPanel1.Controls.Add(this.btnImport, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbxPADept, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbPADept, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxPABasicBonus, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbPABasicBonus, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbYYMM_E, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxYYMM_E, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbYYMM_B, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxYYMM_B, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbPADeptName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxPADeptName, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(220, 167);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btnImport, 2);
            this.btnImport.Location = new System.Drawing.Point(72, 140);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 21);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cbxPADept
            // 
            this.cbxPADept.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxPADept.FormattingEnabled = true;
            this.cbxPADept.Location = new System.Drawing.Point(89, 3);
            this.cbxPADept.Name = "cbxPADept";
            this.cbxPADept.Size = new System.Drawing.Size(128, 20);
            this.cbxPADept.TabIndex = 0;
            this.cbxPADept.Tag = "部門代碼";
            // 
            // lbPADept
            // 
            this.lbPADept.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPADept.AutoSize = true;
            this.lbPADept.ForeColor = System.Drawing.Color.Red;
            this.lbPADept.Location = new System.Drawing.Point(30, 7);
            this.lbPADept.Name = "lbPADept";
            this.lbPADept.Size = new System.Drawing.Size(53, 12);
            this.lbPADept.TabIndex = 106;
            this.lbPADept.Text = "部門代碼";
            // 
            // cbxPABasicBonus
            // 
            this.cbxPABasicBonus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxPABasicBonus.FormattingEnabled = true;
            this.cbxPABasicBonus.Location = new System.Drawing.Point(89, 111);
            this.cbxPABasicBonus.Name = "cbxPABasicBonus";
            this.cbxPABasicBonus.Size = new System.Drawing.Size(128, 20);
            this.cbxPABasicBonus.TabIndex = 4;
            this.cbxPABasicBonus.Tag = "基本獎金";
            // 
            // lbPABasicBonus
            // 
            this.lbPABasicBonus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPABasicBonus.AutoSize = true;
            this.lbPABasicBonus.ForeColor = System.Drawing.Color.Red;
            this.lbPABasicBonus.Location = new System.Drawing.Point(30, 115);
            this.lbPABasicBonus.Name = "lbPABasicBonus";
            this.lbPABasicBonus.Size = new System.Drawing.Size(53, 12);
            this.lbPABasicBonus.TabIndex = 107;
            this.lbPABasicBonus.Text = "基本獎金";
            // 
            // lbYYMM_E
            // 
            this.lbYYMM_E.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbYYMM_E.AutoSize = true;
            this.lbYYMM_E.ForeColor = System.Drawing.Color.Red;
            this.lbYYMM_E.Location = new System.Drawing.Point(18, 88);
            this.lbYYMM_E.Name = "lbYYMM_E";
            this.lbYYMM_E.Size = new System.Drawing.Size(65, 12);
            this.lbYYMM_E.TabIndex = 110;
            this.lbYYMM_E.Text = "考核年月迄";
            // 
            // cbxYYMM_E
            // 
            this.cbxYYMM_E.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxYYMM_E.FormattingEnabled = true;
            this.cbxYYMM_E.Location = new System.Drawing.Point(89, 84);
            this.cbxYYMM_E.Name = "cbxYYMM_E";
            this.cbxYYMM_E.Size = new System.Drawing.Size(128, 20);
            this.cbxYYMM_E.TabIndex = 3;
            this.cbxYYMM_E.Tag = "考核年月迄";
            // 
            // lbYYMM_B
            // 
            this.lbYYMM_B.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbYYMM_B.AutoSize = true;
            this.lbYYMM_B.ForeColor = System.Drawing.Color.Red;
            this.lbYYMM_B.Location = new System.Drawing.Point(18, 61);
            this.lbYYMM_B.Name = "lbYYMM_B";
            this.lbYYMM_B.Size = new System.Drawing.Size(65, 12);
            this.lbYYMM_B.TabIndex = 108;
            this.lbYYMM_B.Text = "考核年月起";
            // 
            // cbxYYMM_B
            // 
            this.cbxYYMM_B.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxYYMM_B.FormattingEnabled = true;
            this.cbxYYMM_B.Location = new System.Drawing.Point(89, 57);
            this.cbxYYMM_B.Name = "cbxYYMM_B";
            this.cbxYYMM_B.Size = new System.Drawing.Size(128, 20);
            this.cbxYYMM_B.TabIndex = 2;
            this.cbxYYMM_B.Tag = "考核年月起";
            // 
            // lbPADeptName
            // 
            this.lbPADeptName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPADeptName.AutoSize = true;
            this.lbPADeptName.Location = new System.Drawing.Point(30, 34);
            this.lbPADeptName.Name = "lbPADeptName";
            this.lbPADeptName.Size = new System.Drawing.Size(53, 12);
            this.lbPADeptName.TabIndex = 115;
            this.lbPADeptName.Text = "部門名稱";
            // 
            // cbxPADeptName
            // 
            this.cbxPADeptName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxPADeptName.FormattingEnabled = true;
            this.cbxPADeptName.Location = new System.Drawing.Point(89, 30);
            this.cbxPADeptName.Name = "cbxPADeptName";
            this.cbxPADeptName.Size = new System.Drawing.Size(128, 20);
            this.cbxPADeptName.TabIndex = 1;
            this.cbxPADeptName.Tag = "部門名稱";
            // 
            // Hunya_PADeptBonus_Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(244, 191);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Hunya_PADeptBonus_Import";
            this.Load += new System.EventHandler(this.Hunya_PADeptBonus_Import_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ComboBox cbxPADept;
        private System.Windows.Forms.Label lbPADept;
        private System.Windows.Forms.ComboBox cbxPABasicBonus;
        private System.Windows.Forms.Label lbPABasicBonus;
        private System.Windows.Forms.Label lbYYMM_E;
        private System.Windows.Forms.ComboBox cbxYYMM_E;
        private System.Windows.Forms.Label lbYYMM_B;
        private System.Windows.Forms.ComboBox cbxYYMM_B;
        private System.Windows.Forms.Label lbPADeptName;
        private System.Windows.Forms.ComboBox cbxPADeptName;
    }
}
