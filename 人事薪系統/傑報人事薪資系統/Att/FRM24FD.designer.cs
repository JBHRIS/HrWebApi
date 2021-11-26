namespace JBHR.Att
{
    partial class FRM24FD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ibImport = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbnCreateCard = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.cbxATime = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboADate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxNobr = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxSheet = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.dgvCardView = new System.Windows.Forms.DataGridView();
            this.lb8 = new System.Windows.Forms.Label();
            this.lbRepeat = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxCardcd = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardView)).BeginInit();
            this.SuspendLayout();
            // 
            // ibImport
            // 
            this.ibImport.AutoSize = true;
            this.ibImport.Location = new System.Drawing.Point(635, 145);
            this.ibImport.Name = "ibImport";
            this.ibImport.Size = new System.Drawing.Size(11, 12);
            this.ibImport.TabIndex = 36;
            this.ibImport.Text = "0";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(635, 127);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(11, 12);
            this.lbTotal.TabIndex = 35;
            this.lbTotal.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(563, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "匯入筆數 : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(575, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 33;
            this.label6.Text = "總筆數 : ";
            // 
            // tbnCreateCard
            // 
            this.tbnCreateCard.Location = new System.Drawing.Point(12, 565);
            this.tbnCreateCard.Name = "tbnCreateCard";
            this.tbnCreateCard.Size = new System.Drawing.Size(107, 23);
            this.tbnCreateCard.TabIndex = 32;
            this.tbnCreateCard.Text = "轉入刷卡資料";
            this.tbnCreateCard.UseVisualStyleBackColor = true;
            this.tbnCreateCard.Click += new System.EventHandler(this.tbnCreateCard_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(223, 133);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 31;
            this.btnOpenFile.TabStop = false;
            this.btnOpenFile.Text = "檢視";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // cbxATime
            // 
            this.cbxATime.FormattingEnabled = true;
            this.cbxATime.Location = new System.Drawing.Point(95, 161);
            this.cbxATime.Name = "cbxATime";
            this.cbxATime.Size = new System.Drawing.Size(121, 20);
            this.cbxATime.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 29;
            this.label5.Text = "刷卡時間";
            // 
            // cboADate
            // 
            this.cboADate.FormattingEnabled = true;
            this.cboADate.Location = new System.Drawing.Point(95, 134);
            this.cboADate.Name = "cboADate";
            this.cboADate.Size = new System.Drawing.Size(121, 20);
            this.cboADate.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "刷卡日期";
            // 
            // cbxNobr
            // 
            this.cbxNobr.FormattingEnabled = true;
            this.cbxNobr.Location = new System.Drawing.Point(96, 73);
            this.cbxNobr.Name = "cbxNobr";
            this.cbxNobr.Size = new System.Drawing.Size(121, 20);
            this.cbxNobr.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "工號/卡號";
            // 
            // cbxSheet
            // 
            this.cbxSheet.FormattingEnabled = true;
            this.cbxSheet.Location = new System.Drawing.Point(96, 43);
            this.cbxSheet.Name = "cbxSheet";
            this.cbxSheet.Size = new System.Drawing.Size(121, 20);
            this.cbxSheet.TabIndex = 24;
            this.cbxSheet.SelectedIndexChanged += new System.EventHandler(this.cbxSheet_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "資料表";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(95, 11);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(203, 22);
            this.txtPath.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "檔案位置";
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(302, 11);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(75, 23);
            this.btnChooseFile.TabIndex = 20;
            this.btnChooseFile.Text = "預覽";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(430, 565);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "關閉";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(349, 565);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 38;
            this.btnImport.Text = "匯入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dgvCardView
            // 
            this.dgvCardView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardView.Location = new System.Drawing.Point(12, 188);
            this.dgvCardView.Name = "dgvCardView";
            this.dgvCardView.ReadOnly = true;
            this.dgvCardView.RowTemplate.Height = 24;
            this.dgvCardView.Size = new System.Drawing.Size(655, 370);
            this.dgvCardView.TabIndex = 37;
            // 
            // lb8
            // 
            this.lb8.AutoSize = true;
            this.lb8.Location = new System.Drawing.Point(587, 108);
            this.lb8.Name = "lb8";
            this.lb8.Size = new System.Drawing.Size(47, 12);
            this.lb8.TabIndex = 40;
            this.lb8.Text = "重複 : ";
            this.lb8.Visible = false;
            // 
            // lbRepeat
            // 
            this.lbRepeat.AutoSize = true;
            this.lbRepeat.Location = new System.Drawing.Point(635, 108);
            this.lbRepeat.Name = "lbRepeat";
            this.lbRepeat.Size = new System.Drawing.Size(11, 12);
            this.lbRepeat.TabIndex = 41;
            this.lbRepeat.Text = "0";
            this.lbRepeat.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(511, 564);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(156, 23);
            this.progressBar.TabIndex = 42;
            this.progressBar.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 43;
            this.label8.Text = "卡機代碼(來源)";
            // 
            // comboBoxCardcd
            // 
            this.comboBoxCardcd.FormattingEnabled = true;
            this.comboBoxCardcd.Location = new System.Drawing.Point(96, 105);
            this.comboBoxCardcd.Name = "comboBoxCardcd";
            this.comboBoxCardcd.Size = new System.Drawing.Size(121, 20);
            this.comboBoxCardcd.TabIndex = 27;
            // 
            // FRM24FD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 594);
            this.Controls.Add(this.comboBoxCardcd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lbRepeat);
            this.Controls.Add(this.lb8);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dgvCardView);
            this.Controls.Add(this.ibImport);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbnCreateCard);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.cbxATime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboADate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxNobr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxSheet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChooseFile);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM24FD";
            this.Text = "FRM24FD";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ibImport;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button tbnCreateCard;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.ComboBox cbxATime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboADate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxNobr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxSheet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridView dgvCardView;
        private System.Windows.Forms.Label lb8;
        private System.Windows.Forms.Label lbRepeat;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxCardcd;
    }
}