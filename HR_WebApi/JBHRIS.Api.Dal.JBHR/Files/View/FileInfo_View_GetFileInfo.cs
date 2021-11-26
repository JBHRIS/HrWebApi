using JBHRIS.Api.Dal.Files.View;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Files;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Dal.JBHR.Files.View
{
    public class FileInfo_View_GetFileInfo : IFileInfo_View_GetFileInfo
    {
        private IUnitOfWork _unitOfWork;

        public FileInfo_View_GetFileInfo(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public FileInfoDto GetFileInfoByGuid(string FileGuid)
        {
            var data = _unitOfWork.Repository<FileInfo>().Reads().Select(p => new FileInfoDto()
            {
                FileId = p.FileId,
                FileGuid = p.FileGuid,
                FileName = p.FileName,
                ExtensionName = p.ExtensionName,
                FullName = p.FullName,
                FileStream = p.FileStream,
                ContentType = p.ContentType,
                FileSize = p.FileSize,
                FileTicket = p.FileTicket,
                CreateMan = p.CreateMan,
                CreateTime = p.CreateTime
            }).Where(p => p.FileGuid == FileGuid).FirstOrDefault();
            return data;
        }

        public ApiResult<string> InsertFileInfo(FileInfoDto fileInfoDto)
        {
            ApiResult<string> statusResultDto = new ApiResult<string>()
            {
                State = false
            };
            try
            {
                var roleRepo = _unitOfWork.Repository<FileInfo>();
                var isRepeat = roleRepo.Reads().Where(r => r.FileGuid == fileInfoDto.FileGuid).FirstOrDefault();
                if (isRepeat == null)
                {
                    FileInfo sysRolePage = new FileInfo()
                    {
                        FileId  = fileInfoDto.FileId,
                        FileGuid  = fileInfoDto.FileGuid,
                        FileName  = fileInfoDto.FileName, 
                        ExtensionName  = fileInfoDto.ExtensionName, 
                        FullName  = fileInfoDto.FullName,
                        FileStream  = fileInfoDto.FileStream, 
                        ContentType  = fileInfoDto.ContentType, 
                        FileSize  = fileInfoDto.FileSize, 
                        FileTicket  = fileInfoDto.FileTicket, 
                        CreateMan  = fileInfoDto.CreateMan,
                        CreateTime = fileInfoDto.CreateTime
                    };
                    roleRepo.Create(sysRolePage);
                    roleRepo.SaveChanges();
                    statusResultDto.State = true;
                }
                else
                {
                    statusResultDto.Message = "資料已重複";
                }
                return statusResultDto;
            }
            catch (Exception ex)
            {
                statusResultDto.Message = ex.ToString();
                return statusResultDto;
            }
        }

        public ApiResult<string> DeleteFileInfo(string FileGuid)
        {
            ApiResult<string> statusResultDto = new ApiResult<string>()
            {
                State = false
            };
            try
            {
                var roleRepo = _unitOfWork.Repository<FileInfo>();
                var data = _unitOfWork.Repository<FileInfo>().Reads().SingleOrDefault(x => x.FileGuid == FileGuid);
                if (data != null)
                {
                    roleRepo.Delete(data);
                    roleRepo.SaveChanges();
                    statusResultDto.State = true;
                }
                return statusResultDto;
            }
            catch (Exception ex)
            {
                statusResultDto.Message = ex.ToString();
                return statusResultDto;
            }
        }

        public List<FileInfoDto> GetFileInfoByFileTicket(string FileTicket)
        {
            var data = _unitOfWork.Repository<FileInfo>().Reads().Select(p => new FileInfoDto()
            {
                FileId = p.FileId,
                FileGuid = p.FileGuid,
                FileName = p.FileName,
                ExtensionName = p.ExtensionName,
                FullName = p.FullName,
                FileStream = p.FileStream,
                ContentType = p.ContentType,
                FileSize = p.FileSize,
                FileTicket = p.FileTicket,
                CreateMan = p.CreateMan,
                CreateTime = p.CreateTime
            }).Where(p => p.FileTicket == FileTicket).ToList();
            return data;
        }
    }
}
