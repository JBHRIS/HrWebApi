using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace JBModule.Pluging
{
	public class CMail
	{
		MailMessage message = new MailMessage();
		private string host;
		private bool isUseDefaultCredentials = true;
		private string loginID = "";
		private string loginPW = "";
		private Encoding _encoding = System.Text.Encoding.Default;

		private CMail() { }

		public CMail(string hostName)
		{
			host = hostName;
		}

		public void SetEncoding(Encoding encoding)
		{
			_encoding = encoding;
		}

		public void NetworkCredential(string userID, string userPW)
		{
			if (userID.Trim().Length == 0)
			{
				isUseDefaultCredentials = true;
				loginID = "";
				loginPW = "";
			}
			else
			{
				isUseDefaultCredentials = false;
				loginID = userID;
				loginPW = userPW;
			}
		}

		public void From(string address, string displayName)
		{
			message.From = new MailAddress(address, displayName, _encoding);
		}

		public void To(string address, string displayName)
		{
			message.To.Add(new MailAddress(address, displayName, _encoding));
		}

        public void ClearTo()
        {
            message.To.Clear();
        }

		public void CC(string address, string displayName)
		{
			message.CC.Add(new MailAddress(address, displayName, _encoding));
		}

        public void ClearCC()
        {
            message.CC.Clear();
        }

		public void Bcc(string address, string displayName)
		{
			message.Bcc.Add(new MailAddress(address, displayName, _encoding));
		}

        public void ClearBcc()
        {
            message.Bcc.Clear();
        }

		public void Attach(string fileName)
		{
			message.Attachments.Add(new Attachment(fileName));
		}

        public void ClearAttach()
        {
            message.Attachments.Clear();
        }

		public bool SendMail(string subject, string body, MailPriority priority)
		{			
			message.Subject = subject;
			message.Body = body;
			message.IsBodyHtml = true;
			message.Priority = priority;
			message.SubjectEncoding = _encoding;
			message.BodyEncoding = _encoding;			

			SmtpClient mailClient = new SmtpClient(host);
			mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;

			if (isUseDefaultCredentials) mailClient.UseDefaultCredentials = true;
			else
			{
				mailClient.UseDefaultCredentials = false;
				mailClient.Credentials = new System.Net.NetworkCredential(loginID, loginPW);
			}

			bool isSuccess;
			try
			{
				mailClient.Send(message);
				isSuccess = true;
			}
			catch {
				isSuccess = false;
			}

			return isSuccess;
		}
	}
}
