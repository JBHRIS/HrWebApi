namespace FlowManage
{
    partial class fmDeptView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmDeptView));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tv = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.ckDept = new System.Windows.Forms.CheckBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.vEmpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBase = new FlowManage.dsBase();
            this.vEmpTableAdapter = new FlowManage.dsBaseTableAdapters.vEmpTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pwDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mgDefaultDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rloeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deptIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deptNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deptPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEmpBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBase)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv);
            this.splitContainer1.Size = new System.Drawing.Size(584, 362);
            this.splitContainer1.SplitterDistance = 194;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tv, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ckDept, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(194, 362);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.ImageIndex = 0;
            this.tv.ImageList = this.imageList;
            this.tv.Location = new System.Drawing.Point(3, 3);
            this.tv.Name = "tv";
            this.tv.SelectedImageIndex = 0;
            this.tv.Size = new System.Drawing.Size(188, 326);
            this.tv.TabIndex = 1;
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.SystemColors.Control;
            this.imageList.Images.SetKeyName(0, "untitled.bmp");
            // 
            // ckDept
            // 
            this.ckDept.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ckDept.AutoSize = true;
            this.ckDept.Location = new System.Drawing.Point(3, 339);
            this.ckDept.Name = "ckDept";
            this.ckDept.Size = new System.Drawing.Size(84, 16);
            this.ckDept.TabIndex = 2;
            this.ckDept.Text = "包含子部門";
            this.ckDept.UseVisualStyleBackColor = true;
            this.ckDept.CheckedChanged += new System.EventHandler(this.ckDept_CheckedChanged);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.loginDataGridViewTextBoxColumn,
            this.pwDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.mgDefaultDataGridViewCheckBoxColumn,
            this.rloeIDDataGridViewTextBoxColumn,
            this.deptIDDataGridViewTextBoxColumn,
            this.deptNameDataGridViewTextBoxColumn,
            this.deptPathDataGridViewTextBoxColumn,
            this.posIDDataGridViewTextBoxColumn,
            this.posNameDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.vEmpBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(386, 362);
            this.dgv.TabIndex = 2;
            // 
            // vEmpBindingSource
            // 
            this.vEmpBindingSource.DataMember = "vEmp";
            this.vEmpBindingSource.DataSource = this.dsBase;
            // 
            // dsBase
            // 
            this.dsBase.DataSetName = "dsBase";
            this.dsBase.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vEmpTableAdapter
            // 
            this.vEmpTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "工號";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "姓名";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loginDataGridViewTextBoxColumn
            // 
            this.loginDataGridViewTextBoxColumn.DataPropertyName = "login";
            this.loginDataGridViewTextBoxColumn.HeaderText = "登錄帳號";
            this.loginDataGridViewTextBoxColumn.Name = "loginDataGridViewTextBoxColumn";
            this.loginDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pwDataGridViewTextBoxColumn
            // 
            this.pwDataGridViewTextBoxColumn.DataPropertyName = "pw";
            this.pwDataGridViewTextBoxColumn.HeaderText = "密碼";
            this.pwDataGridViewTextBoxColumn.Name = "pwDataGridViewTextBoxColumn";
            this.pwDataGridViewTextBoxColumn.ReadOnly = true;
            this.pwDataGridViewTextBoxColumn.Visible = false;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "信箱";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mgDefaultDataGridViewCheckBoxColumn
            // 
            this.mgDefaultDataGridViewCheckBoxColumn.DataPropertyName = "mgDefault";
            this.mgDefaultDataGridViewCheckBoxColumn.HeaderText = "主管";
            this.mgDefaultDataGridViewCheckBoxColumn.Name = "mgDefaultDataGridViewCheckBoxColumn";
            this.mgDefaultDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // rloeIDDataGridViewTextBoxColumn
            // 
            this.rloeIDDataGridViewTextBoxColumn.DataPropertyName = "RloeID";
            this.rloeIDDataGridViewTextBoxColumn.HeaderText = "角色代碼";
            this.rloeIDDataGridViewTextBoxColumn.Name = "rloeIDDataGridViewTextBoxColumn";
            this.rloeIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deptIDDataGridViewTextBoxColumn
            // 
            this.deptIDDataGridViewTextBoxColumn.DataPropertyName = "DeptID";
            this.deptIDDataGridViewTextBoxColumn.HeaderText = "部門代碼";
            this.deptIDDataGridViewTextBoxColumn.Name = "deptIDDataGridViewTextBoxColumn";
            this.deptIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deptNameDataGridViewTextBoxColumn
            // 
            this.deptNameDataGridViewTextBoxColumn.DataPropertyName = "DeptName";
            this.deptNameDataGridViewTextBoxColumn.HeaderText = "部門名稱";
            this.deptNameDataGridViewTextBoxColumn.Name = "deptNameDataGridViewTextBoxColumn";
            this.deptNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deptPathDataGridViewTextBoxColumn
            // 
            this.deptPathDataGridViewTextBoxColumn.DataPropertyName = "DeptPath";
            this.deptPathDataGridViewTextBoxColumn.HeaderText = "部門樹";
            this.deptPathDataGridViewTextBoxColumn.Name = "deptPathDataGridViewTextBoxColumn";
            this.deptPathDataGridViewTextBoxColumn.ReadOnly = true;
            this.deptPathDataGridViewTextBoxColumn.Visible = false;
            // 
            // posIDDataGridViewTextBoxColumn
            // 
            this.posIDDataGridViewTextBoxColumn.DataPropertyName = "PosID";
            this.posIDDataGridViewTextBoxColumn.HeaderText = "職稱代碼";
            this.posIDDataGridViewTextBoxColumn.Name = "posIDDataGridViewTextBoxColumn";
            this.posIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // posNameDataGridViewTextBoxColumn
            // 
            this.posNameDataGridViewTextBoxColumn.DataPropertyName = "PosName";
            this.posNameDataGridViewTextBoxColumn.HeaderText = "職稱名稱";
            this.posNameDataGridViewTextBoxColumn.Name = "posNameDataGridViewTextBoxColumn";
            this.posNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fmDeptView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.splitContainer1);
            this.Name = "fmDeptView";
            this.Text = "fmDeptView";
            this.Load += new System.EventHandler(this.fmDeptView_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEmpBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ImageList imageList;
        private dsBase dsBase;
        private System.Windows.Forms.BindingSource vEmpBindingSource;
        private FlowManage.dsBaseTableAdapters.vEmpTableAdapter vEmpTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox ckDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pwDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mgDefaultDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rloeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deptIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deptNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deptPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn posIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn posNameDataGridViewTextBoxColumn;
    }
}