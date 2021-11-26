using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using SalaryWeb.Models;

namespace SalaryWeb
{
    /// <summary>
    ///WebServiceProvide 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceProvide : System.Web.Services.WebService
    {
        private BasClass bc = new BasClass();
        [WebMethod(MessageName="取得個人薪資單相關年月週期資料")]
        public List<PayslipYearMonthSeqDDLInfo> PayslipYMSInfos(string EmpId)
        {
            //BasClass bc = new BasClass();
            var result_dt = bc.Get_LockWage(EmpId);

            var handle_result = result_dt.AsEnumerable().Select(o => new PayslipYearMonthSeqDDLInfo
            {
                Year = o.Field<string>("sYear")
                ,
                Month = o.Field<string>("sMonth")
                ,
                Seq = o.Field<string>("Seq")
                ,
                Note = o.Field<string>("Meno")
            }).ToList();

            return handle_result;
        }

        //[WebMethod(MessageName="取得年所得週期資料")]
        private List<TaxSatementDDLInfo> TaxSatementInfos(string EmpId)
        {
            var result = bc.Get_LockIncome();

            /// Todo 年度所得TaxSatement年度查詢條件,sValue=>年,sText=>備註說明
            var handle_result = result.AsEnumerable().Select(o => new TaxSatementDDLInfo
            {
                Text = o.Field<string>("sText")   
                ,
                Value = o.Field<int>("sValue").ToString()
            }).ToList();
                
            return handle_result;
        }

        //[WebMethod(MessageName="取得保險週期資訊")]
        private List<InsCertificateDDLInfo> InsCertificateInfos(string EmpId)
        {
            /// Todo 保費證明單InsCertificate年度查詢條件,sValue=>年,sText=>備註說明
            var result = bc.Get_LockInsurance();

            var handl_result = result.AsEnumerable().Select(o => new InsCertificateDDLInfo
            {
                Text = o.Field<string>("sText"),
                Value = o.Field<int>("sValue").ToString()
            }).ToList();
            
            return handl_result;
        }
    }
}
