using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UC_TeacherD : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TestDataTable NewCourse = new TestDataTable();
        NewCourse.col = 5;
        NewCourse.row = 5;
        NewCourse.setTypeList(1, typeof(DateTime));
        NewCourse.setColName(0, "課程名稱");
        NewCourse.setColName(1, "上課日期");
        NewCourse.setColName(2, "上課時間");
        NewCourse.setColName(3, "上課地點");
        NewCourse.setColName(4, "上課時數");
        

        DataTable dt = NewCourse.getData();
        dt.Rows[0][0] = "教育訓練技巧";
       
        dt.Rows[1][0] = "面談技巧";
       
        dt.Rows[2][0] = "情緒管理";
       
        dt.Rows[3][0] = "目標管理";
       
        dt.Rows[4][0] = "專案管理與執行";
      


        RadGrid1.DataSource = dt;
        RadGrid1.DataBind();

    }
}