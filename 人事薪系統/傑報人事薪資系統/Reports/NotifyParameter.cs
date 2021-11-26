using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace JBHR.Reports
{
    class NotifyParameter
    {
        public static void SetAttendSetting()
        {
            JBModule.Message.DBDataContext db = new JBModule.Message.DBDataContext();

            //異常通知部門主管
            var qu = from a in db.PARAMETER where a.CODE == "JbMail.Department" select a;
            int GroupID = 1;
            if (qu.FirstOrDefault() == null)
            {
                JBModule.Message.UI.DbContext.CreateParameterTreeTable();
                //GroupID = JBModule.Message.UI.DbContext.InitialParameterTree();
                var parm = new JBModule.Message.PARAMETER();
                parm.CODE = "JbMail.Department";
                parm.DISPLAY = true;
                parm.KEY_DATE = DateTime.Now;
                parm.KEY_MAN = "JB";
                parm.NOTE = "部門主管";
                parm.PARMGROUP_AUTO = GroupID;
                parm.TYPE = "String";
                parm.VALUE = "Dept";
                db.PARAMETER.InsertOnSubmit(parm);
                db.SubmitChanges();
            }

            //異常通知試用期滿
            var qu1 = from a in db.PARAMETER where a.CODE == "JbMail.ExpirationDays" select a;
            if (qu1.FirstOrDefault() == null)
            {
                JBModule.Message.UI.DbContext.CreateParameterTreeTable();
                //GroupID = JBModule.Message.UI.DbContext.InitialParameterTree();
                var parm = new JBModule.Message.PARAMETER();
                parm.CODE = "JbMail.ExpirationDays";
                parm.DISPLAY = true;
                parm.KEY_DATE = DateTime.Now;
                parm.KEY_MAN = "JB";
                parm.NOTE = "試用期滿";
                parm.PARMGROUP_AUTO = GroupID;
                parm.TYPE = "Int";
                parm.VALUE = "30";
                db.PARAMETER.InsertOnSubmit(parm);
                db.SubmitChanges();
            }

            //異常通知合同通知到期天數
            var qu2 = from a in db.PARAMETER where a.CODE == "JbMail.ContractDays" select a;
            if (qu2.FirstOrDefault() == null)
            {
                JBModule.Message.UI.DbContext.CreateParameterTreeTable();
                //GroupID = JBModule.Message.UI.DbContext.InitialParameterTree();
                var parm = new JBModule.Message.PARAMETER();
                parm.CODE = "JbMail.ContractDays";
                parm.DISPLAY = true;
                parm.KEY_DATE = DateTime.Now;
                parm.KEY_MAN = "JB";
                parm.NOTE = "合同通知到期天數";
                parm.PARMGROUP_AUTO = GroupID;
                parm.TYPE = "Int";
                parm.VALUE = "30";
                db.PARAMETER.InsertOnSubmit(parm);
                db.SubmitChanges();
            }

            //試用期滿/合同間隔區間天數
            var qu6 = from a in db.PARAMETER where a.CODE == "JbMail.ContractInteval" select a;
            if (qu6.FirstOrDefault() == null)
            {
                JBModule.Message.UI.DbContext.CreateParameterTreeTable();
                //GroupID = JBModule.Message.UI.DbContext.InitialParameterTree();
                var parm = new JBModule.Message.PARAMETER();
                parm.CODE = "JbMail.ContractInteval";
                parm.DISPLAY = true;
                parm.KEY_DATE = DateTime.Now;
                parm.KEY_MAN = "JB";
                parm.NOTE = "試用期滿/合同間隔區間天數";
                parm.PARMGROUP_AUTO = GroupID;
                parm.TYPE = "Int";
                parm.VALUE = "0";
                db.PARAMETER.InsertOnSubmit(parm);
                db.SubmitChanges();
            }
            ////連續工作起始日期
            //var qu1 = from a in db.PARAMETER where a.CODE == "JbMail.ContinuousWorkInteval" select a;
            //if (qu1.FirstOrDefault() == null)
            //{
            //    JBModule.Message.UI.DbContext.CreateParameterTreeTable();
            //    //GroupID = JBModule.Message.UI.DbContext.InitialParameterTree();
            //    var parm = new JBModule.Message.PARAMETER();
            //    parm.CODE = "JbMail.ContinuousWorkInteval";
            //    parm.DISPLAY = true;
            //    parm.KEY_DATE = DateTime.Now;
            //    parm.KEY_MAN = "JB";
            //    parm.NOTE = "連續工作日期間隔天數";
            //    parm.PARMGROUP_AUTO = GroupID;
            //    parm.TYPE = "Int";
            //    parm.VALUE = "-1";
            //    db.PARAMETER.InsertOnSubmit(parm);
            //    db.SubmitChanges();
            //}

            ////連續工作天數
            //var qu2 = from a in db.PARAMETER where a.CODE == "JbMail.ContinuousDays" select a;
            //if (qu2.FirstOrDefault() == null)
            //{
            //    JBModule.Message.UI.DbContext.CreateParameterTreeTable();
            //    //GroupID = JBModule.Message.UI.DbContext.InitialParameterTree();
            //    var parm = new JBModule.Message.PARAMETER();
            //    parm.CODE = "JbMail.ContinuousDays";
            //    parm.DISPLAY = true;
            //    parm.KEY_DATE = DateTime.Now;
            //    parm.KEY_MAN = "JB";
            //    parm.NOTE = "連續工作天數";
            //    parm.PARMGROUP_AUTO = GroupID;
            //    parm.TYPE = "Int";
            //    parm.VALUE = "6";
            //    db.PARAMETER.InsertOnSubmit(parm);
            //    db.SubmitChanges();
            //}

            ////超時加班時數
            //var qu3 = from a in db.PARAMETER where a.CODE == "JbMail.OverHRS" select a;
            //if (qu3.FirstOrDefault() == null)
            //{
            //    JBModule.Message.UI.DbContext.CreateParameterTreeTable();
            //    //GroupID = JBModule.Message.UI.DbContext.InitialParameterTree();
            //    var parm = new JBModule.Message.PARAMETER();
            //    parm.CODE = "JbMail.OverHRS";
            //    parm.DISPLAY = true;
            //    parm.KEY_DATE = DateTime.Now;
            //    parm.KEY_MAN = "JB";
            //    parm.NOTE = "加班超時時數";
            //    parm.PARMGROUP_AUTO = GroupID;
            //    parm.TYPE = "Int";
            //    parm.VALUE = "46";
            //    db.PARAMETER.InsertOnSubmit(parm);
            //    db.SubmitChanges();
            //}
        }
    }
}
