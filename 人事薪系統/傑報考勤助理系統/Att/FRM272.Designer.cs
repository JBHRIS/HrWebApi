namespace JBHR.Att
{
    partial class FRM272
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.txtGotoDate = new JBControls.TextBox();
            this.btnGoto = new System.Windows.Forms.Button();
            this.btnPrevMonth = new System.Windows.Forms.Button();
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxDept = new System.Windows.Forms.ComboBox();
            this.dEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBas = new JBHR.Att.dsBas();
            this.dataGridView1 = new JBControls.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.nOBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAMECDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEPTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tEL1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gSMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aTTBAKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblAdate = new System.Windows.Forms.Label();
            this.aTTBAKTableAdapter = new JBHR.Att.dsAttTableAdapters.ATTBAKTableAdapter();
            this.dEPTTableAdapter = new JBHR.Att.dsBasTableAdapters.DEPTTableAdapter();
            this.chkDept = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTTBAKBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "星期日";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(76, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 24);
            this.button2.TabIndex = 1;
            this.button2.Text = "星期一";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(152, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 24);
            this.button3.TabIndex = 2;
            this.button3.Text = "星期二";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(228, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 24);
            this.button4.TabIndex = 3;
            this.button4.Text = "星期三";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(304, 1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 24);
            this.button5.TabIndex = 4;
            this.button5.Text = "星期四";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(380, 1);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 24);
            this.button6.TabIndex = 5;
            this.button6.Text = "星期五";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(456, 1);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 24);
            this.button7.TabIndex = 6;
            this.button7.Text = "星期六";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // txtGotoDate
            // 
            this.txtGotoDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtGotoDate.CaptionLabel = null;
            this.txtGotoDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtGotoDate.DecimalPlace = 2;            
            this.txtGotoDate.IsEmpty = true;
            this.txtGotoDate.Location = new System.Drawing.Point(203, 385);
            this.txtGotoDate.Mask = "";
            this.txtGotoDate.MaxLength = -1;
            this.txtGotoDate.Name = "txtGotoDate";
            this.txtGotoDate.PasswordChar = '\0';
            this.txtGotoDate.ReadOnly = false;
            this.txtGotoDate.Size = new System.Drawing.Size(100, 22);
            this.txtGotoDate.TabIndex = 51;
            this.txtGotoDate.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // btnGoto
            // 
            this.btnGoto.Location = new System.Drawing.Point(309, 385);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(60, 23);
            this.btnGoto.TabIndex = 52;
            this.btnGoto.Text = "到";
            this.btnGoto.UseVisualStyleBackColor = true;
            this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
            // 
            // btnPrevMonth
            // 
            this.btnPrevMonth.Location = new System.Drawing.Point(386, 385);
            this.btnPrevMonth.Name = "btnPrevMonth";
            this.btnPrevMonth.Size = new System.Drawing.Size(60, 23);
            this.btnPrevMonth.TabIndex = 53;
            this.btnPrevMonth.Text = "上月";
            this.btnPrevMonth.UseVisualStyleBackColor = true;
            this.btnPrevMonth.Click += new System.EventHandler(this.btnPrevMonth_Click);
            // 
            // btnNextMonth
            // 
            this.btnNextMonth.Location = new System.Drawing.Point(462, 385);
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.Size = new System.Drawing.Size(60, 23);
            this.btnNextMonth.TabIndex = 54;
            this.btnNextMonth.Text = "下月";
            this.btnNextMonth.UseVisualStyleBackColor = true;
            this.btnNextMonth.Click += new System.EventHandler(this.btnNextMonth_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(530, 348);
            this.tableLayoutPanel1.TabIndex = 55;
            // 
            // cbxDept
            // 
            this.cbxDept.DataSource = this.dEPTBindingSource;
            this.cbxDept.DisplayMember = "D_NAME";
            this.cbxDept.FormattingEnabled = true;
            this.cbxDept.Location = new System.Drawing.Point(7, 386);
            this.cbxDept.Name = "cbxDept";
            this.cbxDept.Size = new System.Drawing.Size(121, 20);
            this.cbxDept.TabIndex = 56;
            this.cbxDept.ValueMember = "D_NO";
            this.cbxDept.SelectedIndexChanged += new System.EventHandler(this.cbxHolicd_SelectedIndexChanged);
            // 
            // dEPTBindingSource
            // 
            this.dEPTBindingSource.DataMember = "DEPT";
            this.dEPTBindingSource.DataSource = this.dsBas;
            // 
            // dsBas
            // 
            this.dsBas.DataSetName = "dsBas";
            this.dsBas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.nOBRDataGridViewTextBoxColumn,
            this.nAMECDataGridViewTextBoxColumn,
            this.dEPTDataGridViewTextBoxColumn,
            this.tEL1DataGridViewTextBoxColumn,
            this.gSMDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.aTTBAKBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(7, 448);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(524, 130);
            this.dataGridView1.TabIndex = 58;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "NOBR";
            this.Column1.FillWeight = 60F;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Text = "刪除";
            this.Column1.UseColumnTextForButtonValue = true;
            this.Column1.Width = 60;
            // 
            // nOBRDataGridViewTextBoxColumn
            // 
            this.nOBRDataGridViewTextBoxColumn.DataPropertyName = "NOBR";
            this.nOBRDataGridViewTextBoxColumn.HeaderText = "員工編號";
            this.nOBRDataGridViewTextBoxColumn.Name = "nOBRDataGridViewTextBoxColumn";
            this.nOBRDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nAMECDataGridViewTextBoxColumn
            // 
            this.nAMECDataGridViewTextBoxColumn.DataPropertyName = "NAME_C";
            this.nAMECDataGridViewTextBoxColumn.HeaderText = "員工姓名";
            this.nAMECDataGridViewTextBoxColumn.Name = "nAMECDataGridViewTextBoxColumn";
            this.nAMECDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dEPTDataGridViewTextBoxColumn
            // 
            this.dEPTDataGridViewTextBoxColumn.DataPropertyName = "DEPT";
            this.dEPTDataGridViewTextBoxColumn.HeaderText = "部門編號";
            this.dEPTDataGridViewTextBoxColumn.Name = "dEPTDataGridViewTextBoxColumn";
            this.dEPTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tEL1DataGridViewTextBoxColumn
            // 
            this.tEL1DataGridViewTextBoxColumn.DataPropertyName = "TEL1";
            this.tEL1DataGridViewTextBoxColumn.HeaderText = "住家電話";
            this.tEL1DataGridViewTextBoxColumn.Name = "tEL1DataGridViewTextBoxColumn";
            this.tEL1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gSMDataGridViewTextBoxColumn
            // 
            this.gSMDataGridViewTextBoxColumn.DataPropertyName = "GSM";
            this.gSMDataGridViewTextBoxColumn.HeaderText = "行動電話";
            this.gSMDataGridViewTextBoxColumn.Name = "gSMDataGridViewTextBoxColumn";
            this.gSMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aTTBAKBindingSource
            // 
            this.aTTBAKBindingSource.DataMember = "ATTBAK";
            this.aTTBAKBindingSource.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(462, 419);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 23);
            this.btnAdd.TabIndex = 59;
            this.btnAdd.Text = "加入";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblAdate
            // 
            this.lblAdate.AutoSize = true;
            this.lblAdate.Location = new System.Drawing.Point(390, 425);
            this.lblAdate.Name = "lblAdate";
            this.lblAdate.Size = new System.Drawing.Size(65, 12);
            this.lblAdate.TabIndex = 60;
            this.lblAdate.Text = "0000/00/00";
            // 
            // aTTBAKTableAdapter
            // 
            this.aTTBAKTableAdapter.ClearBeforeFill = true;
            // 
            // dEPTTableAdapter
            // 
            this.dEPTTableAdapter.ClearBeforeFill = true;
            // 
            // chkDept
            // 
            this.chkDept.AutoSize = true;
            this.chkDept.Checked = true;
            this.chkDept.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDept.Location = new System.Drawing.Point(134, 388);
            this.chkDept.Name = "chkDept";
            this.chkDept.Size = new System.Drawing.Size(48, 16);
            this.chkDept.TabIndex = 61;
            this.chkDept.Text = "全部";
            this.chkDept.UseVisualStyleBackColor = true;
            this.chkDept.CheckedChanged += new System.EventHandler(this.chkDept_CheckedChanged);
            // 
            // FRM272
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 590);
            this.Controls.Add(this.chkDept);
            this.Controls.Add(this.lblAdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbxDept);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnNextMonth);
            this.Controls.Add(this.btnPrevMonth);
            this.Controls.Add(this.btnGoto);
            this.Controls.Add(this.txtGotoDate);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM272";
            this.Text = "FRM272";
            this.Load += new System.EventHandler(this.FRM2E_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTTBAKBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private JBControls.TextBox txtGotoDate;
        private System.Windows.Forms.Button btnGoto;
        private System.Windows.Forms.Button btnPrevMonth;
        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbxDept;
        private JBControls.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblAdate;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource aTTBAKBindingSource;
        private JBHR.Att.dsAttTableAdapters.ATTBAKTableAdapter aTTBAKTableAdapter;
        private dsBas dsBas;
        private System.Windows.Forms.BindingSource dEPTBindingSource;
        private JBHR.Att.dsBasTableAdapters.DEPTTableAdapter dEPTTableAdapter;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAMECDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEPTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tEL1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gSMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox chkDept;

    }
}