namespace JBHR.Att
{
    partial class FRM231
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM231));
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMTABLEIMPORTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
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
            resources.ApplyResources(this.txtPath, "txtPath");
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            // 
            // bnOpenFile
            // 
            resources.ApplyResources(this.bnOpenFile, "bnOpenFile");
            this.bnOpenFile.Name = "bnOpenFile";
            this.bnOpenFile.UseVisualStyleBackColor = true;
            this.bnOpenFile.Click += new System.EventHandler(this.bnOpenFile_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbxSheet
            // 
            this.cbxSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSheet.FormattingEnabled = true;
            resources.ApplyResources(this.cbxSheet, "cbxSheet");
            this.cbxSheet.Name = "cbxSheet";
            // 
            // bnQuery
            // 
            resources.ApplyResources(this.bnQuery, "bnQuery");
            this.bnQuery.Name = "bnQuery";
            this.bnQuery.UseVisualStyleBackColor = true;
            this.bnQuery.Click += new System.EventHandler(this.bnQuery_Click);
            // 
            // bn_ImportOK
            // 
            resources.ApplyResources(this.bn_ImportOK, "bn_ImportOK");
            this.bn_ImportOK.Name = "bn_ImportOK";
            this.bn_ImportOK.UseVisualStyleBackColor = true;
            this.bn_ImportOK.Click += new System.EventHandler(this.bn_ImportOK_Click);
            // 
            // bn_ImportCancel
            // 
            resources.ApplyResources(this.bn_ImportCancel, "bn_ImportCancel");
            this.bn_ImportCancel.Name = "bn_ImportCancel";
            this.bn_ImportCancel.UseVisualStyleBackColor = true;
            this.bn_ImportCancel.Click += new System.EventHandler(this.bn_ImportCancel_Click);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Step = 1;
            // 
            // FRM231
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.bn_ImportCancel);
            this.Controls.Add(this.bn_ImportOK);
            this.Controls.Add(this.bnQuery);
            this.Controls.Add(this.cbxSheet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnOpenFile);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FRM231";
            this.Load += new System.EventHandler(this.FRM232_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMTABLEIMPORTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
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
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

