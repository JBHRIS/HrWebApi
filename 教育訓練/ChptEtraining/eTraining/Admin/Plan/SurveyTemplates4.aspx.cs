using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
using Telerik.Web.UI;
using System.Collections;

public partial class eTraining_Admin_Plan_SurveyTemplates4 : JBWebPage
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
        SiteHelper sh = new SiteHelper();
        sh.SetTvCourseCat(TV_Course);
        sh.SetTvCourse(TV_Course);
    }

    //跳窗
    protected void UseWindowWithScript(string ClientID)
    {
        string script = "function f(){$find(\"" + ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
    }

    //Grid 資料
    protected void Gv_Main_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        trRequirementTemplate_Repo rtRepo = new trRequirementTemplate_Repo();
        Gv_Main.DataSource = rtRepo.GetAll();
    }

    //Grid 事件
    protected void Gv_Main_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName.Equals("AddData"))
        {
            TB_AddData_Name.Text = "";
            Lbl_AddData_Msg.Text = "";
            UseWindowWithScript(Wd_AddData.ClientID);
        }
        else
        {
            object sCodeKey = Gv_Main.MasterTableView.DataKeyValues[e.Item.ItemIndex]["sCode"];
            object sNameKey = Gv_Main.MasterTableView.DataKeyValues[e.Item.ItemIndex]["sName"];

            if (sCodeKey == null) return;

            string sCode = sCodeKey.ToString();

            if (e.CommandName.Equals("LinkData"))
            {
                Btn_LinkData_Add.CommandArgument = sCode;
                Btn_LinkData_Save.CommandArgument = sCode;
                Btn_LinkData_Cancel.CommandArgument = sCode;
                Wd_LinkData.Title = sNameKey == null ? "" : sNameKey.ToString();
                LinkData_CourseBound(sCode);
                UseWindowWithScript(Wd_LinkData.ClientID);
            }
            else if (e.CommandName.Equals("EditData"))
            {
                Wd_EditData.Title = sNameKey == null ? "" : sNameKey.ToString();
                HidFld_sCode.Value = sCode;
                EditData_CourseBound(sCode);
                UseWindowWithScript(Wd_EditData.ClientID);
            }
        }
    }

    //(btn)新增儲存
    protected void Btn_AddData_Save_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TB_AddData_Name.Text) || string.IsNullOrWhiteSpace(TB_AddData_Name.Text)) return;

        string aName = TB_AddData_Name.Text.Trim();

        string sCode = Guid.NewGuid().ToString();

        trRequirementTemplate_Repo rtRepo = new trRequirementTemplate_Repo();

        trRequirementTemplate aNew = new trRequirementTemplate();
        aNew.sCode = sCode;
        aNew.sName = aName;
        aNew.dKeyDate = DateTime.Now;
        aNew.sKeyMan = User.Identity.Name;

        try
        {
            rtRepo.Add(aNew);
            rtRepo.Save();
        }
        catch
        {
            Lbl_AddData_Msg.Text = "資料異常，或重複輸入!!";
            UseWindowWithScript(Wd_AddData.ClientID);
        }

        Gv_Main.Rebind();
    }

    #region =====================================關聯課程==========================================

    //關聯課程載入
    protected void LinkData_CourseBound(string sCode)
    {
        trRequirementTemplateCourse_Repo rtcRepo = new trRequirementTemplateCourse_Repo();
        List<trRequirementTemplateCourse> rtcList = rtcRepo.GetByRT_CodeDlo(sCode).OrderBy(p => p.Sequence).ToList();

        LB_LinkData_Course.Items.Clear();
        foreach (var o in rtcList)
        {
            RadListBoxItem item = new RadListBoxItem();
            item.Text = o.trCourse.sName;
            item.Value = o.CourseCode;
            LB_LinkData_Course.Items.Add(item);
        }
    }

    //(btn)加入
    protected void Btn_LinkData_Add_Command(object sender, CommandEventArgs e)
    {
        foreach (var p in TV_Course.SelectedNodes)
        {
            if (!p.Category.Equals("COURSE")) continue;

            if (!LB_LinkData_Course.Items.Any(i => i.Value == p.Value))
            {
                RadListBoxItem item = new RadListBoxItem();
                item.Text = p.Text;
                item.Value = p.Value;
                LB_LinkData_Course.Items.Add(item);
            }
        }
        UseWindowWithScript(Wd_LinkData.ClientID);
    }

    //(btn)儲存
    protected void Btn_LinkData_Save_Command(object sender, CommandEventArgs e)
    {
        string sCode = Btn_LinkData_Save.CommandArgument;

        bool Result = false;

        if (sCode == null) Result = false;
        else
        {
            trRequirementTemplateCourse_Repo rtcRepo = new trRequirementTemplateCourse_Repo();
            List<trRequirementTemplateCourse> rtcList = rtcRepo.GetByRT_CodeDlo(sCode);

            int iSort = 0;
            foreach (RadListBoxItem item in LB_LinkData_Course.Items)
            {
                trRequirementTemplateCourse obj = rtcList.FirstOrDefault(m => m.CourseCode == item.Value);

                if (obj == null)
                {
                    obj = new trRequirementTemplateCourse();
                    obj.Sequence = iSort;
                    obj.RT_Code = sCode;
                    obj.CourseCode = item.Value;
                    rtcRepo.Add(obj);
                }
                else
                {
                    obj.Sequence = iSort;
                    rtcRepo.Update(obj);
                }
                iSort++;
            }

            var DeleteLink = rtcList.Where(m => !LB_LinkData_Course.Items.Select(p => p.Value).Contains(m.CourseCode)).ToList();

            foreach (var r in DeleteLink)
            {
                rtcRepo.Delete(r);
            }

            try
            {
                rtcRepo.Save();
                Result = true;
            }
            catch (Exception)
            {
                Result = false;
            }
        }

        if (!Result) UseWindowWithScript(Wd_LinkData.ClientID);        
    }

    //(btn)取消
    protected void Btn_LinkData_Cancel_Command(object sender, CommandEventArgs e)
    {
        string sCode = Btn_LinkData_Cancel.CommandArgument;
        if (sCode == null) return;
        LinkData_CourseBound(sCode);
        UseWindowWithScript(Wd_LinkData.ClientID);
    }

    #endregion

    #region =====================================檢視範本==========================================

    //關聯課程載入
    protected void EditData_CourseBound(string sCode)
    {
        trRequirementTemplateCourse_Repo rtcRepo = new trRequirementTemplateCourse_Repo();
        List<trRequirementTemplateCourse> rtcList = rtcRepo.GetByRT_CodeDlo(sCode).OrderBy(p => p.Sequence).ToList();
        Gv_LinkCourse.DataSource = rtcList.Select(m => new { ID = m.Id, m.CourseCode, m.Sequence, CourseName = m.trCourse.sName, m.Budget }).ToList();
        Gv_LinkCourse.DataBind();
    }

    //事件
    protected void Gv_LinkCourse_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "Update")
        {
            GridEditableItem EditedItem = e.Item as GridEditableItem;
            Hashtable newValues = new Hashtable();
            EditedItem.OwnerTableView.ExtractValuesFromItem(newValues, EditedItem);

            object IDKey = Gv_LinkCourse.MasterTableView.DataKeyValues[EditedItem.ItemIndex]["ID"];                        
            
            int IntKey = 0 ;

            if (IDKey != null && int.TryParse(IDKey.ToString(), out IntKey))
            {
                int iBudget = 0;
                if (newValues["Budget"] != null &&
                    !string.IsNullOrEmpty((string)newValues["Budget"]) &&
                    Int32.TryParse((string)newValues["Budget"], out iBudget))
                {
                    try
                    {
                        trRequirementTemplateCourse_Repo rtcRepo = new trRequirementTemplateCourse_Repo();
                        var rtcObj = rtcRepo.GetByPk(IntKey);
                        rtcObj.Budget = iBudget;
                        rtcRepo.Update(rtcObj);
                        rtcRepo.Save();
                    }
                    catch (Exception)
                    {
                        EditedItem.Edit = true;
                    }
                }
                else EditedItem.Edit = true;
            }
            else EditedItem.Edit = true;
        }
        else if (e.CommandName == "Edit")
        {
            
        }
        else if (e.CommandName == "Cancel")
        {
        }

        EditData_CourseBound(HidFld_sCode.Value);
        UseWindowWithScript(Wd_EditData.ClientID);
    }

    #endregion

}