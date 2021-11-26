using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace SalaryWeb
{
    /// <summary>
    ///SalaryAuthenticationService 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    // [System.Web.Script.Services.ScriptService]
    public class SalaryAuthenticationService : System.Web.Services.WebService
    {
        private SalaryModel salaryModel = new SalaryModel();

        /// <param name="EmpId">工號</param>
        /// <param name="PlaintextPassword">密碼</param>
        [WebMethod(Description="驗證使用者可否存取薪資相關權限(如果沒有設定密碼此檢查是無效的)",CacheDuration=0)]
        public bool IsValied(string EmpId, string PlaintextPassword)
        {
            bool result = salaryModel.ComparePassword(EmpId, PlaintextPassword);
            return result;
        }

        /// <param name="EmpId">工號</param>
        /// <param name="PlaintextPassword">密碼</param>
        /// <returns></returns>
        [WebMethod(Description = "驗證使用者並取得可以查詢的票卡" , CacheDuration = 0)]
        public string GetTicket(string EmpId, string PlaintextPassword)
        {
            bool isValied = IsValied(EmpId, PlaintextPassword);

            if (!(isValied))
            {
                return null;
            }

            string ticket = DateTimeOffset.UtcNow.ToString();

            return ticket;
        }

        /// <param name="EmpId">工號</param>
        [WebMethod(Description="是否有初始化薪資密碼相關資訊",CacheDuration=0)]
        public bool IsNotInitial(string EmpId)
        {
            bool isExist = salaryModel.IsExistPassword(EmpId);
            return (!isExist);
        }
        
    }
}
