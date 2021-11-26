using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using BL;

public partial class Utli_ConvertResx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        BASE_REPO baseRepo = new BASE_REPO();
        List<BASE> baseList= baseRepo.GetAll();
        string newPassword = "";
        foreach (var b in baseList) 
        {
            newPassword = Guid.NewGuid().ToString().Substring(0, 8);
            b.PASSWORD = newPassword;
            baseRepo.Update(b);
        }
        baseRepo.Save();
    }
}