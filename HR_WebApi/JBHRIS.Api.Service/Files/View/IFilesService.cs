using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Files;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace JBHRIS.Api.Service.Files.View
{
    public interface IFilesService
    {
        FileInfoDto GetFileInfoByGuid(string FileGuid);
        List<FileInfoDto> GetFileInfoByFileTicket(string FileTicket);
        ApiResult<string> InsertFileInfo(FileInfoDto fileInfoDto);
        ApiResult<string> DeleteFileInfo(string FileGuid);
        DataTable LoadExcelToDataTable(Stream stream, string FileName, string sheetName);
        List<TmtableImportDto> DataTableToTmtableImportDto(DataTable dataTable, string KeyMan);
        ApiResult<string> ImportAttendExcelCover(List<TmtableImportDto> tmtableImportDtos);
        ApiResult<string> ImportAttendExcelDelete(List<TmtableImportDto> tmtableImportDtos);
        ApiResult<string> ImportAttendExcelIgnore(List<TmtableImportDto> tmtableImportDtos);
        List<string> ExcelSheetName(Stream stream, string FileName);

    }
}
