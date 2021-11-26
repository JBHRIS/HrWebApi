namespace JBHR.Sys
{
    partial class AddDataGroup
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.cbxWrite = new JBControls.CheckBox();
            this.cbxRead = new JBControls.CheckBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(52, 94);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.TabStop = false;
            this.btnOk.Text = "確認";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(169, 94);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "資料群組";
            // 
            // comboBox2
            // 
            this.comboBox2.DisplayMember = "disp";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(113, 28);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(131, 20);
            this.comboBox2.TabIndex = 0;
            this.comboBox2.ValueMember = "val";
            // 
            // cbxWrite
            // 
            this.cbxWrite.AutoSize = true;
            this.cbxWrite.CaptionLabel = null;
            this.cbxWrite.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbxWrite.IsImitateCaption = true;
            this.cbxWrite.Location = new System.Drawing.Point(154, 63);
            this.cbxWrite.Name = "cbxWrite";
            this.cbxWrite.Size = new System.Drawing.Size(72, 16);
            this.cbxWrite.TabIndex = 2;
            this.cbxWrite.TabStop = false;
            this.cbxWrite.Text = "異動權限";
            this.cbxWrite.UseVisualStyleBackColor = true;
            // 
            // cbxRead
            // 
            this.cbxRead.AutoSize = true;
            this.cbxRead.CaptionLabel = null;
            this.cbxRead.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbxRead.IsImitateCaption = true;
            this.cbxRead.Location = new System.Drawing.Point(71, 63);
            this.cbxRead.Name = "cbxRead";
            this.cbxRead.Size = new System.Drawing.Size(72, 16);
            this.cbxRead.TabIndex = 1;
            this.cbxRead.TabStop = false;
            this.cbxRead.Text = "讀取權限";
            this.cbxRead.UseVisualStyleBackColor = true;
            // 
            // AddDataGroup
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(313, 140);
            this.Controls.Add(this.cbxWrite);
            this.Controls.Add(this.cbxRead);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDataGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddDataGroup";
            this.Load += new System.EventHandler(this.AddDataGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private JBControls.CheckBox cbxWrite;
        private JBControls.CheckBox cbxRead;
    }
}