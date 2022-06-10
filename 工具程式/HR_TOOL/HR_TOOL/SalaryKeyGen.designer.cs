namespace JBHRKEYCREATOR
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLOGINID = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPASSWORD = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUSERID = new JBControls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDATABASE = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSERVER = new JBControls.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxFOLDER = new JBControls.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(57, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "薪資授權帳號";
            // 
            // textBoxLOGINID
            // 
            this.textBoxLOGINID.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxLOGINID.CaptionLabel = this.label1;
            this.textBoxLOGINID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxLOGINID.DecimalPlace = 2;
            this.textBoxLOGINID.IsEmpty = true;
            this.textBoxLOGINID.Location = new System.Drawing.Point(140, 22);
            this.textBoxLOGINID.Mask = "";
            this.textBoxLOGINID.MaxLength = -1;
            this.textBoxLOGINID.Name = "textBoxLOGINID";
            this.textBoxLOGINID.PasswordChar = '\0';
            this.textBoxLOGINID.ReadOnly = false;
            this.textBoxLOGINID.Size = new System.Drawing.Size(157, 22);
            this.textBoxLOGINID.TabIndex = 0;
            this.textBoxLOGINID.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(81, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "登入密碼";
            // 
            // textBoxPASSWORD
            // 
            this.textBoxPASSWORD.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxPASSWORD.CaptionLabel = this.label2;
            this.textBoxPASSWORD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxPASSWORD.DecimalPlace = 2;
            this.textBoxPASSWORD.IsEmpty = true;
            this.textBoxPASSWORD.Location = new System.Drawing.Point(140, 106);
            this.textBoxPASSWORD.Mask = "";
            this.textBoxPASSWORD.MaxLength = -1;
            this.textBoxPASSWORD.Name = "textBoxPASSWORD";
            this.textBoxPASSWORD.PasswordChar = '*';
            this.textBoxPASSWORD.ReadOnly = false;
            this.textBoxPASSWORD.Size = new System.Drawing.Size(157, 22);
            this.textBoxPASSWORD.TabIndex = 3;
            this.textBoxPASSWORD.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(81, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "登入帳號";
            // 
            // textBoxUSERID
            // 
            this.textBoxUSERID.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxUSERID.CaptionLabel = this.label4;
            this.textBoxUSERID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxUSERID.DecimalPlace = 2;
            this.textBoxUSERID.IsEmpty = true;
            this.textBoxUSERID.Location = new System.Drawing.Point(140, 78);
            this.textBoxUSERID.Mask = "";
            this.textBoxUSERID.MaxLength = -1;
            this.textBoxUSERID.Name = "textBoxUSERID";
            this.textBoxUSERID.PasswordChar = '*';
            this.textBoxUSERID.ReadOnly = false;
            this.textBoxUSERID.Size = new System.Drawing.Size(157, 22);
            this.textBoxUSERID.TabIndex = 2;
            this.textBoxUSERID.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(69, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "資料庫名稱";
            // 
            // textBoxDATABASE
            // 
            this.textBoxDATABASE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxDATABASE.CaptionLabel = this.label5;
            this.textBoxDATABASE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxDATABASE.DecimalPlace = 2;
            this.textBoxDATABASE.IsEmpty = true;
            this.textBoxDATABASE.Location = new System.Drawing.Point(140, 50);
            this.textBoxDATABASE.Mask = "";
            this.textBoxDATABASE.MaxLength = -1;
            this.textBoxDATABASE.Name = "textBoxDATABASE";
            this.textBoxDATABASE.PasswordChar = '\0';
            this.textBoxDATABASE.ReadOnly = false;
            this.textBoxDATABASE.Size = new System.Drawing.Size(157, 22);
            this.textBoxDATABASE.TabIndex = 1;
            this.textBoxDATABASE.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(21, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "伺服器名稱或IP位址";
            // 
            // textBoxSERVER
            // 
            this.textBoxSERVER.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxSERVER.CaptionLabel = this.label6;
            this.textBoxSERVER.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxSERVER.DecimalPlace = 2;
            this.textBoxSERVER.IsEmpty = true;
            this.textBoxSERVER.Location = new System.Drawing.Point(140, 22);
            this.textBoxSERVER.Mask = "";
            this.textBoxSERVER.MaxLength = -1;
            this.textBoxSERVER.Name = "textBoxSERVER";
            this.textBoxSERVER.PasswordChar = '\0';
            this.textBoxSERVER.ReadOnly = false;
            this.textBoxSERVER.Size = new System.Drawing.Size(157, 22);
            this.textBoxSERVER.TabIndex = 0;
            this.textBoxSERVER.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(447, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "產生金鑰與連線字串";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(28, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "儲存路徑";
            // 
            // textBoxFOLDER
            // 
            this.textBoxFOLDER.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxFOLDER.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxFOLDER.CaptionLabel = this.label7;
            this.textBoxFOLDER.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxFOLDER.DecimalPlace = 2;
            this.textBoxFOLDER.IsEmpty = true;
            this.textBoxFOLDER.Location = new System.Drawing.Point(87, 7);
            this.textBoxFOLDER.Mask = "";
            this.textBoxFOLDER.MaxLength = -1;
            this.textBoxFOLDER.Name = "textBoxFOLDER";
            this.textBoxFOLDER.PasswordChar = '\0';
            this.textBoxFOLDER.ReadOnly = true;
            this.textBoxFOLDER.Size = new System.Drawing.Size(458, 22);
            this.textBoxFOLDER.TabIndex = 0;
            this.textBoxFOLDER.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(543, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "…";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::HR_TOOL.Properties.Resources.Key;
            this.pictureBox1.Location = new System.Drawing.Point(441, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 129);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(303, 105);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "連線測試";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(303, 22);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "只產生金鑰";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(384, 106);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "只產生連線字串";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(582, 174);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxLOGINID);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(574, 148);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "產生金鑰";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBoxPASSWORD);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.textBoxSERVER);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.textBoxDATABASE);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textBoxUSERID);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(574, 148);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "設定連線";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 252);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxFOLDER);
            this.Controls.Add(this.button1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "傑報薪資系統金鑰產生器";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;        
        private JBControls.TextBox textBoxLOGINID;
        private System.Windows.Forms.Label label2;
        private JBControls.TextBox textBoxPASSWORD;
        private System.Windows.Forms.Label label4;
        private JBControls.TextBox textBoxUSERID;
        private System.Windows.Forms.Label label5;
        private JBControls.TextBox textBoxDATABASE;
        private System.Windows.Forms.Label label6;
        private JBControls.TextBox textBoxSERVER;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private JBControls.TextBox textBoxFOLDER;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

