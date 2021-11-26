namespace JBHR.Att
{
    partial class FRM2CIS
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
            this.dgvExcelView = new System.Windows.Forms.DataGridView();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.btnShowRepeat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvExcelView
            // 
            this.dgvExcelView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcelView.Location = new System.Drawing.Point(12, 12);
            this.dgvExcelView.Name = "dgvExcelView";
            this.dgvExcelView.ReadOnly = true;
            this.dgvExcelView.RowTemplate.Height = 24;
            this.dgvExcelView.Size = new System.Drawing.Size(612, 387);
            this.dgvExcelView.TabIndex = 0;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(283, 416);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "確定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(483, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "總共筆數 : ";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(552, 406);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(11, 12);
            this.lbTotal.TabIndex = 4;
            this.lbTotal.Text = "0";
            // 
            // btnShowRepeat
            // 
            this.btnShowRepeat.Location = new System.Drawing.Point(202, 416);
            this.btnShowRepeat.Name = "btnShowRepeat";
            this.btnShowRepeat.Size = new System.Drawing.Size(75, 23);
            this.btnShowRepeat.TabIndex = 5;
            this.btnShowRepeat.Text = "顯示重複";
            this.btnShowRepeat.UseVisualStyleBackColor = true;
            this.btnShowRepeat.Visible = false;
            this.btnShowRepeat.Click += new System.EventHandler(this.btnShowRepeat_Click);
            // 
            // FRM2CIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 451);
            this.Controls.Add(this.btnShowRepeat);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.dgvExcelView);
            this.Name = "FRM2CIS";
            this.Text = "FRM2CIS";
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvExcelView;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Button btnShowRepeat;
    }
}