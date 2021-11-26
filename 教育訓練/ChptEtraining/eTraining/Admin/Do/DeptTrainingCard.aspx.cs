using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Repo;

public partial class eTraining_Admin_Do_DeptTrainingCard : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    OjtUnitCard_Repo ojtUnitCardRepo = new OjtUnitCard_Repo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteHelper help = new SiteHelper();
            help.setDeptTv(tvDept);
            RadTabStrip1.SelectedIndex = 0;
            RadMultiPage1.PageViews[RadTabStrip1.SelectedTab.PageView.Index].Selected = true;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //將所選取的職能積分卡及部門加入OJTDeptCard
        //List<OjtDeptCard> DeptCard = new List<OjtDeptCard>();
        if (IsRefresh)
        {
            gvUnitCard.Rebind();
            return;
        }

        var OjtUnitCardList = (from c in dcTrain.OjtUnitCard select c).ToList();

        try
        {
            foreach (var itm in tvDept.CheckedNodes)
            {
                //判斷是否有重覆資料
                var d = (from c in OjtUnitCardList
                         where c.OjtUnit == itm.Value &&
                             c.OjtCard == cbxOJT.SelectedValue
                         select c).FirstOrDefault();
                //無重覆資料才新增
                if (d == null)
                {
                    var r = new OjtUnitCard();
                    r.OjtUnit = itm.Value;
                    r.OjtCard = cbxOJT.SelectedValue;
                    r.sKeyMan = User.Identity.Name;
                    r.dKeyDate = DateTime.Now;
                    dcTrain.OjtUnitCard.InsertOnSubmit(r);
                }
            }

            dcTrain.SubmitChanges();
            gvUnitCard.Rebind();
        }
        catch (Exception ex)
        {
            AlertMsg(ex.Message);
        }
    }
    protected void gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {        
        var a = ojtUnitCardRepo.GetAllByOjtCardValid_DLO();
        gvUnitCard.DataSource = (from c in a
                         select new {deptName = c.DEPT.D_NAME,
                             ojtCardName = c.trOJTTemplate.sName,
                         iAutoKey = c.iAutoKey});
    }
    protected void gv_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        OjtUnitCard_Repo t = new OjtUnitCard_Repo(dcTrain);
        GridDataItem item  = e.Item as GridDataItem;        
        t.Delete(Convert.ToInt32(item["iAutoKey"].Text));
        t.Save();
        gvUnitCard.Rebind();
    }
}