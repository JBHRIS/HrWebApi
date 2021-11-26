using JBHRIS.Api.Dto.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.ezEngineServices.Dao
{
    public interface IUploadFileDaoInterface
    {
        public List<UploadFileRow> GetData();

        public List<UploadFileRow> GetDataByProcessID(string ProcessID);
        public UploadFileRow GetDataByKey(int AutoKey);

        public bool Save(UploadFileRow UploadFile);

        public bool Save(List<UploadFileRow> UploadFiles);

        public bool Delete(int AutoKey);

        public bool DeleteByProcessID(string ProcessID);
    }
}
