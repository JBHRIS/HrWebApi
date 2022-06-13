namespace HR_TOOL
{
    partial class SalaryKeyViewer
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
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxFOLDER = new JBControls.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.textBoxDcode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(525, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 23);
            this.button2.TabIndex = 30;
            this.button2.Text = "…";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(10, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 31;
            this.label7.Text = "儲存路徑";
            // 
            // textBoxFOLDER
            // 
            this.textBoxFOLDER.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxFOLDER.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxFOLDER.CaptionLabel = this.label7;
            this.textBoxFOLDER.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxFOLDER.DecimalPlace = 2;
            this.textBoxFOLDER.IsEmpty = true;
            this.textBoxFOLDER.Location = new System.Drawing.Point(69, 75);
            this.textBoxFOLDER.Mask = "";
            this.textBoxFOLDER.MaxLength = -1;
            this.textBoxFOLDER.Name = "textBoxFOLDER";
            this.textBoxFOLDER.PasswordChar = '\0';
            this.textBoxFOLDER.ReadOnly = true;
            this.textBoxFOLDER.ShowCalendarButton = true;
            this.textBoxFOLDER.Size = new System.Drawing.Size(458, 22);
            this.textBoxFOLDER.TabIndex = 29;
            this.textBoxFOLDER.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 103);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox1.Size = new System.Drawing.Size(540, 190);
            this.textBox1.TabIndex = 32;
            // 
            // buttonDecode
            // 
            this.buttonDecode.Location = new System.Drawing.Point(362, 13);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(75, 23);
            this.buttonDecode.TabIndex = 33;
            this.buttonDecode.Text = "文字解密";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
            // 
            // textBoxDcode
            // 
            this.textBoxDcode.Location = new System.Drawing.Point(12, 12);
            this.textBoxDcode.Name = "textBoxDcode";
            this.textBoxDcode.Size = new System.Drawing.Size(344, 22);
            this.textBoxDcode.TabIndex = 34;
            // 
            // SalaryKeyViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 305);
            this.Controls.Add(this.textBoxDcode);
            this.Controls.Add(this.buttonDecode);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxFOLDER);
            this.Name = "SalaryKeyViewer";
            this.Text = "SalaryKeyViewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private JBControls.TextBox textBoxFOLDER;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.TextBox textBoxDcode;

    }
}