using JBHRIS.Api.Dto.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.ezEngineServices.Dao
{
    public interface IShareUploadDaoInterface
    {

        public ShareUploadDto GetDataByKey(int AutoKey);
        public List<ShareUploadDto> GetFileListByCode(string Code);

        public bool Save(ShareUploadDto UploadFile);

        public bool Save(List<ShareUploadDto> UploadFiles);

        public bool Delete(int AutoKey);

    }
}
