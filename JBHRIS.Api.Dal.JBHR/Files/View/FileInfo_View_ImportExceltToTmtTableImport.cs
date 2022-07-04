using JBHRIS.Api.Dal.Files.View;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Files;
using System;
using System.Collections.Generic;
using System.Text;
using JBHRIS.Api.Tools;
using System.Linq;

namespace JBHRIS.Api.Dal.JBHR.Files.View
{
    public class FileInfo_View_ImportExceltToTmtTableImport : IFileInfo_View_ImportExceltToTmtTableImport
    {
        private IUnitOfWork _unitOfWork;

        public FileInfo_View_ImportExceltToTmtTableImport(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<string> ImportAttendExcelCover(List<Dto.Files.TmtableImportDto> tmtableImportDtos)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<TmtableImport>();
                foreach (var item in tmtableImportDtos.Split(2100))
                {
                    item.ForEach((Dto.Files.TmtableImportDto p) =>
                    {
                        var repeat = (from r in Repo.Reads()
                                     where r.Nobr == p.Nobr && r.Yymm == p.Yymm
                                     select r).FirstOrDefault();
                        if (repeat != null)
                        {
                            int monthDay = DateTime.DaysInMonth(int.Parse(repeat.Yymm.Substring(0, 4)), int.Parse(repeat.Yymm.Substring(4, 2)));

                            for (int i = 1; i <= monthDay; i++)
                            {
                                var valueObj = p.GetType().GetProperty("D" + i.ToString()).GetValue(p);
                                var value = valueObj.ToString();
                                if (value != null && value.Trim().Length > 0)
                                {
                                    repeat.GetType().GetProperty("D" + i.ToString()).SetValue(repeat, value);
                                }
                            }
                            repeat.KeyMan = p.KeyMan;
                            repeat.KeyDate = p.KeyDate;
                            repeat.No = p.No;
                            repeat.Holis = p.Holis;
                            repeat.FreqNo = p.FreqNo;
                            Repo.Update(repeat);
                        }
                        else
                        {
                            TmtableImport tmtableImport = CovertTmtableImport(p);
                            Repo.Create(tmtableImport);
                        }
                        Repo.SaveChanges();
                    });
                }
                apiResult.State = true;
            }
            catch(Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        public ApiResult<string> ImportAttendExcelDelete(List<Dto.Files.TmtableImportDto> tmtableImportDtos)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<TmtableImport>();
                foreach (var item in tmtableImportDtos.Split(2100))
                {
                    item.ForEach((Dto.Files.TmtableImportDto p) =>
                    {
                        var repeat = (from r in Repo.Reads()
                                      where r.Nobr == p.Nobr && r.Yymm == p.Yymm
                                      select r).FirstOrDefault();

                        if (repeat != null)
                        {
                            Repo.Delete(repeat);
                        }
                        else
                        {
                            TmtableImport tmtableImport = CovertTmtableImport(p);
                            Repo.Create(tmtableImport);
                        }
                    });
                    Repo.SaveChanges();
                }
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        public ApiResult<string> ImportAttendExcelIgnore(List<Dto.Files.TmtableImportDto> tmtableImportDtos)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<TmtableImport>();
                foreach (var item in tmtableImportDtos.Split(2100))
                {
                    item.ForEach((Dto.Files.TmtableImportDto p) =>
                    {
                        var repeat = (from r in Repo.Reads()
                                      where r.Nobr == p.Nobr && r.Yymm == p.Yymm
                                      select r).FirstOrDefault();

                        if (repeat != null)
                        {
                        }
                        else
                        {
                            TmtableImport tmtableImport = CovertTmtableImport(p);
                            Repo.Create(tmtableImport);
                        }
                    });
                    Repo.SaveChanges();
                }
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }


        private TmtableImport CovertTmtableImport(Dto.Files.TmtableImportDto p)
        {
            TmtableImport tmtableImport = new TmtableImport()
            {
                Yymm = p.Yymm,
                Nobr = p.Nobr,
                D1 = p.D1,
                D2 = p.D2,
                D3 = p.D3,
                D4 = p.D4,
                D5 = p.D5,
                D6 = p.D6,
                D7 = p.D7,
                D8 = p.D8,
                D9 = p.D9,
                D10 = p.D10,
                D11 = p.D11,
                D12 = p.D12,
                D13 = p.D13,
                D14 = p.D14,
                D15 = p.D15,
                D16 = p.D16,
                D17 = p.D17,
                D18 = p.D18,
                D19 = p.D19,
                D20 = p.D20,
                D21 = p.D21,
                D22 = p.D22,
                D23 = p.D23,
                D24 = p.D24,
                D25 = p.D25,
                D26 = p.D26,
                D27 = p.D27,
                D28 = p.D28,
                D29 = p.D29,
                D30 = p.D30,
                D31 = p.D31,
                KeyMan = p.KeyMan,
                KeyDate = p.KeyDate,
                No = p.No,
                Holis = p.Holis,
                FreqNo = p.FreqNo
            };
            return tmtableImport;
        }
    }
}
