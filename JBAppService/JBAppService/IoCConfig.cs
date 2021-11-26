using JBAppService.Api.Service.Implement;
using JBAppService.Api.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBAppService
{
    public class IoCConfig
    {

        public IoCConfig()
        {

        }

        public static IServiceCollection Configure(IConfiguration Configuration, IServiceCollection services)
        {
            //services.AddDbContext<Api.Dal.Models.StandardFoodsHR.StandardFoodsHRContext>(options => options.UseSqlServer(Configuration["HRConnectionStrings:DefaultConnection"]));
            //services.AddDbContext<ezEngineServices.core.Models.ezFlowContent.ezFlow_StandardFoodsContext>(options => options.UseSqlServer(Configuration["ezFlowConnectionStrings:DefaultConnection"]));
            //services.AddDbContext<ezFlow_StandardFoodsContext>(options => options.UseSqlServer(Configuration["ezFlowConnectionStrings:DefaultConnection"]));

            //Service
            services.AddScoped<IAttHandlerService, AttHandlerService>();
            services.AddScoped<IAuthHandlerService, AuthHandlerService>();
            services.AddScoped<IAuthorizeHandlerService, AuthorizeHandlerService>();
            services.AddScoped<IBaseHandlerService, BaseHandlerService>();
            services.AddScoped<ICardHandlerService, CardHandlerService>();
            services.AddScoped<ICertificationService, CertificationService>();
            services.AddScoped<IDeptHandlerService, DeptHandlerService>();
            /* 座標 */
            services.AddScoped<IFencePointsService, FencePointsService>();
            /* 照片 */
            services.AddScoped<IImagesService, ImagesService>();
            /* QRCode */
            services.AddScoped<IQRCodeInterface, QRCodeInterface>();
            /* wifi設定 */
            services.AddScoped<IBSSIDInterface, BSSIDService>();

            services.AddScoped<IAuthorizeHandlerService, AuthorizeHandlerService>();

            //HR_Dal 

            #region 抽換參考位置

            services.AddScoped<Api.Dal.Interface.IAttEndHandler, Api.Dal.Implement.HR.AttEndHandler>();
            services.AddScoped<Api.Dal.Interface.IBaseHandler, Api.Dal.Implement.HR.BaseHandler>();
            services.AddScoped<Api.Dal.Interface.ICardAppDetailsHandler, Api.Dal.Implement.App.HR.CardAppDetailsHandler>();

            //services.AddScoped<Api.Dal.Interface.IAttEndHandler, Api.Dal.Implement.EEP.AttEndHandler>();
            //services.AddScoped<Api.Dal.Interface.IBaseHandler, Api.Dal.Implement.EEP.BaseHandler>();
            //services.AddScoped<Api.Dal.Interface.ICardAppDetailsHandler, Api.Dal.Implement.App.EEP.CardAppDetailsHandler>();

            //services.AddScoped<Api.Dal.Interface.IAttEndHandler, Api.Dal.Implement.JB.AttEndHandler>();
            //services.AddScoped<Api.Dal.Interface.IBaseHandler, Api.Dal.Implement.JB.BaseHandler>();
            //services.AddScoped<Api.Dal.Interface.ICardAppDetailsHandler, Api.Dal.Implement.App.JB.CardAppDetailsHandler>();

            #endregion

            /* APP 設定檔 */
            services.AddScoped<Api.Dal.Interface.IAppSettingConfigurationHandler, Api.Dal.Implement.App.AppSettingConfigurationHandler>();
            services.AddScoped<Api.Dal.Interface.ICardAppImagesHandler, Api.Dal.Implement.App.CardAppImagesHandler>();
            services.AddScoped<Api.Dal.Interface.IEmpConfigurationHandler, Api.Dal.Implement.App.EmpConfigurationHandler>();
            /* 座標圍籬判斷 */
            services.AddScoped<Api.Dal.Interface.IFencePointsHandler, Api.Dal.Implement.App.FencePointsHandler>();
            /* 打卡資訊 */
            services.AddScoped<Api.Dal.Interface.IPunchCardTypeHandler, Api.Dal.Implement.App.PunchCardTypeHandler>();
            /* QRCode */
            services.AddScoped<Api.Dal.Interface.IQRCodeHandler, Api.Dal.Implement.App.QRCodeHandler>();
            /* wifi 設定 */
            services.AddScoped<Api.Dal.Interface.IBSSIDHandler, Api.Dal.Implement.App.BSSIDHandler>();
            services.AddScoped<Api.Dal.Interface.IAppRegistryKeyBindHandler, Api.Dal.Implement.App.AppRegistryKeyBindHandler>();


            ////EEP_Dal
            //services.AddScoped<Api.Dal.Interface.IAppSettingConfigurationHandler, Api.Dal.Implement.EEP.AppSettingConfigurationHandler>();
            //services.AddScoped<Api.Dal.Interface.IAttEndHandler, Api.Dal.Implement.EEP.AttEndHandler>();
            //services.AddScoped<Api.Dal.Interface.IBaseHandler, Api.Dal.Implement.EEP.BaseHandler>();
            //services.AddScoped<Api.Dal.Interface.ICardAppDetailsHandler, Api.Dal.Implement.EEP.CardAppDetailsHandler>();
            //services.AddScoped<Api.Dal.Interface.ICardAppImagesHandler, Api.Dal.Implement.EEP.CardAppImagesHandler>();
            //services.AddScoped<Api.Dal.Interface.ICardHandler, Api.Dal.Implement.EEP.CardHandler>();
            //services.AddScoped<Api.Dal.Interface.IDeptHandler, Api.Dal.Implement.EEP.DeptHandler>();
            //services.AddScoped<Api.Dal.Interface.IEmpConfigurationHandler, Api.Dal.Implement.EEP.EmpConfigurationHandler>();
            //services.AddScoped<Api.Dal.Interface.IFencePointsHandler, Api.Dal.Implement.EEP.FencePointsHandler>();
            //services.AddScoped<Api.Dal.Interface.IPunchCardTypeHandler, Api.Dal.Implement.EEP.PunchCardTypeHandler>();



            //2021/03/05 新增獨立資料庫
            services.AddDbContext<Api.Dal.Models.AppDBContext.AppDBContext>(options => options.UseSqlServer(Configuration["AppConnectionStrings:DefaultConnection"]));
            services.AddScoped<DbContext, Api.Dal.Models.AppDBContext.AppDBContext>();



            #region 抽換資料庫參考來源

            //HR
            services.AddDbContext<Api.Dal.Models.HRContent.JBHRContext>(options => options.UseSqlServer(Configuration["HRConnectionStrings:DefaultConnection"]));
            services.AddScoped<DbContext, Api.Dal.Models.HRContent.JBHRContext>();

            //EEP
            //services.AddDbContext<Api.Dal.Models.EEPContent.JBEEPContext>(options => options.UseSqlServer(Configuration["EEPConnectionStrings:DefaultConnection"]));
            //services.AddScoped<DbContext, Api.Dal.Models.EEPContent.JBEEPContext>();

            //  JBJOB DB for eep
            //services.AddDbContext<Api.Dal.Models.JBContent.JBDBContent>(options => options.UseSqlServer(Configuration["JBDBConnectionStrings:DefaultConnection"]));
            //services.AddScoped<DbContext, Api.Dal.Models.JBContent.JBDBContent>();

            #endregion

            return services;        
        }
        
    }
}
