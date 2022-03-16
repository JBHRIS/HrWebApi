using JBHRIS.Api.Dto.System;
using JBHRIS.Api.Dto.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Interface.System
{
    public interface IShareUploadInterface
    {
        bool Save(ShareUploadDto UploadFile);
        ShareUploadDto GetDataByKey(int AutoKey);
        List<ShareUploadDto> GetFileListByCode(string Code);
        public bool Delete(int AutoKey);
        public bool Save(List<ShareUploadDto> UploadFiles);
    }
}
