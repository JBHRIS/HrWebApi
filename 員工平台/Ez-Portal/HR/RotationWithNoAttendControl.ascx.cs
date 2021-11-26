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


public partial class HR_RotationWithNoAttendControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {    
    }
    protected void btn_exportExcel_Click(object sender, EventArgs e)
    {
        HIDsTableAdapters.RotationWithNoAttendTableAdapter adapter = new HIDsTableAdapters.RotationWithNoAttendTableAdapter();                
        HIDs.RotationWithNoAttendDataTable dt = adapter.GetDataByRotationWithNoAttend();

        if (dt != null)
        {
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this.Page, GridView1, (HIDs.RotationWithNoAttendDataTable)dt, "RotationWithNoAttend");
        }
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }
}
