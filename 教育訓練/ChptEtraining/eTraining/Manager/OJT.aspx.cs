using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using Repo;

public partial class eTraining_Manager_OJT : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    private BASETTS_Repo basettsRepo = new BASETTS_Repo();
    private OjtCheckUnit_Repo ojtCheckUnitRepo = new OjtCheckUnit_Repo();
    private trOJTStudentM_Repo osmRepo = new trOJTStudentM_Repo();

    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gvNobr);
        if (!IsPostBack)
        {
            var obj = (from c in dcTraining.BASETTS
                       where c.NOBR == User.Identity.Name
                       && DateTime.Now.Date >= c.ADATE && DateTime.Now.Date <= c.DDATE
                       && new string[] { "1", "4", "6" }.Contains(c.TTSCODE)
                       select c).FirstOrDefault();

            if (obj != null)
            {
                lblDept.Text = obj.DEPT;
                gvEmp.Rebind();
            }

            bind_cbxOjtDept();
        }        
    }

    private void bind_cbxOjtDept()
    {
        //抓取設定的部門
        BASETTS basetts = basettsRepo.GetEmpByNobrNow_DLO(User.Identity.Name);

        //RadComboBoxItem item = new RadComboBoxItem();
        //item.Value=  basetts.DEPT1.D_NO;
        //item.Text=  basetts.DEPT1.D_NAME;
        //cbxOjtDept.Items.Add(item);
        cbxOjtDept.DataSource =
            (from c in ojtCheckUnitRepo.GetByCheckUnit_DLO(basetts.DEPT)
             select new { Value = c.OjtUnit, 
                 Text = c.OjtDEPT!=null?c.OjtDEPT.D_NO+c.OjtDEPT.D_NAME:"" }).ToList().OrderBy(p=>p.Text);
        cbxOjtDept.DataBind();
    }

    private void changeMode(string mode)
    {
        if (mode == "v")
        {
            pnlOJT.Visible = true;
            pnlEdit.Visible = false;
            pnlLevel.Visible = false;
        }
        else if (mode == "e")
        {
            pnlOJT.Visible = false;
            pnlEdit.Visible = true;
            pnlLevel.Visible = false;
        }
        else if (mode == "l")
        {
            pnlOJT.Visible = false;
            pnlEdit.Visible = false;
            pnlLevel.Visible = true;
        }

    }

    protected void gvEmp_SelectedIndexChanged(object sender, EventArgs e)
    {
        osmRepo.CheckEmpOjtCard(gvEmp.SelectedValue.ToString());        
        changeMode("v");
    }
    protected void sdsEmpData_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["@nobr"].Value = gvEmp.SelectedValue;
    }
    protected void sdsName_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        // e.Command.Parameters["@Manage"].Value = Page.User.Identity.Name;        
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        changeMode("e");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!dpDate.SelectedDate.HasValue)
        {
            RadAjaxPanel1.Alert("需輸入日期");            
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
                //data.bPass = cbPass.Checked;
                data.dCheckDate = dpDate.SelectedDate.Value;
                data.sCheckMan = User.Identity.Name;
                data.dOJT_Date = dpDate.SelectedDate.Value;
                //data.dTeacherKeyDate = DateTime.Now;
                //data.sTeacher = lblTeacherNobr.Text;
                data.sKeyMan = User.Identity.Name;
                data.dKeyDate = DateTime.Now;
                dcTraining.SubmitChanges();
                gv.Rebind();
            }
        }
        changeMode("v");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        changeMode("v");
    }
    protected void btnLevel_Click(object sender, EventArgs e)
    {
        changeMode("l");
    }
    protected void btnSaveLevel_Click(object sender, EventArgs e)
    {
        var data = (from c in dcTraining.trOJTStudentD
                    where c.sNobr == lblNobr.Text
                    && c.trCourse_sCode == lblCourseCode.Text
                    select c).FirstOrDefault();

        if (data != null)
        {
            //data.iLevel = tbLevel.Text.Trim();
            data.iLevel = Convert.ToInt32(cbxJobSkill.SelectedValue);
            dcTraining.SubmitChanges();
            gv.Rebind();
            changeMode("v");
        }

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
            trOJTStudentD_Repo trOJT_SD_Repo = new trOJTStudentD_Repo();

            //無資料則新增，不要用直接判斷gv是否空白，因為他們會按回上一頁
            var data = trOJT_SD_Repo.GetByNobrCourse(gvEmp.SelectedValue.ToString(),item["CourseCode"].Text);
            //if (item["iAutokey"].Text.Trim().Length == 0)
            if(data==null)
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
                    obj.dCreatedDate = DateTime.Now;
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
                changeMode("e");
            }
            if (e.CommandName == "LevelEdit")
            {
                lblKey.Text = item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutokey"].ToString();
                lblOjtCode.Text = cbxCard.SelectedValue.ToString();
                lblCourseCode.Text = item["CourseCode"].Text;
                lblNobr.Text = gvEmp.SelectedValue.ToString();
                changeMode("l");
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
            CheckBox ckPass = item["bPass"].Controls[0] as CheckBox;
            CheckBox ckTrainned = item["trainned"].Controls[0] as CheckBox;
            RadComboBox cbxLevel = item["Level"].FindControl("cbxLevel") as RadComboBox;

            //如果已經通過
            if (ckPass.Checked == true)
            {
                item["DataEdit"].Enabled = false;
                ckTrainned.Enabled = false;
                ckTrainned.Checked = true;
                cbxLevel.Enabled = false;
            }
            else
            {
                ckTrainned.Enabled = true;
                cbxLevel.Enabled = true;
            }

            //處理以訓練欄位
            if (item["dCheckDate"].Text.Length > 0)
            {
                ckTrainned.Checked = true;
            }
            else
                ckTrainned.Checked = false;

            //cbxLevel           
            if (item["iLevel"].Text.Length == 0)
            {
                item["iLevel"].Text = "non-selected";
            }

            foreach (RadComboBoxItem cbxItem in cbxLevel.Items)
            {
                if (cbxItem.Value.Equals(item["iLevel"].Text))
                {
                    cbxItem.Selected = true;
                }
                else
                    cbxItem.Selected = false;
            }
        }
    }

    private void doInsert(GridDataItem item)
    {
        CheckBox ckPass = item["bPass"].Controls[0] as CheckBox;
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
            obj.dCreatedDate = DateTime.Now;
            obj.sCreateMan = User.Identity.Name;
            CheckBox ckTrainned = item["trainned"].Controls[0] as CheckBox;
            RadComboBox cbxLevel = item["Level"].FindControl("cbxLevel") as RadComboBox;

            if (ckTrainned.Checked == true)
            {
                obj.dCheckDate = DateTime.Now;
                obj.sCheckMan = User.Identity.Name;
            }

            if (!cbxLevel.SelectedValue.Equals("non-selected"))
            {
                obj.iLevel = Convert.ToInt32(cbxLevel.SelectedValue);
                obj.sKeyMan = User.Identity.Name;
                obj.dKeyDate = DateTime.Now;
            }

            dcTraining.trOJTStudentD.InsertOnSubmit(obj);
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
            CheckBox ckTrainned = item["trainned"].Controls[0] as CheckBox;
            RadComboBox cbxLevel = item["Level"].FindControl("cbxLevel") as RadComboBox;

            if (obj.iLevel.HasValue)
            {
                if (cbxLevel.SelectedValue.Equals(obj.iLevel.Value.ToString()))
                {
                    //上次跟這次都是選一樣的 do nothing
                }
                else
                {
                    if (cbxLevel.SelectedValue.Equals("non-selected"))
                    {
                        obj.iLevel = null;
                    }
                    else
                    {
                        obj.iLevel = Convert.ToInt32(cbxLevel.SelectedValue);
                    }
                    obj.sKeyMan = User.Identity.Name;
                    obj.dKeyDate = DateTime.Now;
                }
            }
            else
            {
                if (cbxLevel.SelectedValue.Equals("non-selected"))
                {
                    //上次跟這次都是未選擇 do nothing
                }
                else//上次沒選值，這次有
                {
                    obj.iLevel = Convert.ToInt32(cbxLevel.SelectedValue);
                    obj.sKeyMan = User.Identity.Name;
                    obj.dKeyDate = DateTime.Now;
                }
            }

            //原先有勾已訓練、且這次勾選沒異動
            if (ckTrainned.Checked == true && obj.dCheckDate.HasValue)
            {
            }
            //原先沒勾已訓練，但這次有勾
            else if (ckTrainned.Checked == true && (obj.dCheckDate.HasValue == false))
            {
                obj.dCheckDate = DateTime.Now;
                obj.sCheckMan = User.Identity.Name;
                obj.iLevel = null;
            }
            //原先沒勾選，這次也沒勾
            else if (ckTrainned.Checked == false && (obj.dCheckDate.HasValue == false))
            {
            }
            //原先有勾選，這次沒勾
            else if (ckTrainned.Checked == false && (obj.dCheckDate.HasValue))
            {
                obj.dCheckDate = null;
                obj.sCheckMan = null;
            }

            dcTraining.SubmitChanges();
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
            allScore = allScore + score;                
        }

        lblUserJobScore.Text = "個人積分 " + userScore.ToString();
        lblJobScoreAmt.Text = "總積分" + allScore.ToString();
    }

    protected void btnSaveList_Click(object sender, EventArgs e)
    {
        trOJTStudentD_Repo trOJT_SD_Repo = new trOJTStudentD_Repo();

        foreach (GridDataItem item in gv.Items)
        {
            CheckBox ckPass = item["bPass"].Controls[0] as CheckBox;
            //如果pass的就不考慮做動作，只考慮沒通過的
            if (ckPass.Checked == false)
            {
                //iAutoKey因為透過即時計算，有可能是null，所以要判斷，null則新增，非null就update
                var data = trOJT_SD_Repo.GetByNobrCourse(gvEmp.SelectedValue.ToString(), item["CourseCode"].Text);
                //if (item["iAutokey"].Text.Length == 0) //直接新增                

                if(data==null)                
                    doInsert(item);                
                else //更新資料                
                    doUpdate(item);                
            }
        }

        gv.Rebind();
    }
    protected void gv_DataBound(object sender, EventArgs e)
    {
        loadJobScore();
    }

    protected void cbxOjtDept_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gvEmp.Rebind();
    }
}
