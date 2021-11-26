namespace JBHR.Att
{
    partial class FRM21CA
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
            this.btnRun = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox2 = new JBControls.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxHoliB = new System.Windows.Forms.ComboBox();
            this.cbxHoliE = new System.Windows.Forms.ComboBox();
            this.cbxRoteB = new System.Windows.Forms.ComboBox();
            this.cbxRoteE = new System.Windows.Forms.ComboBox();
            this.cbxHoliCode = new System.Windows.Forms.ComboBox();
            this.cbxAtype = new System.Windows.Forms.ComboBox();
            this.hOLICDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.rOTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oTRATECDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oTHCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hOLICDTableAdapter = new JBHR.Att.dsAttTableAdapters.HOLICDTableAdapter();
            this.rOTETableAdapter = new JBHR.Att.dsAttTableAdapters.ROTETableAdapter();
            this.oTRATECDTableAdapter = new JBHR.Att.dsAttTableAdapters.OTRATECDTableAdapter();
            this.oTHCODETableAdapter = new JBHR.Att.dsAttTableAdapters.OTHCODETableAdapter();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hOLICDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oTRATECDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oTHCODEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(113, 175);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 8;
            this.btnRun.Text = "產生";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(283, 175);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxHoliB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxHoliE, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxRoteB, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxRoteE, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxHoliCode, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbxAtype, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(40, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(391, 144);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = null;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.DecimalPlace = 2;
            this.textBox2.IsEmpty = false;
            this.textBox2.Location = new System.Drawing.Point(248, 3);
            this.textBox2.Mask = "0000/00/00";
            this.textBox2.MaxLength = -1;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ReadOnly = false;
            this.textBox2.ShowCalendarButton = true;
            this.textBox2.Size = new System.Drawing.Size(67, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(225, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "至";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(225, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "至";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(51, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "日期";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(39, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "行事曆";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(51, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "班別";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "加班比率代碼";
            // 
            // textBox1
            // 
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = null;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.DecimalPlace = 2;
            this.textBox1.IsEmpty = false;
            this.textBox1.Location = new System.Drawing.Point(86, 3);
            this.textBox1.Mask = "0000/00/00";
            this.textBox1.MaxLength = -1;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = false;
            this.textBox1.ShowCalendarButton = true;
            this.textBox1.Size = new System.Drawing.Size(69, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(51, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "類別";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(225, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "至";
            // 
            // cbxHoliB
            // 
            this.cbxHoliB.FormattingEnabled = true;
            this.cbxHoliB.Location = new System.Drawing.Point(86, 31);
            this.cbxHoliB.Name = "cbxHoliB";
            this.cbxHoliB.Size = new System.Drawing.Size(121, 20);
            this.cbxHoliB.TabIndex = 2;
            // 
            // cbxHoliE
            // 
            this.cbxHoliE.FormattingEnabled = true;
            this.cbxHoliE.Location = new System.Drawing.Point(248, 31);
            this.cbxHoliE.Name = "cbxHoliE";
            this.cbxHoliE.Size = new System.Drawing.Size(121, 20);
            this.cbxHoliE.TabIndex = 3;
            // 
            // cbxRoteB
            // 
            this.cbxRoteB.FormattingEnabled = true;
            this.cbxRoteB.Location = new System.Drawing.Point(86, 57);
            this.cbxRoteB.Name = "cbxRoteB";
            this.cbxRoteB.Size = new System.Drawing.Size(121, 20);
            this.cbxRoteB.TabIndex = 4;
            // 
            // cbxRoteE
            // 
            this.cbxRoteE.FormattingEnabled = true;
            this.cbxRoteE.Location = new System.Drawing.Point(248, 57);
            this.cbxRoteE.Name = "cbxRoteE";
            this.cbxRoteE.Size = new System.Drawing.Size(121, 20);
            this.cbxRoteE.TabIndex = 5;
            // 
            // cbxHoliCode
            // 
            this.cbxHoliCode.FormattingEnabled = true;
            this.cbxHoliCode.Location = new System.Drawing.Point(86, 83);
            this.cbxHoliCode.Name = "cbxHoliCode";
            this.cbxHoliCode.Size = new System.Drawing.Size(121, 20);
            this.cbxHoliCode.TabIndex = 6;
            // 
            // cbxAtype
            // 
            this.cbxAtype.FormattingEnabled = true;
            this.cbxAtype.Location = new System.Drawing.Point(86, 109);
            this.cbxAtype.Name = "cbxAtype";
            this.cbxAtype.Size = new System.Drawing.Size(121, 20);
            this.cbxAtype.TabIndex = 7;
            // 
            // hOLICDBindingSource
            // 
            this.hOLICDBindingSource.DataMember = "HOLICD";
            this.hOLICDBindingSource.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rOTEBindingSource
            // 
            this.rOTEBindingSource.DataMember = "ROTE";
            this.rOTEBindingSource.DataSource = this.dsAtt;
            // 
            // oTRATECDBindingSource
            // 
            this.oTRATECDBindingSource.DataMember = "OTRATECD";
            this.oTRATECDBindingSource.DataSource = this.dsAtt;
            // 
            // oTHCODEBindingSource
            // 
            this.oTHCODEBindingSource.DataMember = "OTHCODE";
            this.oTHCODEBindingSource.DataSource = this.dsAtt;
            // 
            // hOLICDTableAdapter
            // 
            this.hOLICDTableAdapter.ClearBeforeFill = true;
            // 
            // rOTETableAdapter
            // 
            this.rOTETableAdapter.ClearBeforeFill = true;
            // 
            // oTRATECDTableAdapter
            // 
            this.oTRATECDTableAdapter.ClearBeforeFill = true;
            // 
            // oTHCODETableAdapter
            // 
            this.oTHCODETableAdapter.ClearBeforeFill = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(198, 175);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FRM21CA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 214);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRun);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM21CA";
            this.Text = "FRM21CA";
            this.Load += new System.EventHandler(this.FRM21CA_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hOLICDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oTRATECDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oTHCODEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private JBControls.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private JBControls.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource hOLICDBindingSource;
        private dsAttTableAdapters.HOLICDTableAdapter hOLICDTableAdapter;
        private System.Windows.Forms.BindingSource rOTEBindingSource;
        private dsAttTableAdapters.ROTETableAdapter rOTETableAdapter;
        private System.Windows.Forms.BindingSource oTRATECDBindingSource;
        private dsAttTableAdapters.OTRATECDTableAdapter oTRATECDTableAdapter;
        private System.Windows.Forms.BindingSource oTHCODEBindingSource;
        private dsAttTableAdapters.OTHCODETableAdapter oTHCODETableAdapter;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbxHoliB;
        private System.Windows.Forms.ComboBox cbxHoliE;
        private System.Windows.Forms.ComboBox cbxRoteB;
        private System.Windows.Forms.ComboBox cbxRoteE;
        private System.Windows.Forms.ComboBox cbxHoliCode;
        private System.Windows.Forms.ComboBox cbxAtype;
    }
}