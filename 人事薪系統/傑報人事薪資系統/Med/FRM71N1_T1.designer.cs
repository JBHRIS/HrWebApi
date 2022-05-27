namespace JBHR.Med
{
    partial class FRM71N1_T1
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
            this.textBoxYYMM = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEmp = new System.Windows.Forms.Button();
            this.radCheckedDropDownList1 = new Telerik.WinControls.UI.RadCheckedDropDownList();
            this.label3 = new System.Windows.Forms.Label();
            this.radCheckedDropDownList2 = new Telerik.WinControls.UI.RadCheckedDropDownList();
            this.textBoxSEQ = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedDropDownList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedDropDownList2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(175, 121);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 8;
            this.buttonClose.Text = "離開";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonTrans
            // 
            this.buttonTrans.Location = new System.Drawing.Point(94, 121);
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
            this.label8.Location = new System.Drawing.Point(59, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 57;
            this.label8.Text = "格式";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(35, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 52;
            this.label4.Text = "員工編號";
            // 
            // textBoxYYMM
            // 
            this.textBoxYYMM.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxYYMM.CaptionLabel = this.label1;
            this.textBoxYYMM.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxYYMM.DecimalPlace = 2;
            this.textBoxYYMM.IsEmpty = true;
            this.textBoxYYMM.Location = new System.Drawing.Point(94, 12);
            this.textBoxYYMM.Mask = "";
            this.textBoxYYMM.MaxLength = 6;
            this.textBoxYYMM.Name = "textBoxYYMM";
            this.textBoxYYMM.PasswordChar = '\0';
            this.textBoxYYMM.ReadOnly = false;
            this.textBoxYYMM.ShowCalendarButton = true;
            this.textBoxYYMM.Size = new System.Drawing.Size(49, 22);
            this.textBoxYYMM.TabIndex = 0;
            this.textBoxYYMM.ValidType = JBControls.TextBox.EValidType.String;
            this.textBoxYYMM.Validated += new System.EventHandler(this.textBoxYYMM_B_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(35, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 49;
            this.label1.Text = "申報年月";
            // 
            // buttonEmp
            // 
            this.buttonEmp.Location = new System.Drawing.Point(94, 40);
            this.buttonEmp.Name = "buttonEmp";
            this.buttonEmp.Size = new System.Drawing.Size(75, 23);
            this.buttonEmp.TabIndex = 4;
            this.buttonEmp.Text = "(0)";
            this.buttonEmp.UseVisualStyleBackColor = true;
            // 
            // radCheckedDropDownList1
            // 
            this.radCheckedDropDownList1.Location = new System.Drawing.Point(94, 95);
            this.radCheckedDropDownList1.Name = "radCheckedDropDownList1";
            this.radCheckedDropDownList1.ShowCheckAllItems = true;
            this.radCheckedDropDownList1.Size = new System.Drawing.Size(255, 20);
            this.radCheckedDropDownList1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(59, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 57;
            this.label3.Text = "公司";
            // 
            // radCheckedDropDownList2
            // 
            this.radCheckedDropDownList2.Location = new System.Drawing.Point(94, 69);
            this.radCheckedDropDownList2.Name = "radCheckedDropDownList2";
            this.radCheckedDropDownList2.ShowCheckAllItems = true;
            this.radCheckedDropDownList2.Size = new System.Drawing.Size(255, 20);
            this.radCheckedDropDownList2.TabIndex = 5;
            // 
            // textBoxSEQ
            // 
            this.textBoxSEQ.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxSEQ.CaptionLabel = null;
            this.textBoxSEQ.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxSEQ.DecimalPlace = 2;
            this.textBoxSEQ.IsEmpty = true;
            this.textBoxSEQ.Location = new System.Drawing.Point(201, 12);
            this.textBoxSEQ.Mask = "";
            this.textBoxSEQ.MaxLength = 6;
            this.textBoxSEQ.Name = "textBoxSEQ";
            this.textBoxSEQ.PasswordChar = '\0';
            this.textBoxSEQ.ReadOnly = false;
            this.textBoxSEQ.ShowCalendarButton = true;
            this.textBoxSEQ.Size = new System.Drawing.Size(49, 22);
            this.textBoxSEQ.TabIndex = 0;
            this.textBoxSEQ.ValidType = JBControls.TextBox.EValidType.String;
            this.textBoxSEQ.Validated += new System.EventHandler(this.textBoxYYMM_B_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(166, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 49;
            this.label2.Text = "期別";
            // 
            // FRM71N1_T1
            // 
            this.ClientSize = new System.Drawing.Size(361, 162);
            this.Controls.Add(this.radCheckedDropDownList2);
            this.Controls.Add(this.radCheckedDropDownList1);
            this.Controls.Add(this.buttonEmp);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonTrans);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxSEQ);
            this.Controls.Add(this.textBoxYYMM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM71N1_T1";
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
        private JBControls.TextBox textBoxYYMM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEmp;
        private Telerik.WinControls.UI.RadCheckedDropDownList radCheckedDropDownList1;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadCheckedDropDownList radCheckedDropDownList2;
        private JBControls.TextBox textBoxSEQ;
        private System.Windows.Forms.Label label2;
    }
}
