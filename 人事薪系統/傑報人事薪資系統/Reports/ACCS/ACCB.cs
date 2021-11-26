using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JBModule.Data.Linq;


namespace JBHR.Reports.AttForm.ACCS
{

    class ACCB
    {
       
        //抽出
        //Random ran;
        /// <summary>
        /// 轉換ZZ2Z報表的DATATABLE成ACCDtoList
        /// </summary>
        /// <param name="ZZ2ZDT"></param>
        public DataTable GetACCB(DataTable DT, int MINHRS, int MAXHRS, DateTime ADATE, DateTime DDATE)
        {

            //如果資料為零 直接傳回。
            if (DT.Rows.Count != 0)
            {
                ABCI oABC = new NylokABC();

                #region 新邏輯
                //轉換
                List<rq_OTDto> allrq_OTDtoList = Createrq_OTDtoByDataTable_BYDT(DT);
                

                //新加判斷最大時數 //抽換
                Dictionary<string, List<rq_OTDto>> rq_OTDto_dic = oABC.FilterByMaxHrs(allrq_OTDtoList);
                
                //連續加班
                List<rq_OTDto> ACCBDT = Filterzz2zDataTableByWeekNotConOT_New(rq_OTDto_dic["NOT"], ADATE, DDATE);
                #endregion
                ////過濾每周加班時數 超過三小時資料 
                //ACCBDT = Filterzz2zDataTableByWeekOT(ACCBDT);

                //過濾每月最大時數 加班時數不超過最大時數區間得資料 //抽換
                ACCBDT = oABC.Filterzz2zDataTableByMonthOT(ACCBDT);

                //加入合格資料
                ACCBDT.AddRange(rq_OTDto_dic["PASS"]);

                var ACCB_ = ChangeAByB(DT, ACCBDT);

                return ACCB_;
            }
            else
            {
                return DT;
            }
        }
        
        #region 新連續加班邏輯
        //連續請假 新邏輯 
        List<rq_OTDto> Filterzz2zDataTableByWeekNotConOT_New(List<rq_OTDto> ACC,DateTime ADATE, DateTime DDATE) {
            //避免錯誤。
            if (ACC.Count == 0)
            {
                return ACC;
            }
            
            List<rq_OTDto> oACCB = new List<rq_OTDto>();
            
            var MINMON = ACC.Min(t => t.bdate);

            var MAXMON = ACC.Max(t => t.bdate);

            int FirstDay = 1;

            int FinalDay = 0;

            //取得最早的一週開始
            while (Convert.ToInt32(MINMON.DayOfWeek) != FirstDay)
            {
                MINMON = MINMON.AddDays(-1);
            }

            //取得最晚的一週結束
            while (Convert.ToInt32(MAXMON.DayOfWeek) != FinalDay)
            {
                MAXMON = MAXMON.AddDays(1);
            }

            //因為抓週 可能跨月 所以用所有月份來算
            var ACCMonthPerEMPList = Getzz2zListByPerEmp(ACC);

            DateTime AD = MINMON;
            DateTime DD = MAXMON;

            //抓最大週數
            int days = new TimeSpan(DD.Ticks - AD.Ticks).Days;

            foreach (var item in ACCMonthPerEMPList)
            {
                List<DateTime> FilterDate = new List<DateTime>();

                //開始抓取每周
                for (int i = 0; i <= days; i+=7)
                {
                    var itemOFWeek = (from c in item
                                      where
                                      c.bdate.CompareTo(AD.AddDays(i)) >= 0
                                      &&
                                      c.bdate.CompareTo(AD.AddDays(i + 6)) <= 0
                                      select
                                      c).ToList();
                    //如果超過 就抓最後一個假日。
                    if (CheckConOTByPerEMPWeek(itemOFWeek))
                    {
                        FilterDate.Add(AD.AddDays(i + 6));
                    }
                }
                var ACCBList = GetACCBByFilterConHoliOT(item, FilterDate, ADATE, DDATE);

                oACCB.AddRange(ACCBList);
            }
            return oACCB;
        }

        //檢查每個禮拜連續加班
        bool CheckConOTByPerEMPWeek(List<rq_OTDto> rq_OTDtoListOFWeek)
        {

            bool conOT = false;

            int oTCount = 0;

            DateTime ReADATE = DateTime.MinValue;

            bool AleardyOTCount = false;

            int MaxCon = 7;

            foreach (var itemDay in rq_OTDtoListOFWeek)
            {
                //重複加班判斷
                if (!((ReADATE.CompareTo(itemDay.bdate) == 0) && (AleardyOTCount == true)))
                {
                    if (itemDay.ot_hrs > 0)
                    {
                        oTCount++;
                    }

                    //判斷假日加班
                    if (CodeFunction.GetHolidayRoteList().Contains(itemDay.rote))
                    {
                        conOT = true;
                    }
                }
            }
            if (oTCount >= MaxCon)
            {
                conOT = true;
            }

            return conOT;
        }

        //轉換 弱型別 成 類別
        public List<rq_OTDto> Createrq_OTDtoByDataTable_BYDT(DataTable DT)
        {
            ATTEND_REPO oATTEND_REPO = new ATTEND_REPO();

            List<rq_OTDto> rq_OTDtoList = new List<rq_OTDto>();
            foreach (DataRow item in DT.Rows)
            {
                rq_OTDto orq_OTDto = new rq_OTDto();
                orq_OTDto.nobr = (string)item["nobr"];
                orq_OTDto.bdate = (DateTime)item["bdate"];
                orq_OTDto.btime = (string)item["btime"];
                orq_OTDto.etime = (string)item["etime"];
                orq_OTDto.ot_hrs = (decimal)item["ot_hrs"];
                orq_OTDto.tot_hours = (decimal)item["tot_hours"];
                orq_OTDto.maxhrs = Convert.ToDecimal(item["maxhrs"]);
                if ( !Convert.IsDBNull(item["rote"])){
                    orq_OTDto.rote = (string)item["rote"];
                }
                else{
                    orq_OTDto.rote = "";
                }
                //try
                //{
                //    orq_OTDto.rote = (string)item["rote"];
                //}
                //catch (InvalidCastException ice)
                //{

                //    orq_OTDto.rote = "";
                //}
                
                orq_OTDto.defaultdata = true;
                rq_OTDtoList.Add(orq_OTDto);
            }
            
            rq_OTDtoList = rq_OTDtoList.OrderBy(t => t.bdate).ToList();
            return rq_OTDtoList;
        }
        #endregion

        //取得ACCByMonyhPerEMP  抽出
        //public List<List<rq_OTDto>> Getzz2zListByMonth(List<rq_OTDto> ACC)
        //{
        //    List<List<rq_OTDto>> zz2zRowGroupList = new List<List<rq_OTDto>>();
        //    var NOBRList = ACC.Select(t => t.nobr).Distinct().ToList();
        //    //取得資料裡面的最大月份 最小月份
        //    var MINMON = new DateTime(ACC.Min(t => t.bdate).Year, ACC.Min(t => t.bdate).Month, 1);
        //    var MAXMON = new DateTime(ACC.Max(t => t.bdate).Year, ACC.Max(t => t.bdate).Month, 1);
        //    //找出每月
        //    while (MAXMON.CompareTo(MINMON) >= 0)
        //    {
        //        foreach (var item in NOBRList)
        //        {
        //            //取得當月最大日期最小日期
        //            int MINDay = 1;
        //            int MAXDay = DateTime.DaysInMonth(MINMON.Year, MINMON.Month);
        //            DateTime ADATEM = new DateTime(MINMON.Year, MINMON.Month, MINDay);
        //            DateTime DDATEM = new DateTime(MINMON.Year, MINMON.Month, MAXDay);

        //            //取得員工每月的資料
        //            var itemList = (from c in ACC
        //                            where
        //                            c.bdate.CompareTo(ADATEM) >= 0
        //                            &&
        //                            c.bdate.CompareTo(DDATEM) <= 0
        //                            &&
        //                            c.nobr.Equals(item)
        //                            select
        //                            c).ToList();
        //            zz2zRowGroupList.Add(itemList);
        //        }
        //        MINMON = MINMON.AddMonths(1);
        //    }
        //    return zz2zRowGroupList;
        //}

        public List<List<rq_OTDto>> Getzz2zListByPerEmp(List<rq_OTDto> ACC)
        {
            List<List<rq_OTDto>> zz2zRowGroupList = new List<List<rq_OTDto>>();
            var NOBRList = ACC.Select(t => t.nobr).Distinct().ToList();
            foreach (var item in NOBRList)
            {
                //取得員工每月的資料
                var itemList = (from c in ACC
                                where
                                c.nobr.Equals(item)
                                select
                                c).ToList();
                zz2zRowGroupList.Add(itemList);
            }
            return zz2zRowGroupList;
        }

        //製造 ACCB
        List<rq_OTDto> GetACCBByFilterConHoliOT(List<rq_OTDto> zz2zRowListByNobr, List<DateTime> FilterDate, DateTime ADATE, DateTime DDATE)
        {
            //將多餘月份去除。
            
            var Filterzz2zRowDATERange = (from c in zz2zRowListByNobr
                                          where
                                          c.bdate.CompareTo(ADATE) >= 0
                                          &&
                                          c.bdate.CompareTo(DDATE) <= 0
                                          select
                                          c).ToList();

            if (FilterDate.Count != 0)
            {
                List<rq_OTDto> ACCBRow = new List<rq_OTDto>();
                List<DateTime> FilterHOLIDate = new List<DateTime>();
                //找當周最後一個 00班
                foreach (var DateItem in FilterDate)
                {
                    var item = (from c in Filterzz2zRowDATERange
                                where
                                c.bdate.CompareTo(DateItem) <= 0
                                &&
                                c.bdate.CompareTo(DateItem.AddDays(-6)) >= 0
                                &&
                                CodeFunction.GetHolidayRoteList().Contains(c.rote)
                                orderby
                                c.bdate descending
                                select
                                c.bdate).FirstOrDefault();
                    
                    if (item != null)
                    {
                        FilterHOLIDate.Add(item);
                    }
                }
                foreach (var item in Filterzz2zRowDATERange)
                {
                    //要去除的DATE
                    var ImportRowFlag = FilterHOLIDate.Contains(item.bdate.Date);
                    if (!ImportRowFlag)
                    {
                        ACCBRow.Add(item);
                    }
                }
                return ACCBRow;
            }
            else
            {
                return Filterzz2zRowDATERange;
            }
        }

        //取得要去除加班的禮拜
        List<DateTime> GetFilterDateByPerEMP(List<rq_OTDto> item)
        {
            //輪迴終點設定輪迴終點。
            int ConOTDay = 0;

            int OTCount = 0;

            DateTime ReADATE = DateTime.MinValue; ;

            bool AleardyOTCount = false;

            List<DateTime> FilterDate = new List<DateTime>();
            //計算連續加班LOOPDATE
            foreach (var itemDay in item)
            {
                if (!((ReADATE.CompareTo(itemDay.bdate) == 0) && (AleardyOTCount == true)))
                {
                    ReADATE = itemDay.bdate;
                    AleardyOTCount = false;
                    var DayOfWeek = Convert.ToInt32(itemDay.bdate.DayOfWeek.ToString("d"));
                    //判斷輪迴終點為禮拜日
                    if (ConOTDay == DayOfWeek)
                    {
                        //判斷終點 是否有加班。
                        if (itemDay.ot_hrs > 0)
                        {
                            OTCount++;
                            AleardyOTCount = true;
                        }
                        //判斷一周連續加班
                        if (OTCount >= 7)
                        {
                            FilterDate.Add(itemDay.bdate);
                        }
                        //將加班旗標歸零。
                        OTCount = 0;
                    }
                    else
                    {
                        //有加班
                        if (itemDay.ot_hrs > 0)
                        {
                            OTCount++;
                            AleardyOTCount = true;
                        }
                    }
                }
            }
            return FilterDate;
        }

        //每周非假日 加班時數不超過設定時數的資料
        public List<rq_OTDto> Filterzz2zDataTableByWeekOT(List<rq_OTDto> ACC)
        {
            //避免錯誤
            if (ACC.Count == 0)
            {
                return ACC;
            }

            List<rq_OTDto> ACCB = new List<rq_OTDto>();
            decimal OTHRS = 3;

            foreach (rq_OTDto item in ACC)
            {
                var Holi = CodeFunction.GetHolidayRoteList().Contains(item.rote);
                if (Holi)
	            {
                    ACCB.Add(item);
                }
                else
                {
                    if (item.ot_hrs <= OTHRS)
                    {
                        ACCB.Add(item);
                    }
                    //else
                    //{
                    //    ACCB.Add(item);
                    //}
                }
            }
            return ACCB;
        }

        //每月最大時數 加班時數不可以超過隨機最大加班  抽出
        //public List<rq_OTDto> Filterzz2zDataTableByMonthOT(List<rq_OTDto> ACC, int MINHRS, int MAXHRS)
        //{
        //    //避免錯誤回傳
        //    if (ACC.Count == 0)
        //    {
        //        return ACC;
        //    }
        //    List<rq_OTDto> ACCB = new List<rq_OTDto>();
        //    int MINHRS_ = MINHRS;
        //    int MAXHRS_ = MAXHRS;

        //    var ACCMonth = Getzz2zListByMonth(ACC);

        //    //抽換取得每月資料。
        //    foreach (var item in ACCMonth)
        //    {
        //        int MINDay = 1;
        //        var MINMON = new DateTime(item.FirstOrDefault().bdate.Year, item.FirstOrDefault().bdate.Month,MINDay);
        //        DateTime ADATEM = new DateTime(MINMON.Year, MINMON.Month, MINDay);
        //        string intNOBR = ConvertNOBR(item.FirstOrDefault().nobr).ToString();
        //        decimal SEEDDec = Convert.ToDecimal(intNOBR + (ADATEM.Year + ADATEM.Month + ADATEM.Day)) % 65534;
        //        int SEED = Convert.ToInt32(SEEDDec);
        //        ran = new Random(SEED);
        //        decimal RanHrs = ran.Next(MINHRS_, MAXHRS_);

        //        //修改最大時數判斷
        //        var ACCBList = FilterByMonthPerPerson(item, RanHrs, RanHrs);

        //        var maxHrs = ACCBList.Sum(t => t.ot_hrs);

        //        //if (maxHrs > RanHrs)
        //        //{
        //        //    var Why = "WWHHYY";
        //        //}

        //        var maxHRS = ACCBList.Sum(t => t.ot_hrs);

        //        if (maxHRS > RanHrs)
        //        {
        //            var Why = "No Why";
        //        }

        //        ACCB.AddRange(ACCBList);
        //    }
        //    return ACCB;
        //}

        //抓取每月員工資料 //更新  抽出
        //public List<rq_OTDto> FilterByMonthPerPerson(List<rq_OTDto> zz2zRowNobrMonth, decimal MAXHrs, decimal MAXHrs_Rel)
        //{
        //    decimal TotalOTHRS = 0;

        //    //計算每月員工加班時數最大 是否超過設定時數。
        //    foreach (var item in zz2zRowNobrMonth)
        //    {
        //        TotalOTHRS += item.ot_hrs;
        //    }


        //    //如果低於設定時數直接Return
        //    if (TotalOTHRS <= MAXHrs_Rel)
        //    {
        //        return zz2zRowNobrMonth;
        //    }
        //    else
        //    {
        //        List<rq_OTDto> zz2zRowList = new List<rq_OTDto>();

        //        HashSet<int> Indexs = new HashSet<int>();

        //        int MAXIndex = zz2zRowNobrMonth.Count ;
        //        int MINIndex = 0;
        //        decimal totalOTHrs = 0;
        //        int Index = ran.Next(MINIndex, MAXIndex);

        //        //LOOP當月資料 不重複
        //        for (int i = MINIndex; i <= MAXIndex; i++)
        //        {
        //            //跑完資料
        //            if (Indexs.Count == MAXIndex)
        //            {
        //                return zz2zRowList;
        //            }
        //            while (Indexs.Contains(Index))
        //            {
        //                Index = ran.Next(MINIndex, MAXIndex);
        //            }

        //            //取得隨機資料
        //            rq_OTDto zz2zRow = zz2zRowNobrMonth[Convert.ToInt32(Index)];
                    
        //            //檢查時數是否超過最大時數。
        //            if ((totalOTHrs + zz2zRow.ot_hrs) <= MAXHrs)
        //            {
        //                totalOTHrs += zz2zRow.ot_hrs;
        //                Indexs.Add(Index);
        //                zz2zRowList.Add(zz2zRow);
        //            }
        //            else
        //            {
        //                Indexs.Add(Index);
        //                //return zz2zRowList;
        //            }
        //        }
        //        return zz2zRowList;
        //    }
        //}

        /// <summary>
        /// 判斷假日用
        /// </summary>
        /// <param name="ACCA"></param>
        /// <returns></returns>
        public List<ATTEND> GetATTENDListByACCA(attenddata.zz2zDataTable ACC)
        { 
            ATTEND_REPO ATTEND_REPO = new ACCS.ATTEND_REPO();
            var MAXDATE = ACC.Max(t => t.adate);
            var MINDATE = ACC.Min(t => t.adate);
            var NOBRList = ACC.Select(t => t.nobr).Distinct().ToList();
        return ATTEND_REPO.GetByNOBRListDATERange(NOBRList, MINDATE, MAXDATE);
        }


        //抽出
        //int ConvertNOBR(string NOBR) {
        //    int length = NOBR.Length;
        //    string intNOBR = "";
        //    for (int i = 0; i < length; i++)
        //    {
        //        var str = NOBR.Substring(i, 1);
        //        int num = 0;
        //        try
        //        {
        //            num = Convert.ToInt32(str);
        //        }
        //        catch (FormatException fe)
        //        {
        //            num = Convert.ToInt32(Convert.ToChar(str));
        //        }
        //        intNOBR += num.ToString();
        //    }
        //    return Convert.ToInt32(intNOBR);
        //}

        DataTable ChangeAByB(DataTable ACCA, List<rq_OTDto> ACCB)
        {
            //去除非規則加班資料
            foreach (DataRow item in ACCA.Rows)
            {
                var itemB = (from c in ACCB
                             where
                             c.nobr.Equals((string)item["nobr"])
                             &&
                             c.bdate.CompareTo((DateTime)item["bdate"]) == 0
                             &&
                             c.btime.Equals((string)item["btime"])
                             &&
                             c.defaultdata == true
                             select
                             c);
                if (!itemB.Any())
                {
                    item["ot_hrs"] = 0;
                    item["etime"] = "";
                }
            }
            return ACCA;
        }
        //抽出
        //public Dictionary<string, List<rq_OTDto>> FilterByMaxHrs(List<rq_OTDto> allrq_OTDtoList,decimal MaxHrs)
        //{
        //    List<rq_OTDto> OTDtoList_Pass = new List<rq_OTDto>();

        //    List<rq_OTDto> OTDtoList_Not = new List<rq_OTDto>();

        //    DateTime MAXDATE = allrq_OTDtoList.Max(t=>t.bdate);

        //    DateTime MINDATE = allrq_OTDtoList.Min(t=>t.bdate);

        //    List<DateTime> dList =  CreateDateList(MAXDATE,MINDATE);

        //    Dictionary<string, List<rq_OTDto>> OTDtoList_Dic = new Dictionary<string, List<rq_OTDto>>();

        //    //groupData
        //    var groupItem = from c in allrq_OTDtoList
        //                    group c by c.nobr
        //                    ;


        //    foreach (var dItem in dList)
        //    {
        //        DateTime MAXDATEsql = new DateTime(dItem.Year, dItem.Month, DateTime.DaysInMonth(dItem.Year, dItem.Month));

        //        DateTime MINDATEsql = dItem;

        //        foreach (var item in groupItem)
        //        {
        //            var itemByDateRange = (from c in item
        //                                   where
        //                                   c.bdate.CompareTo(MAXDATEsql) <= 0
        //                                   &&
        //                                   c.bdate.CompareTo(MINDATEsql) >= 0
        //                                   select
        //                                   c).ToList();



        //            if (CheckDataMaxHrs(itemByDateRange, MaxHrs))
        //            {
        //                OTDtoList_Pass.AddRange(itemByDateRange);
        //            }
        //            else
        //            {
        //                OTDtoList_Not.AddRange(itemByDateRange);
        //            }
        //        }
        //    }
        //    OTDtoList_Dic.Add("PASS",OTDtoList_Pass);
        //    OTDtoList_Dic.Add("NOT", OTDtoList_Not);
        //    return OTDtoList_Dic;
        //}
        //抽出
        //public List<DateTime> CreateDateList(DateTime MAXDATE,DateTime MINDATE) {

        //    List<DateTime> dList = new List<DateTime>();

        //    DateTime MAXDATE_ = new DateTime(MAXDATE.Year, MAXDATE.Month,1);

        //    DateTime MINDATE_ = new DateTime(MINDATE.Year, MINDATE.Month,1);

        //    while (MAXDATE_.CompareTo(MINDATE_)>=0)
        //    {
        //        dList.Add(MINDATE_);
        //        MINDATE_ = MINDATE_.AddMonths(1);
        //    }
        //    return dList;
        //}
        //抽出
        //public bool CheckDataMaxHrs(List<rq_OTDto> rq_OTDtoList , decimal MaxHrs)
        //{
        //    bool flag = false;

        //    var totalHrs = rq_OTDtoList.Sum(t => t.ot_hrs);

        //    if (MaxHrs >= totalHrs)
        //    {
        //        flag = true;
        //    }
        //    return flag;
        //}
    }
}
