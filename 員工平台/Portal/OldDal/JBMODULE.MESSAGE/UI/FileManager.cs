using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using JBModule.Message;
using JBModule.Message.Service;

namespace JBModule.Message.UI
{
    public partial class FileManager :System.Windows.Forms.Form
    {
        public FileManager()
        {
            InitializeComponent();
        }
        public string FileTicket = "";
        public string Filter = "*.*|*.*";
        private void button1_Click(object sender, EventArgs e)
        {
            if (FileTicket.Trim().Length != 0)
            {
                string FilePath = textBoxUpName1.Text;
                FileInfo fi = new FileInfo(FilePath);
                if (fi.Exists)
                {
                    JBHRIS.BLL.Service.FileStreamService fss = new FileStreamService();
                    FileStream fs = new FileStream(FilePath, FileMode.Open);
                    using (fs)
                    {
                        JBHRIS.BLL.Dto.FileStreamInfoDto fsDto = new JBHRIS.BLL.Dto.FileStreamInfoDto();
                        fsDto.FileName = fi.Name; ;
                        fsDto.FileSize = fi.Length;
                        fsDto.FileStream = fs;
                        fsDto.FileTicket = FileTicket;
                        fsDto.ExtensionName = fi.Extension;
                        fsDto.FullName = fi.FullName;
                        fsDto.FileID = -1;
                        fsDto.CreateMan = USER_NAME;
                        fsDto.CreateTime = DateTime.Now;
                        fss.Upload(fsDto);
                        RefreshData();
                    }
                }
            }
        }

        public string USER_NAME { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            //DownloadFileByID();
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要刪除此檔案?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
            {
                if (FileTicket.Trim().Length != 0)
                {
                    JBHRIS.BLL.Service.FileStreamService fss = new FileStreamService();
                    var ff = fss.Download(-1);
                    fss.Delete(ff);
                    RefreshData();
                }
            }
        }

        private void bnUp1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = Filter;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                textBoxUpName1.Text = path;
            }
        }
        void RefreshData()
        {
            DBDataContext db = new DBDataContext();
            var data = db.FileStreamInfo.Where(p => p.FileTicket == FileTicket).Select(p => new { 下載 = "下載", 刪除 = "刪除", 檔案編號 = p.FileID, 檔案名稱 = p.FileName, 檔案大小 = p.FileSize, 檔案類型 = p.ExtensionName, });
            dataGridView1.DataSource = data;
        }

        private void FileManager_Load(object sender, EventArgs e)
        {
            //var colDelete = dataGridView1.Columns[0] as DataGridViewButtonCell;
            RefreshData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int FileID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                DownloadFileByID(FileID);
            }
            else if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("是否要刪除檔案", "檔案", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
                {
                    int FileID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                    DeleteFileByID(FileID);
                }
            }
        }

        private void DownloadFileByID(int FileID)
        {
            if (FileID != -1)
            {
                JBHRIS.BLL.Service.FileStreamService fss = new FileStreamService();
                var ff = fss.Download(FileID);
                SaveFileDialog ofd = new SaveFileDialog();
                ofd.Filter = Filter;
                ofd.FileName = ff.FileName;
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
                    byte[] array = new byte[ff.FileStream.Length];
                    ff.FileStream.Read(array, 0, array.Length);
                    fs.Write(array, 0, array.Length);
                    fs.Flush();
                    fs.Close();
                    fs.Dispose();
                    if (MessageBox.Show("是否要開啟檔案", "檔案", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start(ofd.FileName);
                    }
                }
            }
        }
        private void DeleteFileByID(int FileID)
        {
            if (FileID != -1)
            {
                JBHRIS.BLL.Service.FileStreamService fss = new FileStreamService();
                var ff = fss.Download(FileID);
                fss.Delete(ff);
                RefreshData();
            }
        }
    }
}
