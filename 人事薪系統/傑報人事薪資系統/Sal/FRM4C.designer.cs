namespace JBHR.Sal
{
    partial class FRM4C
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDeptE = new System.Windows.Forms.ComboBox();
            this.txtDeptB = new System.Windows.Forms.ComboBox();
            this.txtSeq = new JBControls.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDateE = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtYear = new JBControls.TextBox();
            this.txtMonth = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNobrB = new JBControls.PopupTextBox();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fRM4CDS = new JBHR.Sal.FRM4CDS();
            this.txtNobrE = new JBControls.PopupTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDateB = new JBControls.TextBox();
            this.dEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCalc = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfig = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.trpState = new System.Windows.Forms.ToolStripStatusLabel();
            this.BW = new System.ComponentModel.BackgroundWorker();
            this.dEPTTableAdapter = new JBHR.Sal.FRM4CDSTableAdapters.DEPTTableAdapter();
            this.v_BASETableAdapter = new JBHR.Sal.FRM4CDSTableAdapters.V_BASETableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fRM4CDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel1.Controls.Add(this.txtDeptE, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDeptB, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSeq, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDateE, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNobrB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNobrE, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDateB, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(454, 111);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtDeptE
            // 
            this.txtDeptE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtDeptE.DropDownWidth = 150;
            this.txtDeptE.FormattingEnabled = true;
            this.txtDeptE.Location = new System.Drawing.Point(289, 59);
            this.txtDeptE.Name = "txtDeptE";
            this.txtDeptE.Size = new System.Drawing.Size(150, 20);
            this.txtDeptE.TabIndex = 5;
            // 
            // txtDeptB
            // 
            this.txtDeptB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtDeptB.DropDownWidth = 150;
            this.txtDeptB.FormattingEnabled = true;
            this.txtDeptB.Location = new System.Drawing.Point(96, 59);
            this.txtDeptB.Name = "txtDeptB";
            this.txtDeptB.Size = new System.Drawing.Size(150, 20);
            this.txtDeptB.TabIndex = 4;
            // 
            // txtSeq
            // 
            this.txtSeq.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSeq.CaptionLabel = null;
            this.txtSeq.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSeq.DecimalPlace = 2;
            this.txtSeq.IsEmpty = true;
            this.txtSeq.Location = new System.Drawing.Point(289, 3);
            this.txtSeq.Mask = "";
            this.txtSeq.MaxLength = -1;
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.PasswordChar = '\0';
            this.txtSeq.ReadOnly = false;
            this.txtSeq.ShowCalendarButton = true;
            this.txtSeq.Size = new System.Drawing.Size(40, 22);
            this.txtSeq.TabIndex = 1;
            this.txtSeq.ValidType = JBControls.TextBox.EValidType.String;
            this.txtSeq.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(254, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "期別";
            this.label8.Visible = false;
            // 
            // txtDateE
            // 
            this.txtDateE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDateE.CaptionLabel = null;
            this.txtDateE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDateE.DecimalPlace = 2;
            this.txtDateE.IsEmpty = true;
            this.txtDateE.Location = new System.Drawing.Point(289, 85);
            this.txtDateE.Mask = "0000/00/00";
            this.txtDateE.MaxLength = -1;
            this.txtDateE.Name = "txtDateE";
            this.txtDateE.PasswordChar = '\0';
            this.txtDateE.ReadOnly = false;
            this.txtDateE.ShowCalendarButton = true;
            this.txtDateE.Size = new System.Drawing.Size(67, 22);
            this.txtDateE.TabIndex = 7;
            this.txtDateE.ValidType = JBControls.TextBox.EValidType.Date;
            this.txtDateE.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "考勤區間";
            this.label4.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txtYear);
            this.flowLayoutPanel1.Controls.Add(this.txtMonth);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(93, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(111, 28);
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
            this.txtYear.MaxLength = 4;
            this.txtYear.Name = "txtYear";
            this.txtYear.PasswordChar = '\0';
            this.txtYear.ReadOnly = false;
            this.txtYear.ShowCalendarButton = true;
            this.txtYear.Size = new System.Drawing.Size(47, 22);
            this.txtYear.TabIndex = 0;
            this.txtYear.ValidType = JBControls.TextBox.EValidType.String;
            this.txtYear.Validated += new System.EventHandler(this.txtYear_Validated);
            // 
            // txtMonth
            // 
            this.txtMonth.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtMonth.CaptionLabel = null;
            this.txtMonth.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMonth.DecimalPlace = 2;
            this.txtMonth.IsEmpty = true;
            this.txtMonth.Location = new System.Drawing.Point(56, 3);
            this.txtMonth.Mask = "";
            this.txtMonth.MaxLength = 2;
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.PasswordChar = '\0';
            this.txtMonth.ReadOnly = false;
            this.txtMonth.ShowCalendarButton = true;
            this.txtMonth.Size = new System.Drawing.Size(33, 22);
            this.txtMonth.TabIndex = 1;
            this.txtMonth.ValidType = JBControls.TextBox.EValidType.String;
            this.txtMonth.Validated += new System.EventHandler(this.txtYear_Validated);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "薪資年月";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "員工編號";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "至";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "部門代碼";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(266, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "至";
            // 
            // txtNobrB
            // 
            this.txtNobrB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtNobrB.CaptionLabel = null;
            this.txtNobrB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNobrB.DataSource = this.vBASEBindingSource;
            this.txtNobrB.DisplayMember = "name_c";
            this.txtNobrB.IsEmpty = true;
            this.txtNobrB.IsEmptyToQuery = true;
            this.txtNobrB.IsMustBeFound = true;
            this.txtNobrB.LabelText = "";
            this.txtNobrB.Location = new System.Drawing.Point(96, 31);
            this.txtNobrB.Name = "txtNobrB";
            this.txtNobrB.QueryFields = "name_e,name_p";
            this.txtNobrB.ReadOnly = false;
            this.txtNobrB.ShowDisplayName = true;
            this.txtNobrB.Size = new System.Drawing.Size(75, 22);
            this.txtNobrB.TabIndex = 2;
            this.txtNobrB.ValueMember = "nobr";
            this.txtNobrB.WhereCmd = "";
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.fRM4CDS;
            // 
            // fRM4CDS
            // 
            this.fRM4CDS.DataSetName = "FRM4CDS";
            this.fRM4CDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtNobrE
            // 
            this.txtNobrE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtNobrE.CaptionLabel = null;
            this.txtNobrE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNobrE.DataSource = this.vBASEBindingSource;
            this.txtNobrE.DisplayMember = "name_c";
            this.txtNobrE.IsEmpty = true;
            this.txtNobrE.IsEmptyToQuery = true;
            this.txtNobrE.IsMustBeFound = true;
            this.txtNobrE.LabelText = "";
            this.txtNobrE.Location = new System.Drawing.Point(289, 31);
            this.txtNobrE.Name = "txtNobrE";
            this.txtNobrE.QueryFields = "name_e,name_p";
            this.txtNobrE.ReadOnly = false;
            this.txtNobrE.ShowDisplayName = true;
            this.txtNobrE.Size = new System.Drawing.Size(75, 22);
            this.txtNobrE.TabIndex = 3;
            this.txtNobrE.ValueMember = "nobr";
            this.txtNobrE.WhereCmd = "";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(266, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "至";
            this.label5.Visible = false;
            // 
            // txtDateB
            // 
            this.txtDateB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDateB.CaptionLabel = null;
            this.txtDateB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDateB.DecimalPlace = 2;
            this.txtDateB.IsEmpty = true;
            this.txtDateB.Location = new System.Drawing.Point(96, 85);
            this.txtDateB.Mask = "0000/00/00";
            this.txtDateB.MaxLength = -1;
            this.txtDateB.Name = "txtDateB";
            this.txtDateB.PasswordChar = '\0';
            this.txtDateB.ReadOnly = false;
            this.txtDateB.ShowCalendarButton = true;
            this.txtDateB.Size = new System.Drawing.Size(67, 22);
            this.txtDateB.TabIndex = 6;
            this.txtDateB.ValidType = JBControls.TextBox.EValidType.Date;
            this.txtDateB.Visible = false;
            this.txtDateB.Validated += new System.EventHandler(this.txtDateB_Validated);
            // 
            // dEPTBindingSource
            // 
            this.dEPTBindingSource.DataMember = "DEPT";
            this.dEPTBindingSource.DataSource = this.fRM4CDS;
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(129, 139);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 0;
            this.btnCalc.Text = "計算";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfig);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.btnCalc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 203);
            this.panel1.TabIndex = 3;
            // 
            // btnConfig
            // 
            this.btnConfig.BackgroundImage = global::JBHR.Properties.Resources.Settings_icon;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(441, 139);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(25, 23);
            this.btnConfig.TabIndex = 2;
            this.btnConfig.TabStop = false;
            this.btnConfig.Tag = "FRM4C";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(280, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.TabStop = false;
            this.button2.Text = "離開";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar1,
            this.toolStripStatusLabel1,
            this.trpState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 177);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(479, 26);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar1
            // 
            this.progressBar1.AutoToolTip = true;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(150, 20);
            this.progressBar1.Tag = "";
            this.progressBar1.ToolTipText = "123";
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
            // BW
            // 
            this.BW.WorkerReportsProgress = true;
            this.BW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.BW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.BW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // dEPTTableAdapter
            // 
            this.dEPTTableAdapter.ClearBeforeFill = true;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // FRM4C
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 203);
            this.Controls.Add(this.panel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM4C";
            this.Text = "FRM4C";
            this.Load += new System.EventHandler(this.FRM4C_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fRM4CDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private JBControls.TextBox txtYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Panel panel1;
        private JBControls.PopupTextBox txtNobrB;
        private JBControls.PopupTextBox txtNobrE;
		private FRM4CDS fRM4CDS;
		private System.Windows.Forms.BindingSource dEPTBindingSource;
        private JBHR.Sal.FRM4CDSTableAdapters.DEPTTableAdapter dEPTTableAdapter;
		private System.ComponentModel.BackgroundWorker BW;
		private System.Windows.Forms.BindingSource vBASEBindingSource;
		private JBHR.Sal.FRM4CDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel trpState;
        private System.Windows.Forms.Button button2;
        private JBControls.TextBox txtMonth;
        private System.Windows.Forms.Label label4;
        private JBControls.TextBox txtDateB;
        private JBControls.TextBox txtDateE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private JBControls.TextBox txtSeq;
        private System.Windows.Forms.ComboBox txtDeptB;
        private System.Windows.Forms.ComboBox txtDeptE;
        private System.Windows.Forms.Button btnConfig;
    }
}