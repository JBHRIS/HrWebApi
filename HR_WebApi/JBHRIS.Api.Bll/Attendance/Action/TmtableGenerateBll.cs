using AutoMapper;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Bll.Attendance.Action
{
    public class TmtableGenerateBll : ITimetableGenerateBll
    {
        private bool isBreak;
        private IMapper _mapper;

        public TmtableGenerateBll(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<TmtableDto> Generate(string YYMM, List<EmployeeInfo_HoliCode> employeeInfos_HoliCode, List<RotetDto> rotetList, List<HoliDto> calendarList, List<TmtableImportDto> tmtableImportDtos)
        {
            List<TmtableDto> results = new List<TmtableDto>();
            #region 資料處理
            int Year = Convert.ToInt32(YYMM.Substring(0, 4));
            int Month = Convert.ToInt32(YYMM.Substring(4, 2));
            DateTime beginDateOfMonth, endDateOfMonth;
            beginDateOfMonth = new DateTime(Year, Month, 1);
            endDateOfMonth = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
            #endregion
            //匯總
            var group = employeeInfos_HoliCode.GroupBy(p => p.EmployeeId);
            foreach (var emp in group)
            {
                var tmtable = new TmtableDto();

                foreach (var property in tmtable.GetType().GetProperties())//預設值空白
                {
                    if (property.PropertyType == typeof(string))
                        property.SetValue(tmtable, "");
                }

                tmtable.Nobr = emp.Key;
                tmtable.Yymm = YYMM;
                var tmtableImport = tmtableImportDtos.FirstOrDefault(p => p.Nobr == tmtable.Nobr && p.Yymm == tmtable.Yymm);

                {
                    int LastSequnce = emp.First().LastSequnce;

                    foreach (var info in emp)
                    {
                        var roteSequnces = GetRotetList(info.Rotet, rotetList);
                        var rotet = rotetList.FirstOrDefault(p => p.Rotet1 == info.Rotet);
                        var rotetSize = roteSequnces.Count();

                        DateTime dateStart = beginDateOfMonth;
                        DateTime dateEnd = endDateOfMonth;

                        if (info.Adate > dateStart)
                            dateStart = info.Adate;
                        if (info.Ddate < dateEnd)
                            dateStart = info.Adate;

                        for (DateTime setDate = dateStart; setDate <= dateEnd; setDate = setDate.AddDays(1))
                        {
                            if (rotet.Freq == "1")
                                LastSequnce = (LastSequnce + 1) % rotetSize;
                            else if (rotet.Freq == "2" && Convert.ToInt32(setDate.DayOfWeek) % 7 == Convert.ToInt32(rotet.FreqStart) % 7)
                                LastSequnce = (LastSequnce + 1) % rotetSize;
                            else if (rotet.Freq == "3")
                                LastSequnce = (LastSequnce + 1) % rotetSize;
                            else LastSequnce = (LastSequnce) % rotetSize;

                            if (LastSequnce >= rotetSize)
                                LastSequnce = 0;
                            var rote = roteSequnces[LastSequnce];
                            var Calendar = calendarList.SingleOrDefault(p => p.HDate == setDate && p.HoliCode == info.Calendar);
                            if (Calendar != null && Calendar.Othcode_Rote.Trim().Length > 0)
                                rote = Calendar.Othcode_Rote;
                            if (tmtableImport != null)//有匯入資料
                            {
                                var roteImport = tmtableImport.GetType().GetProperty("D" + setDate.Day.ToString()).GetValue(tmtableImport);
                                if (roteImport != null && roteImport.ToString().Trim().Length > 0)//如果匯入資料不是空值或是空白
                                    tmtable.GetType().GetProperty("D" + setDate.Day.ToString()).SetValue(tmtable, roteImport.ToString().Trim());
                                else
                                    tmtable.GetType().GetProperty("D" + setDate.Day.ToString()).SetValue(tmtable, rote);
                            }
                            else
                                tmtable.GetType().GetProperty("D" + setDate.Day.ToString()).SetValue(tmtable, rote);
                        }
                        tmtable.FreqNo = LastSequnce;
                    }
                }
                results.Add(tmtable);
            }
            return results;
        }
        List<string> GetRotetList(string Rotet, List<RotetDto> rotetList)
        {
            var rotet = rotetList.FirstOrDefault(p => p.Rotet1 == Rotet);
            if (rotet == null)
            {
                throw new ArgumentNullException("找不到輪班別代碼" + Rotet);
            }
            List<string> lst = new List<string>();
            isBreak = false;
            SetList(lst, rotet.R1, rotet.R1t);
            SetList(lst, rotet.R2, rotet.R2t);
            SetList(lst, rotet.R3, rotet.R3t);
            SetList(lst, rotet.R4, rotet.R4t);
            SetList(lst, rotet.R5, rotet.R5t);
            SetList(lst, rotet.R6, rotet.R6t);
            SetList(lst, rotet.R7, rotet.R7t);
            SetList(lst, rotet.R8, rotet.R8t);
            SetList(lst, rotet.R9, rotet.R9t);
            SetList(lst, rotet.R10, rotet.R10t);
            return lst;
        }
        void SetList(List<string> lst, string Value, int count)
        {
            if (Value == null || Value.Trim().Length == 0 || isBreak)
            {
                isBreak = true;
                return;
            }
            for (int i = 0; i < count; i++)
                lst.Add(Value);
        }
    }
}
