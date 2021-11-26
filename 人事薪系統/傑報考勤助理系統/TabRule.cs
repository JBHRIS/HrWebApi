using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR
{
    public class TabRule
    {
        public static void CheckRule(string FormName, System.Windows.Forms.TabControl tab)
        {//20121003禾申堂暫時停用此功能
            //if (MainForm.SUPER) return;
            //var db = new JBModule.Data.Linq.HrDBDataContext();
            //var sql = (from a in db.U_PRGID
            //           where a.PROG.Contains(FormName + "-")
            //            && a.USER_ID == MainForm.USER_ID
            //           select a).ToList();
            //int i = 0;
            //foreach (System.Windows.Forms.TabPage tb in tab.TabPages)
            //{
            //    i++;
            //    foreach (var ctrl in tb.Controls)
            //    {
            //        var pnl = ctrl as System.Windows.Forms.Panel;
            //        if (pnl != null)
            //        {
            //            pnl.Enabled = false;//預設鎖定
            //        }
            //    }
            //    //if (i == 1)
            //    //    tab.TabPages.Remove(tb);
            //    var qq = from a in sql where a.PROG == FormName + "-" + tb.Text select a;
            //    if (qq.Any())
            //    {
            //        var rr = qq.First();
            //        if (rr.ADD_ || rr.EDIT)
            //        {
            //            foreach (var ctrl in tb.Controls)
            //            {
            //                var pnl = ctrl as System.Windows.Forms.Panel;
            //                if (pnl != null)
            //                {
            //                    pnl.Enabled = true;
            //                }
            //            }
            //        }
            //    }
            //    else tab.TabPages.Remove(tb);//如果沒有權限，連顯示都不能顯示

            //}
        }
    }
}
