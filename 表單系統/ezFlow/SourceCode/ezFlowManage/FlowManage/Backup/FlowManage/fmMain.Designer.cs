namespace FlowManage
{
    partial class fmMain
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
            this.stStrip = new System.Windows.Forms.StatusStrip();
            this.lblState = new System.Windows.Forms.ToolStripStatusLabel();
            this.muStrip = new System.Windows.Forms.MenuStrip();
            this.stStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // stStrip
            // 
            this.stStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblState});
            this.stStrip.Location = new System.Drawing.Point(0, 440);
            this.stStrip.Name = "stStrip";
            this.stStrip.Size = new System.Drawing.Size(684, 22);
            this.stStrip.TabIndex = 1;
            // 
            // lblState
            // 
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(32, 17);
            this.lblState.Text = "狀態";
            // 
            // muStrip
            // 
            this.muStrip.Location = new System.Drawing.Point(0, 0);
            this.muStrip.Name = "muStrip";
            this.muStrip.Size = new System.Drawing.Size(684, 24);
            this.muStrip.TabIndex = 7;
            this.muStrip.Text = "menuStrip1";
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.stStrip);
            this.Controls.Add(this.muStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.muStrip;
            this.Name = "fmMain";
            this.Text = "FlowManage V3.2 by ming 20121221";
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.MdiChildActivate += new System.EventHandler(this.fmMain_MdiChildActivate);
            this.stStrip.ResumeLayout(false);
            this.stStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip muStrip;
        public System.Windows.Forms.StatusStrip stStrip;
        public System.Windows.Forms.ToolStripStatusLabel lblState;
    }
}