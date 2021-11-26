using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;

namespace SalaryWeb
{
    /// <summary>
    /// Handler1 的摘要描述
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        BasClass bc = new BasClass();

        public void ProcessRequest(HttpContext context)
        {
            string selectName = context.Request.QueryString["name"] as string;
            context.Response.ContentType = "text/html";
            //context.Response.Write("<p style='color:#ff0000;'>Hello World</p>");

            var result_dt = bc.Get_LockWage("G00521");

            var test = result_dt.AsEnumerable().Select(o => new
            {
                year = o.Field<string>("sYear")
                ,
                month = o.Field<string>("sMonth")
                ,
                Seq = o.Field<string>("Seq")
                ,
                Note = o.Field<string>("Meno")
            }).ToList();


            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("<select name='{0}' id='tsettttt'>", selectName??string.Empty));
            foreach (var t in test.GroupBy(o => o.year).OrderByDescending(o => o.Key))
            {
                string year = t.Key;
                sb.Append(string.Format("<optgroup label='{0}'>",year));
                foreach (var u in t)
                {
                    string option = string.Format("<option value='{0}:{1}:{2}'>{3}</option>",u.year,u.month,u.Seq,u.Note);
                    sb.Append(option);
                }
                sb.Append(string.Format("</optgroup>"));
            }
            sb.Append("</select>");
            
            context.Response.Write(sb.ToString());

        }

     

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}