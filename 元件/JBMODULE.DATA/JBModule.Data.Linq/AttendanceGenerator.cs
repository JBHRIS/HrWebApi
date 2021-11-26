using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JBTools.Extend;
using Dapper;

namespace JBHR.BLL.Att
{
    public class AttendanceGenerator
    {
        public string KeyMan = "JB";
        List<string> _EmployeeList;
        DateTime _DateBegin, _DateEnd;
        public List<JBModule.Data.Linq.TMTABLE> TimeTableList = null;
        public List<JBModule.Data.Linq.ATTEND> AttendList = null;
        public List<JBModule.Data.Linq.ROTECHG> rotechgList = null;
        public List<JBModule.Data.Linq.ROTE> roteList = null;
        List<string> holi_codeList = new List<string>() { "00", "0X", "0Y", "0Z" };
        public AttendanceGenerator(List<string> EmployeeList, DateTime DateBegin, DateTime DateEnd)
        {
            _EmployeeList = EmployeeList;
            _DateBegin = DateBegin;
            _DateEnd = DateEnd;
        }
        public AttendanceGenerator(string EmployeeID, DateTime DateBegin, DateTime DateEnd)
        {
            _EmployeeList = new List<string>();
            _EmployeeList.Add(EmployeeID);
            _DateBegin = DateBegin;
            _DateEnd = DateEnd;
        }
        public void Generate()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var TmTableSQL = from a in db.TMTABLE
                             where _EmployeeList.Contains(a.NOBR)
                             && a.YYMM.CompareTo(_DateBegin.ToString("yyyyMM")) >= 0 && a.YYMM.CompareTo(_DateEnd.ToString("yyyyMM")) <= 0
                             select a;
            var attendSQL = from a in db.ATTEND
                            where _EmployeeList.Contains(a.NOBR)
                            && a.ADATE.CompareTo(_DateBegin) >= 0 && a.ADATE.CompareTo(_DateEnd) <= 0
                            select a;
            var rotechgSQL = from a in db.ROTECHG
                             where _EmployeeList.Contains(a.NOBR)
                             && a.ADATE >= _DateBegin && a.ADATE <= _DateEnd
                             select a;
            var roteSQL = from a in db.ROTE
                          select a;
            if (TimeTableList == null)
                TimeTableList = TmTableSQL.ToList();
            if (AttendList == null)
                AttendList = attendSQL.ToList();
            if (rotechgList == null)
                rotechgList = rotechgSQL.ToList();
            if (roteList == null)
                roteList = roteSQL.ToList();

            List<JBModule.Data.Linq.ATTEND> BulkAttend = new List<JBModule.Data.Linq.ATTEND>();
            foreach (DataRow r in JBTools.Extend.CustomLINQtoDataSetMethods.CopyToDataTable(TimeTableList).Rows)
            {
                string nobr = r["NOBR"].ToString();
                int year = Convert.ToInt32(r["YYMM"].ToString().Substring(0, 4));
                int month = Convert.ToInt32(r["YYMM"].ToString().Substring(4, 2));
                DateTime d1, d2;
                int monthDays = DateTime.DaysInMonth(year, month);
                d1 = new DateTime(year, month, 1);
                if (d1 < _DateBegin) d1 = _DateBegin;
                d2 = new DateTime(year, month, monthDays);
                if (d2 > _DateEnd) d2 = _DateEnd;

                List<string> ttscodeList = new List<string>();
                ttscodeList.Add("1");
                ttscodeList.Add("4");
                ttscodeList.Add("6");
                var rotetByNobr = (from a in db.BASETTS
                                   where a.NOBR == nobr && ttscodeList.Contains(a.TTSCODE)
                                   && a.ADATE <= d2 && a.DDATE.Value >= d1
                                   select new { a.NOBR, a.ADATE, a.DDATE, a.ROTET }).ToList();

                var attendListOfNobr = AttendList.Where(p => p.NOBR.Trim() == nobr.Trim() && p.ADATE >= d1 && p.ADATE <= d2);
                string tmpRote = "00";
                for (DateTime i = d1; i <= d2; i = i.AddDays(1))
                {
                    string rote = r["D" + i.Day.ToString()].ToString();
                    //單日調班
                    var rotechgData = from a in rotechgList where a.NOBR.Trim().ToUpper() == nobr && a.ADATE == i select a;
                    if (rotechgData.Any())//如果有資料的話，就將班別改掉
                        rote = rotechgData.First().ROTE;
                    var attendListOfNobrAtDate = from a in attendListOfNobr where a.ADATE == i select a;
                    if (rote.Trim().Length == 0)
                    {
                        db.ATTEND.DeleteAllOnSubmit(attendListOfNobrAtDate);
                        continue;//如果空白就跳下一筆
                    }
                    if (!holi_codeList.Contains(rote))
                        tmpRote = rote;
                    JBModule.Data.Linq.ATTEND att = null;
                    if (attendListOfNobrAtDate.Any())
                    {//修改
                        att = attendListOfNobrAtDate.First().Clone();
                        att.KEY_DATE = DateTime.Now;
                        att.KEY_MAN = KeyMan;
                        att.ROTE = rote;
                        if (string.IsNullOrWhiteSpace(att.ROTE_H) || holi_codeList.Contains( att.ROTE_H))
                        {
                            att.ROTE_H = rote;
                            att.CANT_ADJ = false;
                        }
                        if (!att.CANT_ADJ)
                        {
                            if (holi_codeList.Contains(att.ROTE))
                            {
                                var attendListOfNobrAtDate1 = from a in attendListOfNobr where a.ADATE >= i.AddDays(-1) && !holi_codeList.Contains(a.ROTE) select a;
                                if (attendListOfNobrAtDate1.Any())
                                {
                                    att.ROTE_H = attendListOfNobrAtDate1.First().ROTE;
                                }
                                else
                                {
                                    var rotetByNobrData = rotetByNobr.Where(p => p.ADATE <= i && p.DDATE >= i).FirstOrDefault();
                                    if (rotetByNobrData != null)
                                    {
                                        var rotet = db.ROTET.Where(p => p.ROTET1 == rotetByNobrData.ROTET).FirstOrDefault();
                                        if (rotet != null)
                                        {
                                            Type type = rotet.GetType();
                                            for (int y = 1; y <= 10; y++)
                                            {
                                                string tempRote = type.GetProperty("R" + y.ToString()).GetValue(rotet, null).ToString();
                                                if (!string.IsNullOrWhiteSpace(tempRote) && !holi_codeList.Contains(tempRote))
                                                {
                                                    att.ROTE_H = tempRote;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                                att.ROTE_H = att.ROTE;
                        }
                    }
                    else
                    {//新增
                        att = new JBModule.Data.Linq.ATTEND();
                        att.ABS = false;
                        att.ADATE = i;
                        att.ADJ_CODE = "";
                        att.ATT_HRS = 0;
                        att.CANT_ADJ = false;
                        att.E_MINS = 0;
                        att.FOODAMT = 0;
                        att.SPECAMT = 0;
                        att.STATIONAMT = 0;
                        att.SPECSALCD = "";
                        att.ROTE = rote;
                        att.ROTE_H = rote;
                        if (string.IsNullOrWhiteSpace(att.ROTE_H) || holi_codeList.Contains(att.ROTE_H))
                        {
                            att.ROTE_H = rote;
                            att.CANT_ADJ = false;
                        }
                        if (!att.CANT_ADJ)
                        {
                            if (holi_codeList.Contains(att.ROTE))
                            {
                                var attendListOfNobrAtDate1 = from a in attendListOfNobr where a.ADATE >= i.AddDays(-1) && !holi_codeList.Contains(a.ROTE) select a;
                                if (attendListOfNobrAtDate1.Any())
                                {
                                    att.ROTE_H = attendListOfNobrAtDate1.First().ROTE;
                                }
                                else
                                {
                                    var rotetByNobrData = rotetByNobr.Where(p => p.ADATE <= i && p.DDATE >= i).FirstOrDefault();
                                    if (rotetByNobrData != null)
                                    {
                                        var rotet = db.ROTET.Where(p => p.ROTET1 == rotetByNobrData.ROTET).FirstOrDefault();
                                        if (rotet != null)
                                        {
                                            Type type = rotet.GetType();
                                            for (int y = 1; y <= 10; y++)
                                            {
                                                string tempRote = type.GetProperty("R" + y.ToString()).GetValue(rotet, null).ToString();
                                                if (!string.IsNullOrWhiteSpace(tempRote) && !holi_codeList.Contains(tempRote))
                                                {
                                                    att.ROTE_H = tempRote;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                                att.ROTE_H = att.ROTE;
                        }
                        var roteData = from rr in roteList where rr.ROTE1 == att.ROTE select rr;
                        if (!roteData.Any())
                        {
                            JBModule.Message.TextLog.WriteLog("工號" + nobr + "於" + i.ToShortDateString() + "的出勤班別無法辨識(" + att.ROTE + ")"
                                  );
                            continue;
                        }
                        var rowRote = roteData.First();
                        att.FOODSALCD = rowRote.FOODSALCD;
                        att.SER = 0;
                        att.FORGET = 0;
                        att.KEY_DATE = DateTime.Now;
                        att.KEY_MAN = KeyMan;
                        att.LATE_MINS = 0;
                        att.NIGAMT = rowRote.FOODAMT;
                        att.NIGHT_HRS = rowRote.NIGHT ? rowRote.WK_HRS : 0;
                        att.NOBR = nobr;
                        //db.ATTEND.InsertOnSubmit(att);
                    }
                    BulkAttend.Add(att);
                }
                //db.SubmitChanges();
            }
            //db.Connection.Execute("DELETE Attend WHERE nobr in @EmployeeList and adate between @DateBegin and @DateEnd" , new { EmployeeList = _EmployeeList, DateBegin = _DateBegin, DateEnd = _DateEnd });
            //db.BulkInsertAll(BulkAttend);
            string deleteSql = "DELETE Attend WHERE nobr in @EmployeeList and adate between @DateBegin and @DateEnd";
            object param = new { EmployeeList = _EmployeeList, DateBegin = _DateBegin, DateEnd = _DateEnd };
            string errMsg = "寫入出勤資料異常.";
            db.BulkInsertWithDelete(db, BulkAttend, deleteSql, param, errMsg);
        }
    }
}
