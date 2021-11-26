using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Bll.Attendance.Action
{
    public class AttendanceGenerateBll : IAttendanceGenerateBll
    {
        public AttendanceGenerateBll()
        {

        }
        public List<AttendDto> Generate(DateTime DateBegin, DateTime DateEnd, List<TmtableDto> tmtableDtos, List<RotechgDto> rotechgDtos)
        {
            List<AttendDto> results = new List<AttendDto>();
            foreach (var tmtable in tmtableDtos)
            {
                List<AttendDto> resultsEmp = new List<AttendDto>();
                for (var day = DateBegin.Date; day <= DateEnd; day = day.AddDays(1))
                {
                    AttendDto attendDto = new AttendDto();

                    setDefault(attendDto, tmtable.Nobr, day);

                    setTmtable(attendDto, tmtable, day);

                    var rotechg = rotechgDtos.FirstOrDefault(p => p.Nobr == tmtable.Nobr && p.Adate == day);
                    setRotechg(attendDto, rotechg);

                    setRoteH(attendDto, resultsEmp, tmtable);

                    results.Add(attendDto);
                    resultsEmp.Add(attendDto);
                }
            }

            return results;
        }

        private void setRoteH(AttendDto attendDto, List<AttendDto> attendDtos, TmtableDto tmtable)
        {
            if (isHoliday(attendDto.Rote))
            {
                var previousAttend = attendDtos.FirstOrDefault(p => p.Adate == attendDto.Adate.AddDays(-1));
                if (previousAttend != null && !isHoliday(previousAttend.Rote))
                {
                    attendDto.RoteH = previousAttend.Rote;
                }
                else
                {
                    var nextAttend = attendDtos.OrderBy(p => p.Adate).FirstOrDefault(p => p.Adate > attendDto.Adate);
                    if (nextAttend != null && !isHoliday(nextAttend.Rote))
                    {
                        attendDto.RoteH = nextAttend.Rote;
                    }
                    else
                    {
                        var roteTmtableList = tmtable.GetRoteList();
                        var rote = roteTmtableList.Where(p => p.Key > attendDto.Adate.Day && !isHoliday(p.Value));
                        if (rote.Any())
                            attendDto.RoteH = rote.FirstOrDefault().Value;
                        else
                        {
                            rote = roteTmtableList.Where(p => p.Key < attendDto.Adate.Day && !isHoliday(p.Value));
                            if (rote != null)
                                attendDto.RoteH = rote.FirstOrDefault().Value;
                            else
                            {
                                rote = roteTmtableList.Where(p => p.Key < attendDto.Adate.Day && !isHoliday(p.Value));
                                if (rote.Any())
                                    attendDto.RoteH = rote.FirstOrDefault().Value;
                                else
                                {
                                    rote = roteTmtableList.Where(p => !isHoliday(p.Value));
                                    if (rote.Any())
                                        attendDto.RoteH = rote.FirstOrDefault().Value;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                attendDto.RoteH = attendDto.Rote;
            }
        }

        private bool isHoliday(string rote)
        {
            return new string[] { "00", "0X", "0Z" }.Contains(rote);
        }


        private void setRotechg(AttendDto attendDto, RotechgDto rotechg)
        {
            if (rotechg != null)
                attendDto.Rote = rotechg.Rote;
        }

        private void setDefault(AttendDto attendDto, string nobr, DateTime day)
        {
            attendDto.Nobr = nobr;
            attendDto.Adate = day;
            attendDto.AdjCode = "";
            attendDto.AttHrs = 0;
            attendDto.CantAdj = false;
            attendDto.DelayMins = 0;
            attendDto.EarlyMins = 0;
            attendDto.EMins = 0;
            attendDto.Foodamt = 0;
            attendDto.Foodsalcd = "";
            attendDto.Forget = 0;
            attendDto.KeyDate = DateTime.Now;
            attendDto.KeyMan = "";
            attendDto.LateMins = 0;
            attendDto.Nigamt = 0;
            attendDto.NightHrs = 0;
            attendDto.RelHrs = 0;
            attendDto.Rote = "";
            attendDto.RoteH = "";
            attendDto.Ser = 0;
            attendDto.Specamt = 0;
            attendDto.Specsalcd = "";
            attendDto.Stationamt = 0;

        }

        private void setTmtable(AttendDto attendDto, TmtableDto tmtable, DateTime day)
        {
            attendDto.Rote = tmtable.GetType().GetProperty("D" + day.Day.ToString()).GetValue(tmtable).ToString();
        }
    }
}
