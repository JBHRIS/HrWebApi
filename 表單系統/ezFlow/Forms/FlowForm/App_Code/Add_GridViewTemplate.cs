using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public class Add_GridViewTemplate : ITemplate
{
    private DataControlRowType u_Type;
    private string column_title;
    private string cn;
    private string ca;
    private string text;

    public Add_GridViewTemplate(DataControlRowType type, string colname, string cn, string ca, string text)
    {
        this.u_Type = type;
        this.column_title = colname;
        this.cn = cn;
        this.ca = ca;
        this.text = text;
    }

    public void InstantiateIn(System.Web.UI.Control container)
    {   // ITemplate只有一個 InstantiateIn()方法，此方法需要輸入一個控制項
        // 當實作Class時，定義子控制項和樣板所屬的 Control 物件。這些子控制項依次定義在內嵌樣板內。
        switch (u_Type)
        {
            case DataControlRowType.Header:  // GridView表頭
                Literal literal1 = new Literal();
                literal1.Text = column_title;
                container.Controls.Add(literal1);
                break;
            case DataControlRowType.DataRow:  // Gridview資料列
                LinkButton lbtn = new LinkButton();
                lbtn.ID = column_title;
                lbtn.CommandName = cn;
                lbtn.CommandArgument = ca;
                lbtn.Text = text;
                container.Controls.Add(lbtn);
                break;

            default:
                break;
        }
    }
}