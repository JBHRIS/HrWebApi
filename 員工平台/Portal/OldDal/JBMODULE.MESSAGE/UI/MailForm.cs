using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace JBModule.Message.UI
{
    public partial class MailForm : Form
    {
        public MailForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JBModule.Message.Mail mail = new Mail();
            List<Attachment> attachments = new List<Attachment>();
            var pathList = (string[])buttonAttachment.Tag;
            if (pathList != null)
            {
                foreach (var path in pathList)
                {
                    Attachment attachment = new Attachment(path);
                    attachments.Add(attachment);
                }
            }
            mail.SendMailWithQueueAndFileService(new MailAddress(textBoxSender.Text), new MailAddress(textBoxReceiver.Text), textBoxSubject.Text, richTextBoxBody.Text, attachments,dateTimePickerFreezeTime.Value);
            MessageBox.Show("寄送完成");
        }

        private void buttonAttachment_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                buttonAttachment.Tag = openFileDialog.FileNames;
            }
        }
    }
}
