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

public partial class Mang_MangSelectOt : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1");
            ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        FEFC_AttendDS.FRM29DataTable f29dt = new FEFC_AttendDS.FRM29DataTable();


        TreeView tv = new TreeView();
        SiteHelper sh = new SiteHelper();
        sh.InitManagerDeptTreeView(tv,Juser.ManageDeptRootNodeList);

        List<TreeNode> nodeList = SiteHelper.GetTreeViewAllNodes(tv); 

        if (RadioButton1.Checked)
        {
            foreach (var d in nodeList)
            {
                f29dt.Merge(getF29ByAdate(adate.SelectedDate.Value, ddate.SelectedDate.Value, d.Value));
            }
        }
        else 
        {
            for (int i = 0; i < nodeList.Count; i++)
            {
                f29dt.Merge(getF29ByYYMM(tb_yymm.Text, nodeList[i].Value));
            }
        }

        tb_count.Text = "此查詢筆數為：" + f29dt.Rows.Count.ToString();
        ot_select.DataSource = f29dt;
        ot_select.DataBind();


        FEFC_AttendDS.OtSelectDataTable odt = new FEFC_AttendDS.OtSelectDataTable();

        
        
        for (int i = 0; i < f29dt.Rows.Count; i++) {
            FEFC_AttendDS.OtSelectRow[] otrows = (FEFC_AttendDS.OtSelectRow[])odt.Select("dept ='" + f29dt[i].D_NO.Trim() + "'");

            if (otrows.Length > 0) {

                if (f29dt[i].isHoli==1)
                {
                    otrows[0].h_ot_r += f29dt[i].REST_HRS;
                    otrows[0].h_ot_t += f29dt[i].OT_HRS;
                }
                else
                {
                    otrows[0].ot_r += f29dt[i].REST_HRS;
                    otrows[0].ot_t += f29dt[i].OT_HRS;
                }
            
            }
            else {
                FEFC_AttendDS.OtSelectRow arow = odt.NewOtSelectRow();
                arow.dept = f29dt[i].D_NO;
                arow.ot_r = 0;
                arow.ot_t = 0;
                arow.h_ot_r = 0;
                arow.h_ot_t = 0;


                if (f29dt[i].isHoli==1)
                {
                    arow.h_ot_r += f29dt[i].REST_HRS;
                    arow.h_ot_t += f29dt[i].OT_HRS;
                }
                else 
                {
                    arow.ot_r += f29dt[i].REST_HRS;
                    arow.ot_t += f29dt[i].OT_HRS;
                }




                odt.AddOtSelectRow(arow);
            }

        
        }

        gv_otSelect.DataSource = odt;
        gv_otSelect.DataBind();

       
    }


    FEFC_AttendDS.FRM29DataTable getF29ByAdate(DateTime adate, DateTime ddate, string dept)
    {
        FEFC_AttendDSTableAdapters.FRM29TableAdapter f29ad = new FEFC_AttendDSTableAdapters.FRM29TableAdapter();
        FEFC_AttendDS.FRM29DataTable f29dt = f29ad.GetDataByAdate(adate, ddate, dept);
        return f29dt;
    }
    FEFC_AttendDS.FRM29DataTable getF29ByYYMM(string yymm, string dept)
    {
        FEFC_AttendDSTableAdapters.FRM29TableAdapter f29ad = new FEFC_AttendDSTableAdapters.FRM29TableAdapter();
        FEFC_AttendDS.FRM29DataTable f29dt = f29ad.GetDataByYYMM(yymm, dept);
        return f29dt;
    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        MultiView1.ActiveViewIndex = int.Parse(Menu1.SelectedValue);
    }
    decimal o1, o2, o3, o4 = 0;
    
    protected void gv_otSelect_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            o1 += decimal.Parse(e.Row.Cells[1].Text);
            o2 += decimal.Parse(e.Row.Cells[2].Text);
            o3 += decimal.Parse(e.Row.Cells[3].Text);
            o4 += decimal.Parse(e.Row.Cells[4].Text);

        }
        else if (e.Row.RowType == DataControlRowType.Footer) {
            e.Row.Cells[0].Text = "總計：";
            e.Row.Cells[1].Text = o1.ToString();
            e.Row.Cells[2].Text = o2.ToString();
            e.Row.Cells[3].Text = o3.ToString();
            e.Row.Cells[4].Text = o4.ToString();

        }
    }
}
