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
using NPOI.HSSF.UserModel;
using System.IO;
using Repo;
public partial class eTraining_System_EmailChange : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserQuickSearch1.sHandler += new UC_UserQuickSearch.SelectedEventHandler(gvSelected);

        if (!IsPostBack)
        {
            SiteHelper help = new SiteHelper();
            help.setDeptTv(tvDept);
            dp.SelectedDate = DateTime.Now;
        }
    }
    protected void tvDept_NodeClick(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
    {
        //gv.Visible = true;
        gv.DataSourceID = "sdsGV";
        gv.DataBind();
    }

    protected void gvSelected(string nobr, GridDataItem sItem)
    {
        lblNobr.Text = nobr;
        //lblSearchBy.Text = "nobr";
        gv.DataSourceID = "sdsQuickSearch";
        gv.Rebind();
    }
    protected void gv_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        //Get the GridEditableItem of the RadGrid      
        GridEditableItem editedItem = e.Item as GridEditableItem;
        //Get the primary key value using the DataKeyValue.      
        string NOBR = editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["NOBR"].ToString();
        //Access the textbox from the edit form template and store the values in string variables.   
        string GSM = (editedItem["GSM"].Controls[0] as TextBox).Text;
        string TEL1 = (editedItem["TEL1"].Controls[0] as TextBox).Text;
        string TEL2 = (editedItem["TEL2"].Controls[0] as TextBox).Text;
        string EMAIL = (editedItem["EMAIL"].Controls[0] as TextBox).Text;
        string connString = ConfigurationManager.ConnectionStrings["JBHRConnectionString"].ConnectionString;
        SqlConnection sqlConn = new SqlConnection(connString);
        //用這個方法，字串會有預設值空字串

        try
        {
            sqlConn.Open();

            string updateQuery = "update BASE set GSM = @GSM, TEL1=@TEL1,TEL2=@TEL2,EMAIL=@EMAIL where NOBR=@NOBR";
            SqlCommand sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandText = updateQuery;
            sqlCmd.Parameters.Add("@GSM", SqlDbType.NVarChar);
            sqlCmd.Parameters.Add("@TEL1", SqlDbType.NVarChar);
            sqlCmd.Parameters.Add("@TEL2", SqlDbType.NVarChar);
            sqlCmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar);
            sqlCmd.Parameters.Add("@NOBR", SqlDbType.NVarChar);
            sqlCmd.Parameters["@GSM"].Value = GSM;
            sqlCmd.Parameters["@TEL1"].Value = TEL1;
            sqlCmd.Parameters["@TEL2"].Value = TEL2;
            sqlCmd.Parameters["@EMAIL"].Value = EMAIL;
            sqlCmd.Parameters["@NOBR"].Value = NOBR;

            sqlCmd.ExecuteNonQuery();
            sqlConn.Close();
            gv.Rebind();
        }
        catch (Exception ex)
        {         
            e.Canceled = true;
            return;
        }
        return;

        //GridEditableItem item = e.Item as GridEditableItem;
        //Hashtable newValues = new Hashtable();
        //item.ExtractValues(newValues);

    }
    protected void btnSelectAllEmp_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("工號", typeof(string));
        dt.Columns.Add("姓名", typeof(string));
        dt.Columns.Add("部門代碼", typeof(string));
        dt.Columns.Add("部門", typeof(string));
        dt.Columns.Add("Email", typeof(string));
        dt.Columns.Add("電話1", typeof(string));
        dt.Columns.Add("電話2", typeof(string));
        dt.Columns.Add("手機", typeof(string));
        dt.Columns.Add("出生日期", typeof(string));
        dt.Columns.Add("身分證號", typeof(string));
        dt.Columns.Add("報到日", typeof(string));

        BASE_Repo baseRepo = new BASE_Repo();
        List<BASE> baseList= baseRepo.GetEmpHiredByDate_Dlo(dp.SelectedDate.Value);

        foreach (var b in baseList)
        {
            DataRow row = dt.NewRow();
            row["工號"] = b.NOBR;
            row["姓名"] = b.NAME_C;            
            row["部門代碼"] = b.BASETTS[0].DEPT;
            row["部門"] = b.BASETTS[0].DEPT1.D_NAME;
            row["Email"] = b.EMAIL;
            row["電話1"] = b.TEL1;
            row["電話2"] = b.TEL2;
            row["手機"] = b.GSM;
            if(b.BIRDT.HasValue)
                row["出生日期"] = b.BIRDT.Value;
            else
                row["出生日期"] = "";
            row["身分證號"] = b.IDNO;
            row["報到日"] = b.BASETTS[0].INDT.Value.ToShortDateString();

            dt.Rows.Add(row);

        }

        HSSFWorkbook workbook = DataTableRenderToExcel.RenderDataTableToExcel(dt);
        MemoryStream ms = new MemoryStream();
        workbook.Write(ms);
        ms.Flush();
        ms.Position = 0;
        SiteHelper.ResponseExcel(ms, dp.SelectedDate.Value.ToShortDateString()+"員工資料");
        ms.Dispose();
    }
}