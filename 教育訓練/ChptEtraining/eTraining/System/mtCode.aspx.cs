using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class eTraining_System_mtCode : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteHelper.ConverToChinese(gv);
        }
    }
    protected void tvDept_NodeClick(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
    {
        //gv.Visible = true;
        gv.DataSourceID = "sdsGV";
        gv.DataBind();
    }

    protected void gv_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        ////Get the GridEditableItem of the RadGrid      
        //GridEditableItem editedItem = e.Item as GridEditableItem;
        ////Get the primary key value using the DataKeyValue.      
        //string NOBR = editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["NOBR"].ToString();
        ////Access the textbox from the edit form template and store the values in string variables.   
        //string GSM = (editedItem["GSM"].Controls[0] as TextBox).Text;
        //string TEL1 = (editedItem["TEL1"].Controls[0] as TextBox).Text;
        //string TEL2 = (editedItem["TEL2"].Controls[0] as TextBox).Text;
        //string EMAIL = (editedItem["EMAIL"].Controls[0] as TextBox).Text;
        //string connString = ConfigurationManager.ConnectionStrings["JBHRConnectionString"].ConnectionString;
        //SqlConnection sqlConn = new SqlConnection(connString);
        ////用這個方法，字串會有預設值空字串

        //try
        //{
        //    sqlConn.Open();

        //    string updateQuery = "update BASE set GSM = @GSM, TEL1=@TEL1,TEL2=@TEL2,EMAIL=@EMAIL where NOBR=@NOBR";
        //    SqlCommand sqlCmd = sqlConn.CreateCommand();
        //    sqlCmd.CommandText = updateQuery;
        //    sqlCmd.Parameters.Add("@GSM", SqlDbType.NVarChar);
        //    sqlCmd.Parameters.Add("@TEL1", SqlDbType.NVarChar);
        //    sqlCmd.Parameters.Add("@TEL2", SqlDbType.NVarChar);
        //    sqlCmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar);
        //    sqlCmd.Parameters.Add("@NOBR", SqlDbType.NVarChar);
        //    sqlCmd.Parameters["@GSM"].Value = GSM;
        //    sqlCmd.Parameters["@TEL1"].Value = TEL1;
        //    sqlCmd.Parameters["@TEL2"].Value = TEL2;
        //    sqlCmd.Parameters["@EMAIL"].Value = EMAIL;
        //    sqlCmd.Parameters["@NOBR"].Value = NOBR;

        //    sqlCmd.ExecuteNonQuery();
        //    sqlConn.Close();
        //    gv.Rebind();
        //}
        //catch (Exception ex)
        //{         
        //    e.Canceled = true;
        //    return;
        //}
        //return;


    }
}