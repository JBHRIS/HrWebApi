using System.Windows.Forms;

namespace JBModule.Message.UI
{
    partial class FileManager
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.bnUp1 = new System.Windows.Forms.Button();
            this.textBoxUpName1 = new TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(511, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "上傳檔案";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bnUp1
            // 
            this.bnUp1.Location = new System.Drawing.Point(465, 19);
            this.bnUp1.Name = "bnUp1";
            this.bnUp1.Size = new System.Drawing.Size(40, 23);
            this.bnUp1.TabIndex = 1005;
            this.bnUp1.Text = "....";
            this.bnUp1.UseVisualStyleBackColor = true;
            this.bnUp1.Click += new System.EventHandler(this.bnUp1_Click);
            // 
            // textBoxUpName1
            // 
            this.textBoxUpName1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxUpName1.Location = new System.Drawing.Point(93, 20);
            this.textBoxUpName1.MaxLength = 500;
            this.textBoxUpName1.Name = "textBoxUpName1";
            this.textBoxUpName1.PasswordChar = '\0';
            this.textBoxUpName1.ReadOnly = true;
            this.textBoxUpName1.Size = new System.Drawing.Size(366, 22);
            this.textBoxUpName1.TabIndex = 1004;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("細明體", 9.75F);
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(24, 25);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(63, 13);
            this.label39.TabIndex = 1003;
            this.label39.Text = "檔案名稱";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(12, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(760, 489);
            this.dataGridView1.TabIndex = 1006;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "下載";
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Text = "下載";
            this.Column1.ToolTipText = "下載";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "刪除";
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Text = "刪除";
            this.Column2.UseColumnTextForButtonValue = true;
            // 
            // FileManager
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bnUp1);
            this.Controls.Add(this.textBoxUpName1);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.button1);
            this.Name = "FileManager";
            this.Load += new System.EventHandler(this.FileManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bnUp1;
        private TextBox textBoxUpName1;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn Column2;
    }
}
