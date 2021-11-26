using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.ComponentModel;
using System.IO;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;
using NPOI.HSSF.UserModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.Linq;
using Repo;

public partial class eTraining_test : System.Web.UI.Page
{
    private DEPT_Repo deptRepo = new DEPT_Repo();
    private BASETTS_Repo basettsRepo = new BASETTS_Repo();
    internal class DeptDataItem
    {
        private string _d_no;
        private string _id;
        private string _d_name;
        private string _parentId;
        private string _nobr;

        public string Nobr
        {
            get
            {
                return _nobr;
            }
            set
            {
                _nobr = value;
            }
        }
        public string D_NO
        {
            get { return _d_no; }
            set { _d_no = value; }
        }

        public string D_NAME
        {
            get
            {
                return _d_name;
            }
            set
            {
                _d_name = value;
            }
        }
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string ParentID
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        public DeptDataItem(string id , string parentId , string d_no,string d_name,string nobr)
        {
            _id = id;
            _parentId = parentId;
            _d_no = d_no;
            _d_name = d_name;
            _nobr = nobr;
        }
    }


    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    DataContext dc = new DataContext();    
    protected void Page_Load(object sender, EventArgs e)
    {








        var b = (from c in dcTraining.BASE
                 select c).FirstOrDefault();
        var deptList = (from c in dcTraining.DEPT select c).ToList();

        List<DeptDataItem> list = new List<DeptDataItem>();
        foreach (var d in deptList)
        {
            BASETTS basetts = basettsRepo.GetDeptManagerByDept_DLO(d.D_NO).FirstOrDefault();

            string manager = "";
            if ( basetts != null )
                manager = basetts.NOBR;
            
            DeptDataItem obj = new DeptDataItem(d.D_NO,d.DEPT_GROUP,d.D_NO,d.D_NAME,manager);
            if (d.DEPT_GROUP.Trim().Equals(""))
                obj.ParentID = null;
            list.Add(obj);

        }


        RadOrgChart1.DataTextField = "D_NAME";
        RadOrgChart1.DataFieldID = "ID";
        RadOrgChart1.DataFieldParentID = "ParentID";

        //RadOrgChart1.DataImageUrlField = @"~/TestEmpPhoto.aspx?Nobr=0000011"+ ".jpg";
        //RadOrgChart1.GroupEnabledBinding.NodeBindingSettings.DataFieldID = "ID";
        //RadOrgChart1.GroupEnabledBinding.NodeBindingSettings.DataFieldParentID = "ParentID";     
        
        //TestEmpPhoto
        //RadOrgChart1.GroupEnabledBinding.NodeBindingSettings.DataSource = list;
        RadOrgChart1.DataSource = list;
        RadOrgChart1.DataBind(); 


        //RadOrgChart1.DataSource = list;
        //RadOrgChart1.DataBind();               


        RadWindow1.VisibleOnPageLoad = false;
        if ( !IsPostBack )
        {
            PlanHelper PlanHelper = new PlanHelper();
            PlanHelper.setCbYear(cbxYear);
        }
    }
    protected void RadGrid1_NeedDataSource(object sender , Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

    }
    protected void LinqDataSource1_Selecting(object sender , LinqDataSourceSelectEventArgs e)
    {
        var q = (from c in dcTraining.trNotifyTemplate
                   join i in dcTraining.trNotifyTemplateDetail
                   on c.iAutoKey equals i.NotifyItem_iAutokey                 
        select new{c,i}).ToList();
        e.Result = q;
    }
    protected void RadGrid1_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        GridDataItem item = (GridDataItem)e.Item;
        string test= item.OwnerTableView.DataKeyValues[item.ItemIndex]["c.iAutoKey"].ToString();
        var data = (from c in dcTraining.trNotifyTemplate
                   where c.iAutoKey == Convert.ToInt32(test)
                   select c).FirstOrDefault();

        dcTraining.trNotifyTemplate.DeleteOnSubmit(data);

        dcTraining.SubmitChanges();


    }

    protected void RadComboBox2_ItemsRequested(object sender , RadComboBoxItemsRequestedEventArgs e)
    {
        JBComboBoxData.GetEmpsDesc(RadComboBox2 , e.Text);
        
        //var o = (from c in dcTraining.BASE
        //         where c.NAME_C.Contains(e.Text) || c.NOBR.Contains(e.Text)
        //         select c).Take(10).ToList();

        //foreach ( var i in o )
        //{
        //    RadComboBoxItem item = new RadComboBoxItem(i.NOBR + " " + i.NAME_C , i.NOBR);
        //    RadComboBox2.Items.Add(item);
        //}
    }
    protected void Button1_Click(object sender , EventArgs e)
    {
            Label2.Text = RadComboBox2.SelectedValue;
           // CoreClassRpt test = new CoreClassRpt();
            //test.GetData("A" , 2011);

            RadWindow1.VisibleOnPageLoad = true;
        //ScriptManager.RegisterStartupScript(this.Page , this.Page.GetType() , "buttonStartupBySM" , String.Format("openWinAddByEdit('{0}'); " , winAdd.ClientID) , true);
    }
    protected void RadComboBox2_SelectedIndexChanged(object sender , RadComboBoxSelectedIndexChangedEventArgs e)
    {
        Label2.Text = RadComboBox2.SelectedValue;
    }





    protected void RadButton2_Click(object sender , EventArgs e)
    {
    HSSFWorkbook workbook = new HSSFWorkbook();
    MemoryStream ms = new MemoryStream();
     
    // 新增試算表。
    //workbook.CreateSheet("試算表 A");
    //workbook.CreateSheet("試算表 B");
    //workbook.CreateSheet("試算表 C");
    //HSSFSheet sheet = workbook.CreateSheet("My Sheet");
    ISheet sheet = workbook.CreateSheet("test");
    sheet.CreateRow(0).CreateCell(0).SetCellValue("0");
    sheet.GetRow(0).CreateCell(1).SetCellValue("0");
    sheet.GetRow(0).CreateCell(2).SetCellValue("0");
    sheet.GetRow(0).CreateCell(3).SetCellValue("1");
    sheet.GetRow(0).CreateCell(4).SetCellValue("2");
    //sheet.CreateRow(0).CreateCell(1).SetCellValue("0");
    //sheet.CreateRow(0).CreateCell(2).SetCellValue("0");
    //sheet.CreateRow(0).CreateCell(3).SetCellValue("1");
    //sheet.CreateRow(0).CreateCell(4).SetCellValue("2");
    sheet.CreateRow(1).CreateCell(0).SetCellValue("0");
    sheet.CreateRow(2).CreateCell(0).SetCellValue("0");
    sheet.CreateRow(3).CreateCell(0).SetCellValue("3");
    sheet.CreateRow(4).CreateCell(0).SetCellValue("4");
    sheet.CreateRow(5).CreateCell(0).SetCellValue("5");

    //merged cells on single row
    //ATTENTION: don't use Region class, which is obsolete
    //sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 1));

    ////merged cells on mutiple rows
    //CellRangeAddress region = new CellRangeAddress(2, 4, 2, 4);
    //CellRangeAddress region2 = new CellRangeAddress(2, 4, 2, 5);
    //sheet.AddMergedRegion(region);
    //sheet.AddMergedRegion(region2);

    //sheet.GetRow(1).GetCell(1). 

    workbook.Write(ms);
    //ms = DataTableRenderToExcel.MergeDuplicationCol(ms, 0);
    //ms = DataTableRenderToExcel.MergeDuplicationRowCell(ms, 0);
    Response.AddHeader("Content-Disposition", string.Format("attachment; filename=EmptyWorkbook.xls"));
    Response.BinaryWrite(ms.ToArray());
    
    workbook = null;
    }
    protected void Button3_Click(object sender , EventArgs e)
    {
        Bitmap B = new Bitmap(100 , 100);
        Graphics G = Graphics.FromImage(B);

        Color BrushColor = ColorTranslator.FromHtml("#FF0000");
        SolidBrush MyBrush = new SolidBrush(BrushColor);
        G.FillRectangle(MyBrush , 5 , 5 , 10 , 10);
        Point point1 = new Point(5 , 0);
        Point point2 = new Point(0 , 10);
        Point point3 = new Point(10 , 10);
        Point[] MyPoints = { point1 , point2 , point3 };
        G.FillPolygon(MyBrush , MyPoints);
        Color LineColor = ColorTranslator.FromHtml("#000000");
        Pen LinePen = new Pen(LineColor , (float) 1);
        G.DrawRectangle(LinePen , 5 , 5 , 10 , 10);
        
        Color TextColor = ColorTranslator.FromHtml("#000000");
        SolidBrush TextBrush = new SolidBrush(TextColor);
        Font FontStyle = new Font("細明體" , (float) 9);
        G.DrawString("我的字串" , FontStyle , TextBrush , 0 , 0);
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        B.Save(Response.OutputStream , ImageFormat.Jpeg);
        //DesignHelper hp = new DesignHelper();
        //DataTable dt = hp.getTeachingMaterialDetail(48);
        //MemoryStream ms = (MemoryStream) DataTableRenderToExcel.RenderDataTableToExcel(dt);
        //Response.AddHeader("Content-Disposition" , string.Format("attachment; filename=EmptyWorkbook.xls"));
       // Response.BinaryWrite(ms.ToArray());
       // Response.End();
        

    }
    protected void RadButton3_Click(object sender, EventArgs e)
    {
        if (RadTextBox1.Text.Equals("11"))
            Label3.Text = "輸入正確";
        else
        {
            RadTextBox1.Text = "";
            Label3.Text = "要key 11";
        }
    }
    protected void RadButton3_Click1(object sender, EventArgs e)
    {
        RadGrid3.MasterTableView.ExportToExcel();
        if (RadTextBox1.Text.Equals("11"))
            Label3.Text = "輸入正確";
        else
        {
            RadTextBox1.Text = "";
            Label3.Text = "要key 11";
        }
    }
    protected void RadButton4_Click(object sender, EventArgs e)
    {
        DataContext dc = new DataContext();        
        IRepository<BASE> BaseRepository = new Repository<BASE>(dc);
        IList<BASE> Bases = BaseRepository.All().ToList();
            
    }
    protected void Button4_Click(object sender , EventArgs e)
    {
        Bitmap B = new Bitmap(100 , 100);
        Graphics G = Graphics.FromImage(B);

        Color BrushColor = ColorTranslator.FromHtml("#FF0000");
        SolidBrush MyBrush = new SolidBrush(BrushColor);
        G.FillRectangle(MyBrush , 5 , 5 , 10 , 10);
        Point point1 = new Point(5 , 0);
        Point point2 = new Point(0 , 10);
        Point point3 = new Point(10 , 10);
        Point[] MyPoints = { point1 , point2 , point3 };
        G.FillPolygon(MyBrush , MyPoints);
        Color LineColor = ColorTranslator.FromHtml("#000000");
        Pen LinePen = new Pen(LineColor , (float) 1);
        G.DrawRectangle(LinePen , 5 , 5 , 10 , 10);

        Color TextColor = ColorTranslator.FromHtml("#000000");
        SolidBrush TextBrush = new SolidBrush(TextColor);
        Font FontStyle = new Font("細明體" , (float) 9);
        G.DrawString("我的字串" , FontStyle , TextBrush , 0 , 0);
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        B.Save(Response.OutputStream , ImageFormat.Jpeg);
    }
    protected void Button5_Click(object sender , EventArgs e)
    {
        RadWindow2.VisibleOnPageLoad = true;
        RadWindow2.NavigateUrl = "~/login.aspx";
    }
    protected void RadButton5_Click(object sender , EventArgs e)
    {
        RadWindow2.VisibleOnPageLoad = true;
        RadWindow2.NavigateUrl = "~/login.aspx";
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        QuestionaryRpt rpt = new QuestionaryRpt();
        rpt.GetDataByClass(89, "01");
    }
    protected void RadButton6_Click(object sender, EventArgs e)
    {
        QuestionaryRpt rpt = new QuestionaryRpt();
        rpt.GetDataByClass(89, "01");
    }

      
    private DataTable CreateTeams()
    {
        var teams = new DataTable();
        teams.Columns.Add("TeamID");
        teams.Columns.Add("ReportsTo");
        teams.Columns.Add("Team");
        teams.Rows.Add(new string[] { "1", null, "Management" });
        teams.Rows.Add(new string[] { "2", "1", "Dev" });
        teams.Rows.Add(new string[] { "3", "2", "QA" });
        teams.Rows.Add(new string[] { "4", "1", "Support" });
        return teams;
    }
  
    private DataTable CreateEmployees()
    {
        var employees = new DataTable();
        employees.Columns.Add("EmployeeID");
        employees.Columns.Add("TeamID");
        employees.Columns.Add("Name");
        employees.Columns.Add("ImageUrl");
        employees.Rows.Add(new string[] { "1", "1", "Kate", "~/Img/Northwind/Customers/LONEP.jpg" });
        employees.Rows.Add(new string[] { "2", "2", "Arnold", "~/Img/Northwind/Customers/LACOR.jpg" });
        employees.Rows.Add(new string[] { "3", "3", "Tim", "~/Img/Northwind/Customers/GREAL.jpg" });
        employees.Rows.Add(new string[] { "4", "4", "David", "~/Img/Northwind/Customers/CENTC.jpg" });
        employees.Rows.Add(new string[] { "4", "4", "Mike", "~/Img/Northwind/Customers/VAFFE.jpg" });
        return employees;
    }
    protected void RadOrgChart1_GroupItemDataBound(object sender , OrgChartGroupItemDataBoundEventArguments e)
    {

    }
    protected void RadOrgChart1_NodeDataBound(object sender , OrgChartNodeDataBoundEventArguments e)
    {

    }
    protected void RadGrid3_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {
        var a = (from c in dcTraining.DEPT
                 select c).ToList();

        var dt = a.ToDataTable();
        RadGrid3.DataSource = dt;
        //RadGrid3.Rebind();

        
    }
    protected void RadGrid3_ItemDataBound(object sender , GridItemEventArgs e)
    {
        if ( e.Item is GridHeaderItem )
        {
            GridHeaderItem hItem = e.Item as GridHeaderItem;
            hItem.Cells[0].Text = "1";
            hItem.Cells[1].Text = "2";
            hItem.Cells[2].Text = "3";
            hItem.Cells[3].Text = "4";
        }
    }
    protected void Button7_Click(object sender , EventArgs e)
    {
        RadGrid3.MasterTableView.ExportToExcel();
    }
    protected void RadButton7_Click(object sender , EventArgs e)
    {
        trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
        List<trTrainingDetailM> list = tdmRepo.GetByAll();
        Course courseFacade = new Course();
        foreach ( var obj in list )
        {
            if ( obj.bIsPublished )
            {
                courseFacade.SyncCourseTeacher(obj.iAutoKey);
                courseFacade.CalculateInstructorFee(obj.iAutoKey);
            }
        }
    }
    protected void Button8_Click(object sender , EventArgs e)
    {
        trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
        List<trTrainingDetailM> list = tdmRepo.GetByAll();
        Course courseFacade = new Course();
        foreach ( var obj in list )
        {
            if ( obj.bIsPublished )
            {
                courseFacade.SyncCourseTeacher(obj.iAutoKey);
                courseFacade.CalculateInstructorFee(obj.iAutoKey);
            }
        }
    }
}
