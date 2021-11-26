using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Files.View
{
    public interface IFileInfo_View_ImportExceltToTmtTableImport
    {
        ApiResult<string> ImportAttendExcelCover(List<TmtableImportDto> tmtableImportDtos);
        ApiResult<string> ImportAttendExcelDelete(List<TmtableImportDto> tmtableImportDtos);
        ApiResult<string> ImportAttendExcelIgnore(List<TmtableImportDto> tmtableImportDtos);
    }
}
