namespace HR_TOOL.JBQuery
{
    partial class QueryTableSettingForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settingIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.displayNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createManDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jqTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jqTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.settingIDDataGridViewTextBoxColumn,
            this.tableNameDataGridViewTextBoxColumn,
            this.displayNameDataGridViewTextBoxColumn,
            this.memoDataGridViewTextBoxColumn,
            this.createManDataGridViewTextBoxColumn,
            this.createDateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.jqTableBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(563, 224);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValidated);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserAddedRow);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // settingIDDataGridViewTextBoxColumn
            // 
            this.settingIDDataGridViewTextBoxColumn.DataPropertyName = "SettingID";
            this.settingIDDataGridViewTextBoxColumn.HeaderText = "SettingID";
            this.settingIDDataGridViewTextBoxColumn.Name = "settingIDDataGridViewTextBoxColumn";
            this.settingIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // tableNameDataGridViewTextBoxColumn
            // 
            this.tableNameDataGridViewTextBoxColumn.DataPropertyName = "TableName";
            this.tableNameDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.tableNameDataGridViewTextBoxColumn.HeaderText = "資料表名稱";
            this.tableNameDataGridViewTextBoxColumn.Name = "tableNameDataGridViewTextBoxColumn";
            this.tableNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tableNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // displayNameDataGridViewTextBoxColumn
            // 
            this.displayNameDataGridViewTextBoxColumn.DataPropertyName = "DisplayName";
            this.displayNameDataGridViewTextBoxColumn.HeaderText = "顯示名稱";
            this.displayNameDataGridViewTextBoxColumn.Name = "displayNameDataGridViewTextBoxColumn";
            // 
            // memoDataGridViewTextBoxColumn
            // 
            this.memoDataGridViewTextBoxColumn.DataPropertyName = "Memo";
            this.memoDataGridViewTextBoxColumn.HeaderText = "備註";
            this.memoDataGridViewTextBoxColumn.Name = "memoDataGridViewTextBoxColumn";
            // 
            // createManDataGridViewTextBoxColumn
            // 
            this.createManDataGridViewTextBoxColumn.DataPropertyName = "CreateMan";
            this.createManDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.createManDataGridViewTextBoxColumn.Name = "createManDataGridViewTextBoxColumn";
            // 
            // createDateDataGridViewTextBoxColumn
            // 
            this.createDateDataGridViewTextBoxColumn.DataPropertyName = "CreateDate";
            this.createDateDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.createDateDataGridViewTextBoxColumn.Name = "createDateDataGridViewTextBoxColumn";
            // 
            // jqTableBindingSource
            // 
            this.jqTableBindingSource.DataSource = typeof(HR_TOOL.jqTable);
            this.jqTableBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.jqTableBindingSource_AddingNew);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(175, 254);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "存檔";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(296, 254);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "離開";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // QueryTableSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 287);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridView1);
            this.Name = "QueryTableSettingForm";
            this.Text = "QueryTableSettingForm";
            this.Load += new System.EventHandler(this.QueryTableSettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jqTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource jqTableBindingSource;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn settingIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn tableNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createManDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
    }
}