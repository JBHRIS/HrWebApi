namespace JBHR.Att
{
    partial class FRM2A1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM2A1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tMTABLEIMPORTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.tMTABLE_IMPORTTableAdapter = new JBHR.Att.dsAttTableAdapters.TMTABLE_IMPORTTableAdapter();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.bnOpenFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxSheet = new System.Windows.Forms.ComboBox();
            this.bnQuery = new System.Windows.Forms.Button();
            this.bn_ImportOK = new System.Windows.Forms.Button();
            this.bn_ImportCancel = new System.Windows.Forms.Button();
            this.dsBas = new JBHR.Att.dsBas();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMTABLEIMPORTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 76);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1144, 372);
            this.dataGridView1.TabIndex = 0;
            // 
            // tMTABLEIMPORTBindingSource
            // 
            this.tMTABLEIMPORTBindingSource.DataMember = "TMTABLE_IMPORT";
            this.tMTABLEIMPORTBindingSource.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tMTABLE_IMPORTTableAdapter
            // 
            this.tMTABLE_IMPORTTableAdapter.ClearBeforeFill = true;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(33, 18);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(542, 29);
            this.txtPath.TabIndex = 1;
            // 
            // bnOpenFile
            // 
            this.bnOpenFile.Location = new System.Drawing.Point(586, 16);
            this.bnOpenFile.Margin = new System.Windows.Forms.Padding(4);
            this.bnOpenFile.Name = "bnOpenFile";
            this.bnOpenFile.Size = new System.Drawing.Size(112, 34);
            this.bnOpenFile.TabIndex = 2;
            this.bnOpenFile.Text = "開啟檔案";
            this.bnOpenFile.UseVisualStyleBackColor = true;
            this.bnOpenFile.Click += new System.EventHandler(this.bnOpenFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(748, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "工作表：";
            // 
            // cbxSheet
            // 
            this.cbxSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSheet.FormattingEnabled = true;
            this.cbxSheet.Location = new System.Drawing.Point(837, 18);
            this.cbxSheet.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSheet.Name = "cbxSheet";
            this.cbxSheet.Size = new System.Drawing.Size(180, 26);
            this.cbxSheet.TabIndex = 4;
            // 
            // bnQuery
            // 
            this.bnQuery.Location = new System.Drawing.Point(1065, 16);
            this.bnQuery.Margin = new System.Windows.Forms.Padding(4);
            this.bnQuery.Name = "bnQuery";
            this.bnQuery.Size = new System.Drawing.Size(112, 34);
            this.bnQuery.TabIndex = 5;
            this.bnQuery.Text = "預覽";
            this.bnQuery.UseVisualStyleBackColor = true;
            this.bnQuery.Click += new System.EventHandler(this.bnQuery_Click);
            // 
            // bn_ImportOK
            // 
            this.bn_ImportOK.Location = new System.Drawing.Point(928, 472);
            this.bn_ImportOK.Margin = new System.Windows.Forms.Padding(4);
            this.bn_ImportOK.Name = "bn_ImportOK";
            this.bn_ImportOK.Size = new System.Drawing.Size(112, 34);
            this.bn_ImportOK.TabIndex = 6;
            this.bn_ImportOK.Text = "確定匯入";
            this.bn_ImportOK.UseVisualStyleBackColor = true;
            this.bn_ImportOK.Click += new System.EventHandler(this.bn_ImportOK_Click);
            // 
            // bn_ImportCancel
            // 
            this.bn_ImportCancel.Location = new System.Drawing.Point(1066, 472);
            this.bn_ImportCancel.Margin = new System.Windows.Forms.Padding(4);
            this.bn_ImportCancel.Name = "bn_ImportCancel";
            this.bn_ImportCancel.Size = new System.Drawing.Size(112, 34);
            this.bn_ImportCancel.TabIndex = 6;
            this.bn_ImportCancel.Text = "取消";
            this.bn_ImportCancel.UseVisualStyleBackColor = true;
            this.bn_ImportCancel.Click += new System.EventHandler(this.bn_ImportCancel_Click);
            // 
            // dsBas
            // 
            this.dsBas.DataSetName = "dsBas";
            this.dsBas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FRM2A1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 532);
            this.Controls.Add(this.bn_ImportCancel);
            this.Controls.Add(this.bn_ImportOK);
            this.Controls.Add(this.bnQuery);
            this.Controls.Add(this.cbxSheet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnOpenFile);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRM2A1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FRM2A1-調班資料匯入";
            this.Load += new System.EventHandler(this.FRM2A1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMTABLEIMPORTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource tMTABLEIMPORTBindingSource;
        private dsAttTableAdapters.TMTABLE_IMPORTTableAdapter tMTABLE_IMPORTTableAdapter;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button bnOpenFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxSheet;
        private System.Windows.Forms.Button bnQuery;
        private System.Windows.Forms.Button bn_ImportOK;
        private System.Windows.Forms.Button bn_ImportCancel;
        private dsBas dsBas;
    }
}