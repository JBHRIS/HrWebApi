using Dal;
using OldBll.MT.Vdb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class FormOvtBStd : WebPageBase
    {
        private dcHrDataContext dcHR = new dcHrDataContext();

        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private string _FormCode = "OvtB";
        private List<string> arrHoidDay = new List<string> { "00", "0Y", "0X", "0Z" };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompanySetting != null)
            {
                dcHR.Connection.ConnectionString = CompanySetting.ConnHr;
                dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
            }
            if (!IsPostBack)
            {
                lblProcessID.Text = Guid.NewGuid().ToString();  //產生一組暫存的序號
                txtDateB.SelectedDate = DateTime.Now.Date;
                //txtDateE.SelectedDate = DateTime.Now.Date;
                lblNobrAppM.Text = _User.EmpId;
                SetInfoAppM();
                SetDefault();

                ddlOtCat_DataBind();
                ddlRote_DataBind();
                ddlOtrcd_DataBind();
                ddlDepts_DataBind();
                ddlDept_DataBind();
                txtNameAppS_DataBind();
                ckblNameAppS_DataBind();
                Rote_DataBind();
                ckblNameAppSRoteChange_DataBind();
                ckblNameAppSDetail_DataBind();


                SetTime(lblNobrAppM.Text, DateTime.Now.Date);
                SetRote(lblNobrAppM.Text, DateTime.Now.Date);
                SetDepts(lblNobrAppM.Text);
                var Extend = (from c in dcFlow.FormsExtend
                              where c.Code == "OtRoteChangable" && c.Active == true && c.FormsCode == "Ot"
                              select c).FirstOrDefault();
                var OvtBNameSearchExtend = (from c in dcFlow.FormsExtend
                                            where c.Code == "OvtBNameSearch" && c.Active == true && c.FormsCode == "OvtB"
                                            select c).FirstOrDefault();
                if (OvtBNameSearchExtend != null)
                    plNameSearch.Visible = false;

                if (Extend != null)
                    ddlRote.Enabled = false;
            }
        }

        #region 加载相关默认值
        private void SetInfoAppM()
        {
            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
            var rBas = oBasDao.GetBaseByNobr(lblNobrAppM.Text, DateTime.Now).FirstOrDefault();

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == lblNobrAppM.Text
                         && role.Dept_id == rBas.DeptmCode
                         select new
                         {
                             RoleId = role.id,
                             EmpNobr = emp.id,
                             EmpName = emp.name,
                             DeptCode = dept.id,
                             DeptName = dept.name,
                             JobCode = pos.id,
                             JobName = pos.name,
                             Auth = role.deptMg.Value,
                         }).FirstOrDefault();

            if (rEmpM != null)
            {
                lblRoleAppM.Text = rEmpM.RoleId;
                lblNobrAppM.Text = rEmpM.EmpNobr;
                lblNameAppM.Text = rEmpM.EmpName;
                lblDeptCodeAppM.Text = rEmpM.DeptCode;
                lblDeptNameAppM.Text = rEmpM.DeptName;
                lblJobNameAppM.Text = rEmpM.JobName;
            }
        }
        private void txtNameAppS_DataBind()
        {
            if (lblDeptCodeAppM.Text.Trim().Length > 0)
            {
                OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);
                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
                var rsDept = oDeptDao.GetDept();

                lblDeptCodeAppMByDept.Text = oBasDao.GetBaseByNobr(lblNobrAppM.Text,DateTime.Now).FirstOrDefault().DeptCode;

                var rsBas = oBasDao.GetBaseByNobr(lblNobrAppM.Text);
                var rsBasByDept = oBasDao.GetBaseByDept(lblDeptCodeAppMByDept.Text, "1");

                foreach (var rBasByDept in rsBasByDept)
                    if (!rsBas.Where(p => p.Nobr == rBasByDept.Nobr).Any())
                        rsBas.Add(rBasByDept);

                txtNameAppS.DataSource = rsBas;
                txtNameAppS.DataTextField = "Name";
                txtNameAppS.DataValueField = "Nobr";
                txtNameAppS.DataBind();
            }
        }
        private void ckblNameAppS_DataBind()
        {
            if (lblDeptCodeAppM.Text.Trim().Length > 0)
            {
                OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);
                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
                var rsDept = oDeptDao.GetDept();

                lblDeptCodeAppMByDept.Text = oBasDao.GetBaseByNobr(lblNobrAppM.Text, DateTime.Now).FirstOrDefault().DeptCode;

                var rsBas = oBasDao.GetBaseByNobr(lblNobrAppM.Text);
                var rsBasByDept = oBasDao.GetBaseByDept(lblDeptCodeAppMByDept.Text, "1");

                foreach (var rBasByDept in rsBasByDept)
                    if (!rsBas.Where(p => p.Nobr == rBasByDept.Nobr).Any())
                        rsBas.Add(rBasByDept);

                ckblNameAppS.DataSource = rsBasByDept;
                ckblNameAppS.DataValueField = "Nobr";
                ckblNameAppS.DataTextField = "Name";
                ckblNameAppS.DataBind();


            }
        }
        private void ckblNameAppSRoteChange_DataBind()
        {
            if (lblDeptCodeAppM.Text.Trim().Length > 0)
            {
                OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);
                OldDal.Dao.Att.RoteDao oRoteDao = new OldDal.Dao.Att.RoteDao(dcHR.Connection);
                OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
                var rsDept = oDeptDao.GetDept();

                var rsBasByDept = oBasDao.GetBaseByDept(ddlDept.SelectedValue, "1", false, true);

                List<string> NobrList = new List<string>();

                //foreach (ListItem c in ckblNameAppS.Items)
                //{
                //    NobrList.Add(c.Value);
                //}
                foreach (var c in rsBasByDept)
                {
                    NobrList.Add(c.Nobr);
                }
                List<string> GetNobrByRoteH = new List<string>();

                var AttendAll = oAttendDao.GetAttend(NobrList, txtDateB.SelectedDate.Value, txtDateB.SelectedDate.Value);//取得該部門員工的加班日期當天班表

                if (txtRote.SelectedItem != null)
                    GetNobrByRoteH = AttendAll.Where(p => p.RoteCodeH == txtRote.SelectedItem.Value).Select(p => p.Nobr).ToList();//取得選擇的班別的人員清單

                var GetNobr = oBasDao.GetBase(GetNobrByRoteH);

                ckblNameAppS.DataSource = GetNobr;
                ckblNameAppS.DataValueField = "Nobr";
                ckblNameAppS.DataTextField = "Name";
                ckblNameAppS.DataBind();


            }
        }
        private void Rote_DataBind()
        {
            OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
            OldDal.Dao.Att.RoteDao oRoteDao = new OldDal.Dao.Att.RoteDao(dcHR.Connection);
            List<TextValueRow> Rote = new List<TextValueRow>();
            List<string> NobrList = new List<string>();
            TextValueRow it = new TextValueRow();
            //foreach (ListItem c in ckblNameAppS.Items)
            //{
            //    NobrList.Add(c.Value);
            //}
            foreach (RadComboBoxItem c in txtNameAppS.Items)
            {
                NobrList.Add(c.Value);
            }
            var AttendAll = oAttendDao.GetAttend(NobrList, txtDateB.SelectedDate.Value, txtDateB.SelectedDate.Value);
            var GroupAttend = AttendAll.GroupBy(p => new { p.RoteCodeH }).Select(p => p.Key).ToList();

            var RoteAll = oRoteDao.GetRote();
            foreach (var c in GroupAttend)
            {
                var GetRote = RoteAll.Where(p => p.RoteCode == c.RoteCodeH).FirstOrDefault();
                it = new TextValueRow();
                it.Text = GetRote.RoteName;
                it.Value = GetRote.RoteCode;
                Rote.Add(it);
            }

            txtRote.DataSource = Rote;
            txtRote.DataTextField = "Text";
            txtRote.DataValueField = "Value";
            txtRote.DataBind();

            var RoteByNobr = AttendAll.Where(p => p.Nobr == lblNobrAppS.Text).FirstOrDefault();
            if (RoteByNobr != null)
                txtRote.SelectedValue = RoteByNobr.RoteCodeH;
            else
                txtRote.SelectedValue = Rote.Count() > 0 ? Rote.First().Value : "";

        }
        private void ckblNameAppSDetail_DataBind()
        {
            OldDal.Dao.Att.AttcardDao oAttcardDao = new OldDal.Dao.Att.AttcardDao(dcHR.Connection);
            OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
            OldDal.Dao.Att.RoteDao oRoteDao = new OldDal.Dao.Att.RoteDao(dcHR.Connection);
            OldDal.Dao.Att.OtDao oOtDao = new OldDal.Dao.Att.OtDao(dcHR.Connection);
            List<string> NobrList = new List<string>();

            foreach (ListItem c in ckblNameAppS.Items)
            {
                NobrList.Add(c.Value);
            }

            var RoteAll = oRoteDao.GetRote();
            var AttCardAll = oAttcardDao.GetAttcard(NobrList, txtDateB.SelectedDate.Value, txtDateB.SelectedDate.Value);
            var AttendAll = oAttendDao.GetAttend(NobrList, txtDateB.SelectedDate.Value, txtDateB.SelectedDate.Value);
            var OtAll = oOtDao.GetOt(NobrList, txtDateB.SelectedDate.Value, txtDateB.SelectedDate.Value);

            foreach (ListItem c in ckblNameAppS.Items)
            {
                var GetAttCard = AttCardAll.Where(p => p.Nobr == c.Value).FirstOrDefault();
                var GetAttend = AttendAll.Where(p => p.Nobr == c.Value).FirstOrDefault();
                var GetOt = OtAll.Where(p => p.Nobr == c.Value).ToList();
                lblOtTime.Text = "";

                foreach (var q in GetOt)
                {
                    lblOtTime.Text += q.TimeB + "-" + q.TimeE;
                    if (GetOt.Count > 1)
                        lblOtTime.Text += "，";
                }

                if (GetAttend != null)
                {
                    if (GetAttend.IsHoliDay)
                        lblIsHoliday.Text = "[假日]";
                    else
                        lblIsHoliday.Text = "";
                    var GetRote = RoteAll.Where(p => p.RoteCode == GetAttend.RoteCodeH).FirstOrDefault();
                    if (GetRote != null)
                    {
                        lblRote.Text = GetRote.RoteName;
                        if (GetAttCard != null)
                        {
                            if (GetAttCard.OnCardTime48.Length == 4 && GetAttCard.OffCardTime48.Length == 4)
                            {
                                lblAttCard.Text = GetAttCard.OnCardTime48 + "-" + GetAttCard.OffCardTime48;
                                if (GetOt.Count() > 0)
                                {
                                    c.Text = "<font color=blue>" + c.Text + "&nbsp&nbsp&nbsp(" + lblRote.Text + lblIsHoliday.Text + " | " + "出勤刷卡時間：" + lblAttCard.Text + " | " + "已報加班時間：" + lblOtTime.Text + ")";
                                }
                                else
                                {
                                    c.Text = c.Text + "&nbsp&nbsp&nbsp(" + lblRote.Text + lblIsHoliday.Text + " | " + "出勤刷卡時間：" + lblAttCard.Text + " | " + ")";
                                }
                            }
                            else
                            {
                                lblAttCard.Text = GetAttCard.OnCardTime48 + "-" + GetAttCard.OffCardTime48;
                                if (GetOt.Count() > 0)
                                {
                                }
                                else
                                {
                                    lblOtTime.Text = "";
                                }
                                c.Text = "<font color=red>" + c.Text + "&nbsp&nbsp&nbsp(" + lblRote.Text + lblIsHoliday.Text + " | " + "出勤刷卡時間：" + lblAttCard.Text + " | " + "已報加班時間：" + lblOtTime.Text + ")";
                            }
                        }
                        else
                        {
                            if (GetOt.Count() > 0)
                            {
                            }
                            else
                            {
                                lblOtTime.Text = "";
                            }
                            c.Text = "<font color=red>" + c.Text + "&nbsp&nbsp&nbsp(" + lblRote.Text + lblIsHoliday.Text + " |" + "出勤刷卡時間：" + "| " + "已報加班時間：" + lblOtTime.Text + ")";
                        }
                    }
                    else
                    {
                        lblRote.Text = "";
                        if (GetAttCard != null)
                        {
                            lblAttCard.Text = GetAttCard.OnCardTime48 + "-" + GetAttCard.OffCardTime48;
                        }
                        else
                        {
                            lblAttCard.Text = "";
                        }
                        if (GetOt.Count() > 0)
                        {
                        }
                        else
                        {
                            lblOtTime.Text = "";
                        }
                        c.Text = "<font color=red>" + c.Text + "( " + lblRote.Text + " | " + "出勤刷卡時間：" + lblAttCard.Text + " | " + "已報加班時間：" + lblOtTime.Text + ")";
                    }
                }
                else
                {
                    c.Text = "<font color=red>" + c.Text + "( | | )";
                }
            }

        }
        //private void ckblNameAppSChange_DataBind()
        //{
        //    OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);
        //    var rsDept = oDeptDao.GetDeptm();
        //    OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
        //    var rsGetDept = oBasDao.GetBaseByNobr(lblNobrAppS.Text, DateTime.Now).FirstOrDefault();
        //    //特殊规则 75层级以下的 就抓到75的人向下 75以上的 采用本层
        //    OldBll.Bas.Dept oDept = new OldBll.Bas.Dept();
        //    string sDept = oDept.GetDeptByTree(rsGetDept.DeptCode, rsDept);

        //    var rsBasByDept = oBasDao.GetBaseByDept(sDept, "1", false, true);

        //    ckblNameAppS.DataSource = rsBasByDept;
        //    ckblNameAppS.DataValueField = "Nobr";
        //    ckblNameAppS.DataTextField = "Name";
        //    ckblNameAppS.DataBind();

        //}
        private void ddlOtCat_DataBind()
        {
            RadComboBoxItem it = new RadComboBoxItem();

            it.Text = "加班費";
            it.Value = "1";

            ddlOtCat.Items.Add(it);

            it = new RadComboBoxItem();

            it.Text = "補休假";
            it.Value = "2";

            ddlOtCat.Items.Add(it);
        }
        private void ddlRote_DataBind()
        {
            string Nobr = lblNobrAppS.Text;
            OldDal.Dao.Att.RoteDao oRoteDao = new OldDal.Dao.Att.RoteDao(dcHR.Connection);
            var rsRote = oRoteDao.GetRoteByOt(Nobr, DateTime.Now.Date);
            //var rsRote = oRoteDao.GetRote();
            ddlRote.DataSource = rsRote;
            ddlRote.DataTextField = "RoteName";
            ddlRote.DataValueField = "RoteCode";
            ddlRote.DataBind();
        }
        private void ddlOtrcd_DataBind()
        {
            string Nobr = lblNobrAppS.Text;

            OldDal.Dao.Att.OtDao oOtDao = new OldDal.Dao.Att.OtDao(dcHR.Connection);
            var rsOtrcd = oOtDao.GetOtrcd();

            ddlOtrcd.DataSource = rsOtrcd;
            ddlOtrcd.DataTextField = "Name";
            ddlOtrcd.DataValueField = "Code";
            ddlOtrcd.DataBind();
        }
        private void ddlDepts_DataBind()
        {
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);
            var rsDepts = oDeptDao.GetDepts();

            ddlDepts.DataSource = rsDepts;
            ddlDepts.DataTextField = "Name";
            ddlDepts.DataValueField = "Code";
            ddlDepts.DataBind();
        }
        private void ddlDept_DataBind()
        {
            List<string> lsDept = new List<string>();
            List<string> lsNobr = new List<string>();
            Dictionary<string, string> dcDept = new Dictionary<string, string>();
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);
            var rsDept = oDeptDao.GetDept();
            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
            var rsGetDept = oBasDao.GetBaseByNobr(lblNobrAppM.Text, DateTime.Now).FirstOrDefault();
            OldBll.Bas.Dept oDept = new OldBll.Bas.Dept();
            string sDept = oDept.GetDeptByTree(rsGetDept.DeptCode, rsDept);


            //var rsDeptByNobr = rsDept.Where(p => p.Manage == lblNobrAppM.Text).ToList();
            //foreach (var rDept in rsDeptByNobr)
            //    lsDept.Add(rDept.Code.Trim());
            lsDept.Add(rsGetDept.DeptCode);
            dcDept = rsDept.ToDictionary(p => p.Code, p => p.ParentCode);
            lsDept = oDept.GetDeptDowmList(dcDept, lsDept);

            var rsGetDeptm = oDeptDao.GetDept(lsDept, lsNobr).ToList();

            ddlDept.DataSource = rsGetDeptm;
            ddlDept.DataTextField = "Name";
            ddlDept.DataValueField = "Code";
            ddlDept.DataBind();


        }
        private void SetDefault()
        {
            var rForm = (from c in dcFlow.Forms
                         where c.Code == _FormCode
                         select c).FirstOrDefault();

            if (rForm != null)
            {
                lblFlowTreeID.Text = rForm.FlowTreeId;
                lblFormNoteStd.Text = rForm.NoteStd;
                Title = rForm.Name;
            }
        }
        #endregion
        #region 申请人工号及姓名
        protected void txtNameAppS_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SetName(e.Text);
            ckblNameAppS_DataBind();
            Rote_DataBind();
            ckblNameAppSRoteChange_DataBind();
            ckblNameAppSDetail_DataBind();
        }
        protected void txtNameAppS_DataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
                SetName(lblNobrAppM.Text);
        }
        protected void txtNameAppS_TextChanged(object sender, EventArgs e)
        {
            RadComboBox txt = sender as RadComboBox;
            RadComboBoxItem li = txt.SelectedItem;

            if (li != null)
                SetName(li);
            else if (txtNameAppS.Text.Trim().Length > 0)
            {
                SetName(txtNameAppS.Text);
                //ckblNameAppS_DataBind();
                //Rote_DataBind();
                //ckblNameAppSRoteChange_DataBind();
                //ckblNameAppSDetail_DataBind();
            }
        }
        private void SetName(RadComboBoxItem li)
        {
            if (li != null)
            {
                txtNameAppS.ClearSelection();
                li.Selected = true;
                SetName(li.Value);
            }

            //ShowgvOtInfo(li.Value.ToString(), txtDateB.SelectedDate.Value, lblDeptCodeAppM.Text, 0M);
        }
        private void SetName(string sNobr)
        {
            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
            var rBas = oBasDao.GetBase(sNobr).FirstOrDefault();
            var rBasDetail = oBasDao.GetBaseByNobr(sNobr, DateTime.Now.Date).FirstOrDefault();
            if (txtNameAppS.Items.Where(p => p.Value == sNobr).Any())
            {
                if (rBas != null)
                {
                    lblNobrAppS.Text = rBas.Nobr;
                    txtNameAppS.Text = rBas.Name;
                    txtNameAppS.ToolTip = rBas.Name;
                    lblSaladrS.Text = rBasDetail.Saladr;
                    ddlDept.SelectedValue = rBasDetail.DeptCode;

                }
                else
                    txtNameAppS.Text = txtNameAppS.ToolTip;
                txtDateB_SelectedDateChanged(null, null);
                SetDepts(lblNobrAppS.Text);
                ckbAll.Checked = false;
            }


            //palgvOtInfo.Visible = true;
            //ShowgvOtInfo(sNobr, txtDateB.SelectedDate.Value, lblDeptCodeAppM.Text, 0M);
        }
        #endregion
        private void SetTime(string sNobr, DateTime dDate)
        {
            txtTimeB.Text = "0000";
            txtTimeE.Text = "0000";

            OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
            var rAttend = oAttendDao.GetAttendH(sNobr, dDate).FirstOrDefault();

            OldDal.Dao.Att.AttcardDao oAttcardDao = new OldDal.Dao.Att.AttcardDao(dcHR.Connection);
            var rAttcard = oAttcardDao.GetAttcard(sNobr, dDate).FirstOrDefault();

            if (rAttend != null)
            {
                OldDal.Dao.Att.RoteDao oRoteDao = new OldDal.Dao.Att.RoteDao(dcHR.Connection);
                var rRote = oRoteDao.GetRoteDetail(new List<string>() { rAttend.RoteCode }).FirstOrDefault();

                if (rRote != null)
                {
                    //平日 先带入下班时间
                    if (!arrHoidDay.Contains(rRote.RoteCode))
                    {
                        txtTimeB.Text = rRote.OtBeginTime;
                        txtTimeE.Text = rRote.OtBeginTime;
                    }
                    else
                    {
                        //假日带入刷卡T1的时间
                        if (rAttcard != null && rAttcard.OnCardTime48.Length > 0)
                            txtTimeB.Text = rAttcard.OnCardTime48;
                    }

                    //共同带入刷卡下班时间
                    if (rAttcard != null && rAttcard.OffCardTime48.Length > 0)
                        txtTimeE.Text = rAttcard.OffCardTime48;
                }
            }
        }
        private void SetRote(string sNobr, DateTime dDate)
        {
            OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
            var rAttend = oAttendDao.GetAttendH(sNobr, dDate).FirstOrDefault();

            string RoteCode = oAttendDao.GetAttendFixedRoteCode(sNobr, dDate);
            if (rAttend != null)
                RoteCode = rAttend.RoteCodeH;

            if (ddlRote.Items.FindItemByValue(RoteCode) != null)
                ddlRote.Items.FindItemByValue(RoteCode).Selected = true;
        }
        private void SetDepts(string sNobr)
        {
            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
            var rBasS = oBasDao.GetBaseByNobr(sNobr, DateTime.Now.Date).FirstOrDefault();

            if (ddlDepts.Items.FindItemByValue(rBasS.DeptsCode) != null)
                ddlDepts.Items.FindItemByValue(rBasS.DeptsCode).Selected = true;
        }
        protected void txtDateB_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            //ckblNameAppS_DataBind();
            Rote_DataBind();
            ckblNameAppSRoteChange_DataBind();
            ckblNameAppSDetail_DataBind();
            //SetRote(ckblNameAppS, DateTime.Now.Date);
            //ckblNameAppSRoteChange_DataBind();
            //string Nobr = lblNobrAppS.Text;
            //DateTime Date = txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now).Date;
            //txtDateB.SelectedDate = Date;
            //SetTime(Nobr, Date);
            //SetRote(Nobr, Date);

            ////如果选择非假日，要锁住班别不让他选
            //ddlRote.Enabled = true;
            //OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
            //var rAttend = oAttendDao.GetAttend(Nobr, Date).FirstOrDefault();
            //if (rAttend != null && !rAttend.IsHoliDay)
            //    ddlRote.Enabled = false;

            //SetTransDateTime();
            //ShowgvOtInfo(Nobr, txtDateB.SelectedDate.Value, lblDeptCodeAppM.Text, 0M);

        }
        protected void gvAppS_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var rs = (from c in dcFlow.FormsAppOt
                      where c.ProcessID == lblProcessID.Text
                      select c).ToList();
            gvAppS.DataSource = rs;

            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var a = "";
            DateTime DateB = txtDateB.SelectedDate.Value;
            string TimeB = txtTimeB.Text;
            string TimeE = txtTimeE.Text;
            string OtCatCode = ddlOtCat.SelectedItem.Value;
            string OtCatName = ddlOtCat.SelectedItem.Text;
            string Otrcd = ddlOtrcd.SelectedItem.Value;
            string RoteHCode = "";
            string RoteHName = "";
            string RoteCode = "";
            //string Rote = ddlRote.SelectedItem.Value;
            string Depts = ddlDepts.SelectedItem.Value;
            int jg = 0;
            var Calculate = 0M;
            bool IsOt1 = true;
            if (txtDateB.SelectedDate == null)
            {
                lblErrorMsg.Text = "您的開始或結束日期沒有輸入正確";
                return;
            }
            if (TimeB.Length != 4 || TimeE.Length != 4)
            {
                lblErrorMsg.Text = "您所輸入的時間不正確";
                return;
            }

            //int iTimeB = OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeB);
            //int iTimeE = OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeE);
            //int iTemp;

            //iTemp = (30 - (iTimeB % 30));
            //iTimeB = iTemp == 30 ? iTimeB : iTimeB + iTemp;
            //TimeB = OldBll.Tools.TimeTrans.ConvertMinutesToHhMm(iTimeB);

            //iTemp = iTimeE % 30;
            //iTimeE -= iTemp;
            //TimeE = OldBll.Tools.TimeTrans.ConvertMinutesToHhMm(iTimeE);

            DateTime DateTimeB = DateB.Date.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeB));
            DateTime DateTimeE = DateB.Date.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeE));

            if (DateTimeB >= DateTimeE)
            {
                lblErrorMsg.Text = "您的開始日期時間不能大於或等於結束日期時間";
                return;
            }

            OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
            OldDal.Dao.Att.RoteDao oRoteDao = new OldDal.Dao.Att.RoteDao(dcHR.Connection);


            var Is0XOt = (from c in dcFlow.FormsExtend
                          where c.FormsCode == "Ot" && c.Active == true && c.Code == "Is0XOt"
                          select c).FirstOrDefault();




            int ckblCount = 0;
            foreach (ListItem item in ckblNameAppS.Items)
            {
                if (item.Selected == true)
                {
                    ckblCount++;
                }
            }
            if (ckblCount >= 50)
            {
                lblErrorMsg.Text = "最多一次只能申請50筆加班資料";
                return;
            }

            foreach (ListItem item in ckblNameAppS.Items)
            {
                if (item.Selected == true)
                {
                    a = item.Value;
                    lblNobrAppS.Text = a;

                    string Nobr = lblNobrAppS.Text;
                    string Note = txtNote.Text.Trim();

                    var rAttend = oAttendDao.GetAttendH(Nobr, DateB.Date).FirstOrDefault();
                    if (Is0XOt != null && rAttend.RoteCode == "0X")
                    {
                        lblErrorMsg.Text = "休息日無法申請加班";
                        return;
                    }

                    var Is0ZOt = (from c in dcFlow.FormsExtend
                                  where c.FormsCode == "Ot" && c.Active == true && c.Code == "Is0ZOt"
                                  select c).FirstOrDefault();
                    if (Is0ZOt != null && rAttend.RoteCode == "0Z")
                    {
                        lblErrorMsg.Text = "例假日無法申請加班";
                        return;
                    }

                    var GetAttend = oAttendDao.GetAttendH(Nobr, DateB).FirstOrDefault();
                    if (GetAttend != null)
                    {
                        RoteHCode = GetAttend.RoteCodeH;
                        var GetRoteAll = oRoteDao.GetRote(RoteHCode).FirstOrDefault();
                        if (GetRoteAll != null)
                        {
                            RoteHName = GetRoteAll.RoteName;
                            RoteCode = GetAttend.RoteCode;
                        }
                        else
                        {
                            lblErrorMsg.Text = "無此出勤班別，請假人事單位";
                            return;
                        }
                    }
                    else
                    {
                        lblErrorMsg.Text = "出勤班別錯誤，請假人事單位";
                        return;
                    }

                    OldDal.Dao.Att.AbsDao oAbsDao = new OldDal.Dao.Att.AbsDao(dcHR.Connection);
                    OldDal.Dao.Att.AttcardDao oAttcardDao = new OldDal.Dao.Att.AttcardDao(dcHR.Connection);


                    //RadWindowManager1.RadAlert("您所申请的时间不可为过去的时间", 400, 100, "警告讯息", "", "");
                    //return;
                    //}

                    var rAttendDate = oAttendDao.GetAttendH(Nobr, DateB).FirstOrDefault();
                    if (rAttendDate == null)
                    {
                        lblErrorMsg.Text = "出勤資料錯誤，請洽人事單位";
                        return;
                    }

                    //DateTime AppDate = Convert.ToDateTime(rAttendDate.Text);

                    //if (DateB < AppDate)
                    //{
                    //    RadWindowManager1.RadAlert("您所申请的日期必须是前一次出勤日三日之后，请洽人事单位", 300, 100, "警告讯息", "", "");
                    //    return;
                    //}

                    //检查重复的数据
                    var rsAppS = (from c in dcFlow.FormsAppOt
                                  where (c.ProcessID == lblProcessID.Text || (c.idProcess != 0 && c.SignState == "1"))
                                  && c.EmpId == Nobr
                                  select c).ToList();

                    if (rsAppS.Where(c => c.DateTimeB < DateTimeE && c.DateTimeE > DateTimeB).Any())
                    {
                        lblErrorMsg.Text = "資料重複或流程正在進行中";
                        return;
                    }

                    OldDal.Dao.Att.OtDao oOtDao = new OldDal.Dao.Att.OtDao(dcHR.Connection);
                    var rsOt = oOtDao.GetOt(Nobr, DateB.AddDays(-1).Date, DateB.AddDays(1).Date);
                    foreach (var c in rsOt)
                    {
                        if (rsOt.Where(p => p.DateTimeB < DateTimeE && p.DateTimeE > DateTimeB).Any())
                        {
                            lblErrorMsg.Text = "人事資料重複";
                            return;
                        }
                    }


                    var rEmpS = (from role in dcFlow.Role
                                 join emp in dcFlow.Emp on role.Emp_id equals emp.id
                                 join dept in dcFlow.Dept on role.Dept_id equals dept.id
                                 join pos in dcFlow.Pos on role.Pos_id equals pos.id
                                 where role.Emp_id == Nobr
                                 select new
                                 {
                                     RoleId = role.id,
                                     EmpNobr = emp.id,
                                     EmpName = emp.name,
                                     DeptCode = dept.id,
                                     DeptName = dept.name,
                                     JobCode = pos.id,
                                     JobName = pos.name,
                                     Auth = role.deptMg.Value,
                                 }).FirstOrDefault();

                    DateTime DateB1 = DateB;
                    DateTime DateE1 = DateB;
                    string TimeB1 = TimeB;
                    string TimeE1 = TimeE;

                    var OtMin = 0.5M;

                    if (jg == 0)
                    {
                        var OtIntervalExtend = (from c in dcFlow.FormsExtend
                                                where c.FormsCode == "Ot" && c.Code == "OtInterval" && c.Active == true
                                                select c).ToList();
                        if (OtIntervalExtend.Any())
                        {
                            OtMin = Convert.ToDecimal(OtIntervalExtend.First().Column1);
                            var IntervalTime = Convert.ToDecimal(OtIntervalExtend.First().Column2);
                            Calculate = oOtDao.GetCalculate(Nobr, OtCatCode, DateB1, DateE1, TimeB1, TimeE1, Otrcd, 0, RoteHCode, InterVal: IntervalTime);
                        }
                        else
                            Calculate = oOtDao.GetCalculate(Nobr, OtCatCode, DateB1, DateE1, TimeB1, TimeE1, Otrcd, 0, RoteHCode);

                        jg = 1;
                    }
                    if (Calculate == 0M)
                    {
                        lblErrorMsg.Text = "計算時數必須大於0.5小時";
                        return;
                    }


                    var Code = Guid.NewGuid().ToString();

                    var rsFormsAppOt = new FormsAppOt();
                    rsFormsAppOt.Code = Code;
                    rsFormsAppOt.ProcessID = lblProcessID.Text;
                    rsFormsAppOt.idProcess = 0;
                    rsFormsAppOt.EmpId = Nobr;
                    rsFormsAppOt.EmpName = rEmpS.EmpName;
                    rsFormsAppOt.DeptCode = rEmpS.DeptCode;
                    rsFormsAppOt.DeptName = rEmpS.DeptName;
                    rsFormsAppOt.JobCode = rEmpS.JobCode;
                    rsFormsAppOt.JobName = rEmpS.JobName;
                    rsFormsAppOt.RoleId = rEmpS.RoleId;
                    rsFormsAppOt.DateTimeB1 = DateTimeB;
                    rsFormsAppOt.DateTimeE1 = DateTimeE;
                    rsFormsAppOt.DateB1 = DateB1;
                    rsFormsAppOt.DateE1 = DateE1;
                    rsFormsAppOt.TimeB1 = TimeB1;
                    rsFormsAppOt.TimeE1 = TimeE1;
                    rsFormsAppOt.DateTimeB = DateTimeB;
                    rsFormsAppOt.DateTimeE = DateTimeE;
                    rsFormsAppOt.DateB = DateB;
                    rsFormsAppOt.DateE = DateB;
                    rsFormsAppOt.TimeB = TimeB;
                    rsFormsAppOt.TimeE = TimeE;
                    rsFormsAppOt.RoteCode = RoteCode;
                    rsFormsAppOt.RoteName = RoteHName;
                    rsFormsAppOt.RotehCode = RoteCode;
                    rsFormsAppOt.RotehName = RoteHName;
                    rsFormsAppOt.OtCateCode = OtCatCode;
                    rsFormsAppOt.OtCateName = ddlOtCat.SelectedItem.Text;
                    rsFormsAppOt.OtrcdCode = Otrcd;
                    rsFormsAppOt.OtrcdName = ddlOtrcd.SelectedItem.Text;
                    rsFormsAppOt.DeptsCode = Depts;
                    rsFormsAppOt.DeptsName = ddlDepts.SelectedItem.Text;
                    rsFormsAppOt.Use = Calculate;
                    rsFormsAppOt.UnitCode = "";
                    rsFormsAppOt.IsExceptionUse = false;
                    rsFormsAppOt.ExceptionUse = 0;
                    rsFormsAppOt.Sign = true;
                    rsFormsAppOt.SignState = "1";
                    rsFormsAppOt.Note = txtNote.Text;
                    rsFormsAppOt.Status = "1";
                    rsFormsAppOt.InsertDate = DateTime.Now;
                    rsFormsAppOt.InsertMan = _User.EmpId;

                    var rsFormsAppInfo = new FormsAppInfo()
                    {
                        Code = Code,
                        EmpId = rEmpS.EmpNobr,
                        EmpName = rEmpS.EmpName,
                        idProcess = 0,
                        ProcessId = lblProcessID.Text,
                        KeyDate = DateTime.Now,
                        SignState = "1",
                        InfoSign = rsFormsAppOt.EmpName + "," + rsFormsAppOt.DateB.ToShortDateString() + "," + rsFormsAppOt.TimeB + "~" + rsFormsAppOt.DateE.ToShortDateString() + "," + rsFormsAppOt.TimeE + rsFormsAppOt.Use + "小時," + rsFormsAppOt.Note,
                        InfoMail = MessageSendMail.OtBody(rsFormsAppOt.EmpId, rsFormsAppOt.EmpName, rsFormsAppOt.DeptName, RoteHName, rsFormsAppOt.DateB, rsFormsAppOt.TimeB, rsFormsAppOt.TimeE, rsFormsAppOt.Use, rsFormsAppOt.OtCateName, rsFormsAppOt.Note)
                    };

                    dcFlow.FormsAppInfo.InsertOnSubmit(rsFormsAppInfo);
                    dcFlow.FormsAppOt.InsertOnSubmit(rsFormsAppOt);
                }
            }
            dcFlow.SubmitChanges();

            gvAppS.Rebind();
            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
            Session["sProcessID"] = lblProcessID.Text;
            Session["FormCode"] = _FormCode;
            Session["FlowTreeID"] = lblFlowTreeID.Text;

            lblNotifyMsg.Text = "新增成功";
        }
        protected void gvAppS_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();


            var r = (from c in dcFlow.FormsAppOt
                     where c.AutoKey == Convert.ToInt32(ca)
                     select c).FirstOrDefault();


            if (cn == "Del")
            {
                if (r != null)
                {
                    dcFlow.FormsAppOt.DeleteOnSubmit(r);

                    dcFlow.SubmitChanges();
                    lblNotifyMsg.Text = "刪除成功";
                }
            }
            gvAppS.Rebind();
        }

        protected void btnDate_Click(object sender, EventArgs e)
        {
            txtDateB_SelectedDateChanged(null, null);
        }
        /// <summary>取得某日期在該星期的第一天 (星期日) </summary> 
        /// <param name="dt">某日期</param> 
        /// <returns>某日期在該星期的第一天 (星期日)</returns>         
        protected DateTime GetTheFirstDayOfWeek(DateTime dt)
        {
            return dt.AddDays((int)dt.DayOfWeek * -1).Date;
        }

        /// <summary>取得某日期在該星期的最後一天 (星期六)</summary> 
        /// <param name="dt">某日期</param> 
        /// <returns>某日期在該星期的最後一天 (星期六)</returns> 
        protected DateTime GetTheLastDayOfWeek(DateTime dt)
        {
            return dt.AddDays(7 + (int)dt.DayOfWeek * -1 - 1).Date;
        }
        protected void btnTransCard_Click(object sender, EventArgs e)
        {
            string Nobr = lblNobrAppS.Text;
            DateTime Date = txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now.Date);

            OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
            var rAttend = oAttendDao.GetAttend(Nobr, Date).FirstOrDefault();

            if (rAttend != null)
            {
                string RoteCode = rAttend.RoteCode;

                if (arrHoidDay.Contains(RoteCode))
                {
                    //置换假日真实新班别
                    RoteCode = ddlRote.SelectedItem.Value;

                    oAttendDao.SaveAttend(Nobr, Date, RoteCode);
                }

                OldDal.Dao.Att.TransCardDao oTransCardDao = new OldDal.Dao.Att.TransCardDao(dcHR.Connection);
                oTransCardDao.TransCard(Nobr, Nobr, "0", "z", Date, Date, Nobr, true, true, true, "", "JB-TRANSCARD", true, 1);

                SetTime(Nobr, Date);
                //SetTransDateTime();
            }
        }
        protected void ckbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAll.Checked == true)
            {
                foreach (ListItem c in ckblNameAppS.Items)
                {

                    c.Selected = true;
                }
            }
            else
            {
                foreach (ListItem c in ckblNameAppS.Items)
                {

                    c.Selected = false;
                }
            }
        }
        protected void ddlDept_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ckblNameAppS_DataBind();
            Rote_DataBind();
            ckblNameAppSRoteChange_DataBind();
            ckblNameAppSDetail_DataBind();
        }
        protected void txtRote_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ckblNameAppS_DataBind();
            ckblNameAppSRoteChange_DataBind();
            ckblNameAppSDetail_DataBind();
        }
        protected void btnRoteReBind_Click(object sender, EventArgs e)
        {
            ckblNameAppS_DataBind();
            ckblNameAppSDetail_DataBind();
        }

        protected void gvAppS_DataBound(object sender, EventArgs e)
        {
            int count = 0;
            foreach (var item in gvAppS.Items)
            {
                var No = item.FindControl("lblListNumber") as RadLabel;
                if (No != null)
                {
                    count++;
                    No.Text = count.ToString();
                }

            }
            var lblAbsCount = gvAppS.FindControl("lblCount") as RadLabel;
            if (lblAbsCount != null)
                lblAbsCount.Text = count.ToString();
        }
    }
}