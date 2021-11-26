using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eTraining_Admin_Do_StudentScore : System.Web.UI.Page
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        //select ca.sName,co.sName,d.dClassDate,t.sName,* from trCourse co
        //join trTrainingDetailM tdm on co.sCode=tdm.trCourse_sCode
        //join trAttendClassDate d on tdm.iAutoKey=d.iClassAutoKey
        //join trAttendClassTeacher at on tdm.iAutoKey=at.iClassAutoKey
        //and d.dClassDate=at.dClassDate
        //join trTeacher t on at.sTeacherCode=t.sCode
        //join trCategoryCourse caco on co.sCode=caco.sCourseCode
        //join trCategory ca on caco.sCateCode=ca.sCode
        //where tdm.iAutoKey=37
        var CourseInfo = from co in dcTrain.trCourse
                         join tdm in dcTrain.trTrainingDetailM on co.sCode equals tdm.trCourse_sCode
                         join d in dcTrain.trAttendClassDate on tdm.iAutoKey equals d.iClassAutoKey
                         join at in dcTrain.trAttendClassTeacher on tdm.iAutoKey equals at.iClassAutoKey
                         join t in dcTrain.trTeacher on at.sTeacherCode equals t.sCode
                         join caco in dcTrain.trCategoryCourse on co.sCode equals caco.sCourseCode
                         join ca in dcTrain.trCategory on caco.sCateCode equals ca.sCode
                         where tdm.iAutoKey == Convert.ToInt32(lblID.Text) && d.dClassDate == at.dClassDate
                         select new
                         {
                             CatName = ca.sName,
                             CourseName = co.sName,
                             ClassDate = d.dClassDate,
                             Teacher = t.sName,
                             CourseDateA = tdm.dDateA,
                             CourseDateD = tdm.dDateD
                         };

        foreach (var itm in CourseInfo)
        {
            lblCat.Text = itm.CatName;
            lblCourse.Text = itm.CourseName;
            lblClassDateA.Text = itm.CourseDateA.Value.ToShortDateString();
            lblClassDateD.Text = itm.CourseDateD.Value.ToShortDateString();
            lblTeacher.Text = itm.Teacher;
        }
    }
}