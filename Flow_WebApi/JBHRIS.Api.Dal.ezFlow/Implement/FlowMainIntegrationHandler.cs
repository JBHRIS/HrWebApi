using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using JBHRIS.Api.Tools;
using JBHRIS.Api.Tools.Tool;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class FlowMainIntegrationHandler : IFlowMainIntegrationHandler_Interface
    {
        private ezFlowContext _context;


        

        public FlowMainIntegrationHandler(ezFlowContext ezFlowContext)
        {
            this._context = ezFlowContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NodeFinish"></param>
        /// <returns></returns>
        public ActionResultRow FlowNodeFinish(NodeFinishRow NodeFinish)
        {
            throw new NotImplementedException();
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="State"></param>
        /// <param name="DynamicEmpID"></param>
        /// <param name="DynamicRoleID"></param>
        /// <param name="SignEmpID"></param>
        /// <param name="SignRoleID"></param>
        /// <returns></returns>
        public bool FlowNodeFinishByFlowID(int idProcess, string State = "", string DynamicEmpID = "", string DynamicRoleID = "", string SignEmpID = "", string SignRoleID = "")
        {
            //FlowMainHandlerBll_StandardFoods oFlowMainHandler = new FlowMainHandlerBll_StandardFoods();

            bool result = false;

            try
            {
                var SignRole = (from role in _context.Roles
                                join emp in _context.Emps on role.Emp_id equals emp.id
                                join dept in _context.Depts on role.Dept_id equals dept.id
                                join pos in _context.Pos on role.Pos_id equals pos.id
                                where role.id == SignRoleID && role.Emp_id == SignEmpID
                                select new
                                {
                                    RoleID = role.id,
                                    RoleEmp = role.id + emp.id,
                                    Auth = role.deptMg.GetValueOrDefault(false),
                                    //ChiefCode = role.ChiefCode,
                                    DeptID = role.Dept_id,
                                    DeptName = dept.name,
                                    DeptPath = dept.path,
                                    Email = emp.email,
                                    EmpID = emp.id,
                                    EmpName = emp.name,
                                    MainMan = role.sort == 1,
                                    PosID = pos.id,
                                    PosName = pos.name
                                }).FirstOrDefault();


                if (SignRole == null)
                {
                    return false;
                }

                var NodeFinishSQL = from pc in _context.ProcessChecks
                                    join pn in _context.ProcessNodes on pc.ProcessNode_auto equals pn.auto
                                    join fn in _context.FlowNodes on pn.FlowNode_id equals fn.id
                                    join pf in _context.ProcessFlows on pn.ProcessFlow_id equals pf.id
                                    join ft in _context.FlowTrees on pf.FlowTree_id equals ft.id
                                    join pa in _context.ProcessApParms
                                    on new { ProcessCheck_auto = pc.auto, ProcessNode_auto = pn.auto, ProcessFlow_id = pf.id }
                                    equals new { ProcessCheck_auto = pa.ProcessCheck_auto.Value, ProcessNode_auto = pa.ProcessNode_auto.Value, ProcessFlow_id = pa.ProcessFlow_id.Value }

                                    join app in _context.wfFormApps on pf.id equals app.idProcess
                                    join form in _context.wfForms on ft.id equals form.sFlowTree
                                    where (pn.isFinish == false) && pf.id == idProcess
                                    orderby pc.auto
                                    select new NodeFinishRow
                                    {
                                        FlowNodeID = pn.FlowNode_id,
                                        FlowTreeID = ft.id,
                                        NodeName = fn.name,
                                        Note = "",
                                        ProcessApParmAuto = pa.auto,
                                        State = string.IsNullOrEmpty(State) ? app.sState : State,
                                        ProcessFlowID = pf.id,
                                        FlowDynamic = new FlowDynamicRow
                                        {
                                            EmpID = DynamicEmpID,
                                            RoleID = DynamicRoleID,
                                            FlowNode = pn.FlowNode_id,
                                        },
                                        ManInfo = new ManInfoRow
                                        {
                                            RoleID = SignRole.RoleID,
                                            RoleEmp = SignRole.RoleEmp,
                                            Auth = SignRole.Auth,
                                            //ChiefCode = SignRole.ChiefCode,
                                            DeptID = SignRole.DeptID,
                                            DeptName = SignRole.DeptName,
                                            DeptPath = SignRole.DeptPath,
                                            Email = SignRole.Email,
                                            EmpID = SignRole.EmpID,
                                            EmpName = SignRole.EmpName,
                                            MainMan = SignRole.MainMan,
                                            PosID = SignRole.PosID,
                                            PosName = SignRole.PosName
                                        }
                                    };

                var NodeFinish = NodeFinishSQL.FirstOrDefault();

                if (NodeFinish == null)
                {
                    return false;
                }


                result = true;// oFlowMainHandler.FlowNodeFinish(NodeFinish);

                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="SignEmpID"></param>
        /// <param name="SignRoleID"></param>
        /// <param name="RealSignEmpID"></param>
        /// <param name="RealSignRoleID"></param>
        /// <param name="SignDate"></param>
        /// <returns></returns>
        public List<FlowSignAbsRow> GetFlowSignAbs(string SignEmpID, string SignRoleID, string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "")
        {
            var FlowTreeID = "15";
            var rsFlowSignRole = GetFlowSignRoleFullDataByNow(SignEmpID, new List<string> { FlowTreeID }, SignRoleID, RealSignEmpID, RealSignRoleID, SignDate);
            if (rsFlowSignRole.Count == 0)
                return null;

            //var rFlowSignRole = rsFlowSignRole.FirstOrDefault(p => (p.RoleID == RealSignRoleID || RealSignRoleID.Length == 0)
            //&& p.EmpID == RealSignEmpID);
            var rFlowSignRole = rsFlowSignRole.FirstOrDefault();
            if (rFlowSignRole == null)
                return null;

            //var rFlowSignForm = rFlowSignRole.FlowSignForm.FirstOrDefault(p => p.FlowTreeID == FlowTreeID);
            var rFlowSignForm = rFlowSignRole.FlowSignForm.FirstOrDefault();
            if (rFlowSignForm == null)
                return null;

            var rsFlowSign = rFlowSignForm.FlowSign;

            var ListProcessFlowID = rsFlowSign.Select(p => p.ProcessFlowID).ToList();

            var rsAbs = (from a in _context.wfAppAbs
                         where ListProcessFlowID.Contains(a.idProcess)
                         select new
                         {
                             ProcessFlowID = a.idProcess,
                             EmpCode = a.sNobr,
                             EmpNameC = a.sName,
                             EmpNameE = "",
                             HoliDayID = a.sHcode,
                             HolidayName = a.sHname,
                             DateB = a.dDateB,
                             DateE = a.dDateE,
                             TimeB = a.sTimeB,
                             TimeE = a.sTimeE,
                             //Use = a.iUse.GetValueOrDefault(0),
                             Use = a.iUse,
                             BaseHours = 8m
                             // Appointment = a.bAppointment,
                         }).ToList();

            //AttHandlerBll_StandardFoods oAttHandler = new AttHandlerBll_StandardFoods();
            //MultiHandlerBll_StandardFoods oMultiHandler = new MultiHandlerBll_StandardFoods();

            AbsCalculate absCalculate = new AbsCalculate();
            

            //取得假別代碼
            //var rsHoliDay = oAttHandler.GetHoliDay(null);

            List<FlowSignAbsRow> Vdb = new List<FlowSignAbsRow>();

            foreach (var rAbs in rsAbs)
            {
                //重複的流程資料不要寫入
                if (!Vdb.Any(p => p.ProcessFlowID == rAbs.ProcessFlowID))
                {
                    //可能一張單有多筆假單
                    var rsAbsTemp = rsAbs.Where(p => p.ProcessFlowID == rAbs.ProcessFlowID).ToList();

                    //計算天 時 分
                    decimal TotalDay = 0, TotalHour = 0, TotalMinute = 0;
                    List<string> ListHolidayName = new List<string>();
                    foreach (var rAbsTemp in rsAbsTemp)
                    {
                        //var rHoliDay = rsHoliDay.FirstOrDefault(p => p.HoliDayID == rAbsTemp.HoliDayID);

                        var DayWorkHours = rAbsTemp.BaseHours;

                        //特殊假種基底時數等於24小時
                        //if (oMultiHandler.HoliDayCodeForBaseHour24.Contains(rHoliDay.HoliDayCode))
                            //DayWorkHours = 24m;

                        //轉換成分鐘數
                        var DayWorkMinutes = Convert.ToInt32(DayWorkHours * 60);

                        //DayHourMinuteRow UseDayHourMinute = absCalculate.ConvertTimeUse(rAbsTemp.Use, Convert.ToInt32(rHoliDay.HoliDayUnit), DayWorkHours, DayWorkMinutes);
                        DayHourMinuteRow UseDayHourMinute = absCalculate.ConvertTimeUse(rAbsTemp.Use, 1, DayWorkHours, DayWorkMinutes);

                        TotalDay += UseDayHourMinute.Day;
                        TotalHour += UseDayHourMinute.Hour;
                        TotalMinute += UseDayHourMinute.Minute;

                        if (!ListHolidayName.Contains(rAbsTemp.HolidayName))
                            ListHolidayName.Add(rAbsTemp.HolidayName);
                    }

                    var rFlowSign = rsFlowSign.FirstOrDefault(p => p.ProcessFlowID == rAbs.ProcessFlowID);

                    if (rFlowSign == null)
                    {
                        continue;
                    }

                    FlowSignAbsRow rVdb = new FlowSignAbsRow();
                    rVdb.ProcessFlowID = rAbs.ProcessFlowID;
                    rVdb.FlowTreeID = rFlowSign.FlowTreeID;
                    rVdb.FlowNodeID = rFlowSign.FlowNodeID;
                    rVdb.ProcessApParmAuto = rFlowSign.ProcessApParmAuto;
                    rVdb.EmpCode = rAbs.EmpCode;
                    rVdb.EmpNameC = rAbs.EmpNameC ?? "";
                    rVdb.EmpNameE = rAbs.EmpNameE ?? "";
                    rVdb.HolidayName = ListHolidayName;
                    rVdb.isApproved = rFlowSign.SignCondition.SignComplete;
                    rVdb.isSendback = rFlowSign.SignCondition.Reject;
                    rVdb.isPutForward = rFlowSign.SignCondition.Sign;
                    rVdb.WriteEmpCode = rFlowSign.AppEmpID;
                    rVdb.WriteEmpNameC = rFlowSign.AppEmpName ?? "";
                    rVdb.DateB = rsAbsTemp.Min(p => p.DateB);
                    rVdb.DateE = rsAbsTemp.Max(p => p.DateE);
                    rVdb.TimeB = rsAbsTemp.OrderBy(p => p.DateB).First().TimeB;
                    rVdb.TimeE = rsAbsTemp.OrderByDescending(p => p.DateE).First().TimeE;
                    rVdb.day = TotalDay;
                    rVdb.hour = TotalHour;
                    rVdb.minute = TotalMinute;
                    //rVdb.numberOfVaData = rsAbsTemp.Count;
                    rVdb.checkProxy = rVdb.EmpCode != rVdb.WriteEmpCode;
                    //rVdb.Appointment = rAbs.Appointment;

                    Vdb.Add(rVdb);
                }
            }

            return Vdb;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="signEmpID"></param>
        /// <param name="signRoleID"></param>
        /// <param name="realSignEmpID"></param>
        /// <param name="realSignRoleID"></param>
        /// <param name="signDate"></param>
        /// <returns></returns>
        public List<FlowSignAbsRow> GetFlowSignAbs1(string signEmpID, string signRoleID, string realSignEmpID, string realSignRoleID, string signDate)
        {
            var FlowTreeID = "62";
            var rsFlowSignRole = GetFlowSignRoleFullDataByNow(signEmpID, new List<string> { FlowTreeID }, signRoleID, realSignEmpID, realSignRoleID, signDate);
            if (rsFlowSignRole.Count == 0)
                return null;

            //var rFlowSignRole = rsFlowSignRole.FirstOrDefault(p => (p.RoleID == RealSignRoleID || RealSignRoleID.Length == 0)
            //&& p.EmpID == RealSignEmpID);
            var rFlowSignRole = rsFlowSignRole.FirstOrDefault();
            if (rFlowSignRole == null)
                return null;

            //var rFlowSignForm = rFlowSignRole.FlowSignForm.FirstOrDefault(p => p.FlowTreeID == FlowTreeID);
            var rFlowSignForm = rFlowSignRole.FlowSignForm.FirstOrDefault();
            if (rFlowSignForm == null)
                return null;

            var rsFlowSign = rFlowSignForm.FlowSign;

            var ListProcessFlowID = rsFlowSign.Select(p => p.ProcessFlowID).ToList();

            var rsAbs = (from a in _context.wfAppAbs
                         where ListProcessFlowID.Contains(a.idProcess)
                         select new
                         {
                             ProcessFlowID = a.idProcess,
                             EmpCode = a.sNobr,
                             EmpNameC = a.sName,
                             EmpNameE = "",
                             HoliDayID = a.sHcode,
                             HolidayName = a.sHname,
                             DateB = a.dDateB,
                             DateE = a.dDateE,
                             TimeB = a.sTimeB,
                             TimeE = a.sTimeE,
                             //Use = a.iUse.GetValueOrDefault(0),
                             Use = a.iUse,
                             BaseHours = 8m
                             // Appointment = a.bAppointment,
                         }).ToList();

            //AttHandlerBll_StandardFoods oAttHandler = new AttHandlerBll_StandardFoods();
            //MultiHandlerBll_StandardFoods oMultiHandler = new MultiHandlerBll_StandardFoods();
            //AbsBll oAbsBll = new AbsBll();

            AbsCalculate absCalculate = new AbsCalculate();

            //取得假別代碼
            //var rsHoliDay = oAttHandler.GetHoliDay(null);

            List<FlowSignAbsRow> Vdb = new List<FlowSignAbsRow>();

            foreach (var rAbs in rsAbs)
            {
                //重複的流程資料不要寫入
                if (!Vdb.Any(p => p.ProcessFlowID == rAbs.ProcessFlowID))
                {
                    //可能一張單有多筆假單
                    var rsAbsTemp = rsAbs.Where(p => p.ProcessFlowID == rAbs.ProcessFlowID).ToList();

                    //計算天 時 分
                    decimal TotalDay = 0, TotalHour = 0, TotalMinute = 0;
                    List<string> ListHolidayName = new List<string>();
                    foreach (var rAbsTemp in rsAbsTemp)
                    {
                        //var rHoliDay = rsHoliDay.FirstOrDefault(p => p.HoliDayID == rAbsTemp.HoliDayID);

                        var DayWorkHours = rAbsTemp.BaseHours;

                        //特殊假種基底時數等於24小時
                        //if (oMultiHandler.HoliDayCodeForBaseHour24.Contains(rHoliDay.HoliDayCode))
                            //DayWorkHours = 24m;

                        //轉換成分鐘數
                        var DayWorkMinutes = Convert.ToInt32(DayWorkHours * 60);

                        //DayHourMinuteRow UseDayHourMinute = oAbsBll.ConvertTimeUse(rAbsTemp.Use, Convert.ToInt32(rHoliDay.HoliDayUnit), DayWorkHours, DayWorkMinutes);
                        DayHourMinuteRow UseDayHourMinute = absCalculate.ConvertTimeUse(rAbsTemp.Use, 1, DayWorkHours, DayWorkMinutes);

                        TotalDay += UseDayHourMinute.Day;
                        TotalHour += UseDayHourMinute.Hour;
                        TotalMinute += UseDayHourMinute.Minute;

                        if (!ListHolidayName.Contains(rAbsTemp.HolidayName))
                            ListHolidayName.Add(rAbsTemp.HolidayName);
                    }

                    var rFlowSign = rsFlowSign.FirstOrDefault(p => p.ProcessFlowID == rAbs.ProcessFlowID);

                    if (rFlowSign == null)
                    {
                        continue;
                    }

                    FlowSignAbsRow rVdb = new FlowSignAbsRow();
                    rVdb.ProcessFlowID = rAbs.ProcessFlowID;
                    rVdb.FlowTreeID = rFlowSign.FlowTreeID;
                    rVdb.FlowNodeID = rFlowSign.FlowNodeID;
                    rVdb.ProcessApParmAuto = rFlowSign.ProcessApParmAuto;
                    rVdb.EmpCode = rAbs.EmpCode;
                    rVdb.EmpNameC = rAbs.EmpNameC ?? "";
                    rVdb.EmpNameE = rAbs.EmpNameE ?? "";
                    rVdb.HolidayName = ListHolidayName;
                    rVdb.isApproved = rFlowSign.SignCondition.SignComplete;
                    rVdb.isSendback = rFlowSign.SignCondition.Reject;
                    rVdb.isPutForward = rFlowSign.SignCondition.Sign;
                    rVdb.WriteEmpCode = rFlowSign.AppEmpID;
                    rVdb.WriteEmpNameC = rFlowSign.AppEmpName ?? "";
                    rVdb.DateB = rsAbsTemp.Min(p => p.DateB);
                    rVdb.DateE = rsAbsTemp.Max(p => p.DateE);
                    rVdb.TimeB = rsAbsTemp.OrderBy(p => p.DateB).First().TimeB;
                    rVdb.TimeE = rsAbsTemp.OrderByDescending(p => p.DateE).First().TimeE;
                    rVdb.day = TotalDay;
                    rVdb.hour = TotalHour;
                    rVdb.minute = TotalMinute;
                    //rVdb.numberOfVaData = rsAbsTemp.Count;
                    rVdb.checkProxy = rVdb.EmpCode != rVdb.WriteEmpCode;
                    //rVdb.Appointment = rAbs.Appointment;

                    Vdb.Add(rVdb);
                }
            }

            return Vdb;
        }

        public List<FlowSignAbscRow> GetFlowSignAbsc(string SignEmpID, string SignRoleID, string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "")
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// TODO :
        /// </summary>
        /// <param name="RealSignEmpID"></param>
        /// <param name="RealSignRoleID"></param>
        /// <param name="SignDate"></param>
        /// <returns></returns>
        public List<FlowSignAttendUnusualRow> GetFlowSignAttendUnusual(string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "")
        {
            return new List<FlowSignAttendUnusualRow>();
        }

        public List<FlowSignCardRow> GetFlowSignCard(string SignEmpID, string SignRoleID, string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "")
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 取得目前待審核的表單-補卡單
        /// TODO :
        /// </summary>
        /// <param name="SignEmpID">審核者工號</param>
        /// <param name="SignRoleID">審核者角色</param>
        /// <param name="RealSignEmpID">代理審核者工號</param>
        /// <param name="RealSignRoleID">代理審核者角色</param>
        /// <param name="SignDate">審核日期</param>
        /// <returns>List FlowSignCardRow</returns>
        public List<FlowSignCardRow> GetFlowSignCardPatch(string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "")
        {
            return new List<FlowSignCardRow>();
        }


        /// <summary>
        /// 取得目前待審核的表單-加班單
        /// </summary>
        /// <param name="SignEmpID"></param>
        /// <param name="SignRoleID"></param>
        /// <param name="RealSignEmpID"></param>
        /// <param name="RealSignRoleID"></param>
        /// <param name="SignDate"></param>
        /// <param name="PageCurrent"></param>
        /// <param name="PageRows"></param>
        /// <returns></returns>
        public FlowSignOTDetail GetFlowSignOT(string SignEmpID, string SignRoleID, string RealSignEmpID, string RealSignRoleID, string SignDate, int PageCurrent, int PageRows)
        {
            int BaseHour = 8;

            //加班單
            var OTFlowTreeID = "16";
            //預估加班單
            //var OT1FlowTreeID = "73";
            List<FlowSignRoleRow> rsFlowSignRole = GetFlowSignRoleFullDataByNow(SignEmpID, new List<string> { OTFlowTreeID }, SignRoleID, RealSignEmpID, RealSignRoleID, SignDate);
            if (rsFlowSignRole.Count == 0)
                return null;

            var rFlowSignRole = rsFlowSignRole.FirstOrDefault(p => (p.maninfo.RoleID == RealSignRoleID || RealSignRoleID.Length == 0) && p.maninfo.EmpID == RealSignEmpID);
            rFlowSignRole = rsFlowSignRole.FirstOrDefault();
            if (rFlowSignRole == null)
                return null;

            var rFlowSignForm = rFlowSignRole.FlowSignForm.FirstOrDefault();
            if (rFlowSignForm == null)
                return null;

            var rsFlowSign = rFlowSignForm.FlowSign;

            /**/
            var ListProcessFlowID = rsFlowSign.Select(p => p.ProcessFlowID).Distinct().ToList();

            var rsOT = (from a in _context.wfAppOts
                        where ListProcessFlowID.Contains(a.idProcess)
                        select new
                        {

                            ProcessFlowID = a.idProcess,
                            EmpCode = a.sNobr,
                            EmpNameC = a.sName,
                            EmpNameE = "",
                            //HoliDayID = a.sHcode,
                            //HolidayName = a.sHname,
                            DateTimeB = a.dDateTimeB,
                            DateTimeE = a.dDateTimeE,
                            TimeB = a.sTimeB,
                            TimeE = a.sTimeE,
                            TotalHour = a.iTotalHour, //   1 :加班總時數
                            OtcatCode = a.sOtcatCode,  //  1: 加班費 , 2:補休日
                            OtcatName = a.sOtcatName,
                            FormCode = a.sFormCode,
                            //BaseHours = 8m
                        }).ToList();

            AbsCalculate absCalculate = new AbsCalculate();

            List<FlowSignOTRow> Vdb = new List<FlowSignOTRow>();

            foreach (var rAbs in rsOT)
            {
                //重複的流程資料不要寫入
                if (!Vdb.Any(p => p.ProcessFlowID == rAbs.ProcessFlowID))
                {
                    var rFlowSign = rsFlowSign.FirstOrDefault(p => p.ProcessFlowID == rAbs.ProcessFlowID);
                    if (rFlowSign == null)
                        continue;

                    var OtDataList = rsOT.Where(x => x.ProcessFlowID == rAbs.ProcessFlowID).OrderBy(x => x.DateTimeB).ThenBy(x => x.TimeB).ToList();

                    if (OtDataList.Count == 0)
                        continue;

                    FlowSignOTRow rVdb = new FlowSignOTRow();

                    rVdb.ProcessFlowID = rAbs.ProcessFlowID;
                    rVdb.EmpCode = rAbs.EmpCode;
                    rVdb.EmpNameC = rAbs.EmpNameC;
                    rVdb.FlowTreeID = rFlowSign.FlowTreeID;
                    rVdb.FlowNodeID = rFlowSign.FlowNodeID;
                    rVdb.ProcessApParmAuto = rFlowSign.ProcessApParmAuto;
                    rVdb.FormCode = rAbs.FormCode;
                    rVdb.isApproved = rFlowSign.SignCondition.SignComplete;//核准
                    rVdb.isSendback = rFlowSign.SignCondition.Reject;  //退回
                    rVdb.isPutForward = rFlowSign.SignCondition.Sign;
                    rVdb.WriteEmpCode = rFlowSign.AppEmpID;
                    rVdb.WriteEmpNameC = rFlowSign.AppEmpName ?? "";

                    var UseDayHourMinute = absCalculate.ConvertTimeUse(OtDataList.Sum(x => x.TotalHour), 1, BaseHour, BaseHour * 60);//oAbsBll.ConvertTimeUse(rAbs.TotalHour, 1, BaseHour, BaseHour * 60);

                    rVdb.DateTimeB = OtDataList.First().DateTimeB;
                    rVdb.DateTimeE = OtDataList.Last().DateTimeE;
                    rVdb.TimeB = OtDataList.First().TimeB;
                    rVdb.TimeE = OtDataList.Last().TimeE;
                    DayHourMinuteRow dayHourMinuteRow = new DayHourMinuteRow();
                    dayHourMinuteRow.Day = UseDayHourMinute.Day;
                    dayHourMinuteRow.Hour = UseDayHourMinute.Hour;
                    dayHourMinuteRow.Minute = UseDayHourMinute.Minute;

                    rVdb.UseDayHourMinute = dayHourMinuteRow;
                    rVdb.OtcatCode = rAbs.OtcatCode;  // 加班換  1:  加班費 , 2: 補休日
                    rVdb.OtcatName = rAbs.OtcatName;  // 加班換   加班費 , 補休日
                    Vdb.Add(rVdb);
                }
            }

            FlowSignOTDetail flowSignOTDetail = new FlowSignOTDetail();
            PageCategory pageCategory = new PageCategory();
            pageCategory.PageTotalCount = (Vdb.Count() + PageRows - 1) / PageRows;
            pageCategory.pageCurrent = PageCurrent;
            pageCategory.PageRows = PageRows;
            flowSignOTDetail.Page = pageCategory;
            flowSignOTDetail.FlowSignOTRow = Vdb.Skip((PageCurrent - 1) * PageRows).Take(PageRows).ToList();

            return flowSignOTDetail;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SignEmpID"></param>
        /// <param name="SignRoleID"></param>
        /// <param name="RealSignEmpID"></param>
        /// <param name="RealSignRoleID"></param>
        /// <param name="SignDate"></param>
        /// <param name="PageCurrent"></param>
        /// <param name="PageRows"></param>
        /// <returns></returns>
        public FlowSignOTDetail GetFlowSignOT1(string SignEmpID, string SignRoleID, string RealSignEmpID, string RealSignRoleID, string SignDate, int PageCurrent, int PageRows)
        {
            int BaseHour = 8;
            //預估加班單
            var OT1FlowTreeID = "73";
            List<FlowSignRoleRow> rsFlowSignRole = GetFlowSignRoleFullDataByNow(SignEmpID, new List<string> { OT1FlowTreeID }, SignRoleID, RealSignEmpID, RealSignRoleID, SignDate);
            if (rsFlowSignRole.Count == 0)
                return null;

            var rFlowSignRole = rsFlowSignRole.FirstOrDefault(p => (p.maninfo.RoleID == RealSignRoleID || RealSignRoleID.Length == 0) && p.maninfo.EmpID == RealSignEmpID);
            rFlowSignRole = rsFlowSignRole.FirstOrDefault();
            if (rFlowSignRole == null)
                return null;

            var rFlowSignForm = rFlowSignRole.FlowSignForm.FirstOrDefault();
            if (rFlowSignForm == null)
                return null;

            var rsFlowSign = rFlowSignForm.FlowSign;

            /**/
            var ListProcessFlowID = rsFlowSign.Select(p => p.ProcessFlowID).Distinct().ToList();

            var rsOT = (from a in _context.wfAppOts
                        where ListProcessFlowID.Contains(a.idProcess)
                        select new
                        {

                            ProcessFlowID = a.idProcess,
                            EmpCode = a.sNobr,
                            EmpNameC = a.sName,
                            EmpNameE = "",
                            //HoliDayID = a.sHcode,
                            //HolidayName = a.sHname,
                            DateTimeB = a.dDateTimeB,
                            DateTimeE = a.dDateTimeE,
                            TimeB = a.sTimeB,
                            TimeE = a.sTimeE,
                            TotalHour = a.iTotalHour, //   1 :加班總時數
                            OtcatCode = a.sOtcatCode,  //  1: 加班費 , 2:補休日
                            OtcatName = a.sOtcatName,
                            FormCode = a.sFormCode,
                            //BaseHours = 8m
                        }).ToList();

            AbsCalculate absCalculate = new AbsCalculate();
            List<FlowSignOTRow> Vdb = new List<FlowSignOTRow>();

            foreach (var rAbs in rsOT)
            {
                //重複的流程資料不要寫入
                if (!Vdb.Any(p => p.ProcessFlowID == rAbs.ProcessFlowID))
                {
                    var rFlowSign = rsFlowSign.FirstOrDefault(p => p.ProcessFlowID == rAbs.ProcessFlowID);
                    if (rFlowSign == null)
                        continue;

                    FlowSignOTRow rVdb = new FlowSignOTRow();

                    rVdb.ProcessFlowID = rAbs.ProcessFlowID;
                    rVdb.EmpCode = rAbs.EmpCode;
                    rVdb.EmpNameC = rAbs.EmpNameC;
                    rVdb.FlowTreeID = rFlowSign.FlowTreeID;
                    rVdb.FlowNodeID = rFlowSign.FlowNodeID;
                    rVdb.ProcessApParmAuto = rFlowSign.ProcessApParmAuto;
                    rVdb.FormCode = rAbs.FormCode;
                    rVdb.isApproved = rFlowSign.SignCondition.SignComplete;//核准
                    rVdb.isSendback = rFlowSign.SignCondition.Reject;  //退回
                    rVdb.isPutForward = rFlowSign.SignCondition.Sign;
                    rVdb.WriteEmpCode = rFlowSign.AppEmpID;
                    rVdb.WriteEmpNameC = rFlowSign.AppEmpName ?? "";

                    var UseDayHourMinute = absCalculate.ConvertTimeUse(rAbs.TotalHour, 3, BaseHour, BaseHour * 60);//oAbsBll.ConvertTimeUse(rAbs.TotalHour, 1, BaseHour, BaseHour * 60);

                    rVdb.DateTimeB = rAbs.DateTimeB;
                    rVdb.DateTimeE = rAbs.DateTimeE;
                    rVdb.TimeB = rAbs.TimeB;
                    rVdb.TimeE = rAbs.TimeE;
                    DayHourMinuteRow dayHourMinuteRow = new DayHourMinuteRow();
                    dayHourMinuteRow.Day = UseDayHourMinute.Day;
                    dayHourMinuteRow.Hour = UseDayHourMinute.Hour;
                    dayHourMinuteRow.Minute = UseDayHourMinute.Minute;

                    rVdb.UseDayHourMinute = dayHourMinuteRow;
                    rVdb.OtcatCode = rAbs.OtcatCode;  // 加班換  1:  加班費 , 2: 補休日
                    rVdb.OtcatName = rAbs.OtcatName;  // 加班換   加班費 , 補休日
                    Vdb.Add(rVdb);
                }
            }

            FlowSignOTDetail flowSignOTDetail = new FlowSignOTDetail();
            PageCategory pageCategory = new PageCategory();
            pageCategory.PageTotalCount = (Vdb.Count() + PageRows - 1) / PageRows;
            pageCategory.pageCurrent = PageCurrent;
            pageCategory.PageRows = PageRows;
            flowSignOTDetail.Page = pageCategory;
            flowSignOTDetail.FlowSignOTRow = Vdb.Skip((PageCurrent - 1) * PageRows).Take(PageRows).ToList();

            return flowSignOTDetail;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SignEmpID"></param>
        /// <param name="SignRoleID"></param>
        /// <param name="RealSignEmpID"></param>
        /// <param name="RealSignRoleID"></param>
        /// <param name="FlowTreeID"></param>
        /// <param name="SignDate"></param>
        /// <returns></returns>
        public List<FlowSignRoleRow> GetFlowSignRole(string SignEmpID, string SignRoleID = "", string RealSignEmpID = "", string RealSignRoleID = "", string FlowTreeID = "", string SignDate = "")
        {
            DateTime SignDate1 = SignDate.Length == 0 ? DateTime.Now.Date : Convert.ToDateTime(SignDate).Date;

            //寫死 只列出 5張表單 by ming
            var ListFlowTreeID = new List<string>();
            ListFlowTreeID.Add("15");
            ListFlowTreeID.Add("16");
            ListFlowTreeID.Add("60");
            ListFlowTreeID.Add("62");
            ListFlowTreeID.Add("17");
            ListFlowTreeID.Add("81");

            var rs = (from ca in _context.CheckAgentDates
                      from ft in _context.FlowTrees
                      join w in _context.wfForms on ft.id equals w.sFlowTree
                      join r in _context.Roles on ca.Emp_idSource equals r.Emp_id
                      join d in _context.Depts on r.Dept_id equals d.id
                      join p in _context.Pos on r.Pos_id equals p.id
                      join e in _context.Emps on r.Emp_id equals e.id
                      where SignDate1 >= r.dateB && SignDate1 <= r.dateE
                      && ca.Emp_idTarget == SignEmpID
                      && SignDate1 >= ca.DateB && SignDate1 <= ca.DateE && ca.IsValid
                      && ListFlowTreeID.Contains(ft.id)
                      select new
                      {
                          FormCode = w.sFormCode,
                          Sort = 1,
                          MainMan = true,
                          EmpID = ca.Emp_idTarget,
                          EmpName = e.name,
                          DeptName = d.name,
                          DeptID = d.id,
                          DeptPath = d.path,
                          PosID = p.id,
                          PosName = p.name,
                          RoleID = r.id,
                          FlowTreeID = ft.id,
                          FormName = ft.name,
                          Count =
                          (from pf in _context.ProcessFlows
                           where !pf.isFinish.Value
                           && !pf.isCancel.Value
                           && !pf.isError.Value
                           && pf.FlowTree_id == ft.id
                           && (from pn in _context.ProcessNodes
                               where !pn.isFinish.Value
                               && pn.ProcessFlow_id.Value == pf.id
                               && (from pc in _context.ProcessChecks
                                   where pc.Emp_idReal == ""
                                   && pc.Emp_idDefault == ca.Emp_idSource
                                   && pc.Role_idDefault == ca.Role_idSource
                                   && pc.ProcessNode_auto.Value == pn.auto
                                   select 1).Any()
                               select 1).Any()
                           select 1).Count()
                      }).Union(from ft in _context.FlowTrees
                               join w in _context.wfForms on ft.id equals w.sFlowTree
                               from r in _context.Roles
                               join d in _context.Depts on r.Dept_id equals d.id
                               join p in _context.Pos on r.Pos_id equals p.id
                               join e in _context.Emps on r.Emp_id equals e.id
                               where SignDate1 >= r.dateB && SignDate1 <= r.dateE
                               && SignEmpID == r.Emp_id
                               && ListFlowTreeID.Contains(ft.id)
                               select new
                               {
                                   FormCode = w.sFormCode,
                                   Sort = 2,
                                   MainMan = false,
                                   EmpID = r.Emp_id,
                                   EmpName = e.name,
                                   DeptName = d.name,
                                   DeptID = d.id,
                                   DeptPath = d.path,
                                   PosID = p.id,
                                   PosName = p.name,
                                   RoleID = r.id,
                                   FlowTreeID = ft.id,
                                   FormName = ft.name,
                                   Count =
                                   (from pf in _context.ProcessFlows
                                    where !pf.isFinish.Value
                                    && !pf.isCancel.Value
                                    && !pf.isError.Value
                                    && pf.FlowTree_id == ft.id
                                    && (from pn in _context.ProcessNodes
                                        where !pn.isFinish.Value
                                        && pn.ProcessFlow_id == pf.id
                                        && (from pc in _context.ProcessChecks
                                            where pc.Emp_idReal == ""
                                            && pc.Emp_idDefault == r.Emp_id
                                            && pc.Role_idDefault == r.id
                                            && pc.ProcessNode_auto == pn.auto
                                            select 1).Any()
                                        select 1).Any()
                                    select 1).Count()
                               }).ToList();

            var Vdb = new List<FlowSignRoleRow>();

            var rsGroup = rs.GroupBy(p => new { EmpID = p.EmpID, RoleID = p.RoleID }).OrderByDescending(p => p.Key.EmpID == SignEmpID).ToList();

            foreach (var r in rsGroup)
            {
                FlowSignRoleRow rFlowSignRoleRow = new FlowSignRoleRow();
                rFlowSignRoleRow.Count = r.Sum(p => p.Count);
                rFlowSignRoleRow.BatchSign = true;
                rFlowSignRoleRow.maninfo = new ManInfoRow();
                rFlowSignRoleRow.maninfo.EmpID = r.First().EmpID;
                rFlowSignRoleRow.maninfo.DeptID = r.First().DeptID;
                rFlowSignRoleRow.maninfo.DeptPath = r.First().DeptPath;
                rFlowSignRoleRow.maninfo.PosID = r.First().PosID;
                rFlowSignRoleRow.maninfo.EmpName = r.First().EmpName;
                rFlowSignRoleRow.maninfo.DeptName = r.First().DeptName;
                rFlowSignRoleRow.maninfo.PosName = r.First().PosName;
                rFlowSignRoleRow.maninfo.RoleID = r.First().RoleID;
                rFlowSignRoleRow.maninfo.Sort = r.First().Sort;
                rFlowSignRoleRow.maninfo.MainMan = r.First().MainMan;
                rFlowSignRoleRow.FlowSignForm = new List<FlowSignFormRow>();

                foreach (var r1 in r)
                {
                    FlowSignFormRow rFlowSignFormRow = new FlowSignFormRow();
                    //rFlowSignFormRow.AutoKey = 0;
                    rFlowSignFormRow.Count = r1.Count;
                    rFlowSignFormRow.FormName = r1.FormName;
                    rFlowSignFormRow.FlowTreeID = r1.FlowTreeID;
                    rFlowSignFormRow.FormCode = r1.FormCode;
                    //rFlowSignFormRow.DynamicNode = "";
                    rFlowSignRoleRow.FlowSignForm.Add(rFlowSignFormRow);
                }

                Vdb.Add(rFlowSignRoleRow);
            }
            return Vdb;
        }

        /// <summary>
        /// 取得目前待審核的表單-調班
        /// </summary>
        /// <param name="RealSignEmpID">代理審核者工號</param>
        /// <param name="RealSignRoleID">代理審核者角色</param>
        /// <param name="SignDate">審核日期</param>
        /// <returns>List FlowSignShiftRoteRow</returns>
        public List<FlowSignShiftRoteRow> GetFlowSignShiftRote(string SignEmpID, string SignRoleID, string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "")
        {
            var FlowTreeID = "66";
            var rsFlowSignRole = GetFlowSignRoleFullDataByNow(SignEmpID, new List<string> { FlowTreeID }, SignRoleID, RealSignEmpID, RealSignRoleID, SignDate);
            if (rsFlowSignRole.Count == 0)
                return null;

            //var rFlowSignRole = rsFlowSignRole.FirstOrDefault(p => (p.RoleID == RealSignRoleID || RealSignRoleID.Length == 0)
            //&& p.EmpID == RealSignEmpID);
            var rFlowSignRole = rsFlowSignRole.FirstOrDefault();
            if (rFlowSignRole == null)
                return null;

            //var rFlowSignForm = rFlowSignRole.FlowSignForm.FirstOrDefault(p => p.FlowTreeID == FlowTreeID);
            var rFlowSignForm = rFlowSignRole.FlowSignForm.FirstOrDefault();
            if (rFlowSignForm == null)
                return null;

            var rsFlowSign = rFlowSignForm.FlowSign;

            var ListProcessFlowID = rsFlowSign.Select(p => p.ProcessFlowID).ToList();

            var rsShiftRote = (from a in _context.wfAppShiftRotes
                               where ListProcessFlowID.Contains(a.idProcess)
                               select new
                               {
                                   ProcessFlowID = a.idProcess,
                                   ShiftRoteType = a.sShiftRoteType,
                                   EmpID1 = a.sEmpID1,
                                   EmpCode1 = a.sEmpCode1,
                                   EmpNameC1 = a.sName1,

                                   EmpID2 = a.sEmpID2,
                                   EmpCode2 = a.sEmpCode2,
                                   EmpNameC2 = a.sName2,

                                   Key = a.sGuid,
                                   Note = a.sNote,
                               }).ToList();

            var ListKey = rsShiftRote.Select(p => p.Key).ToList();

            var rsShiftRoteDetail = (from c in _context.wfAppShiftRoteDetails
                                     where ListKey.Contains(c.sShiftRoteKey)
                                     select new
                                     {
                                         Key = c.sShiftRoteKey,
                                         ShiftRoteDate = c.dShiftRoteDate.ToShortDateString(),
                                     }).ToList();

            List<FlowSignShiftRoteRow> Vdb = new List<FlowSignShiftRoteRow>();

            

            foreach (var rShiftRote in rsShiftRote)
            {
                //重複的流程資料不要寫入
                if (!Vdb.Any(p => p.ProcessFlowID == rShiftRote.ProcessFlowID))
                {
                    var rFlowSign = rsFlowSign.FirstOrDefault(p => p.ProcessFlowID == rShiftRote.ProcessFlowID);

                    if (rFlowSign == null)
                        continue;

                    FlowSignShiftRoteRow rVdb = new FlowSignShiftRoteRow();
                    rVdb.ProcessFlowID = rShiftRote.ProcessFlowID;
                    rVdb.FlowTreeID = rFlowSign.FlowTreeID;
                    rVdb.FlowNodeID = rFlowSign.FlowNodeID;
                    rVdb.ProcessApParmAuto = rFlowSign.ProcessApParmAuto;
                    rVdb.EmpID1 = rShiftRote.EmpID1;
                    rVdb.EmpCode1 = rShiftRote.EmpCode1;
                    rVdb.EmpNameC1 = rShiftRote.EmpNameC1 ?? "";
                    rVdb.EmpID2 = rShiftRote.EmpID2;
                    rVdb.EmpCode2 = rShiftRote.EmpCode2;
                    rVdb.EmpNameC2 = rShiftRote.EmpNameC2 ?? "";
                    rVdb.isApproved = rFlowSign.SignCondition.SignComplete;
                    rVdb.isSendback = rFlowSign.SignCondition.Reject;
                    rVdb.isPutForward = rFlowSign.SignCondition.Sign;
                    rVdb.WriteEmpCode = rFlowSign.AppEmpID;
                    rVdb.WriteEmpNameC = rFlowSign.AppEmpName ?? "";
                    rVdb.checkProxy = rVdb.EmpID1 != rVdb.WriteEmpCode;
                    rVdb.isDR = rShiftRote.ShiftRoteType == "DR";
                    rVdb.isRR = rShiftRote.ShiftRoteType == "RR";
                    rVdb.isRZ = rShiftRote.ShiftRoteType == "RZ";
                    var rsShiftRoteDetailTemp = rsShiftRoteDetail.Where(p => p.Key == rShiftRote.Key).ToList();
                    rVdb.numberOfVaData = rsShiftRoteDetailTemp.Count;
                    rVdb.dateArray = rsShiftRoteDetailTemp.Select(p => p.ShiftRoteDate).ToList();

                    Vdb.Add(rVdb);
                }
            }

            return Vdb;
        }

        /// <summary>
        /// 流程檢視
        /// TODO :
        /// </summary>
        /// <param name="ListEmpID">管理者或被查詢者工號</param>
        /// <param name="DateB">簽核開始日期</param>
        /// <param name="DateE">簽核結束日期</param>
        /// <param name="FormCode">查詢表單代碼</param>
        /// <param name="State">狀態</param>
        /// <param name="ProcessFlowID">流程序號</param>
        /// <param name="Cond1">條件1</param>
        /// <param name="Cond2">條件2</param>
        /// <param name="Cond3">絛件3</param>
        /// <returns>List FlowViewRow</returns>
        public List<FlowViewRow> GetFlowView(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0")
        {
            var Vdb = GetFlowView1(ListEmpID, DateB, DateE, FormCode, State, ProcessFlowID, Cond1, Cond2, Cond3);
            return new List<FlowViewRow>();
        }

        /// <summary>
        /// TODO :
        /// </summary>
        /// <param name="ListEmpID"></param>
        /// <param name="DateB"></param>
        /// <param name="DateE"></param>
        /// <param name="FormCode"></param>
        /// <param name="State"></param>
        /// <param name="ProcessFlowID"></param>
        /// <param name="Cond1"></param>
        /// <param name="Cond2"></param>
        /// <param name="Cond3"></param>
        /// <returns></returns>
        private List<FlowViewRow> GetFlowView1(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0",
            string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0")
        {
            return new List<FlowViewRow>();
        }


        /// <summary>
        /// 流程檢視(請假)
        /// </summary>
        /// <param name="ListEmpID">管理者或被查詢者工號</param>
        /// <param name="DateB">簽核開始日期</param>
        /// <param name="DateE">簽核結束日期</param>
        /// <param name="FormCode">查詢表單代碼</param>
        /// <param name="State">狀態</param>
        /// <param name="ProcessFlowID">流程序號</param>
        /// <param name="Cond1">條件1</param>
        /// <param name="Cond2">條件2</param>
        /// <param name="Cond3">絛件3</param>
        /// <param name="Handle">經手</param>
        /// <returns>List FlowViewRow</returns>
        public List<FlowViewAbsRow> GetFlowViewAbs(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 流程檢視(請假)-部門
        /// </summary>
        /// <param name="DeptaID">部門代碼</param>
        /// <param name="ChildDept">是否向下</param>
        /// <param name="PageCurrent">頁面</param>
        /// <param name="PageRows">筆數</param>
        /// <param name="EffectDate">生效日</param>
        /// <param name="DateB">簽核開始日期</param>
        /// <param name="DateE">簽核結束日期</param>
        /// <param name="FormCode">查詢表單代碼</param>
        /// <param name="State">狀態</param>
        /// <param name="ProcessFlowID">流程序號</param>
        /// <param name="Cond1">條件1</param>
        /// <param name="Cond2">條件2</param>
        /// <param name="Cond3">絛件3</param>
        /// <param name="Handle">經手</param>
        /// <returns>List FlowViewAbsRow</returns>
        public List<FlowViewAbsRow> GetFlowViewAbsByDept(int DeptaID = 0, bool ChildDept = false, int PageCurrent = 1, int PageRows = 100, string EffectDate = "", string DateB = "", string DateE = "", string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return new List<FlowViewAbsRow>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ListEmpID"></param>
        /// <param name="DateB"></param>
        /// <param name="DateE"></param>
        /// <param name="FormCode"></param>
        /// <param name="State"></param>
        /// <param name="ProcessFlowID"></param>
        /// <param name="Cond1"></param>
        /// <param name="Cond2"></param>
        /// <param name="Cond3"></param>
        /// <param name="Handle"></param>
        /// <returns></returns>
        public List<FlowViewAbscRow> GetFlowViewAbsc(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            DateTime DateNow = DateTime.Now.Date;
            DateTime DateB1 = Convert.ToDateTime(DateB).Date;
            DateTime DateE1 = Convert.ToDateTime(DateE).Date;

            List<int> ListProcessFlowID = new List<int>();

            if (Handle)
            {
                //經手過(簽核)
                ListProcessFlowID = (from pc in _context.ProcessChecks
                                     join pn in _context.ProcessNodes on pc.ProcessNode_auto equals pn.auto
                                     join pf in _context.ProcessFlows on pn.ProcessFlow_id equals pf.id
                                     where (ListEmpID.Contains(pc.Emp_idAgent) || ListEmpID.Contains(pc.Emp_idDefault) || ListEmpID.Contains(pc.Emp_idReal))
                                     && pf.FlowTree_id == "17"
                                     select pn.ProcessFlow_id.Value).ToList();

                //經手過(幫別人申請)
                ListProcessFlowID.AddRange((from c in _context.wfFormApps
                                            where ListEmpID.Contains(c.sNobr)
                                            && c.sFormCode == "Absc"
                                            select c.idProcess).ToList());

                ListProcessFlowID = ListProcessFlowID.Distinct().Take(500).ToList();
            }

            var rsAbscFlowSql = from a in _context.wfAppAbscs
                                where (ListEmpID.Contains(a.sNobr) || ListProcessFlowID.Contains(a.idProcess))
                                && DateB1 <= a.dDate
                                && DateE1 >= a.dDate
                                && (a.idProcess == ProcessFlowID || ProcessFlowID == 0)
                                select a;

            switch (Cond1)
            {
                case "1":   //假別種類
                    rsAbscFlowSql = from a in rsAbscFlowSql
                                    where a.sHcode == Cond2
                                    select a;
                    break;
            }

            ListProcessFlowID = rsAbscFlowSql.Select(p => p.idProcess).ToList();

            //申請人
            var Vdb = (from m in _context.wfFormApps
                       where (State == "0" || m.sState == State)
                       && ListProcessFlowID.Contains(m.idProcess)
                       orderby m.idProcess descending
                       select new FlowViewAbscRow
                       {
                           Key = "0",
                           ProcessFlowID = m.idProcess,
                           FormName = m.sFormName,
                           AppEmpID = m.sNobr,
                           AppEmpName = m.sName,
                           AppDeptName = m.sDeptName,
                           ManageEmpName = "",//p.ManageName,
                           RealManageEmpName = "",
                           State = m.sState,
                           Take = true,
                           Handle = false,
                           TransSign = false,
                       }).ToList();

            //判斷是否有人簽核過
            var rsProcess1 = (from pn in _context.ProcessNodes
                              join pc in _context.ProcessChecks on pn.auto equals pc.ProcessNode_auto
                              join e1 in _context.Emps on pc.Emp_idDefault equals e1.id
                              join e2 in _context.Emps on pc.Emp_idReal equals e2.id into e2g
                              from e2gs in e2g.DefaultIfEmpty()
                              where ListProcessFlowID.Contains(pn.ProcessFlow_id.Value)
                              select new
                              {
                                  ProcessNodeAuto = pn.auto,
                                  ProcessFlowID = pn.ProcessFlow_id,
                                  PendingDay = (DateTime.Now - pn.adate.Value).Days,
                                  ManageEmpName = e1.name,
                                  RealManageEmpName = e2gs.name,
                              }).ToList();

            //取得最後一次簽核的資料
            var rsProcess = (from p in rsProcess1
                             group p by p.ProcessFlowID into g
                             select g.OrderByDescending(p => p.ProcessNodeAuto).First() into d
                             select d).ToList();

            //重新取得流程的資料 避免有沒抓到的資料
            var rsAbscFlow = (from a in _context.wfAppAbscs
                              where ListProcessFlowID.Contains(a.idProcess)
                              select a).ToList();


            //AttHandlerBll_StandardFoods oAttHandler = new AttHandlerBll_StandardFoods(HR);
            //取得假別代碼資料
            //var rsHoliDay = oAttHandler.GetHoliDay(null);

            List<HoliDayRow> rsHoliDay = new List<HoliDayRow>();

            AbsCalculate absCalculate = new AbsCalculate();
            //MultiHandlerBll_StandardFoods oMultiHandler = new MultiHandlerBll_StandardFoods(HR);

            //BaseHandlerBll_StandardFoods oBaseHandler = new BaseHandlerBll_StandardFoods(HR);
            //取得登入者工號
            //string LoginEmpID = oBaseHandler.GetHeadersOfAuthorizationToEmpID();
            //取得員工基本資料
            //var rBaseInfoDetail = oBaseHandler.GetBaseInfoDetail(new List<string> { LoginEmpID }, DateTime.Today.ToShortDateString()).FirstOrDefault();
            bool IsAssistant = false;
            //if (rBaseInfoDetail != null)
            //{
            //    IsAssistant = rBaseInfoDetail.IsAssistant;
            //}

            //AuthHandlerBll_StandardFoods oAuthHandler = new AuthHandlerBll_StandardFoods(HR);
            //根據工號權限取得角色
            //var RoleAuth = oAuthHandler.GetRoleByAuth(LoginEmpID);
            //var IsAdmin = RoleAuth.Any(p => p.isAdmin);
            var IsAdmin = false;

            foreach (var rVdb in Vdb)
            {
                var rsAbscFlowTemp = rsAbscFlow.Where(p => p.idProcess == rVdb.ProcessFlowID).ToList();

                if (rsAbscFlowTemp.Count > 0)
                {
                    //取得第一筆資料
                    var rAbscFlowTemp = rsAbscFlowTemp.First();

                    //處理中
                    rVdb.Handle = false;
                    if (rAbscFlowTemp.sState == "1")
                        if (rVdb.State == "3" || rVdb.State == "2")
                            rVdb.Handle = true;

                    //是否可以轉呈
                    rVdb.TransSign = false;
                    if (rAbscFlowTemp.sState == "1")
                        if (rVdb.State == "1")
                            if (IsAssistant || IsAdmin)
                                rVdb.TransSign = true;

                    rVdb.EmpID = rAbscFlowTemp.sNobr;
                    rVdb.EmpName = rAbscFlowTemp.sName;
                    rVdb.DeptName = rAbscFlowTemp.sDeptName;
                    rVdb.AbscCount = rsAbscFlowTemp.Count;
                    rVdb.BaseHour = 8;
                    rVdb.FlowViewAbscDate = new List<FlowViewAbscDateRow>();

                    //不等於已核准的都直接計算
                    //if (rVdb.State != "3")
                    {
                        //加總所有資料變更為分鐘數
                        int TotalUse = 0;
                        decimal TotalDay = 0, TotalHour = 0, TotalMinute = 0;
                        foreach (var rAbscFlow in rsAbscFlowTemp)
                        {
                            var rHoliDay = rsHoliDay.FirstOrDefault(p => p.HoliDayID.ToString() == rAbscFlow.sHcode);
                            int Use = 0;

                            switch (rHoliDay.HoliDayUnit)
                            {
                                case "1":   //時
                                    Use = Convert.ToInt32(rAbscFlow.iUse * 60);
                                    break;
                                case "2":   //天
                                    Use = Convert.ToInt32(rAbscFlow.iUse * rVdb.BaseHour * 60);
                                    break;
                                case "3":   //分
                                    Use = Convert.ToInt32(rAbscFlow.iUse);
                                    break;
                            }

                            FlowViewAbscDateRow r = new FlowViewAbscDateRow();
                            r.DateTimeB = rAbscFlow.dDateTime;
                            r.DateTimeE = rAbscFlow.dDateTime;
                            r.Use = Use;
                            rVdb.FlowViewAbscDate.Add(r);

                            var UseDayHourMinute = absCalculate.ConvertTimeUse(rAbscFlow.iUse, Convert.ToInt32(rHoliDay.HoliDayUnit), rVdb.BaseHour, Convert.ToInt32(rVdb.BaseHour * 60));
                            //特殊假種 它們的基底時數為24小時
                            //if (oMultiHandler.HoliDayCodeForBaseHour24.Contains(rHoliDay.HoliDayCode))
                            //{
                            //    UseDayHourMinute = absCalculate.ConvertTimeUse(rAbscFlow.iUse, Convert.ToInt32(rHoliDay.HoliDayUnit), 24, 1440);
                            //}

                            TotalUse += Use;
                            TotalDay += UseDayHourMinute.Day;
                            TotalHour += UseDayHourMinute.Hour;
                            TotalMinute += UseDayHourMinute.Minute;
                        }

                        rVdb.Use = TotalUse;
                        rVdb.UseDayHourMinute = new DayHourMinuteRow();
                        rVdb.UseDayHourMinute.Day = TotalDay;
                        rVdb.UseDayHourMinute.Hour = TotalHour;
                        rVdb.UseDayHourMinute.Minute = TotalMinute;
                    }
                }

                var rProcess = rsProcess.Where(p => p.ProcessFlowID == rVdb.ProcessFlowID).FirstOrDefault();
                if (rProcess != null)
                {
                    rVdb.ManageEmpName = rProcess.ManageEmpName;
                    rVdb.RealManageEmpName = rProcess.RealManageEmpName;
                }

                //如果是進行中或預排 且 沒有人簽核過
                rVdb.Take = rVdb.Take && (rVdb.State == "1" || rVdb.State == "6")
                            && (!(rsProcess1.Count(p => p.ProcessFlowID == rVdb.ProcessFlowID) >= 2) || IsAdmin || IsAssistant);
            }

            return Vdb;
        }

        public List<FlowViewAbscRow> GetFlowViewAbscByDept(int DeptaID = 0, bool ChildDept = false, int PageCurrent = 1, int PageRows = 100, string EffectDate = "", string DateB = "", string DateE = "", string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return new List<FlowViewAbscRow>();
        }

        public List<FlowViewAttendUnusualRow> GetFlowViewAttendUnusual(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return new List<FlowViewAttendUnusualRow>();
        }

        public List<FlowViewAttendUnusualRow> GetFlowViewAttendUnusualByDept(int DeptaID = 0, bool ChildDept = false, int PageCurrent = 1, int PageRows = 100, string EffectDate = "", string DateB = "", string DateE = "", string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return new List<FlowViewAttendUnusualRow>();
        }

        public List<FlowViewCardRow> GetFlowViewCard(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return new List<FlowViewCardRow>();
        }

        public List<FlowViewCardRow> GetFlowViewCardByDept(string DeptaID = "", bool ChildDept = false, int PageCurrent = 1, int PageRows = 100, string EffectDate = "", string DateB = "", string DateE = "", string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            throw new NotImplementedException();
        }

        public List<FlowViewCardRow> GetFlowViewCardPatch(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            DateTime DateNow = DateTime.Now.Date;
            DateTime DateB1 = Convert.ToDateTime(DateB).Date;
            DateTime DateE1 = Convert.ToDateTime(DateE).Date;

            

            List<int> ListProcessFlowID = new List<int>();

            if (Handle)
            {
                //經手過(簽核)
                ListProcessFlowID = (from pc in _context.ProcessChecks
                                     join pn in _context.ProcessNodes on pc.ProcessNode_auto equals pn.auto
                                     join pf in _context.ProcessFlows on pn.ProcessFlow_id equals pf.id
                                     where (ListEmpID.Contains(pc.Emp_idAgent) || ListEmpID.Contains(pc.Emp_idDefault) || ListEmpID.Contains(pc.Emp_idReal))
                                     && pf.FlowTree_id == "82"
                                     select pn.ProcessFlow_id.Value).ToList();

                //經手過(幫別人申請)
                ListProcessFlowID.AddRange((from c in _context.wfFormApps
                                            where ListEmpID.Contains(c.sNobr)
                                            && c.sFormCode == "CardPatch"
                                            select c.idProcess).ToList());

                ListProcessFlowID = ListProcessFlowID.Distinct().Take(500).ToList();
            }

            //申請人
            var Vdb = (from m in _context.wfFormApps
                       where (State == "0" || m.sState == State)
                       && ListProcessFlowID.Contains(m.idProcess)
                       orderby m.idProcess descending
                       select new FlowViewCardRow
                       {
                           Key = "0",
                           ProcessFlowID = m.idProcess,
                           FormName = m.sFormName,
                           AppEmpID = m.sNobr,
                           AppEmpName = m.sName,
                           AppDeptName = m.sDeptName,
                           ManageEmpName = "",//p.ManageName,
                           RealManageEmpName = "",
                           State = m.sState,
                           Take = true,
                           Handle = false,
                           TransSign = false,
                       }).ToList();

            //判斷是否有人簽核過
            var rsProcess1 = (from pn in _context.ProcessNodes
                              join pc in _context.ProcessChecks on pn.auto equals pc.ProcessNode_auto
                              join e1 in _context.Emps on pc.Emp_idDefault equals e1.id
                              join e2 in _context.Emps on pc.Emp_idReal equals e2.id into e2g
                              from e2gs in e2g.DefaultIfEmpty()
                              where ListProcessFlowID.Contains(pn.ProcessFlow_id.Value)
                              select new
                              {
                                  ProcessNodeAuto = pn.auto,
                                  ProcessFlowID = pn.ProcessFlow_id,
                                  PendingDay = (DateTime.Now - pn.adate.Value).Days,
                                  ManageEmpName = e1.name,
                                  RealManageEmpName = e2gs.name,
                              }).ToList();

            //取得最後一次簽核的資料
            var rsProcess = (from p in rsProcess1
                             group p by p.ProcessFlowID into g
                             select g.OrderByDescending(p => p.ProcessNodeAuto).First() into d
                             select d).ToList();

            //重新取得流程的資料 避免有沒抓到的資料(沒有一次請多筆的問題，所以不用)

            //var FlowEmpIDList = rsCardFlow.Select(x => x.sNobr).ToList();

           

            //BaseHandlerBll_StandardFoods oBaseHandler = new BaseHandlerBll_StandardFoods();
            //string LoginEmpID = oBaseHandler.GetHeadersOfAuthorizationToEmpID();
            //var rBaseInfoDetail = oBaseHandler.GetBaseInfoDetail(new List<string> { LoginEmpID }, "").FirstOrDefault();
            bool IsAssistant = false;
            //if (rBaseInfoDetail != null)
            //    IsAssistant = rBaseInfoDetail.IsAssistant;

            //AuthHandlerBll_StandardFoods oAuthHandler = new AuthHandlerBll_StandardFoods();
            //var RoleAuth = oAuthHandler.GetRoleByAuth(LoginEmpID);
            bool IsAdmin = false;
            //var IsAdmin = RoleAuth.Any(p => p.isAdmin);

            foreach (var rVdb in Vdb)
            {
               
                var rProcess = rsProcess.Where(p => p.ProcessFlowID == rVdb.ProcessFlowID).FirstOrDefault();
                if (rProcess != null)
                {
                    rVdb.ManageEmpName = rProcess.ManageEmpName;
                    rVdb.RealManageEmpName = rProcess.RealManageEmpName;
                }

                //如果是進行中或預排 且 沒有人簽核過
                rVdb.Take = rVdb.Take && (rVdb.State == "1" || rVdb.State == "6")
                     && (!(rsProcess1.Count(p => p.ProcessFlowID == rVdb.ProcessFlowID) >= 2) || IsAdmin || IsAssistant);
            }

            return Vdb;
        }

        public List<FlowViewCardRow> GetFlowViewCardPatchByDept(int DeptaID = 0, bool ChildDept = false, int PageCurrent = 1, int PageRows = 100, string EffectDate = "", string DateB = "", string DateE = "", string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return new List<FlowViewCardRow>();
        }

        public List<FlowViewShiftRoteRow> GetFlowViewShiftRote(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            DateTime DateNow = DateTime.Now.Date;
            DateTime DateB1 = Convert.ToDateTime(DateB).Date;
            DateTime DateE1 = Convert.ToDateTime(DateE).Date;


            List<int> ListProcessFlowID = new List<int>();

            if (Handle)
            {
                //經手過(簽核)
                ListProcessFlowID = (from pc in _context.ProcessChecks
                                     join pn in _context.ProcessNodes on pc.ProcessNode_auto equals pn.auto
                                     join pf in _context.ProcessFlows on pn.ProcessFlow_id equals pf.id
                                     where (ListEmpID.Contains(pc.Emp_idAgent) || ListEmpID.Contains(pc.Emp_idDefault) || ListEmpID.Contains(pc.Emp_idReal))
                                     && pf.FlowTree_id == "66"
                                     select pn.ProcessFlow_id.Value).ToList();

                //經手過(幫別人申請)
                ListProcessFlowID.AddRange((from c in _context.wfFormApps
                                            where ListEmpID.Contains(c.sNobr)
                                            && c.sFormCode == "ShiftRote"
                                            select c.idProcess).ToList());

                ListProcessFlowID = ListProcessFlowID.Distinct().Take(500).ToList();
            }

            var rsShiftRoteFlowSql = from a in _context.wfAppShiftRotes
                                     join rm in _context.wfFormApps on a.idProcess equals rm.idProcess
                                     where ((ListEmpID.Contains(a.sEmpID1) || ListEmpID.Contains(a.sEmpID2)) || ListProcessFlowID.Contains(a.idProcess))
                                     && (from b in _context.wfAppShiftRoteDetails
                                         where a.sGuid == b.sShiftRoteKey
                                         && DateB1 <= b.dShiftRoteDate && b.dShiftRoteDate <= DateE1
                                         select 1).Any()
                                     select a;

            switch (Cond1)
            {
                case "1":   //請求調班
                    rsShiftRoteFlowSql = from a in rsShiftRoteFlowSql
                                         where a.sShiftRoteType == "DR"
                                         select a;
                    break;
                case "2":   //雙人互調
                    rsShiftRoteFlowSql = from a in rsShiftRoteFlowSql
                                         where a.sShiftRoteType == "RR"
                                         select a;

                    break;
                case "3":   //例休互調
                    rsShiftRoteFlowSql = from a in rsShiftRoteFlowSql
                                         where a.sShiftRoteType == "RZ"
                                         select a;

                    break;
            }

            ListProcessFlowID = rsShiftRoteFlowSql.Select(p => p.idProcess).ToList();

            //申請人
            var Vdb = (from m in _context.wfFormApps
                       where (State == "0" || m.sState == State)
                       && ListProcessFlowID.Contains(m.idProcess)
                       orderby m.idProcess descending
                       select new FlowViewShiftRoteRow
                       {
                           Key = "0",
                           ProcessFlowID = m.idProcess,
                           FormName = m.sFormName,
                           AppEmpID = m.sNobr,
                           AppEmpName = m.sName,
                           AppDeptName = m.sDeptName,
                           ManageEmpName = "",//p.ManageName,
                           RealManageEmpName = "",
                           State = m.sState,
                           Take = true,
                           Handle = false,
                           TransSign = false,
                       }).ToList();

            //判斷是否有人簽核過
            var rsProcess1 = (from pn in _context.ProcessNodes
                              join pc in _context.ProcessChecks on pn.auto equals pc.ProcessNode_auto
                              join e1 in _context.Emps on pc.Emp_idDefault equals e1.id
                              join e2 in _context.Emps on pc.Emp_idReal equals e2.id into e2g
                              from e2gs in e2g.DefaultIfEmpty()
                              where ListProcessFlowID.Contains(pn.ProcessFlow_id.Value)
                              select new
                              {
                                  ProcessNodeAuto = pn.auto,
                                  ProcessFlowID = pn.ProcessFlow_id,
                                  PendingDay = (DateTime.Now - pn.adate.Value).Days,
                                  ManageEmpName = e1.name,
                                  RealManageEmpName = e2gs.name,
                              }).ToList();

            //取得最後一次簽核的資料
            var rsProcess = (from p in rsProcess1
                             group p by p.ProcessFlowID into g
                             select g.OrderByDescending(p => p.ProcessNodeAuto).First() into d
                             select d).ToList();

            //重新取得流程的資料 避免有沒抓到的資料
            var rsShiftRoteFlow = (from a in _context.wfAppShiftRotes
                                   where ListProcessFlowID.Contains(a.idProcess)
                                   select a).ToList();

            var ListShiftRoteKey = rsShiftRoteFlow.Select(p => p.sGuid).ToList();

            //取得調班明細資料
            var rsShiftRoteDetail = (from a in _context.wfAppShiftRoteDetails
                                     where ListShiftRoteKey.Contains(a.sShiftRoteKey)
                                     select a).ToList();

            //BaseHandlerBll_StandardFoods oBaseHandler = new BaseHandlerBll_StandardFoods();
            //string LoginEmpID = oBaseHandler.GetHeadersOfAuthorizationToEmpID();
            //var rBaseInfoDetail = oBaseHandler.GetBaseInfoDetail(new List<string> { LoginEmpID }, "").FirstOrDefault();
            bool IsAssistant = false;
            //if (rBaseInfoDetail != null)
            //    IsAssistant = rBaseInfoDetail.IsAssistant;

            //AuthHandlerBll_StandardFoods oAuthHandler = new AuthHandlerBll_StandardFoods();
            //var RoleAuth = oAuthHandler.GetRoleByAuth(LoginEmpID);
            bool IsAdmin = false;
            //var IsAdmin = RoleAuth.Any(p => p.isAdmin);

            foreach (var rVdb in Vdb)
            {
                var rShiftRoteFlow = rsShiftRoteFlow.FirstOrDefault(p => p.idProcess == rVdb.ProcessFlowID);
                {
                    //處理中
                    rVdb.Handle = false;
                    if (rShiftRoteFlow.sState == "1")
                        if (rVdb.State == "3" || rVdb.State == "2")
                            rVdb.Handle = true;

                    //是否可以轉呈
                    rVdb.TransSign = false;
                    if (rShiftRoteFlow.sState == "1")
                        if (rVdb.State == "1")
                            if (IsAssistant || IsAdmin)
                                rVdb.TransSign = true;

                    rVdb.EmpID1 = rShiftRoteFlow.sEmpID1;
                    rVdb.EmpName1 = rShiftRoteFlow.sName1;
                    rVdb.DeptName1 = rShiftRoteFlow.sDeptName1;
                    rVdb.EmpID2 = rShiftRoteFlow.sEmpID2;
                    rVdb.EmpName2 = rShiftRoteFlow.sName2;
                    rVdb.DeptName2 = rShiftRoteFlow.sDeptName2;
                    rVdb.ShiftRoteName = rShiftRoteFlow.sShiftRoteName;

                    var rsShiftRoteDetailTemp = rsShiftRoteDetail.Where(p => p.sShiftRoteKey == rShiftRoteFlow.sGuid).ToList();
                    rVdb.ShiftRoteCount = rsShiftRoteDetailTemp.Count;

                    rVdb.FlowViewShiftRoteDate = new List<FlowViewShiftRoteDateRow>();

                    foreach (var rShiftRoteDetail in rsShiftRoteDetailTemp)
                    {
                        FlowViewShiftRoteDateRow rFlowViewShiftRoteDate = new FlowViewShiftRoteDateRow();
                        rFlowViewShiftRoteDate.ShiftRoteDate = rShiftRoteDetail.dShiftRoteDate;

                        rFlowViewShiftRoteDate.RoteID1 = rShiftRoteDetail.iRoteID1;
                        rFlowViewShiftRoteDate.RoteCode1 = rShiftRoteDetail.sRote1;
                        rFlowViewShiftRoteDate.RoteName1 = rShiftRoteDetail.sRoteName1;

                        rFlowViewShiftRoteDate.RoteID2 = rShiftRoteDetail.iRoteID2;
                        rFlowViewShiftRoteDate.RoteCode2 = rShiftRoteDetail.sRote2;
                        rFlowViewShiftRoteDate.RoteName2 = rShiftRoteDetail.sRoteName2;

                        rVdb.FlowViewShiftRoteDate.Add(rFlowViewShiftRoteDate);
                    }
                }

                var rProcess = rsProcess.Where(p => p.ProcessFlowID == rVdb.ProcessFlowID).FirstOrDefault();
                if (rProcess != null)
                {
                    rVdb.ManageEmpName = rProcess.ManageEmpName;
                    rVdb.RealManageEmpName = rProcess.RealManageEmpName;
                }

                //如果是進行中或預排 且 沒有人簽核過
                rVdb.Take = rVdb.Take && (rVdb.State == "1" || rVdb.State == "6")
                    && (!(rsProcess1.Count(p => p.ProcessFlowID == rVdb.ProcessFlowID) >= 2) || IsAdmin || IsAssistant);
            }

            return Vdb;
        }

        public List<FlowViewShiftRoteRow> GetFlowViewShiftRoteByDept(int DeptaID = 0, bool ChildDept = false, int PageCurrent = 1, int PageRows = 100, string EffectDate = "", string DateB = "", string DateE = "", string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return new List<FlowViewShiftRoteRow>();
        }



        /// <summary>
        /// 批次節點審核
        /// </summary>
        /// <param name="ListNodeFinish">ListNodeFinish</param>
        /// <returns>int</returns>
        public int ListFlowNodeFinish(List<NodeFinishRow> ListNodeFinish)
        {
            int Finish = 0;
            foreach (var NodeFinish in ListNodeFinish)
            {
                var r = FlowNodeFinish(NodeFinish);
                if (r.isOK)
                {
                    Finish++;
                }   
            }
            return Finish;
        }

        public bool RunServiceByProcessID(int ProcessFlowID)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 存入資料
        /// </summary>
        /// <param name="processFlowID">idProcess</param>
        public void SaveDataByProcessID(int processFlowID)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 流程狀態設定
        /// </summary>
        /// <param name="ListProcessFlowID"></param>
        /// <param name="enumState">狀態(Approve,Reject,Cancel,Delete,Take)</param>
        /// <param name="EmpID">動作人工號</param>
        /// <param name="SignEmpID">轉呈人工號</param>
        /// <returns>FlowStateRow</returns>
        public FlowStateRow SetFlowState(List<int> ListProcessFlowID, MultiEnum.FlowState enumState, string EmpID = "", string SignEmpID = "")
        {
            return new FlowStateRow();
        }



        /// <summary>0
        /// 取得待審核
        /// </summary>
        /// <param name="SignEmpID">審核者工號</param>
        /// <param name="FlowTreeID"></param>
        /// <param name="SignRoleID">審核者角色</param>
        /// <param name="RealSignEmpID">代理審核者工號</param>
        /// <param name="RealSignRoleID">代理審核者角色</param>
        /// <param name="SignDate">審核日期</param>
        /// <returns></returns>
        public List<FlowSignRoleRow> GetFlowSignRoleFullDataByNow(string SignEmpID, List<string> FlowTreeID, string SignRoleID = "",
           string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "")
        {


            List<string> ListFlowTreeID = FlowTreeID.Count == 0 ? (from c in _context.Forms where c.Sort > 0 select c.FlowTreeId).ToList() : FlowTreeID;

            //FlowMainHandlerBll_StandardFoods oFlowMainHandler = new FlowMainHandlerBll_StandardFoods(); 

            List<FlowSignRoleRow> Vdb = new List<FlowSignRoleRow>();

            DateTime SignDate1 = SignDate.Length == 0 ? DateTime.Now.Date : Convert.ToDateTime(SignDate).Date;

            //取得主要簽核者
            string EmpID = RealSignEmpID.Length > 0 ? RealSignEmpID : SignEmpID;

            var rsFlowSign = (from pc in _context.ProcessChecks
                              join pa in _context.ProcessApParms on pc.auto equals pa.ProcessCheck_auto
                              join pn in _context.ProcessNodes on pc.ProcessNode_auto equals pn.auto
                              join pf in _context.ProcessFlows on pn.ProcessFlow_id equals pf.id
                              join fn in _context.FlowNodes on pn.FlowNode_id equals fn.id
                              join ft in _context.FlowTrees on pf.FlowTree_id equals ft.id
                              join f in _context.Forms on ft.id equals f.FlowTreeId
                              join fa in _context.FormsApps on pf.id equals fa.idProcess
                              //join ai in _context.FormsAppInfos on pf.id equals ai.idProcess
                              where !pf.isFinish.Value
                              && !pf.isCancel.Value
                              && !pf.isError.Value
                              && !pn.isFinish.Value
                              && ListFlowTreeID.Contains(pf.FlowTree_id) // == FlowTreeID
                              && pc.Emp_idReal == ""
                              && (pc.Emp_idDefault == EmpID || pc.Emp_idAgent == EmpID)
                              && ((pc.Role_idDefault == RealSignRoleID || RealSignRoleID == "")
                              || (pc.Role_idAgent == RealSignRoleID || RealSignRoleID == ""))

                              select new FlowSignRow()
                              {
                                  ProcessApParmAuto = pa.auto,
                                  ProcessFlowID = pf.id,
                                  ProcessCheckAuto = pc.auto,
                                  ProcessNodeAuto = pn.auto,
                                  AppRoleID = pf.Role_id,
                                  AppEmpID = fa.EmpId,
                                  AppDeptID = fa.DeptCode,
                                  AppDeptName = fa.DeptName,
                                  AppEmpName = fa.EmpName,
                                  AppDate = pf.adate.Value,
                                  AppDateD = fa.DateTimeD.Value,
                                  FlowTreeID = ft.id,
                                  FormCode = f.Code,
                                  FormName = f.Name,
                                  FlowNodeID = fn.id,
                                  FlowNodeName = fn.name,
                                  CheckRoleID = pc.Role_idDefault,
                                  CheckEmpID = pc.Emp_idDefault,
                                  PendingDay = Convert.ToInt32((DateTime.Now.Date - pn.adate.Value.Date).TotalDays),
                                  //Batch = fn.Batch.GetValueOrDefault(true),
                                  Info = fa.Note ?? "",
                                  Cond1 = fa.Cond01 ?? "",
                                  Cond2 = fa.Cond02 ?? "",
                                  Cond3 = fa.Cond03 ?? "",
                                  Cond4 = fa.Cond04 ?? "",
                                  Cond5 = fa.Cond05 ?? "",
                                  Cond6 = fa.Cond06 ?? "",

                                  //RealAppEmpID = ai.EmpId,
                              }).Distinct().ToList();
            //foreach (var r in rsFlowSign)
            //{
            //    var lsInfoData = (from c in _context.FormsAppInfos
            //                      where c.ProcessId == r.ProcessFlowID.ToString()
            //                      select c).ToList();
            //    foreach (var InfoData in lsInfoData)
            //    {
            //        r.Info += InfoData.InfoSign + "\r\n";
            //    }
            //}
            //判斷簽核權限
            var rsSignCondition = (from rFlowSign in rsFlowSign
                                   select new SignConditionRow
                                   {
                                       FormCode = rFlowSign.FormCode,
                                       AppEmpID = rFlowSign.AppEmpID,
                                       CheckEmpID = rFlowSign.CheckEmpID,    //審核者工號
                                       Tree = 9,   //簽核部門層級 會被轉換
                                       ProcessFlowID = rFlowSign.ProcessFlowID,
                                       Cond1 = rFlowSign.Cond1,
                                       Cond2 = rFlowSign.Cond2,
                                       Cond3 = rFlowSign.Cond3,
                                       Cond4 = rFlowSign.Cond4,
                                       Cond5 = rFlowSign.Cond5,
                                       Cond6 = rFlowSign.Cond6,
                                       Sign = true,
                                       Reject = true,
                                       SignComplete = false,
                                   }).ToList();


            foreach (var rSignCondition in rsSignCondition)
            {
                var rFlowSign = rsFlowSign.FirstOrDefault(p => p.ProcessFlowID == rSignCondition.ProcessFlowID);
                if (rFlowSign != null)
                {
                    //自己不能核自己的單
                    if (rFlowSign.RealAppEmpID == EmpID)
                        rSignCondition.SignComplete = false;

                    rFlowSign.SignCondition = rSignCondition;
                }
            }

            //審核人員切換
            bool FirstData = ListFlowTreeID.Count == 0;

            var rVdb = new FlowSignRoleRow();
            rVdb.maninfo = new ManInfoRow();
            rVdb.Count = rsFlowSign.Count(p => p.CheckEmpID == rVdb.maninfo.EmpID && p.CheckRoleID == rVdb.maninfo.RoleID);
            rVdb.FlowSignForm = new List<FlowSignFormRow>();
            FlowSignFormRow rFlowSignForm = new FlowSignFormRow();
            rFlowSignForm.Count = rsFlowSign.Count;
            rFlowSignForm.FlowSign = rsFlowSign;
            rVdb.FlowSignForm.Add(rFlowSignForm);
            Vdb.Add(rVdb);

            return Vdb;
            //DateTime SignDate1 = SignDate.Length == 0 ? DateTime.Now.Date : Convert.ToDateTime(SignDate).Date;


            //var rs = (from ca in _context.CheckAgentDates
            //          from ft in _context.FlowTrees
            //          join w in _context.Forms on ft.id equals w.FlowTreeId
            //          join r in _context.Roles on ca.Role_idSource equals r.id
            //          join d in _context.Depts on r.Dept_id equals d.id
            //          join p in _context.Pos on r.Pos_id equals p.id
            //          join e in _context.Emps on r.Emp_id equals e.id
            //          where SignDate1 >= r.dateB && SignDate1 <= r.dateE
            //          && ca.Emp_idTarget == SignEmpID
            //          && SignDate1 >= ca.DateB && SignDate1 <= ca.DateE && ca.IsValid
            //          select new
            //          {
            //              FormCode = w.Code,
            //              Sort = r.sort.Value,
            //              MainMan = true,
            //              EmpID = ca.Emp_idSource,
            //              EmpName = e.name,
            //              DeptName = d.name,
            //              PosName = p.name,
            //              RoleID = r.id,
            //              FlowTreeID = ft.id,
            //              FormName = ft.name,
            //              Count =
            //              (from pf in _context.ProcessFlows
            //               where !pf.isFinish.Value
            //               && !pf.isCancel.Value
            //               && !pf.isError.Value
            //               && pf.FlowTree_id == ft.id
            //               && (from pn in _context.ProcessNodes
            //                   where !pn.isFinish.Value
            //                   && pn.ProcessFlow_id.Value == pf.id
            //                   && (from pc in _context.ProcessChecks
            //                       where pc.Emp_idReal == ""
            //                       && pc.Role_idDefault == ca.Role_idSource
            //                       && pc.ProcessNode_auto.Value == pn.auto
            //                       select 1).Any()
            //                   select 1).Any()
            //               select 1).Count()
            //          }).Union(from ft in _context.FlowTrees
            //                   join w in _context.Forms on ft.id equals w.FlowTreeId
            //                   from r in _context.Roles
            //                   join d in _context.Depts on r.Dept_id equals d.id
            //                   join p in _context.Pos on r.Pos_id equals p.id
            //                   join e in _context.Emps on r.Emp_id equals e.id
            //                   where SignDate1 >= r.dateB && SignDate1 <= r.dateE
            //                   && SignEmpID == r.Emp_id
            //                   select new
            //                   {
            //                       FormCode = w.Code,
            //                       Sort = r.sort.Value,
            //                       MainMan = false,
            //                       EmpID = r.Emp_id,
            //                       EmpName = e.name,
            //                       DeptName = d.name,
            //                       PosName = p.name,
            //                       RoleID = r.id,
            //                       FlowTreeID = ft.id,
            //                       FormName = ft.name,
            //                       Count =
            //                       (from pf in _context.ProcessFlows
            //                        where !pf.isFinish.Value
            //                        && !pf.isCancel.Value
            //                        && !pf.isError.Value
            //                        && pf.FlowTree_id == ft.id
            //                        && (from pn in _context.ProcessNodes
            //                            where !pn.isFinish.Value
            //                            && pn.ProcessFlow_id.Value == pf.id
            //                            && (from pc in _context.ProcessChecks
            //                                where pc.Emp_idReal == ""
            //                                && pc.Role_idDefault == r.id
            //                                && pc.ProcessNode_auto.Value == pn.auto
            //                                select 1).Any()
            //                            select 1).Any()
            //                        select 1).Count()
            //                   }).ToList();

            //var Vdb = new List<FlowSignRoleRow>();

            //var rsGroup = rs.GroupBy(p => p.RoleID).OrderByDescending(p => p.Key == SignEmpID).ToList();

            //foreach (var r in rsGroup)
            //{
            //    FlowSignRoleRow rFlowSignRoleRow = new FlowSignRoleRow();
            //    rFlowSignRoleRow.Count = r.Sum(p => p.Count);
            //    rFlowSignRoleRow.BatchSign = true;
            //    rFlowSignRoleRow.EmpID = r.First().EmpID;
            //    rFlowSignRoleRow.EmpName = r.First().EmpName;
            //    rFlowSignRoleRow.DeptName = r.First().DeptName;
            //    rFlowSignRoleRow.PosName = r.First().PosName;
            //    rFlowSignRoleRow.RoleID = r.First().RoleID;
            //    rFlowSignRoleRow.Sort = r.First().Sort;
            //    rFlowSignRoleRow.MainMan = r.First().MainMan;
            //    rFlowSignRoleRow.FlowSignForm = new List<FlowSignFormRow>();

            //    foreach (var r1 in r)
            //    {
            //        FlowSignFormRow rFlowSignFormRow = new FlowSignFormRow();
            //        rFlowSignFormRow.Count = r1.Count;
            //        rFlowSignFormRow.FormName = r1.FormName;
            //        rFlowSignFormRow.FlowTreeID = r1.FlowTreeID;
            //        rFlowSignFormRow.FormCode = r1.FormCode;
            //        rFlowSignRoleRow.FlowSignForm.Add(rFlowSignFormRow);
            //    }

            //    Vdb.Add(rFlowSignRoleRow);
            //}

            ////var Vdb = GetFlowSignRoleFullData(SignEmpID, SignRoleID, RealSignEmpID, RealSignRoleID, "", SignDate);

            ////foreach (var rVdb in Vdb)
            ////    foreach (var rFlowSignForm in rVdb.FlowSignForm)
            ////        rFlowSignForm.FlowSign = null;

            ////dcFlow.Transaction.Commit();
            //return Vdb.OrderByDescending(x => x.Count > 0).ThenByDescending(x => x.EmpID == SignEmpID).ThenBy(x => x.Sort).ToList();
        }
    }



}
