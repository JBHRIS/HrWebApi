using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Security.Principal;

public partial class Default : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private class ucTable
    {
        private Table table;
        public int col { get; set; }
        private TableRow row = null;

        public ucTable(Table t)
        {
            table = t;
        }

        public void AddEmptyCell()
        {
            if (row != null)
            {
                while (row.Cells.Count < col)
                {
                    TableCell cell = new TableCell();                    
                    row.Cells.Add(cell);
                }
                
                table.Rows.Add(row);
                row = null;                
            }
        }
        public void Add(Control control)
        {
            if (row == null)
            {
                row = new TableRow();
                TableCell cell = new TableCell();                               
                cell.Width = Unit.Percentage(49);
                cell.VerticalAlign = VerticalAlign.Top;
                cell.Controls.Add(control);
                row.Cells.Add(cell);
            }
            else
            {
                TableCell cell = new TableCell();
                cell.Width = Unit.Percentage(49);
                cell.VerticalAlign = VerticalAlign.Top;
                cell.Controls.Add(control);
                row.Cells.Add(cell);
            }

            if (row.Cells.Count == col)
            {
                table.Rows.Add(row);
                row = null;
            }
        }

        public void refresh()
        {
            while (row != null)
            {
                AddEmptyCell();             
                
            }
        }

        public Table GetTable()
        {
            if (table.Rows.Count == 0)
                return null;
            else
                return table;
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        //Table table = new Table();
        //TableRow row = null;
        
        //int role = ((CustomSecurity.CustomIdentity)User.Identity).UserRole;
        //系統管理者

        ucTable table = new ucTable(Table1);
        table.col = 2;
        Control c;

        //如果為管理者 Juser.IsInRole("1")
        if (Juser.IsInRole("1"))
        {
            string HRNotifyPath = "~/UC/HRNotify.ascx";
            c = LoadControl(HRNotifyPath);
            table.Add(c);

            c = LoadControl(@"~/UC/CourseNonExecution.ascx");
            table.Add(c);

            //20131031修改-只有管理者才需看到異常訊息通知
            string ErrorMsgPath = "~/UC/ErrorMsg.ascx";
            c = LoadControl(ErrorMsgPath);
            table.Add(c);
        }

        if (Juser.IsInRole("32") || Juser.IsInRole("1"))
        {
            string DeptEmpAttendedClass = "~/UC/DeptEmpAttendedClass.ascx";
            c = LoadControl(DeptEmpAttendedClass);
            table.Add(c);

            string ManagerApplyCourse = "~/UC/ManagerApplyCourse.ascx";
            c = LoadControl(ManagerApplyCourse);
            table.Add(c);
        }

        //講師
        if (Juser.IsInRole("64"))
        {
            string ApplyCourse = "~/UC/TeacherAttendedClass.ascx";
            c = LoadControl(ApplyCourse);
            table.Add(c);
        }

        //if (!Juser.IsOuterTeacher)
        //{
        //    string ApplyCourse = "~/UC/ApplyCourse.ascx";
        //    c = LoadControl(ApplyCourse);
        //    table.Add(c);
        //}



        

        string AttendedClass = "~/UC/AttendedClass.ascx";
        c = LoadControl(AttendedClass);
        table.Add(c);

        string notifyMsg = "~/UC/NotifyMsg.ascx";
        c = LoadControl(notifyMsg);
        table.Add(c);

        table.refresh();

       //this.Controls.Add(table.GetTable());
        
        //this.Controls.Add(c);

    }
}