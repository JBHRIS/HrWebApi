using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Tools;

namespace JBHRIS.Api.Dal.JBHR.Attendance.View
{
    public class Attend_View_GetCardSearch : IAttend_View_GetCardSearch
    {
        private IUnitOfWork _unitOfWork;
        public  Attend_View_GetCardSearch(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<List<CardSearchViewDto>> GetCardSearchView(CardSearchViewEntry cardSearchViewEntry)
        {
            ApiResult<List<CardSearchViewDto>> apiResult = new ApiResult<List<CardSearchViewDto>>();
            apiResult.State = false;
            try
            {
                var result = new List<CardSearchViewDto>();
                foreach (var item in cardSearchViewEntry.EmployeeList.Split(2100))
                {
                    var CardsByEntry = from c in _unitOfWork.Repository<Card>().Reads()
                                       join cl in _unitOfWork.Repository<Cardlosd>().Reads() on c.Reason equals cl.Code
                                       into clgrp
                                       from clg in clgrp.DefaultIfEmpty()
                                       join b in _unitOfWork.Repository<Base>().Reads() on c.Nobr equals b.Nobr
                                       join btts in _unitOfWork.Repository<Basetts>().Reads() on b.Nobr equals btts.Nobr
                                       join d in _unitOfWork.Repository<Dept>().Reads() on btts.Dept equals d.DNo
                                       where item.Contains(c.Nobr)
                                       && cardSearchViewEntry.DateBegin <= c.Adate && c.Adate <= cardSearchViewEntry.DateEnd
                                       && (btts.Ddate >= DateTime.Now && btts.Adate <= DateTime.Now)
                                       && new string[] { "1", "4", "6" }.Contains(btts.Ttscode)
                                       select new CardSearchViewDto
                                       {
                                          EmployeeID = b.Nobr,
                                          EmployeeName = b.NameC,
                                          DeptCode = d.DNo,
                                          DeptName = d.DName,
                                          PuchInDate = c.Adate,
                                          PuchInTime = c.Ontime,
                                          Forget = c.Los,
                                          ForgetReason = clg.Descr,
                                          Remarks = c.Meno
                                       };

                    if (cardSearchViewEntry.IsForget)
                    {
                        CardsByEntry = from c in CardsByEntry
                                       where c.Forget == true
                                       select c;
                    }

                    result.AddRange(CardsByEntry);
                }
                apiResult.State = true;
                apiResult.Result = result.ToList();

            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }

            return apiResult;
        }
    }
}
