namespace JBHR.Ins
{
	partial class FRM3FI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFileName = new JBControls.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtYYMM = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFA_IDNO = new JBControls.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEXP = new JBControls.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCOMP = new JBControls.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTYPE = new JBControls.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.iNSURTYPEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.insDS = new JBHR.Ins.InsDS();
            this.dataGridViewEx1 = new JBControls.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.iNSUR_TYPETableAdapter = new JBHR.Ins.InsDSTableAdapters.INSUR_TYPETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.iNSURTYPEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.insDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(376, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "…";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtFileName.CaptionLabel = this.label7;
            this.txtFileName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtFileName.DecimalPlace = 2;
            this.txtFileName.Enabled = false;
            this.txtFileName.IsEmpty = true;
            this.txtFileName.Location = new System.Drawing.Point(74, 12);
            this.txtFileName.Mask = "";
            this.txtFileName.MaxLength = -1;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.PasswordChar = '\0';
            this.txtFileName.ReadOnly = false;
            this.txtFileName.ShowCalendarButton = true;
            this.txtFileName.Size = new System.Drawing.Size(302, 22);
            this.txtFileName.TabIndex = 0;
            this.txtFileName.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(15, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "匯入檔案";
            // 
            // txtYYMM
            // 
            this.txtYYMM.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYYMM.CaptionLabel = this.label2;
            this.txtYYMM.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYYMM.DecimalPlace = 2;
            this.txtYYMM.Enabled = false;
            this.txtYYMM.IsEmpty = false;
            this.txtYYMM.Location = new System.Drawing.Point(74, 40);
            this.txtYYMM.Mask = "";
            this.txtYYMM.MaxLength = -1;
            this.txtYYMM.Name = "txtYYMM";
            this.txtYYMM.PasswordChar = '\0';
            this.txtYYMM.ReadOnly = false;
            this.txtYYMM.ShowCalendarButton = true;
            this.txtYYMM.Size = new System.Drawing.Size(59, 22);
            this.txtYYMM.TabIndex = 2;
            this.txtYYMM.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(39, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "年月";
            // 
            // cbFA_IDNO
            // 
            this.cbFA_IDNO.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.cbFA_IDNO.BackColor = System.Drawing.Color.Transparent;
            this.cbFA_IDNO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cbFA_IDNO.CaptionLabel = this.label1;
            this.cbFA_IDNO.DataSource = null;
            this.cbFA_IDNO.DropDownCount = 10;
            this.cbFA_IDNO.Enabled = false;
            this.cbFA_IDNO.IsDisplayValueLabel = true;
            this.cbFA_IDNO.IsEmpty = false;
            this.cbFA_IDNO.Location = new System.Drawing.Point(74, 68);
            this.cbFA_IDNO.Name = "cbFA_IDNO";
            this.cbFA_IDNO.SelectedValue = "";
            this.cbFA_IDNO.Size = new System.Drawing.Size(124, 22);
            this.cbFA_IDNO.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(15, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 43;
            this.label1.Text = "身份証號";
            // 
            // cbEXP
            // 
            this.cbEXP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.cbEXP.BackColor = System.Drawing.Color.Transparent;
            this.cbEXP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cbEXP.CaptionLabel = this.label3;
            this.cbEXP.DataSource = null;
            this.cbEXP.DropDownCount = 10;
            this.cbEXP.Enabled = false;
            this.cbEXP.IsDisplayValueLabel = true;
            this.cbEXP.IsEmpty = false;
            this.cbEXP.Location = new System.Drawing.Point(74, 96);
            this.cbEXP.Name = "cbEXP";
            this.cbEXP.SelectedValue = "";
            this.cbEXP.Size = new System.Drawing.Size(124, 22);
            this.cbEXP.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(15, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 45;
            this.label3.Text = "員工自付";
            // 
            // cbCOMP
            // 
            this.cbCOMP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.cbCOMP.BackColor = System.Drawing.Color.Transparent;
            this.cbCOMP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cbCOMP.CaptionLabel = this.label4;
            this.cbCOMP.DataSource = null;
            this.cbCOMP.DropDownCount = 10;
            this.cbCOMP.Enabled = false;
            this.cbCOMP.IsDisplayValueLabel = true;
            this.cbCOMP.IsEmpty = false;
            this.cbCOMP.Location = new System.Drawing.Point(74, 124);
            this.cbCOMP.Name = "cbCOMP";
            this.cbCOMP.SelectedValue = "";
            this.cbCOMP.Size = new System.Drawing.Size(124, 22);
            this.cbCOMP.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(15, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 47;
            this.label4.Text = "公司付擔";
            // 
            // cbTYPE
            // 
            this.cbTYPE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.cbTYPE.BackColor = System.Drawing.Color.Transparent;
            this.cbTYPE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cbTYPE.CaptionLabel = this.label5;
            this.cbTYPE.DataSource = this.iNSURTYPEBindingSource;
            this.cbTYPE.DisplayMember = "name";
            this.cbTYPE.DropDownCount = 10;
            this.cbTYPE.Enabled = false;
            this.cbTYPE.IsDisplayValueLabel = true;
            this.cbTYPE.IsEmpty = false;
            this.cbTYPE.Location = new System.Drawing.Point(74, 152);
            this.cbTYPE.Name = "cbTYPE";
            this.cbTYPE.SelectedValue = "";
            this.cbTYPE.Size = new System.Drawing.Size(124, 22);
            this.cbTYPE.TabIndex = 6;
            this.cbTYPE.ValueMember = "code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(15, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 49;
            this.label5.Text = "費用種類";
            // 
            // iNSURTYPEBindingSource
            // 
            this.iNSURTYPEBindingSource.DataMember = "INSUR_TYPE";
            this.iNSURTYPEBindingSource.DataSource = this.insDS;
            // 
            // insDS
            // 
            this.insDS.DataSetName = "InsDS";
            this.insDS.Locale = new System.Globalization.CultureInfo("");
            this.insDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.insDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.AllowUserToAddRows = false;
            this.dataGridViewEx1.AllowUserToDeleteRows = false;
            this.dataGridViewEx1.AllowUserToResizeRows = false;
            this.dataGridViewEx1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEx1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEx1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEx1.Location = new System.Drawing.Point(17, 180);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(385, 260);
            this.dataGridViewEx1.TabIndex = 50;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(327, 151);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "匯入";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // iNSUR_TYPETableAdapter
            // 
            this.iNSUR_TYPETableAdapter.ClearBeforeFill = true;
            // 
            // FRM3FI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 452);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridViewEx1);
            this.Controls.Add(this.cbTYPE);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbCOMP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbEXP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFA_IDNO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtYYMM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM3FI";
            this.Load += new System.EventHandler(this.FRM3FI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iNSURTYPEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.insDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Button button1;
		private JBControls.TextBox txtFileName;
        private System.Windows.Forms.Label label7;
		private JBControls.TextBox txtYYMM;
		private System.Windows.Forms.Label label2;
		private JBControls.ComboBox cbFA_IDNO;
		private System.Windows.Forms.Label label1;
		private JBControls.ComboBox cbEXP;
		private System.Windows.Forms.Label label3;
		private JBControls.ComboBox cbCOMP;
		private System.Windows.Forms.Label label4;
		private JBControls.ComboBox cbTYPE;
		private System.Windows.Forms.Label label5;
		private JBControls.DataGridView dataGridViewEx1;
		private System.Windows.Forms.Button button2;		
		private InsDS insDS;
		private System.Windows.Forms.BindingSource iNSURTYPEBindingSource;
		private JBHR.Ins.InsDSTableAdapters.INSUR_TYPETableAdapter iNSUR_TYPETableAdapter;
	}
}