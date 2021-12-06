using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace TmFunc
{
    public class TimeTableGenerator
    {
        bool isBreak = false;
        public string KeyMan = "JB";
        List<string> _EmployeeList;
        string _YYMM;
        public TimeTableGenerator(List<string> EmployeeList, string YYMM)
        {
            _EmployeeList = EmployeeList;
            _YYMM = YYMM;
        }
        public TimeTableGenerator(string EmployeeID, string YYMM)
        {
            _EmployeeList = new List<string>();
            _EmployeeList.Add(EmployeeID);
            _YYMM = YYMM;
        }
        public void Generate(bool AttendanceGenerate = true)
        {
            int Year = Convert.ToInt32(_YYMM.Substring(0, 4));
            int Month = Convert.ToInt32(_YYMM.Substring(4, 2));
            DateTime d1, d2;
            d1 = new DateTime(Year, Month, 1);
            d2 = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
            string prevYymm = d1.AddMonths(-1).ToString("yyyyMM");
            ezEngineServices.TmFunc.Linq.HrDBDataContext db = new ezEngineServices.TmFunc.Linq.HrDBDataContext();
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            var sql = from a in db.BASETTS
                      where _EmployeeList.Contains(a.NOBR) && ttscodeList.Contains(a.TTSCODE)
                      && a.ADATE <= d2 && a.DDATE.Value >= d1
                      select new { a.NOBR, a.ADATE, a.DDATE, a.ROTET, a.HOLI_CODE };
            var rotetData = sql.Select(p => p.ROTET).Distinct();
            var gpSQL = from a in sql group a by a.NOBR;

            //產生班表
            //var dtTmt = new ezEngineServices.TmFunc.dsAtt.TMTABLEDataTable();
            var holiList = (from rHoli in db.HOLI
                            join b in db.OTHCODE on rHoli.OTHCODE equals b.OTHCODE1
                            where rHoli.H_DATE >= d1 && rHoli.H_DATE <= d2
                            && (b.STDHOLI || b.OTHHOLI)//屬於假日的部分
                            select rHoli).ToList();//取得期間行事曆設定

            var _HoliCode = (from _HoliCodei in db.OTHCODE select _HoliCodei).ToList();


            ezEngineServices.dsAttTableAdapters.TMTABLE_TMPTableAdapter ad = new ezEngineServices.dsAttTableAdapters.TMTABLE_TMPTableAdapter();
            ezEngineServices.dsAtt.TMTABLE_TMPDataTable tmtt = ad.GetDataByYymm(prevYymm);//取得上個月的設定

            ezEngineServices.dsAtt.TMTABLEDataTable dt = new ezEngineServices.dsAtt.TMTABLEDataTable();
            ezEngineServices.dsAttTableAdapters.TMTABLETableAdapter ad1 = new ezEngineServices.dsAttTableAdapters.TMTABLETableAdapter();

            var importList = (from a in db.TMTABLE_IMPORT
                              where _EmployeeList.Contains(a.NOBR)
                              && a.YYMM == _YYMM
                              select a).Distinct().ToList();//有無匯入的資料
            //var rotechgList = (from a in db.ROTECHG
            //                   where EmployeeList.Contains(a.NOBR)
            //                   where a.ADATE >= d1 && a.ADATE <= d2
            //                   select new { a.NOBR, a.ADATE, a.ROTE }).ToList();
            var roteList = (from rr in db.ROTE select rr).ToList();
            var rotetList = db.ROTET.ToList();
            //string roteHoliCode = "00";
            //var attendList = (from a in db.ATTEND
            //                  where EmployeeList.Contains(a.NOBR)
            //                  && a.ADATE >= d1 && a.ADATE <= d2
            //                  select a).ToList();
            foreach (var it in rotetData)
            {
                object[] parms1 = new object[] { _YYMM, it };
                db.ExecuteCommand("delete tmtable_TMP where ROTE={1} and yymm={0}", parms1);
                var tmttOfRotet = tmtt.FindByYYMMROTE(prevYymm, it);

                var rotet = rotetList.Where(p => p.ROTET1 == it).FirstOrDefault();

                List<string> lst = new List<string>();
                isBreak = false;
                SetList(lst, rotet.R1, rotet.R1T);
                SetList(lst, rotet.R2, rotet.R2T);
                SetList(lst, rotet.R3, rotet.R3T);
                SetList(lst, rotet.R4, rotet.R4T);
                SetList(lst, rotet.R5, rotet.R5T);
                SetList(lst, rotet.R6, rotet.R6T);
                SetList(lst, rotet.R7, rotet.R7T);
                SetList(lst, rotet.R8, rotet.R8T);
                SetList(lst, rotet.R9, rotet.R9T);
                SetList(lst, rotet.R10, rotet.R10T);
                int freq = lst.Count() - 1;//預設起始點

                if (tmttOfRotet != null) freq = Convert.ToInt32(tmttOfRotet.FREQ_NO);//如果上個月有班表，就取得上次的排班位置

                tmttOfRotet = tmtt.NewTMTABLE_TMPRow();//新增
                tmttOfRotet.SetRowDefaultValue();
                tmttOfRotet.FREQ_NO = 0;
                tmttOfRotet.HOLIS = 0;
                tmttOfRotet.KEY_DATE = DateTime.Now;
                tmttOfRotet.KEY_MAN = KeyMan;
                tmttOfRotet.NO = 0;
                tmttOfRotet.ROTE = it;
                tmttOfRotet.YYMM = _YYMM;

                int monthDays = DateTime.DaysInMonth(Year, Month);
                int no = freq;

                for (int i = 0; i < monthDays; i++)
                {
                    DateTime dd = new DateTime(Year, Month, i + 1);
                    if (rotet.FREQ == "1")
                        no = (no + 1) % lst.Count();
                    else if (rotet.FREQ == "2" && Convert.ToInt32(dd.DayOfWeek) % 7 == Convert.ToInt32(rotet.FREQ_START) % 7)
                        no = (no + 1) % lst.Count();
                    else if (rotet.FREQ == "3")
                        no = (freq + 1) % lst.Count();
                    else no = (no) % lst.Count();
                    //no = no < 0 ? 0 : no;
                    tmttOfRotet["D" + (i + 1).ToString()] = lst[no];
                }
                tmttOfRotet.FREQ_NO = no;
                tmtt.AddTMTABLE_TMPRow(tmttOfRotet);
            }

            foreach (var it in _EmployeeList)
            {
                object[] parms = new object[] { it, _YYMM };
                db.ExecuteCommand("delete tmtable where nobr={0} and yymm={1}", parms);
            }

            foreach (var it in gpSQL)
            {
                var r = dt.NewTMTABLERow();
                r.SetRowDefaultValue();
                //如果有手動匯入的部分，就置換掉
                var importData = from a in importList where a.NOBR == it.Key select a;

                foreach (var gp in it)//以人
                {
                    ezEngineServices.dsAtt.TMTABLE_TMPRow rTmp = tmtt.FindByYYMMROTE(_YYMM, gp.ROTET);//取得範本    
                    var dtImp = JBTools.Extend.CustomLINQtoDataSetMethods.CopyToDataTable(importData);
                    DataRow rImp = null;
                    if (dtImp.Rows.Count > 0)
                        rImp = dtImp.Rows[0];
                    //int count = 0;
                    //count++;
                    var rotet = rotetList.Where(p => p.ROTET1 == gp.ROTET).FirstOrDefault();//取得Rotet設定
                    DateTime dd1, dd2;
                    dd1 = gp.ADATE > d1 ? gp.ADATE : d1;
                    dd2 = gp.DDATE.Value < d2 ? gp.DDATE.Value : d2;
                    r.FREQ_NO = rTmp.FREQ_NO;
                    r.HOLIS = rTmp.HOLIS;
                    r.KEY_DATE = DateTime.Now;
                    r.KEY_MAN = KeyMan;
                    r.NO = rTmp.NO;
                    r.NOBR = gp.NOBR;
                    r.YYMM = _YYMM;
                    //var attendListOfNobr = from a in attendList where a.NOBR == r.NOBR select a;

                    for (DateTime i = dd1; i <= dd2; i = i.AddDays(1))
                    {
                        int nn = i.Day;
                        string rote = rTmp["D" + nn.ToString()].ToString();//取得tmtable_tmp裡面的班別

                        //1=假日輪班(假日還要輪班，所以不參考行事曆
                        //3=不影響輪班頻率(見紅就放，可是一樣班表跳一格)
                        if (holiList.Where(p => p.H_DATE == i
                            && p.HOLI_CODE == gp.HOLI_CODE).Any()
                            && rotet.INHOLI != "1")//如果有假日
                        {
                            if (rotet.INHOLI == "2") nn--;//如果是選擇2(不跳格，但是目前沒用到

                            var list = holiList.Where(
                            p => p.H_DATE == i
                            && p.HOLI_CODE == gp.HOLI_CODE
                            ).FirstOrDefault();

                            var rOthcode = _HoliCode.Where(h => h.OTHCODE1 == list.OTHCODE
                                );
                            if (rOthcode.Any())
                            {
                                string roteHoli = rOthcode.First().ROTE;// "00";
                                if (roteHoli.Trim().Length > 0)
                                    rote = roteHoli;
                            }
                        }
                        if (rImp != null)//採用匯入
                        {
                            string roteImp = rImp["D" + i.Day.ToString()].ToString();
                            if (roteList.Where(p => p.ROTE1 == roteImp).Any())
                                rote = roteList.Where(p => p.ROTE1 == roteImp).First().ROTE1;
                        }
                        r["D" + i.Day.ToString()] = rote;

                    }// for (DateTime i = dd1; i <= dd2; i = i.AddDays(1))

                }// foreach (var gp in it)//以人
                dt.AddTMTABLERow(r);
            }//else
            ad.Update(tmtt);
            ad1.Update(dt);

            if (AttendanceGenerate)
            {
                AttendanceGenerator ag = new AttendanceGenerator(_EmployeeList, d1, d2);
                ag.KeyMan = this.KeyMan;
                ag.roteList = roteList;
                //ag.TimeTableList=                
                ag.Generate();
            }
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
