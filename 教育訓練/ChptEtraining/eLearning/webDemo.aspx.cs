using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

public partial class eLearning_webDemo : System.Web.UI.Page
{
   

    protected void Page_Load(object sender, EventArgs e)
    {
        TestDataTable NewCourse = new TestDataTable();
        NewCourse.col = 5;
        NewCourse.row = 1;
        //NewCourse.setTypeList(3, typeof(DateTime));
        //NewCourse.setTypeList(4, typeof(DateTime));
        NewCourse.setColName(0, "員工編號");
        NewCourse.setColName(1, "員工姓名");
        NewCourse.setColName(2, "異動原因");
        NewCourse.setColName(3, "異動日期");
        NewCourse.setColName(4, "失效日期");

        DataTable dt = NewCourse.getData();
        dt.Rows[0][0] = "0123";
        dt.Rows[0][1] = "李大同";
        dt.Rows[0][2] = "到職";
        dt.Rows[0][3] = "2011/08/08";
        dt.Rows[0][4] = "9999/12/31";
        //dt.Rows[0][5] = "尚未報名";
        //dt.Rows[1][0] = "面談技巧";
        //dt.Rows[1][4] = "12/50人";
        //dt.Rows[1][5] = "尚未報名";
        //dt.Rows[2][0] = "情緒管理";
        //dt.Rows[2][4] = "8/35人";
        //dt.Rows[2][5] = "已報名";
        //dt.Rows[3][0] = "目標管理";
        //dt.Rows[3][4] = "0/35人";
        //dt.Rows[3][5] = "已報名";
        //dt.Rows[4][0] = "專案管理與執行";
        //dt.Rows[4][4] = "3/45人";
        //dt.Rows[4][5] = "尚未報名";

        gv.DataSource = dt;
        gv.DataBind();
    }
}