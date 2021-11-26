using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SalaryWeb.Models;

namespace SalaryWeb
{
    public partial class Entry : System.Web.UI.Page
    {
        private const string EmpIdQueryString = "empid";
        private readonly SalaryModel _salaryModel = new SalaryModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack))
            {
                string EmpId = Request.QueryString[EmpIdQueryString] as string;
                showMsgLabel.Text = string.IsNullOrWhiteSpace(EmpId) ? "員工欄位空白" : string.Empty;
                EmpIdTextBox.Text = EmpId;
                EmpIdLabel.Text = EmpId;
                TicketLabel.Text = string.Empty;
            }
            else
            {
                showMsgLabel.Text = string.Empty;
            }
        }

        /// <summary>
        /// 要求初始化密碼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InitialPWButton_Click(object sender, EventArgs e)
        {
            string EmpId = EmpIdLabel.Text;
            bool isExistPW = _salaryModel.IsExistPassword(EmpId);

            if (isExistPW)
            {
                showMsgLabel.Text = "密碼已設定";
                return;
            }

            queryDiv.Visible = false;
            initialDiv.Visible = true;
        }

        /// <summary>
        /// 初始化密碼欄位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SetNewPasswordBtn_Click(object sender, EventArgs e)
        {
            string pw1 = NewPasswordTextBox1.Text;
            string pw2 = NewPasswordTextBox2.Text;

            #region password check 

            // 密碼不相等
            if (pw1 != pw2)
            {
                showMsgLabel.Text = "輸入密碼欄位不相符";
                return;
            }

            #endregion

            #region 設定密碼區塊

            string EmpId = EmpIdLabel.Text;
            string cPW = pw1;

            //SalaryModel salaryModel = new SalaryModel();

            try
            {
                _salaryModel.SetNewPassword(EmpId, cPW);
            }
            catch
            {
                showMsgLabel.Text = "更新密碼失敗";
                return;
            }

            queryDiv.Visible = true;
            initialDiv.Visible = false;

            #endregion
        }


        //取得yymm等資料
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            WebServiceProvide YYMMservice = new WebServiceProvide();

            string empid = EmpIdTextBox.Text;
            string plaintextPW = PasswordTextBox.Text;

            string ticket;
            bool hasTicket = _salaryModel.GetTicket(empid, plaintextPW, out ticket);

            if ((!hasTicket))
            {
                showMsgLabel.Text = "驗證失敗";
                return;
            }
            else
            {
                //TicketLabel.Text =  CEncrypt.Text(ticket);
                TicketLabel.Text =  CipherTool.EncryptText(ticket);
            }

            string EmpId = EmpIdLabel.Text;
            List<PayslipYearMonthSeqDDLInfo> yymmDatas = YYMMservice.PayslipYMSInfos(EmpId);
            var handleForSelect =
                yymmDatas.Select(info => new {text = info.Note, value = info.Year + "|" + info.Month + "|" + info.Seq})
                    .ToArray();
            YYMMSelect.DataTextField = "text";
            YYMMSelect.DataValueField = "value";
            YYMMSelect.DataSource = handleForSelect;
            YYMMSelect.DataBind();


            SalaryDiv.Visible = true;
            queryDiv.Visible = false;
        }

        protected void YYMMSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList select = (DropDownList) sender /*as DropDownList*/;

            string selectValue = select.SelectedValue;

            string[] splitValues = selectValue.Split(new char[] {'|'}, 3);

            if (splitValues.Length != 3)
            {
                throw new ArgumentOutOfRangeException("薪資格式異常");
            }


            string empid = EmpIdLabel.Text;
            string salaryYear = splitValues[0];
            string salaryMonth = splitValues[1];
            string salarySeq = splitValues[2];
            string validateKey = TicketLabel.Text;
            string deadline = Config.Deadline().ToString();
            string language = LanguageDropdownlist.SelectedItem.Value;

            string showSalaryUrl =
                string.Format(
                    "Payslip.aspx?salary_nobr={0}&salary_year={1}&salary_month={2}&salary_seq={3}&validate={4}&Deadline={5}&salary_lang={6}"
                    , empid, salaryYear, salaryMonth, salarySeq, validateKey, deadline, language);
            //"Payslip.aspx?salary_nobr=C11113&salary_year=2016&salary_month=07&salary_seq=2&validate=" +
            //JBModule.Data.CEncrypt.Text(DateTimeOffset.UtcNow.ToString());

            //Response.Redirect(showSalaryUrl,true);
            Server.Transfer(showSalaryUrl, false);
        }
    }
}