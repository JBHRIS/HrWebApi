namespace JBHR.Att
{
    partial class FRM2IiA
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
            this.dEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBas = new JBHR.Att.dsBas();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dEPTBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bASEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.rOTEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.rOTEBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Att.dsBasTableAdapters.BASETableAdapter();
            this.dEPTTableAdapter = new JBHR.Att.dsBasTableAdapters.DEPTTableAdapter();
            this.rOTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rOTETableAdapter = new JBHR.Att.dsAttTableAdapters.ROTETableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtYear = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ptxNobrB = new JBControls.PopupTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ptxNobrE = new JBControls.PopupTextBox();
            this.txtDdate = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ptxDeptB = new System.Windows.Forms.ComboBox();
            this.ptxDeptE = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxWorkYearEndDate = new JBControls.TextBox();
            this.hCODEBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.hCODEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.hCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hCODETableAdapter = new JBHR.Att.dsAttTableAdapters.HCODETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hCODEBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hCODEBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hCODEBindingSource)).BeginInit();
            this.SuspendLayout();
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
            // bASEBindingSource
            // 
            this.bASEBindingSource.DataMember = "BASE";
            this.bASEBindingSource.DataSource = this.dsBas;
            // 
            // dEPTBindingSource1
            // 
            this.dEPTBindingSource1.DataMember = "DEPT";
            this.dEPTBindingSource1.DataSource = this.dsBas;
            // 
            // bASEBindingSource1
            // 
            this.bASEBindingSource1.DataMember = "BASE";
            this.bASEBindingSource1.DataSource = this.dsBas;
            // 
            // rOTEBindingSource1
            // 
            this.rOTEBindingSource1.DataMember = "ROTE";
            this.rOTEBindingSource1.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rOTEBindingSource2
            // 
            this.rOTEBindingSource2.DataMember = "ROTE";
            this.rOTEBindingSource2.DataSource = this.dsAtt;
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // dEPTTableAdapter
            // 
            this.dEPTTableAdapter.ClearBeforeFill = true;
            // 
            // rOTEBindingSource
            // 
            this.rOTEBindingSource.DataMember = "ROTE";
            this.rOTEBindingSource.DataSource = this.dsAtt;
            // 
            // rOTETableAdapter
            // 
            this.rOTETableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtYear);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 216);
            this.panel1.TabIndex = 24;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(286, 181);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(169, 181);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 3;
            this.btnDel.TabStop = false;
            this.btnDel.Text = "刪除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, -185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "員工編號";
            // 
            // txtYear
            // 
            this.txtYear.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYear.CaptionLabel = null;
            this.txtYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYear.DecimalPlace = 2;
            this.txtYear.IsEmpty = true;
            this.txtYear.Location = new System.Drawing.Point(110, 17);
            this.txtYear.Mask = "";
            this.txtYear.MaxLength = -1;
            this.txtYear.Name = "txtYear";
            this.txtYear.PasswordChar = '\0';
            this.txtYear.ReadOnly = false;
            this.txtYear.ShowCalendarButton = true;
            this.txtYear.Size = new System.Drawing.Size(59, 29);
            this.txtYear.TabIndex = 0;
            this.txtYear.ValidType = JBControls.TextBox.EValidType.String;
            this.txtYear.Leave += new System.EventHandler(this.txtYear_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "特休年度";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(64, 181);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "新增";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobrB, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobrE, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDdate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ptxDeptB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ptxDeptE, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxWorkYearEndDate, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 45);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(380, 114);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "部門代碼";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "員工編號";
            // 
            // ptxNobrB
            // 
            this.ptxNobrB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobrB.CaptionLabel = null;
            this.ptxNobrB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobrB.DataSource = this.bASEBindingSource;
            this.ptxNobrB.DisplayMember = "name_c";
            this.ptxNobrB.IsEmpty = true;
            this.ptxNobrB.IsEmptyToQuery = true;
            this.ptxNobrB.IsMustBeFound = true;
            this.ptxNobrB.LabelText = "";
            this.ptxNobrB.Location = new System.Drawing.Point(143, 3);
            this.ptxNobrB.Name = "ptxNobrB";
            this.ptxNobrB.ReadOnly = false;
            this.ptxNobrB.ShowDisplayName = true;
            this.ptxNobrB.Size = new System.Drawing.Size(59, 22);
            this.ptxNobrB.TabIndex = 2;
            this.ptxNobrB.ValueMember = "nobr";
            this.ptxNobrB.WhereCmd = "";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(273, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "至";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(273, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "至";
            // 
            // ptxNobrE
            // 
            this.ptxNobrE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobrE.CaptionLabel = null;
            this.ptxNobrE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobrE.DataSource = this.bASEBindingSource1;
            this.ptxNobrE.DisplayMember = "name_c";
            this.ptxNobrE.IsEmpty = true;
            this.ptxNobrE.IsEmptyToQuery = true;
            this.ptxNobrE.IsMustBeFound = true;
            this.ptxNobrE.LabelText = "";
            this.ptxNobrE.Location = new System.Drawing.Point(305, 3);
            this.ptxNobrE.Name = "ptxNobrE";
            this.ptxNobrE.ReadOnly = false;
            this.ptxNobrE.ShowDisplayName = true;
            this.ptxNobrE.Size = new System.Drawing.Size(59, 22);
            this.ptxNobrE.TabIndex = 3;
            this.ptxNobrE.ValueMember = "nobr";
            this.ptxNobrE.WhereCmd = "";
            // 
            // txtDdate
            // 
            this.txtDdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDdate.CaptionLabel = null;
            this.txtDdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDdate.DecimalPlace = 2;
            this.txtDdate.IsEmpty = true;
            this.txtDdate.Location = new System.Drawing.Point(143, 58);
            this.txtDdate.Mask = "0000/00/00";
            this.txtDdate.MaxLength = -1;
            this.txtDdate.Name = "txtDdate";
            this.txtDdate.PasswordChar = '\0';
            this.txtDdate.ReadOnly = false;
            this.txtDdate.ShowCalendarButton = true;
            this.txtDdate.Size = new System.Drawing.Size(71, 29);
            this.txtDdate.TabIndex = 6;
            this.txtDdate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "異動截止日";
            // 
            // ptxDeptB
            // 
            this.ptxDeptB.DropDownWidth = 121;
            this.ptxDeptB.FormattingEnabled = true;
            this.ptxDeptB.Location = new System.Drawing.Point(143, 31);
            this.ptxDeptB.Name = "ptxDeptB";
            this.ptxDeptB.Size = new System.Drawing.Size(121, 26);
            this.ptxDeptB.TabIndex = 4;
            // 
            // ptxDeptE
            // 
            this.ptxDeptE.FormattingEnabled = true;
            this.ptxDeptE.Location = new System.Drawing.Point(305, 31);
            this.ptxDeptE.Name = "ptxDeptE";
            this.ptxDeptE.Size = new System.Drawing.Size(121, 26);
            this.ptxDeptE.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 18);
            this.label8.TabIndex = 2;
            this.label8.Text = "特休年資截止日";
            // 
            // textBoxWorkYearEndDate
            // 
            this.textBoxWorkYearEndDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxWorkYearEndDate.CaptionLabel = null;
            this.textBoxWorkYearEndDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxWorkYearEndDate.DecimalPlace = 2;
            this.textBoxWorkYearEndDate.IsEmpty = true;
            this.textBoxWorkYearEndDate.Location = new System.Drawing.Point(143, 87);
            this.textBoxWorkYearEndDate.Mask = "0000/00/00";
            this.textBoxWorkYearEndDate.MaxLength = -1;
            this.textBoxWorkYearEndDate.Name = "textBoxWorkYearEndDate";
            this.textBoxWorkYearEndDate.PasswordChar = '\0';
            this.textBoxWorkYearEndDate.ReadOnly = false;
            this.textBoxWorkYearEndDate.ShowCalendarButton = true;
            this.textBoxWorkYearEndDate.Size = new System.Drawing.Size(71, 29);
            this.textBoxWorkYearEndDate.TabIndex = 4;
            this.textBoxWorkYearEndDate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // hCODEBindingSource2
            // 
            this.hCODEBindingSource2.DataMember = "HCODE";
            this.hCODEBindingSource2.DataSource = this.dsAtt;
            // 
            // hCODEBindingSource1
            // 
            this.hCODEBindingSource1.DataMember = "HCODE";
            this.hCODEBindingSource1.DataSource = this.dsAtt;
            // 
            // hCODEBindingSource
            // 
            this.hCODEBindingSource.DataMember = "HCODE";
            this.hCODEBindingSource.DataSource = this.dsAtt;
            // 
            // hCODETableAdapter
            // 
            this.hCODETableAdapter.ClearBeforeFill = true;
            // 
            // FRM2IiA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 216);
            this.Controls.Add(this.panel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM2IiA";
            this.Text = "FRM2IiA";
            this.Load += new System.EventHandler(this.FRM2O_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hCODEBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hCODEBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hCODEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private dsBas dsBas;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Att.dsBasTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.BindingSource bASEBindingSource1;
        private System.Windows.Forms.BindingSource dEPTBindingSource;
        private JBHR.Att.dsBasTableAdapters.DEPTTableAdapter dEPTTableAdapter;
        private System.Windows.Forms.BindingSource dEPTBindingSource1;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource rOTEBindingSource;
        private JBHR.Att.dsAttTableAdapters.ROTETableAdapter rOTETableAdapter;
        private System.Windows.Forms.BindingSource rOTEBindingSource1;
        private System.Windows.Forms.BindingSource rOTEBindingSource2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private JBControls.PopupTextBox ptxNobrB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private JBControls.PopupTextBox ptxNobrE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.BindingSource hCODEBindingSource;
        private JBHR.Att.dsAttTableAdapters.HCODETableAdapter hCODETableAdapter;
        private System.Windows.Forms.BindingSource hCODEBindingSource1;
        private System.Windows.Forms.BindingSource hCODEBindingSource2;
        private JBControls.TextBox txtDdate;
        private System.Windows.Forms.Label label7;
        private JBControls.TextBox txtYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ptxDeptB;
        private System.Windows.Forms.ComboBox ptxDeptE;
        private System.Windows.Forms.Label label8;
        private JBControls.TextBox textBoxWorkYearEndDate;
    }
}