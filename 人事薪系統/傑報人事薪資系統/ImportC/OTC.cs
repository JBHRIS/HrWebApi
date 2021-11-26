using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.Linq;
using JBHR.ImportC.DataFormat.SiteHelper;
using JBHR.ImportC.VDB;
using JBHR.ImportC.SQL_Repo;
using JBModule.Data.Linq;

namespace JBHR.ImportC
{
    class OTC : JBHR.ImportC.ImportGenObj.ImportExcelv1
    {
        Base_REPO baseREPO = new Base_REPO();

        ATTEND_REPO attendREPO = new ATTEND_REPO();

        DateTimeHelper dateTimeHelper = new DateTimeHelper();

        NumericHelper NumericHelper = new NumericHelper();

        OT_REPO otREPO = new OT_REPO();

        List<string> nobrList ;

        List<OT> otList;

        List<ATTEND> attendList;





        public override DataTable ceateTable(Dictionary<string, string> dic, ProgressBar PB)
        {


            


            nobrList = baseREPO.getAllNobrList();

            Dictionary<string, DateTime> dateDic = dateTimeHelper.getDateTimeRange(dt, dic["BDATE"]);

            otList = otREPO.getByDateTimeRange(dateDic["dtMax"], dateDic["dtMin"]);

            attendList = attendREPO.getByDateRangeDlo(dateDic["dtMax"], dateDic["dtMin"]);


            List<OTDto> otDTOList = new List<OTDto>();

            string dvNOBR       = dic["NOBR"]; //工號 string NOBRk
            string dvBDATE      = dic["BDATE"]; //加班日期 datetimeBDATEk
            string dvTOT_HOURS  = dic["TOT_HOURS"];//總時數 decimalTOT_HOURS
            string dvREST_HRS   = dic["REST_HRS"];//加班時數 decimalOT_HRS
            string dvOT_HRS     = dic["OT_HRS"];//補修時數 decimalREST_HRS
            string dvBTIME       = dic["BTIME"];//加班起 stringBTIMEk
            string dvETIME      = dic["ETIME"];//加班迄 stringETIME
            string dvYYMM = dic["YYMM"];//計薪年月 stringYYMM

            if (true)
            {
                
            }




            bool NoteFalag = true;

            string dvNOTE       = dic["NOTE"];// 記事 stringNOTE

            if (dvNOTE.Length ==0)
            {
                NoteFalag = false;
            }



            //有效日期detetimeOT_EDATE
            //OTRCDstringOTRCDk
            
            foreach (DataRow item in dt.Rows)
            {
                OTDto otDto;
                string sNOBR        =item[dvNOBR].ToString().Trim();
                string sBDATE       = item[dvBDATE].ToString().Trim();
                string sTOT_HOURS = item[dvTOT_HOURS].ToString().Trim().Length == 0 ? "0" : item[dvTOT_HOURS].ToString().Trim();
                string sREST_HRS    = item[dvREST_HRS].ToString().Trim().Length == 0 ? "0" : item[dvREST_HRS].ToString().Trim();
                string sOT_HRS = item[dvOT_HRS].ToString().Trim().Length == 0 ? "0" : item[dvOT_HRS].ToString();
                string sBTIME       = item[dvBTIME].ToString().Trim();
                string sETIME       = item[dvETIME].ToString().Trim();
                string sYYMM = item[dvYYMM].ToString().Trim();

                string sNOTE        =NoteFalag ? item[dvNOTE].ToString().Trim() :"" ;

                string ErrorMassage = "";
                otDto = setOTDto(sNOBR, sBDATE, sTOT_HOURS, sREST_HRS, sOT_HRS, sBTIME, sETIME, sYYMM, sNOTE, ErrorMassage);
                otDTOList.Add(otDto);
            }
            return otDTOList.CopyToDataTable<OTDto>();
        }

        public override int insertDB(DataGridView DGW, ProgressBar PB)
        {
            DateTime dtNow = DateTime.Now;
            
            string keyMan = MainForm.USER_NAME;

            List<OTDto> errorOTDtoList = new List<OTDto>();

            List<OT> otList = new List<OT>();

            foreach (DataGridViewRow item in DGW.Rows)
            {
                if (item.Cells["工號"].Value!=null)
                {
                    OTDto oOTDto = getOTDto(item.Cells["工號"].Value.ToString(), item.Cells["加班日期"].Value.ToString(), item.Cells["總時數"].Value.ToString(), item.Cells["加班時數"].Value.ToString(), item.Cells["補休時數"].Value.ToString(), item.Cells["加班起"].Value.ToString(), item.Cells["加班迄"].Value.ToString(), item.Cells["計薪年月"].Value.ToString(), "", item.Cells["加班原因"].Value.ToString(), item.Cells["備註"].Value.ToString());
                    if (oOTDto.備註.Contains("錯誤_。"))
	                {
                        errorOTDtoList.Add(getOTDto(item.Cells["工號"].Value.ToString(), item.Cells["加班日期"].Value.ToString(), item.Cells["總時數"].Value.ToString(), item.Cells["加班時數"].Value.ToString(), item.Cells["補休時數"].Value.ToString(), item.Cells["加班起"].Value.ToString(), item.Cells["加班迄"].Value.ToString(), item.Cells["計薪年月"].Value.ToString(), "", item.Cells["加班原因"].Value.ToString(), item.Cells["備註"].Value.ToString()));
	                }
                    else
	                {
                        otList.Add(setOTDataTable(oOTDto, keyMan, dtNow));
	                }
                }
            }
            try
            {
                otREPO.InsertByOTList(otList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("資料未匯入，請重新開啟。" + System.Environment.NewLine +ex , Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            if (errorOTDtoList.Count >0)
	        {
                ExportExcel(errorOTDtoList.CopyToDataTable(),"加班錯誤資料");
	        }
            removeDGWRows(DGW);
            return otList.Count;
        }
        // 新增資料庫使用
        public OT setOTDataTable(OTDto otDto,string Key_Man,DateTime Key_Time) {
            OT oOT = new OT();
            oOT.NOBR = otDto.工號;
            oOT.BDATE = otDto.加班日期;
            oOT.BTIME = otDto.加班起;
            oOT.ETIME = otDto.加班迄;
            oOT.TOT_HOURS = otDto.總時數;
            oOT.OT_HRS = otDto.加班時數;
            oOT.REST_HRS = otDto.補休時數;
            oOT.YYMM = otDto.計薪年月;
            oOT.NOTE = otDto.加班原因;
            oOT.OT_EDATE = otDto.有效日期;
            oOT.KEY_MAN = Key_Man;
            oOT.KEY_DATE = Key_Time;
            oOT.OT_CAR	           = 0;
            oOT.OT_DEPT	           = "";
            oOT.OT_FOOD	           = 0;
            oOT.NOTE	           = "";
            oOT.FOOD_PRI	       = 0;
            oOT.FOOD_CNT	       = 0;
            oOT.SER	               = "";
            oOT.NOT_W_133	       = 0;
            oOT.NOT_W_167	       = 0;
            oOT.NOT_W_200	       = 0;
            oOT.NOT_H_200	       = 0;
            oOT.TOT_W_100	       = 0;
            oOT.TOT_W_133	       = 0;
            oOT.TOT_W_167	       = 0;
            oOT.TOT_W_200	       = 0;
            oOT.TOT_H_200	       = 0;
            oOT.NOT_EXP	           = 0;
            oOT.TOT_EXP	           = 0;
            oOT.REST_EXP	       = 0;
            oOT.FST_HOURS	       = 0;
            oOT.SALARY	           = 0;
            oOT.NOTMODI	           = false;
            oOT.OTRCD	           = "";
            oOT.NOFOOD	           = true;
            oOT.FIX_AMT	           = false;
            oOT.REC	               = 0;
            oOT.CANT_ADJ	       = true;
            oOT.OTNO	           = "";
            oOT.OT_ROTE	           = "";
            oOT.OT_FOOD1	       = 0;
            oOT.OT_FOODH	       = 0;
            oOT.OT_FOODH1	       = 0;
            oOT.NOP_W_133	       = 0;
            oOT.NOP_W_167	       = 0;
            oOT.NOP_W_200	       = 0;
            oOT.NOP_H_100	       = 0;
            oOT.NOP_H_133	       = 0;
            oOT.NOP_H_167	       = 0;
            oOT.NOP_H_200	       = 0;
            oOT.TOP_W_133	       = 0;
            oOT.TOP_W_167	       = 0;
            oOT.TOP_W_200	       = 0;
            oOT.TOP_H_200	       = 0;
            oOT.NOT_H_133	       = 0;
            oOT.NOT_H_167	       = 0;
            oOT.HOT_133	           = 0;
            oOT.HOT_166            = 0;
            oOT.HOT_200	           = 0;
            oOT.WOT_133	           = 0;
            oOT.WOT_166            = 0;
            oOT.WOT_200	           = 0;
            oOT.SUM	               = false;
            oOT.SYSCREAT	       = true;
            oOT.OTRATE_CODE	       = "";
            oOT.NOT_W_100	       = 0;
            oOT.TOP_W_100	       = 0;
            oOT.SYSCREAT1	       = true;
            oOT.NOP_W_100	       = 0;
            oOT.SYS_OT	           = true;
            oOT.SERNO	           = "";
            oOT.DIFF	           = 0;
            oOT.EAT	               = false;
            oOT.RES	               = false;
            oOT.NOFOOD1            = true;

            return oOT;
        }

        public override int insertAndUpdateDB(DataGridView DGW, ProgressBar PB)
        {
            throw new NotImplementedException();
        }
        // 匯出使用
        public OTDto getOTDto(string sNOBR, string sBDATE, string sTOT_HOURS, string sREST_HRS, string sOT_HRS, string sBTIME, string sETIME, string sYYMM,string ot_Edate, string sNOTE, string ErrorMassage)
        {
            OTDto oOTDto = new OTDto();
            oOTDto.工號 = sNOBR;
            oOTDto.加班日期 = Convert.ToDateTime(sBDATE);
            oOTDto.總時數 = Convert.ToDecimal(sTOT_HOURS);
            oOTDto.加班時數 = Convert.ToDecimal(sOT_HRS);
            oOTDto.補休時數 = Convert.ToDecimal(sREST_HRS);
            oOTDto.加班起 = sBTIME;
            oOTDto.加班迄 = sETIME;
            oOTDto.加班原因 = sNOTE;
            oOTDto.計薪年月 = sYYMM;
            oOTDto.有效日期 = oOTDto.加班日期.AddMonths(3);
            //oOTDto.有效日期 = Convert.ToDateTime(ot_Edate);
            oOTDto.備註 = ErrorMassage;
            return oOTDto;
        }

        public OTDto setOTDto(string sNOBR, string sBDATE, string sTOT_HOURS, string sREST_HRS, string sOT_HRS, string sBTIME, string sETIME, string sYYMM, string sNOTE, string ErrorMassage)
        { 
            string   sNOBR_          ;
            DateTime dBDATE_         ;
            decimal  deTOT_HOURS_    ;
            decimal  deREST_HRS_     ;
            decimal  deOT_HRS_       ;
            string   sBTIME_         ;
            string   sETIME_         ;
            string   sYYMM_          ;
            string   sNOTE_          ;
            string   ErrorMassage_   ;
            OTDto otDto = new OTDto();
            if (!nobrList.Contains(sNOBR))
            {
                sNOBR_ = sNOBR;
                ErrorMassage = "無此員工錯誤_。";
            }
            else
            {
                sNOBR_ = sNOBR;
            }

            if (!dateTimeHelper.CheckDateTime(sBDATE))
            {
                dBDATE_ = DateTime.MinValue;
                ErrorMassage = "日期格式錯誤_。";
            }
            else
            {
                dBDATE_ = Convert.ToDateTime(sBDATE).Date ;
            }

            if (!NumericHelper.CheckNum(sTOT_HOURS))
            {
                deTOT_HOURS_ = 0;
                ErrorMassage = "總時數格式錯誤_。";
            }
            else
            {
                deTOT_HOURS_ = Convert.ToDecimal(sTOT_HOURS);
            }

            if (!NumericHelper.CheckNum(sREST_HRS))
            {
                deREST_HRS_ = 0;
                ErrorMassage = "補休時數格式錯誤_。";
            }
            else
            {
                deREST_HRS_ = Convert.ToDecimal(sREST_HRS);
            }

            if (!NumericHelper.CheckNum(sOT_HRS))
            {
                deOT_HRS_ = 0;
                ErrorMassage = "加班時數格式錯誤_。";
            }
            else
            {
                deOT_HRS_ = Convert.ToDecimal(sOT_HRS);
            }

            if (!dateTimeHelper.CompTime(sBTIME, sETIME))
            {
                sBTIME_ = sBTIME;
                sETIME_ = sETIME;
                ErrorMassage = "加班起訖格式錯誤_。";
            }
            else
            {
                sBTIME_ = sBTIME;
                sETIME_ = sETIME;
            }


            if (!ErrorMassage.Contains("錯誤_。"))
            {
                if (!(deOT_HRS_ + deREST_HRS_ == deTOT_HOURS_))
                {
                    ErrorMassage = "總時數錯誤_。";
                }
            }

            if (!ErrorMassage.Contains("錯誤_。"))
	        {
                var attend = (from c in attendList
                              where
                              c.ADATE.CompareTo(dBDATE_) == 0
                              select
                              c).FirstOrDefault();

                if (attend != null)
                {
                    if (!dateTimeHelper.CheckTimeWhitRote(attend.ROTE1, sBTIME_, sETIME_))
	                {
                        ErrorMassage = "時間衝突錯誤_。";
	                }
                }
                else
                {
                    ErrorMassage = "無班別錯誤_。";
                }
	        }


            if (!ErrorMassage.Contains("錯誤_。"))
            {
                var otItem = from c in otList
                             where
                             c.NOBR.Equals(sNOBR_)
                             &&
                             c.BDATE.CompareTo(dBDATE_) == 0
                             &&
                             c.BTIME.Equals(sBTIME_)
                             select
                             c;
                if (otItem.Any())
                {
                    ErrorMassage = "加班資料重複錯誤_。";
                }
            }

            sYYMM_ = sYYMM;

            sNOTE_ = sNOTE;



            ErrorMassage_ = ErrorMassage;

            otDto.工號 = sNOBR_;
            otDto.加班日期 = dBDATE_      ;
            otDto.總時數 = deTOT_HOURS_ ;
            otDto.補休時數 = deREST_HRS_  ;
            otDto.加班時數 = deOT_HRS_    ;
            otDto.加班起 = sBTIME_      ;
            otDto.加班迄 = sETIME_      ;
            otDto.計薪年月 = sYYMM_       ;
            otDto.加班原因 = sNOTE_       ;
            otDto.備註 = ErrorMassage_;

            return otDto;
        }

    }
}
