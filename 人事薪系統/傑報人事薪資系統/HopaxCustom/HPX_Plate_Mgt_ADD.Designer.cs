
namespace JBHR.HopaxCustom
{
    partial class HPX_Plate_Mgt_ADD
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbEmployee = new System.Windows.Forms.Label();
            this.ptxEmployee = new JBControls.PopupTextBox();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBas = new JBHR.Att.dsBas();
            this.lbVehicle_Type = new System.Windows.Forms.Label();
            this.cbxVehicle_Type = new System.Windows.Forms.ComboBox();
            this.lbMemo = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.lbPlate_Number = new System.Windows.Forms.Label();
            this.txtPlate_Number = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bASETableAdapter = new JBHR.Att.dsBasTableAdapters.BASETableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbEmployee, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ptxEmployee, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbVehicle_Type, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxVehicle_Type, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbMemo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtMemo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbPlate_Number, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPlate_Number, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(401, 125);
            this.tableLayoutPanel1.TabIndex = 64;
            // 
            // lbEmployee
            // 
            this.lbEmployee.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEmployee.AutoSize = true;
            this.lbEmployee.ForeColor = System.Drawing.Color.Red;
            this.lbEmployee.Location = new System.Drawing.Point(24, 9);
            this.lbEmployee.Name = "lbEmployee";
            this.lbEmployee.Size = new System.Drawing.Size(53, 12);
            this.lbEmployee.TabIndex = 47;
            this.lbEmployee.Text = "員工編號";
            // 
            // ptxEmployee
            // 
            this.ptxEmployee.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ptxEmployee.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxEmployee.CaptionLabel = null;
            this.ptxEmployee.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.ptxEmployee, 2);
            this.ptxEmployee.DataSource = this.bASEBindingSource;
            this.ptxEmployee.DisplayMember = "name_c";
            this.ptxEmployee.IsEmpty = false;
            this.ptxEmployee.IsEmptyToQuery = true;
            this.ptxEmployee.IsMustBeFound = true;
            this.ptxEmployee.LabelText = "";
            this.ptxEmployee.Location = new System.Drawing.Point(83, 4);
            this.ptxEmployee.Name = "ptxEmployee";
            this.ptxEmployee.ReadOnly = false;
            this.ptxEmployee.ShowDisplayName = true;
            this.ptxEmployee.Size = new System.Drawing.Size(96, 22);
            this.ptxEmployee.TabIndex = 1;
            this.ptxEmployee.ValueMember = "nobr";
            this.ptxEmployee.WhereCmd = "";
            // 
            // bASEBindingSource
            // 
            this.bASEBindingSource.DataMember = "BASE";
            this.bASEBindingSource.DataSource = this.dsBas;
            // 
            // dsBas
            // 
            this.dsBas.DataSetName = "dsBas";
            this.dsBas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbVehicle_Type
            // 
            this.lbVehicle_Type.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbVehicle_Type.AutoSize = true;
            this.lbVehicle_Type.ForeColor = System.Drawing.Color.Red;
            this.lbVehicle_Type.Location = new System.Drawing.Point(48, 40);
            this.lbVehicle_Type.Name = "lbVehicle_Type";
            this.lbVehicle_Type.Size = new System.Drawing.Size(29, 12);
            this.lbVehicle_Type.TabIndex = 46;
            this.lbVehicle_Type.Text = "車種";
            // 
            // cbxVehicle_Type
            // 
            this.cbxVehicle_Type.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxVehicle_Type.FormattingEnabled = true;
            this.cbxVehicle_Type.Location = new System.Drawing.Point(83, 36);
            this.cbxVehicle_Type.Name = "cbxVehicle_Type";
            this.cbxVehicle_Type.Size = new System.Drawing.Size(114, 20);
            this.cbxVehicle_Type.TabIndex = 4;
            // 
            // lbMemo
            // 
            this.lbMemo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbMemo.AutoSize = true;
            this.lbMemo.Location = new System.Drawing.Point(48, 71);
            this.lbMemo.Name = "lbMemo";
            this.lbMemo.Size = new System.Drawing.Size(29, 12);
            this.lbMemo.TabIndex = 51;
            this.lbMemo.Text = "備註";
            // 
            // txtMemo
            // 
            this.txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtMemo, 3);
            this.txtMemo.Location = new System.Drawing.Point(83, 66);
            this.txtMemo.MaxLength = 100;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(315, 22);
            this.txtMemo.TabIndex = 12;
            // 
            // lbPlate_Number
            // 
            this.lbPlate_Number.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPlate_Number.AutoSize = true;
            this.lbPlate_Number.Location = new System.Drawing.Point(224, 40);
            this.lbPlate_Number.Name = "lbPlate_Number";
            this.lbPlate_Number.Size = new System.Drawing.Size(53, 12);
            this.lbPlate_Number.TabIndex = 75;
            this.lbPlate_Number.Text = "車牌號碼";
            // 
            // txtPlate_Number
            // 
            this.txtPlate_Number.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlate_Number.Location = new System.Drawing.Point(283, 35);
            this.txtPlate_Number.MaxLength = 20;
            this.txtPlate_Number.Name = "txtPlate_Number";
            this.txtPlate_Number.Size = new System.Drawing.Size(115, 22);
            this.txtPlate_Number.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Location = new System.Drawing.Point(122, 97);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 66;
            this.btnSave.Text = "存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btnCancel, 2);
            this.btnCancel.Location = new System.Drawing.Point(263, 97);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 67;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // HPX_Plate_Mgt_ADD
            // 
            this.ClientSize = new System.Drawing.Size(425, 149);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HPX_Plate_Mgt_ADD";
            this.Load += new System.EventHandler(this.HPX_Plate_Mgt_ADD_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbEmployee;
        private JBControls.PopupTextBox ptxEmployee;
        private System.Windows.Forms.Label lbVehicle_Type;
        private System.Windows.Forms.ComboBox cbxVehicle_Type;
        private System.Windows.Forms.Label lbMemo;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Label lbPlate_Number;
        private System.Windows.Forms.TextBox txtPlate_Number;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private JBHR.Att.dsBas dsBas;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Att.dsBasTableAdapters.BASETableAdapter bASETableAdapter;
    }
}
