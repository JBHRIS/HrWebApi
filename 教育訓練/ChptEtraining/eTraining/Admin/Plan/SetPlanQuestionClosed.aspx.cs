using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;

public partial class eTraining_Admin_Plan_SetPlanQuestionClosed : JBWebPage
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AllPageDataBound();
        }
    }

    //資料載入
    protected void AllPageDataBound()
    {
        //下拉載入
        trRequirementTemplateRecord_Repo rtr_Repo = new trRequirementTemplateRecord_Repo();
        var AllData = rtr_Repo.GetAll();

        CB_Year.DataSource = AllData;
        CB_Year.DataTextField = "iYear";
        CB_Year.DataValueField = "iYear";
        CB_Year.DataBind();

        //CheckBox
        SetCheckBox();
    }

    //設定CheckBox
    protected void SetCheckBox()
    {
        int iYear = 0;
        if (!string.IsNullOrEmpty(CB_Year.SelectedValue) && Int32.TryParse(CB_Year.SelectedValue, out iYear))
        {
            trRequirementTemplateRecord_Repo rtr_Repo = new trRequirementTemplateRecord_Repo();
            var data = rtr_Repo.GetByYear(iYear);

            if (data != null) CB_IsClose.Checked = data.bIsClosed;
        }
    }

    //(cb)change
    protected void CB_Year_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        SetCheckBox();
    }

    //(btn)存檔
    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        int iYear = 0;
        if (!string.IsNullOrEmpty(CB_Year.SelectedValue) && Int32.TryParse(CB_Year.SelectedValue, out iYear))
        {
            trRequirementTemplateRecord_Repo rtr_Repo = new trRequirementTemplateRecord_Repo();
            var data = rtr_Repo.GetByYear(iYear);

            if (data != null)
            {
                data.dClosedDate = DateTime.Now;
                data.bIsClosed = CB_IsClose.Checked;
                rtr_Repo.Update(data);
                rtr_Repo.Save();
                AlertMsg("存檔完畢");
            }
        }              
    }

}