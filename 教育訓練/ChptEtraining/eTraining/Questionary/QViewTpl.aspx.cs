using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Telerik.Web.UI;
using Repo;

public partial class eTraining_Questionary_QViewTpl:JBWebPage
{
    private QQMcq_Repo mcqRepo = new QQMcq_Repo();
    private QTplCategory_Repo tplCatRepo = new QTplCategory_Repo();
    private QDetail_Repo qDetailRepo = new QDetail_Repo();
    private QTpl_Repo tplRepo = new QTpl_Repo();

    protected void Page_Init(object sender , EventArgs e)
    {
        if ( !IsPostBack )
        {
            if ( Request.QueryString["Code"] != null )
            {
                QTpl tplObj = tplRepo.GetByPk_Dlo(Request.QueryString["Code"]);
                if ( tplObj != null )
                {
                    display(tplObj);
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void display(QTpl tplObj)
    {
        foreach ( QTplCategory item in tplObj.QTplCategory.OrderBy(p=>p.Sequence) )
        {
            Panel p = new Panel();
            p.ID = item.QCategory.GetType().ToString() + item.QCategory.Code;
            p.GroupingText = item.QCategory.Name;
            p.Attributes.Add("class", "DivQCategory");
            RadAjaxPanel1.Controls.Add(p);

            foreach ( QDetail dItem in item.QDetail.OrderBy(q=>q.Sequence) )
            {
                Panel tempP = new Panel();
                tempP.Attributes.Add("class", "DivQItem");    
                Label lbl = new Label();
                lbl.Text=dItem.QQItem.QuestionText;
                tempP.Controls.Add(lbl);
                Panel tempP2 = new Panel();

                if ( dItem.QQItem.TypeCode.Equals(QQTypeEnum.MCQ.ToString()) )
                {
                    RadioButtonList rbl = new RadioButtonList();
                    //rbl.ID = dItem.QQItem.QQType.GetType().ToString() + dItem.QQItem.Id.ToString();
                    rbl.ID = QQItem_Repo.QQItemDisplayName + dItem.QQItem.Id.ToString();
                    if(dItem.QQItem.McqDisplayHorizontal)
                        rbl.RepeatDirection = RepeatDirection.Horizontal;
                    else
                        rbl.RepeatDirection = RepeatDirection.Vertical;

                    foreach (QQMcqDetail i in dItem.QQItem.QQMcq.QQMcqDetail.OrderBy(q => q.Sequence))
                    {
                        ListItem li = new ListItem();
                        li.Text = i.Text;

                        if (i.QQMcq.IsValueInt)
                            li.Value = i.IntValue.ToString();
                        else
                            li.Value = i.StringValue;

                        rbl.Items.Add(li);
                    }

                    tempP2.Controls.Add(rbl);
                }
                else if ( dItem.QQItem.TypeCode.Equals(QQTypeEnum.TFQ.ToString()) )
                {
                    RadioButtonList rbl = new RadioButtonList();
                    rbl.ID = QQItem_Repo.QQItemDisplayName + dItem.QQItem.Id.ToString();

                    rbl.RepeatDirection = RepeatDirection.Horizontal;
                    ListItem li1 = new ListItem();
                    li1.Text = "是";
                    li1.Value = "1";
                    ListItem li2 = new ListItem();
                    li2.Text = "否";
                    li2.Value = "0";
                    rbl.Items.Add(li1);
                    rbl.Items.Add(li2);
                    tempP2.Controls.Add(rbl);
                }
                else if ( dItem.QQItem.TypeCode.Equals(QQTypeEnum.SAQ.ToString()) )
                {
                    TextBox tb = new TextBox();
                    tb.ID = QQItem_Repo.QQItemDisplayName + dItem.QQItem.Id.ToString();
                    tb.Width = 800;
                    tempP2.Controls.Add(tb);
                }

                tempP.Controls.Add(tempP2);
                p.Controls.Add(tempP);
            }
        }

    }
}