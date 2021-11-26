namespace JBHR.Med
{
    partial class FRM71N_ADD
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tWTAXBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.textBoxYearMonth = new System.Windows.Forms.TextBox();
            this.datePickBegin = new System.Windows.Forms.DateTimePicker();
            this.datePickEnd = new System.Windows.Forms.DateTimePicker();
            this.textBoxRemark = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxReleaseDate = new JBControls.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tWTAXBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(41, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "申報年(月)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "申報區間";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "標題";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "備註";
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(132, 181);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "存檔";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(274, 181);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // tWTAXBindingSource
            // 
            this.tWTAXBindingSource.DataSource = typeof(JBModule.Data.Linq.TW_TAX);
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tWTAXBindingSource, "Subject", true));
            this.textBoxSubject.Location = new System.Drawing.Point(107, 11);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(369, 22);
            this.textBoxSubject.TabIndex = 0;
            // 
            // textBoxYearMonth
            // 
            this.textBoxYearMonth.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tWTAXBindingSource, "YearMonth", true));
            this.textBoxYearMonth.Location = new System.Drawing.Point(107, 39);
            this.textBoxYearMonth.Name = "textBoxYearMonth";
            this.textBoxYearMonth.Size = new System.Drawing.Size(75, 22);
            this.textBoxYearMonth.TabIndex = 1;
            // 
            // datePickBegin
            // 
            this.datePickBegin.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tWTAXBindingSource, "DateBegin", true));
            this.datePickBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickBegin.Location = new System.Drawing.Point(106, 66);
            this.datePickBegin.Name = "datePickBegin";
            this.datePickBegin.Size = new System.Drawing.Size(101, 22);
            this.datePickBegin.TabIndex = 2;
            // 
            // datePickEnd
            // 
            this.datePickEnd.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tWTAXBindingSource, "DateEnd", true));
            this.datePickEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickEnd.Location = new System.Drawing.Point(229, 66);
            this.datePickEnd.Name = "datePickEnd";
            this.datePickEnd.Size = new System.Drawing.Size(101, 22);
            this.datePickEnd.TabIndex = 3;
            // 
            // textBoxRemark
            // 
            this.textBoxRemark.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tWTAXBindingSource, "Remark", true));
            this.textBoxRemark.Location = new System.Drawing.Point(106, 94);
            this.textBoxRemark.Name = "textBoxRemark";
            this.textBoxRemark.Size = new System.Drawing.Size(369, 22);
            this.textBoxRemark.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.tWTAXBindingSource, "IsLock", true));
            this.checkBox1.Location = new System.Drawing.Point(104, 122);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "鎖檔";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "開放查詢日期";
            // 
            // textBox3
            // 
            this.textBoxReleaseDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxReleaseDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxReleaseDate.CaptionLabel = this.label1;
            this.textBoxReleaseDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxReleaseDate.DecimalPlace = 2;
            this.textBoxReleaseDate.IsEmpty = true;
            this.textBoxReleaseDate.Location = new System.Drawing.Point(104, 144);
            this.textBoxReleaseDate.Mask = "0000/00/00";
            this.textBoxReleaseDate.MaxLength = 50;
            this.textBoxReleaseDate.Name = "textBox3";
            this.textBoxReleaseDate.PasswordChar = '\0';
            this.textBoxReleaseDate.ReadOnly = false;
            this.textBoxReleaseDate.ShowCalendarButton = true;
            this.textBoxReleaseDate.Size = new System.Drawing.Size(100, 22);
            this.textBoxReleaseDate.TabIndex = 8;
            this.textBoxReleaseDate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // FRM71N_ADD
            // 
            this.ClientSize = new System.Drawing.Size(488, 216);
            this.Controls.Add(this.textBoxReleaseDate);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.datePickEnd);
            this.Controls.Add(this.datePickBegin);
            this.Controls.Add(this.textBoxYearMonth);
            this.Controls.Add(this.textBoxRemark);
            this.Controls.Add(this.textBoxSubject);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM71N_ADD";
            this.Load += new System.EventHandler(this.FRM71N_ADD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tWTAXBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.BindingSource tWTAXBindingSource;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.TextBox textBoxYearMonth;
        private System.Windows.Forms.DateTimePicker datePickBegin;
        private System.Windows.Forms.DateTimePicker datePickEnd;
        private System.Windows.Forms.TextBox textBoxRemark;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private JBControls.TextBox textBoxReleaseDate;
    }
}
