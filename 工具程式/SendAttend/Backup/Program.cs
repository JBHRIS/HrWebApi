using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace sendAttendMail
{
    class Program
    {
        static void Main(string[] args)
        {
            //禾伸堂出勤異常
            //2013/02/26出勤異常通知,只發送個人,遲到、早退、曠職,請假資料顯示假別名稱、請假起迄時間、時數
           
            ErrorUtility.WriteLog("開始程式");
            //waferattend.SendAttend.DoSend();    //出勤異常通知個人
            //SendAttend2.DoSend();   //出勤異常通知主管
            //SendAttend3.DoSend();   //個人出勤明細表
            SendAttend4.DoSend();   //個人出勤明細表
            ErrorUtility.WriteLog("結束程式");           
        }
    }
}
