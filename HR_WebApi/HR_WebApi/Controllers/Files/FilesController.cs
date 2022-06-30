using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using JBHRIS.Api.Dto;
using static System.Net.WebRequestMethods;
using JBHRIS.Api.Dto.Files;
using JBHRIS.Api.Service.Files.View;
using Microsoft.Extensions.FileProviders;
using JBHRIS.Api.Tools;
using System.Data;
using JBHRIS.Api.Service.Attendance;
using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Service.Attendance.Action;
using JBHRIS.Api.Dal.Salary.View;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Service.Attendance.Normal;
using JBHRIS.Api.Dto.Attendance.Action;

namespace HR_WebApi.Controllers
{
    /// <summary>
    /// 檔案
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private IConfiguration _configuration;
        private IFilesService _filesService;
        private IWorkScheduleCheckService _workScheduleCheckService;
        private IAttend_View_GetAttendRote _attend_View_GetAttendRote;
        private ITimetableGenerateService _timetableGenerateService;
        private ISalary_View_SalaryView _salary_View_SalaryView;
        private IAttendanceService _attendanceService;
        private IAttendanceGenerateService _attendanceGenerateService;

        public FilesController(IConfiguration configuration, IFilesService filesService, IWorkScheduleCheckService workScheduleCheckService,
            IAttend_View_GetAttendRote attend_View_GetAttendRote, ITimetableGenerateService timetableGenerateService,
            ISalary_View_SalaryView salary_View_SalaryView, IAttendanceService attendanceService, IAttendanceGenerateService attendanceGenerateService)
        {
            _configuration = configuration;
            _filesService = filesService;
            _workScheduleCheckService = workScheduleCheckService;
            _attend_View_GetAttendRote = attend_View_GetAttendRote;
            _timetableGenerateService = timetableGenerateService;
            _salary_View_SalaryView = salary_View_SalaryView;
            _attendanceService = attendanceService;
            _attendanceGenerateService = attendanceGenerateService;
        }

        /// <summary>
        /// 取得檔案by主檔Guid
        /// </summary>
        [Route("GetFilesByFileTicket")]
        [HttpPost, DisableRequestSizeLimit]
        [Authorize(Roles = "Files/GetFilesByFileTicket,Admin")]
        public ApiResult<List<FileInfoDto>> GetFilesByFileTicket(string fileTicket)
        {
            ApiResult<List<FileInfoDto>> apiResult = new ApiResult<List<FileInfoDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _filesService.GetFileInfoByFileTicket(fileTicket);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();

            }
            return apiResult;
        }

        /// <summary>
        /// 上傳單一檔案
        /// </summary>
        [Route("UploadSingleFile")]
        [HttpPost, DisableRequestSizeLimit]
        [Authorize(Roles = "Files/UploadSingleFile,Admin")]
        public async Task<ApiResult<SingleFileDto>> UploadSingleFile(IFormFile file, string FileTicket)
        {
            if (String.IsNullOrEmpty(FileTicket))
            {
                FileTicket = Guid.NewGuid().ToString();
            }

            return await Upload(file, FileTicket);
        }

        /// <summary>
        /// 上傳多個檔案
        /// </summary>
        [Route("UploadMultiple")]
        [HttpPost, DisableRequestSizeLimit]
        [Authorize(Roles = "Files/UploadMultipleFiles,Admin")]
        public async Task<ApiResult<MultipleFilesDto>> UploadMultipleFiles(IFormCollection files, string FileTicket)
        {
            ApiResult<MultipleFilesDto> apiResult = new ApiResult<MultipleFilesDto>();
            apiResult.State = false;
            try
            {
                if (files != null)
                {
                    if (String.IsNullOrEmpty(FileTicket))
                    {
                        FileTicket = Guid.NewGuid().ToString();
                    }

                    var AllFile = new MultipleFilesDto()
                    {
                        FileTicket = FileTicket,
                        Files = new List<ApiResult<SingleFileDto>>()
                    };
                    //Directory.GetCurrentDirectory()
                    for (var i = 0; i < files.Files.Count; i++)
                    {
                        var file = Request.Form.Files[i];
                        var SingleFile = await Upload(file, FileTicket);
                        AllFile.Files.Add(SingleFile);
                    }
                    apiResult.State = true;
                    apiResult.Result = AllFile;
                }
                return apiResult;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
                return apiResult;
            }
        }

        /// <summary>
        /// 下載檔案
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [Route("DownloadFiles")]
        [HttpGet]
        [Authorize(Roles = "Files/DownloadFiles,Admin")]
        public async Task<IActionResult> DownloadFiles(string fileGuid)
        {
            FileInfoDto fileInfoDto = _filesService.GetFileInfoByGuid(fileGuid);
            if (fileInfoDto != null)
            {
                UserInfo userInfo = JBHRIS.Api.Bll.GetUserInfos.GetUserInfo(User);
                string FileUploadPath = _configuration["FileUpload:Path"];
                if (userInfo.Connection != null)
                {
                    if (userInfo.Connection.Trim().Length > 0)
                    {
                        FileUploadPath = FileUploadPath + "\\" + userInfo.Connection.Trim();
                    }
                }
                var pathToSave = Path.Combine(FileUploadPath, fileInfoDto.FileGuid);
                var memoryStream = new MemoryStream();
                using (var stream = new FileStream(pathToSave, FileMode.Open))
                {
                    await stream.CopyToAsync(memoryStream);
                }
                memoryStream.Seek(0, SeekOrigin.Begin);
                var ContentType = fileInfoDto.ContentType;
                return File(memoryStream, ContentType, fileInfoDto.FileName);
            }
            else
            {
                return Ok(new { State = false, Message = "找不到檔案" });
            }

        }

        /// <summary>
        /// 刪除檔案
        /// </summary>
        /// <param name="fileGuid"></param>
        /// <returns></returns>
        [Route("DeleteFiles")]
        [HttpGet]
        [Authorize(Roles = "Files/DeleteFile,Admin")]
        public ApiResult<string> DeleteFile(string fileGuid)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                ApiResult<string> deleteDbFile = _filesService.DeleteFileInfo(fileGuid);
                if (deleteDbFile.State)
                {
                    UserInfo userInfo = JBHRIS.Api.Bll.GetUserInfos.GetUserInfo(User);
                    string FileUploadPath = _configuration["FileUpload:Path"];
                    if (userInfo.Connection != null)
                    {
                        if (userInfo.Connection.Trim().Length > 0)
                        {
                            FileUploadPath = FileUploadPath + "\\" + userInfo.Connection.Trim();
                        }
                    }
                    var pathToSave = Path.Combine(FileUploadPath);
                    IFileProvider physicalFileProvider = new PhysicalFileProvider(pathToSave);
                    if (physicalFileProvider is PhysicalFileProvider)
                    {
                        var directory = physicalFileProvider.GetDirectoryContents(string.Empty);
                        foreach (var file in directory)
                        {
                            if (!file.IsDirectory)
                            {
                                if (file.Name == fileGuid)
                                {
                                    var fileInfo = new System.IO.FileInfo(file.PhysicalPath);
                                    fileInfo.Delete();
                                }
                            }
                        }
                    }
                    apiResult.State = true;
                }
                else
                {
                    apiResult.Message = deleteDbFile.Message;
                }
                return apiResult;
            }
            catch (Exception ex)
            {
                apiResult.State = false;
                apiResult.Message = ex.ToString();
                return apiResult;
            }
        }

        /// <summary>
        /// 共用檔案上傳方法
        /// </summary>
        /// <param name="file"></param>
        /// <param name="FileTicket"></param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)] //Swagger不會產生給人呼叫
        public async Task<ApiResult<SingleFileDto>> Upload(IFormFile file, string FileTicket)
        {
            ApiResult<SingleFileDto> apiResult = new ApiResult<SingleFileDto>();
            apiResult.State = false;
            try
            {
                if (file.Length > 0)
                {
                    var FileGuid = Guid.NewGuid().ToString();
                    //double FileSizeMB = file.Length / 1024.0 / 1024.0;
                    //var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    UserInfo userInfo = JBHRIS.Api.Bll.GetUserInfos.GetUserInfo(User);
                    string FileUploadPath = _configuration["FileUpload:Path"];
                    if (userInfo.Connection != null)
                    {
                        if (userInfo.Connection.Trim().Length > 0)
                        {
                            FileUploadPath = FileUploadPath + "\\" + userInfo.Connection.Trim();
                        }
                    }
                    var pathToSave = Path.Combine(FileUploadPath, FileGuid);
                    var KeyMan = User.Identity.Name;
                    if (KeyMan == null) KeyMan = "";
                    FileInfoDto fileInfoDto = new FileInfoDto()
                    {
                        FileGuid = FileGuid,
                        FileName = file.FileName,
                        ExtensionName = "",
                        FileStream = new byte[0],
                        FullName = file.FileName,
                        ContentType = file.ContentType,
                        FileSize = file.Length,
                        FileTicket = FileTicket,
                        CreateMan = KeyMan,
                        CreateTime = DateTime.Now
                    };
                    var insertDB = _filesService.InsertFileInfo(fileInfoDto);
                    if (insertDB.State)
                    {
                        using (var stream = new FileStream(pathToSave, FileMode.Create))
                        {
                            apiResult.Result = new SingleFileDto
                            {
                                FileGuid = FileGuid,
                                FileName = file.FileName,
                                ContentType = file.ContentType,
                                FileSize = file.Length.ToString(),
                                FileTicket = FileTicket
                            };
                            await file.CopyToAsync(stream);
                            apiResult.State = true;
                        }
                    }
                    else
                    {
                        apiResult.Message = insertDB.Message;
                    }
                }
                return apiResult;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
                return apiResult;
            }
        }

        ApiResult<List<TmtableImportDto>> ImportAttendExcel(IFormFile file, string sheetName, string ImportType)
        {
            ApiResult<List<TmtableImportDto>> apiResult = new ApiResult<List<TmtableImportDto>>();
            apiResult.State = false;
            apiResult.Message = "";
            apiResult.Result = new List<TmtableImportDto>();
            var KeyMan = User.Identity.Name;
            if (KeyMan == null) KeyMan = "";
            try
            {
                List<TmtableImportDto> tmtableImportDtos;
                using (var stream = new StreamReader(file.OpenReadStream()))
                {
                    DataTable dataTable = _filesService.LoadExcelToDataTable(stream.BaseStream, file.FileName, sheetName);
                    tmtableImportDtos = _filesService.DataTableToTmtableImportDto(dataTable, KeyMan);
                    #region 排班檢核
                    foreach (var import in tmtableImportDtos)
                    {
                        var rotes = _attend_View_GetAttendRote.GetCodeFilterRotes(import.Nobr);
                        var DateBegin = new DateTime(int.Parse(import.Yymm.Substring(0, 4)), int.Parse(import.Yymm.Substring(4, 2)), 1);
                        var DateEnd = new DateTime(int.Parse(import.Yymm.Substring(0, 4)), int.Parse(import.Yymm.Substring(4, 2)), DateTime.DaysInMonth(int.Parse(import.Yymm.Substring(0, 4)), int.Parse(import.Yymm.Substring(4, 2))));
                        var workScheduleCheckEntry = new JBHRIS.Api.Dto.Attendance.WorkScheduleCheckEntry
                        {
                            CheckTypes = new List<string> { "CW7" },
                            workScheduleCheck = new JBHRIS.Api.Dto.Attendance.WorkScheduleCheckDto
                            {
                                BeginCheckDate = DateBegin,
                                EndCheckDate = DateEnd,
                                //scheduleTypes = scheduleTypes.ToArray(),
                                StartDate = new DateTime(2020, 11, 1),//todo:開始日期寫死
                                //workSchedules = workSchedulesOfEmp.ToArray(),
                                EmployeeId = import.Nobr
                            }
                        };
                        workScheduleCheckEntry.workScheduleCheck.WorkSchedules = new List<JBHRIS.Api.Dto.Attendance.WorkScheduleDto>();
                        int monthDay = DateTime.DaysInMonth(int.Parse(import.Yymm.Substring(0, 4)), int.Parse(import.Yymm.Substring(4, 2)));
                        for (int i = 1; i <= monthDay; i++)
                        {
                            var valueObj = import.GetType().GetProperty("D" + i.ToString()).GetValue(import);
                            if (valueObj != null)
                            {
                                string value = valueObj.ToString();
                                string realCode = value;
                                var rote = rotes.SingleOrDefault(p => p.RoteDisp.Trim().ToUpper() == value.Trim().ToUpper());
                                if (rote != null)
                                    realCode = rote.RoteCode;
                                else
                                    import.Message += "D" + i.ToString() + "班別錯誤：" + value + ";";
                                workScheduleCheckEntry.workScheduleCheck.WorkSchedules.Add(new JBHRIS.Api.Dto.Attendance.WorkScheduleDto { AttendanceDate = new DateTime(int.Parse(import.Yymm.Substring(0, 4)), int.Parse(import.Yymm.Substring(4, 2)), i), ScheduleType = realCode });
                                import.GetType().GetProperty("D" + i.ToString()).SetValue(import, realCode);
                            }
                        }
                        var resultCheck = _workScheduleCheckService.CheckWithQuery(workScheduleCheckEntry);
                        import.Message = resultCheck.Message;
                        import.WorkScheduleIssues = resultCheck.Result;
                        if (import.WorkScheduleIssues.Count > 0)
                            apiResult.Result.Add(import);
                        import.State = resultCheck.State;
                    }
                    #endregion

                    var IncludeProperties = new List<string>();
                    for (int i = 1; i <= 31; i++)
                    {
                        IncludeProperties.Add("D" + i);
                    }
                    //班別為null時轉成空白
                    tmtableImportDtos = tmtableImportDtos.ObjectStringNullToEmptyInclude(IncludeProperties);

                    foreach (var tmtable in tmtableImportDtos.Where(p => p.State).ToList())
                    {
                        int Year = Convert.ToInt32(tmtable.Yymm.Substring(0, 4));
                        int Month = Convert.ToInt32(tmtable.Yymm.Substring(4, 2));
                        DateTime beginDate = new DateTime(Year, Month, 1);
                        DateTime endDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
                        //取得當月員工出勤鎖檔日期
                        List<DateTime> lockAttDateList = _salary_View_SalaryView.GetDataPassList(tmtable.Nobr, beginDate, endDate);
                        //確認當月某出勤鎖檔日有資料
                        CheckDataHaveAttLockDto checkDataHaveAttLockDto = _attendanceService.CheckDataHaveAttLock(tmtable, lockAttDateList);
                        bool haveLockData = checkDataHaveAttLockDto.haveLockData;
                        string ErrorMessage = checkDataHaveAttLockDto.ErrorMessage; 

                        if (haveLockData)
                        {
                            //當月某出勤鎖檔日有資料，不給匯入班表
                            tmtable.WorkScheduleIssues.Add(new JBHRIS.Api.Dto.Attendance.WorkScheduleIssueDto { ErrorMessage = ErrorMessage });
                            apiResult.Result.Add(tmtable);
                        }
                        else
                        {
                            if (ImportType == "Ignore")
                                _filesService.ImportAttendExcelIgnore(new List<TmtableImportDto> { tmtable });
                            else if (ImportType == "Delete")
                                _filesService.ImportAttendExcelDelete(new List<TmtableImportDto> { tmtable });
                            else
                                _filesService.ImportAttendExcelCover(new List<TmtableImportDto> { tmtable });

                            DateTime genBeginDate = new DateTime(Year, Month, 1);
                            DateTime genEndDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
                            int monthDay = DateTime.DaysInMonth(int.Parse(tmtable.Yymm.Substring(0, 4)), int.Parse(tmtable.Yymm.Substring(4, 2)));
                            bool firstDaySet = false;
                            for (int i = 1; i <= monthDay; i++)
                            {
                                var valueObj = tmtable.GetType().GetProperty("D" + i.ToString()).GetValue(tmtable);
                                if (valueObj != null && valueObj.ToString().Trim().Length > 0 && firstDaySet == false)
                                {
                                    genBeginDate = new DateTime(Year, Month, i);
                                    genEndDate = new DateTime(Year, Month, i);
                                    firstDaySet = true;
                                }else if (valueObj != null && valueObj.ToString().Trim().Length > 0)
                                {
                                    genEndDate = new DateTime(Year, Month, i);
                                }
                            }

                            List<string> employeeList = new List<string> { tmtable.Nobr };
                            TimetableGenerateEntry timetableGenerateEntry = new TimetableGenerateEntry { employeeList = employeeList, Yymm = tmtable.Yymm };
                            var timetableResult = _timetableGenerateService.GenerateCore(timetableGenerateEntry,false);
                            _attendanceGenerateService.Generate(employeeList, genBeginDate, genEndDate);

                            if (!timetableResult.State)
                            {
                                tmtable.WorkScheduleIssues.Add(new JBHRIS.Api.Dto.Attendance.WorkScheduleIssueDto { ErrorMessage = timetableResult.Message });
                                apiResult.Result.Add(tmtable);
                            }
                        }
                    }
                }
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message += ex.Message;
            }
            return apiResult;
        }

        /// <summary>
        /// 出勤班表匯入_覆蓋
        /// </summary>
        [Route("ImportAttendExcelCover")]
        [HttpPost, DisableRequestSizeLimit]
        [Authorize(Roles = "Files/ImportAttendExcelCover,Admin")]
        public ApiResult<List<TmtableImportDto>> ImportAttendExcelCover(IFormFile file, string sheetName)
        {
            return ImportAttendExcel(file, sheetName, "Cover");
        }

        ///// <summary>
        ///// 出勤班表匯入_刪除
        ///// </summary>
        //[Route("ImportAttendExcelDelete")]
        //[HttpPost, DisableRequestSizeLimit]
        //[Authorize(Roles = "Files/ImportAttendExcelDelete,Admin")]
        //public ApiResult<List<TmtableImportDto>> ImportAttendExcelDelete(IFormFile file, string sheetName)
        //{
        //    return ImportAttendExcel(file, sheetName, "Delete");
        //}

        /// <summary>
        /// 出勤班表匯入_忽略
        /// </summary>
        [Route("ImportAttendExcelIgnore")]
        [HttpPost, DisableRequestSizeLimit]
        [Authorize(Roles = "Files/ImportAttendExcelIgnore,Admin")]
        public ApiResult<List<TmtableImportDto>> ImportAttendExcelIgnore(IFormFile file, string sheetName)
        {
            return ImportAttendExcel(file, sheetName, "Ignore");
        }


        /// <summary>
        /// 取得Excel工作表名稱
        /// </summary>
        [Route("GetExcelSheetName")]
        [HttpPost, DisableRequestSizeLimit]
        //[Authorize(Roles = "Files/GetExcelSheetName,Admin")]
        public ApiResult<List<string>> GetExcelSheetName(IFormFile file)
        {
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = false;
            try
            {
                using (var stream = new StreamReader(file.OpenReadStream()))
                {
                    apiResult.Result = _filesService.ExcelSheetName(stream.BaseStream, file.FileName);
                }
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.Message;
                apiResult.StackTrace = ex.StackTrace;
            }
            return apiResult;
        }

    }

}
