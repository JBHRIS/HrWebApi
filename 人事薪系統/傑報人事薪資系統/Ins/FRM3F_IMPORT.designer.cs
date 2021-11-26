namespace JBHR.Ins
{
    partial class FRM3F_IMPORT
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
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBoxInsType = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.buttonConfig = new System.Windows.Forms.Button();
            this.txtYYMM = new JBControls.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(44, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 53;
            this.label1.Text = "身份証號";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(44, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 59;
            this.label5.Text = "費用種類";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(44, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 51;
            this.label2.Text = "保險年月";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(44, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 57;
            this.label4.Text = "公司負擔";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(44, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 55;
            this.label3.Text = "個人負擔";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(103, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Tag = "身分證號";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(103, 111);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.Tag = "個人負擔";
            // 
            // comboBoxInsType
            // 
            this.comboBoxInsType.FormattingEnabled = true;
            this.comboBoxInsType.Location = new System.Drawing.Point(103, 83);
            this.comboBoxInsType.Name = "comboBoxInsType";
            this.comboBoxInsType.Size = new System.Drawing.Size(121, 20);
            this.comboBoxInsType.TabIndex = 2;
            this.comboBoxInsType.Tag = "費用種類";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(103, 139);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 20);
            this.comboBox4.TabIndex = 4;
            this.comboBox4.Tag = "公司負擔";
            // 
            // buttonConfig
            // 
            this.buttonConfig.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConfig.Location = new System.Drawing.Point(103, 177);
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Size = new System.Drawing.Size(75, 23);
            this.buttonConfig.TabIndex = 5;
            this.buttonConfig.Text = "設定";
            this.buttonConfig.UseVisualStyleBackColor = true;
            this.buttonConfig.Click += new System.EventHandler(this.buttonConfig_Click);
            // 
            // txtYYMM
            // 
            this.txtYYMM.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYYMM.CaptionLabel = this.label2;
            this.txtYYMM.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYYMM.DecimalPlace = 2;
            this.txtYYMM.IsEmpty = false;
            this.txtYYMM.Location = new System.Drawing.Point(103, 25);
            this.txtYYMM.Mask = "";
            this.txtYYMM.MaxLength = -1;
            this.txtYYMM.Name = "txtYYMM";
            this.txtYYMM.PasswordChar = '\0';
            this.txtYYMM.ReadOnly = false;
            this.txtYYMM.ShowCalendarButton = true;
            this.txtYYMM.Size = new System.Drawing.Size(59, 22);
            this.txtYYMM.TabIndex = 0;
            this.txtYYMM.Tag = "保險年月";
            this.txtYYMM.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // FRM3F_IMPORT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 224);
            this.Controls.Add(this.buttonConfig);
            this.Controls.Add(this.comboBoxInsType);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtYYMM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "FRM3F_IMPORT";
            this.Text = "FRM3F_IMPORT";
            this.Load += new System.EventHandler(this.FRM3F_IMPORT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBoxInsType;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button buttonConfig;
        private JBControls.TextBox txtYYMM;

    }
}