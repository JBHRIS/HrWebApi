namespace JBHR.Med
{
    partial class FRM71N1_T
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonTrans = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPayDateE = new JBControls.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxYYMM_E = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPayDateB = new JBControls.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxYYMM_B = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEmp = new System.Windows.Forms.Button();
            this.radCheckedDropDownList1 = new Telerik.WinControls.UI.RadCheckedDropDownList();
            this.label3 = new System.Windows.Forms.Label();
            this.radCheckedDropDownList2 = new Telerik.WinControls.UI.RadCheckedDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedDropDownList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedDropDownList2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(175, 151);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 8;
            this.buttonClose.Text = "離開";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonTrans
            // 
            this.buttonTrans.Location = new System.Drawing.Point(94, 151);
            this.buttonTrans.Name = "buttonTrans";
            this.buttonTrans.Size = new System.Drawing.Size(75, 23);
            this.buttonTrans.TabIndex = 7;
            this.buttonTrans.Text = "轉入";
            this.buttonTrans.UseVisualStyleBackColor = true;
            this.buttonTrans.Click += new System.EventHandler(this.buttonTrans_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(59, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 57;
            this.label8.Text = "格式";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(35, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 52;
            this.label4.Text = "員工編號";
            // 
            // txtPayDateE
            // 
            this.txtPayDateE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtPayDateE.CaptionLabel = this.label10;
            this.txtPayDateE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPayDateE.DecimalPlace = 2;
            this.txtPayDateE.IsEmpty = true;
            this.txtPayDateE.Location = new System.Drawing.Point(223, 40);
            this.txtPayDateE.Mask = "0000/00/00";
            this.txtPayDateE.MaxLength = 6;
            this.txtPayDateE.Name = "txtPayDateE";
            this.txtPayDateE.PasswordChar = '\0';
            this.txtPayDateE.ReadOnly = false;
            this.txtPayDateE.ShowCalendarButton = true;
            this.txtPayDateE.Size = new System.Drawing.Size(70, 22);
            this.txtPayDateE.TabIndex = 3;
            this.txtPayDateE.ValidType = JBControls.TextBox.EValidType.Date;
            this.txtPayDateE.Validated += new System.EventHandler(this.txtPayDateE_Validated);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(200, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 50;
            this.label10.Text = "至";
            // 
            // textBoxYYMM_E
            // 
            this.textBoxYYMM_E.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxYYMM_E.CaptionLabel = this.label2;
            this.textBoxYYMM_E.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxYYMM_E.DecimalPlace = 2;
            this.textBoxYYMM_E.IsEmpty = true;
            this.textBoxYYMM_E.Location = new System.Drawing.Point(223, 12);
            this.textBoxYYMM_E.Mask = "";
            this.textBoxYYMM_E.MaxLength = 6;
            this.textBoxYYMM_E.Name = "textBoxYYMM_E";
            this.textBoxYYMM_E.PasswordChar = '\0';
            this.textBoxYYMM_E.ReadOnly = false;
            this.textBoxYYMM_E.ShowCalendarButton = true;
            this.textBoxYYMM_E.Size = new System.Drawing.Size(52, 22);
            this.textBoxYYMM_E.TabIndex = 1;
            this.textBoxYYMM_E.ValidType = JBControls.TextBox.EValidType.String;
            this.textBoxYYMM_E.Validated += new System.EventHandler(this.textBoxYYMM_E_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(200, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 51;
            this.label2.Text = "至";
            // 
            // txtPayDateB
            // 
            this.txtPayDateB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtPayDateB.CaptionLabel = this.label9;
            this.txtPayDateB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPayDateB.DecimalPlace = 2;
            this.txtPayDateB.IsEmpty = true;
            this.txtPayDateB.Location = new System.Drawing.Point(94, 40);
            this.txtPayDateB.Mask = "0000/00/00";
            this.txtPayDateB.MaxLength = 6;
            this.txtPayDateB.Name = "txtPayDateB";
            this.txtPayDateB.PasswordChar = '\0';
            this.txtPayDateB.ReadOnly = false;
            this.txtPayDateB.ShowCalendarButton = true;
            this.txtPayDateB.Size = new System.Drawing.Size(67, 22);
            this.txtPayDateB.TabIndex = 2;
            this.txtPayDateB.ValidType = JBControls.TextBox.EValidType.Date;
            this.txtPayDateB.Validated += new System.EventHandler(this.txtPayDateB_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(35, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 48;
            this.label9.Text = "發放日期";
            // 
            // textBoxYYMM_B
            // 
            this.textBoxYYMM_B.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxYYMM_B.CaptionLabel = this.label1;
            this.textBoxYYMM_B.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxYYMM_B.DecimalPlace = 2;
            this.textBoxYYMM_B.IsEmpty = true;
            this.textBoxYYMM_B.Location = new System.Drawing.Point(94, 12);
            this.textBoxYYMM_B.Mask = "";
            this.textBoxYYMM_B.MaxLength = 6;
            this.textBoxYYMM_B.Name = "textBoxYYMM_B";
            this.textBoxYYMM_B.PasswordChar = '\0';
            this.textBoxYYMM_B.ReadOnly = false;
            this.textBoxYYMM_B.ShowCalendarButton = true;
            this.textBoxYYMM_B.Size = new System.Drawing.Size(49, 22);
            this.textBoxYYMM_B.TabIndex = 0;
            this.textBoxYYMM_B.ValidType = JBControls.TextBox.EValidType.String;
            this.textBoxYYMM_B.Validated += new System.EventHandler(this.textBoxYYMM_B_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(35, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 49;
            this.label1.Text = "發放年月";
            // 
            // buttonEmp
            // 
            this.buttonEmp.Location = new System.Drawing.Point(94, 70);
            this.buttonEmp.Name = "buttonEmp";
            this.buttonEmp.Size = new System.Drawing.Size(75, 23);
            this.buttonEmp.TabIndex = 4;
            this.buttonEmp.Text = "(0)";
            this.buttonEmp.UseVisualStyleBackColor = true;
            // 
            // radCheckedDropDownList1
            // 
            this.radCheckedDropDownList1.Location = new System.Drawing.Point(94, 125);
            this.radCheckedDropDownList1.Name = "radCheckedDropDownList1";
            this.radCheckedDropDownList1.ShowCheckAllItems = true;
            this.radCheckedDropDownList1.Size = new System.Drawing.Size(255, 20);
            this.radCheckedDropDownList1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(59, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 57;
            this.label3.Text = "公司";
            // 
            // radCheckedDropDownList2
            // 
            this.radCheckedDropDownList2.Location = new System.Drawing.Point(94, 99);
            this.radCheckedDropDownList2.Name = "radCheckedDropDownList2";
            this.radCheckedDropDownList2.ShowCheckAllItems = true;
            this.radCheckedDropDownList2.Size = new System.Drawing.Size(255, 20);
            this.radCheckedDropDownList2.TabIndex = 5;
            // 
            // FRM71N1_T
            // 
            this.ClientSize = new System.Drawing.Size(361, 188);
            this.Controls.Add(this.radCheckedDropDownList2);
            this.Controls.Add(this.radCheckedDropDownList1);
            this.Controls.Add(this.buttonEmp);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonTrans);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPayDateE);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxYYMM_E);
            this.Controls.Add(this.txtPayDateB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxYYMM_B);
            this.Controls.Add(this.label1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM71N1_T";
            this.Load += new System.EventHandler(this.FRM71N1_T_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedDropDownList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedDropDownList2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonTrans;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private JBControls.TextBox txtPayDateE;
        private System.Windows.Forms.Label label10;
        private JBControls.TextBox textBoxYYMM_E;
        private System.Windows.Forms.Label label2;
        private JBControls.TextBox txtPayDateB;
        private System.Windows.Forms.Label label9;
        private JBControls.TextBox textBoxYYMM_B;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEmp;
        private Telerik.WinControls.UI.RadCheckedDropDownList radCheckedDropDownList1;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadCheckedDropDownList radCheckedDropDownList2;
    }
}
