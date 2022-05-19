namespace JBHR.Wel
{
    partial class FRM63N2_RepeatIDNO
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbCOMP = new System.Windows.Forms.Label();
            this.txtCOMP = new System.Windows.Forms.TextBox();
            this.lbIDNO = new System.Windows.Forms.Label();
            this.txtIDNO = new JBControls.TextBox();
            this.lbNOBR = new System.Windows.Forms.Label();
            this.dgv = new JBControls.DataGridView();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.lbCOMP, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCOMP, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbIDNO, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtIDNO, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbNOBR, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgv, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnIgnore, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnApply, 2, 7);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(644, 227);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbCOMP
            // 
            this.lbCOMP.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbCOMP.AutoSize = true;
            this.lbCOMP.Location = new System.Drawing.Point(51, 8);
            this.lbCOMP.Name = "lbCOMP";
            this.lbCOMP.Size = new System.Drawing.Size(53, 12);
            this.lbCOMP.TabIndex = 0;
            this.lbCOMP.Text = "公司名稱";
            // 
            // txtCOMP
            // 
            this.txtCOMP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txtCOMP, 3);
            this.txtCOMP.Location = new System.Drawing.Point(110, 3);
            this.txtCOMP.Name = "txtCOMP";
            this.txtCOMP.ReadOnly = true;
            this.txtCOMP.Size = new System.Drawing.Size(315, 22);
            this.txtCOMP.TabIndex = 1;
            this.txtCOMP.TabStop = false;
            // 
            // lbIDNO
            // 
            this.lbIDNO.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbIDNO.AutoSize = true;
            this.lbIDNO.Location = new System.Drawing.Point(51, 36);
            this.lbIDNO.Name = "lbIDNO";
            this.lbIDNO.Size = new System.Drawing.Size(53, 12);
            this.lbIDNO.TabIndex = 2;
            this.lbIDNO.Text = "身分證號";
            // 
            // txtIDNO
            // 
            this.txtIDNO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIDNO.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtIDNO.CaptionLabel = null;
            this.txtIDNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtIDNO.DecimalPlace = 2;
            this.txtIDNO.IsEmpty = true;
            this.txtIDNO.Location = new System.Drawing.Point(110, 31);
            this.txtIDNO.Mask = "";
            this.txtIDNO.MaxLength = -1;
            this.txtIDNO.Name = "txtIDNO";
            this.txtIDNO.PasswordChar = '\0';
            this.txtIDNO.ReadOnly = true;
            this.txtIDNO.ShowCalendarButton = true;
            this.txtIDNO.Size = new System.Drawing.Size(101, 22);
            this.txtIDNO.TabIndex = 3;
            this.txtIDNO.TabStop = false;
            this.txtIDNO.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // lbNOBR
            // 
            this.lbNOBR.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbNOBR.AutoSize = true;
            this.lbNOBR.Location = new System.Drawing.Point(63, 64);
            this.lbNOBR.Name = "lbNOBR";
            this.lbNOBR.Size = new System.Drawing.Size(41, 12);
            this.lbNOBR.TabIndex = 5;
            this.lbNOBR.Text = "合併為";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgv, 5);
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(110, 59);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.dgv, 5);
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(531, 134);
            this.dgv.TabIndex = 8;
            // 
            // btnIgnore
            // 
            this.btnIgnore.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnIgnore.Location = new System.Drawing.Point(457, 200);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(75, 23);
            this.btnIgnore.TabIndex = 7;
            this.btnIgnore.Text = "忽略";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnApply.Location = new System.Drawing.Point(217, 200);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "套用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // FRM71N2_RepeatIDNO
            // 
            this.ClientSize = new System.Drawing.Size(668, 251);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM71N2_RepeatIDNO";
            this.Load += new System.EventHandler(this.FRM62N2_RepeatIDNO_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbCOMP;
        private System.Windows.Forms.TextBox txtCOMP;
        private System.Windows.Forms.Label lbIDNO;
        private JBControls.TextBox txtIDNO;
        private System.Windows.Forms.Label lbNOBR;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnIgnore;
        private JBControls.DataGridView dgv;
    }
}
