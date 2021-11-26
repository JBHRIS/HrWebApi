namespace JBHR.Sys
{
	partial class FRMG14A
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
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBox2 = new JBControls.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sysDS = new JBHR.Sys.SysDS();
            this.sALADRTableAdapter = new JBHR.Sys.SysDSTableAdapters.SALADRTableAdapter();
            this.uPRGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.u_PRGTableAdapter = new JBHR.Sys.SysDSTableAdapters.U_PRGTableAdapter();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uPRGBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "鎖檔資料日期";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.maskedTextBox1.CaptionLabel = this.label1;
            this.maskedTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.maskedTextBox1.DecimalPlace = 2;
            this.maskedTextBox1.IsEmpty = true;
            this.maskedTextBox1.Location = new System.Drawing.Point(113, 25);
            this.maskedTextBox1.Mask = "0000/00/00";
            this.maskedTextBox1.MaxLength = -1;
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.PasswordChar = '\0';
            this.maskedTextBox1.ReadOnly = false;
            this.maskedTextBox1.Size = new System.Drawing.Size(66, 22);
            this.maskedTextBox1.TabIndex = 0;
            this.maskedTextBox1.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "至";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.maskedTextBox2.CaptionLabel = null;
            this.maskedTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.maskedTextBox2.DecimalPlace = 2;
            this.maskedTextBox2.IsEmpty = true;
            this.maskedTextBox2.Location = new System.Drawing.Point(208, 25);
            this.maskedTextBox2.Mask = "0000/00/00";
            this.maskedTextBox2.MaxLength = -1;
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.PasswordChar = '\0';
            this.maskedTextBox2.ReadOnly = false;
            this.maskedTextBox2.Size = new System.Drawing.Size(66, 22);
            this.maskedTextBox2.TabIndex = 1;
            this.maskedTextBox2.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "執行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(54, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "資料群組";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "SALADR";
            this.bindingSource1.DataSource = this.sysDS;
            // 
            // sysDS
            // 
            this.sysDS.DataSetName = "SysDS";
            this.sysDS.Locale = new System.Globalization.CultureInfo("");
            this.sysDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.sysDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sALADRTableAdapter
            // 
            this.sALADRTableAdapter.ClearBeforeFill = true;
            // 
            // uPRGBindingSource
            // 
            this.uPRGBindingSource.DataMember = "U_PRG";
            this.uPRGBindingSource.DataSource = this.sysDS;
            // 
            // u_PRGTableAdapter
            // 
            this.u_PRGTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(113, 62);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 20);
            this.comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(291, 62);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(130, 20);
            this.comboBox2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "至";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(269, 99);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(66, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FRMG14A
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(483, 141);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRMG14A";
            this.Text = "FRMG14A";
            this.Load += new System.EventHandler(this.FRMG14A_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uPRGBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private JBControls.TextBox maskedTextBox1;
		private System.Windows.Forms.Label label2;
		private JBControls.TextBox maskedTextBox2;
		private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.BindingSource bindingSource1;
		private SysDS sysDS;
		private JBHR.Sys.SysDSTableAdapters.SALADRTableAdapter sALADRTableAdapter;
		private System.Windows.Forms.BindingSource uPRGBindingSource;
		private JBHR.Sys.SysDSTableAdapters.U_PRGTableAdapter u_PRGTableAdapter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExit;
	}
}