using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace JBModule.Message.Service
{
    public class FileStreamService : JBHRIS.BLL.Service.FileStreamService
    {
        private System.Data.Common.DbConnection dbConnection;

        public FileStreamService()
        {
            DBDataContext db=new DBDataContext();
            dbConnection = db.Connection;
        }

        public FileStreamService(System.Data.Common.DbConnection dbConnection)
        {
            // TODO: Complete member initialization
            this.dbConnection = dbConnection;
        }
        public override JBHRIS.BLL.Dto.FileStreamInfoDto Download(object ID)
        {
            DBDataContext db = new DBDataContext(dbConnection);
            var instance = db.FileStreamInfo.SingleOrDefault(p => p.FileID == Convert.ToInt32(ID));
            if (instance != null)
            {
                JBHRIS.BLL.Dto.FileStreamInfoDto dto = new JBHRIS.BLL.Dto.FileStreamInfoDto
                {
                    ExtensionName = instance.ExtensionName,
                    FileID = instance.FileID,
                    FullName = instance.FullName,
                    FileTicket = instance.FileTicket,
                    FileName = instance.FileName,
                    FileSize = instance.FileSize,
                };
                MemoryStream ms = new MemoryStream(instance.FileStream.ToArray());
                dto.FileStream = ms;
                return dto;
            }
            return base.Download(ID);
        }
        public override List<JBHRIS.BLL.Dto.FileStreamInfoDto> DownloadByTicket(string Ticket)
        {
            DBDataContext db = new DBDataContext();
            var lst = db.FileStreamInfo.Where(p => p.FileTicket == Ticket).ToList();
            List<JBHRIS.BLL.Dto.FileStreamInfoDto> result = new List<JBHRIS.BLL.Dto.FileStreamInfoDto>();
            foreach (var instance in lst)
            {
                JBHRIS.BLL.Dto.FileStreamInfoDto dto = new JBHRIS.BLL.Dto.FileStreamInfoDto
                {
                    ExtensionName = instance.ExtensionName,
                    FileID = instance.FileID,
                    FullName = instance.FullName,
                    FileTicket = instance.FileTicket,
                    FileName = instance.FileName,
                    FileSize = instance.FileSize,
                };
                MemoryStream ms = new MemoryStream(instance.FileStream.ToArray());
                dto.FileStream = ms;
                result.Add(dto);
            }
            return result;
        }
        public override bool Upload(JBHRIS.BLL.Dto.FileStreamInfoDto file)
        {
            try
            {
                DBDataContext db = new DBDataContext();
                FileStreamInfo fsi = db.FileStreamInfo.SingleOrDefault(p => p.FileID == file.FileID);
                if (fsi == null)
                {
                    fsi = new FileStreamInfo
                    {
                        FileName = file.FileName,
                        FileID = file.FileID,
                        FileTicket = file.FileTicket,
                        //FileStream = file.FileStream,
                        ExtensionName = file.ExtensionName,
                        CreateMan = file.CreateMan,
                        CreateTime = file.CreateTime,
                        FileSize = file.FileSize,
                        FullName = file.FullName,
                    };
                    byte[] binaryData = new byte[file.FileStream.Length];
                    file.FileStream.Read(binaryData, 0, binaryData.Length);
                    fsi.FileStream = binaryData;
                    db.FileStreamInfo.InsertOnSubmit(fsi);
                }
                else
                {
                    byte[] binaryData = new byte[file.FileStream.Length];
                    file.FileStream.Read(binaryData, 0, binaryData.Length);
                    fsi.FileStream = binaryData;
                    fsi.FileName = file.FileName;
                }
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override bool Delete(JBHRIS.BLL.Dto.FileStreamInfoDto file)
        {
            try
            {
                DBDataContext db = new DBDataContext();
                FileStreamInfo fsi = db.FileStreamInfo.SingleOrDefault(p => p.FileID == file.FileID);
                if (fsi != null)
                {
                    db.FileStreamInfo.DeleteOnSubmit(fsi);
                }
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
