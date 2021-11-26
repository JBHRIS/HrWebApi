using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.Linq;
using System.Data.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using JBHRModel;
using System.Net.Mail;
using System.Xml;
using System.Xml.Linq;

public partial class Test4 : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       // JbFlow.WebServiceSoapClient flowService = new JbFlow.WebServiceSoapClient();
       // string empAbsStr = flowService.AbsData(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 12, 31), new JbFlow.ArrayOfString(), new JbFlow.ArrayOfString() { "10201015" });
     //   Newtonsoft.Json.Linq.JArray empAbsArr = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(empAbsStr);
      //  List<FlowProcessingDto> flowAbsList = empAbsArr.ToObject<List<FlowProcessingDto>>();

        int i = 0;

        //SiteHelper s = new SiteHelper();

        //JbhrService c = new JbhrService();
        //var d = c.GetTitleData();
        ////Label1.Text = c.IsInRoleHR(TextBox1.Text).ToString();



        //COMP_REPO compRepo = new COMP_REPO();
        //List<COMP> l =compRepo.GetAll();

        //foreach ( var c in l )
        //{
            
        //}
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //ServiceReference1.JbhrServiceClient s = new ServiceReference1.JbhrServiceClient();
        //ServiceReference2.JbhrServiceClient s = new ServiceReference2.JbhrServiceClient();

        //ServiceReference1.JbhrServiceClient
        //var a = s.GetCompanyInfo();
        //var a6 = s.GetTitleData();

        //HttpWebRequest request = new HttpWebRequest();
        //增加下面两个属性即可
        //request.KeepAlive = false;
        //request.ProtocolVersion = HttpVersion.Version10;


        //ServiceReference1.JbhrServiceClient s = new ServiceReference1.JbhrServiceClient();
        
        

        //var a5 = s.GetDepartmentData();
        //byte[] test= s.GetEmpPhoto("10100002");
        //FileStream fs = new FileStream(@"c:\10100002.png", FileMode.Create);
        //BinaryWriter bw = new BinaryWriter(fs);
        //bw.Write(test);
        //bw.Close();
        //fs.Close();

        //BASE_REPO baseRepo = new BASE_REPO();
        //var baseList=baseRepo.GetAll_Dlo();
        //var baseL = (from c in baseList select c.NOBR).ToList();


        //var baseObj = (from c in baseList where c.NOBR == "10400045" select c).FirstOrDefault();

        //var all=baseRepo.GetAll();
        //BASE_REPO baseRepo = new BASE_REPO();
        //var a=baseRepo.GetAll_Dlo();



        //var others = (from c in all where !baseL.Contains(c.NOBR) select c).ToList();

        //ServiceReference1.JbhrServiceClient s = new ServiceReference1.JbhrServiceClient();
        //var a5 = s.GetHumanReport("201303", "0");
        //var a6 = s.GetHumanReport("201303", "1");

        int i = 0;
        //var test = (from c in a5 where c.User_id == "10100529" select c).FirstOrDefault();


        //var a5 = s.GetHumanReport("201303", "1");
        //var a5 = s.GetHRUSER_DEPT_FLOWA();
        //JbhrService j = new JbhrService();
        //var a5 = j.GetHRUSER_DEPT_FLOWA();
        //RadGrid1.DataSource = a5;
        //RadGrid1.Rebind();
        
       // JbFlow.WebServiceSoapClient cc = new JbFlow.WebServiceSoapClient();
      //  JbFlow.ArrayOfString l = new JbFlow.ArrayOfString();
        //l.Add
        //cc.AbsGoIng(l);

        TreeView tv = new TreeView();
        SiteHelper.SetAllDeptTree(tv);

        List<TreeNode> nodeList = SiteHelper.GetTreeViewAllNodes(tv);

        foreach (var n in nodeList)
        {
            //l.Add(n.Value);
        }

        
        //string s = cc.AbsGoIng(l,new JbFlow.ArrayOfString());
        //string s = cc.AbsGoIng(new JbFlow.ArrayOfString(),new JbFlow.ArrayOfString(){"10200130"});


        //DataTable dt = JsonConvert.DeserializeObject<DataTable>(s);
        //Newtonsoft.Json.Linq.JArray arr = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(s);
        //List<FlowProcessingDto> flowPsList = arr.ToObject<List<FlowProcessingDto>>();

        //RadGrid1.DataSource = dt;
        //Newtonsoft.Json.Linq.JArray jArry = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(s);
        //RadGrid1.DataSource = jArry;
        //RadGrid1.DataBind();


        //var a55 = (from c in a5 where c.User_name == "陳良偉" select c).FirstOrDefault();

        
        //var a6 = s.GetUserData();
        //var a7 = s.GetNotHiredUserData();

        //var aa = (from c in a6 where c.User_id == "10400046" select c).FirstOrDefault();
        //var a5 = s.GetRotetData();

        //var a6 = (from c in a5 where c.Father_id == "" select c).ToList();

        //RadGrid1.DataSource = a5;
        //RadGrid1.Rebind();

        //var a1 = s.GetDepartmentData();
        //var a2 = s.GetHRCostCenter();
        //var a3 = s.GetHRUSER_DEPT_BAS_FLOWA();
        //var a4 = s.GetHRUSER_DEPT_FLOWA();
        //var a5 = s.GetJobLevel();
        //var a6 = s.GetTitleData();
        //var a7 = s.GetUserData();
        //var a9 = s.GetTitleData();
        //var a8 = s.GetUserDept();


       // var test = a1.Where(p => p.Dbname != "NULL");
       // var test1 = a1.Where(p => p.Dbname != "NULL");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
// ServiceReference1.JbhrServiceClient s = new ServiceReference1.JbhrServiceClient();
        //var temp = s.GetUserDataById("10400050");
        //int i = 0;
        //var a = s.GetHumanReport("201303", "1").OrderBy(p => p.CompanyId);
        //var aa = (from c in a where c.EmployeeId == "10200153" select c).FirstOrDefault();
        //RadGrid1.DataSource = a;
        //RadGrid1.Rebind();

        //using (JBHRModelDataContext ldc = new JBHRModelDataContext())
        //{
        //    DateTime datetime = new DateTime(2013, 5, 1);
        //    ldc.Log = new DebuggerWriter();
        //    DataLoadOptions dlo = new DataLoadOptions();
        //    dlo.LoadWith<BASE>(l => l.BASETTS);
        //    dlo.LoadWith<BASE>(l => l.BankCode);
        //    dlo.LoadWith<BASETTS>(l => l.DEPT1);
        //    dlo.LoadWith<BASETTS>(l => l.DEPTS1);
        //    dlo.LoadWith<BASETTS>(l => l.JOB1);
        //    dlo.LoadWith<BASETTS>(l => l.JOBL1);
        //    dlo.LoadWith<BASETTS>(l => l.WORKCD1);
        //    dlo.LoadWith<BASETTS>(l => l.ROTET1);
        //    dlo.LoadWith<BASETTS>(l => l.OutPost1);
        //    dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
        //    ldc.LoadOptions = dlo;

        //    var aaa = (from c in ldc.BASE
        //               where c.BASETTS.Any()
        //               select c).ToList();
        //}
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        PARAMETER_REPO pRepo = new PARAMETER_REPO();
        var pList=pRepo.GetAll();

        string smtpServer = (from c in pList where c.CODE.Equals("JbMail.host") select c.VALUE).FirstOrDefault();
        string user = (from c in pList where c.CODE.Equals("JbMail.sys_mail") select c.VALUE).FirstOrDefault();
        string pwd = (from c in pList where c.CODE.Equals("JbMail.sys_pwd") select c.VALUE).FirstOrDefault();
        int port = Convert.ToInt32((from c in pList where c.CODE.Equals("JbMail.port") select c.VALUE).FirstOrDefault());


        SmtpClient smtpClient = new SmtpClient(smtpServer, port);
        smtpClient.Credentials = new System.Net.NetworkCredential(user, pwd);
        MailMessage mailMessage = new MailMessage();
        mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
        mailMessage.BodyEncoding = System.Text.Encoding.UTF8; ;
        mailMessage.IsBodyHtml = true;
        mailMessage.From = new MailAddress(user, user);

        mailMessage.Subject = "test";
        mailMessage.Body = "content";
        mailMessage.To.Add(@"kukoc@jbjob.com.tw");
        smtpClient.Send(mailMessage);

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        //DEPT_REPO deptRepo = new DEPT_REPO();
        //List<DEPT> deptList= deptRepo.GetDeptListByCompany("AA01");
        string s1 = "A00AB00";
        string s2 = "A00ABB0";

        //if(s1.CompareTo(s2))




        //JbFlow.WebServiceSoapClient flowService = new JbFlow.WebServiceSoapClient();

        //string s22 = flowService.AbsInfoWithHR(DateTime.Now.Date,new JbFlow.ArrayOfString() { "10201015"});

        //flowService.AbsInfoWithHR()

      //  string s = flowService.GetYearAbsenceDetail(new JbFlow.ArrayOfString { "10201025" }, new DateTime(2013, 1, 1),
      //      new DateTime(2013, 12, 31), DateTime.Now.Date);

      //  Newtonsoft.Json.Linq.JArray empAbsArr = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(s);
       // List<SpecialLeaveOfYearDto> flowAbsList = empAbsArr.ToObject<List<SpecialLeaveOfYearDto>>();
        int i = 0;


        //string s = flowService.AbsInfoWithHrHide(DateTime.Now.Date, true,new JbFlow.ArrayOfString() { "10201015" });



        //string empAbsStr = flowService.AbsData(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 12, 31), new JbFlow.ArrayOfString(), new JbFlow.ArrayOfString() { lblNobr.Text });
        //Newtonsoft.Json.Linq.JArray empAbsArr = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(s);
        //List<AbsenceDetailDto> flowAbsList = empAbsArr.ToObject<List<AbsenceDetailDto>>();

        //int i = 0;




        //Newtonsoft.Json.Linq.JArray empAbsArr = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(empAbsStr);
        //List<FlowProcessingDto> flowAbsList = empAbsArr.ToObject<List<FlowProcessingDto>>();

        //string flowPsStr = flowService.AbsGoIng(new JbFlow.ArrayOfString(), new JbFlow.ArrayOfString() { lblNobr.Text });
        //Newtonsoft.Json.Linq.JArray arr = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(flowPsStr);
        //List<FlowProcessingDto> flowPsList = arr.ToObject<List<FlowProcessingDto>>();

        //List<string> absCodeList = (from c in flowPsList select c.sHcode).ToList();
        //absCodeList.AddRange((from c in flowAbsList select c.sHcode).ToList());

        //absCodeList = (from c in absCodeList select c).Distinct().ToList();
       




       
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        String confPath = Server.MapPath(@"~/File/resume.xml");
        XDocument xml = XDocument.Load(confPath);

        var masterRow = (from c in xml.Descendants() where c.Name == "Table" && c.Attribute("Name").Value.Equals("RESUME") select c).ToList();
        foreach (var mr in masterRow)
        {
            var mrDataList= mr.Element("Row").Elements();
            foreach(var mrd in mrDataList)
            {
                
            }

        }

        //List<RoleConfig> testList = new List<RoleConfig>();
        //foreach (var r in roles.Elements())

        //var rootNode = (from c in xml.Descendants()
        //                where c.Name == @"{http://schemas.microsoft.com/AspNet/SiteMap-File-1.0}siteMapNode"
        //                select c).FirstOrDefault();

        //doc.LoadXml(xml.ToString());
        //string jsonText = JsonConvert.SerializeXmlNode(doc);

        //string jsonText = JsonConvert.SerializeXmlNode(doc);
    }
}      

       
       
       

       
       

       