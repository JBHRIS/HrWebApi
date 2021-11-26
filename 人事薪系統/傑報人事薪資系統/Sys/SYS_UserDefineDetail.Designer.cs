namespace JBHR.Sys
{
    partial class SYS_UserDefineDetail
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gpbControl = new System.Windows.Forms.GroupBox();
            this.rbNumericUpDown = new System.Windows.Forms.RadioButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbRemoveAt = new System.Windows.Forms.Label();
            this.rbRemoveAt = new System.Windows.Forms.RadioButton();
            this.rbComboBox = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.rbDateTimePicker = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbTextBox = new System.Windows.Forms.RadioButton();
            this.rbCheckBox = new System.Windows.Forms.RadioButton();
            this.rbLabel = new System.Windows.Forms.RadioButton();
            this.gpbProperty = new System.Windows.Forms.GroupBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.gpbControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.gpbProperty.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbControl
            // 
            this.gpbControl.Controls.Add(this.rbNumericUpDown);
            this.gpbControl.Controls.Add(this.numericUpDown1);
            this.gpbControl.Controls.Add(this.btnCancel);
            this.gpbControl.Controls.Add(this.btnSave);
            this.gpbControl.Controls.Add(this.lbRemoveAt);
            this.gpbControl.Controls.Add(this.rbRemoveAt);
            this.gpbControl.Controls.Add(this.rbComboBox);
            this.gpbControl.Controls.Add(this.comboBox1);
            this.gpbControl.Controls.Add(this.dateTimePicker1);
            this.gpbControl.Controls.Add(this.rbDateTimePicker);
            this.gpbControl.Controls.Add(this.textBox1);
            this.gpbControl.Controls.Add(this.checkBox1);
            this.gpbControl.Controls.Add(this.label1);
            this.gpbControl.Controls.Add(this.rbTextBox);
            this.gpbControl.Controls.Add(this.rbCheckBox);
            this.gpbControl.Controls.Add(this.rbLabel);
            this.gpbControl.Location = new System.Drawing.Point(12, 12);
            this.gpbControl.Name = "gpbControl";
            this.gpbControl.Size = new System.Drawing.Size(245, 417);
            this.gpbControl.TabIndex = 0;
            this.gpbControl.TabStop = false;
            this.gpbControl.Text = "選擇欲使用的元件";
            // 
            // rbNumericUpDown
            // 
            this.rbNumericUpDown.AutoSize = true;
            this.rbNumericUpDown.Location = new System.Drawing.Point(13, 230);
            this.rbNumericUpDown.Name = "rbNumericUpDown";
            this.rbNumericUpDown.Size = new System.Drawing.Size(14, 13);
            this.rbNumericUpDown.TabIndex = 10;
            this.rbNumericUpDown.UseVisualStyleBackColor = true;
            this.rbNumericUpDown.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Location = new System.Drawing.Point(43, 225);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(182, 22);
            this.numericUpDown1.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(150, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(43, 265);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbRemoveAt
            // 
            this.lbRemoveAt.AutoSize = true;
            this.lbRemoveAt.Location = new System.Drawing.Point(40, 41);
            this.lbRemoveAt.Name = "lbRemoveAt";
            this.lbRemoveAt.Size = new System.Drawing.Size(113, 12);
            this.lbRemoveAt.TabIndex = 7;
            this.lbRemoveAt.Text = "移除目前選取的元件";
            // 
            // rbRemoveAt
            // 
            this.rbRemoveAt.AutoSize = true;
            this.rbRemoveAt.Location = new System.Drawing.Point(13, 40);
            this.rbRemoveAt.Name = "rbRemoveAt";
            this.rbRemoveAt.Size = new System.Drawing.Size(14, 13);
            this.rbRemoveAt.TabIndex = 6;
            this.rbRemoveAt.UseVisualStyleBackColor = true;
            this.rbRemoveAt.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rbComboBox
            // 
            this.rbComboBox.AutoSize = true;
            this.rbComboBox.Location = new System.Drawing.Point(13, 168);
            this.rbComboBox.Name = "rbComboBox";
            this.rbComboBox.Size = new System.Drawing.Size(14, 13);
            this.rbComboBox.TabIndex = 5;
            this.rbComboBox.UseVisualStyleBackColor = true;
            this.rbComboBox.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(43, 166);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(182, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "請先選擇資料來源";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(43, 194);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(182, 22);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // rbDateTimePicker
            // 
            this.rbDateTimePicker.AutoSize = true;
            this.rbDateTimePicker.Location = new System.Drawing.Point(13, 200);
            this.rbDateTimePicker.Name = "rbDateTimePicker";
            this.rbDateTimePicker.Size = new System.Drawing.Size(14, 13);
            this.rbDateTimePicker.TabIndex = 4;
            this.rbDateTimePicker.UseVisualStyleBackColor = true;
            this.rbDateTimePicker.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(43, 134);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(182, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "文字輸入";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox1.Location = new System.Drawing.Point(43, 104);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "勾選項目";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(40, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "標籤";
            // 
            // rbTextBox
            // 
            this.rbTextBox.AutoSize = true;
            this.rbTextBox.Location = new System.Drawing.Point(13, 136);
            this.rbTextBox.Name = "rbTextBox";
            this.rbTextBox.Size = new System.Drawing.Size(14, 13);
            this.rbTextBox.TabIndex = 3;
            this.rbTextBox.UseVisualStyleBackColor = true;
            this.rbTextBox.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rbCheckBox
            // 
            this.rbCheckBox.AutoSize = true;
            this.rbCheckBox.Location = new System.Drawing.Point(13, 104);
            this.rbCheckBox.Name = "rbCheckBox";
            this.rbCheckBox.Size = new System.Drawing.Size(14, 13);
            this.rbCheckBox.TabIndex = 2;
            this.rbCheckBox.UseVisualStyleBackColor = true;
            this.rbCheckBox.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rbLabel
            // 
            this.rbLabel.AutoSize = true;
            this.rbLabel.Location = new System.Drawing.Point(13, 72);
            this.rbLabel.Name = "rbLabel";
            this.rbLabel.Size = new System.Drawing.Size(14, 13);
            this.rbLabel.TabIndex = 1;
            this.rbLabel.UseVisualStyleBackColor = true;
            this.rbLabel.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // gpbProperty
            // 
            this.gpbProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbProperty.Controls.Add(this.propertyGrid1);
            this.gpbProperty.Location = new System.Drawing.Point(263, 12);
            this.gpbProperty.Name = "gpbProperty";
            this.gpbProperty.Size = new System.Drawing.Size(509, 417);
            this.gpbProperty.TabIndex = 1;
            this.gpbProperty.TabStop = false;
            this.gpbProperty.Text = "元件屬性設定";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 18);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(503, 396);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // SYS_UserDefineDetail
            // 
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.gpbProperty);
            this.Controls.Add(this.gpbControl);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SYS_UserDefineDetail";
            this.Load += new System.EventHandler(this.SYS_UserDefineDetail_Load);
            this.gpbControl.ResumeLayout(false);
            this.gpbControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.gpbProperty.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbControl;
        private System.Windows.Forms.RadioButton rbComboBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton rbDateTimePicker;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbTextBox;
        private System.Windows.Forms.RadioButton rbCheckBox;
        private System.Windows.Forms.RadioButton rbLabel;
        private System.Windows.Forms.GroupBox gpbProperty;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Label lbRemoveAt;
        private System.Windows.Forms.RadioButton rbRemoveAt;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rbNumericUpDown;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
