namespace JBHR.Sal
{
    partial class FRM4WO
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
            this.jqAbs = new JBControls.JBQuery();
            this.gvAbs = new System.Windows.Forms.DataGridView();
            this.btnWriteOff = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvAbs)).BeginInit();
            this.SuspendLayout();
            // 
            // jqAbs
            // 
            this.jqAbs.DataGrid = this.gvAbs;
            this.jqAbs.Location = new System.Drawing.Point(13, 15);
            this.jqAbs.Margin = new System.Windows.Forms.Padding(6);
            this.jqAbs.Name = "jqAbs";
            this.jqAbs.QuerySettingString = "ABS_WriteOff";
            this.jqAbs.RadDataGrid = null;
            this.jqAbs.Size = new System.Drawing.Size(636, 79);
            this.jqAbs.SourceTable = null;
            this.jqAbs.TabIndex = 4;
            // 
            // gvAbs
            // 
            this.gvAbs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvAbs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gvAbs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAbs.Location = new System.Drawing.Point(13, 104);
            this.gvAbs.Margin = new System.Windows.Forms.Padding(4);
            this.gvAbs.MultiSelect = false;
            this.gvAbs.Name = "gvAbs";
            this.gvAbs.RowHeadersVisible = false;
            this.gvAbs.RowHeadersWidth = 62;
            this.gvAbs.RowTemplate.Height = 24;
            this.gvAbs.Size = new System.Drawing.Size(982, 524);
            this.gvAbs.TabIndex = 5;
            this.gvAbs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvAbs_CellClick);
            // 
            // btnWriteOff
            // 
            this.btnWriteOff.Enabled = false;
            this.btnWriteOff.Location = new System.Drawing.Point(659, 62);
            this.btnWriteOff.Margin = new System.Windows.Forms.Padding(4);
            this.btnWriteOff.Name = "btnWriteOff";
            this.btnWriteOff.Size = new System.Drawing.Size(117, 23);
            this.btnWriteOff.TabIndex = 6;
            this.btnWriteOff.Text = "銷假作業";
            this.btnWriteOff.UseVisualStyleBackColor = true;
            this.btnWriteOff.Click += new System.EventHandler(this.btnWriteOff_Click);
            // 
            // FRM4WO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 641);
            this.Controls.Add(this.btnWriteOff);
            this.Controls.Add(this.gvAbs);
            this.Controls.Add(this.jqAbs);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRM4WO";
            this.Text = "FRM4WO";
            this.Load += new System.EventHandler(this.FRM4WO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvAbs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JBControls.JBQuery jqAbs;
        private System.Windows.Forms.DataGridView gvAbs;
        private System.Windows.Forms.Button btnWriteOff;
    }
}