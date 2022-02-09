namespace JBHR.Med
{
    partial class FRM71N2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.jbQuery1 = new JBControls.JBQuery();
            this.buttonImportFromPayRoll = new System.Windows.Forms.Button();
            this.buttonImportFromFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.buttonReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(984, 535);
            this.dataGridView1.TabIndex = 3;
            // 
            // jbQuery1
            // 
            this.jbQuery1.bnAddEnable = true;
            this.jbQuery1.bnDelEnable = true;
            this.jbQuery1.bnEditEnable = true;
            this.jbQuery1.bnExportEnable = true;
            this.jbQuery1.DataGrid = this.dataGridView1;
            this.jbQuery1.Location = new System.Drawing.Point(12, 11);
            this.jbQuery1.Name = "jbQuery1";
            this.jbQuery1.QuerySettingString = "TW_TAX_SUMMARY";
            this.jbQuery1.RadDataGrid = null;
            this.jbQuery1.Size = new System.Drawing.Size(642, 77);
            this.jbQuery1.SortString = "";
            this.jbQuery1.SourceTable = null;
            this.jbQuery1.TabIndex = 2;
            this.jbQuery1.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.jbQuery1_RowDelete);
            // 
            // buttonImportFromPayRoll
            // 
            this.buttonImportFromPayRoll.Location = new System.Drawing.Point(921, 13);
            this.buttonImportFromPayRoll.Name = "buttonImportFromPayRoll";
            this.buttonImportFromPayRoll.Size = new System.Drawing.Size(75, 23);
            this.buttonImportFromPayRoll.TabIndex = 4;
            this.buttonImportFromPayRoll.Text = "從資料轉入";
            this.buttonImportFromPayRoll.UseVisualStyleBackColor = true;
            this.buttonImportFromPayRoll.Click += new System.EventHandler(this.buttonImportFromPayRoll_Click);
            // 
            // buttonImportFromFile
            // 
            this.buttonImportFromFile.Location = new System.Drawing.Point(921, 60);
            this.buttonImportFromFile.Name = "buttonImportFromFile";
            this.buttonImportFromFile.Size = new System.Drawing.Size(75, 23);
            this.buttonImportFromFile.TabIndex = 5;
            this.buttonImportFromFile.Text = "從檔案匯入";
            this.buttonImportFromFile.UseVisualStyleBackColor = true;
            this.buttonImportFromFile.Visible = false;
            this.buttonImportFromFile.Click += new System.EventHandler(this.buttonImportFromFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(788, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "起始編號";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.maskedTextBox1.Location = new System.Drawing.Point(842, 13);
            this.maskedTextBox1.Mask = "A0000000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(62, 23);
            this.maskedTextBox1.TabIndex = 7;
            this.maskedTextBox1.Text = "A0000001";
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(819, 60);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(85, 23);
            this.buttonReport.TabIndex = 8;
            this.buttonReport.Text = "產生報表";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // FRM71N2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 641);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonImportFromFile);
            this.Controls.Add(this.buttonImportFromPayRoll);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.jbQuery1);
            this.FormSize = JBControls.JBForm.FormSizeType.Large;
            this.Name = "FRM71N2";
            this.Text = "FRM71N2-申報資料結轉";
            this.Load += new System.EventHandler(this.FRM71N2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private JBControls.JBQuery jbQuery1;
        private System.Windows.Forms.Button buttonImportFromPayRoll;
        private System.Windows.Forms.Button buttonImportFromFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button buttonReport;
    }
}