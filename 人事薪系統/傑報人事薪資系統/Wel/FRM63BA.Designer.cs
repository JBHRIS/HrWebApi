namespace JBHR.Wel
{
	partial class FRM63BA
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxYYMM_B = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxYYMM_E = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxYEAR = new JBControls.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxNOBR_B = new JBControls.PopupTextBox();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.welDS = new JBHR.Wel.WelDS();
            this.textBoxNOBR_E = new JBControls.PopupTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.v_BASETableAdapter = new JBHR.Wel.WelDSTableAdapters.V_BASETableAdapter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFormat = new JBControls.ComboBox();
            this.medDS = new JBHR.Med.MedDS();
            this.yRFORMATBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yRFORMATTableAdapter = new JBHR.Med.MedDSTableAdapters.YRFORMATTableAdapter();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.welDS)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRFORMATBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "發放年月";
            // 
            // textBoxYYMM_B
            // 
            this.textBoxYYMM_B.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxYYMM_B.CaptionLabel = this.label3;
            this.textBoxYYMM_B.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxYYMM_B.DecimalPlace = 2;
            this.textBoxYYMM_B.IsEmpty = true;
            this.textBoxYYMM_B.Location = new System.Drawing.Point(62, 3);
            this.textBoxYYMM_B.Mask = "";
            this.textBoxYYMM_B.MaxLength = -1;
            this.textBoxYYMM_B.Name = "textBoxYYMM_B";
            this.textBoxYYMM_B.PasswordChar = '\0';
            this.textBoxYYMM_B.ReadOnly = false;
            this.textBoxYYMM_B.ShowCalendarButton = true;
            this.textBoxYYMM_B.Size = new System.Drawing.Size(57, 22);
            this.textBoxYYMM_B.TabIndex = 0;
            this.textBoxYYMM_B.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(192, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "～";
            // 
            // textBoxYYMM_E
            // 
            this.textBoxYYMM_E.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxYYMM_E.CaptionLabel = this.label1;
            this.textBoxYYMM_E.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxYYMM_E.DecimalPlace = 2;
            this.textBoxYYMM_E.IsEmpty = true;
            this.textBoxYYMM_E.Location = new System.Drawing.Point(215, 3);
            this.textBoxYYMM_E.Mask = "";
            this.textBoxYYMM_E.MaxLength = -1;
            this.textBoxYYMM_E.Name = "textBoxYYMM_E";
            this.textBoxYYMM_E.PasswordChar = '\0';
            this.textBoxYYMM_E.ReadOnly = false;
            this.textBoxYYMM_E.ShowCalendarButton = true;
            this.textBoxYYMM_E.Size = new System.Drawing.Size(57, 22);
            this.textBoxYYMM_E.TabIndex = 1;
            this.textBoxYYMM_E.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(192, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "～";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "員工編號";
            // 
            // textBoxYEAR
            // 
            this.textBoxYEAR.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxYEAR.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxYEAR.DecimalPlace = 2;
            this.textBoxYEAR.IsEmpty = true;
            this.textBoxYEAR.Location = new System.Drawing.Point(62, 31);
            this.textBoxYEAR.Mask = "";
            this.textBoxYEAR.MaxLength = 4;
            this.textBoxYEAR.Name = "textBoxYEAR";
            this.textBoxYEAR.PasswordChar = '\0';
            this.textBoxYEAR.ReadOnly = false;
            this.textBoxYEAR.ShowCalendarButton = true;
            this.textBoxYEAR.Size = new System.Drawing.Size(57, 22);
            this.textBoxYEAR.TabIndex = 2;
            this.textBoxYEAR.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "轉入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxNOBR_B
            // 
            this.textBoxNOBR_B.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxNOBR_B.CaptionLabel = null;
            this.textBoxNOBR_B.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxNOBR_B.DataSource = this.vBASEBindingSource;
            this.textBoxNOBR_B.DisplayMember = "name_c";
            this.textBoxNOBR_B.IsEmpty = true;
            this.textBoxNOBR_B.IsEmptyToQuery = true;
            this.textBoxNOBR_B.IsMustBeFound = true;
            this.textBoxNOBR_B.LabelText = "";
            this.textBoxNOBR_B.Location = new System.Drawing.Point(62, 59);
            this.textBoxNOBR_B.Name = "textBoxNOBR_B";
            this.textBoxNOBR_B.QueryFields = "name_e,name_p";
            this.textBoxNOBR_B.ReadOnly = false;
            this.textBoxNOBR_B.ShowDisplayName = true;
            this.textBoxNOBR_B.Size = new System.Drawing.Size(57, 22);
            this.textBoxNOBR_B.TabIndex = 3;
            this.textBoxNOBR_B.ValueMember = "nobr";
            this.textBoxNOBR_B.WhereCmd = "";
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.welDS;
            // 
            // welDS
            // 
            this.welDS.DataSetName = "WelDS";
            this.welDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBoxNOBR_E
            // 
            this.textBoxNOBR_E.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxNOBR_E.CaptionLabel = null;
            this.textBoxNOBR_E.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxNOBR_E.DataSource = this.vBASEBindingSource;
            this.textBoxNOBR_E.DisplayMember = "name_c";
            this.textBoxNOBR_E.IsEmpty = true;
            this.textBoxNOBR_E.IsEmptyToQuery = true;
            this.textBoxNOBR_E.IsMustBeFound = true;
            this.textBoxNOBR_E.LabelText = "";
            this.textBoxNOBR_E.Location = new System.Drawing.Point(215, 59);
            this.textBoxNOBR_E.Name = "textBoxNOBR_E";
            this.textBoxNOBR_E.QueryFields = "name_e,name_p";
            this.textBoxNOBR_E.ReadOnly = false;
            this.textBoxNOBR_E.ShowDisplayName = true;
            this.textBoxNOBR_E.Size = new System.Drawing.Size(57, 22);
            this.textBoxNOBR_E.TabIndex = 4;
            this.textBoxNOBR_E.ValueMember = "nobr";
            this.textBoxNOBR_E.WhereCmd = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 165);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(336, 23);
            this.progressBar1.TabIndex = 21;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxYYMM_B, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxYEAR, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxYYMM_E, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxNOBR_E, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxNOBR_B, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbFormat, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(319, 138);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "所得格式";
            // 
            // cbFormat
            // 
            this.cbFormat.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.cbFormat.BackColor = System.Drawing.Color.Transparent;
            this.cbFormat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cbFormat.DataSource = this.yRFORMATBindingSource;
            this.cbFormat.DisplayMember = "m_fmt_name";
            this.cbFormat.DropDownCount = 10;
            this.cbFormat.IsDisplayValueLabel = true;
            this.cbFormat.IsEmpty = false;
            this.cbFormat.Location = new System.Drawing.Point(62, 87);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.SelectedValue = "";
            this.cbFormat.Size = new System.Drawing.Size(124, 22);
            this.cbFormat.TabIndex = 5;
            this.cbFormat.ValueMember = "m_format";
            // 
            // medDS
            // 
            this.medDS.DataSetName = "MedDS";
            this.medDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.medDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // yRFORMATBindingSource
            // 
            this.yRFORMATBindingSource.DataMember = "YRFORMAT";
            this.yRFORMATBindingSource.DataSource = this.medDS;
            // 
            // yRFORMATTableAdapter
            // 
            this.yRFORMATTableAdapter.ClearBeforeFill = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(27, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "年度";
            // 
            // FRM63BA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 188);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM63BA";
            this.Load += new System.EventHandler(this.FRM63BA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.welDS)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRFORMATBindingSource)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label3;
		private JBControls.TextBox textBoxYYMM_B;
		private System.Windows.Forms.Label label1;
		private JBControls.TextBox textBoxYYMM_E;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
		private JBControls.TextBox textBoxYEAR;
		private System.Windows.Forms.Button button1;
        private JBControls.PopupTextBox textBoxNOBR_B;
        private JBControls.PopupTextBox textBoxNOBR_E;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private WelDS welDS;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private JBHR.Wel.WelDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private JBControls.ComboBox cbFormat;
        private Med.MedDS medDS;
        private System.Windows.Forms.BindingSource yRFORMATBindingSource;
        private Med.MedDSTableAdapters.YRFORMATTableAdapter yRFORMATTableAdapter;
        private System.Windows.Forms.Label label5;
	}
}