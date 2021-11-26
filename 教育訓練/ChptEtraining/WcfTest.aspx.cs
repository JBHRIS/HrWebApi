using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WcfTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();
        //Label1.Text= client.Test();
        //ServiceReference1.trTrainingDetailM[] tdmArr = client.GetByYearDateRange_DLO(2012, new DateTime(2012, 5, 1), new DateTime(2012, 8, 1));
        //client.Close();
        //Label1.Text = test.Count().ToString();
        eTraining.WcfStudentClient client = new eTraining.WcfStudentClient();
        var list= client.GetByNobrDateRange("0085271", new DateTime(2011, 1, 1), new DateTime(2013, 12, 31), true);

        RadGrid1.DataSource = list;
        RadGrid1.Rebind();
        client.Close();
        //foreach (var a in tdmArr)
        //{
            
        //}

        //Label1.Text = tdmArr.Length.ToString();



        //RadGrid1.DataSource = tdmArr;
        //RadGrid1.Rebind();
        //ServiceClient client = new ServiceClient();

        // 使用 'client' 變數來呼叫服務上的作業。

        // 永遠關閉用戶端。
        //client.Close();
    }
}