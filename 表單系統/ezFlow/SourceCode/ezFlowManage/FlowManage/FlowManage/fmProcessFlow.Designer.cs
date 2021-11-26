namespace FlowManage
{
    partial class fmProcessFlow
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSelectMsg = new System.Windows.Forms.Label();
            this.ckDate = new System.Windows.Forms.CheckBox();
            this.ckCancel = new System.Windows.Forms.CheckBox();
            this.ckFlow = new System.Windows.Forms.CheckBox();
            this.ckDept = new System.Windows.Forms.CheckBox();
            this.ckStarter = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowTreenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowNodenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empnameCheckDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isCancelDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.vProcessFlowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsFlow = new FlowManage.dsFlow();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.vProcessFlowTableAdapter = new FlowManage.dsFlowTableAdapters.vProcessFlowTableAdapter();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vProcessFlowBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFlow)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(584, 362);
            this.splitContainer1.SplitterDistance = 46;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSelectMsg, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ckDate, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.ckCancel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ckFlow, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ckDept, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ckStarter, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 46);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "篩選條件：";
            // 
            // lblSelectMsg
            // 
            this.lblSelectMsg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSelectMsg.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblSelectMsg, 4);
            this.lblSelectMsg.ForeColor = System.Drawing.Color.Red;
            this.lblSelectMsg.Location = new System.Drawing.Point(105, 28);
            this.lblSelectMsg.Name = "lblSelectMsg";
            this.lblSelectMsg.Size = new System.Drawing.Size(113, 12);
            this.lblSelectMsg.TabIndex = 14;
            this.lblSelectMsg.Text = "目前無任何篩選條件";
            // 
            // ckDate
            // 
            this.ckDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ckDate.AutoSize = true;
            this.ckDate.Location = new System.Drawing.Point(351, 3);
            this.ckDate.Name = "ckDate";
            this.ckDate.Size = new System.Drawing.Size(72, 16);
            this.ckDate.TabIndex = 5;
            this.ckDate.Tag = "fmDate";
            this.ckDate.Text = "日期篩選";
            this.ckDate.UseVisualStyleBackColor = true;
            this.ckDate.CheckedChanged += new System.EventHandler(this.ck_CheckedChanged);
            // 
            // ckCancel
            // 
            this.ckCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ckCancel.AutoSize = true;
            this.ckCancel.Location = new System.Drawing.Point(3, 3);
            this.ckCancel.Name = "ckCancel";
            this.ckCancel.Size = new System.Drawing.Size(96, 16);
            this.ckCancel.TabIndex = 1;
            this.ckCancel.Tag = "";
            this.ckCancel.Text = "中止流程篩選";
            this.ckCancel.UseVisualStyleBackColor = true;
            this.ckCancel.CheckedChanged += new System.EventHandler(this.ck_CheckedChanged);
            // 
            // ckFlow
            // 
            this.ckFlow.AccessibleDescription = "";
            this.ckFlow.AccessibleName = "";
            this.ckFlow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ckFlow.AutoSize = true;
            this.ckFlow.Location = new System.Drawing.Point(105, 3);
            this.ckFlow.Name = "ckFlow";
            this.ckFlow.Size = new System.Drawing.Size(72, 16);
            this.ckFlow.TabIndex = 2;
            this.ckFlow.Tag = "fmFlowTree";
            this.ckFlow.Text = "表單篩選";
            this.ckFlow.UseVisualStyleBackColor = true;
            this.ckFlow.CheckedChanged += new System.EventHandler(this.ck_CheckedChanged);
            // 
            // ckDept
            // 
            this.ckDept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ckDept.AutoSize = true;
            this.ckDept.Location = new System.Drawing.Point(183, 3);
            this.ckDept.Name = "ckDept";
            this.ckDept.Size = new System.Drawing.Size(72, 16);
            this.ckDept.TabIndex = 3;
            this.ckDept.Tag = "fmDept";
            this.ckDept.Text = "部門篩選";
            this.ckDept.UseVisualStyleBackColor = true;
            this.ckDept.CheckedChanged += new System.EventHandler(this.ck_CheckedChanged);
            // 
            // ckStarter
            // 
            this.ckStarter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ckStarter.AutoSize = true;
            this.ckStarter.Location = new System.Drawing.Point(261, 3);
            this.ckStarter.Name = "ckStarter";
            this.ckStarter.Size = new System.Drawing.Size(84, 16);
            this.ckStarter.TabIndex = 4;
            this.ckStarter.Tag = "fmEmp";
            this.ckStarter.Text = "申請者篩選";
            this.ckStarter.UseVisualStyleBackColor = true;
            this.ckStarter.CheckedChanged += new System.EventHandler(this.ck_CheckedChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgv);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Size = new System.Drawing.Size(584, 312);
            this.splitContainer2.SplitterDistance = 279;
            this.splitContainer2.TabIndex = 0;
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
            this.flowTreenameDataGridViewTextBoxColumn,
            this.adateDataGridViewTextBoxColumn,
            this.empidDataGridViewTextBoxColumn,
            this.empnameDataGridViewTextBoxColumn,
            this.flowNodenameDataGridViewTextBoxColumn,
            this.empnameCheckDataGridViewTextBoxColumn,
            this.isCancelDataGridViewCheckBoxColumn});
            this.dgv.DataSource = this.vProcessFlowBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(584, 279);
            this.dgv.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "流程序號";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // flowTreenameDataGridViewTextBoxColumn
            // 
            this.flowTreenameDataGridViewTextBoxColumn.DataPropertyName = "FlowTree_name";
            this.flowTreenameDataGridViewTextBoxColumn.HeaderText = "流程名稱";
            this.flowTreenameDataGridViewTextBoxColumn.Name = "flowTreenameDataGridViewTextBoxColumn";
            this.flowTreenameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // adateDataGridViewTextBoxColumn
            // 
            this.adateDataGridViewTextBoxColumn.DataPropertyName = "adate";
            this.adateDataGridViewTextBoxColumn.HeaderText = "申請日期";
            this.adateDataGridViewTextBoxColumn.Name = "adateDataGridViewTextBoxColumn";
            this.adateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // empidDataGridViewTextBoxColumn
            // 
            this.empidDataGridViewTextBoxColumn.DataPropertyName = "Emp_id";
            this.empidDataGridViewTextBoxColumn.HeaderText = "申請者工號";
            this.empidDataGridViewTextBoxColumn.Name = "empidDataGridViewTextBoxColumn";
            this.empidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // empnameDataGridViewTextBoxColumn
            // 
            this.empnameDataGridViewTextBoxColumn.DataPropertyName = "Emp_name";
            this.empnameDataGridViewTextBoxColumn.HeaderText = "申請者姓名";
            this.empnameDataGridViewTextBoxColumn.Name = "empnameDataGridViewTextBoxColumn";
            this.empnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // flowNodenameDataGridViewTextBoxColumn
            // 
            this.flowNodenameDataGridViewTextBoxColumn.DataPropertyName = "FlowNode_name";
            this.flowNodenameDataGridViewTextBoxColumn.HeaderText = "處理進度";
            this.flowNodenameDataGridViewTextBoxColumn.Name = "flowNodenameDataGridViewTextBoxColumn";
            this.flowNodenameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // empnameCheckDataGridViewTextBoxColumn
            // 
            this.empnameCheckDataGridViewTextBoxColumn.DataPropertyName = "Emp_nameCheck";
            this.empnameCheckDataGridViewTextBoxColumn.HeaderText = "處理者";
            this.empnameCheckDataGridViewTextBoxColumn.Name = "empnameCheckDataGridViewTextBoxColumn";
            this.empnameCheckDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isCancelDataGridViewCheckBoxColumn
            // 
            this.isCancelDataGridViewCheckBoxColumn.DataPropertyName = "isCancel";
            this.isCancelDataGridViewCheckBoxColumn.HeaderText = "中止流程";
            this.isCancelDataGridViewCheckBoxColumn.Name = "isCancelDataGridViewCheckBoxColumn";
            this.isCancelDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // vProcessFlowBindingSource
            // 
            this.vProcessFlowBindingSource.DataMember = "vProcessFlow";
            this.vProcessFlowBindingSource.DataSource = this.dsFlow;
            // 
            // dsFlow
            // 
            this.dsFlow.DataSetName = "dsFlow";
            this.dsFlow.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDelete, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnReset, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnContinue, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAssign, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnFinish, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(584, 29);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Tag = "";
            this.btnCancel.Text = "中止運作";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDelete.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(429, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSave.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSave.ForeColor = System.Drawing.Color.Red;
            this.btnSave.Location = new System.Drawing.Point(358, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "存入";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnReset.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnReset.ForeColor = System.Drawing.Color.Maroon;
            this.btnReset.Location = new System.Drawing.Point(287, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(65, 23);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "重送";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnContinue.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnContinue.ForeColor = System.Drawing.Color.Green;
            this.btnContinue.Location = new System.Drawing.Point(74, 3);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(65, 23);
            this.btnContinue.TabIndex = 7;
            this.btnContinue.Text = "恢復運作";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAssign.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAssign.ForeColor = System.Drawing.Color.Maroon;
            this.btnAssign.Location = new System.Drawing.Point(216, 3);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(65, 23);
            this.btnAssign.TabIndex = 10;
            this.btnAssign.Text = "指向某人";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnFinish.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnFinish.ForeColor = System.Drawing.Color.Blue;
            this.btnFinish.Location = new System.Drawing.Point(145, 3);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(65, 23);
            this.btnFinish.TabIndex = 8;
            this.btnFinish.Text = "徹回";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btn_Click);
            // 
            // vProcessFlowTableAdapter
            // 
            this.vProcessFlowTableAdapter.ClearBeforeFill = true;
            // 
            // fmProcessFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.splitContainer1);
            this.Name = "fmProcessFlow";
            this.ShowIcon = false;
            this.Text = "fmProcessFlow";
            this.Load += new System.EventHandler(this.fmProcessFlow_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vProcessFlowBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFlow)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSelectMsg;
        private System.Windows.Forms.CheckBox ckDate;
        private System.Windows.Forms.CheckBox ckCancel;
        private System.Windows.Forms.CheckBox ckFlow;
        private System.Windows.Forms.CheckBox ckDept;
        private System.Windows.Forms.CheckBox ckStarter;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnFinish;
        private dsFlow dsFlow;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource vProcessFlowBindingSource;
        private FlowManage.dsFlowTableAdapters.vProcessFlowTableAdapter vProcessFlowTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn flowTreenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn flowNodenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empnameCheckDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCancelDataGridViewCheckBoxColumn;
    }
}