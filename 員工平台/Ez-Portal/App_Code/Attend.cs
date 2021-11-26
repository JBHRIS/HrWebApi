using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Attend 的摘要描述
/// </summary>
public class Attend {
    public Attend() {
        //
        // TODO: 在此加入建構函式的程式碼
        //



    }
    public DataTable getAttendData(string nobr, int year, int month) {
        return null;
    }

    public bool IsData_PALocked(DateTime adate, DateTime ddate)
    {
        AttendDsTableAdapters.DATA_PATableAdapter data_paAdap = new AttendDsTableAdapters.DATA_PATableAdapter();
        AttendDs.DATA_PADataTable dt = data_paAdap.GetDataBtwADdate(adate, ddate);
        if (dt.Rows.Count > 0)
            return true;
        else
            return false;
    }

    public AttendDs.DATA_PADataTable GetData_PA(DateTime adate, DateTime ddate)
    {
        AttendDsTableAdapters.DATA_PATableAdapter data_paAdap = new AttendDsTableAdapters.DATA_PATableAdapter();
        AttendDs.DATA_PADataTable dt = data_paAdap.GetDataBtwADdate(adate, ddate);
        return dt;
    }
}

