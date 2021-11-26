namespace JBHR.Sal
{
    partial class FRM4P
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
            this.btnConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConfig
            // 
            this.btnConfig.BackgroundImage = global::JBHR.Properties.Resources.Settings_icon;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(1008, 21);
            this.btnConfig.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(38, 34);
            this.btnConfig.TabIndex = 1017;
            this.btnConfig.Tag = "FRM4P";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // FRM4P
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(1065, 786);
            this.Controls.Add(this.btnConfig);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRM4P";
            this.Controls.SetChildIndex(this.btnConfig, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRun;
        private SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.BindingSource sALCODEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter sALCODETableAdapter;
        private System.Windows.Forms.BindingSource bASEBindingSource1;
        private BaseDS baseDS;
        private System.Windows.Forms.BindingSource dEPTBindingSource;
        private JBHR.Sal.BaseDSTableAdapters.DEPTTableAdapter dEPTTableAdapter;
        private System.Windows.Forms.BindingSource dEPTBindingSource1;
        private System.Windows.Forms.BindingSource jOBLBindingSource;
        private JBHR.Sal.BaseDSTableAdapters.JOBLTableAdapter jOBLTableAdapter;
        private System.Windows.Forms.BindingSource jOBLBindingSource1;
        private ViewDS viewDS;
        private System.Windows.Forms.BindingSource fRM4PPRINTTYPEBindingSource;
        private JBHR.Sal.ViewDSTableAdapters.FRM4P_PRINTTYPETableAdapter fRM4P_PRINTTYPETableAdapter;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnConfig;
    }
}