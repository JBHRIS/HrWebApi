using Bll.Flow.Vdb;
using Dal;
using Dal.Dao.Flow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class FormOvtChk2 : WebPageBase
    {
        private dcHrDataContext dcHR = new dcHrDataContext();
        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private bool isView = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompanySetting != null)
            {
                dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
            }
            if (UnobtrusiveSession.Session["RequestName"].ToString() == "View")
                isView = true;
            if (!IsPostBack)
            {
                if (Request.QueryString["ProcessApParmAuto"] != null)
                {
                    int RequestValue = 0;
                    RequestValue = Convert.ToInt32(UnobtrusiveSession.Session["ProcessApParmAuto"].ToString());

                    var rsProcessFlowID = (from c in dcFlow.ProcessApParm
                                           where c.auto == RequestValue
                                           select c).FirstOrDefault();

                    if (rsProcessFlowID != null)
                        lblProcessID.Text = rsProcessFlowID.ProcessFlow_id.ToString();

                }
                else if (Request.QueryString["ProcessApViewAuto"] != null)
                {
                    int RequestValue = 0;
                    RequestValue = Convert.ToInt32(UnobtrusiveSession.Session["ProcessApViewAuto"].ToString());

                    var rsProcessFlowID = (from c in dcFlow.ProcessApView
                                           where c.auto == RequestValue
                                           select c).FirstOrDefault();


                    if (rsProcessFlowID != null)
                        lblProcessID.Text = rsProcessFlowID.ProcessFlow_id.ToString();
                }
            }
        }
        protected void gvAppS_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var oFormAppOtDao = new FormAppOtDao();
            var FormAppOtCond = new FormAppOtConditions();

            FormAppOtCond.AccessToken = _User.AccessToken;
            FormAppOtCond.RefreshToken = _User.RefreshToken;
            FormAppOtCond.CompanySetting = CompanySetting;
            FormAppOtCond.ProcessFlowID = lblProcessID.Text;
            FormAppOtCond.Sign = true;
            FormAppOtCond.SignState = "";
            FormAppOtCond.Status = UnobtrusiveSession.Session["RequestName"].ToString() == "View" ? "" : "1";

            var rsFormAppOt = oFormAppOtDao.GetData(FormAppOtCond);
            var rFormAppOt = new FormAppOtRow();
            if (rsFormAppOt.Status)
            {
                if (rsFormAppOt.Data != null)
                {
                    rFormAppOt = rsFormAppOt.Data as FormAppOtRow;
                    if (rFormAppOt.FlowApps.Count() != 0)
                    {
                        gvAppS.DataSource = rFormAppOt.FlowApps;
                        Session["ProcessID"] = lblProcessID.Text;
                    }
                }
            }

        }
        protected void btnCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadButtonList rsButtonList = sender as RadButtonList;
            var ca = rsButtonList.FeatureGroupID;

            var rs = (from c in dcFlow.FormsAppOt
                      where c.AutoKey.ToString() == ca
                      select c).FirstOrDefault();

            var btnCheck = sender as RadRadioButtonList;

            if (rs != null)
            {
                if (btnCheck.SelectedValue == "2")
                {
                    rs.SignState = "2";
                    rs.Sign = false;
                }
                if (btnCheck.SelectedValue == "1")
                {
                    rs.SignState = "1";
                    rs.Sign = true;
                }

                dcFlow.SubmitChanges();
            }
        }

        protected void gvAppS_ItemDataBound(object sender, RadListViewItemEventArgs e)
        {
            RadRadioButtonList rdblSign = e.Item.FindControl("btnCheck") as RadRadioButtonList;

            var rsFlowNodeId = (from pn in dcFlow.ProcessApParm
                                join pc in dcFlow.ProcessNode on pn.ProcessNode_auto equals pc.auto
                                where pn.ProcessFlow_id == Convert.ToInt32(lblProcessID.Text)
                                orderby pc.auto descending
                                select pc).FirstOrDefault();


            var OvtDynamic = (from c in dcFlow.FormsExtend//加班單申請者確認節點編號
                               where c.FormsCode == "Ovt" && c.Code == "OvtOt1CheckNode" && c.Active == true
                               select c).FirstOrDefault();

            if (OvtDynamic != null && OvtDynamic.Column1 != null && OvtDynamic.Column1 != "")
            {
                var NodeId = OvtDynamic.Column1.Split(';');
                if (NodeId.Contains(rsFlowNodeId.FlowNode_id))//若是在需要確認的節點需要檢查時間是在刷卡時間內
                {

                    RadLabel lblDateB = e.Item.FindControl("lblDateB") as RadLabel;
                    RadLabel lblTimeB = e.Item.FindControl("lblTimeB") as RadLabel;
                    RadLabel lblDateE = e.Item.FindControl("lblDateE") as RadLabel;
                    RadLabel lblTimeE = e.Item.FindControl("lblTimeE") as RadLabel;
                    RadLabel lblEmpName = e.Item.FindControl("lblEmpName") as RadLabel;
                    RadLabel lblEmpId = e.Item.FindControl("lblEmpId") as RadLabel;


                    string Nobr = lblEmpId.Text;
                    DateTime DateB = Convert.ToDateTime(lblDateB.Text);
                    DateTime DateE = Convert.ToDateTime(lblDateE.Text);
                    string TimeB = lblTimeB.Text;
                    string TimeE = lblTimeE.Text;

                    OldDal.Dao.Att.AbsDao oAbsDao = new OldDal.Dao.Att.AbsDao(dcHR.Connection);
                    OldDal.Dao.Att.AttcardDao oAttcardDao = new OldDal.Dao.Att.AttcardDao(dcHR.Connection);
                    var rsAbs = oAbsDao.GetAbs(Nobr, DateB, DateB);
                    var lsHcode = new List<string>();

                    var OtAbs1Hcode = (from c in dcFlow.FormsExtend
                                       where c.FormsCode == "Ot" && c.Active == true && c.Code == "OtAbs1Hcode"
                                       select c).FirstOrDefault();
                    if (OtAbs1Hcode != null)
                    {
                        var sHcode = OtAbs1Hcode.Column1.Split(';').ToList();
                        lsHcode.AddRange(sHcode);
                    }
                    else
                    {
                        lsHcode.Add("N");
                    }
                    var rAbs = rsAbs.Where(p => lsHcode.Contains(p.Hcode)).FirstOrDefault();
                    bool IsAbs = false;
                    DateTime dDateTimeB, dDateTimeE;
                    if (rAbs != null)
                    {
                        dDateTimeB = DateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeB));    //加班开始日期时间
                        dDateTimeE = DateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeE));    //加班结束日期时间

                        DateTime dAbsDateTimeB, dAbsDateTimeE;
                        dAbsDateTimeB = rAbs.DateE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rAbs.TimeB));    //实际开始日期时间
                        dAbsDateTimeE = rAbs.DateE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rAbs.TimeE));    //实际结束日期时间
                                                                                                                             //检视公出单
                        if (dAbsDateTimeB <= dDateTimeB && dDateTimeE <= dAbsDateTimeE)
                        {
                            IsAbs = true;
                        }
                    }
                    if (!IsAbs && !oAttcardDao.IsCardTime(Nobr, DateB, TimeB, TimeE))
                    {
                        lblDateB.ForeColor = System.Drawing.Color.Red;
                        lblTimeB.ForeColor = System.Drawing.Color.Red;
                        lblDateE.ForeColor = System.Drawing.Color.Red;
                        lblTimeE.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }



            if (isView)
            {
                txtNote.Enabled = false;
                rdblSign.Visible = false;
                return;
            }
            if (rdblSign != null)
            {
                foreach (ButtonListItem list in rdblSign.Items)
                {
                    if (rdblSign.ToolTip == "1")
                    {
                        if (list.Value == "1")
                            list.Selected = true;
                    }
                    if (rdblSign.ToolTip == "2")
                    {
                        if (list.Value == "2")
                            list.Selected = true;
                    }
                }
            }
        }
        public RadTextBox Note
        {
            get { return txtNote; }
            set { txtNote = value; }
        }
        protected void lvSignM_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var rsSignM = (from c in dcFlow.FormsSign
                           where c.idProcess == Convert.ToInt32(lblProcessID.Text)
                           select c).ToList();

            lvSignM.DataSource = rsSignM;
        }

        protected void btnChangeTime_Click(object sender, EventArgs e)
        {
            var btnChangeTime = sender as RadButton;
            var Autokey = btnChangeTime.ToolTip;
            var a = (from c in dcFlow.FormsAppOt
                     where c.AutoKey == Convert.ToInt32(Autokey)
                     select c).FirstOrDefault();
            //lvChangeTime.DataSource = a;
            //lvChangeTime.DataBind();
            lblNobr.Text = a.EmpId;
            lblName.Text = a.EmpName;
            lblDate.Text = a.DateTimeB.ToShortDateString();
            lblAutokey.Text = a.AutoKey.ToString();
            txtTimeB.Text = a.TimeB;
            txtTimeE.Text = a.TimeE;
            lblErrorMsg.Text = "";
            SetCardTime(lblNobr.Text, a.DateTimeB);
        }
        private void SetCardTime(string sNobr, DateTime dDate)
        {
            lblCardTime.Text = "";

            string Card = GetCardTime(sNobr, dDate.AddDays(-1));
            if (Card.Length > 0)
                lblCardTime.Text = Card;

            Card = GetCardTime(sNobr, dDate);
            if (Card.Length > 0)
            {
                if (lblCardTime.Text.Length > 0)
                    lblCardTime.Text += "<BR>";
                lblCardTime.Text += Card;
            }

            Card = GetCardTime(sNobr, dDate.AddDays(1));
            if (Card.Length > 0)
            {
                if (lblCardTime.Text.Length > 0)
                    lblCardTime.Text += "<BR>";
                lblCardTime.Text += Card;
            }
        }

        private string GetCardTime(string sNobr, DateTime dDate)
        {
            string Card = "";

            OldDal.Dao.Att.CardDao oCardDao = new OldDal.Dao.Att.CardDao(dcHR.Connection);
            var rsCard = oCardDao.GetData(sNobr, dDate.Date);
            if (rsCard.Count > 0)
            {
                Card = dDate.ToShortDateString() + "-";

                foreach (var rCard in rsCard)
                    Card += rCard.OnTime + ",";
            }

            return Card;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            var r = (from c in dcFlow.FormsAppOt
                     where c.AutoKey == Convert.ToInt32(lblAutokey.Text)
                     select c).FirstOrDefault();

            if (r != null)
            {
                string Nobr = lblNobr.Text;
                string OtCat = r.OtCateCode;
                string Otrcd = r.OtrcdCode;
                string Rote = r.RoteCode;
                DateTime DateB = r.DateB.Date;
                string TimeB = txtTimeB.Text;
                string TimeE = txtTimeE.Text;

                if (TimeB.Length != 4 || TimeE.Length != 4)
                {
                    lblErrorMsg.Text = "輸入的時間不正確";
                    return;
                }

                OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
                var rAttend = oAttendDao.GetAttend(Nobr, DateB).FirstOrDefault();

                //if (rAttend.IsHoliDay)
                //{
                //    int iTimeB = Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeB);
                //    int iTimeE = Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeE);
                //    int iTemp;

                //    iTemp = (30 - (iTimeB % 30));
                //    iTimeB = iTemp == 30 ? iTimeB : iTimeB + iTemp;
                //    TimeB = Bll.Tools.TimeTrans.ConvertMinutesToHhMm(iTimeB);

                //    iTemp = iTimeE % 30;
                //    iTimeE -= iTemp;
                //    TimeE = Bll.Tools.TimeTrans.ConvertMinutesToHhMm(iTimeE);
                //}

                DateTime DateTimeB = DateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeB));
                DateTime DateTimeE = DateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeE));
                if (DateTimeB >= DateTimeE)
                {
                    lblErrorMsg.Text = "開始日期時間不能大於或等於結束日期時間";
                    return;
                }

                OldDal.Dao.Att.OtDao oOtDao = new OldDal.Dao.Att.OtDao(dcHR.Connection);

                var Calculate = oOtDao.GetCalculate(Nobr, OtCat, DateB, DateB, TimeB, TimeE, Otrcd, 0, Rote, true, true);

                var OtMin = 0.5M;

                var OtIntervalExtend = (from c in dcFlow.FormsExtend
                                        where c.FormsCode == "Ot" && c.Code == "OtInterval" && c.Active == true
                                        select c).ToList();
                if (OtIntervalExtend.Any())
                {
                    OtMin = Convert.ToDecimal(OtIntervalExtend.First().Column1);
                    var IntervalTime = Convert.ToDecimal(OtIntervalExtend.First().Column2);
                    Calculate = oOtDao.GetCalculate(Nobr, OtCat, DateB, DateB, TimeB, TimeE, Otrcd, 0, Rote, InterVal: IntervalTime);
                }
                else
                    Calculate = oOtDao.GetCalculate(Nobr, OtCat, DateB, DateB, TimeB, TimeE, Otrcd, 0, Rote);

                if (Calculate <= 0)
                {
                    lblErrorMsg.Text = "計算時數不可以為零";
                    return;
                }
                OldDal.Dao.Att.AbsDao oAbsDao = new OldDal.Dao.Att.AbsDao(dcHR.Connection);
                OldDal.Dao.Att.AttcardDao oAttcardDao = new OldDal.Dao.Att.AttcardDao(dcHR.Connection);
                var rsAbs = oAbsDao.GetAbs(Nobr, DateB, DateB);
                var lsHcode = new List<string>();

                var OtAbs1Hcode = (from c in dcFlow.FormsExtend
                                   where c.FormsCode == "Ot" && c.Active == true && c.Code == "OtAbs1Hcode"
                                   select c).FirstOrDefault();
                if (OtAbs1Hcode != null)
                {
                    var sHcode = OtAbs1Hcode.Column1.Split(';').ToList();
                    lsHcode.AddRange(sHcode);
                }
                else
                {
                    lsHcode.Add("N");
                }
                var rAbs = rsAbs.Where(p => lsHcode.Contains(p.Hcode)).FirstOrDefault();
                bool IsAbs = false;
                if (rAbs != null)
                {
                    DateTime dDateTimeB, dDateTimeE;
                    dDateTimeB = DateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeB));    //加班开始日期时间
                    dDateTimeE = DateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeE));    //加班结束日期时间

                    DateTime dAbsDateTimeB, dAbsDateTimeE;
                    dAbsDateTimeB = rAbs.DateE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rAbs.TimeB));    //实际开始日期时间
                    dAbsDateTimeE = rAbs.DateE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rAbs.TimeE));    //实际结束日期时间
                                                                                                                         //检视公出单
                    if (dAbsDateTimeB <= dDateTimeB && dDateTimeE <= dAbsDateTimeE)
                    {
                        IsAbs = true;
                    }
                }

                if (!IsAbs && !oAttcardDao.IsCardTime(Nobr, DateB, TimeB, TimeE))
                {
                    lblErrorMsg.Text = "申請時間不在刷卡時間內";
                    return;
                }

                r.TimeB = txtTimeB.Text;
                r.TimeE = txtTimeE.Text;
                r.Use = Calculate;

                dcFlow.SubmitChanges();
                gvAppS.Rebind();

                var Script = "$(document).ready(function() {$('.footable').footable();});";
                ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);


                lblErrorMsg.Text = "修改完畢";
            }
        }
    }
}