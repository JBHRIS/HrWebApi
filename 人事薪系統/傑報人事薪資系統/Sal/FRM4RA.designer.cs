namespace JBHR.Sal
{
    partial class FRM4RA
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtYYMM = new JBControls.TextBox();
            this.txtSEQ = new JBControls.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(711, 322);
            this.dataGridView1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.52239F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.47761F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtYYMM, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtSEQ, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 340);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(230, 32);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "計薪年月";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "期別";
            // 
            // txtYYMM
            // 
            this.txtYYMM.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYYMM.CaptionLabel = null;
            this.txtYYMM.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYYMM.DecimalPlace = 2;
            this.txtYYMM.IsEmpty = true;
            this.txtYYMM.Location = new System.Drawing.Point(66, 3);
            this.txtYYMM.Mask = "";
            this.txtYYMM.MaxLength = -1;
            this.txtYYMM.Name = "txtYYMM";
            this.txtYYMM.PasswordChar = '\0';
            this.txtYYMM.ReadOnly = false;
            this.txtYYMM.Size = new System.Drawing.Size(69, 22);
            this.txtYYMM.TabIndex = 3;
            this.txtYYMM.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtSEQ
            // 
            this.txtSEQ.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSEQ.CaptionLabel = null;
            this.txtSEQ.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSEQ.DecimalPlace = 2;
            this.txtSEQ.IsEmpty = true;
            this.txtSEQ.Location = new System.Drawing.Point(182, 3);
            this.txtSEQ.Mask = "";
            this.txtSEQ.MaxLength = -1;
            this.txtSEQ.Name = "txtSEQ";
            this.txtSEQ.PasswordChar = '\0';
            this.txtSEQ.ReadOnly = false;
            this.txtSEQ.Size = new System.Drawing.Size(37, 22);
            this.txtSEQ.TabIndex = 3;
            this.txtSEQ.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "確認";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(329, 345);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "匯出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FRM4RA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 384);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.dataGridView1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM4RA";
            this.Text = "FRM4RA";
            this.Load += new System.EventHandler(this.FRM4RA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private JBControls.TextBox txtYYMM;
        private JBControls.TextBox txtSEQ;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnExport;
    }
}