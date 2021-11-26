namespace JBHR.Ins
{
    partial class FRM3U
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
            this.components = new System.ComponentModel.Container();
            this.iNSCOUNTRYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.insDS = new JBHR.Ins.InsDS();
            this.eMPCDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.iNSCOMPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.eMPCDTableAdapter = new JBHR.Bas.BasDSTableAdapters.EMPCDTableAdapter();
            this.dEPTTableAdapter = new JBHR.Bas.BasDSTableAdapters.DEPTTableAdapter();
            this.iNSCOMPTableAdapter = new JBHR.Ins.InsDSTableAdapters.INSCOMPTableAdapter();
            this.iNSCOUNTRYTableAdapter = new JBHR.Ins.InsDSTableAdapters.INSCOUNTRYTableAdapter();
            this.v_BASETableAdapter = new JBHR.Ins.InsDSTableAdapters.V_BASETableAdapter();
            this.popupTextBoxNOBRE = new JBControls.PopupTextBox();
            this.popupTextBoxNOBRB = new JBControls.PopupTextBox();
            this.textBoxNET_TXT = new JBControls.TextBox();
            this.textBoxNET_CHK = new JBControls.TextBox();
            this.textBoxNET_NO = new JBControls.TextBox();
            this.textBoxADATE = new JBControls.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbINSCOMP = new System.Windows.Forms.ComboBox();
            this.cbFORMAT = new System.Windows.Forms.ComboBox();
            this.cbEmpcdB = new System.Windows.Forms.ComboBox();
            this.cbCountcd = new System.Windows.Forms.ComboBox();
            this.cbBRCH = new System.Windows.Forms.ComboBox();
            this.cbEmpcdE = new System.Windows.Forms.ComboBox();
            this.cbDeptB = new System.Windows.Forms.ComboBox();
            this.cbDeptE = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.iNSCOUNTRYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.insDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eMPCDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNSCOMPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iNSCOUNTRYBindingSource
            // 
            this.iNSCOUNTRYBindingSource.DataMember = "INSCOUNTRY";
            this.iNSCOUNTRYBindingSource.DataSource = this.insDS;
            // 
            // insDS
            // 
            this.insDS.DataSetName = "InsDS";
            this.insDS.Locale = new System.Globalization.CultureInfo("");
            this.insDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.insDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eMPCDBindingSource
            // 
            this.eMPCDBindingSource.DataMember = "EMPCD";
            this.eMPCDBindingSource.DataSource = this.basDS;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // iNSCOMPBindingSource
            // 
            this.iNSCOMPBindingSource.DataMember = "INSCOMP";
            this.iNSCOMPBindingSource.DataSource = this.insDS;
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.insDS;
            // 
            // dEPTBindingSource
            // 
            this.dEPTBindingSource.DataMember = "DEPT";
            this.dEPTBindingSource.DataSource = this.basDS;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "產生";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(243, 313);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.TabStop = false;
            this.button2.Text = "離開";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // eMPCDTableAdapter
            // 
            this.eMPCDTableAdapter.ClearBeforeFill = true;
            // 
            // dEPTTableAdapter
            // 
            this.dEPTTableAdapter.ClearBeforeFill = true;
            // 
            // iNSCOMPTableAdapter
            // 
            this.iNSCOMPTableAdapter.ClearBeforeFill = true;
            // 
            // iNSCOUNTRYTableAdapter
            // 
            this.iNSCOUNTRYTableAdapter.ClearBeforeFill = true;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // popupTextBoxNOBRE
            // 
            this.popupTextBoxNOBRE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.popupTextBoxNOBRE.CaptionLabel = null;
            this.popupTextBoxNOBRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.popupTextBoxNOBRE.DataSource = this.vBASEBindingSource;
            this.popupTextBoxNOBRE.DisplayMember = "name_c";
            this.popupTextBoxNOBRE.IsEmpty = false;
            this.popupTextBoxNOBRE.IsEmptyToQuery = true;
            this.popupTextBoxNOBRE.IsMustBeFound = true;
            this.popupTextBoxNOBRE.LabelText = "";
            this.popupTextBoxNOBRE.Location = new System.Drawing.Point(324, 109);
            this.popupTextBoxNOBRE.Name = "popupTextBoxNOBRE";
            this.popupTextBoxNOBRE.QueryFields = "name_e,name_p";
            this.popupTextBoxNOBRE.ReadOnly = false;
            this.popupTextBoxNOBRE.ShowDisplayName = true;
            this.popupTextBoxNOBRE.Size = new System.Drawing.Size(83, 22);
            this.popupTextBoxNOBRE.TabIndex = 6;
            this.popupTextBoxNOBRE.ValueMember = "nobr";
            this.popupTextBoxNOBRE.WhereCmd = "";
            // 
            // popupTextBoxNOBRB
            // 
            this.popupTextBoxNOBRB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.popupTextBoxNOBRB.CaptionLabel = null;
            this.popupTextBoxNOBRB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.popupTextBoxNOBRB.DataSource = this.vBASEBindingSource;
            this.popupTextBoxNOBRB.DisplayMember = "name_c";
            this.popupTextBoxNOBRB.IsEmpty = false;
            this.popupTextBoxNOBRB.IsEmptyToQuery = true;
            this.popupTextBoxNOBRB.IsMustBeFound = true;
            this.popupTextBoxNOBRB.LabelText = "";
            this.popupTextBoxNOBRB.Location = new System.Drawing.Point(152, 109);
            this.popupTextBoxNOBRB.Name = "popupTextBoxNOBRB";
            this.popupTextBoxNOBRB.QueryFields = "name_e,name_p";
            this.popupTextBoxNOBRB.ReadOnly = false;
            this.popupTextBoxNOBRB.ShowDisplayName = true;
            this.popupTextBoxNOBRB.Size = new System.Drawing.Size(83, 22);
            this.popupTextBoxNOBRB.TabIndex = 5;
            this.popupTextBoxNOBRB.ValueMember = "nobr";
            this.popupTextBoxNOBRB.WhereCmd = "";
            // 
            // textBoxNET_TXT
            // 
            this.textBoxNET_TXT.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxNET_TXT.CaptionLabel = null;
            this.textBoxNET_TXT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxNET_TXT, 3);
            this.textBoxNET_TXT.DecimalPlace = 2;
            this.textBoxNET_TXT.IsEmpty = true;
            this.textBoxNET_TXT.Location = new System.Drawing.Point(152, 271);
            this.textBoxNET_TXT.Mask = "";
            this.textBoxNET_TXT.MaxLength = -1;
            this.textBoxNET_TXT.Name = "textBoxNET_TXT";
            this.textBoxNET_TXT.PasswordChar = '\0';
            this.textBoxNET_TXT.ReadOnly = false;
            this.textBoxNET_TXT.ShowCalendarButton = true;
            this.textBoxNET_TXT.Size = new System.Drawing.Size(316, 22);
            this.textBoxNET_TXT.TabIndex = 13;
            this.textBoxNET_TXT.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBoxNET_CHK
            // 
            this.textBoxNET_CHK.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxNET_CHK.CaptionLabel = null;
            this.textBoxNET_CHK.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxNET_CHK.DecimalPlace = 2;
            this.textBoxNET_CHK.IsEmpty = true;
            this.textBoxNET_CHK.Location = new System.Drawing.Point(152, 243);
            this.textBoxNET_CHK.Mask = "";
            this.textBoxNET_CHK.MaxLength = -1;
            this.textBoxNET_CHK.Name = "textBoxNET_CHK";
            this.textBoxNET_CHK.PasswordChar = '\0';
            this.textBoxNET_CHK.ReadOnly = false;
            this.textBoxNET_CHK.ShowCalendarButton = true;
            this.textBoxNET_CHK.Size = new System.Drawing.Size(56, 22);
            this.textBoxNET_CHK.TabIndex = 12;
            this.textBoxNET_CHK.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBoxNET_NO
            // 
            this.textBoxNET_NO.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxNET_NO.CaptionLabel = null;
            this.textBoxNET_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxNET_NO.DecimalPlace = 2;
            this.textBoxNET_NO.IsEmpty = true;
            this.textBoxNET_NO.Location = new System.Drawing.Point(152, 215);
            this.textBoxNET_NO.Mask = "";
            this.textBoxNET_NO.MaxLength = -1;
            this.textBoxNET_NO.Name = "textBoxNET_NO";
            this.textBoxNET_NO.PasswordChar = '\0';
            this.textBoxNET_NO.ReadOnly = false;
            this.textBoxNET_NO.ShowCalendarButton = true;
            this.textBoxNET_NO.Size = new System.Drawing.Size(143, 22);
            this.textBoxNET_NO.TabIndex = 11;
            this.textBoxNET_NO.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBoxADATE
            // 
            this.textBoxADATE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxADATE.CaptionLabel = null;
            this.textBoxADATE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxADATE.DecimalPlace = 2;
            this.textBoxADATE.IsEmpty = true;
            this.textBoxADATE.Location = new System.Drawing.Point(152, 55);
            this.textBoxADATE.Mask = "0000/00/00";
            this.textBoxADATE.MaxLength = -1;
            this.textBoxADATE.Name = "textBoxADATE";
            this.textBoxADATE.PasswordChar = '\0';
            this.textBoxADATE.ReadOnly = false;
            this.textBoxADATE.ShowCalendarButton = true;
            this.textBoxADATE.Size = new System.Drawing.Size(66, 22);
            this.textBoxADATE.TabIndex = 2;
            this.textBoxADATE.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(57, 276);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(89, 12);
            this.label22.TabIndex = 21;
            this.label22.Text = "網路申報文字檔";
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(3, 248);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(143, 12);
            this.label21.TabIndex = 20;
            this.label21.Text = "網路申報-保險證號檢查碼";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(15, 220);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(131, 12);
            this.label20.TabIndex = 19;
            this.label20.Text = "網路申報-單位保險證號";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(81, 193);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 18;
            this.label19.Text = "投保者國別";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(81, 167);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 17;
            this.label18.Text = "健保分局別";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(301, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "至";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(93, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "部門代碼";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(301, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "至";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(93, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "員工編號";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(301, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "至";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(117, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "員別";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(93, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "異動日期";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(93, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "投保單位";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(93, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "檔案格式";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label18, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label19, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.label20, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.label21, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.label22, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.textBoxADATE, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxNET_NO, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.textBoxNET_CHK, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.textBoxNET_TXT, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.popupTextBoxNOBRE, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbINSCOMP, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbFORMAT, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbEmpcdB, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbCountcd, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.cbBRCH, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.cbEmpcdE, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbDeptB, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbDeptE, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.popupTextBoxNOBRB, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(476, 296);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbINSCOMP
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbINSCOMP, 3);
            this.cbINSCOMP.FormattingEnabled = true;
            this.cbINSCOMP.Location = new System.Drawing.Point(152, 29);
            this.cbINSCOMP.Name = "cbINSCOMP";
            this.cbINSCOMP.Size = new System.Drawing.Size(316, 20);
            this.cbINSCOMP.TabIndex = 1;
            this.cbINSCOMP.SelectedIndexChanged += new System.EventHandler(this.cbINSCOMP_SelectedIndexChange);
            // 
            // cbFORMAT
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbFORMAT, 3);
            this.cbFORMAT.FormattingEnabled = true;
            this.cbFORMAT.Location = new System.Drawing.Point(152, 3);
            this.cbFORMAT.Name = "cbFORMAT";
            this.cbFORMAT.Size = new System.Drawing.Size(316, 20);
            this.cbFORMAT.TabIndex = 0;
            this.cbFORMAT.SelectedIndexChanged += new System.EventHandler(this.cbFORMAT_Validated);
            // 
            // cbEmpcdB
            // 
            this.cbEmpcdB.FormattingEnabled = true;
            this.cbEmpcdB.Location = new System.Drawing.Point(152, 83);
            this.cbEmpcdB.Name = "cbEmpcdB";
            this.cbEmpcdB.Size = new System.Drawing.Size(143, 20);
            this.cbEmpcdB.TabIndex = 3;
            // 
            // cbCountcd
            // 
            this.cbCountcd.FormattingEnabled = true;
            this.cbCountcd.Location = new System.Drawing.Point(152, 189);
            this.cbCountcd.Name = "cbCountcd";
            this.cbCountcd.Size = new System.Drawing.Size(143, 20);
            this.cbCountcd.TabIndex = 10;
            // 
            // cbBRCH
            // 
            this.cbBRCH.FormattingEnabled = true;
            this.cbBRCH.Location = new System.Drawing.Point(152, 163);
            this.cbBRCH.Name = "cbBRCH";
            this.cbBRCH.Size = new System.Drawing.Size(143, 20);
            this.cbBRCH.TabIndex = 9;
            // 
            // cbEmpcdE
            // 
            this.cbEmpcdE.FormattingEnabled = true;
            this.cbEmpcdE.Location = new System.Drawing.Point(324, 83);
            this.cbEmpcdE.Name = "cbEmpcdE";
            this.cbEmpcdE.Size = new System.Drawing.Size(143, 20);
            this.cbEmpcdE.TabIndex = 4;
            // 
            // cbDeptB
            // 
            this.cbDeptB.FormattingEnabled = true;
            this.cbDeptB.Location = new System.Drawing.Point(152, 137);
            this.cbDeptB.Name = "cbDeptB";
            this.cbDeptB.Size = new System.Drawing.Size(143, 20);
            this.cbDeptB.TabIndex = 7;
            // 
            // cbDeptE
            // 
            this.cbDeptE.FormattingEnabled = true;
            this.cbDeptE.Location = new System.Drawing.Point(324, 137);
            this.cbDeptE.Name = "cbDeptE";
            this.cbDeptE.Size = new System.Drawing.Size(143, 20);
            this.cbDeptE.TabIndex = 8;
            // 
            // FRM3U
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 346);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM3U";
            this.Text = "FRM3U";
            this.Load += new System.EventHandler(this.FRM3U_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iNSCOUNTRYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.insDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eMPCDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNSCOMPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private InsDS insDS;
        private System.Windows.Forms.BindingSource iNSCOMPBindingSource;
        private JBHR.Ins.InsDSTableAdapters.INSCOMPTableAdapter iNSCOMPTableAdapter;
        private JBHR.Bas.BasDS basDS;
        private System.Windows.Forms.BindingSource eMPCDBindingSource;
        private JBHR.Bas.BasDSTableAdapters.EMPCDTableAdapter eMPCDTableAdapter;
        private System.Windows.Forms.BindingSource dEPTBindingSource;
        private JBHR.Bas.BasDSTableAdapters.DEPTTableAdapter dEPTTableAdapter;
        private System.Windows.Forms.BindingSource iNSCOUNTRYBindingSource;
        private JBHR.Ins.InsDSTableAdapters.INSCOUNTRYTableAdapter iNSCOUNTRYTableAdapter;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private JBHR.Ins.InsDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private JBControls.PopupTextBox popupTextBoxNOBRE;
        private JBControls.PopupTextBox popupTextBoxNOBRB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private JBControls.TextBox textBoxADATE;
        private JBControls.TextBox textBoxNET_NO;
        private JBControls.TextBox textBoxNET_CHK;
        private JBControls.TextBox textBoxNET_TXT;
        private System.Windows.Forms.ComboBox cbINSCOMP;
        private System.Windows.Forms.ComboBox cbFORMAT;
        private System.Windows.Forms.ComboBox cbEmpcdB;
        private System.Windows.Forms.ComboBox cbCountcd;
        private System.Windows.Forms.ComboBox cbBRCH;
        private System.Windows.Forms.ComboBox cbEmpcdE;
        private System.Windows.Forms.ComboBox cbDeptB;
        private System.Windows.Forms.ComboBox cbDeptE;
    }
}