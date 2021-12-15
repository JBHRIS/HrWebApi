using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flow_WebApi
{
    public class IoCConfig
    {

        public IoCConfig()
        {

        }

        /// <summary>
        /// 設定註冊服務
        /// </summary>
        /// <param name="Configuration">設定檔</param>
        /// <param name="services">服務集合</param>
        /// <returns></returns>
        public static IServiceCollection Configure(IConfiguration Configuration, IServiceCollection services)
        {

            // DB_ConnectionStrings
            //services.AddDbContext<JBHRIS.Api.Dal.HRM.Entity.HR.JBHRContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:HRConnectionStrings"]));
            services.AddDbContext<JBHRIS.Api.Dal.ezFlow.Entity.ezFlow.ezFlowContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ezFlowConnectionStrings"]));
            //services.AddDbContext<JBHRIS.Api.Dal.OldezFlow.Entity.ezFlow.OldezFlowContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:OldezFlowConnectionStrings"]));
			services.AddDbContext<JBHRIS.Api.Dal.ezFlow.Entity.Share.ShareContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ShareConnectionStrings"]));																																								   



            //1-1.Service
            services.AddScoped<JBHRIS.Api.Service.Interface.ITestInterface, JBHRIS.Api.Service.Implement.TestService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IDeptInterface, JBHRIS.Api.Service.Implement.System.DeptService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IFormsInterface, JBHRIS.Api.Service.Implement.System.FormsService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IGetEmpInterface, JBHRIS.Api.Service.Implement.System.GetEmpService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IHcodeInterface, JBHRIS.Api.Service.Implement.System.HcodeService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IOtrcdInterface, JBHRIS.Api.Service.Implement.System.OtrcdService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IRoleInterface, JBHRIS.Api.Service.Implement.System.RoleService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IFormsAppInterface, JBHRIS.Api.Service.Implement.System.FormsAppService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IFormAppOTInterface, JBHRIS.Api.Service.Implement.System.FormAppOTService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IFormsAppAbnInterface, JBHRIS.Api.Service.Implement.System.FormsAppAbnService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IFormsAppAbscInterface, JBHRIS.Api.Service.Implement.System.FormsAppAbscService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IFormsAppAbsInterface, JBHRIS.Api.Service.Implement.System.FormsAppAbsService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IFormsAppAppointInterface, JBHRIS.Api.Service.Implement.System.FormsAppAppointService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IFormsAppCardInterface, JBHRIS.Api.Service.Implement.System.FormsAppCardService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IFormsAppEmployInterface, JBHRIS.Api.Service.Implement.System.FormsAppEmployService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IFormsAppShiftShortInterface, JBHRIS.Api.Service.Implement.System.FormsAppShiftShortService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IFormsAppShiftLongInterface, JBHRIS.Api.Service.Implement.System.FormsAppShiftLongService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IFormsAppInfoInterface, JBHRIS.Api.Service.Implement.System.FormsAppInfoService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IProcessIdInterface, JBHRIS.Api.Service.Implement.System.ProcessIdService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.ISysVarInterface, JBHRIS.Api.Service.Implement.System.SysVarService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.IFlowControlInterface, JBHRIS.Api.Service.Implement.System.FlowControlService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.QuestionDefaultMessageInterFace, JBHRIS.Api.Service.Implement.System.QuestionDefaultMessageService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.QuestionMainInterFace, JBHRIS.Api.Service.Implement.System.QuestionMainService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.QuestionReplyInterFace, JBHRIS.Api.Service.Implement.System.QuestionReplyService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.System.QuestionCategoryInterFace, JBHRIS.Api.Service.Implement.System.QuestionCategoryService>();
            services.AddScoped<JBHRIS.Api.Service.Interface.FlowMainInte.IFlowMainIntegrationHandleInterface, JBHRIS.Api.Service.Implement.FlowMainInte.FlowMainIntegrationHandle>();





            /***** ******/


            /***** ******/
            //2-1.logic
            //services.AddScoped<JBHRIS.Api..ITestInterface, JBHRIS.Api.Service.Implement.TestService>();

            //2-2.dal
            //
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_Dept_View, JBHRIS.Api.Dal.ezFlow.Implement.System_Dept_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_Role_View, JBHRIS.Api.Dal.ezFlow.Implement.System_Role_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_Emp_View, JBHRIS.Api.Dal.ezFlow.Implement.System_Emp_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_Forms_View, JBHRIS.Api.Dal.ezFlow.Implement.System_Forms_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_FormsApp_View, JBHRIS.Api.Dal.ezFlow.Implement.System_FormsApp_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_FormsAppAbn_View, JBHRIS.Api.Dal.ezFlow.Implement.System_FormsAppAbn_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_FormsAppAbsc_View, JBHRIS.Api.Dal.ezFlow.Implement.System_FormsAppAbsc_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_FormsAppAbs_View, JBHRIS.Api.Dal.ezFlow.Implement.System_FormsAppAbs_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_FormsAppAppoint_View, JBHRIS.Api.Dal.ezFlow.Implement.System_FormsAppAppoint_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_FormsAppCard_View, JBHRIS.Api.Dal.ezFlow.Implement.System_FormsAppCard_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_FormsAppEmploy_View, JBHRIS.Api.Dal.ezFlow.Implement.System_FormsAppEmploy_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_FormsAppShiftShort_View, JBHRIS.Api.Dal.ezFlow.Implement.System_FormsAppShiftShort_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_FormsAppShiftLong_View, JBHRIS.Api.Dal.ezFlow.Implement.System_FormsAppShiftLong_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_FormsAppInfo_View, JBHRIS.Api.Dal.ezFlow.Implement.System_FormsAppInfo_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_FormsOT_View, JBHRIS.Api.Dal.ezFlow.Implement.System_FormsOT_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_ProcessId_View, JBHRIS.Api.Dal.ezFlow.Implement.System_ProcessId_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_SysVar_View, JBHRIS.Api.Dal.ezFlow.Implement.System_SysVar_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_FlowControl_View, JBHRIS.Api.Dal.ezFlow.Implement.System_FlowControl_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_QuestionDefaultMessage_View, JBHRIS.Api.Dal.ezFlow.Implement.System_QuestionDefaultMessage_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_QuestionMain_View, JBHRIS.Api.Dal.ezFlow.Implement.System_QuestionMain_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_QuestionReply_View, JBHRIS.Api.Dal.ezFlow.Implement.System_QuestionReply_View>();
            services.AddScoped<JBHRIS.Api.Dal.Interface.ISystem_QuestionCategory_View, JBHRIS.Api.Dal.ezFlow.Implement.System_QuestionCategory_View>();


            services.AddScoped<JBHRIS.Api.Dal.Interface.IFlowMainIntegrationHandler_Interface, JBHRIS.Api.Dal.ezFlow.Implement.FlowMainIntegrationHandler>();

            /***** ******/


            /***** ******/



            #region  ezEngineServices.core

            //2-2.Service
            // ezEngineServices.core
            services.AddScoped<JBHRIS.Api.Service.Interface.ezEngineServices.ICDataInterface, JBHRIS.Api.Service.Implement.ezEngineServices.CDataImplement>();
            services.AddScoped<JBHRIS.Api.Service.Interface.ezEngineServices.ICImageInterface, JBHRIS.Api.Service.Implement.ezEngineServices.CImageImplement>();
            services.AddScoped<JBHRIS.Api.Service.Interface.ezEngineServices.ICFlowManageInterface, JBHRIS.Api.Service.Implement.ezEngineServices.CFlowManageImplement>();
            services.AddScoped<JBHRIS.Api.Service.Interface.ezEngineServices.ICOrgInterface, JBHRIS.Api.Service.Implement.ezEngineServices.COrgImplement>();
            //2-2.dal
            // ezEngineServices.core
            services.AddScoped<JBHRIS.Api.Dal.ezEngineServices.Dao.IEmpDaoInterface, JBHRIS.Api.Dal.ezFlow.ezEngineServicesImplement.Dao.EmpDao>();
            services.AddScoped<JBHRIS.Api.Dal.ezEngineServices.ICData_Dal, JBHRIS.Api.Dal.ezFlow.ezEngineServicesImplement.CData>();
            services.AddScoped<JBHRIS.Api.Dal.ezEngineServices.ICFlowInterface, JBHRIS.Api.Dal.ezFlow.ezEngineServicesImplement.CFlow>();
            services.AddScoped<JBHRIS.Api.Dal.ezEngineServices.ICFlowManage_Dal, JBHRIS.Api.Dal.ezFlow.ezEngineServicesImplement.CFlowManage>();
            services.AddScoped<JBHRIS.Api.Dal.ezEngineServices.ICImage_Dal, JBHRIS.Api.Dal.ezFlow.ezEngineServicesImplement.CImage>();
            services.AddScoped<JBHRIS.Api.Dal.ezEngineServices.ICNoticeInterface, JBHRIS.Api.Dal.ezFlow.ezEngineServicesImplement.CNotice>();
            services.AddScoped<JBHRIS.Api.Dal.ezEngineServices.ICOrg_Dal, JBHRIS.Api.Dal.ezFlow.ezEngineServicesImplement.COrg>();
            services.AddScoped<JBHRIS.Api.Dal.ezEngineServices.ICProcess_Dal, JBHRIS.Api.Dal.ezFlow.ezEngineServicesImplement.CProcess>();
            services.AddScoped<JBHRIS.Api.Dal.ezEngineServices.IServiceInterface, JBHRIS.Api.Dal.ezFlow.ezEngineServicesImplement.Service>();
            #endregion ezEngineServices.core



            return services;

        }


    }
}
