﻿namespace JBHR.Reports.SalForm
{
    partial class ZZ4B_Report
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
            this.RptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // RptViewer
            // 
            this.RptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RptViewer.Location = new System.Drawing.Point(0, 0);
            this.RptViewer.Name = "RptViewer";
            this.RptViewer.Size = new System.Drawing.Size(1016, 646);
            this.RptViewer.TabIndex = 0;
            // 
            // ZZ4B_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 646);
            this.Controls.Add(this.RptViewer);
            this.FormSize = JBControls.JBForm.FormSizeType.Large;
            this.Name = "ZZ4B_Report";
            this.Text = "其它費用總表";
            this.Load += new System.EventHandler(this.ZZ4B_Report_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RptViewer;
    }
}