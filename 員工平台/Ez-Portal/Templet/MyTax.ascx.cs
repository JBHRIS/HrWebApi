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
using JB.WebModules.Authentication;
using BL;
using System.Linq;
public partial class Templet_MyTax : JBUserControl, IUC
{
    protected void Page_Init(object sender, EventArgs e)
    {
        //JBHRModel.JBHRModelDataContext dc = new JBHRModel.JBHRModelDataContext();
        //var value = (from c in dc.U_SYS9 select c).FirstOrDefault();
        //ntbInputTaxFixRate.MinValue = Convert.ToDouble(value.FIXTAXRATE * 100);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    void getData()
    {
        //BASE_REPO baseRepo = new BASE_REPO();
        //BASE baseObj = baseRepo.GetByNobr_Dlo(lblNobr.Text);
        //if (baseObj == null)
        //    return;

        //lblPay.Text = Convert.ToInt32(baseObj.BASETTS[0].RETRATE * 100).ToString();

        //if (baseObj.BASETTS[0].FIXRATE)//固定稅率
        //{
        //    lblIncomeTaxNum.Text = (Convert.ToInt32(baseObj.BASETTS[0].FIXRATE_P * 100)).ToString();
        //    lblTaxPostfix.Visible = true;
        //    cbFixRate.Checked = true;
        //}
        //else
        //{
        //    lblIncomeTaxNum.Text = "依級距表";
        //    lblTaxPostfix.Visible = false;
        //    cbFixRate.Checked = false;
        //}

        //cbFixRate_CheckedChanged(this, null);
    }

    public void SetValue(string value)
    {
        lblNobr.Text = value;
    }

    public void BindData()
    {
        getData();
    }
    protected void btnTaxEdit_Click(object sender, EventArgs e)
    {
        btnTaxEdit.Visible = false;
        pnlTaxForm.Visible = true;
    }
    protected void btnTaxSubmit_Click(object sender, EventArgs e)
    {
        //BASE_REPO baseRepo = new BASE_REPO();
        //BASE baseObj = baseRepo.GetEmpByNobrNow_DLO(lblNobr.Text);
        //if (baseObj == null)
        //    return;

        //baseObj.BASETTS[0].FIXRATE = cbFixRate.Checked;
        //BASETTS_REPO ttsRepo =new BASETTS_REPO();

        //if (cbFixRate.Checked)
        //{
        //    if (ntbInputTaxFixRate.Value.HasValue)
        //    {
        //        baseObj.BASETTS[0].FIXRATE_P = ((Decimal)ntbInputTaxFixRate.Value / (Decimal)100);
        //    }
        //    else
        //        return;
        //}

        //ttsRepo.Update(baseObj.BASETTS[0]);
        //ttsRepo.Save();

        //getData();
        //pnlTaxForm.Visible = false;
        //btnTaxEdit.Visible = true;
    }
    protected void btnTaxCancel_Click(object sender, EventArgs e)
    {
        getData();
        pnlTaxForm.Visible = false;
        btnTaxEdit.Visible = true;
    }
    protected void btnPensionEdit_Click(object sender, EventArgs e)
    {
        pnlPension.Visible = true;
        btnPensionEdit.Visible = false;
    }
    protected void btnPensionSubmit_Click(object sender, EventArgs e)
    {
        BASE_REPO baseRepo = new BASE_REPO();
        BASE baseObj = baseRepo.GetEmpByNobrNow_DLO(lblNobr.Text);
        if (baseObj == null)
            return;

        BASETTS_REPO ttsRepo = new BASETTS_REPO();

        if (ntbInputPensionRate.Value.HasValue)
        {
            baseObj.BASETTS[0].RETRATE = ((Decimal)ntbInputPensionRate.Value / (Decimal)100);
        }
        else
        {
            return;
        }

        ttsRepo.Update(baseObj.BASETTS[0]);
        ttsRepo.Save();

        getData();
        pnlPension.Visible = false;
        btnPensionEdit.Visible = true;
    }
    protected void btnPensionCancel_Click(object sender, EventArgs e)
    {
        getData();
        pnlPension.Visible = false;
        btnPensionEdit.Visible = true;
    }
    protected void cbFixRate_CheckedChanged(object sender, EventArgs e)
    {
        if (cbFixRate.Checked)
            ntbInputTaxFixRate.Enabled = true;
        else
            ntbInputTaxFixRate.Enabled = false;
    }
}
