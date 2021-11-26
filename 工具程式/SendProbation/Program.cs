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
            ErrorUtility.WriteLog("開始程式");
            waferattend.SendAttend.DoSend();    //試用期滿通知
            SendAttend2.DoSend();//合同通知
            ErrorUtility.WriteLog("結束程式");           
        }
    }
}
