namespace JBHR.Att
{
    partial class FRM24T
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
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtTime = new JBControls.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtDateE = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDateB = new JBControls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeptE = new JBControls.PopupTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDeptB = new JBControls.PopupTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNobrE = new JBControls.PopupTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNobrB = new JBControls.PopupTextBox();
            this.bsDEPT = new System.Windows.Forms.BindingSource(this.components);
            this.dsBas = new JBHR.Att.dsBas();
            this.bsBASE = new System.Windows.Forms.BindingSource(this.components);
            this.taBASE = new JBHR.Att.dsBasTableAdapters.BASETableAdapter();
            this.taDEPT = new JBHR.Att.dsBasTableAdapters.DEPTTableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDEPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBASE)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnCheck, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtTime, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDateE, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDateB, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDeptE, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDeptB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNobrE, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNobrB, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(484, 142);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btnCheck, 4);
            this.btnCheck.Location = new System.Drawing.Point(204, 115);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "檢查";
            this.btnCheck.UseVisualStyleBackColor = true;
            // 
            // txtTime
            // 
            this.txtTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTime.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtTime.CaptionLabel = null;
            this.txtTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;            
            this.txtTime.IsEmpty = false;
            this.txtTime.Location = new System.Drawing.Point(62, 87);
            this.txtTime.Mask = "";
            this.txtTime.Name = "txtTime";
            this.txtTime.PasswordChar = '\0';
            this.txtTime.ReadOnly = false;
            this.txtTime.Size = new System.Drawing.Size(50, 22);
            this.txtTime.TabIndex = 6;
            this.txtTime.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "相距時間";
            // 
            // txtDateE
            // 
            this.txtDateE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDateE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDateE.CaptionLabel = null;
            this.txtDateE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;            
            this.txtDateE.IsEmpty = false;
            this.txtDateE.Location = new System.Drawing.Point(286, 59);
            this.txtDateE.Mask = "0000/00/00";
            this.txtDateE.Name = "txtDateE";
            this.txtDateE.PasswordChar = '\0';
            this.txtDateE.ReadOnly = false;
            this.txtDateE.Size = new System.Drawing.Size(100, 22);
            this.txtDateE.TabIndex = 5;
            this.txtDateE.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(263, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "至";
            // 
            // txtDateB
            // 
            this.txtDateB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDateB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDateB.CaptionLabel = null;
            this.txtDateB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;            
            this.txtDateB.IsEmpty = false;
            this.txtDateB.Location = new System.Drawing.Point(62, 59);
            this.txtDateB.Mask = "0000/00/00";
            this.txtDateB.Name = "txtDateB";
            this.txtDateB.PasswordChar = '\0';
            this.txtDateB.ReadOnly = false;
            this.txtDateB.Size = new System.Drawing.Size(100, 22);
            this.txtDateB.TabIndex = 4;
            this.txtDateB.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "出勤日期";
            // 
            // txtDeptE
            // 
            this.txtDeptE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDeptE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDeptE.CaptionLabel = null;
            this.txtDeptE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDeptE.DataSource = this.bsDEPT;
            this.txtDeptE.DisplayMember = "d_name";            
            this.txtDeptE.IsEmpty = false;
            //this.txtDeptE.IsQuery = true;
            this.txtDeptE.LabelText = "";
            this.txtDeptE.Location = new System.Drawing.Point(286, 31);
            this.txtDeptE.Name = "txtDeptE";
            this.txtDeptE.QueryFields = "d_no,d_name";
            this.txtDeptE.ReadOnly = false;
            //this.txtDeptE.ShowExceptionMsg = true;
            this.txtDeptE.Size = new System.Drawing.Size(100, 22);
            this.txtDeptE.TabIndex = 3;
            this.txtDeptE.ValueMember = "d_no";
            this.txtDeptE.WhereCmd = "";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "至";
            // 
            // txtDeptB
            // 
            this.txtDeptB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDeptB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDeptB.CaptionLabel = null;
            this.txtDeptB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDeptB.DataSource = this.bsDEPT;
            this.txtDeptB.DisplayMember = "d_name";            
            this.txtDeptB.IsEmpty = false;
            //this.txtDeptB.IsQuery = true;
            this.txtDeptB.LabelText = "";
            this.txtDeptB.Location = new System.Drawing.Point(62, 31);
            this.txtDeptB.Name = "txtDeptB";
            this.txtDeptB.QueryFields = "d_no,d_name";
            this.txtDeptB.ReadOnly = false;
            //this.txtDeptB.ShowExceptionMsg = true;
            this.txtDeptB.Size = new System.Drawing.Size(100, 22);
            this.txtDeptB.TabIndex = 2;
            this.txtDeptB.ValueMember = "d_no";
            this.txtDeptB.WhereCmd = "";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "部門代碼";
            // 
            // txtNobrE
            // 
            this.txtNobrE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNobrE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtNobrE.CaptionLabel = null;
            this.txtNobrE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNobrE.DataSource = this.bsBASE;
            this.txtNobrE.DisplayMember = "name_c";            
            this.txtNobrE.IsEmpty = false;
            //this.txtNobrE.IsQuery = true;
            this.txtNobrE.LabelText = "";
            this.txtNobrE.Location = new System.Drawing.Point(286, 3);
            this.txtNobrE.Name = "txtNobrE";
            this.txtNobrE.QueryFields = "nobr,name_c,name_e,name_p";
            this.txtNobrE.ReadOnly = false;
            //this.txtNobrE.ShowExceptionMsg = true;
            this.txtNobrE.Size = new System.Drawing.Size(100, 22);
            this.txtNobrE.TabIndex = 1;
            this.txtNobrE.ValueMember = "nobr";
            this.txtNobrE.WhereCmd = "";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "至";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "員工編號";
            // 
            // txtNobrB
            // 
            this.txtNobrB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNobrB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtNobrB.CaptionLabel = null;
            this.txtNobrB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNobrB.DataSource = this.bsBASE;
            this.txtNobrB.DisplayMember = "name_c";
            //this.txtNobrB.ErrorProvider = this.errorProvider;
            this.txtNobrB.IsEmpty = false;
            //this.txtNobrB.IsQuery = true;
            this.txtNobrB.LabelText = "";
            this.txtNobrB.Location = new System.Drawing.Point(62, 3);
            this.txtNobrB.Name = "txtNobrB";
            this.txtNobrB.QueryFields = "nobr,name_c,name_e,name_p";
            this.txtNobrB.ReadOnly = false;
            //this.txtNobrB.ShowExceptionMsg = true;
            this.txtNobrB.Size = new System.Drawing.Size(100, 22);
            this.txtNobrB.TabIndex = 0;
            this.txtNobrB.ValueMember = "nobr";
            this.txtNobrB.WhereCmd = "";
            // 
            // bsDEPT
            // 
            this.bsDEPT.DataMember = "DEPT";
            this.bsDEPT.DataSource = this.dsBas;
            // 
            // dsBas
            // 
            this.dsBas.DataSetName = "dsBas";
            this.dsBas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bsBASE
            // 
            this.bsBASE.DataMember = "BASE";
            this.bsBASE.DataSource = this.dsBas;
            // 
            // taBASE
            // 
            this.taBASE.ClearBeforeFill = true;
            // 
            // taDEPT
            // 
            this.taDEPT.ClearBeforeFill = true;
            // 
            // FRM24T
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 142);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM24T";
            this.Text = "FRM24T";
            this.Load += new System.EventHandler(this.FRM24T_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDEPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBASE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCheck;
        private JBControls.TextBox txtTime;
        private System.Windows.Forms.Label label7;
        private JBControls.TextBox txtDateE;
        private System.Windows.Forms.Label label6;
        private JBControls.TextBox txtDateB;
        private System.Windows.Forms.Label label5;
        private JBControls.PopupTextBox txtDeptE;
        private System.Windows.Forms.Label label4;
        private JBControls.PopupTextBox txtDeptB;
        private System.Windows.Forms.Label label3;
        private JBControls.PopupTextBox txtNobrE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private JBControls.PopupTextBox txtNobrB;
        private dsBas dsBas;
        private System.Windows.Forms.BindingSource bsBASE;
        private JBHR.Att.dsBasTableAdapters.BASETableAdapter taBASE;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.BindingSource bsDEPT;
        private JBHR.Att.dsBasTableAdapters.DEPTTableAdapter taDEPT;
    }
}