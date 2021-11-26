using BL;
using System;
using Telerik.Web.UI;

public partial class System_MarqueeSetting : JBWebPage
{
    private Marquee_Repo mRepo = new Marquee_Repo();
    protected override void OnInit(EventArgs e)
    {
        CanCopy = true;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteHelper sh = new SiteHelper();
            sh.SetDateRangeForLatestYear(dpB, dpE);
        }
    }

    protected void gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        gv.DataSource = mRepo.GetAll();
    }

    private void loadData(int id)
    {
        Marquee o = mRepo.GetByPK(Convert.ToInt32(lblId.Text));
        etDisplayText.Content = o.DisplayText;
        cbEnable.Checked = o.Enable;
        dpB.SelectedDate = o.StartDate;
        dpE.SelectedDate = o.EndDate;
    }

    protected void gv_ItemCommand(object sender, GridCommandEventArgs e)
    {
        GridDataItem item = e.Item as GridDataItem;

        if (e.CommandName.Equals("Del"))
        {
            var o = mRepo.GetByPK(Convert.ToInt32(item["ID"].Text));
            mRepo.Delete(o);
            mRepo.Save();
            gv.Rebind();
        }
        else if (e.CommandName.Equals("Edt"))
        {
            lblId.Text = item["ID"].Text;
            loadData(Convert.ToInt32(lblId.Text));
            changeFormMode(FormMode.Update);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        changeFormMode(FormMode.View);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FormMode fm = (FormMode)Enum.Parse(typeof(FormMode), lblFormMode.Text);
        if (fm == FormMode.Insert)
        {
            Marquee o = new Marquee();
            o.DisplayText = etDisplayText.Content;
            o.Enable = cbEnable.Checked;
            o.StartDate = dpB.SelectedDate.Value;
            o.EndDate = dpE.SelectedDate.Value;
            mRepo.Add(o);
            mRepo.Save();
            gv.Rebind();
        }
        else if (fm == FormMode.Update)
        {
            pnlAddForm.Visible = true;
            Marquee o = mRepo.GetByPK(Convert.ToInt32(lblId.Text));
            o.DisplayText = etDisplayText.Content;
            o.Enable = cbEnable.Checked;
            o.StartDate = dpB.SelectedDate.Value;
            o.EndDate = dpE.SelectedDate.Value;
            mRepo.Update(o);
            mRepo.Save();
            gv.Rebind();
        }

        changeFormMode(FormMode.View);
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        changeFormMode(FormMode.Insert);
    }

    private void changeFormMode(FormMode mode)
    {
        lblFormMode.Text = mode.ToString();
        if (mode == FormMode.Insert)
        {
            pnlAddForm.Visible = true;
            btnNew.Visible = false;
        }
        else if (mode == FormMode.Update)
        {
            pnlAddForm.Visible = true;
            btnNew.Visible = false;
        }
        else if (mode == FormMode.View)
        {
            pnlAddForm.Visible = false;
            etDisplayText.Content = "";
            cbEnable.Checked = false;
            btnNew.Visible = true;
        }
    }
}