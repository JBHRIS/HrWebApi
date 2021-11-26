using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BL;
using JBHRModel;
using System.Collections.Generic;
using System.Linq;
using Telerik.Web.UI;
using Newtonsoft.Json;
public partial class Mang_EmpAbsStatistics:JBWebPage
{
    protected void Page_Load(object sender , EventArgs e)
    {
        if ( !IsPostBack )
        {
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.Manager);
            a.InitUC_Cat(1);

            Session[SessionName] = null;
            initCbxYear();
        }
    }
    private void initCbxYear()
    {
        RadComboBoxItem item = new RadComboBoxItem();
        item.Text = DateTime.Now.Year.ToString();
        item.Value = DateTime.Now.Year.ToString();
        item.Selected = true;
        cbxYear.Items.Add(item);

        RadComboBoxItem item1 = new RadComboBoxItem();
        item1.Text = DateTime.Now.AddYears(-1).Year.ToString();
        item1.Value = DateTime.Now.AddYears(-1).Year.ToString();
        cbxYear.Items.Add(item1);
    }


    protected void Button1_Click(object sender , EventArgs e)
    {
        GetData();
    }
    protected void ExportExcel_Click(object sender , EventArgs e)
    {
        if ( Session[SessionName] != null )
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this , gv , (List<SpecialLeaveOfYearDto>) Session[SessionName] , SessionName);
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }

    void GetData()
    {
        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj = a.GetSelectedObj();

        if (obj == null)
        {
            Show("Select Unit or Team Member");
            return;
        }


        List<SpecialLeaveOfYearDto> flowAbsList = new List<SpecialLeaveOfYearDto>();
//        JbFlow.WebServiceSoapClient flowService = new JbFlow.WebServiceSoapClient();
        List<BASE> baseList = new List<BASE>();
        BASE_REPO baseRepo = new BASE_REPO();

        
        if (obj.SelectedType==EnumUC_QS_SelectedType.Dept)
        {
            foreach (var d in obj.DeptList )
                baseList.AddRange(baseRepo.GetHiredEmpByDept_Dlo(d));
        }

        //排除主管不可看的部分
        //baseList.RemoveAll(p => Juser.ManagerExeptEmpList.Contains(p.NOBR));


       // JbFlow.ArrayOfString arr = new JbFlow.ArrayOfString();
        //arr.AddRange(baseList.Select(p => p.NOBR));

        //string s = flowService.GetYearAbsenceDetail(arr , new DateTime(Convert.ToInt32(cbxYear.SelectedValue) , 1 , 1) ,
    //new DateTime(Convert.ToInt32(cbxYear.SelectedValue) , 12 , 31) , DateTime.Now.Date);

       // Newtonsoft.Json.Linq.JArray empAbsArr = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(s);
       // flowAbsList.AddRange(empAbsArr.ToObject<List<SpecialLeaveOfYearDto>>());

        //給DeptName
        foreach ( var i in flowAbsList )
        {
            var empObj = (from c in baseList
                          where c.NOBR == i.NOBR
                          select c).FirstOrDefault();
            if ( empObj != null )
            {
                    i.DeptName = empObj.BASETTS[0].DEPT1.D_NAME;
            }
        }


        Session[SessionName] = flowAbsList;

        gv.DataSource = flowAbsList;
        gv.DataBind();
    }
    protected void gv_PageIndexChanging(object sender , GridViewPageEventArgs e)
    {
        if ( Session[SessionName] != null )
        {
            gv.PageIndex = e.NewPageIndex;
            gv.DataSource = (List<SpecialLeaveOfYearDto>) Session[SessionName];
            gv.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }
    protected void gv_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
}
