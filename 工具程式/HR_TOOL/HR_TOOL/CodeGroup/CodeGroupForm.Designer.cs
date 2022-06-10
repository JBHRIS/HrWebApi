namespace HR_TOOL.CodeGroup
{
    partial class CodeGroupForm
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn4 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radDropDownList1 = new Telerik.WinControls.UI.RadDropDownList();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radCheckBox1 = new Telerik.WinControls.UI.RadCheckBox();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radCheckBox2 = new Telerik.WinControls.UI.RadCheckBox();
            this.radListView1 = new Telerik.WinControls.UI.RadListView();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.Location = new System.Drawing.Point(22, 82);
            // 
            // radGridView1
            // 
            gridViewCheckBoxColumn4.HeaderText = "";
            gridViewCheckBoxColumn4.Name = "column1";
            gridViewCheckBoxColumn4.Width = 51;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn4});
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(553, 435);
            this.radGridView1.TabIndex = 0;
            this.radGridView1.Text = "radGridView1";
            // 
            // radDropDownList1
            // 
            this.radDropDownList1.DropDownAnimationEnabled = true;
            this.radDropDownList1.Location = new System.Drawing.Point(22, 22);
            this.radDropDownList1.MaxDropDownItems = 0;
            this.radDropDownList1.Name = "radDropDownList1";
            this.radDropDownList1.ShowImageInEditorArea = true;
            this.radDropDownList1.Size = new System.Drawing.Size(146, 20);
            this.radDropDownList1.TabIndex = 1;
            this.radDropDownList1.Text = "radDropDownList1";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(174, 20);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(88, 24);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "讀取";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radCheckBox1
            // 
            this.radCheckBox1.Location = new System.Drawing.Point(22, 51);
            this.radCheckBox1.Name = "radCheckBox1";
            this.radCheckBox1.Size = new System.Drawing.Size(43, 18);
            this.radCheckBox1.TabIndex = 3;
            this.radCheckBox1.Text = "全選";
            this.radCheckBox1.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox1_ToggleStateChanged);
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(174, 50);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(88, 24);
            this.radButton2.TabIndex = 4;
            this.radButton2.Text = "寫入";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // radButton3
            // 
            this.radButton3.Location = new System.Drawing.Point(273, 20);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(88, 24);
            this.radButton3.TabIndex = 4;
            this.radButton3.Text = "清空";
            this.radButton3.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // radCheckBox2
            // 
            this.radCheckBox2.Location = new System.Drawing.Point(77, 51);
            this.radCheckBox2.Name = "radCheckBox2";
            this.radCheckBox2.Size = new System.Drawing.Size(77, 18);
            this.radCheckBox2.TabIndex = 5;
            this.radCheckBox2.Text = "去除已設定";
            this.radCheckBox2.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox2_ToggleStateChanged);
            // 
            // radListView1
            // 
            this.radListView1.GroupItemSize = new System.Drawing.Size(200, 20);
            this.radListView1.ItemSize = new System.Drawing.Size(200, 20);
            this.radListView1.Location = new System.Drawing.Point(602, 82);
            this.radListView1.Name = "radListView1";
            this.radListView1.ShowCheckBoxes = true;
            this.radListView1.Size = new System.Drawing.Size(178, 229);
            this.radListView1.TabIndex = 6;
            this.radListView1.Text = "radListView1";
            this.radListView1.SelectedItemChanged += new System.EventHandler(this.radListView1_SelectedItemChanged);
            // 
            // CodeGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 580);
            this.Controls.Add(this.radListView1);
            this.Controls.Add(this.radCheckBox2);
            this.Controls.Add(this.radButton3);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radCheckBox1);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.radDropDownList1);
            this.Controls.Add(this.radGridView1);
            this.Name = "CodeGroupForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "CodeGroupForm";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.CodeGroupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadDropDownList radDropDownList1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadCheckBox radCheckBox1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadCheckBox radCheckBox2;
        private Telerik.WinControls.UI.RadListView radListView1;
    }
}
