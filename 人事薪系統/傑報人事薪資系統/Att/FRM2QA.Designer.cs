namespace JBHR.Att
{
    partial class FRM2QA
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
            this.dsBas = new JBHR.Att.dsBas();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Att.dsBasTableAdapters.BASETableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.gpbType = new System.Windows.Forms.GroupBox();
            this.rdb3 = new System.Windows.Forms.RadioButton();
            this.rdb2 = new System.Windows.Forms.RadioButton();
            this.rdb1 = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtSeq = new JBControls.TextBox();
            this.txtYymm = new JBControls.TextBox();
            this.txtDDate = new JBControls.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ptxDeptB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ptxNobrB = new JBControls.PopupTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ptxNobrE = new JBControls.PopupTextBox();
            this.ptxDeptE = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.gpbType.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.gpbType);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.txtSeq);
            this.panel1.Controls.Add(this.txtYymm);
            this.panel1.Controls.Add(this.txtDDate);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 223);
            this.panel1.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "年月期別";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(33, 93);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 29;
            this.label16.Text = "假別代號";
            // 
            // gpbType
            // 
            this.gpbType.Controls.Add(this.rdb3);
            this.gpbType.Controls.Add(this.rdb2);
            this.gpbType.Controls.Add(this.rdb1);
            this.gpbType.Location = new System.Drawing.Point(92, 78);
            this.gpbType.Name = "gpbType";
            this.gpbType.Size = new System.Drawing.Size(261, 32);
            this.gpbType.TabIndex = 4;
            this.gpbType.TabStop = false;
            // 
            // rdb3
            // 
            this.rdb3.AutoSize = true;
            this.rdb3.Location = new System.Drawing.Point(152, 10);
            this.rdb3.Name = "rdb3";
            this.rdb3.Size = new System.Drawing.Size(47, 16);
            this.rdb3.TabIndex = 4;
            this.rdb3.Text = "補休";
            this.rdb3.UseVisualStyleBackColor = true;
            // 
            // rdb2
            // 
            this.rdb2.AutoSize = true;
            this.rdb2.Location = new System.Drawing.Point(84, 10);
            this.rdb2.Name = "rdb2";
            this.rdb2.Size = new System.Drawing.Size(47, 16);
            this.rdb2.TabIndex = 4;
            this.rdb2.Text = "特休";
            this.rdb2.UseVisualStyleBackColor = true;
            // 
            // rdb1
            // 
            this.rdb1.AutoSize = true;
            this.rdb1.Checked = true;
            this.rdb1.Location = new System.Drawing.Point(7, 10);
            this.rdb1.Name = "rdb1";
            this.rdb1.Size = new System.Drawing.Size(47, 16);
            this.rdb1.TabIndex = 4;
            this.rdb1.Text = "全部";
            this.rdb1.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(281, 185);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtSeq
            // 
            this.txtSeq.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSeq.CaptionLabel = null;
            this.txtSeq.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSeq.DecimalPlace = 2;
            this.txtSeq.IsEmpty = true;
            this.txtSeq.Location = new System.Drawing.Point(140, 118);
            this.txtSeq.Mask = "";
            this.txtSeq.MaxLength = -1;
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.PasswordChar = '\0';
            this.txtSeq.ReadOnly = false;
            this.txtSeq.ShowCalendarButton = true;
            this.txtSeq.Size = new System.Drawing.Size(22, 22);
            this.txtSeq.TabIndex = 6;
            this.txtSeq.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtYymm
            // 
            this.txtYymm.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYymm.CaptionLabel = null;
            this.txtYymm.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYymm.DecimalPlace = 2;
            this.txtYymm.IsEmpty = true;
            this.txtYymm.Location = new System.Drawing.Point(91, 118);
            this.txtYymm.Mask = "";
            this.txtYymm.MaxLength = -1;
            this.txtYymm.Name = "txtYymm";
            this.txtYymm.PasswordChar = '\0';
            this.txtYymm.ReadOnly = false;
            this.txtYymm.ShowCalendarButton = true;
            this.txtYymm.Size = new System.Drawing.Size(43, 22);
            this.txtYymm.TabIndex = 5;
            this.txtYymm.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtDDate
            // 
            this.txtDDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDDate.CaptionLabel = null;
            this.txtDDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDDate.DecimalPlace = 2;
            this.txtDDate.IsEmpty = true;
            this.txtDDate.Location = new System.Drawing.Point(91, 146);
            this.txtDDate.Mask = "0000/00/00";
            this.txtDDate.MaxLength = -1;
            this.txtDDate.Name = "txtDDate";
            this.txtDDate.PasswordChar = '\0';
            this.txtDDate.ReadOnly = false;
            this.txtDDate.ShowCalendarButton = true;
            this.txtDDate.Size = new System.Drawing.Size(71, 22);
            this.txtDDate.TabIndex = 7;
            this.txtDDate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(164, 185);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 9;
            this.btnDel.TabStop = false;
            this.btnDel.Text = "刪除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(59, 185);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 8;
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
            this.tableLayoutPanel1.Controls.Add(this.ptxDeptB, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobrB, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobrE, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.ptxDeptE, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(347, 60);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ptxDeptB
            // 
            this.ptxDeptB.FormattingEnabled = true;
            this.ptxDeptB.Location = new System.Drawing.Point(62, 31);
            this.ptxDeptB.Name = "ptxDeptB";
            this.ptxDeptB.Size = new System.Drawing.Size(121, 20);
            this.ptxDeptB.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "部門代碼";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
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
            this.ptxNobrB.Location = new System.Drawing.Point(62, 3);
            this.ptxNobrB.Name = "ptxNobrB";
            this.ptxNobrB.ReadOnly = false;
            this.ptxNobrB.ShowDisplayName = true;
            this.ptxNobrB.Size = new System.Drawing.Size(78, 22);
            this.ptxNobrB.TabIndex = 0;
            this.ptxNobrB.ValueMember = "nobr";
            this.ptxNobrB.WhereCmd = "";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(192, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "至";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "至";
            // 
            // ptxNobrE
            // 
            this.ptxNobrE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobrE.CaptionLabel = null;
            this.ptxNobrE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobrE.DataSource = this.bASEBindingSource;
            this.ptxNobrE.DisplayMember = "name_c";
            this.ptxNobrE.IsEmpty = true;
            this.ptxNobrE.IsEmptyToQuery = true;
            this.ptxNobrE.IsMustBeFound = true;
            this.ptxNobrE.LabelText = "";
            this.ptxNobrE.Location = new System.Drawing.Point(215, 3);
            this.ptxNobrE.Name = "ptxNobrE";
            this.ptxNobrE.ReadOnly = false;
            this.ptxNobrE.ShowDisplayName = true;
            this.ptxNobrE.Size = new System.Drawing.Size(78, 22);
            this.ptxNobrE.TabIndex = 1;
            this.ptxNobrE.ValueMember = "nobr";
            this.ptxNobrE.WhereCmd = "";
            // 
            // ptxDeptE
            // 
            this.ptxDeptE.FormattingEnabled = true;
            this.ptxDeptE.Location = new System.Drawing.Point(215, 31);
            this.ptxDeptE.Name = "ptxDeptE";
            this.ptxDeptE.Size = new System.Drawing.Size(121, 20);
            this.ptxDeptE.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "異動日期";
            // 
            // FRM2QA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 223);
            this.Controls.Add(this.panel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM2QA";
            this.Text = "FRM2PBA";
            this.Load += new System.EventHandler(this.FRM2O_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gpbType.ResumeLayout(false);
            this.gpbType.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private dsBas dsBas;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Att.dsBasTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox gpbType;
        private System.Windows.Forms.RadioButton rdb2;
        private System.Windows.Forms.RadioButton rdb1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private JBControls.PopupTextBox ptxNobrB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private JBControls.PopupTextBox ptxNobrE;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.RadioButton rdb3;
        private JBControls.TextBox txtDDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private JBControls.TextBox txtSeq;
        private JBControls.TextBox txtYymm;
        private System.Windows.Forms.ComboBox ptxDeptB;
        private System.Windows.Forms.ComboBox ptxDeptE;
    }
}