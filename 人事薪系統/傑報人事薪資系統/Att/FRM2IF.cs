using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM2IF : JBControls.JBForm
    {
        public FRM2IF()
        {
            InitializeComponent();
        }

        string IntervalType = "年";
        int IntervalLength = 1;
        string Msg = "";
        //DateTime SpecifiedDate = DateTime.Today;
        private void buttonExtend_Click(object sender, EventArgs e)
        {
            FRM2IF_OPTION frm = new FRM2IF_OPTION();
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                IntervalLength = frm.ExtendLength;
                IntervalType = frm.ExtendLegthType;
                if (MessageBox.Show(string.Format("是否要將所選擇的{0}筆得假資料剩餘時數進行遞延", jbQuery1.SelectKeys.Count), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                    var hcodetypeList = db.HcodeType.ToList();
                    var hcodeList = db.HCODE.ToList();
                    foreach (var it in jbQuery1.SelectKeys)
                    {
                        try
                        {

                            string ExtendCode = "";
                            string ExpireCode = "";
                            //DateTime? PayDate = null;

                            db = new JBModule.Data.Linq.HrDBDataContext();
                            var instance = db.ABS.Where(p => p.Guid == it.ToString()).FirstOrDefault();
                            var rHcode = hcodeList.SingleOrDefault(p => p.H_CODE.Trim() == instance.H_CODE.Trim());
                            if (rHcode != null)
                            {
                                var hcodetype = hcodetypeList.SingleOrDefault(p => p.HTYPE == rHcode.HTYPE);
                                if (hcodetype != null)
                                {
                                    ExtendCode = hcodetype.ExtendCode;
                                    ExpireCode = hcodetype.ExpireCode;
                                }
                            }
                            var checkItem = db.ABS.SingleOrDefault(p => p.Guid == it.ToString());
                            if (ExpireCode.Trim().Length == 0 || ExtendCode.Trim().Length == 0)
                                continue;

                            if (checkItem != null)
                            {
                                if (checkItem.Balance == 0) continue;
                                DateTime StartDate = instance.EDATE.AddDays(1);
                                DateTime EndDate = StartDate;
                                if (frm.ExtendSelection == "1")
                                {
                                    if (IntervalType == "天")
                                    {
                                        EndDate = StartDate.AddDays(IntervalLength).AddDays(-1);
                                    }
                                    else if (IntervalType == "月")
                                    {
                                        EndDate = StartDate.AddMonths(IntervalLength).AddDays(-1);
                                    }
                                    else if (IntervalType == "年")
                                    {
                                        EndDate = StartDate.AddYears(IntervalLength).AddDays(-1);
                                    }
                                }
                                else if (frm.ExtendSelection == "2")
                                {
                                    EndDate = frm.ExtendSelectedDate;
                                }

                                if (instance.EDATE > EndDate) continue;
                                JBModule.Data.Linq.HrDBDataContext dbTrans = new JBModule.Data.Linq.HrDBDataContext();

                                if (dbTrans.Connection.State != ConnectionState.Open)
                                    dbTrans.Connection.Open();
                                var trans = dbTrans.Connection.BeginTransaction();
                                dbTrans.Transaction = trans;
                                using (trans)
                                {
                                    string guid = Guid.NewGuid().ToString();
                                    JBHRIS.BLL.Dto.AbsTakenDto taken = new JBHRIS.BLL.Dto.AbsTakenDto
                                    {
                                        AttendDate = instance.EDATE,
                                        BeginTime = instance.EDATE,
                                        CheckAttendConflict = false,
                                        CreateMan = MainForm.USER_NAME,
                                        EmployeeID = instance.NOBR,
                                        EndTime = instance.EDATE,
                                        Hcode = ExpireCode,
                                        Syscreate = true,
                                        Taken = checkItem.Balance.Value,
                                        Guid = guid,
                                        Serno = instance.Guid,
                                        Remark = "",
                                        YYMM = "",
                                        Field01= instance.Guid,
                                    };
                                    JBModule.Data.Repo.AbsRepo absRepo = new JBModule.Data.Repo.AbsRepo(dbTrans);
                                    if (!absRepo.Insert(taken, out Msg))
                                    {
                                        JBModule.Message.TextLog.WriteLog(Msg);
                                        trans.Rollback();
                                        continue;
                                    }
                                    var entitle = new JBHRIS.BLL.Dto.AbsEntitleDto
                                    {
                                        BeginDate = instance.BDATE,
                                        CreateMan = MainForm.USER_NAME,
                                        EmployeeID = instance.NOBR,
                                        EndDate = EndDate,
                                        HolidayCode = ExtendCode,
                                        Remark = instance.NOTE,
                                        Taken = 0,
                                        Balance = checkItem.Balance.Value,
                                        CreateTime = DateTime.Now,
                                        EmployeeName = "",
                                        Entitle = checkItem.Balance.Value,
                                        HolidayName = "",
                                        //PayDate = instance.EDATE,
                                    };
                                    JBModule.Data.Repo.AbsEntitleRepo EntitleRepo = new JBModule.Data.Repo.AbsEntitleRepo(dbTrans);
                                    if (!EntitleRepo.Insert(entitle, out Msg))
                                    {
                                        JBModule.Message.TextLog.WriteLog(Msg);
                                        trans.Rollback();
                                        continue;
                                    }
                                    trans.Commit();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            JBModule.Message.TextLog.WriteLog(ex);
                        }
                    }
                    MessageBox.Show("完成");
                    jbQuery1.Query();
                }
            }
        }
        JBModule.Data.ApplicationConfigSettings acg = null;
        private void FRM2IF_Load(object sender, EventArgs e)
        {
            //SystemFunction.CheckAppConfigRule(btnConfig);
            //acg = new JBModule.Data.ApplicationConfigSettings(this.Name, MainForm.COMPANY);
            //acg.CheckParameterAndSetDefault("HTYPE", "特休假別種類代碼", "", "指定假別種類代碼，用來判斷特休假別相關代碼及設定", "ComboBox", "select htype,htype+'-'+type_name from hcodetype", "String");
            //acg.CheckParameterAndSetDefault("ExtendCode", "特休遞延代碼", "", "指定延休假別代碼，用來判斷遞延假別須以上年度薪資計算", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1", "String");
            //acg.CheckParameterAndSetDefault("ExpireCode", "特休失效代碼", "", "指定特休假別失效代碼，用來結清遞延後的時數", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1", "String");
        }
    }
}
