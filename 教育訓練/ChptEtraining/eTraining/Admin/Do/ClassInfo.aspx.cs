using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
public partial class eTraining_Admin_Do_ClassInfo : JBWebPage
{
    DataContext dc = new DataContext();
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            lblID.Text = Request.QueryString["ID"].ToString();
            IRepository<trTrainingDetailM> DMRepository = new Repository<trTrainingDetailM>(dc);
            trTrainingDetailM DMObj= DMRepository.FirstOrDefault(c=>c.iAutoKey == Convert.ToInt32(lblID.Text));
            if (DMObj != null)
            {
                if (DMObj.dClassRptDeadline.HasValue)
                {
                    lblClassRptDeadLine.Text = DMObj.dClassRptDeadline.Value.ToShortDateString();
                }
                if ( DMObj.dStudentScoreDeadline.HasValue )
                    lblStudentScoreDeadLine.Text = DMObj.dStudentScoreDeadline.Value.ToShortDateString();
            }
        }
        else
            throw new ApplicationException("無輸入課程ID");
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void gvAttendClass_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            int mins = 0;
            int.TryParse(item["iAttendMins"].Text, out mins);
            item["iAttendMins"].Text = Convert.ToDouble(mins / 60).ToString("0.0");
            //f_item["iMins"].Text = string.Format("{0:#,0.0}", iMins / 60); 


        }
    }
}