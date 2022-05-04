namespace JBHR.Wel
{
    partial class FRM62N_ADD
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
            this.lbNobr = new System.Windows.Forms.Label();
            this.lbAdate = new System.Windows.Forms.Label();
            this.txtYYMM = new System.Windows.Forms.TextBox();
            this.txtSeq = new System.Windows.Forms.TextBox();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.tBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.medDS = new JBHR.Med.MedDS();
            this.lbNote1 = new System.Windows.Forms.Label();
            this.lbNote2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lbFormat = new System.Windows.Forms.Label();
            this.cbxFormat = new System.Windows.Forms.ComboBox();
            this.lbAMT = new System.Windows.Forms.Label();
            this.lbD_AMT = new System.Windows.Forms.Label();
            this.txtAMT = new JBControls.TextBox();
            this.txtD_AMT = new JBControls.TextBox();
            this.lbWCode = new System.Windows.Forms.Label();
            this.cbxWCode = new System.Windows.Forms.ComboBox();
            this.tBASETableAdapter = new JBHR.Med.MedDSTableAdapters.TBASETableAdapter();
            this.lbMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medDS)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbNobr, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbAdate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtYYMM, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSeq, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbNote1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbNote2, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCopy, 6, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbFormat, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxFormat, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbAMT, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbD_AMT, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtAMT, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtD_AMT, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbWCode, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxWCode, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbMessage, 6, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(503, 142);
            this.tableLayoutPanel1.TabIndex = 64;
            // 
            // lbNobr
            // 
            this.lbNobr.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbNobr.AutoSize = true;
            this.lbNobr.ForeColor = System.Drawing.Color.Red;
            this.lbNobr.Location = new System.Drawing.Point(24, 8);
            this.lbNobr.Name = "lbNobr";
            this.lbNobr.Size = new System.Drawing.Size(53, 12);
            this.lbNobr.TabIndex = 47;
            this.lbNobr.Text = "員工編號";
            // 
            // lbAdate
            // 
            this.lbAdate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbAdate.AutoSize = true;
            this.lbAdate.ForeColor = System.Drawing.Color.Red;
            this.lbAdate.Location = new System.Drawing.Point(24, 36);
            this.lbAdate.Name = "lbAdate";
            this.lbAdate.Size = new System.Drawing.Size(53, 12);
            this.lbAdate.TabIndex = 43;
            this.lbAdate.Text = "所得年月";
            // 
            // txtYYMM
            // 
            this.txtYYMM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYYMM.Location = new System.Drawing.Point(83, 31);
            this.txtYYMM.Name = "txtYYMM";
            this.txtYYMM.Size = new System.Drawing.Size(70, 22);
            this.txtYYMM.TabIndex = 2;
            this.txtYYMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSeq
            // 
            this.txtSeq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeq.Location = new System.Drawing.Point(159, 31);
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.Size = new System.Drawing.Size(44, 22);
            this.txtSeq.TabIndex = 3;
            this.txtSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ptxNobr
            // 
            this.ptxNobr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ptxNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobr.CaptionLabel = null;
            this.ptxNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.ptxNobr, 3);
            this.ptxNobr.DataSource = this.tBASEBindingSource;
            this.ptxNobr.DisplayMember = "name_c";
            this.ptxNobr.IsEmpty = false;
            this.ptxNobr.IsEmptyToQuery = true;
            this.ptxNobr.IsMustBeFound = true;
            this.ptxNobr.LabelText = "";
            this.ptxNobr.Location = new System.Drawing.Point(83, 3);
            this.ptxNobr.Name = "ptxNobr";
            this.ptxNobr.ReadOnly = false;
            this.ptxNobr.ShowDisplayName = true;
            this.ptxNobr.Size = new System.Drawing.Size(96, 22);
            this.ptxNobr.TabIndex = 1;
            this.ptxNobr.ValueMember = "nobr";
            this.ptxNobr.WhereCmd = "";
            this.ptxNobr.QueryCompleted += new JBControls.PopupTextBox.QueryCompletedHandler(this.ptxNobr_QueryCompleted);
            // 
            // tBASEBindingSource
            // 
            this.tBASEBindingSource.DataMember = "TBASE";
            this.tBASEBindingSource.DataSource = this.medDS;
            // 
            // medDS
            // 
            this.medDS.DataSetName = "MedDS";
            this.medDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.medDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.medDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbNote1
            // 
            this.lbNote1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbNote1.AutoSize = true;
            this.lbNote1.ForeColor = System.Drawing.Color.Black;
            this.lbNote1.Location = new System.Drawing.Point(42, 92);
            this.lbNote1.Name = "lbNote1";
            this.lbNote1.Size = new System.Drawing.Size(35, 12);
            this.lbNote1.TabIndex = 72;
            this.lbNote1.Text = "NOTE1";
            // 
            // lbNote2
            // 
            this.lbNote2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbNote2.AutoSize = true;
            this.lbNote2.ForeColor = System.Drawing.Color.Black;
            this.lbNote2.Location = new System.Drawing.Point(248, 92);
            this.lbNote2.Name = "lbNote2";
            this.lbNote2.Size = new System.Drawing.Size(35, 12);
            this.lbNote2.TabIndex = 73;
            this.lbNote2.Text = "NOTE2";
            // 
            // btnSave
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnSave, 2);
            this.btnSave.Location = new System.Drawing.Point(159, 115);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 66;
            this.btnSave.Text = "存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnCancel, 2);
            this.btnCancel.Location = new System.Drawing.Point(289, 115);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 67;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCopy.Location = new System.Drawing.Point(429, 115);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(71, 23);
            this.btnCopy.TabIndex = 77;
            this.btnCopy.Text = "複製";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lbFormat
            // 
            this.lbFormat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbFormat.AutoSize = true;
            this.lbFormat.ForeColor = System.Drawing.Color.Red;
            this.lbFormat.Location = new System.Drawing.Point(290, 8);
            this.lbFormat.Name = "lbFormat";
            this.lbFormat.Size = new System.Drawing.Size(53, 12);
            this.lbFormat.TabIndex = 44;
            this.lbFormat.Text = "所得格式";
            // 
            // cbxFormat
            // 
            this.cbxFormat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxFormat, 2);
            this.cbxFormat.FormattingEnabled = true;
            this.cbxFormat.Location = new System.Drawing.Point(349, 4);
            this.cbxFormat.Name = "cbxFormat";
            this.cbxFormat.Size = new System.Drawing.Size(120, 20);
            this.cbxFormat.TabIndex = 5;
            // 
            // lbAMT
            // 
            this.lbAMT.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbAMT.AutoSize = true;
            this.lbAMT.ForeColor = System.Drawing.Color.Red;
            this.lbAMT.Location = new System.Drawing.Point(290, 36);
            this.lbAMT.Name = "lbAMT";
            this.lbAMT.Size = new System.Drawing.Size(53, 12);
            this.lbAMT.TabIndex = 48;
            this.lbAMT.Text = "給付總額";
            // 
            // lbD_AMT
            // 
            this.lbD_AMT.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbD_AMT.AutoSize = true;
            this.lbD_AMT.ForeColor = System.Drawing.Color.Red;
            this.lbD_AMT.Location = new System.Drawing.Point(290, 64);
            this.lbD_AMT.Name = "lbD_AMT";
            this.lbD_AMT.Size = new System.Drawing.Size(53, 12);
            this.lbD_AMT.TabIndex = 50;
            this.lbD_AMT.Text = "扣繳稅額";
            // 
            // txtAMT
            // 
            this.txtAMT.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAMT.CaptionLabel = null;
            this.txtAMT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAMT.DecimalPlace = 2;
            this.txtAMT.IsEmpty = false;
            this.txtAMT.Location = new System.Drawing.Point(349, 31);
            this.txtAMT.Mask = "";
            this.txtAMT.MaxLength = -1;
            this.txtAMT.Name = "txtAMT";
            this.txtAMT.PasswordChar = '\0';
            this.txtAMT.ReadOnly = false;
            this.txtAMT.ShowCalendarButton = false;
            this.txtAMT.Size = new System.Drawing.Size(71, 22);
            this.txtAMT.TabIndex = 7;
            this.txtAMT.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // txtD_AMT
            // 
            this.txtD_AMT.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtD_AMT.CaptionLabel = null;
            this.txtD_AMT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtD_AMT.DecimalPlace = 2;
            this.txtD_AMT.IsEmpty = false;
            this.txtD_AMT.Location = new System.Drawing.Point(349, 59);
            this.txtD_AMT.Mask = "";
            this.txtD_AMT.MaxLength = -1;
            this.txtD_AMT.Name = "txtD_AMT";
            this.txtD_AMT.PasswordChar = '\0';
            this.txtD_AMT.ReadOnly = false;
            this.txtD_AMT.ShowCalendarButton = false;
            this.txtD_AMT.Size = new System.Drawing.Size(71, 22);
            this.txtD_AMT.TabIndex = 8;
            this.txtD_AMT.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // lbWCode
            // 
            this.lbWCode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbWCode.AutoSize = true;
            this.lbWCode.ForeColor = System.Drawing.Color.Black;
            this.lbWCode.Location = new System.Drawing.Point(12, 64);
            this.lbWCode.Name = "lbWCode";
            this.lbWCode.Size = new System.Drawing.Size(65, 12);
            this.lbWCode.TabIndex = 78;
            this.lbWCode.Text = "福利金代號";
            // 
            // cbxWCode
            // 
            this.cbxWCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxWCode, 2);
            this.cbxWCode.FormattingEnabled = true;
            this.cbxWCode.Location = new System.Drawing.Point(83, 60);
            this.cbxWCode.Name = "cbxWCode";
            this.cbxWCode.Size = new System.Drawing.Size(120, 20);
            this.cbxWCode.TabIndex = 79;
            // 
            // tBASETableAdapter
            // 
            this.tBASETableAdapter.ClearBeforeFill = true;
            // 
            // lbMessage
            // 
            this.lbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMessage.AutoSize = true;
            this.lbMessage.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Location = new System.Drawing.Point(429, 64);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(71, 12);
            this.lbMessage.TabIndex = 80;
            // 
            // FRM62N_ADD
            // 
            this.ClientSize = new System.Drawing.Size(527, 170);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM62N_ADD";
            this.Text = "FRM62N_ADD";
            this.Load += new System.EventHandler(this.FRM62N_ADD_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbNobr;
        private System.Windows.Forms.Label lbAdate;
        private System.Windows.Forms.TextBox txtYYMM;
        private System.Windows.Forms.Label lbD_AMT;
        private System.Windows.Forms.Label lbAMT;
        private System.Windows.Forms.TextBox txtSeq;
        private JBControls.TextBox txtAMT;
        private JBControls.TextBox txtD_AMT;
        private JBControls.PopupTextBox ptxNobr;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbNote1;
        private System.Windows.Forms.Label lbNote2;
        private System.Windows.Forms.Label lbFormat;
        private System.Windows.Forms.ComboBox cbxFormat;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lbWCode;
        private System.Windows.Forms.ComboBox cbxWCode;
        private System.Windows.Forms.BindingSource tBASEBindingSource;
        private Med.MedDS medDS;
        private Med.MedDSTableAdapters.TBASETableAdapter tBASETableAdapter;
        private System.Windows.Forms.Label lbMessage;
    }
}
