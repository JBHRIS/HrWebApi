using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// gv 的摘要描述
/// </summary>
public class gvCS
{
	public gvCS()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public static void RowDataBoundColorChange(GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //滑鼠移至資料列上的顏色
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFC0FF'");
            //滑鼠點擊後變色
            e.Row.Attributes.Add("onclick", "this.style.backgroundColor='#FF9933'");
            //e.Row.Attributes.Add("onclick", "window.location.href='Login.aspx'");
            if (e.Row.RowState == DataControlRowState.Alternate)
            {
                //滑鼠離開資料列上的顏色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White'");
            }
            else if (e.Row.RowState == DataControlRowState.Normal)
            {
                //滑鼠離開資料列上的顏色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#EFF3FB'");
            }
        }
    }

    //匯出xls
    public static void ExportXls(GridView gv)
    {
        string FileName = gv.ID + "-" + DateTime.Now.Ticks.ToString("X") + ".xls";

        //for(int i = 0; i < gv.Rows.Count; i++) {
        //    for(int j = 0; j < gv.Columns.Count - 1; j++) {
        //        gv.Rows[i].Cells[j].Attributes.Add("class", "xlString");
        //    }
        //}

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
}
