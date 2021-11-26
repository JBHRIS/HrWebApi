using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.IO;

/// <summary>
/// Flow 的摘要描述
/// </summary>
public class Flow
{
    public Flow()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public static IQueryable<wfForm> FormDefault(string sFormCode)
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();
        IQueryable<wfForm> dtForm = from c in dcFlow.wfForm where c.sFormCode == sFormCode select c;
        return dtForm;
    }

    //利用ApView及ApParm取得ProcessID
    public static int GetProcessID(string RequestName, int RequestValue)
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();

        IQueryable<int> ApParm = from c in dcFlow.ProcessApParm where c.auto == RequestValue select c.ProcessFlow_id.Value;
        IQueryable<int> ApView = from c in dcFlow.ProcessApView where c.auto == RequestValue select c.ProcessFlow_id.Value;

        return (RequestName == "ApParm") ? Convert.ToInt32(ApParm.FirstOrDefault()) : Convert.ToInt32(ApView.FirstOrDefault());
    }

    //利用ProcessID取得ApView或ApParm
    public static int GetViewID(int ProcessID, string cat)
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();

        IQueryable<int> ApParm = from c in dcFlow.ProcessApParm where c.ProcessFlow_id == ProcessID select c.auto;
        IQueryable<int> ApView = from c in dcFlow.ProcessApView where c.ProcessFlow_id == ProcessID select c.auto;

        return (cat == "ApParm") ? Convert.ToInt32(ApParm.FirstOrDefault()) : Convert.ToInt32(ApView.FirstOrDefault());
    }

    //設定預設代理人
    public static void SetCheckAgentDefault(string sNobrSource, string sNobrTarget, DateTime dDateTimeB, DateTime dDateTimeE)
    {
        dcFlowDataContext dc = new dcFlowDataContext();

        var rEmp = (from c in dc.Emp
                    where c.id == sNobrSource
                    select c).FirstOrDefault();

        var rSource = (from c in dc.Role
                       where c.Emp_id == sNobrSource
                       select c).FirstOrDefault();

        var rTarget = (from c in dc.Role
                       where c.Emp_id == sNobrTarget
                       select c).FirstOrDefault();

        if (rEmp != null && rSource != null && rTarget != null)
        {
            var rAgent = (from c in dc.CheckAgentDefault
                          where c.Emp_idSource == sNobrSource
                          select c).FirstOrDefault();

            if (rAgent == null)
            {
                rAgent = new CheckAgentDefault();
                JBHR.Dll.Tools.SetRowDefaultValue(rAgent);
                dc.CheckAgentDefault.InsertOnSubmit(rAgent);
            }

            rAgent.Emp_idSource = rSource.Emp_id;
            rAgent.Role_idSource = rSource.id;
            rAgent.Emp_idTarget1 = rTarget.Emp_id;
            rAgent.Role_idTarget1 = rTarget.id;

            rEmp.isNeedAgent = true;
            rEmp.dateB = dDateTimeB;
            rEmp.dateE = dDateTimeE;

            dc.SubmitChanges();
        }
    }

    public static void SendMail(string to, string subject, string body)
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();
        var rVar = (from c in dcFlow.SysVar select c).FirstOrDefault();

        if (rVar != null)
        {

            string mailServerName = rVar.mailServer;
            string from = rVar.senderMail;
            bool isUseDefaultCredentials = true;
            string strFrom = rVar.mailID;
            string strFromPass = rVar.mailPW;

            body += "<br><br><font color='red'>此信件為系統自動寄送，請勿直接回信，同仁若有疑問請直接洽業務承辦人員辦理，謝謝您！</font>";

            JBHR.Dll.Tools.SendMailThread(mailServerName, from, isUseDefaultCredentials, strFrom, strFromPass, to, subject, body);
        }
    }

    //匯出xls
    public static void ExportXls(GridView gv)
    {
        string FileName = gv.ID + "-" + Guid.NewGuid().ToString() + ".xls";

        for (int i = 0; i < gv.Rows.Count; i++)
            for (int j = 0; j < gv.Columns.Count - 1; j++)
                gv.Rows[i].Cells[j].Attributes.Add("class", "xlString");

        System.Web.HttpContext.Current.Response.Clear();
        System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
        System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
        gv.RenderControl(htmlWrite);
        string strStyle = "<style>.xlString { mso-number-format:\\@; } </style>";
        System.Web.HttpContext.Current.Response.Write(strStyle);
        System.Web.HttpContext.Current.Response.Write(stringWrite.ToString());
        System.Web.HttpContext.Current.Response.End();
    }

    public static void transHtml(string path, string outpath)
    {
        System.Web.UI.Page page = new System.Web.UI.Page();
        StringWriter writer = new StringWriter();
        page.Server.Execute(path, writer);

        FileStream fs;

        fs = File.Create(page.Server.MapPath(outpath));
        byte[] bt = System.Text.Encoding.Default.GetBytes(writer.ToString());
        fs.Write(bt, 0, bt.Length);
        fs.Flush();
        fs.Close();
    }
}