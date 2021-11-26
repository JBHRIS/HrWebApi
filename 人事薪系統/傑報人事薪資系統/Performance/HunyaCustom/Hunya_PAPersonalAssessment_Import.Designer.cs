
namespace JBHR.Performance.HunyaCustom
{
    partial class Hunya_PAPersonalAssessment_Import
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
            this.cbxEmployeeID = new System.Windows.Forms.ComboBox();
            this.lbEmployeeID = new System.Windows.Forms.Label();
            this.lbYYMM = new System.Windows.Forms.Label();
            this.cbxYYMM = new System.Windows.Forms.ComboBox();
            this.lbEmployeeName = new System.Windows.Forms.Label();
            this.cbxEmployeeName = new System.Windows.Forms.ComboBox();
            this.lbPALevelCode = new System.Windows.Forms.Label();
            this.cbxPALevelCode = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.Controls.Add(this.cbxEmployeeID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbEmployeeID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbYYMM, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxYYMM, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbEmployeeName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxEmployeeName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbPALevelCode, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxPALevelCode, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnImport, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(220, 137);
            this.tableLayoutPanel1.TabIndex = 1;
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
            // lbYYMM
            // 
            this.lbYYMM.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbYYMM.AutoSize = true;
            this.lbYYMM.ForeColor = System.Drawing.Color.Red;
            this.lbYYMM.Location = new System.Drawing.Point(30, 61);
            this.lbYYMM.Name = "lbYYMM";
            this.lbYYMM.Size = new System.Drawing.Size(53, 12);
            this.lbYYMM.TabIndex = 108;
            this.lbYYMM.Text = "考核年月";
            // 
            // cbxYYMM
            // 
            this.cbxYYMM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxYYMM.FormattingEnabled = true;
            this.cbxYYMM.Location = new System.Drawing.Point(89, 57);
            this.cbxYYMM.Name = "cbxYYMM";
            this.cbxYYMM.Size = new System.Drawing.Size(128, 20);
            this.cbxYYMM.TabIndex = 2;
            this.cbxYYMM.Tag = "考核年月";
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
            // lbPALevelCode
            // 
            this.lbPALevelCode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPALevelCode.AutoSize = true;
            this.lbPALevelCode.ForeColor = System.Drawing.Color.Red;
            this.lbPALevelCode.Location = new System.Drawing.Point(30, 88);
            this.lbPALevelCode.Name = "lbPALevelCode";
            this.lbPALevelCode.Size = new System.Drawing.Size(53, 12);
            this.lbPALevelCode.TabIndex = 107;
            this.lbPALevelCode.Text = "考核等級";
            // 
            // cbxPALevelCode
            // 
            this.cbxPALevelCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxPALevelCode.FormattingEnabled = true;
            this.cbxPALevelCode.Location = new System.Drawing.Point(89, 84);
            this.cbxPALevelCode.Name = "cbxPALevelCode";
            this.cbxPALevelCode.Size = new System.Drawing.Size(128, 20);
            this.cbxPALevelCode.TabIndex = 3;
            this.cbxPALevelCode.Tag = "考核等級";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btnImport, 2);
            this.btnImport.Location = new System.Drawing.Point(72, 112);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 21);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // Hunya_PAPersonalAssessment_Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(244, 161);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Hunya_PAPersonalAssessment_Import";
            this.Load += new System.EventHandler(this.Hunya_PAPersonalAssessment_Import_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ComboBox cbxEmployeeID;
        private System.Windows.Forms.Label lbEmployeeID;
        private System.Windows.Forms.Label lbYYMM;
        private System.Windows.Forms.ComboBox cbxYYMM;
        private System.Windows.Forms.Label lbEmployeeName;
        private System.Windows.Forms.ComboBox cbxEmployeeName;
        private System.Windows.Forms.Label lbPALevelCode;
        private System.Windows.Forms.ComboBox cbxPALevelCode;
    }
}
