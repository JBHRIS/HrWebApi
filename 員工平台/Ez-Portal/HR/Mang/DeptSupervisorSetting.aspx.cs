﻿using System;
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
using BL;
using JBHRModel;
using System.Linq;
using Telerik.Web.UI;

public partial class DeptSupervisorSetting : JBWebPage
{
    private DEPT_REPO dept_repo = new DEPT_REPO();
    protected void Page_Load(object sender, EventArgs e) 
    {
        UserQuickSearch1.sHandler += new UC_UserQuickSearch.SelectedEventHandler(UserQuickSearch1_sHandler);

        if (!IsPostBack) 
        {
            SiteHelper.SetAllDeptTree(TreeView1);
        }
    }

    void UserQuickSearch1_sHandler(string nobr, Telerik.Web.UI.GridDataItem sItem)
    {
        lblNobr.Text = nobr;
        //lblSearchBy.Text = "nobr";
        //gv.DataSourceID = "sdsQuickSearch";
        //gv.Rebind();
    }




    protected void Button1_Click(object sender, EventArgs e) 
    {
        gv.Rebind();
    }

    protected void gv_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        DeptSupervisor_REPO deptSupervisorRepo = new DeptSupervisor_REPO();
        List<DeptSupervisor> list = new List<DeptSupervisor>();
        if (ddlSearchType.SelectedValue.Equals("0"))
            list = deptSupervisorRepo.GetBySupervisorNobr_DLO(lblNobr.Text);
        else if (ddlSearchType.SelectedValue.Equals("1"))
            list = deptSupervisorRepo.GetByDept_DLO(TreeView1.SelectedValue);
        else
            list = deptSupervisorRepo.GetAll_Dlo();

        gv.DataSource = (from c in list
                         select new
                         {
                             //DeptCode = c.D_No,
                             DeptCode = c.DEPT.D_NO_DISP,
                             DeptName = c.DEPT.D_NAME,
                             Nobr = c.SupervisorNobr,
                             Name_C = c.BASE.NAME_C,
                             AddOrDel = c.AddOrDel == true ? "增加" : "排除",
                             AutoKey = c.AutoKey
                         }).ToList();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        
        if (lblNobr.Text.Trim().Length <= 0 && TreeView1.SelectedNode == null)
        {
            JB.WebModules.Message.Show("請選擇部門及人員");
        }
        else
        {
            DeptSupervisor obj = new DeptSupervisor();
            obj.SupervisorNobr = lblNobr.Text.Trim();
            obj.KeyMan = User.Identity.Name;
            obj.KeyDate = DateTime.Now;
            obj.D_No = TreeView1.SelectedValue;
            if (ddlType.SelectedValue.Equals("1"))
                obj.AddOrDel = true;
            else
                obj.AddOrDel = false;

            DeptSupervisor_REPO deptSupervisorRepo = new DeptSupervisor_REPO();
            deptSupervisorRepo.Add(obj);
            deptSupervisorRepo.Save();
            gv.Rebind();
        }

    }
    protected void gv_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            GridDataItem item = (GridDataItem)e.Item;
            int autoKey = Convert.ToInt32(item.OwnerTableView.DataKeyValues[item.ItemIndex]["AutoKey"].ToString());

            DeptSupervisor_REPO deptSupervisorRepo = new DeptSupervisor_REPO();
            DeptSupervisor obj= deptSupervisorRepo.GetByPk(autoKey);
            if (obj != null)
            {
                deptSupervisorRepo.Delete(obj);
                deptSupervisorRepo.Save();
                gv.Rebind();
            }
        }
    }
}
