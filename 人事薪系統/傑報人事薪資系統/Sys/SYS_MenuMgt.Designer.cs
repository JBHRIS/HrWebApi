namespace JBHR.Sys
{
    partial class SYS_MenuMgt
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.jbQuery2 = new JBControls.JBQuery();
            this.CompMenudataGridView = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnImportSetting = new System.Windows.Forms.Button();
            this.btnExportSetting = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.jbQuery1 = new JBControls.JBQuery();
            this.menuGroupDataGridView = new System.Windows.Forms.DataGridView();
            this.menuStripSetting = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompMenudataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuGroupDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitContainer1.Panel2.Controls.Add(this.menuStripSetting);
            this.splitContainer1.Size = new System.Drawing.Size(1064, 601);
            this.splitContainer1.SplitterDistance = 320;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 601);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(3, 303);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            this.splitContainer3.Panel1.Controls.Add(this.jbQuery2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.CompMenudataGridView);
            this.splitContainer3.Size = new System.Drawing.Size(314, 295);
            this.splitContainer3.SplitterDistance = 35;
            this.splitContainer3.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "公司選單設定";
            // 
            // jbQuery2
            // 
            this.jbQuery2.bnAddEnable = true;
            this.jbQuery2.bnDelEnable = true;
            this.jbQuery2.bnEditEnable = true;
            this.jbQuery2.bnExportEnable = true;
            this.jbQuery2.DataGrid = this.CompMenudataGridView;
            this.jbQuery2.Location = new System.Drawing.Point(84, 1);
            this.jbQuery2.Margin = new System.Windows.Forms.Padding(4);
            this.jbQuery2.Name = "jbQuery2";
            this.jbQuery2.QuerySettingString = "MenuGroupForComp";
            this.jbQuery2.RadDataGrid = null;
            this.jbQuery2.Size = new System.Drawing.Size(226, 31);
            this.jbQuery2.SortString = "";
            this.jbQuery2.SourceTable = null;
            this.jbQuery2.TabIndex = 2;
            this.jbQuery2.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.jbQuery2_RowInsert);
            this.jbQuery2.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.jbQuery2_RowUpdate);
            // 
            // CompMenudataGridView
            // 
            this.CompMenudataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.CompMenudataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompMenudataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompMenudataGridView.Location = new System.Drawing.Point(0, 0);
            this.CompMenudataGridView.MultiSelect = false;
            this.CompMenudataGridView.Name = "CompMenudataGridView";
            this.CompMenudataGridView.RowHeadersVisible = false;
            this.CompMenudataGridView.RowHeadersWidth = 62;
            this.CompMenudataGridView.RowTemplate.Height = 24;
            this.CompMenudataGridView.Size = new System.Drawing.Size(314, 256);
            this.CompMenudataGridView.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnImportSetting);
            this.splitContainer2.Panel1.Controls.Add(this.btnExportSetting);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.jbQuery1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.menuGroupDataGridView);
            this.splitContainer2.Size = new System.Drawing.Size(314, 294);
            this.splitContainer2.SplitterDistance = 62;
            this.splitContainer2.TabIndex = 3;
            // 
            // btnImportSetting
            // 
            this.btnImportSetting.Enabled = false;
            this.btnImportSetting.Location = new System.Drawing.Point(239, 8);
            this.btnImportSetting.Name = "btnImportSetting";
            this.btnImportSetting.Size = new System.Drawing.Size(65, 20);
            this.btnImportSetting.TabIndex = 5;
            this.btnImportSetting.Text = "匯入設定";
            this.btnImportSetting.UseVisualStyleBackColor = true;
            // 
            // btnExportSetting
            // 
            this.btnExportSetting.Enabled = false;
            this.btnExportSetting.Location = new System.Drawing.Point(165, 8);
            this.btnExportSetting.Name = "btnExportSetting";
            this.btnExportSetting.Size = new System.Drawing.Size(65, 20);
            this.btnExportSetting.TabIndex = 4;
            this.btnExportSetting.Text = "匯出設定";
            this.btnExportSetting.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "選單群組設定";
            // 
            // jbQuery1
            // 
            this.jbQuery1.bnAddEnable = true;
            this.jbQuery1.bnDelEnable = true;
            this.jbQuery1.bnEditEnable = true;
            this.jbQuery1.bnExportEnable = true;
            this.jbQuery1.DataGrid = this.menuGroupDataGridView;
            this.jbQuery1.Location = new System.Drawing.Point(84, 28);
            this.jbQuery1.Margin = new System.Windows.Forms.Padding(4);
            this.jbQuery1.Name = "jbQuery1";
            this.jbQuery1.QuerySettingString = "MenuMgt";
            this.jbQuery1.RadDataGrid = null;
            this.jbQuery1.Size = new System.Drawing.Size(226, 31);
            this.jbQuery1.SortString = "";
            this.jbQuery1.SourceTable = null;
            this.jbQuery1.TabIndex = 2;
            this.jbQuery1.RowDelete += new JBControls.JBQuery.RowDeleteEventHandler(this.menuGroupDataGridView_RowDelete);
            this.jbQuery1.RowInsert += new JBControls.JBQuery.RowInsertEventHandler(this.menuGroupDataGridView_RowInsert);
            this.jbQuery1.RowUpdate += new JBControls.JBQuery.RowUpdateEventHandler(this.menuGroupDataGridView_RowUpdate);
            // 
            // menuGroupDataGridView
            // 
            this.menuGroupDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.menuGroupDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.menuGroupDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuGroupDataGridView.Location = new System.Drawing.Point(0, 0);
            this.menuGroupDataGridView.MultiSelect = false;
            this.menuGroupDataGridView.Name = "menuGroupDataGridView";
            this.menuGroupDataGridView.RowHeadersVisible = false;
            this.menuGroupDataGridView.RowHeadersWidth = 62;
            this.menuGroupDataGridView.RowTemplate.Height = 24;
            this.menuGroupDataGridView.Size = new System.Drawing.Size(314, 228);
            this.menuGroupDataGridView.TabIndex = 1;
            this.menuGroupDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.menuGroupDataGridView_CellClick);
            // 
            // menuStripSetting
            // 
            this.menuStripSetting.AllowItemReorder = true;
            this.menuStripSetting.AllowMerge = false;
            this.menuStripSetting.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripSetting.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripSetting.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStripSetting.Location = new System.Drawing.Point(12, 9);
            this.menuStripSetting.Name = "menuStripSetting";
            this.menuStripSetting.Size = new System.Drawing.Size(202, 24);
            this.menuStripSetting.TabIndex = 0;
            this.menuStripSetting.Text = "menuStrip1";
            this.menuStripSetting.DoubleClick += new System.EventHandler(this.new_Menuitem_DoubleClick);
            // 
            // SYS_MenuMgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 601);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "SYS_MenuMgt";
            this.Text = "選單管理";
            this.Load += new System.EventHandler(this.SYS_MenuManagement_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CompMenudataGridView)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.menuGroupDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStripSetting;
        private System.Windows.Forms.DataGridView menuGroupDataGridView;
        private JBControls.JBQuery jbQuery1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label2;
        private JBControls.JBQuery jbQuery2;
        private System.Windows.Forms.DataGridView CompMenudataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImportSetting;
        private System.Windows.Forms.Button btnExportSetting;
    }
}