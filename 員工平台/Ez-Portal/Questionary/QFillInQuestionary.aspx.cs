using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using BL;

public partial class QFillInQuestionary : JBWebPage
{
    private QQMcq_Repo mcqRepo = new QQMcq_Repo();
    private QTplCategory_Repo tplCatRepo = new QTplCategory_Repo();
    private QDetail_Repo qDetailRepo = new QDetail_Repo();
    private QTpl_Repo tplRepo = new QTpl_Repo();

    protected void Page_Init(object sender, EventArgs e)
    {
        if (GetEncryptQueryString("Code") != null)
        {
            QAMaster_Repo mRepo = new QAMaster_Repo();
            QAMaster mObj = mRepo.GetByPk_Dlo(Convert.ToInt32(GetEncryptQueryString("Code")));
            if (mObj != null)
            {
                QTpl tplObj = tplRepo.GetByPk_Dlo(mObj.QA_Published.QTplCode);
                if (tplObj != null)
                {
                    display(mObj, tplObj);
                    displayUserInfo(mObj, tplObj);
                }
            }
        }
    }

    private void writable(bool b)
    {
        btnSave.Enabled = b;
    }

    private void checkWritable(int id)
    {
        QAMaster_Repo mRepo = new QAMaster_Repo();
        QAMaster mObj = mRepo.GetByPk_Dlo(id);
        if (mObj == null)
        {
            writable(false);
        }
        else
        {
            if (GetEncryptQueryString("Mode") != null && GetEncryptQueryString("Mode").Equals("View"))
            {
                writable(false);
                return;
            }

            if (mObj.FillFormDatetimeB <= DateTime.Now && mObj.FillFormDatetimeE >= DateTime.Now)
            {
                writable(true);
            }
            else
            {
                writable(false);
                Show("填寫問卷時間未到或已超過!!");
            }

            if ((mObj.FillerCategory.Equals("S") || mObj.FillerCategory.Equals("CU")))
            {
                if (!mObj.Nobr.Equals(Juser.Nobr) && mObj.QA_Published.IsAnonymous == false)
                {
                    writable(false);
                    Show("非本人不得填寫!!");
                    return;
                }
                else if (!mObj.Nobr.Equals(Juser.Nobr) && mObj.QA_Published.IsAnonymous == true)
                {
                    hideDisplayInfo();
                    return;
                }
            }

            //if ( mObj.FillerCategory.Equals("Supervisor") && !mObj.SupervisorNobr.Equals(Juser.Nobr) )
            //{
            //    writable(false);
            //    Show("非本人不得填寫!!");
            //    return;
            //}

            if (mObj.WriteDate.HasValue)
            {
                writable(false);
                return;
            }

            if (mObj.FillerCategory.Equals("M"))
            {
                if (!Juser.IsInRole("1"))
                {
                    writable(false);
                    Show("非系統管理者不得填寫!!");
                    return;
                }
            }
        }
    }

    private void displayUserInfo(QAMaster mObj, QTpl tplObj)
    {
        if (tplObj.FillerCategory.Equals("S") || tplObj.FillerCategory.Equals("CU") || tplObj.FillerCategory.Equals("Supervisor"))
        {
            BASE_REPO baseRepo = new BASE_REPO();
            BASE bObj = baseRepo.GetByNobr_Dlo(mObj.Nobr);
            lblName.Text = bObj.NAME_C;
            lblNobr.Text = bObj.NOBR;
            lblDept.Text = bObj.BASETTS[0].DEPT1.D_NAME;
            if (mObj.WriteDate.HasValue)
            {
                lblFillDate.Text = mObj.WriteDate.Value.ToShortDateString();
            }
        }

        if (tplObj.FillerCategory.Equals("Supervisor"))
        {
            BASE_REPO baseRepo = new BASE_REPO();
            BASE bObj = baseRepo.GetByNobr(mObj.Nobr);
            lblName.Text = bObj.NAME_C;
            lblNobr.Text = bObj.NOBR;

            if (mObj.WriteDate.HasValue)
            {
                lblFillDate.Text = mObj.WriteDate.Value.ToShortDateString();
            }
        }

        if (tplObj.FillerCategory.Equals("M"))
        {
            if (GetEncryptQueryString("Mode") != null && GetEncryptQueryString("Mode").Equals("View"))
            {
                BASE_REPO baseRepo = new BASE_REPO();
                BASE bObj = baseRepo.GetByNobr(mObj.FillInBy);
                if (bObj != null)
                {
                    lblName.Text = bObj.NAME_C;
                    lblNobr.Text = bObj.NOBR;
                }
            }
            else
            {
                lblName.Text = Juser.NameC;
                lblNobr.Text = Juser.Nobr;
            }

            if (mObj.WriteDate.HasValue)
            {
                lblFillDate.Text = mObj.WriteDate.Value.ToShortDateString();
            }
        }
    }

    private void hideDisplayInfo()
    {
        RadAjaxPanel1.Visible = false;
        RadAjaxPanel2.Visible = false;
        btnSave.Visible = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (GetEncryptQueryString("Code") != null)
                checkWritable(Convert.ToInt32(GetEncryptQueryString("Code")));
        }
    }

    private void display(QAMaster mObj, QTpl tplObj)
    {
        QADetail_Repo qaDtlRepo = new QADetail_Repo();
        List<QADetail> qaDtlList = qaDtlRepo.GetByQAMasterId(mObj.Id);
        if (tplObj.HeaderText != null && !tplObj.HeaderText.Equals(""))
        {
            lbHeader.Text = tplObj.HeaderText;
        }
        if (tplObj.FooterText != null && !tplObj.FooterText.Equals(""))
        {
            lbFooter.Text = tplObj.FooterText;
        }

        foreach (QTplCategory item in tplObj.QTplCategory.OrderBy(p => p.Sequence))
        {
            Panel p = new Panel();
            RadAjaxPanel1.Controls.Add(p);

            p.ID = item.QCategory.GetType().ToString() + item.QCategory.Code;
            p.GroupingText = item.QCategory.Name;
            p.Attributes.Add("class", "DivQCategory");

            foreach (QDetail dItem in item.QDetail.OrderBy(q => q.Sequence))
            {
                Panel tempP = new Panel();
                p.Controls.Add(tempP);
                tempP.Attributes.Add("class", "DivQItem");

                Label lbl = new Label();
                tempP.Controls.Add(lbl);
                lbl.Text = dItem.QQItem.QuestionText;

                Panel tempP2 = new Panel();
                tempP.Controls.Add(tempP2);
                tempP2.CssClass = "QQItem";

                string id = QQItem_Repo.QQItemDisplayName + dItem.QQItem.Id.ToString();
                QADetail dObj = qaDtlList.Find(q => q.QQItemId == dItem.QQItemId);

                if (dItem.QQItem.TypeCode.Equals(QQTypeEnum.MCQ.ToString()))
                {
                    RadioButtonList rbl = new RadioButtonList();
                    rbl.ID = id;
                    tempP2.Controls.Add(rbl);
                    rbl.Font.Size = 12;
                    rbl.Font.Bold = true;
                    if (dItem.QQItem.McqDisplayHorizontal)
                        rbl.RepeatDirection = RepeatDirection.Horizontal;
                    else
                        rbl.RepeatDirection = RepeatDirection.Vertical;

                    string selectedValue = "";
                    if (dItem.QQItem.QQMcq.IsValueInt)
                    {
                        if (dObj.McqIntValue.HasValue)
                            selectedValue = dObj.McqIntValue.Value.ToString();
                    }
                    else
                    {
                        if (dObj.McqStringValue != null)
                            selectedValue = dObj.McqStringValue;
                    }

                    foreach (QQMcqDetail i in dItem.QQItem.QQMcq.QQMcqDetail.OrderBy(q => q.Sequence))
                    {
                        ListItem li = new ListItem();
                        li.Text = i.Text;

                        if (i.QQMcq.IsValueInt)
                            li.Value = i.IntValue.ToString();
                        else
                            li.Value = i.StringValue;

                        if (li.Value == selectedValue)
                            li.Selected = true;

                        rbl.Items.Add(li);
                    }
                }
                else if (dItem.QQItem.TypeCode.Equals(QQTypeEnum.TFQ.ToString()))
                {
                    RadioButtonList rbl = new RadioButtonList();
                    rbl.ID = id;
                    tempP2.Controls.Add(rbl);
                    rbl.Font.Size = 12;
                    rbl.RepeatDirection = RepeatDirection.Horizontal;
                    ListItem li1 = new ListItem();
                    li1.Text = "是";
                    li1.Value = "1";
                    ListItem li2 = new ListItem();
                    li2.Text = "否";
                    li2.Value = "0";
                    rbl.Items.Add(li1);
                    rbl.Items.Add(li2);

                    if (dObj.TfqValue.HasValue)
                    {
                        if (dObj.TfqValue.Value)
                            li1.Selected = true;
                        else
                            li2.Selected = true;
                    }
                }
                //問答
                else if (dItem.QQItem.TypeCode.Equals(QQTypeEnum.SAQ.ToString()))
                {
                    TextBox tb = new TextBox();
                    tempP2.Controls.Add(tb);
                    tb.ID = id;
                    tb.Width = 800;
                    tb.TextMode = TextBoxMode.MultiLine;
                    tb.Rows = 3;
                    tb.Font.Size = 12;

                    if (dObj.SaqValue != null)
                        tb.Text = dObj.SaqValue;
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (GetEncryptQueryString("Code") != null)
        {
            int code = Convert.ToInt32(GetEncryptQueryString("Code"));
            QAMaster_Repo mRepo = new QAMaster_Repo();
            QAMaster mObj = mRepo.GetByPk_Dlo(code);
            QTpl tplObj = tplRepo.GetByPk_Dlo(mObj.QA_Published.QTplCode);
            QADetail_Repo qaDtlRepo = new QADetail_Repo(mRepo.dc);
            List<QADetail> qaDtlList = qaDtlRepo.GetByQAMasterId(mObj.Id);

            foreach (QTplCategory item in tplObj.QTplCategory.OrderBy(p => p.Sequence))
            {
                foreach (QDetail dItem in item.QDetail.OrderBy(q => q.Sequence))
                {
                    string id = QQItem_Repo.QQItemDisplayName + dItem.QQItem.Id.ToString();

                    if (dItem.QQItem.TypeCode.Equals(QQTypeEnum.MCQ.ToString()))
                    {
                        RadioButtonList rbl = RadAjaxPanel1.FindControl(id) as RadioButtonList;

                        if (rbl.SelectedItem == null)
                        {
                            if (dItem.QQItem.IsRequired)
                            {
                                Show(dItem.QQItem.QuestionText + "必須填寫!!");
                                rbl.Focus();
                                return;
                            }
                            else
                                continue;
                        }

                        QADetail dObj = qaDtlList.Find(p => p.QQItemId == dItem.QQItemId);

                        if (dItem.QQItem.QQMcq.IsValueInt)
                        {
                            dObj.McqIntValue = Convert.ToInt32(rbl.SelectedValue.ToString());
                        }
                        else
                        {
                            dObj.McqStringValue = rbl.SelectedValue.ToString();
                        }

                        qaDtlRepo.Update(dObj);
                    }
                    else if (dItem.QQItem.TypeCode.Equals(QQTypeEnum.TFQ.ToString()))
                    {
                        RadioButtonList rbl = RadAjaxPanel1.FindControl(id) as RadioButtonList;

                        if (rbl.SelectedItem == null)
                        {
                            if (dItem.QQItem.IsRequired)
                            {
                                Show(dItem.QQItem.QuestionText + "必須填寫!!");
                                rbl.Focus();
                                return;
                            }
                            else
                                continue;
                        }

                        QADetail dObj = qaDtlList.Find(p => p.QQItemId == dItem.QQItemId);

                        if (rbl.SelectedValue.Equals("1"))
                            dObj.TfqValue = true;
                        else
                            dObj.TfqValue = false;

                        qaDtlRepo.Update(dObj);
                    }
                    else if (dItem.QQItem.TypeCode.Equals(QQTypeEnum.SAQ.ToString()))
                    {
                        TextBox tb = RadAjaxPanel1.FindControl(id) as TextBox;

                        if (dItem.QQItem.IsRequired && tb.Text.Trim().Length == 0)
                        {
                            Show(dItem.QQItem.QuestionText + "為必填欄位");
                            tb.Focus();
                            return;
                        }

                        if (dItem.QQItem.MinCharCount.HasValue && tb.Text.Trim().Length < dItem.QQItem.MinCharCount.Value)
                        {
                            Show(dItem.QQItem.QuestionText + "填寫字數必須大於等於：" + dItem.QQItem.MinCharCount.Value + " 字!!");
                            tb.Focus();
                            return;
                        }

                        QADetail dObj = qaDtlList.Find(p => p.QQItemId == dItem.QQItemId);
                        dObj.SaqValue = tb.Text;
                        qaDtlRepo.Update(dObj);
                    }
                }
            }

            mObj.WriteDate = DateTime.Now;
            mObj.TotalScore = (from c in qaDtlList
                               select c.McqIntValue).Sum();

            mRepo.Update(mObj);
            qaDtlRepo.Save();

            displayUserInfo(mObj, tplObj);
            checkWritable(code);
            //RadScriptManager.RegisterStartupScript(this , typeof(Page) , this.GetType().ToString() , "CloseAndRebind('Rebind');" , true);
        }
    }
}