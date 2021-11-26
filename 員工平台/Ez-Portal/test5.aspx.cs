using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using BL;
using System.IO;
using Telerik.Web.UI;
public partial class test5 : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    TextBox1.Attributes["onfocus"] = "javascript:this.select();";
    TextBox1.Focus();

    RadioButtonList1.Font.Size = 30;


    JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
    var aa = sc.GetHoliType();

    RadioButtonList rbl = new RadioButtonList();
    rbl.ID = "test";
    this.Controls.Add(rbl);
    rbl.Font.Size = 30;
    rbl.RepeatDirection = RepeatDirection.Horizontal;
    ListItem li1 = new ListItem();
    li1.Text = "是";
    li1.Value = "1";
    ListItem li2 = new ListItem();
    li2.Text = "否";
    li2.Value = "0";
    rbl.Items.Add(li1);
    rbl.Items.Add(li2);

    }
    protected void Button6_Click(object sender, EventArgs e)
    {

        SiteHelper sh = new SiteHelper();
        object[] tArgs = new object[3];
        tArgs[0]=Juser.Nobr ;
        tArgs[1]= DateTime.Now.AddMonths(-1);
        tArgs[2]=  DateTime.Now.AddMonths(1);
        var obj =sh.InvokeWebservice(@"http://hr.jbjob.com.tw/ASML/FlowWebServices/Service.svc", @"http://jbjob.com.tw/Flow","Service", "GetFlowSearchComplete", tArgs);

        int ii = 0;

        //String confPath=  Server.MapPath(@"~/File/resume.xml");
        //ServiceReference1.JbhrServiceClient sc = new ServiceReference1.JbhrServiceClient();
        //FileStream fileStream = new FileStream(confPath, FileMode.Open);


        //SiteHelper shelper = new SiteHelper();
        //shelper.SetMainTvRootValues("Root",tv,Juser);
        //shelper.ConvertTv2RadMenu(tv,RadMenu1);
        //bool b = sc.ImportResume(fileStream);

        JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
        var test = sc.GetFlowSearchComplete("300118", new DateTime(2012, 1, 1), new DateTime(2013, 12, 31));
        var test1 = sc.GetFlowSearchIng("300118");
        //var test = sc.GetFlowProgressFlow("334141");


        int i = 0;

    //    String confPath = Server.MapPath(@"~/File/resume.xml");
    //    FileStream fileStream = new FileStream(confPath, FileMode.Open); 
    //    XDocument xml = XDocument.Load(fileStream);

    //    var resumeList = (from c in xml.Descendants()
    //                      where c.Name == "Resume"
    //                      // where c.Name == "Table" && c.Attribute("Name").Value.Equals("RESUME")
    //                      select c).ToList();

    //    RESUME_REPO rRepo = new RESUME_REPO();
    //    RESUME_D_REPO rdRepo = new RESUME_D_REPO(rRepo.dc);

    //    foreach (var r in resumeList)
    //    {
    //        var mRow = (from c in r.Descendants()
    //                    where c.Name == "Table" && c.Attribute("Name").Value == "RESUME"
    //                    select c.Element("Row")).FirstOrDefault();
    //        if (mRow != null)
    //        {
    //            RESUME rObj = new RESUME();
    //            foreach (var f in mRow.Elements("Field"))
    //            {
    //                string key = f.Attribute("Name").Value;
    //                string value = f.Attribute("Value").Value;
    //                switch (key)
    //                {
    //                    case "PNO":
    //                        rObj.PNO = value;
    //                        break;
    //                    case "PHOTO":
    //                        rObj.PHOTO = value;
    //                        break;
    //                    case "UIDENTID":
    //                        rObj.UIDENTID = value;
    //                        break;
    //                    case "HECNAME":
    //                        rObj.HECNAME = value;
    //                        break;
    //                    case "PDATE":
    //                        rObj.PDATE = DateTime.ParseExact(value, "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
    //                        break;
    //                    case "HEENAME":
    //                        rObj.HEENAME = value;
    //                        break;
    //                    case "SEX":
    //                        rObj.SEX = value;
    //                        break;
    //                    case "BIRTHDAY":
    //                        rObj.BIRTHDAY = DateTime.ParseExact(value, "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
    //                        break;
    //                    case "WEIGHT":
    //                        rObj.WEIGHT = Convert.ToDecimal(value);
    //                        break;
    //                    case "TALL":
    //                        rObj.TALL = Convert.ToDecimal(value);
    //                        break;
    //                    case "MARRY":
    //                        rObj.MARRY = value;
    //                        break;
    //                    case "TEL":
    //                        rObj.TEL = value;
    //                        break;
    //                    case "MOBILNO":
    //                        rObj.MOBILNO = value;
    //                        break;
    //                    case "BLOOD":
    //                        rObj.BLOOD = value;
    //                        break;
    //                    case "DOMIPLACE":
    //                        rObj.DOMIPLACE = value;
    //                        break;
    //                    case "BESTDIP":
    //                        rObj.BESTDIP = value;
    //                        break;
    //                    case "GRSCHOOL":
    //                        rObj.GRSCHOOL = value;
    //                        break;
    //                    case "OTHERJU_1":
    //                        rObj.OTHERJU_1 = value;
    //                        break;
    //                    case "GRYM":
    //                        rObj.GRYM = value;
    //                        break;
    //                    case "DNDEPT":
    //                        rObj.DNDEPT = value;
    //                        break;
    //                    case "MAINSTU":
    //                        rObj.MAINSTU = value;
    //                        break;
    //                    case "NESTDIP":
    //                        rObj.NESTDIP = value;
    //                        break;
    //                    case "NGRSCHOOL":
    //                        rObj.NGRSCHOOL = value;
    //                        break;
    //                    case "OTHERJU_2":
    //                        rObj.OTHERJU_2 = value;
    //                        break;
    //                    case "NGRYM":
    //                        rObj.NGRYM = value;
    //                        break;
    //                    case "NDNDEPT":
    //                        rObj.NDNDEPT = value;
    //                        break;
    //                    case "NMAINSTU":
    //                        rObj.NMAINSTU = value;
    //                        break;
    //                    case "RESUME":
    //                        rObj.RESUME1 = value;
    //                        break;
    //                    case "ENTER":
    //                        rObj.ENTER = value;
    //                        break;
    //                    case "EMAIL":
    //                        rObj.EMAIL = value;
    //                        break;
    //                    case "BROKER":
    //                        rObj.BROKER = value;
    //                        break;
    //                    case "SET1":
    //                        rObj.SET1 = value;
    //                        break;
    //                    case "SET2":
    //                        rObj.SET2 = value;
    //                        break;
    //                    case "SET3":
    //                        rObj.SET3 = value;
    //                        break;
    //                    case "Q1":
    //                        rObj.Q1 = value;
    //                        break;
    //                    case "DOMIADDNO":
    //                        rObj.DOMIADDNO = value;
    //                        break;
    //                    case "DOMIADDR":
    //                        rObj.DOMIADDR = value;
    //                        break;
    //                    case "NOWADDNO":
    //                        rObj.NOWADDNO = value;
    //                        break;
    //                    case "NOWADDR":
    //                        rObj.NOWADDR = value;
    //                        break;
    //                    case "SET4":
    //                        rObj.SET4 = value;
    //                        break;
    //                    case "SET5":
    //                        rObj.SET5 = value;
    //                        break;
    //                    case "SET6":
    //                        rObj.SET6 = value;
    //                        break;
    //                    case "NOTE":
    //                        rObj.NOTE = value;
    //                        break;
    //                    case "FILES":
    //                        rObj.FILES = value;
    //                        break;
    //                    case "SET7":
    //                        rObj.SET7 = value;
    //                        break;
    //                    case "SET8":
    //                        rObj.SET8 = value;
    //                        break;
    //                    case "SET9":
    //                        rObj.SET9 = value;
    //                        break;
    //                    case "SET10":
    //                        rObj.SET10 = value;
    //                        break;
    //                    case "JMUSE":
    //                        rObj.JMUSE = value;
    //                        break;
    //                    case "MEEDATE":
    //                        if (value.Trim().Equals(""))
    //                            rObj.MEEDATE = null;
    //                        else
    //                            rObj.MEEDATE = DateTime.ParseExact(value, "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
    //                        break;
    //                    case "SALTYPE":
    //                        rObj.SALTYPE = value;
    //                        break;
    //                    case "SALARY":
    //                        rObj.SALARY = value;
    //                        break;
    //                    case "WORKTYPE":
    //                        rObj.WORKTYPE = value;
    //                        break;
    //                    case "WORKDATE":
    //                        if (value.Trim().Equals(""))
    //                            rObj.MEEDATE = null;
    //                        else
    //                            rObj.WORKDATE = DateTime.ParseExact(value, "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
    //                        break;
    //                    case "WORKDAY":
    //                        rObj.WORKDAY = value;
    //                        break;
    //                    case "OT1":
    //                        rObj.OT1 = value;
    //                        break;
    //                    case "MSET1":
    //                        rObj.MSET1 = value;
    //                        break;
    //                    case "MSET2":
    //                        rObj.MSET2 = value;
    //                        break;
    //                    case "MSET3":
    //                        rObj.MSET3 = value;
    //                        break;
    //                    case "MSET4":
    //                        rObj.MSET4 = value;
    //                        break;
    //                    case "MSET5":
    //                        rObj.MSET5 = value;
    //                        break;
    //                    case "MSET6":
    //                        rObj.MSET6 = value;
    //                        break;
    //                    case "MSETL":
    //                        rObj.MSETL = value;
    //                        break;
    //                    case "OT2":
    //                        rObj.OT2 = value;
    //                        break;
    //                    case "QSET7":
    //                        rObj.QSET7 = value;
    //                        break;
    //                    case "QSET1":
    //                        rObj.QSET1 = value;
    //                        break;
    //                    case "QSET2":
    //                        rObj.QSET2 = value;
    //                        break;
    //                    case "QSET3":
    //                        rObj.QSET3 = value;
    //                        break;
    //                    case "QSET4":
    //                        rObj.QSET4 = value;
    //                        break;
    //                    case "QSET5":
    //                        rObj.QSET5 = value;
    //                        break;
    //                    case "QSET6":
    //                        rObj.QSET6 = value;
    //                        break;
    //                    case "OT3":
    //                        rObj.OT3 = value;
    //                        break;
    //                    case "LSET1":
    //                        rObj.LSET1 = value;
    //                        break;
    //                    case "LSET2":
    //                        rObj.LSET2 = value;
    //                        break;
    //                    case "LSET3":
    //                        rObj.LSET3 = value;
    //                        break;
    //                    case "LSET4":
    //                        rObj.LSET4 = value;
    //                        break;
    //                    case "LSET5":
    //                        rObj.LSET5 = value;
    //                        break;
    //                    case "LSET6":
    //                        rObj.LSET6 = value;
    //                        break;
    //                    case "LSET7":
    //                        rObj.LSET7 = value;
    //                        break;
    //                    case "LSET8":
    //                        rObj.LSET8 = value;
    //                        break;
    //                    case "LSET9":
    //                        rObj.LSET9 = value;
    //                        break;
    //                    case "LSET10":
    //                        rObj.LSET10 = value;
    //                        break;
    //                    case "LSET11":
    //                        rObj.LSET11 = value;
    //                        break;
    //                    case "EMYCTNAME":
    //                        rObj.EMYCTNAME = value;
    //                        break;
    //                    case "EMYTELNO":
    //                        rObj.EMYTELNO = value;
    //                        break;
    //                    case "EMYTELNO_1":
    //                        rObj.EMYTELNO_1 = value;
    //                        break;
    //                    case "BADYN":
    //                        rObj.BADYN = value;
    //                        break;
    //                    case "BADRESON":
    //                        rObj.BADRESON = value;
    //                        break;
    //                    case "BADYN1":
    //                        rObj.BADYN1 = value;
    //                        break;
    //                    case "BADRESON1":
    //                        rObj.BADRESON1 = value;
    //                        break;
    //                    case "REMAN_1":
    //                        rObj.REMAN_1 = value;
    //                        break;
    //                    case "REMAN_2":
    //                        rObj.REMAN_2 = value;
    //                        break;
    //                    case "REMAN_3":
    //                        rObj.REMAN_3 = value;
    //                        break;
    //                    case "MUSER":
    //                        rObj.MUSER = value;
    //                        break;
    //                    case "MDATE":
    //                        if (value.Trim().Equals(""))
    //                            rObj.MEEDATE = null;
    //                        rObj.MDATE = DateTime.ParseExact(value, "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
    //                        break;
    //                    case "MTIME":
    //                        rObj.MTIME = value;
    //                        break;
    //                    case "BODY":
    //                        rObj.BODY = value;
    //                        break;
    //                    case "INTERESTING":
    //                        rObj.INTERESTING = value;
    //                        break;
    //                    case "DOMITEL":
    //                        rObj.DOMITEL = value;
    //                        break;
    //                    case "EMYRELATION":
    //                        rObj.EMYRELATION = value;
    //                        break;
    //                    case "EMYADDR":
    //                        rObj.EMYADDR = value;
    //                        break;
    //                    case "GRYN":
    //                        rObj.GRYN = value;
    //                        break;
    //                    case "GRPLACE":
    //                        rObj.GRPLACE = value;
    //                        break;
    //                    case "GRYN2":
    //                        rObj.GRYN2 = value;
    //                        break;
    //                    case "GRPLACE2":
    //                        rObj.GRPLACE2 = value;
    //                        break;
    //                    case "SOLYN":
    //                        rObj.SOLYN = value;
    //                        break;
    //                    case "SOLRESON":
    //                        rObj.SOLRESON = value;
    //                        break;
    //                    case "SOLTYPE":
    //                        rObj.SOLTYPE = value;
    //                        break;
    //                    case "SOLLEVEL":
    //                        rObj.SOLLEVEL = value;
    //                        break;
    //                    case "SOLSDATE":
    //                        if (value.Trim().Equals(""))
    //                            rObj.MEEDATE = null;
    //                        else
    //                            rObj.SOLSDATE = DateTime.ParseExact(value, "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
    //                        break;
    //                    case "SOLDDATE":
    //                        if (value.Trim().Equals(""))
    //                            rObj.MEEDATE = null;
    //                        else
    //                            rObj.SOLDDATE = DateTime.ParseExact(value, "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
    //                        break;
    //                    case "SOLIDYN":
    //                        rObj.SOLIDYN = value;
    //                        break;
    //                    case "OVERSEAYN":
    //                        rObj.OVERSEAYN = value;
    //                        break;
    //                    case "WINWORD":
    //                        rObj.WINWORD = value;
    //                        break;
    //                    case "WINEXCEL":
    //                        rObj.WINEXCEL = value;
    //                        break;
    //                    case "POWERP":
    //                        rObj.POWERP = value;
    //                        break;
    //                    case "DBASE":
    //                        rObj.DBASE = value;
    //                        break;
    //                    case "AUTOCAD":
    //                        rObj.AUTOCAD = value;
    //                        break;
    //                    case "MAC":
    //                        rObj.MAC = value;
    //                        break;
    //                    case "LOTUS":
    //                        rObj.LOTUS = value;
    //                        break;
    //                    case "OTHERS":
    //                        rObj.OTHERS = value;
    //                        break;
    //                    case "Q2":
    //                        rObj.Q2 = value;
    //                        break;
    //                    case "Q3":
    //                        rObj.Q3 = value;
    //                        break;
    //                    case "Q4":
    //                        rObj.Q4 = value;
    //                        break;
    //                    case "Q5":
    //                        rObj.Q5 = value;
    //                        break;
    //                    case "Q6":
    //                        rObj.Q6 = value;
    //                        break;
    //                    default:
    //                        break;
    //                }
    //            }

    //            rRepo.Add(rObj);

    //            var RESUME_D = (from c in r.Descendants()
    //                            where c.Name == "Table" && c.Attribute("Name").Value == "RESUME_D"
    //                            select c).FirstOrDefault();

    //            if (RESUME_D != null)
    //            {
    //                foreach (var dRow in RESUME_D.Elements("Row"))
    //                {
    //                    RESUME_D rdObj = new RESUME_D();

    //                    foreach (var f in dRow.Elements("Field"))
    //                    {
    //                        string key = f.Attribute("Name").Value;
    //                        string value = f.Attribute("Value").Value;
    //                        switch (key)
    //                        {
    //                            case "UIDENTID":
    //                                rdObj.UIDENTID = value;
    //                                break;
    //                            case "SKEYD":
    //                                rdObj.SKEYD = Convert.ToDecimal(value);
    //                                break;
    //                            case "SER_COMP":
    //                                rdObj.SER_COMP = value;
    //                                break;
    //                            case "SER_DEPT":
    //                                rdObj.SER_DEPT = value;
    //                                break;
    //                            case "SER_POS":
    //                                rdObj.SER_POS = value;
    //                                break;
    //                            case "SER_SDA":
    //                                rdObj.SER_SDA = value;
    //                                break;
    //                            case "SER_ED":
    //                                rdObj.SER_ED = value;
    //                                break;
    //                            case "LPAY":
    //                                rdObj.LPAY = Convert.ToDecimal(value);
    //                                break;
    //                            case "NOTE":
    //                                rdObj.NOTE = value;
    //                                break;
    //                            case "MAJOB":
    //                                rdObj.MAJOB = value;
    //                                break;
    //                            case "REA":
    //                                rdObj.REA = value;
    //                                break;
    //                            default:
    //                                break;
    //                        }
    //                    }

    //                    rdObj.RESUME_PNO = rObj.PNO;
    //                    rdRepo.Add(rdObj);
    //                }
    //            }

    //            rRepo.Save();
    //        }
    //    }

    }
    protected void Button7_Click(object sender , EventArgs e)
    {
        //JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
        //var a = sc.GetFormTreeToList("320749");

        //ResxConv.ResxTool t = new ResxTool();
        //ResxTool.ConvResxToExcel(Server.MapPath(@"~/App_LocalResources"), "Login");

        //ResxConv.ResxTool t = new ResxTool();
        //ResxTool.ConvExcelToResx(Server.MapPath(@"~/App_LocalResources/Login.xlsx"));

    }
    protected void Button8_Click(object sender, EventArgs e)
    {

        
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        
        
        ISelectEmp s = SelectEmp31 as ISelectEmp;
        var list = s.GetSelectedEmps();
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "callcall", "callcall");

        //Button10_Click(this, e);


        string _javascript = "var _button = document.getElementById('" + this.Button10.ClientID + "'); if (_button != null) {_button.click();}";

        if (ScriptManager.GetCurrent(this.Page) != null)
        {
            // When in AJAX context...
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "submitForm",
                    _javascript, true);
        }
        else
        {
            // When NOT in AJAX context...
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "submitForm",
             _javascript, true);
        }
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        //RadAsyncUpload1.UploadedFiles[0]

    }
    protected void RadAsyncUpload1_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
    {
        e.IsValid = false;
    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        HR_File_REPO fRepo = new HR_File_REPO();
        HR_File o = new HR_File();
        o.ID = Guid.NewGuid().ToString();
        o.GroupID = Guid.NewGuid().ToString();
        FileInfo fi = new FileInfo(Server.MapPath("~/File/resume.xml"));

        o.FileName = fi.Name;
       
        o.FileBinary = File.ReadAllBytes(Server.MapPath("~/File/resume.xml"));
        fRepo.Add(o);
        fRepo.Save();
               
        Response.AddHeader("Content-Disposition", "attachement;filename=" + HttpUtility.UrlEncode(o.FileName));
        Response.BinaryWrite(o.FileBinary.ToArray());
        Response.Flush();
        Response.Close();
    }
    protected void gv_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        QA_Published_Repo qapRepo = new QA_Published_Repo();
        gv.DataSource = qapRepo.GetAll();
    }
    protected void gv_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        //if (e.Item is GridDataItem)
        //{
        //    var item = e.Item as GridDataItem;
        //    if (item.ItemIndex % 2 == 0)
        //    {
        //        item.Display = false;
        //    }
        //}
    }
    protected void gv_PreRender(object sender, EventArgs e)
    {
        foreach(GridDataItem item in gv.Items)
        {
            if (item.ItemIndex % 2 == 0)
            {
                item.Visible = false;
            }
        }
    }
}