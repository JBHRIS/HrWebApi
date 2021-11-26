using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BL;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;

public partial class Attendance_RoteList : JBUserControl, ICU
{
    const int MINUTES_OF_DAY = 1440;
    private HRDsTableAdapters.CARDTableAdapter card_adapter = new HRDsTableAdapters.CARDTableAdapter();
    private HRDsTableAdapters.MealMoneyTableAdapter mealMoney_adapter = new HRDsTableAdapters.MealMoneyTableAdapter();
    private HRDsTableAdapters.ATTCARDTableAdapter attCard_adapter = new HRDsTableAdapters.ATTCARDTableAdapter();
    private HRDsTableAdapters.ATTENDTableAdapter attend_adapter = new HRDsTableAdapters.ATTENDTableAdapter();
    private ABSTableAdapters.ABSTableAdapter absAdapter = new ABSTableAdapters.ABSTableAdapter();
    private ABSTableAdapters.HCODETableAdapter hcodeAdapter = new ABSTableAdapters.HCODETableAdapter();
    private ROTE_REPO roteRepo = new ROTE_REPO();
    private CARDLOSD_REPO cardLostRepo = new CARDLOSD_REPO();
    private List<BL.ABS> absList = new List<BL.ABS>();
    private HRDs.ATTENDDataTable attendDT = null;
    private ABS.HCODEDataTable hcodeDT = null;
    private string selectedRote = "";
    private List<EmpAbs1List> Abs1List = null;

    private HRDsTableAdapters.BASETTSTableAdapter basetts_adapter = new HRDsTableAdapters.BASETTSTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1");
            ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());
        }

        if (Request["print"] != null)
        {
            btnPrint.OnClientClick = "window.print();";
        }
        else
        {
            btnPrint.OnClientClick = "window.open('" + ResolveClientUrl("AttendSelectPrn.aspx") + "?print=true&NOPIC=Y', '_blank');";
        }


    }
    #region ICU 成員

    public void bindGrid()
    {

        GetData();
    }

    #endregion

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session["rv_attend"] != null)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = Session["rv_attend"];
            GridView2.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }



    int t1 = 0;
    int t2 = 0;
    int t3 = 0;

    /// <summary>
    /// bind data
    /// </summary>
    void GetData()
    {

        //((Label)AccountPicture1_1.FindControl("lb_nobr")).Text = lb_nobr.Text;
        //((ICU)AccountPicture1_1).bindGrid();
        if (adate.SelectedDate == null)
        {
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1");
            ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());

        }
        HRDsTableAdapters.rv_attendTableAdapter rv_attend = new HRDsTableAdapters.rv_attendTableAdapter();
        HRDs.rv_attendDataTable rv_attendDs = new HRDs.rv_attendDataTable();
        HRDsTableAdapters.rv_cardTableAdapter rv_card = new HRDsTableAdapters.rv_cardTableAdapter();
        HRDs.rv_cardDataTable rv_cardDs = new HRDs.rv_cardDataTable();
        rv_attendDs.Merge(rv_attend.GetData_rv_attend(adate.SelectedDate.Value, ddate.SelectedDate.Value, lb_nobr.Text, ""));
        rv_cardDs.Merge(rv_card.GetData_rv_card(adate.SelectedDate.Value, ddate.SelectedDate.Value, lb_nobr.Text, ""));

        //計算當月可休假日，會過濾掉員工到職當月，比如說 2/14到職， 2/1~2/13都不算休假日
        //lb_Holi.Text = countHoli().ToString();
        //lb_Holi.Text = new HIDsTableAdapters.QueriesTableAdapter().ScalarHoliDayQuery(Convert.ToDecimal(adate.SelectedDate.Value.Year),Convert.ToDecimal(adate.SelectedDate.Value.Month)).ToString();
        
        //lb_attHoli.Text = new HIDsTableAdapters.QueriesTableAdapter().ScalarAttHoliDayQuery(lb_nobr.Text, Convert.ToDecimal(adate.SelectedDate.Value.Year),
        //    Convert.ToDecimal(adate.SelectedDate.Value.Month)).ToString();
        //

        Session["rv_card"] = rv_cardDs;
        Session["rv_attend"] = rv_attendDs;
        GridView2.DataSource = rv_attendDs;
        GridView2.DataBind();
        t1 = 0;
        t2 = 0;
        t3 = 0;
        Calendar1.DataBind();

        //setErrorCardCount();
        //Label3.Text = t1.ToString();
        //Label4.Text = t2.ToString();
        //Label5.Text = t3.ToString();

        //A1.Text = "0";
        //A2.Text = "0";
        //A3.Text = "0";

        //   4次-0.5天
        //                            6次-1天
        //                          8次-1.5天
        //                       10次-2天
        //                     12次-2.5天
        //                   14次-3天
        //                 16次-3.5天
        //if (t1 >= 4 && t1 <= 5)
        //{
        //    A1.Text = "0.5";
        //}
        //else if (t1 >= 6 && t1 <= 7)
        //{
        //    A1.Text = "1";
        //}
        //else if (t1 >= 8 && t1 <= 9)
        //{
        //    A1.Text = "1.5";
        //}
        //else if (t1 >= 10 && t1 <= 11)
        //{
        //    A1.Text = "2";
        //}
        //else if (t1 >= 12 && t1 <= 13)
        //{
        //    A1.Text = "2.5";

        //}
        //else if (t1 >= 14 && t1 <= 15)
        //{
        //    A1.Text = "3";
        //}
        //else if (t1 >= 16)
        //{
        //    A1.Text = "3.5";
        //}


        //decimal _t3 = Convert.ToDecimal(t3) / Convert.ToDecimal(2);
        //A3.Text = _t3.ToString();

        //餐費的顯示
        //decimal intTotMealMoney = 0;
        //intTotMealMoney = countMealMoney(lb_nobr.Text, adate.SelectedDate.Value, ddate.SelectedDate.Value);
        //lb_TotMealMoney.Text = intTotMealMoney.ToString("N0");        

        //lb_ot.Text = countOTByRote(lb_nobr.Text, adate.SelectedDate.Value, ddate.SelectedDate.Value).ToString();
        //lbl_remainDays.Text = countRemainDays().ToString("F1");



    }

    ///
    ///計算假日
    ///
    private  int countHoli(){
        int result = 0;

        HRDs.BASETTSDataTable basetts_dt = basetts_adapter.GetDataByNobrTtscodeBTWDate(lb_nobr.Text, "1", adate.SelectedDate.Value, ddate.SelectedDate.Value);


        if (basetts_dt.Count > 0)
        {
            result = new HIDsTableAdapters.QueriesTableAdapter().ScalarHoliDayBTWDate(basetts_dt[0].ADATE,ddate.SelectedDate.Value).Value;
        }
        else
        {
            result=new HIDsTableAdapters.QueriesTableAdapter().ScalarHoliDayQuery(Convert.ToDecimal(adate.SelectedDate.Value.Year),Convert.ToDecimal(adate.SelectedDate.Value.Month)).Value;
        }

        return result;
    }


    //計算剩餘天數
    //private decimal countRemainDays()
    //{
    //    decimal result = 0;

    //    result = Convert.ToDecimal(lb_Holi.Text);
    //    result = result - Convert.ToDecimal(lb_attHoli.Text) - Convert.ToDecimal(A1.Text) - Convert.ToDecimal(A2.Text) - Convert.ToDecimal(A3.Text) + Convert.ToDecimal(lb_ot.Text);

    //    return result;
    //}



    /// <summary>
    /// 計算假日加班，以天計算，所以小時除以4，0.75以0.5計算
    /// </summary>
    /// <param name="nobr"></param>
    /// <param name="adate"></param>
    /// <param name="ddate"></param>
    /// <returns></returns>
    private double countOTByRote(string nobr, DateTime adate, DateTime ddate)
    {
        double doubleOTHrs = 0;
        int intOTHrs = 0;
        Int32 intOTMins = 0;

        HRDs.ATTENDDataTable attend_dt = attend_adapter.GetDataByNobrRoleDate(nobr, "00", adate, ddate);

        foreach (HRDs.ATTENDRow row in attend_dt)
        {
            HRDs.CARDDataTable card_dt = card_adapter.GetDataByNobrOneDay(nobr, row.ADATE, "0400", row.ADATE.AddDays(1), "0400");


            //有兩筆以上打卡紀錄就計算
            if (card_dt.Rows.Count > 1)
            {
                int length = card_dt.Rows.Count - 1;
                DateTime tmp_datetime = card_dt[0].ADATE;
                DateTime datetime1 = new DateTime(tmp_datetime.Year, tmp_datetime.Month, tmp_datetime.Day, Convert.ToInt16(card_dt[0].ONTIME.Substring(0, 2)), Convert.ToInt16(card_dt[0].ONTIME.Substring(2, 2)), 0);

                tmp_datetime = card_dt[length].ADATE;
                DateTime datetime2 = new DateTime(tmp_datetime.Year, tmp_datetime.Month, tmp_datetime.Day, Convert.ToInt16(card_dt[length].ONTIME.Substring(0, 2)), Convert.ToInt16(card_dt[length].ONTIME.Substring(2, 2)), 0);

                TimeSpan ts = new TimeSpan(datetime2.Ticks - datetime1.Ticks);

                Int32 diffHours = Convert.ToInt32(ts.Hours);

                //超過8小時，就以8小時算，不得超過8小時
                if (diffHours >= 1)
                {
                    if (diffHours >= 8)
                    {
                        intOTMins = intOTMins + (8 * 60);
                    }
                    else
                    {
                        intOTMins = intOTMins + Convert.ToInt32(ts.Minutes) + (diffHours * 60);
                    }
                }
            }
        }


        doubleOTHrs = (Double)intOTMins / 60;
        doubleOTHrs = doubleOTHrs / 8;

        intOTHrs = (int)Math.Floor(doubleOTHrs);
        doubleOTHrs = doubleOTHrs - intOTHrs;

        if (doubleOTHrs > 0.5)
            doubleOTHrs = 0.5;

        if (doubleOTHrs < 0.5)
            doubleOTHrs = 0;

        doubleOTHrs = doubleOTHrs + intOTHrs;

        return doubleOTHrs;
    }
        ///如果可以，應該直接抓attend的 att_hrs欄位，不過刷卡轉出勤沒轉這部分
        /*
        double doubleOTHrs = 0;
        int intOTHrs = 0;

        HRDsTableAdapters.ATTENDTableAdapter adapter = new HRDsTableAdapters.ATTENDTableAdapter();
        HRDs.ATTENDDataTable dt = adapter.GetDataByNobrRoleDate(nobr, "00", adate, ddate);

        foreach (HRDs.ATTENDRow row in dt)
        {
            doubleOTHrs = doubleOTHrs + Convert.ToDouble(row.ATT_HRS);
        }

        doubleOTHrs = doubleOTHrs/8;
        intOTHrs = Convert.ToInt32(doubleOTHrs - 0.5);
        doubleOTHrs = doubleOTHrs - intOTHrs;

        if (doubleOTHrs > 0.5)
             doubleOTHrs = 0.5;

        if (doubleOTHrs < 0.5)
            doubleOTHrs = 0;

        doubleOTHrs = doubleOTHrs + intOTHrs;

        return doubleOTHrs;
         */ 




    /// <summary>
    /// 計算餐費，早上1100以前有打卡資料，算餐費100元，以24小時分鐘計算，小於等於 660分鐘
    ///           晚上2000以後有打卡資料，算餐費100元，以24小時分鐘計算，大於等於 1200分鐘
    ///           2011/01/24 kukoc
    /// </summary>
    /// <param name="nobr"></param>
    /// <param name="adate"></param>
    /// <param name="ddate"></param>
    private decimal countMealMoney(string nobr, DateTime adate, DateTime ddate)
    {
        decimal intTotMealMoney = 0;        
        HRDs.MealMoneyDataTable dt = mealMoney_adapter.GetMealMoneyByNobr(nobr, adate, ddate);

        if (dt.Rows.Count > 0)
        {
            return dt[0].tot_meal_money;
        }
        else
            return intTotMealMoney;
        /*
        
           string lunchTime = "1100";
           string dinnerTime ="2000";

           int intTotMealMoney = 0;
           HRDsTableAdapters.CARD_meal_moneyTableAdapter adapter = new HRDsTableAdapters.CARD_meal_moneyTableAdapter();

           HRDs.CARD_meal_moneyDataTable DT = adapter.GetDataByLunchMealMoney(adate, ddate, lunchTime, nobr);
           DT.Merge(adapter.GetDataByDinnerMealMoney(adate, ddate, dinnerTime, nobr));

           intTotMealMoney = DT.Rows.Count * 100;
            return intTotMealMoney;
         * 
         */

    }

    void setErrorCardCount()
    {
        
        RoteExDsTableAdapters.AttendLosTableAdapter attendLosAdapter = new RoteExDsTableAdapters.AttendLosTableAdapter();
        RoteExDs.AttendLosDataTable attendLosDT = attendLosAdapter.GetAttendLosByNobrDate(lb_nobr.Text, adate.SelectedDate.Value, ddate.SelectedDate.Value);
        RoteExDsTableAdapters.ATTENDExtTableAdapter attendExtAdapter = new RoteExDsTableAdapters.ATTENDExtTableAdapter();
        RoteExDs.ATTENDExtDataTable attendExtDT = attendExtAdapter.GetAttendLate_MinsByNobrDate(lb_nobr.Text, adate.SelectedDate.Value, ddate.SelectedDate.Value);
        RoteExDs.ATTENDExtDataTable attendExtDT2 = attendExtAdapter.GetAttendE_MinsByNobrDate(lb_nobr.Text, adate.SelectedDate.Value, ddate.SelectedDate.Value);


        //計算扣全勤的忘刷卡
        t3 = attendLosDT.Rows.Count;
        t1 = attendExtDT.Rows.Count;
        t2 = attendExtDT2.Rows.Count;

        /*
        DateTime _adate = adate.SelectedDate.Value;
        for (int i = 1; i <= ddate.SelectedDate.Value.Day; i++)
        {
            HRDs.rv_attendDataTable bdt = (HRDs.rv_attendDataTable)Session["rv_attend"];
            HRDs.rv_attendRow[] rv_attendRows = (HRDs.rv_attendRow[])bdt.Select("adate ='" + _adate.ToShortDateString() + "'");

            HRDs.rv_cardDataTable rv_cardDs = (HRDs.rv_cardDataTable)Session["rv_card"];
            HRDs.rv_cardRow[] rv_cardRows = (HRDs.rv_cardRow[])rv_cardDs.Select("( adate ='" + _adate.ToShortDateString() + "' and ontime >'0400' ) or (adate ='" + _adate.AddDays(1).ToShortDateString() + "') and ontime <= '0400'  ");

            //  DataView dv = rv_cardDs.DefaultView;
            //  dv.RowFilter = "( adate ='" + adate.SelectedDate.Value.ToShortDateString() + "' and ontime >'0400' ) or (adate ='" + adate.SelectedDate.Value.AddDays(1).ToShortDateString() + "') and ontime <= '0400'  ";
            //dv.Sort = "adate asc ,ontime asc";

            RoteExDsTableAdapters.ROTETableAdapter rotead = new RoteExDsTableAdapters.ROTETableAdapter();




            string s_2 = "";
            string s_1 = "";
            string s_3 = "";
            string ontime = "0000";
            string offtime = "0000";

            string rote = "";
            if (rv_attendRows.Length > 0)
            {
                RoteExDs.ROTEDataTable rotedt = rotead.GetData(rv_attendRows[0].ROTE);
                
                //以下這段是去判斷班表非假日班，且當天打卡紀錄大於兩筆
                // 20110217 改成去抓attcard 的t1,t2是否為空值
                /*
                if (rotedt.Rows.Count > 0)
                {

                    ontime = rotedt[0].ON_TIME;
                    offtime = rotedt[0].OFF_TIME;

                    rote = rotedt[0].ROTE.Trim();

                    if (!rotedt[0].ROTE.Trim().Equals("00"))
                    {
                        if (rv_cardRows.Length <= 1)
                        {
                            t3 += 1;
                        }
                    }
                }
                 */



        /*                  

                        if (rv_cardRows.Length > 0)
                        {

                            for (int j = 0; j < rv_cardRows.Length; j++)
                            {
                                if (!rote.Trim().Equals("00"))
                                {
                                    if (j == 0)
                                    {
                                        if (setTimeHrs(rv_cardRows[j].ONTIME) > setTimeHrs(ontime))
                                        {
                                            t1 += 1;  //算上班遲到
                                        }
                                    }
                                    else if (j == rv_cardRows.Length - 1)
                                    {
                                        if (rv_cardRows[j].ADATE == DateTime.Parse(ddate.SelectedDate.Value.Year.ToString() + "/" +
                                          ddate.SelectedDate.Value.Month.ToString() + "/" + i.ToString()))
                                        {
                                            if (setTimeHrs(rv_cardRows[j].ONTIME) < setTimeHrs(offtime))
                                            {
                                                t2 += 1;   //算下班早退

                                            }
                                        }
                                    }
                                }
                            }

                        }


                    }

                    _adate = _adate.AddDays(1);
    
                }

                */
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {

        if (e.Day.Date > ddate.SelectedDate.Value || e.Day.Date < adate.SelectedDate.Value)
        { 
            return; 
        }


        if (Session["rv_attend"] == null)
        {
            adate.SelectedDate = DateTime.Parse(e.Day.Date.Year.ToString() + "/" + e.Day.Date.Month + "/1");
            ddate.SelectedDate = DateTime.Parse(e.Day.Date.Year.ToString() + "/" + e.Day.Date.Month + "/" + DateTime.DaysInMonth(e.Day.Date.Year, e.Day.Date.Month).ToString());
            GetData();
        }

        HRDs.rv_attendDataTable bdt = (HRDs.rv_attendDataTable)Session["rv_attend"];
        HRDs.rv_attendRow[] rv_attendRows = (HRDs.rv_attendRow[])bdt.Select("adate ='" + e.Day.Date.ToShortDateString() + "'");

        //HRDs.rv_cardDataTable rv_cardDs = (HRDs.rv_cardDataTable)Session["rv_card"];
        //HRDs.rv_cardRow[] rcards = (HRDs.rv_cardRow[])rv_cardDs.Select("adate ='" + e.Day.Date.ToShortDateString() + "'");
        //HRDs.rv_cardRow[] rcards = (HRDs.rv_cardRow[])rv_cardDs.Select("los=0 and ( adate ='" + e.Day.Date.ToShortDateString() + "' and ontime >'0400' ) or (adate ='" + e.Day.Date.AddDays(1).ToShortDateString() + "') and ontime <= '0400'");

        RoteExDsTableAdapters.ROTETableAdapter rotead = new RoteExDsTableAdapters.ROTETableAdapter();

        //HRDsTableAdapters.Attend1TableAdapter att_adapter = new HRDsTableAdapters.Attend1TableAdapter();        
        HRDs.ATTCARDDataTable attendCardDT = attCard_adapter.GetDataByNobrAdate(lb_nobr.Text,e.Day.Date);


        string s_2 = "";
        string s_1 = "";
        string s_3 = "";
        string ontime = "0000";
        string offtime = "0000";
        string _rote = "";


        //有排班資料，且無刷卡資料，變粉紅色
        if (rv_attendRows.Length > 0)
        {
            //RoteExDs.ROTEDataTable rotedt = rotead.GetData(rv_attendRows[0].ROTE);
            ROTE roteObj= roteRepo.GetByPk(rv_attendRows[0].ROTE);

            //顯示餐費
            HRDs.ATTENDRow[] attendRows = (HRDs.ATTENDRow[])attendDT.Select("adate ='" + e.Day.Date.ToShortDateString() + "'");
            decimal nigamt = 0;

            if (attendRows.Length > 0)
            {
                nigamt = attendRows[0].NIGAMT;                
            }
         //   s_1 = "<tr> <td><div class='class1' style=\"color: #000099\">餐費：" + nigamt.ToString("#") +"</div></td> </tr>";
            
            //顯示班別
            //s_1 += "   <tr> <td><div class='class1' style=\"color: #000099\">" + GetGlobalResourceObject("Resource" , "Shift") + "：" + rv_attendRows[0].ROTE + "-" + rv_attendRows[0].ROTENAME + "</div></td> </tr> ";
            s_1 += "   <tr align='left'> <td><div style=\"color: #000099\">" + GetGlobalResourceObject("Resource", "Shift") + "：" + rv_attendRows[0].ROTENAME + "</div></td> </tr> ";

            if (roteObj!=null)
            {

                ontime = roteObj.ON_TIME;
                offtime = roteObj.OFF_TIME;
                _rote = roteObj.ROTE1;

                //判斷非假日，且無刷卡資料，底色變粉紅
                if (!roteObj.ROTE_DISP.Trim().Equals("00"))
                {
                    //if (rcards.Length <= 1)
                    if(attendCardDT.Rows.Count==0)
                    {
                        e.Cell.BackColor = System.Drawing.Color.Pink;
//                        t3 += 1;
                    }

                }
            }

            // string s_2 = "  <tr>  <td><span style=\"color: #ff0000\">離職人數</span>：" + _2.ToString() + "人</td> </tr> ";
            //  string s_3 = "   <tr> <td><span style=\"color: #ff6666\">留停人數</span>：" + _3.ToString() + "人</td> </tr> ";
            // string s_4 = "   <tr> <td><span style=\"color: #009900\">復職人數</span>：" + _4.ToString() + "人</td> </tr> ";
            //  string s_5 = "  <tr>  <td><span style=\"color: #666600\">停職人數</span>：" + _5.ToString() + "人</td></tr>  ";
            //string s_7 = "  <tr>  <td><span style=\"color: #666600\">試用期滿人數</span>：" + _7.ToString() + "人</td></tr>  ";
        }

        //如果有請假的話，cell顏色改成亮黃
        //ABS.ABSRow[] absRows = (ABS.ABSRow[])absDT.Select("bdate = '" + e.Day.Date.ToShortDateString() + "'");
        var absRows = absList.Where(p => p.BDATE == e.Day.Date).ToList();
        //  if (absRows.Length > 0)
        foreach (var row in absRows)
        {
            e.Cell.BackColor = System.Drawing.Color.Yellow;

            //ABS.HCODERow[] hcodeRows = (ABS.HCODERow[])hcodeDT.Select("H_CODE='" + absRows[0].H_CODE + "'");
            ABS.HCODERow[] hcodeRows = (ABS.HCODERow[])hcodeDT.Select("H_CODE='" + row.H_CODE + "'");
            if (hcodeRows.Length > 0)
            {
                //s_3 = s_3 + "  <tr>  <td><div class='class1' style=\"color:#ff0000 \">" + hcodeRows[0].H_NAME + "：" + row.TOL_HOURS.ToString("0.#") + hcodeRows[0].UNIT + "</div></td> </tr> ";
                s_3 = s_3 + "  <tr align='left'>  <td><div style=\"color:#ff0000 \">" + hcodeRows[0].H_NAME + "：" + row.BTIME + "-" + row.ETIME + "</div></td> </tr> ";
            }
        }
        
        //20140527公出已合併至 ABS處理
        //處理公出
        //var abs1TodayList = (from c in Abs1List where c.AbsDate == e.Day.Date select c).ToList();
        //foreach (var a in abs1TodayList)
        //{
        //    e.Cell.BackColor = System.Drawing.Color.Yellow;

        //    ABS.HCODERow[] hcodeRows = (ABS.HCODERow[])hcodeDT.Select("H_CODE='" + a.H_Code + "'");
        //    if (hcodeRows.Length > 0)
        //        s_3 = s_3 + "  <tr align='left'>  <td><div style=\"color:#ff0000 \">" + hcodeRows[0].H_NAME + "：" + a.AbsBtime + "-" + a.AbsEtime + "</div></td> </tr> ";
        //}


        RoteExDsTableAdapters.ROTECHGTableAdapter ad = new RoteExDsTableAdapters.ROTECHGTableAdapter();
        RoteExDs.ROTECHGDataTable dt = ad.GetDataByNobr(lb_nobr.Text, e.Day.Date);

        if (dt.Rows.Count > 0)
        {
            if (dt[0].CODE.Trim().Length > 0)
                s_3 += "  <tr align='left' >  <td><div style=\"color:#ff0000 \">" + GetGlobalResourceObject("Resource", "Remark") + "：" + dt[0].CODE + "</div></td> </tr> ";
        }


        //這很重要，如果attendcard有紀錄的話，才進行動作，但attendcard有資料，attend卻有沒有資料的，
        if (attendCardDT.Rows.Count > 0)
        {
                        
            HRDs.ATTENDDataTable attendDT = attend_adapter.GetDataByNobrAdate(lb_nobr.Text,attendCardDT[0].ADATE);

            //上下班刷卡地會不同
            if (attendDT.Rows.Count > 0)
            {
                string cardtpyename = "";
                string style = " #000099";
                cardtpyename = GetGlobalResourceObject("Resource", "punch_in").ToString() +"：";               
                string cardSpace = "";

                string str_temp1 = "";

                //原先的會去依照attcard再去找刷卡紀錄顯示刷卡地點、補卡等資訊，現在改成直接顯示attcard的上下班紀錄
                HRDs.CARDDataTable card_dt = card_adapter.GetDataNobrAdateOntime(lb_nobr.Text, attendCardDT[0].ADATE, attendCardDT[0].T1);
                if (card_dt.Rows.Count > 0)
                {
                    cardSpace = card_dt[0].CODE;
                    //if (card_dt[0].LOS == true && card_dt[0].REASON != "5")
                    //    str_temp1 = attendCardDT[0].T1 + "<font color=\"green\">(補卡)</font>";
                    //else if (card_dt[0].LOS == true && card_dt[0].REASON == "5") //忘記刷卡不顯示時間顯示忘刷
                    //    str_temp1 = "忘刷卡";
                    if (card_dt[0].LOS == true)
                    {
                        CARDLOSD cardLostObj = cardLostRepo.GetByCode(card_dt[0].REASON);
                        string cardLostDesc = "";
                        if (cardLostObj != null)
                            cardLostDesc = cardLostObj.DESCR;

                        str_temp1 = SiteHelper.ConvertStrTimeTo24(attendCardDT[0].T1) + "<font color=\"green\">" + "(" + cardLostDesc + ")" + "</font>";
                    }
                    else
                        str_temp1 = SiteHelper.ConvertStrTimeTo24(attendCardDT[0].T1);
                }
                else //無刷卡紀錄，直接顯示attcard打卡時間
                {
                    str_temp1 = SiteHelper.ConvertStrTimeTo24(attendCardDT[0].T1);
                }
               

                if (attendDT[0].LATE_MINS > 0)
                {
                    cardtpyename = GetGlobalResourceObject("Resource", "late_for_work").ToString()+ "：";
                    style = " #ff0000"; //紅色字
                    t1 += 1;
                    Session.Add("t1", t1);
                }

                /*

              // 刷卡轉出勤程式不確定轉los了沒，所以先抓card的los if (attendCardDT[0].LOST1 == true)
                if(card_dt[0].LOS==true)
                    str_temp1 = "(補卡)";
                 */

                s_2 += "  <tr align='left' >  <td><div style=\"color:" + style + " \">" + cardtpyename + str_temp1 + " </div></td> </tr> ";
             style = " #000099";


             cardtpyename = GetGlobalResourceObject("Resource", "punch_out").ToString()+ "：";
                                
                int T2_mins=FlowCS.GetMinutes(attendCardDT[0].T2);

                if(T2_mins >= MINUTES_OF_DAY)
                {
                    string strT2 = FlowCS.GetStrHourMin(T2_mins - MINUTES_OF_DAY);
                    card_dt = card_adapter.GetDataNobrAdateOntime(lb_nobr.Text, attendCardDT[0].ADATE.AddDays(1), strT2);
                }
                else{
                    card_dt = card_adapter.GetDataNobrAdateOntime(lb_nobr.Text, attendCardDT[0].ADATE, attendCardDT[0].T2);
                }

                
                cardSpace = "";

                string str_temp2 = "";

                if (card_dt.Rows.Count > 0)
                {
                    cardSpace = card_dt[0].CODE;
                    //if (card_dt[0].LOS == true && card_dt[0].REASON != "5")
                    //if (card_dt[0].LOS == true)
                    //    str_temp2 = SiteHelper.ConvertStrTimeTo24(attendCardDT[0].T2) + "<font color=\"green\">" + GetGlobalResourceObject("Resource", "Card_Added_By_HR").ToString() + "：" + "</font>";
                        //str_temp2 = SiteHelper.ConvertStrTimeTo24(attendCardDT[0].T2) + "<font color=\"green\">" + GetGlobalResourceObject("Resource", "Card_Added_By_HR").ToString() + "：" + "</font>";
                    //else if (card_dt[0].LOS == true && card_dt[0].REASON == "5") //忘記刷卡不顯示時間
                    //    str_temp2 = "忘刷卡";
                    if (card_dt[0].LOS == true)
                    {
                        CARDLOSD cardLostObj = cardLostRepo.GetByCode(card_dt[0].REASON);
                        string cardLostDesc = "";
                        if (cardLostObj != null)
                            cardLostDesc = cardLostObj.DESCR;
                        str_temp2 = SiteHelper.ConvertStrTimeTo24(attendCardDT[0].T2) + "<font color=\"green\">" + "(" + cardLostDesc + ")" + "</font>";
                    }
                    else
                        str_temp2 = SiteHelper.ConvertStrTimeTo24(attendCardDT[0].T2);
                }
                else
                {
                    str_temp2 = SiteHelper.ConvertStrTimeTo24(attendCardDT[0].T2);
                }


                if (attendDT[0].E_MINS > 0)
                {
                    cardtpyename = GetGlobalResourceObject("Resource","leave_early").ToString()  +"：";
                    style = " #ff0000"; //紅色字
                    t2 += 1;

                }

                /*
                // 刷卡轉出勤程式不確定轉los了沒，所以先抓card的los  if (attendCardDT[0].LOST2 == true)
                if(card_dt[0].LOS==true)
                    str_temp2 = "(補卡)";
                 */

                s_2 += "  <tr align='left' >  <td><div style=\"color:" + style + " \">" + cardtpyename + str_temp2 + " </div></td> </tr> ";

            }

            /*
             * 
          if (rcards.Length > 0){
            for (int i = 0; i < rcards.Length; i++)
            {
                string cardtpyename = "";
                string style = " #000099";
                if (i == 0)
                {
                    cardtpyename = "上班：";
                    if (!_rote.Trim().Equals("00"))
                    {
                        if (setTimeHrs(rcards[i].ONTIME) > setTimeHrs(ontime))
                        {
                            cardtpyename = "上班遲到：";
                            style = " #ff0000";
                            t1 += 1;
                            Session.Add("t1", t1);
                        }
                    }
                }
                else if (i == rcards.Length - 1)
                {
                    cardtpyename = "下班：";
                    if (!_rote.Trim().Equals("00"))
                    {
                        if (rcards[i].ADATE == e.Day.Date)
                        {
                            if (setTimeHrs(rcards[i].ONTIME) < setTimeHrs(offtime))
                            {
                                cardtpyename = "下班早退：";
                                style = " #ff0000";
                                t2 += 1;

                            }
                        }
                    }
                }

                if (i == 0 || i == rcards.Length - 1)
                {
                    s_2 += "  <tr>  <td><span style=\"color:" + style + " \">" + cardtpyename + "</span> " + rcards[i].ONTIME + " <BR>刷卡地：" + rcards[i].CODE.Trim() + "</td> </tr> ";
                }
            }
             }
             */
        }

        string html = "";
        html = "<br><br><table align='left' width='100%' border='0' cellspacing='1' cellpadding='1' > " +s_1 + s_2 + s_3 +" </table> ";
        Label lb = new Label();
        lb.Text = html;
        e.Cell.Controls.Add(lb);



    }



    private void setNote(string nobr, DateTime date)
    {
        RoteExDsTableAdapters.ROTECHGTableAdapter roteChg = new RoteExDsTableAdapters.ROTECHGTableAdapter();
        RoteExDs.ROTECHGDataTable roteChgDT = roteChg.GetDataByNobr(nobr, date);
        if (roteChgDT.Rows.Count > 0)
            note.Text = roteChgDT[0].CODE;
        else
            note.Text = "";


    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        //鎖住修改班表的畫面，禾伸堂不想看到
        return;

        HRDs.rv_attendDataTable bdt = (HRDs.rv_attendDataTable)Session["rv_attend"];
        HRDs.rv_attendRow[] rv_attendRows = (HRDs.rv_attendRow[])bdt.Select("adate ='" + Calendar1.SelectedDate.ToShortDateString() + "'");
        MultiView1.ActiveViewIndex = 1;
        b_adate.Text = Calendar1.SelectedDate.ToShortDateString();
        Label6.Text = "";
        if (rv_attendRows.Length > 0)
        {
            Label6.Text = rv_attendRows[0].ROTENAME+","+rv_attendRows[0].ROTE;

            if (DropDownList3.Items.Count == 0)
                DropDownList3.DataBind();

            ListItem item = DropDownList3.Items.FindByValue(rv_attendRows[0].ROTE);
            if (item != null)
                DropDownList3.SelectedValue = rv_attendRows[0].ROTE;
        }

        //note.Text = "";
        setNote(lb_nobr.Text, Calendar1.SelectedDate);
                

        DropDownList3.Enabled = false;
        Button2.Enabled = false;
        note.Enabled = false;

        //intMangAlterShiftTableDay主管可調整班別天數，intEmpAlterShiftTableNoteDay員工可新增備註的天數
        int intMangAlterShiftTableDay = 7;
        int intEmpAlterShiftTableNoteDay = 3;

        try
        {
            intMangAlterShiftTableDay = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["MangAlterShiftTableDay"].ToString());
            intEmpAlterShiftTableNoteDay = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["EmpAlterShiftTableNoteDay"].ToString());
        }
        catch
        {
            ;
        }

        intMangAlterShiftTableDay++;
        intEmpAlterShiftTableNoteDay ++;

        if (Calendar1.SelectedDate.AddDays(intEmpAlterShiftTableNoteDay) > DateTime.Now.Date)
        {
            note.Enabled = true;
            Button2.Enabled = true;
        }

        //2011/01/31  HR角色可調整班，原來只有主管職的才可
        // HR部門可隨意調整班表，主管只能調整七天
        if (JbUser.IsMang)
        {
            if (Calendar1.SelectedDate.AddDays(intMangAlterShiftTableDay) > DateTime.Now.Date)
            {
                DropDownList3.Enabled = true;
                Button2.Enabled = true;
                note.Enabled = true;
            }
        }

        if (Page.User.IsInRole("HR"))
        {
            DropDownList3.Enabled = true;
            Button2.Enabled = true;
            note.Enabled = true;
        }




        /*
        if (!JbUser.IsMang && !Page.User.IsInRole("HR"))
        {
            DropDownList3.Enabled = false;
        }
        else
        {
            //原來是往前三天，2011/01/31改為七天
            if (Calendar1.SelectedDate.AddDays(8) < DateTime.Now.Date)
            {
                DropDownList3.Enabled = false;
            }
            else
            {
                DropDownList3.Enabled = true;
            }
        }
        */


        Calendar1.SelectedDate = DateTime.Parse("2000/1/1");
    }
    protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        adate.SelectedDate = DateTime.Parse(e.NewDate.Year.ToString() + "/" + e.NewDate.Month + "/1");
        ddate.SelectedDate = DateTime.Parse(e.NewDate.Year.ToString() + "/" + e.NewDate.Month + "/" + DateTime.DaysInMonth(e.NewDate.Year, e.NewDate.Month).ToString());
        GetData();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;

        RoteExDsTableAdapters.ROTECHGTableAdapter ad = new RoteExDsTableAdapters.ROTECHGTableAdapter();
        RoteExDs.ROTECHGDataTable dt = ad.GetDataByNobr(lb_nobr.Text, DateTime.Parse(b_adate.Text));
        if (dt.Rows.Count > 0)
        {
            dt[0].ROTE = DropDownList3.SelectedValue;
            dt[0].KEY_DATE = DateTime.Now;
            dt[0].KEY_MAN = JbUser.NAME_C;
            dt[0].CODE = note.Text;
            ad.Update(dt);

        }
        else
        {
            RoteExDs.ROTECHGRow r = dt.NewROTECHGRow();
            r.ADATE = DateTime.Parse(b_adate.Text);
            r.CODE = "";
            r.KEY_DATE = DateTime.Now;
            r.KEY_MAN = JbUser.NAME_C;
            r.NOBR = lb_nobr.Text;
            r.ROTE = DropDownList3.SelectedValue;
            r.CODE = note.Text;
            dt.AddROTECHGRow(r);
            ad.Update(dt);


        }

        setAttend(DateTime.Parse(b_adate.Text), lb_nobr.Text, DropDownList3.SelectedValue);

        GetData();



    }

    void setAttend(DateTime adate, string nobr, string rote)
    {
        AttendDsTableAdapters.ATTEND1TableAdapter attad = new AttendDsTableAdapters.ATTEND1TableAdapter();
        AttendDs.ATTEND1DataTable attdt = attad.GetDataByNobr(nobr, adate);
        if (attdt.Rows.Count > 0)
        {
            attdt[0].ROTE = rote;
            attdt[0].KEY_DATE = DateTime.Now;
            attdt[0].KEY_MAN = JbUser.NAME_C;
            attad.Update(attdt);
        }
        else
        {
            AttendDs.ATTEND1Row attrow = attdt.NewATTEND1Row();
            attrow.NOBR = nobr;
            attrow.ROTE = rote;
            attrow.ADATE = adate;
            attrow.KEY_DATE = DateTime.Now;
            attrow.KEY_MAN = JbUser.NAME_C;
            attrow.LATE_MINS = 0;
            attrow.E_MINS = 0;
            attrow.ADJ_CODE = "";
            attrow.CANT_ADJ = false;
            attrow.SER = 0;
            attrow.NIGHT_HRS = 0;
            attrow.FOODAMT = 0;
            attrow.FOODSALCD = "";
            attrow.FORGET = 0;
            attrow.ATT_HRS = 0;
            attrow.NIGAMT = 0;
            attrow.ABS = false;

            attdt.AddATTEND1Row(attrow);
            attad.Update(attdt);
        }

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void Calendar1_DataBinding(object sender, EventArgs e)
    {



    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void Button4_Click(object sender, EventArgs e)
    {

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }
    protected void Calendar1_PreRender(object sender, EventArgs e)
    {
        attendDT = attend_adapter.GetDataByNobrBTWDate(lb_nobr.Text, adate.SelectedDate.Value, ddate.SelectedDate.Value);
        getabsDT(lb_nobr.Text, adate.SelectedDate.Value, ddate.SelectedDate.Value);        
        ABS1_REPO abs1Repo = new ABS1_REPO();
        Abs1List = abs1Repo.GetByNobrDateRange_Dlo(lb_nobr.Text, adate.SelectedDate.Value, ddate.SelectedDate.Value);
    }


    /// <summary>
    /// 計算扣假，會抓取jbcustom.conf裡面扣假的hcode去計算
    /// </summary>
    /// 
    //private double countDeductionABS(string nobr, DateTime adate, DateTime ddate)
    //{
    //    double result = ABSCs.countDeductionABS(nobr, adate, ddate);
    //    return result;
    //}


    private void getabsDT(string nobr, DateTime padate, DateTime pddate)
    {
        ABS_REPO absRepo = new ABS_REPO();
        absList.AddRange(absRepo.GetByNobrDateRangeHcodeFlag_Dlo(nobr, padate, pddate, "-"));
        //absDT = absAdapter.GetDataByNobrHcodeBTWDate(nobr, padate, pddate, "0");
        //absDT.Merge(absAdapter.GetDataByNobrHcodeBTWDate(nobr, padate, pddate, "2"));
        //absDT.Merge(absAdapter.GetDataByNobrHcodeBTWDate(nobr, padate, pddate, "4"));
        //absDT.Merge(absAdapter.GetDataByNobrHcodeBTWDate(nobr, padate, pddate, "6"));
        

        hcodeDT = hcodeAdapter.GetData();
    }


    protected void DropDownList3_PreRender(object sender, EventArgs e)
    {
        for (int i = 0; i < DropDownList3.Items.Count; i++)
        {
            if (DropDownList3.Items[i].Value == selectedRote)
            {
                DropDownList3.SelectedIndex = i;
                break;
            }

        }
    }
}
