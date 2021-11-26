using Bll;
using Bll.Share.Vdb;
using Bll.System.Vdb;
using Bll.Token.Vdb;
using Bll.Tools;
using Dal.Dao.System;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dal.Dao
{
    public class DataAccessDao:MainDao
    {
        /// <summary>
        /// 
        /// </summary>
        public DataAccessDao() : base() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public DataAccessDao(IDbConnection conn) : base(conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public DataAccessDao(string ConnectionString) : base(ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcShare"></param>
        public DataAccessDao(dcShareDataContext dcShare) : base(dcShare) { this.dcShare = dcShare; }

        /// <summary>
        /// 新增訊息檢查
        /// </summary>
        /// <param name="TableName">資料表名稱</param>
        /// <param name="ListData">修改或要寫入的資料表</param>
        /// <param name="TableData">資料庫的資料表</param>
        /// <param name="CheckRepeat">檢查重複</param>
        /// <param name="DataHandle">01=新增,02=修改,03=刪除,04=儲存</param>
        /// <returns>List InsertResult</returns>
        public List<Message> DataCheck(string TableName, DataTable ListData, DataTable TableData, bool CheckRepeat = true, string DataHandle = "01")
        {
            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0401000001");  //檢查成功
            ListShareDisplayMessageCode.Add("0402000001");  //檢查失敗
            ListShareDisplayMessageCode.Add("0402000002");  //檢查失敗，找到相同的資料，可能主鍵已存在
            ListShareDisplayMessageCode.Add("0402000003");  //檢查失敗，找不到相同的資料，可能主鍵不存在
            ListShareDisplayMessageCode.Add("0402000004");  //檢查失敗，欄位不允許修改
            ListShareDisplayMessageCode.Add("0402000005");  //檢查失敗，欄位不允許Null
            ListShareDisplayMessageCode.Add("0402000006");  //檢查失敗，欄位不允許空白

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<Message>();
            Message rVdb;

            //欄位設定
            var oSystemColumns = new SystemColumnsDao(dcShare);
            var SystemColumnsCond = new SystemColumnsConditions();
            var ListTablesCode = new List<string>();
            ListTablesCode.Add(TableName);
            SystemColumnsCond.ListTablesCode = ListTablesCode;
            var rsSystemColumns = oSystemColumns.GetSystemColumns(SystemColumnsCond);

            var ListKey = new List<string>();

            //判斷重複
            if (DataHandle == "01" && CheckRepeat)
            {
                var ListKeyColumns = rsSystemColumns.Where(p => p.IsKey).OrderBy(p => p.Sort).ToList();
                if (ListKeyColumns.Count > 0)
                {
                    //取出key的名稱
                    var ListKeyColumn = ListKeyColumns.Select(p => p.Code).ToList();

                    //準備 WhereScript
                    var KeyColumnScript = string.Join(" + ", ListKeyColumn.Select(x => x).ToArray<string>());

                    //組合主鍵
                    foreach (DataRow row in ListData.Rows)
                    {
                        var Key = "";
                        foreach (var ColumnName in ListKeyColumn)
                            Key += row[ColumnName].ToString().Trim();

                        ListKey.Add(Key);
                    }

                    using (var Conn = new SqlConnection(dcShare.Connection.ConnectionString))
                    {
                        Conn.Open();

                        var SqlScript = @"Select " + KeyColumnScript + " As [Key] From " + TableName + "  Where " + KeyColumnScript + " In @Key";
                        var Param = new
                        {
                            Key = ListKey,
                        };
                        ListKey = Conn.Query<string>(SqlScript, Param).ToList();


                        foreach (var Key in ListKey)
                        {
                            rVdb = new Message();
                            rVdb.Code = "0402000002";
                            rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                            rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "檢查失敗，找到相同的資料，可能主鍵已存在";
                            rVdb.Contents += "-" + Key;
                            rVdb.Pass = false;
                            Vdb.Add(rVdb);
                        }
                    }
                }
            }

            foreach (DataRow row in ListData.Rows)
            {
                var AutoKey = Convert.ToInt32(row["AutoKey"]);
                var Code = row["Code"].ToString();

                DataRow[] TableDataRows = TableData.Select("AutoKey = " + AutoKey + " Or Code = '" + Code + "'");

                var Key = AutoKey > 0 ? AutoKey.ToString() : "";
                Key = Code.Length > 0 ? Code : Key;

                if (CheckRepeat)
                    if (DataHandle == "01")
                    {
                        if (TableDataRows.Length > 0)
                        {
                            rVdb = new Message();
                            rVdb.Code = "0402000002";
                            rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                            rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "檢查失敗，找到相同的資料，可能主鍵已存在";
                            rVdb.Contents += "-" + Key;
                            rVdb.Pass = false;
                            Vdb.Add(rVdb);
                        }
                    }
                    else if (DataHandle == "02" || DataHandle == "03")
                    {
                        if (TableDataRows.Length == 0)
                        {
                            rVdb = new Message();
                            rVdb.Code = "0402000003";
                            rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                            rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "檢查失敗，找不到相同的資料，可能主鍵不存在";
                            rVdb.Contents += "-" + Key;
                            rVdb.Pass = false;
                            Vdb.Add(rVdb);
                        }
                    }

                //判斷空白、格式
                foreach (var rSystemColumns in rsSystemColumns)
                {
                    var Name = rSystemColumns.Name;
                    var ColumnName = rSystemColumns.Code;
                    var Value = row[ColumnName];

                    //是否允許修改
                    if (DataHandle == "02" || DataHandle == "04")
                        if (!rSystemColumns.AllowUpdate)
                        {
                            if (TableDataRows.Length > 0)
                            {
                                var OriginalValue = TableDataRows[0][ColumnName];
                                if (Value == OriginalValue)
                                {
                                    rVdb = new Message();
                                    rVdb.Code = "0402000004";
                                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "檢查失敗，欄位不允許修改";
                                    rVdb.Contents += "-Key:" + Key + ",Name:" + Name;
                                    rVdb.Pass = false;
                                    Vdb.Add(rVdb);
                                }
                            }
                        }

                    if (DataHandle != "03")
                    {
                        //不允許Null
                        if (!rSystemColumns.AllowNull)
                        {
                            if (Value == null)
                            {
                                rVdb = new Message();
                                rVdb.Code = "0402000005";
                                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "檢查失敗，欄位不允許Null";
                                rVdb.Contents += "-Key:" + Key + ",Name:" + Name;
                                rVdb.Pass = false;
                                Vdb.Add(rVdb);
                            }
                        }

                        //不允許空白
                        if (!rSystemColumns.AllowEmpty)
                        {
                            if (Convert.ToString(Value).Length == 0)
                            {
                                rVdb = new Message();
                                rVdb.Code = "0402000006";
                                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "檢查失敗，欄位不允許空白";
                                rVdb.Contents += "-Key:" + Key + ",Name:" + Name;
                                rVdb.Pass = false;
                                Vdb.Add(rVdb);
                            }
                        }
                    }
                }
            }

            if (Vdb.Count == 0)
            {
                rVdb = new Message();
                rVdb.Code = "0401000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "檢查成功";
                rVdb.Pass = true;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }


        //    public async Task<APIResult> RelaySendAsync(DataConditions Cond, Dictionary<string, string> dic, HttpMethod httpMethod,
        //        CancellationToken token = default(CancellationToken))
        //    {
        //        var AccessToken = Cond.AccessToken;
        //        var RefreshToken = Cond.RefreshToken;

        //        var mr = new APIResult();

        //        //呼叫api如果失敗要重新取得token 幾次以後就不要再呼叫
        //        var DoCall = true;
        //        var CallFrequency = 1;
        //        SigninRow rSignin = null;
        //        do
        //        {
        //            mr = await this.SendAsync(dic, HttpMethod.Post, token);

        //            //呼叫成功
        //            if (mr != null && mr.Status)
        //                DoCall = false;

        //            //超過系統設定上限次數
        //            if (DoCall && CallFrequency >= Constants.ReCallFrequencyMax)
        //                DoCall = false;

        //            //超過本方法設定上限次數
        //            if (DoCall && CallFrequency >= Cond.ReCallFrequencyMax)
        //                DoCall = false;

        //            if (DoCall)
        //            {
        //                var oRefreshToken = new RefreshTokenDto();
        //                var RefreshTokenCond = new RefreshTokenConditions();
        //                RefreshTokenCond.AccessToken = AccessToken;
        //                RefreshTokenCond.RefreshToken = RefreshToken;
        //                RefreshTokenCond.refreshToken = RefreshToken;
        //                var rs = await oRefreshToken.GetDataAsync(RefreshTokenCond, token);

        //                if (rs.Status)
        //                {
        //                    if (rs.Data != null)
        //                    {
        //                        rSignin = rs.Data as SigninRow;

        //                        AuthenticationHeaderBearerTokenValue = rSignin.AccessToken;
        //                    }
        //                    else
        //                        DoCall = false;
        //                }
        //                else
        //                    DoCall = false;

        //                CallFrequency = CallFrequency + 1;
        //                Thread.Sleep((Constants.ReCallIntervalSec + Cond.ReCallIntervalSec) * 1000);
        //            }
        //        } while (DoCall);

        //        mr.Signin = rSignin;

        //        return mr;
        //    }

        //    public APIResult RelaySend(DataConditions Cond, Dictionary<string, string> dic, HttpMethod httpMethod,
        //CancellationToken token = default(CancellationToken))
        //    {
        //        var AccessToken = Cond.AccessToken;
        //        var RefreshToken = Cond.RefreshToken;

        //        var mr = new APIResult();

        //        //呼叫api如果失敗要重新取得token 幾次以後就不要再呼叫
        //        var DoCall = true;
        //        var CallFrequency = 1;
        //        SigninRow rSignin = null;
        //        do
        //        {
        //            mr = this.SendAsync(dic, HttpMethod.Post, token);

        //            //呼叫成功
        //            if (mr != null && mr.Status)
        //                DoCall = false;

        //            //超過系統設定上限次數
        //            if (DoCall && CallFrequency >= Constants.ReCallFrequencyMax)
        //                DoCall = false;

        //            //超過本方法設定上限次數
        //            if (DoCall && CallFrequency >= Cond.ReCallFrequencyMax)
        //                DoCall = false;

        //            if (DoCall)
        //            {
        //                var oRefreshToken = new RefreshTokenDto();
        //                var RefreshTokenCond = new RefreshTokenConditions();
        //                RefreshTokenCond.AccessToken = AccessToken;
        //                RefreshTokenCond.RefreshToken = RefreshToken;
        //                RefreshTokenCond.refreshToken = RefreshToken;
        //                var rs = oRefreshToken.GetData(RefreshTokenCond, token);

        //                if (rs.Status)
        //                {
        //                    if (rs.Data != null)
        //                    {
        //                        rSignin = rs.Data as SigninRow;

        //                        AuthenticationHeaderBearerTokenValue = rSignin.AccessToken;
        //                    }
        //                    else
        //                        DoCall = false;
        //                }
        //                else
        //                    DoCall = false;

        //                CallFrequency = CallFrequency + 1;
        //                Thread.Sleep((Constants.ReCallIntervalSec + Cond.ReCallIntervalSec) * 1000);
        //            }
        //        } while (DoCall);

        //        mr.Signin = rSignin;

        //        return mr;
        //    }
    }
}