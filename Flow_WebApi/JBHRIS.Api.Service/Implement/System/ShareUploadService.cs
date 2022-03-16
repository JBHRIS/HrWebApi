using JBHRIS.Api.Dal.ezEngineServices.Dao;
using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.System;
using JBHRIS.Api.Dto.Vdb;
using JBHRIS.Api.Service.Interface.System;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Implement.System
{
    public class ShareUploadService : IShareUploadInterface
    {

        private IShareUploadDaoInterface _IShareUploadDaoInterface;

        public ShareUploadService(IShareUploadDaoInterface _IShareUploadDaoInterface)
        {
            this._IShareUploadDaoInterface = _IShareUploadDaoInterface;
        }

        public bool Delete(int AutoKey)
        {
            return this._IShareUploadDaoInterface.Delete(AutoKey);
        }

        public ShareUploadDto GetDataByKey(int AutoKey)
        {
            return this._IShareUploadDaoInterface.GetDataByKey(AutoKey);
        }
        public List<ShareUploadDto> GetFileListByCode(string Code)
        {
            return this._IShareUploadDaoInterface.GetFileListByCode(Code);
        }

        public bool Save(ShareUploadDto UploadFile)
        {
            return this._IShareUploadDaoInterface.Save(UploadFile);
        }

        public bool Save(List<ShareUploadDto> UploadFiles)
        {
            return this._IShareUploadDaoInterface.Save(UploadFiles);
        }
    }
}
