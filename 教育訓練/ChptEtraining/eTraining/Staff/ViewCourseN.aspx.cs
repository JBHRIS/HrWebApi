using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class eTraining_Staff_ViewCourseN : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TestDataTable CourseN = new TestDataTable();
        CourseN.col = 7;
        CourseN.row = 3;
        CourseN.setColName(0, "課程名稱");
        CourseN.setColName(1, "課程類別");
        CourseN.setColName(2, "上課日期");
        CourseN.setColName(3, "上課時間");
        CourseN.setColName(4, "上課時數");
        CourseN.setColName(5, "上課地點");
        CourseN.setColName(6, "授課講師");
        DataTable dt = CourseN.getData();
        dt.Rows[0][0] = "面談技巧";
        dt.Rows[0][1] = "一般管理技能";
        dt.Rows[0][2] = "2011/06/08";
        dt.Rows[0][3] = "9:00";
        dt.Rows[0][4] = "2hr";
        dt.Rows[0][5] = "訓練教室";
        dt.Rows[0][6] = "王老師";

        dt.Rows[1][0] = "談判技巧";
        dt.Rows[1][1] = "一般管理技能";
        dt.Rows[1][2] = "2011/06/15";
        dt.Rows[1][3] = "16:00";
        dt.Rows[1][4] = "4hr";
        dt.Rows[1][5] = "訓練教室";
        dt.Rows[1][6] = "林老師";

        dt.Rows[2][0] = "情緒管理";
        dt.Rows[2][1] = "人際關係課程";
        dt.Rows[2][2] = "2011/06/25";
        dt.Rows[2][3] = "15:00";
        dt.Rows[2][4] = "1hr";
        dt.Rows[2][5] = "訓練教室";
        dt.Rows[2][6] = "陳老師";
        RadGrid1.DataSource = dt;
        RadGrid1.DataBind();


    }
}