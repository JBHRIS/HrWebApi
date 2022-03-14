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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxCode1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(37, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "退保日期";
            // 
            // txtOutDate
            // 
            this.txtOutDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtOutDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtOutDate.CaptionLabel = this.label1;
            this.txtOutDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.txtOutDate, 2);
            this.txtOutDate.DecimalPlace = 2;
            this.txtOutDate.IsEmpty = false;
            this.txtOutDate.Location = new System.Drawing.Point(96, 4);
            this.txtOutDate.Mask = "0000/00/00";
            this.txtOutDate.MaxLength = -1;
            this.txtOutDate.Name = "txtOutDate";
            this.txtOutDate.PasswordChar = '\0';
            this.txtOutDate.ReadOnly = false;
            this.txtOutDate.ShowCalendarButton = true;
            this.txtOutDate.Size = new System.Drawing.Size(92, 22);
            this.txtOutDate.TabIndex = 1;
            this.txtOutDate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "勞退停繳日期";
            // 
            // txtRoutDate
            // 
            this.txtRoutDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtRoutDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtRoutDate.CaptionLabel = this.label2;
            this.txtRoutDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.txtRoutDate, 2);
            this.txtRoutDate.DecimalPlace = 2;
            this.txtRoutDate.IsEmpty = false;
            this.txtRoutDate.Location = new System.Drawing.Point(96, 34);
            this.txtRoutDate.Mask = "0000/00/00";
            this.txtRoutDate.MaxLength = -1;
            this.txtRoutDate.Name = "txtRoutDate";
            this.txtRoutDate.PasswordChar = '\0';
            this.txtRoutDate.ReadOnly = false;
            this.txtRoutDate.ShowCalendarButton = true;
            this.txtRoutDate.Size = new System.Drawing.Size(92, 22);
            this.txtRoutDate.TabIndex = 1;
            this.txtRoutDate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // bnSave
            // 
            this.bnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel1.SetColumnSpan(this.bnSave, 2);
            this.bnSave.Location = new System.Drawing.Point(77, 94);
            this.bnSave.Name = "bnSave";
            this.bnSave.Size = new System.Drawing.Size(75, 23);
            this.bnSave.TabIndex = 2;
            this.bnSave.Text = "確定";
            this.bnSave.UseVisualStyleBackColor = true;
            this.bnSave.Click += new System.EventHandler(this.bnSave_Click);
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.bnCancel, 2);
            this.bnCancel.Location = new System.Drawing.Point(195, 94);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 2;
            this.bnCancel.Text = "取消";
            this.bnCancel.UseVisualStyleBackColor = true;
            this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtOutDate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtRoutDate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.bnCancel, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxCode1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.bnSave, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(310, 121);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(37, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "異動原因";
            // 
            // comboBoxCode1
            // 
            this.comboBoxCode1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxCode1, 3);
            this.comboBoxCode1.FormattingEnabled = true;
            this.comboBoxCode1.Location = new System.Drawing.Point(96, 65);
            this.comboBoxCode1.Name = "comboBoxCode1";
            this.comboBoxCode1.Size = new System.Drawing.Size(211, 20);
            this.comboBoxCode1.TabIndex = 9;
            // 
            // FRM12P
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 146);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM12P";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "退保設定";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private JBControls.TextBox txtOutDate;
        private System.Windows.Forms.Label label2;
        private JBControls.TextBox txtRoutDate;
        private System.Windows.Forms.Button bnSave;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxCode1;
    }
}