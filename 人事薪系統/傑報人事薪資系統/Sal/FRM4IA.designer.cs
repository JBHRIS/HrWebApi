namespace JBHR.Sal
{
    partial class FRM4IA
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
            this.txtYymmB = new JBControls.TextBox();
            this.textBoxSeqB = new JBControls.TextBox();
            this.txtYymmE = new JBControls.TextBox();
            this.textBoxSeqE = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtYymmB
            // 
            this.txtYymmB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYymmB.CaptionLabel = null;
            this.txtYymmB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYymmB.DecimalPlace = 2;
            this.txtYymmB.IsEmpty = true;
            this.txtYymmB.Location = new System.Drawing.Point(86, 21);
            this.txtYymmB.Mask = "000000";
            this.txtYymmB.MaxLength = -1;
            this.txtYymmB.Name = "txtYymmB";
            this.txtYymmB.PasswordChar = '\0';
            this.txtYymmB.ReadOnly = false;
            this.txtYymmB.ShowCalendarButton = true;
            this.txtYymmB.Size = new System.Drawing.Size(55, 22);
            this.txtYymmB.TabIndex = 0;
            this.txtYymmB.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBoxSeqB
            // 
            this.textBoxSeqB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxSeqB.CaptionLabel = null;
            this.textBoxSeqB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxSeqB.DecimalPlace = 2;
            this.textBoxSeqB.IsEmpty = true;
            this.textBoxSeqB.Location = new System.Drawing.Point(147, 21);
            this.textBoxSeqB.Mask = "";
            this.textBoxSeqB.MaxLength = -1;
            this.textBoxSeqB.Name = "textBoxSeqB";
            this.textBoxSeqB.PasswordChar = '\0';
            this.textBoxSeqB.ReadOnly = false;
            this.textBoxSeqB.ShowCalendarButton = true;
            this.textBoxSeqB.Size = new System.Drawing.Size(27, 22);
            this.textBoxSeqB.TabIndex = 1;
            this.textBoxSeqB.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtYymmE
            // 
            this.txtYymmE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYymmE.CaptionLabel = null;
            this.txtYymmE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYymmE.DecimalPlace = 2;
            this.txtYymmE.IsEmpty = true;
            this.txtYymmE.Location = new System.Drawing.Point(203, 21);
            this.txtYymmE.Mask = "000000";
            this.txtYymmE.MaxLength = -1;
            this.txtYymmE.Name = "txtYymmE";
            this.txtYymmE.PasswordChar = '\0';
            this.txtYymmE.ReadOnly = false;
            this.txtYymmE.ShowCalendarButton = true;
            this.txtYymmE.Size = new System.Drawing.Size(55, 22);
            this.txtYymmE.TabIndex = 2;
            this.txtYymmE.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBoxSeqE
            // 
            this.textBoxSeqE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxSeqE.CaptionLabel = null;
            this.textBoxSeqE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxSeqE.DecimalPlace = 2;
            this.textBoxSeqE.IsEmpty = true;
            this.textBoxSeqE.Location = new System.Drawing.Point(264, 21);
            this.textBoxSeqE.Mask = "";
            this.textBoxSeqE.MaxLength = -1;
            this.textBoxSeqE.Name = "textBoxSeqE";
            this.textBoxSeqE.PasswordChar = '\0';
            this.textBoxSeqE.ReadOnly = false;
            this.textBoxSeqE.ShowCalendarButton = true;
            this.textBoxSeqE.Size = new System.Drawing.Size(27, 22);
            this.textBoxSeqE.TabIndex = 3;
            this.textBoxSeqE.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "薪資年月";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "至";
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(86, 62);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(65, 23);
            this.btnCalc.TabIndex = 4;
            this.btnCalc.Text = "計算";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(182, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "離開";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FRM4IA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 107);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSeqE);
            this.Controls.Add(this.textBoxSeqB);
            this.Controls.Add(this.txtYymmE);
            this.Controls.Add(this.txtYymmB);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM4IA";
            this.Text = "FRM4IA";
            this.Load += new System.EventHandler(this.FRM4IA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JBControls.TextBox txtYymmB;
        private JBControls.TextBox textBoxSeqB;
        private JBControls.TextBox txtYymmE;
        private JBControls.TextBox textBoxSeqE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button button1;
    }
}