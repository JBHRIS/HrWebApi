using JBHRIS.Api.Dal.Files.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Files;
using JBHRIS.Api.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Service.Files.View
{
    public class FilesService : IFilesService
    {
        IFileInfo_View_GetFileInfo _fileInfo_View_GetFileInfo;
        IFileInfo_View_ImportExceltToTmtTableImport _fileInfo_View_ImportExceltToTmtTableImport;
        public FilesService(IFileInfo_View_GetFileInfo fileInfo_View_GetFileInfo,
            IFileInfo_View_ImportExceltToTmtTableImport fileInfo_View_ImportExceltToTmtTableImport)
        {
            _fileInfo_View_GetFileInfo = fileInfo_View_GetFileInfo;
            _fileInfo_View_ImportExceltToTmtTableImport = fileInfo_View_ImportExceltToTmtTableImport;
        }

        public List<TmtableImportDto> DataTableToTmtableImportDto(DataTable dataTable, string KeyMan)
        {
            var query = from product in dataTable.AsEnumerable() select product;
            List<TmtableImportDto> ts = query.Select(product => new TmtableImportDto
            {
                Yymm = product.Field<string>("出勤年月"),
                Nobr = product.Field<string>("工號"),
                D1 = product.Field<string>("D1"),
                D2 = product.Field<string>("D2"),
                D3 = product.Field<string>("D3"),
                D4 = product.Field<string>("D4"),
                D5 = product.Field<string>("D5"),
                D6 = product.Field<string>("D6"),
                D7 = product.Field<string>("D7"),
                D8 = product.Field<string>("D8"),
                D9 = product.Field<string>("D9"),
                D10 = product.Field<string>("D10"),
                D11 = product.Field<string>("D11"),
                D12 = product.Field<string>("D12"),
                D13 = product.Field<string>("D13"),
                D14 = product.Field<string>("D14"),
                D15 = product.Field<string>("D15"),
                D16 = product.Field<string>("D16"),
                D17 = product.Field<string>("D17"),
                D18 = product.Field<string>("D18"),
                D19 = product.Field<string>("D19"),
                D20 = product.Field<string>("D20"),
                D21 = product.Field<string>("D21"),
                D22 = product.Field<string>("D22"),
                D23 = product.Field<string>("D23"),
                D24 = product.Field<string>("D24"),
                D25 = product.Field<string>("D25"),
                D26 = product.Field<string>("D26"),
                D27 = product.Field<string>("D27"),
                D28 = product.Field<string>("D28"),
                D29 = product.Field<string>("D29"),
                D30 = product.Field<string>("D30"),
                D31 = product.Field<string>("D31"),
                KeyMan = KeyMan,
                KeyDate = DateTime.Now,
                No = 0,
                Holis = 0,
                FreqNo = 0
            }).ToList();
            return ts;
        }

        public ApiResult<string> DeleteFileInfo(string FileGuid)
        {
            return _fileInfo_View_GetFileInfo.DeleteFileInfo(FileGuid);
        }

        public List<string> ExcelSheetName(Stream stream, string FileName)
        {
            LoadExcelColumnNameStyle style = LoadExcelColumnNameStyle.DefinedColumn;
            var FileFormatList = FileName.Split('.');
            string FileFormat = "";
            if (FileFormatList != null && FileFormatList.Length > 1)
            {
                FileFormat = "." + FileFormatList[1];
            }
            NpoiExcelReader reader = new NpoiExcelReader(FileFormat, stream);
            reader.ColumnPosition = 0;
            reader.ColumnNameStyle = style;
            return reader.ColumnNameList;
        }

        public List<FileInfoDto> GetFileInfoByFileTicket(string FileTicket)
        {
            return _fileInfo_View_GetFileInfo.GetFileInfoByFileTicket(FileTicket);
        }

        public FileInfoDto GetFileInfoByGuid(string FileGuid)
        {
            return _fileInfo_View_GetFileInfo.GetFileInfoByGuid(FileGuid);
        }

        public ApiResult<string> ImportAttendExcelCover(List<TmtableImportDto> tmtableImportDtos)
        {
            return _fileInfo_View_ImportExceltToTmtTableImport.ImportAttendExcelCover(tmtableImportDtos);
        }

        public ApiResult<string> ImportAttendExcelDelete(List<TmtableImportDto> tmtableImportDtos)
        {
            return _fileInfo_View_ImportExceltToTmtTableImport.ImportAttendExcelDelete(tmtableImportDtos);
        }

        public ApiResult<string> ImportAttendExcelIgnore(List<TmtableImportDto> tmtableImportDtos)
        {
            return _fileInfo_View_ImportExceltToTmtTableImport.ImportAttendExcelIgnore(tmtableImportDtos);
        }

        public ApiResult<string> InsertFileInfo(FileInfoDto fileInfoDto)
        {
            return _fileInfo_View_GetFileInfo.InsertFileInfo(fileInfoDto);
        }

        public DataTable LoadExcelToDataTable(Stream stream, string FileName, string sheetName)
        {
            LoadExcelColumnNameStyle style = LoadExcelColumnNameStyle.DefinedColumn;
            var FileFormatList = FileName.Split('.');
            string FileFormat = "";
            if (FileFormatList != null && FileFormatList.Length > 1)
            {
                FileFormat = "." + FileFormatList[1];
            }
            NpoiExcelReader reader = new NpoiExcelReader(FileFormat, stream);
            reader.ColumnPosition = 0;
            reader.ColumnNameStyle = style;
            var LoadExcelToDataSet = reader.LoadExcelToDataSet();

            DataTable products = LoadExcelToDataSet.Tables[sheetName];

            return products;
        }
    }
}
