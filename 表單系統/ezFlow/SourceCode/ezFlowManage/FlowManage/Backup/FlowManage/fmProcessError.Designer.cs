namespace FlowManage
{
    partial class fmProcessError
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
            this.bnOK = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.dsFlow = new FlowManage.dsFlow();
            this.vProcessExceptionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vProcessExceptionTableAdapter = new FlowManage.dsFlowTableAdapters.vProcessExceptionTableAdapter();
            this.autoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processFlowidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowTreenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowNodenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorMsgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vProcessExceptionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(584, 362);
            this.splitContainer1.SplitterDistance = 329;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.bnOK, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 29);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // bnOK
            // 
            this.bnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bnOK.Location = new System.Drawing.Point(192, 3);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(200, 23);
            this.bnOK.TabIndex = 3;
            this.bnOK.Text = "選取的項目問題已解決";
            this.bnOK.UseVisualStyleBackColor = true;
            this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.autoDataGridViewTextBoxColumn,
            this.processFlowidDataGridViewTextBoxColumn,
            this.flowTreenameDataGridViewTextBoxColumn,
            this.flowNodenameDataGridViewTextBoxColumn,
            this.empnameDataGridViewTextBoxColumn,
            this.errorTypeDataGridViewTextBoxColumn,
            this.errorMsgDataGridViewTextBoxColumn,
            this.adateDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.vProcessExceptionBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(584, 329);
            this.dgv.TabIndex = 1;
            // 
            // dsFlow
            // 
            this.dsFlow.DataSetName = "dsFlow";
            this.dsFlow.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vProcessExceptionBindingSource
            // 
            this.vProcessExceptionBindingSource.DataMember = "vProcessException";
            this.vProcessExceptionBindingSource.DataSource = this.dsFlow;
            // 
            // vProcessExceptionTableAdapter
            // 
            this.vProcessExceptionTableAdapter.ClearBeforeFill = true;
            // 
            // autoDataGridViewTextBoxColumn
            // 
            this.autoDataGridViewTextBoxColumn.DataPropertyName = "auto";
            this.autoDataGridViewTextBoxColumn.HeaderText = "自動編號";
            this.autoDataGridViewTextBoxColumn.Name = "autoDataGridViewTextBoxColumn";
            this.autoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // processFlowidDataGridViewTextBoxColumn
            // 
            this.processFlowidDataGridViewTextBoxColumn.DataPropertyName = "ProcessFlow_id";
            this.processFlowidDataGridViewTextBoxColumn.HeaderText = "流程序號";
            this.processFlowidDataGridViewTextBoxColumn.Name = "processFlowidDataGridViewTextBoxColumn";
            this.processFlowidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // flowTreenameDataGridViewTextBoxColumn
            // 
            this.flowTreenameDataGridViewTextBoxColumn.DataPropertyName = "FlowTree_name";
            this.flowTreenameDataGridViewTextBoxColumn.HeaderText = "流程名稱";
            this.flowTreenameDataGridViewTextBoxColumn.Name = "flowTreenameDataGridViewTextBoxColumn";
            this.flowTreenameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // flowNodenameDataGridViewTextBoxColumn
            // 
            this.flowNodenameDataGridViewTextBoxColumn.DataPropertyName = "FlowNode_name";
            this.flowNodenameDataGridViewTextBoxColumn.HeaderText = "節點名稱";
            this.flowNodenameDataGridViewTextBoxColumn.Name = "flowNodenameDataGridViewTextBoxColumn";
            this.flowNodenameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // empnameDataGridViewTextBoxColumn
            // 
            this.empnameDataGridViewTextBoxColumn.DataPropertyName = "Emp_name";
            this.empnameDataGridViewTextBoxColumn.HeaderText = "處理者";
            this.empnameDataGridViewTextBoxColumn.Name = "empnameDataGridViewTextBoxColumn";
            this.empnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // errorTypeDataGridViewTextBoxColumn
            // 
            this.errorTypeDataGridViewTextBoxColumn.DataPropertyName = "errorType";
            this.errorTypeDataGridViewTextBoxColumn.HeaderText = "例外類型";
            this.errorTypeDataGridViewTextBoxColumn.Name = "errorTypeDataGridViewTextBoxColumn";
            this.errorTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // errorMsgDataGridViewTextBoxColumn
            // 
            this.errorMsgDataGridViewTextBoxColumn.DataPropertyName = "errorMsg";
            this.errorMsgDataGridViewTextBoxColumn.HeaderText = "例外訊息";
            this.errorMsgDataGridViewTextBoxColumn.Name = "errorMsgDataGridViewTextBoxColumn";
            this.errorMsgDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // adateDataGridViewTextBoxColumn
            // 
            this.adateDataGridViewTextBoxColumn.DataPropertyName = "adate";
            this.adateDataGridViewTextBoxColumn.HeaderText = "發生時間";
            this.adateDataGridViewTextBoxColumn.Name = "adateDataGridViewTextBoxColumn";
            this.adateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fmProcessError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.splitContainer1);
            this.Name = "fmProcessError";
            this.Text = "fmProcessError";
            this.Load += new System.EventHandler(this.fmProcessError_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vProcessExceptionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.DataGridView dgv;
        private dsFlow dsFlow;
        private System.Windows.Forms.BindingSource vProcessExceptionBindingSource;
        private FlowManage.dsFlowTableAdapters.vProcessExceptionTableAdapter vProcessExceptionTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn autoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn processFlowidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn flowTreenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn flowNodenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorMsgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adateDataGridViewTextBoxColumn;
    }
}