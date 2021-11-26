using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
using Telerik.Web.UI;

public partial class eTraining_System_OJTDept : JBWebPage
{
    private dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    OjtUnitCard_Repo ojtUnitCardRepo = new OjtUnitCard_Repo();
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gvUnitCard);

        if (!IsPostBack)
        {
            SiteHelper help = new SiteHelper();
            help.setDeptTv(tvDept);
            RadTabStrip1.SelectedIndex = 0;
            RadMultiPage1.PageViews[RadTabStrip1.SelectedTab.PageView.Index].Selected = true;
            SiteHelper.ConverToChinese(gvUnitCard);
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var data = (from c in dcTrain.OjtVerificationUnit
                    where c.OjtUnit == cbxOjtUnit.SelectedValue
                    && c.VerificationUnit == cbxOjtVerificationUnit.SelectedValue
                    select c).FirstOrDefault();

        if (data == null)
        {
            OjtVerificationUnit obj = new OjtVerificationUnit();
            obj.OjtUnit = cbxOjtUnit.SelectedValue;
            obj.VerificationUnit = cbxOjtVerificationUnit.SelectedValue;
            obj.sKeyMan = User.Identity.Name;
            obj.dDateTime = DateTime.Now;
            dcTrain.OjtVerificationUnit.InsertOnSubmit(obj);
            dcTrain.SubmitChanges();
            gv.Rebind();
        }
    }
    protected void btnAddOjtCheckUnit_Click(object sender, EventArgs e)
    {
        OjtCheckUnit_Repo ojtCheckUnitRepo = new OjtCheckUnit_Repo(dcTrain);
        if (ojtCheckUnitRepo.GetByCheckUnitOjtUnit(cbxOjtCheckUnit.SelectedValue, cbxOjtDept2.SelectedValue) == null)
        {
            OjtCheckUnit ojtCheckUnit = new OjtCheckUnit();
            ojtCheckUnit.OjtUnit = cbxOjtDept2.SelectedValue;
            ojtCheckUnit.CheckUnit = cbxOjtCheckUnit.SelectedValue;
            ojtCheckUnit.sKeyMan = User.Identity.Name;
            ojtCheckUnit.dKeyDate = DateTime.Now;
            ojtCheckUnitRepo.Add(ojtCheckUnit);
            ojtCheckUnitRepo.Save();
            gvCheckUnit.Rebind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        //將所選取的職能積分卡及部門加入OJTDeptCard
        //List<OjtDeptCard> DeptCard = new List<OjtDeptCard>();
        //if (IsRefresh)
        //{
        //    gv.Rebind();
        //    return;
        //}

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
            tvDept.UncheckAllNodes();
        }
        catch (Exception ex)
        {
            RadAjaxPanel1.Alert(ex.Message);
        }
    }
    protected void gvUnitCard_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        OjtUnitCard_Repo t = new OjtUnitCard_Repo(dcTrain);
        GridDataItem item = e.Item as GridDataItem;
        t.Delete(Convert.ToInt32(item["iAutoKey"].Text));
        t.Save();
        gvUnitCard.Rebind();
    }
    protected void gvUnitCard_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        gvUnitCard.DataSource = (from c in ojtUnitCardRepo.GetAllByOjtCardValid_DLO()
                                 select new
                                 {
                                     deptName = c.DEPT.D_NO+" "+ c.DEPT.D_NAME,                                     
                                     ojtCardName = c.trOJTTemplate.sName,
                                     iAutoKey = c.iAutoKey
                                 });
    }
}