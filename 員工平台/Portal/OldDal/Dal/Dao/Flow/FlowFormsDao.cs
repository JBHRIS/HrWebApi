using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OldBll.Flow.Vdb;
using OldDal.Entity;
using System.Data.SqlClient;

namespace OldDal.Dao.Flow
{
    public class FlowFormsDao
    {
        private OldDal.Entity.dcFlowDataContext dcFlow = new Entity.dcFlowDataContext();

        /// <summary>
        /// 表單資料
        /// </summary>
        /// <param name="conn">連接字串 沒有等於預設</param>
        public FlowFormsDao(IDbConnection conn = null)
        {
            dcFlow = new Entity.dcFlowDataContext();

            if (conn != null)
                dcFlow = new Entity.dcFlowDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 表單資料
        /// </summary>
        /// <param name="ConnectionString">連接字串 沒有等於預設</param>
        public FlowFormsDao(string ConnectionString = null)
        {
            dcFlow = new Entity.dcFlowDataContext();

            if (ConnectionString != null)
                dcFlow = new Entity.dcFlowDataContext(ConnectionString);
        }

        /// <summary>
        /// 表單請假資料
        /// </summary>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="sCat">請假類別0 = 不分,1 = 請假,2 = 公出</param>
        /// <param name="lsDept">部門List 忽略此條件需傳入null或是0筆資料的物件</param>
        /// <param name="lsNobr">工號List 忽略此條件需傳入null或是0筆資料的物件</param>
        /// <param name="lsState">狀態List 忽略此條件需傳入null或是0筆資料的物件1=進行中, 2=駁回, 3=完成</param>
        /// <returns>List</returns>
        public List<FlowAbsTable> GetFlowAbs(DateTime dDateB, DateTime dDateE, string sCat = "0", List<string> lsDept = null, List<string> lsNobr = null, List<string> lsState = null)
        {
            return GetFlowAbs(dDateB, dDateE, "", sCat, lsDept, lsNobr, lsState);
        }

        /// <summary>
        /// 表單請假資料
        /// </summary>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="sHcode">假別代碼 空白 = 全部</param>
        /// <param name="sCat">請假類別0 = 不分,1 = 請假,2 = 公出</param>
        /// <param name="lsDept">部門List 忽略此條件需傳入null或是0筆資料的物件</param>
        /// <param name="lsNobr">工號List 忽略此條件需傳入null或是0筆資料的物件</param>
        /// <param name="lsState">狀態List 忽略此條件需傳入null或是0筆資料的物件1=進行中, 2=駁回, 3=完成</param>
        /// <returns>List</returns>
        public List<FlowAbsTable> GetFlowAbs(DateTime dDateB, DateTime dDateE, string sHcode = "", string sCat = "0", List<string> lsDept = null, List<string> lsNobr = null, List<string> lsState = null)
        {
            if (lsDept == null)
                lsDept = new List<string>();

            if (lsNobr == null)
                lsNobr = new List<string>();

            if (lsState == null)
                lsState = new List<string>();

            List<string> lsAbsCat = new List<string>();

            if (sCat == "0")
            {
                lsAbsCat.Add("Abs");
                lsAbsCat.Add("Abs1");
            }
            else if (sCat == "2")
                lsAbsCat.Add("Abs1");
            else
                lsAbsCat.Add("Abs");

            //var lsProcessID = (from c in dcFlow.wfFormApp
            //                   where (lsState.Count == 0 || lsState.Contains(c.sState))
            //                   && lsAbsCat.Contains(c.sFormCode)
            //                   select c.sProcessID).ToList();

            //var Vdb = from c in dcFlow.wfAppAbs
            //          where c.idProcess != 0
            //          && (lsState.Count == 0 || lsState.Contains(c.sState))
            //          && (sHcode == "" || c.sHcode == sHcode)
            //          && (lsDept.Contains(c.sDept) || lsDept.Count == 0)
            //          && (lsNobr.Contains(c.sNobr) || lsNobr.Count == 0)
            //          && dDateB.Date <= c.dDateE.Date
            //          && dDateE.Date >= c.dDateB.Date
            //          select new FlowAbsTable
            //          {
            //              ProcessID = c.idProcess,
            //              ApViewID = 0,
            //              ViewUrl = string.Empty,
            //              Nobr = c.sNobr,
            //              NameC = "<span title='" + c.sNobr + "," + c.idProcess + "'>" + c.sName + "</span>",
            //              NameE = "<span title='" + c.sNobr + "," + c.idProcess + "'>" + c.sName + "</span>",
            //              DateB = c.dDateB,
            //              DateE = c.dDateE,
            //              TimeB = c.sTimeB,
            //              TimeE = c.sTimeE,
            //              Hcode = c.sHcode,
            //              HcodeName = c.sHname,
            //              TotalDay = c.iTotalDay,
            //              TotalHour = c.iTotalHour,
            //              Unit = string.Empty,
            //              Note = c.sNote,
            //              YYMM = c.sSalYYMM,
            //              State = c.sState,
            //              Approver = string.Empty,
            //              FlowAbsdD = c.sReserve3,
            //          };

            var Vdb = from c in dcFlow.AbsView
                      where c.idProcess != 0
                          && (lsState.Count == 0 || lsState.Contains(c.sState))
                          && (sHcode == "" || c.sHcode == sHcode)
                          && (lsDept.Contains(c.sDept) || lsNobr.Contains(c.sNobr))
                          && dDateB.Date <= c.dDateE.Date
                          && dDateE.Date >= c.dDateB.Date
                      select new FlowAbsTable
                      {
                          ProcessID = c.idProcess.Value,
                          ApViewID = 0,
                          ViewUrl = string.Empty,
                          Nobr = c.sNobr,
                          NameC = "<span title='" + c.sNobr + "," + c.idProcess.Value + "'>" + c.sName + "</span>",
                          NameE = "<span title='" + c.sNobr + "," + c.idProcess.Value + "'>" + c.sName + "</span>",
                          DateB = c.dDateB,
                          DateE = c.dDateE,
                          TimeB = c.sTimeB,
                          TimeE = c.sTimeE,
                          Hcode = c.sHcode,
                          HcodeName = c.sHname,
                          TotalDay = c.TotalHour.Value,
                          TotalHour = c.TotalHour.Value,
                          Unit = string.Empty,
                          Note = c.Remark,
                          YYMM = string.Empty,
                          State = c.sState,
                          Approver = string.Empty,
                          FlowAbsdD = c.FlowAbsdD,
                          Dept = c.sDept,
                          DeptName = c.sDeptName,
                      };

            //子查詢條件
            var rsFormSignM = (from a in dcFlow.wfFormSignM
                               where (from b in Vdb where a.idProcess == b.ProcessID select 1).Any()
                               select new { a.idProcess, a.sName }).ToList();

            //子查詢找出ApViewID
            var rsProcessApView = (from a in dcFlow.ProcessApView
                                   where (from b in Vdb where a.ProcessFlow_id == b.ProcessID select 1).Any()
                                   select new { a.ProcessFlow_id, a.auto }).ToList();

            var vdb1 = Vdb.ToList();

            MainDao oMainDao = new MainDao(dcFlow.Connection);

            string sUrl = "";

            foreach (var rVdb in vdb1)
            {
                var rsFormSignMWhere = from a in rsFormSignM where a.idProcess == rVdb.ProcessID select a;
                foreach (var rFormSignMWhere in rsFormSignMWhere)
                    rVdb.Approver += rFormSignMWhere.sName + ",";

                //把最後的逗號拿掉
                if (rVdb.Approver.Length > 0)
                    rVdb.Approver = rVdb.Approver.Substring(0, rVdb.Approver.Length - 1);

                //填入檢視網址
                var rProcessApView = (from a in rsProcessApView where a.ProcessFlow_id == rVdb.ProcessID select a).FirstOrDefault();
                if (sUrl == "" && rProcessApView != null)
                    sUrl = oMainDao.GetFlowViewUrlOnlyUrl(rProcessApView.auto);
                else if (rProcessApView != null)
                    rVdb.ViewUrl = sUrl + rProcessApView.auto.ToString();

                //if (rProcessApView != null)
                //    rVdb.ViewUrl = oMainDao.GetFlowViewUrl(rProcessApView.auto);

                if (rVdb.FlowAbsdD != null && rVdb.FlowAbsdD.Length > 0)
                    rVdb.FlowAbsd = GetFlowAbsd(rVdb.FlowAbsdD, rVdb.ProcessID);
            }

            return vdb1;
        }

        /// <summary>
        /// 取得請假明細
        /// </summary>
        /// <param name="sAbsd">長字串</param>
        /// <returns>List</returns>
        public List<FlowAbsdTable> GetFlowAbsd(string sAbsd,int pid=0)
        {
            var Vdb = new List<FlowAbsdTable>();

            var t = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Newtonsoft.Json.Linq.JObject>>(sAbsd);

            foreach (var i in t)
            {
                var hr = 0m;
                decimal.TryParse(i.SelectToken("hr").ToString(),out hr);

                Vdb.Add(new FlowAbsdTable()
                {
                    SernoAdd = i.SelectToken("pid").ToString(),
                    SernoSubtract = pid.ToString(),
                    UseHour =  hr
                });
            }

            return Vdb;
        }


        /// <summary>
        /// 表單加班資料
        /// </summary>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="lsDept">部門List 忽略此條件需傳入null或是0筆資料的物件</param>
        /// <param name="lsNobr">工號List 忽略此條件需傳入null或是0筆資料的物件</param>
        /// <param name="lsState">狀態List 忽略此條件需傳入null或是0筆資料的物件1=進行中, 2=駁回, 3=完成</param>
        /// <returns>List</returns>
        public List<FlowOtTable> GetFlowOt(DateTime dDateB, DateTime dDateE, List<string> lsDept = null, List<string> lsNobr = null, List<string> lsState = null)
        {
            return GetFlowOt(dDateB, dDateE, lsDept, lsNobr, lsState, null);
        }

        /// <summary>
        /// 表單加班資料
        /// </summary>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="lsDept">部門List 忽略此條件需傳入null或是0筆資料的物件</param>
        /// <param name="lsNobr">工號List 忽略此條件需傳入null或是0筆資料的物件</param>
        /// <param name="lsState">狀態List 忽略此條件需傳入null或是0筆資料的物件1=進行中, 2=駁回, 3=完成</param>
        /// <param name="lsOtType">加班類別List 忽略此條件需傳入null或是0筆資料的物件</param>
        /// <returns>List</returns>
        public List<FlowOtTable> GetFlowOt(DateTime dDateB, DateTime dDateE, List<string> lsDept = null, List<string> lsNobr = null, List<string> lsState = null, List<string> lsOtType = null)
        {
            if (lsDept == null)
                lsDept = new List<string>();

            if (lsNobr == null)
                lsNobr = new List<string>();

            if (lsState == null)
                lsState = new List<string>();

            if (lsOtType == null)
                lsOtType = new List<string>();

            //var Vdb = from c in dcFlow.wfAppOt
            //          where c.idProcess != 0
            //          && (lsState.Count == 0 || lsState.Contains(c.sState))
            //          && (lsDept.Contains(c.sDept) || lsDept.Count == 0)
            //          && (lsNobr.Contains(c.sNobr) || lsNobr.Count == 0)
            //          && ((c.sOtrcdName.IndexOf(",") != -1 && lsOtType.Contains(c.sOtrcdName.Substring(0, c.sOtrcdName.IndexOf(","))))
            //          || lsOtType.Count == 0 || c.sOtcatName.Trim() == string.Empty)
            //          && dDateB.Date <= c.dDateE.Date
            //          && dDateE.Date >= c.dDateB.Date
            //          select new FlowOtTable
            //          {
            //              ProcessID = c.idProcess,
            //              ApViewID = 0,
            //              ViewUrl = string.Empty,
            //              Nobr = c.sNobr,
            //              NameC = "<span title='" + c.sNobr + "," + c.idProcess + "'>" + c.sName + "</span>",
            //              NameE = "<span title='" + c.sNobr + "," + c.idProcess + "'>" + c.sName + "</span>",
            //              DateB = c.dDateB,
            //              DateE = c.dDateE,
            //              TimeB = c.sTimeB,
            //              TimeE = c.sTimeE,
            //              TotalHour = c.iTotalHour,
            //              OtHour = c.sOtcatCode.Length > 0 ? Convert.ToDecimal(c.sOtcatCode) : 0,
            //              ResHour = c.sOtrcdCode.Length > 0 ? Convert.ToDecimal(c.sOtrcdCode) : 0,
            //              Note = c.sNote,
            //              YYMM = c.sSalYYMM,
            //              OtTypeCode = c.sOtrcdName,
            //              OtTypeName = string.Empty,
            //              State = c.sState,
            //              Approver = string.Empty,
            //          };

            var Vdb = from c in dcFlow.OtView
                      where c.idProcess != 0
                      && (lsState.Count == 0 || lsState.Contains(c.sState))
                      && (lsDept.Contains(c.sDept) || lsNobr.Contains(c.sNobr))
                      && ((c.OtType.IndexOf(",") != -1 && lsOtType.Contains(c.OtType.Substring(0, c.OtType.IndexOf(","))))
                      || lsOtType.Count == 0 || c.OtType.Trim() == string.Empty)
                      && dDateB.Date <= c.dDateE.Value.Date
                      && dDateE.Date >= c.dDateB.Value.Date
                      select new FlowOtTable
                      {
                          ProcessID = c.idProcess.Value,
                          ApViewID = 0,
                          ViewUrl = string.Empty,
                          Nobr = c.sNobr,
                          NameC = "<span title='" + c.sNobr + "," + c.idProcess.Value + "'>" + c.sName + "</span>",
                          NameE = "<span title='" + c.sNobr + "," + c.idProcess.Value + "'>" + c.sName + "</span>",
                          DateB = c.dDateB.Value,
                          DateE = c.dDateE.Value,
                          TimeB = c.sTimeB,
                          TimeE = c.sTimeE,
                          TotalHour = c.TotalHours,
                          OtHour = c.OtHours.Value,
                          ResHour = c.RestHours.Value,
                          Note = c.Remark,
                          YYMM = c.YYMM,
                          OtTypeCode = c.OtType,
                          OtTypeName = string.Empty,
                          State = c.sState,
                          Approver = string.Empty,
                          Dept = c.sDept,
                          DeptName = c.sDeptName,
                      };

            //子查詢條件
            var rsFormSignM = (from a in dcFlow.wfFormSignM
                               where (from b in Vdb where a.idProcess == b.ProcessID select 1).Any()
                               select new { a.idProcess, a.sName }).ToList();

            //子查詢找出ApViewID
            var rsProcessApView = (from a in dcFlow.ProcessApView
                                   where (from b in Vdb where a.ProcessFlow_id == b.ProcessID select 1).Any()
                                   select new { a.ProcessFlow_id, a.auto }).ToList();

            var vdb1 = Vdb.ToList();

            MainDao oMainDao = new MainDao(dcFlow.Connection);

            foreach (var rVdb in vdb1)
            {
                var rsFormSignMWhere = from a in rsFormSignM where a.idProcess == rVdb.ProcessID select a;
                foreach (var rFormSignMWhere in rsFormSignMWhere)
                    rVdb.Approver += rFormSignMWhere.sName + ",";

                //把最後的逗號拿掉
                if (rVdb.Approver.Length > 0)
                    rVdb.Approver = rVdb.Approver.Substring(0, rVdb.Approver.Length - 1);

                //填入檢視網址
                var rProcessApView = (from a in rsProcessApView where a.ProcessFlow_id == rVdb.ProcessID select a).FirstOrDefault();
                if (rProcessApView != null)
                    rVdb.ViewUrl = oMainDao.GetFlowViewUrl(rProcessApView.auto);

                var arrOtTypeCode = rVdb.OtTypeCode.Split(',');
                if (arrOtTypeCode.Count() == 2)
                {
                    rVdb.OtTypeCode = arrOtTypeCode[0].Trim();
                    rVdb.OtTypeName = arrOtTypeCode[1].Trim();
                }
            }

            return vdb1;
        }

        /// <summary>
        /// 重設表單流程(開始步驟)
        /// </summary>
        /// <param name="iProcessID">ProcessID</param>
        /// <param name="RoleID">角色代碼</param>
        /// <param name="EmpID">工號代碼</param>
        /// <param name="FlowTreeID">流程樹</param>
        /// <returns>string</returns>
        public string SetResetFormBegin(int iProcessID, out string RoleID, out string EmpID, out string FlowTreeID)
        {
            RoleID = "";
            EmpID = "";
            FlowTreeID = "";

            string sGuid = Guid.NewGuid().ToString();

            DataTable dt = null;

            //流程編號必須大於1 因為1是匯入的資料
            if (iProcessID > 1)
            {
                var rFormApp = (from c in dcFlow.wfFormApp
                                where c.idProcess == iProcessID
                                select c).FirstOrDefault();

                if (rFormApp != null)
                {
                    var rForm = (from p in dcFlow.wfForm
                                 where p.sFormCode.ToUpper() == rFormApp.sFormCode.ToUpper()
                                 select p).FirstOrDefault();

                    if (rForm != null)
                    {
                        var rFormAppNew = new wfFormApp();
                        OldBll.Tools.DefaultData.CloneProperties(rFormApp, rFormAppNew);
                        rFormAppNew.idProcess = 0;
                        rFormAppNew.sProcessID = sGuid;
                        rFormAppNew.sState = "4";
                        dcFlow.wfFormApp.InsertOnSubmit(rFormAppNew);

                        var rRole = (from c in dcFlow.Role
                                     where c.Emp_id == rFormAppNew.sNobr
                                     select c).FirstOrDefault();

                        if (rRole != null)
                        {
                            rFormAppNew.sRole = rRole.id;

                            using (SqlConnection conn = new SqlConnection(dcFlow.Connection.ConnectionString))
                            {
                                conn.Open();
                                using (SqlDataAdapter da = new SqlDataAdapter(
                                    "Select * From " + rForm.s4 + " Where idProcess = " + iProcessID, conn))
                                {
                                    dt = new DataTable();
                                    da.Fill(dt);

                                    foreach (DataRow r in dt.Rows)
                                    {
                                        r["idProcess"] = 0;
                                        r["sProcessID"] = sGuid;
                                        r["sState"] = "4";
                                    }

                                    using (SqlBulkCopy sqlBC = new SqlBulkCopy(conn))
                                    {
                                        //設定一個批次量寫入多少筆資料
                                        sqlBC.BatchSize = 1000;
                                        //設定逾時的秒數
                                        sqlBC.BulkCopyTimeout = 60;

                                        //設定 NotifyAfter 屬性，以便在每複製 10000 個資料列至資料表後，呼叫事件處理常式。
                                        sqlBC.NotifyAfter = 10000;
                                        //sqlBC.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsCopied);

                                        //設定要寫入的資料庫
                                        sqlBC.DestinationTableName = rForm.s4;

                                        //對應資料行
                                        //sqlBC.ColumnMappings.Add("id", "id");
                                        //sqlBC.ColumnMappings.Add("name", "name");

                                        //開始寫入
                                        sqlBC.WriteToServer(dt);
                                        dcFlow.SubmitChanges();

                                        RoleID = rFormAppNew.sRole;
                                        EmpID = rFormAppNew.sNobr;
                                        FlowTreeID = rForm.sFlowTree;
                                    }
                                    conn.Dispose();
                                }
                            }
                        }
                    }
                }
            }

            return sGuid;
        }

        /// <summary>
        /// 重設表單流程(開始步驟)
        /// </summary>
        /// <param name="sProcessID">Guid ProcessID</param>
        /// <param name="iProcessID">New ProcessID</param>
        /// <param name="iProcessIDOld">Old ProcessID</param>
        /// <returns>string</returns>
        public bool SetResetFormAfter(string sProcessID, int iProcessID, int iProcessIDOld)
        {
            bool bPass = false;

            List<int> lsProcessID = new List<int>();
            lsProcessID.Add(iProcessIDOld);

            var rFormApp = (from c in dcFlow.wfFormApp
                            where c.sProcessID == sProcessID
                            select c).FirstOrDefault();

            if (rFormApp != null)
            {
                var rForm = (from p in dcFlow.wfForm
                             where p.sFormCode.ToUpper() == rFormApp.sFormCode.ToUpper()
                             select p).FirstOrDefault();

                if (rForm != null)
                {
                    //寫入動態成員
                    if (rFormApp.sReserve3 != null && rFormApp.sReserve3.Length > 0)
                    {
                        var rRole = (from c in dcFlow.Role
                                     where c.Emp_id == rFormApp.sReserve3
                                     select c).FirstOrDefault();

                        if (rRole != null)
                        {
                            var rDynamic = new wfDynamic();
                            rDynamic.idProcess = iProcessID;
                            rDynamic.idFlowNode = rForm.s1;
                            rDynamic.Role_id = rRole.id;
                            rDynamic.Emp_id = rFormApp.sReserve3;
                            dcFlow.wfDynamic.InsertOnSubmit(rDynamic);

                            rFormApp.idProcess = iProcessID;
                            rFormApp.sProcessID = rFormApp.idProcess.ToString();
                            rFormApp.sState = "1";

                            try
                            {
                                dcFlow.ExecuteCommand("Update " + rForm.s4 + " Set idProcess = " + iProcessID + ", sProcessID = '" + iProcessID.ToString() + "', sState = '1' Where sProcessID = '" + sProcessID + "'");
                                dcFlow.SubmitChanges();
                                SetCancelForm(lsProcessID);

                                bPass = true;
                            }
                            catch
                            {
                                //如果有錯就還原回來
                                dcFlow.ExecuteCommand("Update " + rForm.s4 + " Set idProcess = 0 ,sProcessID = '" + sProcessID + "', sState = '4' Where idProcess = " + iProcessID);
                                SetCancelForm(lsProcessID, false);
                            }
                        }
                    }
                }
            }
            return bPass;
        }

        /// <summary>
        /// 設定表單作業
        /// </summary>
        /// <param name="lsProcessID">List ProcessID</param>
        /// <param name="bCancel">True = 取消流程</param>
        /// <returns>List int</returns>
        public List<int> SetCancelForm(List<int> lsProcessID, bool bCancel = true)
        {
            List<int> Vdb = new List<int>();

            var rsForm = dcFlow.wfForm.ToList();

            string State = bCancel ? "4" : "1";

            var rsProcessFlow = (from c in dcFlow.ProcessFlow
                                 where lsProcessID.Contains(c.id)
                                 select c).ToList();

            foreach (int iProcessID in lsProcessID)
            {
                //流程編號必須大於1 因為1是匯入的資料
                if (iProcessID > 1)
                {
                    var rFormApp = (from c in dcFlow.wfFormApp
                                    where c.idProcess == iProcessID
                                    select c).FirstOrDefault();

                    if (rFormApp != null)
                        rFormApp.sState = State;

                    var rProcessFlow = rsProcessFlow.Where(p => p.id == iProcessID).FirstOrDefault();
                    if (rProcessFlow != null)
                    {
                        rProcessFlow.isCancel = bCancel;
                        dcFlow.SubmitChanges();

                        var rForm = rsForm.Where(p => p.sFlowTree == rProcessFlow.FlowTree_id).FirstOrDefault();

                        if (rForm != null)
                        {
                            int iCount = dcFlow.ExecuteCommand("Update " + rForm.s4 + " Set sState = '" + State + "' Where idProcess = " + iProcessID);

                            if (iCount > 0)
                                if (!Vdb.Contains(iProcessID))
                                    Vdb.Add(iProcessID);
                        }
                    }
                    else
                    {
                        foreach (var rForm in rsForm)
                        {
                            int iCount = dcFlow.ExecuteCommand("Update " + rForm.s4 + " Set sState = '" + State + "' Where idProcess = " + iProcessID);

                            if (iCount > 0)
                                Vdb.Add(iProcessID);
                        }
                    }
                }
            }

            //string dtName = "";

            //var rForm = rsForm.Where(p => p.sFormCode == "").FirstOrDefault();

            //switch (FormName)
            //{
            //    case FormCategroy.Abs:
            //        rForm = rsForm.Where(p => p.sFormCode == "Abs").FirstOrDefault();
            //        break;
            //    case FormCategroy.Abs1:
            //        rForm = rsForm.Where(p => p.sFormCode == "Abs1").FirstOrDefault();
            //        break;
            //    case FormCategroy.Absc:
            //        rForm = rsForm.Where(p => p.sFormCode == "Absc").FirstOrDefault();
            //        break;
            //    case FormCategroy.Ot:
            //        rForm = rsForm.Where(p => p.sFormCode == "Ot").FirstOrDefault();
            //        break;
            //    case FormCategroy.Card:
            //        rForm = rsForm.Where(p => p.sFormCode == "Card").FirstOrDefault();
            //        break;
            //    case FormCategroy.ShiftLong:
            //        rForm = rsForm.Where(p => p.sFormCode == "ShiftLong").FirstOrDefault();
            //        break;
            //    case FormCategroy.ShiftShort:
            //        rForm = rsForm.Where(p => p.sFormCode == "ShiftShort").FirstOrDefault();
            //        break;
            //}

            //if (rForm != null)
            //    dtName = rForm.s4;

            //if (dtName.Trim().Length > 0)
            //{
            //    foreach (var iProcessID in lsProcessID)
            //    {
            //        //因為所有舊的表單流程都是1號
            //        if (iProcessID > 1)
            //        {
            //            int iCount = dcFlow.ExecuteCommand("Update " + dtName + " Set sState = '" + State + "' Where idProcess = " + iProcessID);
            //            if (iCount > 0)
            //                Vdb.Add(iProcessID);
            //        }
            //    }
            //}

            return Vdb;
        }

        /// <summary>
        /// 設定表單作業
        /// </summary>
        /// <param name="FormName">表單類別</param>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">日期</param>
        /// <param name="sTimeB">時間</param>
        /// <param name="sType">假別或加班類別...</param>
        /// <param name="bCancel">是否取消流程 True = 取消</param>
        /// <returns>List int</returns>
        public List<int> SetCancelForm(FormCategroy FormName, string sNobr, DateTime dDateB, string sTimeB, string sType = "", bool bCancel = true)
        {
            int iPass = 0;

            string State = bCancel ? "4" : "1";

            List<int> lsProcessID = new List<int>();

            switch (FormName)
            {
                case FormCategroy.Abs:
                    var rsAbs = (from c in dcFlow.wfAppAbs
                                 where c.sNobr == sNobr
                                 && c.dDateB.Date == dDateB
                                 && c.sTimeB == sTimeB
                                 && c.sHcode == sType
                                 select c).ToList();

                    foreach (var r in rsAbs)
                    {
                        lsProcessID.Add(r.idProcess);

                        r.sState = State;
                        iPass++;
                    }

                    break;
                case FormCategroy.Ot:
                    var rsOt = (from c in dcFlow.wfAppOt
                                where c.sNobr == sNobr
                                && c.dDateB.Date == dDateB
                                && c.sTimeB == sTimeB
                                select c).ToList();

                    foreach (var r in rsOt)
                    {
                        lsProcessID.Add(r.idProcess);

                        r.sState = State;
                        iPass++;
                    }

                    break;
            }

            SetCancelForm(lsProcessID, bCancel);

            dcFlow.SubmitChanges();

            return lsProcessID;
        }

        /// <summary>
        /// 存入審核資訊
        /// </summary>
        /// <param name="iApParm">iApParmID</param>
        /// <param name="iProcessID">iProcessID</param>
        /// <param name="sSignNobr">審核者工號</param>
        /// <param name="sNote">備註</param>
        /// <param name="bSign">是否核准</param>
        /// <returns>bool</returns>
        public bool SetFormSignM(int iApParm, int iProcessID, string sSignNobr, string sNote = "", bool bSign = true)
        {
            var rBase = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == sSignNobr
                         select new { role, emp, dept, pos }).FirstOrDefault();

            var rFormApp = (from c in dcFlow.wfFormApp
                            where c.idProcess == iProcessID
                            select c).FirstOrDefault();

            if (rBase == null || rFormApp == null)
                return false;


            var sDept = (from pc in dcFlow.ProcessCheck
                         join pn in dcFlow.ProcessNode on pc.ProcessNode_auto equals pn.auto
                         join role in dcFlow.Role on pc.Role_idDefault equals role.id
                         where pn.ProcessFlow_id == iProcessID
                         && (pc.Emp_idDefault == sSignNobr || pc.Emp_idAgent == sSignNobr)
                         orderby pc.auto descending
                         select role.Dept_id).FirstOrDefault();

            string sOrder = "00";
            if (sDept != null)
            {
                var sTree = dcFlow.Dept.Where(p => p.id == sDept).FirstOrDefault();
                if (sTree != null)
                    sOrder = sTree.DeptLevel_id;
            }

            rFormApp.sConditions1 = sOrder;

            var rSignM = (from c in dcFlow.wfFormSignM
                          where c.idProcess == iProcessID
                          && c.sNobr == sSignNobr
                          select c).FirstOrDefault();

            if (rSignM == null)
            {
                rSignM = new wfFormSignM();
                dcFlow.wfFormSignM.InsertOnSubmit(rSignM);
            }

            rSignM.sFormCode = rFormApp.sFormCode;
            rSignM.sFormName = rFormApp.sFormName;
            rSignM.sKey = Guid.NewGuid().ToString();
            rSignM.sProcessID = iProcessID.ToString();
            rSignM.idProcess = iProcessID;
            rSignM.sNobr = sSignNobr;
            rSignM.sName = rBase == null ? "" : rBase.emp.name;
            rSignM.sRole = rBase == null ? "" : rBase.role.id;
            rSignM.sDept = rBase == null ? "" : rBase.dept.id;
            rSignM.sDeptName = rBase == null ? "" : rBase.dept.name;
            rSignM.sJob = rBase == null ? "" : rBase.pos.id;
            rSignM.sJobName = rBase == null ? "" : rBase.pos.name;
            rSignM.sNote = sNote;
            rSignM.bSign = bSign;
            rSignM.dKeyDate = DateTime.Now;

            //被駁回的表單直接結束流程
            if (!bSign)
            {
                var rProcessFlow = (from c in dcFlow.ProcessFlow
                                    where c.id == iProcessID
                                    select c).FirstOrDefault();

                if (rProcessFlow != null)
                    rProcessFlow.isCancel = true;
            }

            dcFlow.SubmitChanges();

            return true;
        }
    }
}