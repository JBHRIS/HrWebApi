using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Vdb;
using JBHRIS.Api.Service.Interface.System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flow_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsAppAbscController : ControllerBase
    {


        private IConfiguration _IConfiguration;
        private IFormsAppAbscInterface _IFormsAppAbscInterface;


        public FormsAppAbscController(IConfiguration configuration , IFormsAppAbscInterface formsAppAbscInterface)
        {
            this._IConfiguration = configuration;
            this._IFormsAppAbscInterface = formsAppAbscInterface;
            
        }



        /// <summary>
        /// 取得銷假單List
        /// </summary>
        /// <param name="Nobr"></param>
        /// <param name="BDate"></param>
        /// <param name="EDate"></param>
        [HttpGet]
        [Route("GetFormAppAbsc")]
        public ApiResult<List<AbsenceCancelDto>> GetFormAppAbsc(string Nobr, DateTime BDate, DateTime EDate)
        {
            //string apiBaseUrl = this._IConfiguration.GetValue<string>("HostAPI");
            //string ClientId = this._IConfiguration.GetValue<string>("ClientId");



            


            ApiResult<List<AbsenceCancelDto>> apiResult = new ApiResult<List<AbsenceCancelDto>>();


            
                apiResult.State = true;
                apiResult.Message= "";
                apiResult.StackTrace = "";
                apiResult.Result = new  List<AbsenceCancelDto >();


            AbsenceCancelDto dto = new AbsenceCancelDto();
            dto.ProcessId = "a0";
            dto.idProcess = 0;
             dto.EmployeeID = "A0550";
            dto.EmployeeName = "許OO";
            dto.HolidayCode = "B";
            dto.HolidayName = "事假";
            dto.BeginDate = new DateTime(2021, 3, 1, 8, 0, 0);
            dto.EndDate = new DateTime(2021, 3, 1, 17, 0, 0);
            dto.AbsenceAmount = 8;
            dto.AbsenceUnit = "小時";

            apiResult.Result.Add(dto);
            dto.ProcessId = "a1";
            dto.idProcess = 1;
            dto.EmployeeID = "A0550";
            dto.EmployeeName = "許OO";
            dto.HolidayCode = "C";
            dto.HolidayName = "病假";
            dto.BeginDate = new DateTime(2021, 3, 2, 9, 0, 0);
            dto.EndDate = new DateTime(2021, 3, 2, 18, 0, 0);
            dto.AbsenceAmount = 8;
            dto.AbsenceUnit = "小時";

            apiResult.Result.Add(dto);

            return apiResult;




          
        }




        /// <summary>
        /// 取得銷假單明細
        /// </summary>
        /// <param name="ProcessFlowID"></param>
        /// <param name="Sign"></param>
        /// <param name="SignState"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFormsAppAbsByProcessId")]
        public ApiResult<AbsFlowAppRow> GetFormsAppAbscByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            ApiResult<AbsFlowAppRow> mapiResult = new ApiResult<AbsFlowAppRow>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._IFormsAppAbscInterface.GetFormsAppAbsByProcessId(ProcessFlowID, Sign, SignState, Status);
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }




        #region 別刪掉呼叫 hrweb api 要用到 請先確認好參數
        //using (HttpClient client = new HttpClient())
        //{
        //    //StringContent content = new StringContent("", Encoding.UTF8, "application/json");
        //    //string endpoint = "https://localhost:5001/WeatherForecast";//apiBaseUrl + "/login";

        //    //httpget
        //    //client.BaseAddress  = new Uri("https://localhost:5001/");
        //    //var responseTask = client.GetAsync("WeatherForecast");
        //    //var result = responseTask.Result;
        //    //if (result.IsSuccessStatusCode)
        //    //{
        //    //    var readTask = result.Content.ReadAsAsync<IList<WeatherForecast>>();
        //    //    readTask.Wait();

        //    //    var  AA = readTask.Result;
        //    //}

        //    //httppost


        //    //var response = await client.PostAsync("https://192.168.1.46/HRWebApi/api/Token/ClientGetToken", new StringContent("JbFlow"));
        //    //var content = await response.Content.ReadAsStringAsync();



        //    //ClientIdDto dto = new ClientIdDto();
        //    //dto.ClientId = ClientId;

        //    //var str = JsonConvert.SerializeObject("JbFlow");

        //    //HttpContent content = new StringContent(str);


        //    //content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        //    //HttpResponseMessage response = await client.PostAsync(string.Format("http://192.168.1.46/HRWebApi/api/Token/ClientGetToken?ClientId={0}", ClientId), content);//改成自己的
        //    //response.EnsureSuccessStatusCode();//用来抛异常的
        //    //string responseBody = await response.Content.ReadAsStringAsync();


        //    //return content;

        //    //client.BaseAddress = new Uri("");
        //    //var responseTask = client.PostAsync("ClientId", ClientId);
        //    //responseTask.Wait();
        //    //var token = responseTask.Result;

        //    //client.Dispose();

        //    //AbsenceEntry rd = new AbsenceEntry();
        //    //rd.EmployeeList = new List<string>();
        //    //rd.EmployeeList.Add("A0198");
        //    //rd.HcodeList = new List<string>();
        //    //rd.HcodeList.Add("A");
        //    //rd.DateBegin = new DateTime(2020, 10, 1);
        //    //rd.DateEnd = new DateTime(2020, 10, 30);

        //    ////client.BaseAddress = new Uri("http://192.168.1.46/HRWebApi/api/Absence/GetAbsenceCancel");
        //    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiIxZjUxZjc0ZC0yNTVlLTQwMGEtOWNhNi02MmUxZDlmMTllYmQiLCJ1bmlxdWVfbmFtZSI6IkEwNTUwIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy91c2VyZGF0YSI6IntcIlVzZXJJZFwiOlwiQTA1NTBcIixcIlVzZXJOYW1lXCI6XCLoqLHlkI3nkaRcIixcIkNvbXBhbnlcIjpcIkhcIixcIkRlcGFydG1lbnRcIjpcIkgtTTEwMDEwXCIsXCJEZXBhcnRtZW50TmFtZVwiOlwi5Lq66LOH57WEXCIsXCJKb2JcIjpcIkZcIixcIkpvYk5hbWVcIjpcIuS4u-S7u1wiLFwiRGF0YUdyb3Vwc1wiOltcIkFcIixcIkJcIixcIkhcIixcIlNcIl19Iiwicm9sZSI6IkFkbWluIiwibmJmIjoxNjE2MDU4MDgwLCJleHAiOjE2MTYwNTk4ODAsImlhdCI6MTYxNjA1ODA4MCwiaXNzIjoiSHJfV2ViQXBpIn0.1hLnXx99KpzmvQdhoryJqqeEiGqI_jBs7zBt4IXkmhg");
        //    ////var postTask = client.PostAsJsonAsync<AbsenceEntry>("AbsenceEntry", rd);

        //    ////postTask.Wait();

        //    ////var result = postTask.Result;


        //    //string URI = "http://192.168.1.46/HRWebApi/api/Absence/GetAbsenceCancel";
        //    //client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");

        //    //var str = JsonConvert.SerializeObject(rd);

        //    //var response = client.PostAsync(URI, new StringContent(str, Encoding.UTF8, "application/json"));
        //    //var result = response.Result;

        //    //string responseBody = await response..ReadAsStringAsync();


        //    //List<BusinessUnit> businessunits = JsonConvert.DeserializeObject<List<BusinessUnit>>(result);



        //    //return this 


        //    //List<AbscRowsDto> mAbscRowsDtos = JsonConvert.DeserializeObject<List<AbscRowsDto>>("");

        //    //foreach (var row1 in mAbscRowsDtos)
        //    //{
        //    //    List<AbscDto> md = new List<AbscDto>();

        //    //    TimeIntervalDto rdDto = new TimeIntervalDto();
        //    //    var mList = mAbscRowsDtos.GroupBy(m => new { m.BeginDate, m.EndDate }).ToList();
        //    //    foreach (var rdlist in mList)
        //    //    {


        //    //        //rdDto.HolidayCode =rdlist.

        //    //    }

        //    //    //mapiResult.Result = new List<AbscDto>();
        //    //    mapiResult.State = true;
        //    //    mapiResult.Message = "";
        //    //}



        //}



        //mapiResult.State = false;
        //try
        //{
        //    mapiResult.State = true;

        //}
        //catch (Exception)
        //{
        //    mapiResult.State = false;
        //}

        #endregion





        //private class ClientIdDto
        //{
        //    public string ClientId { get; set; }
        //}




        //private class AbscRowsDto
        //{

        //    public string EmployeeID { get; set; }

        //    public string EmployeeName { get; set; }

        //    public DateTime BeginDate { get; set; }

        //    public DateTime EndDate { get; set; }

        //    public string HolidayCode { get; set; }

        //    public string HolidayName { get; set; }

        //    public string BeginTime { get; set; }

        //    public string EndTime { get; set; }

        //    public int AbsenceAmount { get; set; }

        //    public string AbsenceUnit { get; set; }


        //}

        //private class AbscDto
        //{ 

        //    public string EmployeeID { get; set; }

        //    public string EmployeeName { get; set; }

        //    public DateTime BeginDate { get; set; }

        //    public DateTime EndDate { get; set; }
        //            public List<TimeIntervalDto> TimeInterval { get; set; }
        //}




        //private class TimeIntervalDto
        //{ 
        //    public string HolidayCode { get; set; }

        //    public string HolidayName { get; set; }

        //    public string BeginTime { get; set; }

        //    public string EndTime { get; set; }

        //    public int AbsenceAmount { get; set; }

        //    public string AbsenceUnit { get; set; }



        //}








        //    private class AbsenceEntry
        //{
        //    /// <summary>
        //    /// 員工編號清單
        //    /// </summary>
        //    public List<string> EmployeeList { get; set; }
        //    /// <summary>
        //    /// 假別代碼清單
        //    /// </summary>
        //    public List<string> HcodeList { get; set; }
        //    /// <summary>
        //    /// 請假日期起
        //    /// </summary>
        //    public DateTime DateBegin { get; set; }
        //    /// <summary>
        //    /// 請假日期迄
        //    /// </summary>
        //    public DateTime DateEnd { get; set; }
        //}




    }
}
