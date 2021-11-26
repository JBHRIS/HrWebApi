﻿using JBHRIS.Api.Dto.Vdb;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace JBHRIS.Api.Service.Interface.ezEngineServices
{
    public interface ICFlowManageInterface
    {

        /// <summary>
        /// 流程重送(含上點重送)
        /// IServiceInterface.FlowStart  重複注入 未解決
        /// IServiceInterface.WorkFinish 重複注入 未解決
        /// </summary>
        /// <param name="lsProcessID">流程編號</param>
        /// <param name="idEmp_Agent">代理啟單人工號</param>
        /// <param name="bPreviousStep">是否上點送重</param>
        /// <returns>List int</returns>
        public List<int> FlowResubmit(List<int> lsProcessID, string idEmp_Agent, bool bPreviousStep = false);
        /// <summary>
        /// 指定簽核人員
        /// </summary>
        /// <param name="lsProcessID"></param>
        /// <param name="Man_Default">簽核者 物件內容可只填工號</param>
        /// <param name="Man_Agent">代理簽核者 物件內容可只填工號</param>
        /// <returns>List int</returns>
        public List<int> FlowSignSet(List<int> lsProcessID, CMan Man_Default = null, CMan Man_Agent = null);

        /// <summary>
        /// 簽核
        /// IServiceInterface.WorkFinish 重複注入 未解決
        /// </summary>
        /// <param name="lsProcessID"></param>
        /// <param name="idEmp">簽核者工號</param>
        /// <param name="sNote">意見</param>
        ///  <param name="bSign">是否核准</param>
        /// <returns>List int</returns>
        public List<int> FlowSignWorkFinish(List<int> lsProcessID, string idEmp, string sNote, bool bSign = true, bool EmpSameUp = true);

        /// <summary>
        /// 簽核
        /// </summary>
        /// <param name="lsProcessID"></param>
        /// <param name="idEmp">簽核者工號</param>
        /// <returns>List int</returns>
        public void FlowSign(List<int> lsProcessID, string idEmp);
        /// <summary>
        /// 刪除整個流程
        /// </summary>
        /// <param name="ProcessFlowId">ProcessFlowId</param>
        /// <returns>bool</returns>
        public bool DeleteProcessFlow(int ProcessFlowId);
        /// <summary>
        /// 流程狀態設定
        /// </summary>
        /// <param name="lsProcessID"></param>
        /// <param name="State">狀態</param>
        /// <param name="idEmp">動作人工號</param>
        /// <returns>List int</returns>
        public List<int> FlowStateSet(List<int> lsProcessID, FlowState State, string idEmp);

    }
}
