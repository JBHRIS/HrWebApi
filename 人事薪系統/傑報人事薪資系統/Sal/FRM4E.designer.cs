namespace JBHR.Sal
{
    partial class FRM4E
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
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.bASEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.baseDS = new JBHR.Sal.BaseDS();
            this.dEPTBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.dEPTTableAdapter = new JBHR.Sal.BaseDSTableAdapters.DEPTTableAdapter();
            this.BW = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.trpState = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCalc = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtYear = new JBControls.TextBox();
            this.txtMonth = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ptxDeptE = new System.Windows.Forms.ComboBox();
            this.ptxDeptB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ptxNobrB = new JBControls.PopupTextBox();
            this.ptxNobrE = new JBControls.PopupTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bASEBindingSource
            // 
            this.bASEBindingSource.DataMember = "BASE";
            this.bASEBindingSource.DataSource = this.salaryDS;
            // 
            // salaryDS
            // 
            this.salaryDS.DataSetName = "SalaryDS";
            this.salaryDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.salaryDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bASEBindingSource1
            // 
            this.bASEBindingSource1.DataMember = "BASE";
            this.bASEBindingSource1.DataSource = this.salaryDS;
            // 
            // dEPTBindingSource
            // 
            this.dEPTBindingSource.DataMember = "DEPT";
            this.dEPTBindingSource.DataSource = this.baseDS;
            // 
            // baseDS
            // 
            this.baseDS.DataSetName = "BaseDS";
            this.baseDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.baseDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dEPTBindingSource1
            // 
            this.dEPTBindingSource1.DataMember = "DEPT";
            this.dEPTBindingSource1.DataSource = this.baseDS;
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // dEPTTableAdapter
            // 
            this.dEPTTableAdapter.ClearBeforeFill = true;
            // 
            // BW
            // 
            this.BW.WorkerReportsProgress = true;
            this.BW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_DoWork);
            this.BW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BW_ProgressChanged);
            this.BW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.trpState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 162);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(448, 26);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AutoToolTip = true;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(150, 20);
            this.toolStripProgressBar1.Tag = "";
            this.toolStripProgressBar1.ToolTipText = "123";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 21);
            this.toolStripStatusLabel1.Text = " | ";
            // 
            // trpState
            // 
            this.trpState.Name = "trpState";
            this.trpState.Size = new System.Drawing.Size(31, 21);
            this.trpState.Text = "等待";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnCalc);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 162);
            this.panel1.TabIndex = 18;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(251, 121);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 22);
            this.btnExit.TabIndex = 1;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(125, 121);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 22);
            this.btnCalc.TabIndex = 0;
            this.btnCalc.Text = "計算";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 169F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ptxDeptE, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.ptxDeptB, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobrB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobrE, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(31, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(386, 87);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txtYear);
            this.flowLayoutPanel1.Controls.Add(this.txtMonth);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(59, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(110, 28);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // txtYear
            // 
            this.txtYear.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYear.CaptionLabel = null;
            this.txtYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYear.DecimalPlace = 2;
            this.txtYear.IsEmpty = true;
            this.txtYear.Location = new System.Drawing.Point(3, 3);
            this.txtYear.Mask = "";
            this.txtYear.MaxLength = -1;
            this.txtYear.Name = "txtYear";
            this.txtYear.PasswordChar = '\0';
            this.txtYear.ReadOnly = false;
            this.txtYear.ShowCalendarButton = true;
            this.txtYear.Size = new System.Drawing.Size(50, 22);
            this.txtYear.TabIndex = 0;
            this.txtYear.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtMonth
            // 
            this.txtMonth.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtMonth.CaptionLabel = null;
            this.txtMonth.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMonth.DecimalPlace = 2;
            this.txtMonth.IsEmpty = true;
            this.txtMonth.Location = new System.Drawing.Point(59, 3);
            this.txtMonth.Mask = "";
            this.txtMonth.MaxLength = -1;
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.PasswordChar = '\0';
            this.txtMonth.ReadOnly = false;
            this.txtMonth.ShowCalendarButton = true;
            this.txtMonth.Size = new System.Drawing.Size(40, 22);
            this.txtMonth.TabIndex = 1;
            this.txtMonth.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "保險年月";
            // 
            // ptxDeptE
            // 
            this.ptxDeptE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ptxDeptE.DropDownWidth = 150;
            this.ptxDeptE.FormattingEnabled = true;
            this.ptxDeptE.Location = new System.Drawing.Point(220, 59);
            this.ptxDeptE.Name = "ptxDeptE";
            this.ptxDeptE.Size = new System.Drawing.Size(150, 20);
            this.ptxDeptE.TabIndex = 4;
            // 
            // ptxDeptB
            // 
            this.ptxDeptB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ptxDeptB.DropDownWidth = 150;
            this.ptxDeptB.FormattingEnabled = true;
            this.ptxDeptB.Location = new System.Drawing.Point(62, 59);
            this.ptxDeptB.Name = "ptxDeptB";
            this.ptxDeptB.Size = new System.Drawing.Size(129, 20);
            this.ptxDeptB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "員工編號";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "至";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "部門代碼";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "至";
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
            this.ptxNobrB.Location = new System.Drawing.Point(62, 31);
            this.ptxNobrB.Name = "ptxNobrB";
            this.ptxNobrB.ReadOnly = false;
            this.ptxNobrB.ShowDisplayName = true;
            this.ptxNobrB.Size = new System.Drawing.Size(63, 22);
            this.ptxNobrB.TabIndex = 1;
            this.ptxNobrB.ValueMember = "nobr";
            this.ptxNobrB.WhereCmd = "";
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
            this.ptxNobrE.Location = new System.Drawing.Point(220, 31);
            this.ptxNobrE.Name = "ptxNobrE";
            this.ptxNobrE.ReadOnly = false;
            this.ptxNobrE.ShowDisplayName = true;
            this.ptxNobrE.Size = new System.Drawing.Size(63, 22);
            this.ptxNobrE.TabIndex = 2;
            this.ptxNobrE.ValueMember = "nobr";
            this.ptxNobrE.WhereCmd = "";
            // 
            // FRM4E
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(448, 188);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM4E";
            this.Text = "FRM4E";
            this.Load += new System.EventHandler(this.FRM4E_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.BindingSource bASEBindingSource1;
        private BaseDS baseDS;
        private System.Windows.Forms.BindingSource dEPTBindingSource;
        private JBHR.Sal.BaseDSTableAdapters.DEPTTableAdapter dEPTTableAdapter;
        private System.Windows.Forms.BindingSource dEPTBindingSource1;
        private System.ComponentModel.BackgroundWorker BW;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel trpState;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private JBControls.TextBox txtYear;
        private JBControls.TextBox txtMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ptxDeptE;
        private System.Windows.Forms.ComboBox ptxDeptB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private JBControls.PopupTextBox ptxNobrB;
        private JBControls.PopupTextBox ptxNobrE;
    }
}