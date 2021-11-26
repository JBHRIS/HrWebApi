using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBHR.Reports.AttForm.ACCS;

namespace JBHR.Reports.AttForm.ACCS
{
    class NylokABC : ABCI
    {
        Random ran;

        public Dictionary<string, List<Reports.AttForm.ACCS.rq_OTDto>> FilterByMaxHrs(List<Reports.AttForm.ACCS.rq_OTDto> allrq_OTDtoList, decimal MaxHrs)
        {
            List<rq_OTDto> OTDtoList_Pass = new List<rq_OTDto>();

            List<rq_OTDto> OTDtoList_Not = new List<rq_OTDto>();

            DateTime MAXDATE = allrq_OTDtoList.Max(t => t.bdate);

            DateTime MINDATE = allrq_OTDtoList.Min(t => t.bdate);

            List<DateTime> dList = CreateDateList(MAXDATE, MINDATE);

            Dictionary<string, List<rq_OTDto>> OTDtoList_Dic = new Dictionary<string, List<rq_OTDto>>();

            //groupData
            var groupItem = from c in allrq_OTDtoList
                            group c by c.nobr
                            ;


            foreach (var dItem in dList)
            {
                DateTime MAXDATEsql = new DateTime(dItem.Year, dItem.Month, DateTime.DaysInMonth(dItem.Year, dItem.Month));

                DateTime MINDATEsql = dItem;

                foreach (var item in groupItem)
                {
                    var itemByDateRange = (from c in item
                                           where
                                           c.bdate.CompareTo(MAXDATEsql) <= 0
                                           &&
                                           c.bdate.CompareTo(MINDATEsql) >= 0
                                           select
                                           c).ToList();



                    if (CheckDataMaxHrs(itemByDateRange, MaxHrs))
                    {
                        OTDtoList_Pass.AddRange(itemByDateRange);
                    }
                    else
                    {
                        OTDtoList_Not.AddRange(itemByDateRange);
                    }
                }
            }
            OTDtoList_Dic.Add("PASS", OTDtoList_Pass);
            OTDtoList_Dic.Add("NOT", OTDtoList_Not);
            return OTDtoList_Dic;
        }

        public Dictionary<string, List<Reports.AttForm.ACCS.rq_OTDto>> FilterByMaxHrs(List<Reports.AttForm.ACCS.rq_OTDto> allrq_OTDtoList)
        {
            List<rq_OTDto> OTDtoList_Pass = new List<rq_OTDto>();

            List<rq_OTDto> OTDtoList_Not = new List<rq_OTDto>();

            DateTime MAXDATE = allrq_OTDtoList.Max(t => t.bdate);

            DateTime MINDATE = allrq_OTDtoList.Min(t => t.bdate);

            List<DateTime> dList = CreateDateList(MAXDATE, MINDATE);

            Dictionary<string, List<rq_OTDto>> OTDtoList_Dic = new Dictionary<string, List<rq_OTDto>>();

            //groupData
            var groupItem = from c in allrq_OTDtoList
                            group c by c.nobr
                            ;


            foreach (var dItem in dList)
            {
                //DateTime MAXDATEsql = new DateTime(dItem.Year, dItem.Month, DateTime.DaysInMonth(dItem.Year, dItem.Month));

                //DateTime MINDATEsql = dItem;

                DateTime MAXDATEsql = MAXDATE;

                DateTime MINDATEsql = MINDATE;

                foreach (var item in groupItem)
                {
                    var itemByDateRange = (from c in item
                                           where
                                           c.bdate.CompareTo(MAXDATEsql) <= 0
                                           &&
                                           c.bdate.CompareTo(MINDATEsql) >= 0
                                           select
                                           c).ToList();
                    //forNylok
                    var MaxHrs = GetDataMaxHrs(itemByDateRange);

                    //forNylok 
                    if (CheckDataMaxHrs(itemByDateRange, MaxHrs))
                    {
                        OTDtoList_Pass.AddRange(itemByDateRange);
                    }
                    else
                    {
                        OTDtoList_Not.AddRange(itemByDateRange);
                    }
                }
            }
            OTDtoList_Dic.Add("PASS", OTDtoList_Pass);
            OTDtoList_Dic.Add("NOT", OTDtoList_Not);
            return OTDtoList_Dic;
        }

        public List<Reports.AttForm.ACCS.rq_OTDto> Filterzz2zDataTableByMonthOT(List<Reports.AttForm.ACCS.rq_OTDto> ACC, int MINHRS, int MAXHRS)
        {
            //避免錯誤回傳
            if (ACC.Count == 0)
            {
                return ACC;
            }
            List<rq_OTDto> ACCB = new List<rq_OTDto>();
            int MINHRS_ = MINHRS;
            int MAXHRS_ = MAXHRS;

            var ACCMonth = Getzz2zListByMonth(ACC);

            //抽換取得每月資料。
            foreach (var item in ACCMonth)
            {
                int MINDay = 1;
                var MINMON = new DateTime(item.FirstOrDefault().bdate.Year, item.FirstOrDefault().bdate.Month, MINDay);
                DateTime ADATEM = new DateTime(MINMON.Year, MINMON.Month, MINDay);
                string intNOBR = ConvertNOBR(item.FirstOrDefault().nobr).ToString();
                decimal SEEDDec = Convert.ToDecimal(intNOBR + (ADATEM.Year + ADATEM.Month + ADATEM.Day)) % 65534;
                int SEED = Convert.ToInt32(SEEDDec);
                ran = new Random(SEED);
                decimal RanHrs = ran.Next(MINHRS_, MAXHRS_);

                //修改最大時數判斷
                var ACCBList = FilterByMonthPerPerson(item, RanHrs, RanHrs);

                var maxHrs = ACCBList.Sum(t => t.ot_hrs);

                //if (maxHrs > RanHrs)
                //{
                //    var Why = "WWHHYY";
                //}

                var maxHRS = ACCBList.Sum(t => t.ot_hrs);

                if (maxHRS > RanHrs)
                {
                    var Why = "No Why";
                }

                ACCB.AddRange(ACCBList);
            }
            return ACCB;
        }

        public List<Reports.AttForm.ACCS.rq_OTDto> Filterzz2zDataTableByMonthOT(List<Reports.AttForm.ACCS.rq_OTDto> ACC)
        {
            //避免錯誤回傳
            if (ACC.Count == 0)
            {
                return ACC;
            }
            List<rq_OTDto> ACCB = new List<rq_OTDto>();
            int MINHRS_ ;
            int MAXHRS_;

            var ACCMonth = Getzz2zListByMonth(ACC);

            //抽換取得每月資料。
            foreach (var item in ACCMonth)
            {
                int MINDay = 1;
                var MINMON = new DateTime(item.FirstOrDefault().bdate.Year, item.FirstOrDefault().bdate.Month, MINDay);
                DateTime ADATEM = new DateTime(MINMON.Year, MINMON.Month, MINDay);
                string intNOBR = ConvertNOBR(item.FirstOrDefault().nobr).ToString();
                decimal SEEDDec = Convert.ToDecimal(intNOBR + (ADATEM.Year + ADATEM.Month + ADATEM.Day)) % 65534;
                int SEED = Convert.ToInt32(SEEDDec);
                ran = new Random(SEED);

                //ForNylok
                MAXHRS_ = Convert.ToInt32(GetDataMaxHrs(item)) ;
                MINHRS_ = Convert.ToInt32(GetDataMaxHrs(item)) ;

                decimal RanHrs = ran.Next(MINHRS_, MAXHRS_);

                //修改最大時數判斷  修改Fornylok
                var ACCBList = FilterByMonthPerPerson(item, RanHrs, RanHrs);

                var maxHrs = ACCBList.Sum(t => t.ot_hrs);

                var maxHRS = ACCBList.Sum(t => t.ot_hrs);

                ACCB.AddRange(ACCBList);
            }
            return ACCB;
        }

        //取得ACCByMonyhPerEMP  抽出
        public List<List<rq_OTDto>> Getzz2zListByMonth(List<rq_OTDto> ACC)
        {
            List<List<rq_OTDto>> zz2zRowGroupList = new List<List<rq_OTDto>>();
            var NOBRList = ACC.Select(t => t.nobr).Distinct().ToList();
            //取得資料裡面的最大月份 最小月份
            var MINMON = new DateTime(ACC.Min(t => t.bdate).Year, ACC.Min(t => t.bdate).Month, 1);
            var MAXMON = new DateTime(ACC.Max(t => t.bdate).Year, ACC.Max(t => t.bdate).Month, 1);
            //找出每月
            while (MAXMON.CompareTo(MINMON) >= 0)
            {
                foreach (var item in NOBRList)
                {
                    //取得當月最大日期最小日期
                    int MINDay = 1;
                    int MAXDay = DateTime.DaysInMonth(MINMON.Year, MINMON.Month);
                    DateTime ADATEM = new DateTime(MINMON.Year, MINMON.Month, MINDay);
                    DateTime DDATEM = new DateTime(MINMON.Year, MINMON.Month, MAXDay);

                    //取得員工每月的資料
                    var itemList = (from c in ACC
                                    where
                                    c.bdate.CompareTo(ADATEM) >= 0
                                    &&
                                    c.bdate.CompareTo(DDATEM) <= 0
                                    &&
                                    c.nobr.Equals(item)
                                    select
                                    c).ToList();
                    zz2zRowGroupList.Add(itemList);
                }
                MINMON = MINMON.AddMonths(1);
            }
            return zz2zRowGroupList;
        }

        int ConvertNOBR(string NOBR)
        {
            int length = NOBR.Length;
            string intNOBR = "";
            for (int i = 0; i < length; i++)
            {
                var str = NOBR.Substring(i, 1);
                int num = 0;
                try
                {
                    num = Convert.ToInt32(str);
                }
                catch (FormatException fe)
                {
                    num = Convert.ToInt32(Convert.ToChar(str));
                }
                intNOBR += num.ToString();
            }
            return Convert.ToInt32(intNOBR);
        }

        //抓取每月員工資料 //更新
        public List<rq_OTDto> FilterByMonthPerPerson(List<rq_OTDto> zz2zRowNobrMonth, decimal MAXHrs, decimal MAXHrs_Rel)
        {
            decimal TotalOTHRS = 0;

            //計算每月員工加班時數最大 是否超過設定時數。
            foreach (var item in zz2zRowNobrMonth)
            {
                TotalOTHRS += item.ot_hrs;
            }


            //如果低於設定時數直接Return
            if (TotalOTHRS <= MAXHrs_Rel)
            {
                return zz2zRowNobrMonth;
            }
            else
            {
                List<rq_OTDto> zz2zRowList = new List<rq_OTDto>();

                HashSet<int> Indexs = new HashSet<int>();

                int MAXIndex = zz2zRowNobrMonth.Count;
                int MINIndex = 0;
                decimal totalOTHrs = 0;
                int Index = ran.Next(MINIndex, MAXIndex);

                //LOOP當月資料 不重複
                for (int i = MINIndex; i <= MAXIndex; i++)
                {
                    //跑完資料
                    if (Indexs.Count == MAXIndex)
                    {
                        return zz2zRowList;
                    }
                    while (Indexs.Contains(Index))
                    {
                        Index = ran.Next(MINIndex, MAXIndex);
                    }

                    //取得隨機資料
                    rq_OTDto zz2zRow = zz2zRowNobrMonth[Convert.ToInt32(Index)];

                    //檢查時數是否超過最大時數。
                    if ((totalOTHrs + zz2zRow.ot_hrs) <= MAXHrs)
                    {
                        totalOTHrs += zz2zRow.ot_hrs;
                        Indexs.Add(Index);
                        zz2zRowList.Add(zz2zRow);
                    }
                    else
                    {
                        Indexs.Add(Index);
                        //return zz2zRowList;
                    }
                }
                return zz2zRowList;
            }
        }

        public List<DateTime> CreateDateList(DateTime MAXDATE, DateTime MINDATE)
        {

            List<DateTime> dList = new List<DateTime>();

            DateTime MAXDATE_ = new DateTime(MAXDATE.Year, MAXDATE.Month, 1);

            DateTime MINDATE_ = new DateTime(MINDATE.Year, MINDATE.Month, 1);

            while (MAXDATE_.CompareTo(MINDATE_) >= 0)
            {
                dList.Add(MINDATE_);
                MINDATE_ = MINDATE_.AddMonths(1);
            }
            return dList;
        }

        public bool CheckDataMaxHrs(List<rq_OTDto> rq_OTDtoList, decimal MaxHrs)
        {
            bool flag = false;

            var totalHrs = rq_OTDtoList.Sum(t => t.ot_hrs);

            if (MaxHrs >= totalHrs)
            {
                flag = true;
            }
            return flag;
        }

        public decimal GetDataMaxHrs(List<rq_OTDto> rq_OTDtoList)
        {
            decimal maxHrs = 0;
            if (!(rq_OTDtoList.Count == 0))
            {
                maxHrs = rq_OTDtoList[0].maxhrs;
            }
            return maxHrs;
        }

    }
}
