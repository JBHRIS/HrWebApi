namespace JBHR.Bas
{
    partial class FRM12C
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInDate = new JBControls.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewNobr = new JBControls.TextBox();
            this.cbxDetail = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "到職日期";
            // 
            // txtInDate
            // 
            this.txtInDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtInDate.CaptionLabel = null;
            this.txtInDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtInDate.DecimalPlace = 2;
            this.txtInDate.IsEmpty = true;
            this.txtInDate.Location = new System.Drawing.Point(81, 43);
            this.txtInDate.Mask = "0000/00/00";
            this.txtInDate.MaxLength = -1;
            this.txtInDate.Name = "txtInDate";
            this.txtInDate.PasswordChar = '\0';
            this.txtInDate.ReadOnly = false;
            this.txtInDate.Size = new System.Drawing.Size(68, 22);
            this.txtInDate.TabIndex = 1;
            this.txtInDate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(55, 79);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "複製";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(172, 79);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "員工編號";
            // 
            // txtNewNobr
            // 
            this.txtNewNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtNewNobr.CaptionLabel = null;
            this.txtNewNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNewNobr.DecimalPlace = 2;
            this.txtNewNobr.IsEmpty = true;
            this.txtNewNobr.Location = new System.Drawing.Point(81, 12);
            this.txtNewNobr.Mask = "";
            this.txtNewNobr.MaxLength = -1;
            this.txtNewNobr.Name = "txtNewNobr";
            this.txtNewNobr.PasswordChar = '\0';
            this.txtNewNobr.ReadOnly = false;
            this.txtNewNobr.Size = new System.Drawing.Size(88, 22);
            this.txtNewNobr.TabIndex = 1;
            this.txtNewNobr.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // cbxDetail
            // 
            this.cbxDetail.AutoSize = true;
            this.cbxDetail.Location = new System.Drawing.Point(172, 46);
            this.cbxDetail.Name = "cbxDetail";
            this.cbxDetail.Size = new System.Drawing.Size(72, 16);
            this.cbxDetail.TabIndex = 3;
            this.cbxDetail.Text = "完整複製";
            this.cbxDetail.UseVisualStyleBackColor = true;
            // 
            // FRM12C
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 126);
            this.Controls.Add(this.cbxDetail);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtNewNobr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInDate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM12C";
            this.Text = "FRM12C";
            this.Load += new System.EventHandler(this.FRM12C_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private JBControls.TextBox txtInDate;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private JBControls.TextBox txtNewNobr;
        private System.Windows.Forms.CheckBox cbxDetail;
    }
}