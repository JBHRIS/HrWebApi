using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using Repo;
public partial class eTraining_Manager_ConfirmOJT : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    private trOJTStudentM_Repo osmRepo = new trOJTStudentM_Repo();
    private trOJTStudentD_Repo ojtSD_REPO = new trOJTStudentD_Repo();
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gvNobr);
        if (!IsPostBack)
        {
            var dept = (from c in dcTraining.BASETTS
                        where c.NOBR == User.Identity.Name
                        && DateTime.Now.Date >= c.ADATE && DateTime.Now.Date <= c.DDATE
                        && new string[] { "1", "4", "6" }.Contains(c.TTSCODE)
                        select c).FirstOrDefault();

            if (dept != null)
            {
                var ojtConfirmDept = (from c in dcTraining.OjtVerificationUnit
                                      join d in dcTraining.DEPT on c.OjtUnit equals d.D_NO
                                      where c.VerificationUnit == dept.DEPT
                                      select new
                                      {
                                          c,
                                          d.D_NAME
                                      }).ToList();

                cbxDept.Items.Clear();

                foreach (var d in ojtConfirmDept)
                {
                    RadComboBoxItem item = new RadComboBoxItem();
                    item.Text = d.D_NAME;
                    item.Value = d.c.OjtUnit;
                    cbxDept.Items.Add(item);
                }

                if (cbxDept.Items.Count > 0)
                {
                    cbxDept.Items[0].Selected = true;
                    lblDept.Text = cbxDept.Items[0].Value;
                    gvEmp.Rebind();
                }
            }
        }
        this.Title = "區主管OJT確認";
    }

    //private void changeMode(string mode)
    //{
    //    if (mode == "v")
    //    {
    //        pnlOJT.Visible = true;
    //        pnlEdit.Visible = false;            
    //    }
    //    else if (mode == "e")
    //    {
    //        pnlOJT.Visible = false;
    //        pnlEdit.Visible = true;            
    //    }
    //    else if (mode == "l")
    //    {
    //        pnlOJT.Visible = false;
    //        pnlEdit.Visible = false;            
    //    }

    //}

    protected void gvEmp_SelectedIndexChanged(object sender, EventArgs e)
    {
        //osmRepo.CheckEmpOjtCard(gvEmp.SelectedValue.ToString()); 
        cbxCard.DataBind();
        gv.Rebind();

        //changeMode("v");
    }
    protected void sdsEmpData_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["@nobr"].Value = gvEmp.SelectedValue;
    }
    protected void sdsName_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        //e.Command.Parameters["@Manage"].Value = Page.User.Identity.Name;        
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        // changeMode("e");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!dpDate.SelectedDate.HasValue)
        {
            AlertMsg("需輸入日期");
            return;
        }

        //if (lblTeacherNobr.Text.Trim().Length == 0)
        //{
        //    Show("需選擇教導者");
        //    return;
        //}
        if (cbPass.Checked == true)
        {
            var data = (from c in dcTraining.trOJTStudentD
                        where c.sNobr == lblNobr.Text
                        && c.trCourse_sCode == lblCourseCode.Text
                        select c).FirstOrDefault();

            if (data != null)
            {
                data.bPass = true;
                //data.dCheckDate = dpDate.SelectedDate.Value;
                //data.sCheckMan = User.Identity.Name;
                data.sFinalCheckMan = User.Identity.Name;
                data.dFinalCheckDate = dpDate.SelectedDate.Value;
                //data.dOJT_Date = dpDate.SelectedDate.Value;
                //data.dTeacherKeyDate = DateTime.Now;
                //data.sTeacher = lblTeacherNobr.Text;
                //data.sKeyMan = User.Identity.Name;
                //data.dKeyDate = DateTime.Now;
                dcTraining.SubmitChanges();
                gv.Rebind();
            }
        }
        else
        {
            AlertMsg("請勾選通過");
        }
        // changeMode("v");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        // changeMode("v");
    }
    protected void btnLevel_Click(object sender, EventArgs e)
    {
        //changeMode("l");
    }

    protected void gv_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        GridDataItem item = null;
        if (e.Item is GridDataItem)
        {
            item = e.Item as GridDataItem;
        }

        if (e.CommandName == "DataEdit" || e.CommandName == "LevelEdit")
        {
            //無iAutokey代表為無此資料，則新增
            if (item["iAutokey"].Text.Trim().Length == 0)
            {
                var course = (from c in dcTraining.trCourse
                              where c.sCode == item["CourseCode"].Text
                              select c).FirstOrDefault();
                if (course != null)
                {
                    trOJTStudentD obj = new trOJTStudentD();
                    obj.bPass = false;
                    obj.iJobScore = course.iJobScore;
                    obj.OJT_sCode = cbxCard.SelectedValue.ToString();
                    obj.trCourse_sCode = item["CourseCode"].Text;
                    obj.sNobr = gvEmp.SelectedValue.ToString();
                    dcTraining.trOJTStudentD.InsertOnSubmit(obj);
                    dcTraining.SubmitChanges();
                    gv.Rebind();
                }
            }

            if (e.CommandName == "DataEdit")
            {
                lblKey.Text = item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutokey"].ToString();
                lblOjtCode.Text = cbxCard.SelectedValue.ToString();
                lblCourseCode.Text = item["CourseCode"].Text;
                lblNobr.Text = gvEmp.SelectedValue.ToString();
                //changeMode("e");
            }
            if (e.CommandName == "LevelEdit")
            {
                lblKey.Text = item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutokey"].ToString();
                lblOjtCode.Text = cbxCard.SelectedValue.ToString();
                lblCourseCode.Text = item["CourseCode"].Text;
                lblNobr.Text = gvEmp.SelectedValue.ToString();
                // changeMode("l");
                loadLevel();
            }
        }
    }

    private void loadEdit()
    {


    }

    private void loadLevel()
    {
        //var data = (from c in dcTraining.trOJTStudent
        //            where c.iAutokey == Convert.ToInt32(lblKey.Text)
        //            select c).FirstOrDefault();

        //if (data != null)
        //{
        //    tbLevel.Text = data.iLevel;
        //}
    }
    protected void gvNobr_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridDataItem item = gvNobr.SelectedItems[0] as GridDataItem;
        if (item != null)
        {
            lblTeacherNobr.Text = gvNobr.SelectedValue.ToString();
            tbTeacher.Text = item["NAME_C"].Text;
        }
    }
    protected void gv_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            CheckBox ck = item["bPass"].Controls[0] as CheckBox;
            CheckBox ckPass = item["Select"].Controls[0] as CheckBox;
            //已確認
            if (ck.Checked == true)
            {
                ck.Enabled = true;
                //item["DataEdit"].Enabled = false;

            }

            //要有部門主管確認才能簽
            if (item["dCheckDate"].Text.Trim().Length == 0)
            {
                //item["DataEdit"].Enabled = false;
                ckPass.Enabled = false;
            }
            else
            {
                item["dCheckDate"].Text = item["dCheckDate"].Text + " " + item["NAME_C"].Text;
                ck.Enabled = true;
                ckPass.Enabled = true;
            }
        }
    }
    protected void cbxDept_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        lblDept.Text = cbxDept.SelectedValue;
        gvEmp.Rebind();
    }
    protected void cbNeedCheckOnly_CheckedChanged(object sender, EventArgs e)
    {
        if (cbNeedCheckOnly.Checked)
        {
            gvByDept.Rebind();
            gvByDept.Visible = true;
            gv.Visible = false;
            gvEmp.Visible = false;
            pnlDept.Visible = false;
            pnlUserScore.Visible = false;
        }
        else
        {
            gv.Visible = true;
            gvByDept.Visible = false;
            gvEmp.Visible = true;
            pnlDept.Visible = true;
            pnlUserScore.Visible = true;
            gv.Rebind();
        }
    }

    private void loadJobScore()
    {
        int allScore = 0;
        int userScore = 0;

        foreach (GridDataItem item in gv.Items)
        {
            CheckBox ckPass = item["bPass"].Controls[0] as CheckBox;

            int score = 0;
            int.TryParse(item["CourseJobScore"].Text, out score);

            if (ckPass.Checked == true)
            {
                userScore = userScore + score;
            }
            else
            {
                if (ckPass.Enabled)
                    item.BackColor = System.Drawing.Color.Pink;
            }
            allScore = allScore + score;
        }

        lblUserJobScore.Text = "個人積分 " + userScore.ToString();
        lblJobScoreAmt.Text = "總積分" + allScore.ToString();
    }
    protected void gv_PreRender(object sender, EventArgs e)
    {
        if (cbNeedCheckOnly.Checked == true)
        {
            foreach (GridDataItem item in gv.Items)
            {
                CheckBox ck = item["bPass"].Controls[0] as CheckBox;
                //已確認

                if (ck.Checked == true || (item["dCheckDate"].Text.Trim().Length == 0))
                {
                    item.Visible = false;
                }
            }
        }
    }
    protected void btnSaveList_Click(object sender, EventArgs e)
    {
        //RadGrid _gv = null;
        if (cbNeedCheckOnly.Checked == true)
        {
            foreach (GridDataItem item in gvByDept.SelectedItems)
            {
                int id = 0;
                if (Int32.TryParse(item["iAutokey"].Text, out id))
                    doUpdateByAll(id);
            }
            gvByDept.Rebind();
            //   _gv = gvByDept;

        }
        else
        {
            // _gv = gv;
            foreach (GridDataItem item in gv.Items)
            {
                if (item.Visible == true && item["iAutokey"].Text.Trim().Length > 0)
                    doUpdate(item);
            }
            gv.Rebind();
        }

        //_gv.Rebind();
        RadAjaxPanel1.Alert("已存檔");
    }

    private void doUpdateByAll(int iAutoKey)
    {
        var obj = (from c in dcTraining.trOJTStudentD
                   where c.iAutokey == iAutoKey
                   select c).FirstOrDefault();

        if (obj == null)
        {
            throw new ApplicationException("無法取得正確id");
        }
        else
        {
            obj.dFinalCheckDate = DateTime.Now;
            obj.sFinalCheckMan = User.Identity.Name;
            obj.bPass = true;
            obj.iLevel = null;
            dcTraining.SubmitChanges();
        }
    }

    private void doUpdate(GridDataItem item)
    {
        CheckBox ckPass = item["bPass"].Controls[0] as CheckBox;
        int id = Convert.ToInt32(item["iAutokey"].Text);
        var obj = (from c in dcTraining.trOJTStudentD
                   where c.iAutokey == id
                   select c).FirstOrDefault();

        if (obj == null)
        {
            throw new ApplicationException("無法取得正確id");
        }
        else
        {
            //無任何改變，Do Nothing
            if (ckPass.Checked == obj.bPass)
                return;
            else
            {
                if (ckPass.Checked == true)
                {
                    obj.dFinalCheckDate = DateTime.Now;
                    obj.sFinalCheckMan = User.Identity.Name;
                    obj.bPass = true;
                    obj.iLevel = null;
                }
                else //取消通過
                {
                    obj.bPass = false;
                    obj.dFinalCheckDate = null;
                    obj.sFinalCheckMan = null;
                }
            }

            dcTraining.SubmitChanges();
        }
    }

    protected void gv_DataBound(object sender, EventArgs e)
    {
        loadJobScore();
    }


    protected void gvByDept_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        List<trOJTStudentD> list = new List<trOJTStudentD>();
        foreach (RadComboBoxItem item in cbxDept.Items)
        {
            list.AddRange(ojtSD_REPO.GetNeedFinalCheckByDept(item.Value));
        }

        var ds = (from c in list
                  select new
                  {
                      NAME_C = c.BASETTS.BASE.NAME_C,
                      deptName = c.BASETTS.DEPT1.D_NO + " " + c.BASETTS.DEPT1.D_NAME,
                      courseName = c.trCourse.sName,
                      courseCode = c.trCourse_sCode,
                      dCheckDate = c.dCheckDate,
                      bPass = c.bPass,
                      iAutoKey = c.iAutokey,
                      sNobr = c.sNobr,
                      courseJobScore = c.trCourse.iJobScore
                  }).ToList();

        gvByDept.DataSource = ds;
    }
}
