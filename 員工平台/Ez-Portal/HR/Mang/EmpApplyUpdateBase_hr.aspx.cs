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
using JB.HRIS.Organization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL;
using Telerik.Web.UI;
using System.Drawing;
public partial class HR_Mang_EmpWorkHours_hr:JBWebPage
{
    private NotifyApplyUpdateBase_REPO naubRepo = new NotifyApplyUpdateBase_REPO();
    protected void Page_Load(object sender , EventArgs e)
    {
        if ( !IsPostBack )
        {
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1");
            ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year , DateTime.Now.Month).ToString());
            RadMultiPage1.SelectedIndex = RadTabStrip1.SelectedIndex;
            bindDgCbx();
        }
    }

    private void bindDgCbx()
    {
        DATAGROUP_REPO dpRepo = new DATAGROUP_REPO();
        dgCbx.DataSource = dpRepo.GetAll();
        dgCbx.DataBind();
    }

    protected void Button1_Click(object sender , EventArgs e)
    {
        gv.Rebind();
    }
    protected void ExportExcel_Click(object sender , EventArgs e)
    {
        //if (Session[SESSION_NAME] != null)
        //    JB.WebModules.Data.Export.Excel.WebResponseExcel(this, GridView2, (AttendDs.WorkHoursDataTable)Session[SESSION_NAME], HttpUtility.UrlEncode("員工工時",Encoding.UTF8));
        //else
        //    JB.WebModules.Message.Show("無資料可匯出！");
    }


    protected void gv_NeedDataSource(object sender , Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        if ( !e.IsFromDetailTable )
        {
            ApplyUpdateBase_REPO applyRepo = new ApplyUpdateBase_REPO();
            List<ApplyUpdateBase> list = applyRepo.GetByDateRange_Dlo(adate.SelectedDate.Value , ddate.SelectedDate.Value);
            if ( !cbIsProcessed.Checked )
            {
                list = (from c in list
                        where c.Approve == null
                        select c).ToList();
            }

            var dataList = (from c in list
                             select new ApplyUpdateBaseView
                             {
                                 ApplyMan = c.ApplyMan ,
                                 Name_c = c.BASE.NAME_C ,
                                 Approve = c.Approve ,
                                 ApproveMan = c.ApproveMan,
                                 ApplyDatetime = c.ApplyDatetime,
                                 GSM = c.GSM ,
                                 EMAIL = c.EMAIL ,
                                 TEL1 = c.TEL1 ,
                                 TEL2 = c.TEL2 ,
                                 POSTCODE1 = c.POSTCODE1 ,
                                 ADDR1 = c.ADDR1 ,
                                 POSTCODE2 = c.POSTCODE2 ,
                                 ADDR2 = c.ADDR2 ,
                                 PROVINCE = c.PROVINCE ,
                                 BORN_ADDR = c.BORN_ADDR ,
                                 CONT_MAN = c.CONT_MAN ,
                                 CONT_REL1 = c.CONT_REL1 ,
                                 CONT_TEL = c.CONT_TEL ,
                                 CONT_GSM = c.CONT_GSM ,
                                 CONT_MAN2 = c.CONT_MAN2 ,
                                 CONT_REL2 = c.CONT_REL2 ,
                                 CONT_TEL2 = c.CONT_TEL2 ,
                                 CONT_GSM2 = c.CONT_GSM2 ,
                                 SUBTEL=c.SUBTEL,
                                 GSM_IsChanged = c.GSM_IsChanged ,
                                 EMAIL_IsChanged = c.EMAIL_IsChanged ,
                                 TEL1_IsChanged = c.TEL1_IsChanged ,
                                 TEL2_IsChanged = c.TEL2_IsChanged ,
                                 POSTCODE1_IsChanged = c.POSTCODE1_IsChanged ,
                                 ADDR1_IsChanged = c.ADDR1_IsChanged ,
                                 POSTCODE2_IsChanged = c.POSTCODE2_IsChanged ,
                                 ADDR2_IsChanged = c.ADDR2_IsChanged ,
                                 PROVINCE_IsChanged = c.PROVINCE_IsChanged ,
                                 BORN_ADDR_IsChanged = c.BORN_ADDR_IsChanged ,
                                 CONT_MAN_IsChanged = c.CONT_MAN_IsChanged ,
                                 CONT_REL1_IsChanged = c.CONT_REL1_IsChanged ,
                                 CONT_TEL_IsChanged = c.CONT_TEL_IsChanged ,
                                 CONT_GSM_IsChanged = c.CONT_GSM_IsChanged ,
                                 CONT_MAN2_IsChanged = c.CONT_MAN2_IsChanged ,
                                 CONT_REL2_IsChanged = c.CONT_REL2_IsChanged ,
                                 CONT_TEL2_IsChanged = c.CONT_TEL2_IsChanged ,
                                 CONT_GSM2_IsChanged = c.CONT_GSM2_IsChanged ,
                                 CONT_REL1_NAME = c.RELCODE != null ? c.RELCODE.REL_NAME : "" ,
                                 CONT_REL2_NAME = c.RELCODE1 != null ? c.RELCODE1.REL_NAME : "",
                                 SUBTEL_IsChanged = c.SUBTEL_IsChanged,
                                 Pk = c.Pk.ToString() ,
                             }).ToList();

            for (int i = 0; i < dataList.Count; i=i+2)
            {
                var data = (from c in list where c.Pk.ToString() == dataList[i].Pk select c).FirstOrDefault();
                if(data !=null)
                {
                var oldData = new ApplyUpdateBaseView{ 
                                 ApplyMan = data.ApplyMan ,
                                 Name_c = data.BASE.NAME_C ,
                                 Approve = data.Approve ,
                                 ApproveMan = data.ApproveMan,
                                 ApplyDatetime = data.ApplyDatetime,
                                 GSM = data.GSM_Old ,
                                 EMAIL = data.EMAIL_Old ,
                                 TEL1 = data.TEL1_Old ,
                                 TEL2 = data.TEL2_Old ,
                                 POSTCODE1 = data.POSTCODE1_Old ,
                                 ADDR1 = data.ADDR1_Old ,
                                 POSTCODE2 = data.POSTCODE2_Old ,
                                 ADDR2 = data.ADDR2_Old ,
                                 PROVINCE = data.PROVINCE_Old ,
                                 BORN_ADDR = data.BORN_ADDR_Old ,
                                 CONT_MAN = data.CONT_MAN_Old ,
                                 CONT_REL1 = data.CONT_REL1_Old ,
                                 CONT_TEL = data.CONT_TEL_Old ,
                                 CONT_GSM = data.CONT_GSM_Old ,
                                 CONT_MAN2 = data.CONT_MAN2_Old ,
                                 CONT_REL2 = data.CONT_REL2_Old ,
                                 CONT_TEL2 = data.CONT_TEL2_Old ,
                                 CONT_GSM2 = data.CONT_GSM2_Old ,
                                 SUBTEL=data.SUBTEL_Old,
                                 GSM_IsChanged = data.GSM_IsChanged ,
                                 EMAIL_IsChanged = data.EMAIL_IsChanged ,
                                 TEL1_IsChanged = data.TEL1_IsChanged ,
                                 TEL2_IsChanged = data.TEL2_IsChanged ,
                                 POSTCODE1_IsChanged = data.POSTCODE1_IsChanged ,
                                 ADDR1_IsChanged = data.ADDR1_IsChanged ,
                                 POSTCODE2_IsChanged = data.POSTCODE2_IsChanged ,
                                 ADDR2_IsChanged = data.ADDR2_IsChanged ,
                                 PROVINCE_IsChanged = data.PROVINCE_IsChanged ,
                                 BORN_ADDR_IsChanged = data.BORN_ADDR_IsChanged ,
                                 CONT_MAN_IsChanged = data.CONT_MAN_IsChanged ,
                                 CONT_REL1_IsChanged = data.CONT_REL1_IsChanged ,
                                 CONT_TEL_IsChanged = data.CONT_TEL_IsChanged ,
                                 CONT_GSM_IsChanged = data.CONT_GSM_IsChanged ,
                                 CONT_MAN2_IsChanged = data.CONT_MAN2_IsChanged ,
                                 CONT_REL2_IsChanged = data.CONT_REL2_IsChanged ,
                                 CONT_TEL2_IsChanged = data.CONT_TEL2_IsChanged ,
                                 CONT_GSM2_IsChanged = data.CONT_GSM2_IsChanged ,
                                 CONT_REL1_NAME = data.RELCODE2 != null ? data.RELCODE.REL_NAME : "" ,
                                 CONT_REL2_NAME = data.RELCODE3 != null ? data.RELCODE1.REL_NAME : "" ,
                                 SUBTEL_IsChanged = data.SUBTEL_IsChanged,
                                 Pk = "old_"+data.Pk 
                             };

                dataList.Insert(i, oldData);
                    }

            }


                gv.DataSource = dataList;
        }
    }
    protected void gv_ItemDataBound(object sender , Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;

            if (!item["Pk"].Text.Contains("old"))
            {
                if (!item["ApproveMan"].Text.Equals(""))
                {
                    foreach (Control c in item["ApproveItem"].Controls)
                        c.Visible = false;

                    item["ApproveItem"].Text = "已處理";
                }

                CheckBox cb1 = item["GSM_IsChanged"].Controls[0] as CheckBox;
                if (cb1.Checked)
                    item["GSM"].ForeColor = Color.Red;
                CheckBox cb2 = item["EMAIL_IsChanged"].Controls[0] as CheckBox;
                if (cb2.Checked)
                    item["EMAIL"].ForeColor = Color.Red;
                CheckBox cb3 = item["TEL1_IsChanged"].Controls[0] as CheckBox;
                if (cb3.Checked)
                    item["TEL1"].ForeColor = Color.Red;
                CheckBox cb4 = item["TEL2_IsChanged"].Controls[0] as CheckBox;
                if (cb4.Checked)
                    item["TEL2"].ForeColor = Color.Red;
                CheckBox cb5 = item["POSTCODE1_IsChanged"].Controls[0] as CheckBox;
                if (cb5.Checked)
                    item["POSTCODE1"].ForeColor = Color.Red;
                CheckBox cb6 = item["POSTCODE2_IsChanged"].Controls[0] as CheckBox;
                if (cb6.Checked)
                    item["POSTCODE2"].ForeColor = Color.Red;
                CheckBox cb6_1 = item["ADDR1_IsChanged"].Controls[0] as CheckBox;
                if (cb6_1.Checked)
                    item["ADDR1"].ForeColor = Color.Red;
                CheckBox cb7 = item["ADDR2_IsChanged"].Controls[0] as CheckBox;
                if (cb7.Checked)
                    item["ADDR2"].ForeColor = Color.Red;
                CheckBox cb8 = item["PROVINCE_IsChanged"].Controls[0] as CheckBox;
                if (cb8.Checked)
                    item["PROVINCE"].ForeColor = Color.Red;
                CheckBox cb9 = item["BORN_ADDR_IsChanged"].Controls[0] as CheckBox;
                if (cb9.Checked)
                    item["BORN_ADDR"].ForeColor = Color.Red;
                CheckBox cb10 = item["CONT_MAN_IsChanged"].Controls[0] as CheckBox;
                if (cb10.Checked)
                    item["CONT_MAN"].ForeColor = Color.Red;
                CheckBox cb11 = item["CONT_REL1_IsChanged"].Controls[0] as CheckBox;
                if (cb11.Checked)
                    item["CONT_REL1_NAME"].ForeColor = Color.Red;
                CheckBox cb12 = item["CONT_TEL_IsChanged"].Controls[0] as CheckBox;
                if (cb12.Checked)
                    item["CONT_TEL"].ForeColor = Color.Red;
                CheckBox cb13 = item["CONT_GSM_IsChanged"].Controls[0] as CheckBox;
                if (cb13.Checked)
                    item["CONT_GSM"].ForeColor = Color.Red;
                CheckBox cb14 = item["CONT_MAN2_IsChanged"].Controls[0] as CheckBox;
                if (cb14.Checked)
                    item["CONT_MAN2"].ForeColor = Color.Red;
                CheckBox cb15 = item["CONT_REL2_IsChanged"].Controls[0] as CheckBox;
                if (cb15.Checked)
                    item["CONT_REL2_NAME"].ForeColor = Color.Red;
                CheckBox cb16 = item["CONT_TEL2_IsChanged"].Controls[0] as CheckBox;
                if (cb16.Checked)
                    item["CONT_TEL2"].ForeColor = Color.Red;
                CheckBox cb17 = item["CONT_GSM2_IsChanged"].Controls[0] as CheckBox;
                if (cb17.Checked)
                    item["CONT_GSM2"].ForeColor = Color.Red;
                CheckBox cb18 = item["SUBTEL_IsChanged"].Controls[0] as CheckBox;
                if (cb18.Checked)
                    item["SUBTEL"].ForeColor = Color.Red;

            }
            else
            {
                foreach (Control c in item["ApproveItem"].Controls)
                    c.Visible = false;

                foreach (Control c in item["Approve"].Controls)
                    c.Visible = false;
                
                item["ApproveItem"].Text = "舊資料";

                item.BackColor = Color.Pink;
            }
        }
    }
    protected void gv_ItemCommand(object sender , GridCommandEventArgs e)
    {
        GridDataItem item = null;
        if ( e.Item is GridDataItem )
        {
            item = e.Item as GridDataItem;
        }

        int pk = Convert.ToInt32(item["Pk"].Text);
        ApplyUpdateBase_REPO applyRepo = new ApplyUpdateBase_REPO();
        ApplyUpdateBase obj = applyRepo.GetByPk(pk);
        if ( obj == null )
            return;
        else
        {
            obj.ApproveDatetime = DateTime.Now;
            obj.ApproveMan = JbUser.NOBR;
        }

        if ( e.CommandName.Equals("Unapprove") )
        {
            obj.Approve = false;
        }

        if ( e.CommandName.Equals("Approve") )
        {
            obj.Approve = true;
        }

        applyRepo.Update(obj);
        applyRepo.UpdateBase(obj);
        applyRepo.Save();
        gv.Rebind();
    }
    protected void gv_DetailTableDataBind(object sender , GridDetailTableDataBindEventArgs e)
    {
        //GridDataItem item = (GridDataItem) e.DetailTableView.ParentItem;
        //ApplyUpdateBaseOldView obj = new ApplyUpdateBaseOldView();
        //int pk = Convert.ToInt32(item["Pk"].Text);

        //ApplyUpdateBase_REPO upRepo = new ApplyUpdateBase_REPO();
        //ApplyUpdateBase objUp= upRepo.GetByPk(pk);

        //obj.GSM = objUp.GSM_Old;
        //obj.EMAIL = objUp.EMAIL_Old;
        //obj.TEL1 = objUp.TEL1_Old;
        //obj.TEL2 = objUp.TEL2_Old;
        //obj.POSTCODE1 = objUp.POSTCODE1_Old;
        //obj.POSTCODE2 = objUp.POSTCODE2_Old;
        //obj.ADDR2 = objUp.ADDR2_Old;
        //obj.PROVINCE = objUp.PROVINCE_Old;
        //obj.BORN_ADDR = objUp.BORN_ADDR_Old;
        //obj.CONT_MAN = objUp.CONT_MAN_Old;

        //RELCODE_REPO relcodeRepo = new RELCODE_REPO();
        //RELCODE relcodeObj = relcodeRepo.GetByPk(objUp.CONT_REL1);
        //obj.CONT_REL1_NAME = relcodeObj != null ? relcodeObj.REL_NAME : "";
        //obj.CONT_TEL = objUp.CONT_TEL_Old;
        //obj.CONT_GSM = objUp.CONT_GSM_Old;
        //obj.CONT_MAN2 = objUp.CONT_MAN2_Old;

        //RELCODE relcodeObj2 = relcodeRepo.GetByPk(objUp.CONT_REL2);
        //obj.CONT_REL2_NAME = relcodeObj2 != null ? relcodeObj2.REL_NAME : "";
        //obj.CONT_TEL2 = objUp.CONT_TEL2_Old;
        //obj.CONT_GSM2 = objUp.CONT_GSM2_Old;
        //List<ApplyUpdateBaseOldView> oldList = new List<ApplyUpdateBaseOldView>();
        //oldList.Add(obj);
        //e.DetailTableView.DataSource = oldList;
    }
    protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
    {
        RadMultiPage1.SelectedIndex = RadTabStrip1.SelectedIndex;
    }
    protected void addBtn_Click(object sender, EventArgs e)
    {
        NotifyApplyUpdateBase obj = new NotifyApplyUpdateBase();
        obj.Nobr = tbNobr.Text;
        obj.DataGroup = dgCbx.SelectedValue;

        BASE_REPO baseRepo = new BASE_REPO();
        BASE baseObj= baseRepo.GetByNobr(obj.Nobr);
        if (baseObj == null)
        {
            RadAjaxPanel1.Alert("查無此員工!1");
            return;
        }
        
        naubRepo.Add(obj);
        naubRepo.Save();
        gvNotify.Rebind();
    }
    protected void gvNotify_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        gvNotify.DataSource = (from c in naubRepo.GetAll_Dlo()
                               select new
                               {
                                   DpName = c.DATAGROUP1.GROUPNAME,
                                   Id = c.Id,
                                   Nobr = c.Nobr,
                                   Email = c.BASE.EMAIL,
                                   Name = c.BASE.NAME_C
                               }).ToList();
    }
    protected void gvNotify_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName.Equals("Del"))
        {
            GridDataItem item = e.Item as GridDataItem;
            int id = Convert.ToInt32(item["Id"].Text);
            NotifyApplyUpdateBase obj = naubRepo.GetByPk(id);
            naubRepo.Delete(obj);
            naubRepo.Save();
            gvNotify.Rebind();
        }

    }
}
