using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Repo;

public partial class eTraining_Questionary_QQ : JBWebPage
{
    const string qqItemEditUrl = @"~/eTraining/Questionary/QQItemEdit.aspx?Id=";
    private QQItem_Repo qqItemRepo = new QQItem_Repo();
    private QQMcqDetailTpl_Repo qqMDT_Repo = new QQMcqDetailTpl_Repo();
    private QQMcq_Repo mcqRepo = new QQMcq_Repo();
    private QQMcqDetail_Repo qqdRepo = new QQMcqDetail_Repo(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gv);

        if (!IsPostBack)
        {
            initCbType();
        }
        win.VisibleOnPageLoad = false;
    }

    private void initCbType()
    {
        QQType_Repo qqTypeRepo = new QQType_Repo();
        cbType.DataSource = qqTypeRepo.GetAll();
        cbType.DataBind();

        if (cbType.SelectedItem != null)
        {
            cbType_SelectedIndexChanged(this,
                new RadComboBoxSelectedIndexChangedEventArgs(cbType.SelectedItem.Text, "", cbType.SelectedValue, ""));
        }

        bindCbGroup();
        if (cbGroup.SelectedItem != null)
        {
            cbGroup_SelectedIndexChanged(this,
    new RadComboBoxSelectedIndexChangedEventArgs(cbGroup.SelectedItem.Text, "", cbGroup.SelectedValue, ""));
        }
    }

    private void bindCbGroup()
    {
        string selectedValue = "";
        if (cbGroup.SelectedItem != null)
        {
            selectedValue = cbGroup.SelectedValue;
        }

        QQMcqDetailTpl_Repo qRepo = new QQMcqDetailTpl_Repo();
        cbGroup.DataSource = (from c in qRepo.GetDistinctGroup() select new { Text = c, Value = c }).ToList();
        cbGroup.DataBind();

        if (!selectedValue.Equals(""))
        {
            RadComboBoxItem obj = cbGroup.Items.FindItemByValue(selectedValue);
            if (obj != null)
            {
                obj.Selected = true;
            }
        }

        gv2.Rebind();
    }

    private void loadData(string code)
    {


    }


    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        QQItem_Repo qqItemRepo = new QQItem_Repo();
        gv.DataSource = (from c in qqItemRepo.GetAll_Dlo()
                         select new
                         {
                             c.Id,
                             c.TypeCode,
                             c.McqDisplayHorizontal,
                             c.QuestionText,
                             TypeName = c.QQType.Name,
                             c.McqId,
                             IsValueInt = c.QQMcq == null ? false : c.QQMcq.IsValueInt
                         }).ToList();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (tbQuestionText.Text.Trim().Length == 0)
        {
            Show("請輸入問題");
            return;
        }

        if (cbType.SelectedValue.Equals(QQTypeEnum.MCQ.ToString()))
        {
            if (cbGroup.SelectedItem == null)
            {
                Show("尚未選擇選項群組");
                return;
            }

            List<QQMcqDetailTpl> mcqdtList = qqMDT_Repo.GetByGroupCode(cbGroup.SelectedValue);

            if (mcqdtList.Count == 0)
            {
                Show("無選擇題選項");
                return;
            }

            QQItem qqItemObj = new QQItem();
            qqItemObj.TypeCode = cbType.SelectedValue;
            qqItemObj.QuestionText = tbQuestionText.Text;
            qqItemObj.McqDisplayHorizontal = cbMcqDisplayHorizontal.Checked;

            QQMcq mcqObj = new QQMcq();
            mcqObj.IsValueInt = cbIsValueInt.Checked;
            mcqObj.Name = "";

            qqItemObj.QQMcq = mcqObj;
            foreach (QQMcqDetailTpl i in mcqdtList)
            {
                QQMcqDetail obj = new QQMcqDetail();
                obj.IntValue = i.IntValue;
                obj.Sequence = i.Sequence;
                obj.StringValue = i.StringValue;
                obj.Text = i.Text;
                mcqObj.QQMcqDetail.Add(obj);
            }

            if (mcqObj.IsValueInt)
            {
                foreach (var i in mcqObj.QQMcqDetail)
                {
                    if (!i.IntValue.HasValue)
                    {
                        Show("採用選項數字值，選項數字需有值");
                        return;
                    }
                }
            }

            qqItemRepo.Add(qqItemObj);
            qqItemRepo.Save();
            gv.Rebind();
            clearForm();
        }
        else
        {
            QQItem qqItemObj = new QQItem();
            qqItemObj.TypeCode = cbType.SelectedValue;
            qqItemObj.QuestionText = tbQuestionText.Text;
            qqItemRepo.Add(qqItemObj);
            qqItemRepo.Save();
            gv.Rebind();
            clearForm();
        }
    }
    protected void gv_ItemCommand(object sender, GridCommandEventArgs e)
    {
        GridDataItem item = null;
        if (e.Item is GridDataItem)
        {
            item = e.Item as GridDataItem;
            if (item == null)
                throw new ApplicationException("資料有誤");
        }

        if ( e.CommandName.Equals("Edt") )
        {
            win.NavigateUrl =qqItemEditUrl + item["Id"].Text;
            win.Height = 600;
            win.Width = 800;
            win.VisibleOnPageLoad = true;
        }

        if (e.CommandName.Equals("Del"))
        {
            QDetail_Repo dRepo = new QDetail_Repo();
            List<QDetail> dList= dRepo.GetByQQItemId(Convert.ToInt32(item["Id"].Text));
            if (dList.Count > 0)
            {
                Show("此問題已有問卷採用，無法刪除。");
                return;
            }
            else
            {
                QQItem_Repo qqItemRepo = new QQItem_Repo();
                QQItem qqItemObj= qqItemRepo.GetByPk_Dlo(Convert.ToInt32(item["Id"].Text));
                    if (qqItemObj.McqId.HasValue)
                    {
                        QQMcq_Repo mcqRepo = new QQMcq_Repo(qqItemRepo.dc);
                        mcqRepo.Delete(qqItemObj.QQMcq);

                        QQMcqDetail_Repo mcqdRepo = new QQMcqDetail_Repo(qqItemRepo.dc);
                        mcqdRepo.Delete(qqItemObj.QQMcq.QQMcqDetail.ToList());
                    }

                qqItemRepo.Delete(qqItemObj);

                qqItemRepo.Save();
                gv.Rebind();
            }
        }
    }

    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadData(gv.SelectedValue.ToString());
    }

    private void clearForm()
    {
        cbMcqDisplayHorizontal.Checked = false;
        cbIsValueInt.Checked = false;
        tbQuestionText.Text = "";
    }
    protected void cbType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (e.Value == QQTypeEnum.MCQ.ToString())
        {
            pnl2.Visible = true;
            cbMcqDisplayHorizontal.Visible = true;
            cbIsValueInt.Visible = true;
        }
        else
        {
            pnl2.Visible = false;
            cbMcqDisplayHorizontal.Visible = false;
            cbIsValueInt.Visible = false;
        }
    }
    protected void gv2_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (cbGroup.SelectedItem != null)
        {
            gv2.DataSource = qqMDT_Repo.GetByGroupCode(cbGroup.SelectedValue).OrderBy(p => p.Sequence);
        }
    }
    protected void cbGroup_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gv2.Rebind();
    }
    protected void btnAddGp_Click(object sender, EventArgs e)
    {
        pnl3.Visible = true;
        lblMode.Text = FormMode.Insert.ToString();

    }
    protected void gv2_ItemCommand(object sender, GridCommandEventArgs e)
    {
        GridDataItem item = null;
        if (e.Item is GridDataItem)
        {
            item = e.Item as GridDataItem;
            if (item == null)
                throw new ApplicationException("資料有誤");
        }

        if (e.CommandName.Equals("Update"))
        {
            lblMode.Text = FormMode.Update.ToString();
            lblId.Text = item["Id"].Text;
            loadDtlData(Convert.ToInt32(lblId.Text));
            pnl3.Visible = true;
        }

        if (e.CommandName.Equals("Del"))
        {
            QQMcqDetailTpl obj = qqMDT_Repo.GetByPk(Convert.ToInt32(item["Id"].Text));
            qqMDT_Repo.Delete(obj);
            qqMDT_Repo.Save();
            //gv2.Rebind();
            bindCbGroup();
        }
    }

    private void loadDtlData(int id)
    {
        QQMcqDetailTpl obj = qqMDT_Repo.GetByPk(Convert.ToInt32(lblId.Text));
        tbGroupCode.Text = obj.GroupCode;
        ntbIntValue.Value = obj.IntValue;
        ntbSequence.Value = obj.Sequence;
        tbStringValue.Text = obj.StringValue;
        tbText.Text = obj.Text;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblMode.Text = FormMode.View.ToString();
        pnl3.Visible = false;
    }

    private void clearFormData()
    {
        tbStringValue.Text = "";
        tbText.Text = "";
        ntbIntValue.Value = 0;
        ntbSequence.Value = 0;
        tbGroupCode.Text = "";
    }
    protected void btnSaveDetailTpl_Click(object sender, EventArgs e)
    {
        if (lblMode.Text.Equals(FormMode.Update.ToString()))
        {
            QQMcqDetailTpl obj = qqMDT_Repo.GetByPk(Convert.ToInt32(lblId.Text));
            obj.GroupCode = tbGroupCode.Text;
            obj.IntValue = Convert.ToInt32(ntbIntValue.Value);
            obj.Sequence = Convert.ToInt32(ntbSequence.Value);
            obj.StringValue = tbStringValue.Text;
            obj.Text = tbText.Text;
            qqMDT_Repo.Update(obj);
            qqMDT_Repo.Save();
            //gv2.Rebind();
            bindCbGroup();
            clearForm();
            pnl3.Visible = false;
        }
        else if (lblMode.Text.Equals(FormMode.Insert.ToString()))
        {
            QQMcqDetailTpl obj = new QQMcqDetailTpl();
            obj.GroupCode = tbGroupCode.Text;
            obj.IntValue = Convert.ToInt32(ntbIntValue.Value);
            obj.Sequence = Convert.ToInt32(ntbSequence.Value);
            obj.StringValue = tbStringValue.Text;
            obj.Text = tbText.Text;
            qqMDT_Repo.Add(obj);
            qqMDT_Repo.Save();
            bindCbGroup();
            //gv2.Rebind();
            clearForm();
            pnl3.Visible = false;
        }
    }
    protected void gv_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if(e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            if (item["McqId"].Text.Length > 0)
            {
                QQMcq mcqObj= mcqRepo.GetByPk_Dlo(Convert.ToInt32(item["McqId"].Text));

                if (mcqObj.QQMcqDetail.Count > 0) 
                { 
                    Table tbl= item["tpl1"].FindControl("tbl") as Table;
                    TableRow row1 = new TableRow();
                    TableRow row2 = new TableRow();
                    row1.BorderWidth = 1;
                    row2.BorderWidth = 1;                    

                    foreach (QQMcqDetail i in mcqObj.QQMcqDetail.OrderBy(p=>p.Sequence))
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
        }
    }
    protected void RadAjaxPanel1_AjaxRequest(object sender , AjaxRequestEventArgs e)
    {
        if ( e.Argument == "Rebind" )
        {
            gv.MasterTableView.SortExpressions.Clear();
            gv.MasterTableView.GroupByExpressions.Clear();
            gv.Rebind();
        }
        else if ( e.Argument == "RebindAndNavigate" )
        {
            gv.MasterTableView.SortExpressions.Clear();
            gv.MasterTableView.GroupByExpressions.Clear();
            gv.MasterTableView.CurrentPageIndex = gv.MasterTableView.PageCount - 1;
            gv.Rebind();
        }
    }
}