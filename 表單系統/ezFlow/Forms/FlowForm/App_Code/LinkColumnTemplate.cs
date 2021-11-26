using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public class LinkColumnTemplate : ITemplate
{
    private string fieldName;
    private string link_fieldName;

    //這裡的設計是在new LinkColumnTemplate時，傳入兩個String
    //fieldName表示此Column要顯示的資料欄位名稱
    //link_fieldName表示此Column滑鼠點擊時所要連結link的資料欄位名稱
    public LinkColumnTemplate(string fieldName, string link_fieldName)
    {
        this.fieldName = fieldName;
        this.link_fieldName = link_fieldName;
    }

    public void InstantiateIn(Control container)
    {
        LiteralControl l = new LiteralControl();
        l.DataBinding += new EventHandler(this.OnDataBinding);//資料綁定        
        container.Controls.Add(l);  //為模板列加入LiteralControl         
    }

    public void OnDataBinding(object sender, EventArgs e)
    {
        LiteralControl l = (LiteralControl)sender;//LiteralControl發送綁定請求 
        GridViewRow container = (GridViewRow)l.NamingContainer;

        //在此處決定了Column中，每個Row所Binding出來的資料內容
        l.Text = "<a href='" + link_fieldName + "'>" + fieldName + "</a>";
        //l.Text = "<" + ((DataRowView)container.DataItem)[link_fieldName].ToString()
        //    + "',760,420,'yes','report');>"
        //    + ((DataRowView)container.DataItem)[fieldName].ToString() + "";

    }
}