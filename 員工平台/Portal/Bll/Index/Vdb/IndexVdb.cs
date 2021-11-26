using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Index.Vdb
{
  public  class IndexVdb
    {
    }

    public class IndexConditions : DataConditions
    { 
    }
    
    public class IndexApiRow : StandardDataBaseApiRow
    {
    }

    public class IndexRow
    {
        public class BillBoard 
        {
            public int idNO { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public DateTime PublishTime { get; set; }
            public string KeyName { get; set; }
        }
        public class Leave 
        {
            public string LeaveName { get; set; }
            public string RemainHour { get; set; }
            public string TotalHour { get; set; }
            public string UseHour { get; set; }
            public DateTime ExpiryDate { get; set; }
        }
        public class Abnormal 
        {
            public string Title { get; set; }
            public DateTime AbnormalDate { get; set; }
            public int AbnormalCount { get; set; }
            public Abnormal()
            {
                AbnormalCount = 0;
            }
        }
        public class AbnormalHost
        {
            public string Title { get; set; }
            public DateTime AbnormalDate { get; set; }
            public int AbnormalTagCount { get; set; }
            public AbnormalHost() 
            {
                AbnormalTagCount = 0;
            }
        }
        public class OtHour
        {
            public string OverTimeTitle { get; set; }
            public string DateRange { get; set; }
            public double OverTimeHours { get; set; }
            public OtHour()
            {
                OverTimeHours = 0;
            }
        }
        public class Upcoming 
        {
            public string UpcomingTitle { get; set; }
            public string Count { get; set; }
        }
        public class WorkTime
        { 
            public string OnTime { get; set; }
            public string OffTime { get; set; }
        }
        /// <summary>
        /// 公佈欄列表
        /// </summary>
        public List<BillBoard> BillBoardList { get; set; }
        /// <summary>
        /// 特休(w)資料
        /// </summary>
        public Leave SpecialLeave { get; set; }
        /// <summary>
        /// 補修(w4)資料
        /// </summary>
        public Leave CompensatoryLeave { get; set; }
        /// <summary>
        /// 今日異常資訊(個人)
        /// </summary>
        public Abnormal TodayAbnormal { get; set; }
        /// <summary>
        /// 昨日異常資訊(個人)
        /// </summary>
        public Abnormal YesterdayAbnormal { get; set; }
        /// <summary>
        /// 今日異常資訊(主管)
        /// </summary>
        public AbnormalHost TodayAbnormalHost { get; set; }
        /// <summary>
        /// 當月個人加班總時數(計薪年月)
        /// </summary>
        public OtHour OtHoursYYMMList { get; set; }
        /// <summary>
        /// 當月個人加班總時數(日期區間)
        /// </summary>
        public OtHour OtHoursDateRangeList { get; set; }
        /// <summary>
        /// 今日上下班時間
        /// </summary>
        public WorkTime TodayWorkTime { get; set; }
        /// <summary>
        /// 班別名稱
        /// </summary>
        public string RoteName { get; set; }
        public IndexRow()
        {
            BillBoardList = new List<BillBoard>();
            SpecialLeave = new Leave();
            CompensatoryLeave = new Leave();
            TodayAbnormal = new Abnormal();
            YesterdayAbnormal = new Abnormal();
            TodayAbnormalHost = new AbnormalHost();
            OtHoursYYMMList = new OtHour();
            OtHoursDateRangeList = new OtHour();
            TodayWorkTime = new WorkTime();
        }
    }
}
