using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
public partial class HR_Mang_ExcuteSql : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnExcute_Click(object sender , EventArgs e)
    {
        bindGv();
    }

    private void bindGv()
    {
        lbMsg.ForeColor = System.Drawing.Color.Black;
        lbMsg.Text = "";
        string sqlConnStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["eLearningConnectionString"].ConnectionString;

        try
        {
            using ( SqlConnection conn = new SqlConnection(sqlConnStr) )
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(TextBox1.Text , conn);
                if ( TextBox1.Text.Trim().ToUpper().Substring(0 , 6).Equals("SELECT") )
                {
                    var result = cmd.ExecuteReader();
                    gv.DataSource = result;
                    gv.DataBind();
                }
                else
                {
                    int count = cmd.ExecuteNonQuery();
                    gv.DataSource = null;
                    gv.DataBind();
                    
                    lbMsg.Text = "影響了" + count.ToString() + "筆";
                }
            }
        }
        catch ( Exception ex )
        {
            lbMsg.ForeColor = System.Drawing.Color.Red;
            lbMsg.Text = ex.Message;
        }
    }
    protected void gv_PageIndexChanging(object sender , GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        bindGv();
    }
}