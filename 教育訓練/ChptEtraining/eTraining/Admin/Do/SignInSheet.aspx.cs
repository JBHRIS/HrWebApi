using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
public partial class eTraining_Admin_Do_SignInSheet : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cbxAttendClassDate_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gvSignInSheet.Rebind();
    }
    protected void gvSignInSheet_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            CheckBox ck = item["bPresence"].Controls[0] as CheckBox;
            if (ck != null)
            {
                ck.Enabled = true;
                if (ck.Checked == true)
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
            }

            item["Item"].Text = (item.DataSetIndex + 1).ToString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        GridDataItemCollection items = gvSignInSheet.Items;
        foreach (GridDataItem item in items)
        {
            int iAutoKey = Int32.Parse(item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString());

            var dataList = (from c in dcTraining.trTrainingStudentPresence
                            where c.iClassAutoKey == Int32.Parse(Request.QueryString["ID"].ToString())                            
                            select c).ToList();

            CheckBox ck = item["bPresence"].Controls[0] as CheckBox;
            if (ck != null)
            {
                var data = (from c in dataList
                            where c.iAutoKey == iAutoKey
                            select c).FirstOrDefault();

                if (data != null)
                {
                    if (item.Selected != data.bPresence)
                    {
                        data.bPresence = item.Selected;
                        dcTraining.SubmitChanges();
                    }

                    //未出勤的計算
                    var AbsenceCount = (from c in dataList
                                         where c.trTrainingStudentM_ID == Convert.ToInt32(item["trTrainingStudentM_ID"].Text)
                                         && c.bPresence == false
                                         select c.trTrainingStudentM_ID).Count();

                    var studentM = (from c in dcTraining.trTrainingStudentM
                                    where c.iAutoKey == Convert.ToInt32(item["trTrainingStudentM_ID"].Text)
                                    select c).FirstOrDefault();

                    if (studentM != null )
                    {
                        if (AbsenceCount == 0)//都沒有未出勤的
                            studentM.bPresence = true;
                        else  
                            studentM.bPresence = false;

                        dcTraining.SubmitChanges();
                    }
                }
            }
        }

        gvSignInSheet.Rebind();
    }
}