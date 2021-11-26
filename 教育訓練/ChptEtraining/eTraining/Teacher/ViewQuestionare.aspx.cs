using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class eTraining_Teacher_TeacherWrite : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TestDataTable cList = new TestDataTable();
        cList.col = 3;
        cList.row = 5;
        cList.setColName(0, "課程分類");
        cList.setColName(1, "課程名稱");
        cList.setColName(2, "上課日期");
        DataTable dt = cList.getData();
        dt.Rows[0][0] = "一般管理技能";
        dt.Rows[0][1] = "面談技巧";
        dt.Rows[0][2] = "2011/05/28";
        dt.Rows[1][0] = "一般管理技能";
        dt.Rows[1][1] = "談判技巧";
        dt.Rows[1][2] = "2011/05/28";
        dt.Rows[2][0] = "人際關係課程";
        dt.Rows[2][1] = "溝通協調技巧";
        dt.Rows[2][2] = "2011/05/30";
        dt.Rows[3][0] = "人際關係課程";
        dt.Rows[3][1] = "情緒管理";
        dt.Rows[3][2] = "2011/06/15";
        dt.Rows[4][0] = "創造力與自主管理課程";
        dt.Rows[4][1] = "自我管理";
        dt.Rows[4][2] = "2011/07/02";
        RadGrid1.DataSource = dt;
        RadGrid1.DataBind();
    }
}