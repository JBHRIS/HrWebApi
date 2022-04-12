namespace JBHR.Att.KCRCustom
{
    partial class FRM2_MealCount
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpCountDate = new System.Windows.Forms.DateTimePicker();
            this.lbCountDate = new System.Windows.Forms.Label();
            this.btnCount = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.lbFilter = new System.Windows.Forms.Label();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.bnColumnFilter = new System.Windows.Forms.Button();
            this.bsData = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.Controls.Add(this.dtpCountDate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbCountDate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCount, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgv, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbFilter, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxFilter, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.bnColumnFilter, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 5, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 677);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dtpCountDate
            // 
            this.dtpCountDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpCountDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCountDate.Location = new System.Drawing.Point(143, 7);
            this.dtpCountDate.Name = "dtpCountDate";
            this.dtpCountDate.Size = new System.Drawing.Size(131, 22);
            this.dtpCountDate.TabIndex = 0;
            // 
            // lbCountDate
            // 
            this.lbCountDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbCountDate.AutoSize = true;
            this.lbCountDate.Location = new System.Drawing.Point(84, 12);
            this.lbCountDate.Name = "lbCountDate";
            this.lbCountDate.Size = new System.Drawing.Size(53, 12);
            this.lbCountDate.TabIndex = 1;
            this.lbCountDate.Text = "統計日期";
            // 
            // btnCount
            // 
            this.btnCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCount.Location = new System.Drawing.Point(563, 7);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(134, 23);
            this.btnCount.TabIndex = 2;
            this.btnCount.Text = "統計數量";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgv, 7);
            this.dgv.Location = new System.Drawing.Point(3, 121);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.dgv, 8);
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(978, 553);
            this.dgv.TabIndex = 3;
            // 
            // lbFilter
            // 
            this.lbFilter.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbFilter.AutoSize = true;
            this.lbFilter.Location = new System.Drawing.Point(84, 71);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(53, 12);
            this.lbFilter.TabIndex = 15;
            this.lbFilter.Text = "篩選條件";
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxFilter, 3);
            this.textBoxFilter.Location = new System.Drawing.Point(143, 40);
            this.textBoxFilter.Multiline = true;
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxFilter.Size = new System.Drawing.Size(414, 75);
            this.textBoxFilter.TabIndex = 16;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
            this.textBoxFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFilter_KeyDown);
            // 
            // bnColumnFilter
            // 
            this.bnColumnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bnColumnFilter.Location = new System.Drawing.Point(563, 66);
            this.bnColumnFilter.Name = "bnColumnFilter";
            this.bnColumnFilter.Size = new System.Drawing.Size(134, 23);
            this.bnColumnFilter.TabIndex = 21;
            this.bnColumnFilter.Text = "篩選欄位(0)";
            this.bnColumnFilter.UseVisualStyleBackColor = true;
            this.bnColumnFilter.Click += new System.EventHandler(this.bnColumnFilter_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBox1, 2);
            this.textBox1.Location = new System.Drawing.Point(703, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.tableLayoutPanel1.SetRowSpan(this.textBox1, 2);
            this.textBox1.Size = new System.Drawing.Size(278, 112);
            this.textBox1.TabIndex = 22;
            // 
            // FRM2_MealCount
            // 
            this.ClientSize = new System.Drawing.Size(1008, 701);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM2_MealCount";
            this.Text = "用餐統計";
            this.Load += new System.EventHandler(this.FRM2_MealCount_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dtpCountDate;
        private System.Windows.Forms.Label lbCountDate;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lbFilter;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Button bnColumnFilter;
        private System.Windows.Forms.BindingSource bsData;
        private System.Windows.Forms.TextBox textBox1;
    }
}
