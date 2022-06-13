using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;

namespace HR_TOOL.DataBase
{
    public partial class DbBackup : Form
    {
        public DbBackup()
        {
            InitializeComponent();
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            try
            {
                HrDBDataContext db = new HrDBDataContext();
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = db.Connection.Database + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";
                sfd.Filter = "資料庫備份|*.bak";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = sfd.FileName;
                    using (db.Connection)
                    {
                        JBTools.SQL.DatabaseBackup backup = new JBTools.SQL.DatabaseBackup(db.Connection);
                        backup.Backup(db.Connection.Database, path);
                        ZipFile zip = new ZipFile();
                        System.IO.FileInfo fi = new System.IO.FileInfo(path);
                        string zipFile = fi.FullName.Substring(0, fi.FullName.LastIndexOf('.')) + ".zip";
                        System.IO.FileInfo upfi = new System.IO.FileInfo(zipFile);
                        using (zip)
                        {
                            zip.AddFile(path);
                            zip.Save(zipFile);
                        }
                        JBTools.IO.FtpTranferFile.UploadFileToFTP(new Uri(textBox2.Text), upfi.Name, zipFile, textBox3.Text, textBox4.Text);
                        JBModule.Message.Mail mail = new JBModule.Message.Mail();
                        mail.SendMailWithQueue(textBox1.Text, "資料庫備份通知" + db.Connection.Database, "資料已備份到FTP：" + textBox2.Text + Environment.NewLine + "檔名：" + upfi.Name);
                    }
                }
            }

            catch (Exception ex)
            {
                JBModule.Message.Mail mail = new JBModule.Message.Mail();
                mail.SendMailWithQueue(textBox1.Text, "資料庫備份失敗通知" , ex.Message+Environment.NewLine+ex.StackTrace);
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("備份完成");
        }
    }
}
