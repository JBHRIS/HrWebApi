namespace JBHR.Att
{
    partial class FRM2TG
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
            this.buttonGen = new System.Windows.Forms.Button();
            this.comboBoxHcode = new System.Windows.Forms.ComboBox();
            this.checkBoxOverride = new System.Windows.Forms.CheckBox();
            this.ptxNobrB = new JBControls.PopupTextBox();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainDS = new JBHR.MainDS();
            this.textBoxYear = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ptxNobrE = new JBControls.PopupTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.v_BASETableAdapter = new JBHR.MainDSTableAdapters.V_BASETableAdapter();
            this.textBoxDDATE = new JBControls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGen
            // 
            this.buttonGen.Location = new System.Drawing.Point(108, 152);
            this.buttonGen.Name = "buttonGen";
            this.buttonGen.Size = new System.Drawing.Size(75, 23);
            this.buttonGen.TabIndex = 6;
            this.buttonGen.Text = "產生";
            this.buttonGen.UseVisualStyleBackColor = true;
            this.buttonGen.Click += new System.EventHandler(this.buttonGen_Click);
            // 
            // comboBoxHcode
            // 
            this.comboBoxHcode.FormattingEnabled = true;
            this.comboBoxHcode.Location = new System.Drawing.Point(133, 72);
            this.comboBoxHcode.Name = "comboBoxHcode";
            this.comboBoxHcode.Size = new System.Drawing.Size(121, 20);
            this.comboBoxHcode.TabIndex = 3;
            // 
            // checkBoxOverride
            // 
            this.checkBoxOverride.AutoSize = true;
            this.checkBoxOverride.Location = new System.Drawing.Point(133, 130);
            this.checkBoxOverride.Name = "checkBoxOverride";
            this.checkBoxOverride.Size = new System.Drawing.Size(48, 16);
            this.checkBoxOverride.TabIndex = 5;
            this.checkBoxOverride.TabStop = false;
            this.checkBoxOverride.Text = "覆蓋";
            this.checkBoxOverride.UseVisualStyleBackColor = true;
            // 
            // ptxNobrB
            // 
            this.ptxNobrB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobrB.CaptionLabel = null;
            this.ptxNobrB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobrB.DataSource = this.vBASEBindingSource;
            this.ptxNobrB.DisplayMember = "name_c";
            this.ptxNobrB.IsEmpty = false;
            this.ptxNobrB.IsEmptyToQuery = true;
            this.ptxNobrB.IsMustBeFound = true;
            this.ptxNobrB.LabelText = "";
            this.ptxNobrB.Location = new System.Drawing.Point(133, 44);
            this.ptxNobrB.Name = "ptxNobrB";
            this.ptxNobrB.ReadOnly = false;
            this.ptxNobrB.ShowDisplayName = true;
            this.ptxNobrB.Size = new System.Drawing.Size(73, 22);
            this.ptxNobrB.TabIndex = 1;
            this.ptxNobrB.ValueMember = "nobr";
            this.ptxNobrB.WhereCmd = "";
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.mainDS;
            // 
            // mainDS
            // 
            this.mainDS.DataSetName = "MainDS";
            this.mainDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.mainDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBoxYear
            // 
            this.textBoxYear.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxYear.CaptionLabel = null;
            this.textBoxYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxYear.DecimalPlace = 2;
            this.textBoxYear.IsEmpty = false;
            this.textBoxYear.Location = new System.Drawing.Point(133, 16);
            this.textBoxYear.Mask = "";
            this.textBoxYear.MaxLength = -1;
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.PasswordChar = '\0';
            this.textBoxYear.ReadOnly = false;
            this.textBoxYear.ShowCalendarButton = true;
            this.textBoxYear.Size = new System.Drawing.Size(50, 22);
            this.textBoxYear.TabIndex = 0;
            this.textBoxYear.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "年度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "員工編號";
            // 
            // ptxNobrE
            // 
            this.ptxNobrE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobrE.CaptionLabel = null;
            this.ptxNobrE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobrE.DataSource = this.vBASEBindingSource;
            this.ptxNobrE.DisplayMember = "name_c";
            this.ptxNobrE.IsEmpty = false;
            this.ptxNobrE.IsEmptyToQuery = true;
            this.ptxNobrE.IsMustBeFound = true;
            this.ptxNobrE.LabelText = "";
            this.ptxNobrE.Location = new System.Drawing.Point(236, 43);
            this.ptxNobrE.Name = "ptxNobrE";
            this.ptxNobrE.ReadOnly = false;
            this.ptxNobrE.ShowDisplayName = true;
            this.ptxNobrE.Size = new System.Drawing.Size(73, 22);
            this.ptxNobrE.TabIndex = 2;
            this.ptxNobrE.ValueMember = "nobr";
            this.ptxNobrE.WhereCmd = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "至";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "假別";
            // 
            // buttonExit
            // 
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.Location = new System.Drawing.Point(236, 152);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.TabStop = false;
            this.buttonExit.Text = "離開";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // textBoxDDATE
            // 
            this.textBoxDDATE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxDDATE.CaptionLabel = null;
            this.textBoxDDATE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxDDATE.DecimalPlace = 2;
            this.textBoxDDATE.IsEmpty = false;
            this.textBoxDDATE.Location = new System.Drawing.Point(133, 98);
            this.textBoxDDATE.Mask = "0000/00/00";
            this.textBoxDDATE.MaxLength = -1;
            this.textBoxDDATE.Name = "textBoxDDATE";
            this.textBoxDDATE.PasswordChar = '\0';
            this.textBoxDDATE.ReadOnly = false;
            this.textBoxDDATE.ShowCalendarButton = true;
            this.textBoxDDATE.Size = new System.Drawing.Size(73, 22);
            this.textBoxDDATE.TabIndex = 4;
            this.textBoxDDATE.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "異動截止日";
            // 
            // FRM2TG
            // 
            this.AcceptButton = this.buttonGen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonExit;
            this.ClientSize = new System.Drawing.Size(399, 208);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDDATE);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.ptxNobrE);
            this.Controls.Add(this.ptxNobrB);
            this.Controls.Add(this.checkBoxOverride);
            this.Controls.Add(this.comboBoxHcode);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonGen);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM2TG";
            this.Text = "FRM2TG";
            this.Load += new System.EventHandler(this.FRM2TG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGen;
        private System.Windows.Forms.ComboBox comboBoxHcode;
        private System.Windows.Forms.CheckBox checkBoxOverride;
        private JBControls.PopupTextBox ptxNobrB;
        private JBControls.TextBox textBoxYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private JBControls.PopupTextBox ptxNobrE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonExit;
        private MainDS mainDS;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private MainDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private JBControls.TextBox textBoxDDATE;
        private System.Windows.Forms.Label label5;
    }
}