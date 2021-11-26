using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class eTraining_Manager_UploadAllFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TestDataTable applyCourse = new TestDataTable();
        applyCourse.col = 5;
        applyCourse.row = 5;
        applyCourse.setColName(0, "課程名稱");
        applyCourse.setColName(1, "開課日期");
        applyCourse.setColName(2, "報名開始日");
        applyCourse.setColName(3, "報名結束日");
        applyCourse.setColName(4, "報名人數/上限");
        
        DataTable dt = applyCourse.getData();
        dt.Rows[0][0] = "教育訓練技巧";
        dt.Rows[0][1]="2011/06/01";
        dt.Rows[0][2] = "2011/03/01";
        dt.Rows[0][3] = "2011/05/20";
        dt.Rows[0][4] = "11/40人";

        dt.Rows[1][0] = "面談技巧";
        dt.Rows[1][1] = "2011/07/15";
        dt.Rows[1][2] = "2011/04/01";
        dt.Rows[1][3] = "2011/06/30";
        dt.Rows[1][4] = "23/50人";

        dt.Rows[2][0] = "情緒管理";
        dt.Rows[2][1] = "2011/07/23";
        dt.Rows[2][2] = "2011/04/01";
        dt.Rows[2][3] = "2011/06/30";
        dt.Rows[2][4] = "15/30人";

        dt.Rows[3][0] = "目標管理";
        dt.Rows[3][1] = "2011/08/15";
        dt.Rows[3][2] = "2011/06/01";
        dt.Rows[3][3] = "2011/07/30";
        dt.Rows[3][4] = "0/35人";

        dt.Rows[4][0] = "專案管理與執行";
        dt.Rows[4][1] = "2011/09/28";
        dt.Rows[4][2] = "2011/07/01";
        dt.Rows[4][3] = "2011/09/18";
        dt.Rows[4][4] = "0/20人";

        RadGrid1.DataSource = dt;
        RadGrid1.DataBind();
    }
}