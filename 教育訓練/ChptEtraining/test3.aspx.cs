using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
//using Microsoft.Web.Helpers;

public partial class test3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //mpc.AutoStart = true;
            //mpc.MovieURL = "f641981e-4fa6-4a0b-abd1-3e11bee40fb1.wmv";
            //mpc.Mute = false;
            //mpc.Rate = 1;
            //mpc.uiMode = Media_Player_ASP.NET_Control.Enumerations.PlayerMode.Full;
            //mpc.CurrentPosition = 0;
            
            //f641981e-4fa6-4a0b-abd1-3e11bee40fb1.wmv
            //Video.MediaPlayer("~/f641981e-4fa6-4a0b-abd1-3e11bee40fb1.wmv", "400", "600", true, 1, "full",
            //    true, true, false, 75, null, null, null, null);
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
       // RadWindowManager1.RadAlert("test", 800, 600, "testTitle", "stopAllMedia");
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool b= MailVariable.IsEmail(@"6615abc@yahoo.com.tw                       ");
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        sysRole_Repo roleRepo = new sysRole_Repo();
        RadGrid1.DataSource = roleRepo.GetAll();
    }
}