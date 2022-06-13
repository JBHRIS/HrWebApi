namespace HR_TOOL.NHI
{
    partial class NHI_Import
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSheet = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxYYMM = new System.Windows.Forms.TextBox();
            this.buttonImport = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxIdType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxAmt = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxBirthday = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxSNO = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxFaName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxIDNO = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonIG = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "檔案";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(64, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(372, 22);
            this.textBox1.TabIndex = 1;
            // 
            // buttonFile
            // 
            this.buttonFile.Location = new System.Drawing.Point(451, 14);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(75, 23);
            this.buttonFile.TabIndex = 2;
            this.buttonFile.Text = "瀏覽";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "工作表";
            // 
            // comboBoxSheet
            // 
            this.comboBoxSheet.FormattingEnabled = true;
            this.comboBoxSheet.Location = new System.Drawing.Point(64, 49);
            this.comboBoxSheet.Name = "comboBoxSheet";
            this.comboBoxSheet.Size = new System.Drawing.Size(121, 20);
            this.comboBoxSheet.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 188);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(793, 433);
            this.dataGridView1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxYYMM);
            this.groupBox1.Controls.Add(this.buttonIG);
            this.groupBox1.Controls.Add(this.buttonImport);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.comboBoxIdType);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.comboBoxAmt);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBoxBirthday);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBoxSNO);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBoxFaName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBoxName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxIDNO);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(793, 97);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // textBoxYYMM
            // 
            this.textBoxYYMM.Location = new System.Drawing.Point(480, 69);
            this.textBoxYYMM.Name = "textBoxYYMM";
            this.textBoxYYMM.Size = new System.Drawing.Size(121, 22);
            this.textBoxYYMM.TabIndex = 7;
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(712, 67);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(75, 23);
            this.buttonImport.TabIndex = 6;
            this.buttonImport.Text = "健保轉入";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(421, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "帳單年月";
            // 
            // comboBoxIdType
            // 
            this.comboBoxIdType.FormattingEnabled = true;
            this.comboBoxIdType.Location = new System.Drawing.Point(480, 15);
            this.comboBoxIdType.Name = "comboBoxIdType";
            this.comboBoxIdType.Size = new System.Drawing.Size(121, 20);
            this.comboBoxIdType.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(433, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "身分別";
            // 
            // comboBoxAmt
            // 
            this.comboBoxAmt.FormattingEnabled = true;
            this.comboBoxAmt.Location = new System.Drawing.Point(282, 73);
            this.comboBoxAmt.Name = "comboBoxAmt";
            this.comboBoxAmt.Size = new System.Drawing.Size(121, 20);
            this.comboBoxAmt.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(223, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "投保金額";
            // 
            // comboBoxBirthday
            // 
            this.comboBoxBirthday.FormattingEnabled = true;
            this.comboBoxBirthday.Location = new System.Drawing.Point(282, 47);
            this.comboBoxBirthday.Name = "comboBoxBirthday";
            this.comboBoxBirthday.Size = new System.Drawing.Size(121, 20);
            this.comboBoxBirthday.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(223, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "出生日期";
            // 
            // comboBoxSNO
            // 
            this.comboBoxSNO.FormattingEnabled = true;
            this.comboBoxSNO.Location = new System.Drawing.Point(282, 18);
            this.comboBoxSNO.Name = "comboBoxSNO";
            this.comboBoxSNO.Size = new System.Drawing.Size(121, 20);
            this.comboBoxSNO.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "投保單位";
            // 
            // comboBoxFaName
            // 
            this.comboBoxFaName.FormattingEnabled = true;
            this.comboBoxFaName.Location = new System.Drawing.Point(73, 73);
            this.comboBoxFaName.Name = "comboBoxFaName";
            this.comboBoxFaName.Size = new System.Drawing.Size(121, 20);
            this.comboBoxFaName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "眷屬姓名";
            // 
            // comboBoxName
            // 
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.Location = new System.Drawing.Point(73, 47);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(121, 20);
            this.comboBoxName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "員工姓名";
            // 
            // comboBoxIDNO
            // 
            this.comboBoxIDNO.FormattingEnabled = true;
            this.comboBoxIDNO.Location = new System.Drawing.Point(73, 21);
            this.comboBoxIDNO.Name = "comboBoxIDNO";
            this.comboBoxIDNO.Size = new System.Drawing.Size(121, 20);
            this.comboBoxIDNO.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "身分證號";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(191, 46);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 6;
            this.buttonLoad.Text = "讀取";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonIG
            // 
            this.buttonIG.Location = new System.Drawing.Point(712, 38);
            this.buttonIG.Name = "buttonIG";
            this.buttonIG.Size = new System.Drawing.Size(75, 23);
            this.buttonIG.TabIndex = 6;
            this.buttonIG.Text = "團保轉入";
            this.buttonIG.UseVisualStyleBackColor = true;
            this.buttonIG.Click += new System.EventHandler(this.buttonIG_Click);
            // 
            // NHI_Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 633);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBoxSheet);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NHI_Import";
            this.Text = "NHI_Import";
            this.Load += new System.EventHandler(this.NHI_Import_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSheet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxBirthday;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxSNO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxFaName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxIDNO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxIdType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxAmt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.TextBox textBoxYYMM;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonIG;
    }
}