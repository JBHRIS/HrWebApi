using System;
using System.Collections.Generic;
using System.Linq;
using BL;
using Telerik.Web.UI;

public partial class eTraining_Questionary_QTplCategoryRel : JBWebPage
{
    private QCategory_Repo qCatRepo = new QCategory_Repo();
    private QTplCategory_Repo qTplCatRepo = new QTplCategory_Repo();
    private QDetail_Repo qDetailRepo = new QDetail_Repo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] == null)
                throw new ApplicationException("未帶入參數");

            loadData(Request.QueryString["Id"].ToString());
        }
    }

    private void loadData(string code)
    {
        bindLb();
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    private void bindLb()
    {
        var catList = qCatRepo.GetAll();
        var tplCatList = qTplCatRepo.GetByTplCode_Dlo(Request.QueryString["Id"].ToString()).OrderBy(p => p.Sequence);

        lb2.DataSource = tplCatList.Select(p => p.QCategory);
        lb2.DataBind();
        catList.RemoveAll(p => tplCatList.Select(c => c.QCategoryCode).Contains(p.Code));
        lb1.DataSource = catList;
        lb1.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        var catList = qCatRepo.GetAll();
        var tplCatList = qTplCatRepo.GetByTplCode(Request.QueryString["Id"].ToString());

        List<string> tplCatValueList = tplCatList.Select(p => p.QCategoryCode).ToList();
        List<string> lb2ValueList = lb2.Items.Select(p => p.Value).ToList();

        string[] tempArr = new string[tplCatValueList.Count];
        tplCatValueList.CopyTo(tempArr);

        //原儲存的排除掉目前所選的，剩下的是要新增的
        List<string> tempList = tempArr.ToList();
        tempList.RemoveAll(p => lb2ValueList.Contains(p));

        foreach (string temp in tempList)
        {
            QTplCategory obj = (from c in tplCatList where c.QCategoryCode == temp select c).FirstOrDefault();
            List<QDetail> qDetailList = qDetailRepo.GetByTplCatId(obj.Id);
            if (qDetailList.Count > 0)
            {
                var catObj = catList.Find(p => p.Code == obj.QCategoryCode);
                Show(catObj.Name + "已連結問卷，無法取消");
                return;
            }
            else
            {
                qTplCatRepo.Delete(obj);
            }
        }

        //目前所選，排除掉原本儲存的，就是要新增的項目
        //tempArr目前lb2儲存的資料順序
        tempArr = new string[lb2ValueList.Count];
        lb2ValueList.CopyTo(tempArr);
        tempList = tempArr.ToList();
        tempList.RemoveAll(p => tplCatValueList.Contains(p));

        foreach (string temp in tempList)
        {
            QTplCategory tplCatObj = new QTplCategory();
            tplCatObj.QCategoryCode = temp;
            tplCatObj.QTplCode = Request.QueryString["Id"].ToString();

            //新增的部分要處理一下儲存的順序
            //tplCatObj.Sequence= tempArr.ToList().FindIndex(p => p == temp)+1;
            tplCatObj.Sequence = tempArr.FindIndex(p => p == temp) + 1;

            qTplCatRepo.Add(tplCatObj);
        }

        //處理一下目前選擇的順序
        foreach (string s in tempArr)
        {
            QTplCategory tplCatObj = tplCatList.Find(p => p.QTplCode == Request.QueryString["Id"].ToString() && p.QCategoryCode == s);
            //tplCatObj.Sequence = tempArr.ToList().FindIndex(0, tempArr.ToList().Count, s) + 1;
            if (tplCatObj != null)
            {
                tplCatObj.Sequence = tempArr.FindIndex(p => p == s) + 1;
                qTplCatRepo.Update(tplCatObj);
            }
        }

        qTplCatRepo.Save();

        bindLb();
        Show("已儲存");
    }

    protected void lb1_ItemDataBound(object sender, RadListBoxItemEventArgs e)
    {
        if (e.Item.Index % 2 == 0)
            e.Item.ForeColor = System.Drawing.Color.RoyalBlue;
    }

    protected void lb2_ItemDataBound(object sender, RadListBoxItemEventArgs e)
    {
        if (e.Item.Index % 2 == 0)
            e.Item.ForeColor = System.Drawing.Color.RoyalBlue;
    }
}