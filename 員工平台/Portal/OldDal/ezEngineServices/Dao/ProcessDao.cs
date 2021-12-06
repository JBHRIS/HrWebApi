using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ezEngineServices.Dao
{
    public class ProcessDao
    {
        private dcFlowDataContext dcFlow;
        private string _ConnectionString;

        public ProcessDao()
        {
            dcFlow = new dcFlowDataContext();
            _ConnectionString = dcFlow.Connection.ConnectionString;
        }

        /// <summary>
        /// ProcessDao
        /// </summary>
        /// <param name="conn"></param>
        public ProcessDao(IDbConnection conn)
        {
            _ConnectionString = conn.ConnectionString;
            dcFlow = new dcFlowDataContext(conn);
        }

        /// <summary>
        /// ProcessDao
        /// </summary>
        /// <param name="ConnectionString"></param>
        public ProcessDao(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            dcFlow = new dcFlowDataContext(ConnectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public ProcessDao(dcFlowDataContext dcFlow)
        {
            _ConnectionString = dcFlow.Connection.ConnectionString;
            this.dcFlow = dcFlow;
        }
    }
}