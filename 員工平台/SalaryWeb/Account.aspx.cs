using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalaryWeb
{
    public partial class Account : System.Web.UI.Page
    {
        private SalaryModel _salaryModel = new SalaryModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowMsgLabel.Text = string.Empty;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RemoveSalaryPassword(empidLabel.Text);
        }

        private void RemoveSalaryPassword(string empid)
        {
            try
            {
                _salaryModel.RemovePassword(empid);
                ShowMsgLabel.Text = "success";
            }
            catch
            {
                ShowMsgLabel.Text = "移除驗證碼失敗";
                return;
            }
        }
    }
}