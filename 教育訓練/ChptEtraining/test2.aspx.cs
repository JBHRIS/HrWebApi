using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Telerik.Web.UI;
using Repo;
using System.Data;
public partial class test2 : System.Web.UI.Page
{    /// <summary>
    /// CommunicationBase給客戶端和主機端共用，可傳送接收訊息
    /// </summary>
    public class CommunicationBase
    {
        /// <summary>
        /// 傳送訊息
        /// </summary>
        /// <param name="msg">要傳送的訊息</param>
        /// <param name="tmpTcpClient">TcpClient</param>
        public void SendMsg(string msg, TcpClient tmpTcpClient)
        {
            NetworkStream ns = tmpTcpClient.GetStream();
            if (ns.CanWrite)
            {
                byte[] msgByte = Encoding.Default.GetBytes(msg);
                ns.Write(msgByte, 0, msgByte.Length);
            }
        }

        private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
        /// <summary>
        /// 接收訊息
        /// </summary>
        /// <param name="tmpTcpClient">TcpClient</param>
        /// <returns>接收到的訊息</returns>
        public string ReceiveMsg(TcpClient tmpTcpClient)
        {
            string receiveMsg = string.Empty;
            byte[] receiveBytes = new byte[tmpTcpClient.ReceiveBufferSize];
            int numberOfBytesRead = 0;
            NetworkStream ns = tmpTcpClient.GetStream();

            if (ns.CanRead)
            {
                do
                {
                    numberOfBytesRead = ns.Read(receiveBytes, 0, tmpTcpClient.ReceiveBufferSize);
                    receiveMsg = Encoding.Default.GetString(receiveBytes, 0, numberOfBytesRead);
                }
                while (ns.DataAvailable);
            }
            return receiveMsg;
        }
    } 
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime date = DateTime.Now;
        date = date.AddDays(3);

    }
    protected void Button1_Click(object sender , EventArgs e)
    {
        Bitmap B = new Bitmap(1000 , 1000);
        Graphics G = Graphics.FromImage(B);

        Color BrushColor = ColorTranslator.FromHtml("#00FF00");
        SolidBrush MyBrush = new SolidBrush(BrushColor);
        G.FillRectangle(MyBrush , 50 , 50 , 100 , 100);
        Point point1 = new Point(50 , 10);
        Point point2 = new Point(0 , 100);
        Point point3 = new Point(10 , 100);
        Point[] MyPoints = { point1 , point2 , point3 };
        G.FillPolygon(MyBrush , MyPoints);
        Color LineColor = ColorTranslator.FromHtml("#FF0000");
        Pen LinePen = new Pen(LineColor , (float) 1);
        G.DrawRectangle(LinePen , 5 , 5 , 100 , 100);

        Color TextColor = ColorTranslator.FromHtml("#FF0000");
        SolidBrush TextBrush = new SolidBrush(TextColor);
        Font FontStyle = new Font("細明體" , (float) 39);
        G.DrawString("我的字串" , FontStyle , TextBrush , 300 , 300);
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        B.Save(Response.OutputStream , ImageFormat.Jpeg);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ClassErrorRpt rpt = new ClassErrorRpt();
        DateTime adate = new DateTime(2011,1,1);
        DateTime ddate = new DateTime(2011,12,31);
        rpt.GetClassErrorBy2Date(adate, ddate);
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {
        IPAddress ipaddress = IPAddress.Parse("192.168.1.30");
        //IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 3000);
        IPEndPoint ipep = new IPEndPoint(ipaddress, 3000);
        TcpClient tcpClient = new TcpClient();

        tcpClient.Connect(ipep);
        if (tcpClient.Connected)
        {
            string s = "連線成功";
            CommunicationBase cb = new CommunicationBase();
            cb.SendMsg("00", tcpClient);
            cb.ReceiveMsg(tcpClient);
        }
        //Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //newsock.Bind(ipep);
        //newsock.Listen(1000);
        
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        int x = 48;
        int y = 49;
        
        int reust = 48 ^ 49;
        Char c = '1';
        char d = '0';
        int ic = (int)c;
        int p = c ^ d;
        char ccc= Convert.ToChar(p);


        string s = "530N1.00508042";

        int r =0;
        for(int i=0;i < s.Length;i++)
        {
            r = s[i] ^ r;

        }
        Convert.ToChar(r);
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        RadGrid3.MasterTableView.ExportToExcel();
        
       // JobAbility jobAbility = new JobAbility();
        //jobAbility.GetDataByCardYear("01", 2011);

        //Formosa_eLearningModel.Formosa_eLearningEntities ee = new Formosa_eLearningModel.Formosa_eLearningEntities();
        //var a = (from c in ee.BASETTS
        //         where c.ADATE <= DateTime.Now && c.DDATE >= DateTime.Now
        //         && (c.TTSCODE == "1" || c.TTSCODE == "4" || c.TTSCODE == "6")
        //         select c).ToList();


    }

    protected void gvSelected(string nobr, GridDataItem sItem)
    {


    }
    protected void RadButton2_Click(object sender, EventArgs e)
    {
        dcTrainingDataContext tndc = new dcTrainingDataContext();

        var d = (from c in tndc.BASE
                 join t in tndc.BASETTS on c.NOBR equals t.NOBR
                 select new { c, t }).Take(100).ToList();
        
        RadGrid1.DataSource = d;
        RadGrid1.Rebind();
    }
    protected void RadGrid1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
    {
        dcTrainingDataContext tndc = new dcTrainingDataContext();

        var d = (from c in tndc.BASE select c).Take(100).ToList();

        RadGrid1.DataSource = d;
        RadGrid1.Rebind();
    }
    protected void RadButton3_Click(object sender, EventArgs e)
    {
        CourseType_Repo courseTypeRepo = new CourseType_Repo();
        //string test=Enum.GetName(typeof(Cou.type), CourseType_Repo.type.DEMAND);
        string test=Enum.GetName(typeof(EnumCourseTypes), EnumCourseTypes.DEMAND);
        SiteHelper.CbxSelectAll(RadComboBox1);


        trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
        trTrainingDetailM tdm = tdmRepo.GetByKey_DLO(89);
        if (tdm != null)
        {
            DcHelper.Detach(tdm);
            trTrainingDetailM newObj = new trTrainingDetailM();
            DcHelper.CopyObjectProperty(tdm, newObj);
            tdm.iYear = 2014;
           
            tdmRepo.Update(tdm);
            tdmRepo.Save();
        }
        
    }


    public void CbxSelectAll(RadComboBox cbx)
    {
        if (cbx.CheckBoxes)
        {
            var items = (from c in cbx.Items select c).ToList();
            foreach (var item in items)
                item.Checked = true;
        }
    }



    protected void Button5_Click(object sender, EventArgs e)
    {
        dcTrainingDataContext dc = new dcTrainingDataContext();
        trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
        tdmRepo.dc = dc;
       // trTrainingDetailM tdm= tdmRepo.GetByKey_DLO(88);
        //if (tdm != null)
        {
            tdmRepo.DeleteByPK(88);
            tdmRepo.Save();
        }
    }
    protected void RadGrid3_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {
        dcTrainingDataContext dcTraining = new dcTrainingDataContext();
        var a = (from c in dcTraining.DEPT
                 select c).ToList();

        var dt = a.ToDataTable();

        if (Session["DT"] != null)
        {
            RadGrid3.DataSource = (DataTable)Session["DT"];

        }
        else
        {
            Session["DT"] = dt;
            RadGrid3.DataSource = dt;
        }

        
    }
    protected void RadGrid3_ItemDataBound(object sender , GridItemEventArgs e)
    {
        if ( e.Item is GridHeaderItem )
        {
            GridHeaderItem hItem = e.Item as GridHeaderItem;
            hItem.Cells[0].Text = "11";
            hItem.Cells[1].Text = "22";
            hItem.Cells[2].Text = "33";
            hItem.Cells[3].Text = "44";
        }
    }
    protected void RadGrid3_ExcelExportCellFormatting(object sender , ExcelExportCellFormattingEventArgs e)
    {
        e.FormattedColumn.HeaderText = "test";
        
    }
    protected void RadGrid3_ExportCellFormatting(object sender , ExportCellFormattingEventArgs e)
    {

    }
    protected void RadGrid3_ExcelMLExportRowCreated(object sender , Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLRowCreatedArgs e)
    {
        //if ( e.RowType == Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLRowType.HeaderRow )
        //{
        //    e.Row.Cells[0].Data.DataItem = "1";
        //    e.Row.Cells[1].Data.DataItem = "2";
        //    e.Row.Cells[2].Data.DataItem = "3";        
        //}
    }
    protected void RadButton4_Click(object sender , EventArgs e)
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
    protected void RadButton7_Click(object sender , EventArgs e)
    {
        trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
        List<trTrainingDetailM> list = tdmRepo.GetByAll();
        Course courseFacade = new Course();
        foreach ( var obj in list )
        {
            if ( obj.bIsPublished)
            {
                courseFacade.SyncCourseTeacher(obj.iAutoKey);
                if(obj.trTeacher_sCode.Equals("01"))
                    courseFacade.CalculateInstructorFee(obj.iAutoKey);

                courseFacade.CalculateInstructorTime(obj.iAutoKey);

                
            }
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        DateTime dt= DateTime.Now;
        


        if(MailVariable.IsEmail("macry.cheng@larviewtek.com"))
        {
        

        }
        if (MailVariable.IsEmail("sandy.chen@larviewtek.com"))
        {


        }
        if (MailVariable.IsEmail("diana.lee@larviewtek.com"))
        {


        }
    }
}