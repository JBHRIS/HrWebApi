using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

public partial class eTraining_Admin_Design_NotifyTemplate : JBWebPage
{
    private dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            lblMsg2.Text = "";
            lblMsg.Text = "";
            
        }       
    }

    protected void btnNfAdd_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        //新增流程樣版
        string sCode = Guid.NewGuid().ToString();
        List<trNotifyTemplate> NotifyTpl = new List<trNotifyTemplate>();

        var r = new trNotifyTemplate();

        r.sCode = sCode;
        r.sName = txtNfName.Text;
        r.sKeyMan = User.Identity.Name;
        r.dKeyDate = DateTime.Now;

        NotifyTpl.Add(r);

        try
        {
            dcTrain.trNotifyTemplate.InsertAllOnSubmit(NotifyTpl);
            dcTrain.SubmitChanges();

            gvNfTemplate.Rebind();
            cbxNfName.DataBind();
            cbxNfVName.DataBind();
        }
        catch
        {
            lblMsg.Text = "資料錯誤，或重複輸入!!!";
        }

        cbxNfName.DataBind();
        cbxNfVName.DataBind();
        //清空txt資料
        txtNfName.Text = string.Empty;
    }
    protected void btnAddNfItem0_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        //重整時新增動作不會被重覆
        if (IsRefresh)
        {
            txtNfItem.Text = string.Empty;
            txtTimespan.Text = string.Empty;
            gvNotifyItem.Rebind();
            lblMsg.Text = "";
            return;
        }

        //新增通知項目
        List<trNotifyItem> NotifyItem = new List<trNotifyItem>();

        var r = new trNotifyItem();

        r.sName = txtNfItem.Text;
        r.iTimespan = Convert.ToInt32(txtTimespan.Text);
        r.sKeyMan = User.Identity.Name;
        r.dKeyDate = DateTime.Now;

        NotifyItem.Add(r);

        try
        {
            dcTrain.trNotifyItem.InsertAllOnSubmit(NotifyItem);
            dcTrain.SubmitChanges();

            gvNotifyItem.Rebind();
            gvPickItem.Rebind();
        }
        catch
        {
            //Show("新增錯誤");
            lblMsg.Text = "新增錯誤";
            txtNfItem.Text = string.Empty;
            txtTimespan.Text = string.Empty;            
        }

        //清空txt資料
        txtNfItem.Text = string.Empty;
        txtTimespan.Text = string.Empty;
    }
    protected void btnAddItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvPickItem.SelectedItems.Count ==0)
            {
                return;
            }
            //取得NotifyTemplate的sCode
            string TplCode = cbxNfName.SelectedValue;

            //取得選取樣板的所有資料
            var detailList = (from c in dcTrain.trNotifyTemplateDetail
                              where c.sCode == TplCode
                              select c).ToList();

            //取得勾選項目
            foreach (GridDataItem itm in gvPickItem.Items)
            {
                //List<trNotifyTemplateDetail> TplDetail = new List<trNotifyTemplateDetail>();

                //新增
                if (itm.Selected == true && itm["dtl_iAutoKey"].Text.Trim().Length == 0)
                {
                    trNotifyTemplateDetail obj = new trNotifyTemplateDetail();
                    obj.dKeyDate = DateTime.Now;
                    obj.sKeyMan = User.Identity.Name;
                    obj.sCode = TplCode;
                    obj.NotifyItem_iAutokey = Convert.ToInt32(itm["iAutokey"].Text.ToString());
                    RadNumericTextBox ntb = itm["iAutokey"].FindControl("ntb_iTimespanT") as RadNumericTextBox;
                    obj.iTimespanT = 0;

                    if (ntb != null)
                    {
                        if (ntb.Value.HasValue)
                        {
                            obj.iTimespanT = Convert.ToInt32(ntb.Value);
                        }
                    }

                    dcTrain.trNotifyTemplateDetail.InsertOnSubmit(obj);
                }
                else if (itm.Selected == true && itm["dtl_iAutoKey"].Text.Trim().Length > 0)
                {
                    var obj = (from c in dcTrain.trNotifyTemplateDetail
                               where c.iAutoKey == Convert.ToInt32(itm["dtl_iAutoKey"].Text)
                               select c).FirstOrDefault();
                    if (obj != null)
                    {
                        RadNumericTextBox ntb = itm["iAutokey"].FindControl("ntb_iTimespanT") as RadNumericTextBox;
                        obj.iTimespanT = 0;

                        if (ntb != null)
                        {
                            if (ntb.Value.HasValue)
                            {
                                obj.iTimespanT = Convert.ToInt32(ntb.Value);
                            }
                        }
                    }

                }
                else if (itm.Selected == false && itm["dtl_iAutoKey"].Text.Trim().Length > 0)
                {
                    var obj = (from c in dcTrain.trNotifyTemplateDetail
                               where c.iAutoKey == Convert.ToInt32(itm["dtl_iAutoKey"].Text)
                               select c).FirstOrDefault();

                    dcTrain.trNotifyTemplateDetail.DeleteOnSubmit(obj);
                }

                dcTrain.SubmitChanges();

            }


            gvPickItem.Rebind();
            gvNotifyTemplateDetail.Rebind();

            //    string key = itm.OwnerTableView.DataKeyValues[itm.ItemIndex]["iAutokey"].ToString();
            //    r.sCode = TplCode;

            //    //判斷NotifyItem_iAutokey是否重複
            //    if(detailList.Any(p=>p.NotifyItem_iAutokey==Convert.ToInt32(key)))
            //    {
            //        //若重複不動作
            //        continue;
            //    }
            //    //不重複才加入trNotifyTemplateDetail
            //    else
            //    {

            //        r.NotifyItem_iAutokey = Convert.ToInt32(key);
            //        r.sKeyMan = User.Identity.Name;
            //        r.dKeyDate = DateTime.Now;

            //        dcTrain.trNotifyTemplateDetail.InsertOnSubmit(r);
            //    }
            //}

            //dcTrain.SubmitChanges();
            //gvPickItem.Rebind();
            ////檢示流程樣版gv.bind
            //gvNotifyTemplateDetail.Rebind();
            //Show("已加入");
            ////lblMsg2.Text = "已加入";
            
        }
        catch (Exception ex)
        {
            lblMsg2.Text = ex.Message;
        }
    }
    protected void cbxNfVName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gvNotifyTemplateDetail.Rebind();
    }
    protected void txtTimespan_TextChanged(object sender, EventArgs e)
    {

    }
    protected void gvPickItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void gvPickItem_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;

            if (item["dtl_iAutoKey"].Text.Trim().Length > 0)
            {
                item.Selected = true;
            }
            else
            {
                item.Selected = false;
            }


        }
    }
    protected void cbxNfName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gvPickItem.Rebind();
    }
}