namespace JBHR.Wel
{
	partial class FRM62I
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSeq = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtYYMM = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileName = new JBControls.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridViewEx1 = new JBControls.DataGridView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cbFormat = new JBControls.ComboBox();
            this.yRFOMATBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.welDS = new JBHR.Wel.WelDS();
            this.cbSalcode = new JBControls.ComboBox();
            this.wCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbNobr = new JBControls.ComboBox();
            this.cbAmt = new JBControls.ComboBox();
            this.cbDAmt = new JBControls.ComboBox();
            this.wCODETableAdapter = new JBHR.Wel.WelDSTableAdapters.WCODETableAdapter();
            this.yRFOMATTableAdapter = new JBHR.Wel.WelDSTableAdapters.YRFOMATTableAdapter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRFOMATBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.welDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(289, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "福利代號";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(10, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "員工編號";
            // 
            // txtSeq
            // 
            this.txtSeq.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSeq.CaptionLabel = null;
            this.txtSeq.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSeq.DecimalPlace = 2;
            this.txtSeq.Enabled = false;
            this.txtSeq.IsEmpty = false;
            this.txtSeq.Location = new System.Drawing.Point(413, 40);
            this.txtSeq.Mask = "";
            this.txtSeq.MaxLength = -1;
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.PasswordChar = '\0';
            this.txtSeq.ReadOnly = false;
            this.txtSeq.Size = new System.Drawing.Size(35, 22);
            this.txtSeq.TabIndex = 6;
            this.txtSeq.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(10, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "扣繳稅額";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(313, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "格式";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(34, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "金額";
            // 
            // txtYYMM
            // 
            this.txtYYMM.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYYMM.CaptionLabel = this.label2;
            this.txtYYMM.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYYMM.DecimalPlace = 2;
            this.txtYYMM.Enabled = false;
            this.txtYYMM.IsEmpty = false;
            this.txtYYMM.Location = new System.Drawing.Point(348, 40);
            this.txtYYMM.Mask = "";
            this.txtYYMM.MaxLength = -1;
            this.txtYYMM.Name = "txtYYMM";
            this.txtYYMM.PasswordChar = '\0';
            this.txtYYMM.ReadOnly = false;
            this.txtYYMM.Size = new System.Drawing.Size(59, 22);
            this.txtYYMM.TabIndex = 5;
            this.txtYYMM.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(289, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "計薪年月";
            // 
            // txtFileName
            // 
            this.txtFileName.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtFileName.CaptionLabel = this.label7;
            this.txtFileName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtFileName.DecimalPlace = 2;
            this.txtFileName.Enabled = false;
            this.txtFileName.IsEmpty = true;
            this.txtFileName.Location = new System.Drawing.Point(69, 12);
            this.txtFileName.Mask = "";
            this.txtFileName.MaxLength = -1;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.PasswordChar = '\0';
            this.txtFileName.ReadOnly = false;
            this.txtFileName.Size = new System.Drawing.Size(403, 22);
            this.txtFileName.TabIndex = 0;
            this.txtFileName.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(10, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 31;
            this.label7.Text = "匯入檔案";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(470, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "…";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("標楷體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(502, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 78);
            this.button2.TabIndex = 9;
            this.button2.Text = "匯入";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.AllowUserToAddRows = false;
            this.dataGridViewEx1.AllowUserToDeleteRows = false;
            this.dataGridViewEx1.AllowUserToResizeRows = false;
            this.dataGridViewEx1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEx1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewEx1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEx1.Location = new System.Drawing.Point(12, 124);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(612, 316);
            this.dataGridViewEx1.TabIndex = 35;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // cbFormat
            // 
            this.cbFormat.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.cbFormat.BackColor = System.Drawing.Color.Transparent;
            this.cbFormat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cbFormat.CaptionLabel = this.label5;
            this.cbFormat.DataSource = this.yRFOMATBindingSource;
            this.cbFormat.DisplayMember = "name";
            this.cbFormat.DropDownCount = 10;
            this.cbFormat.Enabled = false;
            this.cbFormat.IsEmpty = false;
            this.cbFormat.Location = new System.Drawing.Point(348, 96);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.SelectedValue = "";
            this.cbFormat.Size = new System.Drawing.Size(124, 22);
            this.cbFormat.TabIndex = 8;
            this.cbFormat.ValueMember = "code";
            // 
            // yRFOMATBindingSource
            // 
            this.yRFOMATBindingSource.DataMember = "YRFOMAT";
            this.yRFOMATBindingSource.DataSource = this.welDS;
            // 
            // welDS
            // 
            this.welDS.DataSetName = "WelDS";
            this.welDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.welDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbSalcode
            // 
            this.cbSalcode.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.cbSalcode.BackColor = System.Drawing.Color.Transparent;
            this.cbSalcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cbSalcode.CaptionLabel = this.label3;
            this.cbSalcode.DataSource = this.wCODEBindingSource;
            this.cbSalcode.DisplayMember = "w_name";
            this.cbSalcode.DropDownCount = 10;
            this.cbSalcode.Enabled = false;
            this.cbSalcode.IsEmpty = false;
            this.cbSalcode.Location = new System.Drawing.Point(348, 68);
            this.cbSalcode.Name = "cbSalcode";
            this.cbSalcode.SelectedValue = "";
            this.cbSalcode.Size = new System.Drawing.Size(124, 22);
            this.cbSalcode.TabIndex = 7;
            this.cbSalcode.ValueMember = "w_code";
            // 
            // wCODEBindingSource
            // 
            this.wCODEBindingSource.DataMember = "WCODE";
            this.wCODEBindingSource.DataSource = this.welDS;
            // 
            // cbNobr
            // 
            this.cbNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.cbNobr.BackColor = System.Drawing.Color.Transparent;
            this.cbNobr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cbNobr.CaptionLabel = this.label1;
            this.cbNobr.DataSource = null;
            this.cbNobr.DropDownCount = 10;
            this.cbNobr.Enabled = false;
            this.cbNobr.IsEmpty = false;
            this.cbNobr.Location = new System.Drawing.Point(69, 40);
            this.cbNobr.Name = "cbNobr";
            this.cbNobr.SelectedValue = "";
            this.cbNobr.Size = new System.Drawing.Size(124, 22);
            this.cbNobr.TabIndex = 2;
            // 
            // cbAmt
            // 
            this.cbAmt.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.cbAmt.BackColor = System.Drawing.Color.Transparent;
            this.cbAmt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cbAmt.CaptionLabel = this.label4;
            this.cbAmt.DataSource = null;
            this.cbAmt.DropDownCount = 10;
            this.cbAmt.Enabled = false;
            this.cbAmt.IsEmpty = false;
            this.cbAmt.Location = new System.Drawing.Point(69, 68);
            this.cbAmt.Name = "cbAmt";
            this.cbAmt.SelectedValue = "";
            this.cbAmt.Size = new System.Drawing.Size(124, 22);
            this.cbAmt.TabIndex = 3;
            // 
            // cbDAmt
            // 
            this.cbDAmt.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.cbDAmt.BackColor = System.Drawing.Color.Transparent;
            this.cbDAmt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cbDAmt.CaptionLabel = this.label6;
            this.cbDAmt.DataSource = null;
            this.cbDAmt.DropDownCount = 10;
            this.cbDAmt.Enabled = false;
            this.cbDAmt.IsEmpty = false;
            this.cbDAmt.Location = new System.Drawing.Point(69, 96);
            this.cbDAmt.Name = "cbDAmt";
            this.cbDAmt.SelectedValue = "";
            this.cbDAmt.Size = new System.Drawing.Size(124, 22);
            this.cbDAmt.TabIndex = 4;
            // 
            // wCODETableAdapter
            // 
            this.wCODETableAdapter.ClearBeforeFill = true;
            // 
            // yRFOMATTableAdapter
            // 
            this.yRFOMATTableAdapter.ClearBeforeFill = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FRM62I
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 452);
            this.Controls.Add(this.cbDAmt);
            this.Controls.Add(this.cbAmt);
            this.Controls.Add(this.cbNobr);
            this.Controls.Add(this.dataGridViewEx1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbSalcode);
            this.Controls.Add(this.txtSeq);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbFormat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtYYMM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM62I";
            this.Load += new System.EventHandler(this.FRM62I_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRFOMATBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.welDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private JBControls.TextBox txtSeq;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private JBControls.TextBox txtYYMM;
		private System.Windows.Forms.Label label2;
		private JBControls.TextBox txtFileName;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private JBControls.DataGridView dataGridViewEx1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
		private JBControls.ComboBox cbFormat;
        private JBControls.ComboBox cbSalcode;
		private JBControls.ComboBox cbNobr;
		private JBControls.ComboBox cbAmt;
		private JBControls.ComboBox cbDAmt;
		private WelDS welDS;
		private System.Windows.Forms.BindingSource wCODEBindingSource;
		private JBHR.Wel.WelDSTableAdapters.WCODETableAdapter wCODETableAdapter;
		private System.Windows.Forms.BindingSource yRFOMATBindingSource;
		private JBHR.Wel.WelDSTableAdapters.YRFOMATTableAdapter yRFOMATTableAdapter;
		private System.Windows.Forms.ErrorProvider errorProvider1;
	}
}