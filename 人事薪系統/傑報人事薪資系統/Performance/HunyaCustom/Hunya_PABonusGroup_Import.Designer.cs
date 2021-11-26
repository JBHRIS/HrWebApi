
namespace JBHR.Performance.HunyaCustom
{
    partial class Hunya_PABonusGroup_Import
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
            this.cbxEmployeeID = new System.Windows.Forms.ComboBox();
            this.lbEmployeeID = new System.Windows.Forms.Label();
            this.cbxPAGroupCode = new System.Windows.Forms.ComboBox();
            this.lbPAGroupCode = new System.Windows.Forms.Label();
            this.lbYYMM_E = new System.Windows.Forms.Label();
            this.cbxYYMM_E = new System.Windows.Forms.ComboBox();
            this.lbYYMM_B = new System.Windows.Forms.Label();
            this.cbxYYMM_B = new System.Windows.Forms.ComboBox();
            this.lbEmployeeName = new System.Windows.Forms.Label();
            this.cbxEmployeeName = new System.Windows.Forms.ComboBox();
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
            this.tableLayoutPanel1.Controls.Add(this.cbxEmployeeID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbEmployeeID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxPAGroupCode, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbPAGroupCode, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbYYMM_E, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxYYMM_E, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbYYMM_B, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxYYMM_B, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbEmployeeName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxEmployeeName, 1, 1);
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
            this.tableLayoutPanel1.TabIndex = 0;
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
            // cbxEmployeeID
            // 
            this.cbxEmployeeID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxEmployeeID.FormattingEnabled = true;
            this.cbxEmployeeID.Location = new System.Drawing.Point(89, 3);
            this.cbxEmployeeID.Name = "cbxEmployeeID";
            this.cbxEmployeeID.Size = new System.Drawing.Size(128, 20);
            this.cbxEmployeeID.TabIndex = 0;
            this.cbxEmployeeID.Tag = "員工編號";
            // 
            // lbEmployeeID
            // 
            this.lbEmployeeID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEmployeeID.AutoSize = true;
            this.lbEmployeeID.ForeColor = System.Drawing.Color.Red;
            this.lbEmployeeID.Location = new System.Drawing.Point(30, 7);
            this.lbEmployeeID.Name = "lbEmployeeID";
            this.lbEmployeeID.Size = new System.Drawing.Size(53, 12);
            this.lbEmployeeID.TabIndex = 106;
            this.lbEmployeeID.Text = "員工編號";
            // 
            // cbxPAGroupCode
            // 
            this.cbxPAGroupCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxPAGroupCode.FormattingEnabled = true;
            this.cbxPAGroupCode.Location = new System.Drawing.Point(89, 111);
            this.cbxPAGroupCode.Name = "cbxPAGroupCode";
            this.cbxPAGroupCode.Size = new System.Drawing.Size(128, 20);
            this.cbxPAGroupCode.TabIndex = 4;
            this.cbxPAGroupCode.Tag = "績效獎金群組";
            // 
            // lbPAGroupCode
            // 
            this.lbPAGroupCode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPAGroupCode.AutoSize = true;
            this.lbPAGroupCode.ForeColor = System.Drawing.Color.Red;
            this.lbPAGroupCode.Location = new System.Drawing.Point(6, 115);
            this.lbPAGroupCode.Name = "lbPAGroupCode";
            this.lbPAGroupCode.Size = new System.Drawing.Size(77, 12);
            this.lbPAGroupCode.TabIndex = 107;
            this.lbPAGroupCode.Text = "績效獎金群組";
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
            // lbEmployeeName
            // 
            this.lbEmployeeName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEmployeeName.AutoSize = true;
            this.lbEmployeeName.Location = new System.Drawing.Point(30, 34);
            this.lbEmployeeName.Name = "lbEmployeeName";
            this.lbEmployeeName.Size = new System.Drawing.Size(53, 12);
            this.lbEmployeeName.TabIndex = 115;
            this.lbEmployeeName.Text = "員工姓名";
            // 
            // cbxEmployeeName
            // 
            this.cbxEmployeeName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxEmployeeName.FormattingEnabled = true;
            this.cbxEmployeeName.Location = new System.Drawing.Point(89, 30);
            this.cbxEmployeeName.Name = "cbxEmployeeName";
            this.cbxEmployeeName.Size = new System.Drawing.Size(128, 20);
            this.cbxEmployeeName.TabIndex = 1;
            this.cbxEmployeeName.Tag = "員工姓名";
            // 
            // Hunya_PABonusGroup_Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(244, 191);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Hunya_PABonusGroup_Import";
            this.Load += new System.EventHandler(this.Hunya_PABonusGroup_Import_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbEmployeeID;
        private System.Windows.Forms.Label lbPAGroupCode;
        private System.Windows.Forms.Label lbYYMM_B;
        private System.Windows.Forms.Label lbYYMM_E;
        private System.Windows.Forms.ComboBox cbxPAGroupCode;
        private System.Windows.Forms.ComboBox cbxYYMM_E;
        private System.Windows.Forms.ComboBox cbxYYMM_B;
        private System.Windows.Forms.ComboBox cbxEmployeeID;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label lbEmployeeName;
        private System.Windows.Forms.ComboBox cbxEmployeeName;
    }
}
