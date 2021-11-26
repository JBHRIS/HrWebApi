namespace JBHR.Med
{
    partial class FRM74A
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.medDS = new JBHR.Med.MedDS();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.yRFORMATBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxSER_NOE = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSER_NOB = new JBControls.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.popupTextBoxNOBR_E = new JBControls.PopupTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.popupTextBoxNOBR_B = new JBControls.PopupTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxYEAR = new JBControls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxYYMM_E = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxYYMM_B = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.yRFORMATTableAdapter = new JBHR.Med.MedDSTableAdapters.YRFORMATTableAdapter();
            this.tBASETableAdapter = new JBHR.Med.MedDSTableAdapters.TBASETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.medDS)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yRFORMATBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBASEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // medDS
            // 
            this.medDS.DataSetName = "MedDS";
            this.medDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.medDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.medDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 208);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(329, 23);
            this.progressBar1.TabIndex = 20;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBoxSER_NOE);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBoxSER_NOB);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.popupTextBoxNOBR_E);
            this.panel1.Controls.Add(this.popupTextBoxNOBR_B);
            this.panel1.Controls.Add(this.textBoxYEAR);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxYYMM_E);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxYYMM_B);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 208);
            this.panel1.TabIndex = 21;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(176, 166);
            this.button2.Name = "buttonMang";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 37;
            this.button2.Text = "離開";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(95, 166);
            this.button1.Name = "btnEmp";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "轉入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // yRFORMATBindingSource
            // 
            this.yRFORMATBindingSource.DataMember = "YRFORMAT";
            this.yRFORMATBindingSource.DataSource = this.medDS;
            // 
            // textBoxSER_NOE
            // 
            this.textBoxSER_NOE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxSER_NOE.CaptionLabel = this.label6;
            this.textBoxSER_NOE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxSER_NOE.DecimalPlace = 2;
            this.textBoxSER_NOE.IsEmpty = true;
            this.textBoxSER_NOE.Location = new System.Drawing.Point(213, 101);
            this.textBoxSER_NOE.Mask = "L0000000";
            this.textBoxSER_NOE.MaxLength = -1;
            this.textBoxSER_NOE.Name = "textBoxSER_NOE";
            this.textBoxSER_NOE.PasswordChar = '\0';
            this.textBoxSER_NOE.ReadOnly = false;
            this.textBoxSER_NOE.Size = new System.Drawing.Size(103, 22);
            this.textBoxSER_NOE.TabIndex = 29;
            this.textBoxSER_NOE.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(190, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 34;
            this.label6.Text = "至";
            // 
            // textBoxSER_NOB
            // 
            this.textBoxSER_NOB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxSER_NOB.CaptionLabel = this.label7;
            this.textBoxSER_NOB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxSER_NOB.DecimalPlace = 2;
            this.textBoxSER_NOB.IsEmpty = true;
            this.textBoxSER_NOB.Location = new System.Drawing.Point(84, 101);
            this.textBoxSER_NOB.Mask = "L0000000";
            this.textBoxSER_NOB.MaxLength = -1;
            this.textBoxSER_NOB.Name = "textBoxSER_NOB";
            this.textBoxSER_NOB.PasswordChar = '\0';
            this.textBoxSER_NOB.ReadOnly = false;
            this.textBoxSER_NOB.Size = new System.Drawing.Size(100, 22);
            this.textBoxSER_NOB.TabIndex = 28;
            this.textBoxSER_NOB.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(37, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 33;
            this.label7.Text = "流水號";
            // 
            // popupTextBoxNOBR_E
            // 
            this.popupTextBoxNOBR_E.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.popupTextBoxNOBR_E.CaptionLabel = this.label3;
            this.popupTextBoxNOBR_E.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.popupTextBoxNOBR_E.DataSource = this.tBASEBindingSource;
            this.popupTextBoxNOBR_E.DisplayMember = "name_c";
            this.popupTextBoxNOBR_E.IsEmpty = true;
            this.popupTextBoxNOBR_E.IsEmptyToQuery = true;
            this.popupTextBoxNOBR_E.IsMustBeFound = true;
            this.popupTextBoxNOBR_E.LabelText = "";
            this.popupTextBoxNOBR_E.Location = new System.Drawing.Point(213, 73);
            this.popupTextBoxNOBR_E.Name = "popupTextBoxNOBR_E";
            this.popupTextBoxNOBR_E.ReadOnly = false;
            this.popupTextBoxNOBR_E.Size = new System.Drawing.Size(52, 22);
            this.popupTextBoxNOBR_E.TabIndex = 26;
            this.popupTextBoxNOBR_E.ValueMember = "nobr";
            this.popupTextBoxNOBR_E.WhereCmd = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(190, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 30;
            this.label3.Text = "至";
            // 
            // tBASEBindingSource
            // 
            this.tBASEBindingSource.DataMember = "TBASE";
            this.tBASEBindingSource.DataSource = this.medDS;
            // 
            // popupTextBoxNOBR_B
            // 
            this.popupTextBoxNOBR_B.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.popupTextBoxNOBR_B.CaptionLabel = this.label4;
            this.popupTextBoxNOBR_B.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.popupTextBoxNOBR_B.DataSource = this.tBASEBindingSource;
            this.popupTextBoxNOBR_B.DisplayMember = "name_c";
            this.popupTextBoxNOBR_B.IsEmpty = true;
            this.popupTextBoxNOBR_B.IsEmptyToQuery = true;
            this.popupTextBoxNOBR_B.IsMustBeFound = true;
            this.popupTextBoxNOBR_B.LabelText = "";
            this.popupTextBoxNOBR_B.Location = new System.Drawing.Point(84, 73);
            this.popupTextBoxNOBR_B.Name = "popupTextBoxNOBR_B";
            this.popupTextBoxNOBR_B.ReadOnly = false;
            this.popupTextBoxNOBR_B.Size = new System.Drawing.Size(49, 22);
            this.popupTextBoxNOBR_B.TabIndex = 25;
            this.popupTextBoxNOBR_B.ValueMember = "nobr";
            this.popupTextBoxNOBR_B.WhereCmd = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(13, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "所得人編號";
            // 
            // textBoxYEAR
            // 
            this.textBoxYEAR.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxYEAR.CaptionLabel = this.label5;
            this.textBoxYEAR.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxYEAR.DecimalPlace = 2;
            this.textBoxYEAR.IsEmpty = true;
            this.textBoxYEAR.Location = new System.Drawing.Point(84, 45);
            this.textBoxYEAR.Mask = "";
            this.textBoxYEAR.MaxLength = 4;
            this.textBoxYEAR.Name = "textBoxYEAR";
            this.textBoxYEAR.PasswordChar = '\0';
            this.textBoxYEAR.ReadOnly = false;
            this.textBoxYEAR.Size = new System.Drawing.Size(49, 22);
            this.textBoxYEAR.TabIndex = 23;
            this.textBoxYEAR.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(25, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 32;
            this.label5.Text = "扣繳年度";
            // 
            // textBoxYYMM_E
            // 
            this.textBoxYYMM_E.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxYYMM_E.CaptionLabel = this.label2;
            this.textBoxYYMM_E.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxYYMM_E.DecimalPlace = 2;
            this.textBoxYYMM_E.IsEmpty = true;
            this.textBoxYYMM_E.Location = new System.Drawing.Point(213, 17);
            this.textBoxYYMM_E.Mask = "";
            this.textBoxYYMM_E.MaxLength = 6;
            this.textBoxYYMM_E.Name = "textBoxYYMM_E";
            this.textBoxYYMM_E.PasswordChar = '\0';
            this.textBoxYYMM_E.ReadOnly = false;
            this.textBoxYYMM_E.Size = new System.Drawing.Size(52, 22);
            this.textBoxYYMM_E.TabIndex = 22;
            this.textBoxYYMM_E.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(190, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "至";
            // 
            // textBoxYYMM_B
            // 
            this.textBoxYYMM_B.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxYYMM_B.CaptionLabel = this.label1;
            this.textBoxYYMM_B.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxYYMM_B.DecimalPlace = 2;
            this.textBoxYYMM_B.IsEmpty = true;
            this.textBoxYYMM_B.Location = new System.Drawing.Point(84, 17);
            this.textBoxYYMM_B.Mask = "";
            this.textBoxYYMM_B.MaxLength = 6;
            this.textBoxYYMM_B.Name = "textBoxYYMM_B";
            this.textBoxYYMM_B.PasswordChar = '\0';
            this.textBoxYYMM_B.ReadOnly = false;
            this.textBoxYYMM_B.Size = new System.Drawing.Size(49, 22);
            this.textBoxYYMM_B.TabIndex = 20;
            this.textBoxYYMM_B.ValidType = JBControls.TextBox.EValidType.String;
            this.textBoxYYMM_B.Validated += new System.EventHandler(this.textBoxYYMM_B_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "發放年月";
            // 
            // yRFORMATTableAdapter
            // 
            this.yRFORMATTableAdapter.ClearBeforeFill = true;
            // 
            // tBASETableAdapter
            // 
            this.tBASETableAdapter.ClearBeforeFill = true;
            // 
            // FRM74A
            // 
            this.ClientSize = new System.Drawing.Size(329, 231);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM74A";
            this.Text = "從薪資轉入";
            this.Load += new System.EventHandler(this.FRM51A_Load);
            ((System.ComponentModel.ISupportInitialize)(this.medDS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yRFORMATBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBASEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MedDS medDS;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private JBControls.TextBox textBoxSER_NOE;
        private System.Windows.Forms.Label label6;
        private JBControls.TextBox textBoxSER_NOB;
        private System.Windows.Forms.Label label7;
        private JBControls.PopupTextBox popupTextBoxNOBR_E;
        private System.Windows.Forms.Label label3;
        private JBControls.PopupTextBox popupTextBoxNOBR_B;
        private System.Windows.Forms.Label label4;
        private JBControls.TextBox textBoxYEAR;
        private System.Windows.Forms.Label label5;
        private JBControls.TextBox textBoxYYMM_E;
        private System.Windows.Forms.Label label2;
        private JBControls.TextBox textBoxYYMM_B;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource yRFORMATBindingSource;
        private MedDSTableAdapters.YRFORMATTableAdapter yRFORMATTableAdapter;
        private System.Windows.Forms.BindingSource tBASEBindingSource;
        private MedDSTableAdapters.TBASETableAdapter tBASETableAdapter;

    }
}
