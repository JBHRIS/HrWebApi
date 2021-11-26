namespace JBHR.Att
{
    partial class FRM2V_EDIT
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxErrorType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRoteOnTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRoteOffTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCardOnTime = new System.Windows.Forms.TextBox();
            this.textBoxCardOffTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxErrorMinutes = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxRemark = new System.Windows.Forms.TextBox();
            this.aTTENDABNORMALCHECKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxRemarkType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aTTENDABNORMALCHECKBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy/MM/dd";
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(117, 21);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(99, 22);
            this.dtpDate.TabIndex = 1;
            // 
            // comboBoxErrorType
            // 
            this.comboBoxErrorType.FormattingEnabled = true;
            this.comboBoxErrorType.Location = new System.Drawing.Point(117, 49);
            this.comboBoxErrorType.Name = "comboBoxErrorType";
            this.comboBoxErrorType.Size = new System.Drawing.Size(99, 20);
            this.comboBoxErrorType.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "異常種類";
            // 
            // textBoxRoteOnTime
            // 
            this.textBoxRoteOnTime.Location = new System.Drawing.Point(116, 75);
            this.textBoxRoteOnTime.Name = "textBoxRoteOnTime";
            this.textBoxRoteOnTime.Size = new System.Drawing.Size(48, 22);
            this.textBoxRoteOnTime.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "班別上下班時間";
            // 
            // textBoxRoteOffTime
            // 
            this.textBoxRoteOffTime.Location = new System.Drawing.Point(170, 75);
            this.textBoxRoteOffTime.Name = "textBoxRoteOffTime";
            this.textBoxRoteOffTime.Size = new System.Drawing.Size(48, 22);
            this.textBoxRoteOffTime.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "打卡上下班時間";
            // 
            // textBoxCardOnTime
            // 
            this.textBoxCardOnTime.Location = new System.Drawing.Point(116, 103);
            this.textBoxCardOnTime.Name = "textBoxCardOnTime";
            this.textBoxCardOnTime.Size = new System.Drawing.Size(48, 22);
            this.textBoxCardOnTime.TabIndex = 3;
            // 
            // textBoxCardOffTime
            // 
            this.textBoxCardOffTime.Location = new System.Drawing.Point(170, 103);
            this.textBoxCardOffTime.Name = "textBoxCardOffTime";
            this.textBoxCardOffTime.Size = new System.Drawing.Size(48, 22);
            this.textBoxCardOffTime.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "異常分鐘數";
            // 
            // textBoxErrorMinutes
            // 
            this.textBoxErrorMinutes.Location = new System.Drawing.Point(116, 131);
            this.textBoxErrorMinutes.Name = "textBoxErrorMinutes";
            this.textBoxErrorMinutes.Size = new System.Drawing.Size(48, 22);
            this.textBoxErrorMinutes.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxCardOffTime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxRoteOffTime);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxErrorMinutes);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxCardOnTime);
            this.groupBox1.Controls.Add(this.comboBoxErrorType);
            this.groupBox1.Controls.Add(this.textBoxRoteOnTime);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 171);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "異常紀錄";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxRemark);
            this.groupBox2.Controls.Add(this.comboBoxRemarkType);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 140);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "註記說明";
            // 
            // textBoxRemark
            // 
            this.textBoxRemark.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aTTENDABNORMALCHECKBindingSource, "REMARK", true));
            this.textBoxRemark.Location = new System.Drawing.Point(117, 48);
            this.textBoxRemark.Multiline = true;
            this.textBoxRemark.Name = "textBoxRemark";
            this.textBoxRemark.Size = new System.Drawing.Size(382, 86);
            this.textBoxRemark.TabIndex = 3;
            // 
            // aTTENDABNORMALCHECKBindingSource
            // 
            this.aTTENDABNORMALCHECKBindingSource.DataSource = typeof(JBModule.Data.Linq.ATTEND_ABNORMAL_CHECK);
            // 
            // comboBoxRemarkType
            // 
            this.comboBoxRemarkType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.aTTENDABNORMALCHECKBindingSource, "REMARK_TYPE", true));
            this.comboBoxRemarkType.FormattingEnabled = true;
            this.comboBoxRemarkType.Location = new System.Drawing.Point(116, 21);
            this.comboBoxRemarkType.Name = "comboBoxRemarkType";
            this.comboBoxRemarkType.Size = new System.Drawing.Size(99, 20);
            this.comboBoxRemarkType.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "註記說明";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "註記原因";
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(165, 351);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "儲存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(290, 351);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.TabStop = false;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FRM2V_EDIT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 386);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FRM2V_EDIT";
            this.Text = "FRM2V_EDIT - 異常註記";
            this.Load += new System.EventHandler(this.FRM2V_EDIT_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aTTENDABNORMALCHECKBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox comboBoxErrorType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRoteOnTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRoteOffTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCardOnTime;
        private System.Windows.Forms.TextBox textBoxCardOffTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxErrorMinutes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxRemark;
        private System.Windows.Forms.ComboBox comboBoxRemarkType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.BindingSource aTTENDABNORMALCHECKBindingSource;
    }
}