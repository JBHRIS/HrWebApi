using JBHRIS.Api.Dto.Vdb;
using JBHRIS.Api.Service.Interface.ezEngineServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flow_WebApi.Controllers.ezEngineServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class CProcessController : ControllerBase
    {



        //private ICProcessInterface _ICProcessInterface;


        public CProcessController() //ICProcessInterface iCProcessInterface
        {
            //this._ICProcessInterface = iCProcessInterface;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProcessNode_Prior"></param>
        /// <param name="idProcess"></param>
        /// <param name="idFlowNode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CreateProcessNode")]
        public int CreateProcessNode(int idProcessNode_Prior, int idProcess, string idFlowNode)
        {


            //return this._ICProcessInterface.CreateProcessNode( idProcessNode_Prior, idProcess, idFlowNode); 

            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProcessNode_Prior"></param>
        /// <param name="idProcess"></param>
        /// <param name="idFlowNode"></param>
        /// <param name="Man_Default"></param>
        /// <param name="Man_Agent"></param>
        /// <param name="idEmpSource"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("WriteProcessNodeAndCheck")]
        public int WriteProcessNodeAndCheck()
        {
            //int idProcessNode_Prior, int idProcess, string idFlowNode, CMan Man_Default, CMan Man_Agent, string idEmpSource
            //return this._ICProcessInterface.CreateProcessNode(idProcessNode_Prior, idProcess, idFlowNode);
            return 0;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProcessID")]
        public int GetProcessID()
        {

            //return this._ICProcessInterface.GetProcessID();
            return 0;
        }


    }
}
