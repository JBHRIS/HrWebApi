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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.dtpCountDate = new System.Windows.Forms.DateTimePicker();
            this.lbCountDate = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.txtCountResult = new System.Windows.Forms.TextBox();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.tlpFilterSub = new System.Windows.Forms.TableLayoutPanel();
            this.lbFilter = new System.Windows.Forms.Label();
            this.bnColumnFilter = new System.Windows.Forms.Button();
            this.btnCount = new System.Windows.Forms.Button();
            this.bsData = new System.Windows.Forms.BindingSource(this.components);
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.tlpFilterSub.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.ColumnCount = 7;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tlpMain.Controls.Add(this.dtpCountDate, 1, 0);
            this.tlpMain.Controls.Add(this.lbCountDate, 0, 0);
            this.tlpMain.Controls.Add(this.dgv, 0, 2);
            this.tlpMain.Controls.Add(this.txtCountResult, 5, 0);
            this.tlpMain.Controls.Add(this.textBoxFilter, 1, 1);
            this.tlpMain.Controls.Add(this.tlpFilterSub, 0, 1);
            this.tlpMain.Controls.Add(this.btnCount, 4, 1);
            this.tlpMain.Location = new System.Drawing.Point(12, 12);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 10;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(984, 677);
            this.tlpMain.TabIndex = 0;
            // 
            // dtpCountDate
            // 
            this.dtpCountDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpCountDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCountDate.Location = new System.Drawing.Point(143, 7);
            this.dtpCountDate.Name = "dtpCountDate";
            this.dtpCountDate.Size = new System.Drawing.Size(131, 22);
            this.dtpCountDate.TabIndex = 0;
            this.dtpCountDate.ValueChanged += new System.EventHandler(this.dtpCountDate_ValueChanged);
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
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlpMain.SetColumnSpan(this.dgv, 7);
            this.dgv.Location = new System.Drawing.Point(3, 121);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.tlpMain.SetRowSpan(this.dgv, 8);
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(978, 553);
            this.dgv.TabIndex = 3;
            // 
            // txtCountResult
            // 
            this.txtCountResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.SetColumnSpan(this.txtCountResult, 2);
            this.txtCountResult.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCountResult.Location = new System.Drawing.Point(703, 3);
            this.txtCountResult.Multiline = true;
            this.txtCountResult.Name = "txtCountResult";
            this.tlpMain.SetRowSpan(this.txtCountResult, 2);
            this.txtCountResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCountResult.Size = new System.Drawing.Size(278, 112);
            this.txtCountResult.TabIndex = 22;
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.SetColumnSpan(this.textBoxFilter, 3);
            this.textBoxFilter.Location = new System.Drawing.Point(143, 40);
            this.textBoxFilter.Multiline = true;
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxFilter.Size = new System.Drawing.Size(414, 75);
            this.textBoxFilter.TabIndex = 16;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
            this.textBoxFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFilter_KeyDown);
            // 
            // tlpFilterSub
            // 
            this.tlpFilterSub.ColumnCount = 1;
            this.tlpFilterSub.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFilterSub.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFilterSub.Controls.Add(this.lbFilter, 0, 0);
            this.tlpFilterSub.Controls.Add(this.bnColumnFilter, 0, 1);
            this.tlpFilterSub.Location = new System.Drawing.Point(3, 40);
            this.tlpFilterSub.Name = "tlpFilterSub";
            this.tlpFilterSub.RowCount = 2;
            this.tlpFilterSub.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFilterSub.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFilterSub.Size = new System.Drawing.Size(134, 75);
            this.tlpFilterSub.TabIndex = 23;
            // 
            // lbFilter
            // 
            this.lbFilter.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbFilter.AutoSize = true;
            this.lbFilter.Location = new System.Drawing.Point(78, 12);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(53, 12);
            this.lbFilter.TabIndex = 15;
            this.lbFilter.Text = "篩選條件";
            // 
            // bnColumnFilter
            // 
            this.bnColumnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bnColumnFilter.Location = new System.Drawing.Point(3, 44);
            this.bnColumnFilter.Name = "bnColumnFilter";
            this.bnColumnFilter.Size = new System.Drawing.Size(128, 23);
            this.bnColumnFilter.TabIndex = 21;
            this.bnColumnFilter.Text = "篩選欄位(0)";
            this.bnColumnFilter.UseVisualStyleBackColor = true;
            this.bnColumnFilter.Click += new System.EventHandler(this.bnColumnFilter_Click);
            // 
            // btnCount
            // 
            this.btnCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCount.Location = new System.Drawing.Point(563, 66);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(134, 23);
            this.btnCount.TabIndex = 2;
            this.btnCount.Text = "統計數量";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // FRM2_MealCount
            // 
            this.ClientSize = new System.Drawing.Size(1008, 701);
            this.Controls.Add(this.tlpMain);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM2_MealCount";
            this.Text = "用餐統計";
            this.Load += new System.EventHandler(this.FRM2_MealCount_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.tlpFilterSub.ResumeLayout(false);
            this.tlpFilterSub.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.DateTimePicker dtpCountDate;
        private System.Windows.Forms.Label lbCountDate;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lbFilter;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Button bnColumnFilter;
        private System.Windows.Forms.BindingSource bsData;
        private System.Windows.Forms.TextBox txtCountResult;
        private System.Windows.Forms.TableLayoutPanel tlpFilterSub;
    }
}
