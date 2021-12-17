namespace JBHR.AnnualBonus.HunyaCustom
{
    partial class Hunya_ABPersonalBonus_Import
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
            this.lbYYYY = new System.Windows.Forms.Label();
            this.cbxYYYY = new System.Windows.Forms.ComboBox();
            this.lbEmployeeName = new System.Windows.Forms.Label();
            this.cbxEmployeeName = new System.Windows.Forms.ComboBox();
            this.lbABLevelCode = new System.Windows.Forms.Label();
            this.lbABRealLevel = new System.Windows.Forms.Label();
            this.cbxABLevelCode = new System.Windows.Forms.ComboBox();
            this.cbxABRealLevel = new System.Windows.Forms.ComboBox();
            this.lbABScore = new System.Windows.Forms.Label();
            this.cbxABScore = new System.Windows.Forms.ComboBox();
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
            this.tableLayoutPanel1.Controls.Add(this.btnImport, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbxEmployeeID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbEmployeeID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbYYYY, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxYYYY, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbEmployeeName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxEmployeeName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbABRealLevel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbABLevelCode, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbABScore, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxABRealLevel, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbxABScore, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxABLevelCode, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(220, 197);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btnImport, 2);
            this.btnImport.Location = new System.Drawing.Point(72, 172);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 21);
            this.btnImport.TabIndex = 120;
            this.btnImport.Text = "設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cbxEmployeeID
            // 
            this.cbxEmployeeID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxEmployeeID.FormattingEnabled = true;
            this.cbxEmployeeID.Location = new System.Drawing.Point(89, 4);
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
            this.lbEmployeeID.Location = new System.Drawing.Point(30, 8);
            this.lbEmployeeID.Name = "lbEmployeeID";
            this.lbEmployeeID.Size = new System.Drawing.Size(53, 12);
            this.lbEmployeeID.TabIndex = 106;
            this.lbEmployeeID.Text = "員工編號";
            // 
            // lbYYYY
            // 
            this.lbYYYY.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbYYYY.AutoSize = true;
            this.lbYYYY.ForeColor = System.Drawing.Color.Red;
            this.lbYYYY.Location = new System.Drawing.Point(30, 64);
            this.lbYYYY.Name = "lbYYYY";
            this.lbYYYY.Size = new System.Drawing.Size(53, 12);
            this.lbYYYY.TabIndex = 108;
            this.lbYYYY.Text = "考績年度";
            // 
            // cbxYYYY
            // 
            this.cbxYYYY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxYYYY.FormattingEnabled = true;
            this.cbxYYYY.Location = new System.Drawing.Point(89, 60);
            this.cbxYYYY.Name = "cbxYYYY";
            this.cbxYYYY.Size = new System.Drawing.Size(128, 20);
            this.cbxYYYY.TabIndex = 2;
            this.cbxYYYY.Tag = "考績年度";
            // 
            // lbEmployeeName
            // 
            this.lbEmployeeName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEmployeeName.AutoSize = true;
            this.lbEmployeeName.Location = new System.Drawing.Point(30, 36);
            this.lbEmployeeName.Name = "lbEmployeeName";
            this.lbEmployeeName.Size = new System.Drawing.Size(53, 12);
            this.lbEmployeeName.TabIndex = 115;
            this.lbEmployeeName.Text = "員工姓名";
            // 
            // cbxEmployeeName
            // 
            this.cbxEmployeeName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxEmployeeName.FormattingEnabled = true;
            this.cbxEmployeeName.Location = new System.Drawing.Point(89, 32);
            this.cbxEmployeeName.Name = "cbxEmployeeName";
            this.cbxEmployeeName.Size = new System.Drawing.Size(128, 20);
            this.cbxEmployeeName.TabIndex = 1;
            this.cbxEmployeeName.Tag = "員工姓名";
            // 
            // lbABLevelCode
            // 
            this.lbABLevelCode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbABLevelCode.AutoSize = true;
            this.lbABLevelCode.ForeColor = System.Drawing.Color.Black;
            this.lbABLevelCode.Location = new System.Drawing.Point(30, 120);
            this.lbABLevelCode.Name = "lbABLevelCode";
            this.lbABLevelCode.Size = new System.Drawing.Size(53, 12);
            this.lbABLevelCode.TabIndex = 107;
            this.lbABLevelCode.Text = "年度評等";
            // 
            // lbABRealLevel
            // 
            this.lbABRealLevel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbABRealLevel.AutoSize = true;
            this.lbABRealLevel.ForeColor = System.Drawing.Color.Black;
            this.lbABRealLevel.Location = new System.Drawing.Point(30, 148);
            this.lbABRealLevel.Name = "lbABRealLevel";
            this.lbABRealLevel.Size = new System.Drawing.Size(53, 12);
            this.lbABRealLevel.TabIndex = 116;
            this.lbABRealLevel.Text = "實際評等";
            // 
            // cbxABLevelCode
            // 
            this.cbxABLevelCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxABLevelCode.FormattingEnabled = true;
            this.cbxABLevelCode.Location = new System.Drawing.Point(89, 116);
            this.cbxABLevelCode.Name = "cbxABLevelCode";
            this.cbxABLevelCode.Size = new System.Drawing.Size(128, 20);
            this.cbxABLevelCode.TabIndex = 3;
            this.cbxABLevelCode.Tag = "年度評等";
            // 
            // cbxABRealLevel
            // 
            this.cbxABRealLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxABRealLevel.FormattingEnabled = true;
            this.cbxABRealLevel.Location = new System.Drawing.Point(89, 144);
            this.cbxABRealLevel.Name = "cbxABRealLevel";
            this.cbxABRealLevel.Size = new System.Drawing.Size(128, 20);
            this.cbxABRealLevel.TabIndex = 117;
            this.cbxABRealLevel.Tag = "實際評等";
            // 
            // lbABScore
            // 
            this.lbABScore.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbABScore.AutoSize = true;
            this.lbABScore.ForeColor = System.Drawing.Color.Black;
            this.lbABScore.Location = new System.Drawing.Point(30, 92);
            this.lbABScore.Name = "lbABScore";
            this.lbABScore.Size = new System.Drawing.Size(53, 12);
            this.lbABScore.TabIndex = 118;
            this.lbABScore.Text = "年度考績";
            // 
            // cbxABScore
            // 
            this.cbxABScore.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxABScore.FormattingEnabled = true;
            this.cbxABScore.Location = new System.Drawing.Point(89, 88);
            this.cbxABScore.Name = "cbxABScore";
            this.cbxABScore.Size = new System.Drawing.Size(128, 20);
            this.cbxABScore.TabIndex = 119;
            this.cbxABScore.Tag = "年度考績";
            // 
            // Hunya_ABPersonalBonus_Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(244, 221);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Hunya_ABPersonalBonus_Import";
            this.Load += new System.EventHandler(this.Hunya_ABPersonalBonus_Import_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ComboBox cbxEmployeeID;
        private System.Windows.Forms.Label lbEmployeeID;
        private System.Windows.Forms.Label lbYYYY;
        private System.Windows.Forms.ComboBox cbxYYYY;
        private System.Windows.Forms.Label lbEmployeeName;
        private System.Windows.Forms.ComboBox cbxEmployeeName;
        private System.Windows.Forms.Label lbABLevelCode;
        private System.Windows.Forms.Label lbABRealLevel;
        private System.Windows.Forms.ComboBox cbxABLevelCode;
        private System.Windows.Forms.ComboBox cbxABRealLevel;
        private System.Windows.Forms.Label lbABScore;
        private System.Windows.Forms.ComboBox cbxABScore;
    }
}
