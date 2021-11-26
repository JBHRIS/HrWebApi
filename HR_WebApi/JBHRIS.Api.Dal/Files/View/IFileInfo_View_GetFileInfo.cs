using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Files.View
{
    public interface IFileInfo_View_GetFileInfo
    {
        FileInfoDto GetFileInfoByGuid(string FileGuid);
        List<FileInfoDto> GetFileInfoByFileTicket(string FileTicket);
        ApiResult<string> InsertFileInfo(FileInfoDto fileInfoDto);
        ApiResult<string> DeleteFileInfo(string FileGuid);
    }
}
