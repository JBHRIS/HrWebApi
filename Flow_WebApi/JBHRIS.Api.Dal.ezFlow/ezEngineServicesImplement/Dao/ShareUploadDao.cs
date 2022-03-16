using JBHRIS.Api.Dal.ezEngineServices.Dao;
using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dto.Vdb;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using JBHRIS.Api.Dal.ezFlow.Entity.Share;

namespace JBHRIS.Api.Dal.ezFlow.ezEngineServicesImplement.Dao
{
    public class ShareUploadDao : IShareUploadDaoInterface
    {

        private ShareContext _context;

        public ShareUploadDao(ShareContext context)
        {
            this._context = context;
        }
        public bool Delete(int AutoKey)
        {
            bool IsDelete = false;

            var r = (from c in _context.ShareUploads
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                _context.ShareUploads.Remove(r);
                _context.SaveChanges();

                IsDelete = true;
            }

            return IsDelete;
        }


        

        public ShareUploadDto GetDataByKey(int AutoKey)
        {
            var r = (from c in _context.ShareUploads
                     where c.AutoKey == AutoKey
                     select new ShareUploadDto
                     {
                         Blob = c.Blob,
                         CompanyId = c.CompanyId,
                         ServerName = c.ServerName,
                         UploadName = c.UploadName,
                         Type = c.Type

                     }).FirstOrDefault();

            return r;
        }
        public List<ShareUploadDto> GetFileListByCode(string Code)
        {
            var r = (from c in _context.ShareUploads
                     where c.Code == Code
                     select new ShareUploadDto
                     {
                         AutoKey = c.AutoKey,
                         Blob = c.Blob,
                         CompanyId = c.CompanyId,
                         ServerName = c.ServerName,
                         UploadName = c.UploadName,
                         Type = c.Type
                     }).ToList();

            return r;
        }


        public bool Save(ShareUploadDto UploadFile)
        {
            bool IsSave = false;

            var rf = new ShareUpload();
            rf.SystemCode = "Reply";
            rf.CompanyId = UploadFile.CompanyId;
            rf.Code = UploadFile.Code;
            rf.Blob = UploadFile.Blob;
            rf.Key1 = UploadFile.Key1;
            rf.Key2 = UploadFile.Key2;
            rf.Key3 = UploadFile.Key3;
            rf.UploadName = UploadFile.UploadName;
            rf.ServerName = UploadFile.ServerName;
            rf.Note = UploadFile.Note;
            rf.Type = UploadFile.Type;
            rf.Size = UploadFile.Size;
            rf.Sort = UploadFile.Sort;
            rf.SystemUse = UploadFile.SystemUse;
            rf.Status = UploadFile.Status;
            rf.InsertMan = UploadFile.InsertMan;
            rf.InsertDate = UploadFile.InsertDate;
            rf.UpdateMan = UploadFile.UpdateMan;
            rf.UpdateDate = UploadFile.UpdateDate;
            //rf.sFormCode = UploadFile.FormCode;
            //rf.sFormName = UploadFile.FormName;
            //rf.sProcessID = UploadFile.ProcessID;
            //rf.idProcess = UploadFile.idProcess;
            //rf.sNobr = UploadFile.Nobr;
            //rf.sKey = UploadFile.Key;
            //rf.sKey2 = UploadFile.Key2;
            //rf.sUpName = UploadFile.UpName;
            //rf.sServerName = UploadFile.ServerName;
            //rf.sDescription = UploadFile.Description;
            //rf.sType = UploadFile.Type;
            //rf.iSize = UploadFile.Size;
            //rf.dKeyDate = DateTime.Now;
            ////rf.oBlob = UploadFile.Blob;
            _context.ShareUploads.Add(rf);
            _context.SaveChanges();

            IsSave = true;

            return IsSave;
        }

        public bool Save(List<ShareUploadDto> UploadFiles)
        {
            bool IsSave = false;

            List<ShareUpload> rsFormUploadFile = new List<ShareUpload>();

            foreach (var UploadFile in UploadFiles)
            {
                var rf = new ShareUpload();
                rf.SystemCode = "Reply";
                rf.CompanyId = UploadFile.CompanyId;
                rf.Blob = UploadFile.Blob;
                rf.Key1 = UploadFile.Key1;
                rf.Key2 = UploadFile.Key2;
                rf.Key3 = UploadFile.Key3;
                rf.UploadName = UploadFile.UploadName;
                rf.ServerName = UploadFile.ServerName;
                rf.Note = UploadFile.Note;
                rf.Type = UploadFile.Type;
                rf.Size = UploadFile.Size;
                rf.Sort = UploadFile.Sort;
                rf.SystemUse = UploadFile.SystemUse;
                rf.Status = UploadFile.Status;
                rf.InsertMan = UploadFile.InsertMan;
                rf.InsertDate = UploadFile.InsertDate;
                rf.UpdateMan = UploadFile.UpdateMan;
                rf.UpdateDate = UploadFile.UpdateDate;
                rsFormUploadFile.Add(rf);
            }

            _context.ShareUploads.AddRange(rsFormUploadFile);
            _context.SaveChanges();

            IsSave = true;

            return IsSave;
        }
    }
}
