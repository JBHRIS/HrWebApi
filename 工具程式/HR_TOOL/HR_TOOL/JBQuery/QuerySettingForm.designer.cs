namespace HR_TOOL.JBQuery
{
    partial class QuerySettingForm
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
            this.textBoxSetting = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSettingName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxSourceTable = new System.Windows.Forms.ComboBox();
            this.textBoxMemo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCustomWhere = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxSetting
            // 
            this.textBoxSetting.Location = new System.Drawing.Point(79, 21);
            this.textBoxSetting.Name = "textBoxSetting";
            this.textBoxSetting.Size = new System.Drawing.Size(100, 22);
            this.textBoxSetting.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "設定代碼";
            // 
            // textBoxSettingName
            // 
            this.textBoxSettingName.Location = new System.Drawing.Point(79, 49);
            this.textBoxSettingName.Name = "textBoxSettingName";
            this.textBoxSettingName.Size = new System.Drawing.Size(100, 22);
            this.textBoxSettingName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "設定名稱";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "資料表來源";
            // 
            // comboBoxSourceTable
            // 
            this.comboBoxSourceTable.FormattingEnabled = true;
            this.comboBoxSourceTable.Location = new System.Drawing.Point(79, 105);
            this.comboBoxSourceTable.Name = "comboBoxSourceTable";
            this.comboBoxSourceTable.Size = new System.Drawing.Size(150, 20);
            this.comboBoxSourceTable.TabIndex = 3;
            // 
            // textBoxMemo
            // 
            this.textBoxMemo.Location = new System.Drawing.Point(79, 77);
            this.textBoxMemo.Name = "textBoxMemo";
            this.textBoxMemo.Size = new System.Drawing.Size(347, 22);
            this.textBoxMemo.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "備註";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(135, 168);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "存檔";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(233, 168);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "離開";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "自訂篩選";
            // 
            // textBoxCustomWhere
            // 
            this.textBoxCustomWhere.Location = new System.Drawing.Point(79, 131);
            this.textBoxCustomWhere.Name = "textBoxCustomWhere";
            this.textBoxCustomWhere.Size = new System.Drawing.Size(347, 22);
            this.textBoxCustomWhere.TabIndex = 7;
            // 
            // QuerySettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 203);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxCustomWhere);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxSourceTable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMemo);
            this.Controls.Add(this.textBoxSettingName);
            this.Controls.Add(this.textBoxSetting);
            this.Name = "QuerySettingForm";
            this.Text = "QuerySettingForm";
            this.Load += new System.EventHandler(this.QuerySettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSettingName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxSourceTable;
        private System.Windows.Forms.TextBox textBoxMemo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxCustomWhere;
    }
}