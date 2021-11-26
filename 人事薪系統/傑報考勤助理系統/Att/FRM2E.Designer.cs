namespace JBHR.Att
{
    partial class FRM2E
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.oTHCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.txtGotoDate = new JBControls.TextBox();
            this.btnGoto = new System.Windows.Forms.Button();
            this.btnPrevMonth = new System.Windows.Forms.Button();
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dsBas = new JBHR.Att.dsBas();
            this.oTHCODETableAdapter = new JBHR.Att.dsAttTableAdapters.OTHCODETableAdapter();
            this.cbxHoliCode = new System.Windows.Forms.ComboBox();
            this.hOLICDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbxOtHcode = new System.Windows.Forms.ComboBox();
            this.hOLICDTableAdapter = new JBHR.Att.dsAttTableAdapters.HOLICDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.oTHCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOLICDBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "星期日";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(76, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 24);
            this.button2.TabIndex = 1;
            this.button2.Text = "星期一";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(152, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 24);
            this.button3.TabIndex = 2;
            this.button3.Text = "星期二";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(228, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 24);
            this.button4.TabIndex = 3;
            this.button4.Text = "星期三";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(304, 1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 24);
            this.button5.TabIndex = 4;
            this.button5.Text = "星期四";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(380, 1);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 24);
            this.button6.TabIndex = 5;
            this.button6.Text = "星期五";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(456, 1);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 24);
            this.button7.TabIndex = 6;
            this.button7.Text = "星期六";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // oTHCODEBindingSource
            // 
            this.oTHCODEBindingSource.DataMember = "OTHCODE";
            this.oTHCODEBindingSource.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtGotoDate
            // 
            this.txtGotoDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtGotoDate.CaptionLabel = null;
            this.txtGotoDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtGotoDate.DecimalPlace = 2;
            this.txtGotoDate.IsEmpty = true;
            this.txtGotoDate.Location = new System.Drawing.Point(7, 419);
            this.txtGotoDate.Mask = "";
            this.txtGotoDate.MaxLength = -1;
            this.txtGotoDate.Name = "txtGotoDate";
            this.txtGotoDate.PasswordChar = '\0';
            this.txtGotoDate.ReadOnly = false;
            this.txtGotoDate.Size = new System.Drawing.Size(100, 22);
            this.txtGotoDate.TabIndex = 51;
            this.txtGotoDate.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // btnGoto
            // 
            this.btnGoto.Location = new System.Drawing.Point(113, 419);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(60, 23);
            this.btnGoto.TabIndex = 52;
            this.btnGoto.Text = "到";
            this.btnGoto.UseVisualStyleBackColor = true;
            this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
            // 
            // btnPrevMonth
            // 
            this.btnPrevMonth.Location = new System.Drawing.Point(386, 385);
            this.btnPrevMonth.Name = "btnPrevMonth";
            this.btnPrevMonth.Size = new System.Drawing.Size(60, 23);
            this.btnPrevMonth.TabIndex = 53;
            this.btnPrevMonth.Text = "上月";
            this.btnPrevMonth.UseVisualStyleBackColor = true;
            this.btnPrevMonth.Click += new System.EventHandler(this.btnPrevMonth_Click);
            // 
            // btnNextMonth
            // 
            this.btnNextMonth.Location = new System.Drawing.Point(462, 385);
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.Size = new System.Drawing.Size(60, 23);
            this.btnNextMonth.TabIndex = 54;
            this.btnNextMonth.Text = "下月";
            this.btnNextMonth.UseVisualStyleBackColor = true;
            this.btnNextMonth.Click += new System.EventHandler(this.btnNextMonth_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(530, 348);
            this.tableLayoutPanel1.TabIndex = 55;
            // 
            // dsBas
            // 
            this.dsBas.DataSetName = "dsBas";
            this.dsBas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oTHCODETableAdapter
            // 
            this.oTHCODETableAdapter.ClearBeforeFill = true;
            // 
            // cbxHoliCode
            // 
            this.cbxHoliCode.DataSource = this.hOLICDBindingSource;
            this.cbxHoliCode.DisplayMember = "HOLI_NAME";
            this.cbxHoliCode.FormattingEnabled = true;
            this.cbxHoliCode.Location = new System.Drawing.Point(7, 388);
            this.cbxHoliCode.Name = "cbxHoliCode";
            this.cbxHoliCode.Size = new System.Drawing.Size(121, 20);
            this.cbxHoliCode.TabIndex = 56;
            this.cbxHoliCode.ValueMember = "HOLI_CODE";
            this.cbxHoliCode.SelectedIndexChanged += new System.EventHandler(this.cbxHolicd_SelectedIndexChanged);
            // 
            // hOLICDBindingSource
            // 
            this.hOLICDBindingSource.DataMember = "HOLICD";
            this.hOLICDBindingSource.DataSource = this.dsAtt;
            // 
            // cbxOtHcode
            // 
            this.cbxOtHcode.DataSource = this.oTHCODEBindingSource;
            this.cbxOtHcode.DisplayMember = "OTHNAME";
            this.cbxOtHcode.FormattingEnabled = true;
            this.cbxOtHcode.Location = new System.Drawing.Point(213, 388);
            this.cbxOtHcode.Name = "cbxOtHcode";
            this.cbxOtHcode.Size = new System.Drawing.Size(121, 20);
            this.cbxOtHcode.TabIndex = 57;
            this.cbxOtHcode.ValueMember = "OTHCODE";
            // 
            // hOLICDTableAdapter
            // 
            this.hOLICDTableAdapter.ClearBeforeFill = true;
            // 
            // FRM2E
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 452);
            this.Controls.Add(this.cbxOtHcode);
            this.Controls.Add(this.cbxHoliCode);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnNextMonth);
            this.Controls.Add(this.btnPrevMonth);
            this.Controls.Add(this.btnGoto);
            this.Controls.Add(this.txtGotoDate);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM2E";
            this.Text = "FRM2E";
            this.Load += new System.EventHandler(this.FRM2E_Load);
            ((System.ComponentModel.ISupportInitialize)(this.oTHCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOLICDBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private JBControls.TextBox txtGotoDate;
        private System.Windows.Forms.Button btnGoto;
        private System.Windows.Forms.Button btnPrevMonth;
        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private dsBas dsBas;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource oTHCODEBindingSource;
        private JBHR.Att.dsAttTableAdapters.OTHCODETableAdapter oTHCODETableAdapter;
        private System.Windows.Forms.ComboBox cbxHoliCode;
        private System.Windows.Forms.ComboBox cbxOtHcode;
        private System.Windows.Forms.BindingSource hOLICDBindingSource;
        private JBHR.Att.dsAttTableAdapters.HOLICDTableAdapter hOLICDTableAdapter;

    }
}