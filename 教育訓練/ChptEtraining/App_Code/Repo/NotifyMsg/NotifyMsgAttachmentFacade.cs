using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Repo
{
    public class NotifyMsgAttachmentFacade
    {
        public string Guid { get; set; }
        public string FileName { get; set; }
        public Byte[] FileStream { get; set; }

        public NotifyMsgAttachmentFacade()
        {
            Guid = System.Guid.NewGuid().ToString();            
        }
        /// <summary>
        /// 傳入檔名，二進位檔案
        /// </summary>
        /// <param name="AfileName"></param>
        /// <param name="AfileStream"></param>
        public NotifyMsgAttachmentFacade(string AfileName,Byte[] AfileStream)
        {
            Guid = System.Guid.NewGuid().ToString();
            FileStream = AfileStream;
            FileName = AfileName;
        }

        /// <summary>
        /// 傳入檔名，路徑
        /// </summary>
        /// <param name="AfileName"></param>
        /// <param name="AfilePath"></param>
        public NotifyMsgAttachmentFacade(string AfileName, string AfilePath)
        {
            Guid = System.Guid.NewGuid().ToString();
            FileStream = File.ReadAllBytes(AfilePath);
            FileName = AfileName;
        }

        public void LoadFileFrom(string AfilePath)
        {
            FileStream = File.ReadAllBytes(AfilePath);
        }
    }
}
