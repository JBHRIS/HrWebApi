using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

public partial class test3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        OT_REPO otRepo = new OT_REPO();
        otRepo.GetEmpOtSummuryByDeptDateRange("ACB0D00", new DateTime(2013, 4, 1), new DateTime(2013, 4, 30));

        //jbhrService.JbhrServiceClient client = new jbhrService.JbhrServiceClient();
        //List<jbhrService.SCompanyInfoDto> list= client.GetCompanyInfo().ToList();
        //AutoLoginAuth.Text = list.Count.ToString();
    }
}