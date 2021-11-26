using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.IO;

public partial class eTraining_Admin_Do_SetStudentKnotTeaches : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gv);
        if (Request.QueryString["ID"] == null)
        {
            throw new ApplicationException("未傳入正確參數");
        }

        var classObj = (from c in dcTraining.trTrainingDetailM
                        where c.iAutoKey == Int32.Parse(Request.QueryString["ID"].ToString())
                        select c).FirstOrDefault();

        if (classObj != null)
        {
            if (classObj.dDateTimeD.HasValue)
            {
                if (classObj.dDateTimeD.Value.CompareTo(DateTime.Now) <=0)
                {
                    btnSave.Enabled = true;
                }
                else
                    btnSave.Enabled = false;
            }

        }

        RadWindow1.VisibleOnPageLoad = false;
        //if (!IsPostBack)
        //{
        //    rblClassKnotTeaches.DataBind();
        //    if (rblClassKnotTeaches.Items.Count > 0)
        //    {
        //        rblClassKnotTeaches.Items[0].Selected = true;
        //    }

        //}
        //RadButton3.Attributes["onclick"] = String.Format("return ShowInsertForm();");
        //btnHelp.Attributes["onclick"] = String.Format("return ShowInsertForm();");
    }
    protected void rblClassKnotTeaches_SelectedIndexChanged(object sender, EventArgs e)
    {
        gv.Rebind();
    }
    protected void gv_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            CheckBox ck = item["bPass"].Controls[0] as CheckBox;
            if (ck != null)
            {
                ck.Enabled = true;
                if (ck.Checked == true)
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }

            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        GridDataItemCollection items = gv.Items;
        foreach (GridDataItem item in items)
        {
            int iAutoKey = Int32.Parse(item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString());

            var dataList = (from c in dcTraining.trTrainingStudentS
                        where c.iClassAutoKey == Int32.Parse(Request.QueryString["ID"].ToString())
                        select c).ToList();

            CheckBox ck = item["bPass"].Controls[0] as CheckBox;
            if (ck != null)
            {
                var data = (from c in dataList
                            where c.iAutoKey == iAutoKey
                            select c).FirstOrDefault();

                if (data != null)
                {
                    if (item.Selected !=data.bPass)
                    {
                        data.bPass = item.Selected;
                        dcTraining.SubmitChanges();

                        //update 訓練名單，是否結訓
                        int trTrainingStudentM_ID = Convert.ToInt32(item["trTrainingStudentM_ID"].Text);
                        var TrainingStudentS = (from c in dcTraining.trTrainingStudentS
                                                where c.trTrainingStudentM_ID == trTrainingStudentM_ID
                                                && c.bPass == false
                                                select c).FirstOrDefault();

                        //必訓全部都通過
                        if ( TrainingStudentS == null )
                        {
                            var TrainingStudentM = (from c in dcTraining.trTrainingStudentM
                                                    where c.iAutoKey == trTrainingStudentM_ID
                                                    select c).FirstOrDefault();

                            TrainingStudentM.bPass = true;
                            dcTraining.SubmitChanges();
                        }
                        else
                        {
                            var TrainingStudentM = (from c in dcTraining.trTrainingStudentM
                                                    where c.iAutoKey == trTrainingStudentM_ID
                                                    select c).FirstOrDefault();

                            TrainingStudentM.bPass = false;
                            dcTraining.SubmitChanges();
                        }                        
                    }
                }
            }
        }

        AlertMsg("已存檔");
        gv.Rebind();
    }
    protected void rblClassKnotTeaches_DataBound(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (rblClassKnotTeaches.Items.Count > 0)
                rblClassKnotTeaches.Items[0].Selected = true;

        }
    }
    protected void btnHelp_Click(object sender, EventArgs e)
    {
        RadWindow1.AutoSize = true;
        RadWindow1.VisibleOnPageLoad = true;
    }
}