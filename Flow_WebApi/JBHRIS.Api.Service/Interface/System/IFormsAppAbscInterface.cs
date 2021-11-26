using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Interface.System
{
    public interface IFormsAppAbscInterface
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProcessFlowID"></param>
        /// <param name="Sign"></param>
        /// <param name="SignState"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        AbsFlowAppRow GetFormsAppAbsByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status);
    }
}
