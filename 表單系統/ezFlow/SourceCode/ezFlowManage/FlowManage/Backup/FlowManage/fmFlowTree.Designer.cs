namespace FlowManage
{
    partial class fmFlowTree
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
            this.btnY = new System.Windows.Forms.Button();
            this.cbxFlowTree = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnY
            // 
            this.btnY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnY.Location = new System.Drawing.Point(130, 4);
            this.btnY.Name = "btnY";
            this.btnY.Size = new System.Drawing.Size(37, 23);
            this.btnY.TabIndex = 6;
            this.btnY.Tag = "Yes";
            this.btnY.Text = "確定";
            this.btnY.UseVisualStyleBackColor = true;
            this.btnY.Click += new System.EventHandler(this.btnYorN_Click);
            // 
            // cbxFlowTree
            // 
            this.cbxFlowTree.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxFlowTree.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cbxFlowTree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFlowTree.DropDownWidth = 200;
            this.cbxFlowTree.FormattingEnabled = true;
            this.cbxFlowTree.Location = new System.Drawing.Point(3, 6);
            this.cbxFlowTree.Name = "cbxFlowTree";
            this.cbxFlowTree.Size = new System.Drawing.Size(121, 20);
            this.cbxFlowTree.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.cbxFlowTree, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnY, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(184, 32);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // fmFlowTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 32);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "fmFlowTree";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fmFlowTree";
            this.Load += new System.EventHandler(this.fmFlowTree_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnY;
        private System.Windows.Forms.ComboBox cbxFlowTree;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}