using JBHRIS.Api.Dal.ezEngineServices.Dao;
using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dto.Vdb;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.ezFlow.ezEngineServicesImplement.Dao
{
    public class UploadFileDao : IUploadFileDaoInterface
    {

        private ezFlowContext _context;

        public UploadFileDao(ezFlowContext context)
        {
            this._context = context;
        }
        public bool Delete(int AutoKey)
        {
            bool IsDelete = false;

            var r = (from c in _context.wfFormUploadFiles
                     where c.iAutoKey == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                _context.wfFormUploadFiles.Remove(r);
                _context.SaveChanges();

                IsDelete = true;
            }

            return IsDelete;
        }

        public bool DeleteByProcessID(string ProcessID)
        {
            bool IsDelete = false;

            var rs = (from c in _context.wfFormUploadFiles
                      where c.sProcessID == ProcessID
                      select c).ToList();

            if (rs.Count > 0)
            {
                _context.wfFormUploadFiles.RemoveRange(rs);
                _context.SaveChanges();

                IsDelete = true;
            }

            return IsDelete;
        }

        public List<UploadFileRow> GetData()
        {
            var rs = (from c in _context.wfFormUploadFiles
                      select new UploadFileRow
                      {
                          AutoKey = c.iAutoKey,
                          FormCode = c.sFormCode,
                          FormName = c.sFormName,
                          ProcessID = c.sProcessID,
                          idProcess = c.idProcess,
                          Nobr = c.sNobr,
                          Key = c.sKey,
                          Key2 = c.sKey2,
                          UpName = c.sUpName,
                          ServerName = c.sServerName,
                          Description = c.sDescription,
                          Type = c.sType,
                          Size = c.iSize,
                          //Blob = c.oBlob,
                          KeyDate = c.dKeyDate.GetValueOrDefault(DateTime.Now),
                      }).ToList();

            return rs;
        }

        public UploadFileRow GetDataByKey(int AutoKey)
        {
            var r = (from c in _context.wfFormUploadFiles
                     where c.iAutoKey == AutoKey
                     select new UploadFileRow
                     {
                         AutoKey = c.iAutoKey,
                         FormCode = c.sFormCode,
                         FormName = c.sFormName,
                         ProcessID = c.sProcessID,
                         idProcess = c.idProcess,
                         Nobr = c.sNobr,
                         Key = c.sKey,
                         Key2 = c.sKey2,
                         UpName = c.sUpName,
                         ServerName = c.sServerName,
                         Description = c.sDescription,
                         Type = c.sType,
                         Size = c.iSize,
                         //Blob = c.oBlob,
                         KeyDate = c.dKeyDate.GetValueOrDefault(DateTime.Now),
                     }).FirstOrDefault();

            return r;
        }

        public List<UploadFileRow> GetDataByProcessID(string ProcessID)
        {
            var rs = (from c in _context.wfFormUploadFiles
                      where c.sProcessID == ProcessID
                      select new UploadFileRow
                      {
                          AutoKey = c.iAutoKey,
                          FormCode = c.sFormCode,
                          FormName = c.sFormName,
                          ProcessID = c.sProcessID,
                          idProcess = c.idProcess,
                          Nobr = c.sNobr,
                          Key = c.sKey,
                          Key2 = c.sKey2,
                          UpName = c.sUpName,
                          ServerName = c.sServerName,
                          Description = c.sDescription,
                          Type = c.sType,
                          Size = c.iSize,
                          //Blob = c.oBlob,
                          KeyDate = c.dKeyDate.GetValueOrDefault(DateTime.Now),
                      }).ToList();

            return rs;
        }

        public bool Save(UploadFileRow UploadFile)
        {
            bool IsSave = false;

            var rf = new wfFormUploadFile();
            rf.sFormCode = UploadFile.FormCode;
            rf.sFormName = UploadFile.FormName;
            rf.sProcessID = UploadFile.ProcessID;
            rf.idProcess = UploadFile.idProcess;
            rf.sNobr = UploadFile.Nobr;
            rf.sKey = UploadFile.Key;
            rf.sKey2 = UploadFile.Key2;
            rf.sUpName = UploadFile.UpName;
            rf.sServerName = UploadFile.ServerName;
            rf.sDescription = UploadFile.Description;
            rf.sType = UploadFile.Type;
            rf.iSize = UploadFile.Size;
            rf.dKeyDate = DateTime.Now;
            //rf.oBlob = UploadFile.Blob;
            _context.wfFormUploadFiles.Add(rf);
            _context.SaveChanges();

            IsSave = true;

            return IsSave;
        }

        public bool Save(List<UploadFileRow> UploadFiles)
        {
            bool IsSave = false;

            List<wfFormUploadFile> rsFormUploadFile = new List<wfFormUploadFile>();

            foreach (var UploadFile in UploadFiles)
            {
                var rf = new wfFormUploadFile();
                rf.sFormCode = UploadFile.FormCode;
                rf.sFormName = UploadFile.FormName;
                rf.sProcessID = UploadFile.ProcessID;
                rf.idProcess = UploadFile.idProcess;
                rf.sNobr = UploadFile.Nobr;
                rf.sKey = UploadFile.Key;
                rf.sKey2 = UploadFile.Key2;
                rf.sUpName = UploadFile.UpName;
                rf.sServerName = UploadFile.ServerName;
                rf.sDescription = UploadFile.Description;
                rf.sType = UploadFile.Type;
                rf.iSize = UploadFile.Size;
                rf.dKeyDate = DateTime.Now;
                //rf.oBlob = UploadFile.Blob;
                rsFormUploadFile.Add(rf);
            }

            _context.wfFormUploadFiles.AddRange(rsFormUploadFile);
            _context.SaveChanges();

            IsSave = true;

            return IsSave;
        }
    }
}
