using Bll.Attendance.Vdb;
using Bll.Token.Vdb;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dal.Dao.Attendance
{
    public class AttendDetailDao : BaseWebAPI<AttendDetailApiRow>
    {

        public AttendDetailDao() : base()
        {
            this.restURL = "/api/Attendance/GetAttendDetail";
            this.ApiSetting = "Hr";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = false;
        }

        public async Task<APIResult> PostAsync(AttendDetailConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();

            // ---------------------------- 另外兩種建立 QueryString的方式
            //dic.Add(Global.getName(() => memberSignIn_QS.app), memberSignIn_QS.app);
            //dic.AddItem<string>(() => 查詢資料QueryString.strHospCode);
            //dic.Add("Price", SetMemberSignUpVM.Price.ToString());
            dic.Add(Constants.JSONDataKeyName, JsonConvert.SerializeObject(Cond));
            //dic.Add("UserId", Cond.UserId);
            //dic.Add("Password", Cond.Password);
            #endregion

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            var  mr = await this.SendAsync(dic, HttpMethod.Post, RefreshToken, cancellationToken);

            return mr;
        }

        public APIResult Post(AttendDetailConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();

            // ---------------------------- 另外兩種建立 QueryString的方式
            //dic.Add(Global.getName(() => memberSignIn_QS.app), memberSignIn_QS.app);
            //dic.AddItem<string>(() => 查詢資料QueryString.strHospCode);
            //dic.Add("Price", SetMemberSignUpVM.Price.ToString());
            dic.Add(Constants.JSONDataKeyName, JsonConvert.SerializeObject(Cond));
            //dic.Add("UserId", Cond.UserId);
            //dic.Add("Password", Cond.Password);
            #endregion

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";
            this.CompanySetting = Cond.CompanySetting;
            var mr = this.Send(dic, HttpMethod.Post,RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(AttendDetailConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = await this.PostAsync(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Payload != null && Vdb.Data != null)
                {
                    var oSource = Vdb.Data as AttendDetailApiRow;

                    if (oSource != null)
                    {
                        Vdb.Status = oSource.state;
                        Vdb.Message = oSource.message;
                        Vdb.StackTrace = oSource.stackTrace;

                        if (oSource.state)
                        {
                            var rsSource = oSource.result;
                            var rsTarget = new List<AttendDetailRow>();

                            foreach (var rSource in rsSource)
                            {
                                var rTarget = new AttendDetailRow();
                                rTarget.EmpId = rSource.employeeId;
                                rTarget.EmpName = rSource.employeeName;
                                rTarget.DateA = rSource.attendDate;
                                rTarget.RoteDisplayName = rSource.roteCodeDisp;
                                rTarget.RoteCode = rSource.roteCode;
                                rTarget.RoteName = rSource.roteName;
                                rTarget.RoteTimeB = rSource.roteTimeB;
                                rTarget.RoteTimeE = rSource.roteTimeE;
                                rTarget.RoteTime = rTarget.RoteTimeB + "-" + rTarget.RoteTimeE;
                                rTarget.AttcardTimeB = rSource.cardTimeB;
                                rTarget.AttcardTimeE = rSource.cardTimeE;
                                rTarget.AttcardTime = rTarget.AttcardTimeB + "-" + rTarget.AttcardTimeE;
                                rTarget.LateMins = Convert.ToInt32(rSource.lateMin);
                                rTarget.EarlyMins = Convert.ToInt32(rSource.earlyMin);
                                rTarget.IsAbs = rSource.isAbs ? "是" : "否";
                                rTarget.Forget = Convert.ToInt32(rSource.forget);

                                //請假資料組合
                                rTarget.ListAbs = new List<AbsRow>();
                                var rsSourceAbs = rSource.listAbs;
                                foreach (var rSourceAbs in rsSourceAbs)
                                {
                                    var rTargetAbs = new AbsRow();
                                    rTargetAbs.Name = rSourceAbs.holidayName;
                                    rTargetAbs.TimeB = rSourceAbs.beginTime;
                                    rTargetAbs.TimeE = rSourceAbs.endTime;
                                    rTargetAbs.Time = rTargetAbs.TimeB + "-" + rTargetAbs.TimeE;
                                    rTargetAbs.Hcode = rSourceAbs.holidayCode;
                                    rTargetAbs.HcodeName = rSourceAbs.holidayName;
                                    rTargetAbs.HcodeUnitName = rSourceAbs.absenceUnit;
                                    rTargetAbs.Use = rSourceAbs.absenceAmount;
                                    rTarget.ListAbs.Add(rTargetAbs);

                                    //組合數列資料
                                    rTarget.AbsData += rTargetAbs.Time;

                                    //不是最後一筆就斷行
                                    if (rsSourceAbs.Last() != rSourceAbs)
                                        rTarget.AbsData += "<br>";
                                }

                                //加班資料組合
                                rTarget.ListOt = new List<OtRow>();
                                var rsSourceOt = rSource.listOt;
                                foreach (var rSourceOt in rsSourceOt)
                                {
                                    var rTargetOt = new OtRow();
                                    rTargetOt.Name = rSourceOt.overTimeHours > 0 ? "加班費" : "補休假";
                                    rTargetOt.TimeB = rSourceOt.beginTime;
                                    rTargetOt.TimeE = rSourceOt.endTime;
                                    rTargetOt.Time = rTargetOt.TimeB + "-" + rTargetOt.TimeE;
                                    rTargetOt.OtHour = rSourceOt.overTimeHours;
                                    rTargetOt.RestHour = rSourceOt.restTimeHours;
                                    rTargetOt.TotalHour = rTargetOt.OtHour + rTargetOt.RestHour;
                                    rTarget.ListOt.Add(rTargetOt);

                                    //組合數列資料
                                    rTarget.OtData += rTargetOt.Time;

                                    //不是最後一筆就斷行
                                    if (rsSourceOt.Last() != rSourceOt)
                                        rTarget.OtData += "<br>";
                                }

                                //註記資料組合
                                rTarget.ListAbnormal = new List<AbnormalRow>();
                                var rsSourceAbnormal = rSource.listAbnormal;
                                foreach (var rSourceAbnormal in rsSourceAbnormal)
                                {
                                    var rTargetAbnormal = new AbnormalRow();
                                    rTargetAbnormal.Name = rSourceAbnormal.name;
                                    rTargetAbnormal.Type = rSourceAbnormal.type;
                                    rTargetAbnormal.Mins = rSourceAbnormal.mins;
                                    rTargetAbnormal.Check = rSourceAbnormal.check;
                                    rTarget.ListAbnormal.Add(rTargetAbnormal);

                                    //組合數列資料
                                    rTarget.AbnormalData += rTargetAbnormal.Name + rTargetAbnormal.Mins + "分鐘";

                                    //不是最後一筆就斷行
                                    if (rsSourceAbnormal.Last() != rSourceAbnormal)
                                        rTarget.AbnormalData += "<br>";
                                }

                                rsTarget.Add(rTarget);
                            }

                            //把api的Data轉成我們的Data
                            Vdb.Data = rsTarget;
                        }
                    }
                }
            }

            return Vdb;
        }

        public APIResult GetData(AttendDetailConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond , cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        var oSource = Vdb.Data as AttendDetailApiRow;

                        if (oSource != null)
                        {
                            Vdb.Status = oSource.state;
                            Vdb.Message = oSource.message;
                            Vdb.StackTrace = oSource.stackTrace;

                            if (oSource.state)
                            {
                                var rsSource = oSource.result;
                                var rsTarget = new List<AttendDetailRow>();

                                foreach (var rSource in rsSource)
                                {
                                    var rTarget = new AttendDetailRow();
                                    rTarget.EmpId = rSource.employeeId;
                                    rTarget.EmpName = rSource.employeeName;
                                    rTarget.DateA = rSource.attendDate;
                                    rTarget.RoteDisplayName = rSource.roteCodeDisp;
                                    rTarget.RoteCode = rSource.roteCode;
                                    rTarget.RoteName = rSource.roteName;
                                    rTarget.RoteTimeB = rSource.roteTimeB;
                                    rTarget.RoteTimeE = rSource.roteTimeE;
                                    rTarget.RoteTime = rTarget.RoteTimeB + "-" + rTarget.RoteTimeE;
                                    rTarget.AttcardTimeB = rSource.cardTimeB;
                                    rTarget.AttcardTimeE = rSource.cardTimeE;
                                    rTarget.AttcardTime = rTarget.AttcardTimeB + "-" + rTarget.AttcardTimeE;
                                    rTarget.LateMins = Convert.ToInt32(rSource.lateMin);
                                    rTarget.EarlyMins = Convert.ToInt32(rSource.earlyMin);
                                    rTarget.IsAbs = rSource.isAbs ? "是" : "否";
                                    rTarget.Forget = Convert.ToInt32(rSource.forget);

                                    //請假資料組合
                                    rTarget.ListAbs = new List<AbsRow>();
                                    var rsSourceAbs = rSource.listAbs;
                                    foreach (var rSourceAbs in rsSourceAbs)
                                    {
                                        var rTargetAbs = new AbsRow();
                                        rTargetAbs.Name = rSourceAbs.holidayName;
                                        rTargetAbs.TimeB = rSourceAbs.beginTime;
                                        rTargetAbs.TimeE = rSourceAbs.endTime;
                                        rTargetAbs.Time = rTargetAbs.TimeB + "-" + rTargetAbs.TimeE;
                                        rTargetAbs.Hcode = rSourceAbs.holidayCode;
                                        rTargetAbs.HcodeName = rSourceAbs.holidayName;
                                        rTargetAbs.HcodeUnitName = rSourceAbs.absenceUnit;
                                        rTargetAbs.Use = rSourceAbs.absenceAmount;
                                        rTarget.ListAbs.Add(rTargetAbs);

                                        //組合數列資料
                                        rTarget.AbsData += rTargetAbs.HcodeName + rTargetAbs.Time;

                                        //不是最後一筆就斷行
                                        if (rsSourceAbs.Last() != rSourceAbs)
                                            rTarget.AbsData += "<br>";
                                    }

                                    //加班資料組合
                                    rTarget.ListOt = new List<OtRow>();
                                    var rsSourceOt = rSource.listOt;
                                    foreach (var rSourceOt in rsSourceOt)
                                    {
                                        var rTargetOt = new OtRow();
                                        rTargetOt.Name = rSourceOt.overTimeHours > 0 ? "加班費" : "補休假";
                                        rTargetOt.TimeB = rSourceOt.beginTime;
                                        rTargetOt.TimeE = rSourceOt.endTime;
                                        rTargetOt.Time = rTargetOt.TimeB + "-" + rTargetOt.TimeE;
                                        rTargetOt.OtHour = rSourceOt.overTimeHours;
                                        rTargetOt.RestHour = rSourceOt.restTimeHours;
                                        rTargetOt.TotalHour = rTargetOt.OtHour + rTargetOt.RestHour;
                                        rTarget.ListOt.Add(rTargetOt);

                                        //組合數列資料
                                        rTarget.OtData += rTargetOt.Time + "(" + rSourceOt.overTimeTotalHours + ")";

                                        //不是最後一筆就斷行
                                        if (rsSourceOt.Last() != rSourceOt)
                                            rTarget.OtData += "<br>";
                                    }

                                    //註記資料組合
                                    rTarget.ListAbnormal = new List<AbnormalRow>();
                                    var rsSourceAbnormal = rSource.listAbnormal;
                                    foreach (var rSourceAbnormal in rsSourceAbnormal)
                                    {
                                        var rTargetAbnormal = new AbnormalRow();
                                        rTargetAbnormal.Name = rSourceAbnormal.name;
                                        rTargetAbnormal.Type = rSourceAbnormal.type;
                                        rTargetAbnormal.Mins = rSourceAbnormal.mins;
                                        rTargetAbnormal.Check = rSourceAbnormal.check;
                                        rTarget.ListAbnormal.Add(rTargetAbnormal);

                                        //組合數列資料
                                        rTarget.AbnormalData += rTargetAbnormal.Name + rTargetAbnormal.Mins + "分鐘" + (rTargetAbnormal.Check ? "(已註記)" : "(未註記)");

                                        //不是最後一筆就斷行
                                        if (rsSourceAbnormal.Last() != rSourceAbnormal)
                                            rTarget.AbnormalData += "<br>";
                                    }

                                    rsTarget.Add(rTarget);
                                }

                                //把api的Data轉成我們的Data
                                Vdb.Data = rsTarget;
                            }
                        }
                    }
                }
            }

            return Vdb;
        }

    }
}