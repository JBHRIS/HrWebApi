
using ezEngineServices.core.Vdb;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;

namespace ezEngineServices.core.Dao
{
    public class UploadFileDao
    {

        private ezFlowContext dcFlow;

        public UploadFileDao()
        {
            ezFlowContext dcFlow = new ezFlowContext();
        }
        public UploadFileDao(ezFlowContext dcFlow)
        {
            this.dcFlow = dcFlow;
        }

        public List<UploadFileRow> GetData()
        {
            var rs = (from c in dcFlow.wfFormUploadFiles
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

        public List<UploadFileRow> GetDataByProcessID(string ProcessID)
        {
            var rs = (from c in dcFlow.wfFormUploadFiles
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

        public UploadFileRow GetDataByKey(int AutoKey)
        {
            var r = (from c in dcFlow.wfFormUploadFiles
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
            dcFlow.wfFormUploadFiles.Add(rf);
            dcFlow.SaveChanges();

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

            dcFlow.wfFormUploadFiles.AddRange(rsFormUploadFile);
            dcFlow.SaveChanges();

            IsSave = true;

            return IsSave;
        }

        public bool Delete(int AutoKey)
        {
            bool IsDelete = false;

            var r = (from c in dcFlow.wfFormUploadFiles
                     where c.iAutoKey == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                dcFlow.wfFormUploadFiles.Remove(r);
                dcFlow.SaveChanges();

                IsDelete = true;
            }

            return IsDelete;
        }

        public bool DeleteByProcessID(string ProcessID)
        {
            bool IsDelete = false;

            var rs = (from c in dcFlow.wfFormUploadFiles
                      where c.sProcessID == ProcessID
                      select c).ToList();

            if (rs.Count > 0)
            {
                dcFlow.wfFormUploadFiles.RemoveRange(rs);
                dcFlow.SaveChanges();

                IsDelete = true;
            }

            return IsDelete;
        }
    }
}
