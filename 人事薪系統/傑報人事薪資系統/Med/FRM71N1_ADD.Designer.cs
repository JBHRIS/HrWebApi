
namespace JBHR.Med
{
    partial class FRM71N1_ADD
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
            this.lbMemo = new System.Windows.Forms.Label();
            this.lbD_AMT = new System.Windows.Forms.Label();
            this.lbRET_AMT = new System.Windows.Forms.Label();
            this.lbAMT = new System.Windows.Forms.Label();
            this.lbNobr = new System.Windows.Forms.Label();
            this.lbSubcode = new System.Windows.Forms.Label();
            this.lbFormat = new System.Windows.Forms.Label();
            this.lbComp = new System.Windows.Forms.Label();
            this.lbAdate = new System.Windows.Forms.Label();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.tBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.medDS = new JBHR.Med.MedDS();
            this.txtYYMM = new System.Windows.Forms.TextBox();
            this.txtSeq = new System.Windows.Forms.TextBox();
            this.cbxComp = new System.Windows.Forms.ComboBox();
            this.cbxFormat = new System.Windows.Forms.ComboBox();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtAMT = new JBControls.TextBox();
            this.txtD_AMT = new JBControls.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbNote1 = new System.Windows.Forms.Label();
            this.lbNote2 = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.cbxForsub = new System.Windows.Forms.ComboBox();
            this.chkIS_FILE = new JBControls.CheckBox();
            this.txtTAXNO = new System.Windows.Forms.TextBox();
            this.lbTAXNO = new System.Windows.Forms.Label();
            this.txtRET_AMT = new JBControls.TextBox();
            this.lbSUP_AMT = new System.Windows.Forms.Label();
            this.txtSUP_AMT = new JBControls.TextBox();
            this.tBASETableAdapter = new JBHR.Med.MedDSTableAdapters.TBASETableAdapter();
            this.TW_TAX_ITEMbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCopy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medDS)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TW_TAX_ITEMbindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMemo
            // 
            this.lbMemo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbMemo.AutoSize = true;
            this.lbMemo.Location = new System.Drawing.Point(48, 148);
            this.lbMemo.Name = "lbMemo";
            this.lbMemo.Size = new System.Drawing.Size(29, 12);
            this.lbMemo.TabIndex = 51;
            this.lbMemo.Text = "備註";
            // 
            // lbD_AMT
            // 
            this.lbD_AMT.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbD_AMT.AutoSize = true;
            this.lbD_AMT.ForeColor = System.Drawing.Color.Red;
            this.lbD_AMT.Location = new System.Drawing.Point(370, 36);
            this.lbD_AMT.Name = "lbD_AMT";
            this.lbD_AMT.Size = new System.Drawing.Size(53, 12);
            this.lbD_AMT.TabIndex = 50;
            this.lbD_AMT.Text = "扣繳稅額";
            // 
            // lbRET_AMT
            // 
            this.lbRET_AMT.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbRET_AMT.AutoSize = true;
            this.lbRET_AMT.ForeColor = System.Drawing.Color.Black;
            this.lbRET_AMT.Location = new System.Drawing.Point(358, 92);
            this.lbRET_AMT.Name = "lbRET_AMT";
            this.lbRET_AMT.Size = new System.Drawing.Size(65, 12);
            this.lbRET_AMT.TabIndex = 49;
            this.lbRET_AMT.Text = "自提退休金";
            // 
            // lbAMT
            // 
            this.lbAMT.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbAMT.AutoSize = true;
            this.lbAMT.ForeColor = System.Drawing.Color.Red;
            this.lbAMT.Location = new System.Drawing.Point(370, 8);
            this.lbAMT.Name = "lbAMT";
            this.lbAMT.Size = new System.Drawing.Size(53, 12);
            this.lbAMT.TabIndex = 48;
            this.lbAMT.Text = "給付總額";
            // 
            // lbNobr
            // 
            this.lbNobr.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbNobr.AutoSize = true;
            this.lbNobr.ForeColor = System.Drawing.Color.Red;
            this.lbNobr.Location = new System.Drawing.Point(12, 8);
            this.lbNobr.Name = "lbNobr";
            this.lbNobr.Size = new System.Drawing.Size(65, 12);
            this.lbNobr.TabIndex = 47;
            this.lbNobr.Text = "所得人編號";
            // 
            // lbSubcode
            // 
            this.lbSubcode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbSubcode.AutoSize = true;
            this.lbSubcode.ForeColor = System.Drawing.Color.Red;
            this.lbSubcode.Location = new System.Drawing.Point(24, 120);
            this.lbSubcode.Name = "lbSubcode";
            this.lbSubcode.Size = new System.Drawing.Size(53, 12);
            this.lbSubcode.TabIndex = 45;
            this.lbSubcode.Text = "所得註記";
            // 
            // lbFormat
            // 
            this.lbFormat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbFormat.AutoSize = true;
            this.lbFormat.ForeColor = System.Drawing.Color.Red;
            this.lbFormat.Location = new System.Drawing.Point(24, 92);
            this.lbFormat.Name = "lbFormat";
            this.lbFormat.Size = new System.Drawing.Size(53, 12);
            this.lbFormat.TabIndex = 44;
            this.lbFormat.Text = "所得格式";
            // 
            // lbComp
            // 
            this.lbComp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbComp.AutoSize = true;
            this.lbComp.ForeColor = System.Drawing.Color.Red;
            this.lbComp.Location = new System.Drawing.Point(48, 64);
            this.lbComp.Name = "lbComp";
            this.lbComp.Size = new System.Drawing.Size(29, 12);
            this.lbComp.TabIndex = 46;
            this.lbComp.Text = "公司";
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
            // cbxComp
            // 
            this.cbxComp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxComp, 3);
            this.cbxComp.FormattingEnabled = true;
            this.cbxComp.Location = new System.Drawing.Point(83, 60);
            this.cbxComp.Name = "cbxComp";
            this.cbxComp.Size = new System.Drawing.Size(200, 20);
            this.cbxComp.TabIndex = 4;
            // 
            // cbxFormat
            // 
            this.cbxFormat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxFormat, 2);
            this.cbxFormat.FormattingEnabled = true;
            this.cbxFormat.Location = new System.Drawing.Point(83, 88);
            this.cbxFormat.Name = "cbxFormat";
            this.cbxFormat.Size = new System.Drawing.Size(120, 20);
            this.cbxFormat.TabIndex = 5;
            this.cbxFormat.SelectedValueChanged += new System.EventHandler(this.cbxFormat_SelectedValueChanged);
            // 
            // txtMemo
            // 
            this.txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtMemo, 5);
            this.txtMemo.Location = new System.Drawing.Point(83, 143);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(340, 22);
            this.txtMemo.TabIndex = 12;
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
            this.tableLayoutPanel1.Controls.Add(this.lbD_AMT, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbComp, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxComp, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbAMT, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSeq, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtAMT, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtD_AMT, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbMemo, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtMemo, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.lbNote1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lbNote2, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.lbFormat, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxFormat, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbSubcode, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbMessage, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxForsub, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkIS_FILE, 6, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtTAXNO, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbTAXNO, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbRET_AMT, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtRET_AMT, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbSUP_AMT, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSUP_AMT, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCopy, 6, 7);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(503, 227);
            this.tableLayoutPanel1.TabIndex = 63;
            // 
            // txtAMT
            // 
            this.txtAMT.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAMT.CaptionLabel = null;
            this.txtAMT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAMT.DecimalPlace = 2;
            this.txtAMT.IsEmpty = false;
            this.txtAMT.Location = new System.Drawing.Point(429, 3);
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
            this.txtD_AMT.Location = new System.Drawing.Point(429, 31);
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
            // btnSave
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnSave, 2);
            this.btnSave.Location = new System.Drawing.Point(159, 199);
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
            this.btnCancel.Location = new System.Drawing.Point(289, 199);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 67;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbNote1
            // 
            this.lbNote1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbNote1.AutoSize = true;
            this.lbNote1.ForeColor = System.Drawing.Color.Black;
            this.lbNote1.Location = new System.Drawing.Point(42, 176);
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
            this.lbNote2.Location = new System.Drawing.Point(248, 176);
            this.lbNote2.Name = "lbNote2";
            this.lbNote2.Size = new System.Drawing.Size(35, 12);
            this.lbNote2.TabIndex = 73;
            this.lbNote2.Text = "NOTE2";
            // 
            // lbMessage
            // 
            this.lbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMessage.AutoSize = true;
            this.lbMessage.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Location = new System.Drawing.Point(289, 92);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(54, 12);
            this.lbMessage.TabIndex = 74;
            // 
            // cbxForsub
            // 
            this.cbxForsub.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxForsub, 3);
            this.cbxForsub.FormattingEnabled = true;
            this.cbxForsub.Location = new System.Drawing.Point(83, 116);
            this.cbxForsub.Name = "cbxForsub";
            this.cbxForsub.Size = new System.Drawing.Size(200, 20);
            this.cbxForsub.TabIndex = 6;
            // 
            // chkIS_FILE
            // 
            this.chkIS_FILE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIS_FILE.AutoSize = true;
            this.chkIS_FILE.CaptionLabel = null;
            this.chkIS_FILE.IsImitateCaption = true;
            this.chkIS_FILE.Location = new System.Drawing.Point(429, 146);
            this.chkIS_FILE.Name = "chkIS_FILE";
            this.chkIS_FILE.Size = new System.Drawing.Size(71, 16);
            this.chkIS_FILE.TabIndex = 13;
            this.chkIS_FILE.Text = "已申報";
            this.chkIS_FILE.UseVisualStyleBackColor = true;
            // 
            // txtTAXNO
            // 
            this.txtTAXNO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtTAXNO, 2);
            this.txtTAXNO.Location = new System.Drawing.Point(349, 115);
            this.txtTAXNO.Name = "txtTAXNO";
            this.txtTAXNO.Size = new System.Drawing.Size(151, 22);
            this.txtTAXNO.TabIndex = 11;
            // 
            // lbTAXNO
            // 
            this.lbTAXNO.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTAXNO.AutoSize = true;
            this.lbTAXNO.Location = new System.Drawing.Point(290, 120);
            this.lbTAXNO.Name = "lbTAXNO";
            this.lbTAXNO.Size = new System.Drawing.Size(53, 12);
            this.lbTAXNO.TabIndex = 75;
            this.lbTAXNO.Text = "稅籍編號";
            // 
            // txtRET_AMT
            // 
            this.txtRET_AMT.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtRET_AMT.CaptionLabel = null;
            this.txtRET_AMT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRET_AMT.DecimalPlace = 2;
            this.txtRET_AMT.IsEmpty = false;
            this.txtRET_AMT.Location = new System.Drawing.Point(429, 87);
            this.txtRET_AMT.Mask = "";
            this.txtRET_AMT.MaxLength = -1;
            this.txtRET_AMT.Name = "txtRET_AMT";
            this.txtRET_AMT.PasswordChar = '\0';
            this.txtRET_AMT.ReadOnly = false;
            this.txtRET_AMT.ShowCalendarButton = false;
            this.txtRET_AMT.Size = new System.Drawing.Size(71, 22);
            this.txtRET_AMT.TabIndex = 10;
            this.txtRET_AMT.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // lbSUP_AMT
            // 
            this.lbSUP_AMT.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbSUP_AMT.AutoSize = true;
            this.lbSUP_AMT.ForeColor = System.Drawing.Color.Black;
            this.lbSUP_AMT.Location = new System.Drawing.Point(370, 64);
            this.lbSUP_AMT.Name = "lbSUP_AMT";
            this.lbSUP_AMT.Size = new System.Drawing.Size(53, 12);
            this.lbSUP_AMT.TabIndex = 76;
            this.lbSUP_AMT.Text = "補充保費";
            // 
            // txtSUP_AMT
            // 
            this.txtSUP_AMT.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSUP_AMT.CaptionLabel = null;
            this.txtSUP_AMT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSUP_AMT.DecimalPlace = 2;
            this.txtSUP_AMT.IsEmpty = false;
            this.txtSUP_AMT.Location = new System.Drawing.Point(429, 59);
            this.txtSUP_AMT.Mask = "";
            this.txtSUP_AMT.MaxLength = -1;
            this.txtSUP_AMT.Name = "txtSUP_AMT";
            this.txtSUP_AMT.PasswordChar = '\0';
            this.txtSUP_AMT.ReadOnly = false;
            this.txtSUP_AMT.ShowCalendarButton = false;
            this.txtSUP_AMT.Size = new System.Drawing.Size(71, 22);
            this.txtSUP_AMT.TabIndex = 9;
            this.txtSUP_AMT.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // tBASETableAdapter
            // 
            this.tBASETableAdapter.ClearBeforeFill = true;
            // 
            // TW_TAX_ITEMbindingSource
            // 
            this.TW_TAX_ITEMbindingSource.DataSource = typeof(JBModule.Data.Linq.TW_TAX_ITEM);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCopy.Location = new System.Drawing.Point(429, 200);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(71, 23);
            this.btnCopy.TabIndex = 77;
            this.btnCopy.Text = "複製";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // FRM71N1_ADD
            // 
            this.ClientSize = new System.Drawing.Size(527, 252);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM71N1_ADD";
            this.Load += new System.EventHandler(this.FRM71N1_ADD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medDS)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TW_TAX_ITEMbindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbMemo;
        private System.Windows.Forms.Label lbD_AMT;
        private System.Windows.Forms.Label lbRET_AMT;
        private System.Windows.Forms.Label lbAMT;
        private System.Windows.Forms.Label lbNobr;
        private System.Windows.Forms.Label lbSubcode;
        private System.Windows.Forms.Label lbFormat;
        private System.Windows.Forms.Label lbComp;
        private System.Windows.Forms.Label lbAdate;
        private JBControls.PopupTextBox ptxNobr;
        private System.Windows.Forms.TextBox txtYYMM;
        private System.Windows.Forms.TextBox txtSeq;
        private System.Windows.Forms.ComboBox cbxComp;
        private System.Windows.Forms.ComboBox cbxFormat;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbxForsub;
        private System.Windows.Forms.BindingSource TW_TAX_ITEMbindingSource;
        private JBControls.TextBox txtAMT;
        private JBControls.TextBox txtD_AMT;
        private JBControls.TextBox txtRET_AMT;
        private JBControls.CheckBox chkIS_FILE;
        private System.Windows.Forms.TextBox txtTAXNO;
        private MedDSTableAdapters.TBASETableAdapter tBASETableAdapter;
        private System.Windows.Forms.BindingSource tBASEBindingSource;
        private MedDS medDS;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbNote1;
        private System.Windows.Forms.Label lbNote2;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Label lbTAXNO;
        private System.Windows.Forms.Label lbSUP_AMT;
        private JBControls.TextBox txtSUP_AMT;
        private System.Windows.Forms.Button btnCopy;
    }
}
