namespace JBHR.Bas
{
    partial class FRM12P
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM12P));
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutDate = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRoutDate = new JBControls.TextBox();
            this.bnSave = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(92, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "退保日期";
            // 
            // txtOutDate
            // 
            this.txtOutDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtOutDate.CaptionLabel = this.label1;
            this.txtOutDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtOutDate.DecimalPlace = 2;
            this.txtOutDate.IsEmpty = false;
            this.txtOutDate.Location = new System.Drawing.Point(180, 40);
            this.txtOutDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutDate.Mask = "0000/00/00";
            this.txtOutDate.MaxLength = -1;
            this.txtOutDate.Name = "txtOutDate";
            this.txtOutDate.PasswordChar = '\0';
            this.txtOutDate.ReadOnly = false;
            this.txtOutDate.ShowCalendarButton = true;
            this.txtOutDate.Size = new System.Drawing.Size(138, 29);
            this.txtOutDate.TabIndex = 1;
            this.txtOutDate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(56, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "勞退停繳日期";
            // 
            // txtRoutDate
            // 
            this.txtRoutDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtRoutDate.CaptionLabel = this.label2;
            this.txtRoutDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRoutDate.DecimalPlace = 2;
            this.txtRoutDate.IsEmpty = false;
            this.txtRoutDate.Location = new System.Drawing.Point(180, 87);
            this.txtRoutDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtRoutDate.Mask = "0000/00/00";
            this.txtRoutDate.MaxLength = -1;
            this.txtRoutDate.Name = "txtRoutDate";
            this.txtRoutDate.PasswordChar = '\0';
            this.txtRoutDate.ReadOnly = false;
            this.txtRoutDate.ShowCalendarButton = true;
            this.txtRoutDate.Size = new System.Drawing.Size(138, 29);
            this.txtRoutDate.TabIndex = 1;
            this.txtRoutDate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // bnSave
            // 
            this.bnSave.Location = new System.Drawing.Point(58, 148);
            this.bnSave.Margin = new System.Windows.Forms.Padding(4);
            this.bnSave.Name = "bnSave";
            this.bnSave.Size = new System.Drawing.Size(112, 34);
            this.bnSave.TabIndex = 2;
            this.bnSave.Text = "確定";
            this.bnSave.UseVisualStyleBackColor = true;
            this.bnSave.Click += new System.EventHandler(this.bnSave_Click);
            // 
            // bnCancel
            // 
            this.bnCancel.Location = new System.Drawing.Point(206, 148);
            this.bnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(112, 34);
            this.bnCancel.TabIndex = 2;
            this.bnCancel.Text = "取消";
            this.bnCancel.UseVisualStyleBackColor = true;
            this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
            // 
            // FRM12P
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 219);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnSave);
            this.Controls.Add(this.txtRoutDate);
            this.Controls.Add(this.txtOutDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRM12P";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "退保設定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private JBControls.TextBox txtOutDate;
        private System.Windows.Forms.Label label2;
        private JBControls.TextBox txtRoutDate;
        private System.Windows.Forms.Button bnSave;
        private System.Windows.Forms.Button bnCancel;
    }
}