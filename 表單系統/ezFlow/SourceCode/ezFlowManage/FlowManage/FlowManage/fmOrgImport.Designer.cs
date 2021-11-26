namespace FlowManage
{
    partial class fmOrgImport
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ckRoleTopEmpty = new System.Windows.Forms.CheckBox();
            this.ckSyncLoginPW = new System.Windows.Forms.CheckBox();
            this.ckFullImport = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblJobCount = new System.Windows.Forms.Label();
            this.lblDeptCountNew = new System.Windows.Forms.Label();
            this.lblEmpCountNew = new System.Windows.Forms.Label();
            this.lblJobCountNew = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEmpCount = new System.Windows.Forms.Label();
            this.lblDeptCount = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.txtFrontLoginID = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDeptTopCode = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFlow = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.cbTest = new System.Windows.Forms.CheckBox();
            this.lblState = new System.Windows.Forms.ToolStripStatusLabel();
            this.pb = new System.Windows.Forms.ToolStripProgressBar();
            this.stStrip = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.stStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.ckRoleTopEmpty, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.ckSyncLoginPW, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ckFullImport, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 0, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 258);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 196);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 82;
            this.checkBox1.Text = "階層正向";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ckRoleTopEmpty
            // 
            this.ckRoleTopEmpty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ckRoleTopEmpty.AutoSize = true;
            this.ckRoleTopEmpty.Location = new System.Drawing.Point(3, 145);
            this.ckRoleTopEmpty.Name = "ckRoleTopEmpty";
            this.ckRoleTopEmpty.Size = new System.Drawing.Size(224, 16);
            this.ckRoleTopEmpty.TabIndex = 79;
            this.ckRoleTopEmpty.Text = "上層角色全為空白(按照部門進行簽核)";
            this.ckRoleTopEmpty.UseVisualStyleBackColor = true;
            // 
            // ckSyncLoginPW
            // 
            this.ckSyncLoginPW.AutoSize = true;
            this.ckSyncLoginPW.Location = new System.Drawing.Point(3, 67);
            this.ckSyncLoginPW.Name = "ckSyncLoginPW";
            this.ckSyncLoginPW.Size = new System.Drawing.Size(211, 16);
            this.ckSyncLoginPW.TabIndex = 61;
            this.ckSyncLoginPW.Text = "覆蓋Flow使用者登入密碼(密碼同步)";
            this.ckSyncLoginPW.UseVisualStyleBackColor = true;
            // 
            // ckFullImport
            // 
            this.ckFullImport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ckFullImport.AutoSize = true;
            this.ckFullImport.Checked = true;
            this.ckFullImport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckFullImport.Enabled = false;
            this.ckFullImport.Location = new System.Drawing.Point(3, 45);
            this.ckFullImport.Name = "ckFullImport";
            this.ckFullImport.Size = new System.Drawing.Size(176, 16);
            this.ckFullImport.TabIndex = 60;
            this.ckFullImport.Text = "完整匯入(會先刪除原始資料)";
            this.ckFullImport.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label8, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblJobCount, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblDeptCountNew, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblEmpCountNew, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblJobCountNew, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblEmpCount, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblDeptCount, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(227, 42);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 48;
            this.label8.Text = "部門數量";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(97, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 46;
            this.label9.Text = "人員數量";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 50;
            this.label5.Text = "職稱數量";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 80;
            this.label10.Text = "目前";
            // 
            // lblJobCount
            // 
            this.lblJobCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblJobCount.AutoSize = true;
            this.lblJobCount.Location = new System.Drawing.Point(184, 12);
            this.lblJobCount.Name = "lblJobCount";
            this.lblJobCount.Size = new System.Drawing.Size(11, 12);
            this.lblJobCount.TabIndex = 84;
            this.lblJobCount.Text = "0";
            // 
            // lblDeptCountNew
            // 
            this.lblDeptCountNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDeptCountNew.AutoSize = true;
            this.lblDeptCountNew.Location = new System.Drawing.Point(59, 27);
            this.lblDeptCountNew.Name = "lblDeptCountNew";
            this.lblDeptCountNew.Size = new System.Drawing.Size(11, 12);
            this.lblDeptCountNew.TabIndex = 85;
            this.lblDeptCountNew.Text = "0";
            // 
            // lblEmpCountNew
            // 
            this.lblEmpCountNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmpCountNew.AutoSize = true;
            this.lblEmpCountNew.Location = new System.Drawing.Point(118, 27);
            this.lblEmpCountNew.Name = "lblEmpCountNew";
            this.lblEmpCountNew.Size = new System.Drawing.Size(11, 12);
            this.lblEmpCountNew.TabIndex = 87;
            this.lblEmpCountNew.Text = "0";
            // 
            // lblJobCountNew
            // 
            this.lblJobCountNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblJobCountNew.AutoSize = true;
            this.lblJobCountNew.Location = new System.Drawing.Point(184, 27);
            this.lblJobCountNew.Name = "lblJobCountNew";
            this.lblJobCountNew.Size = new System.Drawing.Size(11, 12);
            this.lblJobCountNew.TabIndex = 86;
            this.lblJobCountNew.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 81;
            this.label1.Text = "應轉";
            // 
            // lblEmpCount
            // 
            this.lblEmpCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmpCount.AutoSize = true;
            this.lblEmpCount.Location = new System.Drawing.Point(118, 12);
            this.lblEmpCount.Name = "lblEmpCount";
            this.lblEmpCount.Size = new System.Drawing.Size(11, 12);
            this.lblEmpCount.TabIndex = 82;
            this.lblEmpCount.Text = "0";
            // 
            // lblDeptCount
            // 
            this.lblDeptCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDeptCount.AutoSize = true;
            this.lblDeptCount.Location = new System.Drawing.Point(59, 12);
            this.lblDeptCount.Name = "lblDeptCount";
            this.lblDeptCount.Size = new System.Drawing.Size(11, 12);
            this.lblDeptCount.TabIndex = 83;
            this.lblDeptCount.Text = "0";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label16);
            this.flowLayoutPanel1.Controls.Add(this.txtFrontLoginID);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 86);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(284, 26);
            this.flowLayoutPanel1.TabIndex = 62;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 12);
            this.label16.TabIndex = 83;
            this.label16.Text = "帳號前置名稱：";
            // 
            // txtFrontLoginID
            // 
            this.txtFrontLoginID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFrontLoginID.Location = new System.Drawing.Point(98, 3);
            this.txtFrontLoginID.Name = "txtFrontLoginID";
            this.txtFrontLoginID.Size = new System.Drawing.Size(99, 22);
            this.txtFrontLoginID.TabIndex = 84;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.txtDeptTopCode);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 112);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(284, 30);
            this.flowLayoutPanel2.TabIndex = 63;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 12);
            this.label4.TabIndex = 68;
            this.label4.Text = "起始根(最上層)部門代碼：";
            // 
            // txtDeptTopCode
            // 
            this.txtDeptTopCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDeptTopCode.CausesValidation = false;
            this.txtDeptTopCode.Location = new System.Drawing.Point(154, 3);
            this.txtDeptTopCode.Name = "txtDeptTopCode";
            this.txtDeptTopCode.Size = new System.Drawing.Size(99, 22);
            this.txtDeptTopCode.TabIndex = 69;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Controls.Add(this.dtStart);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 164);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(284, 29);
            this.flowLayoutPanel3.TabIndex = 81;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 84;
            this.label2.Text = "匯入生效日：";
            // 
            // dtStart
            // 
            this.dtStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtStart.CustomFormat = "yyyy/MM/dd";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(86, 3);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(79, 22);
            this.dtStart.TabIndex = 85;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.btnFlow);
            this.flowLayoutPanel4.Controls.Add(this.btnImport);
            this.flowLayoutPanel4.Controls.Add(this.cbTest);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 215);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(284, 100);
            this.flowLayoutPanel4.TabIndex = 83;
            // 
            // btnFlow
            // 
            this.btnFlow.Location = new System.Drawing.Point(3, 3);
            this.btnFlow.Name = "btnFlow";
            this.btnFlow.Size = new System.Drawing.Size(75, 23);
            this.btnFlow.TabIndex = 0;
            this.btnFlow.Text = "關閉系統";
            this.btnFlow.UseVisualStyleBackColor = true;
            this.btnFlow.Click += new System.EventHandler(this.btnFlow_Click);
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(84, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(37, 23);
            this.btnImport.TabIndex = 80;
            this.btnImport.Tag = "Yes";
            this.btnImport.Text = "匯入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cbTest
            // 
            this.cbTest.AutoSize = true;
            this.cbTest.Location = new System.Drawing.Point(127, 3);
            this.cbTest.Name = "cbTest";
            this.cbTest.Size = new System.Drawing.Size(48, 16);
            this.cbTest.TabIndex = 81;
            this.cbTest.Text = "測試";
            this.cbTest.UseVisualStyleBackColor = true;
            // 
            // lblState
            // 
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(32, 17);
            this.lblState.Text = "就緒";
            // 
            // pb
            // 
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(100, 16);
            this.pb.Visible = false;
            // 
            // stStrip
            // 
            this.stStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pb,
            this.lblState});
            this.stStrip.Location = new System.Drawing.Point(0, 245);
            this.stStrip.Name = "stStrip";
            this.stStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stStrip.Size = new System.Drawing.Size(284, 22);
            this.stStrip.SizingGrip = false;
            this.stStrip.TabIndex = 1;
            this.stStrip.Text = "stStrip";
            // 
            // fmOrgImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 267);
            this.Controls.Add(this.stStrip);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "fmOrgImport";
            this.ShowIcon = false;
            this.Text = "fmOrgImport";
            this.Load += new System.EventHandler(this.fmOrgImport_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.stStrip.ResumeLayout(false);
            this.stStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblJobCount;
        private System.Windows.Forms.Label lblDeptCountNew;
        private System.Windows.Forms.Label lblEmpCountNew;
        private System.Windows.Forms.Label lblJobCountNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEmpCount;
        private System.Windows.Forms.Label lblDeptCount;
        private System.Windows.Forms.CheckBox ckSyncLoginPW;
        private System.Windows.Forms.CheckBox ckFullImport;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtFrontLoginID;
        private System.Windows.Forms.CheckBox ckRoleTopEmpty;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDeptTopCode;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripStatusLabel lblState;
        public System.Windows.Forms.ToolStripProgressBar pb;
        private System.Windows.Forms.StatusStrip stStrip;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button btnFlow;
        private System.Windows.Forms.CheckBox cbTest;
    }
}