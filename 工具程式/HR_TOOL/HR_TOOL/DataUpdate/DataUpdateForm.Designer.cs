namespace HR_TOOL.DataUpdate
{
    partial class DataUpdateForm
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
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.cbxSheet = new Telerik.WinControls.UI.RadDropDownList();
            this.cbxTargetTable = new Telerik.WinControls.UI.RadDropDownList();
            this.label1 = new System.Windows.Forms.Label();
            this.gvWhereColumn = new Telerik.WinControls.UI.RadGridView();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.gvSetColumn = new Telerik.WinControls.UI.RadGridView();
            this.txtWhereCommand = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxTargetTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWhereColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWhereColumn.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSetColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSetColumn.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWhereCommand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radTextBox1
            // 
            this.radTextBox1.Enabled = false;
            this.radTextBox1.Location = new System.Drawing.Point(59, 14);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.Size = new System.Drawing.Size(259, 20);
            this.radTextBox1.TabIndex = 0;
            this.radTextBox1.TabStop = false;
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(324, 10);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(101, 24);
            this.radButton1.TabIndex = 1;
            this.radButton1.Text = "讀取檔案";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radGridView1
            // 
            this.radGridView1.Location = new System.Drawing.Point(59, 268);
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(965, 414);
            this.radGridView1.TabIndex = 3;
            this.radGridView1.Text = "radGridView1";
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(894, 225);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(130, 24);
            this.radButton2.TabIndex = 4;
            this.radButton2.Text = "寫入";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // cbxSheet
            // 
            this.cbxSheet.DropDownAnimationEnabled = true;
            this.cbxSheet.Location = new System.Drawing.Point(440, 12);
            this.cbxSheet.MaxDropDownItems = 0;
            this.cbxSheet.Name = "cbxSheet";
            this.cbxSheet.ShowImageInEditorArea = true;
            this.cbxSheet.Size = new System.Drawing.Size(259, 20);
            this.cbxSheet.TabIndex = 5;
            this.cbxSheet.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cbxSheet_SelectedIndexChanged);
            // 
            // cbxTargetTable
            // 
            this.cbxTargetTable.DropDownAnimationEnabled = true;
            this.cbxTargetTable.Location = new System.Drawing.Point(782, 12);
            this.cbxTargetTable.MaxDropDownItems = 0;
            this.cbxTargetTable.Name = "cbxTargetTable";
            this.cbxTargetTable.ShowImageInEditorArea = true;
            this.cbxTargetTable.Size = new System.Drawing.Size(139, 20);
            this.cbxTargetTable.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(710, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "目標資料表";
            // 
            // gvWhereColumn
            // 
            this.gvWhereColumn.EnableHotTracking = false;
            this.gvWhereColumn.Location = new System.Drawing.Point(59, 40);
            // 
            // gvWhereColumn
            // 
            this.gvWhereColumn.MasterTemplate.AllowAddNewRow = false;
            this.gvWhereColumn.MasterTemplate.AllowCellContextMenu = false;
            this.gvWhereColumn.MasterTemplate.AllowColumnChooser = false;
            this.gvWhereColumn.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.gvWhereColumn.MasterTemplate.AllowColumnReorder = false;
            this.gvWhereColumn.MasterTemplate.AllowColumnResize = false;
            this.gvWhereColumn.MasterTemplate.AllowDeleteRow = false;
            this.gvWhereColumn.MasterTemplate.AllowDragToGroup = false;
            this.gvWhereColumn.MasterTemplate.EnableGrouping = false;
            this.gvWhereColumn.Name = "gvWhereColumn";
            this.gvWhereColumn.Size = new System.Drawing.Size(309, 211);
            this.gvWhereColumn.TabIndex = 7;
            this.gvWhereColumn.Text = "radGridView2";
            // 
            // radButton3
            // 
            this.radButton3.Location = new System.Drawing.Point(927, 8);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(101, 24);
            this.radButton3.TabIndex = 1;
            this.radButton3.Text = "選擇";
            this.radButton3.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // gvSetColumn
            // 
            this.gvSetColumn.EnableHotTracking = false;
            this.gvSetColumn.Location = new System.Drawing.Point(390, 38);
            // 
            // gvSetColumn
            // 
            this.gvSetColumn.MasterTemplate.AllowAddNewRow = false;
            this.gvSetColumn.MasterTemplate.AllowCellContextMenu = false;
            this.gvSetColumn.MasterTemplate.AllowColumnChooser = false;
            this.gvSetColumn.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.gvSetColumn.MasterTemplate.AllowColumnReorder = false;
            this.gvSetColumn.MasterTemplate.AllowColumnResize = false;
            this.gvSetColumn.MasterTemplate.AllowDeleteRow = false;
            this.gvSetColumn.MasterTemplate.AllowDragToGroup = false;
            this.gvSetColumn.MasterTemplate.EnableGrouping = false;
            this.gvSetColumn.Name = "gvSetColumn";
            this.gvSetColumn.Size = new System.Drawing.Size(309, 211);
            this.gvSetColumn.TabIndex = 7;
            this.gvSetColumn.Text = "radGridView2";
            // 
            // txtWhereCommand
            // 
            this.txtWhereCommand.Location = new System.Drawing.Point(782, 40);
            this.txtWhereCommand.Name = "txtWhereCommand";
            this.txtWhereCommand.Size = new System.Drawing.Size(242, 20);
            this.txtWhereCommand.TabIndex = 8;
            this.txtWhereCommand.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(724, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "篩選條件";
            // 
            // DataUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 703);
            this.Controls.Add(this.txtWhereCommand);
            this.Controls.Add(this.gvSetColumn);
            this.Controls.Add(this.gvWhereColumn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxTargetTable);
            this.Controls.Add(this.cbxSheet);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radButton3);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.radTextBox1);
            this.Name = "DataUpdateForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "DataUpdateForm";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.DataUpdateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxTargetTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWhereColumn.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWhereColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSetColumn.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSetColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWhereCommand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox radTextBox1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadDropDownList cbxSheet;
        private Telerik.WinControls.UI.RadDropDownList cbxTargetTable;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadGridView gvWhereColumn;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadGridView gvSetColumn;
        private Telerik.WinControls.UI.RadTextBox txtWhereCommand;
        private System.Windows.Forms.Label label2;
    }
}
