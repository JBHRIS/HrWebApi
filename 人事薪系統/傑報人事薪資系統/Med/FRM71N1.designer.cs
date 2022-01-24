namespace JBHR.Med
{
    partial class FRM71N1
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
            this.buttonIsFile = new System.Windows.Forms.Button();
            this.buttonIsNotFile = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
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
            this.jbQuery1.QuerySettingString = "TW_TAX_ITEM";
            this.jbQuery1.RadDataGrid = null;
            this.jbQuery1.Size = new System.Drawing.Size(642, 77);
            this.jbQuery1.SortString = "";
            this.jbQuery1.SourceTable = null;
            this.jbQuery1.TabIndex = 2;
            this.jbQuery1.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.jbQuery1_RowDelete);
            this.jbQuery1.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.jbQuery1_RowInsert);
            this.jbQuery1.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.jbQuery1_RowUpdate);
            // 
            // buttonImportFromPayRoll
            // 
            this.buttonImportFromPayRoll.Location = new System.Drawing.Point(921, 13);
            this.buttonImportFromPayRoll.Name = "buttonImportFromPayRoll";
            this.buttonImportFromPayRoll.Size = new System.Drawing.Size(75, 23);
            this.buttonImportFromPayRoll.TabIndex = 4;
            this.buttonImportFromPayRoll.Text = "從薪資轉入";
            this.buttonImportFromPayRoll.UseVisualStyleBackColor = true;
            this.buttonImportFromPayRoll.Click += new System.EventHandler(this.buttonImportFromPayRoll_Click);
            // 
            // buttonImportFromFile
            // 
            this.buttonImportFromFile.Location = new System.Drawing.Point(921, 40);
            this.buttonImportFromFile.Name = "buttonImportFromFile";
            this.buttonImportFromFile.Size = new System.Drawing.Size(75, 23);
            this.buttonImportFromFile.TabIndex = 5;
            this.buttonImportFromFile.Text = "從檔案匯入";
            this.buttonImportFromFile.UseVisualStyleBackColor = true;
            this.buttonImportFromFile.Click += new System.EventHandler(this.buttonImportFromFile_Click);
            // 
            // buttonIsFile
            // 
            this.buttonIsFile.Location = new System.Drawing.Point(650, 13);
            this.buttonIsFile.Name = "buttonIsFile";
            this.buttonIsFile.Size = new System.Drawing.Size(75, 23);
            this.buttonIsFile.TabIndex = 6;
            this.buttonIsFile.Text = "設為已申報";
            this.buttonIsFile.UseVisualStyleBackColor = true;
            this.buttonIsFile.Click += new System.EventHandler(this.buttonIsFile_Click);
            // 
            // buttonIsNotFile
            // 
            this.buttonIsNotFile.Location = new System.Drawing.Point(731, 13);
            this.buttonIsNotFile.Name = "buttonIsNotFile";
            this.buttonIsNotFile.Size = new System.Drawing.Size(75, 23);
            this.buttonIsNotFile.TabIndex = 6;
            this.buttonIsNotFile.Text = "設為未申報";
            this.buttonIsNotFile.UseVisualStyleBackColor = true;
            this.buttonIsNotFile.Click += new System.EventHandler(this.buttonIsNotFile_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnConfig.BackgroundImage = global::JBHR.Properties.Resources.Settings_icon;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(971, 65);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(25, 23);
            this.btnConfig.TabIndex = 1020;
            this.btnConfig.Tag = "FRM71N1";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // FRM71N1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 641);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.buttonIsNotFile);
            this.Controls.Add(this.buttonIsFile);
            this.Controls.Add(this.buttonImportFromFile);
            this.Controls.Add(this.buttonImportFromPayRoll);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.jbQuery1);
            this.FormSize = JBControls.JBForm.FormSizeType.Large;
            this.Name = "FRM71N1";
            this.Text = "FRM71N1-申報資料維護";
            this.Load += new System.EventHandler(this.FRM71N1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private JBControls.JBQuery jbQuery1;
        private System.Windows.Forms.Button buttonImportFromPayRoll;
        private System.Windows.Forms.Button buttonImportFromFile;
        private System.Windows.Forms.Button buttonIsFile;
        private System.Windows.Forms.Button buttonIsNotFile;
        private System.Windows.Forms.Button btnConfig;
    }
}