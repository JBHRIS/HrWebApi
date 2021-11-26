namespace JBHR.Sys
{
    partial class DEPT_DATAID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DEPT_DATAID));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.uUSERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sysDS = new JBHR.Sys.SysDS();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainDS = new JBHR.MainDS();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.v_BASETableAdapter = new JBHR.MainDSTableAdapters.V_BASETableAdapter();
            this.u_USERTableAdapter = new JBHR.Sys.SysDSTableAdapters.U_USERTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.uUSERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(12, 40);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(459, 332);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(341, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "讀取";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ptxNobr
            // 
            this.ptxNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobr.CaptionLabel = null;
            this.ptxNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobr.DataSource = this.vBASEBindingSource;
            this.ptxNobr.DisplayMember = "name_c";
            this.ptxNobr.IsEmpty = false;
            this.ptxNobr.IsEmptyToQuery = true;
            this.ptxNobr.IsMustBeFound = true;
            this.ptxNobr.LabelText = "";
            this.ptxNobr.Location = new System.Drawing.Point(80, 11);
            this.ptxNobr.Name = "ptxNobr";
            this.ptxNobr.ReadOnly = false;
            this.ptxNobr.ShowDisplayName = true;
            this.ptxNobr.Size = new System.Drawing.Size(100, 22);
            this.ptxNobr.TabIndex = 4;
            this.ptxNobr.ValueMember = "nobr";
            this.ptxNobr.WhereCmd = "";
            // 
            // uUSERBindingSource
            // 
            this.uUSERBindingSource.DataMember = "U_USER";
            this.uUSERBindingSource.DataSource = this.sysDS;
            // 
            // sysDS
            // 
            this.sysDS.DataSetName = "SysDS";
            this.sysDS.Locale = new System.Globalization.CultureInfo("");
            this.sysDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.sysDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.mainDS;
            // 
            // mainDS
            // 
            this.mainDS.DataSetName = "MainDS";
            this.mainDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.mainDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "員工姓名";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(409, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "存檔";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // u_USERTableAdapter
            // 
            this.u_USERTableAdapter.ClearBeforeFill = true;
            // 
            // DEPT_DATAID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 384);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ptxNobr);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DEPT_DATAID";
            this.Text = "DEPT_DATAID";
            this.Load += new System.EventHandler(this.DEPT_DATAID_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uUSERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
        private JBControls.PopupTextBox ptxNobr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private MainDS mainDS;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private MainDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private System.Windows.Forms.BindingSource uUSERBindingSource;
        private SysDS sysDS;
        private SysDSTableAdapters.U_USERTableAdapter u_USERTableAdapter;
    }
}