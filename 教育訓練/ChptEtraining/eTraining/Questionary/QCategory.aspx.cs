using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Telerik.Web.UI;
using Repo;

public partial class eTraining_Questionary_QCategory : JBWebPage
{
    QCategory_Repo qCatRepo = new QCategory_Repo();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void loadData(string code)
    {
        QCategory obj= qCatRepo.GetByPk(code);
        if (obj != null)
        {
            tbName.Text = obj.Name;
        }

    }


    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        QCategory_Repo qCatRepo = new QCategory_Repo();
        gv.DataSource = qCatRepo.GetAll();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        QCategory obj = new QCategory();
        obj.Code = Guid.NewGuid().ToString();
        obj.Name = tbName.Text;
        qCatRepo.Add(obj);
        qCatRepo.Save();
        gv.Rebind();

    }
    protected void gv_ItemCommand(object sender, GridCommandEventArgs e)
    {
        GridDataItem item = null;
        if (e.Item is GridDataItem)
            item = e.Item as GridDataItem;

        if (e.CommandName.Equals("Del"))
        {
            if (item != null)
            {
                QTplCategory_Repo tplCatRepo = new QTplCategory_Repo();
                List<QTplCategory> list= tplCatRepo.GetByCatCode(item["Code"].Text);
                if (list.Count > 0)
                {
                    Show("此類別以關聯到問卷，無法刪除");
                }
                else
                {
                    QCategory obj = qCatRepo.GetByPk(item["Code"].Text);
                    qCatRepo.Delete(obj);
                    qCatRepo.Save();
                    gv.Rebind();
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (gv.SelectedItems.Count > 0)
        {
            QCategory obj = qCatRepo.GetByPk(gv.SelectedValue.ToString());
            obj.Name = tbName.Text;
            qCatRepo.Update(obj);
            qCatRepo.Save();
            gv.Rebind();
        }
        else
            Show("尚未選擇類別，無法更新");            
    }
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadData(gv.SelectedValue.ToString());
    }
}