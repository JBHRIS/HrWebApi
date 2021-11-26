using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SalaryWeb.Models;

namespace SalaryWeb
{
    public partial class ExtendPage : System.Web.UI.Page
    {
        private const string _ValidateQueryStringName = "validate";
        
        //private const string ErrorPageUriWithMsgParameter = "Error.aspx?message=";

        private const string ErrorPageName = "Error.aspx";
        private const string ErrorPageMessageParameter = "message";


        private string combineErrorUriStr(string message)
        {
            string outputStr = string.Empty;
            outputStr = ErrorPageName + "?" + ErrorPageMessageParameter + "=" + message;
            return outputStr;

        }
        protected override void OnPreInit(EventArgs e)
        {
            if (isSkipValidate())
            {
                return;
            }

            string message = string.Empty;


            message = isValidForTimeSpan();

            if ((!string.IsNullOrWhiteSpace(message)))
            {
                Response.Redirect(combineErrorUriStr(message));
            }
            
            base.OnPreInit(e);
        }

        /// <summary>
        /// 是否跳過相關驗證手續
        /// </summary>
        private bool isSkipValidate()
        {
            const string SkipValidateName = "skipValidate";
            bool isSkip = (Request.QueryString[SkipValidateName] as string) != null;
            return isSkip;
        }

        private string isValidForTimeSpan()
        {
            
            string message = string.Empty;

            string encryptDataStr = Request.QueryString[_ValidateQueryStringName] as string;

            // 驗證安全參數是否存在
            if (string.IsNullOrWhiteSpace(encryptDataStr))
            {
                message = "無驗證資料";
                return message;
            }



            string dateStr = string.Empty;
            DateTimeOffset currentDateTimeOffset = DateTimeOffset.UtcNow;

            try
            {
                //dateStr = JBModule.Data.CDecryp.Text(encryptDataStr);
                dateStr =   CipherTool.DecryptText(encryptDataStr);
            }
            catch
            {
                message = "驗證碼JBModule decode fail";
                return message;
            }


            DateTimeOffset senderDateTimeOffset;

            // 驗證參數是否可以解析(是否合法參數)
            bool canParseSenderDateTimeOffset = DateTimeOffset.TryParse(dateStr, out senderDateTimeOffset);
            
            if ((!canParseSenderDateTimeOffset))
            {
                message = "無法解析驗證資訊";
                return message;
            }

            // To  UTC datetomeoffset
            senderDateTimeOffset = senderDateTimeOffset.ToUniversalTime();
            

            TimeSpan diffTimeSpan = currentDateTimeOffset - senderDateTimeOffset;

            //diffTimeSpan.TotalSeconds

            double totlaSecs = diffTimeSpan.TotalSeconds;

            if (totlaSecs >= Config.ValidateUpperUpperbound())
            {
                message = "Ticket is expired";
                return message;
            }

            return message;
        }
    }
}