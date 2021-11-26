using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections.Generic;

public partial class HR_UpBaseCon : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lb_nobr.Text = JbUser.NOBR;



        }
    }
    protected void UpButton_Click(object sender, EventArgs e)
    {
        //SqlDataSource1.Update();      

    }

    protected void FormView1_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        e.NewValues["BORN_ADDR"] = e.OldValues["BORN_ADDR"];
        if (!e.OldValues[0].ToString().Trim().Equals(e.NewValues[0].ToString().Trim()))
            lb_updescr.Text = "手機資料是為：" + e.OldValues[0].ToString().Trim() + "改為：" + e.NewValues[0].ToString().Trim() + ";<br>";
        if (!e.OldValues[1].ToString().Trim().Equals(e.NewValues[1].ToString().Trim()))
            lb_updescr.Text += "E-Mail資料是為：" + e.OldValues[1].ToString().Trim() + "改為：" + e.NewValues[1].ToString().Trim() + ";<br>";
        if (!e.OldValues[2].ToString().Trim().Equals(e.NewValues[2].ToString().Trim()))
            lb_updescr.Text += "戶籍電話資料是為：" + e.OldValues[2].ToString().Trim() + "改為：" + e.NewValues[2].ToString().Trim() + ";<br>";
        if (!e.OldValues[3].ToString().Trim().Equals(e.NewValues[3].ToString().Trim()))
            lb_updescr.Text += "通訊電話資料是為：" + e.OldValues[3].ToString().Trim() + "改為：" + e.NewValues[3].ToString().Trim() + ";<br>";
        if (!e.OldValues[4].ToString().Trim().Equals(e.NewValues[4].ToString().Trim()))
            lb_updescr.Text += "戶籍郵政區號資料是為：" + e.OldValues[4].ToString().Trim() + "改為：" + e.NewValues[4].ToString().Trim() + ";<br>";

        if (!e.OldValues[5].ToString().Trim().Equals(e.NewValues[5].ToString().Trim()))
            lb_updescr.Text += "戶籍地址資料是為：" + e.OldValues[5].ToString().Trim() + "改為：" + e.NewValues[5].ToString().Trim() + ";<br>";
        if (!e.OldValues[6].ToString().Trim().Equals(e.NewValues[6].ToString().Trim()))
            lb_updescr.Text += "通訊地址區號地址資料是為：" + e.OldValues[6].ToString().Trim() + "改為：" + e.NewValues[6].ToString().Trim() + ";<br>";
        if (!e.OldValues[7].ToString().Trim().Equals(e.NewValues[7].ToString().Trim()))
            lb_updescr.Text += "通訊地址資料是為：" + e.OldValues[7].ToString().Trim() + "改為：" + e.NewValues[7].ToString().Trim() + ";<br>";
        if (!e.OldValues[8].ToString().Trim().Equals(e.NewValues[8].ToString().Trim()))
            lb_updescr.Text += "戶籍地是為：" + e.OldValues[8].ToString().Trim() + "改為：" + e.NewValues[8].ToString().Trim() + ";<br>";
        if (!e.OldValues[9].ToString().Trim().Equals(e.NewValues[9].ToString().Trim()))
            lb_updescr.Text += "出生地是為：" + e.OldValues[9].ToString().Trim() + "改為：" + e.NewValues[9].ToString().Trim() + ";<br>";

        if (!e.OldValues["CONT_MAN"].ToString().Trim().Equals(e.NewValues["CONT_MAN"].ToString().Trim()))
            lb_updescr.Text += "連絡人1姓名資料是為：" + e.OldValues["CONT_MAN"].ToString().Trim() + "改為：" + e.NewValues["CONT_MAN"].ToString().Trim() + ";<br>";
        if (!e.OldValues["CONT_REL1"].ToString().Trim().Equals(e.NewValues["CONT_REL1"].ToString().Trim()))
            lb_updescr.Text += "連絡人1關係資料是為：" + e.OldValues["CONT_REL1"].ToString().Trim() + "改為：" + e.NewValues["CONT_REL1"].ToString().Trim() + ";<br>";

        if (!e.OldValues["CONT_TEL"].ToString().Trim().Equals(e.NewValues["CONT_TEL"].ToString().Trim()))
            lb_updescr.Text += "連絡人1電話資料是為：" + e.OldValues["CONT_TEL"].ToString().Trim() + "改為：" + e.NewValues["CONT_TEL"].ToString().Trim() + ";<br>";

        if (!e.OldValues["CONT_GSM"].ToString().Trim().Equals(e.NewValues["CONT_GSM"].ToString().Trim()))
            lb_updescr.Text += "連絡人1行動電話資料是為：" + e.OldValues["CONT_GSM"].ToString().Trim() + "改為：" + e.NewValues["CONT_GSM"].ToString().Trim() + ";<br>";

        if (!e.OldValues["CONT_MAN2"].ToString().Trim().Equals(e.NewValues["CONT_MAN2"].ToString().Trim()))
            lb_updescr.Text += "連絡人2姓名資料是為：" + e.OldValues["CONT_MAN2"].ToString().Trim() + "改為：" + e.NewValues["CONT_MAN2"].ToString().Trim() + ";<br>";

        if (!e.OldValues["CONT_REL2"].ToString().Trim().Equals(e.NewValues["CONT_REL2"].ToString().Trim()))
            lb_updescr.Text += "連絡人2關係資料是為：" + e.OldValues["CONT_REL2"].ToString().Trim() + "改為：" + e.NewValues["CONT_REL2"].ToString().Trim() + ";<br>";

        if (!e.OldValues["CONT_TEL2"].ToString().Trim().Equals(e.NewValues["CONT_TEL2"].ToString().Trim()))
            lb_updescr.Text += "連絡人2電話資料是為：" + e.OldValues["CONT_TEL2"].ToString().Trim() + "改為：" + e.NewValues["CONT_TEL"].ToString().Trim() + ";<br>";

        if (!e.OldValues["CONT_GSM2"].ToString().Trim().Equals(e.NewValues["CONT_GSM2"].ToString().Trim()))
            lb_updescr.Text += "連絡人2行動電話資料是為：" + e.OldValues["CONT_GSM2"].ToString().Trim() + "改為：" + e.NewValues["CONT_GSM2"].ToString().Trim() + ";<br>";


        if (e.NewValues["GSM"].ToString().Trim().Equals(""))
        {
            e.NewValues["GSM"] = " ";
        }

        if (e.NewValues["CONT_MAN"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_MAN"] = " ";
        }
        if (e.NewValues["CONT_GSM"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_GSM"] = " ";
        }
        if (e.NewValues["CONT_REL1"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_REL1"] = " ";
        }
        if (e.NewValues["CONT_GSM"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_GSM"] = " ";
        }
        if (e.NewValues["CONT_MAN2"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_MAN2"] = " ";
        }
        if (e.NewValues["CONT_REL2"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_REL2"] = " ";
        }
        if (e.NewValues["CONT_TEL"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_TEL"] = " ";
        }
        if (e.NewValues["CONT_TEL2"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_TEL2"] = " ";
        }
        if (e.NewValues["CONT_GSM2"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_GSM2"] = " ";
        }
        if (e.NewValues["POSTCODE1"].ToString().Trim().Equals(""))
        {
            e.NewValues["POSTCODE1"] = " ";
        }
        if (e.NewValues["POSTCODE2"].ToString().Trim().Equals(""))
        {
            e.NewValues["POSTCODE2"] = " ";
        }
        if (e.NewValues["TEL1"].ToString().Trim().Equals(""))
        {
            e.NewValues["TEL1"] = " ";
        }
        if (e.NewValues["TEL2"].ToString().Trim().Equals(""))
        {
            e.NewValues["TEL2"] = " ";
        }

        if (lb_updescr.Text.Trim().Length <= 0)
        {
            e.Cancel = true;
            JB.WebModules.Message.Show("資料未修改！");
            return;

        }

        HRDsTableAdapters.UpBaseRecordTableAdapter rv_upbasecon = new HRDsTableAdapters.UpBaseRecordTableAdapter();
        HRDs.UpBaseRecordDataTable rv_upbaseconDs = new HRDs.UpBaseRecordDataTable();
        HRDs.UpBaseRecordRow newrow = rv_upbaseconDs.NewUpBaseRecordRow();
        newrow.nobr = lb_nobr.Text;
        newrow.updescr = lb_updescr.Text;
        newrow.name_c = JbUser.NAME_C;
        newrow.key_date = DateTime.Now;
        rv_upbaseconDs.AddUpBaseRecordRow(newrow);
        rv_upbasecon.Update(rv_upbaseconDs);

        JB.WebModules.Message.Show("修改完成！！");
    }
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {

    }
    protected void CONT_REL1_DataBound(object sender, EventArgs e)
    {
        //DropDownList DDL = (DropDownList)sender;
        //DDL.Items.Insert(0, new ListItem("", ""));
    }
    protected void CONT_REL2_PreRender(object sender, EventArgs e)
    {
        //DropDownList DDL = (DropDownList)sender;
        //DDL.Items.Insert(0, new ListItem("", ""));
    }
    protected void CONT_REL1_DataBinding(object sender, EventArgs e)
    {
        //DropDownList DDL = (DropDownList)sender;
        // DDL.Items.Insert(0, new ListItem("", ""));
    }
}
