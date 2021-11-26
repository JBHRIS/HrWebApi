namespace JBHR.Sal
{
    partial class FRM4WO_WriteOff
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbMemo = new System.Windows.Forms.Label();
            this.txtSeq = new JBControls.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtYymm = new JBControls.TextBox();
            this.ptxSalcode = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvSALABS = new System.Windows.Forms.DataGridView();
            this.lbDetail = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSALABS)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.43646F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.64703F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.00527F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.91124F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Controls.Add(this.lbMemo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSeq, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label22, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtYymm, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ptxSalcode, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.dgvSALABS, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbDetail, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtMemo, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33464F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33462F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33074F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(248, 356);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // lbMemo
            // 
            this.lbMemo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbMemo.AutoSize = true;
            this.lbMemo.Location = new System.Drawing.Point(29, 63);
            this.lbMemo.Name = "lbMemo";
            this.lbMemo.Size = new System.Drawing.Size(29, 12);
            this.lbMemo.TabIndex = 22;
            this.lbMemo.Text = "備註";
            // 
            // txtSeq
            // 
            this.txtSeq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeq.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSeq.CaptionLabel = this.label22;
            this.txtSeq.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSeq.DecimalPlace = 2;
            this.txtSeq.IsEmpty = true;
            this.txtSeq.Location = new System.Drawing.Point(211, 3);
            this.txtSeq.Mask = "";
            this.txtSeq.MaxLength = -1;
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.PasswordChar = '\0';
            this.txtSeq.ReadOnly = false;
            this.txtSeq.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSeq.ShowCalendarButton = true;
            this.txtSeq.Size = new System.Drawing.Size(34, 22);
            this.txtSeq.TabIndex = 1;
            this.txtSeq.ValidType = JBControls.TextBox.EValidType.String;
            this.txtSeq.Validated += new System.EventHandler(this.txtSeq_Validated);
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(150, 8);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 19;
            this.label22.Text = "還款期別";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "還款薪資代碼";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(4, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "還款年月";
            // 
            // txtYymm
            // 
            this.txtYymm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYymm.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYymm.CaptionLabel = this.label10;
            this.txtYymm.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.txtYymm, 2);
            this.txtYymm.DecimalPlace = 2;
            this.txtYymm.IsEmpty = true;
            this.txtYymm.Location = new System.Drawing.Point(64, 3);
            this.txtYymm.Mask = "";
            this.txtYymm.MaxLength = -1;
            this.txtYymm.Name = "txtYymm";
            this.txtYymm.PasswordChar = '\0';
            this.txtYymm.ReadOnly = false;
            this.txtYymm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtYymm.ShowCalendarButton = true;
            this.txtYymm.Size = new System.Drawing.Size(79, 22);
            this.txtYymm.TabIndex = 0;
            this.txtYymm.ValidType = JBControls.TextBox.EValidType.String;
            this.txtYymm.Validated += new System.EventHandler(this.txtYymm_Validated);
            // 
            // ptxSalcode
            // 
            this.ptxSalcode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.ptxSalcode, 3);
            this.ptxSalcode.FormattingEnabled = true;
            this.ptxSalcode.Location = new System.Drawing.Point(86, 32);
            this.ptxSalcode.Name = "ptxSalcode";
            this.ptxSalcode.Size = new System.Drawing.Size(156, 20);
            this.ptxSalcode.TabIndex = 2;
            // 
            // btnSave
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnSave, 2);
            this.btnSave.Location = new System.Drawing.Point(3, 330);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "銷假";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnCancel, 2);
            this.btnCancel.Location = new System.Drawing.Point(149, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvSALABS
            // 
            this.dgvSALABS.AllowUserToAddRows = false;
            this.dgvSALABS.AllowUserToDeleteRows = false;
            this.dgvSALABS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvSALABS, 5);
            this.dgvSALABS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSALABS.Location = new System.Drawing.Point(3, 108);
            this.dgvSALABS.Name = "dgvSALABS";
            this.dgvSALABS.ReadOnly = true;
            this.dgvSALABS.RowHeadersVisible = false;
            this.dgvSALABS.RowHeadersWidth = 62;
            this.dgvSALABS.RowTemplate.Height = 24;
            this.dgvSALABS.Size = new System.Drawing.Size(242, 216);
            this.dgvSALABS.TabIndex = 23;
            // 
            // lbDetail
            // 
            this.lbDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDetail.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbDetail, 2);
            this.lbDetail.Location = new System.Drawing.Point(3, 87);
            this.lbDetail.Name = "lbDetail";
            this.lbDetail.Size = new System.Drawing.Size(77, 12);
            this.lbDetail.TabIndex = 24;
            this.lbDetail.Text = "扣款明細：";
            // 
            // txtMemo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtMemo, 4);
            this.txtMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMemo.Location = new System.Drawing.Point(64, 59);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(181, 22);
            this.txtMemo.TabIndex = 3;
            // 
            // FRM4WO_WriteOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 380);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM4WO_WriteOff";
            this.Text = "FRM4WO_WriteOff";
            this.Load += new System.EventHandler(this.FRM4WO_WriteOff_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSALABS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private JBControls.TextBox txtSeq;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private JBControls.TextBox txtYymm;
        private System.Windows.Forms.ComboBox ptxSalcode;
        private System.Windows.Forms.DataGridView dgvSALABS;
        private System.Windows.Forms.Label lbDetail;
        private System.Windows.Forms.Label lbMemo;
        private System.Windows.Forms.TextBox txtMemo;
    }
}