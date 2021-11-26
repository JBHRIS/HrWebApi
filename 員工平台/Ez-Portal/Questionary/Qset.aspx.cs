using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using BL;
using Telerik.Web.UI;

public partial class eTraining_Questionary_QSet : JBWebPage
{
    private QQMcq_Repo mcqRepo = new QQMcq_Repo();
    private QTplCategory_Repo tplCatRepo = new QTplCategory_Repo();
    private QDetail_Repo qDetailRepo = new QDetail_Repo();
    private QQItem_Repo qqItemRepo = new QQItem_Repo();

    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gv);

        if (!IsPostBack)
            initCcbTplCat();
    }

    private void initCcbTplCat()
    {
        if (Request.QueryString["Code"] == null)
            throw new ApplicationException("傳入參數錯誤");
        cbbTplCat.DataSource = (from c in tplCatRepo.GetByTplCode_Dlo(Request.QueryString["Code"].ToString())
                                select new
                                {
                                    c.Id,
                                    c.QCategory.Name
                                }).ToList();
        cbbTplCat.DataBind();

        if (cbbTplCat.SelectedItem != null)
        {
            cbbTplCat_SelectedIndexChanged(this,
        new RadComboBoxSelectedIndexChangedEventArgs(cbbTplCat.SelectedItem.Text, "", cbbTplCat.SelectedValue, ""));
        }
    }

    protected void gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        QQItem_Repo qqItemRepo = new QQItem_Repo();
        List<QsetPageView> list = new List<QsetPageView>();
        if (e.RebindReason == GridRebindReason.InitialLoad || e.RebindReason == GridRebindReason.ExplicitRebind)
        {
            List<QDetail> qDetailList = new List<QDetail>();

            if (cbbTplCat.SelectedItem != null)
            {
                qDetailList.AddRange(qDetailRepo.GetByTplCatId(Convert.ToInt32(cbbTplCat.SelectedValue)));
            }

            list.AddRange((from c in qqItemRepo.GetAll_Dlo().OrderByDescending(p => p.CreatedDate)
                           select new QsetPageView
                           {
                               Id = c.Id,
                               TypeCode = c.TypeCode,
                               McqDisplayHorizontal = c.McqDisplayHorizontal,
                               QuestionText = c.QuestionText,
                               TypeName = c.QQType.Name,
                               McqId = c.McqId,
                               IsValueInt = c.QQMcq == null ? false : c.QQMcq.IsValueInt,
                               IsContain = qDetailList.Any(p => p.QQItemId == c.Id),
                               IsRequired = qDetailList.Any(p => p.QQItemId == c.Id && p.IsRequired),
                               Sequence = qDetailList.Any(p => p.QQItemId == c.Id) ? qDetailList.Find(p => p.QQItemId == c.Id).Sequence : 0
                           }).ToList());
            Session[SessionName] = list;
            gv.DataSource = list;
        }
        else
        {
            if (Session[SessionName] != null)
            {
                list = Session[SessionName] as List<QsetPageView>;
                gv.DataSource = list;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool isError = false;
        if (cbbTplCat.SelectedItem == null)
        {
            Show("尚未設定類別，請先設定類別");
            isError = true;
            //return;
        }

        int selectedTplCat = Convert.ToInt32(cbbTplCat.SelectedValue);

        List<QDetail> qDetailList = qDetailRepo.GetByTplCatId(Convert.ToInt32(cbbTplCat.SelectedValue));
        List<QQItem> qqItemList = qqItemRepo.GetByTplCode_Dlo(Request.QueryString["Code"]);

        foreach (QDetail i in qDetailList)
        {
            qDetailRepo.Delete(i);
        }

        foreach (GridDataItem i in gv.SelectedItems)
        {
            if (qqItemList.Any(p => p.Id == Convert.ToInt32(i["Id"].Text)
                && p.QDetail.Any(a => a.QTplCategoryId != selectedTplCat)))
            {
                Show("在本問卷其他類別有重複相同題目");
                isError = true;
                //    return;
            }

            QDetail obj = new QDetail();
            obj.QQItemId = Convert.ToInt32(i["Id"].Text);
            obj.QTplCategoryId = selectedTplCat;
            obj.IsRequired = (i["tplIsRequired"].FindControl("cbIsRequired") as CheckBox).Checked;
            RadNumericTextBox ntb = i["tplSequence"].FindControl("ntbSequence") as RadNumericTextBox;
            if (ntb.Value.HasValue)
                obj.Sequence = Convert.ToInt32(ntb.Value);
            else
            {
                Show("選擇項目，必須輸入順序值");
                isError = true;
                //return;
            }

            qDetailRepo.Add(obj);
        }

        if (!isError)
        {
            qDetailRepo.Save();
            Show("已儲存");
        }

        gv.Rebind();
    }

    protected void gv_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            if (item["McqId"].Text.Length > 0)
            {
                QQMcq mcqObj = mcqRepo.GetByPk_Dlo(Convert.ToInt32(item["McqId"].Text));

                if (mcqObj.QQMcqDetail.Count > 0)
                {
                    Table tbl = item["tpl1"].FindControl("tbl") as Table;
                    TableRow row1 = new TableRow();
                    TableRow row2 = new TableRow();
                    row1.BorderWidth = 1;
                    row2.BorderWidth = 1;

                    foreach (QQMcqDetail i in mcqObj.QQMcqDetail.OrderBy(p => p.Sequence))
                    {
                        TableCell cell1 = new TableCell();
                        TableCell cell2 = new TableCell();
                        cell1.BorderWidth = 1;
                        cell2.BorderWidth = 1;

                        cell1.Text = i.Text;
                        if (mcqObj.IsValueInt)
                            cell2.Text = i.IntValue.Value.ToString();
                        else
                            cell2.Text = i.StringValue;

                        row1.Cells.Add(cell1);
                        row2.Cells.Add(cell2);
                    }

                    tbl.Rows.Add(row1);
                    tbl.Rows.Add(row2);
                }
            }

            CheckBox cb = item["IsContain"].Controls[0] as CheckBox;
            if (cb.Checked)
                item.Selected = true;

            RadNumericTextBox ntb = item["tplSequence"].FindControl("ntbSequence") as RadNumericTextBox;
            ntb.Value = Convert.ToInt32(item["Sequence"].Text);
        }
    }

    protected void cbbTplCat_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gv.Rebind();
    }
}

public class QsetPageView
{
    public int Id { get; set; }

    public string TypeCode { get; set; }

    public bool McqDisplayHorizontal { get; set; }

    public string QuestionText { get; set; }

    public string TypeName { get; set; }

    public int? McqId { get; set; }

    public bool IsValueInt { get; set; }

    public bool IsContain { get; set; }

    public bool IsRequired { get; set; }

    public int Sequence { get; set; }
}